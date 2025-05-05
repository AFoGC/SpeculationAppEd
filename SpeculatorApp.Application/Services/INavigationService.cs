using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Services
{
    public interface INavigationService
    {
        public T Navigate<T>() where T : ViewModel;
    }
}
