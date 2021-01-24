using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTA.Models
{
    public class SMA
    {
        public string Ticker { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal FiftyDaySMA { get; set; }
        public decimal TwoHundredDaySMA { get; set; }
    }
}
