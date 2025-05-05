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
    public class OperationTypeMaper : IMaper<OperationType, OperationTypeModel>
    {
        public OperationType MapModel(OperationTypeModel model)
        {
            return new OperationType
            {
                Id = model.Id,
                Name = model.Name,
                IsIncrease = model.IsIncrease,
            };
        }

        public void MapModel(OperationTypeModel model, OperationType entity)
        {
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.IsIncrease = model.IsIncrease;
        }

        public OperationTypeModel MapEntity(OperationType entity)
        {
            return new OperationTypeModel
            {
                Id = entity.Id,
                Name = entity.Name,
                IsIncrease = entity.IsIncrease,
            };
        }
    }
}
