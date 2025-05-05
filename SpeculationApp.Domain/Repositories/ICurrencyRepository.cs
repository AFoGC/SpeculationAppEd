using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface ICurrencyRepository
    {
        IEnumerable<CurrencyModel> GetAll();
        CurrencyModel GetById(int id);
        void Create(CurrencyModel entity);
        void Update(CurrencyModel entity);
        void Delete(int id);
    }
}
