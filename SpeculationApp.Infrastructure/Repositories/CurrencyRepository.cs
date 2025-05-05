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
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly TradingContext _dbContext;
        private readonly CurrencyMaper _maper;

        public CurrencyRepository(TradingContext dbContext)
        {
            _dbContext = dbContext;
            _maper = new CurrencyMaper();
        }

        public IEnumerable<CurrencyModel> GetAll()
        {
            return _dbContext.Currencies
                .ToList()
                .Select(x => _maper.MapEntity(x));
        }

        public CurrencyModel GetById(int id)
        {
            var entity = _dbContext.Currencies
                .Single(x => x.Id == id);

            return _maper.MapEntity(entity);
        }

        public void Create(CurrencyModel model)
        {
            int id = 1;

            if (model.Id == 0)
            {
                int count = _dbContext.Currencies.Count();

                if (count != 0)
                    id = _dbContext.Currencies.Max(x => x.Id);
            }

            model.Id = id + 1;
            var entity = _maper.MapModel(model);

            _dbContext.Currencies.Add(entity);
        }

        public void Update(CurrencyModel model)
        {
            var entity = _dbContext.Currencies
                .Single(x => x.Id == model.Id);

            _maper.MapModel(model, entity);
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Currencies
                .Single(x => x.Id == id);

            _dbContext.Currencies.Remove(entity);
        }
    }
}
