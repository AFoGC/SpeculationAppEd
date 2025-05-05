using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.Commands;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using SpeculatorApp.Application.WindowServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpeculatorApp.Application.ViewModels
{
    public class MainMenuViewModel : ViewModel
    {
        private readonly INavigationService _navigation;
        private readonly MainMenuService _menuService;
        private readonly IAddPairWindowService _addPairService;

        public MainMenuViewModel(INavigationService navigation, MainMenuService menuService, IAddPairWindowService addPairService)
        {
            _navigation = navigation;
            _menuService = menuService;
            _addPairService = addPairService;

            NavigateToCurrencyCommand = new RelayCommand(NavigateToCurrency);
            NavigateToPairCommand = new RelayCommand(NavigateToPair);
            AddPairCommand = new RelayCommand(CreatePair);
            AddCurrencyCommand = new RelayCommand(CreateCurrency);
        }

        public ICommand NavigateToCurrencyCommand { get; }
        public ICommand NavigateToPairCommand { get; }
        public ICommand AddPairCommand { get; }
        public ICommand AddCurrencyCommand { get; }

        public ObservableCollection<CurrencyReadViewModel> Currencies => _menuService.Currencies;
        public ObservableCollection<PairReadViewModel> Pairs => _menuService.Pairs;

        public void LoadData()
        {
            _menuService.LoadData();
        }

        public void RefreshData()
        {
            foreach (var currency in _menuService.Currencies)
                currency.RefreshData();
        }

        public void NavigateToCurrency(object? obj)
        {
            CurrencyReadViewModel? currency = obj as CurrencyReadViewModel;

            if (currency == null)
                throw new NullReferenceException();

            _navigation
                .Navigate<CurrencyMenuViewModel>()
                .LoadCurrency(currency.Id);
        }

        public void NavigateToPair(object? obj)
        {
            PairReadViewModel? pair = obj as PairReadViewModel;

            if (pair == null)
                throw new NullReferenceException();

            _navigation
                .Navigate<PairMenuViewModel>()
                .LoadPair(pair.BaseCurrencyId, pair.TradeCurrencyId);
        }

        public void CreateCurrency(object? obj)
        {
            _menuService.CreateCurrency();
        }

        public void CreatePair(object? obj)
        {
            PairCreationInfo? pair = _addPairService.GetInfo();

            if (pair != null)
                _menuService.CreatePair(pair.BaseCurrency, pair.TradeCurrency);
        }
    }
}
