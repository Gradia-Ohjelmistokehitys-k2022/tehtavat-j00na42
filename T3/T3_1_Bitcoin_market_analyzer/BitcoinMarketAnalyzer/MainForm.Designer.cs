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
            SuspendLayout();
            // 
            // dateStart
            // 
            dateStart.CustomFormat = "";
            dateStart.Format = DateTimePickerFormat.Short;
            dateStart.Location = new Point(129, 161);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(142, 27);
            dateStart.TabIndex = 0;
            dateStart.ValueChanged += dateStart_ValueChanged;
            // 
            // dateEnd
            // 
            dateEnd.CustomFormat = "";
            dateEnd.Format = DateTimePickerFormat.Short;
            dateEnd.Location = new Point(480, 161);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(142, 27);
            dateEnd.TabIndex = 1;
            dateEnd.ValueChanged += dateEnd_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(151, 114);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 2;
            label1.Text = "Starting date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(506, 114);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 3;
            label2.Text = "Ending date";
            // 
            // btnFindFromDates
            // 
            btnFindFromDates.Location = new Point(177, 265);
            btnFindFromDates.Name = "btnFindFromDates";
            btnFindFromDates.Size = new Size(94, 29);
            btnFindFromDates.TabIndex = 4;
            btnFindFromDates.Text = "Find";
            btnFindFromDates.UseVisualStyleBackColor = true;
            btnFindFromDates.Click += btnFindFromDates_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 586);
            Controls.Add(btnFindFromDates);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateEnd);
            Controls.Add(dateStart);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateStart;
        private DateTimePicker dateEnd;
        private Label label1;
        private Label label2;
        private Button btnFindFromDates;
    }
}