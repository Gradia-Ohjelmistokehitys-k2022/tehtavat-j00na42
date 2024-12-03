namespace BitcoinMarketAnalyzer
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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            maxValue = new Label();
            minValue = new Label();
            label6 = new Label();
            label5 = new Label();
            maxDate = new Label();
            minDate = new Label();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGVBitcoin).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dateStart);
            groupBox1.Controls.Add(btnFindFromDates);
            groupBox1.Controls.Add(dateEnd);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(867, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(279, 156);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dates";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(maxValue);
            groupBox2.Controls.Add(minValue);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(maxDate);
            groupBox2.Controls.Add(minDate);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(319, 156);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Bitcoin high/low value";
            // 
            // maxValue
            // 
            maxValue.AutoSize = true;
            maxValue.Location = new Point(182, 95);
            maxValue.Name = "maxValue";
            maxValue.Size = new Size(77, 20);
            maxValue.TabIndex = 5;
            maxValue.Text = "Value Max";
            // 
            // minValue
            // 
            minValue.AutoSize = true;
            minValue.Location = new Point(38, 95);
            minValue.Name = "minValue";
            minValue.Size = new Size(74, 20);
            minValue.TabIndex = 4;
            minValue.Text = "Value Min";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(182, 43);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 3;
            label6.Text = "Highest";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 43);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 2;
            label5.Text = "Lowest";
            // 
            // maxDate
            // 
            maxDate.AutoSize = true;
            maxDate.Location = new Point(182, 75);
            maxDate.Name = "maxDate";
            maxDate.Size = new Size(73, 20);
            maxDate.TabIndex = 1;
            maxDate.Text = "Date Max";
            // 
            // minDate
            // 
            minDate.AutoSize = true;
            minDate.Location = new Point(38, 75);
            minDate.Name = "minDate";
            minDate.Size = new Size(70, 20);
            minDate.TabIndex = 0;
            minDate.Text = "Date Min";
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(12, 174);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(319, 134);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Bitcoin trading value";
            // 
            // groupBox4
            // 
            groupBox4.Location = new Point(485, 206);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(250, 125);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Bear";
            // 
            // groupBox5
            // 
            groupBox5.Location = new Point(741, 206);
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
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGVBitcoin);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGVBitcoin).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateStart;
        private DateTimePicker dateEnd;
        private Label label1;
        private Label label2;
        private Button btnFindFromDates;
        private DataGridView dataGVBitcoin;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label maxValue;
        private Label minValue;
        private Label label6;
        private Label label5;
        private Label maxDate;
        private Label minDate;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
    }
}