using SpeculationApp.Domain.Entities;
using SpeculationApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpeculationApp.Infrastructure.Mapers
{
    public class CurrencyMaper : IMaper<Currency, CurrencyModel>
    {
        public Currency MapModel(CurrencyModel model)
        {
            return new Currency
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
            };
        }

        public void MapModel(CurrencyModel model, Currency entity)
        {
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Code = model.Code;
        }

        public CurrencyModel MapEntity(Currency entity)
        {
            return new CurrencyModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
            };
        }
    }
}
