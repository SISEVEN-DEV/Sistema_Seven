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
    public partial class FrmObservacao : Form
    {
        public FrmObservacao(string codigo)
        {
            InitializeComponent();
            _Codigo = codigo;
        }

        string _Codigo;

        private void FrmObservacao_Load(object sender, EventArgs e)
        {
            if (bllContasPagar.Sel_Conta_Codigo(_Codigo) != null)
            {
                foreach (DataRow dr in bllContasPagar.Sel_Conta_Codigo(_Codigo).Rows)
                {
                    if (dr["observacao"].ToString() == null)
                    {
                        rtxtObs.Text = null;
                    }
                    else
                    {
                        rtxtObs.Text = dr["observacao"].ToString();
                    }
                }
            }            
            rtxtObs.Select();
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Contains("'") || rtxtObs.Text.Contains(";") || rtxtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtxtObs.Text = null;
            }
            rtxtObs.BackColor = Color.White;
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void FrmObservacao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Trim() == "")
            {
                MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:" + Environment.NewLine + "< Observação >", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                rtxtObs.Select();
            }
            else
            {
                try
                {
                    bllContasPagar.Alterar_Observacao(_Codigo, rtxtObs.Text.Trim());

                    MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rtxtObs.Text = null;
                }
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

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
