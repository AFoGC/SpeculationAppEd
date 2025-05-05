using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IConvertationRepository
    {
        IEnumerable<ConvertationModel> GetAll(int baseCurrencyId, int tradeCurrencyId);
        ConvertationModel GetById(int id);
        void Create(ConvertationModel entity);
        void Update(ConvertationModel entity);
        void Delete(int id);
        decimal GetBaseCurrencyAmount(int currencyId);
        decimal GetTradeCurrencyAmount(int currencyId);
    }
}
