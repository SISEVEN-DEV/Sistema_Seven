using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using BLL;

namespace Seven_Sistema
{
    public partial class FrmConfLocalArquivosSistema : Form
    {
        public FrmConfLocalArquivosSistema()
        {
            InitializeComponent();
        }

        private void FrmCadNivel_Load(object sender, EventArgs e)
        {
            try
            {
                if (bllLocalArquivosSistema.Sel_Tabela_Local_Arquivos_Sistema_Configuracoes() == null)
                {
                    btnAlterar.Enabled = false;
                    btnSalvar.Enabled = true;
                    MessageBox.Show("Ainda não foram definidas configurações para esta opção.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtComprovanteContasaPagar.Select();
                }
                else
                {
                    foreach (DataRow dr in bllLocalArquivosSistema.Sel_Tabela_Local_Arquivos_Sistema_Configuracoes().Rows)
                    {
                        txtComprovanteContasaPagar.Text = dr["local_comp_contas_pagar"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtComprovanteContasaPagar_Enter(object sender, EventArgs e)
        {
            txtComprovanteContasaPagar.BackColor = Color.LightBlue;
        }

        private void txtComprovanteContasaPagar_Leave(object sender, EventArgs e)
        {
            if (txtComprovanteContasaPagar.Text.Contains("'") || txtComprovanteContasaPagar.Text.Contains(";") || txtComprovanteContasaPagar.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtComprovanteContasaPagar.Text = null;
            }
            txtComprovanteContasaPagar.BackColor = Color.White;
        }

        private void txtComprovanteContasaPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

            }
        }

        private void FrmConfLocalArquivosSistema_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnAlterar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                bllLocalArquivosSistema.Alterar(txtComprovanteContasaPagar.Text.Trim());
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtComprovanteContasaPagar.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                bllLocalArquivosSistema.Salvar(txtComprovanteContasaPagar.Text.Trim());
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtComprovanteContasaPagar.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
