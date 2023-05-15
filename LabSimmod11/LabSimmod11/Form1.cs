using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LabSimmod11
{

    public partial class Form1 : Form
    {
        Random rnd = new Random();
        double BoxMullerGen(double MathExp,double Variance)
        {
            return (MathExp+Math.Sqrt(Variance) *Math.Sqrt(-21 * Math.Log(rnd.NextDouble())) * Math.Cos(2 * Math.PI * rnd.NextDouble()));
        }
        double Exp(double[] probsmass)
        {
            double aver = 0;
            for (int i = 0; i < probsmass.Length; i++)
                aver += probsmass[i] * (i + 1);
            return aver;
        }
        public double Var(double[] probsmass)
        {
            double variance = 0;
            for (int i = 0; i < probsmass.Length; i++)
                variance += probsmass[i] * (i + 1) * (i + 1);
            variance -= Exp(probsmass) * Exp(probsmass);
            return variance;
        }
        double AbsoluteErrors(double Empiric, double Statistic)
        {
            return Math.Abs(Empiric - Statistic);
        }
        double RelativeeErrors(double abserr, double statvalue)
        {
            return abserr / Math.Abs(statvalue);
        }
        void Otrezok(double Mathexp,double size, string[] names)
        {
            double min = Mathexp - size;
            double max = Mathexp + size;
            double Len = max - min;
            int onesize = Convert.ToInt32(Math.Round(Len));
            names = new string[onesize];

        }
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            double expnumb = Convert.ToInt32(textBox3.Text);
            for (int k = 0; k < expnumb; k++)
            {

            }
            
            chart1.Series[0].Points.AddXY(1, 1);
        }
    }


}
