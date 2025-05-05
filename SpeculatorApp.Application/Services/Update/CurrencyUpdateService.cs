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
    public class CurrencyUpdateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;

        public CurrencyUpdateService(IUnitOfWork unitOfWork, ReadTablesStore tablesStore)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;
        }

        public void Update(CurrencyModel model)
        {
            _unitOfWork.Currencies.Update(model);
            _unitOfWork.Complete();

            _tablesStore.Currencies
                .Single(x => x.Id == model.Id)
                .RefreshData();
        }

        public CurrencyModel RestoreModel(CurrencyModel model)
        {
            return _unitOfWork.Currencies.GetById(model.Id);
        }
    }
}
