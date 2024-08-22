namespace LabSimmod2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Eurovalue = new System.Windows.Forms.NumericUpDown();
            this.Pricelabel = new System.Windows.Forms.Label();
            this.Calcbutton = new System.Windows.Forms.Button();
            this.Dollarlabel = new System.Windows.Forms.Label();
            this.Dollarvalue = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Eurolabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eplabel = new System.Windows.Forms.Label();
            this.dplabel = new System.Windows.Forms.Label();
            this.daylaybel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Eurovalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dollarvalue)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.MaximumAutoSize = 80F;
            chartArea1.AxisX2.MaximumAutoSize = 80F;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.MaximumAutoSize = 80F;
            chartArea1.AxisY2.MaximumAutoSize = 80F;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 92);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.LabelBorderWidth = 10;
            series1.LabelFormat = "f4";
            series1.Legend = "Legend1";
            series1.Name = "Euro";
            series1.SmartLabelStyle.MaxMovingDistance = 1D;
            series1.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Bottom)));
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Green;
            series2.LabelBorderWidth = 10;
            series2.LabelFormat = "f4";
            series2.Legend = "Legend1";
            series2.Name = "Dollar";
            series2.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.None;
            series2.SmartLabelStyle.MaxMovingDistance = 3D;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1141, 403);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // Eurovalue
            // 
            this.Eurovalue.DecimalPlaces = 3;
            this.Eurovalue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Eurovalue.Location = new System.Drawing.Point(98, 28);
            this.Eurovalue.Name = "Eurovalue";
            this.Eurovalue.Size = new System.Drawing.Size(120, 20);
            this.Eurovalue.TabIndex = 1;
            // 
            // Pricelabel
            // 
            this.Pricelabel.AutoSize = true;
            this.Pricelabel.Location = new System.Drawing.Point(32, 30);
            this.Pricelabel.Name = "Pricelabel";
            this.Pricelabel.Size = new System.Drawing.Size(60, 13);
            this.Pricelabel.TabIndex = 2;
            this.Pricelabel.Text = "Initial price:";
            // 
            // Calcbutton
            // 
            this.Calcbutton.Location = new System.Drawing.Point(350, 25);
            this.Calcbutton.Name = "Calcbutton";
            this.Calcbutton.Size = new System.Drawing.Size(117, 23);
            this.Calcbutton.TabIndex = 3;
            this.Calcbutton.Text = "Start/Stop";
            this.Calcbutton.UseVisualStyleBackColor = true;
            this.Calcbutton.Click += new System.EventHandler(this.Calcbutton_Click);
            // 
            // Dollarlabel
            // 
            this.Dollarlabel.AutoSize = true;
            this.Dollarlabel.Location = new System.Drawing.Point(221, 9);
            this.Dollarlabel.Name = "Dollarlabel";
            this.Dollarlabel.Size = new System.Drawing.Size(34, 13);
            this.Dollarlabel.TabIndex = 4;
            this.Dollarlabel.Text = "Dollar";
            // 
            // Dollarvalue
            // 
            this.Dollarvalue.DecimalPlaces = 3;
            this.Dollarvalue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Dollarvalue.Location = new System.Drawing.Point(224, 28);
            this.Dollarvalue.Name = "Dollarvalue";
            this.Dollarvalue.Size = new System.Drawing.Size(120, 20);
            this.Dollarvalue.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Eurolabel
            // 
            this.Eurolabel.AutoSize = true;
            this.Eurolabel.Location = new System.Drawing.Point(95, 9);
            this.Eurolabel.Name = "Eurolabel";
            this.Eurolabel.Size = new System.Drawing.Size(29, 13);
            this.Eurolabel.TabIndex = 6;
            this.Eurolabel.Text = "Euro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1006, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dollar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1006, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Euro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1006, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Days";
            // 
            // eplabel
            // 
            this.eplabel.AutoSize = true;
            this.eplabel.Location = new System.Drawing.Point(1041, 19);
            this.eplabel.Name = "eplabel";
            this.eplabel.Size = new System.Drawing.Size(0, 13);
            this.eplabel.TabIndex = 13;
            // 
            // dplabel
            // 
            this.dplabel.AutoSize = true;
            this.dplabel.Location = new System.Drawing.Point(1048, 45);
            this.dplabel.Name = "dplabel";
            this.dplabel.Size = new System.Drawing.Size(0, 13);
            this.dplabel.TabIndex = 14;
            // 
            // daylaybel
            // 
            this.daylaybel.AutoSize = true;
            this.daylaybel.Location = new System.Drawing.Point(1048, 71);
            this.daylaybel.Name = "daylaybel";
            this.daylaybel.Size = new System.Drawing.Size(0, 13);
            this.daylaybel.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 507);
            this.Controls.Add(this.daylaybel);
            this.Controls.Add(this.dplabel);
            this.Controls.Add(this.eplabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Eurolabel);
            this.Controls.Add(this.Dollarvalue);
            this.Controls.Add(this.Dollarlabel);
            this.Controls.Add(this.Calcbutton);
            this.Controls.Add(this.Pricelabel);
            this.Controls.Add(this.Eurovalue);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Eurovalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dollarvalue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown Eurovalue;
        private System.Windows.Forms.Label Pricelabel;
        private System.Windows.Forms.Button Calcbutton;
        private System.Windows.Forms.Label Dollarlabel;
        private System.Windows.Forms.NumericUpDown Dollarvalue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Eurolabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label eplabel;
        private System.Windows.Forms.Label dplabel;
        private System.Windows.Forms.Label daylaybel;
    }
}

