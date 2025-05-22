using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Test.Mock.Repositories
{
    public class MockPairRepository : IPairRepository
    {
        private readonly List<PairModel> _pairs;
        public MockPairRepository(List<PairModel> pairs)
        {
            _pairs = pairs;
        }

        public IEnumerable<PairModel> GetAll() => _pairs;
        public PairModel GetById(int baseCurrencyId, int tradeCurrencyId)
        {
            return _pairs.First(p => p.BaseCurrencyId == baseCurrencyId && p.TradeCurrencyId == tradeCurrencyId);
        }

        public void Create(PairModel entity) => _pairs.Add(entity);
        public void Update(PairModel entity)
        {
            //Delete(entity.BaseCurrencyId, entity.TradeCurrencyId);
            //_pairs.Add(entity);
        }
        public void Update(IEnumerable<PairModel> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }
        public void Delete(int baseCurrencyId, int tradeCurrencyId) =>
            _pairs.RemoveAll(p => p.BaseCurrencyId == baseCurrencyId && p.TradeCurrencyId == tradeCurrencyId);
    }
}
