using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmFormaPagamento : Form
    {
        public FrmFormaPagamento(string valor_total_produto, string valor_subtotal_produto, byte formulario, string acrescimo_item, string desconto_item, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Valor_Total_Produto = valor_total_produto;
            _Valor_SubTotal_Produto = valor_subtotal_produto;
            _Formulario = formulario;
            _Acrescimo_Item = acrescimo_item;
            _Desconto_Item = desconto_item;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Valor_Total_Produto;
        private string _Valor_SubTotal_Produto;
        private decimal _Valor_Diferenca_Troco = 0;
        private decimal _Valor_Total_Pago = 0;
        private bool _Nota_Promissoria = false;
        private byte _Formulario;
        decimal _Desconto_Fixo_Porc_1 = 0;
        decimal _Acrescimo_Fixo_Porc_1 = 0;
        decimal _Desconto_Fixo_Porc_2 = 0;
        decimal _Acrescimo_Fixo_Porc_2 = 0;
        decimal _Desconto_Fixo_Porc_3 = 0;
        decimal _Acrescimo_Fixo_Porc_3 = 0;
        decimal _Desconto_Fixo_Porc_4 = 0;
        decimal _Acrescimo_Fixo_Porc_4 = 0;
        private string _Acrescimo_Item;
        private string _Desconto_Item;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private bool _Perm_Desc_Usuario = false;
        private bool _Perm_Acresc_Usuario = false;


        private void FrmFormaPagamento_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFormaPagamento iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFormaPagamento iniciado.");
                }
                //
                lblValorPagar.Text = _Valor_Total_Produto;
                lblTotalSub.Text = _Valor_SubTotal_Produto;
                lblDifTroco.Text = _Valor_Total_Produto.Insert(0, "-");
                //
                txtDesconto.Text = "0,00";
                txtDescontoPorc.Text = "0,00";
                txtAcrescimoPorc.Text = "0,00";
                txtAcrescimo.Text = "0,00";
                //
                if (_Formulario == 0)
                {
                    if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                    {
                        cbbForma1.Text = null;
                        cbbForma2.Text = null;
                        cbbForma3.Text = null;
                        cbbForma4.Text = null;
                    }
                    else
                    {
                        cbbForma1.Items.Add("");
                        cbbForma2.Items.Add("");
                        cbbForma3.Items.Add("");
                        cbbForma4.Items.Add("");
                        //
                        foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                        {
                            if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                            {
                                cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["descricao"] + "—" + dr["tipo"].ToString());
                                cbbForma2.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["descricao"] + "—" + dr["tipo"].ToString());
                                cbbForma3.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["descricao"] + "—" + dr["tipo"].ToString());
                                cbbForma4.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["descricao"] + "—" + dr["tipo"].ToString());
                            }
                            else
                            {
                                cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                                cbbForma2.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                                cbbForma3.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                                cbbForma4.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                            }
                        }
                    }
                    //
                    txtCodigo.Select();
                }
                else if (_Formulario == 1)
                {
                    //
                    txtDescontoPorc.Enabled = false;
                    txtDesconto.Enabled = false;
                    txtAcrescimoPorc.Enabled = false;
                    txtAcrescimo.Enabled = false;
                    lblDesconto.Enabled = false;
                    label1.Enabled = false;
                    label3.Enabled = false;
                    lblAcrescimo.Enabled = false;
                    label2.Enabled = false;
                    label4.Enabled = false;
                    //
                    if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                    {
                        cbbForma1.Text = null;
                        cbbForma2.Text = null;
                        cbbForma3.Text = null;
                        cbbForma4.Text = null;
                    }
                    else
                    {
                        cbbForma1.Items.Add("");
                        cbbForma2.Items.Add("");
                        cbbForma3.Items.Add("");
                        cbbForma4.Items.Add("");
                        //
                        foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                        {
                            if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                            {
                                cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"] + "—" + dr["descricao"].ToString());
                                cbbForma2.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"] + "—" + dr["descricao"].ToString());
                                cbbForma3.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"] + "—" + dr["descricao"].ToString());
                                cbbForma4.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"] + "—" + dr["descricao"].ToString());
                            }
                            else
                            {
                                cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                                cbbForma2.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                                cbbForma3.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                                cbbForma4.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                            }
                        }
                        //
                    }
                    //                   
                    if (bllVenda._Valor_Desconto_Devolucao != null)
                    {
                        txtDesconto.Text = (Convert.ToDecimal(_Valor_Total_Produto) - Convert.ToDecimal(bllVenda._Valor_Desconto_Devolucao)).ToString();
                        txtDesconto_Leave(sender, e);
                        lblValorPagar.Text = bllVenda._Valor_Desconto_Devolucao;
                        lblDifTroco.Text = bllVenda._Valor_Desconto_Devolucao.Insert(0, "-");
                    }
                    else
                    {
                        txtCodigo.Text = "5";
                        //
                        cbbForma1.Text = "5—CREDITO LOJA";
                        //
                        grbBox1.Enabled = false;
                        txtValor1.Text = lblValorPagar.Text;
                        lblDifTroco.Text = "0,00";
                    }
                    //
                    btnSalvar.Select();
                }
                else if (_Formulario == 2)
                {
                    if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                    {
                        cbbForma1.Text = null;
                        cbbForma2.Text = null;
                        cbbForma3.Text = null;
                        cbbForma4.Text = null;
                    }
                    else
                    {
                        cbbForma1.Items.Add("");
                        cbbForma2.Items.Add("");
                        cbbForma3.Items.Add("");
                        cbbForma4.Items.Add("");
                        //
                        foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                        {
                            if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                            {
                                cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"] + "—" + dr["descricao"].ToString());
                                cbbForma2.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"] + "—" + dr["descricao"].ToString());
                                cbbForma3.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"] + "—" + dr["descricao"].ToString());
                                cbbForma4.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"] + "—" + dr["descricao"].ToString());
                            }
                            else
                            {
                                cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                                cbbForma2.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                                cbbForma3.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                                cbbForma4.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"]);
                            }
                        }
                    }
                    txtCodigo.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmFormaPagamento.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Desconto_Leave()
        {
            if (txtDesconto.Text.Contains("'") || txtDesconto.Text.Contains(";") || txtDesconto.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDesconto.Text = null;
                txtDesconto.Select();
            }
            else
            {
                if (txtDesconto.Text == "")
                {
                    txtDesconto.Text = "0,00";
                }
                //
                txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                txtDesconto.Text = Convert.ToDecimal(txtDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                //
                txtDescontoPorc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Desconto_Forma_Pagamento(_Valor_Total_Produto.Replace("R$ ", ""), txtDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                lblValorPagar.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Venda(_Valor_Total_Produto.Replace("R$ ", ""), txtDesconto.Text.Trim(), txtAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valor_Pago_1;
                decimal valor_Pago_2;
                decimal valor_Pago_3;
                decimal valor_Pago_4;

                if (txtValor1.Text == "")
                {
                    valor_Pago_1 = 0;
                }
                else
                {
                    valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                }

                if (txtValor2.Text == "")
                {
                    valor_Pago_2 = 0;
                }
                else
                {
                    valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                }

                if (txtValor3.Text == "")
                {
                    valor_Pago_3 = 0;
                }
                else
                {
                    valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                }

                if (txtValor4.Text == "")
                {
                    valor_Pago_4 = 0;
                }
                else
                {
                    valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                }
                _Valor_Total_Pago = Convert.ToDecimal(valor_Pago_1) + Convert.ToDecimal(valor_Pago_2) + Convert.ToDecimal(valor_Pago_3) + Convert.ToDecimal(valor_Pago_4);
                //
                if (_Valor_Total_Pago < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    txtValor1.ForeColor = Color.Red;
                    txtValor2.ForeColor = Color.Red;
                    txtValor3.ForeColor = Color.Red;
                    txtValor4.ForeColor = Color.Red;
                }
                else
                {
                    txtValor1.ForeColor = Color.Blue;
                    txtValor2.ForeColor = Color.Blue;
                    txtValor3.ForeColor = Color.Blue;
                    txtValor4.ForeColor = Color.Blue;
                }
                //
                _Valor_Diferenca_Troco = _Valor_Total_Pago - Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", ""));
                if (_Valor_Total_Pago > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    lblDT.ForeColor = Color.Blue;
                    lblDT.Text = "Troco (R$):";
                    lblDifTroco.ForeColor = Color.Blue;
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblDifTroco.ForeColor = Color.Red;
                    lblDT.ForeColor = Color.Red;
                    lblDT.Text = "Diferença (R$):";
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
            }
            txtDesconto.BackColor = Color.White;
        }

        private void Desconto_Porc_Leave()
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
                if (txtDescontoPorc.Text == "")
                {
                    txtDescontoPorc.Text = "0,00";
                }
                //
                txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                //
                txtDesconto.Text = bllVenda.Calculo_Desconto_Porc_Forma_Pagamento(_Valor_Total_Produto.Replace("R$ ", ""), txtDescontoPorc.Text).ToString();
                lblValorPagar.Text = bllVenda.Calculo_Valor_Venda(_Valor_Total_Produto.Replace("R$ ", ""), txtDesconto.Text.Trim(), txtAcrescimo.Text.Trim());
                //
                decimal valor_Pago_1;
                decimal valor_Pago_2;
                decimal valor_Pago_3;
                decimal valor_Pago_4;

                if (txtValor1.Text == "")
                {
                    valor_Pago_1 = 0;
                }
                else
                {
                    valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                }

                if (txtValor2.Text == "")
                {
                    valor_Pago_2 = 0;
                }
                else
                {
                    valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                }

                if (txtValor3.Text == "")
                {
                    valor_Pago_3 = 0;
                }
                else
                {
                    valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                }

                if (txtValor4.Text == "")
                {
                    valor_Pago_4 = 0;
                }
                else
                {
                    valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                }
                _Valor_Total_Pago = Convert.ToDecimal(valor_Pago_1) + Convert.ToDecimal(valor_Pago_2) + Convert.ToDecimal(valor_Pago_3) + Convert.ToDecimal(valor_Pago_4);
                //
                if (_Valor_Total_Pago < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    txtValor1.ForeColor = Color.Red;
                    txtValor2.ForeColor = Color.Red;
                    txtValor3.ForeColor = Color.Red;
                    txtValor4.ForeColor = Color.Red;
                }
                else
                {
                    txtValor1.ForeColor = Color.Blue;
                    txtValor2.ForeColor = Color.Blue;
                    txtValor3.ForeColor = Color.Blue;
                    txtValor4.ForeColor = Color.Blue;
                }
                //
                _Valor_Diferenca_Troco = _Valor_Total_Pago - Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", ""));
                if (_Valor_Total_Pago > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    lblDT.ForeColor = Color.Blue;
                    lblDT.Text = "Troco (R$):";
                    lblDifTroco.ForeColor = Color.Blue;
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblDifTroco.ForeColor = Color.Red;
                    lblDT.ForeColor = Color.Red;
                    lblDT.Text = "Diferença (R$):";
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
            }
            txtDescontoPorc.BackColor = Color.White;
        }

        private void Acrescimo_Leave()
        {
            if (txtAcrescimo.Text.Contains("'") || txtAcrescimo.Text.Contains(";") || txtAcrescimo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtAcrescimo.Text = null;
                txtAcrescimo.Select();
            }
            else
            {

                if (txtAcrescimo.Text == "")
                {
                    txtAcrescimo.Text = "0,00";
                }

                txtAcrescimo.Text = Convert.ToDecimal(txtAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));
                txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));

                txtAcrescimoPorc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Acrescimo_Forma_Pagamento(_Valor_Total_Produto.Replace("R$ ", ""), txtAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));
                lblValorPagar.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Venda(_Valor_Total_Produto.Replace("R$ ", ""), txtDesconto.Text.Trim(), txtAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valor_Pago_1;
                decimal valor_Pago_2;
                decimal valor_Pago_3;
                decimal valor_Pago_4;

                if (txtValor1.Text == "")
                {
                    valor_Pago_1 = 0;
                }
                else
                {
                    valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                }

                if (txtValor2.Text == "")
                {
                    valor_Pago_2 = 0;
                }
                else
                {
                    valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                }

                if (txtValor3.Text == "")
                {
                    valor_Pago_3 = 0;
                }
                else
                {
                    valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                }

                if (txtValor4.Text == "")
                {
                    valor_Pago_4 = 0;
                }
                else
                {
                    valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                }
                _Valor_Total_Pago = Convert.ToDecimal(valor_Pago_1) + Convert.ToDecimal(valor_Pago_2) + Convert.ToDecimal(valor_Pago_3) + Convert.ToDecimal(valor_Pago_4);
                //
                if (_Valor_Total_Pago < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    txtValor1.ForeColor = Color.Red;
                    txtValor2.ForeColor = Color.Red;
                    txtValor3.ForeColor = Color.Red;
                    txtValor4.ForeColor = Color.Red;
                }
                else
                {
                    txtValor1.ForeColor = Color.Blue;
                    txtValor2.ForeColor = Color.Blue;
                    txtValor3.ForeColor = Color.Blue;
                    txtValor4.ForeColor = Color.Blue;
                }
                //
                _Valor_Diferenca_Troco = _Valor_Total_Pago - Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", ""));
                if (_Valor_Total_Pago > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    lblDT.ForeColor = Color.Blue;
                    lblDT.Text = "Troco (R$):";
                    lblDifTroco.ForeColor = Color.Blue;
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblDifTroco.ForeColor = Color.Red;
                    lblDT.ForeColor = Color.Red;
                    lblDT.Text = "Diferença (R$):";
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
            }
            txtAcrescimo.BackColor = Color.White;
        }

        private void AcrescimoPorc_Leave()
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
                if (txtAcrescimoPorc.Text == "")
                {
                    txtAcrescimoPorc.Text = "0,00";
                }
                //
                txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                //
                txtAcrescimo.Text = Convert.ToDecimal(bllVenda.Calculo_Acrescimo_Porc_Forma_Pagamento(_Valor_Total_Produto.Replace("R$ ", ""), txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                lblValorPagar.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Venda(_Valor_Total_Produto.Replace("R$ ", ""), txtDesconto.Text.Trim(), txtAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valor_Pago_1;
                decimal valor_Pago_2;
                decimal valor_Pago_3;
                decimal valor_Pago_4;

                if (txtValor1.Text == "")
                {
                    valor_Pago_1 = 0;
                }
                else
                {
                    valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                }

                if (txtValor2.Text == "")
                {
                    valor_Pago_2 = 0;
                }
                else
                {
                    valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                }

                if (txtValor3.Text == "")
                {
                    valor_Pago_3 = 0;
                }
                else
                {
                    valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                }

                if (txtValor4.Text == "")
                {
                    valor_Pago_4 = 0;
                }
                else
                {
                    valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                }
                _Valor_Total_Pago = Convert.ToDecimal(valor_Pago_1) + Convert.ToDecimal(valor_Pago_2) + Convert.ToDecimal(valor_Pago_3) + Convert.ToDecimal(valor_Pago_4);
                //
                if (_Valor_Total_Pago < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    txtValor1.ForeColor = Color.Red;
                    txtValor2.ForeColor = Color.Red;
                    txtValor3.ForeColor = Color.Red;
                    txtValor4.ForeColor = Color.Red;
                }
                else
                {
                    txtValor1.ForeColor = Color.Blue;
                    txtValor2.ForeColor = Color.Blue;
                    txtValor3.ForeColor = Color.Blue;
                    txtValor4.ForeColor = Color.Blue;
                }
                //
                _Valor_Diferenca_Troco = _Valor_Total_Pago - Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", ""));
                if (_Valor_Total_Pago > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    lblDT.ForeColor = Color.Blue;
                    lblDT.Text = "Troco (R$):";
                    lblDifTroco.ForeColor = Color.Blue;
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblDifTroco.ForeColor = Color.Red;
                    lblDT.ForeColor = Color.Red;
                    lblDT.Text = "Diferença (R$):";
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
            }
            txtAcrescimoPorc.BackColor = Color.White;
        }

        private void btnProcurar1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtDescontoPorc_Enter(object sender, EventArgs e)
        {
            txtDescontoPorc.BackColor = Color.LightBlue;
        }

        private void txtDescontoPorc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Permitir_Desc_Pag_Usuario(_Usuario) == false & _Perm_Desc_Usuario == false & txtDescontoPorc.Text != "0,00" & txtDescontoPorc.Text != "0")
                {
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(_Usuario, _Cod_PDV_Computador, "Permitir_Desc_Pag"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Desc_Pag == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para aplicar Descontos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                txtDescontoPorc.Text = "0,00";
                                Desconto_Porc_Leave();
                                _Perm_Desc_Usuario = false;
                            }
                            else if (bllVenda._Permitir_Desc_Pag == 1)
                            {
                                Desconto_Porc_Leave();
                                _Perm_Desc_Usuario = true;
                            }
                        }
                        else
                        {
                            txtDescontoPorc.Text = "0,00";
                            Desconto_Porc_Leave();
                            _Perm_Desc_Usuario = false;
                        }
                    }
                }
                else
                {
                    Desconto_Porc_Leave();
                    _Perm_Desc_Usuario = true;
                }
                //
                if (bllUsuario.Sel_Desconto_Porc_Max_Venda_Usuario(_Usuario, txtDescontoPorc.Text) != true & _Formulario != 1)
                {
                    MessageBox.Show("O valor do desconto informado é maior que o definido para este Usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtDescontoPorc.Text = "0,00";
                    txtDesconto.Text = "0,00";
                    Desconto_Porc_Leave();
                    _Perm_Desc_Usuario = false;
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

        private void txtDescontoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDescontoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtDesconto.Select();
            }
        }

        private void txtDesconto_Enter(object sender, EventArgs e)
        {
            txtDesconto.BackColor = Color.LightBlue;
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Permitir_Desc_Pag_Usuario(_Usuario) == false & _Perm_Desc_Usuario == false & txtDesconto.Text != "0,00" & txtDesconto.Text != "0")
                {
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(_Usuario, _Cod_PDV_Computador, "Permitir_Desc_Pag"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Desc_Pag == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para aplicar Descontos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtDescontoPorc.Text = "0,00";
                                Desconto_Leave();
                                _Perm_Desc_Usuario = false;
                            }
                            else if (bllVenda._Permitir_Desc_Pag == 1)
                            {
                                Desconto_Leave();
                                _Perm_Desc_Usuario = true;
                            }
                        }
                        else
                        {
                            txtDescontoPorc.Text = "0,00";
                            Desconto_Leave();
                            _Perm_Desc_Usuario = false;
                        }
                    }
                }
                else
                {
                    Desconto_Leave();
                    _Perm_Desc_Usuario = true;
                }
                //
                if (bllUsuario.Sel_Desconto_Porc_Max_Venda_Usuario(_Usuario, txtDescontoPorc.Text) != true & _Formulario != 1)
                {
                    MessageBox.Show("O valor do desconto informado é maior que o definido para este Usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtDescontoPorc.Text = "0,00";
                    txtDesconto.Text = "0,00";
                    Desconto_Leave();
                    _Perm_Desc_Usuario = false;
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

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDesconto.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtAcrescimoPorc.Select();
            }
        }

        private void txtAcrescimoPorc_Enter(object sender, EventArgs e)
        {
            txtAcrescimoPorc.BackColor = Color.LightBlue;
        }

        private void txtAcrescimoPorc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Permitir_Acresc_Pag_Usuario(_Usuario) == false & _Perm_Acresc_Usuario == false & txtAcrescimoPorc.Text != "0,00" & txtAcrescimoPorc.Text != "0")
                {
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(_Usuario, _Cod_PDV_Computador, "Permitir_Acresc_Pag"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Acresc_Pag == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para aplicar Acréscimos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtAcrescimoPorc.Text = "0,00";
                                AcrescimoPorc_Leave();
                                _Perm_Acresc_Usuario = false;
                            }
                            else if (bllVenda._Permitir_Acresc_Pag == 1)
                            {
                                AcrescimoPorc_Leave();
                                _Perm_Acresc_Usuario = true;
                            }
                        }
                        else
                        {
                            txtAcrescimoPorc.Text = "0,00";
                            AcrescimoPorc_Leave();
                            _Perm_Acresc_Usuario = false;
                        }
                    }
                }
                else
                {
                    AcrescimoPorc_Leave();
                    _Perm_Acresc_Usuario = true;
                }
                //
                if (bllUsuario.Sel_Acrescimo_Porc_Max_Venda_Usuario(_Usuario, txtAcrescimoPorc.Text) != true & _Formulario != 1)
                {
                    MessageBox.Show("O valor do acréscimo informado é maior que o definido para este Usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtAcrescimoPorc.Text = "0,00";
                    txtAcrescimo.Text = "0,00";
                    AcrescimoPorc_Leave();
                    _Perm_Acresc_Usuario = false;
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

        private void txtAcrescimoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAcrescimoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtAcrescimo.Select();
            }
        }

        private void txtAcrescimo_Enter(object sender, EventArgs e)
        {
            txtAcrescimo.BackColor = Color.LightBlue;
        }

        private void txtAcrescimo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Permitir_Acresc_Pag_Usuario(_Usuario) == false & _Perm_Acresc_Usuario == false & txtAcrescimo.Text != "0,00" & txtAcrescimo.Text != "0")
                {
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(_Usuario, _Cod_PDV_Computador, "Permitir_Acresc_Pag"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Acresc_Pag == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para aplicar Acréscimos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtAcrescimo.Text = "0,00";
                                Acrescimo_Leave();
                                _Perm_Acresc_Usuario = false;
                            }
                            else if (bllVenda._Permitir_Acresc_Pag == 1)
                            {
                                Acrescimo_Leave();
                                _Perm_Acresc_Usuario = true;
                            }
                        }
                        else
                        {
                            txtAcrescimo.Text = "0,00";
                            Acrescimo_Leave();
                            _Perm_Acresc_Usuario = false;
                        }
                    }
                }
                else
                {
                    Acrescimo_Leave();
                    _Perm_Acresc_Usuario = true;
                }
                //
                if (bllUsuario.Sel_Acrescimo_Porc_Max_Venda_Usuario(_Usuario, txtAcrescimoPorc.Text) != true & _Formulario != 1)
                {
                    MessageBox.Show("O valor do acréscimo informado é maior que o definido para este Usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtAcrescimoPorc.Text = "0,00";
                    txtAcrescimo.Text = "0,00";
                    Acrescimo_Leave();
                    _Perm_Acresc_Usuario = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAcrescimo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAcrescimo.");
                }
                txtAcrescimo.Text = null;
            }
        }

        private void txtAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAcrescimo.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtCodigo.Select();
            }
        }

        private void cbbForma1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtValor1.Enabled == false)
                {
                    btnSalvar.Select();
                }
                else
                {
                    txtValor1.Select();
                }
            }
        }

        private void txtDescricao1_Enter(object sender, EventArgs e)
        {
            txtCodigo.BackColor = Color.LightBlue;
        }

        private void txtDescricao1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValor1_Enter(object sender, EventArgs e)
        {
            txtValor1.BackColor = Color.LightBlue;
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
                        txtValor1_TextChanged(sender, e);
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
                        txtCodigo.Text = null;
                        cbbForma1.Text = null;
                        txtValor1.Text = null;
                    }
                }
            }
            else
            {
                if (cbbForma1.Text == "NOTA PROMISSORIA")
                {
                    txtValor1.Text = "0,00";
                }
            }
            txtValor1.BackColor = Color.White;
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
                if (btnSalvar.Enabled == false)
                {
                    btnRemover1.Select();
                }
                else
                {
                    btnSalvar.Select();
                }
            }
        }

        private void cbbForma2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValor2.Select();
            }
        }

        private void txtDescricao2_Enter(object sender, EventArgs e)
        {
            txtCodigo1.BackColor = Color.LightBlue;
        }

        private void txtDescricao2_Leave(object sender, EventArgs e)
        {
            if (txtCodigo1.Text.Contains("'") || txtCodigo1.Text.Contains(";") || txtCodigo1.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodigo1.Text = null;
                txtCodigo1.Select();
            }
            else if (txtCodigo1.Text.Trim() == "0")
            {
                txtCodigo1.Text = null;
                cbbForma2.Text = null;
                txtValor2.Text = null;
            }
            else
            {
                try
                {
                    if (txtCodigo1.Text.Trim() != "")
                    {

                        if (bllVenda.Sel_Forma_Pagamento_Codigo_PDV(txtCodigo1.Text) == null)
                        {
                            MessageBox.Show("Não existe forma de pagamento para o código informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            txtCodigo1.Text = null;
                            cbbForma2.Text = null;
                            txtValor2.Text = null;
                            txtCodigo1.Select();
                        }
                        else
                        {
                            try
                            {
                                cbbForma2.Items.Clear();
                                if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                                {
                                    cbbForma2.Text = null;
                                    cbbForma2.Enabled = false;
                                }
                                else
                                {
                                    cbbForma2.Enabled = true;
                                    cbbForma2.Items.Add("");
                                    foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                                    {
                                        if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                                        {
                                            cbbForma2.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString() + "—" + dr["descricao"].ToString());
                                        }
                                        else
                                        {
                                            cbbForma2.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                                        }
                                    }
                                }
                                //
                                DataRow dr1 = bllVenda.Sel_Forma_Pagamento_Codigo_PDV(txtCodigo1.Text).Rows[0];
                                //
                                if (dr1["tipo"].ToString() == "NOTA PROMISSORIA")
                                {
                                    cbbForma2.Text = dr1["id_pagamento"].ToString() + "—" + dr1["tipo"].ToString() + "—" + dr1["descricao"].ToString();
                                }
                                else
                                {
                                    cbbForma2.Text = dr1["id_pagamento"].ToString() + "—" + dr1["tipo"].ToString();
                                }
                                cbbForma2.Select();
                                //
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do txtCodigo1.");
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do txtCodigo1.");
                                }
                                cbbForma2.Items.Clear();
                                cbbForma2.Text = null;
                                bllVenda._PDV_PesqForma_Tabela = null;
                            }
                        }
                    }
                    else
                    {
                        txtCodigo1.Text = null;
                        cbbForma2.Text = null;
                        txtValor2.Text = null;
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
                    txtCodigo1.Text = null;
                    cbbForma2.Text = null;
                    txtValor2.Text = null;
                    txtCodigo1.Select();
                }
            }
            txtCodigo1.BackColor = Color.White;
        }

        private void txtValor2_Enter(object sender, EventArgs e)
        {
            txtValor2.BackColor = Color.LightBlue;
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
                        txtValor2.Text = decimal.Parse(txtValor2.Text, new CultureInfo("pt-BR")).ToString("n2");
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
                        txtCodigo1.Text = null;
                        cbbForma2.Text = null;
                        txtValor2.Text = null;
                    }
                }
            }
            txtValor2.BackColor = Color.White;
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
                if (btnSalvar.Enabled == false)
                {
                    btnRemover2.Select();
                }
                else
                {
                    btnSalvar.Select();
                }
            }
        }

        private void cbbForma3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValor3.Select();
            }
        }

        private void txtDescricao3_Enter(object sender, EventArgs e)
        {
            txtCodigo2.BackColor = Color.LightBlue;
        }

        private void txtDescricao3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbForma3.Select();
            }
        }

        private void txtDescricao3_Leave(object sender, EventArgs e)
        {
            if (txtCodigo2.Text.Contains("'") || txtCodigo2.Text.Contains(";") || txtCodigo2.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodigo2.Text = null;
                txtCodigo2.Select();
            }
            else if (txtCodigo2.Text.Trim() == "0")
            {
                txtCodigo2.Text = null;
                cbbForma3.Text = null;
                txtValor3.Text = null;
            }
            else
            {
                try
                {
                    if (txtCodigo2.Text.Trim() != "")
                    {

                        if (bllVenda.Sel_Forma_Pagamento_Codigo_PDV(txtCodigo2.Text) == null)
                        {
                            MessageBox.Show("Não existe forma de pagamento para o código informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            txtCodigo2.Text = null;
                            cbbForma3.Text = null;
                            txtValor3.Text = null;
                            txtCodigo2.Select();
                        }
                        else
                        {
                            try
                            {
                                cbbForma3.Items.Clear();
                                if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                                {
                                    cbbForma3.Text = null;
                                    cbbForma3.Enabled = false;
                                }
                                else
                                {
                                    cbbForma3.Enabled = true;
                                    cbbForma3.Items.Add("");
                                    foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                                    {
                                        if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                                        {
                                            cbbForma3.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString() + "—" + dr["descricao"].ToString());
                                        }
                                        else
                                        {
                                            cbbForma3.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                                        }
                                    }
                                }
                                //
                                DataRow dr1 = bllVenda.Sel_Forma_Pagamento_Codigo_PDV(txtCodigo2.Text).Rows[0];
                                //
                                if (dr1["tipo"].ToString() == "NOTA PROMISSORIA")
                                {
                                    cbbForma3.Text = dr1["id_pagamento"].ToString() + "—" + dr1["tipo"].ToString() + "—" + dr1["descricao"].ToString();
                                }
                                else
                                {
                                    cbbForma3.Text = dr1["id_pagamento"].ToString() + "—" + dr1["tipo"].ToString();
                                }
                                //
                                cbbForma3.Select();
                                //
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do txtCodigo2.");
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do txtCodigo2.");
                                }
                                cbbForma3.Items.Clear();
                                cbbForma3.Text = null;
                                bllVenda._PDV_PesqForma_Tabela = null;
                            }
                        }
                    }
                    else
                    {
                        txtCodigo2.Text = null;
                        cbbForma3.Text = null;
                        txtValor3.Text = null;
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
                    txtCodigo2.Text = null;
                    cbbForma3.Text = null;
                    txtValor3.Text = null;
                    txtCodigo2.Select();
                }
            }
            txtCodigo2.BackColor = Color.White;
        }

        private void txtValor3_Enter(object sender, EventArgs e)
        {
            txtValor3.BackColor = Color.LightBlue;
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
                        txtCodigo2.Text = null;
                        cbbForma3.Text = null;
                        txtValor3.Text = null;
                    }
                }
            }
            txtValor3.BackColor = Color.White;
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
                if (btnSalvar.Enabled == false)
                {
                    btnRemover3.Select();
                }
                else
                {
                    btnSalvar.Select();
                }
            }
        }

        private void cbbForma4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValor4.Select();
            }
        }

        private void txtDescricao4_Enter(object sender, EventArgs e)
        {
            txtCodigo3.BackColor = Color.LightBlue;
        }

        private void txtDescricao4_Leave(object sender, EventArgs e)
        {
            if (txtCodigo3.Text.Contains("'") || txtCodigo3.Text.Contains(";") || txtCodigo3.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodigo3.Text = null;
                txtCodigo3.Select();
            }
            else if (txtCodigo3.Text.Trim() == "0")
            {
                txtCodigo3.Text = null;
                cbbForma4.Text = null;
                txtValor4.Text = null;
            }
            else
            {
                try
                {
                    if (txtCodigo3.Text.Trim() != "")
                    {

                        if (bllVenda.Sel_Forma_Pagamento_Codigo_PDV(txtCodigo3.Text) == null)
                        {
                            MessageBox.Show("Não existe forma de pagamento para o código informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            txtCodigo3.Text = null;
                            cbbForma4.Text = null;
                            txtValor4.Text = null;
                            txtCodigo3.Select();
                        }
                        else
                        {
                            try
                            {
                                cbbForma4.Items.Clear();
                                if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                                {
                                    cbbForma4.Text = null;
                                    cbbForma4.Enabled = false;
                                }
                                else
                                {
                                    cbbForma4.Enabled = true;
                                    cbbForma4.Items.Add("");
                                    foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                                    {
                                        if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                                        {
                                            cbbForma4.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString() + "—" + dr["descricao"].ToString());
                                        }
                                        else
                                        {
                                            cbbForma4.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                                        }
                                    }
                                }
                                //
                                DataRow dr1 = bllVenda.Sel_Forma_Pagamento_Codigo_PDV(txtCodigo3.Text).Rows[0];
                                //
                                if (dr1["tipo"].ToString() == "NOTA PROMISSORIA")
                                {
                                    cbbForma4.Text = dr1["id_pagamento"].ToString() + "—" + dr1["tipo"].ToString() + "—" + dr1["descricao"].ToString();
                                }
                                else
                                {
                                    cbbForma4.Text = dr1["id_pagamento"].ToString() + "—" + dr1["tipo"].ToString();
                                }
                                cbbForma4.Select();
                                //
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do txtCodigo3.");
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do txtCodigo3.");
                                }
                                cbbForma4.Items.Clear();
                                cbbForma4.Text = null;
                                bllVenda._PDV_PesqForma_Tabela = null;
                            }
                        }
                    }
                    else
                    {
                        txtCodigo3.Text = null;
                        cbbForma4.Text = null;
                        txtValor4.Text = null;
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
                    txtCodigo3.Text = null;
                    cbbForma4.Text = null;
                    txtValor4.Text = null;
                    txtCodigo3.Select();
                }
            }
            txtCodigo3.BackColor = Color.White;
        }

        private void txtDescricao4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbForma4.Select();
            }
        }

        private void txtValor4_Enter(object sender, EventArgs e)
        {
            txtValor4.BackColor = Color.LightBlue;
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
                        txtCodigo3.Text = null;
                        cbbForma4.Text = null;
                        txtValor4.Text = null;
                    }
                }
            }
            txtValor4.BackColor = Color.White;
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
                if (btnSalvar.Enabled == false)
                {
                    btnRemover4.Select();
                }
                else
                {
                    btnSalvar.Select();
                }
                btnSalvar.Select();
            }
        }

        private void txtDescricao2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbForma2.Select();
            }
        }

        private void btnProcurar2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma1_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma1_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForma3_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma3_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma4_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForma4_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForma1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForma2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForma3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForma4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmFormaPagamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
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

        private void btnProcurar1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(0, txtCodigo.Text, _Usuario, _Cod_PDV_Computador))
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
                                if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                                {
                                    cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString() + "—" + dr["descricao"].ToString());
                                }
                                else
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
                        this.Enabled = true;
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
            this.Enabled = true;
        }

        private void btnProcurar2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(0, txtCodigo1.Text, _Usuario, _Cod_PDV_Computador))
            {
                if (Pag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbForma2.Items.Clear();
                        if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                        {
                            cbbForma2.Text = null;
                            cbbForma2.Enabled = false;
                        }
                        else
                        {
                            cbbForma2.Enabled = true;
                            cbbForma2.Items.Add("");
                            foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                            {
                                if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                                {
                                    cbbForma2.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString() + "—" + dr["descricao"].ToString());
                                }
                                else
                                {
                                    cbbForma2.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                                }
                            }
                        }
                        string[] items = bllVenda._PDV_PesqForma_Tabela.Split('—');
                        txtCodigo1.Text = items[0];
                        cbbForma2.Text = bllVenda._PDV_PesqForma_Tabela;
                        cbbForma2.Select();
                    }
                    catch (Exception ex)
                    {
                        this.Enabled = true;
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
                        cbbForma2.Items.Clear();
                        cbbForma2.Text = null;
                        bllVenda._PDV_PesqForma_Tabela = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void btnProcurar3_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(0, txtCodigo2.Text, _Usuario, _Cod_PDV_Computador))
            {
                if (Pag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbForma3.Items.Clear();
                        if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                        {
                            cbbForma3.Text = null;
                            cbbForma3.Enabled = false;
                        }
                        else
                        {
                            cbbForma3.Enabled = true;
                            cbbForma3.Items.Add("");
                            foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                            {
                                if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                                {
                                    cbbForma3.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString() + "—" + dr["descricao"].ToString());
                                }
                                else
                                {
                                    cbbForma3.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                                }
                            }
                        }
                        string[] items = bllVenda._PDV_PesqForma_Tabela.Split('—');
                        txtCodigo2.Text = items[0];
                        cbbForma3.Text = bllVenda._PDV_PesqForma_Tabela;
                        cbbForma3.Select();
                    }
                    catch (Exception ex)
                    {
                        this.Enabled = true;
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
                        cbbForma3.Items.Clear();
                        cbbForma3.Text = null;
                        bllVenda._PDV_PesqForma_Tabela = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void btnProcurar4_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(0, txtCodigo3.Text, _Usuario, _Cod_PDV_Computador))
            {
                if (Pag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbForma4.Items.Clear();
                        if (bllVenda.Sel_Forma_Pagamento_PDV() == null)
                        {
                            cbbForma4.Text = null;
                            cbbForma4.Enabled = false;
                        }
                        else
                        {
                            cbbForma4.Enabled = true;
                            cbbForma4.Items.Add("");
                            foreach (DataRow dr in bllVenda.Sel_Forma_Pagamento_PDV().Rows)
                            {
                                if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                                {
                                    cbbForma4.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString() + "—" + dr["descricao"].ToString());
                                }
                                else
                                {
                                    cbbForma4.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                                }
                            }
                        }
                        string[] items = bllVenda._PDV_PesqForma_Tabela.Split('—');
                        txtCodigo3.Text = items[0];
                        cbbForma4.Text = bllVenda._PDV_PesqForma_Tabela;
                        cbbForma4.Select();
                    }
                    catch (Exception ex)
                    {
                        this.Enabled = true;
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
                        cbbForma4.Items.Clear();
                        cbbForma4.Text = null;
                        bllVenda._PDV_PesqForma_Tabela = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void btnRemover1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRemover1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRemover2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRemover2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRemover3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRemover3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRemover4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRemover4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRemover1_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = null;
            cbbForma1.Text = null;
            txtValor1.Text = null;
            lblValorPago.Enabled = true;
            txtValor1.Enabled = true;
            lblAsterisco3.Enabled = true;
        }

        private void btnRemover2_Click(object sender, EventArgs e)
        {
            txtCodigo1.Text = null;
            cbbForma2.Text = null;
            txtValor2.Text = null;
        }

        private void btnRemover3_Click(object sender, EventArgs e)
        {
            txtCodigo2.Text = null;
            cbbForma3.Text = null;
            txtValor3.Text = null;
        }

        private void btnRemover4_Click(object sender, EventArgs e)
        {
            txtCodigo3.Text = null;
            cbbForma4.Text = null;
            txtValor4.Text = null;
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
                if (cbbForma1.Text == "" || txtValor1.Text.Trim() == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Forma de Pagamento ] e [ Valor Pago (R$) ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    if (bllVenda._PDV_PesqCliente_Tabela != null & bllVenda._PDV_PesqCliente_Tabela != "Não identificado.")
                    {
                        string[] items = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                        //
                        if (bllClieCons.Sel_Situacao_Cliente_Bloqueado(items[0], "BLOQUEADO") == true || bllClieCons.Sel_Situacao_Cliente_Bloqueado(items[0], "INATIVO") == true)
                        {
                            MessageBox.Show("O Consumidor está com a situação cadastral [ Bloqueado ] ou \n[ Inativo ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }
                    //
                    DataRow dr = bllVenda.Sel_Ver_Forma_Pagamento_PDV(cbbForma1.Text).Rows[0];
                    //                   
                    this.DialogResult = DialogResult.None;
                    if ((cbbForma2.Text == "" & txtValor2.Text != "") || (cbbForma2.Text != "" & txtValor2.Text == ""))
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Forma de Pagamento 2 ] e [ Valor Pago 2 ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else if ((cbbForma3.Text == "" & txtValor3.Text != "") || (cbbForma3.Text != "" & txtValor3.Text == ""))
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Forma de Pagamento 3 ] e [ Valor Pago 3 ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else if ((cbbForma4.Text == "" & txtValor4.Text != "") || (cbbForma4.Text != "" & txtValor4.Text == ""))
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Forma de Pagamento 4 ] e [ Valor Pago 4 ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else if (dr["tipo"].ToString() != "NOTA PROMISSORIA" & lblDifTroco.Text.Contains("-"))
                    {
                        MessageBox.Show("Os valores informados são menores que o valor total a pagar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtValor1.Select();
                    }
                    else if (dr["tipo"].ToString() == "NOTA PROMISSORIA" & !lblDifTroco.Text.Contains("-"))
                    {
                        MessageBox.Show("O valor informado é maior ou igual que o valor total a pagar pois a forma de pagamento selecionada é \n[ Nota Promissória ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtValor1.Select();
                    }
                    else
                    {
                        if (txtDesconto.Text == "")
                        {
                            txtDesconto.Text = "0,00";
                        }
                        //
                        if (txtDescontoPorc.Text == "")
                        {
                            txtDescontoPorc.Text = "0,00";
                        }
                        //
                        if (txtAcrescimo.Text == "")
                        {
                            txtAcrescimo.Text = "0,00";
                        }
                        //
                        if (txtAcrescimoPorc.Text == "")
                        {
                            txtAcrescimoPorc.Text = "0,00";
                        }
                        //
                        if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                        {
                            if (bllClieCons.Sel_Cliente_Saldo_Creditor_Ver(bllVenda._PDV_PesqCliente_Tabela, lblDifTroco.Text.Replace("-", "")) == true)
                            {
                                if (txtValor1.Text != "" & txtValor1.Text != "0,00" & txtValor1.Text != "0")
                                {
                                    using (FrmTipoEntNotaPromissoria Ent = new FrmTipoEntNotaPromissoria(0, txtValor1.Text.Trim(), _Usuario, _Cod_PDV_Computador))
                                    {
                                        if (Ent.ShowDialog() == DialogResult.OK)
                                        {
                                            bllVenda._PDV_Forma_Pagamento.Add(cbbForma1.Text + "—" + txtValor1.Text.Trim());
                                            //
                                            bllVenda._Desconto_Porc = txtDescontoPorc.Text.Trim();
                                            bllVenda._Valor_Desconto = txtDesconto.Text.Trim();
                                            bllVenda._Acrescimo_Porc = txtAcrescimoPorc.Text.Trim();
                                            bllVenda._Valor_Acrescimo = txtAcrescimo.Text.Trim();
                                            bllVenda._Total = lblTotalSub.Text.Replace("R$ ", "");
                                            bllVenda._Total_Real = lblValorPagar.Text.Replace("R$ ", "");
                                            bllVenda._Troco = "0,00";
                                            bllVenda._Valor_Total_Pago = lblValorPagar.Text.Replace("R$ ", "");
                                            bllVenda._Valor_Entrada_Promissoria = txtValor1.Text.Trim();
                                            bllVenda._Nota_Promissoria = true;
                                            bllVenda._N_Parcela = dr["parcela"].ToString();
                                            //
                                            this.DialogResult = DialogResult.OK;
                                        }
                                    }
                                }
                                else
                                {
                                    bllVenda._PDV_Forma_Pagamento.Add(cbbForma1.Text + "—" + txtValor1.Text.Trim());
                                    //
                                    bllVenda._Desconto_Porc = txtDescontoPorc.Text.Trim();
                                    bllVenda._Valor_Desconto = txtDesconto.Text.Trim();
                                    bllVenda._Acrescimo_Porc = txtAcrescimoPorc.Text.Trim();
                                    bllVenda._Valor_Acrescimo = txtAcrescimo.Text.Trim();
                                    bllVenda._Total = lblTotalSub.Text.Replace("R$ ", "");
                                    bllVenda._Total_Real = lblValorPagar.Text.Replace("R$ ", "");
                                    bllVenda._Troco = "0,00";
                                    bllVenda._Valor_Total_Pago = lblValorPagar.Text.Replace("R$ ", "");
                                    bllVenda._Valor_Entrada_Promissoria = txtValor1.Text.Trim();
                                    bllVenda._Nota_Promissoria = true;
                                    bllVenda._N_Parcela = dr["parcela"].ToString();
                                    //
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                            else
                            {
                                DialogResult = MessageBox.Show("O Consumidor informado não tem saldo suficiente para vendas a prazo [ Nota Promissória ], deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    this.DialogResult = DialogResult.None;
                                    //
                                    if (bllUsuario.Sel_Permitir_Venda_N_Promissoria_S_Credito_Usuario(_Usuario) == true)
                                    {
                                        if (txtValor1.Text != "" & txtValor1.Text != "0,00" & txtValor1.Text != "0")
                                        {
                                            using (FrmTipoEntNotaPromissoria Ent = new FrmTipoEntNotaPromissoria(0, txtValor1.Text.Trim(), _Usuario, _Cod_PDV_Computador))
                                            {
                                                if (Ent.ShowDialog() == DialogResult.OK)
                                                {
                                                    bllVenda._PDV_Forma_Pagamento.Add(cbbForma1.Text + "—" + txtValor1.Text.Trim());
                                                    //
                                                    bllVenda._Desconto_Porc = txtDescontoPorc.Text.Trim();
                                                    bllVenda._Valor_Desconto = txtDesconto.Text.Trim();
                                                    bllVenda._Acrescimo_Porc = txtAcrescimoPorc.Text.Trim();
                                                    bllVenda._Valor_Acrescimo = txtAcrescimo.Text.Trim();
                                                    bllVenda._Total = lblTotalSub.Text.Replace("R$ ", "");
                                                    bllVenda._Total_Real = lblValorPagar.Text.Replace("R$ ", "");
                                                    bllVenda._Troco = "0,00";
                                                    bllVenda._Valor_Total_Pago = lblValorPagar.Text.Replace("R$ ", "");
                                                    bllVenda._Valor_Entrada_Promissoria = txtValor1.Text.Trim();
                                                    bllVenda._Nota_Promissoria = true;
                                                    bllVenda._N_Parcela = dr["parcela"].ToString();
                                                    //
                                                    this.DialogResult = DialogResult.OK;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            bllVenda._PDV_Forma_Pagamento.Add(cbbForma1.Text + "—" + txtValor1.Text.Trim());
                                            //
                                            bllVenda._Desconto_Porc = txtDescontoPorc.Text.Trim();
                                            bllVenda._Valor_Desconto = txtDesconto.Text.Trim();
                                            bllVenda._Acrescimo_Porc = txtAcrescimoPorc.Text.Trim();
                                            bllVenda._Valor_Acrescimo = txtAcrescimo.Text.Trim();
                                            bllVenda._Total = lblTotalSub.Text.Replace("R$ ", "");
                                            bllVenda._Total_Real = lblValorPagar.Text.Replace("R$ ", "");
                                            bllVenda._Troco = "0,00";
                                            bllVenda._Valor_Total_Pago = lblValorPagar.Text.Replace("R$ ", "");
                                            bllVenda._Valor_Entrada_Promissoria = txtValor1.Text.Trim();
                                            bllVenda._Nota_Promissoria = true;
                                            bllVenda._N_Parcela = dr["parcela"].ToString();
                                            //
                                            this.DialogResult = DialogResult.OK;
                                        }
                                    }
                                    else
                                    {
                                        using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(_Usuario, _Cod_PDV_Computador, "Permitir_Venda_N_Prom_S_Credito"))
                                        {
                                            if (Login.ShowDialog() == DialogResult.OK)
                                            {
                                                if (bllVenda._Permitir_Venda_N_Prom_S_Credito == 1)
                                                {
                                                    if (txtValor1.Text != "" & txtValor1.Text != "0,00" & txtValor1.Text != "0")
                                                    {
                                                        using (FrmTipoEntNotaPromissoria Ent = new FrmTipoEntNotaPromissoria(0, txtValor1.Text.Trim(), _Usuario, _Cod_PDV_Computador))
                                                        {
                                                            if (Ent.ShowDialog() == DialogResult.OK)
                                                            {
                                                                bllVenda._PDV_Forma_Pagamento.Add(cbbForma1.Text + "—" + txtValor1.Text.Trim());
                                                                //
                                                                bllVenda._Desconto_Porc = txtDescontoPorc.Text.Trim();
                                                                bllVenda._Valor_Desconto = txtDesconto.Text.Trim();
                                                                bllVenda._Acrescimo_Porc = txtAcrescimoPorc.Text.Trim();
                                                                bllVenda._Valor_Acrescimo = txtAcrescimo.Text.Trim();
                                                                bllVenda._Total = lblTotalSub.Text.Replace("R$ ", "");
                                                                bllVenda._Total_Real = lblValorPagar.Text.Replace("R$ ", "");
                                                                bllVenda._Troco = "0,00";
                                                                bllVenda._Valor_Total_Pago = lblValorPagar.Text.Replace("R$ ", "");
                                                                bllVenda._Valor_Entrada_Promissoria = txtValor1.Text.Trim();
                                                                bllVenda._Nota_Promissoria = true;
                                                                bllVenda._N_Parcela = dr["parcela"].ToString();
                                                                //
                                                                this.DialogResult = DialogResult.OK;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        bllVenda._PDV_Forma_Pagamento.Add(cbbForma1.Text + "—" + txtValor1.Text.Trim());
                                                        //
                                                        bllVenda._Desconto_Porc = txtDescontoPorc.Text.Trim();
                                                        bllVenda._Valor_Desconto = txtDesconto.Text.Trim();
                                                        bllVenda._Acrescimo_Porc = txtAcrescimoPorc.Text.Trim();
                                                        bllVenda._Valor_Acrescimo = txtAcrescimo.Text.Trim();
                                                        bllVenda._Total = lblTotalSub.Text.Replace("R$ ", "");
                                                        bllVenda._Total_Real = lblValorPagar.Text.Replace("R$ ", "");
                                                        bllVenda._Troco = "0,00";
                                                        bllVenda._Valor_Total_Pago = lblValorPagar.Text.Replace("R$ ", "");
                                                        bllVenda._Valor_Entrada_Promissoria = txtValor1.Text.Trim();
                                                        bllVenda._Nota_Promissoria = true;
                                                        bllVenda._N_Parcela = dr["parcela"].ToString();
                                                        //
                                                        this.DialogResult = DialogResult.OK;
                                                    }
                                                }
                                                else if (bllVenda._Permitir_Venda_N_Prom_S_Credito == 0)
                                                {
                                                    MessageBox.Show("O Usuário informado não possui permissão para permitir uma venda a prazo para Consumidor sem saldo disponível.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    this.DialogResult = DialogResult.None;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                        }
                        else
                        {
                            if (dr["tipo"].ToString() == "PIX")
                            {
                                if (bllPSP.Sel_PSP_QRDinamico(0) != null)
                                {
                                    DialogResult = MessageBox.Show("Deseja exibir o QR Code Estático para pagamento?", "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;
                                        //
                                        using (FrmGerarQRCodePIX Pix = new FrmGerarQRCodePIX(1, txtValor1.Text, bllVenda._PDV_PesqCliente_Tabela, _Usuario, _Cod_PDV_Computador))
                                        {
                                            if (Pix.ShowDialog() == DialogResult.Abort)
                                            {
                                                DialogResult = MessageBox.Show("O pagamento foi concluído?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                                        }
                                    }
                                    else if(DialogResult == DialogResult.No)
                                    {
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                        return;
                                    }
                                }
                            }
                            //
                            bllVenda._PDV_Forma_Pagamento.Add(cbbForma1.Text + "—" + txtValor1.Text.Trim());
                            //
                            if (cbbForma2.Text != "" & txtValor2.Text.Trim() != "")
                            {
                                bllVenda._PDV_Forma_Pagamento.Add(cbbForma2.Text + "—" + txtValor2.Text.Trim());
                                //
                                dr = bllVenda.Sel_Ver_Forma_Pagamento_PDV(cbbForma2.Text).Rows[0];

                                if (dr["tipo"].ToString() == "PIX")
                                {
                                    if (bllPSP.Sel_PSP_QRDinamico(0) != null)
                                    {
                                        DialogResult = MessageBox.Show("Deseja exibir o QR Code Estático para pagamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (DialogResult == DialogResult.Yes)
                                        {
                                            this.DialogResult = DialogResult.None;
                                            //
                                            using (FrmGerarQRCodePIX Pix = new FrmGerarQRCodePIX(1, txtValor2.Text, bllVenda._PDV_PesqCliente_Tabela, _Usuario, _Cod_PDV_Computador))
                                            {
                                                if (Pix.ShowDialog() == DialogResult.Abort)
                                                {
                                                    DialogResult = MessageBox.Show("O pagamento foi concluído?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                                            }
                                        }
                                        else if (DialogResult == DialogResult.No)
                                        {
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.None;
                                            return;
                                        }
                                    }
                                }
                            }
                            //
                            if (cbbForma3.Text != "" & txtValor3.Text.Trim() != "")
                            {
                                bllVenda._PDV_Forma_Pagamento.Add(cbbForma3.Text + "—" + txtValor3.Text.Trim());
                                //
                                dr = bllVenda.Sel_Ver_Forma_Pagamento_PDV(cbbForma3.Text).Rows[0];
                                //
                                if (dr["tipo"].ToString() == "PIX")
                                {
                                    if (bllPSP.Sel_PSP_QRDinamico(0) != null)
                                    {
                                        DialogResult = MessageBox.Show("Deseja exibir o QR Code Estático para pagamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (DialogResult == DialogResult.Yes)
                                        {
                                            this.DialogResult = DialogResult.None;
                                            //
                                            using (FrmGerarQRCodePIX Pix = new FrmGerarQRCodePIX(1, txtValor3.Text, bllVenda._PDV_PesqCliente_Tabela, _Usuario, _Cod_PDV_Computador))
                                            {
                                                if (Pix.ShowDialog() == DialogResult.Abort)
                                                {
                                                    DialogResult = MessageBox.Show("O pagamento foi concluído?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                                            }
                                        }
                                        else if (DialogResult == DialogResult.No)
                                        {
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.None;
                                            return;
                                        }
                                    }
                                }
                            }
                            //
                            if (cbbForma4.Text != "" & txtValor4.Text.Trim() != "")
                            {
                                bllVenda._PDV_Forma_Pagamento.Add(cbbForma4.Text + "—" + txtValor4.Text.Trim());
                                //
                                dr = bllVenda.Sel_Ver_Forma_Pagamento_PDV(cbbForma4.Text).Rows[0];
                                //
                                if (dr["tipo"].ToString() == "PIX")
                                {
                                    if (bllPSP.Sel_PSP_QRDinamico(0) != null)
                                    {
                                        DialogResult = MessageBox.Show("Deseja exibir o QR Code Estático para pagamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (DialogResult == DialogResult.Yes)
                                        {
                                            this.DialogResult = DialogResult.None;
                                            //
                                            using (FrmGerarQRCodePIX Pix = new FrmGerarQRCodePIX(1, txtValor4.Text, bllVenda._PDV_PesqCliente_Tabela, _Usuario, _Cod_PDV_Computador))
                                            {
                                                if (Pix.ShowDialog() == DialogResult.Abort)
                                                {
                                                    DialogResult = MessageBox.Show("O pagamento foi concluído?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                                            }
                                        }
                                        else if (DialogResult == DialogResult.No)
                                        {
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.None;
                                            return;
                                        }
                                    }
                                }
                            }
                            //
                            bllVenda._Desconto_Porc = txtDescontoPorc.Text.Trim();
                            bllVenda._Valor_Desconto = txtDesconto.Text.Trim();
                            bllVenda._Acrescimo_Porc = txtAcrescimoPorc.Text.Trim();
                            bllVenda._Valor_Acrescimo = txtAcrescimo.Text.Trim();
                            bllVenda._Total = lblTotalSub.Text.Replace("R$ ", "");
                            bllVenda._Total_Real = lblValorPagar.Text.Replace("R$ ", "");
                            bllVenda._Troco = lblDifTroco.Text.Replace("R$ ", "");
                            bllVenda._Valor_Total_Pago = _Valor_Total_Pago.ToString();
                            bllVenda._Nota_Promissoria = false;
                            bllVenda._N_Parcela = null;
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                //
                bllVenda._Cod_Nota_Promissoria_Plano = null;
                bllVenda._Entrada_Plano = null;
                bllVenda._Parcela_Plano = null;
                bllVenda._Multa_Plano = null;
                bllVenda._Juros_Mora_Plano = null;
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
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVoltar_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void txtValor1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Nota_Promissoria == true)
                {
                    lbl2.Enabled = false;
                    txtCodigo1.Enabled = false;
                    cbbForma2.Enabled = false;
                    btnProcurar2.Enabled = false;
                    txtValor2.Enabled = false;
                    btnProcurar2.Enabled = false;
                    btnRemover2.Enabled = false;
                    txtCodigo1.Text = null;
                    cbbForma2.Text = null;
                    txtValor2.Text = null;
                    //
                    lbl3.Enabled = false;
                    txtCodigo2.Enabled = false;
                    cbbForma3.Enabled = false;
                    btnProcurar3.Enabled = false;
                    txtValor3.Enabled = false;
                    btnProcurar3.Enabled = false;
                    btnRemover3.Enabled = false;
                    txtCodigo2.Text = null;
                    cbbForma3.Text = null;
                    txtValor3.Text = null;
                    //
                    lbl4.Enabled = false;
                    txtCodigo3.Enabled = false;
                    cbbForma4.Enabled = false;
                    btnProcurar4.Enabled = false;
                    txtValor4.Enabled = false;
                    btnProcurar4.Enabled = false;
                    btnRemover4.Enabled = false;
                    txtCodigo3.Text = null;
                    cbbForma4.Text = null;
                    txtValor4.Text = null;
                    //
                    decimal valor_Pago_1;
                    //
                    if (txtValor1.Text == "")
                    {
                        btnSalvar.Enabled = false;
                        valor_Pago_1 = 0;
                    }
                    else
                    {
                        btnSalvar.Enabled = true;
                        valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                    }
                    //
                    _Valor_Total_Pago = Convert.ToDecimal(valor_Pago_1);
                    //
                    if (_Valor_Total_Pago < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                    {
                        txtValor1.ForeColor = Color.Red;
                        txtValor2.ForeColor = Color.Red;
                        txtValor3.ForeColor = Color.Red;
                        txtValor4.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtValor1.ForeColor = Color.Blue;
                        txtValor2.ForeColor = Color.Blue;
                        txtValor3.ForeColor = Color.Blue;
                        txtValor4.ForeColor = Color.Blue;
                    }
                    //
                    _Valor_Diferenca_Troco = _Valor_Total_Pago - Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", ""));
                    if (_Valor_Total_Pago > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                    {
                        lblDT.ForeColor = Color.Blue;
                        lblDT.Text = "Troco (R$):";
                        lblDifTroco.ForeColor = Color.Blue;
                        lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        lblDifTroco.ForeColor = Color.Red;
                        lblDT.ForeColor = Color.Red;
                        lblDT.Text = "Diferença (R$):";
                        lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
                else
                {
                    decimal valor_Pago_1;
                    decimal valor_Pago_2;
                    decimal valor_Pago_3;
                    decimal valor_Pago_4;
                    //
                    if (txtValor1.Text == "")
                    {
                        btnSalvar.Enabled = false;
                        valor_Pago_1 = 0;
                    }
                    else
                    {
                        btnSalvar.Enabled = true;
                        valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                    }

                    if (txtValor2.Text == "")
                    {
                        valor_Pago_2 = 0;
                    }
                    else
                    {
                        valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                    }

                    if (txtValor3.Text == "")
                    {
                        valor_Pago_3 = 0;
                    }
                    else
                    {
                        valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                    }

                    if (txtValor4.Text == "")
                    {
                        valor_Pago_4 = 0;
                    }
                    else
                    {
                        valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                    }
                    //
                    if (valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                    {
                        lbl2.Enabled = true;
                        txtCodigo1.Enabled = true;
                        btnProcurar2.Enabled = true;
                        cbbForma2.Enabled = true;
                        txtValor2.Enabled = true;
                        btnProcurar2.Enabled = true;
                        btnRemover2.Enabled = true;
                    }
                    else
                    {
                        lbl2.Enabled = false;
                        txtCodigo1.Enabled = false;
                        cbbForma2.Enabled = false;
                        btnProcurar2.Enabled = false;
                        txtValor2.Enabled = false;
                        btnProcurar2.Enabled = false;
                        btnRemover2.Enabled = false;
                        txtCodigo1.Text = null;
                        cbbForma2.Text = null;
                        txtValor2.Text = null;
                    }
                    //                            
                    _Valor_Total_Pago = Convert.ToDecimal(valor_Pago_1) + Convert.ToDecimal(valor_Pago_2) + Convert.ToDecimal(valor_Pago_3) + Convert.ToDecimal(valor_Pago_4);
                    //
                    if (_Valor_Total_Pago < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                    {
                        txtValor1.ForeColor = Color.Red;
                        txtValor2.ForeColor = Color.Red;
                        txtValor3.ForeColor = Color.Red;
                        txtValor4.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtValor1.ForeColor = Color.Blue;
                        txtValor2.ForeColor = Color.Blue;
                        txtValor3.ForeColor = Color.Blue;
                        txtValor4.ForeColor = Color.Blue;
                    }
                    //
                    _Valor_Diferenca_Troco = _Valor_Total_Pago - Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", ""));
                    if (_Valor_Total_Pago > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                    {
                        lblDT.ForeColor = Color.Blue;
                        lblDT.Text = "Troco (R$):";
                        lblDifTroco.ForeColor = Color.Blue;
                        lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        lblDifTroco.ForeColor = Color.Red;
                        lblDT.ForeColor = Color.Red;
                        lblDT.Text = "Diferença (R$):";
                        lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }

                if (txtValor1.Text.Trim() == "")
                {
                    lbl2.Enabled = false;
                    txtCodigo1.Enabled = false;
                    cbbForma2.Enabled = false;
                    btnProcurar2.Enabled = false;
                    txtValor2.Enabled = false;
                    btnProcurar2.Enabled = false;
                    btnRemover2.Enabled = false;
                    txtCodigo1.Text = null;
                    cbbForma2.Text = null;
                    txtValor2.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor1.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtValor2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal valor_Pago_1;
                decimal valor_Pago_2;
                decimal valor_Pago_3;
                decimal valor_Pago_4;
                //
                if (txtValor2.Text.Trim() != "")
                {
                    if (txtValor1.Text == "")
                    {
                        valor_Pago_1 = 0;
                    }
                    else
                    {
                        valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                    }

                    if (txtValor2.Text == "")
                    {
                        valor_Pago_2 = 0;
                    }
                    else
                    {
                        valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                    }

                    if (txtValor3.Text == "")
                    {
                        valor_Pago_3 = 0;
                    }
                    else
                    {
                        valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                    }

                    if (txtValor4.Text == "")
                    {
                        valor_Pago_4 = 0;
                    }
                    else
                    {
                        valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                    }
                    //
                    if (valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                    {
                        lbl3.Enabled = true;
                        txtCodigo2.Enabled = true;
                        btnProcurar3.Enabled = true;
                        cbbForma3.Enabled = true;
                        txtValor3.Enabled = true;
                        btnProcurar3.Enabled = true;
                        btnRemover3.Enabled = true;
                    }
                    else
                    {
                        lbl3.Enabled = false;
                        txtCodigo2.Enabled = false;
                        cbbForma3.Enabled = false;
                        btnProcurar3.Enabled = false;
                        txtValor3.Enabled = false;
                        btnProcurar3.Enabled = false;
                        btnRemover3.Enabled = false;
                        txtCodigo2.Text = null;
                        cbbForma3.Text = null;
                        txtValor3.Text = null;
                    }
                }
                else
                {
                    lbl3.Enabled = false;
                    txtCodigo2.Enabled = false;
                    cbbForma3.Enabled = false;
                    btnProcurar3.Enabled = false;
                    txtValor3.Enabled = false;
                    btnProcurar3.Enabled = false;
                    btnRemover3.Enabled = false;
                    txtCodigo2.Text = null;
                    cbbForma3.Text = null;
                    txtValor3.Text = null;
                }
                //
                if (txtValor1.Text == "")
                {
                    valor_Pago_1 = 0;
                }
                else
                {
                    valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                }
                //
                if (txtValor2.Text == "")
                {
                    valor_Pago_2 = 0;
                }
                else
                {
                    valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                }
                //
                if (txtValor3.Text == "")
                {
                    valor_Pago_3 = 0;
                }
                else
                {
                    valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                }
                //
                if (txtValor4.Text == "")
                {
                    valor_Pago_4 = 0;
                }
                else
                {
                    valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                }
                //
                _Valor_Total_Pago = Convert.ToDecimal(valor_Pago_1) + Convert.ToDecimal(valor_Pago_2) + Convert.ToDecimal(valor_Pago_3) + Convert.ToDecimal(valor_Pago_4);
                //
                if (_Valor_Total_Pago < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    txtValor1.ForeColor = Color.Red;
                    txtValor2.ForeColor = Color.Red;
                    txtValor3.ForeColor = Color.Red;
                    txtValor4.ForeColor = Color.Red;
                }
                else
                {
                    txtValor1.ForeColor = Color.Blue;
                    txtValor2.ForeColor = Color.Blue;
                    txtValor3.ForeColor = Color.Blue;
                    txtValor4.ForeColor = Color.Blue;
                }
                //
                _Valor_Diferenca_Troco = _Valor_Total_Pago - Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", ""));
                if (_Valor_Total_Pago > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    lblDT.ForeColor = Color.Blue;
                    lblDT.Text = "Troco (R$):";
                    lblDifTroco.ForeColor = Color.Blue;
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblDifTroco.ForeColor = Color.Red;
                    lblDT.ForeColor = Color.Red;
                    lblDT.Text = "Diferença (R$):";
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor1.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtValor3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                decimal valor_Pago_1;
                decimal valor_Pago_2;
                decimal valor_Pago_3;
                decimal valor_Pago_4;
                //
                if (txtValor3.Text.Trim() != "")
                {
                    if (txtValor1.Text == "")
                    {
                        valor_Pago_1 = 0;
                    }
                    else
                    {
                        valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                    }

                    if (txtValor2.Text == "")
                    {
                        valor_Pago_2 = 0;
                    }
                    else
                    {
                        valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                    }

                    if (txtValor3.Text == "")
                    {
                        valor_Pago_3 = 0;
                    }
                    else
                    {
                        valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                    }

                    if (txtValor4.Text == "")
                    {
                        valor_Pago_4 = 0;
                    }
                    else
                    {
                        valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                    }
                    //
                    if (valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                    {
                        lbl4.Enabled = true;
                        txtCodigo3.Enabled = true;
                        btnProcurar4.Enabled = true;
                        cbbForma4.Enabled = true;
                        txtValor4.Enabled = true;
                        btnProcurar4.Enabled = true;
                        btnRemover4.Enabled = true;
                    }
                    else
                    {
                        lbl4.Enabled = false;
                        txtCodigo3.Enabled = false;
                        cbbForma4.Enabled = false;
                        btnProcurar4.Enabled = false;
                        txtValor4.Enabled = false;
                        btnProcurar4.Enabled = false;
                        btnRemover4.Enabled = false;
                        txtCodigo3.Text = null;
                        cbbForma4.Text = null;
                        txtValor4.Text = null;
                    }
                }
                else
                {
                    lbl4.Enabled = false;
                    txtCodigo3.Enabled = false;
                    cbbForma4.Enabled = false;
                    btnProcurar4.Enabled = false;
                    txtValor4.Enabled = false;
                    btnProcurar4.Enabled = false;
                    btnRemover4.Enabled = false;
                    txtCodigo3.Text = null;
                    cbbForma4.Text = null;
                    txtValor4.Text = null;
                }
                //
                if (txtValor1.Text == "")
                {
                    valor_Pago_1 = 0;
                }
                else
                {
                    valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                }

                if (txtValor2.Text == "")
                {
                    valor_Pago_2 = 0;
                }
                else
                {
                    valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                }

                if (txtValor3.Text == "")
                {
                    valor_Pago_3 = 0;
                }
                else
                {
                    valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                }

                if (txtValor4.Text == "")
                {
                    valor_Pago_4 = 0;
                }
                else
                {
                    valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                }
                //
                _Valor_Total_Pago = Convert.ToDecimal(valor_Pago_1) + Convert.ToDecimal(valor_Pago_2) + Convert.ToDecimal(valor_Pago_3) + Convert.ToDecimal(valor_Pago_4);
                //
                if (_Valor_Total_Pago < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    txtValor1.ForeColor = Color.Red;
                    txtValor2.ForeColor = Color.Red;
                    txtValor3.ForeColor = Color.Red;
                    txtValor4.ForeColor = Color.Red;
                }
                else
                {
                    txtValor1.ForeColor = Color.Blue;
                    txtValor2.ForeColor = Color.Blue;
                    txtValor3.ForeColor = Color.Blue;
                    txtValor4.ForeColor = Color.Blue;
                }
                //
                _Valor_Diferenca_Troco = _Valor_Total_Pago - Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", ""));
                if (_Valor_Total_Pago > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    lblDT.ForeColor = Color.Blue;
                    lblDT.Text = "Troco (R$):";
                    lblDifTroco.ForeColor = Color.Blue;
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblDifTroco.ForeColor = Color.Red;
                    lblDT.ForeColor = Color.Red;
                    lblDT.Text = "Diferença (R$):";
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento textchanged da caixa de texto txtValor1.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtValor4_TextChanged(object sender, EventArgs e)
        {
            try
            {

                decimal valor_Pago_1;
                decimal valor_Pago_2;
                decimal valor_Pago_3;
                decimal valor_Pago_4;
                //
                if (txtValor1.Text == "")
                {
                    valor_Pago_1 = 0;
                }
                else
                {
                    valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                }

                if (txtValor2.Text == "")
                {
                    valor_Pago_2 = 0;
                }
                else
                {
                    valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                }

                if (txtValor3.Text == "")
                {
                    valor_Pago_3 = 0;
                }
                else
                {
                    valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                }

                if (txtValor4.Text == "")
                {
                    valor_Pago_4 = 0;
                }
                else
                {
                    valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                }
                _Valor_Total_Pago = Convert.ToDecimal(valor_Pago_1) + Convert.ToDecimal(valor_Pago_2) + Convert.ToDecimal(valor_Pago_3) + Convert.ToDecimal(valor_Pago_4);
                //
                if (_Valor_Total_Pago < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    txtValor1.ForeColor = Color.Red;
                    txtValor2.ForeColor = Color.Red;
                    txtValor3.ForeColor = Color.Red;
                    txtValor4.ForeColor = Color.Red;
                }
                else
                {
                    txtValor1.ForeColor = Color.Blue;
                    txtValor2.ForeColor = Color.Blue;
                    txtValor3.ForeColor = Color.Blue;
                    txtValor4.ForeColor = Color.Blue;
                }
                //
                _Valor_Diferenca_Troco = _Valor_Total_Pago - Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", ""));
                if (_Valor_Total_Pago > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                {
                    lblDT.ForeColor = Color.Blue;
                    lblDT.Text = "Troco (R$):";
                    lblDifTroco.ForeColor = Color.Blue;
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    lblDifTroco.ForeColor = Color.Red;
                    lblDT.ForeColor = Color.Red;
                    lblDT.Text = "Diferença (R$):";
                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                }

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
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Descontos e Acréscimos: Informe desconto e acréscimo caso seja necessário.\n\n2 - Formas de Pagamento: Informe as formas de pagamento nas 4 opções disponíveis. A forma de pagamento 1 é obrigatória.\n\n3 - As formas Crédito da Loja e Nota Promissória devem ser ambas informadas na forma de pagamento 1.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmFormaPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFormaPagamento foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmFormaPagamento foi finalizado.");
                }
                //
                bllVenda._Cod_Nota_Promissoria_Plano = null;
                bllVenda._Entrada_Plano = null;
                bllVenda._Parcela_Plano = null;
                bllVenda._Multa_Plano = null;
                bllVenda._Juros_Mora_Plano = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmFormaPagamento.");
                }
            }
        }

        private void cbbForma2_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbForma2_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTotal1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblTotalSub.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
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
                txtValor1.Text = null;
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
                            txtValor1.Text = null;
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
                                        if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                                        {
                                            cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString() + "—" + dr["descricao"].ToString());

                                        }
                                        else
                                        {
                                            cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                                        }
                                    }
                                }
                                //
                                DataRow dr1 = bllVenda.Sel_Forma_Pagamento_Codigo_PDV(txtCodigo.Text).Rows[0];
                                //
                                if (dr1["tipo"].ToString() == "NOTA PROMISSORIA")
                                {
                                    cbbForma1.Text = dr1["id_pagamento"].ToString() + "—" + dr1["tipo"].ToString() + "—" + dr1["descricao"].ToString();
                                }
                                else
                                {
                                    cbbForma1.Text = dr1["id_pagamento"].ToString() + "—" + dr1["tipo"].ToString();
                                }
                                //
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
                        txtValor1.Text = null;
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
                    txtValor1.Text = null;
                    txtCodigo.Select();
                }
            }
            txtCodigo.BackColor = Color.White;
        }

        private void lblValorPagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total a Pagar (R$): " + lblValorPagar.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblDifTroco_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblDT.Text + " " + lblDifTroco.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void lblDifTroco_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblDifTroco_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbForma1.Text != "")
                {
                    string[] items = cbbForma1.Text.Split('—');
                    txtCodigo.Text = items[0];

                    DataRow dr = bllVenda.Sel_Ver_Forma_Pagamento_PDV(cbbForma1.Text).Rows[0];
                    //
                    if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                    {
                        if (bllVenda._PDV_PesqCliente_Tabela == null)
                        {
                            MessageBox.Show("É necessário identificar o Consumidor para realizar pagamento em [ Nota Promissória ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            cbbForma1.Text = null;
                            txtCodigo.Text = null;
                        }
                        else
                        {
                            string[] item = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                            //
                            if (item[0] == "0")
                            {
                                MessageBox.Show("O Consumidor informado não está cadastrado no sistema. Para realizar pagamento em [ Nota Promissória ] é necessário que o consumidor esteja cadastrado no sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbForma1.Text = null;
                                txtCodigo.Text = null;
                                //
                                return;
                            }
                            //
                            _Nota_Promissoria = true;
                            //
                            dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma1.Text).Rows[0];
                            //                                
                            if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                            {
                                DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                    //
                                    txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                    //
                                    txtAcrescimoPorc_Leave(sender, e);
                                    //
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                            {
                                DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                    //
                                    txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                    //
                                    txtDescontoPorc_Leave(sender, e);
                                    //
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            dr = bllVenda.Sel_Forma_Pagamento_Promissoria_P_Entrada(items[0]).Rows[0];
                            //
                            if (dr["entrada_porc"].ToString() == "0")
                            {
                                txtValor1.ReadOnly = false;
                                //
                                txtValor1_TextChanged(sender, e);
                                //
                                txtValor1.Text = "0,00";
                            }
                            else
                            {
                                txtValor1.ReadOnly = true;
                                txtValor1.Text = bllVenda.Calculo_Valor_Entrada_Porc_PDV(lblValorPagar.Text.Replace("R$ ", ""), dr["entrada_porc"].ToString());
                                //
                                decimal valor_Pago_1;
                                if (txtValor1.Text == "")
                                {
                                    valor_Pago_1 = 0;
                                }
                                else
                                {
                                    valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                                }
                                //                              
                                _Valor_Total_Pago = Convert.ToDecimal(valor_Pago_1);
                                //
                                if (_Valor_Total_Pago < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                                {
                                    txtValor1.ForeColor = Color.Red;
                                    txtValor2.ForeColor = Color.Red;
                                    txtValor3.ForeColor = Color.Red;
                                    txtValor4.ForeColor = Color.Red;
                                }
                                else
                                {
                                    txtValor1.ForeColor = Color.Blue;
                                    txtValor2.ForeColor = Color.Blue;
                                    txtValor3.ForeColor = Color.Blue;
                                    txtValor4.ForeColor = Color.Blue;
                                }
                                //
                                _Valor_Diferenca_Troco = _Valor_Total_Pago - Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", ""));
                                if (_Valor_Total_Pago > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                                {
                                    lblDT.ForeColor = Color.Blue;
                                    lblDT.Text = "Troco (R$):";
                                    lblDifTroco.ForeColor = Color.Blue;
                                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                                }
                                else
                                {
                                    lblDifTroco.ForeColor = Color.Red;
                                    lblDT.ForeColor = Color.Red;
                                    lblDT.Text = "Diferença (R$):";
                                    lblDifTroco.Text = Convert.ToDecimal(_Valor_Diferenca_Troco).ToString("n2", new CultureInfo("pt-BR"));
                                }
                                //
                                txtValor1_TextChanged(sender, e);
                            }
                            //
                            lbl2.Enabled = false;
                            txtCodigo1.Enabled = false;
                            cbbForma2.Enabled = false;
                            btnProcurar2.Enabled = false;
                            txtValor2.Enabled = false;
                            btnProcurar2.Enabled = false;
                            btnRemover2.Enabled = false;
                            txtCodigo1.Text = null;
                            cbbForma2.Text = null;
                            txtValor2.Text = null;
                            //
                            lbl3.Enabled = false;
                            txtCodigo2.Enabled = false;
                            cbbForma3.Enabled = false;
                            btnProcurar3.Enabled = false;
                            txtValor3.Enabled = false;
                            btnProcurar3.Enabled = false;
                            btnRemover3.Enabled = false;
                            txtCodigo2.Text = null;
                            cbbForma3.Text = null;
                            txtValor3.Text = null;
                            //
                            lbl4.Enabled = false;
                            txtCodigo3.Enabled = false;
                            cbbForma4.Enabled = false;
                            btnProcurar4.Enabled = false;
                            txtValor4.Enabled = false;
                            btnProcurar4.Enabled = false;
                            btnRemover4.Enabled = false;
                            txtCodigo3.Text = null;
                            cbbForma4.Text = null;
                            txtValor4.Text = null;
                        }
                        //
                        txtValor1.Select();
                    }
                    else if (dr["tipo"].ToString() == "CREDITO LOJA")
                    {
                        if (bllVenda._PDV_PesqCliente_Tabela == null)
                        {
                            MessageBox.Show("É necessário identificar o Consumidor para realizar pagamento em Crédito Loja.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            cbbForma1.Text = null;
                            txtCodigo.Text = null;
                        }
                        else
                        {
                            string[] item = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                            //
                            if (item[0] == "0")
                            {
                                MessageBox.Show("O Consumidor informado não está cadastrado no sistema. Para realizar pagamento em Crédito da Loja é necessário que o consumidor esteja cadastrado no sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbForma1.Text = null;
                                txtCodigo.Text = null;
                                //
                                return;
                            }
                            //
                            using (FrmValorCreditoLoja Cred = new FrmValorCreditoLoja(bllVenda._PDV_PesqCliente_Tabela, _Usuario, _Cod_PDV_Computador))
                            {
                                if (Cred.ShowDialog() == DialogResult.OK)
                                {
                                    if (Convert.ToDecimal(bllVenda._Valor_Credito_Loja) > Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                                    {
                                        MessageBox.Show("O valor informado é maior que o valor da venda, será acrescentado apenas o valor corresponde ao total a pagar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.DialogResult = DialogResult.None;
                                        //
                                        txtValor1.Text = lblValorPagar.Text.Replace("R$ ", "");
                                    }
                                    else
                                    {
                                        txtValor1.Text = bllVenda._Valor_Credito_Loja;
                                    }
                                }
                                else
                                {
                                    cbbForma1.Text = null;
                                    txtCodigo.Text = null;
                                    return;
                                }
                            }
                            //
                            _Nota_Promissoria = false;
                            //
                            dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma1.Text).Rows[0];
                            //
                            if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                            {
                                DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                    //
                                    txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                    //
                                    txtAcrescimoPorc_Leave(sender, e);
                                    //
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                            {
                                DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                    //
                                    txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                    //
                                    txtDescontoPorc_Leave(sender, e);
                                    //
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            txtValor1.ReadOnly = true;
                            //
                            decimal valor_Pago_1;
                            decimal valor_Pago_2;
                            decimal valor_Pago_3;
                            decimal valor_Pago_4;
                            //
                            if (txtValor1.Text == "")
                            {
                                valor_Pago_1 = 0;
                            }
                            else
                            {
                                valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                            }

                            if (txtValor2.Text == "")
                            {
                                valor_Pago_2 = 0;
                            }
                            else
                            {
                                valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                            }
                            if (txtValor3.Text == "")
                            {
                                valor_Pago_3 = 0;
                            }
                            else
                            {
                                valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                            }

                            if (txtValor4.Text == "")
                            {
                                valor_Pago_4 = 0;
                            }
                            else
                            {
                                valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                            }
                            //
                            if (txtValor1.Text != "" & valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                            {
                                lbl2.Enabled = true;
                                txtCodigo1.Enabled = true;
                                cbbForma2.Enabled = true;
                                btnProcurar2.Enabled = true;
                                txtValor2.Enabled = true;
                                btnProcurar2.Enabled = true;
                                btnRemover2.Enabled = true;
                            }
                            //
                            txtValor1_TextChanged(sender, e);
                            //
                            txtValor1.Select();
                        }
                    }
                    else if (dr["tipo"].ToString() == "PIX")
                    {
                        _Nota_Promissoria = false;
                        txtValor1.ReadOnly = false;
                        //
                        dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma1.Text).Rows[0];
                        //
                        if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                //
                                txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtAcrescimoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                //
                                txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtDescontoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        decimal valor_Pago_1;
                        decimal valor_Pago_2;
                        decimal valor_Pago_3;
                        decimal valor_Pago_4;
                        //
                        if (txtValor1.Text == "")
                        {
                            valor_Pago_1 = 0;
                        }
                        else
                        {
                            valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                        }

                        if (txtValor2.Text == "")
                        {
                            valor_Pago_2 = 0;
                        }
                        else
                        {
                            valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                        }

                        if (txtValor3.Text == "")
                        {
                            valor_Pago_3 = 0;
                        }
                        else
                        {
                            valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                        }

                        if (txtValor4.Text == "")
                        {
                            valor_Pago_4 = 0;
                        }
                        else
                        {
                            valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                        }
                        //
                        if (txtValor1.Text != "" & valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                        {
                            lbl2.Enabled = true;
                            txtCodigo1.Enabled = true;
                            cbbForma2.Enabled = true;
                            btnProcurar2.Enabled = true;
                            txtValor2.Enabled = true;
                            btnProcurar2.Enabled = true;
                            btnRemover2.Enabled = true;
                        }
                        //
                        txtValor1_TextChanged(sender, e);
                        //
                        if (txtValor1.Text == "")
                        {
                            txtValor1.Text = lblDifTroco.Text.Replace("-", "");
                        }
                        //
                        txtValor1.Select();
                    }
                    else if (dr["tipo"].ToString() == "CHEQUE")
                    {
                        if (bllVenda._PDV_PesqCliente_Tabela == null)
                        {
                            MessageBox.Show("É necessário identificar o Consumidor para realizar pagamento em Cheque.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            cbbForma1.Text = null;
                            txtCodigo.Text = null;
                        }
                        else
                        {
                            string[] item = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                            //
                            if (item[0] == "0")
                            {
                                MessageBox.Show("O Consumidor informado não está cadastrado no sistema. Para realizar pagamento em Cheque é necessário que o consumidor esteja cadastrado no sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbForma1.Text = null;
                                txtCodigo.Text = null;
                                //
                                return;
                            }
                            //
                            using (FrmContCheque Cred = new FrmContCheque(bllVenda._PDV_PesqCliente_Tabela, _Usuario, _Cod_PDV_Computador))
                            {
                                if (Cred.ShowDialog() == DialogResult.OK)
                                {
                                    txtValor1.Text = bllVenda._Valor_Cheque;
                                }
                                else
                                {
                                    cbbForma1.Text = null;
                                    txtCodigo.Text = null;
                                    return;
                                }
                            }
                            //
                            _Nota_Promissoria = false;
                            //
                            dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma1.Text).Rows[0];
                            //
                            if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                            {
                                DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                    //
                                    txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                    //
                                    txtAcrescimoPorc_Leave(sender, e);
                                    //
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                            {
                                DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                    //
                                    txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                    //
                                    txtDescontoPorc_Leave(sender, e);
                                    //
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            txtValor1.ReadOnly = true;
                            //
                            decimal valor_Pago_1;
                            decimal valor_Pago_2;
                            decimal valor_Pago_3;
                            decimal valor_Pago_4;
                            //
                            if (txtValor1.Text == "")
                            {
                                valor_Pago_1 = 0;
                            }
                            else
                            {
                                valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                            }

                            if (txtValor2.Text == "")
                            {
                                valor_Pago_2 = 0;
                            }
                            else
                            {
                                valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                            }
                            if (txtValor3.Text == "")
                            {
                                valor_Pago_3 = 0;
                            }
                            else
                            {
                                valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                            }

                            if (txtValor4.Text == "")
                            {
                                valor_Pago_4 = 0;
                            }
                            else
                            {
                                valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                            }
                            //
                            if (txtValor1.Text != "" & valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                            {
                                lbl2.Enabled = true;
                                txtCodigo1.Enabled = true;
                                cbbForma2.Enabled = true;
                                btnProcurar2.Enabled = true;
                                txtValor2.Enabled = true;
                                btnProcurar2.Enabled = true;
                                btnRemover2.Enabled = true;
                            }
                            //
                            txtValor1_TextChanged(sender, e);
                            //
                            if (txtValor1.Text == "")
                            {
                                txtValor1.Text = lblDifTroco.Text.Replace("-", "");
                            }
                            //
                            txtValor1.Select();
                        }
                    }
                    else
                    {
                        _Nota_Promissoria = false;
                        txtValor1.ReadOnly = false;
                        //
                        dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma1.Text).Rows[0];
                        //
                        if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                //
                                txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtAcrescimoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                //
                                txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtDescontoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        decimal valor_Pago_1;
                        decimal valor_Pago_2;
                        decimal valor_Pago_3;
                        decimal valor_Pago_4;
                        //
                        if (txtValor1.Text == "")
                        {
                            valor_Pago_1 = 0;
                        }
                        else
                        {
                            valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                        }

                        if (txtValor2.Text == "")
                        {
                            valor_Pago_2 = 0;
                        }
                        else
                        {
                            valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                        }

                        if (txtValor3.Text == "")
                        {
                            valor_Pago_3 = 0;
                        }
                        else
                        {
                            valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                        }

                        if (txtValor4.Text == "")
                        {
                            valor_Pago_4 = 0;
                        }
                        else
                        {
                            valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                        }
                        //
                        if (txtValor1.Text != "" & valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                        {
                            lbl2.Enabled = true;
                            txtCodigo1.Enabled = true;
                            cbbForma2.Enabled = true;
                            btnProcurar2.Enabled = true;
                            txtValor2.Enabled = true;
                            btnProcurar2.Enabled = true;
                            btnRemover2.Enabled = true;
                        }
                        //
                        txtValor1_TextChanged(sender, e);
                        //
                        if (txtValor1.Text == "")
                        {
                            txtValor1.Text = lblDifTroco.Text.Replace("-", "");
                        }
                        //
                        txtValor1.Select();
                    }
                }
                else
                {
                    _Nota_Promissoria = false;
                    txtValor1.ReadOnly = false;
                    txtCodigo.Text = null;
                    txtValor1.Text = null;
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
                txtValor1.Text = null;
                txtValor1.ReadOnly = false;
            }
        }

        private void cbbForma2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbForma2.Text != "")
                {
                    string[] items = cbbForma2.Text.Split('—');
                    txtCodigo1.Text = items[0];
                    //
                    DataRow dr = bllVenda.Sel_Ver_Forma_Pagamento_PDV(cbbForma2.Text).Rows[0];
                    //
                    if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é permitido informar Nota Promissória como a 2ª forma de pagamento, informe no campo 1º.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbForma2.Text = null;
                        txtCodigo1.Text = null;
                    }
                    else if (dr["tipo"].ToString() == "CREDITO LOJA")
                    {
                        MessageBox.Show("Não é permitido informar Crédito Loja como a 2ª forma de pagamento, informe no campo 1º.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbForma2.Text = null;
                        txtCodigo1.Text = null;
                    }
                    else if (dr["tipo"].ToString() == "PIX")
                    {
                        dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma2.Text).Rows[0];
                        //
                        if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                //
                                txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtAcrescimoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                //
                                txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtDescontoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        decimal valor_Pago_1;
                        decimal valor_Pago_2;
                        decimal valor_Pago_3;
                        decimal valor_Pago_4;
                        //
                        if (txtValor1.Text == "")
                        {
                            valor_Pago_1 = 0;
                        }
                        else
                        {
                            valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                        }
                        //
                        if (txtValor2.Text == "")
                        {
                            valor_Pago_2 = 0;
                        }
                        else
                        {
                            valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                        }
                        //
                        if (txtValor3.Text == "")
                        {
                            valor_Pago_3 = 0;
                        }
                        else
                        {
                            valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                        }
                        //
                        if (txtValor4.Text == "")
                        {
                            valor_Pago_4 = 0;
                        }
                        else
                        {
                            valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                        }
                        //
                        if (txtValor2.Text != "" & valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                        {
                            lbl3.Enabled = true;
                            txtCodigo2.Enabled = true;
                            cbbForma3.Enabled = true;
                            btnProcurar3.Enabled = true;
                            txtValor3.Enabled = true;
                            btnProcurar3.Enabled = true;
                            btnRemover3.Enabled = true;
                        }
                        //
                        txtValor2_TextChanged(sender, e);
                        //
                        if (txtValor2.Text == "")
                        {
                            txtValor2.Text = lblDifTroco.Text.Replace("-", "");
                        }
                        //
                        txtValor2.Select();
                    }
                    else
                    {
                        dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma2.Text).Rows[0];
                        //
                        if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                //
                                txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtAcrescimoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                //
                                txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtDescontoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        decimal valor_Pago_1;
                        decimal valor_Pago_2;
                        decimal valor_Pago_3;
                        decimal valor_Pago_4;
                        //
                        if (txtValor1.Text == "")
                        {
                            valor_Pago_1 = 0;
                        }
                        else
                        {
                            valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                        }
                        //
                        if (txtValor2.Text == "")
                        {
                            valor_Pago_2 = 0;
                        }
                        else
                        {
                            valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                        }
                        //
                        if (txtValor3.Text == "")
                        {
                            valor_Pago_3 = 0;
                        }
                        else
                        {
                            valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                        }
                        //
                        if (txtValor4.Text == "")
                        {
                            valor_Pago_4 = 0;
                        }
                        else
                        {
                            valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                        }
                        //
                        if (txtValor2.Text != "" & valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                        {
                            lbl3.Enabled = true;
                            txtCodigo2.Enabled = true;
                            cbbForma3.Enabled = true;
                            btnProcurar3.Enabled = true;
                            txtValor3.Enabled = true;
                            btnProcurar3.Enabled = true;
                            btnRemover3.Enabled = true;
                        }
                        //
                        txtValor2_TextChanged(sender, e);
                        //
                        if (txtValor2.Text == "")
                        {
                            txtValor2.Text = lblDifTroco.Text.Replace("-", "");
                        }
                        //
                        txtValor2.Select();
                    }
                }
                else
                {
                    txtCodigo1.Text = null;
                    txtValor2.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do combobox cbbForma2.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do combobox cbbForma2.");
                }
                txtCodigo1.Text = null;
                cbbForma2.Text = null;
                txtValor2.Text = null;
            }
        }

        private void cbbForma3_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbForma3.Text != "")
                {
                    string[] item = cbbForma3.Text.Split('—');
                    txtCodigo2.Text = item[0];


                    DataRow dr = bllVenda.Sel_Ver_Forma_Pagamento_PDV(cbbForma3.Text).Rows[0];

                    if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é permitido informar Nota Promissória como a 3ª forma de pagamento, informe no campo 1º.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbForma3.Text = null;
                        txtCodigo2.Text = null;
                    }
                    else if (dr["tipo"].ToString() == "CREDITO LOJA")
                    {
                        MessageBox.Show("Não é permitido informar Crédito Loja como a 3ª forma de pagamento, informe no campo 1º.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbForma3.Text = null;
                        txtCodigo2.Text = null;
                    }
                    else if (dr["tipo"].ToString() == "PIX")
                    {

                        dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma3.Text).Rows[0];
                        //
                        if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                //
                                txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtAcrescimoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                //
                                txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtDescontoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        decimal valor_Pago_1;
                        decimal valor_Pago_2;
                        decimal valor_Pago_3;
                        decimal valor_Pago_4;
                        //
                        if (txtValor1.Text == "")
                        {
                            valor_Pago_1 = 0;
                        }
                        else
                        {
                            valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                        }

                        if (txtValor2.Text == "")
                        {
                            valor_Pago_2 = 0;
                        }
                        else
                        {
                            valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                        }

                        if (txtValor3.Text == "")
                        {
                            valor_Pago_3 = 0;
                        }
                        else
                        {
                            valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                        }

                        if (txtValor4.Text == "")
                        {
                            valor_Pago_4 = 0;
                        }
                        else
                        {
                            valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                        }
                        //
                        if (txtValor3.Text != "" & valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                        {
                            lbl4.Enabled = true;
                            txtCodigo3.Enabled = true;
                            cbbForma4.Enabled = true;
                            btnProcurar4.Enabled = true;
                            txtValor4.Enabled = true;
                            btnProcurar4.Enabled = true;
                            btnRemover4.Enabled = true;
                        }
                        //
                        txtValor3_TextChanged(sender, e);
                        //
                        if (txtValor3.Text == "")
                        {
                            txtValor3.Text = lblDifTroco.Text.Replace("-", "");
                        }
                        //
                        txtValor3.Select();
                    }
                    else
                    {
                        dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma3.Text).Rows[0];
                        //
                        if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                //
                                txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtAcrescimoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                //
                                txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtDescontoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        decimal valor_Pago_1;
                        decimal valor_Pago_2;
                        decimal valor_Pago_3;
                        decimal valor_Pago_4;
                        //
                        if (txtValor1.Text == "")
                        {
                            valor_Pago_1 = 0;
                        }
                        else
                        {
                            valor_Pago_1 = Convert.ToDecimal(txtValor1.Text);
                        }

                        if (txtValor2.Text == "")
                        {
                            valor_Pago_2 = 0;
                        }
                        else
                        {
                            valor_Pago_2 = Convert.ToDecimal(txtValor2.Text);
                        }

                        if (txtValor3.Text == "")
                        {
                            valor_Pago_3 = 0;
                        }
                        else
                        {
                            valor_Pago_3 = Convert.ToDecimal(txtValor3.Text);
                        }

                        if (txtValor4.Text == "")
                        {
                            valor_Pago_4 = 0;
                        }
                        else
                        {
                            valor_Pago_4 = Convert.ToDecimal(txtValor4.Text);
                        }
                        //
                        if (txtValor3.Text != "" & valor_Pago_1 + valor_Pago_2 + valor_Pago_3 + valor_Pago_4 < Convert.ToDecimal(lblValorPagar.Text.Replace("R$ ", "")))
                        {
                            lbl4.Enabled = true;
                            txtCodigo3.Enabled = true;
                            cbbForma4.Enabled = true;
                            btnProcurar4.Enabled = true;
                            txtValor4.Enabled = true;
                            btnProcurar4.Enabled = true;
                            btnRemover4.Enabled = true;
                        }
                        //
                        txtValor3_TextChanged(sender, e);
                        //
                        if (txtValor3.Text == "")
                        {
                            txtValor3.Text = lblDifTroco.Text.Replace("-", "");
                        }
                        //
                        txtValor3.Select();
                    }

                }
                else
                {
                    txtCodigo3.Text = null;
                    txtValor4.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do combobox cbbForma3.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do combobox cbbForma3.");
                }
                txtCodigo2.Text = null;
                cbbForma3.Text = null;
                txtValor3.Text = null;
            }
        }

        private void cbbForma4_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cbbForma4.Text != "")
                {
                    string[] item = cbbForma4.Text.Split('—');
                    txtCodigo3.Text = item[0];


                    DataRow dr = bllVenda.Sel_Ver_Forma_Pagamento_PDV(cbbForma4.Text).Rows[0];
                    //
                    if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é permitido informar Nota Promissória como a 4ª forma de pagamento, informe no campo 1º.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbForma4.Text = null;
                        txtCodigo3.Text = null;
                    }
                    else if (dr["tipo"].ToString() == "CREDITO LOJA")
                    {
                        MessageBox.Show("Não é permitido informar Crédito Loja como a 4ª forma de pagamento, informe no campo 1º.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbForma4.Text = null;
                        txtCodigo3.Text = null;
                    }
                    else if (dr["tipo"].ToString() == "PIX")
                    {
                        dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma4.Text).Rows[0];
                        //
                        if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                //
                                txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtAcrescimoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                //
                                txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtDescontoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        txtValor4_TextChanged(sender, e);
                        //
                        if (txtValor4.Text == "")
                        {
                            txtValor4.Text = lblDifTroco.Text.Replace("-", "");
                        }
                        //
                        txtValor4.Select();
                    }
                    else
                    {
                        dr = bllVenda.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(cbbForma4.Text).Rows[0];
                        //
                        if (Convert.ToDecimal(dr["acrescimo_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um acréscimo fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Acrescimo_Fixo_Porc_1 = Convert.ToDecimal(dr["acrescimo_fixo_porc"]);
                                //
                                txtAcrescimoPorc.Text = Convert.ToDecimal(_Acrescimo_Fixo_Porc_1 + _Acrescimo_Fixo_Porc_2 + _Acrescimo_Fixo_Porc_3 + _Acrescimo_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtAcrescimoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        if (Convert.ToDecimal(dr["desconto_fixo_porc"]) > 0)
                        {
                            DialogResult = MessageBox.Show("Esta forma de pagamento possui um Desconto Fixo cadastrado. Deseja incluir este acréscimo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Desconto_Fixo_Porc_1 = Convert.ToDecimal(dr["desconto_fixo_porc"]);
                                //
                                txtDescontoPorc.Text = Convert.ToDecimal(_Desconto_Fixo_Porc_1 + _Desconto_Fixo_Porc_2 + _Desconto_Fixo_Porc_3 + _Desconto_Fixo_Porc_4).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtDescontoPorc_Leave(sender, e);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        //
                        txtValor4_TextChanged(sender, e);
                        //
                        if (txtValor4.Text == "")
                        {
                            txtValor4.Text = lblDifTroco.Text.Replace("-", "");
                        }
                        //
                        txtValor4.Select();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do combobox cbbForma3.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do combobox cbbForma3.");
                }
                txtCodigo3.Text = null;
                cbbForma4.Text = null;
                txtValor4.Text = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total dos produtos (R$): " + lblTotalSub.Text + "\n                         \nAcréscimos dos itens (R$): +" + _Acrescimo_Item + "\n                          \nDescontos dos itens (R$): -" + _Desconto_Item + "\n                         \nAcréscimo da venda (R$): +" + txtAcrescimo.Text + "\n                          \nDesconto da venda (R$): -" + txtDesconto.Text + "\n                         \nTotal a pagar (R$): " + lblValorPagar.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnInformações_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnInformações_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            if (_Perm_Desc_Usuario == true)
            {
                _Perm_Desc_Usuario = false;
            }
        }

        private void txtAcrescimo_TextChanged(object sender, EventArgs e)
        {
            if (_Perm_Acresc_Usuario == true)
            {
                _Perm_Acresc_Usuario = false;
            }
        }

        private void txtAcrescimoPorc_TextChanged(object sender, EventArgs e)
        {
            if (_Perm_Acresc_Usuario == true)
            {
                _Perm_Acresc_Usuario = false;
            }
        }

        private void txtDescontoPorc_TextChanged(object sender, EventArgs e)
        {
            if (_Perm_Desc_Usuario == true)
            {
                _Perm_Desc_Usuario = false;
            }
        }

        private void btnNovaNotaPromissoria_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            //try
            //{
                if (bllVenda._PDV_PesqCliente_Tabela == null)
                {
                    MessageBox.Show("É necessário identificar o Consumidor para realizar pagamento em Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    using (FrmPlanoNotaPromissoria Prom = new FrmPlanoNotaPromissoria(0, lblValorPagar.Text, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Prom.ShowDialog() == DialogResult.OK)
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
                                    if (dr["tipo"].ToString() == "NOTA PROMISSORIA")
                                    {
                                        cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString() + "—" + dr["descricao"].ToString());
                                    }
                                    else
                                    {
                                        cbbForma1.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                                    }
                                }
                            }
                            txtCodigo.Text = bllVenda._Cod_Nota_Promissoria_Plano;
                            //
                            txtCodigo_Leave(sender, e);
                            //                       
                            cbbForma1.Select();

                        }
                    }
                }
                /*
            }
            catch (Exception ex)
            {
                this.Enabled = true;
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
                */
            this.Enabled = true;
        }

        private void btnNovaNotaPromissoria_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovaNotaPromissoria_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbForma1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnObservacao_Click(object sender, EventArgs e)
        {
            using (FrmObservacao Obs = new FrmObservacao(_Usuario, _Cod_PDV_Computador))
            {
                if (Obs.ShowDialog() == DialogResult.OK)
                {
                    txtCodigo.Select();
                }
                else
                {
                    txtCodigo.Select();
                }
            }
        }
    }
}
