using SpeculatorApp.Application.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly MenuStore _menuStore;

        public MainViewModel(MenuStore menuStore)
        {
            _menuStore = menuStore;
            _menuStore.MenuChanged += OnMenuChanged;
        }

        public ViewModel? CurrentMenu => _menuStore.CurrentMenu;

        private void OnMenuChanged()
        {
            OnPropertyChanged(nameof(CurrentMenu));
        }
    }
}
