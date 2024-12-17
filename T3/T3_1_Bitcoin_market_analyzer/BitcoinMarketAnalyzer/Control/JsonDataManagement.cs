using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Data;
using BitcoinMarketAnalyzer.Model;

namespace BitcoinMarketAnalyzer.Control
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

            // API key stored in local file, will be removed later

            StreamReader sr = new StreamReader(@"C:\Ohjelmointitehtävät\coingecko.txt");
            string local = sr.ReadLine();

            //

            string url = $"https://api.coingecko.com/api/v3/coins/bitcoin/market_chart/range?vs_currency=eur&from={startTimestamp}&to={endTimestamp}&{local}";


            if (cachedBitcoinResponse != null)
            {
                return cachedBitcoinResponse;
            }
            try
            {
                HttpWebRequest jsonRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse jsonResponse = (HttpWebResponse)jsonRequest.GetResponse();
                var JsonResponseReader = new StreamReader(jsonResponse.GetResponseStream());
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


        // Function to clear the API call cache so new data can be fetched from new dates

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

            string maxPriceDate = maxPriceBitcoin.DateTime.ToString("d");
            string minPriceDate = minPriceBitcoin.DateTime.ToString("d");

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

            string maxVolumeDate = maxVolume.DateTime.ToString("d");
            string minVolumeDate = minVolume.DateTime.ToString("d");

            return (maxVolumeDate, minVolumeDate);
        }


        //

        public static (string LongestStreak, string LongestStreakStartDate, string LongestStreakEndDate) BullishMarket(string startDate, string endDate)
        {
            List<Bitcoin> bitcoins = GetBitcoins(startDate, endDate);

            var dailyMax = bitcoins
                .GroupBy(b => b.DateTime.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    MaxPrice = g.Max(b => b.Price)
                })
                .OrderBy(d => d.Date)
                .ToList();

            int longestStreak = 0;
            int currentStreak = 0;
            DateTime longestStreakStartDate = DateTime.MinValue;
            DateTime longestStreakEndDate = DateTime.MinValue;
            DateTime currentStreakStartDate = DateTime.MinValue;

            for (int i = 1; i < dailyMax.Count; i++)
            {
                if (dailyMax[i].MaxPrice > dailyMax[i - 1].MaxPrice)
                {
                    if (currentStreak == 0)
                    {
                        currentStreakStartDate = dailyMax[i - 1].Date;
                    }

                    currentStreak++;
                    if (currentStreak > longestStreak)
                    {
                        longestStreak = currentStreak;
                        longestStreakStartDate = currentStreakStartDate;
                        longestStreakEndDate = dailyMax[i].Date;
                    }
                }
                else
                {
                    currentStreak = 0;
                }
            }


            if (longestStreak == 0)
            {
                string longestStreakString = " - ";
                string longestStreakStartDateString = " - ";
                string longestStreakEndDateString = " - ";

                return (longestStreakString, longestStreakStartDateString, longestStreakEndDateString);
            }

            else
            {
                string longestBullStreakString = longestStreak.ToString();

                string longestBullStreakStartDateString = longestStreakStartDate.ToShortDateString();
                
                string longestBullStreakEndDateString = longestStreakEndDate.ToShortDateString();

                return (longestBullStreakString, longestBullStreakStartDateString, longestBullStreakEndDateString);
            }
        }


        public static (string LongestStreak, string LongestStreakStartDate, string LongestStreakEndDate) BearishMarket(string startDate, string endDate)
        {
            List<Bitcoin> bitcoins = GetBitcoins(startDate, endDate);

            var dailyMax = bitcoins
                .GroupBy(b => b.DateTime.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    MaxPrice = g.Max(b => b.Price)
                })
                .OrderBy(d => d.Date)
                .ToList();

            int longestStreak = 0;
            int currentStreak = 0;
            DateTime longestStreakStartDate = DateTime.MinValue;
            DateTime longestStreakEndDate = DateTime.MinValue;
            DateTime currentStreakStartDate = DateTime.MinValue;

            for (int i = 1; i < dailyMax.Count; i++)
            {
                if (dailyMax[i].MaxPrice < dailyMax[i - 1].MaxPrice)
                {
                    if (currentStreak == 0)
                    {
                        currentStreakStartDate = dailyMax[i - 1].Date;
                    }

                    currentStreak++;
                    if (currentStreak > longestStreak)
                    {
                        longestStreak = currentStreak;
                        longestStreakStartDate = currentStreakStartDate;
                        longestStreakEndDate = dailyMax[i].Date;
                    }
                }
                else
                {
                    currentStreak = 0;
                }
            }

            if (longestStreak == 0)
            {
                string longestStreakString = " - ";
                string longestStreakStartDateString = " - ";
                string longestStreakEndDateString = " - ";

                return (longestStreakString, longestStreakStartDateString, longestStreakEndDateString);
            }
            else
            {
                string longestBearStreakString = longestStreak.ToString();

                string longestBearStreakStartDateString = longestStreakStartDate.ToShortDateString();

                string longestBearStreakEndDateString = longestStreakEndDate.ToShortDateString();

                return (longestBearStreakString, longestBearStreakStartDateString, longestBearStreakEndDateString);
            }
        }


        public static string BestTimeToBuy(string startDate, string endDate)
        {
            List<Bitcoin> bitcoins = GetBitcoins(startDate, endDate);

            var dailyAverage = bitcoins
                .GroupBy(b => b.DateTime.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    AvgPrice = g.Average(b => b.Price)
                })
                .OrderBy(d => d.Date)
                .ToList();

            var bestDay = dailyAverage
                .OrderBy(d => d.AvgPrice)
                .FirstOrDefault();


            if (bestDay != null)
            {
                
                string bestDayToBuy = bestDay.Date.ToShortDateString();
                return bestDayToBuy;
            }
            else
            {
                string bestDayToBuy = " - ";
                return bestDayToBuy;
            }
        }

        public static string BestTimeToSell(string startDate, string endDate)
        {
            List<Bitcoin> bitcoins = GetBitcoins(startDate, endDate);

            var dailyAverage = bitcoins
                .GroupBy(b => b.DateTime.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    AvgPrice = g.Average(b => b.Price)
                })
                .OrderBy(d => d.Date)
                .ToList();

            var bestDay = dailyAverage
                .OrderByDescending(d => d.AvgPrice)
                .FirstOrDefault();


            if (bestDay != null)
            {

                string bestDayToSell = bestDay.Date.ToShortDateString();
                return bestDayToSell;
            }
            else
            {
                string bestDayToSell = " - ";
                return bestDayToSell;
            }
        }

        //


        private static DateTime GetDateTimeFromBicoinsDB(BitcoinJsonResponse bitcoins, int row)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(bitcoins.Prices[row, 0])).DateTime;
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
