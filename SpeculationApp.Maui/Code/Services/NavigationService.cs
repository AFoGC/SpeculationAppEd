using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Maui.Code.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, MenuInfo> _menus;
        private readonly MenuStore _menuStore;
        
        public NavigationService(MenuStore menuStore)
        {
            _menus = new Dictionary<Type, MenuInfo>();
            _menuStore = menuStore;
        }

        public bool AddMenu(string path, ViewModel viewModel)
        {
            Type type = viewModel.GetType();
            MenuInfo info = new MenuInfo(path, viewModel);

            if (_menus.ContainsKey(type))
                return false;

            _menus.Add(type, info);
            return true;
        }

        public T Navigate<T>() where T : ViewModel
        {
            Type type = typeof(T);
            var info = _menus[type];

            _menuStore.CurrentMenu = info.ViewModel;
            Shell.Current.GoToAsync(info.Path);

            return (T)info.ViewModel;
        }

        private class MenuInfo
        {
            public MenuInfo(string path, ViewModel viewModel)
            {
                Path = path;
                ViewModel = viewModel;
            }

            public string Path { get; }
            public ViewModel ViewModel { get; }
        }
    }


}
