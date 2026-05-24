using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using BLL;
using System.IO;
using System.Threading;

namespace SIE_7_Sistema
{
    public partial class FrmBaixaTituloContasPagar : Form
    {
        private static string _Codigo;

        private string _Juros_Am;
        private string _Multa_Fixa;
        private string _Desconto_Fixo;

        public FrmBaixaTituloContasPagar(string desconto, string valor_desconto, string multa, string valor_multa, string juros_am, string data_emissao, string data_vencimento, string valor_conta, string codigo, string data_desconto, string n_documento, string parcela)
        {
            InitializeComponent();
            lblValorDataEmissao.Text = data_emissao;
            lblValorDataVencimento.Text = data_vencimento;
            lblValorDataDesconto.Text = data_desconto;
            lblValorTitulo.Text = Convert.ToDecimal(valor_conta).ToString("n2", new CultureInfo("pt-BR"));
            lblDescontoValor.Text = "Desconto de: " + desconto + "%.";
            lblMultaValor.Text = "Multa de: " + multa + "%.";
            lblMoraValor.Text = "Juros (a.m) de: " + juros_am + "%.";
            lblValorMora.Text = "0,00";
            lblValorDesconto.Text = "0,00";
            lblValorMulta.Text = "0,00";
            _Juros_Am = juros_am;
            _Multa_Fixa = multa;
            _Desconto_Fixo = desconto;
            lblNdocumento.Text = n_documento;
            lblValorParcela.Text = parcela;
            _Codigo = codigo;
        }

