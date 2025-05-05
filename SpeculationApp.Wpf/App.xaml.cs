using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SpeculationApp.Domain.Repositories;
using SpeculationApp.Infrastructure.Context;
using SpeculationApp.Infrastructure.Repositories;
using SpeculationApp.Wpf.Services;
using SpeculationApp.Wpf.Windows;
using SpeculationApp.Wpf.WindowsService;
using SpeculatorApp.Application.Factories;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels;
using SpeculatorApp.Application.WindowServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SpeculationApp.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            string connectionString = "Datasource=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)! + "\\Films.db";
            SqliteConnection connection = new SqliteConnection(connectionString);

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            var opt = optionsBuilder.UseSqlite(connection).Options;
            TradingContext tradingContext = new TradingContext(opt);
            tradingContext.Database.Migrate();

            IUnitOfWork unitOfWork = new UnitOfWork(tradingContext);
            ReadTablesStore store = new ReadTablesStore();

            EditViewModelFactory editViewModelFactory = new EditViewModelFactory(store, unitOfWork);
            ReadViewModelFactory readViewModelFactory = new ReadViewModelFactory(store, unitOfWork);

            MainMenuService mainMenuService = new MainMenuService(unitOfWork, store, readViewModelFactory);
            CurrencyService currencyService = new CurrencyService(unitOfWork, store, editViewModelFactory);
            PairService pairService = new PairService(unitOfWork, store, editViewModelFactory);

            MenuStore menuStore = new MenuStore();
            NavigationService navigationService = new NavigationService(menuStore);

            IAddPairWindowService addPairService = new AddPairWindowService(store);

            MainMenuViewModel mainMenu = new MainMenuViewModel(navigationService, mainMenuService, addPairService);
            navigationService.AddMenu(mainMenu);

            CurrencyMenuViewModel currencyMenu = new CurrencyMenuViewModel(navigationService, currencyService);
            navigationService.AddMenu(currencyMenu);

            PairMenuViewModel pairMenu = new PairMenuViewModel(navigationService, pairService);
            navigationService.AddMenu(pairMenu);

            OperationMenuViewModel operationMenu = new OperationMenuViewModel(navigationService, store);
            navigationService.AddMenu(operationMenu);

            ConvertationMenuViewModel convertationMenu = new ConvertationMenuViewModel(navigationService);
            navigationService.AddMenu(convertationMenu);

            MainViewModel mainViewModel = new MainViewModel(menuStore);

            MainWindow = new MainWindow()
            {
                DataContext = mainViewModel
            };

            mainMenu.LoadData();
            navigationService.Navigate<MainMenuViewModel>();

            MainWindow.Show();
            base.OnStartup(e);
        }


    }
}
