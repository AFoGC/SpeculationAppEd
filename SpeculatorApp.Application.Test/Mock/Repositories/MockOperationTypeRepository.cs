using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Test.Mock.Repositories
{
    public class MockOperationTypeRepository : IOperationTypeRepository
    {
        private readonly List<OperationTypeModel> _operationTypes;

        public MockOperationTypeRepository(List<OperationTypeModel> operationTypes)
        {
            _operationTypes = operationTypes;
        }

        public IEnumerable<OperationTypeModel> GetAll() => _operationTypes;
        public OperationTypeModel GetById(int id) => _operationTypes.First(t => t.Id == id);
        public void Create(OperationTypeModel entity) => _operationTypes.Add(entity);
        public void Update(OperationTypeModel entity)
        {
            //Delete(entity.Id);
            //_operationTypes.Add(entity);
        }
        public void Delete(int id) => _operationTypes.RemoveAll(t => t.Id == id);
    }
}
