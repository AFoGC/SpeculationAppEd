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
    public class OperationMaper : IMaper<Operation, OperationModel>
    {
        public Operation MapModel(OperationModel entity)
        {
            return new Operation
            {
                Id = entity.Id,
                CurrencyId = entity.CurrencyId,
                OperationTypeId = entity.OperationTypeId,
                Amount = entity.Amount,
                Date = entity.Date
            };
        }

        public void MapModel(OperationModel model, Operation entity)
        {
            entity.Id = model.Id;
            entity.CurrencyId = model.CurrencyId;
            entity.OperationTypeId = model.OperationTypeId;
            entity.Amount = model.Amount;
            entity.Date = model.Date;
        }

        public OperationModel MapEntity(Operation entity)
        {
            return new OperationModel
            {
                Id = entity.Id,
                CurrencyId = entity.CurrencyId,
                OperationTypeId = entity.OperationTypeId,
                Amount = entity.Amount,
                Date = entity.Date
            };
        }
    }
}
