using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace LabSimmod1
{
    public partial class Form1 : Form
    {
        
        const decimal g = 9.81M;
        const decimal C = 0.15M;
        const decimal rho = 1.29M;
        decimal t, x, y, v0, sina, cosa, S, m, k, vx, vy, mh, dt;
        int colind =0;
        int i = -1;

        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
        }
        

        

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            if ((!timer1.Enabled) && (colind != Result.ColumnCount - 1))
            {
                i++;
                colind++;
                t = 0;
                x = 0;
                mh = 0;
                dt = 0.01M;
                dt = dt * (decimal)Math.Pow(10, (double)Timestep.Value);
                y = HeightInput.Value;
                m = WeightInput.Value;
                v0 = SpeedInput.Value;
                double a = (double)AngleInput.Value * Math.PI / 180;
                sina = (decimal)Math.Sin(a);
                cosa = (decimal)Math.Cos(a);
                S = SizeInput.Value;
                k = 0.5M * C * rho * S / m;
                vx = v0 * cosa;
                vy = v0 * sina;
                chart1.Series[i].Points.AddXY(x, y);
                timer1.Start();
            }
            else errlabel.Text = "To many charts. Click 'Clear' button.";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            t += dt;
            decimal v = (decimal)Math.Sqrt((double)(vx * vx + vy * vy));
            vx = vx - vx * k * v * dt;
            vy = vy - (g + k * vy * v) * dt;
            x +=  vx * dt;
            y +=  vy * dt;
            if (y > mh) mh = y;
            chart1.Series[i].Points.AddXY(x, y);
            if (y < 0 || y >= (decimal)chart1.ChartAreas[0].AxisY.Maximum ||
                x >= (decimal)chart1.ChartAreas[0].AxisX.Maximum)
            {
                timer1.Stop();
                Result.Controls.Add(new Label() { ForeColor = chart1.Series[i].Color, Text = dt.ToString() }, colind, 0) ; 
                Result.Controls.Add(new Label() { ForeColor = chart1.Series[i].Color, Text = x.ToString()}, colind, 1);
                Result.Controls.Add(new Label() { ForeColor = chart1.Series[i].Color, Text = mh.ToString()}, colind, 2);
                Result.Controls.Add(new Label() { ForeColor = chart1.Series[i].Color, Text = v.ToString()}, colind, 3);
            }   
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            for (int j = i; j >= 0; j--)
            {
                chart1.Series[j].Points.Clear();

            }
            i = -1;
            colind = 0;
            Result.Controls.Clear();
            Result.Controls.Add(new Label() { Text = "Time step" }, 0, 0);
            Result.Controls.Add(new Label() { Text = "Distance" }, 0, 1);
            Result.Controls.Add(new Label() { Text = "Max Height" }, 0, 2);
            Result.Controls.Add(new Label() { Text = "End point speed" }, 0, 3);
            errlabel.Text = "";
        }
    }
}
