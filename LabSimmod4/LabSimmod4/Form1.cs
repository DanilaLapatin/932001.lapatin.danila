using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabSimmod4
{
    public partial class Form1 : Form
    {
        int SizeCells = 8,sum;
        int[,] FieldColors,NextFieldColors;
        int CountRows, CountCollumns;
        Button button = new Button
        {
            Location = new Point(605, 20),
            Size = new Size(100, 30),
            Text = "Старт/Стоп"
        };
        Button ClearButton = new Button();
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            ClientSize = new Size(750, 600);
            CountRows = ClientSize.Height / SizeCells;
            CountCollumns= (ClientSize.Width - 150) / SizeCells;
            MouseDown += Draw;
            DoubleBuffered = true;
            FieldColors = new int[CountRows, CountCollumns];
            button.Click += (z, x) => StopStarter(); 
            Controls.Add(button);
            ClearButton.Location = new Point(605, button.Bottom + 2);
            ClearButton.Size = new Size(100, button.Height);
            ClearButton.Text = "Очистить";
            ClearButton.Click += (z, x) => Clear();
            ClearButton.Enabled = false;
            Controls.Add(ClearButton);
        }

        private void StopStarter()
        {
            if (timer1.Enabled == false)
            {
                MouseDown -= Draw;
                ClearButton.Enabled = false;
                timer1.Start();
            }
            else
            {
                MouseDown += Draw;
                ClearButton.Enabled = true;
                timer1.Stop();
            }
        }

        void Clear()
        {
            FieldColors = new int[CountRows, CountCollumns];
            Invalidate();
            ClearButton.Enabled = false;
        }

        void Executor()
        {
            NextFieldColors = new int[CountRows, CountCollumns];
            if (Comparisor(FieldColors,NextFieldColors)==true)
            {
                MouseDown += Draw;
                timer1.Stop();
                return  ;
            }
            CountRows = ClientSize.Height / SizeCells;
            for (int i = 0; i < CountRows; i++)
            {
                int u =i-1; 
                int d = i + 1;


                if (i == CountRows - 1)
                    d = 0;
                if (i == 0)
                    u = CountRows - 1;
                for (int j = 0; j < CountCollumns; j++)
                {
                    int l = j - 1;
                    int r = j + 1;
                    

                    if (j == CountCollumns - 1)
                        r = 0;
                    if (j == 0)
                        l = CountCollumns - 1;

                    sum = FieldColors[u, l] + +FieldColors[u, j] + FieldColors[u, r] +
                            FieldColors[i, l] + +FieldColors[i, r] +
                            FieldColors[d, l] + FieldColors[d, j] + FieldColors[d, r];

                    if (FieldColors[i, j] == 0)
                        if ( sum== 3)
                            NextFieldColors[i, j] = 1;
                    if (FieldColors[i, j] == 1)
                    {
                        if (sum != 3 && sum != 2)
                            NextFieldColors[i, j] = 0;
                        else
                            NextFieldColors[i, j] = 1;
                    }        
                }
            }
            FieldColors = NextFieldColors;
            Invalidate();
            MouseDown -= Draw;
        }
        bool Comparisor(int[,] one, int[,] two)
        {
            for (int i = 0; i < CountRows; i++)
            {
                for (int j = 0; j < CountCollumns; j++)
                {
                    if (one[i, j] != two[i, j])
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }
        private void Draw(object sender, MouseEventArgs e)
        {
            var ThisX = e.X;
            var ThisY = e.Y;
            try
            {
                FieldColors[ThisY/SizeCells, ThisX / SizeCells] = FieldColors[ThisY / SizeCells, ThisX / SizeCells] == 1 ? 0 : 1;
                Invalidate();
            }
            catch { }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            InitCells(e.Graphics);
            if (SizeCells > 2)
                InitGrid(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Executor();
        }

        private void InitGrid(Graphics g)
        {
            for (int i = 0; i <= CountRows; i++)
            {
                g.DrawLine(new Pen(Color.Black, 1), new Point(0, SizeCells * i), new Point(ClientSize.Width - 150, SizeCells * i));
            }

            for (int i = 0; i <= (ClientSize.Width - 150) / SizeCells - 1; i++)
            {
                g.DrawLine(new Pen(Color.Black, 1), new Point(SizeCells * i, 0), new Point(SizeCells * i, SizeCells * CountRows));
            }
            g.DrawLine(new Pen(Color.Black, 1), new Point(ClientSize.Width - 150, 0), new Point(ClientSize.Width - 150, SizeCells * ClientSize.Height));
        }
        private void InitCells(Graphics g)
        {
            for (int i = 0; i < CountRows; i++)
            {
                for (int j = 0; j < ClientSize.Height / SizeCells; j++)
                {
                    g.DrawLine(new Pen(FieldColors[i, j] == 1 ? Color.Black : Color.White, SizeCells), SizeCells * j, SizeCells * i + SizeCells / 2, SizeCells * j + SizeCells, SizeCells * i + SizeCells / 2);
                }
            }
        }
    }
}
