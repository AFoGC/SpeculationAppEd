using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Maui.Code.Windows
{
    public class MenuTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MainMenuTemplate { get; set; }
        public DataTemplate PairMenuTemplate { get; set; }
        public DataTemplate CurrencyMenuTemplate { get; set; }
        public DataTemplate OperationMenuTemplate { get; set; }
        public DataTemplate ConvertationMenuTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return item switch
            {
                MainMenuViewModel => MainMenuTemplate,
                PairMenuViewModel => PairMenuTemplate,
                CurrencyMenuViewModel => CurrencyMenuTemplate,
                OperationMenuViewModel => OperationMenuTemplate,
                ConvertationMenuViewModel => ConvertationMenuTemplate,
                _ => null
            };
        }
    }
}
