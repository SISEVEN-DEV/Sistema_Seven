using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmDescontoAcrescimoOrc : Form
    {
        public FrmDescontoAcrescimoOrc(string total_real)
        {
            InitializeComponent();
            _Total_Real = total_real;
        }

        string _Total_Real;

        private void FrmDescontoAcrescimoOrc_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmDescontoAcrescimoOrc iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmDescontoAcrescimoOrc iniciado.");
                }
                //
                lblTotalSub.Text = _Total_Real;
                //
                txtValorDesconto.Text = "0,00";
                //
                txtDescontoPorc.Text = "0,00";
                //
                txtValorAcrescimo.Text = "0,00";
                //
                txtAcrescimoPorc.Text = "0,00";
                //
                lblValorTotalDescAcresc.Text = _Total_Real;
                //
                btnSalvar.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmDescontoAcrescimoOrc.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmDescontoAcrescimoOrc.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtDescontoPorc_Enter(object sender, EventArgs e)
        {
            txtDescontoPorc.BackColor = Color.LightBlue;
        }

        private void txtDescontoPorc_Leave(object sender, EventArgs e)
        {
            if (txtDescontoPorc.Text.Contains("'") || txtDescontoPorc.Text.Contains(";") || txtDescontoPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescontoPorc.Text = null;
                txtDescontoPorc.Select();
            }
            else
            {
                try
                {
                    if (txtDescontoPorc.Text != "")
                    {
                        txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblTotalSub.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Desc_Acresc_Orc(lblTotalSub.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        txtDescontoPorc.Text = "0,00";
                        //
                        txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblTotalSub.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Desc_Acresc_Orc(lblTotalSub.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescontoPorc.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescontoPorc.");
                    }
                    txtDescontoPorc.Text = null;
                }
            }
            txtDescontoPorc.BackColor = Color.White;
        }

        private void txtValorDesconto_Leave(object sender, EventArgs e)
        {
            if (txtValorDesconto.Text.Contains("'") || txtValorDesconto.Text.Contains(";") || txtValorDesconto.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtValorDesconto.Text = null;
                txtValorDesconto.Select();
            }
            else
            {
                try
                {
                    if (txtValorDesconto.Text != "")
                    {
                        txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtDescontoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorDesconto(lblTotalSub.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Desc_Acresc_Orc(lblTotalSub.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        txtValorDesconto.Text = "0,00";
                        //
                        txtDescontoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorDesconto(lblTotalSub.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Desc_Acresc_Orc(lblTotalSub.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorDesconto.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorDesconto.");
                    }
                    txtValorDesconto.Text = null;
                }
            }
            txtValorDesconto.BackColor = Color.White;
        }

        private void txtValorDesconto_Enter(object sender, EventArgs e)
        {
            txtValorDesconto.BackColor = Color.LightBlue;
        }

        private void txtAcrescimoPorc_Leave(object sender, EventArgs e)
        {
            if (txtAcrescimoPorc.Text.Contains("'") || txtAcrescimoPorc.Text.Contains(";") || txtAcrescimoPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtAcrescimoPorc.Text = null;
                txtAcrescimoPorc.Select();
            }
            else
            {
                try
                {
                    if (txtAcrescimoPorc.Text != "")
                    {
                        txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));

                        txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblTotalSub.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                        lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Desc_Acresc_Orc(lblTotalSub.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        txtAcrescimoPorc.Text = "0,00";

                        txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblTotalSub.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                        lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Desc_Acresc_Orc(lblTotalSub.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAcrescimoPorc.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAcrescimoPorc.");
                    }
                    txtAcrescimoPorc.Text = null;
                }
            }
            txtAcrescimoPorc.BackColor = Color.White;
        }

        private void txtValorAcrescimo_Leave(object sender, EventArgs e)
        {
            if (txtValorAcrescimo.Text.Contains("'") || txtValorAcrescimo.Text.Contains(";") || txtValorAcrescimo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtValorAcrescimo.Text = null;
                txtValorAcrescimo.Select();
            }
            else
            {
                try
                {
                    if (txtValorAcrescimo.Text != "")
                    {
                        txtValorAcrescimo.Text = Convert.ToDecimal(txtValorAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));

                        txtAcrescimoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorAcrescimo(lblTotalSub.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                        lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Desc_Acresc_Orc(lblTotalSub.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        txtValorAcrescimo.Text = "0,00";

                        txtAcrescimoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorAcrescimo(lblTotalSub.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                        lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Desc_Acresc_Orc(lblTotalSub.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorAcrescimo.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorAcrescimo.");
                    }
                    txtValorAcrescimo.Text = null;
                }
            }
            txtValorAcrescimo.BackColor = Color.White;
        }

        private void txtValorAcrescimo_Enter(object sender, EventArgs e)
        {
            txtValorAcrescimo.BackColor = Color.LightBlue;
        }

        private void txtAcrescimoPorc_Enter(object sender, EventArgs e)
        {
            txtAcrescimoPorc.BackColor = Color.LightBlue;
        }

        private void lblTotalSub_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalSub_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalDescAcresc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalDescAcresc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalSub_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblTotalSub.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalDescAcresc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total a Pagar (R$): " + lblValorTotalDescAcresc.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            bllOrcamento._Acrescimo_Porc = txtAcrescimoPorc.Text;
            bllOrcamento._Valor_Acrescimo = txtValorAcrescimo.Text;
            bllOrcamento._Desconto_Porc = txtDescontoPorc.Text;
            bllOrcamento._Valor_Desconto = txtValorDesconto.Text;
            bllOrcamento._Valor_Real = lblValorTotalDescAcresc.Text;
            this.DialogResult = DialogResult.OK;
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
            MessageBox.Show("1 - Descontos e Acréscimos: Informe desconto e acréscimo caso seja necessário.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmDescontoAcrescimoOrc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtDescontoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorDesconto.Select();
            }
            if (txtDescontoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
        }

        private void txtValorDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAcrescimoPorc.Select();
            }
            if (txtValorDesconto.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
        }

        private void txtAcrescimoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorAcrescimo.Select();
            }
            if (txtAcrescimoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
        }

        private void txtValorAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
            if (txtAcrescimoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
        }

        private void FrmDescontoAcrescimoOrc_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmDescontoAcrescimoOrc foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmDescontoAcrescimoOrc foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmDescontoAcrescimoOrc.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmDescontoAcrescimoOrc.");
                }
            }
        }
    }
}
