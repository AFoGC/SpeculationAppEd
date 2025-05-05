using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels.EditViewModels
{
    public class OperationTypeEditViewModel : ViewModel
    {
        private OperationTypeModel _model;

        public OperationTypeEditViewModel(OperationTypeModel model)
        {
            _model = model;
        }

        public int Id => _model.Id;
        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                OnPropertyChanged();
            }
        }
        public bool IsIncrease
        {
            get => _model.IsIncrease;
            set
            {
                _model.IsIncrease = value;
                OnPropertyChanged();
            }
        }
    }
}
