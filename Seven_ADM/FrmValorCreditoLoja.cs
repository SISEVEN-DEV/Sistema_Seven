using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmValorCreditoLoja : Form
    {
        public FrmValorCreditoLoja(string consumidor, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Consumidor = consumidor;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Consumidor;
        private string _Valor;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmConfCadAluno_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmValorCreditoLoja iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmValorCreditoLoja iniciado.");
                }
                //
                _Valor = bllContasReceber.Sel_Credito_Loja_Cliente_Conta_Receber(_Consumidor);
                txtValorDisponivel.Text = Convert.ToDecimal(_Valor).ToString("n2", new CultureInfo("pt-BR"));
                //
                txtValor.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmValorCreditoLoja.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmValorCreditoLoja.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Select();
                if (txtValor.Text == "")
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido.\n< Valor do Crédito >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtValor.Select();
                }
                else if (Convert.ToDecimal(txtValor.Text) <= 0)
                {
                    MessageBox.Show("O valor informado não pode ser 0,00.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtValor.Select();
                }
                else if (Convert.ToDecimal(txtValor.Text) > Convert.ToDecimal(_Valor))
                {
                    DialogResult = MessageBox.Show("O valor informado ultrapassa o valor em crédito da loja que o cliente/consumidor possui disponível, deseja continuar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        if (bllUsuario.Sel_Permitir_Venda_S_Credito_Loja_Usuario(_Usuario) == true)
                        {
                            bllContasReceber._Valor_Credito_Loja = txtValor.Text;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            /*
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(_Usuario, _Cod_PDV_Computador, "Permitir_Venda_S_Credito_Loja"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Venda_S_Credito_Loja == 1)
                                    {
                                        bllVenda._Valor_Credito_Loja = txtValor.Text;
                                        this.DialogResult = DialogResult.OK;
                                    }
                                    else if (bllVenda._Permitir_Venda_S_Credito_Loja == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para permitir uma venda para Consumidor sem saldo disponível.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                            }
                            */
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        txtValor.Select();
                    }
                }
                else
                {
                    bllContasReceber._Valor_Credito_Loja = txtValor.Text;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValor.Text != "")
                {
                    if (Convert.ToDecimal(txtValor.Text) > Convert.ToDecimal(_Valor))
                    {
                        txtValor.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtValor.ForeColor = Color.Blue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged do txtValor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged do txtValor.");
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                _Valor = bllContasReceber.Sel_Credito_Loja_Cliente_Conta_Receber(_Consumidor);
                txtValorDisponivel.Text = Convert.ToDecimal(_Valor).ToString("n2", new CultureInfo("pt-BR"));
                //
                txtValor.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAtualizar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAtualizar.");
                }
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValor.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                if (txtValor.Text.Contains("'") || txtValor.Text.Contains(";") || txtValor.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValor.Text = null;
                    txtValor.Select();
                }
                else
                {
                    try
                    {
                        txtValor.Text = Convert.ToDecimal(txtValor.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValor.");
                        }
                        txtValor.Text = null;
                    }
                }
            }
            txtValor.BackColor = Color.White;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O valor informado no campo valor do crédito é o valor total de crédito em loja que o consumidor possui você pode informar este valor total ou um valor menor em crédito loja.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
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

        private void btnAtualizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAtualizar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            txtValor.BackColor = Color.LightBlue;
        }

        private void FrmValorCreditoLoja_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
