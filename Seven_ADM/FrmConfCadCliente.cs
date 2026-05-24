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
    public partial class FrmConfCadCliente : Form
    {
        public FrmConfCadCliente()
        {
            InitializeComponent();
        }

        private void FrmConfCadAluno_Load(object sender, EventArgs e)
        {
            try
            {
                if (bllCliente.Sel_Tabela_Cliente_Configuracoes() == null)
                {
                    btnAlterar.Enabled = false;
                    btnSalvar.Enabled = true;
                    MessageBox.Show("Ainda não foram definidas configurações para esta opção.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkbExcluirCascata.Select();
                }
                else
                {
                    foreach (DataRow dr in bllCliente.Sel_Tabela_Cliente_Configuracoes().Rows)
                    {
                        if (Convert.ToByte(dr["excluir_cliente_cascata"]) == 1)
                        {
                            chkbExcluirCascata.Checked = true;
                        }
                        else
                        {
                            chkbExcluirCascata.Checked = false;
                        }
                        //
                        txtMargemEsq.Text = dr["margem_esq"].ToString();
                        if (dr["margem_esq"].ToString().Contains("-"))
                        {
                            lblMaisMenos1.Text = "-";
                            txtMargemEsq.Text = txtMargemEsq.Text.Replace("-", "");
                        }
                        else
                        {
                            lblMaisMenos1.Text = "+";
                        }
                        //
                        txtMargemTopo.Text = dr["margem_topo"].ToString();
                        if (dr["margem_topo"].ToString().Contains("-"))
                        {
                            lblMaisMenos2.Text = "-";
                            txtMargemTopo.Text = txtMargemTopo.Text.Replace("-", "");
                        }
                        else
                        {
                            lblMaisMenos2.Text = "+";
                        }
                        //
                        txtMargemEsq.Text = dr["margem_esq"].ToString();
                        if (dr["margem_esq"].ToString().Contains("-"))
                        {
                            lblMaisMenos1.Text = "-";
                            txtMargemEsq.Text = txtMargemEsq.Text.Replace("-", "");
                        }
                        else
                        {
                            lblMaisMenos1.Text = "+";
                        }
                        //
                        txtMargemEsqPDF58mm.Text = dr["margem_esq_pdf_58"].ToString();
                        if (dr["margem_esq_pdf_58"].ToString().Contains("-"))
                        {
                            lblMaisMenos1PDF58mm.Text = "-";
                            txtMargemEsqPDF58mm.Text = txtMargemEsqPDF58mm.Text.Replace("-", "");
                        }
                        else
                        {
                            lblMaisMenos1PDF58mm.Text = "+";
                        }
                        //
                        txtMargemTopoPDF58mm.Text = dr["margem_topo_pdf_58"].ToString();
                        if (dr["margem_topo_pdf_58"].ToString().Contains("-"))
                        {
                            lblMaisMenos2PDF58mm.Text = "-";
                            txtMargemTopoPDF58mm.Text = txtMargemTopoPDF58mm.Text.Replace("-", "");
                        }
                        else
                        {
                            lblMaisMenos2PDF58mm.Text = "+";
                        }

                        txtMargemEsqPDF80mm.Text = dr["margem_esq_pdf_80"].ToString();
                        if (dr["margem_esq_pdf_80"].ToString().Contains("-"))
                        {
                            lblMaisMenos1PDF80mm.Text = "-";
                            txtMargemEsqPDF80mm.Text = txtMargemEsqPDF80mm.Text.Replace("-", "");
                        }
                        else
                        {
                            lblMaisMenos1PDF80mm.Text = "+";
                        }
                        //
                        txtMargemTopoPDF80mm.Text = dr["margem_topo_pdf_80"].ToString();
                        if (dr["margem_topo_pdf_80"].ToString().Contains("-"))
                        {
                            lblMaisMenos2PDF80mm.Text = "-";
                            txtMargemTopoPDF80mm.Text = txtMargemTopoPDF80mm.Text.Replace("-", "");
                        }
                        else
                        {
                            lblMaisMenos2PDF80mm.Text = "+";
                        }


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

        private void chkbExcluirCascata_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbExcluirCascata_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMostrarImpASalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarImpASalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMostrarImpAAlterar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarImpAAlterar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try 
            {
                bllCliente.Salvar_Config_Cliente(chkbExcluirCascata.Checked, lblMaisMenos1.Text + txtMargemEsq.Text.Trim(), lblMaisMenos2.Text + txtMargemTopo.Text.Trim(), lblMaisMenos1PDF58mm.Text + txtMargemEsqPDF58mm.Text.Trim(), lblMaisMenos2PDF58mm.Text + txtMargemTopoPDF58mm.Text.Trim(), lblMaisMenos1PDF80mm.Text + txtMargemEsqPDF80mm.Text.Trim(), lblMaisMenos2PDF80mm.Text + txtMargemTopoPDF80mm.Text.Trim());
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                bllCliente.Alterar_Config_Cliente(chkbExcluirCascata.Checked, lblMaisMenos1.Text + txtMargemEsq.Text.Trim(), lblMaisMenos2.Text + txtMargemTopo.Text.Trim(), lblMaisMenos1PDF58mm.Text + txtMargemEsqPDF58mm.Text.Trim(), lblMaisMenos2PDF58mm.Text + txtMargemTopoPDF58mm.Text.Trim(), lblMaisMenos1PDF80mm.Text + txtMargemEsqPDF80mm.Text.Trim(), lblMaisMenos2PDF80mm.Text + txtMargemTopoPDF80mm.Text.Trim());
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkbExcluirCascata.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmConfCadAluno_KeyUp(object sender, KeyEventArgs e)
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

        private void txtMargemEsq_Enter(object sender, EventArgs e)
        {
            txtMargemEsq.BackColor = Color.LightBlue;
        }

        private void txtMargemEsq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMargemTopo.Select();                
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtMargemTopo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMargemEsqPDF58mm.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtMargemEsq_Leave(object sender, EventArgs e)
        {
            txtMargemEsq.BackColor = Color.White;
        }

        private void txtMargemTopo_Enter(object sender, EventArgs e)
        {
            txtMargemTopo.BackColor = Color.LightBlue;
        }

        private void txtMargemTopo_Leave(object sender, EventArgs e)
        {
            txtMargemTopo.BackColor = Color.White;
        }

        private void lblMaisMenos1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblMaisMenos1.ForeColor = Color.Red;
        }

        private void lblMaisMenos1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.lblMaisMenos1.ForeColor = Color.Black;
        }

        private void lblMaisMenos2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblMaisMenos2.ForeColor = Color.Red;
        }

        private void lblMaisMenos2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.lblMaisMenos2.ForeColor = Color.Black;
        }

        private void lblMaisMenos1_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos1.Text == "+")
            {
                lblMaisMenos1.Text = "-";
            }
            else
            {
                lblMaisMenos1.Text = "+";
            }
        }

        private void lblMaisMenos2_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos2.Text == "+")
            {
                lblMaisMenos2.Text = "-";
            }
            else
            {
                lblMaisMenos2.Text = "+";
            }
        }

        private void chkbMostrarLogo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarLogo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtMargemEsqPDF58mm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMargemTopoPDF58mm.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtMargemTopoPDF58mm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMargemEsqPDF80mm.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtMargemEsqPDF80mm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMargemTopoPDF80mm.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtMargemTopoPDF80mm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (btnSalvar.Enabled == true)
                {
                    btnSalvar.Select();
                }
                else
                {
                    btnAlterar.Select();
                }
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtMargemEsqPDF58mm_Enter(object sender, EventArgs e)
        {
            txtMargemEsqPDF58mm.BackColor = Color.LightBlue;
        }

        private void txtMargemEsqPDF58mm_Leave(object sender, EventArgs e)
        {
            txtMargemEsqPDF58mm.BackColor = Color.White;
        }

        private void txtMargemTopoPDF58mm_Enter(object sender, EventArgs e)
        {
            txtMargemTopoPDF58mm.BackColor = Color.LightBlue;
        }

        private void txtMargemTopoPDF58mm_Leave(object sender, EventArgs e)
        {
            txtMargemTopoPDF58mm.BackColor = Color.White;
        }

        private void txtMargemEsqPDF80mm_Enter(object sender, EventArgs e)
        {
            txtMargemEsqPDF80mm.BackColor = Color.LightBlue;
        }

        private void txtMargemEsqPDF80mm_Leave(object sender, EventArgs e)
        {
            txtMargemEsqPDF80mm.BackColor = Color.White;
        }

        private void txtMargemTopoPDF80mm_Enter(object sender, EventArgs e)
        {
            txtMargemTopoPDF80mm.BackColor = Color.LightBlue;
        }

        private void txtMargemTopoPDF80mm_Leave(object sender, EventArgs e)
        {
            txtMargemTopoPDF80mm.BackColor = Color.White; 
        }

        private void lblMaisMenos1PDF58mm_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos1PDF58mm.Text == "+")
            {
                lblMaisMenos1PDF58mm.Text = "-";
            }
            else
            {
                lblMaisMenos1PDF58mm.Text = "+";
            }
        }

        private void lblMaisMenos2PDF58mm_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos2PDF58mm.Text == "+")
            {
                lblMaisMenos2PDF58mm.Text = "-";
            }
            else
            {
                lblMaisMenos2PDF58mm.Text = "+";
            }
        }

        private void lblMaisMenos1PDF80mm_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos1PDF80mm.Text == "+")
            {
                lblMaisMenos1PDF80mm.Text = "-";
            }
            else
            {
                lblMaisMenos1PDF80mm.Text = "+";
            }
        }

        private void lblMaisMenos2PDF80mm_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos2PDF80mm.Text == "+")
            {
                lblMaisMenos2PDF80mm.Text = "-";
            }
            else
            {
                lblMaisMenos2PDF80mm.Text = "+";
            }
        }

        private void lblMaisMenos1PDF58mm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblMaisMenos1PDF58mm.ForeColor = Color.Red;
        }

        private void lblMaisMenos2PDF58mm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblMaisMenos2PDF58mm.ForeColor = Color.Red;
        }

        private void lblMaisMenos1PDF80mm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblMaisMenos1PDF80mm.ForeColor = Color.Red;
        }

        private void lblMaisMenos2PDF80mm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblMaisMenos2PDF80mm.ForeColor = Color.Red;
        }

        private void lblMaisMenos1PDF58mm_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos1PDF58mm.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos2PDF58mm_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos2PDF58mm.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos1PDF80mm_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos1PDF80mm.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos2PDF80mm_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos2PDF80mm.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }
    }
}
