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
    public partial class FrmRelBaixaConta : Form
    {
        public FrmRelBaixaConta(string usuario, string codigo, string descricao, string data_emissao, string data_vencimento, string parcela, string data_desconto, string desconto_porc, string multa_porc, string juros_am_porc, string valor_desconto, string valor_multa, string valor_documento, string valor_total_pago, string cod_pdv_computador, string n_documento, byte formulario, byte baixa_apos_vencimento, string cod_cliente)
        {
            InitializeComponent();
            lblValorCodigo.Text = codigo;
            lblValorDataEmissao.Text = data_emissao.Remove(10);
            lblValorDataVencimento.Text = data_vencimento.Remove(10);
            lblValorParcela.Text = parcela;
            if (n_documento != "0" & n_documento != "")
            {
                lblNDocumento.Text = n_documento;
            }
            lblValorDocumento.Text = valor_documento;
            //
            if (data_desconto != "")
            {
                lblValorDataDesconto.Text = data_desconto.Remove(10);
            }
            else
            {
                lblValorDataDesconto.Text = "";
            }
            //
            _Usuario = usuario;
            _Desconto_Porc = desconto_porc;
            _Multa_Porc = multa_porc;
            _Valor_Desconto = valor_desconto;
            _Valor_Multa = valor_multa;
            _Juros_AM_Porc = juros_am_porc;
            _Valor_Total_Pago = valor_total_pago;
            _Descricao = descricao;
            if (Convert.ToDecimal(valor_total_pago) > 0)
            {
                _Pagamento_Parcial_Anterior = true;
            }
            else
            {
                _Pagamento_Parcial_Anterior = false;
            }
            _Cod_PDV_Computador = cod_pdv_computador;
            //
            if (baixa_apos_vencimento == 1)
            {
                _Baixa_Apos_Vencimento = true;
            }
            else
            {
                _Baixa_Apos_Vencimento = false;
            }
            //
            _Cod_Cliente = cod_cliente;
            _Formulario = formulario;
        }

        private string _Usuario;
        private string _Descricao;
        private string _Desconto_Porc;
        private string _Multa_Porc;
        private string _Valor_Desconto;
        private string _Valor_Multa;
        private string _Juros_AM_Porc;
        private string _Valor_Total_Pago;
        private bool _Pagamento_Parcial_Anterior;
        private string _Cod_PDV_Computador;
        private byte _Formulario;
        private bool _Baixa_Apos_Vencimento;
        private string _Cod_Cliente;

        private void FrmOpeFormBaixaContaPagar_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelBaixaConta iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelBaixaConta iniciado.");
                }
                //
                cbbFormaPagamento.Items.Clear();
                if (_Formulario == 0)
                {
                    if (bllContasReceber.Sel_Forma_Pagamento_Conta_Receber() == null)
                    {
                        cbbFormaPagamento.Text = null;
                    }
                    else
                    {
                        cbbFormaPagamento.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_Forma_Pagamento_Conta_Receber().Rows)
                        {
                            cbbFormaPagamento.Items.Add((dr["id_pagamento"].ToString()) + "—" + (dr["tipo"].ToString()));
                        }
                    }
                    //
                    lbldocumento.Text = "Nº da Promissória:";
                    chkbIgnorarMulta.Visible = true;
                    chkbIgnorarJurosAM.Visible = true;
                    grbBox1.Text = "Informações da Conta a Receber:";
                    chkbIgnorarJurosAM.Visible = true;
                    chkbIgnorarMulta.Visible = true;
                }
                else if (_Formulario == 1)
                {
                    if (bllContasPagar.Sel_Forma_Pagamento_Conta_Pagar() == null)
                    {
                        cbbFormaPagamento.Text = null;
                    }
                    else
                    {
                        cbbFormaPagamento.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Forma_Pagamento_Conta_Pagar().Rows)
                        {
                            cbbFormaPagamento.Items.Add((dr["id_pagamento"].ToString()) + "—" + (dr["tipo"].ToString()));
                        }
                    }
                    //
                    lbldocumento.Text = "Nº do Documento:";
                    chkbIgnorarMulta.Visible = false;
                    chkbIgnorarJurosAM.Visible = false;
                    grbBox1.Text = "Informações da Conta a Pagar:";
                    chkbIgnorarJurosAM.Visible = false;
                    chkbIgnorarMulta.Visible = false;
                }
                //
                mtxtDataPagamento.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelBaixaConta.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelBaixaConta.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void lblValorCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDataEmissao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDataEmissao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDocumento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDataVencimento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDataVencimento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDataDesconto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDataDesconto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDesconto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDesconto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorMulta_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorMulta_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorJurosAm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorJurosAm_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorParcialPago_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorParcialPago_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorRealDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorRealDocumento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvarPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvarPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalPago_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalPago_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDiferencaTroco_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDiferencaTroco_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluirReg_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirReg_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFormaPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFormaPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFormaPagamento_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFormaPagamento_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarForma_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarForma_MouseLeave(object sender, EventArgs e)
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

        private void pcibInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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
            if (_Formulario == 0)
            {
                using (FrmDatePicker Data = new FrmDatePicker(1))
                {
                    if (Data.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.None;
                        mtxtDataPagamento.Text = bllContasReceber._Data_DatePicker1;
                        bllContasReceber._Data_DatePicker1 = null;
                        mtxtDataPagamento.Select();
                    }
                }
            }
            else if (_Formulario == 1)
            {
                using (FrmDatePicker Data = new FrmDatePicker(0))
                {
                    if (Data.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.None;
                        mtxtDataPagamento.Text = bllContasPagar._Data_DatePicker1;
                        bllContasPagar._Data_DatePicker1 = null;
                        mtxtDataPagamento.Select();
                    }
                }
            }
        }

        private void mtxtDataPagamento_Enter(object sender, EventArgs e)
        {
            mtxtDataPagamento.BackColor = Color.LightBlue;
        }

        private void mtxtDataPagamento_Leave(object sender, EventArgs e)
        {
            mtxtDataPagamento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataPagamento.Text != "")
            {
                try
                {
                    mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    ValidarData.Ver_Data(mtxtDataPagamento.Text);
                    //
                    if (Convert.ToDateTime(mtxtDataPagamento.Text) < Convert.ToDateTime(lblValorDataEmissao.Text))
                    {
                        MessageBox.Show("A Data de Pagamento informada é menor que a Data de Emissão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataPagamento.Text = null;
                        mtxtDataPagamento.Select();
                    }
                    else
                    {
                        if (_Formulario == 0)
                        {
                            bllContasReceber.Excluir_Item_Conta_Receber_Pgto_Atual(bllConexao._Codigo_Conexao);
                        }
                        else if (_Formulario == 1)
                        {
                            bllContasPagar.Excluir_Item_Conta_Pagar_Pgto_Atual();
                        }
                        //
                        dtFormaPagamento.DataSource = null;
                        //
                        chkbIgnorarJurosAM.Checked = false;
                        chkbIgnorarMulta.Checked = false;
                        //
                        if (Convert.ToDateTime(mtxtDataPagamento.Text) > Convert.ToDateTime(lblValorDataVencimento.Text))
                        {
                            lblDiasDeAtraso.Visible = true;
                            lblDiasDeAtraso.Text = "Total de dias de atraso: " + (Convert.ToDateTime(mtxtDataPagamento.Text) - Convert.ToDateTime(lblValorDataVencimento.Text)).TotalDays.ToString();
                            if (_Baixa_Apos_Vencimento == true)
                            {
                                chkbIgnorarJurosAM.Enabled = false;
                                chkbIgnorarMulta.Enabled = false;
                            }
                            else
                            {
                                if (bllUsuario.Sel_Permitir_Ignorar_Multa_Juros_Receber(_Usuario) == true)
                                {
                                    chkbIgnorarJurosAM.Enabled = true;
                                    chkbIgnorarMulta.Enabled = true;
                                }
                                else
                                {
                                    chkbIgnorarJurosAM.Enabled = false;
                                    chkbIgnorarMulta.Enabled = false;
                                }
                            }
                            lblMultaPorcValor.Text = "Multa de: " + _Multa_Porc + "%.";
                            lblValorMulta.Text = _Valor_Multa;
                            lblJurosAMPorcValor.Text = "Juros (a.m) de: " + _Juros_AM_Porc + "%.";
                            lblValorParcialPago.Text = _Valor_Total_Pago;
                            lblValorDesconto.Text = "0,00";
                            lblDescontoPorcValor.Text = "Desconto de: 0,00%.";
                        }
                        else
                        {
                            lblDiasDeAtraso.Visible = false;
                            lblDiasDeAtraso.Text = null;
                            chkbIgnorarJurosAM.Enabled = false;
                            chkbIgnorarMulta.Enabled = false;
                            lblMultaPorcValor.Text = "Multa de: 0,00%.";
                            lblValorMulta.Text = "0,00";
                            lblJurosAMPorcValor.Text = "Juros (a.m) de: 0,00%.";
                            lblValorParcialPago.Text = _Valor_Total_Pago;
                            //
                            if (lblValorDataDesconto.Text == "")
                            {
                                if (Convert.ToDateTime(mtxtDataPagamento.Text) <= Convert.ToDateTime(lblValorDataVencimento.Text))
                                {
                                    lblValorDesconto.Text = _Valor_Desconto;
                                    lblDescontoPorcValor.Text = "Desconto de: " + _Desconto_Porc + "%.";
                                }
                                else
                                {
                                    lblValorDesconto.Text = "0,00";
                                    lblDescontoPorcValor.Text = "Desconto de: 0,00%.";
                                }
                            }
                            else
                            {
                                if (Convert.ToDateTime(mtxtDataPagamento.Text) <= Convert.ToDateTime(lblValorDataDesconto.Text))
                                {
                                    lblValorDesconto.Text = _Valor_Desconto;
                                    lblDescontoPorcValor.Text = "Desconto de: " + _Desconto_Porc + "%.";

                                }
                                else
                                {
                                    lblValorDesconto.Text = "0,00";
                                    lblDescontoPorcValor.Text = "Desconto de: 0,00%.";
                                }
                            }
                        }
                        //
                        lblAntesVencimento.Enabled = true;
                        lblDesconto.Enabled = true;
                        lblValorDesconto.Enabled = true;
                        lblDescontoPorcValor.Enabled = true;
                        lblAposVencimento.Enabled = true;
                        lblDiasDeAtraso.Enabled = true;
                        lblMulta.Enabled = true;
                        lblValorMulta.Enabled = true;
                        lblMultaPorcValor.Enabled = true;
                        lblJurosAm.Enabled = true;
                        lblValorJurosAm.Enabled = true;
                        lblJurosAMPorcValor.Enabled = true;
                        lblValor.Enabled = true;
                        lblValorReal.Enabled = true;
                        lblValorRealDocumento.Enabled = true;
                        lblValorParcialPago.Enabled = true;
                        lblParcialPago.Enabled = true;
                        lblValorParcialPago.Enabled = true;
                        lblParcialPago.Enabled = true;
                        lblFormaPagamento.Enabled = true;
                        lblAsterisco2.Enabled = true;
                        cbbFormaPagamento.Enabled = true;
                        btnProcurarForma.Enabled = true;
                        lblValorPago.Enabled = true;
                        lblAsterisco3.Enabled = true;
                        txtValorPagamento.Enabled = true;
                        btnSalvarPagamento.Enabled = true;
                        lblListaFormasPagamento.Enabled = true;
                        //
                        if (_Formulario == 0)
                        {
                            lblValorJurosAm.Text = Convert.ToDecimal(bllContasReceber.Calculo_Juros_Am(_Juros_AM_Porc, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            lblValorRealDocumento.Text = Convert.ToDecimal(bllContasReceber.Calculo_Valor_Real(lblValorJurosAm.Text, lblValorDesconto.Text, lblValorMulta.Text, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text, _Pagamento_Parcial_Anterior)).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else if (_Formulario == 1)
                        {
                            lblValorJurosAm.Text = Convert.ToDecimal(bllContasPagar.Calculo_Juros_Am(_Juros_AM_Porc, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            lblValorRealDocumento.Text = Convert.ToDecimal(bllContasPagar.Calculo_Valor_Real(lblValorJurosAm.Text, lblValorDesconto.Text, lblValorMulta.Text, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        //
                        lblValorDiferencaTroco.Text = "-" + lblValorRealDocumento.Text;
                        lblValorTotalPago.Text = "0,00";
                        btnSalvarPagamento.Enabled = true;
                        dtFormaPagamento.Enabled = true;
                        lblTotalPago.Enabled = true;
                        lblValorTotalPago.Enabled = true;
                        lblDiferencaTroco.Enabled = true;
                        lblValorDiferencaTroco.Enabled = true;
                        //
                        if (_Pagamento_Parcial_Anterior == true)
                        {
                            DataRow dr;
                            //
                            if (_Formulario == 0)
                            {
                                for (int i = 0; i < bllContasReceber.Sel_Pagamento_Conta_Receber_Todas(lblValorCodigo.Text).Rows.Count; i++)
                                {
                                    dr = bllContasReceber.Sel_Pagamento_Conta_Receber_Todas(lblValorCodigo.Text).Rows[i];
                                    //
                                    bllContasReceber.Salvar_Forma_Pagamento_Conta_Receber(dr["id_item_pagamento"].ToString(), dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString(), dr["valor_pago"].ToString(), 1, bllConexao._Codigo_Conexao);
                                }
                                //
                                dtFormaPagamento.DataSource = bllContasReceber.Sel_Item_Conta_Receber_Pgto_Todas(bllConexao._Codigo_Conexao);
                            }
                            else if (_Formulario == 1)
                            {
                                for (int i = 0; i < bllContasPagar.Sel_Pagamento_Conta_Pagar_Todas(lblValorCodigo.Text).Rows.Count; i++)
                                {
                                    dr = bllContasPagar.Sel_Pagamento_Conta_Pagar_Todas(lblValorCodigo.Text).Rows[i];
                                    //
                                    bllContasPagar.Salvar_Forma_Pagamento(dr["id_item_pagamento"].ToString(), dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString(), dr["valor_pago"].ToString(), 1, bllConexao._Codigo_Conexao);
                                }
                                //
                                dtFormaPagamento.DataSource = bllContasPagar.Sel_Item_Conta_Pagar_Pgto_Todas();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataPagamento.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataPagamento.");
                    }
                    //
                    if (_Formulario == 0)
                    {
                        bllContasReceber.Excluir_Item_Conta_Receber_Pgto_Atual(bllConexao._Codigo_Conexao);
                    }
                    else
                    {
                        bllContasPagar.Excluir_Item_Conta_Pagar_Pgto_Atual();
                    }
                    //
                    mtxtDataPagamento.Text = null;
                    lblAntesVencimento.Enabled = false;
                    lblDesconto.Enabled = false;
                    lblValorDesconto.Enabled = false;
                    lblDescontoPorcValor.Enabled = false;
                    lblAposVencimento.Enabled = false;
                    lblDiasDeAtraso.Enabled = false;
                    lblMulta.Enabled = false;
                    lblValorMulta.Enabled = false;
                    lblMultaPorcValor.Enabled = false;
                    lblJurosAm.Enabled = false;
                    lblValorJurosAm.Enabled = false;
                    lblJurosAMPorcValor.Enabled = false;
                    lblValor.Enabled = false;
                    lblValorReal.Enabled = false;
                    lblValorParcialPago.Enabled = false;
                    lblParcialPago.Enabled = false;
                    lblValorRealDocumento.Enabled = false;
                    lblFormaPagamento.Enabled = false;
                    lblAsterisco2.Enabled = false;
                    cbbFormaPagamento.Enabled = false;
                    btnProcurarForma.Enabled = false;
                    lblValorPago.Enabled = false;
                    lblAsterisco3.Enabled = false;
                    txtValorPagamento.Enabled = false;
                    btnSalvarPagamento.Enabled = false;
                    lblListaFormasPagamento.Enabled = false;
                    chkbIgnorarJurosAM.Enabled = false;
                    chkbIgnorarMulta.Enabled = false;
                    //
                    lblDescontoPorcValor.Text = "Desconto de: 0,00%.";
                    lblMultaPorcValor.Text = "Multa de: 0,00%.";
                    lblValorDesconto.Text = null;
                    lblValorMulta.Text = null;
                    lblJurosAMPorcValor.Text = "Juros (a.m) de: 0,00%.";
                    lblValorJurosAm.Text = null;
                    lblValorRealDocumento.Text = null;
                    lblValorParcialPago.Text = null;
                    dtFormaPagamento.DataSource = null;
                    cbbFormaPagamento.Text = null;
                    txtValorPagamento.Text = null;
                    lblValorDiferencaTroco.Text = "0,00";
                    lblValorTotalPago.Text = "0,00";
                    //
                    btnSalvarPagamento.Enabled = false;
                    dtFormaPagamento.Enabled = false;
                    lblTotalPago.Enabled = false;
                    lblValorTotalPago.Enabled = false;
                    lblDiferencaTroco.Enabled = false;
                    lblValorDiferencaTroco.Enabled = false;
                }
            }
            else
            {
                if (_Formulario == 0)
                {
                    bllContasReceber.Excluir_Item_Conta_Receber_Pgto_Atual(bllConexao._Codigo_Conexao);
                }
                else
                {
                    bllContasPagar.Excluir_Item_Conta_Pagar_Pgto_Atual();
                }
                //
                mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                lblAntesVencimento.Enabled = false;
                lblDesconto.Enabled = false;
                lblValorDesconto.Enabled = false;
                lblDescontoPorcValor.Enabled = false;
                lblAposVencimento.Enabled = false;
                lblDiasDeAtraso.Enabled = false;
                lblMulta.Enabled = false;
                lblValorMulta.Enabled = false;
                lblMultaPorcValor.Enabled = false;
                lblJurosAm.Enabled = false;
                lblValorJurosAm.Enabled = false;
                lblJurosAMPorcValor.Enabled = false;
                lblValor.Enabled = false;
                lblValorReal.Enabled = false;
                lblValorParcialPago.Enabled = false;
                lblParcialPago.Enabled = false;
                lblValorRealDocumento.Enabled = false;
                lblFormaPagamento.Enabled = false;
                lblAsterisco2.Enabled = false;
                cbbFormaPagamento.Enabled = false;
                btnProcurarForma.Enabled = false;
                lblValorPago.Enabled = false;
                lblAsterisco3.Enabled = false;
                txtValorPagamento.Enabled = false;
                btnSalvarPagamento.Enabled = false;
                lblListaFormasPagamento.Enabled = false;
                chkbIgnorarJurosAM.Enabled = false;
                chkbIgnorarMulta.Enabled = false;
                //
                lblDescontoPorcValor.Text = "Desconto de: 0,00%.";
                lblMultaPorcValor.Text = "Multa de: 0,00%.";
                lblValorDesconto.Text = null;
                lblValorMulta.Text = null;
                lblJurosAMPorcValor.Text = "Juros (a.m) de: 0,00%.";
                lblValorJurosAm.Text = null;
                lblValorRealDocumento.Text = null;
                lblValorParcialPago.Text = null;
                dtFormaPagamento.DataSource = null;
                cbbFormaPagamento.Text = null;
                txtValorPagamento.Text = null;
                lblValorDiferencaTroco.Text = "0,00";
                lblValorTotalPago.Text = "0,00";
                //
                btnSalvarPagamento.Enabled = false;
                dtFormaPagamento.Enabled = false;
                lblTotalPago.Enabled = false;
                lblValorTotalPago.Enabled = false;
                lblDiferencaTroco.Enabled = false;
                lblValorDiferencaTroco.Enabled = false;
            }
            mtxtDataPagamento.BackColor = Color.White;
        }

        private void mtxtDataPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAplicar.Select();
            }
        }

        private void mtxtDataPagamento_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataPagamento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataPagamento.Text == "")
            {
                mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataPagamento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataPagamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataPagamento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataPagamento.Text == "")
                {
                    mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataPagamento.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void cbbFormaPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorPagamento.Select();
            }
        }

        private void txtValorPagamento_Enter(object sender, EventArgs e)
        {
            txtValorPagamento.BackColor = Color.LightBlue;
        }

        private void txtValorPagamento_Leave(object sender, EventArgs e)
        {
            if (txtValorPagamento.Text != "")
            {
                if (txtValorPagamento.Text.Contains("'") || txtValorPagamento.Text.Contains(";") || txtValorPagamento.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorPagamento.Text = null;
                    txtValorPagamento.Select();
                }
                else
                {
                    try
                    {
                        txtValorPagamento.Text = Convert.ToDecimal(txtValorPagamento.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorPagamento.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorPagamento.");
                        }
                        txtValorPagamento.Text = null;
                    }
                }
            }
            txtValorPagamento.BackColor = Color.White;
        }

        private void txtValorPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorPagamento.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (btnSalvarPagamento.Enabled == false)
                {
                    btnSalvar.Select();
                }
                else
                {
                    btnSalvarPagamento.Select();
                }
            }
        }

        private void FrmOpeFormBaixaContaPagar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSalvarPagamento_Click(object sender, EventArgs e)
        {
            btnSalvarPagamento.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados da Forma de Pagamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                if (cbbFormaPagamento.Text == "" || txtValorPagamento.Text.Trim() == "" || txtValorPagamento.Text.Trim() == "0" || txtValorPagamento.Text.Trim() == "0,00")
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Forma de pagamento ] e [ Valor Pago ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    cbbFormaPagamento.Select();
                }
                else
                {
                    try
                    {
                        if (_Formulario == 0)
                        {
                            bllContasReceber.Salvar_Forma_Pagamento_Conta_Receber((dtFormaPagamento.Rows.Count + 1).ToString(), cbbFormaPagamento.Text, txtValorPagamento.Text.Trim(), 0, bllConexao._Codigo_Conexao);
                            //
                            dtFormaPagamento.DataSource = bllContasReceber.Sel_Item_Conta_Receber_Pgto_Todas(bllConexao._Codigo_Conexao);
                            //
                            dtFormaPagamento.CurrentCell = dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Cells[0];
                            //
                            dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Selected = true;
                            //
                            dtFormaPagamento.FirstDisplayedScrollingRowIndex = dtFormaPagamento.Rows.Count - 1;
                            //
                            cbbFormaPagamento.Text = null;
                            txtValorPagamento.Text = null;
                            //
                            MessageBox.Show("Os dados da Forma de Pagamento foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            cbbFormaPagamento.Select();
                        }
                        else if (_Formulario == 1)
                        {
                            bllContasPagar.Salvar_Forma_Pagamento((dtFormaPagamento.Rows.Count + 1).ToString(), cbbFormaPagamento.Text, txtValorPagamento.Text.Trim(), 0, bllConexao._Codigo_Conexao);
                            //
                            dtFormaPagamento.DataSource = bllContasPagar.Sel_Item_Conta_Pagar_Pgto_Todas();
                            //
                            dtFormaPagamento.CurrentCell = dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Cells[0];
                            //
                            dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Selected = true;
                            //
                            dtFormaPagamento.FirstDisplayedScrollingRowIndex = dtFormaPagamento.Rows.Count - 1;
                            //
                            cbbFormaPagamento.Text = null;
                            txtValorPagamento.Text = null;
                            //
                            MessageBox.Show("Os dados da Forma de Pagamento foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            cbbFormaPagamento.Select();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvarPagamento.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvarPagamento.");
                        }
                        //
                        if (_Formulario == 0)
                        {
                            bllContasReceber.Excluir_Item_Conta_Receber_Pgto_Atual(bllConexao._Codigo_Conexao);
                        }
                        else if (_Formulario == 1)
                        {
                            bllContasPagar.Excluir_Item_Conta_Pagar_Pgto_Atual();
                        }
                        //
                        dtFormaPagamento.DataSource = null;
                    }
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
                cbbFormaPagamento.Select();
            }
        }

        private void dtFormaPagamento_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtFormaPagamento.Columns[0].HeaderText = "Item";
                dtFormaPagamento.Columns[1].HeaderText = "Cód. Forma de Pagamento";
                dtFormaPagamento.Columns[2].HeaderText = "Tipo";
                dtFormaPagamento.Columns[3].HeaderText = "Valor Pago (R$)";
                dtFormaPagamento.Columns[4].HeaderText = "Pagamento Parcial";

                dtFormaPagamento.DefaultCellStyle.Font = new Font(dtFormaPagamento.Font, FontStyle.Bold);

                dtFormaPagamento.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFormaPagamento.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFormaPagamento.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFormaPagamento.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFormaPagamento.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFormaPagamento.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFormaPagamento.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFormaPagamento.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFormaPagamento.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtFormaPagamento.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtFormaPagamento.Columns[0].Width = 56;
                dtFormaPagamento.Columns[1].Width = 164;
                dtFormaPagamento.Columns[2].Width = 295;
                dtFormaPagamento.Columns[3].Width = 110;
                dtFormaPagamento.Columns[4].Width = 125;
                //
                decimal valortotal = 0;
                for (int i = 0; i < dtFormaPagamento.Rows.Count; i++)
                {
                    valortotal += Convert.ToDecimal(dtFormaPagamento.Rows[i].Cells[3].Value);
                }
                lblValorTotalPago.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valordiferenca = 0;
                valordiferenca = valortotal - Convert.ToDecimal(lblValorRealDocumento.Text);
                if (valortotal > Convert.ToDecimal(lblValorRealDocumento.Text))
                {
                    lblDiferencaTroco.Location = new Point(280, 183);
                    lblDiferencaTroco.ForeColor = Color.Blue;
                    lblDiferencaTroco.Text = "Troco (R$):";
                    lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblDiferencaTroco.Location = new Point(245, 183);
                    lblDiferencaTroco.ForeColor = Color.Red;
                    lblDiferencaTroco.Text = "Diferença (R$):";
                    lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtFormaPagamento.");
                }
            }
        }

        private void dtFormaPagamento_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFormaPagamento.DataSource == null)
            {
                dtFormaPagamento.Enabled = false;
                btnExcluirReg.Enabled = false;
            }
            else
            {
                dtFormaPagamento.Enabled = true;
                btnExcluirReg.Enabled = true;
            }
        }

        private void dtFormaPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtFormaPagamento.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtFormaPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtFormaPagamento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtFormaPagamento.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtFormaPagamento.Columns[3].DefaultCellStyle.Format = "n2";

            dtFormaPagamento.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtFormaPagamento.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtFormaPagamento_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblValorTotalPago.Text = "0,00";
            lblValorDiferencaTroco.Text = "-" + lblValorRealDocumento.Text;
            lblDiferencaTroco.Location = new Point(245, 183);
            lblDiferencaTroco.ForeColor = Color.Red;
            lblDiferencaTroco.Text = "Diferença (R$):";
        }

        private void btnExcluirReg_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                try
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];

                    if (SelectedRow.Cells[4].Value.ToString() == "1")
                    {
                        MessageBox.Show("Não é possível excluir um pagamento parcial.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        if (_Formulario == 0)
                        {
                            bllContasReceber.Excluir_Item(SelectedRow.Cells[0].Value.ToString());

                            bllContasReceber.Atualizar_Item_Dt_Pgto_Conta_Receber(dtFormaPagamento.CurrentRow.Index + 1, dtFormaPagamento.Rows.Count);

                            dtFormaPagamento.DataSource = bllContasReceber.Sel_Item_Conta_Receber_Pgto_Todas(bllConexao._Codigo_Conexao);

                            if (dtFormaPagamento.Rows.Count > 1)
                            {
                                dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Selected = true;

                                dtFormaPagamento.FirstDisplayedScrollingRowIndex = dtFormaPagamento.Rows.Count - 1;
                            }

                            MessageBox.Show("Item excluído com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;

                            dtFormaPagamento.Select();
                        }
                        else if (_Formulario == 1)
                        {
                            bllContasPagar.Excluir_Item(SelectedRow.Cells[0].Value.ToString());

                            bllContasPagar.Atualizar_Item_Dt_Pgto_Conta_Pagar(dtFormaPagamento.CurrentRow.Index + 1, dtFormaPagamento.Rows.Count);

                            dtFormaPagamento.DataSource = bllContasPagar.Sel_Item_Conta_Pagar_Pgto_Todas();

                            if (dtFormaPagamento.Rows.Count > 1)
                            {
                                dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Selected = true;

                                dtFormaPagamento.FirstDisplayedScrollingRowIndex = dtFormaPagamento.Rows.Count - 1;
                            }

                            MessageBox.Show("Item excluído com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;

                            dtFormaPagamento.Select();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirReg.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirReg.");
                    }
                    //
                    if (_Formulario == 0)
                    {
                        bllContasReceber.Excluir_Item_Conta_Receber_Pgto_Atual(bllConexao._Codigo_Conexao);
                    }
                    else if (_Formulario == 1)
                    {
                        bllContasPagar.Excluir_Item_Conta_Pagar_Pgto_Atual();
                    }
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void FrmOpeFormBaixaContaPagar_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_Formulario == 0)
                {
                    bllContasReceber.Excluir_Item_Conta_Receber_Pgto_Atual(bllConexao._Codigo_Conexao);
                }
                else if (_Formulario == 1)
                {
                    bllContasPagar.Excluir_Item_Conta_Pagar_Pgto_Atual();
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelBaixaConta foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelBaixaConta foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelBaixaConta.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelBaixaConta.");
                }
            }
        }

        private void btnProcurarForma_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Formulario == 0)
                {
                    using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(1, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Pag.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.None;
                            cbbFormaPagamento.Items.Clear();
                            if (bllContasReceber.Sel_Forma_Pagamento_Conta_Receber() == null)
                            {
                                cbbFormaPagamento.Enabled = false;
                                cbbFormaPagamento.Text = null;
                            }
                            else
                            {
                                cbbFormaPagamento.Enabled = true;
                                cbbFormaPagamento.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Forma_Pagamento_Conta_Receber().Rows)
                                {
                                    cbbFormaPagamento.Items.Add((dr["id_pagamento"].ToString()) + "—" + (dr["tipo"].ToString()));
                                }
                            }
                            //
                            cbbFormaPagamento.Text = bllContasReceber._Forma_Pagamento_PesqFormaPagamento_Tabela;
                            bllContasReceber._Forma_Pagamento_PesqFormaPagamento_Tabela = null;
                            cbbFormaPagamento.Select();
                        }
                    }
                }
                else if (_Formulario == 1)
                {
                    using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(0, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Pag.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.None;
                            cbbFormaPagamento.Items.Clear();
                            if (bllContasPagar.Sel_Forma_Pagamento_Conta_Pagar() == null)
                            {
                                cbbFormaPagamento.Enabled = false;
                                cbbFormaPagamento.Text = null;
                            }
                            else
                            {
                                cbbFormaPagamento.Enabled = true;
                                cbbFormaPagamento.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Forma_Pagamento_Conta_Pagar().Rows)
                                {
                                    cbbFormaPagamento.Items.Add((dr["id_pagamento"].ToString()) + "—" + (dr["tipo"].ToString()));
                                }
                            }
                            //
                            cbbFormaPagamento.Text = bllContasPagar._Forma_Pag_PesqFormaPag_Tabela;
                            bllContasPagar._Forma_Pag_PesqFormaPag_Tabela = null;
                            cbbFormaPagamento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarForma.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarForma.");
                }
                cbbFormaPagamento.Text = null;
            }
        }

        private void lblValorDesconto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desconto - (R$): " + lblValorDesconto.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorMulta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Multa + (R$): " + lblValorMulta.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorJurosAm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juros (a.m) + (R$): " + lblValorJurosAm.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDocumento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor (R$): " + lblValorDocumento.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorRealDocumento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Restante Atual (R$): " + lblValorRealDocumento.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalPago_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Pago (R$): " + lblValorTotalPago.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDiferencaTroco_Click(object sender, EventArgs e)
        {
            if (lblDiferencaTroco.Text == "Diferença (R$):")
            {
                MessageBox.Show("Diferença (R$): " + lblValorDiferencaTroco.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                MessageBox.Show("Troco (R$): " + lblValorDiferencaTroco.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
        }

        private void lblValorCodigo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Código: " + lblValorCodigo.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDataEmissao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data de Emissão: " + lblValorDataEmissao.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDataVencimento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data de Vencimento: " + lblValorDataVencimento.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDataDesconto_Click(object sender, EventArgs e)
        {
            if (lblValorDataDesconto.Text != "")
            {
                MessageBox.Show("Desconto Até: " + lblValorDataDesconto.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                MessageBox.Show("Desconto Até: ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            try
            {
                if (_Formulario == 0)
                {
                    DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        for (int i = 0; i < dtFormaPagamento.Rows.Count; i++)
                        {
                            if (bllFormaPagamento.Sel_Forma_Ainda_Existe(dtFormaPagamento.Rows[i].Cells[1].Value.ToString()) == false)
                            {
                                MessageBox.Show("A Forma de Pagamento [ " + dtFormaPagamento.Rows[i].Cells[1].Value.ToString() + " ] não existe ou foi excluída.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        //
                        if (bllContasReceber.Sel_Conta_Receber_Ainda_Existe(lblValorCodigo.Text) == false)
                        {
                            MessageBox.Show("Esta Conta a Receber não existe ou foi excluída.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            btnSair.Select();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            mtxtDataPagamento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            if (mtxtDataPagamento.Text == "" || dtFormaPagamento.Rows.Count == 0)
                            {
                                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: [ Data de Pagamento ] e [ Lista de Formas de Pagamento ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtDataPagamento.Select();
                            }
                            else if (bllContasReceber.Sel_Baixa_Conta_Receber_Aconteceu(lblValorCodigo.Text) == true)
                            {
                                MessageBox.Show("Esta conta a receber já foi baixada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.OK;
                            }
                            else if (bllContasReceber.Sel_Pagamento_Conta_Receber_Existe(lblValorCodigo.Text, dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Cells[0].Value.ToString()) == true)
                            {
                                MessageBox.Show("Existem apenas pagamentos parciais já informados anteriormente, por favor, informe um novo pagamento para continuar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                this.DialogResult = DialogResult.None;
                                if (Convert.ToDecimal(lblValorTotalPago.Text) < Convert.ToDecimal(lblValorRealDocumento.Text))
                                {
                                    string mensagem;
                                    if (dtFormaPagamento.Rows.Count > 1)
                                    {
                                        mensagem = "Existe uma diferença de " + lblValorDiferencaTroco.Text.Replace("-", "") + " R$. Deseja informar esses pagamentos como parciais?";
                                    }
                                    else
                                    {
                                        mensagem = "Existe uma diferença de " + lblValorDiferencaTroco.Text.Replace("-", "") + " R$. Deseja informar esse pagamento como parcial?";
                                    }
                                    //                        
                                    DialogResult = MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;

                                        for (int i = 0; dtFormaPagamento.Rows.Count > i; i++)
                                        {
                                            DataGridViewRow SelectedRow = dtFormaPagamento.Rows[i];

                                            if (Convert.ToByte(SelectedRow.Cells[4].Value) == 0)
                                            {
                                                bllContasReceber.Salvar_Pagamento_Conta_Receber(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), lblValorCodigo.Text, mtxtDataPagamento.Text, 1, _Usuario, _Cod_PDV_Computador);
                                                //
                                                bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), "ENTRADA", "RECEBIMENTO DE CONTA A RECEBER", SelectedRow.Cells[3].Value.ToString(), lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                            }
                                        }
                                        //
                                        bllContasReceber.Salvar_Baixa_Pagamento_Parcial_Conta_Receber(lblValorCodigo.Text, lblValorTotalPago.Text, mtxtDataPagamento.Text, lblValorDataVencimento.Text);
                                        //
                                        if (lblNDocumento.Text != "")
                                        {
                                            decimal valorpagoatual = 0;
                                            for (int i = 0; i < dtFormaPagamento.Rows.Count; i++)
                                            {
                                                if (Convert.ToByte(dtFormaPagamento.Rows[i].Cells[4].Value) == 0)
                                                {
                                                    valorpagoatual += Convert.ToDecimal(dtFormaPagamento.Rows[i].Cells[3].Value);
                                                }
                                            }
                                            //
                                            bllClieCons.Atualizar_Saldo_Clie(_Cod_Cliente, valorpagoatual.ToString());
                                        }
                                        //
                                        bllRegistroAtividades.Salvar("INFORMOU PAGAMENTO PARCIAL A UMA CONTA A RECEBER.", "CONTAS A RECEBER", lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                        //
                                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                                else
                                {
                                    for (int i = 0; dtFormaPagamento.Rows.Count > i; i++)
                                    {
                                        DataGridViewRow SelectedRow = dtFormaPagamento.Rows[i];

                                        if (Convert.ToByte(SelectedRow.Cells[4].Value) == 0)
                                        {
                                            bllContasReceber.Salvar_Pagamento_Conta_Receber(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), lblValorCodigo.Text, mtxtDataPagamento.Text, 0, _Usuario, _Cod_PDV_Computador);
                                            //
                                        }
                                    }
                                    //
                                    bllContasReceber.Salvar_Baixa_Pagamento_Conta_Receber(lblValorCodigo.Text, lblValorJurosAm.Text, lblValorRealDocumento.Text, mtxtDataPagamento.Text, lblValorTotalPago.Text, lblValorDiferencaTroco.Text, _Usuario, chkbIgnorarJurosAM.Checked, chkbIgnorarMulta.Checked, _Cod_PDV_Computador);
                                    //
                                    if (lblNDocumento.Text != "")
                                    {
                                        decimal valorpagoatual = 0;
                                        for (int i = 0; i < dtFormaPagamento.Rows.Count; i++)
                                        {
                                            if (Convert.ToByte(dtFormaPagamento.Rows[i].Cells[4].Value) == 0)
                                            {
                                                valorpagoatual += Convert.ToDecimal(dtFormaPagamento.Rows[i].Cells[3].Value);
                                            }
                                        }
                                        //
                                        bllClieCons.Atualizar_Saldo_Clie(_Cod_Cliente, (Convert.ToDecimal(lblValorDocumento.Text) - (Convert.ToDecimal(lblValorParcialPago.Text))).ToString().Replace("-", ""));
                                    }
                                    //
                                    string valor_recebido = (Convert.ToDecimal(lblValorParcialPago.Text) - Convert.ToDecimal(lblValorRealDocumento.Text)).ToString().Replace("-", "");

                                    bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), "ENTRADA", "RECEBIMENTO DE CONTA A RECEBER", valor_recebido, lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                    //
                                    bllRegistroAtividades.Salvar("FECHOU UMA CONTA A RECEBER.", "CONTAS A RECEBER", lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                    //
                                    using (FrmTroco Troco = new FrmTroco(lblValorDiferencaTroco.Text))
                                    {
                                        if (Troco.ShowDialog() == DialogResult.OK)
                                        {
                                            this.DialogResult = DialogResult.OK;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        mtxtDataPagamento.Select();
                    }
                }
                else if (_Formulario == 1)
                {
                    DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {

                        this.DialogResult = DialogResult.None;
                        if (bllContasPagar.Sel_Conta_Pagar_Ainda_Existe(lblValorCodigo.Text) == false)
                        {
                            MessageBox.Show("Esta Conta a Pagar não existe ou foi excluída.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            btnSair.Select();
                        }
                        else
                        {
                            mtxtDataPagamento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            if (mtxtDataPagamento.Text == "" || dtFormaPagamento.Rows.Count == 0)
                            {
                                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: [ Data de Pagamento ] e [ Lista de Formas de Pagamento ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtDataPagamento.Select();
                            }
                            else if (bllContasPagar.Sel_Baixa_Conta_Pagar_Aconteceu(lblValorCodigo.Text) == true)
                            {
                                MessageBox.Show("Esta conta a pagar já foi baixada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.OK;
                            }
                            else if (bllContasPagar.Sel_Pagamento_Conta_Pagar_Existe(lblValorCodigo.Text, dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Cells[0].Value.ToString()) == true)
                            {
                                MessageBox.Show("Existem apenas pagamentos parciais já informados anteriormente, por favor, informe um novo pagamento para continuar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                mtxtDataPagamento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                this.DialogResult = DialogResult.None;
                                if (Convert.ToDecimal(lblValorTotalPago.Text) < Convert.ToDecimal(lblValorRealDocumento.Text))
                                {
                                    string mensagem;
                                    if (dtFormaPagamento.Rows.Count > 1)
                                    {
                                        mensagem = "Existe uma diferença de " + lblValorDiferencaTroco.Text.Replace("-", "") + " R$. Deseja informar esses pagamentos como parciais?";
                                    }
                                    else
                                    {
                                        mensagem = "Existe uma diferença de " + lblValorDiferencaTroco.Text.Replace("-", "") + " R$. Deseja informar esse pagamento como parcial?";
                                    }
                                    //                        
                                    DialogResult = MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;

                                        for (int i = 0; dtFormaPagamento.Rows.Count > i; i++)
                                        {
                                            DataGridViewRow SelectedRow = dtFormaPagamento.Rows[i];

                                            if (Convert.ToByte(SelectedRow.Cells[4].Value) == 0)
                                            {
                                                bllContasPagar.Salvar_Pagamento_Conta_Pagar(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), lblValorCodigo.Text, _Descricao, mtxtDataPagamento.Text, 1, _Usuario, _Cod_PDV_Computador);
                                                //
                                                bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), "SAIDA", "PAGAMENTO DE CONTA A PAGAR", SelectedRow.Cells[3].Value.ToString(), lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                            }
                                        }
                                        //
                                        bllContasPagar.Salvar_Baixa_Pagamento_Parcial_Conta_Pagar(lblValorCodigo.Text, lblValorRealDocumento.Text, lblValorTotalPago.Text, mtxtDataPagamento.Text);
                                        //
                                        bllRegistroAtividades.Salvar("INFORMOU PAGAMENTO PARCIAL A UMA CONTA A PAGAR.", "CONTAS A PAGAR", lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                        //
                                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                    }
                                }
                                else
                                {
                                    for (int i = 0; dtFormaPagamento.Rows.Count > i; i++)
                                    {
                                        DataGridViewRow SelectedRow = dtFormaPagamento.Rows[i];

                                        if (Convert.ToByte(SelectedRow.Cells[4].Value) == 0)
                                        {
                                            bllContasPagar.Salvar_Pagamento_Conta_Pagar(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), lblValorCodigo.Text, _Descricao, mtxtDataPagamento.Text, 0, _Usuario, _Cod_PDV_Computador);
                                        }
                                    }
                                    //
                                    bllContasPagar.Salvar_Baixa_Pagamento_Conta_Pagar(lblValorCodigo.Text, lblValorJurosAm.Text, lblValorRealDocumento.Text, mtxtDataPagamento.Text, lblValorTotalPago.Text, lblValorDiferencaTroco.Text, _Usuario, _Cod_PDV_Computador, true);
                                    //
                                    string valor_pago = (Convert.ToDecimal(lblValorParcialPago.Text) - Convert.ToDecimal(lblValorRealDocumento.Text)).ToString().Replace("-", "");
                                    //
                                    bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), "SAIDA", "PAGAMENTO DE CONTA A PAGAR", valor_pago, lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                    //
                                    bllRegistroAtividades.Salvar("FECHOU UMA CONTA A PAGAR.", "CONTAS A PAGAR", lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                    //
                                    using (FrmTroco Troco = new FrmTroco(lblValorDiferencaTroco.Text))
                                    {
                                        if (Troco.ShowDialog() == DialogResult.OK)
                                        {
                                            this.DialogResult = DialogResult.OK;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        mtxtDataPagamento.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                bllContasPagar.Excluir_Item_Conta_Pagar_Pgto_Atual();
                dtFormaPagamento.DataSource = null;
            }
        }

        private void dtFormaPagamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value.ToString() == "0")
            {
                e.Value = "NÃO";
            }
            else if (e.ColumnIndex == 4 && e.Value.ToString() == "1")
            {
                e.Value = "SIM";
            }
        }

        private void lblValorParcialPago_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Parcial Pago (R$): " + lblValorParcialPago.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void pcibInterrogacao_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                MessageBox.Show("1 - Informações da Conta a Receber: É onde ficam localizadas as informações relevantes da conta a receber.\n\n2 - Informações de Pagamento: É a parte onde o usuário vai inserir as informações complementares do pagamento.\n\n3 - Pagamento: É onde vai ser informado o pagamento realizado pelo consumidor.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
            else if (_Formulario == 1)
            {
                MessageBox.Show("1 - Informações da Conta a Pagar: É onde ficam localizadas as informações relevantes da conta a pagar.\n\n2 - Informações de Pagamento: É a parte onde o usuário vai inserir as informações complementares do pagamento.\n\n3 - Pagamento: É onde vai ser informado o pagamento realizado pelo consumidor.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
        }

        private void lblNDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblNDocumento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorParcela_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorParcela_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorParcela_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Parcela: " + lblValorParcela.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblNDocumento_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                MessageBox.Show("Nº da Promissória: " + lblNDocumento.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
            else if (_Formulario == 1)
            {
                MessageBox.Show("Nº do Documento: " + lblNDocumento.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnAplicar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAplicar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbIgnorarMulta_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbIgnorarMulta_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbIgnorarJurosAM_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbIgnorarJurosAM_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbIgnorarJurosAM_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkbIgnorarJurosAM.Checked == true)
                {
                    lblJurosAMPorcValor.Text = "Juros (a.m) de: 0,00%.";
                    lblValorJurosAm.Text = "0,00";
                    lblValorRealDocumento.Text = Convert.ToDecimal(bllContasReceber.Calculo_Valor_Real(lblValorJurosAm.Text, lblValorDesconto.Text, lblValorMulta.Text, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text, _Pagamento_Parcial_Anterior)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    decimal valortotal = 0;
                    for (int i = 0; i < dtFormaPagamento.Rows.Count; i++)
                    {
                        valortotal += Convert.ToDecimal(dtFormaPagamento.Rows[i].Cells[3].Value);
                    }
                    lblValorTotalPago.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    decimal valordiferenca = 0;
                    valordiferenca = valortotal - Convert.ToDecimal(lblValorRealDocumento.Text);
                    if (valortotal > Convert.ToDecimal(lblValorRealDocumento.Text))
                    {
                        lblDiferencaTroco.Location = new Point(280, 183);
                        lblDiferencaTroco.ForeColor = Color.Blue;
                        lblDiferencaTroco.Text = "Troco (R$):";
                        lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        lblDiferencaTroco.Location = new Point(245, 183);
                        lblDiferencaTroco.ForeColor = Color.Red;
                        lblDiferencaTroco.Text = "Diferença (R$):";
                        lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
                else
                {
                    lblJurosAMPorcValor.Text = "Juros (a.m) de: " + _Juros_AM_Porc + "%.";
                    lblValorJurosAm.Text = Convert.ToDecimal(bllContasReceber.Calculo_Juros_Am(_Juros_AM_Porc, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    lblValorRealDocumento.Text = Convert.ToDecimal(bllContasReceber.Calculo_Valor_Real(lblValorJurosAm.Text, lblValorDesconto.Text, lblValorMulta.Text, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text, _Pagamento_Parcial_Anterior)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    decimal valortotal = 0;
                    for (int i = 0; i < dtFormaPagamento.Rows.Count; i++)
                    {
                        valortotal += Convert.ToDecimal(dtFormaPagamento.Rows[i].Cells[3].Value);
                    }
                    lblValorTotalPago.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    decimal valordiferenca = 0;
                    valordiferenca = valortotal - Convert.ToDecimal(lblValorRealDocumento.Text);
                    if (valortotal > Convert.ToDecimal(lblValorRealDocumento.Text))
                    {
                        lblDiferencaTroco.Location = new Point(280, 183);
                        lblDiferencaTroco.ForeColor = Color.Blue;
                        lblDiferencaTroco.Text = "Troco (R$):";
                        lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        lblDiferencaTroco.Location = new Point(245, 183);
                        lblDiferencaTroco.ForeColor = Color.Red;
                        lblDiferencaTroco.Text = "Diferença (R$):";
                        lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento CheckedChanged do chkbIgnorarJurosAM.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento CheckedChanged do chkbIgnorarJurosAM.");
                }
            }
        }

        private void chkbIgnorarMulta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkbIgnorarMulta.Checked == true)
                {
                    lblMultaPorcValor.Text = "Multa de: 0,00%.";
                    lblValorMulta.Text = "0,00";
                    lblValorJurosAm.Text = Convert.ToDecimal(bllContasReceber.Calculo_Juros_Am(_Juros_AM_Porc, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    lblValorRealDocumento.Text = Convert.ToDecimal(bllContasReceber.Calculo_Valor_Real(lblValorJurosAm.Text, lblValorDesconto.Text, lblValorMulta.Text, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text, _Pagamento_Parcial_Anterior)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    decimal valortotal = 0;
                    for (int i = 0; i < dtFormaPagamento.Rows.Count; i++)
                    {
                        valortotal += Convert.ToDecimal(dtFormaPagamento.Rows[i].Cells[3].Value);
                    }
                    lblValorTotalPago.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    decimal valordiferenca = 0;
                    valordiferenca = valortotal - Convert.ToDecimal(lblValorRealDocumento.Text);
                    if (valortotal > Convert.ToDecimal(lblValorRealDocumento.Text))
                    {
                        lblDiferencaTroco.Location = new Point(280, 183);
                        lblDiferencaTroco.ForeColor = Color.Blue;
                        lblDiferencaTroco.Text = "Troco (R$):";
                        lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        lblDiferencaTroco.Location = new Point(245, 183);
                        lblDiferencaTroco.ForeColor = Color.Red;
                        lblDiferencaTroco.Text = "Diferença (R$):";
                        lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
                else
                {
                    lblMultaPorcValor.Text = "Multa de: " + _Multa_Porc + "%.";
                    lblValorMulta.Text = _Valor_Multa;
                    lblValorJurosAm.Text = Convert.ToDecimal(bllContasReceber.Calculo_Juros_Am(_Juros_AM_Porc, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    lblValorRealDocumento.Text = Convert.ToDecimal(bllContasReceber.Calculo_Valor_Real(lblValorJurosAm.Text, lblValorDesconto.Text, lblValorMulta.Text, lblValorDocumento.Text, lblValorDataVencimento.Text, mtxtDataPagamento.Text, _Pagamento_Parcial_Anterior)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    decimal valortotal = 0;
                    for (int i = 0; i < dtFormaPagamento.Rows.Count; i++)
                    {
                        valortotal += Convert.ToDecimal(dtFormaPagamento.Rows[i].Cells[3].Value);
                    }
                    lblValorTotalPago.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    decimal valordiferenca = 0;
                    valordiferenca = valortotal - Convert.ToDecimal(lblValorRealDocumento.Text);
                    if (valortotal > Convert.ToDecimal(lblValorRealDocumento.Text))
                    {
                        lblDiferencaTroco.Location = new Point(280, 183);
                        lblDiferencaTroco.ForeColor = Color.Blue;
                        lblDiferencaTroco.Text = "Troco (R$):";
                        lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        lblDiferencaTroco.Location = new Point(245, 183);
                        lblDiferencaTroco.ForeColor = Color.Red;
                        lblDiferencaTroco.Text = "Diferença (R$):";
                        lblValorDiferencaTroco.Text = Convert.ToDecimal(valordiferenca).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento CheckedChanged do chkbIgnorarMulta.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento CheckedChanged do chkbIgnorarMulta.");
                }
            }
        }

        private void grbBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbbFormaPagamento_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbFormaPagamento.Text == "5—CREDITO LOJA")
                {
                    using (FrmValorCreditoLoja Cred = new FrmValorCreditoLoja(_Cod_Cliente, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Cred.ShowDialog() == DialogResult.OK)
                        {
                            if (Convert.ToDecimal(bllContasReceber._Valor_Credito_Loja) > Convert.ToDecimal(lblValorDiferencaTroco.Text.Replace("-", "")))
                            {
                                MessageBox.Show("O valor informado é maior que o valor da venda, será acrescentado apenas o valor corresponde ao total a pagar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                //
                                txtValorPagamento.Text = lblValorDiferencaTroco.Text.Replace("-", "");
                            }
                            else
                            {
                                txtValorPagamento.Text = bllContasReceber._Valor_Credito_Loja;
                            }
                        }
                        else
                        {
                            cbbFormaPagamento.Text = null;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Leave do cbbFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Leave do cbbFormaPagamento.");
                }
            }
        }

        private void txtValorPagamento_DoubleClick(object sender, EventArgs e)
        {
            if (txtValorPagamento.Text == "")
            {
                if (dtFormaPagamento.DataSource != null)
                {
                    if (lblValorDiferencaTroco.Text.Contains("-"))
                    {
                        txtValorPagamento.Text = lblValorDiferencaTroco.Text.Replace("-", "");
                    }
                }
                else
                {
                    txtValorPagamento.Text = lblValorRealDocumento.Text;
                }
            }
        }

        private void txtValorPagamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (txtValorPagamento.Text == "")
                {
                    if (dtFormaPagamento.DataSource != null)
                    {
                        if (lblValorDiferencaTroco.Text.Contains("-"))
                        {
                            txtValorPagamento.Text = lblValorDiferencaTroco.Text.Replace("-", "");
                        }
                    }
                    else
                    {
                        txtValorPagamento.Text = lblValorRealDocumento.Text;
                    }
                }
            }
        }
    }
}
