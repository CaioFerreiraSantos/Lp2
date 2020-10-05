using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraLp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x;
        double Pnum, Snum, Res;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            x = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            x = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pnum = Double.Parse(textBox1.Text);
            Snum = Double.Parse(textBox2.Text);
            switch(x)
            {
                case 1:
                    {
                        Res = Pnum + Snum;
                        textBox3.Text = Res.ToString();
                        break;
                    }
                case 2:
                    {
                        Res = Pnum - Snum;
                        textBox3.Text = Res.ToString();
                        break;
                    }
                case 3:
                    {
                        Res = Pnum * Snum;
                        textBox3.Text = Res.ToString();
                        break;
                    }
                case 4:
                    {
                        if(Snum != 0)
                        {
                            Res = Pnum / Snum;
                            textBox3.Text = Res.ToString();
                        }
                        break;
                    }
            }
            if ( x >= 1 && x <=4)
            {
            	x = 0;
            	textBox1.Text = "";
            	textBox2.Text = "";
	        }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            x = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
