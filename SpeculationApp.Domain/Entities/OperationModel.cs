using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Entities
{
    public class OperationModel
    {
        public int Id { get; set; }
        public int OperationTypeId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
