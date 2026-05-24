using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace SIE_7_Sistema
{
    public partial class FrmConfCadArquivo : Form
    {
        public FrmConfCadArquivo()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                bllArquivo.Salvar_Configuracoes(chkbExcluirArquivo.Checked, chkbpermitirSelVarArq.Checked);
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkbExcluirArquivo.Select();
                btnSalvar.Enabled = false;
                btnAlterar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                bllArquivo.Alterar_Configuracoes(chkbExcluirArquivo.Checked, chkbpermitirSelVarArq.Checked);
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkbExcluirArquivo.Select();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
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

        private void chkbExcluirArquivo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbExcluirArquivo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbpermitirSelVarArq_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbpermitirSelVarArq_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmConfCadArquivo_Load(object sender, EventArgs e)
        {
            try
            {
                if (bllArquivo.Sel_Tabela_Arquivo_Configuracoes() == null)
                {
                    btnAlterar.Enabled = false;
                    btnSalvar.Enabled = true;
                    MessageBox.Show("Ainda não foram definidas configurações para esta opção.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkbExcluirArquivo.Select();                   
                }
                else
                {
                    foreach (DataRow dr in bllArquivo.Sel_Tabela_Arquivo_Configuracoes().Rows)
                    {
                        if (Convert.ToByte(dr["excluir_arquivo_diretorio"]) == 1)
                        {
                            chkbExcluirArquivo.Checked = true;
                        }
                        else
                        {
                            chkbExcluirArquivo.Checked = false;
                        }
                        //
                        if (Convert.ToByte(dr["mostrar_impressao_a_alterar"]) == 1)
                        {
                            chkbpermitirSelVarArq.Checked = true;
                        }
                        else
                        {
                            chkbpermitirSelVarArq.Checked = false;
                        }                      
                        btnAlterar.Enabled = true;
                        btnSalvar.Enabled = false;
                        chkbExcluirArquivo.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmConfCadArquivo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
