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

namespace LabSimmod2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
        

        }
        double Dollarprice, Europrice;
        int state = 0, days = 0;

        const double Ek = 0.02,Dk = 0.05;
        
        Random Ernd = new Random();
        Random Drnd = new Random();
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
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Europrice = Europrice * (1 + Ek * (Ernd.NextDouble() - 0.5));
            Dollarprice = Dollarprice * (1 + Dk * (Drnd.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(days, Europrice);
            chart1.Series[1].Points.AddXY(days, Dollarprice);
            days += 1;
        }
    }
}
