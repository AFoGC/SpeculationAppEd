using SpeculationApp.Domain.Entities;
using SpeculationApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Mapers
{
    public class PairMaper : IMaper<Pair, PairModel>
    {
        public Pair MapModel(PairModel model)
        {
            return new Pair
            {
                BaseCurrencyId = model.BaseCurrencyId,
                TradeCurrencyId = model.TradeCurrencyId,
                PositionInList = model.PositionInList,
            };
        }

        public void MapModel(PairModel model, Pair entity)
        {
            entity.BaseCurrencyId = model.BaseCurrencyId;
            entity.TradeCurrencyId = model.TradeCurrencyId;
            entity.PositionInList = model.PositionInList;
        }

        public PairModel MapEntity(Pair entity)
        {
            return new PairModel
            {
                BaseCurrencyId = entity.BaseCurrencyId,
                TradeCurrencyId = entity.TradeCurrencyId,
                PositionInList = entity.PositionInList,
            };
        }
    }
}
