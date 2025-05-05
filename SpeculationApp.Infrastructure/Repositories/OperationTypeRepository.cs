using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculationApp.Infrastructure.Context;
using SpeculationApp.Infrastructure.Mapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Repositories
{
    public class OperationTypeRepository : IOperationTypeRepository
    {
        private readonly TradingContext _dbContext;
        private readonly OperationTypeMaper _maper;

        public OperationTypeRepository(TradingContext dbContext)
        {
            _dbContext = dbContext;
            _maper = new OperationTypeMaper();
        }

        public IEnumerable<OperationTypeModel> GetAll()
        {
            return _dbContext.OperationTypes
                .ToList()
                .Select(x => _maper.MapEntity(x));
        }

        public OperationTypeModel GetById(int id)
        {
            var entity = _dbContext.OperationTypes
                .Single(x => x.Id == id);

            return _maper.MapEntity(entity);
        }

        public void Create(OperationTypeModel model)
        {
            int id = 1;

            if (model.Id == 0)
            {
                int count = _dbContext.OperationTypes.Count();

                if (count != 0)
                    id = _dbContext.OperationTypes.Max(x => x.Id);
            }

            model.Id = id + 1;
            var entity = _maper.MapModel(model);

            _dbContext.OperationTypes.Add(entity);
        }

        public void Update(OperationTypeModel model)
        {
            var entity = _dbContext.OperationTypes
                .Single(x => x.Id == model.Id);

            _maper.MapModel(model, entity);
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Convertations
                .Single(x => x.Id == id);

            _dbContext.Convertations.Remove(entity);
        }
    }
}
