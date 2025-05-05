using SpeculationApp.Maui.Code.Views;

namespace SpeculationApp.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("mainMenu", typeof(MainMenuView));

            Routing.RegisterRoute("currencyMenu", typeof(CurrencyMenuView));
            Routing.RegisterRoute("operationMenu", typeof(OperationMenuView));

            Routing.RegisterRoute("pairMenu", typeof(PairMenuView));
            Routing.RegisterRoute("convertationMenu", typeof(ConvertationMenuView));
        }
    }
}