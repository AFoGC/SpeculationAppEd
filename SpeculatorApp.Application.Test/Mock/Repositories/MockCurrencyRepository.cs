using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Test.Mock.Repositories
{
    public class MockCurrencyRepository : ICurrencyRepository
    {
        private readonly List<CurrencyModel> _currencies;

        public MockCurrencyRepository(List<CurrencyModel> currencies)
        {
            _currencies = currencies;
        }

        public IEnumerable<CurrencyModel> GetAll() => _currencies;
        public CurrencyModel GetById(int id) => _currencies.First(c => c.Id == id);
        public void Create(CurrencyModel entity) => _currencies.Add(entity);
        public void Update(CurrencyModel entity)
        {
            //Delete(entity.Id);
            //_currencies.Add(entity);
        }
        public void Delete(int id) => _currencies.RemoveAll(c => c.Id == id);
    }
}
