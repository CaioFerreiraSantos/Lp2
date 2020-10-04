using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrianguloLp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Algum Lado se Encotra Sem Valor");
            }
            else
            {
                double ladoa, ladob, ladoc;
                ladoa = Double.Parse(textBox1.Text);
                ladob = Double.Parse(textBox2.Text);
                ladoc = Double.Parse(textBox3.Text);
                if (ladoa < 0 || ladob < 0 || ladoc < 0)
                {
                    MessageBox.Show("Lado de Valor Negativo");
                }
                else if (ladoa > (ladob - ladoc) && ladoa > (ladoc - ladob) && ladoa < ladob + ladoc && ladob > (ladoa - ladoc) && ladob > (ladoc - ladoa) && ladob < ladoa + ladoc && ladoc > (ladob - ladoa) && ladoc > (ladoa - ladob) && ladoc < ladob + ladoa)
                {
                    if (ladoa == ladob && ladoa == ladoc && ladob == ladoc)
                    {
                        MessageBox.Show("É um Triangulo Equilatero");
                    }
                    else if (ladoa == ladob || ladoa == ladoc || ladob == ladoc)
                    {
                        MessageBox.Show("É um Triangulo Isósceles");
                    }
                    else
                    {
                        MessageBox.Show("É um Triangulo Escaleno");
                    }

                }
                else
                {
                    MessageBox.Show("Não é um Triangulo");
                }
            }
        }
    }
}
