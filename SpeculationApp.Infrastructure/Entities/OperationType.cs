using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Entities
{
    public class OperationType
    {
        public OperationType()
        {
            Name = String.Empty;

            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsIncrease { get; set; }

        public ICollection<Operation> Operations { get; }
    }
}
