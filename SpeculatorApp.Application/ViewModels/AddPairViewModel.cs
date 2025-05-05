using SpeculatorApp.Application.Commands;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using SpeculatorApp.Application.WindowServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpeculatorApp.Application.ViewModels
{
    public class AddPairViewModel : ViewModel
    {
        readonly ReadTablesStore _tablesStore;

        private CurrencyReadViewModel? _selectedBaseCurrency;
        private CurrencyReadViewModel? _selectedTradeCurrency;

        public AddPairViewModel(ReadTablesStore tablesStore)
        {
            _tablesStore = tablesStore;
            BaseCurrencies = _tablesStore.Currencies;

            CreateNewPairCommand = new RelayCommand(CreateNewPair);
        }

        public PairCreationInfo? PairInfo { get; private set; }
        public IEnumerable<CurrencyReadViewModel> BaseCurrencies { get; private set; }
        public IEnumerable<CurrencyReadViewModel>? TradeCurrencies { get; private set; }

        public ICommand CreateNewPairCommand { get; }

        public CurrencyReadViewModel? SelectedBaseCurrency
        {
            get => _selectedBaseCurrency;
            set
            {
                _selectedBaseCurrency = value;

                if (value != null)
                {
                    TradeCurrencies = GetAvaibleCurrencies(value);
                }
                else
                {
                    TradeCurrencies = null;
                }

                OnPropertyChanged(nameof(TradeCurrencies));
                SelectedTradeCurrency = null;

                OnPropertyChanged();
            }
        }

        public CurrencyReadViewModel? SelectedTradeCurrency
        {
            get => _selectedTradeCurrency;
            set
            {
                _selectedTradeCurrency = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<CurrencyReadViewModel> GetAvaibleCurrencies(CurrencyReadViewModel currency)
        {
            List<CurrencyReadViewModel> notAvailableCurrencies = new List<CurrencyReadViewModel>();

            foreach (var pair in _tablesStore.Pairs)
            {
                var oppositeCurrency = GetOppositeCurrency(pair, currency);

                if (oppositeCurrency != null)
                    notAvailableCurrencies.Add(oppositeCurrency);
            }

            return _tablesStore.Currencies
                .Where(x => notAvailableCurrencies.Contains(x) == false)
                .Where(x => x != currency);
        }

        private CurrencyReadViewModel? GetOppositeCurrency(PairReadViewModel pair, CurrencyReadViewModel currency)
        {
            if (pair.BaseCurrencyId == currency.Id)
            {
                return pair.TradeCurrency;
            }

            if (pair.TradeCurrencyId == currency.Id)
            {
                return pair.BaseCurrency;
            }

            return null;
        }

        public void CreateNewPair(object? obj)
        {
            if (_selectedBaseCurrency == null || _selectedTradeCurrency == null)
                throw new NullReferenceException();

            PairInfo = new PairCreationInfo
            {
                BaseCurrency = _selectedBaseCurrency.Id,
                TradeCurrency = _selectedTradeCurrency.Id
            };
        }
    }
}
