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
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace LabSimmod8
{


    public partial class Form1 : Form
    {
        Random rnd = new Random();
        double EightOneProb = 0.5;
        string[] ArrResponse = {
  "Бесспорно", "Предрешено", "Никаких сомнений", "Оперделенно да", "Можешь быть уверен в этом",
  "Мне кажется да", "Вероятнее всего", "Хорошие перспективы", "Знаки говорят - да", "Да",
  "Пока не ясно, попробуй снова", "Спроси позже", "Лучше не рассказывать", "Сейчас нельзя предсказать", "Сконцентрируйся и спроси опять",
  "Даже не думай", "Мой ответ — «нет»", "По моим данным — «нет»", "Перспективы не очень хорошие", "Весьма сомнительно"};
        TextBox[] textboxes;
        System.Windows.Forms.Label[] prob;
        List<double> EightthreeProb;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (rnd.NextDouble() > EightOneProb)
                label2.Text = "Да";
            else label2.Text = "Нет";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int numResponse = Convert.ToInt32(Math.Floor(rnd.NextDouble() * ArrResponse.Length));
                label4.Text = ArrResponse[numResponse];

            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                button4.Visible = false;
                numericUpDown2.Visible = false;
                label9.Visible = false;
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
                    button4.Visible = true;
                    numericUpDown2.Visible = true;
                    label9.Visible = true;
                }
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if(EightthreeProb!=null)
            {
                EightthreeProb.Clear();
                EightthreeProb = null;
            }

            EightthreeProb= new List<double>(); 
            
            for (int i=0;i< textboxes.Length;i++)
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
                A= rnd.NextDouble();
                int i = 0;
                while (A > 0)
                {
                    A -= EightthreeProb[i];
                    i++;
                    
                }
                results[i - 1] = results[i - 1] + 1;

            }
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < EightthreeProb.Count; i++)
            {
                chart1.Series[0].Points.AddXY(Convert.ToDouble(i+1), results[i] / expnumb);
            }
        }

    }
}
