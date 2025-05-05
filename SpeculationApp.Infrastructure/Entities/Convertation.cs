using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Infrastructure.Entities
{
    public class Convertation
    {
        public Convertation()
        {

        }

        public int Id { get; set; }
        public int BaseCurrencyId { get; set; }
        public int TradeCurrencyId { get; set; }
        public decimal BaseCurrencyAmount { get; set; }
        public decimal TradeCurrencyAmount { get; set; }
        public bool ToTradeCurrency { get; set; }
        public DateTime Date { get; set; }

        public Pair Pair { get; set; } = null!;
    }
}
