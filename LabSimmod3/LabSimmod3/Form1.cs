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

namespace LabSimmod3
{
    public partial class Form1 : Form
    {
        int SizeCells = 4;
        int[,] FieldColors;
        int CountRows = 1;
        MaskedTextBox masked = new MaskedTextBox
        {
            Location = new Point(605, 20),
            Size =new Size(25,30),
            Mask="000",
            Text="000"
        };
        Button button = new Button();
        Button ClearButton=new Button();
        
        public Form1()
        { 
            InitializeComponent();
            Init();
        }
        void Init()
        {
            ClientSize = new Size(750, 600);
            MouseDown += Draw;
            DoubleBuffered=true;
            FieldColors = new int[(ClientSize.Width-150)/SizeCells, ClientSize.Height / SizeCells];
            masked.TextChanged += TextChange;
            Controls.Add(masked);
            button.Location = new Point(masked.Right+5, masked.Top/2);
            button.Size = new Size(100, masked.Height);
            button.Text = "Запустить";
            button.MouseDown += (z, x) => Executor();
            Controls.Add(button);
            ClearButton.Location = new Point(masked.Right + 5, button.Bottom + 2);
            ClearButton.Size = new Size(100, masked.Height);
            ClearButton.Text = "Очистить";
            ClearButton.MouseDown += (z, x) => Clear();
            ClearButton.Enabled = false;
            Controls.Add(ClearButton);
        }
        void Clear()
        {
            button.Enabled = true;
            FieldColors = new int[(ClientSize.Width - 150) / SizeCells, ClientSize.Height / SizeCells];
            CountRows = 1;
            Invalidate();
            MouseDown += Draw;
            ClearButton.Enabled = false;
        }

        void Executor()
        {
            button.Enabled = false;
            var rule = Converter(int.Parse(masked.Text),8);
            CountRows = ClientSize.Height / SizeCells;
            for(int i=1;i<CountRows;i++)
            {
                for (int j = 0; j < (ClientSize.Width - 150)/SizeCells; j++)
                {
                    var l = j - 1;
                    var r = j + 1;
                    if (j == (ClientSize.Width - 150) / SizeCells - 1)
                        r = 0;
                    if (j == 0)
                        l = (ClientSize.Width - 150) / SizeCells - 1;
                    for (int k = 0; k < 8; k++)
                    {
                        if (FieldColors[i - 1, l].ToString() + FieldColors[i - 1, j].ToString() + FieldColors[i - 1, r].ToString() == Converter(7-k, 3))
                            FieldColors[i, j] = int.Parse(rule[k].ToString());
                    }
                    //if (FieldColors[i - 1, l].ToString() + FieldColors[i - 1, j].ToString() + FieldColors[i - 1, r].ToString() == "111")
                    //    FieldColors[i, j] = int.Parse(rule[0].ToString());
                    //if (FieldColors[i - 1, l].ToString() + FieldColors[i - 1, j].ToString() + FieldColors[i - 1, r].ToString() == "110")
                    //    FieldColors[i, j] = int.Parse(rule[1].ToString());
                    //if (FieldColors[i - 1, l].ToString() + FieldColors[i - 1, j].ToString() + FieldColors[i - 1, r].ToString() == "101")
                    //    FieldColors[i, j] = int.Parse(rule[2].ToString());
                    //if (FieldColors[i - 1, l].ToString() + FieldColors[i - 1, j].ToString() + FieldColors[i - 1, r].ToString() == "100")
                    //    FieldColors[i, j] = int.Parse(rule[3].ToString());
                    //if (FieldColors[i - 1, l].ToString() + FieldColors[i - 1, j].ToString() + FieldColors[i - 1, r].ToString() == "011")
                    //    FieldColors[i, j] = int.Parse(rule[4].ToString());
                    //if (FieldColors[i - 1, l].ToString() + FieldColors[i - 1, j].ToString() + FieldColors[i - 1, r].ToString() == "010")
                    //    FieldColors[i, j] = int.Parse(rule[5].ToString());
                    //if (FieldColors[i - 1, l].ToString() + FieldColors[i - 1, j].ToString() + FieldColors[i - 1, r].ToString() == "001")
                    //    FieldColors[i, j] = int.Parse(rule[6].ToString());
                    //if (FieldColors[i - 1, l].ToString() + FieldColors[i - 1, j].ToString() + FieldColors[i - 1, r].ToString() == "000")
                    //    FieldColors[i, j] = int.Parse(rule[7].ToString());
                }
            }
            Invalidate();
            ClearButton.Enabled = true;
            MouseDown -= Draw;
        }
        string Converter(int decimalsystem,int count) 
        {
            var binarysystem = Convert.ToString(decimalsystem,2);
            var templenght = binarysystem.Length;
            for (int i = 0; i <  count- templenght; i++)
            {
                binarysystem = 0 + binarysystem;
            }

            return binarysystem;
        }
        private void Draw(object sender, MouseEventArgs e)
        {
            var ThisX = e.X;
            try
            {
                FieldColors[0, ThisX / SizeCells] = FieldColors[0, ThisX / SizeCells] == 1 ? 0 : 1;
                Invalidate();
            }
            catch { }    
        }
        private void TextChange(object sender, EventArgs e)
        {
            try 
            {
                if (int.Parse(masked.Text) > 255)
                {
                    masked.Text = "255";
                }
            }
            catch { }
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            InitCells(e.Graphics);
            if(SizeCells>2)
                InitGrid(e.Graphics);
        }
        private void InitGrid(Graphics g)
        {
            for (int i = 0; i <=CountRows; i++)
            {
                g.DrawLine(new Pen(Color.Black,1),new Point(0,SizeCells*i),new Point(ClientSize.Width-150, SizeCells * i));
            }
           
            for (int i = 0; i <= (ClientSize.Width - 150) / SizeCells-1; i++)
            {
                g.DrawLine(new Pen(Color.Black, 1), new Point(SizeCells * i,0), new Point( SizeCells * i, SizeCells*CountRows));
            }
            g.DrawLine(new Pen(Color.Black, 1), new Point(ClientSize.Width - 150, 0), new Point(ClientSize.Width - 150, SizeCells * ClientSize.Height));
        }
        private void InitCells(Graphics g)
        {
            for(int i=0;i< CountRows; i++) 
            {
                for(int j=0; j < ClientSize.Height / SizeCells;j++)
                {
                    g.DrawLine(new Pen(FieldColors[i, j] == 1 ? Color.Black : Color.White, SizeCells), SizeCells * j, SizeCells * i + SizeCells / 2, SizeCells * j + SizeCells, SizeCells * i + SizeCells / 2);
                }
            }
        }
    }
}
