using MudBlazor;

namespace SzaboGlass.PriceCalculator.Components.Layout
{
    public partial class MainLayout
    {
        private bool isOpen = true;

        private void DrawerToggle()
        {
            isOpen = !isOpen;
        }
    }
}
