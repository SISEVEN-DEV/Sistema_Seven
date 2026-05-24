using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmConfDevolucao : Form
    {
        public FrmConfDevolucao()
        {
            InitializeComponent();
        }

        private void FrmConfDevolucao_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\7 Sistema\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\7 Sistema\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\7 Sistema\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\7 Sistema\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConfDevolucao iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConfDevolucao iniciado.");
                }
                //
                if (bllDevolucao.Sel_Tabela_Devolucao_Configuracoes() == null)
                {
                    btnAlterar.Enabled = false;
                    btnSalvar.Enabled = true;
                    MessageBox.Show("Ainda não foram definidas configurações para esta opção.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    chkbUsarVisAdobe.Select();
                }
                else
                {
                    foreach (DataRow dr in bllDevolucao.Sel_Tabela_Devolucao_Configuracoes().Rows)
                    {
                        if (Convert.ToByte(dr["usar_axacropdf"]) == 1)
                        {
                            chkbUsarVisAdobe.Checked = true;
                        }
                        else
                        {
                            chkbUsarVisAdobe.Checked = false;
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
                        //
                        btnAlterar.Enabled = true;
                        btnSalvar.Enabled = false;
                        chkbUsarVisAdobe.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConfFornecedor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConfFornecedor.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void chkbUsarVisAdobe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbUsarVisAdobe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void txtMargemEsq_Leave(object sender, EventArgs e)
        {
            txtMargemEsq.BackColor = Color.White;
        }

      
       
       

        private void FrmConfDevolucao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
              
                    //bllDevolucao.Alterar_Config_Devolucao(lblMaisMenos1.Text + txtMargemEsq.Text.Trim(), lblMaisMenos2.Text + txtMargemTopo.Text.Trim(), lblMaisMenos1PDF80mm.Text + txtMargemEsqPDF80mm.Text, lblMaisMenos2PDF80mm.Text + txtMargemTopoPDF80mm.Text.Trim(), chkbUsarVisAdobe.Checked);
                    MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //chkbUsarVisAdobe.Select();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnAlterar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnAlterar.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMargemEsq.Text.Trim() == "" || txtMargemTopo.Text.Trim() == "" || txtMargemEsqPDF80mm.Text.Trim() == "" || txtMargemTopoPDF80mm.Text.Trim() == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: \n< Margem Esquerda >, < Margem Topo >, < Margem Esquerda Imp. Matricial >, < Margem Topo Imp. Matricial >, < Margem Esquerda PDF 80 mm >, < Margem Topo PDF 80 mm >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtMargemEsq.Select();
                }
                else
                {
                    bllDevolucao.Salvar_Config_Devolucao(lblMaisMenos1.Text + txtMargemEsq.Text.Trim(), lblMaisMenos2.Text + txtMargemTopo.Text.Trim(), lblMaisMenos1PDF80mm.Text + txtMargemEsqPDF80mm.Text, lblMaisMenos2PDF80mm.Text + txtMargemTopoPDF80mm.Text.Trim(), chkbUsarVisAdobe.Checked);
                    MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    btnAlterar.Enabled = true;
                    btnSalvar.Enabled = false;
                    chkbUsarVisAdobe.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnSalvar.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
