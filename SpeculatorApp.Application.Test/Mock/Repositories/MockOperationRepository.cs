using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Test.Mock.Repositories
{
    public class MockOperationRepository : IOperationRepository
    {
        private readonly List<OperationModel> _operations;
        private readonly IEnumerable<OperationTypeModel> _operationTypes;

        public MockOperationRepository(List<OperationModel> operations, IEnumerable<OperationTypeModel> operationTypes)
        {
            _operations = operations;
            _operationTypes = operationTypes;
        }

        public IEnumerable<OperationModel> GetAll(int currencyId) =>
            _operations.Where(o => o.CurrencyId == currencyId);

        public OperationModel GetById(int id) => _operations.First(o => o.Id == id);
        public void Create(OperationModel entity) => _operations.Add(entity);
        public void Update(OperationModel entity)
        {
            //Delete(entity.Id);
            //_operations.Add(entity);
        }
        public void Delete(int id) => _operations.RemoveAll(o => o.Id == id);

        public decimal GetCurrencyAmount(int currencyId)
        {
            Dictionary<int, bool> isIncrease = new Dictionary<int, bool>();

            foreach (var operationType in _operationTypes)
            {
                isIncrease.Add(operationType.Id, operationType.IsIncrease);
            }

            var query = _operations
                .Where(x => x.CurrencyId == currencyId)
                .ToList();

            if (query.Count() != 0)
            {
                decimal increaseSum = query
                    .Where(x => isIncrease[x.OperationTypeId])
                    .Sum(x => x.Amount);

                decimal decreaseSum = query
                    .Where(x => isIncrease[x.OperationTypeId] == false)
                    .Sum(x => x.Amount);

                return increaseSum - decreaseSum;
            }
            else
            {
                return 0;
            }
        }
    }
}
