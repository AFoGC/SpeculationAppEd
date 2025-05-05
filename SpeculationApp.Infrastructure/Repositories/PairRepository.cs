using Microsoft.EntityFrameworkCore;
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
    public class PairRepository : IPairRepository
    {
        private readonly TradingContext _dbContext;
        private readonly PairMaper _maper;

        public PairRepository(TradingContext dbContext)
        {
            _dbContext = dbContext;
            _maper = new PairMaper();
        }

        public IEnumerable<PairModel> GetAll()
        {
            return _dbContext.Pairs
                .ToList()
                .Select(x => _maper.MapEntity(x));
        }

        public PairModel GetById(int baseCurrencyId, int tradeCurrencyId)
        {
            var entity = _dbContext.Pairs
                .Single(x => x.BaseCurrencyId == baseCurrencyId && x.TradeCurrencyId == tradeCurrencyId);

            return _maper.MapEntity(entity);
        }

        public void Create(PairModel model)
        {
            var entity = _maper.MapModel(model);

            _dbContext.Pairs.Add(entity);
        }

        public void Update(PairModel model)
        {
            var entity = _dbContext.Pairs
                .Single(x => x.BaseCurrencyId == model.BaseCurrencyId && x.TradeCurrencyId == model.TradeCurrencyId);

            _maper.MapModel(model, entity);
        }

        public void Update(IEnumerable<PairModel> models)
        {
            foreach (var model in models)
            {
                Update(model);
            }
        }

        public void Delete(int baseCurrencyId, int tradeCurrencyId)
        {
            var entity = _dbContext.Pairs
                .Single(x => x.BaseCurrencyId == baseCurrencyId && x.TradeCurrencyId == tradeCurrencyId);

            _dbContext.Pairs.Remove(entity);
        }
    }
}
