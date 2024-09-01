using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using MudBlazor;

namespace SzaboGlass.PriceCalculator.Components
{
    public partial class InformationLogger
    {
        [Inject] private ISnackbar Snackbar { get; set; } = default!;
        [Parameter] public RenderFragment? ChildContent { get; set; }

        public void LogError(Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
            StateHasChanged();
        }

        public void LogInformation(string message)
        {
            Snackbar.Add(message, Severity.Info);
            StateHasChanged();
        }
    }
}
