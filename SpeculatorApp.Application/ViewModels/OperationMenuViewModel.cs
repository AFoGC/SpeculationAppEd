using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Commands;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpeculatorApp.Application.ViewModels
{
    public class OperationMenuViewModel : ViewModel
    {
        private readonly ReadTablesStore _tablesStore;
        private readonly INavigationService _navigation;

        private OperationEditViewModel? _operation;
        private CurrencyEditViewModel? _currency;

        public OperationMenuViewModel(INavigationService navigation, ReadTablesStore tablesStore)
        {
            _navigation = navigation;
            _tablesStore = tablesStore;

            GoBackCommand = new RelayCommand(GoBack);
            UpdateOperationCommand = new RelayCommand(UpdateOperation);
        }

        public ICommand GoBackCommand { get; }
        public ICommand UpdateOperationCommand { get; }

        public IEnumerable<OperationTypeReadViewModel> OperationTypes => _tablesStore.OperationTypes;

        public CurrencyEditViewModel? Currency
        {
            get => _currency;
            set { _currency = value; OnPropertyChanged(); }
        }

        public OperationEditViewModel? Operation
        {
            get => _operation;
            set { _operation = value; OnPropertyChanged(); }
        }

        public void GoBack(object? obj)
        {
            _navigation.Navigate<CurrencyMenuViewModel>();
            Operation?.RestoreModel();
        }

        public void UpdateOperation(object? obj)
        {
            Operation?.Update();
            _navigation.Navigate<CurrencyMenuViewModel>();
        }
    }
}
