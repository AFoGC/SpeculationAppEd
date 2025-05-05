using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Services.Update
{
    public class ConvertationUpdateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;

        public ConvertationUpdateService(IUnitOfWork unitOfWork, ReadTablesStore tablesStore)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;
        }

        public void Update(ConvertationModel model)
        {
            _unitOfWork.Convertations.Update(model);
            _unitOfWork.Complete();

            _tablesStore.Currencies
                .Single(x => x.Id == model.BaseCurrencyId)
                .RefreshData();

            _tablesStore.Currencies
                .Single(x => x.Id == model.TradeCurrencyId)
                .RefreshData();
        }

        public ConvertationModel RestoreModel(ConvertationModel model)
        {
            return _unitOfWork.Convertations.GetById(model.Id);
        }
    }
}
