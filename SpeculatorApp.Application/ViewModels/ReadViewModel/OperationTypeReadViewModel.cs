using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels.EditViewModels
{
    public class OperationTypeReadViewModel : ViewModel
    {
        private readonly IUnitOfWork _unitOfWork;

        private OperationTypeModel _model;

        public OperationTypeReadViewModel(IUnitOfWork unitOfWork, OperationTypeModel model)
        {
            _unitOfWork = unitOfWork;
            _model = model;
        }

        public int Id => _model.Id;
        public string Name => _model.Name;
        public bool IsIncrease => _model.IsIncrease;

        public void RefreshData()
        {
            _model = _unitOfWork.OperationTypes.GetById(_model.Id);
            OnPropertyChanged(string.Empty);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
