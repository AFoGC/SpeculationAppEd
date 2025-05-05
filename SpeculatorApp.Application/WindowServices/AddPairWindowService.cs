using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.WindowServices
{
    public class PairCreationInfo
    {
        public int BaseCurrency { get; set; }
        public int TradeCurrency { get; set; }
    }

    public interface IAddPairWindowService
    {
        PairCreationInfo? GetInfo();
    }
}
