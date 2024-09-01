using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using SzaboGlass.Data;
using SzaboGlass.Data.Dtos;
using SzaboGlass.Data.Entity;
using SzaboGlass.Logic.Interfaces;

namespace SzaboGlass.Logic.Services
{
    public class GlassService : IGlassService
    {
        private readonly Program _context;
        private readonly IMapper _mapper;
        
        public GlassService(IMapper mapper, Program dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public async Task<List<GlassTypeDto>> GetGlassTypes()
        {
            var glassTypes = await _context.GlassTypes.ToListAsync();
            return _mapper.Map<List<GlassType>, List<GlassTypeDto>>(glassTypes);
        }

        public async Task<GlassDto> GetGlassByIdAsync(int glassId)
        {
            var glass = await _context.Glasses.Include(x => x.GlassType).FirstOrDefaultAsync(x => x.Id == glassId);
            return _mapper.Map<GlassDto>(glass);
        }

        public async Task<GlassTypeDto> GetGlassTypeByIdAsync(int glassTypeId)
        {
            var glassType = await _context.GlassTypes
                .FirstOrDefaultAsync(x => x.Id == glassTypeId);

            return _mapper.Map<GlassTypeDto>(glassType);
        }

        public async Task<List<GlassDto>> GetGlasses(int glassTypeId)
        {
            var glasses = await _context.Glasses
                .Include(x => x.GlassType)
                .Where(x => x.GlassTypeId == glassTypeId)
                .ToListAsync();

            return _mapper.Map<List<Glass>, List<GlassDto>>(glasses);
        }

        public async Task<GlassDto> CreateGlass(GlassCreationDto glassCreationDto, int glassTypeId)
        {
            CheckGlassNameNotEmpty(glassCreationDto);
            CheckPurchasePrizes(glassCreationDto.PurchasePriceCE, glassCreationDto.PurchasePriceMalyi);
            var glassEnt = _mapper.Map<Glass>(glassCreationDto);
            glassEnt.GlassTypeId = glassTypeId;
            _context.Glasses.Add(glassEnt);
            await _context.SaveChangesAsync();

            await CheckGlassExist(glassEnt.Id);
            return await GetGlassByIdAsync(glassEnt.Id);
        }

        private async Task CheckGlassExist(int glassId)
        {
            var glass = await _context.Glasses.AnyAsync(x => x.Id == glassId);

            if(!glass)
            {
                throw new Exception("Ilyen üveg nem létezik! (Keresd a fiad, mert baj van)");
            }
        }

        private void CheckGlassNameNotEmpty(GlassCreationDto glass)
        {
            if(string.IsNullOrEmpty(glass.Name))
            {
                //TODO: Exception
                throw new Exception("Az üveg neve nem lehet üres!");
            }
        }

        private void CheckPurchasePrizes(int? beszAr1, int? beszAr2)
        {
            if(beszAr1 == null && beszAr2 == null)
            {
                throw new Exception("Legalább egy beszerzési árat meg kell adnod!");
            }
        }
    }
}
