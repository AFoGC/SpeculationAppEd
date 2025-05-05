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
    public class PairUpdateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;

        public PairUpdateService(IUnitOfWork unitOfWork, ReadTablesStore tablesStore)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;
        }

        public void Update(PairModel model)
        {
            throw new NotImplementedException();
        }

        public PairModel RestoreModel(PairModel model)
        {
            throw new NotImplementedException();
        }
    }
}
