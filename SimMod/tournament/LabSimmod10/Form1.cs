using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace LabSimmod10
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Label[] Table;//Названия команд на форме
        System.Windows.Forms.Label[] results;//очки команд на форме
        System.Windows.Forms.Label[] Win;//победы на форме
        System.Windows.Forms.Label[] Eq;//ничьи на форме
        System.Windows.Forms.Label[] Los;//поражения на форме
        Random rnd = new Random();
        int Pouassonresult(double lambda)//вычисление количество забитых мячей на основе среднего значения забитых мячей и базового счётчика rnd
        {
            int m = 0;
            double Sum = 0;
            while (Sum >= -lambda)
            {
                Sum += Math.Log(rnd.NextDouble());
                m++;
            }
            return m;
        }
        void Game(int[] wins, int[] eqs, int[] los, int[] Teams, int fn, int sn, int first,int second)//Игра между командами
        {
                    if (first > second)
                    {
                        Teams[fn] += 3;
                        wins[fn] += 1;
                        los[sn] += 1;
                    }

                    else if (first == second)
                    {
                        Teams[fn] += 1;
                        Teams[sn] += 1;
                        eqs[fn] += 1;
                        eqs[sn] += 1;
                    }
                    else
                    {
                        Teams[sn] += 3;
                        wins[sn] += 1;
                        los[fn] += 1;
                    }
        }
        int Turn(int[] Teams, List<double> lambdas, System.Windows.Forms.Label[] Win,System.Windows.Forms.Label[] Eq, System.Windows.Forms.Label[] Los, System.Windows.Forms.Label[] results )
        {//Турнир
            
            int[] wins = new int[8];
            int[] eqs = new int[8];
            int[] los = new int[8];
            for (int i = 0; i < 7; i++)
                for (int j = i + 1; j < 8; j++)
                {
                    Game(wins, eqs, los, Teams,i,j, Pouassonresult(lambdas[i]), Pouassonresult(lambdas[j]));
                }
            int winner = 0;
            int max = 0;
            for (int i = 0; i < 8; i++)
                if (Teams[i]>max)
                {
                    winner = i;
                    max = Teams[i];
                }
            List<int> prewinners = new List<int>();//Предпобедители, набравшие максимум очков
            for (int i = 0; i < 8; i++)
                if (Teams[i] == max)
                    prewinners.Add(i);
            if(prewinners.Count>1)
                for (int i = 0; i < prewinners.Count-1;i++)//игры среди победителей
                    for (int j = i + 1; j < prewinners.Count; j++)
                        Game(wins, eqs, los, Teams, prewinners[i], prewinners[j], Pouassonresult(lambdas[prewinners[i]]), Pouassonresult(lambdas[prewinners[j]]));
            for (int i = 0; i < 8; i++)
                if (Teams[i] > max)
                {
                    winner = i;
                    max = Teams[i];
                }
            for (int i = 0; i < 8; i++)
            {
                results[i].Text = Teams[i].ToString();
                Win[i].Text = wins[i].ToString();
                Eq[i].Text = eqs[i].ToString();
                Los[i].Text = los[i].ToString();
            }
            return winner;
        }
        


        string[] Teamnames = new string[] 
        {
            "Борцы за победу",
            "Ловкие парни",
            "Неуловимые пираты",
            "Football Muscle",
            "Red Bull" ,
            "The Lucky Cranes",
            "Grand Foxes",
            "Crazy Nets"};

        public Form1()
        {
            InitializeComponent();
            Table = new System.Windows.Forms.Label[8];
            results = new System.Windows.Forms.Label[8];
            Win= new System.Windows.Forms.Label[8];
            Eq= new System.Windows.Forms.Label[8];
            Los= new System.Windows.Forms.Label[8];
            for (int i = 0; i < Teamnames.Length; i++)
            {
                Table[i] = new System.Windows.Forms.Label();
                Table[i].Text = Teamnames[i] + ": ";
                Table[i].Location = new Point(label1.Location.X, label1.Location.Y + (i + 1) * 30);
                this.Controls.Add(Table[i]);
                results[i] = new Label();
                results[i].Location = new Point(Table[i].Right + 10, Table[i].Location.Y);
                results[i].Text = "0";
                this.Controls.Add(results[i]);
                Win[i] = new Label();
                Win[i].Location = new Point(results[i].Right + 10, results[i].Location.Y);
                Win[i].Text = "0";
                this.Controls.Add(Win[i]);
                Eq[i] = new Label();
                Eq[i].Location = new Point(Win[i].Right + 10, Win[i].Location.Y);
                Eq[i].Text = "0";
                this.Controls.Add(Eq[i]);
                Los[i] = new Label();
                Los[i].Location = new Point(Eq[i].Right + 10, Eq[i].Location.Y);
                Los[i].Text = "0";
                this.Controls.Add(Los[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] Teams = new int[8];//очки команд
            label5.Text = "";
            List<double> lambdas = new List<double>();
           
            for (int i = 0; i < Teamnames.Length; i++)
            {
                lambdas.Add(rnd.NextDouble() * 5);//среднее число забиваемых мячей меньше пяти
            }
            label5.Text="Победила команда '"+Teamnames[Turn(Teams,lambdas, Win,Eq,Los,results)]+"'";

        }
    }
}
