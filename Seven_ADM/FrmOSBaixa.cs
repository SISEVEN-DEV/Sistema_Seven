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
    public partial class FrmOSBaixa : Form
    {
        public FrmOSBaixa(string usuario, string cod_pdv_computador, string codigo)
        {
            InitializeComponent();
            _Codigo = codigo;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Usuario = usuario;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Codigo;

        private void FrmOSBaixa_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOSBaixa iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOSBaixa iniciado.");
                }
                //
                bllOS.Excluir_Item_OS_Pgto_Atual(bllConexao._Codigo_Conexao);
                //
                DataRow dr = bllOS.Sel_OS_Codigo(_Codigo).Rows[0];
                //
                lblValorCodigo.Text = dr["id_os"].ToString();
                //
                txtObservacao.Text = dr["observacao"].ToString();
                //
                if (dr["data_conc_prev"].ToString() != "")
                {
                    lblValorDataConclusaoPrev.Text = dr["data_conc_prev"].ToString().Remove(10) + "   " + dr["horario_conc_prev"].ToString();
                }
                //
                lblValorDocumento.Text = Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR"));
                //
                lblValorDescontoItem.Text = Convert.ToDecimal(dr["valor_desconto_item"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                //
                lblValorAcrescimoItem.Text = Convert.ToDecimal(dr["valor_acrescimo_item"].ToString()).ToString("n2", new CultureInfo("pt-BR"));
                //
                txtValorDesconto.Text = "0,00";
                //
                txtValorAcrescimo.Text = "0,00";
                //
                txtDescontoPorc.Text = "0,00";
                //
                txtAcrescimoPorc.Text = "0,00";
                //
                lblValorTotal.Text = Convert.ToDecimal(dr["valor_real"]).ToString("n2", new CultureInfo("pt-BR"));
                lblValorDiferencaTroco.Text = "-" + Convert.ToDecimal(dr["valor_real"]).ToString("n2", new CultureInfo("pt-BR"));
                //
                lblValorTotalPagar.Text = lblValorTotal.Text;
                //
                if (bllOS.Sel_Forma_Pagamento_OS() == null)
                {
                    cbbFormaPagamento.Text = null;
                }
                else
                {
                    cbbFormaPagamento.Items.Add("");
                    foreach (DataRow dr1 in bllOS.Sel_Forma_Pagamento_OS().Rows)
                    {
                        cbbFormaPagamento.Items.Add(dr1["id_pagamento"].ToString() + "—" + dr1["tipo"].ToString());
                    }
                }
                //
                if (bllOS.Sel_Formas_Pagamento_OS(lblValorCodigo.Text) != null)
                {
                    for (int i = 0; i < bllOS.Sel_Formas_Pagamento_OS(lblValorCodigo.Text).Rows.Count; i++)
                    {
                        dr = bllOS.Sel_Formas_Pagamento_OS(lblValorCodigo.Text).Rows[i];
                        //
                        bllOS.Salvar_Forma_Pagamento_OS_Temp(dr["id_item_pagamento"].ToString(), dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString(), dr["valor_pago"].ToString(), bllConexao._Codigo_Conexao, "0", 1);
                    }
                    //
                    dtFormaPagamento.DataSource = bllOS.Sel_Item_OS_Pgto_Todas(bllConexao._Codigo_Conexao);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmOSBaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmOSBaixa.");
                }
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

        private void lblValorDataVencimento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDataVencimento_MouseLeave(object sender, EventArgs e)
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

        private void btnSelecionarData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAplicar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAplicar_MouseLeave(object sender, EventArgs e)
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

        private void btnSalvarPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvarPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalPagar_MouseLeave(object sender, EventArgs e)
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

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
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

        private void mtxtDataConclusao_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataConclusao.Text == "")
            {
                mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataConclusao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataConclusao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioConclusao.Select();
            }
        }

        private void mtxtDataConclusao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataConclusao.Text == "")
                {
                    mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataConclusao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataConclusao_Enter(object sender, EventArgs e)
        {
            mtxtDataConclusao.BackColor = Color.LightBlue;
        }

        private void mtxtDataConclusao_Leave(object sender, EventArgs e)
        {
            mtxtDataConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataConclusao.Text != "")
            {
                try
                {
                    mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataConclusao.Text);

                    mtxtDataConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataConclusao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataConclusao.");
                    }
                    mtxtDataConclusao.Text = null;
                }
            }
            mtxtDataConclusao.BackColor = Color.White;
        }

        private void mtxtHorarioConclusao_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioConclusao.Text == "")
            {
                mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioConclusao.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioConclusao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtObservacao.Select();
            }
        }

        private void mtxtHorarioConclusao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioConclusao.Text == "")
                {
                    mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioConclusao.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioConclusao_Enter(object sender, EventArgs e)
        {
            mtxtHorarioConclusao.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioConclusao_Leave(object sender, EventArgs e)
        {
            mtxtHorarioConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioConclusao.Text != "")
            {
                if (mtxtHorarioConclusao.Text.Length == 4)
                {
                    mtxtHorarioConclusao.Text = mtxtHorarioConclusao.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    ValidarData.Ver_Hora(mtxtHorarioConclusao.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioConclusao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioConclusao.");
                    }
                    mtxtHorarioConclusao.Text = null;
                }
            }
            mtxtHorarioConclusao.BackColor = Color.White;
        }

        private void FrmOSBaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllOS.Excluir_Item_OS_Pgto_Atual(bllConexao._Codigo_Conexao);
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOSBaixa foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmOSBaixa foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmOSBaixa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmOSBaixa.");
                }
            }
        }

        private void FrmOSBaixa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtObservacao_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbbFormaPagamento_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFormaPagamento_DropDownClosed(object sender, EventArgs e)
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

        private void txtValorPagamento_Enter(object sender, EventArgs e)
        {
            txtValorPagamento.BackColor = Color.LightBlue;
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
                    btnFinalizar.Select();
                }
                else
                {
                    btnSalvarPagamento.Select();
                }
            }
        }

        private void Desconto_Leave() 
        {
            if (txtValorDesconto.Text == "")
            {
                txtValorDesconto.Text = "0";
            }
            //
            txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
            //
            txtDescontoPorc.Text = Convert.ToDecimal(bllOS.Calculo_ValorDesconto(lblValorTotal.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
            //
            lblValorTotalPagar.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Real_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valordiferenca = Convert.ToDecimal(lblValorTotalPago.Text) - Convert.ToDecimal(lblValorTotalPagar.Text);
            if (Convert.ToDecimal(lblValorTotalPago.Text) > Convert.ToDecimal(lblValorTotalPagar.Text))
            {
                lblDiferencaTroco.Location = new Point(267, 183);
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
                    if (bllUsuario.Sel_Permitir_Desc_Pag_Usuario(_Usuario) == false & txtValorDesconto.Text != "0,00" & txtValorDesconto.Text != "0")
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
                                }
                                else if (bllVenda._Permitir_Desc_Pag == 1)
                                {
                                    Desconto_Leave();
                                }
                            }
                            else
                            {
                                txtDescontoPorc.Text = "0,00";
                                Desconto_Leave();
                            }
                        }
                    }
                    else
                    {
                        Desconto_Leave();
                    }
                    //
                    if (bllUsuario.Sel_Desconto_Porc_Max_Venda_Usuario(_Usuario, txtDescontoPorc.Text) != true)
                    {
                        MessageBox.Show("O valor do desconto informado é maior que o definido para este Usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtDescontoPorc.Text = "0,00";
                        txtValorDesconto.Text = "0,00";
                        Desconto_Leave();
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
                txtDescontoPorc.Select();
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
                txtAcrescimoPorc.Select();
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(5))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.None;
                    mtxtDataConclusao.Text = bllOS._Data_DatePicker1;
                    bllOS._Data_DatePicker1 = null;
                    mtxtDataConclusao.Select();
                }
            }
            this.Enabled = true;
        }

        private void txtValorAcrescimo_Enter(object sender, EventArgs e)
        {
            txtValorAcrescimo.BackColor = Color.LightBlue;
        }

        private void Acrescimo_Leave() 
        {
            if (txtValorAcrescimo.Text == "")
            {
                txtValorAcrescimo.Text = "0";
            }
            //
            txtValorAcrescimo.Text = Convert.ToDecimal(txtValorAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));
            //
            txtAcrescimoPorc.Text = Convert.ToDecimal(bllOS.Calculo_ValorAcrescimo(lblValorTotal.Text, txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            //
            lblValorTotalPagar.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Real_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valordiferenca = Convert.ToDecimal(lblValorTotalPago.Text) - Convert.ToDecimal(lblValorTotalPagar.Text);
            if (Convert.ToDecimal(lblValorTotalPago.Text) > Convert.ToDecimal(lblValorTotalPagar.Text))
            {
                lblDiferencaTroco.Location = new Point(267, 183);
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
                    if (bllUsuario.Sel_Permitir_Acresc_Pag_Usuario(_Usuario) == false & txtValorAcrescimo.Text != "0,00" & txtValorAcrescimo.Text != "0")
                    {
                        using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(_Usuario, _Cod_PDV_Computador, "Permitir_Acresc_Pag"))
                        {
                            if (Login.ShowDialog() == DialogResult.OK)
                            {
                                if (bllVenda._Permitir_Acresc_Pag == 0)
                                {
                                    MessageBox.Show("O Usuário informado não possui permissão para aplicar Acréscimos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtValorAcrescimo.Text = "0,00";
                                    Acrescimo_Leave();
                                }
                                else if (bllVenda._Permitir_Acresc_Pag == 1)
                                {
                                    Acrescimo_Leave();
                                }
                            }
                            else
                            {
                                txtValorAcrescimo.Text = "0,00";
                                Acrescimo_Leave();
                            }
                        }
                    }
                    else
                    {
                        Acrescimo_Leave();
                    }
                    //
                    if (bllUsuario.Sel_Acrescimo_Porc_Max_Venda_Usuario(_Usuario, txtAcrescimoPorc.Text) != true)
                    {
                        MessageBox.Show("O valor do acréscimo informado é maior que o definido para este Usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtAcrescimoPorc.Text = "0,00";
                        txtValorAcrescimo.Text = "0,00";
                        Acrescimo_Leave();
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

        private void lblValorDataVencimento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data de Conclusão Prevista: " + lblValorDataConclusaoPrev.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDocumento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor (R$): " + lblValorDocumento.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbFormaPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorPagamento.Select();
            }
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalPagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total a Pagar (R$): " + lblValorTotalPagar.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnProcurarForma_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(3, _Usuario, _Cod_PDV_Computador))
                {
                    if (Pag.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.None;
                        cbbFormaPagamento.Items.Clear();
                        if (bllOS.Sel_Forma_Pagamento_OS() == null)
                        {
                            cbbFormaPagamento.Enabled = false;
                            cbbFormaPagamento.Text = null;
                        }
                        else
                        {
                            cbbFormaPagamento.Enabled = true;
                            cbbFormaPagamento.Items.Add("");
                            foreach (DataRow dr in bllOS.Sel_Forma_Pagamento_OS().Rows)
                            {
                                cbbFormaPagamento.Items.Add((dr["id_pagamento"].ToString()) + "—" + (dr["tipo"].ToString()));
                            }
                        }
                        //
                        cbbFormaPagamento.Text = bllOS._Forma_Pagamento_PesqFormaPagamento_Tabela;
                        bllOS._Forma_Pagamento_PesqFormaPagamento_Tabela = null;
                        cbbFormaPagamento.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarForma.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarForma.");
                }
                cbbFormaPagamento.Text = null;
            }
            this.Enabled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
                txtValorAcrescimo.Select();
            }
        }

        private void Desconto_Porc_Leave() 
        {
            if (txtDescontoPorc.Text == "")
            {
                txtDescontoPorc.Text = "0";
            }
            //
            txtDescontoPorc.Text = Convert.ToDecimal(txtDescontoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
            //
            txtValorDesconto.Text = Convert.ToDecimal(bllOS.Calculo_Desconto(lblValorTotal.Text, txtDescontoPorc.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            //
            lblValorTotalPagar.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Real_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valordiferenca = Convert.ToDecimal(lblValorTotalPago.Text) - Convert.ToDecimal(lblValorTotalPagar.Text);
            if (Convert.ToDecimal(lblValorTotalPago.Text) > Convert.ToDecimal(lblValorTotalPagar.Text))
            {
                lblDiferencaTroco.Location = new Point(267, 183);
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
                    if (bllUsuario.Sel_Permitir_Desc_Pag_Usuario(_Usuario) == false & txtDescontoPorc.Text != "0,00" & txtDescontoPorc.Text != "0")
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
                                }
                                else if (bllVenda._Permitir_Desc_Pag == 1)
                                {
                                    Desconto_Porc_Leave();
                                }
                            }
                            else
                            {
                                txtDescontoPorc.Text = "0,00";
                                Desconto_Porc_Leave();
                            }
                        }
                    }
                    else
                    {
                        Desconto_Porc_Leave();
                    }
                    //
                    if (bllUsuario.Sel_Desconto_Porc_Max_Venda_Usuario(_Usuario, txtDescontoPorc.Text) != true)
                    {
                        MessageBox.Show("O valor do desconto informado é maior que o definido para este Usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtDescontoPorc.Text = "0,00";
                        txtValorDesconto.Text = "0,00";
                        Desconto_Porc_Leave();
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

        private void txtDescontoPorc_Enter(object sender, EventArgs e)
        {
            txtDescontoPorc.BackColor = Color.LightBlue;
        }

        private void AcrescimoPorc_Leave() 
        {
            if (txtAcrescimoPorc.Text == "")
            {
                txtAcrescimoPorc.Text = "0";
            }
            //
            txtAcrescimoPorc.Text = Convert.ToDecimal(txtAcrescimoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
            //
            txtValorAcrescimo.Text = Convert.ToDecimal(bllOS.Calculo_Acrescimo(lblValorTotal.Text, txtAcrescimoPorc.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            //
            lblValorTotalPagar.Text = Convert.ToDecimal(bllOS.Calculo_Valor_Real_Desc_Acresc(lblValorTotal.Text, txtValorDesconto.Text.Trim(), txtValorAcrescimo.Text.Trim())).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valordiferenca = Convert.ToDecimal(lblValorTotalPago.Text) - Convert.ToDecimal(lblValorTotalPagar.Text);
            if (Convert.ToDecimal(lblValorTotalPago.Text) > Convert.ToDecimal(lblValorTotalPagar.Text))
            {
                lblDiferencaTroco.Location = new Point(267, 183);
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
                    if (bllUsuario.Sel_Permitir_Acresc_Pag_Usuario(_Usuario) == false & txtAcrescimoPorc.Text != "0,00" & txtAcrescimoPorc.Text != "0")
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
                                }
                                else if (bllVenda._Permitir_Acresc_Pag == 1)
                                {
                                    AcrescimoPorc_Leave();
                                }
                            }
                            else
                            {
                                txtAcrescimoPorc.Text = "0,00";
                                AcrescimoPorc_Leave();
                            }
                        }
                    }
                    else
                    {
                        AcrescimoPorc_Leave();
                    }
                    //
                    if (bllUsuario.Sel_Acrescimo_Porc_Max_Venda_Usuario(_Usuario, txtAcrescimoPorc.Text) != true)
                    {
                        MessageBox.Show("O valor do acréscimo informado é maior que o definido para este Usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtAcrescimoPorc.Text = "0,00";
                        txtValorAcrescimo.Text = "0,00";
                        AcrescimoPorc_Leave();
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
                cbbFormaPagamento.Select();
            }
        }

        private void pcibInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Informações da Ordem de Serviço: É onde ficam localizadas as informações relevantes da Ordem de Serviço.\n\n2 - Informações de Pagamento: É a parte onde o usuário vai inserir as informações complementares do pagamento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnSalvarPagamento_Click(object sender, EventArgs e)
        {
            try
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
                        int item;
                        if (dtFormaPagamento.DataSource == null)
                        {
                            item = dtFormaPagamento.Rows.Count + 1;
                        }
                        else
                        {
                            item = Convert.ToInt32(dtFormaPagamento.Rows[dtFormaPagamento.Rows.Count - 1].Cells[0].Value) + 1;
                        }
                        //
                        bllOS.Salvar_Forma_Pagamento_OS_Temp(item.ToString(), cbbFormaPagamento.Text, txtValorPagamento.Text.Trim(), bllConexao._Codigo_Conexao, "0", 0);
                        //
                        dtFormaPagamento.DataSource = bllOS.Sel_Item_OS_Pgto_Todas(bllConexao._Codigo_Conexao);
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
                        dtFormaPagamento.Select();
                    }
                }
                else
                {
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
            }
        }

        private void btnExcluirReg_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    //
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[4].Value.ToString() == "1")
                    {
                        MessageBox.Show("Não é possível excluir um pagamento parcial.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        bllOS.Excluir_Item(SelectedRow.Cells[0].Value.ToString(), bllConexao._Codigo_Conexao, "0");

                        bllOS.Atualizar_Item_Dt_Pgto_OS(dtFormaPagamento.CurrentRow.Index + 1, dtFormaPagamento.Rows.Count, bllConexao._Codigo_Conexao);

                        dtFormaPagamento.DataSource = bllOS.Sel_Item_OS_Pgto_Todas(bllConexao._Codigo_Conexao);

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
                else
                {
                    this.DialogResult = DialogResult.None;
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
            }
        }

        private void dtFormaPagamento_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtFormaPagamento.Columns[0].HeaderText = "Item";
                dtFormaPagamento.Columns[1].HeaderText = "Cód. Forma de Pagamento";
                dtFormaPagamento.Columns[2].HeaderText = "Tipo Forma de Pagamento";
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
                valordiferenca = valortotal - Convert.ToDecimal(lblValorTotalPagar.Text);
                if (valortotal > Convert.ToDecimal(lblValorTotalPagar.Text))
                {
                    lblDiferencaTroco.Location = new Point(267, 183);
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

        private void dtFormaPagamento_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblValorTotalPago.Text = "0,00";
            lblValorDiferencaTroco.Text = "-" + lblValorTotalPagar.Text;
            lblDiferencaTroco.Location = new Point(245, 183);
            lblDiferencaTroco.ForeColor = Color.Red;
            lblDiferencaTroco.Text = "Diferença (R$):";
        }

        private void dtFormaPagamento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtFormaPagamento.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtFormaPagamento.Columns[3].DefaultCellStyle.Format = "n2";

            dtFormaPagamento.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtFormaPagamento.DefaultCellStyle.SelectionForeColor = Color.Black;
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

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            btnFinalizar.Select();
            try
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
                    bool novopagamento = false;
                    foreach (DataGridViewRow row in dtFormaPagamento.Rows)
                    {
                        if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() == "0")
                        {
                            novopagamento = true;
                            break;
                        }
                    }
                    //
                    if (bllOS.Sel_OS_Ainda_Existe(lblValorCodigo.Text) == false)
                    {
                        MessageBox.Show("Esta Ordem de Serviço não existe ou foi excluída.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        btnSair.Select();
                    }
                    else if (bllOS.Sel_Baixa_OS_Aconteceu(lblValorCodigo.Text) == true)
                    {
                        MessageBox.Show("Esta Ordem de Serviço já foi baixada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (novopagamento == false)
                    {
                        MessageBox.Show("Esta Ordem de Serviço não possui novos pagamentos ou possui apenas pagamentos parciais informados anteriormente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        this.DialogResult = DialogResult.None;
                        if (Convert.ToDecimal(lblValorTotalPago.Text) < Convert.ToDecimal(lblValorTotalPagar.Text))
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
                                //
                                bool primeira_finalizacao = true;
                                if (bllOS.Sel_Formas_Pagamento_OS(_Codigo) == null)
                                {
                                    primeira_finalizacao = true;
                                }
                                else
                                {
                                    primeira_finalizacao = false;
                                }
                                //
                                for (int i = 0; dtFormaPagamento.Rows.Count > i; i++)
                                {
                                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[i];

                                    if (primeira_finalizacao == true)
                                    {
                                        if (Convert.ToByte(SelectedRow.Cells[4].Value) == 0)
                                        {
                                            bllOS.Salvar_Pagamento_OS(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador, "0", 1);
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToByte(SelectedRow.Cells[4].Value) == 0)
                                        {
                                            bllOS.Salvar_Pagamento_OS(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador, "0", 2);
                                        }
                                    }
                                }
                                //
                                bllRegistroAtividades.Salvar("INFORMOU PAGAMENTO PARCIAL A UMA ORDEM DE SERVICO.", "ORDEM DE SERVICO", lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
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
                            mtxtDataConclusao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            //
                            if (mtxtDataConclusao.Text == "" || dtFormaPagamento.Rows.Count == 0)
                            {
                                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Data e Horário de Conclusão ] e [ Tabela de Pagamentos ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtDataConclusao.Select();
                            }
                            else
                            {
                                mtxtDataConclusao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //

                                for (int i = 0; dtFormaPagamento.Rows.Count > i; i++)
                                {
                                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[i];

                                    if (Convert.ToByte(SelectedRow.Cells[4].Value) == 0)
                                    {
                                        bllOS.Salvar_Pagamento_OS(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador, "0", 0);
                                    }
                                }
                                //
                                string totaldiftroco = lblValorDiferencaTroco.Text;
                                //
                                string totalvalordesconto = txtValorDesconto.Text;
                                //
                                string totaldescontoporc = txtDescontoPorc.Text;
                                //
                                string totalvaloracrescimo = txtValorAcrescimo.Text;
                                //
                                string totalacrescimoporc = txtAcrescimoPorc.Text;
                                //
                                string valor_real = lblValorTotalPagar.Text;
                                //
                                bllOS.Salvar_Baixa_Pagamento_OS(lblValorCodigo.Text, valor_real, mtxtDataConclusao.Text, mtxtHorarioConclusao.Text, totaldiftroco, _Usuario, _Cod_PDV_Computador, totalvalordesconto, totaldescontoporc, totalvaloracrescimo, totalacrescimoporc);
                                //
                                //
                                if (bllOS.Sel_Item_OS_Funcionario_Todos(_Codigo) != null)
                                {
                                    for (int i = 0; i < bllOS.Sel_Item_Servico_Todos(_Codigo).Rows.Count; i++)
                                    {
                                        DataRow dr = bllOS.Sel_Item_Servico_Todos(_Codigo).Rows[i];
                                        //
                                        if (Convert.ToDecimal(dr["comissao_porc"]) > 0)
                                        {
                                            for (int a = 0; a < bllOS.Sel_Item_OS_Funcionario_Todos(_Codigo).Rows.Count; a++)
                                            {
                                                DataRow dr1 = bllOS.Sel_Item_OS_Funcionario_Todos(_Codigo).Rows[a];
                                                //
                                                bllComissao.Salvar(dr1["id_funcionario"].ToString() + "—" + dr1["nome_funcionario"].ToString(), dr["valor_total"].ToString(), dr["comissao_porc"].ToString(), "0", _Codigo, bllOS.Sel_Item_OS_Funcionario_Todos(_Codigo).Rows.Count);
                                            }
                                        }
                                    }
                                }
                                //
                                bllRegistroAtividades.Salvar("FECHOU UMA ORDEM DE SERVICO.", "ORDEM DE SERVICO", lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                //
                                using (FrmTroco Troco = new FrmTroco(totaldiftroco))
                                {
                                    if (Troco.ShowDialog() == DialogResult.OK)
                                    {
                                        this.DialogResult = DialogResult.OK;
                                    }
                                }
                            }
                        }
                    }
                    //
                    if (txtObservacao.Text != "")
                    {
                        bllOS.Alterar_OS_Observacao(_Codigo, txtObservacao.Text);
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    mtxtDataConclusao.Select();
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
                bllOS.Excluir_Item_OS_Pgto_Atual(bllConexao._Codigo_Conexao);
                dtFormaPagamento.DataSource = null;
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
                    txtValorPagamento.Text = lblValorTotalPagar.Text;
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
                        txtValorPagamento.Text = lblValorTotalPagar.Text;
                    }
                }
            }
        }

        private void dtFormaPagamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnExcluirReg_Click(sender, e);
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
            else if (e.ColumnIndex == 4 && e.Value.ToString() == "2")
            {
                e.Value = "SIM";
            }
        }

        private void txtObservacao_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorDesconto.Select();
            }
        }

        private void txtObservacao_Enter(object sender, EventArgs e)
        {
            txtObservacao.BackColor = Color.LightBlue;
        }

        private void txtObservacao_Leave(object sender, EventArgs e)
        {
            if (txtObservacao.Text.Contains("'") || txtObservacao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtObservacao.Text = null;
                txtObservacao.Select();
            }
            txtObservacao.BackColor = Color.White;
        }

        private void txtObservacao_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCarObs.Text = "Max. de Caracteres: " + txtObservacao.Text.Length + "/250";
        }

        private void lblValorDescontoItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor do Desconto do Item (R$): " + lblValorDescontoItem.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorAcrescimoItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor do Acréscimo do Item (R$): " + lblValorAcrescimoItem.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }
    }
}
