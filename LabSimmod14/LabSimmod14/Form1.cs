using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabSimmod14
{
    public partial class Form1 : Form
    {
        Factory fact = new Factory();
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            fact.BeginWork((double)LambdaVal.Value, (double)MuVal.Value, (int)RobotsCount.Value, (double)Time.Value, (int)StationCount.Value);
            Dictionary<int, double> Freq = fact.DistributionAndEmpiricalProbability(fact.InitialAS(), fact.InitialAQR());
            Dictionary<int, double> Stat = fact.Statistics();

            foreach (int i in Freq.Keys)
            {
                chart1.Series[0].Points.AddXY(i, Freq[i]);
            }
            foreach (int i in Stat.Keys)
            {
                chart1.Series[1].Points.AddXY(i, Stat[i]);
            }
        }
    }
}
