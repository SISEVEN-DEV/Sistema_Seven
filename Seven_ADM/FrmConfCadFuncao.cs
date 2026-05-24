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
    public partial class FrmConfCadFuncao : Form
    {
        public FrmConfCadFuncao()
        {
            InitializeComponent();
        }

        private void FrmConfCadFuncao_Load(object sender, EventArgs e)
        {
            try
            {
                if (bllFuncaoFuncionario.Sel_Tabela_Funcao_Configuracoes() == null)
                {
                    btnAlterar.Enabled = false;
                    btnSalvar.Enabled = true;
                    MessageBox.Show("Ainda não foram definidas configurações para esta opção.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkbExcluirCascata.Select();
                }
                else
                {
                    foreach (DataRow dr in bllFuncaoFuncionario.Sel_Tabela_Funcao_Configuracoes().Rows)
                    {
                        if (Convert.ToByte(dr["excluir_funcao_cascata"]) == 1)
                        {
                            chkbExcluirCascata.Checked = true;
                        }
                        else
                        {
                            chkbExcluirCascata.Checked = false;
                        }
                        //                        
                        btnAlterar.Enabled = true;
                        btnSalvar.Enabled = false;
                        chkbExcluirCascata.Select();
                    }
                }
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
                bllFuncaoFuncionario.Salvar_Config_Funcao(chkbExcluirCascata.Checked);
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkbExcluirCascata.Select();
                btnSalvar.Enabled = false;
                btnAlterar.Enabled = true;            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                bllFuncaoFuncionario.Alterar_Config_Funcao(chkbExcluirCascata.Checked);
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkbExcluirCascata.Select();
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

        private void FrmConfCadFuncao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbExcluirCascata_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbExcluirCascata_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }    
    }
}
