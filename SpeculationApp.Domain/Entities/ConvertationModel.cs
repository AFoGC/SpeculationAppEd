using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Entities
{
    public class ConvertationModel
    {
        public int Id { get; set; }
        public int BaseCurrencyId { get; set; }
        public int TradeCurrencyId { get; set; }
        public decimal BaseCurrencyAmount { get; set; }
        public decimal TradeCurrencyAmount { get; set; }
        public bool ToTradeCurrency { get; set; }
        public DateTime Date { get; set; }
    }
}