        private void FrmBaixaTituloContasPagar_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmBaixaTituloContasPagar iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmBaixaTituloContasPagar iniciado.");
                }
                //               
                if (bllContasPagar.Sel_Forma_Pagamento_Cont() == null)
                {
                    cbbTipoPagamento.Text = null;                    
                }
                else
                {
                    foreach (DataRow dr in bllContasPagar.Sel_Forma_Pagamento_Cont().Rows)
                    {
                        cbbTipoPagamento.Items.Add(dr["id_pagamento"].ToString() + "-" + dr["descricao"].ToString());
                    }                    
                }
                //
                mtxtDataRecebimento.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmBaixaTituloContasPagar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmBaixaTituloContasPagar.");
                }
                this.DialogResult = DialogResult.Ignore;
            }
        }
           

        private void mtxtDataRecebimento_Enter(object sender, EventArgs e)
        {
            mtxtDataRecebimento.BackColor = Color.LightBlue;
        }

        private void mtxtDataRecebimento_Leave(object sender, EventArgs e)
        {
            mtxtDataRecebimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataRecebimento.Text == "")
            {
                mtxtDataRecebimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;                
            }           
            else
            {
                try
                {
                    mtxtDataRecebimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    if (Convert.ToDateTime(mtxtDataRecebimento.Text) < Convert.ToDateTime(lblValorDataEmissao.Text))
                    {
                        MessageBox.Show("Data de recebimento é menor que a data de emissão da conta.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataRecebimento.Text = null;
                        txtValorPago.Text = null;
                        lblValorDesconto.Text = null;
                        lblValorMora.Text = null;
                        lblValorMulta.Text = null;
                        lblValorTotalDocumento.Text = null;
                        txtValorPago.Text = null;
                    }
                    else
                    {
                        ValidarData.Ver_Data(mtxtDataRecebimento.Text);
                        //
                        lblValorDesconto.Text = Convert.ToDecimal(bllContasPagar.Calculo_Desconto_Fixo(_Desconto_Fixo, lblValorTitulo.Text, lblValorDataVencimento.Text, mtxtDataRecebimento.Text, lblValorDataDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        lblValorMulta.Text = Convert.ToDecimal(bllContasPagar.Calculo_Multa_Fixa(_Multa_Fixa, lblValorTitulo.Text, lblValorDataVencimento.Text, mtxtDataRecebimento.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        lblValorMora.Text = Convert.ToDecimal(bllContasPagar.Calculo_Juros_Am(_Juros_Am, lblValorTitulo.Text, lblValorDataVencimento.Text, mtxtDataRecebimento.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        lblValorTotalDocumento.Text = Convert.ToDecimal(bllContasPagar.Valor_A_Pagar_Atualizado(lblValorMulta.Text, lblValorDesconto.Text, lblValorMora.Text, lblValorTitulo.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        if (Convert.ToDateTime(mtxtDataRecebimento.Text) > Convert.ToDateTime(lblValorDataVencimento.Text))
                        {
                            lblDiasDeAtraso.Visible = true;
                            lblDiasDeAtraso.Text = "Total de dias de atraso: " + (Convert.ToDateTime(mtxtDataRecebimento.Text) - Convert.ToDateTime(lblValorDataVencimento.Text)).TotalDays.ToString();
                        }
                        else
                        {
                            lblDiasDeAtraso.Visible = false;
                            lblDiasDeAtraso.Text = null;
                        }
                        //
                        txtValorPago.Text = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataRecebimento.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataRecebimento.");
                    }
                    mtxtDataRecebimento.Text = null;
                    txtValorPago.Text = null;
                    lblValorDesconto.Text = null;
                    lblValorMora.Text = null;
                    lblValorMulta.Text = null;
                    lblValorTotalDocumento.Text = null;
                    txtValorPago.Text = null;
                }
            }
            //
            mtxtDataRecebimento.BackColor = Color.White;
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

        private void btnConfirmar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConfirmar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtDataRecebimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipoPagamento.Select();
            }
        }

        private void cbbTipoPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                txtValorPago.Select();
            }
        }

        private void mtxtDataRecebimento_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataRecebimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataRecebimento.Text == "")
            {
                mtxtDataRecebimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataRecebimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else 
            {
                mtxtDataRecebimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }        

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            mtxtDataRecebimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataRecebimento.Text == "" || cbbTipoPagamento.Text == "" || txtValorPago.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n< Data de pagamento >, < Forma de pagamento > e < Valor Pago >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                mtxtDataRecebimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            else
            {
                mtxtDataRecebimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                if (Convert.ToDecimal(lblValorTotalDocumento.Text) > Convert.ToDecimal(txtValorPago.Text))
                {
                    MessageBox.Show("O valor pago é menor que o valor total da conta.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtValorPago.Select();
                }
                else if (Convert.ToDecimal(lblValorTotalDocumento.Text) < Convert.ToDecimal(txtValorPago.Text))
                {
                    MessageBox.Show("O valor pago é maior que o valor total da conta.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtValorPago.Select();
                }
                else
                {
                    try
                    {
                        bllContasPagar.Baixa_Pagamento(_Codigo, txtValorPago.Text.Trim(), mtxtDataRecebimento.Text, cbbTipoPagamento.Text, lblValorTotalDocumento.Text);
                        //
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        bllContasPagar._FrmContasPagarMostrar = false;
                        /*
                        DialogResult = MessageBox.Show("Deseja selecionar no seu computador, digitalizar ou tirar uma foto do um comprovante de pagamento?", "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            using (FrmComprovantePagamento Comp = new FrmComprovantePagamento(_Codigo))
                            {
                                if (Comp.ShowDialog() == DialogResult.Abort)
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                        }
                        */
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        //
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                        }
                        mtxtDataRecebimento.Text = null;
                        cbbTipoPagamento.Text = null;
                        txtValorPago.Text = null;
                        lblValorDesconto.Text = null;
                        lblValorMulta.Text = null;
                        lblValorMora.Text = null;
                    }
                }                
            }                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
        }

        private void FrmBaixaTituloContasPagar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.DialogResult = DialogResult.Ignore;
            }
        }

        private void pcibInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Informe os campos na sequencia." + Environment.NewLine + "1 - Data de pagamento: Onde você vai informar a data em que a conta foi paga.\n\n2 - Tipo de pagamento: São as formas de pagamento disponíveis no sistema para quitar esta conta.\n\n3 - Valor pago: Onde você informa o valor que foi pago nesta conta.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void pcibInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoPagamento_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoPagamento_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtValorPago_Enter(object sender, EventArgs e)
        {
            txtValorPago.BackColor = Color.LightBlue;
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorPago.Text.Contains(",") && e.KeyChar == (char)44)
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

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            if (txtValorPago.Text != "")
            {
                if (txtValorPago.Text.Contains("'") || txtValorPago.Text.Contains(";") || txtValorPago.Text.Contains("=") || txtValorPago.Text.Contains("-"))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorPago.Text = null;
                }
                else
                {
                    try
                    {
                        txtValorPago.Text = Convert.ToDecimal(txtValorPago.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorPago.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorPago.");
                        }
                        txtValorPago.Text = null;
                    }
                }
            }
            txtValorPago.BackColor = Color.White;
        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            if (lblValorTotalDocumento.Text.Trim() != "" & txtValorPago.Text.Trim() != "")
            {
                if (Convert.ToDecimal(lblValorTotalDocumento.Text) > (Convert.ToDecimal(txtValorPago.Text)))
                {
                    txtValorPago.ForeColor = Color.Red;
                }
                else if (Convert.ToDecimal(lblValorTotalDocumento.Text) < (Convert.ToDecimal(txtValorPago.Text)))
                {
                    txtValorPago.ForeColor = Color.Blue;
                }
                else
                {
                    txtValorPago.ForeColor = Color.Black;
                }
            }
        }

        private void FrmBaixaTituloContasPagar_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmBaixaTituloContas foi finalizado.");
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmBaixaTituloContas foi finalizado.");
            }            
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
            this.Close();
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
        }

        private void cbbTipoPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValorPago.Text = null;
        }

        private void btnMora_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Atenção, o aplicativo 7 Sistema se propõe a auxiliar o usuário como simples referência e verificação de cálculos diversos. Este serviço não deve ser utilizado em substituição a um profissional habilitado. O usuário que utiliza este serviço o faz por sua conta e risco, e aceita que o aplicativo não tem qualquer responsabilidade por danos de qualquer natureza resultantes desta utilização. Dúvidas entrar em contato com o suporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnMora_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnMora_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAdicObservacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAdicObservacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAdicObservacao_Click(object sender, EventArgs e)
        {
            using (FrmTroco Obs = new FrmTroco(_Codigo))
            {
                if (Obs.ShowDialog() == DialogResult.Abort)
                {
                    btnAdicObservacao.Select();
                }
            }
        }

        private void btnSelecionarData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            using (FrmDatePicker Data = new FrmDatePicker(1))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataRecebimento.Text = bllContasPagar._Data_DatePicker1;
                    bllContasPagar._Data_DatePicker1 = null;
                    mtxtDataRecebimento.Select();
                }
            }
        }

        private void btnProcurarForma_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarForma_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarForma_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmPesqFormaPagamento Forma = new FrmPesqFormaPagamento(0))
                {
                    if (Forma.ShowDialog() == DialogResult.OK)
                    {
                        cbbTipoPagamento.Items.Clear();
                        if (bllContasPagar.Sel_Forma_Pagamento_Cont() == null)
                        {
                            cbbTipoPagamento.Text = null;
                        }
                        else
                        {
                            foreach (DataRow dr in bllContasPagar.Sel_Forma_Pagamento_Cont().Rows)
                            {
                                cbbTipoPagamento.Items.Add((dr["id_pagamento"].ToString()) + "-" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbTipoPagamento.Text = bllContasPagar._Forma_Pag_PesqFormaPag_Tabela;
                        bllContasPagar._Forma_Pag_PesqFormaPag_Tabela = null;
                        cbbTipoPagamento.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar2.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar2.");
                }
                cbbTipoPagamento.Text = null;
                bllContasPagar._Forma_Pag_PesqFormaPag_Tabela = null;
            }
        }

        private void txtValorPago_DoubleClick(object sender, EventArgs e)
        {
            if (txtValorPago.Text.Trim() == "")
            {
                txtValorPago.Text = lblValorTotalDocumento.Text;
            }
        }

        private void btnRenegociada_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRenegociada_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRenegociada_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja confirmar que esta conta foi renegociada? Ao clicar em < Sim > a situação desta conta se tornará < Renegociada > o cadastro de Contas a Pagar será aberto para inserir a nova Conta a Pagar renegociaçada." + Environment.NewLine + Environment.NewLine + "Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bllContasPagar._FrmContasPagarMostrar = true;
                bllContasPagar.Renegociar_Conta(_Codigo);
                //
                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }                
        }
    }
}
