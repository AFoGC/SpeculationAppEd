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
    public class ConvertationMenuViewModel : ViewModel
    {
        private readonly INavigationService _navigation;

        private ConvertationEditViewModel? _convertation;
        private PairEditViewModel? _pair;
        private IEnumerable<string>? _flowDirections;

        public ConvertationMenuViewModel(INavigationService navigation)
        {
            _navigation = navigation;

            GoBackCommand = new RelayCommand(GoBack);
            UpdateConvertationCommand = new RelayCommand(UpdateConvertation);
        }

        public ICommand GoBackCommand { get; }
        public ICommand UpdateConvertationCommand { get; }

        public PairEditViewModel? Pair
        {
            get => _pair;
            set 
            { 
                _pair = value;
                OnPropertyChanged();

                FlowDirections = GetFlowDirections(value);
            }
        }

        public ConvertationEditViewModel? Convertation
        {
            get => _convertation;
            set 
            { 
                _convertation = value; 
                OnPropertyChanged(); 
            }
        }

        public IEnumerable<string>? FlowDirections
        {
            get => _flowDirections;
            private set { _flowDirections = value; OnPropertyChanged(); }
        }

        public void GoBack(object? obj)
        {
            _navigation.Navigate<PairMenuViewModel>();
            Convertation?.RestoreModel();
        }

        public void UpdateConvertation(object? obj)
        {
            Convertation?.Update();
            _navigation.Navigate<PairMenuViewModel>();
        }

        private IEnumerable<string>? GetFlowDirections(PairEditViewModel? pair)
        {
            if (pair == null)
                return null;

            string toBaseCurrency = $"{pair.BaseCurrency.Code} <- {pair.TradeCurrency.Code}";
            string toTradeCurrency = $"{pair.BaseCurrency.Code} -> {pair.TradeCurrency.Code}";

            return new List<string>()
            {
                toBaseCurrency,
                toTradeCurrency
            };
        }
    }
}
