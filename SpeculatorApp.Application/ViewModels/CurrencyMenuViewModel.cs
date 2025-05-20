using SpeculatorApp.Application.Commands;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpeculatorApp.Application.ViewModels
{
    public class CurrencyMenuViewModel : ViewModel
    {
        private readonly INavigationService _navigation;
        private readonly CurrencyService _currencyService;

        private CurrencyEditViewModel? _currency;
        private OperationEditViewModel? _selectedOperation;

        public CurrencyMenuViewModel(INavigationService navigation, CurrencyService currencyService)
        {
            _navigation = navigation;
            _currencyService = currencyService;

            NavigateToMainMenuCommand = new RelayCommand(ToMainMenu);
            AddOperationCommand = new RelayCommand(AddOperation);
            RemoveOperationCommand = new RelayCommand(RemoveOperation);
            EditOperationCommand = new RelayCommand(EditOperation);
        }

        public ICommand NavigateToMainMenuCommand { get; }
        public ICommand AddOperationCommand { get; }
        public ICommand RemoveOperationCommand { get; }
        public ICommand EditOperationCommand { get; }

        public CurrencyEditViewModel? Currency
        {
            get => _currency;
            private set { _currency = value; OnPropertyChanged(); }
        }

        public OperationEditViewModel? SelectedOperation
        {
            get => _selectedOperation;
            set { _selectedOperation = value; OnPropertyChanged(); }
        }

        public void LoadCurrency(int currencyId)
        {
            Currency = _currencyService.LoadCurrency(currencyId);
        }

        public void ToMainMenu(object? obj)
        {
            Currency?.Update();

            Currency = null;
            SelectedOperation = null;

            _navigation.Navigate<MainMenuViewModel>();
        }

        public void AddOperation(object? obj)
        {
            if (Currency != null)
            {
                _currencyService.AddOperation(Currency);
            }
        }

        public void RemoveOperation(object? obj)
        {
            if (Currency != null && SelectedOperation != null)
            {
                _currencyService.RemoveOperation(Currency, SelectedOperation);
                Currency?.Update();
            }
        }

        public void EditOperation(object? obj)
        {
            if (Currency != null && SelectedOperation != null)
            {
                var menu = _navigation.Navigate<OperationMenuViewModel>();

                menu.Currency = Currency;
                menu.Operation = SelectedOperation;
            }
        }
    }
}
