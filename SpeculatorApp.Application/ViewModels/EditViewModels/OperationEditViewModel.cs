using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.Services.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels.EditViewModels
{
    public class OperationEditViewModel : ViewModel
    {
        private readonly OperationUpdateService _updateService;

        private OperationModel _model;
        private bool _isChanged;

        private OperationTypeReadViewModel _operationType;

        public OperationEditViewModel(OperationModel model, IEnumerable<OperationTypeReadViewModel> operationTypes, OperationUpdateService updateService)
        {
            _model = model;
            _updateService = updateService;

            var type = operationTypes.Single(x => x.Id == _model.OperationTypeId);
            _operationType = type;
        }

        public bool IsChanged
        {
            get => _isChanged;
            private set
            {
                _isChanged = value;
                OnPropertyChanged();
            }
        }

        public int Id => _model.Id;
        public int CurrencyId => _model.CurrencyId;
        public int OperationTypeId => _model.OperationTypeId;
        public decimal Amount
        {
            get => _model.Amount;
            set
            {
                if (_model.Amount != value)
                {
                    _model.Amount = value;
                    IsChanged = true;

                    OnPropertyChanged();
                }
            }
        }
        public DateTime Date
        {
            get => _model.Date;
            set
            {
                _model.Date = value;
                IsChanged = true;

                OnPropertyChanged();
            }
        }

        public OperationTypeReadViewModel OperationType
        {
            get => _operationType;
            set
            {
                _operationType = value;
                _model.OperationTypeId = value.Id;
                IsChanged = true;

                OnPropertyChanged();
            }
        }

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
