using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpostoLp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double Inss, Irpf, Salf, Salb, Sall;
        string Nome, Aliqin, Aliqir;
        int Fils;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "          ," || maskedTextBox3.Text == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Está faltando preencher todos os campos de informação");
            }
            else
            {
                Nome = maskedTextBox1.Text;
                Salb = Convert.ToDouble(maskedTextBox2.Text);
                Fils = Convert.ToInt32(maskedTextBox3.Text);

                if (Salb <= 800.47)
                {
                    Aliqin = "7.65%";
                    Inss = 0.0765 * Salb;
                }
                else if (800.47 < Salb && Salb <= 1050)
                {
                    Aliqin = "8.65%";
                    Inss = 0.0865 * Salb;
                }
                else if (1050 < Salb && Salb <= 1400.77)
                {
                    Aliqin = "9.00%";
                    Inss = 0.09 * Salb;
                }
                else if (1400.77 < Salb && Salb <= 2801.56)
                {
                    Aliqin = "11.00%";
                    Inss = 0.11 * Salb;
                }
                else
                {
                    Aliqin = "308.17";
                    Inss = 308.17;
                }


                if (Salb <= 1257.12)
                {
                    Aliqir = "0.00%";
                    Irpf = 0 * Salb;
                }
                else if (1257.12 < Salb && Salb <= 2512.08)
                {
                    Aliqir = "15.00%";
                    Irpf = 0.15 * Salb;
                }
                else
                {
                    Aliqir = "27.50%";
                    Irpf = 0.275 * Salb;
                }


                if (Salb <= 435.52)
                {
                    Salf = 22.33 * Fils;
                }
                else if (435.52 < Salb && Salb <= 654.61)
                {
                    Salf = 15.74 * Fils;
                }
                else
                {
                    Salf = 0;
                }

                Sall = Salb - Inss - Irpf + Salf;

                maskedTextBox4.Text = Salf.ToString();
                maskedTextBox5.Text = Aliqir;
                maskedTextBox6.Text = Aliqin; 
                maskedTextBox7.Text = Sall.ToString();
                maskedTextBox8.Text = Inss.ToString();
                maskedTextBox9.Text = Irpf.ToString();

                string Sex, EstCiv;

                if (radioButton2.Checked == true)
                {
                    Sex = "a \n Sra. ";
                }
                else
                {
                    Sex = "o \n Sr. ";
                }
                if (radioButton4.Checked == true)
                {
                    if (radioButton1.Checked == true)
                    {
                        EstCiv = "Casado";
                    }
                    else
                    {
                        EstCiv = "Casada";
                    }
                }
                else
                {
                    if (radioButton1.Checked == true)
                    {
                        EstCiv = "Solteiro";
                    }
                    else
                    {
                        EstCiv = "Solteira";
                    }
                }

                label10.Text = "Os Descontos do Salário d" + Sex + maskedTextBox1.Text + "\n que é " + EstCiv + " e que tem " + Convert.ToString(Fils) + " Filhos são:";
            }
        }
    }
}
