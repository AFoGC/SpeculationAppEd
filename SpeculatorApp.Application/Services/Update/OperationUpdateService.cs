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
    public class OperationUpdateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;

        public OperationUpdateService(IUnitOfWork unitOfWork, ReadTablesStore tablesStore)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;
        }

        public void Update(OperationModel model)
        {
            _unitOfWork.Operations.Update(model);
            _unitOfWork.Complete();

            _tablesStore.Currencies
                .Single(x => x.Id == model.CurrencyId)
                .RefreshData();
        }

        public OperationModel RestoreModel(OperationModel model)
        {
            return _unitOfWork.Operations.GetById(model.Id);
        }
    }
}
