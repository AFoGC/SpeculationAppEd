using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Factories
{
    public class ReadViewModelFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;

        public ReadViewModelFactory(ReadTablesStore tablesStore, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;
        }

        public CurrencyReadViewModel CreateCurrency(CurrencyModel model)
        {
            return new CurrencyReadViewModel(_unitOfWork, model);
        }

        public PairReadViewModel CreatePair(PairModel model)
        {
            var baseCurrency = _tablesStore.Currencies.Single(x => x.Id == model.BaseCurrencyId);
            var tradeCurrency = _tablesStore.Currencies.Single(x => x.Id == model.TradeCurrencyId);

            return new PairReadViewModel(model, baseCurrency, tradeCurrency);
        }

        public OperationTypeReadViewModel CreateOperationType(OperationTypeModel operationType)
        {
            return new OperationTypeReadViewModel(_unitOfWork, operationType);
        }
    }
}
