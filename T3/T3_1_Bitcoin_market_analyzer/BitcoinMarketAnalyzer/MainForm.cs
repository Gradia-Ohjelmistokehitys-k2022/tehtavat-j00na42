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
using BitcoinMarketAnalyzer.Model;
using Newtonsoft.Json.Linq;



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
            Console.WriteLine("Testi");

            dataGVBitcoin.DataBindingComplete += (o, _) =>
            {
                this.dataGVBitcoin.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            };

            dateStart.MaxDate = DateTime.Now.AddDays(-1);
            dateEnd.MaxDate = DateTime.Now;

            dateStart.MinDate = DateTime.Now.AddYears(-1);
            dateEnd.MinDate = DateTime.Now.AddYears(-1);
            
            //

            startDate = dateStart.Value.Date;
            endDate = dateEnd.Value.Date;

            string startDateString = startDate.ToString("yyyy-MM-dd");
            string endDateString = endDate.ToString("yyyy-MM-dd");
            
            
            /*
            dataGVBitcoin.DataSource = JsonDataManagement.GetBitcoins(startDateString, endDateString);
            */


            var (maxPriceBitcoin, minPriceBitcoin) = JsonDataManagement.GetMaxAndMinBitcoins(startDateString, endDateString);

            var (maxValueDate, minValueDate) = JsonDataManagement.GetMaxAndMinDates(startDateString, endDateString);


            maxValue.Text = Math.Round(maxPriceBitcoin.Price, 0).ToString() + " €";
            minValue.Text = Math.Round(minPriceBitcoin.Price, 0).ToString() + " €";

            maxDate.Text = maxValueDate.ToString();
            minDate.Text = minValueDate.ToString();
           

            //
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {

        }
        


        private void btnFindFromDates_Click(object sender, EventArgs e)
        {
            startDate = dateStart.Value.Date;
            endDate = dateEnd.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Starting date cannot be greater than ending date!", "Error 202", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string startDateString = startDate.ToString("yyyy-MM-dd");
                string endDateString = endDate.ToString("yyyy-MM-dd");

                var bitcoinData = JsonDataManagement.GetBitcoins(startDateString, endDateString);
                if (bitcoinData != null)
                {
                    dataGVBitcoin.DataSource = bitcoinData;

                    var (maxBitcoin, minBitcoin) = JsonDataManagement.GetMaxAndMinBitcoins(startDateString, endDateString);


                    var (maxValueDate, minValueDate) = JsonDataManagement.GetMaxAndMinDates(startDateString, endDateString);


                    if (maxBitcoin != null && minBitcoin != null)
                    {
                        maxValue.Text = Math.Round(maxBitcoin.Price, 0).ToString() + " €";
                        minValue.Text = Math.Round(minBitcoin.Price, 0).ToString() + " €";

                        maxDate.Text = maxValueDate.ToString();
                        minDate.Text = minValueDate.ToString();
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


        private void dataGVBitcoin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
