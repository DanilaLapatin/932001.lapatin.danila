using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabSimmod12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClearButton.Visible = false;
        }
        int T = 1000;
        double t = 0;
        double k = 0;
        double[,] Q = new double[3, 3];
        string[] wet = {"Ясно","Облачно","Пасмурно" };
        double Tau;
        int iTau = 0;
        double[] Freq = new double[3];
        void Gnr(int time)
        {
            Random rnd = new Random();
            for (int i = 0; i < time; i++)
            {
                Tau = Math.Log(rnd.NextDouble()) / Q[iTau, iTau];
                t += Tau;
                double[] p = new double[3];
                for (int j = 0; j < 3; j++)
                    if (iTau != j) p[j] = -(Q[iTau, j] / Q[iTau, iTau]);
                    else p[j] = 0;
                double newrnd = rnd.NextDouble();
                for (int j = 0; j < 3; j++)
                {
                    newrnd -= p[j];
                    if (newrnd <= 0)
                    {
                        iTau = j;
                        break;
                    }
                }
            }
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            
            Q[0, 1] = 0.3; Q[0, 2] = 0.1;
            Q[1, 0] = 0.4; Q[1, 2] = 0.4;
            Q[2, 0] = 0.1; Q[2, 1] = 0.4;
            for (int i = 0; i < 3; i++)
            {
                Q[i, i] = 0;
                for (int j = 0; j < 3; j++)
                    if (i != j) 
                        Q[i, i] -= Q[i, j];   
            }
            Gnr(T);
            timer1.Start();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int i_new = 0;
            double t_new;
            Tau = Math.Log(rnd.NextDouble()) / Q[iTau, iTau];
            t_new = t + Tau;
            k += Tau;
            double[] p = new double[3];
            for (int j = 0; j < 3; j++)
            {
                if (iTau != j) p[j] = -(Q[iTau, j] / Q[iTau, iTau]);
                else p[j] = 0;
            }

            double newran = rnd.NextDouble();
            for (int j = 0; j < 3; j++)
            {
                newran = newran - p[j];
                if (newran <= 0)
                {
                    i_new = j;
                    break;
                }
            }
            Freq[iTau] += t_new - t;
            iTau= i_new;
            t = t_new;

            label1.Text = Math.Round(k, 3) + " дней";
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            t = 0;
            k = 0;
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < 3; i++)
                Freq[i] = 0;
            label1.Text ="0 дней";
            ClearButton.Visible = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += Freq[i];
            }
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < 3; i++)
            {
                chart1.Series[0].Points.AddXY(wet[i], Freq[i] / sum);
            }
            timer1.Stop();
            if (ClearButton.Visible == false) ClearButton.Visible = true;
        }


    }
}
