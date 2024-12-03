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
            DateTime startDateTime = DateTime.Parse(startDate).Date.AddHours(2);
            DateTime endDateTime = DateTime.Parse(endDate).Date.AddHours(26);

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



        public static List<Bitcoin> GetBitcoins(string startDate, string endDate)
        {
            List<Bitcoin> BitcoinList = new List<Bitcoin>();
            BitcoinJsonResponse bitcoins = GetBitcoinsInRange(startDate, endDate);

            if (bitcoins.Prices != null && bitcoins.Prices.Length > 0)
            {
                for (int i = 0; i < bitcoins.Prices.GetLength(0); i++)
                {
                    DateTime? dateTime = GetDateTimeFromBicoinsDB(bitcoins, i);
                    decimal? price = GetPriceFromBitcoinsDB(bitcoins, i);
                    decimal? marketCap = GetMarketCapFromBitcoinsDB(bitcoins, i);
                    decimal? totalVolume = GetTotalVolumeFromBitcoinsDB(bitcoins, i);

                    if (dateTime != null && price != null && marketCap != null && totalVolume != null)
                    {
                        Bitcoin bitcoin = new Bitcoin
                        {
                            Id = i,
                            DateTime = dateTime.Value,
                            Price = price.Value,
                            Market_cap = marketCap.Value,
                            Total_volume = totalVolume.Value
                        };

                        BitcoinList.Add(bitcoin);
                    }
                }
                return BitcoinList;
            }

            return new List<Bitcoin>();
        }




        public static (Bitcoin MaxPriceBitcoin, Bitcoin MinPriceBitcoin) GetMaxAndMinBitcoins(string startDate, string endDate)
        {
            List<Bitcoin> bitcoins = GetBitcoins(startDate, endDate);

            if (bitcoins == null || bitcoins.Count == 0)
            {
                return (null, null);
            }

            Bitcoin maxPriceBitcoin = bitcoins.OrderByDescending(b => b.Price).First();
            Bitcoin minPriceBitcoin = bitcoins.OrderBy(b => b.Price).First();

            return (maxPriceBitcoin, minPriceBitcoin);
        }






        public static (string MaxPriceDate, string MinPriceDate) GetMaxAndMinDates(string startDate, string endDate)
        {
            var (maxPriceBitcoin, minPriceBitcoin) = GetMaxAndMinBitcoins(startDate, endDate);

            if (maxPriceBitcoin == null || minPriceBitcoin == null)
            {
                return (string.Empty, string.Empty);
            }

            string maxPriceDate = maxPriceBitcoin.DateTime.ToString("dd/MM/yyyy");
            string minPriceDate = minPriceBitcoin.DateTime.ToString("dd/MM/yyyy");

            return (maxPriceDate, minPriceDate);
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
