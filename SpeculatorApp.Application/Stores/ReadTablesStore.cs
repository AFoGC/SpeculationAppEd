using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Stores
{
    public class ReadTablesStore
    {
        public ObservableCollection<CurrencyReadViewModel> Currencies { get; }
        public ObservableCollection<PairReadViewModel> Pairs { get; }
        public ObservableCollection<OperationTypeReadViewModel> OperationTypes { get; }

        public ReadTablesStore()
        {
            Currencies = new ObservableCollection<CurrencyReadViewModel>();
            Pairs = new ObservableCollection<PairReadViewModel>();
            OperationTypes = new ObservableCollection<OperationTypeReadViewModel>();
        }

        public void RefreshCurrency(int currencyId)
        {
            Currencies.Single(x => x.Id == currencyId).RefreshData();
        }

        /*
        public void RefreshPair(int baseCurrencyId, int tradeCurrencyId)
        {
            Pairs.Single(x => x.BaseCurrencyId == baseCurrencyId && x.TradeCurrencyId == tradeCurrencyId);
        }
        */
    }
}
