using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels.EditViewModels
{
    public class CurrencyReadViewModel : ViewModel
    {
        private readonly IUnitOfWork _unitOfWork;

        private CurrencyModel _model;

        public CurrencyReadViewModel(IUnitOfWork unitOfWork, CurrencyModel model)
        {
            _unitOfWork = unitOfWork;
            _model = model;
        }

        public int Id => _model.Id;
        public string Code => _model.Code;
        public string Name => _model.Name;
        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount = 0;

                totalAmount += _unitOfWork.Operations.GetCurrencyAmount(_model.Id);
                totalAmount += _unitOfWork.Convertations.GetBaseCurrencyAmount(_model.Id);
                totalAmount += _unitOfWork.Convertations.GetTradeCurrencyAmount(_model.Id);

                return totalAmount;
            }
        }

        public void RefreshData()
        {
            _model = _unitOfWork.Currencies.GetById(_model.Id);
            OnPropertyChanged(string.Empty);
        }

        public override string ToString()
        {
            return Code;
        }
    }
}
