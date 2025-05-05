using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Stores
{
    public class MenuStore
    {
        private ViewModel? _currentMenu;

        public MenuStore()
        {

        }

        public event Action? MenuChanged;

        public ViewModel? CurrentMenu
        {
            get => _currentMenu;
            set { _currentMenu = value; MenuChanged?.Invoke(); }
        }
    }
}
