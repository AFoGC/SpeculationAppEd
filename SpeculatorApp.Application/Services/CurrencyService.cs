using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Factories;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Services
{
    public class CurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;
        private readonly EditViewModelFactory _factory;

        public CurrencyService(IUnitOfWork unitOfWork, ReadTablesStore tablesStore, EditViewModelFactory factory)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;
            _factory = factory;
        }

        public CurrencyEditViewModel LoadCurrency(int currencyId)
        {
            IEnumerable<OperationTypeReadViewModel> operationTypes = _tablesStore.OperationTypes;
            CurrencyModel model = _unitOfWork.Currencies.GetById(currencyId);

            var operations = _unitOfWork.Operations
                .GetAll(currencyId)
                .Select(x => _factory.CreateOperation(x, operationTypes));

            return _factory.CreateCurrency(model, operations);
        }

        public void AddOperation(CurrencyEditViewModel viewModel)
        {
            int operationTypeId = _tablesStore.OperationTypes.First().Id;

            OperationModel operation = new OperationModel()
            {
                Id = 0,
                CurrencyId = viewModel.Id,
                OperationTypeId = operationTypeId,
                Date= DateTime.Now,
                Amount = 0
            };

            _unitOfWork.Operations.Create(operation);
            _unitOfWork.Complete();

            var operationViewModel = _factory.CreateOperation(operation, _tablesStore.OperationTypes);
            viewModel.Operations.Add(operationViewModel);
        }

        public void RemoveOperation(CurrencyEditViewModel currency, OperationEditViewModel operation)
        {
            _unitOfWork.Operations.Delete(operation.Id);
            _unitOfWork.Complete();

            currency.Operations.Remove(operation);
        }
    }
}
