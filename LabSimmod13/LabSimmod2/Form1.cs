using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace LabSimmod2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX2.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY2.Minimum = 0;
        }
        double Dollarprice, Europrice;
        int state = 0, days = 0;


        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        double NormalDestrVal(double M, double D)
        {
            Random rnd = new Random();
            double Base= Math.Sqrt(-2 * Math.Log(rnd.NextDouble())) * Math.Sin(2 * Math.PI * rnd.NextDouble());
            double val= Base * Math.Sqrt(D) + M;
            return val;
        }
        double WienerProc(double prevVal)
        {
            double val = prevVal + NormalDestrVal(0, 1);//нет коэффициента Math.Sqrt((t+1)-t),  потому что он всегда равен 1
            return val;
        }
        double GeomBrownProc(double prevVal, int t,double drift, double volatility)
        {
            double val;
            Random rnd = new Random();
            if (rnd.NextDouble() > 0.5)
                val = prevVal * Math.Exp((drift - (volatility * volatility / 2)) + volatility * WienerProc(prevVal));//нет коэффициента Math.Sqrt((t+1)-t),  потому что он всегда равен 1
            else val = prevVal * Math.Exp((drift - (volatility * volatility / 2)) - volatility * WienerProc(prevVal));
            return val; 
            


        }
        void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                         ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    var xVal = Math.Round(result.ChartArea.AxisX.PixelPositionToValue(pos.X),0);
                    var yVal = Math.Round(result.ChartArea.AxisY.PixelPositionToValue(pos.Y), 3);

                    tooltip.Show("Day=" + xVal + ", price=" + yVal, this.chart1,
                                 pos.X, pos.Y);
                }
            }
        }

        private void Calcbutton_Click(object sender, EventArgs e)
        {
            if (state == 0)
            {
                state = 1;
                Europrice = (double)Eurovalue.Value;
                Dollarprice = (double)Dollarvalue.Value;
                timer1.Start();
                
            } 
            else 
            {
                timer1.Stop();
                state = 0;
                eplabel.Text = Math.Round(Europrice,3).ToString();
                dplabel.Text = Math.Round(Dollarprice,3).ToString();
                daylaybel.Text = days.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Europrice = GeomBrownProc(Europrice,days, 0.0001, 0.0002);
            Dollarprice = GeomBrownProc(Dollarprice, days, 0.0002, 0.0001);
            
            chart1.Series[0].Points.AddXY(days, Europrice);
            chart1.Series[1].Points.AddXY(days, Dollarprice);
            if (days % 20 == 0)
            {
                chart1.Series[0].Points[days].IsValueShownAsLabel = true;
                chart1.Series[1].Points[days].IsValueShownAsLabel = true;
            }
            days += 1;
        }
    }
}
