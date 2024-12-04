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

        // Cache to reduce the amount of API calls because Coingecko only allows like five calls.

        private static BitcoinJsonResponse cachedBitcoinResponse = null;
        
        public static BitcoinJsonResponse GetBitcoinsInRange(string startDate, string endDate)
        {
            DateTime startDateTime = DateTime.Parse(startDate).Date.AddHours(2);
            DateTime endDateTime = DateTime.Parse(endDate).Date.AddHours(26);
            
            long startTimestamp = ((DateTimeOffset)startDateTime).ToUnixTimeSeconds();
            long endTimestamp = ((DateTimeOffset)endDateTime).ToUnixTimeSeconds();
            
            string url = $"https://api.coingecko.com/api/v3/coins/bitcoin/market_chart/range?vs_currency=eur&from={startTimestamp}&to={endTimestamp}";



            
            if (cachedBitcoinResponse != null)
            {
                return cachedBitcoinResponse;
            }
            try
            {
                HttpWebRequest jsonRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse jsonResponse = (HttpWebResponse)jsonRequest.GetResponse();
                var JsonResponseReader = new System.IO.StreamReader(jsonResponse.GetResponseStream());
                string bitcoins = JsonResponseReader.ReadToEnd();
                cachedBitcoinResponse = JsonConvert.DeserializeObject<BitcoinJsonResponse>(bitcoins);
                Console.WriteLine("API request made");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return cachedBitcoinResponse;
        }


        // Function to clear the API call cache

        public static void ClearCache()
        {
            cachedBitcoinResponse = null;
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


        public static (Bitcoin MaxVoume, Bitcoin MinVoume) GetMaxAndMinVolume(string startDate, string endDate)
        {
            List<Bitcoin> bitcoins = GetBitcoins(startDate, endDate);

            if (bitcoins == null || bitcoins.Count == 0)
            {
                return (null, null);
            }

            Bitcoin maxVoume = bitcoins.OrderByDescending(b => b.Total_volume).First();
            Bitcoin minVoume = bitcoins.OrderBy(b => b.Total_volume).First();

            return (maxVoume, minVoume);
        }

        public static (string MaxVolumeDate, string MinVolumeDate) GetMaxAndMinVolumeDates(string startDate, string endDate)
        {
            var (maxVolume, minVolume) = GetMaxAndMinVolume(startDate, endDate);

            if (maxVolume == null || minVolume == null)
            {
                return (string.Empty, string.Empty);
            }

            string maxVolumeDate = maxVolume.DateTime.ToString("dd/mm/yyyy");
            string minVolumeDate = minVolume.DateTime.ToString("dd/mm/yyyy");

            return (maxVolumeDate, minVolumeDate);
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
