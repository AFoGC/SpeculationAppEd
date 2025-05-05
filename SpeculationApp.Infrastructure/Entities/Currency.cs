using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Entities
{
    public class Currency
    {
        public Currency()
        {
            Code = String.Empty;
            Name = String.Empty;

            PairsAsBaseCurrency = new HashSet<Pair>();
            PairsAsTradeCurrency = new HashSet<Pair>();
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Pair> PairsAsBaseCurrency { get; }
        public ICollection<Pair> PairsAsTradeCurrency { get; }
        public ICollection<Operation> Operations { get; } 
    }
}
