using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Entities
{
    public class Pair
    {
        public Pair()
        {
            Convertations = new HashSet<Convertation>();
        }

        public int BaseCurrencyId { get; set; }
        public int TradeCurrencyId { get; set; }
        public int PositionInList { get; set; }

        public Currency BaseCurrency { get; set; } = null!;
        public Currency TradeCurrency { get; set; } = null!;

        public ICollection<Convertation> Convertations { get; }
    }
}
