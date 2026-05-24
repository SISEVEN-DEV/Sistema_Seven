using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPlanoNotaPromissoria : Form
    {
        public FrmPlanoNotaPromissoria(byte formulario, string total_a_pagar, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Total_A_Pagar = total_a_pagar;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Formulario;
        private string _Total_A_Pagar;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmPesqUsuario_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPlanoNotaPromissoria iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPlanoNotaPromissoria iniciado.");
                }
                //
                lblTotalSub.Text = _Total_A_Pagar;
                //
                if (bllVenda._Parcela_Plano != null)
                {
                    txtParcela.Text = bllVenda._Parcela_Plano;
                }
                else
                {
                    txtParcela.Text = "1";
                }
                //
                if (bllVenda._Entrada_Plano != null)
                {
                    txtEntradaPorc.Text = bllVenda._Entrada_Plano;
                }
                else
                {
                    txtEntradaPorc.Text = "0,00";
                }
                //
                if (bllVenda._Multa_Plano != null)
                {
                    txtJurosPorc.Text = bllVenda._Multa_Plano;
                }
                else
                {
                    txtJurosPorc.Text = "2,00";
                }
                //
                if (bllVenda._Juros_Mora_Plano != null)
                {
                    txtJurosAtrasoPorc.Text = bllVenda._Juros_Mora_Plano;
                }
                else
                {
                    txtJurosAtrasoPorc.Text = "1,00";
                }
                //
                lblResultado1.Text = bllFormaPagamento.Simular_Forma_Pagamento_Resumida(txtParcela.Text.Trim(), txtEntradaPorc.Text.Trim(), lblTotalSub.Text, "0", "0");
                //
                txtParcela.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPlanoNotaPromissoria.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPlanoNotaPromissoria.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtParcela_Leave(object sender, EventArgs e)
        {
            if (txtParcela.Text == "0" || txtParcela.Text == "0,00" || txtParcela.Text == "")
            {
                txtParcela.Text = "1";
            }
            //
            if (txtEntradaPorc.Text == "")
            {
                txtEntradaPorc.Text = "0,00";
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
            if (txtParcela.Text != "")
            {
                if (txtParcela.Text.Contains("'") || txtParcela.Text.Contains(";") || txtParcela.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtParcela.Text = null;
                    txtParcela.Select();
                }
                //
                lblResultado1.Text = bllFormaPagamento.Simular_Forma_Pagamento_Resumida(txtParcela.Text.Trim(), txtEntradaPorc.Text.Trim(), lblTotalSub.Text, "0", "0");
            }
            txtParcela.BackColor = Color.White;
        }

        private void txtEntradaPorc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtParcela.Text == "0" || txtParcela.Text == "0,00" || txtParcela.Text == "")
                {
                    txtParcela.Text = "1";
                }
                //
                if (txtEntradaPorc.Text == "")
                {
                    txtEntradaPorc.Text = "0,00";
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
                if (txtEntradaPorc.Text != "")
                {
                    if (txtEntradaPorc.Text.Contains("'") || txtEntradaPorc.Text.Contains(";") || txtEntradaPorc.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        txtEntradaPorc.Text = null;
                        txtEntradaPorc.Select();
                    }
                    else if (Convert.ToDecimal(txtEntradaPorc.Text) > 100)
                    {
                        MessageBox.Show("Valor informado é inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEntradaPorc.Text = "0,00";
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        txtEntradaPorc.Text = Convert.ToDecimal(txtEntradaPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        //
                        lblResultado1.Text = bllFormaPagamento.Simular_Forma_Pagamento_Resumida(txtParcela.Text.Trim(), txtEntradaPorc.Text.Trim(), lblTotalSub.Text, "0", "0");

                    }
                }
                //
                lblValorPagar.Text = bllVenda.Calculo_Valor_Entrada_Porc_PDV(lblTotalSub.Text.Replace("R$ ", ""), txtEntradaPorc.Text);
                //
                txtEntradaPorc.BackColor = Color.White;
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
                txtEntradaPorc.BackColor = Color.White;
            }
        }

        private void txtEntradaPorc_Enter(object sender, EventArgs e)
        {
            txtEntradaPorc.BackColor = Color.LightBlue;
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
                txtJurosPorc.Select();
            }
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

        private void txtJurosPorc_Leave(object sender, EventArgs e)
        {
            if (txtParcela.Text == "0" || txtParcela.Text == "0,00" || txtParcela.Text == "")
            {
                txtParcela.Text = "1";
            }
            //
            if (txtEntradaPorc.Text == "")
            {
                txtEntradaPorc.Text = "0,00";
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
            if (txtJurosPorc.Text != "")
            {
                if (txtJurosPorc.Text.Contains("'") || txtJurosPorc.Text.Contains(";") || txtJurosPorc.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtJurosPorc.Text = null;
                    txtJurosPorc.Select();
                }
                else if (Convert.ToDecimal(txtJurosPorc.Text) > 100)
                {
                    MessageBox.Show("Valor informado é inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtJurosPorc.Text = "0,00";
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    try
                    {
                        txtJurosPorc.Text = Convert.ToDecimal(txtJurosPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        lblResultado1.Text = bllFormaPagamento.Simular_Forma_Pagamento_Resumida(txtParcela.Text.Trim(), txtEntradaPorc.Text.Trim(), lblTotalSub.Text, "0", "0");
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

        private void txtJurosPorc_Enter(object sender, EventArgs e)
        {
            txtJurosPorc.BackColor = Color.LightBlue;
        }

        private void txtJurosAtrasoPorc_Leave(object sender, EventArgs e)
        {
            if (txtParcela.Text == "0" || txtParcela.Text == "0,00" || txtParcela.Text == "")
            {
                txtParcela.Text = "1";
            }
            //
            if (txtEntradaPorc.Text == "")
            {
                txtEntradaPorc.Text = "0,00";
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
            if (txtJurosAtrasoPorc.Text != "")
            {
                if (txtJurosAtrasoPorc.Text.Contains("'") || txtJurosAtrasoPorc.Text.Contains(";") || txtJurosAtrasoPorc.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtJurosAtrasoPorc.Text = null;
                    txtJurosAtrasoPorc.Select();
                }
                else if (Convert.ToDecimal(txtJurosAtrasoPorc.Text) > 100)
                {
                    MessageBox.Show("Valor informado é inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtJurosAtrasoPorc.Text = "0,00";
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    try
                    {
                        txtJurosAtrasoPorc.Text = Convert.ToDecimal(txtJurosAtrasoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        lblResultado1.Text = bllFormaPagamento.Simular_Forma_Pagamento_Resumida(txtParcela.Text.Trim(), txtEntradaPorc.Text.Trim(), lblTotalSub.Text, "0", "0");
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
            //
            txtJurosAtrasoPorc.BackColor = Color.White;
        }

        private void txtJurosAtrasoPorc_Enter(object sender, EventArgs e)
        {
            txtJurosAtrasoPorc.BackColor = Color.LightBlue;
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
                btnSalvar.Select();
            }
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

        private void txtParcela_Enter(object sender, EventArgs e)
        {
            txtParcela.BackColor = Color.LightBlue;
        }

        private void lblTotalSub_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblTotalSub_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorPagar_MouseLeave(object sender, EventArgs e)
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void FrmPlanoNotaPromissoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPlanoNotaPromissoria foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPlanoNotaPromissoria foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPlanoNotaPromissoria.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPlanoNotaPromissoria.");
                }
            }
        }

        private void FrmPlanoNotaPromissoria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void lblResultado1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblResultado1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotalSub_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblTotalSub.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorPagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entrada a Pagar (R$): " + lblValorPagar.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }
        
        private void lblResultado1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simulação: " + lblResultado1.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (txtParcela.Text.Trim() == "" || txtEntradaPorc.Text == "" || txtJurosAtrasoPorc.Text == "" || txtJurosPorc.Text == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\rCampos: [ Parcela ], [ Entrada ], [ Multa ] e [ Juros Mora ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtParcela.Select();
                    }
                    else
                    {
                        string codigo;
                        //
                        if (bllFormaPagamento.Sel_Plano_Nota_Prom_Existe(txtParcela.Text, txtEntradaPorc.Text, txtJurosPorc.Text, txtJurosAtrasoPorc.Text) == null)
                        {
                            string descentrada;
                            //
                            if (txtEntradaPorc.Text == "" || Convert.ToDecimal(txtEntradaPorc.Text) == 0)
                            {
                                descentrada = "S/ENTRADA";
                            }
                            else
                            {
                                descentrada = "C/ENTRADA DE " + txtEntradaPorc.Text;
                            }
                            //
                            bllFormaPagamento.Salvar(txtParcela.Text + " PARCELA(S) " + descentrada, txtJurosPorc.Text.Trim(), txtEntradaPorc.Text.Trim(), txtParcela.Text.Trim(), "30", "NOTA PROMISSORIA", txtJurosAtrasoPorc.Text.Trim(), "0", "0", "", "ENTRADA", "0", "0");
                            //
                            codigo = bllFormaPagamento.Sel_Ultima_Forma_Pagamento();
                            //
                            bllRegistroAtividades.Salvar("SALVOU UMA FORMA DE PAGAMENTO", "FORMAS DE PAGAMENTO", codigo, _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Forma cadstrada. Cod: " + codigo + " | Descrição: PLANO DEFINIDO PELO USUÁRIO");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Forma cadstrada. Cod: " + codigo + " | Descrição: PLANO DEFINIDO PELO USUÁRIO");
                            }
                        }
                        else
                        {
                            DataRow dr = bllFormaPagamento.Sel_Plano_Nota_Prom_Existe(txtParcela.Text, txtEntradaPorc.Text, txtJurosPorc.Text, txtJurosAtrasoPorc.Text).Rows[0];
                            //
                            codigo = dr["id_pagamento"].ToString();
                        }
                        //
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        //
                        bllVenda._Cod_Nota_Promissoria_Plano = codigo;
                        bllVenda._Entrada_Plano = txtEntradaPorc.Text;
                        bllVenda._Parcela_Plano = txtParcela.Text;
                        bllVenda._Multa_Plano = txtJurosPorc.Text;
                        bllVenda._Juros_Mora_Plano = txtJurosAtrasoPorc.Text;
                        //
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    txtParcela.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                txtParcela.Text = "1";
                txtEntradaPorc.Text = "0,00";
                txtJurosPorc.Text = "0,00";
                txtJurosAtrasoPorc.Text = "0,00";
            }
        }
    }
}
