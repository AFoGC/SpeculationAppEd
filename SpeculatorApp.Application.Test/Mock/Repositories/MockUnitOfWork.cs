using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Test.Mock.Repositories
{
    public class MockUnitOfWork : IUnitOfWork
    {
        public MockUnitOfWork(MockCurrencyRepository currencies, MockPairRepository pairs,
                              MockConvertationRepository convertations, MockOperationRepository operations,
                              MockOperationTypeRepository operationTypes)
        {
            Currencies = currencies;
            Pairs = pairs;
            Convertations = convertations;
            Operations = operations;
            OperationTypes = operationTypes;
        }

        public ICurrencyRepository Currencies { get; }
        public IPairRepository Pairs { get; }
        public IConvertationRepository Convertations { get; }
        public IOperationRepository Operations { get; }
        public IOperationTypeRepository OperationTypes { get; }

        public void Complete()
        {
            //
        }

        public static MockUnitOfWork CreateWithTestData()
        {
            var currencies = new List<CurrencyModel>();
            currencies.Add(new CurrencyModel { Id = 1, Code = "USD", Name = "US Dollar" });
            currencies.Add(new CurrencyModel { Id = 2, Code = "EUR", Name = "Euro" });
            currencies.Add(new CurrencyModel { Id = 3, Code = "BTC", Name = "Bitcoin" });

            var pairs = new List<PairModel>();
            pairs.Add(new PairModel { BaseCurrencyId = 1, TradeCurrencyId = 2, PositionInList = 0 });
            pairs.Add(new PairModel { BaseCurrencyId = 1, TradeCurrencyId = 3, PositionInList = 1 });

            var convertations = new List<ConvertationModel>();
            convertations.Add(new ConvertationModel
            {
                Id = 1,
                BaseCurrencyId = 1,
                TradeCurrencyId = 2,
                BaseCurrencyAmount = 100,
                TradeCurrencyAmount = 90,
                ToTradeCurrency = true,
                Date = DateTime.Now.AddDays(-1)
            });
            convertations.Add(new ConvertationModel
            {
                Id = 2,
                BaseCurrencyId = 1,
                TradeCurrencyId = 2,
                BaseCurrencyAmount = 80,
                TradeCurrencyAmount = 85,
                ToTradeCurrency = false,
                Date = DateTime.Now
            });

            var operationTypes = new List<OperationTypeModel>();
            operationTypes.Add(new OperationTypeModel { Id = 1, Name = "Deposit", IsIncrease = true });
            operationTypes.Add(new OperationTypeModel { Id = 2, Name = "Withdrawal", IsIncrease = false });

            var operations = new List<OperationModel>();
            operations.Add(new OperationModel
            {
                Id = 1,
                OperationTypeId = 1,
                CurrencyId = 1,
                Amount = 500,
                Date = DateTime.Now.AddDays(-2)
            });
            operations.Add(new OperationModel
            {
                Id = 2,
                OperationTypeId = 2,
                CurrencyId = 2,
                Amount = 200,
                Date = DateTime.Now.AddDays(-1)
            });

            var currencyRepository = new MockCurrencyRepository(currencies);
            var pairRepository = new MockPairRepository(pairs);
            var convertationRepository = new MockConvertationRepository(convertations);
            var operationRepository = new MockOperationRepository(operations, operationTypes);
            var operationTypeRepository = new MockOperationTypeRepository(operationTypes);

            return new MockUnitOfWork(
                currencyRepository,
                pairRepository,
                convertationRepository,
                operationRepository,
                operationTypeRepository
            );
        }
    }
}
