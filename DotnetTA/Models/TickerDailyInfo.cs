using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Models
{
    public class TickerDailyInfo
    {
        public string Ticker { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal DailyLow { get; set; }
        public decimal DailyHigh { get; set; }
        public decimal DailyOpen { get; set; }
        public decimal DailyClose { get; set; }
        public int Volume { get; set; }
        public decimal AdjClose { get; set; }
    }
}
