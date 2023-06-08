namespace LabSimmod14
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RobotsCount = new System.Windows.Forms.NumericUpDown();
            this.StationCount = new System.Windows.Forms.NumericUpDown();
            this.Time = new System.Windows.Forms.NumericUpDown();
            this.LambdaVal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MuVal = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StationCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LambdaVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MuVal)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(217, 63);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.LegendText = "Эмпирические даные";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.LegendText = "Теоретические данные";
            series2.Name = " ";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(751, 426);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // RobotsCount
            // 
            this.RobotsCount.Location = new System.Drawing.Point(128, 63);
            this.RobotsCount.Name = "RobotsCount";
            this.RobotsCount.Size = new System.Drawing.Size(83, 20);
            this.RobotsCount.TabIndex = 1;
            this.RobotsCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // StationCount
            // 
            this.StationCount.Location = new System.Drawing.Point(128, 89);
            this.StationCount.Name = "StationCount";
            this.StationCount.Size = new System.Drawing.Size(83, 20);
            this.StationCount.TabIndex = 2;
            this.StationCount.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // Time
            // 
            this.Time.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Time.Location = new System.Drawing.Point(128, 115);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(83, 20);
            this.Time.TabIndex = 3;
            this.Time.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // LambdaVal
            // 
            this.LambdaVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LambdaVal.Location = new System.Drawing.Point(128, 141);
            this.LambdaVal.Name = "LambdaVal";
            this.LambdaVal.Size = new System.Drawing.Size(83, 20);
            this.LambdaVal.TabIndex = 4;
            this.LambdaVal.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Количество роботов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество станций";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Время";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Лямбда";
            // 
            // MuVal
            // 
            this.MuVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MuVal.Location = new System.Drawing.Point(128, 167);
            this.MuVal.Name = "MuVal";
            this.MuVal.Size = new System.Drawing.Size(83, 20);
            this.MuVal.TabIndex = 9;
            this.MuVal.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Мю";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(594, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Роботы-рабочие на фабрике периодически высылаются на работу. Иногда им требуется " +
    "подзарядка. \r\nЧтобы подзарядиться, они направляются к специальным генераторным с" +
    "танциям, которых меньше, чем роботов.";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 198);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(110, 23);
            this.StartButton.TabIndex = 12;
            this.StartButton.Text = "Смоделировать";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 501);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MuVal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LambdaVal);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.StationCount);
            this.Controls.Add(this.RobotsCount);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StationCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LambdaVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MuVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown RobotsCount;
        private System.Windows.Forms.NumericUpDown StationCount;
        private System.Windows.Forms.NumericUpDown Time;
        private System.Windows.Forms.NumericUpDown LambdaVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown MuVal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button StartButton;
    }
}

