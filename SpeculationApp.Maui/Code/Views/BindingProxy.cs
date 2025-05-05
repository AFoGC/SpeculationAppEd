//using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Maui.Code.Views
{
    public class BindingProxy : BindableObject
    {
        public static readonly BindableProperty DataProperty =
            BindableProperty.Create(
                nameof(Data),
                typeof(object),
                typeof(BindingProxy),
                null);

        public object Data
        {
            get => GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
    }
}
