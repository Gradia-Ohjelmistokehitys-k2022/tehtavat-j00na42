using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BitcoinMarketAnalyzer.Control;
using System.Windows.Forms.DataVisualization.Charting;



namespace BitcoinMarketAnalyzer
{
    public partial class MainForm : Form
    {

        public DateTime startDate;
        public DateTime endDate;


        public MainForm()
        {
            MaximizeBox = false;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Configure date times to not go beyond one year as guided in Coingecko.

            dateStart.MaxDate = DateTime.Now;
            dateEnd.MaxDate = DateTime.Now;

            dateStart.MinDate = DateTime.Now.AddYears(-1);
            dateEnd.MinDate = DateTime.Now.AddYears(-1);

            //

            
            startDate = dateStart.Value.Date;
            endDate = dateEnd.Value.Date;

            string startDateString = startDate.ToString("d");
            string endDateString = endDate.ToString("d");

            var bitcoinData = JsonDataManagement.GetBitcoins(startDateString, endDateString);



            // Get functions from JsonDataManagement.

            var (maxPriceBitcoin, minPriceBitcoin) = JsonDataManagement.GetMaxAndMinBitcoins(startDateString, endDateString);

            var (maxValueDate, minValueDate) = JsonDataManagement.GetMaxAndMinDates(startDateString, endDateString);

            var (maxVolume, minVolume) = JsonDataManagement.GetMaxAndMinVolume(startDateString, endDateString);

            var (maxVolumeDate, minVolumeDate) = JsonDataManagement.GetMaxAndMinVolumeDates(startDateString, endDateString);


            var (longestBullStreakString, longestBullStreakStartDateString, longestBullStreakEndDateString) = JsonDataManagement.BullishMarket(startDateString, endDateString);

            var (longestBearStreakString, longestBearStreakStartDateString, longestBearStreakEndDateString) = JsonDataManagement.BearishMarket(startDateString, endDateString);

            var dates = bitcoinData.Select(data => data.DateTime).ToList();
            var prices = bitcoinData.Select(data => data.Price).ToList();

            UpdateChart(dates, prices);



            // Place bitcoin info into labels in mainform.


            maxValue.Text = Math.Round(maxPriceBitcoin.Price, 0).ToString() + " €";
            minValue.Text = Math.Round(minPriceBitcoin.Price, 0).ToString() + " €";

            maxDate.Text = maxValueDate.ToString();
            minDate.Text = minValueDate.ToString();

            maxVolumelbl.Text = Math.Round(maxVolume.Total_volume, 0).ToString() + " €";
            minVolumeLbl.Text = Math.Round(minVolume.Total_volume, 0).ToString() + " €";

            maxVolumeDateLbl.Text = maxVolumeDate.ToString();
            minVolumeDateLbl.Text = minVolumeDate.ToString();

            dayToBuyLbl.Text = "Best day to buy is " + JsonDataManagement.BestTimeToBuy(startDateString, endDateString);

            dayToSellLbl.Text = "Best day to sell is " + JsonDataManagement.BestTimeToSell(startDateString, endDateString);


            bullLbl.Text = "Longest bullish trend was " + longestBullStreakString + " days";
            bullStartLbl.Text = "From " + longestBullStreakStartDateString;
            bullEndLbl.Text = "To " + longestBullStreakEndDateString;


            bearLbl.Text = "Longest bearish trend was " + longestBearStreakString + " days";
            bearStartLbl.Text = "From " + longestBearStreakStartDateString;
            bearEndLbl.Text = "To " + longestBearStreakEndDateString;
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {

        }
        


        private void btnFindFromDates_Click(object sender, EventArgs e)
        {
            // Clear existing cache to store new data from dates.

            JsonDataManagement.ClearCache();

            startDate = dateStart.Value.Date;
            endDate = dateEnd.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Starting date cannot be greater than ending date!", "Error 202", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string startDateString = startDate.ToString("d");
                string endDateString = endDate.ToString("d");

                var bitcoinData = JsonDataManagement.GetBitcoins(startDateString, endDateString);



                if (bitcoinData != null)
                {
                    var (maxBitcoin, minBitcoin) = JsonDataManagement.GetMaxAndMinBitcoins(startDateString, endDateString);

                    var (maxValueDate, minValueDate) = JsonDataManagement.GetMaxAndMinDates(startDateString, endDateString);

                    var (maxVolume, minVolume) = JsonDataManagement.GetMaxAndMinVolume(startDateString, endDateString);

                    var (maxVolumeDate, minVolumeDate) = JsonDataManagement.GetMaxAndMinVolumeDates(startDateString, endDateString);

                    var (longestBullStreakString, longestBullStreakStartDateString, longestBullStreakEndDateString) = JsonDataManagement.BullishMarket(startDateString, endDateString);

                    var (longestBearStreakString, longestBearStreakStartDateString, longestBearStreakEndDateString) = JsonDataManagement.BearishMarket(startDateString, endDateString);


                    var dates = bitcoinData.Select(data => data.DateTime).ToList();
                    var prices = bitcoinData.Select(data => data.Price).ToList();

                    UpdateChart(dates, prices);



                    if (maxBitcoin != null && minBitcoin != null)
                    {
                        maxValue.Text = Math.Round(maxBitcoin.Price, 0).ToString() + " €";
                        minValue.Text = Math.Round(minBitcoin.Price, 0).ToString() + " €";

                        maxDate.Text = maxValueDate.ToString();
                        minDate.Text = minValueDate.ToString();

                        maxVolumelbl.Text = Math.Round(maxVolume.Total_volume, 0).ToString() + " €";
                        minVolumeLbl.Text = Math.Round(minVolume.Total_volume, 0).ToString() + " €";

                        maxVolumeDateLbl.Text = maxVolumeDate.ToString();
                        minVolumeDateLbl.Text = minVolumeDate.ToString();

                        dayToBuyLbl.Text = "Best day to buy is " + JsonDataManagement.BestTimeToBuy(startDateString, endDateString);

                        dayToSellLbl.Text = "Best day to sell is " + JsonDataManagement.BestTimeToSell(startDateString, endDateString);

                        bullLbl.Text = "Longest bullish trend was " + longestBullStreakString + " days";
                        bullStartLbl.Text = "From " + longestBullStreakStartDateString;
                        bullEndLbl.Text = "To " + longestBullStreakEndDateString;


                        bearLbl.Text = "Longest bearish trend was " + longestBearStreakString + " days";
                        bearStartLbl.Text = "From " + longestBearStreakStartDateString;
                        bearEndLbl.Text = "To " + longestBearStreakEndDateString;
                    }
                    else
                    {
                        MessageBox.Show("Error fetching data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error fetching bitcoin data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void UpdateChart(List<DateTime> dates, List<decimal> prices)
        {
            bitcoinDataChart.Series.Clear();
            bitcoinDataChart.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea("BitcoinPrices");
            chartArea.AxisX.Title = "Date";
            chartArea.AxisY.Title = "Price (€)";
            chartArea.AxisX.LabelStyle.Format = "yyyy-MM-dd";
            bitcoinDataChart.ChartAreas.Add(chartArea);

            Series series = new Series("Bitcoin Price");
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.DateTime;

            for (int i = 0; i < dates.Count; i++)
            {
                series.Points.AddXY(dates[i], prices[i]);
            }

            bitcoinDataChart.Series.Add(series);
        }
    }
}
