using BLL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmTipoEntNotaPromissoria : Form
    {
        public FrmTipoEntNotaPromissoria(byte formulario, string valor_pago, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Valor_Pago = valor_pago;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Valor_Pago;
        private byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmTipoEntNotaPromissoria_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmTipoEntNotaPromissoria niciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmTipoEntNotaPromissoria iniciado.");
                }
                //
                lblValorPago.Text = _Valor_Pago + " R$";
                //
                if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                {
                    cbbForma1.Text = null;
                }
                else
                {
                    cbbForma1.Items.Add("");
                    //
                    for (int i = 0; i < bllVenda.Sel_Forma_Pagamento_PDV().Rows.Count; i++)
                    {
                        DataRow dr = bllVenda.Sel_Forma_Pagamento_PDV().Rows[i];

                        if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                        {
                            cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                        }
                    }
                }
                //
                txtCodigo.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmTipoEntNotaPromissoria.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmTipoEntNotaPromissoria.");
                }
                cbbForma1.Text = null;
            }
        }

        private void cbbForma1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForma1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma1_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForma1_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbForma1.Select();
            }
        }

        private void cbbForma1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            if (cbbForma1.Text == "")
            {
                MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Forma de Pagamento ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                bllVenda._Forma_Ent_Pagamento_Promissoria = cbbForma1.Text;
                //
                this.DialogResult = DialogResult.OK;
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Informe a forma de pagamento de entrada da nota promissória.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            txtCodigo.BackColor = Color.LightBlue;
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Contains("'") || txtCodigo.Text.Contains(";") || txtCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodigo.Text = null;
                txtCodigo.Select();
            }
            else if (txtCodigo.Text.Trim() == "0")
            {
                txtCodigo.Text = null;
                cbbForma1.Text = null;
            }
            else
            {
                try
                {
                    if (txtCodigo.Text.Trim() != "")
                    {
                        if (bllVenda.Sel_Forma_Pagamento_Codigo_PDV(txtCodigo.Text) == null)
                        {
                            MessageBox.Show("Não existe forma de pagamento para o código informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            txtCodigo.Text = null;
                            cbbForma1.Text = null;
                            txtCodigo.Select();
                        }
                        else
                        {
                            try
                            {
                                cbbForma1.Items.Clear();
                                if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                                {
                                    cbbForma1.Text = null;
                                    cbbForma1.Enabled = false;
                                }
                                else
                                {
                                    cbbForma1.Enabled = true;
                                    cbbForma1.Items.Add("");
                                    foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                                    {
                                        if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                        {
                                            cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                                        }
                                    }
                                }
                                //
                                DataRow dr1 = bllVenda.Sel_Forma_Pagamento_Codigo_PDV(txtCodigo.Text).Rows[0];
                                //
                                cbbForma1.Text = dr1["id_pagamento"].ToString() + "—" + dr1["tipo"].ToString();
                                cbbForma1.Select();
                                //
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do txtCodigo.");
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do txtCodigo.");
                                }
                                cbbForma1.Items.Clear();
                                cbbForma1.Text = null;
                                bllVenda._PDV_PesqForma_Tabela = null;
                            }
                        }
                    }
                    else
                    {
                        txtCodigo.Text = null;
                        cbbForma1.Text = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtCodigo1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtCodigo1.");
                    }
                    txtCodigo.Text = null;
                    cbbForma1.Text = null;
                    txtCodigo.Select();
                }
            }
            txtCodigo.BackColor = Color.White;
        }

        private void btnProcurar1_Click(object sender, EventArgs e)
        {
            using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(2, txtCodigo.Text, _Usuario, _Cod_PDV_Computador))
            {
                if (Pag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbForma1.Items.Clear();
                        if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                        {
                            cbbForma1.Text = null;
                            cbbForma1.Enabled = false;
                        }
                        else
                        {
                            cbbForma1.Enabled = true;
                            cbbForma1.Items.Add("");
                            foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                            {
                                if (dr["tipo"].ToString() != "NOTA PROMISSORIA")
                                {
                                    cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                                }
                            }
                        }
                        string[] items = bllVenda._PDV_PesqForma_Tabela.Split('—');
                        txtCodigo.Text = items[0];
                        cbbForma1.Text = bllVenda._PDV_PesqForma_Tabela;
                        cbbForma1.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar1.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar1.");
                        }
                        cbbForma1.Items.Clear();
                        cbbForma1.Text = null;
                        bllVenda._PDV_PesqForma_Tabela = null;
                    }
                }
            }
        }

        private void btnProcurar1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmTipoEntNotaPromissoria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void cbbForma1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbForma1.Text != "")
                {
                    string[] items = cbbForma1.Text.Split('—');
                    txtCodigo.Text = items[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do combobox cbbForma1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do combobox cbbForma1.");
                }
                txtCodigo.Text = null;
                cbbForma1.Text = null;
            }
        }
    }
}
