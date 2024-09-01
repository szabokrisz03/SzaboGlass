using Microsoft.AspNetCore.Components;
using SzaboGlass.Data.Dtos;
using SzaboGlass.Data.Entity;
using SzaboGlass.Logic.Interfaces;

namespace SzaboGlass.PriceCalculator.Components.Layout
{
    public partial class NavMenu
    {
        [Inject] private IGlassService GlassService { get; set; } = default!;
        [Inject] private NavigationManager NavigationManager { get; set; }

        private bool _isExpanded = false;
        private List<GlassTypeDto> glassTypes = new();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                glassTypes = await GetGlassTypes();
            }
        }

        private async Task<List<GlassTypeDto>> GetGlassTypes()
        {
            return await GlassService.GetGlassTypes();
        }

        private void NavigateToPage(GlassTypeDto glassType)
        {
            NavigationManager.NavigateTo($"/beszerzesi_ar/{glassType.Id}", true);
        }
    }
}
