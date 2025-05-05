using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpeculationApp.Wpf.Views
{
    /// <summary>
    /// Логика взаимодействия для ConvertationMenuView.xaml
    /// </summary>
    public partial class ConvertationMenuView : UserControl
    {
        public ConvertationMenuView()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            BindingExpression be;

            be = BaseAmountBox.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();

            be = TradeAmountBox.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();

            be = DateBox.GetBindingExpression(DatePicker.SelectedDateProperty);
            be.UpdateSource();
        }
    }
}
