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
    public class PairService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;
        private readonly EditViewModelFactory _factory;

        public PairService(IUnitOfWork unitOfWork, ReadTablesStore tablesStore, EditViewModelFactory factory)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;
            _factory = factory;
        }

        public PairEditViewModel LoadPair(int baseCurrencyId, int tradeCurrencyId)
        {
            PairModel pairModel = _unitOfWork.Pairs.GetById(baseCurrencyId, tradeCurrencyId);
            CurrencyReadViewModel baseCurrency = _tablesStore.Currencies.Single(x => x.Id == baseCurrencyId);
            CurrencyReadViewModel tradeCurrency = _tablesStore.Currencies.Single(x => x.Id == tradeCurrencyId);

            var convertations = _unitOfWork.Convertations
                .GetAll(baseCurrencyId, tradeCurrencyId)
                .Select(x => _factory.CreateConvertation(x));

            return _factory.CreatePair(baseCurrency, tradeCurrency, convertations);
        }

        public void AddConvertation(PairEditViewModel viewModel)
        {
            ConvertationModel convertation = new ConvertationModel()
            {
                Id = 0,
                BaseCurrencyId = viewModel.BaseCurrency.Id,
                TradeCurrencyId = viewModel.TradeCurrency.Id,
                BaseCurrencyAmount = 0,
                TradeCurrencyAmount = 0,
                Date = DateTime.Now
            };

            _unitOfWork.Convertations.Create(convertation);
            _unitOfWork.Complete();

            var operationViewModel = _factory.CreateConvertation(convertation);
            viewModel.Convertations.Add(operationViewModel);
        }

        public void RemoveConvertation(PairEditViewModel pair, ConvertationEditViewModel convertation)
        {
            _unitOfWork.Convertations.Delete(convertation.Id);
            _unitOfWork.Complete();

            pair.Convertations.Remove(convertation);
        }
    }
}
