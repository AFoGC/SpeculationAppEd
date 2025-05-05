using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Services.Update;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Factories
{
    public class EditViewModelFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;

        private readonly ConvertationUpdateService _convertationUpdateService;
        private readonly CurrencyUpdateService _currencyUpdateService;
        private readonly OperationUpdateService _operationUpdateService;
        private readonly PairUpdateService _pairUpdateService;

        public EditViewModelFactory(ReadTablesStore tablesStore, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;

            _convertationUpdateService = new ConvertationUpdateService(unitOfWork, tablesStore);
            _currencyUpdateService = new CurrencyUpdateService(unitOfWork, tablesStore);
            _operationUpdateService = new OperationUpdateService(unitOfWork, tablesStore);
            _pairUpdateService = new PairUpdateService(unitOfWork, tablesStore);
        }

        public CurrencyEditViewModel CreateCurrency(CurrencyModel model, IEnumerable<OperationEditViewModel> operations)
        {
            return new CurrencyEditViewModel(model, operations, _currencyUpdateService);
        }

        public OperationEditViewModel CreateOperation(OperationModel model, IEnumerable<OperationTypeReadViewModel> operationTypes)
        {
            return new OperationEditViewModel(model, operationTypes, _operationUpdateService);
        }

        public PairEditViewModel CreatePair(CurrencyReadViewModel baseCurrency, CurrencyReadViewModel tradeCurrency, IEnumerable<ConvertationEditViewModel> convertations)
        {
            return new PairEditViewModel(baseCurrency, tradeCurrency, convertations, _pairUpdateService);
        }

        public ConvertationEditViewModel CreateConvertation(ConvertationModel model)
        {
            return new ConvertationEditViewModel(model, _convertationUpdateService);
        }
    }
}
