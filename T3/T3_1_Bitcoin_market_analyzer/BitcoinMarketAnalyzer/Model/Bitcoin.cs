using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BitcoinMarketAnalyzer.Model
{
    public class Bitcoin // DB Model
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public decimal Market_cap { get; set; }
        public decimal Total_volume { get; set; }
    }

    public class BitcoinJsonResponse // JSON response model
    { 
        public string[,] Prices { get; set; }
        public string[,] Market_caps { get; set; }
        public string[,] Total_volumes { get; set; }
    }
}
