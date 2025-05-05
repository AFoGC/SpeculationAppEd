using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IOperationRepository
    {
        IEnumerable<OperationModel> GetAll(int currencyId);
        OperationModel GetById(int id);
        void Create(OperationModel entity);
        void Update(OperationModel entity);
        void Delete(int id);
        decimal GetCurrencyAmount(int currencyId);
    }
}
