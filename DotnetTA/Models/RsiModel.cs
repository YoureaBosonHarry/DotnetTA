using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Models
{
    public class RsiModel
    {
        public string Ticker { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal TwoDayRsi { get; set; }
        public decimal SixDayRsi { get; set; }
        public decimal FourteenDayRsi { get; set; }
    }
}
