using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LabSimmod7
{
    public partial class Form1 : Form
    {
        int clients;
        public Form1()
        {
            InitializeComponent();
        }
        double averagecheck = 400, ADDcoef =0.01;
        Random random = new Random();
        int Recl, salaries, ingr, monthCounter = 0, KOLpeopleADD;

        double curSum, stream_income;
        private void btNextMonth_Click(object sender, EventArgs e)
        {
            monthCounter++;
            stream_income = 0;  KOLpeopleADD = 0;
            curSum = 0; ADDcoef = 0;
            Recl = Convert.ToInt32(textBox1.Text);
            ingr = Convert.ToInt32(textBox5.Text);
            salaries = Convert.ToInt32(textBox2.Text);
            KOLpeopleADD = Convert.ToInt32(Recl * ADDcoef);
            clients = Convert.ToInt32(random.Next(100, 1000))+ KOLpeopleADD; ;
            stream_income = clients*averagecheck;
            curSum = stream_income - Recl - salaries-ingr;
            textBox3.Text = clients.ToString();
            textBox4.Text = curSum.ToString();
            chart1.Series[0].Points.AddXY(monthCounter, curSum);
        }
    }
}
