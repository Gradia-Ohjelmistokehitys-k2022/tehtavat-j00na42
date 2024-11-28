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
        public MainForm()
        {
            MaximizeBox = false;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Testi");
            

            dateStart.MaxDate = DateTime.Now.AddDays(-1);
            dateEnd.MaxDate = DateTime.Now;

            dateStart.MinDate = DateTime.Now.AddYears(-1);
            dateEnd.MinDate = DateTime.Now.AddYears(-1);
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFindFromDates_Click(object sender, EventArgs e)
        {
            

            DateTime startDate = dateStart.Value.Date;
            DateTime endDate = dateEnd.Value.Date;


            string startDateString = startDate.ToString("yyyy-MM-dd+1");
            string endDateString = endDate.ToString("yyyy-MM-dd+1");


            JsonDataManagement.GetBitcoins(startDateString, endDateString);
        }

    }
}
