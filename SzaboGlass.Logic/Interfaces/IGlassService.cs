using SzaboGlass.Data.Dtos;
using SzaboGlass.Data.Entity;

namespace SzaboGlass.Logic.Interfaces
{
    public interface IGlassService
    {
        /// <summary>
        ///     Lekéri az üveg típusokat
        /// </summary>
        Task<List<GlassTypeDto>> GetGlassTypes();

        /// <summary>
        ///     Lekéri az üveget azonosító alapján
        /// </summary>
        /// <param name="glassId"> A megadott azonosító</param>
        Task<GlassDto> GetGlassByIdAsync(int glassId);

        /// <summary>
        ///     Lekéri az üveg típusát a megadott azonosító alapján
        /// </summary>
        /// <param name="glassTypeId"> A típus azonosítója </param>
        Task<GlassTypeDto> GetGlassTypeByIdAsync(int glassTypeId);

        /// <summary>
        ///     Lekéri az üvegeket a megadott üvegtípus alapján
        /// </summary>
        /// <param name="glassTypeId"> Az üvegtípus, aminek az üvegeit le szeretnénk kérni</param>
        Task<List<GlassDto>> GetGlasses(int glassTypeId);

        /// <summary>
        ///     Üveg létrehozása
        /// </summary>
        /// <param name="glassCreationDto"> A létrehozandó üveg </param>
        /// <param name="glassTypeId"> Az üveg típusának azonosítója </param>
        Task<GlassDto> CreateGlass(GlassCreationDto glassCreationDto, int glassTypeId);
    }
}
