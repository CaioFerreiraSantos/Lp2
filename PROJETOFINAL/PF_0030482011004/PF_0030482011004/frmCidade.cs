using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PF_0030482011004
{
    public partial class frmCidade : Form
    {
        private BindingSource bnCidade = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsCidade = new DataSet();

        public frmCidade()
        {
            InitializeComponent();
        }

        private void frmCidade_Load(object sender, EventArgs e)
        {

            try
            {
                Cidade Cid = new Cidade();
                dsCidade.Tables.Add(Cid.Listar());
                bnCidade.DataSource = dsCidade.Tables["TBCidade"];
                dgvCidade.DataSource = bnCidade;

                bnvCidade.BindingSource = bnCidade;
                txtID.DataBindings.Add("TEXT", bnCidade, "id_cidade");
                txtNome.DataBindings.Add("TEXT", bnCidade, "nome_cidade");
                cbxEstado.DataBindings.Add("SelectedItem", bnCidade, "uf_cidade");
                // AJUSTAR DROPDOWNSTYLE PARA DropDownList PARA NAO DEIXAR INCLUIR
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btmNovo_Click(object sender, EventArgs e)
        {
            if (tbCidade.SelectedIndex == 0)
            {
                tbCidade.SelectTab(1);
            }
            bnCidade.AddNew();
            txtNome.Enabled = true;
            cbxEstado.Enabled = true;
            cbxEstado.SelectedIndex = 0;
            txtNome.Focus();
            btmSalvar.Enabled = true;
            btmAlterar.Enabled = false;
            btmNovo.Enabled = false;
            btmExcluir.Enabled = false;
            btmCancelar.Enabled = true;
            bInclusao = true; ;

        }

        private void btmSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Cidade inválida!");
            }
            else
            {
                Cidade RegCid = new Cidade();
                RegCid.IdCidade = Convert.ToInt16(txtID.Text);
                RegCid.NomeCidade = txtNome.Text;
                RegCid.UfCidade = cbxEstado.SelectedItem.ToString();
                if (bInclusao)
                {
                    if (RegCid.Salvar() > 0)
                    {
                        MessageBox.Show("Cidade adicionada com sucesso!");
                        btmSalvar.Enabled = false;
                        txtID.Enabled = false;
                        txtNome.Enabled = false;
                        cbxEstado.Enabled = false;
                        btmSalvar.Enabled = false;
                        btmAlterar.Enabled = true;
                        btmNovo.Enabled = true;
                        btmExcluir.Enabled = true;
                        btmCancelar.Enabled = false;
                        bInclusao = false;
                        // recarrega o grid
                        dsCidade.Tables.Clear();
                        dsCidade.Tables.Add(RegCid.Listar());
                        bnCidade.DataSource = dsCidade.Tables["TBCidade"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar cidade!");
                    }
                }
                else
                {
                    if (RegCid.Alterar() > 0)
                    {
                        MessageBox.Show("Cidade alterada com sucesso!");
                        dsCidade.Tables.Clear();
                        dsCidade.Tables.Add(RegCid.Listar());
                        txtID.Enabled = false;
                        txtNome.Enabled = false;
                        cbxEstado.Enabled = false;
                        btmSalvar.Enabled = false;
                        btmAlterar.Enabled = true;
                        btmNovo.Enabled = true;
                        btmExcluir.Enabled = true;
                        btmCancelar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar cidade!");
                    }
                }
            }

        }

        private void btmAlterar_Click(object sender, EventArgs e)
        {
            if (tbCidade.SelectedIndex == 0)
            {
                tbCidade.SelectTab(1);
            }
            txtNome.Enabled = true;
            cbxEstado.Enabled = true;
            txtNome.Focus();
            btmSalvar.Enabled = true;
            btmAlterar.Enabled = false;
            btmNovo.Enabled = false;
            btmExcluir.Enabled = false;
            btmCancelar.Enabled = true;
            bInclusao = false;

        }

        private void btmExcluir_Click(object sender, EventArgs e)
        {
            if (tbCidade.SelectedIndex == 0)
            {
                tbCidade.SelectTab(1);
            }
            if (MessageBox.Show("Confirma exclusão?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Cidade RegCid = new Cidade();
                RegCid.IdCidade = Convert.ToInt16(txtID.Text);
                RegCid.NomeCidade = txtNome.Text;
                RegCid.UfCidade = cbxEstado.SelectedItem.ToString();
                if (RegCid.Excluir() > 0)
                {
                    MessageBox.Show("Cidade excluída com sucesso!");
                    Cidade R = new Cidade();
                    dsCidade.Tables.Clear();
                    dsCidade.Tables.Add(R.Listar());
                    bnCidade.DataSource = dsCidade.Tables["TBCidade"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir cidade!");
                }
            }

        }

        private void btmCancelar_Click(object sender, EventArgs e)
        {
            bnCidade.CancelEdit();
            btmSalvar.Enabled = false;
            txtNome.Enabled = false;
            cbxEstado.Enabled = false;
            btmAlterar.Enabled = true;
            btmNovo.Enabled = true;
            btmExcluir.Enabled = true;
        }

        private void btmSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
