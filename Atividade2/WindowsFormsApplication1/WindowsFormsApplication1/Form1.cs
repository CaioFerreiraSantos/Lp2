using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Sexo;
        double Alt, Pes, Res;

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Sexo = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Sexo = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != " ," && maskedTextBox2.Text != "   " && (Sexo == 1 || Sexo == 2))
            {
                Alt = Double.Parse(maskedTextBox1.Text);
                Pes = Double.Parse(maskedTextBox2.Text);
                switch (Sexo){
                    case 1: Res = (72.7 * Alt) - 58; break;
                    case 2: Res = (62.1 * Alt) - 44.7; break;
                }
                if(Pes > Res)
                {
                    MessageBox.Show("Regime Obrigatório Já");
                }
                else if (Pes < Res)
                {
                    MessageBox.Show("Coma bastante Massas e Doces");
                } 
                else
                {
                    MessageBox.Show("Você está com o Peso Ideal");
                }

            }
            else
            {
                MessageBox.Show("Informações incompletas");
            }

        }
    }
}
