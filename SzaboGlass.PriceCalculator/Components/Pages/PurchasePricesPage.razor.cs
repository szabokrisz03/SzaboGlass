using Microsoft.AspNetCore.Components;
using MudBlazor;
using SzaboGlass.Data.Dtos;
using SzaboGlass.Logic.Interfaces;
using SzaboGlass.PriceCalculator.Components;
using SzaboGlass.PriceCalculator.Components.Dialogs;

namespace SzaboGlass.PriceCalculator.Components.Pages
{
    public partial class PurchasePricesPage
    {
        [Inject] private IGlassService GlassService { get; set; } = default!;
        [Inject] private IDialogService DialogService { get; set; } = default!;

        [Parameter] public int Id { get; set; }

        private MudDataGrid<GlassDto> _dataGrid = default!;
        private List<GlassDto> glasses = new List<GlassDto>();
        private GlassTypeDto glassType = new();

        private async Task<GridData<GlassDto>> RefreshServerData(GridState<GlassDto> state)
        {
            var glassType = await GetGlassTypeByIdAsync(Id);
            var glasses = await GetGlasses(glassType.Id);
            var totalItems = glasses.Count();

            return new GridData<GlassDto>
            {
                TotalItems = totalItems,
                Items = glasses,
            };
        }

        private async Task OpenDialogAsync()
        {
            var parameters = new DialogParameters
            {
                ["glassTypeId"] = Id,
            };

            var dialog = await DialogService.ShowAsync<GlassCreationDialog>("Üveg hozzáadása", parameters);
            await dialog.Result;
            await _dataGrid.ReloadServerData();
        }

        private async Task<List<GlassDto>> GetGlasses(int glassTypeId)
        {
            var glasses = await GlassService.GetGlasses(glassTypeId);
            return glasses;
        }

        private async Task<GlassTypeDto> GetGlassTypeByIdAsync(int glassTypeId)
        {
            return await GlassService.GetGlassTypeByIdAsync(glassTypeId);
        }
    }
}
