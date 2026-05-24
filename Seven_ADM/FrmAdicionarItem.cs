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
    public partial class FrmAdicionarItem : Form
    {
        public FrmAdicionarItem(int item, byte formulario, string tabela, string quantidade, string codigo)
        {
            InitializeComponent();
            _Item = item.ToString();
            _Formulario = formulario;
            _Tabela = tabela;
            _Quantidade = quantidade;
            _Codigo = codigo;
        }

        private string _Item;
        private byte _Formulario;
        private string _Tabela;
        private string _Quantidade;
        private string _Codigo;

        private void FrmAdicionarItemOrc_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAdicionarItemOrc iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAdicionarItemOrc iniciado.");
                }
                //
                if (_Formulario == 0)
                {
                    string[] items = bllOrcamento._Orc_PesqProduto_Tabela.Split('—');
                    cbbUM.Text = items[2];
                    txtValorUnitario.Text = Convert.ToDecimal(items[3]).ToString("n2", new CultureInfo("pt-BR"));
                    //               
                    txtQuantidade.Text = "1,00";
                    txtDescontoPorc.Text = Convert.ToDecimal(items[5]).ToString("n2", new CultureInfo("pt-BR"));
                    txtDescontoPorc_Leave(sender, e);
                    txtAcrescimoPorc.Text = Convert.ToDecimal(items[4]).ToString("n2", new CultureInfo("pt-BR"));
                    txtAcrescimoPorc_Leave(sender, e);
                    //
                    txtQuantidade_Leave(sender, e);
                }
                else if (_Formulario == 1)
                {
                    string[] items = bllDevolucao._Devolucao_Prod_PesqProd_Tabela.Split('—');
                    cbbUM.Text = items[2];
                    txtValorUnitario.Text = Convert.ToDecimal(items[3]).ToString("n2", new CultureInfo("pt-BR"));
                    //               
                    txtQuantidade.Text = "1,00";
                    txtDescontoPorc.Text = Convert.ToDecimal(items[5]).ToString("n2", new CultureInfo("pt-BR"));
                    txtDescontoPorc_Leave(sender, e);
                    txtAcrescimoPorc.Text = Convert.ToDecimal(items[4]).ToString("n2", new CultureInfo("pt-BR"));
                    txtAcrescimoPorc_Leave(sender, e);
                    //
                    lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblValorTotal.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Dev(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                }
                else if (_Formulario == 2)
                {
                    string[] items = bllVenda._PDV_PesqProduto_Tabela.Split('—');
                    cbbUM.Text = items[2];
                    txtValorUnitario.Text = Convert.ToDecimal(items[3]).ToString("n2", new CultureInfo("pt-BR"));
                    //               
                    txtQuantidade.Text = Convert.ToDecimal(_Quantidade).ToString("n2", new CultureInfo("pt-BR"));
                    txtDescontoPorc.Text = Convert.ToDecimal(items[5]).ToString("n2", new CultureInfo("pt-BR"));
                    txtDescontoPorc_Leave(sender, e);
                    txtAcrescimoPorc.Text = Convert.ToDecimal(items[4]).ToString("n2", new CultureInfo("pt-BR"));
                    txtAcrescimoPorc_Leave(sender, e);
                    //
                    lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    lblValorTotal.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                }
                else if (_Formulario == 3)
                {
                    string[] items = bllOS._Servico_PesqServico_Tabela.Split('—');
                    this.Text = "Inclusão de Item: " + items[0] + "-" + items[1];
                    cbbUM.Enabled = false;
                    lblUN.Enabled = false;
                    lblAsterisco2.Enabled = false;
                    cbbUM.Text = "UN"; ;
                    txtValorUnitario.Text = Convert.ToDecimal(items[2]).ToString("n2", new CultureInfo("pt-BR"));
                    //               
                    txtQuantidade.Text = "1,00";
                    txtDescontoPorc.Text = Convert.ToDecimal(items[5]).ToString("n2", new CultureInfo("pt-BR"));
                    txtDescontoPorc_Leave(sender, e);
                    txtAcrescimoPorc.Text = Convert.ToDecimal(items[4]).ToString("n2", new CultureInfo("pt-BR"));
                    txtAcrescimoPorc_Leave(sender, e);
                    //
                    txtQuantidade_Leave(sender, e);
                }
                else if (_Formulario == 4)
                {
                    string[] items = bllOrcamento._Orc_PesqProduto_Tabela.Split('—');
                    this.Text = "Inclusão de Item: " + items[0] + "-" + items[1];
                    cbbUM.Enabled = false;
                    lblUN.Enabled = false;
                    lblAsterisco2.Enabled = false;
                    cbbUM.Text = "UN"; ;
                    txtValorUnitario.Text = Convert.ToDecimal(items[2]).ToString("n2", new CultureInfo("pt-BR"));
                    //               
                    txtQuantidade.Text = "1,00";
                    txtDescontoPorc.Text = Convert.ToDecimal(items[4]).ToString("n2", new CultureInfo("pt-BR"));
                    txtDescontoPorc_Leave(sender, e);
                    txtAcrescimoPorc.Text = Convert.ToDecimal(items[3]).ToString("n2", new CultureInfo("pt-BR"));
                    txtAcrescimoPorc_Leave(sender, e);
                    //
                    txtQuantidade_Leave(sender, e);
                }
                else if (_Formulario == 5)
                {
                    string[] items = bllOS._Produto_PesqProduto_Tabela.Split('—');
                    cbbUM.Text = items[2];
                    txtValorUnitario.Text = Convert.ToDecimal(items[3]).ToString("n2", new CultureInfo("pt-BR"));
                    //               
                    txtQuantidade.Text = "1,00";
                    txtDescontoPorc.Text = Convert.ToDecimal(items[5]).ToString("n2", new CultureInfo("pt-BR"));
                    txtDescontoPorc_Leave(sender, e);
                    txtAcrescimoPorc.Text = Convert.ToDecimal(items[4]).ToString("n2", new CultureInfo("pt-BR"));
                    txtAcrescimoPorc_Leave(sender, e);
                    //
                    txtQuantidade_Leave(sender, e);
                }
                //
                btnIncluir.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmAdicionarItemOrc.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmAdicionarItemOrc.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtQuantidade_Enter(object sender, EventArgs e)
        {
            txtQuantidade.BackColor = Color.LightBlue;
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtQuantidade.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (_Formulario == 3 || _Formulario == 4)
                {
                    txtValorUnitario.Select();
                }
                else
                {
                    cbbUM.Select();
                }
            }
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.Contains("'") || txtQuantidade.Text.Contains(";") || txtQuantidade.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtQuantidade.Text = null;
                txtQuantidade.Select();
            }
            else
            {
                try
                {
                    if (_Formulario == 0)
                    {
                        if (txtQuantidade.Text != "")
                        {
                            txtQuantidade.Text = txtQuantidade.Text = Convert.ToDecimal(txtQuantidade.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Orc(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));

                        }
                        else
                        {
                            txtQuantidade.Text = "0,00";
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Orc(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));

                        }
                    }
                    else if (_Formulario == 1)
                    {
                        if (txtQuantidade.Text != "")
                        {
                            txtQuantidade.Text = txtQuantidade.Text = Convert.ToDecimal(txtQuantidade.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Dev(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtQuantidade.Text = "0,00";
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Dev(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 2)
                    {
                        if (txtQuantidade.Text != "")
                        {
                            txtQuantidade.Text = txtQuantidade.Text = Convert.ToDecimal(txtQuantidade.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtQuantidade.Text = "0,00";
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 3)
                    {
                        if (txtQuantidade.Text != "")
                        {
                            txtQuantidade.Text = txtQuantidade.Text = Convert.ToDecimal(txtQuantidade.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtQuantidade.Text = "0,00";
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 4)
                    {
                        if (txtQuantidade.Text != "")
                        {
                            txtQuantidade.Text = txtQuantidade.Text = Convert.ToDecimal(txtQuantidade.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Orc(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtQuantidade.Text = "0,00";
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Orc(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 5)
                    {
                        if (txtQuantidade.Text != "")
                        {
                            txtQuantidade.Text = txtQuantidade.Text = Convert.ToDecimal(txtQuantidade.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtQuantidade.Text = "0,00";
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtQuantidade.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtQuantidade.");
                    }
                    txtQuantidade.Text = null;
                }
            }
            txtQuantidade.BackColor = Color.White;
        }

        private void txtValorUnitario_Enter(object sender, EventArgs e)
        {
            txtValorUnitario.BackColor = Color.LightBlue;
        }

        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorUnitario.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtDescontoPorc.Select();
            }
        }

        private void txtValorUnitario_Leave(object sender, EventArgs e)
        {
            if (txtValorUnitario.Text.Contains("'") || txtValorUnitario.Text.Contains(";") || txtValorUnitario.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtValorUnitario.Text = null;
                txtValorUnitario.Select();
            }
            else
            {
                try
                {
                    if (_Formulario == 0)
                    {
                        if (txtValorUnitario.Text != "")
                        {
                            txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Orc(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorUnitario.Text = "0,00";
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Orc(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 1)
                    {
                        if (txtValorUnitario.Text != "")
                        {
                            txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Dev(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorUnitario.Text = "0,00";
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Dev(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 2)
                    {
                        if (txtValorUnitario.Text != "")
                        {
                            txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorUnitario.Text = "0,00";
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 3)
                    {
                        if (txtValorUnitario.Text != "")
                        {
                            txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorUnitario.Text = "0,00";
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 4)
                    {
                        if (txtValorUnitario.Text != "")
                        {
                            txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Orc(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorUnitario.Text = "0,00";
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Orc(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 5)
                    {
                        if (txtValorUnitario.Text != "")
                        {
                            txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorUnitario.Text = "0,00";
                            //
                            lblValorTotal.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item(txtValorUnitario.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    //
                    txtDescontoPorc_Leave(sender, e);
                    //
                    txtAcrescimoPorc_Leave(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorUnitario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorUnitario.");
                    }
                    txtValorUnitario.Text = null;
                }
            }
            txtValorUnitario.BackColor = Color.White;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnIncluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncluir_MouseLeave(object sender, EventArgs e)
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

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            btnIncluir.Select();
            if (txtQuantidade.Text.Trim() == "" || txtQuantidade.Text.Trim() == "0" || txtQuantidade.Text == "0,00" || txtValorUnitario.Text.Trim() == "" || txtValorUnitario.Text.Trim() == "0" || txtValorUnitario.Text.Trim() == "0,00" || cbbUM.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: [ Quantidade ], [ Unidade de Medida (UM) ] e [ Valor Unitário ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtQuantidade.Select();
            }
            else if (lblValorTotalDescAcresc.Text.Contains("-") == true || lblValorTotalDescAcresc.Text == "0,00")
            {
                MessageBox.Show("O valor total não pode ser menor e/ou igual a zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtQuantidade.Select();
            }
            else
            {
                this.DialogResult = DialogResult.None;
                try
                {
                    if (_Formulario == 0)
                    {
                        string[] items = bllOrcamento._Orc_PesqProduto_Tabela.Split('—');
                        //
                        if (bllProduto.Sel_Produto_Ainda_Existe(items[0]) == false)
                        {
                            MessageBox.Show("O produto informado foi excluído ou não existe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {
                            if (bllProduto.Sel_Alert_Est_Max_Min_Prod(items[0]) == true)
                            {
                                if (bllProduto.Ver_Estoque_Min_Prod(items[0], txtQuantidade.Text.Trim()) == true)
                                {
                                    MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            int item = Convert.ToInt32(_Item) + 1;
                            bllOrcamento.Salvar_Itens_Orc_Operation(item.ToString(), items[0], items[1], txtQuantidade.Text.Trim(), cbbUM.Text, txtValorUnitario.Text, txtDescontoPorc.Text.Trim(), txtAcrescimoPorc.Text.Trim(), bllConexao._Codigo_Conexao, 0);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 1)
                    {
                        string[] items = bllDevolucao._Devolucao_Prod_PesqProd_Tabela.Split('—');
                        //
                        if (bllProduto.Sel_Produto_Ainda_Existe(items[0]) == false)
                        {
                            MessageBox.Show("O produto informado foi excluído ou não existe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {
                            if (bllProduto.Sel_Alert_Est_Max_Min_Prod(items[0]) == true)
                            {
                                if (bllProduto.Ver_Estoque_Min_Prod(items[0], txtQuantidade.Text.Trim()) == true)
                                {
                                    MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            int item = Convert.ToInt32(_Item) + 1;
                            //
                            bllDevolucao.Salvar_Item_Dev_Prod(item.ToString(), items[0], items[1], txtValorUnitario.Text, cbbUM.Text, txtQuantidade.Text, txtDescontoPorc.Text, txtAcrescimoPorc.Text, bllConexao._Codigo_Conexao);
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 2)
                    {
                        string[] items = bllVenda._PDV_PesqProduto_Tabela.Split('—');
                        //
                        if (bllProduto.Sel_Produto_Ainda_Existe(items[0]) == false)
                        {
                            MessageBox.Show("O produto informado foi excluído ou não existe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {
                            if (bllProduto.Sel_Alert_Est_Max_Min_Prod(items[0]) == true)
                            {
                                if (bllProduto.Ver_Estoque_Min_Prod(items[0], txtQuantidade.Text.Trim()) == true)
                                {
                                    MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            int item = Convert.ToInt32(_Item) + 1;
                            //
                            DataRow dr = bllProduto.Sel_Prod_Codigo(items[0], "").Rows[0];
                            //
                            string imagem_prod = dr["imagem_prod"].ToString();
                            //
                            bllVenda.Salvar_Items_PDV(item.ToString(), items[0], items[1], txtValorUnitario.Text, cbbUM.Text, txtQuantidade.Text.Trim(), txtAcrescimoPorc.Text, txtDescontoPorc.Text, _Tabela, bllConexao._Codigo_Conexao, "PRODUTO");
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 3)
                    {
                        string[] items = bllOS._Servico_PesqServico_Tabela.Split('—');
                        //
                        if (bllServico.Sel_Servico_Ainda_Existe(items[0]) == false)
                        {
                            MessageBox.Show("O Serviço informado foi excluído ou não existe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {
                            int item = Convert.ToInt32(_Item) + 1;
                            //
                            if (_Codigo == null)
                            {
                                bllOS.Salvar_Items_Servico_Temp(item.ToString(), items[0], items[1], txtValorUnitario.Text, bllConexao._Codigo_Conexao, txtQuantidade.Text, items[3], txtDescontoPorc.Text.Trim(), txtAcrescimoPorc.Text.Trim(), "0");
                            }
                            else
                            {
                                bllOS.Salvar_Items_Servico(item.ToString(), items[0], items[1], txtValorUnitario.Text, _Codigo, txtQuantidade.Text, items[3], txtDescontoPorc.Text.Trim(), txtAcrescimoPorc.Text.Trim(), "0");
                            }
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 4)
                    {
                        string[] items = bllOrcamento._Orc_PesqProduto_Tabela.Split('—');
                        //
                        if (bllServico.Sel_Servico_Ainda_Existe(items[0]) == false)
                        {
                            MessageBox.Show("O Serviço informado foi excluído ou não existe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {
                            int item = Convert.ToInt32(_Item) + 1;
                            bllOrcamento.Salvar_Itens_Orc_Operation(item.ToString(), items[0], items[1], txtQuantidade.Text.Trim(), cbbUM.Text, txtValorUnitario.Text, txtDescontoPorc.Text.Trim(), txtAcrescimoPorc.Text.Trim(), bllConexao._Codigo_Conexao, 1);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 5)
                    {
                        string[] items = bllOS._Produto_PesqProduto_Tabela.Split('—');
                        //
                        if (bllProduto.Sel_Produto_Ainda_Existe(items[0]) == false)
                        {
                            MessageBox.Show("O produto informado foi excluído ou não existe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {
                            if (bllProduto.Sel_Alert_Est_Max_Min_Prod(items[0]) == true)
                            {
                                if (bllProduto.Ver_Estoque_Min_Prod(items[0], txtQuantidade.Text.Trim()) == true)
                                {
                                    MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            int item = Convert.ToInt32(_Item) + 1;
                            //
                            if (_Codigo == null)
                            {
                                bllOS.Salvar_Items_OS_Produto_Temp(item.ToString(), items[0], items[1], txtValorUnitario.Text, cbbUM.Text, txtQuantidade.Text.Trim(), txtAcrescimoPorc.Text.Trim(), txtDescontoPorc.Text.Trim(), bllConexao._Codigo_Conexao, "0");
                            }
                            else
                            {
                                bllOS.Salvar_Items_OS_Produto(item.ToString(), items[0], items[1], txtValorUnitario.Text, cbbUM.Text, txtQuantidade.Text.Trim(), txtAcrescimoPorc.Text.Trim(), txtDescontoPorc.Text.Trim(), _Codigo, "0");
                                //
                                bllOS.Alterar_Estoque_Produto_OS(items[0], txtQuantidade.Text.Trim(), false);
                            }
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                    }
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    txtQuantidade.Text = null;
                    cbbUM.Text = null;
                    txtValorUnitario.Text = null;
                    txtDescontoPorc.Text = null;
                    txtValorDesconto.Text = null;
                    lblValorTotal.Text = null;
                    txtAcrescimoPorc.Text = null;
                    txtValorAcrescimo.Text = null;
                    lblValorTotalDescAcresc.Text = null;
                    txtQuantidade.Select();
                }
            }
        }

        private void FrmAdicionarItemOrc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Informe a quantidade, unidade de medida, valor unitário, desconto e acréscimo do produto/serviço.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbUM_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUM_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUM_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUM_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorUnitario.Select();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void txtDescontoPorc_Enter(object sender, EventArgs e)
        {
            txtDescontoPorc.BackColor = Color.LightBlue;
        }

        private void txtValorDesconto_Enter(object sender, EventArgs e)
        {
            txtValorDesconto.BackColor = Color.LightBlue;
        }

        private void txtAcrescimoPorc_Enter(object sender, EventArgs e)
        {
            txtAcrescimoPorc.BackColor = Color.LightBlue;
        }

        private void txtValorAcrescimo_Enter(object sender, EventArgs e)
        {
            txtValorAcrescimo.BackColor = Color.LightBlue;
        }

        private void txtValorDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorDesconto.Text.Contains(",") && e.KeyChar == (char)44)
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
                txtValorAcrescimo.Select();
            }
        }

        private void txtValorAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorAcrescimo.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnIncluir.Select();
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
                txtValorDesconto.Select();
            }
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
                    if (_Formulario == 0)
                    {
                        if (txtDescontoPorc.Text != "")
                        {
                            txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtDescontoPorc.Text = "0,00";
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 1)
                    {
                        if (txtDescontoPorc.Text != "")
                        {
                            txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllDevolucao.Calculo_Desconto(txtValorUnitario.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtDescontoPorc.Text = "0,00";
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllDevolucao.Calculo_Desconto(txtValorUnitario.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 2)
                    {
                        if (txtDescontoPorc.Text != "")
                        {
                            txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllVenda.Calculo_Desconto(txtValorUnitario.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtDescontoPorc.Text = "0,00";
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllVenda.Calculo_Desconto(txtValorUnitario.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 3)
                    {
                        if (txtDescontoPorc.Text != "")
                        {
                            txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtDescontoPorc.Text = "0,00";
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 4)
                    {
                        if (txtDescontoPorc.Text != "")
                        {
                            txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtDescontoPorc.Text = "0,00";
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOrcamento.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 5)
                    {
                        if (txtDescontoPorc.Text != "")
                        {
                            txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtDescontoPorc.Text = "0,00";
                            //
                            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
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
                    if (_Formulario == 0)
                    {
                        if (txtValorDesconto.Text != "")
                        {
                            txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorDesconto(lblValorTotal.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorDesconto.Text = "0,00";
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorDesconto(lblValorTotal.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 1)
                    {
                        if (txtValorDesconto.Text != "")
                        {
                            txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllDevolucao.Calculo_ValorDesconto(txtValorUnitario.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorDesconto.Text = "0,00";
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllDevolucao.Calculo_ValorDesconto(txtValorUnitario.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 2)
                    {
                        if (txtValorDesconto.Text != "")
                        {
                            txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllVenda.Calculo_ValorDesconto(txtValorUnitario.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorDesconto.Text = "0,00";
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllVenda.Calculo_ValorDesconto(txtValorUnitario.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 3)
                    {
                        if (txtValorDesconto.Text != "")
                        {
                            txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllOS.Calculo_ValorDesconto(lblValorTotal.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorDesconto.Text = "0,00";
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllOS.Calculo_ValorDesconto(lblValorTotal.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 4)
                    {
                        if (txtValorDesconto.Text != "")
                        {
                            txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorDesconto(lblValorTotal.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorDesconto.Text = "0,00";
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorDesconto(lblValorTotal.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 5)
                    {
                        if (txtValorDesconto.Text != "")
                        {
                            txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllOS.Calculo_ValorDesconto(lblValorTotal.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorDesconto.Text = "0,00";
                            //
                            txtDescontoPorc.Text = Convert.ToDecimal(bllOS.Calculo_ValorDesconto(lblValorTotal.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
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
                    if (_Formulario == 0)
                    {
                        if (txtAcrescimoPorc.Text != "")
                        {
                            txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtAcrescimoPorc.Text = "0,00";

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 1)
                    {
                        if (txtAcrescimoPorc.Text != "")
                        {
                            txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllDevolucao.Calculo_Acrescimo(txtValorUnitario.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtAcrescimoPorc.Text = "0,00";

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllDevolucao.Calculo_Acrescimo(txtValorUnitario.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 2)
                    {
                        if (txtAcrescimoPorc.Text != "")
                        {
                            txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllVenda.Calculo_Acrescimo(txtValorUnitario.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtAcrescimoPorc.Text = "0,00";

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllVenda.Calculo_Acrescimo(txtValorUnitario.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 3)
                    {
                        if (txtAcrescimoPorc.Text != "")
                        {
                            txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtAcrescimoPorc.Text = "0,00";

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 4)
                    {
                        if (txtAcrescimoPorc.Text != "")
                        {
                            txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtAcrescimoPorc.Text = "0,00";

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOrcamento.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 5)
                    {
                        if (txtAcrescimoPorc.Text != "")
                        {
                            txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtAcrescimoPorc.Text = "0,00";

                            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
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
                    if (_Formulario == 0)
                    {
                        if (txtValorAcrescimo.Text != "")
                        {
                            txtValorAcrescimo.Text = Convert.ToDecimal(txtValorAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorAcrescimo(lblValorTotal.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorAcrescimo.Text = "0,00";

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorAcrescimo(lblValorTotal.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 1)
                    {
                        if (txtValorAcrescimo.Text != "")
                        {
                            txtValorAcrescimo.Text = Convert.ToDecimal(txtValorAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllDevolucao.Calculo_ValorAcrescimo(txtValorUnitario.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorAcrescimo.Text = "0,00";

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllDevolucao.Calculo_ValorAcrescimo(txtValorUnitario.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllDevolucao.Calculo_Valor_Item_Desc_Acresc_Dev(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 2)
                    {
                        if (txtValorAcrescimo.Text != "")
                        {
                            txtValorAcrescimo.Text = Convert.ToDecimal(txtValorAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllVenda.Calculo_ValorAcrescimo(txtValorUnitario.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorAcrescimo.Text = "0,00";

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllVenda.Calculo_ValorAcrescimo(txtValorUnitario.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllVenda.Calculo_Valor_Item_Desc_Acresc_Item(txtValorUnitario.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 3)
                    {
                        if (txtValorAcrescimo.Text != "")
                        {
                            txtValorAcrescimo.Text = Convert.ToDecimal(txtValorAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllOS.Calculo_ValorAcrescimo(lblValorTotal.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorAcrescimo.Text = "0,00";

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllOS.Calculo_ValorAcrescimo(lblValorTotal.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 4)
                    {
                        if (txtValorAcrescimo.Text != "")
                        {
                            txtValorAcrescimo.Text = Convert.ToDecimal(txtValorAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorAcrescimo(lblValorTotal.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorAcrescimo.Text = "0,00";

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllOrcamento.Calculo_ValorAcrescimo(lblValorTotal.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOrcamento.Calculo_Valor_Item_Desc_Acresc_Orc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                    }
                    else if (_Formulario == 5)
                    {
                        if (txtValorAcrescimo.Text != "")
                        {
                            txtValorAcrescimo.Text = Convert.ToDecimal(txtValorAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllOS.Calculo_ValorAcrescimo(lblValorTotal.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorAcrescimo.Text = "0,00";

                            txtAcrescimoPorc.Text = Convert.ToDecimal(bllOS.Calculo_ValorAcrescimo(lblValorTotal.Text, txtValorAcrescimo.Text)).ToString("n2", new CultureInfo("pt-BR"));

                            lblValorTotalDescAcresc.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Item_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
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

        private void FrmAdicionarItemOrc_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAdicionarItemOrc foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAdicionarItemOrc foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmAdicionarItemOrc.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmAdicionarItemOrc.");
                }
            }
        }

        private void lblValorTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblValorTotal.Text.Replace("R$ ", ""), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalDescAcresc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalDescAcresc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalDescAcresc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total dos Produtos com Descontos e Acréscimos (R$): " + lblValorTotalDescAcresc.Text.Replace("R$ ", ""), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }
    }
}
