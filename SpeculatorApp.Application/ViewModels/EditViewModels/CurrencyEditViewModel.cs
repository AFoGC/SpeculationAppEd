using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Services.Update;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels.EditViewModels
{
    public class CurrencyEditViewModel : ViewModel
    {
        private readonly ObservableCollection<OperationEditViewModel> _operations;
        private readonly CurrencyUpdateService _updateService;

        private CurrencyModel _model;
        private bool _isChanged;

        public CurrencyEditViewModel(CurrencyModel model, IEnumerable<OperationEditViewModel> operations, CurrencyUpdateService updateService)
        {
            _operations = new ObservableCollection<OperationEditViewModel>(operations);
            _updateService = updateService;

            _model = model;
        }

        public bool IsChanged
        {
            get => _isChanged;
            set
            {
                _isChanged = value;
                OnPropertyChanged();
            }
        }

        public int Id => _model.Id;
        public string Code
        {
            get => _model.Code;
            set
            {
                _model.Code = value;
                _isChanged = true;

                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                _isChanged = true;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<OperationEditViewModel> Operations => _operations;

        public void Update()
        {
            if (IsChanged)
            {
                _updateService.Update(_model);
                IsChanged = false;
            }
        }

        public void RestoreModel()
        {
            if (IsChanged)
            {
                _model = _updateService.RestoreModel(_model);
                _isChanged = false;

                OnPropertyChanged(String.Empty);
            }
        }
    }
}
