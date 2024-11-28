using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net;

namespace BitcoinMarketAnalyzer.Model
{
    public class JsonDataManagement
    {
        public static BitcoinJsonResponse GetBitcoinsInRange(string startDate, string endDate)
        {
            DateTime startDateTime = DateTime.Parse(startDate).Date.AddDays(1);
            DateTime endDateTime = DateTime.Parse(endDate).Date.AddDays(1);

            long startTimestamp = ((DateTimeOffset)startDateTime).ToUnixTimeSeconds();
            long endTimestamp = ((DateTimeOffset)endDateTime).ToUnixTimeSeconds();

            string url = $"https://api.coingecko.com/api/v3/coins/bitcoin/market_chart/range?vs_currency=eur&from={startTimestamp}&to={endTimestamp}";

            BitcoinJsonResponse bitcoinResponse = new BitcoinJsonResponse();

            try
            {
                HttpWebRequest jsonRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse jsonResponse = (HttpWebResponse)jsonRequest.GetResponse();

                string bitcoins;
                using (System.IO.StreamReader JsonResponseReader = new System.IO.StreamReader(jsonResponse.GetResponseStream()))
                {
                    bitcoins = JsonResponseReader.ReadToEnd();
                }

                bitcoinResponse = JsonConvert.DeserializeObject<BitcoinJsonResponse>(bitcoins);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }

            return bitcoinResponse;
        }



        //
        public static List<Bitcoin> GetBitcoins(string startDate, string endDate)
        {
            List<Bitcoin> BitcoinList = new List<Bitcoin>();
            BitcoinJsonResponse bitcoins = GetBitcoinsInRange(startDate, endDate);

            if (bitcoins.Prices.Length > 0)
            {
                for (int i = 0; i < bitcoins.Prices.GetLength(0); i++)
                {// get length of the first dimension of an array
                    Bitcoin bitcoin = new()
                    {
                        DateTime = GetDateTimeFromBicoinsDB(bitcoins, i),
                        Price = GetPriceFromBitcoinsDB(bitcoins, i),
                        Market_cap = GetMarketCapFromBitcoinsDB(bitcoins, i),
                        Total_volume = GetTotalVolumeFromBitcoinsDB(bitcoins, i)
                    };

                    BitcoinList.Add(bitcoin);
                }
                return BitcoinList;
                
            }

            return GetBitcoins(startDate, endDate);
        }



        private static DateTime GetDateTimeFromBicoinsDB(BitcoinJsonResponse bitcoins, int row)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(Int64.Parse(bitcoins.Prices[row, 0])).DateTime;
        }

        private static decimal GetPriceFromBitcoinsDB(BitcoinJsonResponse bitcoins, int row)
        {
            return decimal.Parse(bitcoins.Prices[row, 1].Replace('.', ','));
        }

        private static decimal GetMarketCapFromBitcoinsDB(BitcoinJsonResponse bitcoins, int row)
        {
            return decimal.Parse(bitcoins.Market_caps[row, 1].Replace('.', ','));
        }

        private static decimal GetTotalVolumeFromBitcoinsDB(BitcoinJsonResponse bitcoins, int row)
        {
            return decimal.Parse(bitcoins.Total_volumes[row, 1].Replace('.', ','));
        }
        //
    }
}
