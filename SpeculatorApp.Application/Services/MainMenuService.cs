using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Factories;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Services
{
    public class MainMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;
        private readonly ReadViewModelFactory _factory;

        public MainMenuService(IUnitOfWork unitOfWork, ReadTablesStore tablesStore, ReadViewModelFactory factory)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;
            _factory = factory;
        }

        public ObservableCollection<CurrencyReadViewModel> Currencies => _tablesStore.Currencies;
        public ObservableCollection<PairReadViewModel> Pairs => _tablesStore.Pairs;

        public void LoadData()
        {
            _tablesStore.Currencies.Clear();
            _tablesStore.Pairs.Clear();
            _tablesStore.OperationTypes.Clear();

            IEnumerable<CurrencyModel> currencies = _unitOfWork.Currencies.GetAll();
            IEnumerable<PairModel> pairs = _unitOfWork.Pairs.GetAll();
            IEnumerable<OperationTypeModel> operationTypes = _unitOfWork.OperationTypes.GetAll();

            foreach (var currency in currencies)
            {
                _tablesStore.Currencies.Add(_factory.CreateCurrency(currency));
            }

            foreach (var pair in pairs)
            {
                _tablesStore.Pairs.Add(_factory.CreatePair(pair));
            }

            foreach (var operationType in operationTypes)
            {
                _tablesStore.OperationTypes.Add(_factory.CreateOperationType(operationType));
            }
        }

        public void CreateCurrency()
        {
            CurrencyModel model = new CurrencyModel()
            {
                Id = 0,
                Code = "NC",
                Name = "New Currency"
            };

            _unitOfWork.Currencies.Create(model);
            _unitOfWork.Complete();

            _tablesStore.Currencies.Add(_factory.CreateCurrency(model));
        }

        public void CreatePair(int baseCurrencyId, int tradeCurrencyId)
        {
            bool pairNotCreated = _tablesStore.Pairs.All(x => x.IsEquivalentPair(baseCurrencyId, tradeCurrencyId) == false);

            if (pairNotCreated)
            {
                PairModel pairModel = new PairModel()
                {
                    BaseCurrencyId = baseCurrencyId,
                    TradeCurrencyId = tradeCurrencyId
                };

                _unitOfWork.Pairs.Create(pairModel);
                _unitOfWork.Complete();

                _tablesStore.Pairs.Add(_factory.CreatePair(pairModel));
            }
        }
    }
}
