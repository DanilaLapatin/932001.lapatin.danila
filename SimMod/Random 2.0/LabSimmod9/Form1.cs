using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabSimmod9
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        TextBox[] textboxes;
        System.Windows.Forms.Label[] prob;
        List<double> EightthreeProb;
        public double Exp(double[] probsmass)
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
        public double AbsoluteErrors(double Empiric, double Statistic)
        {
            return Math.Abs(Empiric - Statistic);
        }
        public double RelativeeErrors(double abserr, double statvalue)
        {
            return abserr / Math.Abs(statvalue);
        }
        double[] chiSquaredCriticalValues = { 9.488, 13.277, 18.467 };
        public double chiSquared(double expnumb, double[] probsmass, double[] statmass) 
        {
            double chiSquared = 0;
            for (int i = 0; i < probsmass.Length; i++)
                chiSquared += probsmass[i] * probsmass[i] / (statmass[i] * expnumb);
            chiSquared -= expnumb;
            return chiSquared;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (prob != null)
            {

                for (int i = 0; i < prob.Length; i++)
                {
                    Controls.Remove(prob[i]);
                    prob[i].Dispose();
                    Controls.Remove(textboxes[i]);
                    textboxes[i].Dispose();
                }
                prob = null;
                textboxes = null;
                button2.Visible = false;
                numericUpDown2.Visible = false;
                label2.Visible = false;
            }
            else
            {
                int tbnumber = Convert.ToInt32(numericUpDown1.Value);
                prob = new System.Windows.Forms.Label[tbnumber];
                textboxes = new TextBox[tbnumber];
                for (int i = 0; i < tbnumber; i++)
                {
                    prob[i] = new System.Windows.Forms.Label();
                    prob[i].Text = "Prob" + (i + 1).ToString();
                    this.Controls.Add(prob[i]);
                    prob[i].Location = new Point(numericUpDown1.Location.X, numericUpDown1.Location.Y + (i + 1) * 30);
                    textboxes[i] = new TextBox();
                    textboxes[i].Location = new Point(prob[i].Right + 10, prob[i].Location.Y);
                    this.Controls.Add(textboxes[i]);
                    button2.Visible = true;
                    numericUpDown2.Visible = true;
                    label2.Visible = true;
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            if (EightthreeProb != null)
            {
                EightthreeProb.Clear();
                EightthreeProb = null;
            }

            EightthreeProb = new List<double>();

            for (int i = 0; i < textboxes.Length; i++)
            {
                EightthreeProb.Add(Convert.ToDouble(textboxes[i].Text));
            }
            double[] results = new double[EightthreeProb.Count];
            for (int i = 0; i < EightthreeProb.Count; i++)
                results[i] = 0;
            double A;
            double expnumb = Convert.ToInt32(numericUpDown2.Value);
            for (int k = 0; k < expnumb; k++)
            {
                A = rnd.NextDouble();
                int i = 0;
                while (A > 0)
                {
                    A -= EightthreeProb[i];
                    i++;
                }
                results[i - 1] = results[i - 1] + 1;
            }
            chart1.Series[0].Points.Clear();
            double[] expprobs = new double[EightthreeProb.Count];
            double[] probs = new double[EightthreeProb.Count];
            for (int i = 0; i < EightthreeProb.Count; i++)
            {
                probs[i] = EightthreeProb[i];
                expprobs[i] = results[i] / expnumb;
            }

            for (int i = 0; i < EightthreeProb.Count; i++)
            {
                chart1.Series[0].Points.AddXY(Convert.ToDouble(i + 1), expprobs[i] );
            }

            double ExpRelaterrors = RelativeeErrors(AbsoluteErrors(Exp(expprobs), Exp(probs)), Exp(probs));
            double VarRelaterrors = RelativeeErrors(AbsoluteErrors(Var(expprobs), Var(probs)), Var(probs));
            double Chisq = chiSquared(expnumb, results, probs);
            label3.Text = "Average: " +Exp(expprobs).ToString();
            label4.Text ="Variance: "+Var(expprobs).ToString();
            label5.Text= "Chi-squared:"+ Chisq.ToString()+" > "+chiSquaredCriticalValues[0].ToString();
            if (Chisq > chiSquaredCriticalValues[0])
                 label5.Text+=" is true";
            else label5.Text += " is false";
        }

    }
}

