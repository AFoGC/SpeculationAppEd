using SpeculatorApp.Application.Commands;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpeculatorApp.Application.ViewModels
{
    public class PairMenuViewModel : ViewModel
    {
        private readonly INavigationService _navigation;
        private readonly PairService _pairService;

        private PairEditViewModel? _pair;
        private ConvertationEditViewModel? _selectedConvertation;

        public PairMenuViewModel(INavigationService navigation, PairService pairService)
        {
            _navigation = navigation;
            _pairService = pairService;

            NavigateToMainMenuCommand = new RelayCommand(ToMainMenu);
            AddConvertationCommand = new RelayCommand(AddConvertation);
            RemoveConvertationCommand = new RelayCommand(RemoveConvertation);
            EditConvertationCommand = new RelayCommand(EditConvertation);
        }

        public ICommand NavigateToMainMenuCommand { get; }
        public ICommand AddConvertationCommand { get; }
        public ICommand RemoveConvertationCommand { get; }
        public ICommand EditConvertationCommand { get; }

        public PairEditViewModel? Pair
        {
            get => _pair;
            private set { _pair = value; OnPropertyChanged(); }
        }

        public ConvertationEditViewModel? SelectedConvertation
        {
            get => _selectedConvertation;
            set { _selectedConvertation = value; OnPropertyChanged(); }
        }

        public void LoadPair(int baseCurrencyId, int tradeCurrencyId)
        {
            Pair = _pairService.LoadPair(baseCurrencyId, tradeCurrencyId);
        }

        public void ToMainMenu(object? obj)
        {
            //Pair?.Update();

            Pair = null;
            SelectedConvertation = null;

            _navigation.Navigate<MainMenuViewModel>();
        }

        public void AddConvertation(object? obj)
        {
            if (Pair != null)
            {
                _pairService.AddConvertation(Pair);
            }
        }

        public void RemoveConvertation(object? obj)
        {
            if (Pair != null && SelectedConvertation != null)
            {
                _pairService.RemoveConvertation(Pair, SelectedConvertation);
            }
        }

        public void EditConvertation(object? obj)
        {
            if (Pair != null && SelectedConvertation != null)
            {
                var menu = _navigation.Navigate<ConvertationMenuViewModel>();

                menu.Pair = Pair;
                menu.Convertation = SelectedConvertation;
            }
        }
    }
}
