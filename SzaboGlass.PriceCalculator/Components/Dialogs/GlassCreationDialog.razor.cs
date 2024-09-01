using Microsoft.AspNetCore.Components;
using MudBlazor;
using SzaboGlass.Data.Dtos;
using SzaboGlass.Logic.Interfaces;

namespace SzaboGlass.PriceCalculator.Components.Dialogs
{
    public partial class GlassCreationDialog
    {
        [Inject] private IGlassService GlassService { get; set; } = default!;
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; } = default!;
        [CascadingParameter] public InformationLogger InformationLogger { get; set; } = default!;

        [Parameter] public int glassTypeId { get; set; }
        private GlassCreationDto Glass { get; set; } = new();

        private async void Submit()
        {
            try
            {
                await GlassService.CreateGlass(Glass, glassTypeId);
                InformationLogger.LogInformation("Sikeres hozzáadás!");
                MudDialog.Close(DialogResult.Ok(true));
            }
            catch (Exception ex)
            {
                InformationLogger.LogError(ex);
            }
        }

        private void Cancel() => MudDialog.Cancel();
    }
}
