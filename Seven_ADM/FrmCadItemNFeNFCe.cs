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
    public partial class FrmCadItemNFeNFCe : Form
    {
        public FrmCadItemNFeNFCe(byte formulario, string cod_item, string cod_dfe, bool comando_atualizar, string produto, string ncm, string cest, string cst, string aliquota_icms, string csosn, string cfop, string quantidade, string valor_icms, string quantidade_embalagem, string valor_unitario, string valor_desconto, string valor_acrescimo, string base_calculo, string total, string total_real, string base_calculo_st, string reducao_st, string mva, string aliquota_icms_st, string valor_icms_st, string finalidade, string tipo, string usuario, string cod_pdv_computador, string aliq_ipi, string valor_ipi, string reducao_bc_st, string valor_frete)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Cod_Item = cod_item;
            _Cod_Dfe = cod_dfe;
            _Comando_Atualizar = comando_atualizar;
            _Produto = produto;
            _NCM = ncm;
            _CEST = cest;
            _CST = cst;
            _Aliquota_ICMS = aliquota_icms;
            _CSOSN = csosn;
            _CFOP = cfop;
            _Quantidade = quantidade;
            _Quantidade_Embalagem = quantidade_embalagem;
            _Valor_ICMS = valor_icms;
            _Valor_Unitario = valor_unitario;
            _Valor_Desconto = valor_desconto;
            _Valor_Acrescimo = valor_acrescimo;
            _Base_Calculo = base_calculo;
            _Total = total;
            _Total_Real = total_real;
            _Base_Calculo_St = base_calculo_st;
            _Aliquota_ICMS_ST = aliquota_icms_st;
            _MVA = mva;
            _Reducao_BC = reducao_st;
            _Valor_ICMS_St = valor_icms_st;
            _Finalidade = finalidade;
            _Tipo = tipo;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Aliq_IPI = aliq_ipi;
            _Valor_IPI = valor_ipi;
            _Reducao_BC_ST = reducao_bc_st;
            _Valor_Frete = valor_frete;
        }

        byte _Formulario;
        string _Cod_Item;
        string _Cod_Dfe;
        bool _Comando_Atualizar;
        string _Produto;
        string _NCM;
        string _CEST;
        string _CST;
        string _Aliquota_ICMS;
        string _CSOSN;
        string _CFOP;
        string _Quantidade;
        string _Valor_ICMS;
        string _Quantidade_Embalagem;
        string _Valor_Unitario;
        string _Valor_Desconto;
        string _Valor_Acrescimo;
        string _Base_Calculo;
        string _Total;
        string _Total_Real;
        string _Base_Calculo_St;
        string _Aliquota_ICMS_ST;
        string _MVA;
        string _Reducao_BC;
        string _Valor_ICMS_St;
        string _Finalidade;
        string _Tipo;
        string _Aliq_IPI;
        string _Valor_IPI;
        string _Reducao_BC_ST;
        string _Valor_Frete;

        string _Usuario;
        string _Cod_PDV_Computador;

        private void FrmCadItemNFeNFCe_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadItemNFeNFCe iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadItemNFeNFCe iniciado.");
                }
                //
                cbbProduto.Items.Clear();
                if (bllDFe.Sel_Produto_DFe("ATIVO") == null)
                {
                    cbbProduto.Text = null;
                }
                else
                {
                    cbbProduto.Items.Add("");
                    foreach (DataRow dr in bllDFe.Sel_Produto_DFe("ATIVO").Rows)
                    {
                        cbbProduto.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbCFOP.Items.Clear();
                if (bllDFe.Sel_Cfop_Dfe(_Finalidade) == null)
                {
                    cbbCFOP.Text = null;
                }
                else
                {
                    cbbCFOP.Items.Add("");
                    foreach (DataRow dr in bllDFe.Sel_Cfop_Dfe(_Finalidade).Rows)
                    {
                        cbbCFOP.Items.Add((dr["cod_cfop"].ToString()));
                    }
                }
                //
                if (_Comando_Atualizar == true)
                {
                    string[] items = _Produto.Split('—');
                    //
                    txtCodigo.Text = items[0];
                    cbbProduto.Text = items[0] + "—" + items[1];
                    cbbUM.Text = items[2];
                    txtNCM.Text = _NCM;
                    txtCEST.Text = _CEST;
                    //
                    if (_CST != "")
                    {
                        cbbCSTA.Text = _CST.Remove(1);
                        cbbCSTB.Text = _CST.Remove(0, 1);
                    }
                    //
                    txtAliqICMS.Text = Convert.ToDecimal(_Aliquota_ICMS).ToString("n2", new CultureInfo("pt-BR"));
                    cbbCSOSN.Text = _CSOSN;
                    cbbCFOP.Text = _CFOP;
                    txtQuantidade.Text = Convert.ToDecimal(_Quantidade).ToString("n2", new CultureInfo("pt-BR")); ;
                    txtQuantidadeEmbalagem.Text = Convert.ToDecimal(_Quantidade_Embalagem).ToString("n2", new CultureInfo("pt-BR"));
                    txtValorICMS.Text = Convert.ToDecimal(_Valor_ICMS).ToString("n2", new CultureInfo("pt-BR"));
                    txtPreco.Text = Convert.ToDecimal(_Valor_Unitario).ToString("n2", new CultureInfo("pt-BR"));
                    txtValorDesconto.Text = Convert.ToDecimal(_Valor_Desconto).ToString("n2", new CultureInfo("pt-BR"));
                    txtValorAcrescimo.Text = Convert.ToDecimal(_Valor_Acrescimo).ToString("n2", new CultureInfo("pt-BR"));
                    txtValorBaseCalculo.Text = Convert.ToDecimal(_Base_Calculo).ToString("n2", new CultureInfo("pt-BR"));
                    txtTotal.Text = Convert.ToDecimal(_Total).ToString("n2", new CultureInfo("pt-BR"));
                    txtValorTotalReal.Text = Convert.ToDecimal(_Total_Real).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtReducaoBC.Text = Convert.ToDecimal(_Reducao_BC).ToString("n2", new CultureInfo("pt-BR"));
                    txtAliqICMSST.Text = Convert.ToDecimal(_Aliquota_ICMS_ST).ToString("n2", new CultureInfo("pt-BR"));
                    txtValorMVA.Text = Convert.ToDecimal(_MVA).ToString("n2", new CultureInfo("pt-BR"));
                    txtValorBaseCalculoSt.Text = Convert.ToDecimal(_Base_Calculo_St).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorICMSST.Text = Convert.ToDecimal(_Valor_ICMS_St).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtAliqIPI.Text = Convert.ToDecimal(_Aliq_IPI).ToString("n2", new CultureInfo("pt-BR"));
                    txtValorIPI.Text = Convert.ToDecimal(_Valor_IPI).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtReducaoBCST.Text = Convert.ToDecimal(_Reducao_BC_ST).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorFrete.Text = Convert.ToDecimal(_Valor_Frete).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtPreco_Leave(sender, e);
                }
                else
                {
                    txtCodigo_Leave(sender, e);
                }
                //
                if (_Formulario == 4)
                {
                    grbProdutosServicos.Enabled = false;
                    grbQuantidadePreco.Enabled = false;
                    grbDescontoAcrescimo.Enabled = false;
                    grbTotais.Enabled = false;
                    grbOutrosCalc.Enabled = false;
                    grbIBSCBS.Enabled = false;
                    grbICMS.Enabled = false;
                    cbbCFOP.Select();
                }
                else
                {
                    txtCodigo.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadItemNFeNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadItemNFeNFCe.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Limpar()
        {
            cbbProduto.Text = null;
            txtCodigo.Text = null;
            cbbUM.Text = null;
            txtNCM.Text = null;
            txtCEST.Text = null;
            cbbCSTA.Text = null;
            cbbCSTB.Text = null;
            txtAliqICMS.Text = "0,00";
            cbbCSOSN.Text = null;
            cbbCFOP.Text = null;
            txtQuantidade.Text = "0,00";
            txtQuantidadeEmbalagem.Text = "0,00";
            txtPreco.Text = "0,00";
            txtTotal.Text = "0,00";
            txtDescontoPorc.Text = "0,00";
            txtValorDesconto.Text = "0,00";
            txtAcrescimoPorc.Text = "0,00";
            txtValorAcrescimo.Text = "0,00";
            txtValorTotalReal.Text = "0,00";
            txtValorICMS.Text = "0,00";
            txtValorBaseCalculo.Text = "0,00";
            txtValorBaseCalculoSt.Text = "0,00";
            txtValorICMSST.Text = "0,00";
            txtTotalAproxTrib.Text = "0,00";
            txtValorIPI.Text = "0,00";
            txtReducaoBC.Text = "0,00";
            txtValorReducaoICMS.Text = "0,00";
            txtNovoValorICMS.Text = "0,00";
            txtReducaoBCST.Text = "0,00";
            txtValorReducaoICMSST.Text = "0,00";
            txtNovoValorICMSST.Text = "0,00";
            txtAliqIPI.Text = "0,00";
            txtAliqICMSST.Text = "0,00";
            txtValorMVA.Text = "0,00";
            cbbCSTAIBSCBS.Text = null;
            cbbCSTBIBSCBS.Text = null;
            cbbCClassTrib.Text = null;
            txtAliqIBSMun.Text = "0,00";
            txtAliqIBSEstadual.Text = "0,00";
            txtAliqCBS.Text = "0,00";
            txtValorFrete.Text = "0,00";
        }

        private void FrmCadItemNFeNFCe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmCadItemNFeNFCe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadItemNFeNFCe foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadItemNFeNFCe foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadItemNFeNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadItemNFeNFCe.");
                }
            }
        }


        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            txtCodigo.BackColor = Color.LightBlue;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (txtCodigo.Text == "")
                {
                    btnProcurarProduto_Click(sender, e);
                }
                else
                {
                    cbbProduto.Select();
                }
            }
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
                Limpar();
                //
                grbICMS.Enabled = false;
                //
                grbQuantidadePreco.Enabled = false;
                //
                grbDescontoAcrescimo.Enabled = false;
                //
                grbTotais.Enabled = false;
                //
                grbOutrosCalc.Enabled = false;
                //
                grbIBSCBS.Enabled = false;
            }
            else if (txtCodigo.Text.Trim() == "")
            {
                Limpar();
                //
                grbICMS.Enabled = false;
                //
                grbQuantidadePreco.Enabled = false;
                //
                grbDescontoAcrescimo.Enabled = false;
                //
                grbTotais.Enabled = false;
                //
                grbOutrosCalc.Enabled = false;
                //
                grbIBSCBS.Enabled = false;
            }
            else
            {
                try
                {
                    if (bllProduto.Sel_Prod_Codigo(txtCodigo.Text, "ATIVO") == null)
                    {
                        MessageBox.Show("Não existe Produto para o código informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtCodigo.Text = null;
                        cbbProduto.Text = null;
                        txtCodigo.Select();
                    }
                    else
                    {
                        cbbProduto.Items.Clear();
                        if (bllDFe.Sel_Produto_DFe("ATIVO") == null)
                        {
                            cbbProduto.Text = null;
                        }
                        else
                        {
                            cbbProduto.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Produto_DFe("ATIVO").Rows)
                            {
                                cbbProduto.Items.Add(dr["id_produto"].ToString() + "—" + dr["descricao"].ToString());
                            }
                        }
                        //
                        DataRow dr1 = bllProduto.Sel_Prod_Codigo(txtCodigo.Text, "ATIVO").Rows[0];
                        //
                        cbbProduto.Text = dr1["id_produto"].ToString() + "—" + dr1["descricao"].ToString();
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            cbbUM.Text = dr1["um"].ToString();
                        }
                        //
                        grbICMS.Enabled = true;
                        //
                        grbQuantidadePreco.Enabled = true;
                        //
                        grbDescontoAcrescimo.Enabled = true;
                        //
                        grbTotais.Enabled = true;
                        //
                        grbOutrosCalc.Enabled = true;
                        //
                        grbIPI.Enabled = true;
                        //
                        grbIBSCBS.Enabled = true;
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            txtNCM.Text = dr1["ncm"].ToString();
                        }
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            txtCEST.Text = dr1["cest"].ToString();
                        }
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            if (dr1["cst"].ToString() != "")
                            {
                                cbbCSTA.Text = dr1["cst"].ToString().Remove(1);
                                cbbCSTB.Text = dr1["cst"].ToString().Remove(0, 1);
                            }
                        }
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            txtAliqICMS.Text = Convert.ToDecimal(dr1["aliq_icms"]).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            cbbCSOSN.Text = dr1["csosn"].ToString();
                        }
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            txtAliqICMS.Text = Convert.ToDecimal(dr1["aliq_icms"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            txtPreco.Text = Convert.ToDecimal(dr1["preco"]).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            txtQuantidade.Text = "1,00";
                        }
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            txtQuantidadeEmbalagem.Text = "1,00";
                        }
                        //
                        txtTotal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item(txtPreco.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorBaseCalculo.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorICMS.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS(txtValorBaseCalculo.Text, txtAliqICMS.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorTotalReal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item_Desc_Acresc(txtTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorIPI.Text, txtValorFrete.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            if (Convert.ToDecimal(dr1["desconto_porc"]) > 0)
                            {
                                txtDescontoPorc.Text = Convert.ToDecimal(dr1["desconto_porc"]).ToString("n2", new CultureInfo("pt-BR"));
                                txtDescontoPorc_Leave(sender, e);
                            }
                            else
                            {
                                txtDescontoPorc.Text = "0,00";
                                txtValorDesconto.Text = "0,00";
                            }
                        }
                        //
                        if (txtCodigo.Text != _Ult_Codigo)
                        {
                            if (Convert.ToDecimal(dr1["acrescimo_porc"]) > 0)
                            {
                                txtAcrescimoPorc.Text = Convert.ToDecimal(dr1["acrescimo_porc"]).ToString("n2", new CultureInfo("pt-BR"));
                                txtAcrescimoPorc_Leave(sender, e);
                            }
                            else
                            {
                                txtAcrescimoPorc.Text = "0,00";
                                txtValorAcrescimo.Text = "0,00";
                            }
                        }
                        //
                        txtPreco_Leave(sender, e);
                        //
                        _Ult_Codigo = txtCodigo.Text;
                        //
                        cbbCFOP.Text = _CFOP;
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
                    Limpar();
                    //
                    grbICMS.Enabled = false;
                    //
                    grbQuantidadePreco.Enabled = false;
                    //
                    grbDescontoAcrescimo.Enabled = false;
                    //
                    grbTotais.Enabled = false;
                    //
                    grbOutrosCalc.Enabled = false;
                    //
                    grbIBSCBS.Enabled = false;
                    //
                    txtCodigo.Select();
                }
            }
            //
            txtCodigo.BackColor = Color.White;
        }

        private void cbbProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (grbICMS.Enabled == false)
                {
                    btnSair.Select();
                }
                else
                {
                    cbbUM.Select();
                }
            }
        }

        private void cbbProduto_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProduto_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCEST.Select();
            }
        }

        private void txtCEST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCSTA.Select();
            }
        }

        private void cbbCSTA_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCSTA_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCSTA_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCSTA_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCSTA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCSTB.Select();
            }
        }

        private void cbbCSTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtAliqICMS.Enabled == false)
                {
                    cbbCSOSN.Select();
                }
                else
                {
                    txtAliqICMS.Select();
                }
            }
        }

        private void cbbCSTB_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCSTB_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCSTB_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCSTB_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtAliqICMS_Enter(object sender, EventArgs e)
        {
            txtAliqICMS.BackColor = Color.LightBlue;
        }

        private void txtAliqICMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAliqICMS.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbCSOSN.Select();
            }
        }

        private void txtAliqICMS_Leave(object sender, EventArgs e)
        {
            if (txtAliqICMS.Text != "")
            {
                if (txtAliqICMS.Text.Contains("'") || txtAliqICMS.Text.Contains(";") || txtAliqICMS.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtAliqICMS.Text = "0,00";
                    txtAliqICMS.Select();
                }
                else
                {
                    try
                    {
                        txtAliqICMS.Text = Convert.ToDecimal(txtAliqICMS.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorICMS.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS(txtValorBaseCalculo.Text, txtAliqICMS.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqICMS.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqICMS.");
                        }
                        txtAliqICMS.Text = null;
                    }
                }
            }
            txtAliqICMS.BackColor = Color.White;
        }

        private void cbbCSOSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAliqICMSST.Select();
            }
        }

        private void cbbCSOSN_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCSOSN_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCSOSN_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCSOSN_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCFOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNCM.Select();
            }
        }

        private void cbbCFOP_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCFOP_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCFOP_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCFOP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisarCFOP_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisarCFOP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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
                txtQuantidadeEmbalagem.Select();
            }
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            if (txtQuantidade.Text != "")
            {
                if (txtQuantidade.Text.Contains("'") || txtQuantidade.Text.Contains(";") || txtQuantidade.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtQuantidade.Text = "0,00";
                    txtQuantidade.Select();
                }
                else
                {
                    try
                    {
                        txtQuantidade.Text = Convert.ToDecimal(txtQuantidade.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtTotal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item(txtPreco.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorAcrescimo_Leave(sender, e);
                        txtValorDesconto_Leave(sender, e);
                        //
                        txtValorBaseCalculo.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorICMS.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS(txtValorBaseCalculo.Text, txtAliqICMS.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        if (txtValorMVA.Text != "")
                        {
                            if (Convert.ToDecimal(txtValorMVA.Text) != 0)
                            {
                                txtValorBaseCalculoSt.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            else
                            {
                                txtValorBaseCalculoSt.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorBaseCalculoSt.Text = "0,00";
                        }
                        //
                        if (txtAliqICMSST.Text != "")
                        {
                            if (Convert.ToDecimal(txtAliqICMSST.Text) != 0)
                            {
                                txtValorICMSST.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS_ST(txtValorBaseCalculoSt.Text, txtAliqICMSST.Text.Trim(), txtPreco.Text, txtQuantidade.Text.Trim(), txtAliqICMS.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            else
                            {
                                txtValorICMSST.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorICMSST.Text = "0,00";
                        }
                        //
                        if (txtReducaoBCST.Text != "")
                        {
                            if (Convert.ToDecimal(txtReducaoBCST.Text) != 0)
                            {
                                string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim()), txtAliqICMSST.Text, txtReducaoBCST.Text, txtValorMVA.Text).Split('—');
                                //
                                txtValorReducaoICMSST.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorBaseCalculoSt.Text = txtValorReducaoICMSST.Text;
                                //
                                txtNovoValorICMSST.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorICMSST.Text = txtNovoValorICMSST.Text;
                            }
                            else
                            {
                                txtValorReducaoICMSST.Text = "0,00";
                                //
                                txtNovoValorICMSST.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorReducaoICMSST.Text = "0,00";
                            //
                            txtNovoValorICMSST.Text = "0,00";
                        }
                        //
                        if (txtReducaoBC.Text != "")
                        {
                            if (Convert.ToDecimal(txtReducaoBC.Text) != 0)
                            {
                                string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim()), txtAliqICMS.Text, txtReducaoBC.Text).Split('—');
                                //
                                txtValorReducaoICMS.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorBaseCalculo.Text = txtValorReducaoICMS.Text;
                                //
                                txtNovoValorICMS.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorICMS.Text = txtNovoValorICMS.Text;
                            }
                            else
                            {
                                txtValorReducaoICMS.Text = "0,00";
                                //
                                txtNovoValorICMS.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorReducaoICMS.Text = "0,00";
                            //
                            txtNovoValorICMS.Text = "0,00";
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
            }
            else
            {
                txtPreco.Text = "0,00";
            }
            txtQuantidade.BackColor = Color.White;
        }

        private void txtQuantidadeEmbalagem_Enter(object sender, EventArgs e)
        {
            txtQuantidadeEmbalagem.BackColor = Color.LightBlue;
        }

        private void txtQuantidadeEmbalagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtQuantidadeEmbalagem.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtPreco.Select();
            }
        }

        private void txtQuantidadeEmbalagem_Leave(object sender, EventArgs e)
        {
            if (txtQuantidadeEmbalagem.Text != "")
            {
                if (txtQuantidadeEmbalagem.Text.Contains("'") || txtQuantidadeEmbalagem.Text.Contains(";") || txtQuantidadeEmbalagem.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtQuantidadeEmbalagem.Text = "0,00";
                    txtQuantidadeEmbalagem.Select();
                }
                else
                {
                    try
                    {
                        txtQuantidadeEmbalagem.Text = Convert.ToDecimal(txtQuantidadeEmbalagem.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtTotal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item(txtPreco.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorAcrescimo_Leave(sender, e);
                        txtValorDesconto_Leave(sender, e);
                        //
                        txtValorBaseCalculo.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorICMS.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS(txtValorBaseCalculo.Text, txtAliqICMS.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        if (txtValorMVA.Text != "")
                        {
                            if (Convert.ToDecimal(txtValorMVA.Text) != 0)
                            {
                                txtValorBaseCalculoSt.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            else
                            {
                                txtValorBaseCalculoSt.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorBaseCalculoSt.Text = "0,00";
                        }
                        //
                        if (txtAliqICMSST.Text != "")
                        {
                            if (Convert.ToDecimal(txtAliqICMSST.Text) != 0)
                            {
                                txtValorICMSST.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS_ST(txtValorBaseCalculoSt.Text, txtAliqICMSST.Text.Trim(), txtPreco.Text, txtQuantidade.Text.Trim(), txtAliqICMS.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            else
                            {
                                txtValorICMSST.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorICMSST.Text = "0,00";
                        }
                        //
                        if (txtReducaoBCST.Text != "")
                        {
                            if (Convert.ToDecimal(txtReducaoBCST.Text) != 0)
                            {
                                string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim()), txtAliqICMSST.Text, txtReducaoBCST.Text, txtValorMVA.Text).Split('—');
                                //
                                txtValorReducaoICMSST.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorBaseCalculoSt.Text = txtValorReducaoICMSST.Text;
                                //
                                txtNovoValorICMSST.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorICMSST.Text = txtNovoValorICMSST.Text;
                            }
                            else
                            {
                                txtValorReducaoICMSST.Text = "0,00";
                                //
                                txtNovoValorICMSST.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorReducaoICMSST.Text = "0,00";
                            //
                            txtNovoValorICMSST.Text = "0,00";
                        }
                        //
                        if (txtReducaoBC.Text != "")
                        {
                            if (Convert.ToDecimal(txtReducaoBC.Text) != 0)
                            {
                                string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim()), txtAliqICMS.Text, txtReducaoBC.Text).Split('—');
                                //
                                txtValorReducaoICMS.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorBaseCalculo.Text = txtValorReducaoICMS.Text;
                                //
                                txtNovoValorICMS.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorICMS.Text = txtNovoValorICMS.Text;
                            }
                            else
                            {
                                txtValorReducaoICMS.Text = "0,00";
                                //
                                txtNovoValorICMS.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorReducaoICMS.Text = "0,00";
                            //
                            txtNovoValorICMS.Text = "0,00";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtQuantidadeEmbalagem.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtQuantidadeEmbalagem.");
                        }
                        txtQuantidadeEmbalagem.Text = null;
                    }
                }
            }
            else
            {
                txtQuantidadeEmbalagem.Text = "0,00";
            }
            txtQuantidadeEmbalagem.BackColor = Color.White;
        }

        private void txtPreco_Enter(object sender, EventArgs e)
        {
            txtPreco.BackColor = Color.LightBlue;
        }

        private void txtPreco_Leave(object sender, EventArgs e)
        {
            if (txtPreco.Text != "")
            {
                if (txtPreco.Text.Contains("'") || txtPreco.Text.Contains(";") || txtPreco.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtPreco.Text = "0,00";
                    txtPreco.Select();
                }
                else
                {
                    try
                    {
                        txtPreco.Text = Convert.ToDecimal(txtPreco.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtTotal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item(txtPreco.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorAcrescimo_Leave(sender, e);
                        txtValorDesconto_Leave(sender, e);
                        //
                        txtValorBaseCalculo.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorICMS.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS(txtValorBaseCalculo.Text, txtAliqICMS.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        if (txtValorMVA.Text != "")
                        {
                            if (Convert.ToDecimal(txtValorMVA.Text) != 0)
                            {
                                txtValorBaseCalculoSt.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            else
                            {
                                txtValorBaseCalculoSt.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorBaseCalculoSt.Text = "0,00";
                        }
                        //
                        if (txtAliqICMSST.Text != "")
                        {
                            if (Convert.ToDecimal(txtAliqICMSST.Text) != 0)
                            {
                                txtValorICMSST.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS_ST(txtValorBaseCalculoSt.Text, txtAliqICMSST.Text.Trim(), txtPreco.Text, txtQuantidade.Text.Trim(), txtAliqICMS.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            else
                            {
                                txtValorICMSST.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorICMSST.Text = "0,00";
                        }
                        //
                        if (txtReducaoBCST.Text != "")
                        {
                            if (Convert.ToDecimal(txtReducaoBCST.Text) != 0)
                            {
                                string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim()), txtAliqICMSST.Text, txtReducaoBCST.Text, txtValorMVA.Text).Split('—');
                                //
                                txtValorReducaoICMSST.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorBaseCalculoSt.Text = txtValorReducaoICMSST.Text;
                                //
                                txtNovoValorICMSST.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorICMSST.Text = txtNovoValorICMSST.Text;
                            }
                            else
                            {
                                txtValorReducaoICMSST.Text = "0,00";
                                //
                                txtNovoValorICMSST.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorReducaoICMSST.Text = "0,00";
                            //
                            txtNovoValorICMSST.Text = "0,00";
                        }
                        //
                        if (txtReducaoBC.Text != "")
                        {
                            if (Convert.ToDecimal(txtReducaoBC.Text) != 0)
                            {
                                string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim()), txtAliqICMS.Text, txtReducaoBC.Text).Split('—');
                                //
                                txtValorReducaoICMS.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorBaseCalculo.Text = txtValorReducaoICMS.Text;
                                //
                                txtNovoValorICMS.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorICMS.Text = txtNovoValorICMS.Text;
                            }
                            else
                            {
                                txtValorReducaoICMS.Text = "0,00";
                                //
                                txtNovoValorICMS.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorReducaoICMS.Text = "0,00";
                            //
                            txtNovoValorICMS.Text = "0,00";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPreco.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPreco.");
                        }
                        txtPreco.Text = null;
                    }
                }
            }
            else
            {
                txtPreco.Text = "0,00";
            }
            txtPreco.BackColor = Color.White;
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPreco.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtTotal.Select();
            }
        }

        private void txtDescontoPorc_Enter(object sender, EventArgs e)
        {
            txtDescontoPorc.BackColor = Color.LightBlue;
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
                txtDescontoPorc.Text = "0,00";
                txtDescontoPorc.Select();
            }
            else
            {
                try
                {
                    if (txtDescontoPorc.Text == "")
                    {
                        txtDescontoPorc.Text = "0";
                    }
                    //
                    txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorDesconto.Text = Convert.ToDecimal(bllDFe.Calculo_Desconto(txtTotal.Text, txtDescontoPorc.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorBaseCalculo.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorTotalReal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item_Desc_Acresc(txtTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorIPI.Text, txtValorFrete.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorICMS.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS(txtValorBaseCalculo.Text, txtAliqICMS.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    if (txtValorMVA.Text != "")
                    {
                        if (Convert.ToDecimal(txtValorMVA.Text) != 0)
                        {
                            txtValorBaseCalculoSt.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorBaseCalculoSt.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorBaseCalculoSt.Text = "0,00";
                    }
                    //
                    if (txtAliqICMSST.Text != "")
                    {
                        if (Convert.ToDecimal(txtAliqICMSST.Text) > 0)
                        {
                            txtValorICMSST.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS_ST(txtValorBaseCalculoSt.Text, txtAliqICMSST.Text.Trim(), txtPreco.Text, txtQuantidade.Text.Trim(), txtAliqICMS.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorICMSST.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorICMSST.Text = "0,00";
                    }
                    //
                    if (txtReducaoBCST.Text != "")
                    {
                        if (Convert.ToDecimal(txtReducaoBCST.Text) != 0)
                        {
                            string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim()), txtAliqICMSST.Text, txtReducaoBCST.Text, txtValorMVA.Text).Split('—');
                            //
                            txtValorReducaoICMSST.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorBaseCalculoSt.Text = txtValorReducaoICMSST.Text;
                            //
                            txtNovoValorICMSST.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorICMSST.Text = txtNovoValorICMSST.Text;
                        }
                        else
                        {
                            txtValorReducaoICMSST.Text = "0,00";
                            //
                            txtNovoValorICMSST.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorReducaoICMSST.Text = "0,00";
                        //
                        txtNovoValorICMSST.Text = "0,00";
                    }
                    //
                    if (txtReducaoBC.Text != "")
                    {
                        if (Convert.ToDecimal(txtReducaoBC.Text) != 0)
                        {
                            string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim()), txtAliqICMS.Text, txtReducaoBC.Text).Split('—');
                            //
                            txtValorReducaoICMS.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorBaseCalculo.Text = txtValorReducaoICMS.Text;
                            //
                            txtNovoValorICMS.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorICMS.Text = txtNovoValorICMS.Text;
                        }
                        else
                        {
                            txtValorReducaoICMS.Text = "0,00";
                            //
                            txtNovoValorICMS.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorReducaoICMS.Text = "0,00";
                        //
                        txtNovoValorICMS.Text = "0,00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto  txtDescontoPorc.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto  txtDescontoPorc.");
                    }
                    txtDescontoPorc.Text = null;
                }
            }
            txtDescontoPorc.BackColor = Color.White;
        }

        private void txtValorDesconto_Enter(object sender, EventArgs e)
        {
            txtValorDesconto.BackColor = Color.LightBlue;
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

        private void txtValorDesconto_Leave(object sender, EventArgs e)
        {

            if (txtValorDesconto.Text.Contains("'") || txtValorDesconto.Text.Contains(";") || txtValorDesconto.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtValorDesconto.Text = "0,00";
                txtValorDesconto.Select();
            }
            else
            {
                try
                {
                    if (txtValorDesconto.Text == "")
                    {
                        txtValorDesconto.Text = "0";
                    }
                    //
                    txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtDescontoPorc.Text = Convert.ToDecimal(bllDFe.Calculo_ValorDesconto(txtTotal.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorBaseCalculo.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorTotalReal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item_Desc_Acresc(txtTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorIPI.Text, txtValorFrete.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorICMS.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS(txtValorBaseCalculo.Text, txtAliqICMS.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    if (txtValorMVA.Text != "")
                    {
                        if (Convert.ToDecimal(txtValorMVA.Text) != 0)
                        {
                            txtValorBaseCalculoSt.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorBaseCalculoSt.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorBaseCalculoSt.Text = "0,00";
                    }
                    //
                    if (txtAliqICMSST.Text != "")
                    {
                        if (Convert.ToDecimal(txtAliqICMSST.Text) > 0)
                        {
                            txtValorICMSST.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS_ST(txtValorBaseCalculoSt.Text, txtAliqICMSST.Text.Trim(), txtPreco.Text, txtQuantidade.Text.Trim(), txtAliqICMS.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorICMSST.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorICMSST.Text = "0,00";
                    }
                    //
                    if (txtReducaoBCST.Text != "")
                    {
                        if (Convert.ToDecimal(txtReducaoBCST.Text) != 0)
                        {
                            string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim()), txtAliqICMSST.Text, txtReducaoBCST.Text, txtValorMVA.Text).Split('—');
                            //
                            txtValorReducaoICMSST.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorBaseCalculoSt.Text = txtValorReducaoICMSST.Text;
                            //
                            txtNovoValorICMSST.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorICMSST.Text = txtNovoValorICMSST.Text;
                        }
                        else
                        {
                            txtValorReducaoICMSST.Text = "0,00";
                            //
                            txtNovoValorICMSST.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorReducaoICMSST.Text = "0,00";
                        //
                        txtNovoValorICMSST.Text = "0,00";
                    }
                    //
                    if (txtReducaoBC.Text != "")
                    {
                        if (Convert.ToDecimal(txtReducaoBC.Text) != 0)
                        {
                            string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim()), txtAliqICMS.Text, txtReducaoBC.Text).Split('—');
                            //
                            txtValorReducaoICMS.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorBaseCalculo.Text = txtValorReducaoICMS.Text;
                            //
                            txtNovoValorICMS.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorICMS.Text = txtNovoValorICMS.Text;
                        }
                        else
                        {
                            txtValorReducaoICMS.Text = "0,00";
                            //
                            txtNovoValorICMS.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorReducaoICMS.Text = "0,00";
                        //
                        txtNovoValorICMS.Text = "0,00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto  txtValorDesconto.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto  txtValorDesconto.");
                    }
                    txtValorDesconto.Text = null;
                }
            }
            txtValorDesconto.BackColor = Color.White;
        }

        private void txtAcrescimoPorc_Enter(object sender, EventArgs e)
        {
            txtAcrescimoPorc.BackColor = Color.LightBlue;
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

        private void txtAcrescimoPorc_Leave(object sender, EventArgs e)
        {
            if (txtAcrescimoPorc.Text.Contains("'") || txtAcrescimoPorc.Text.Contains(";") || txtAcrescimoPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtAcrescimoPorc.Text = "0,00";
                txtAcrescimoPorc.Select();
            }
            else
            {
                try
                {
                    if (txtAcrescimoPorc.Text == "")
                    {
                        txtAcrescimoPorc.Text = "0";
                    }
                    //
                    txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorAcrescimo.Text = Convert.ToDecimal(bllDFe.Calculo_Acrescimo(txtTotal.Text, txtAcrescimoPorc.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorBaseCalculo.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorTotalReal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item_Desc_Acresc(txtTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorIPI.Text, txtValorFrete.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorICMS.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS(txtValorBaseCalculo.Text, txtAliqICMS.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    if (txtValorMVA.Text != "")
                    {
                        if (Convert.ToDecimal(txtValorMVA.Text) != 0)
                        {
                            txtValorBaseCalculoSt.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorBaseCalculoSt.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorBaseCalculoSt.Text = "0,00";
                    }
                    //
                    if (txtAliqICMSST.Text != "")
                    {
                        if (Convert.ToDecimal(txtAliqICMSST.Text) > 0)
                        {
                            txtValorICMSST.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS_ST(txtValorBaseCalculoSt.Text, txtAliqICMSST.Text.Trim(), txtPreco.Text, txtQuantidade.Text.Trim(), txtAliqICMS.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorICMSST.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorICMSST.Text = "0,00";
                    }
                    //
                    if (txtReducaoBCST.Text != "")
                    {
                        if (Convert.ToDecimal(txtReducaoBCST.Text) != 0)
                        {
                            string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim()), txtAliqICMSST.Text, txtReducaoBCST.Text, txtValorMVA.Text).Split('—');
                            //
                            txtValorReducaoICMSST.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorBaseCalculoSt.Text = txtValorReducaoICMSST.Text;
                            //
                            txtNovoValorICMSST.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorICMSST.Text = txtNovoValorICMSST.Text;
                        }
                        else
                        {
                            txtValorReducaoICMSST.Text = "0,00";
                            //
                            txtNovoValorICMSST.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorReducaoICMSST.Text = "0,00";
                        //
                        txtNovoValorICMSST.Text = "0,00";
                    }
                    //
                    if (txtReducaoBC.Text != "")
                    {
                        if (Convert.ToDecimal(txtReducaoBC.Text) != 0)
                        {
                            string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim()), txtAliqICMS.Text, txtReducaoBC.Text).Split('—');
                            //
                            txtValorReducaoICMS.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorBaseCalculo.Text = txtValorReducaoICMS.Text;
                            //
                            txtNovoValorICMS.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorICMS.Text = txtNovoValorICMS.Text;
                        }
                        else
                        {
                            txtValorReducaoICMS.Text = "0,00";
                            //
                            txtNovoValorICMS.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorReducaoICMS.Text = "0,00";
                        //
                        txtNovoValorICMS.Text = "0,00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto  txtAcrescimoPorc.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto  txtAcrescimoPorc.");
                    }
                    txtAcrescimoPorc.Text = null;
                }
            }
            txtAcrescimoPorc.BackColor = Color.White;
        }

        private void txtValorAcrescimo_Enter(object sender, EventArgs e)
        {
            txtValorAcrescimo.BackColor = Color.LightBlue;
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
                txtAliqIPI.Select();
            }
        }

        private void txtValorAcrescimo_Leave(object sender, EventArgs e)
        {

            if (txtValorAcrescimo.Text.Contains("'") || txtValorAcrescimo.Text.Contains(";") || txtValorAcrescimo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtValorAcrescimo.Text = "0,00";
                txtValorAcrescimo.Select();
            }
            else
            {
                try
                {
                    if (txtValorAcrescimo.Text == "")
                    {
                        txtValorAcrescimo.Text = "0";
                    }
                    //
                    txtValorAcrescimo.Text = Convert.ToDecimal(txtValorAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtAcrescimoPorc.Text = Convert.ToDecimal(bllDFe.Calculo_ValorAcrescimo(txtTotal.Text, txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorBaseCalculo.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorTotalReal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item_Desc_Acresc(txtTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorIPI.Text, txtValorFrete.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorICMS.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS(txtValorBaseCalculo.Text, txtAliqICMS.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    if (txtValorMVA.Text != "")
                    {
                        if (Convert.ToDecimal(txtValorMVA.Text) != 0)
                        {
                            txtValorBaseCalculoSt.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorBaseCalculoSt.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorBaseCalculoSt.Text = "0,00";
                    }
                    //
                    if (txtAliqICMSST.Text != "")
                    {
                        if (Convert.ToDecimal(txtAliqICMSST.Text) > 0)
                        {
                            txtValorICMSST.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS_ST(txtValorBaseCalculoSt.Text, txtAliqICMSST.Text.Trim(), txtPreco.Text, txtQuantidade.Text.Trim(), txtAliqICMS.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorICMSST.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorICMSST.Text = "0,00";
                    }
                    //
                    if (txtReducaoBCST.Text != "")
                    {
                        if (Convert.ToDecimal(txtReducaoBCST.Text) != 0)
                        {
                            string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim()), txtAliqICMSST.Text, txtReducaoBCST.Text, txtValorMVA.Text).Split('—');
                            //
                            txtValorReducaoICMSST.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorBaseCalculoSt.Text = txtValorReducaoICMSST.Text;
                            //
                            txtNovoValorICMSST.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorICMSST.Text = txtNovoValorICMSST.Text;
                        }
                        else
                        {
                            txtValorReducaoICMSST.Text = "0,00";
                            //
                            txtNovoValorICMSST.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorReducaoICMSST.Text = "0,00";
                        //
                        txtNovoValorICMSST.Text = "0,00";
                    }
                    //
                    if (txtReducaoBC.Text != "")
                    {
                        if (Convert.ToDecimal(txtReducaoBC.Text) != 0)
                        {
                            string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim()), txtAliqICMS.Text, txtReducaoBC.Text).Split('—');
                            //
                            txtValorReducaoICMS.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorBaseCalculo.Text = txtValorReducaoICMS.Text;
                            //
                            txtNovoValorICMS.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorICMS.Text = txtNovoValorICMS.Text;
                        }
                        else
                        {
                            txtValorReducaoICMS.Text = "0,00";
                            //
                            txtNovoValorICMS.Text = "0,00";
                        }
                    }
                    else
                    {
                        txtValorReducaoICMS.Text = "0,00";
                        //
                        txtNovoValorICMS.Text = "0,00";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto  txtValorAcrescimo.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto  txtValorAcrescimo.");
                    }
                    txtValorAcrescimo.Text = null;
                }
            }
            txtValorAcrescimo.BackColor = Color.White;
        }

        private void btnNovo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseLeave(object sender, EventArgs e)
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

        private void btnProcurarProduto_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (grbICMS.Enabled != false)
            {
                btnPesquisarCFOP.Enabled = false;
            }
            using (FrmPesqProduto Prod = new FrmPesqProduto(3, null, _Usuario, _Cod_PDV_Computador, 0, null))
            {
                if (Prod.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbProduto.Items.Clear();
                        if (bllDFe.Sel_Produto_DFe("ATIVO") == null)
                        {
                            cbbProduto.Text = null;
                        }
                        else
                        {
                            cbbProduto.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Produto_DFe("ATIVO").Rows)
                            {
                                cbbProduto.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        //
                        cbbProduto.Text = bllDFe._FornDFe_Produto_PesqProduto_Tabela;
                        bllDFe._FornDFe_Produto_PesqProduto_Tabela = null;
                        cbbProduto.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProduto.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProduto.");
                        }
                        cbbProduto.Text = null;
                    }
                }
                this.Enabled = true;
            }
        }

        private void cbbCSTB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCSTB.Text == "00")
            {
                txtAliqICMS.Enabled = true;
                txtAliqICMS.Text = "20,50";
            }
            else if (cbbCSTB.Text == "10")
            {
                txtAliqICMS.Enabled = true;
                txtAliqICMS.Text = "20,50";
            }
            else if (cbbCSTB.Text == "20")
            {
                txtAliqICMS.Enabled = true;
                txtAliqICMS.Text = "20,50";
            }
            else if (cbbCSTB.Text == "30")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSTB.Text == "40")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSTB.Text == "41")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSTB.Text == "50")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSTB.Text == "51")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSTB.Text == "60")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSTB.Text == "70")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSTB.Text == "90")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            //
            txtAliqICMS_Leave(sender, e);
        }

        string _Ult_Codigo;

        private void cbbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbProduto.Text != "")
                {
                    string[] items = cbbProduto.Text.Split('—');
                    txtCodigo.Text = items[0];
                    //
                    DataRow dr = bllProduto.Sel_Prod_Codigo(items[0], "ATIVO").Rows[0];
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        cbbUM.Text = dr["um"].ToString();
                    }
                    //
                    grbICMS.Enabled = true;
                    //
                    grbQuantidadePreco.Enabled = true;
                    //
                    grbDescontoAcrescimo.Enabled = true;
                    //
                    grbTotais.Enabled = true;
                    //
                    grbOutrosCalc.Enabled = true;
                    //
                    grbIPI.Enabled = true;
                    //
                    grbIBSCBS.Enabled = true;
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        txtNCM.Text = dr["ncm"].ToString();
                    }
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        txtCEST.Text = dr["cest"].ToString();
                    }
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        if (dr["cst"].ToString() != "")
                        {
                            cbbCSTA.Text = dr["cst"].ToString().Remove(1);
                            cbbCSTB.Text = dr["cst"].ToString().Remove(0, 1);
                        }
                    }
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        txtAliqICMS.Text = Convert.ToDecimal(dr["aliq_icms"]).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        cbbCSOSN.Text = dr["csosn"].ToString();
                    }
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        txtAliqICMS.Text = Convert.ToDecimal(dr["aliq_icms"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        txtPreco.Text = Convert.ToDecimal(dr["preco"]).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        txtQuantidade.Text = "1,00";
                    }
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        txtQuantidadeEmbalagem.Text = "1,00";
                    }
                    //
                    txtTotal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item(txtPreco.Text.Trim(), txtQuantidade.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorBaseCalculo.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorICMS.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS(txtValorBaseCalculo.Text, txtAliqICMS.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    txtValorTotalReal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item_Desc_Acresc(txtTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorIPI.Text, txtValorFrete.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        if (Convert.ToDecimal(dr["desconto_porc"]) > 0)
                        {
                            txtDescontoPorc.Text = Convert.ToDecimal(dr["desconto_porc"]).ToString("n2", new CultureInfo("pt-BR"));
                            txtDescontoPorc_Leave(sender, e);
                        }
                        else
                        {
                            txtDescontoPorc.Text = "0,00";
                            txtValorDesconto.Text = "0,00";
                        }
                    }
                    //
                    if (txtCodigo.Text != _Ult_Codigo)
                    {
                        if (Convert.ToDecimal(dr["acrescimo_porc"]) > 0)
                        {
                            txtAcrescimoPorc.Text = Convert.ToDecimal(dr["acrescimo_porc"]).ToString("n2", new CultureInfo("pt-BR"));
                            txtAcrescimoPorc_Leave(sender, e);
                        }
                        else
                        {
                            txtAcrescimoPorc.Text = "0,00";
                            txtValorAcrescimo.Text = "0,00";
                        }
                    }
                    //
                    cbbCSTAIBSCBS.Text = "0";
                    cbbCSTBIBSCBS.Text = "00";
                    cbbCClassTrib.Text = "00001";
                    txtAliqIBSMun.Text = "0,00";
                    txtAliqIBSEstadual.Text = "0,10";
                    txtAliqCBS.Text = "0,90";
                    //
                    txtPreco_Leave(sender, e);
                    //
                    _Ult_Codigo = items[0];
                    //
                    cbbCFOP.Text = _CFOP;
                    //
                    btnSalvar.Enabled = true;
                    //
                    if (bllProduto.Sel_Alert_Est_Max_Min_Prod(items[0]) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(items[0], "1") == true)
                        {
                            MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                else
                {
                    grbIPI.Enabled = false;
                    //
                    Limpar();
                    //
                    grbICMS.Enabled = false;
                    //
                    grbQuantidadePreco.Enabled = false;
                    //
                    grbDescontoAcrescimo.Enabled = false;
                    //
                    grbTotais.Enabled = false;
                    //
                    grbOutrosCalc.Enabled = false;
                    //
                    grbIBSCBS.Enabled = false;
                    //
                    btnSalvar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do combobox cbbProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindexchanged do combobox cbbProduto.");
                }
                txtCodigo.Text = null;
                cbbProduto.Text = null;
            }
        }

        private void btnPesquisarCFOP_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqCFOP Cfop = new FrmPesqCFOP(1, _Finalidade, _Usuario, _Cod_PDV_Computador))
            {
                if (Cfop.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbCFOP.Items.Clear();
                        if (bllDFe.Sel_Cfop_Dfe(_Finalidade) == null)
                        {
                            cbbCFOP.Text = null;
                        }
                        else
                        {
                            cbbCFOP.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Cfop_Dfe(_Finalidade).Rows)
                            {
                                cbbCFOP.Items.Add((dr["cod_cfop"].ToString()));
                            }
                        }
                        //
                        string[] items = bllDFe._FornDFe_Cfop_PesqCfop_Tabela.Split('—');
                        cbbCFOP.Text = items[0];
                        bllDFe._FornDFe_Cfop_PesqCfop_Tabela = null;
                        cbbCFOP.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarNatOperacao.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarNatOperacao.");
                        }
                        cbbCFOP.Text = null;
                    }
                }
                this.Enabled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                txtPreco_Leave(sender, e);
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (cbbUM.Text == "" || cbbProduto.Text == "" || cbbCFOP.Text == "" || txtNCM.Text == "" || cbbCSTA.Text == "" || txtPreco.Text.Trim() == "" || txtAliqICMS.Text.Trim() == "" || cbbCSTB.Text == "" || cbbCSOSN.Text == "" || txtQuantidade.Text == "" || txtPreco.Text == "" || txtQuantidadeEmbalagem.Text == "" || cbbCSTAIBSCBS.Text == "" || cbbCSTBIBSCBS.Text == "" || cbbCClassTrib.Text == "" || txtAliqIBSMun.Text == "" || txtAliqIBSEstadual.Text == "" || txtAliqCBS.Text == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Descrição do Produto ], [ NCM ],\n[ CST ], [ Alíquota ], [ CSOSN ], [ CFOP ],\n[ Quantidade ], [ Quantidade da Embalagem ]\n[ Valor Unitário/Preço ], [ UM ] e [ IBS e CBS ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbProduto.Select();
                    }
                    else if (txtPreco.Text.Trim() == "0,00" || txtPreco.Text.Trim() == "0")
                    {
                        MessageBox.Show("Valor informado no campo Preço é inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtPreco.Select();
                    }
                    else if (txtQuantidadeEmbalagem.Text.Trim() == "0,00" || txtQuantidadeEmbalagem.Text.Trim() == "0")
                    {
                        MessageBox.Show("Valor informado no campo Quantidade de Embalagem é inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtQuantidadeEmbalagem.Select();
                    }
                    else if (txtQuantidade.Text.Trim() == "0,00" || txtQuantidade.Text.Trim() == "0")
                    {
                        MessageBox.Show("Valor informado no campo Quantidade é inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtQuantidade.Select();
                    }
                    else
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (_Formulario == 0 || _Formulario == 3 || _Formulario == 4)
                            {
                                bllDFe.Alterar_Items(_Cod_Item, cbbProduto.Text, txtNCM.Text.Trim(), txtCEST.Text.Trim(), cbbCSTA.Text + cbbCSTB.Text, txtAliqICMS.Text.Trim(), cbbCSOSN.Text, cbbCFOP.Text, txtQuantidade.Text.Trim(), txtQuantidadeEmbalagem.Text.Trim(), txtTotal.Text, txtPreco.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorTotalReal.Text, txtValorICMS.Text.Trim(), txtValorBaseCalculo.Text.Trim(), _Cod_Dfe, txtValorICMSST.Text, txtAliqICMSST.Text, txtValorMVA.Text, txtValorBaseCalculoSt.Text, txtReducaoBC.Text, cbbUM.Text, txtTotalAproxTrib.Text.Trim(), txtAliqIPI.Text, txtValorIPI.Text, txtReducaoBCST.Text, cbbCSTAIBSCBS.Text + cbbCSTBIBSCBS.Text, cbbCClassTrib.Text, txtAliqIBSMun.Text, txtAliqIBSEstadual.Text, txtAliqCBS.Text, txtValorFrete.Text);
                                //
                                string[] items = cbbProduto.Text.Split('—');
                                //
                                if (_Formulario == 0)
                                {
                                    bllDFe.Atualizar_Saldo_Produto_Exclusao_Dfe(items[0], _Quantidade);
                                    //
                                    bllProduto.Adicionar_Saldo_Produto(items[0], txtQuantidade.Text);
                                }
                            }
                            else if (_Formulario == 1)
                            {
                                if (_Cod_Dfe == null)
                                {
                                    bllDFe.Alterar_Items_Temp(_Cod_Item, cbbProduto.Text, txtNCM.Text.Trim(), txtCEST.Text.Trim(), cbbCSTA.Text + cbbCSTB.Text, txtAliqICMS.Text.Trim(), cbbCSOSN.Text, cbbCFOP.Text, txtQuantidade.Text.Trim(), txtQuantidadeEmbalagem.Text.Trim(), txtTotal.Text, txtPreco.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorTotalReal.Text, txtValorICMS.Text.Trim(), txtValorBaseCalculo.Text.Trim(), bllConexao._Codigo_Conexao, txtValorICMSST.Text, txtAliqICMSST.Text, txtValorMVA.Text, txtValorBaseCalculoSt.Text, txtReducaoBC.Text, cbbUM.Text, txtTotalAproxTrib.Text.Trim(), txtValorIPI.Text, txtAliqIPI.Text, txtReducaoBCST.Text, cbbCSTAIBSCBS.Text + cbbCSTBIBSCBS.Text, cbbCClassTrib.Text, txtAliqIBSMun.Text, txtAliqIBSEstadual.Text, txtAliqCBS.Text, txtValorFrete.Text);
                                }
                                else
                                {
                                    bllDFe.Alterar_Items(_Cod_Item, cbbProduto.Text, txtNCM.Text.Trim(), txtCEST.Text.Trim(), cbbCSTA.Text + cbbCSTB.Text, txtAliqICMS.Text.Trim(), cbbCSOSN.Text, cbbCFOP.Text, txtQuantidade.Text.Trim(), txtQuantidadeEmbalagem.Text.Trim(), txtTotal.Text, txtPreco.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorTotalReal.Text, txtValorICMS.Text.Trim(), txtValorBaseCalculo.Text.Trim(), _Cod_Dfe, txtValorICMSST.Text, txtAliqICMSST.Text, txtValorMVA.Text, txtValorBaseCalculoSt.Text, txtReducaoBC.Text, cbbUM.Text, txtTotalAproxTrib.Text.Trim(), txtValorIPI.Text, txtAliqIPI.Text, txtReducaoBCST.Text, cbbCSTAIBSCBS.Text + cbbCSTBIBSCBS.Text, cbbCClassTrib.Text, txtAliqIBSMun.Text, txtAliqIBSEstadual.Text, txtAliqCBS.Text, txtValorFrete.Text);
                                }
                            }
                            //
                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (_Formulario == 0 || _Formulario == 3)
                            {
                                bllDFe.Salvar_Items(_Cod_Item, cbbProduto.Text, txtNCM.Text.Trim(), txtCEST.Text.Trim(), cbbCSTA.Text + cbbCSTB.Text, txtAliqICMS.Text.Trim(), cbbCSOSN.Text, cbbCFOP.Text, txtQuantidade.Text.Trim(), txtQuantidadeEmbalagem.Text.Trim(), txtTotal.Text, txtPreco.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorTotalReal.Text, txtValorICMS.Text.Trim(), txtValorBaseCalculo.Text.Trim(), _Cod_Dfe, txtValorICMSST.Text, txtAliqICMSST.Text, txtValorMVA.Text, txtValorBaseCalculoSt.Text, txtReducaoBC.Text, cbbUM.Text, txtTotalAproxTrib.Text.Trim(), txtAliqIPI.Text, txtValorIPI.Text, txtReducaoBCST.Text, cbbCSTAIBSCBS.Text + cbbCSTBIBSCBS.Text, cbbCClassTrib.Text, txtAliqIBSMun.Text, txtAliqIBSEstadual.Text, txtAliqCBS.Text, txtValorFrete.Text);
                                //
                                if (_Formulario == 0)
                                {
                                    string[] items = cbbProduto.Text.Split('—');
                                    //
                                    bllProduto.Adicionar_Saldo_Produto(items[0], txtQuantidade.Text);
                                }
                            }
                            else if (_Formulario == 1)
                            {
                                if (_Cod_Dfe == null)
                                {
                                    bllDFe.Salvar_Items_Temp(_Cod_Item, cbbProduto.Text, txtNCM.Text.Trim(), txtCEST.Text.Trim(), cbbCSTA.Text + cbbCSTB.Text, txtAliqICMS.Text.Trim(), cbbCSOSN.Text, cbbCFOP.Text, txtQuantidade.Text.Trim(), txtQuantidadeEmbalagem.Text.Trim(), txtTotal.Text, txtPreco.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorTotalReal.Text, txtValorICMS.Text.Trim(), txtValorBaseCalculo.Text.Trim(), bllConexao._Codigo_Conexao, txtValorICMSST.Text, txtAliqICMSST.Text, txtValorMVA.Text, txtValorBaseCalculoSt.Text, txtReducaoBC.Text, cbbUM.Text, txtTotalAproxTrib.Text.Trim(), txtValorIPI.Text, txtAliqIPI.Text, txtReducaoBCST.Text, cbbCSTAIBSCBS.Text + cbbCSTBIBSCBS.Text, cbbCClassTrib.Text, txtAliqIBSMun.Text, txtAliqIBSEstadual.Text, txtAliqCBS.Text, txtValorFrete.Text);
                                }
                                else
                                {
                                    bllDFe.Salvar_Items(_Cod_Item, cbbProduto.Text, txtNCM.Text.Trim(), txtCEST.Text.Trim(), cbbCSTA.Text + cbbCSTB.Text, txtAliqICMS.Text.Trim(), cbbCSOSN.Text, cbbCFOP.Text, txtQuantidade.Text.Trim(), txtQuantidadeEmbalagem.Text.Trim(), txtTotal.Text, txtPreco.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorTotalReal.Text, txtValorICMS.Text.Trim(), txtValorBaseCalculo.Text.Trim(), _Cod_Dfe, txtValorICMSST.Text, txtAliqICMSST.Text, txtValorMVA.Text, txtValorBaseCalculoSt.Text, txtReducaoBC.Text, cbbUM.Text, txtTotalAproxTrib.Text.Trim(), txtAliqIPI.Text, txtValorIPI.Text, txtReducaoBCST.Text, cbbCSTAIBSCBS.Text + cbbCSTBIBSCBS.Text, cbbCClassTrib.Text, txtAliqIBSMun.Text, txtAliqIBSEstadual.Text, txtAliqCBS.Text, txtValorFrete.Text);
                                }
                            }
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    cbbProduto.Select();
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
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                Limpar();
                grbICMS.Enabled = false;
                grbDescontoAcrescimo.Enabled = false;
                grbQuantidadePreco.Enabled = false;
                grbTotais.Enabled = false;
                grbOutrosCalc.Enabled = false;
                grbIBSCBS.Enabled = false;

                txtCodigo.Select();
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere os dados.\n\n1 - Ao finalizar o preenchimento dos campos clique no botão [ Salvar ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescontoPorc.Select();
            }
        }

        private void txtValorICMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorBaseCalculoSt.Select();
            }
        }

        private void txtValorBaseCalculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorICMS.Select();
            }
        }

        private void txtValorTotalReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void txtAliqICMSST_Leave(object sender, EventArgs e)
        {
            if (txtAliqICMSST.Text != "")
            {
                if (txtAliqICMSST.Text.Contains("'") || txtAliqICMSST.Text.Contains(";") || txtAliqICMSST.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtAliqICMSST.Text = "0,00";
                    txtAliqICMSST.Select();
                }
                else
                {
                    try
                    {
                        txtAliqICMSST.Text = Convert.ToDecimal(txtAliqICMSST.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        if (txtValorMVA.Text != "")
                        {
                            if (Convert.ToDecimal(txtValorMVA.Text) != 0)
                            {
                                txtValorBaseCalculoSt.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            else
                            {
                                txtValorBaseCalculoSt.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorBaseCalculoSt.Text = "0,00";
                        }
                        //
                        if (txtAliqICMSST.Text != "")
                        {
                            if (Convert.ToDecimal(txtAliqICMSST.Text) != 0)
                            {
                                txtValorICMSST.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS_ST(txtValorBaseCalculoSt.Text, txtAliqICMSST.Text.Trim(), txtPreco.Text, txtQuantidade.Text.Trim(), txtAliqICMS.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            else
                            {
                                txtValorICMSST.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorICMSST.Text = "0,00";
                        }
                        //
                        if (txtReducaoBCST.Text != "")
                        {
                            if (Convert.ToDecimal(txtReducaoBCST.Text) != 0)
                            {
                                string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim()), txtAliqICMSST.Text, txtReducaoBCST.Text, txtValorMVA.Text).Split('—');
                                //
                                txtValorReducaoICMSST.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorBaseCalculoSt.Text = txtValorReducaoICMSST.Text;
                                //
                                txtNovoValorICMSST.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorICMSST.Text = txtNovoValorICMSST.Text;
                            }
                            else
                            {
                                txtValorReducaoICMSST.Text = "0,00";
                                //
                                txtNovoValorICMSST.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorReducaoICMSST.Text = "0,00";
                            //
                            txtNovoValorICMSST.Text = "0,00";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqICMSST.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqICMSST.");
                        }
                        txtAliqICMSST.Text = null;
                    }
                }
            }
            txtAliqICMSST.BackColor = Color.White;
        }

        private void txtValorMVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorMVA.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (txtQuantidade.Enabled == false)
                {
                    btnSalvar.Select();
                }
                else
                {
                    txtQuantidade.Select();
                }
            }
        }

        private void txtValorICMSST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTotalAproxTrib.Select();
            }
        }

        private void txtAliqICMSST_Enter(object sender, EventArgs e)
        {
            txtAliqICMSST.BackColor = Color.LightBlue;
        }

        private void txtAliqICMSST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAliqICMS.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValorMVA.Select();
            }
        }

        private void txtValorMVA_Enter(object sender, EventArgs e)
        {
            txtValorMVA.BackColor = Color.LightBlue;
        }

        private void txtValorMVA_Leave(object sender, EventArgs e)
        {
            if (txtValorMVA.Text != "")
            {
                if (txtValorMVA.Text.Contains("'") || txtValorMVA.Text.Contains(";") || txtValorMVA.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorMVA.Text = "0,00";
                    txtValorMVA.Select();
                }
                else
                {
                    try
                    {
                        txtValorMVA.Text = Convert.ToDecimal(txtValorMVA.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        if (txtValorMVA.Text != "")
                        {
                            if (Convert.ToDecimal(txtValorMVA.Text) != 0)
                            {
                                txtValorBaseCalculoSt.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            else
                            {
                                txtValorBaseCalculoSt.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorBaseCalculoSt.Text = "0,00";
                        }
                        //
                        if (txtAliqICMSST.Text != "")
                        {
                            if (Convert.ToDecimal(txtAliqICMSST.Text) > 0)
                            {
                                txtValorICMSST.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_ICMS_ST(txtValorBaseCalculoSt.Text, txtAliqICMSST.Text.Trim(), txtPreco.Text, txtQuantidade.Text.Trim(), txtAliqICMS.Text)).ToString("n2", new CultureInfo("pt-BR"));
                            }
                            else
                            {
                                txtValorICMSST.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorICMSST.Text = "0,00";
                        }
                        //
                        if (txtReducaoBCST.Text != "")
                        {
                            if (Convert.ToDecimal(txtReducaoBCST.Text) != 0)
                            {
                                string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim()), txtAliqICMSST.Text, txtReducaoBCST.Text, txtValorMVA.Text).Split('—');
                                //
                                txtValorReducaoICMSST.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorBaseCalculoSt.Text = txtValorReducaoICMSST.Text;
                                //
                                txtNovoValorICMSST.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                                //
                                txtValorICMSST.Text = txtNovoValorICMSST.Text;
                            }
                            else
                            {
                                txtValorReducaoICMSST.Text = "0,00";
                                //
                                txtNovoValorICMSST.Text = "0,00";
                            }
                        }
                        else
                        {
                            txtValorReducaoICMSST.Text = "0,00";
                            //
                            txtNovoValorICMSST.Text = "0,00";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorMVA.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorMVA.");
                        }
                        txtValorMVA.Text = null;
                    }
                }
            }
            txtValorMVA.BackColor = Color.White;
        }

        private void txtReducaoBC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtReducaoBC.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValorReducaoICMS.Select();
            }
        }

        private void txtReducaoBC_Leave(object sender, EventArgs e)
        {
            if (txtReducaoBC.Text != "")
            {
                if (txtReducaoBC.Text.Contains("'") || txtReducaoBC.Text.Contains(";") || txtReducaoBC.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtReducaoBC.Text = "0,00";
                    txtReducaoBC.Select();
                }
                else
                {
                    try
                    {
                        txtReducaoBC.Text = Convert.ToDecimal(txtReducaoBC.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        if (Convert.ToDecimal(txtReducaoBC.Text) != 0)
                        {
                            string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS(bllDFe.Calculo_Valor_Base_Calculo_ICMS(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim()), txtAliqICMS.Text, txtReducaoBC.Text).Split('—');
                            //
                            txtValorReducaoICMS.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorBaseCalculo.Text = txtValorReducaoICMS.Text;
                            //
                            txtNovoValorICMS.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorICMS.Text = txtNovoValorICMS.Text;
                        }
                        else
                        {
                            txtPreco_Leave(sender, e);
                            //
                            txtValorReducaoICMS.Text = "0,00";
                            //
                            txtNovoValorICMS.Text = "0,00";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtReducaoBC.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtReducaoBC.");
                        }
                        txtReducaoBC.Text = null;
                    }
                }
            }
            else
            {
                txtPreco_Leave(sender, e);
                //
                txtValorReducaoICMS.Text = "0,00";
                //
                txtNovoValorICMS.Text = "0,00";
            }
            txtReducaoBC.BackColor = Color.White;
        }

        private void txtReducaoBC_Enter(object sender, EventArgs e)
        {
            txtReducaoBC.BackColor = Color.LightBlue;
        }

        private void txtValorBaseCalculoSt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorICMSST.Select();
            }
        }

        private void cbbCFOP_Leave(object sender, EventArgs e)
        {
            if (_Formulario != 0 || _Formulario != 3)
            {
                try
                {

                    if (cbbCFOP.Text != "")
                    {
                        DataRow dr = bllCFOP.Sel_CFOP_Codigo(cbbCFOP.Text).Rows[0];
                        //
                        if (dr["finalidade"].ToString() != _Finalidade)
                        {
                            DialogResult = MessageBox.Show("A finalidade do CFOP cadastrado está como [ " + dr["finalidade"].ToString() + " ], diferente da finalidade selecionada para a criação deste Dfe.\n\nDeseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                cbbCFOP.Text = null;
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Leave do cbbCFOP.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Leave do cbbCFOP.");
                    }
                }
            }
        }

        private void cbbCSOSN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCSOSN.Text == "101")
            {
                txtAliqICMS.Enabled = true;
                txtAliqICMS.Text = "20,50";
            }
            else if (cbbCSOSN.Text == "102")
            {
                txtAliqICMS.Enabled = true;
                txtAliqICMS.Text = "20,50";
            }
            else if (cbbCSOSN.Text == "103")
            {
                txtAliqICMS.Enabled = true;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSOSN.Text == "201")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSOSN.Text == "202")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSOSN.Text == "203")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSOSN.Text == "300")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSOSN.Text == "400")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSOSN.Text == "500")
            {
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "0,00";
            }
            else if (cbbCSOSN.Text == "900")
            {
                txtAliqICMS.Enabled = true;
                txtAliqICMS.Text = "20,50";
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {

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
                cbbCFOP.Select();
            }
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtValorTotalReal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalAproxTrib.Text = bllDFe.Calculo_Valor_Aprox_Trib(txtValorTotalReal.Text, cbbProduto.Text);
            }
            catch (Exception ex)
            {
                txtTotalAproxTrib.Text = "0,00";
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Leave do txtValorTotalReal.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Leave do txtValorTotalReal.");
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void txtAliqIPI_Enter(object sender, EventArgs e)
        {
            txtAliqIPI.BackColor = Color.LightBlue;
        }

        private void txtAliqIPI_Leave(object sender, EventArgs e)
        {
            if (txtAliqIPI.Text != "")
            {
                if (txtAliqIPI.Text.Contains("'") || txtAliqIPI.Text.Contains(";") || txtAliqIPI.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtAliqIPI.Text = "0,00";
                    txtAliqIPI.Select();
                }
                else
                {
                    try
                    {
                        txtAliqIPI.Text = Convert.ToDecimal(txtAliqIPI.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorIPI.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_IPI(txtTotal.Text, txtAliqIPI.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        txtValorTotalReal.Text = Convert.ToDecimal(bllDFe.Calculo_Valor_Item_Desc_Acresc(txtTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorIPI.Text, txtValorFrete.Text)).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqIPI.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqIPI.");
                        }
                        txtAliqIPI.Text = null;
                    }
                }

            }
            txtAliqIPI.BackColor = Color.White;

        }

        private void txtAliqIPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAliqIPI.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtReducaoBC.Select();
            }
        }

        private void txtValorIPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorFrete.Select();
            }
        }

        private void txtAliqICMS_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDescontoPorc_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtValorDesconto_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtAcrescimoPorc_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtValorAcrescimo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtValorReducaoICMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNovoValorICMS.Select();
            }
        }

        private void txtNovoValorICMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtReducaoBCST.Select();
            }
        }

        private void txtReducaoBCST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtReducaoBCST.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValorReducaoICMSST.Select();
            }
        }

        private void txtValorReducaoICMSST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNovoValorICMSST.Select();
            }
        }

        private void txtNovoValorICMSST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorIPI.Select();
            }
        }

        private void txtReducaoBCST_Leave(object sender, EventArgs e)
        {
            if (txtReducaoBCST.Text != "")
            {
                if (txtReducaoBCST.Text.Contains("'") || txtReducaoBCST.Text.Contains(";") || txtReducaoBCST.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtReducaoBCST.Text = "0,00";
                    txtReducaoBCST.Select();
                }
                else
                {
                    try
                    {
                        txtReducaoBCST.Text = Convert.ToDecimal(txtReducaoBCST.Text).ToString("n2", new CultureInfo("pt-BR"));
                        //
                        if (Convert.ToDecimal(txtReducaoBCST.Text) != 0)
                        {
                            string[] items = bllDFe.Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(bllDFe.Calculo_Valor_Base_Calculo_ICMS_ST(txtPreco.Text.Trim(), txtQuantidade.Text.Trim(), txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim(), txtValorMVA.Text.Trim()), txtAliqICMSST.Text, txtReducaoBCST.Text, txtValorMVA.Text).Split('—');
                            //
                            txtValorReducaoICMSST.Text = Convert.ToDecimal(items[0]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorBaseCalculoSt.Text = txtValorReducaoICMSST.Text;
                            //
                            txtNovoValorICMSST.Text = Convert.ToDecimal(items[1]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtValorICMSST.Text = txtNovoValorICMSST.Text;
                        }
                        else
                        {
                            txtPreco_Leave(sender, e);
                            //
                            txtValorReducaoICMSST.Text = "0,00";
                            //
                            txtNovoValorICMSST.Text = "0,00";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtReducaoBCST.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtReducaoBCST.");
                        }
                        txtReducaoBCST.Text = null;
                    }
                }
            }
            else
            {
                txtPreco_Leave(sender, e);
                //
                txtValorReducaoICMSST.Text = "0,00";
                //
                txtNovoValorICMSST.Text = "0,00";
            }
            //
            txtReducaoBCST.BackColor = Color.White;
        }

        private void txtReducaoBCST_Enter(object sender, EventArgs e)
        {
            txtReducaoBCST.BackColor = Color.LightBlue;
        }

        private void txtQuantidadeEmbalagem_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTotalAproxTrib_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorTotalReal.Select();
            }
        }

        private void cbbCSTAIBSCBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCSTBIBSCBS.Select();
            }
        }

        private void cbbCSTBIBSCBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAliqIBSMun.Select();
            }
        }

        private void txtAliqIBSMun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAliqIBSEstadual.Select();
            }
        }

        private void txtAliqIBSEstadual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAliqCBS.Select();
            }
        }

        private void txtAliqCBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQuantidade.Select();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O [ NCM ] e o [ CST ] são definidos no cadastro de produtos; apenas nele essas informações podem ser inseridas.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtValorFrete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorBaseCalculo.Select();            
            }
        }
    }
}
