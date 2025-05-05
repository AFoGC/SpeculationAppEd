using Microsoft.EntityFrameworkCore;
using SpeculationApp.Domain.Entities;
using SpeculationApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpeculationApp.Infrastructure.Mapers
{
    public class ConvertationMaper : IMaper<Convertation, ConvertationModel>
    {
        public Convertation MapModel(ConvertationModel model)
        {
            return new Convertation
            {
                Id = model.Id,
                BaseCurrencyId = model.BaseCurrencyId,
                TradeCurrencyId = model.TradeCurrencyId,
                BaseCurrencyAmount = model.BaseCurrencyAmount,
                TradeCurrencyAmount = model.TradeCurrencyAmount,
                ToTradeCurrency = model.ToTradeCurrency,
                Date = model.Date,
            };
        }

        public void MapModel(ConvertationModel model, Convertation entity)
        {
            entity.Id = model.Id;
            entity.BaseCurrencyId = model.BaseCurrencyId;
            entity.TradeCurrencyId = model.TradeCurrencyId;
            entity.BaseCurrencyAmount = model.BaseCurrencyAmount;
            entity.TradeCurrencyAmount = model.TradeCurrencyAmount;
            entity.ToTradeCurrency = model.ToTradeCurrency;
            entity.Date = model.Date;
        }

        public ConvertationModel MapEntity(Convertation entity)
        {
            return new ConvertationModel
            {
                Id = entity.Id,
                BaseCurrencyId = entity.BaseCurrencyId,
                TradeCurrencyId = entity.TradeCurrencyId,
                BaseCurrencyAmount = entity.BaseCurrencyAmount,
                TradeCurrencyAmount = entity.TradeCurrencyAmount,
                ToTradeCurrency = entity.ToTradeCurrency,
                Date = entity.Date,
            };
        }
    }
}
