using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IOperationTypeRepository
    {
        IEnumerable<OperationTypeModel> GetAll();
        OperationTypeModel GetById(int id);
        void Create(OperationTypeModel entity);
        void Update(OperationTypeModel entity);
        void Delete(int id);
    }
}
