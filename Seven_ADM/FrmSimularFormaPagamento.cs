using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmSimularFormaPagamento : Form
    {
        public FrmSimularFormaPagamento(string descricao, string tipo_pagamento, string parcela, string entrada, string desconto_fixo, string acrescimo_fixo, string prazo_prim_pagto, string multa, string juros_mora, byte formulario)
        {
            InitializeComponent();
            cbbTipo.Text = tipo_pagamento;
            txtDescricao.Text = descricao;
            txtParcela.Text = parcela;
            txtEntradaPorc.Text = entrada;
            txtDescontoFixoPorc.Text = desconto_fixo;
            txtAcrescimoFixoPorc.Text = acrescimo_fixo;
            txtPrimeiroPagamento.Text = prazo_prim_pagto;
            txtJurosPorc.Text = multa;
            txtJurosAtrasoPorc.Text = juros_mora;
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void FrmSimularFormaPagamento_Load(object sender, EventArgs e)
        {
            try
            {
                bllFormaPagamento._FrmSimuFormaPagamento_Ativo = true;

                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }

                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmSimularFormaPagamento iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmSimularFormaPagamento iniciado.");
                }
                //
                txtValorVenda.Text = "100,00";
                txtValorVenda.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmSimularFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmSimularFormaPagamento.");
                }
            }
        }

        private void cbbTipo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void txtEntradaPorc_Enter(object sender, EventArgs e)
        {
            txtEntradaPorc.BackColor = Color.LightBlue;
        }

        private void txtEntradaPorc_Leave(object sender, EventArgs e)
        {
            if (txtEntradaPorc.Text.Contains("'") || txtEntradaPorc.Text.Contains(";") || txtEntradaPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtEntradaPorc.Text = null;
            }
            else
            {
                if (txtEntradaPorc.Text != "")
                {
                    try
                    {
                        txtEntradaPorc.Text = Convert.ToDecimal(txtEntradaPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtEntradaPorc.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtEntradaPorc.");
                        }
                        txtEntradaPorc.Text = null;
                    }
                }
            }
            txtEntradaPorc.BackColor = Color.White;
        }

        private void txtEntradaPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEntradaPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtDescontoFixoPorc.Select();
            }
        }

        private void txtParcela_Enter(object sender, EventArgs e)
        {
            txtParcela.BackColor = Color.LightBlue;
        }

        private void txtParcela_Leave(object sender, EventArgs e)
        {
            if (txtParcela.Text.Contains("'") || txtParcela.Text.Contains(";") || txtParcela.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtParcela.Text = null;
            }
            txtParcela.BackColor = Color.White;
        }

        private void txtParcela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtEntradaPorc.Select();
            }
        }

        private void txtJurosPorc_Enter(object sender, EventArgs e)
        {
            txtJurosPorc.BackColor = Color.LightBlue;
        }

        private void txtJurosPorc_Leave(object sender, EventArgs e)
        {
            if (txtJurosPorc.Text.Contains("'") || txtJurosPorc.Text.Contains(";") || txtJurosPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtJurosPorc.Text = null;
            }
            else
            {
                if (txtJurosPorc.Text != "")
                {
                    try
                    {
                        txtJurosPorc.Text = Convert.ToDecimal(txtJurosPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtJurosPorc.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtJurosPorc.");
                        }
                        txtJurosPorc.Text = null;
                    }
                }
            }
            txtJurosPorc.BackColor = Color.White;
        }

        private void txtJurosPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtJurosPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtJurosAtrasoPorc.Select();
            }
        }

        private void txtPrimeiroPagamento_Enter(object sender, EventArgs e)
        {
            txtPrimeiroPagamento.BackColor = Color.LightBlue;
        }

        private void txtPrimeiroPagamento_Leave(object sender, EventArgs e)
        {
            if (txtPrimeiroPagamento.Text.Contains("'") || txtPrimeiroPagamento.Text.Contains(";") || txtPrimeiroPagamento.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtPrimeiroPagamento.Text = null;
            }
            txtPrimeiroPagamento.BackColor = Color.White;
        }

        private void txtPrimeiroPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtJurosPorc.Select();
            }
        }

        private void txtJurosAtrasoPorc_Enter(object sender, EventArgs e)
        {
            txtJurosAtrasoPorc.BackColor = Color.LightBlue;
        }

        private void txtJurosAtrasoPorc_Leave(object sender, EventArgs e)
        {
            if (txtJurosAtrasoPorc.Text.Contains("'") || txtJurosAtrasoPorc.Text.Contains(";") || txtJurosAtrasoPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtJurosAtrasoPorc.Text = null;
            }
            else
            {
                if (txtJurosAtrasoPorc.Text != "")
                {
                    try
                    {
                        txtJurosAtrasoPorc.Text = Convert.ToDecimal(txtJurosAtrasoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtJurosAtrasoPorc.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtJurosAtrasoPorc.");
                        }
                        txtJurosAtrasoPorc.Text = null;
                    }
                }
            }
            txtJurosAtrasoPorc.BackColor = Color.White;
        }

        private void txtJurosAtrasoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtJurosAtrasoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnSimular.Select();
            }
        }

        private void txtValorVenda_Enter(object sender, EventArgs e)
        {
            txtValorVenda.BackColor = Color.LightBlue;
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorVenda.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbTipo.Select();
            }
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            if (txtValorVenda.Text != "")
            {
                if (txtValorVenda.Text.Contains("'") || txtValorVenda.Text.Contains(";") || txtValorVenda.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorVenda.Text = null;
                    txtValorVenda.Select();
                }
                else
                {
                    try
                    {
                        txtValorVenda.Text = Convert.ToDecimal(txtValorVenda.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorVenda.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorVenda.");
                        }
                        txtValorVenda.Text = null;
                    }
                }
            }
            txtValorVenda.BackColor = Color.White;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtParcela.Text = "1";
            lblParcela.Enabled = true;
            txtParcela.Enabled = true;
            lblEntrada.Enabled = true;
            txtEntradaPorc.Enabled = true;
            lblDescontoFixo.Enabled = true;
            txtDescontoFixoPorc.Enabled = true;
            label5.Enabled = true;
            txtAcrescimoFixoPorc.Enabled = true;
            lblPrimeiroPagamento.Enabled = true;
            txtPrimeiroPagamento.Enabled = true;
            lblJuros.Enabled = true;
            txtJurosPorc.Enabled = true;
            lblJurosAtraso.Enabled = true;
            txtJurosAtrasoPorc.Enabled = true;
            lblDias.Enabled = true;
            lblPorcentagem2.Enabled = true;
            lblPorcentagem3.Enabled = true;
            lblDescontoFixo.Enabled = true;
            lblDescricao.Enabled = true;
            txtDescricao.Enabled = true;
            lblPorcentagem6.Enabled = true;
            lblPorcentagem5.Enabled = true;
        }

        private void FrmSimularFormaPagamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (_Formulario == 0)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else if (_Formulario == 1)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (txtValorVenda.Text.Trim() == "" || txtDescricao.Text.Trim() == "" || cbbTipo.Text == "" || txtParcela.Text.Trim() == "")
            {
                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:" + Environment.NewLine + "[ Total ], [ Tipo de Pagamento ], [ Descrição ] e [ Parcela ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtDescricao.Select();
            }
            else
            {
                try
                {
                    if (txtEntradaPorc.Text == "")
                    {
                        txtEntradaPorc.Text = "0,00";
                    }
                    //
                    if (txtDescontoFixoPorc.Text == "")
                    {
                        txtDescontoFixoPorc.Text = "0,00";
                    }
                    //
                    if (txtAcrescimoFixoPorc.Text == "")
                    {
                        txtAcrescimoFixoPorc.Text = "0,00";
                    }
                    //
                    if (txtJurosPorc.Text == "")
                    {
                        txtJurosPorc.Text = "0,00";
                    }
                    //
                    if (txtJurosAtrasoPorc.Text == "")
                    {
                        txtJurosAtrasoPorc.Text = "0,00";
                    }
                    //
                    if (txtPrimeiroPagamento.Text == "")
                    {
                        txtPrimeiroPagamento.Text = "0";
                    }
                    //
                    lblResultado1.Text = bllFormaPagamento.Simular_Forma_Pagamento_Resumida(txtParcela.Text.Trim(), txtEntradaPorc.Text.Trim(), txtValorVenda.Text.Trim(), txtDescontoFixoPorc.Text.Trim(), txtAcrescimoFixoPorc.Text.Trim());
                    lblResultado.Text = bllFormaPagamento.Simular_Forma_Pagamento(cbbTipo.Text, txtParcela.Text.Trim(), txtEntradaPorc.Text.Trim(), txtJurosPorc.Text.Trim(), txtPrimeiroPagamento.Text.Trim(), txtJurosAtrasoPorc.Text.Trim(), txtValorVenda.Text.Trim(), txtDescricao.Text.Trim(), txtDescontoFixoPorc.Text.Trim(), txtAcrescimoFixoPorc.Text.Trim());
                    //
                    lblDescricaoForma.Enabled = true;
                    lblResultado.Enabled = true;
                    lblDescricaoForma1.Enabled = true;
                    lblResultado1.Enabled = true;
                    //
                    MessageBox.Show("Simulação efetuada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSimular.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSimular.");
                    }
                    txtDescricao.Text = null;
                    cbbTipo.Text = null;
                    txtParcela.Text = null;
                    txtEntradaPorc.Text = null;
                    txtJurosPorc.Text = null;
                    txtPrimeiroPagamento.Text = null;
                    txtJurosPorc.Text = null;
                    txtValorVenda.Text = null;
                    lblResultado.Text = null;
                    lblResultado1.Text = null;
                }
            }
        }

        private void lblResultado_MouseMove(object sender, MouseEventArgs e)
        {
            if (lblResultado.Text != "")
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void lblResultado_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblResultado1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lblResultado1.Text != "")
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void lblResultado1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescricao.Text = null;
            }
            txtDescricao.BackColor = Color.White;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbTipo.SelectedIndex == 4 || cbbTipo.SelectedIndex == 0)
                {
                    txtParcela.Select();
                }
                else
                {
                    txtDescontoFixoPorc.Select();
                }
            }
        }

        private void btnSimular_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSimular_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere os dados. Simule o tipo de pagamento preenchendo os campos necessários.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtDescontoFixoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDescontoFixoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtAcrescimoFixoPorc.Select();
            }
        }

        private void txtDescontoFixoPorc_Enter(object sender, EventArgs e)
        {
            txtDescontoFixoPorc.BackColor = Color.LightBlue;
        }

        private void txtDescontoFixoPorc_Leave(object sender, EventArgs e)
        {
            if (txtDescontoFixoPorc.Text.Contains("'") || txtDescontoFixoPorc.Text.Contains(";") || txtDescontoFixoPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescontoFixoPorc.Text = null;
            }
            else
            {
                if (txtDescontoFixoPorc.Text != "")
                {
                    try
                    {
                        txtDescontoFixoPorc.Text = Convert.ToDecimal(txtDescontoFixoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescontoFixoPorc.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescontoFixoPorc.");
                        }
                        txtDescontoFixoPorc.Text = null;
                    }
                }
            }
            txtDescontoFixoPorc.BackColor = Color.White;
        }

        private void txtAcrescimoFixoPorc_Enter(object sender, EventArgs e)
        {
            txtAcrescimoFixoPorc.BackColor = Color.LightBlue;
        }

        private void txtAcrescimoFixoPorc_Leave(object sender, EventArgs e)
        {
            if (txtAcrescimoFixoPorc.Text.Contains("'") || txtAcrescimoFixoPorc.Text.Contains(";") || txtAcrescimoFixoPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtAcrescimoFixoPorc.Text = null;
            }
            else
            {
                if (txtAcrescimoFixoPorc.Text != "")
                {
                    try
                    {
                        txtAcrescimoFixoPorc.Text = Convert.ToDecimal(txtAcrescimoFixoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAcrescimoFixoPorc.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAcrescimoFixoPorc.");
                        }
                        txtAcrescimoFixoPorc.Text = null;
                    }
                }
            }
            txtAcrescimoFixoPorc.BackColor = Color.White;
        }

        private void txtAcrescimoFixoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAcrescimoFixoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (cbbTipo.SelectedIndex == 4 || cbbTipo.SelectedIndex == 0)
                {
                    txtPrimeiroPagamento.Select();
                }
                else
                {
                    btnSimular.Select();
                }
            }
        }

        private void FrmSimularFormaPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllFormaPagamento._FrmSimuFormaPagamento_Ativo = false;
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmSimularFormaPagamento foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmSimularFormaPagamento foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmSimularFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmSimularFormaPagamento.");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ent: Entrada" + Environment.NewLine + "Acresc: Acréscimo Fixo" + Environment.NewLine + "Desc: Desconto Fixo" + Environment.NewLine + "parc: Parcela" + Environment.NewLine, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
