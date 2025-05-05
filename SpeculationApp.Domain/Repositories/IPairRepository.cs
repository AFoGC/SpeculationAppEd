using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IPairRepository
    {
        IEnumerable<PairModel> GetAll();
        PairModel GetById(int baseCurrencyId, int tradeCurrencyId);
        void Create(PairModel entity);
        void Update(PairModel entity);
        void Update(IEnumerable<PairModel> entities);
        void Delete(int baseCurrencyId, int tradeCurrencyId);
    }
}
