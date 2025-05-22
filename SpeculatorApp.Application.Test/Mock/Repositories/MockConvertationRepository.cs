using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Test.Mock.Repositories
{
    public class MockConvertationRepository : IConvertationRepository
    {
        private readonly List<ConvertationModel> _convertations;

        public MockConvertationRepository(List<ConvertationModel> convertations)
        {
            _convertations = convertations;
        }

        public IEnumerable<ConvertationModel> GetAll(int baseCurrencyId, int tradeCurrencyId) =>
            _convertations.Where(c => c.BaseCurrencyId == baseCurrencyId && c.TradeCurrencyId == tradeCurrencyId);

        public ConvertationModel GetById(int id) => _convertations.First(c => c.Id == id);
        public void Create(ConvertationModel entity) => _convertations.Add(entity);
        public void Update(ConvertationModel entity)
        {
            //Delete(entity.Id);
            //_convertations.Add(entity);
        }
        public void Delete(int id) => _convertations.RemoveAll(c => c.Id == id);

        public decimal GetBaseCurrencyAmount(int currencyId)
        {
            decimal increaseSum = _convertations
                .Where(x => x.BaseCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency == false)
                .ToList()
                .Sum(x => x.BaseCurrencyAmount);

            decimal decreaseSum = _convertations
                .Where(x => x.BaseCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency)
                .ToList()
                .Sum(x => x.BaseCurrencyAmount);

            return increaseSum - decreaseSum;
        }
            

        public decimal GetTradeCurrencyAmount(int currencyId)
        {
            decimal increaseSum = _convertations
                .Where(x => x.TradeCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency)
                .ToList()
                .Sum(x => x.TradeCurrencyAmount);

            decimal decreaseSum = _convertations
                .Where(x => x.TradeCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency == false)
                .ToList()
                .Sum(x => x.TradeCurrencyAmount);

            return increaseSum - decreaseSum;
        }
            
    }
}
