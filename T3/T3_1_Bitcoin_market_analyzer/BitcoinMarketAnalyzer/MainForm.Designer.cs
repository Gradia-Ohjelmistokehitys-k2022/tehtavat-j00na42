﻿namespace BitcoinMarketAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dateStart = new DateTimePicker();
            dateEnd = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            btnFindFromDates = new Button();
            dataGVBitcoin = new DataGridView();
            gbDateSearch = new GroupBox();
            gbBitcoinValue = new GroupBox();
            maxValue = new Label();
            minValue = new Label();
            label6 = new Label();
            label5 = new Label();
            maxDate = new Label();
            minDate = new Label();
            gbTradingVolume = new GroupBox();
            maxVolumeDateLbl = new Label();
            minVolumeDateLbl = new Label();
            maxVolumelbl = new Label();
            minVolumeLbl = new Label();
            label4 = new Label();
            label3 = new Label();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGVBitcoin).BeginInit();
            gbDateSearch.SuspendLayout();
            gbBitcoinValue.SuspendLayout();
            gbTradingVolume.SuspendLayout();
            SuspendLayout();
            // 
            // dateStart
            // 
            dateStart.CustomFormat = "";
            dateStart.Format = DateTimePickerFormat.Short;
            dateStart.Location = new Point(107, 36);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(142, 27);
            dateStart.TabIndex = 0;
            dateStart.ValueChanged += dateStart_ValueChanged;
            // 
            // dateEnd
            // 
            dateEnd.CustomFormat = "";
            dateEnd.Format = DateTimePickerFormat.Short;
            dateEnd.Location = new Point(107, 84);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(142, 27);
            dateEnd.TabIndex = 1;
            dateEnd.ValueChanged += dateEnd_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 41);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 2;
            label1.Text = "Starting date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 89);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 3;
            label2.Text = "Ending date";
            // 
            // btnFindFromDates
            // 
            btnFindFromDates.Location = new Point(155, 117);
            btnFindFromDates.Name = "btnFindFromDates";
            btnFindFromDates.Size = new Size(94, 27);
            btnFindFromDates.TabIndex = 4;
            btnFindFromDates.Text = "Find";
            btnFindFromDates.UseVisualStyleBackColor = true;
            btnFindFromDates.Click += btnFindFromDates_Click;
            // 
            // dataGVBitcoin
            // 
            dataGVBitcoin.AllowUserToAddRows = false;
            dataGVBitcoin.AllowUserToDeleteRows = false;
            dataGVBitcoin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGVBitcoin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVBitcoin.Location = new Point(12, 360);
            dataGVBitcoin.Name = "dataGVBitcoin";
            dataGVBitcoin.ReadOnly = true;
            dataGVBitcoin.RowHeadersWidth = 51;
            dataGVBitcoin.Size = new Size(1134, 279);
            dataGVBitcoin.TabIndex = 5;
            dataGVBitcoin.CellContentClick += dataGVBitcoin_CellContentClick;
            // 
            // gbDateSearch
            // 
            gbDateSearch.Controls.Add(label1);
            gbDateSearch.Controls.Add(dateStart);
            gbDateSearch.Controls.Add(btnFindFromDates);
            gbDateSearch.Controls.Add(dateEnd);
            gbDateSearch.Controls.Add(label2);
            gbDateSearch.Location = new Point(867, 12);
            gbDateSearch.Name = "gbDateSearch";
            gbDateSearch.Size = new Size(279, 157);
            gbDateSearch.TabIndex = 6;
            gbDateSearch.TabStop = false;
            gbDateSearch.Text = "Dates";
            // 
            // gbBitcoinValue
            // 
            gbBitcoinValue.Controls.Add(maxValue);
            gbBitcoinValue.Controls.Add(minValue);
            gbBitcoinValue.Controls.Add(label6);
            gbBitcoinValue.Controls.Add(label5);
            gbBitcoinValue.Controls.Add(maxDate);
            gbBitcoinValue.Controls.Add(minDate);
            gbBitcoinValue.Location = new Point(12, 12);
            gbBitcoinValue.Name = "gbBitcoinValue";
            gbBitcoinValue.Size = new Size(319, 157);
            gbBitcoinValue.TabIndex = 7;
            gbBitcoinValue.TabStop = false;
            gbBitcoinValue.Text = "Bitcoin high/low value";
            // 
            // maxValue
            // 
            maxValue.AutoSize = true;
            maxValue.Location = new Point(182, 106);
            maxValue.Name = "maxValue";
            maxValue.Size = new Size(77, 20);
            maxValue.TabIndex = 5;
            maxValue.Text = "Value max";
            // 
            // minValue
            // 
            minValue.AutoSize = true;
            minValue.Location = new Point(38, 106);
            minValue.Name = "minValue";
            minValue.Size = new Size(74, 20);
            minValue.TabIndex = 4;
            minValue.Text = "Value min";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(182, 32);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 3;
            label6.Text = "Highest";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 32);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 2;
            label5.Text = "Lowest";
            // 
            // maxDate
            // 
            maxDate.AutoSize = true;
            maxDate.Location = new Point(182, 77);
            maxDate.Name = "maxDate";
            maxDate.Size = new Size(73, 20);
            maxDate.TabIndex = 1;
            maxDate.Text = "Date max";
            // 
            // minDate
            // 
            minDate.AutoSize = true;
            minDate.Location = new Point(38, 77);
            minDate.Name = "minDate";
            minDate.Size = new Size(70, 20);
            minDate.TabIndex = 0;
            minDate.Text = "Date min";
            // 
            // gbTradingVolume
            // 
            gbTradingVolume.Controls.Add(maxVolumeDateLbl);
            gbTradingVolume.Controls.Add(minVolumeDateLbl);
            gbTradingVolume.Controls.Add(maxVolumelbl);
            gbTradingVolume.Controls.Add(minVolumeLbl);
            gbTradingVolume.Controls.Add(label4);
            gbTradingVolume.Controls.Add(label3);
            gbTradingVolume.Location = new Point(12, 175);
            gbTradingVolume.Name = "gbTradingVolume";
            gbTradingVolume.Size = new Size(319, 157);
            gbTradingVolume.TabIndex = 8;
            gbTradingVolume.TabStop = false;
            gbTradingVolume.Text = "Bitcoin trading volume";
            // 
            // maxVolumeDateLbl
            // 
            maxVolumeDateLbl.AutoSize = true;
            maxVolumeDateLbl.Location = new Point(182, 77);
            maxVolumeDateLbl.Name = "maxVolumeDateLbl";
            maxVolumeDateLbl.Size = new Size(73, 20);
            maxVolumeDateLbl.TabIndex = 5;
            maxVolumeDateLbl.Text = "Date max";
            // 
            // minVolumeDateLbl
            // 
            minVolumeDateLbl.AutoSize = true;
            minVolumeDateLbl.Location = new Point(38, 77);
            minVolumeDateLbl.Name = "minVolumeDateLbl";
            minVolumeDateLbl.Size = new Size(70, 20);
            minVolumeDateLbl.TabIndex = 4;
            minVolumeDateLbl.Text = "Date min";
            // 
            // maxVolumelbl
            // 
            maxVolumelbl.AutoSize = true;
            maxVolumelbl.Location = new Point(182, 106);
            maxVolumelbl.Name = "maxVolumelbl";
            maxVolumelbl.Size = new Size(90, 20);
            maxVolumelbl.TabIndex = 3;
            maxVolumelbl.Text = "Max volume";
            // 
            // minVolumeLbl
            // 
            minVolumeLbl.AutoSize = true;
            minVolumeLbl.Location = new Point(38, 106);
            minVolumeLbl.Name = "minVolumeLbl";
            minVolumeLbl.Size = new Size(87, 20);
            minVolumeLbl.TabIndex = 2;
            minVolumeLbl.Text = "Min volume";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(182, 32);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 1;
            label4.Text = "Highest";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 32);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 0;
            label3.Text = "Lowest";
            // 
            // groupBox4
            // 
            groupBox4.Location = new Point(337, 192);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(250, 125);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Bear";
            // 
            // groupBox5
            // 
            groupBox5.Location = new Point(593, 192);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(250, 125);
            groupBox5.TabIndex = 10;
            groupBox5.TabStop = false;
            groupBox5.Text = "Bull";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 651);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(gbTradingVolume);
            Controls.Add(gbBitcoinValue);
            Controls.Add(gbDateSearch);
            Controls.Add(dataGVBitcoin);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGVBitcoin).EndInit();
            gbDateSearch.ResumeLayout(false);
            gbDateSearch.PerformLayout();
            gbBitcoinValue.ResumeLayout(false);
            gbBitcoinValue.PerformLayout();
            gbTradingVolume.ResumeLayout(false);
            gbTradingVolume.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateStart;
        private DateTimePicker dateEnd;
        private Label label1;
        private Label label2;
        private Button btnFindFromDates;
        private DataGridView dataGVBitcoin;
        private GroupBox gbDateSearch;
        private GroupBox gbBitcoinValue;
        private Label maxValue;
        private Label minValue;
        private Label label6;
        private Label label5;
        private Label maxDate;
        private Label minDate;
        private GroupBox gbTradingVolume;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Label maxVolumelbl;
        private Label minVolumeLbl;
        private Label label4;
        private Label label3;
        private Label maxVolumeDateLbl;
        private Label minVolumeDateLbl;
    }
}