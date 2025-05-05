using SpeculationApp.Wpf.Windows;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels;
using SpeculatorApp.Application.WindowServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Wpf.WindowsService
{
    public class AddPairWindowService : IAddPairWindowService
    {
        readonly ReadTablesStore _tablesStore;

        public AddPairWindowService(ReadTablesStore tablesStore)
        {
            _tablesStore = tablesStore;
        }

        public PairCreationInfo? GetInfo()
        {
            AddPairViewModel viewModel = new AddPairViewModel(_tablesStore);
            AddPairWindow window = new AddPairWindow();

            window.DataContext = viewModel;
            window.ShowDialog();

            return viewModel.PairInfo;
        }
    }
}
