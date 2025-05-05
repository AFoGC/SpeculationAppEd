using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculationApp.Infrastructure.Context;
using SpeculationApp.Infrastructure.Mapers;

namespace SpeculationApp.Infrastructure.Repositories
{
    public class ConvertationRepository : IConvertationRepository
    {
        private readonly TradingContext _dbContext;
        private readonly ConvertationMaper _maper;

        public ConvertationRepository(TradingContext dbContext)
        {
            _dbContext = dbContext;
            _maper = new ConvertationMaper();
        }

        public IEnumerable<ConvertationModel> GetAll(int baseCurrencyId, int tradeCurrencyId)
        {
            return _dbContext.Convertations
                .Where(x => x.BaseCurrencyId == baseCurrencyId && x.TradeCurrencyId == tradeCurrencyId)
                .ToList()
                .Select(x => _maper.MapEntity(x));
        }

        public ConvertationModel GetById(int id)
        {
            var entity = _dbContext.Convertations
                .Single(x => x.Id == id);

            return _maper.MapEntity(entity);
        }

        public void Create(ConvertationModel model)
        {
            int id = 1;

            if (model.Id == 0)
            {
                int count = _dbContext.Convertations.Count();

                if (count != 0)
                    id = _dbContext.Convertations.Max(x => x.Id);
            }

            model.Id = id + 1;
            var entity = _maper.MapModel(model);

            _dbContext.Convertations.Add(entity);
        }

        public void Update(ConvertationModel model)
        {
            var entity = _dbContext.Convertations
                .Single(x => x.Id == model.Id);

            _maper.MapModel(model, entity);
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Convertations
                .Single(x => x.Id == id);

            _dbContext.Convertations.Remove(entity);
        }

        public decimal GetBaseCurrencyAmount(int currencyId)
        {
            decimal increaseSum = _dbContext.Convertations
                .Where(x => x.BaseCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency == false)
                .ToList()
                .Sum(x => x.BaseCurrencyAmount);

            decimal decreaseSum = _dbContext.Convertations
                .Where(x => x.BaseCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency)
                .ToList()
                .Sum(x => x.BaseCurrencyAmount);

            return increaseSum - decreaseSum;
        }

        public decimal GetTradeCurrencyAmount(int currencyId)
        {
            decimal increaseSum = _dbContext.Convertations
                .Where(x => x.TradeCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency)
                .ToList()
                .Sum(x => x.TradeCurrencyAmount);

            decimal decreaseSum = _dbContext.Convertations
                .Where(x => x.TradeCurrencyId == currencyId)
                .Where(x => x.ToTradeCurrency == false)
                .ToList()
                .Sum(x => x.TradeCurrencyAmount);

            return increaseSum - decreaseSum;
        }
    }
}
