using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Factories;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.Test.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Test
{
    public class MainMenuServiceTests
    {
        public MainMenuServiceTests()
        {
            
        }

        [Fact]
        public void LoadData_ShouldLoadCurrenciesPairsAndOperationTypes()
        {
            // Arrange
            IUnitOfWork unitOfWork = MockUnitOfWork.CreateWithTestData();
            ReadTablesStore tablesStore = new ReadTablesStore();
            ReadViewModelFactory factory = new ReadViewModelFactory(tablesStore, unitOfWork);
            MainMenuService service = new MainMenuService(unitOfWork, tablesStore, factory);

            // Act
            service.LoadData();

            // Assert
            Assert.Equal(3, tablesStore.Currencies.Count);
            Assert.Equal(2, tablesStore.Pairs.Count);
            Assert.Equal(2, tablesStore.OperationTypes.Count);
        }

        [Fact]
        public void CreateCurrency_ShouldAddNewCurrency()
        {
            // Arrange
            IUnitOfWork unitOfWork = MockUnitOfWork.CreateWithTestData();
            ReadTablesStore tablesStore = new ReadTablesStore();
            ReadViewModelFactory factory = new ReadViewModelFactory(tablesStore, unitOfWork);
            MainMenuService service = new MainMenuService(unitOfWork, tablesStore, factory);

            // Act
            service.LoadData();
            service.CreateCurrency();

            // Assert
            var currency = tablesStore.Currencies.Last();
            Assert.Equal(4, tablesStore.Currencies.Count);
            Assert.Equal("NC", currency.Code);
            Assert.Equal("New Currency", currency.Name);
        }

        [Fact]
        public void CreatePair_ShouldAddNewPair_WhenNotExists()
        {
            // Arrange
            IUnitOfWork unitOfWork = MockUnitOfWork.CreateWithTestData();
            ReadTablesStore tablesStore = new ReadTablesStore();
            ReadViewModelFactory factory = new ReadViewModelFactory(tablesStore, unitOfWork);
            MainMenuService service = new MainMenuService(unitOfWork, tablesStore, factory);

            int baseCurrencyId = 2;
            int tradeCurrencyId = 3;

            // Act
            service.LoadData();
            int pairsCount = tablesStore.Pairs.Count;

            service.CreatePair(baseCurrencyId, tradeCurrencyId);

            // Assert
            var pair = tablesStore.Pairs.Last();
            var baseCurrency = tablesStore.Currencies.First(x => x.Id == baseCurrencyId);
            var tradeCurrency = tablesStore.Currencies.First(x => x.Id == tradeCurrencyId);

            Assert.Equal(pairsCount + 1, tablesStore.Pairs.Count);
            Assert.Equal(baseCurrency, pair.BaseCurrency);
            Assert.Equal(tradeCurrency, pair.TradeCurrency);
        }

        [Fact]
        public void CreatePair_ShouldNotAddDuplicatePair()
        {
            // Arrange
            IUnitOfWork unitOfWork = MockUnitOfWork.CreateWithTestData();
            ReadTablesStore tablesStore = new ReadTablesStore();
            ReadViewModelFactory factory = new ReadViewModelFactory(tablesStore, unitOfWork);
            MainMenuService service = new MainMenuService(unitOfWork, tablesStore, factory);

            int baseCurrencyId = 1;
            int tradeCurrencyId = 2;

            // Act
            service.LoadData();
            int pairsCount = tablesStore.Pairs.Count;

            service.CreatePair(baseCurrencyId, tradeCurrencyId);

            // Assert
            Assert.Equal(pairsCount, tablesStore.Pairs.Count);
        }
    }
}
