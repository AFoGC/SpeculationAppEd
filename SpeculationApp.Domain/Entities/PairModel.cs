using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Entities
{
    public class PairModel
    {
        public int BaseCurrencyId { get; set; }
        public int TradeCurrencyId { get; set; }
        public int PositionInList { get; set; }
    }
}
