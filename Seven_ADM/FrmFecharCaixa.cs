using BLL;
using Seven_ADM;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmFecharCaixa : Form
    {
        public FrmFecharCaixa(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Trabalho;
        private string _Data_Abertura;
        private string _Hora_Abertura;
        private string _Total1;
        private string _Total2;
        private string _Total3;
        private string _Total4;
        private string _Total6;
        private string _Totais;
        private string _Total8;


        private void FrmFecharCaixa_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFecharCaixa iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFecharCaixa iniciado.");
                }
                //
                pgbProgresso.Visible = true;
                lblProgresso.Visible = true;
                _Trabalho = 0;
                bckwIndeterminado.RunWorkerAsync();
                pgbProgresso.MarqueeAnimationSpeed = 2;
                this.Cursor = Cursors.WaitCursor;
                grbBox1.Enabled = false;
                //      
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmFecharCaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmFecharCaixa.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Limpar()
        {
            txtValor1.Text = null;
            txtValor2.Text = null;
            txtValor3.Text = null;
            txtValor4.Text = null;
            txtValor7.Text = null;
            txtValor8.Text = null;
            lblTotal1.Text = "0,00";
            lblTotal2.Text = "0,00";
            lblTotal3.Text = "0,00";
            lblTotal4.Text = "0,00";
            lblTotal6.Text = "0,00";
            lblQuebra1.Text = "0,00";
            lblQuebra2.Text = "0,00";
            lblQuebra3.Text = "0,00";
            lblQuebra4.Text = "0,00";
            lblQuebra7.Text = "0,00";
            lblQuebra8.Text = "0,00";
        }

        private void FrmFecharCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtValor1_Enter(object sender, EventArgs e)
        {
            txtValor1.BackColor = Color.LightBlue;
        }

        private void txtValor2_Enter(object sender, EventArgs e)
        {
            txtValor2.BackColor = Color.LightBlue;
        }

        private void txtValor3_Enter(object sender, EventArgs e)
        {
            txtValor3.BackColor = Color.LightBlue;
        }

        private void txtValor4_Enter(object sender, EventArgs e)
        {
            txtValor4.BackColor = Color.LightBlue;
        }

        private void txtValor7_Enter(object sender, EventArgs e)
        {
            txtValor7.BackColor = Color.LightBlue;
        }

        private void txtValor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor1.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValor2.Select();
            }
        }

        private void txtValor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor2.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValor3.Select();
            }
        }

        private void txtValor3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValor3.Text.Trim() != "")
                {
                    decimal valor_Pago;
                    decimal _Valor_Diferenca;
                    //
                    valor_Pago = Convert.ToDecimal(txtValor3.Text);
                    //
                    if (valor_Pago < Convert.ToDecimal(lblTotal3.Text))
                    {
                        lblQuebra3.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblQuebra3.ForeColor = Color.Blue;
                    }
                    //
                    _Valor_Diferenca = valor_Pago - Convert.ToDecimal(lblTotal3.Text);
                    lblQuebra3.Text = Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblQuebra3.Text = lblTotal3.Text;
                    lblQuebra3.ForeColor = Color.Red;
                }
                //
                lblValorTotalInformado.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarValorInformado(txtValor1.Text.Trim(), txtValor2.Text.Trim(), txtValor3.Text.Trim(), txtValor4.Text.Trim(), txtValor7.Text.Trim(), txtValor8.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor3.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor3.");
                }
                lblQuebra3.Text = lblTotal3.Text;
                lblQuebra3.ForeColor = Color.Red;
                txtValor3.Text = null;
            }
        }

        private void txtValor3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor3.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValor4.Select();
            }
        }

        private void txtValor4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor4.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
               
            }
        }

        private void txtValor7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor7.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValor8.Select();
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPreencher_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPreencher_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmFecharCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFecharCaixa foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFecharCaixa foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmFecharCaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmFecharCaixa.");
                }
            }
        }

        private void FrmFecharCaixa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtValor1_Leave(object sender, EventArgs e)
        {
            if (txtValor1.Text != "")
            {
                if (txtValor1.Text.Contains("'") || txtValor1.Text.Contains(";") || txtValor1.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValor1.Text = null;
                    txtValor1.Select();
                }
                else
                {
                    try
                    {
                        txtValor1.Text = Convert.ToDecimal(txtValor1.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor1.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor1.");
                        }
                        txtValor1.Text = null;
                    }
                }
            }
            txtValor1.BackColor = Color.White;
        }

        private void txtValor2_Leave(object sender, EventArgs e)
        {
            if (txtValor2.Text != "")
            {
                if (txtValor2.Text.Contains("'") || txtValor2.Text.Contains(";") || txtValor2.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValor2.Text = null;
                    txtValor2.Select();
                }
                else
                {
                    try
                    {
                        txtValor2.Text = Convert.ToDecimal(txtValor2.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor2.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor2.");
                        }
                        txtValor2.Text = null;
                    }
                }
            }
            txtValor2.BackColor = Color.White;
        }

        private void txtValor3_Leave(object sender, EventArgs e)
        {
            if (txtValor3.Text != "")
            {
                if (txtValor3.Text.Contains("'") || txtValor3.Text.Contains(";") || txtValor3.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValor3.Text = null;
                    txtValor3.Select();
                }
                else
                {
                    try
                    {
                        txtValor3.Text = Convert.ToDecimal(txtValor3.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor3.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor3.");
                        }
                        txtValor3.Text = null;
                    }
                }
            }
            txtValor3.BackColor = Color.White;
        }

        private void txtValor4_Leave(object sender, EventArgs e)
        {
            if (txtValor4.Text != "")
            {
                if (txtValor4.Text.Contains("'") || txtValor4.Text.Contains(";") || txtValor4.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValor4.Text = null;
                    txtValor4.Select();
                }
                else
                {
                    try
                    {
                        txtValor4.Text = Convert.ToDecimal(txtValor4.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor4.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor4.");
                        }
                        txtValor4.Text = null;
                    }
                }
            }
            txtValor4.BackColor = Color.White;
        }

        private void txtValor7_Leave(object sender, EventArgs e)
        {
            if (txtValor7.Text != "")
            {
                if (txtValor7.Text.Contains("'") || txtValor7.Text.Contains(";") || txtValor7.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValor7.Text = null;
                    txtValor7.Select();
                }
                else
                {
                    try
                    {
                        txtValor7.Text = Convert.ToDecimal(txtValor7.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor7.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor7.");
                        }
                        txtValor7.Text = null;
                    }
                }
            }
            txtValor7.BackColor = Color.White;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Preencher Automaticamente: Clique para preencher os campos [ Valor Informado ] automaticamente.\n\n2 - Calcular Totais Novamente: Clique para recalcular os totais.\n\n3 - Salvar: Clique para salvar os dados informados e proseeguir com o fechamento do caixa.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblDinheiro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tipo de Pagamento 1: " + lblDinheiro.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblCartaoCredito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tipo de Pagamento 2: " + lblCartaoCredito.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblCartaoDebito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tipo de Pagamento 3: " + lblCartaoDebito.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblPIX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tipo de Pagamento 4: " + lblPIX.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblCheque_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tipo de Pagamento 6: " + lblCheque.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblDinheiro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblDinheiro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblCartaoCredito_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblCartaoCredito_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblCartaoDebito_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblCartaoDebito_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblPIX_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblPIX_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblCreditoLoja_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblCreditoLoja_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblCheque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblCheque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotal1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total em DINHEIRO (R$): " + lblTotal1.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotal2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total em CARTAO DE CREDITO (R$): " + lblTotal2.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotal3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total em CARTAO DE DEBITO (R$): " + lblTotal3.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotal4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total em PIX (R$): " + lblTotal4.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotal7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total em CHEQUE (R$): " + lblTotal6.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotal1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotal1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotal2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotal2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotal3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotal3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotal4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotal4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotal6_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotal6_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotal7_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotal7_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQuebra1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQuebra1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQuebra2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQuebra2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQuebra3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQuebra3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQuebra4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQuebra4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQuebra6_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQuebra6_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQuebra7_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQuebra7_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQuebra1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quebra de Caixa em DINHEIRO (R$): " + lblQuebra1.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblQuebra2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quebra de Caixa em CARTÃO DE CRÉDITO (R$): " + lblQuebra2.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblQuebra3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quebra de Caixa em CARTÃO DE DÉBITO (R$): " + lblQuebra3.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblQuebra4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quebra de Caixa em PIX (R$): " + lblQuebra4.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblQuebra7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quebra de Caixa em CHEQUE (R$): " + lblQuebra7.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtValor1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValor1.Text.Trim() != "")
                {
                    decimal valor_Pago;
                    decimal _Valor_Diferenca;
                    //
                    valor_Pago = Convert.ToDecimal(txtValor1.Text);
                    //
                    if (valor_Pago < Convert.ToDecimal(lblTotal1.Text))
                    {
                        lblQuebra1.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblQuebra1.ForeColor = Color.Blue;
                    }
                    //
                    _Valor_Diferenca = valor_Pago - Convert.ToDecimal(lblTotal1.Text);
                    lblQuebra1.Text = Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblQuebra1.Text = lblTotal1.Text;
                    lblQuebra1.ForeColor = Color.Red;
                }
                //
                lblValorTotalInformado.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarValorInformado(txtValor1.Text.Trim(), txtValor2.Text.Trim(), txtValor3.Text.Trim(), txtValor4.Text.Trim(), txtValor7.Text.Trim(), txtValor8.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor1.");
                }
                lblQuebra1.Text = lblTotal1.Text;
                lblQuebra1.ForeColor = Color.Red;
                txtValor1.Text = null;
            }
        }

        private void txtValor2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValor2.Text.Trim() != "")
                {
                    decimal valor_Pago;
                    decimal _Valor_Diferenca;
                    //
                    valor_Pago = Convert.ToDecimal(txtValor2.Text);
                    //
                    if (valor_Pago < Convert.ToDecimal(lblTotal2.Text))
                    {
                        lblQuebra2.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblQuebra2.ForeColor = Color.Blue;
                    }
                    //
                    _Valor_Diferenca = valor_Pago - Convert.ToDecimal(lblTotal2.Text);
                    lblQuebra2.Text = Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblQuebra2.Text = lblTotal2.Text;
                    lblQuebra2.ForeColor = Color.Red;
                }
                //
                lblValorTotalInformado.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarValorInformado(txtValor1.Text.Trim(), txtValor2.Text.Trim(), txtValor3.Text.Trim(), txtValor4.Text.Trim(), txtValor7.Text.Trim(), txtValor8.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor2.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor2.");
                }
                lblQuebra2.Text = lblTotal2.Text;
                lblQuebra2.ForeColor = Color.Red;
                txtValor2.Text = null;
            }
        }

        private void txtValor4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValor4.Text.Trim() != "")
                {
                    decimal valor_Pago;
                    decimal _Valor_Diferenca;
                    //
                    valor_Pago = Convert.ToDecimal(txtValor4.Text);
                    //
                    if (valor_Pago < Convert.ToDecimal(lblTotal4.Text))
                    {
                        lblQuebra4.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblQuebra4.ForeColor = Color.Blue;
                    }
                    //
                    _Valor_Diferenca = valor_Pago - Convert.ToDecimal(lblTotal4.Text);
                    lblQuebra4.Text = Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblQuebra4.Text = lblTotal3.Text;
                    lblQuebra4.ForeColor = Color.Red;
                }
                //
                lblValorTotalInformado.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarValorInformado(txtValor1.Text.Trim(), txtValor2.Text.Trim(), txtValor3.Text.Trim(), txtValor4.Text.Trim(), txtValor7.Text.Trim(), txtValor8.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor4.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor4.");
                }
                lblQuebra4.Text = lblTotal4.Text;
                lblQuebra4.ForeColor = Color.Red;
                txtValor4.Text = null;
            }
        }

        private void txtValor7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValor7.Text.Trim() != "")
                {
                    decimal valor_Pago;
                    decimal _Valor_Diferenca;
                    //
                    valor_Pago = Convert.ToDecimal(txtValor7.Text);
                    //
                    if (valor_Pago < Convert.ToDecimal(lblTotal6.Text))
                    {
                        lblQuebra7.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblQuebra7.ForeColor = Color.Blue;
                    }
                    //
                    _Valor_Diferenca = valor_Pago - Convert.ToDecimal(lblTotal6.Text);
                    lblQuebra7.Text = Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblQuebra7.Text = lblTotal6.Text;
                    lblQuebra7.ForeColor = Color.Red;
                }
                //
                lblValorTotalInformado.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarValorInformado(txtValor1.Text.Trim(), txtValor2.Text.Trim(), txtValor3.Text.Trim(), txtValor4.Text.Trim(), txtValor7.Text.Trim(), txtValor8.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor7.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor7.");
                }
                lblQuebra7.Text = lblTotal6.Text;
                lblQuebra7.ForeColor = Color.Red;
                txtValor7.Text = null;
            }
        }

        private void btnPreencher_Click(object sender, EventArgs e)
        {
            txtValor1.Text = lblTotal1.Text;
            txtValor2.Text = lblTotal2.Text;
            txtValor3.Text = lblTotal3.Text;
            txtValor4.Text = lblTotal4.Text;
            txtValor7.Text = lblTotal6.Text;
            txtValor8.Text = lblTotal8.Text;
            MessageBox.Show("Os dados foram preenchidos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtValor1.Select();
            this.DialogResult = DialogResult.None;
        }

        private void btnCalcularNovamente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCalcularNovamente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCalcularNovamente_Click(object sender, EventArgs e)
        {
            try
            {
                Limpar();
                //
                pgbProgresso.Visible = true;
                lblProgresso.Visible = true;
                _Trabalho = 0;
                bckwIndeterminado.RunWorkerAsync();
                pgbProgresso.MarqueeAnimationSpeed = 2;
                this.Cursor = Cursors.WaitCursor;
                grbBox1.Enabled = false;
                //      
                txtValor1.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCalcularNovamente.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCalcularNovamente.");
                }
                this.DialogResult = DialogResult.None;
            }
        }

        private void lblQuebra3_TextChanged(object sender, EventArgs e)
        {
            lblTotalQuebraCaixa.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarQuebraCaixa(lblQuebra1.Text, lblQuebra2.Text, lblQuebra3.Text, lblQuebra4.Text, lblQuebra7.Text, lblQuebra8.Text)).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados e Fechar o Caixa?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (txtValor1.Text.Trim() == "" || txtValor2.Text.Trim() == "" || txtValor3.Text.Trim() == "" || txtValor4.Text.Trim() == "" || txtValor7.Text.Trim() == "" || txtValor8.Text.Trim() == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n< Valor Informado>.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtValor1.Select();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        if (lblQuebra1.Text.Contains('-'))
                        {
                            DialogResult = MessageBox.Show("Existe uma quebra de caixa no valor de " + lblQuebra1.Text.Replace("-", "") + " R$ na forma de pagamento DINHEIRO, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        //
                        if (lblQuebra2.Text.Contains('-'))
                        {
                            DialogResult = MessageBox.Show("Existe uma quebra de caixa no valor de " + lblQuebra2.Text.Replace("-", "") + " R$ na forma de pagamento CARTÃO DE CRÉDITO, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        //
                        if (lblQuebra3.Text.Contains('-'))
                        {
                            DialogResult = MessageBox.Show("Existe uma quebra de caixa no valor de " + lblQuebra3.Text.Replace("-", "") + " R$ na forma de pagamento CARTÃO DE DEBITO, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        //
                        if (lblQuebra4.Text.Contains('-'))
                        {
                            DialogResult = MessageBox.Show("Existe uma quebra de caixa no valor de " + lblQuebra4.Text.Replace("-", "") + " R$ na forma de pagamento PIX, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        //
                        if (lblQuebra7.Text.Contains('-'))
                        {
                            DialogResult = MessageBox.Show("Existe uma quebra de caixa no valor de " + lblQuebra7.Text.Replace("-", "") + " R$ na forma de pagamento CHEQUE, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        //
                        if (lblQuebra8.Text.Contains('-'))
                        {
                            DialogResult = MessageBox.Show("Existe uma quebra de caixa no valor de " + lblQuebra8.Text.Replace("-", "") + " R$ na forma de pagamento VALE ALIM.REF., deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        //
                        DialogResult = MessageBox.Show("Deseja realizar uma sangria?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            using (FrmCadSangriaSuprimento Sang = new FrmCadSangriaSuprimento(_Usuario, _Cod_PDV_Computador, 1, txtValor1.Text))
                            {
                                if (Sang.ShowDialog() == DialogResult.OK)
                                {
                                    btnSalvar.Select();
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                        //
                        string cod_abert_fech_caixa = bllAbert_Fech_Caixa.Sel_Ultima_Abert_Fech_Caixa(_Cod_PDV_Computador);
                        //
                        bllAbert_Fech_Caixa.Salvar_Item_Abert_Fech_Caixa("1", lblDinheiro.Text.ToUpper(), lblTotal1.Text, txtValor1.Text, lblQuebra1.Text, cod_abert_fech_caixa);
                        //
                        bllAbert_Fech_Caixa.Salvar_Item_Abert_Fech_Caixa("2", lblCartaoCredito.Text.ToUpper(), lblTotal2.Text, txtValor2.Text, lblQuebra2.Text, cod_abert_fech_caixa);
                        //
                        bllAbert_Fech_Caixa.Salvar_Item_Abert_Fech_Caixa("3", lblCartaoDebito.Text.ToUpper(), lblTotal3.Text, txtValor3.Text, lblQuebra3.Text, cod_abert_fech_caixa);
                        //
                        bllAbert_Fech_Caixa.Salvar_Item_Abert_Fech_Caixa("4", lblPIX.Text.ToUpper(), lblTotal4.Text, txtValor4.Text, lblQuebra4.Text, cod_abert_fech_caixa);
                        //
                        bllAbert_Fech_Caixa.Salvar_Item_Abert_Fech_Caixa("5", lblCheque.Text.ToUpper(), lblTotal6.Text, txtValor7.Text, lblQuebra7.Text, cod_abert_fech_caixa);
                        //
                        bllAbert_Fech_Caixa.Salvar_Item_Abert_Fech_Caixa("6", lblALimentacaoRefeicao.Text.ToUpper(), lblTotal8.Text, txtValor8.Text, lblQuebra8.Text, cod_abert_fech_caixa);
                        //
                        bllAbert_Fech_Caixa.Salvar_Fechamento(lblTotalTotais.Text, lblTotalQuebraCaixa.Text, rtxtObs.Text.Trim(), _Cod_PDV_Computador, _Usuario, cod_abert_fech_caixa);
                        //
                        DataRow dr = bllAbert_Fech_Caixa.Sel_Fechamento_Caixa_A_Sal().Rows[0];
                        //
                        bllRegistroAtividades.Salvar("FECHOU O CAIXA.", "ABERT/FECH/CAIXA", cod_abert_fech_caixa, _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Abert/Fech de Caixa cadastrada. Cod: " + cod_abert_fech_caixa + " | Descrição: FECHAMENTO DE CAIXA");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Abert/Fech de Caixa cadastrada. Cod: " + cod_abert_fech_caixa + " | Descrição: FECHAMENTO DE CAIXA");
                        }
                        //
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //
                        DialogResult = MessageBox.Show("Deseja imprimir o Histórico do Caixa no período de abertura/fechamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            using (FrmRelHistCaixa Sang = new FrmRelHistCaixa(_Data_Abertura, dr["data_fechamento"].ToString(), _Hora_Abertura, dr["hora_fechamento"].ToString(), _Cod_PDV_Computador, _Usuario, _Cod_PDV_Computador, 1))
                            {
                                if (Sang.ShowDialog() == DialogResult.OK)
                                {
                                    btnSalvar.Select();
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                        //
                        MessageBox.Show("Caixa fechado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                //
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                Limpar();
                btnCalcularNovamente_Click(sender, e);
                this.DialogResult = DialogResult.None;
            }
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Contains("'") || rtxtObs.Text.Contains(";") || rtxtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                rtxtObs.Text = null;
            }
            rtxtObs.BackColor = Color.White;
        }

        private void rtxtObs_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + rtxtObs.Text.Length + "/200";
        }

        private void lblQuebra1_TextChanged(object sender, EventArgs e)
        {
            lblTotalQuebraCaixa.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarQuebraCaixa(lblQuebra1.Text, lblQuebra2.Text, lblQuebra3.Text, lblQuebra4.Text, lblQuebra7.Text, lblQuebra8.Text)).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void lblQuebra2_TextChanged(object sender, EventArgs e)
        {
            lblTotalQuebraCaixa.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarQuebraCaixa(lblQuebra1.Text, lblQuebra2.Text, lblQuebra3.Text, lblQuebra4.Text, lblQuebra7.Text, lblQuebra8.Text)).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void lblQuebra4_TextChanged(object sender, EventArgs e)
        {
            lblTotalQuebraCaixa.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarQuebraCaixa(lblQuebra1.Text, lblQuebra2.Text, lblQuebra3.Text, lblQuebra4.Text, lblQuebra7.Text, lblQuebra8.Text)).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void lblQuebra6_TextChanged(object sender, EventArgs e)
        {
            lblTotalQuebraCaixa.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarQuebraCaixa(lblQuebra1.Text, lblQuebra2.Text, lblQuebra3.Text, lblQuebra4.Text, lblQuebra7.Text, lblQuebra8.Text)).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void lblQuebra7_TextChanged(object sender, EventArgs e)
        {
            lblTotalQuebraCaixa.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarQuebraCaixa(lblQuebra1.Text, lblQuebra2.Text, lblQuebra3.Text, lblQuebra4.Text, lblQuebra7.Text, lblQuebra8.Text)).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void lblTotalTotais_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total das Movimentações (R$): " + lblTotalTotais.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalInformado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total dos Valores Informados (R$): " + lblValorTotalInformado.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalQuebraCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total da Quebra de Caixa (R$): " + lblTotalQuebraCaixa.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotalTotais_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalTotais_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalInformado_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalInformado_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalQuebraCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalQuebraCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_Trabalho == 0)
            {
                DataRow dr = bllAbert_Fech_Caixa.Sel_Data_Ultimo_Fech_Caixa_PDV(_Cod_PDV_Computador).Rows[0];
                //
                _Data_Abertura = dr["data_abertura"].ToString().Remove(10);
                _Hora_Abertura = dr["hora_abertura"].ToString();
                //
                string[] items = _Cod_PDV_Computador.Split('/');
                //
                _Total1 = Convert.ToDecimal(Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Dinheiro_Hist(_Data_Abertura, DateTime.Now.ToShortDateString(), _Hora_Abertura, DateTime.Now.ToLongTimeString(), items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", ""), "")) - Convert.ToDecimal(bllHistCaixa.Sel_Abert_Caixa_Dados_Troco(_Data_Abertura, DateTime.Now.ToShortDateString(), _Hora_Abertura, DateTime.Now.ToLongTimeString(), items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", ""), "")) - Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Dev_Dinheiro_Hist(_Data_Abertura, DateTime.Now.ToShortDateString(), _Hora_Abertura, DateTime.Now.ToLongTimeString(), items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", ""), ""))).ToString("n2", new CultureInfo("pt-BR"));
                //              
                _Total2 = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Cartao_Credito_Hist(_Data_Abertura, DateTime.Now.ToShortDateString(), _Hora_Abertura, DateTime.Now.ToLongTimeString(), items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", ""), "")).ToString("n2", new CultureInfo("pt-BR"));
                //               
                _Total3 = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Cartao_Debito_Hist(_Data_Abertura, DateTime.Now.ToShortDateString(), _Hora_Abertura, DateTime.Now.ToLongTimeString(), items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", ""), "")).ToString("n2", new CultureInfo("pt-BR"));
                //
                _Total4 = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Pix_Hist(_Data_Abertura, DateTime.Now.ToShortDateString(), _Hora_Abertura, DateTime.Now.ToLongTimeString(), items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", ""), "")).ToString("n2", new CultureInfo("pt-BR"));
                //
                _Total6 = Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Cheque_Hist(_Data_Abertura, DateTime.Now.ToShortDateString(), _Hora_Abertura, DateTime.Now.ToLongTimeString(), items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", ""), "")).ToString("n2", new CultureInfo("pt-BR"));
                //
                _Total8 = Convert.ToDecimal(Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Alimentacao_Hist(_Data_Abertura, DateTime.Now.ToShortDateString(), _Hora_Abertura, DateTime.Now.ToLongTimeString(), items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", ""), "")) + Convert.ToDecimal(bllHistCaixa.Sel_Caixa_Dados_Pagamento_Refeicao_Hist(_Data_Abertura, DateTime.Now.ToShortDateString(), _Hora_Abertura, DateTime.Now.ToLongTimeString(), items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", ""), ""))).ToString("n2", new CultureInfo("pt-BR"));
                //
                _Totais = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarTotais(_Total1, _Total2, _Total3, _Total4, _Total6, _Total8)).ToString("n2", new CultureInfo("pt-BR"));
                //
                lblPeriodo.Text = "Período:\n" + _Data_Abertura + " " + _Hora_Abertura + " até " + DateTime.Now.ToShortDateString() + "  -  Nº Comp/PDV: " + items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", "");
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                //
                pgbProgresso.Value = 0;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                grbBox1.Enabled = true;
                btnSair.Enabled = true;
            }
            else
            {
                lblTotal1.Text = _Total1;
                lblTotal2.Text = _Total2;
                lblTotal3.Text = _Total3;
                lblTotal4.Text = _Total4;
                lblTotal6.Text = _Total6;
                lblTotal8.Text = _Total8;
                lblTotalTotais.Text = _Totais;
                //
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                grbBox1.Enabled = true;
                txtValor1.Select();
            }
        }

        private void btnHistoricoCaixa_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                //
                using (FrmRelHistCaixa Hist = new FrmRelHistCaixa(_Data_Abertura, DateTime.Now.ToShortDateString().Replace('/', '.'), _Hora_Abertura, DateTime.Now.ToLongTimeString(), _Cod_PDV_Computador, _Usuario, _Cod_PDV_Computador, 1))
                {
                    if (Hist.ShowDialog() == DialogResult.Abort)
                    {
                        btnHistoricoCaixa.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnHistoricoCaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnHistoricoCaixa.");
                }
            }
            this.Enabled = true;
        }

        private void btnHistoricoCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnHistoricoCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQuebra8_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblQuebra8_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblQuebra8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quebra de Caixa em VALE ALIMENTAÇÃO/REFEIÇÃO (R$): " + lblQuebra7.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtValor8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor8.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnCalcularNovamente.Select();
            }
        }

        private void txtValor8_Enter(object sender, EventArgs e)
        {
            txtValor8.BackColor = Color.LightBlue;
        }

        private void txtValor8_Leave(object sender, EventArgs e)
        {
            if (txtValor8.Text != "")
            {
                if (txtValor8.Text.Contains("'") || txtValor8.Text.Contains(";") || txtValor8.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValor8.Text = null;
                    txtValor8.Select();
                }
                else
                {
                    try
                    {
                        txtValor8.Text = Convert.ToDecimal(txtValor8.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor8.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor8.");
                        }
                        txtValor8.Text = null;
                    }
                }
            }
            txtValor8.BackColor = Color.White;
        }

        private void txtValor8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValor8.Text.Trim() != "")
                {
                    decimal valor_Pago;
                    decimal _Valor_Diferenca;
                    //
                    valor_Pago = Convert.ToDecimal(txtValor8.Text);
                    //
                    if (valor_Pago < Convert.ToDecimal(lblTotal8.Text))
                    {
                        lblQuebra8.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblQuebra8.ForeColor = Color.Blue;
                    }
                    //
                    _Valor_Diferenca = valor_Pago - Convert.ToDecimal(lblTotal8.Text);
                    lblQuebra8.Text = Convert.ToDecimal(_Valor_Diferenca).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblQuebra8.Text = lblTotal6.Text;
                    lblQuebra8.ForeColor = Color.Red;
                }
                //
                lblValorTotalInformado.Text = Convert.ToDecimal(bllAbert_Fech_Caixa.SomvarValorInformado(txtValor1.Text.Trim(), txtValor2.Text.Trim(), txtValor3.Text.Trim(), txtValor4.Text.Trim(), txtValor7.Text.Trim(), txtValor8.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor7.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor7.");
                }
                lblQuebra8.Text = lblTotal6.Text;
                lblQuebra8.ForeColor = Color.Red;
                txtValor8.Text = null;
            }
        }

        private void lblTotal8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total em VALE ALIMENTAÇÃO/REFEIÇÃO (R$): " + lblTotal6.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblTotal8_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotal8_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblALimentacaoRefeicao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblALimentacaoRefeicao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblALimentacaoRefeicao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tipo de Pagamento 7: " + lblALimentacaoRefeicao.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
