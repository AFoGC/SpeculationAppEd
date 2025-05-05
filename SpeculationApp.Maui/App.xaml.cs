using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SpeculationApp.Domain.Repositories;
using SpeculationApp.Infrastructure.Context;
using SpeculationApp.Infrastructure.Repositories;
using SpeculationApp.Maui.Code.Services;
using SpeculationApp.Maui.Code.WindowsService;
using SpeculatorApp.Application.Factories;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels;
using SpeculatorApp.Application.WindowServices;
using System.Diagnostics;
using System.Reflection;

namespace SpeculationApp.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            /*
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
            navigationService.AddMenu("mainMenu", mainMenu);

            CurrencyMenuViewModel currencyMenu = new CurrencyMenuViewModel(navigationService, currencyService);
            navigationService.AddMenu("currencyMenu", currencyMenu);

            OperationMenuViewModel operationMenu = new OperationMenuViewModel(navigationService, store);
            navigationService.AddMenu("operationMenu", operationMenu);

            PairMenuViewModel pairMenu = new PairMenuViewModel(navigationService, pairService);
            navigationService.AddMenu("pairMenu", pairMenu);

            ConvertationMenuViewModel convertationMenu = new ConvertationMenuViewModel(navigationService);
            navigationService.AddMenu("convertationMenu", convertationMenu);

            MainViewModel mainViewModel = new MainViewModel(menuStore);

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
            */

            MainPage = new AppShell();

            //navigationService.Navigate<MainMenuViewModel>();
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            HandleGlobalException(exception, "AppDomain.UnhandledException");
        }

        private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            HandleGlobalException(e.Exception, "TaskScheduler.UnobservedTaskException");
            e.SetObserved(); // предотвращает падение приложения
        }

        private void HandleGlobalException(Exception ex, string source)
        {
            // Логируем или показываем сообщение
            Debug.WriteLine($"[GLOBAL EXCEPTION] ({source}) {ex}");

            // Пример — показать алерт (только если UI доступен):
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", ex.ToString(), "ОК");
            });

            // Также можно логировать в файл, отправлять в AppCenter, Sentry и т.п.
        }
    }
}