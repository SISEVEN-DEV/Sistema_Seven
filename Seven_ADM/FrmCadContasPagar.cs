using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadContasPagar : Form
    {
        public FrmCadContasPagar(byte formulario, string usuario, string cod_pdv_computador, string codigo)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
            _Codigo = codigo;
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;
        private string _ComboboxEmitente_Valor = null;
        private string _ComboboxEntBancaria_Valor = null;
        private string _Usuario;
        private string _ComboboxGrupo_Valor = null;
        private string _ComboboxSubgrupo_Valor = null;
        private string _Cod_PDV_Computador;
        private byte _Formulario;
        private string _Codigo;

        private void ModoPesquisa()
        {
            lblCodigo.Enabled = false;
            txtCodigo.Enabled = false;
            grbBox1.Enabled = true;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtConta.DataSource != null)
            {
                dtConta.Enabled = true;
                dtConta.Select();
            }
            lblContratoMatServ.Enabled = false;
            txtContratoMatServ.Enabled = false;
            txtOcorrenciaParcela.Enabled = false;
            lblOcorrenciaParcela.Enabled = false;
            label1.Enabled = false;
            txtDescricao.Enabled = false;
            lblDescricao.Enabled = false;
            lblAsterisco2.Enabled = false;
            lblNDocumento.Enabled = false;
            txtNDocumento.Enabled = false;
            lblCodigoBarra.Enabled = false;
            txtCodBarra.Enabled = false;
            lblTipoCobranca.Enabled = false;
            cbbTipoDocumento.Enabled = false;
            label9lblAsterisco5.Enabled = false;
            lblDataEmissao.Enabled = false;
            mtxtDataEmissao.Enabled = false;
            lblAsterisco3.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtDataVencimento.Enabled = false;
            lblAsterisco4.Enabled = false;
            btnSelecionarData2.Enabled = false;
            grbBox4.Enabled = false;
            lbllocalizarEmitente.Enabled = false;
            lblEmitente.Enabled = false;
            cbbTipoEmitente.Enabled = false;
            cbbEmitente.Enabled = false;
            cbbEntBanc.Enabled = false;
            lblEntidadeBancaria.Enabled = false;
            btnProcurar.Enabled = false;
            btnProcurarEntBanc.Enabled = false;
            lblValorDocumento.Enabled = false;
            txtValorDocumento.Enabled = false;
            lblAsterisco8.Enabled = false;
            lblDescontoData.Enabled = false;
            mtxtDataDesconto.Enabled = false;
            btnSelecionarData3.Enabled = false;
            lblDesconto.Enabled = false;
            txtDesconto.Enabled = false;
            lblPorcentagem1.Enabled = false;
            lblValorDesconto.Enabled = false;
            txtValorDesconto.Enabled = false;
            lblMulta.Enabled = false;
            txtMulta.Enabled = false;
            lblPorcentagem2.Enabled = false;
            lblValorMulta.Enabled = false;
            txtValorMulta.Enabled = false;
            lblMora.Enabled = false;
            txtMora.Enabled = false;
            lblPorcentagem3.Enabled = false;
            lblObservacao.Enabled = false;
            rtxtObs.Enabled = false;
            lblQtdeCar.Enabled = false;
            btnAviso.Enabled = false;
            cbbEntBanc.Enabled = false;
            btnProcurarEntBanc.Enabled = false;
            lblAsterisco6.Enabled = false;
            lblAsterisco7.Enabled = false;
        }

        public void Ativar()
        {
            lblCodigo.Enabled = true;
            lblContratoMatServ.Enabled = true;
            txtContratoMatServ.Enabled = true;
            txtOcorrenciaParcela.Enabled = true;
            lblOcorrenciaParcela.Enabled = true;
            label1.Enabled = true;
            txtDescricao.Enabled = true;
            lblDescricao.Enabled = true;
            lblAsterisco2.Enabled = true;
            lblNDocumento.Enabled = true;
            txtNDocumento.Enabled = true;
            lblCodigoBarra.Enabled = true;
            txtCodBarra.Enabled = true;
            lblTipoCobranca.Enabled = true;
            cbbTipoDocumento.Enabled = true;
            label9lblAsterisco5.Enabled = true;
            lblDataEmissao.Enabled = true;
            mtxtDataEmissao.Enabled = true;
            lblAsterisco3.Enabled = true;
            lblDataVencimento.Enabled = true;
            mtxtDataVencimento.Enabled = true;
            lblAsterisco4.Enabled = true;
            btnSelecionarData2.Enabled = true;
            grbBox4.Enabled = true;
            lbllocalizarEmitente.Enabled = true;
            lblEmitente.Enabled = true;
            cbbTipoEmitente.Enabled = true;
            cbbEmitente.Enabled = true;
            cbbEntBanc.Enabled = true;
            lblEntidadeBancaria.Enabled = true;
            btnProcurar.Enabled = true;
            btnProcurarEntBanc.Enabled = true;
            lblValorDocumento.Enabled = true;
            txtValorDocumento.Enabled = true;
            lblAsterisco8.Enabled = true;
            lblDescontoData.Enabled = true;
            mtxtDataDesconto.Enabled = true;
            btnSelecionarData3.Enabled = true;
            lblDesconto.Enabled = true;
            txtDesconto.Enabled = true;
            lblPorcentagem1.Enabled = true;
            lblValorDesconto.Enabled = true;
            txtValorDesconto.Enabled = true;
            lblMulta.Enabled = true;
            txtMulta.Enabled = true;
            lblPorcentagem2.Enabled = true;
            lblValorMulta.Enabled = true;
            txtValorMulta.Enabled = true;
            lblMora.Enabled = true;
            txtMora.Enabled = true;
            lblPorcentagem3.Enabled = true;
            lblObservacao.Enabled = true;
            rtxtObs.Enabled = true;
            lblQtdeCar.Enabled = true;
            btnAviso.Enabled = true;
            cbbEntBanc.Enabled = true;
            btnProcurarEntBanc.Enabled = true;
            lblAsterisco6.Enabled = true;
            lblAsterisco7.Enabled = true;
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtContratoMatServ.Text = null;
            txtOcorrenciaParcela.Text = null;
            txtDescricao.Text = null;
            txtCodBarra.Text = null;
            mtxtDataEmissao.Text = null;
            mtxtDataVencimento.Text = null;
            cbbTipoDocumento.Text = null;
            cbbTipoEmitente.Text = null;
            cbbEmitente.Text = null;
            cbbGrupo.Text = null;
            cbbSubGrupo.Text = null;
            txtValorDocumento.Text = null;
            mtxtDataDesconto.Text = null;
            txtDesconto.Text = null;
            txtValorDesconto.Text = null;
            txtMulta.Text = null;
            txtValorMulta.Text = null;
            txtMora.Text = null;
            rtxtObs.Text = null;
            txtNDocumento.Text = null;
        }

        private void FrmCadContasPagar_Load(object sender, EventArgs e)
        {
            try
            {
                bllContasPagar._FrmCadContasPagar_Ativo = true;
                //
                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContasPagar iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContasPagar iniciado.");
                }
                //
                if (_Formulario == 1)
                {
                    rbtnCodigo.Checked = true;
                    //
                    txtpCodigo.Text = _Codigo;
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    btnAlterar_Click(sender, e);
                }
                else
                {
                    rbtnDescricao.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadContasPagar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadContasPagar.");
                }
            }
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            cbbpEmitente.Visible = false;
            cbbpTipoEmitente.Visible = false;
            btnpProcurar.Visible = false;
            txtpBarra.Visible = false;
            txtpDescricao.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(396, 21);
            lblPesquisar.Text = "Digite a descrição:";
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            cbbpEmitente.Visible = false;
            cbbpTipoEmitente.Visible = false;
            btnpProcurar.Visible = false;
            txtpBarra.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = true;
            txtpCodigo.MaxLength = 10;
            lblPesquisar.Location = new Point(583, 21);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnCodBarra_CheckedChanged(object sender, EventArgs e)
        {
            cbbpEmitente.Visible = false;
            cbbpTipoEmitente.Visible = false;
            btnpProcurar.Visible = false;
            txtpBarra.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(356, 21);
            lblPesquisar.Text = "Digite o código de barras:";
            txtpBarra.Text = null;
            txtpBarra.Select();
        }

        private void rbtnCodFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            cbbpTipoEmitente.Visible = true;
            btnpProcurar.Visible = true;
            txtpBarra.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(298, 21);
            cbbpEmitente.Visible = true;
            lblPesquisar.Text = "Escolha o emitente:";
            cbbpEmitente.Text = null;
            cbbpTipoEmitente.Text = "CLIENTES";
            cbbpTipoEmitente.Select();
            //
            try
            {
                cbbpEmitente.Items.Clear();
                if (cbbpTipoEmitente.SelectedIndex == 1)
                {
                    if (bllContasPagar.Sel_Cliente_Cont() == null)
                    {
                        cbbpEmitente.Enabled = false;
                        cbbpEmitente.Text = null;
                    }
                    else
                    {
                        cbbpEmitente.Enabled = true;
                        cbbpEmitente.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                        {
                            cbbpEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnEmitente.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnEmitente.");
                }
                cbbpEmitente.Text = null;
            }
        }

        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodBarra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodBarra_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodFornecedor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpNome_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpDescricao.Text = null;
                txtpDescricao.Select();
            }
            txtpDescricao.BackColor = Color.White;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            if (txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpCodigo.Text = null;
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void txtCodBarra_Enter(object sender, EventArgs e)
        {
            txtCodBarra.BackColor = Color.LightBlue;
        }

        private void txtCodBarra_Leave(object sender, EventArgs e)
        {
            if (txtCodBarra.Text.Contains("'") || txtCodBarra.Text.Contains(";") || txtCodBarra.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodBarra.Text = null;
                txtCodBarra.Select();
            }
            else
            {
                if (_Inserir_Atualizar == true)
                {
                    try
                    {
                        if (txtCodBarra.Text != "")
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllContasPagar.Sel_Conta_Barra_Alt(txtCodigo.Text, txtCodBarra.Text) == true)
                                {
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtCodBarra.Text = null;
                                    txtCodBarra.Select();
                                }
                            }
                            else
                            {
                                if (bllContasPagar.Sel_Conta_Barra(txtCodBarra.Text) == true)
                                {
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtCodBarra.Text = null;
                                    txtCodBarra.Select();
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
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtCodBarra.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtCodBarra.");
                        }
                        txtCodBarra.Text = null;
                    }
                }
            }
            txtCodBarra.BackColor = Color.White;
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescricao.Text = null;
                txtDescricao.Select();
            }
            txtDescricao.BackColor = Color.White;
        }

        private void mtxtDataEmissao_Enter(object sender, EventArgs e)
        {
            mtxtDataEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtDataEmissao_Leave(object sender, EventArgs e)
        {
            mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataEmissao.Text == "")
            {
                mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            else
            {
                try
                {
                    mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataVencimento.Text == "")
                    {
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        ValidarData.Ver_Data(mtxtDataEmissao.Text);
                    }
                    else
                    {
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataEmissao.Text) > Convert.ToDateTime(mtxtDataVencimento.Text))
                        {
                            MessageBox.Show("Data de emissão é maior que a data de vencimento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataEmissao.Text = null;
                            mtxtDataEmissao.Select();
                        }
                        else
                        {
                            ValidarData.Ver_Data(mtxtDataEmissao.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataEmissao.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataEmissao.");
                    }
                    mtxtDataEmissao.Text = null;
                    mtxtDataEmissao.Select();
                }
            }
            mtxtDataEmissao.BackColor = Color.White;
        }

        private void mtxtDataVencimento_Enter(object sender, EventArgs e)
        {
            mtxtDataVencimento.BackColor = Color.LightBlue;
        }

        private void mtxtDataVencimento_Leave(object sender, EventArgs e)
        {
            mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataVencimento.Text == "")
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            else
            {
                try
                {
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataEmissao.Text == "")
                    {
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        ValidarData.Ver_Data(mtxtDataVencimento.Text);
                    }
                    else
                    {
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataVencimento.Text) < Convert.ToDateTime(mtxtDataEmissao.Text))
                        {
                            MessageBox.Show("Data de vencimento é menor que a data de emissão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataVencimento.Text = null;
                            mtxtDataVencimento.Select();
                        }
                        else
                        {
                            ValidarData.Ver_Data(mtxtDataVencimento.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataVencimento.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataVencimento.");
                    }
                    mtxtDataVencimento.Text = null;
                }
            }
            mtxtDataVencimento.BackColor = Color.White;
        }

        private void txtValorDaConta_Enter(object sender, EventArgs e)
        {
            txtValorDocumento.BackColor = Color.LightBlue;
        }

        private void txtValorDaConta_Leave(object sender, EventArgs e)
        {
            if (txtValorDocumento.Text != "")
            {
                if (txtValorDocumento.Text.Contains("'") || txtValorDocumento.Text.Contains(";") || txtValorDocumento.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtValorDocumento.Text = null;
                    txtValorDocumento.Select();
                }
                else
                {
                    try
                    {
                        txtValorDocumento.Text = Convert.ToDecimal(txtValorDocumento.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorDocumento.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorDocumento.");
                        }
                        txtValorDocumento.Text = null;
                    }
                }
            }
            txtValorDocumento.BackColor = Color.White;
        }

        private void mtxtDataDesconto_Enter(object sender, EventArgs e)
        {
            mtxtDataDesconto.BackColor = Color.LightBlue;
        }

        private void mtxtDataDesconto_Leave(object sender, EventArgs e)
        {
            mtxtDataDesconto.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataDesconto.Text == "")
            {
                mtxtDataDesconto.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            else
            {
                try
                {
                    mtxtDataDesconto.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataVencimento.Text == "")
                    {
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        ValidarData.Ver_Data(mtxtDataDesconto.Text);
                    }
                    else
                    {
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataDesconto.Text) < Convert.ToDateTime(mtxtDataEmissao.Text))
                        {
                            MessageBox.Show("Data de desconto é menor que a data de emissão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataDesconto.Text = null;
                            mtxtDataDesconto.Select();
                        }
                        else
                        {
                            ValidarData.Ver_Data(mtxtDataDesconto.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataDesconto.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataDesconto.");
                    }
                    mtxtDataDesconto.Text = null;
                }
            }
            mtxtDataDesconto.BackColor = Color.White;
        }

        private void txtMulta_Enter(object sender, EventArgs e)
        {
            txtMulta.BackColor = Color.LightBlue;
        }

        private void txtMulta_Leave(object sender, EventArgs e)
        {
            if (txtMulta.Text.Contains("'") || txtMulta.Text.Contains(";") || txtMulta.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtMulta.Text = null;
                txtMulta.Select();
            }
            else
            {
                if (txtMulta.Text != "")
                {
                    try
                    {
                        txtMulta.Text = Convert.ToDecimal(txtMulta.Text).ToString("n2", new CultureInfo("pt-BR"));

                        if (txtValorDocumento.Text != "")
                        {
                            txtValorMulta.Text = Convert.ToDecimal(bllContasPagar.Calculo_Multa(txtValorDocumento.Text, txtMulta.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorMulta.Text = "0,00";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtMulta.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtMulta.");
                        }
                        txtMulta.Text = null;
                    }
                }
            }
            txtMulta.BackColor = Color.White;
        }

        private void btnNovo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnNovo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
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

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtConta.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtConta.Enabled = false;
            grbBox1.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnDuplicar.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            Ativar();
            cbbSubGrupo.Enabled = false;
            lblSubGrupo.Enabled = false;
            lblAsteriscoSubGrupo.Enabled = false;
            btnProcurar2.Enabled = false;
            Limpar();
            txtDescricao.Select();
            _Comando_Atualizar = false;
            _Inserir_Atualizar = true;
            tabcCadastro.SelectedTab = tabpCadastro1;
            //
            lblDescontoData.Enabled = false;
            mtxtDataDesconto.Enabled = false;
            txtDesconto.Enabled = false;
            lblDesconto.Enabled = false;
            lblValorDesconto.Enabled = false;
            txtValorDesconto.Enabled = false;
            lblMulta.Enabled = false;
            txtMulta.Enabled = false;
            lblValorMulta.Enabled = false;
            txtValorMulta.Enabled = false;
            btnSelecionarData3.Enabled = false;
            lblMora.Enabled = false;
            txtMora.Enabled = false;
            lblPorcentagem1.Enabled = false;
            lblPorcentagem2.Enabled = false;
            lblPorcentagem3.Enabled = false;
            //
            Limpar();
            txtOcorrenciaParcela.Text = "1";
            cbbTipoEmitente.Text = "CLIENTES";
            //
            try
            {
                cbbGrupo.Items.Clear();
                cbbSubGrupo.Items.Clear();
                if (bllContasPagar.Sel_Grupo_Conta_Pagar() == null)
                {
                    cbbGrupo.Text = null;
                    cbbSubGrupo.Items.Clear();
                    cbbSubGrupo.Enabled = false;
                    cbbSubGrupo.Text = null;
                    btnProcurar2.Enabled = false;
                    lblSubGrupo.Enabled = false;
                }
                else
                {
                    cbbGrupo.Items.Add("");
                    foreach (DataRow dr in bllContasPagar.Sel_Grupo_Conta_Pagar().Rows)
                    {
                        cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbEmitente.Items.Clear();
                if (bllContasPagar.Sel_Cliente_Cont() == null)
                {
                    cbbEmitente.Enabled = false;
                    cbbEmitente.Text = null;
                }
                else
                {
                    cbbEmitente.Enabled = true;
                    btnProcurar.Enabled = true;
                    cbbEmitente.Items.Add("");
                    foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                    {
                        cbbEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
                //
                cbbEntBanc.Items.Clear();
                if (bllContasPagar.Sel_Entidade_Bancaria_Conta_Pagar() == null)
                {
                    cbbEntBanc.Enabled = false;
                    cbbEntBanc.Text = null;
                }
                else
                {
                    cbbEntBanc.Enabled = true;
                    btnProcurarEntBanc.Enabled = true;
                    cbbEntBanc.Items.Add("");
                    foreach (DataRow dr in bllContasPagar.Sel_Entidade_Bancaria_Conta_Pagar().Rows)
                    {
                        cbbEntBanc.Items.Add((dr["id_ent_bancaria"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbGrupo.Text = "2—CONTAS A PAGAR NO GERAL";
                cbbSubGrupo.Text = "2—GERAL";
                cbbTipoDocumento.Text = "OUTROS";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnNovo.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtConta.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxEmitente_Valor = null;
                _ComboboxEntBancaria_Valor = null;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllContasPagar.Sel_Conta_Pagar_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtConta.Select();
                }
                else
                {
                    DataGridViewRow SelectedRow = dtConta.Rows[dtConta.CurrentRow.Index];
                    if (bllContasPagar.Sel_Conta_Pendente_True_Mult(SelectedRow.Cells[0].Value.ToString()) == false)
                    {
                        MessageBox.Show("Não é possível alterar uma Conta a Pagar [ Efetuada ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtConta.Select();
                    }
                    else
                    {
                        dtConta.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                        btnNovo.Enabled = false;
                        btnCancelar.Visible = true;
                        btnAlterar.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnSalvar.Enabled = true;
                        grbBox1.Enabled = false;
                        txtOcorrenciaParcela.Enabled = true;
                        Ativar();
                        cbbSubGrupo.Enabled = true;
                        lblSubGrupo.Enabled = true;
                        lblAsteriscoSubGrupo.Enabled = true;
                        btnProcurar2.Enabled = true;
                        btnDuplicar.Enabled = false;
                        dtConta.Enabled = false;
                        lblCodigo.Enabled = true;
                        txtCodigo.Enabled = true;
                        txtDescricao.Select();
                        _Comando_Atualizar = true;
                        _Inserir_Atualizar = true;
                        //
                        _ComboboxGrupo_Valor = cbbGrupo.Text;
                        _ComboboxSubgrupo_Valor = cbbSubGrupo.Text;
                        _ComboboxEntBancaria_Valor = cbbEntBanc.Text;
                        //
                        cbbEntBanc.Items.Clear();
                        if (bllContasPagar.Sel_Entidade_Bancaria_Conta_Pagar() == null)
                        {
                            cbbEntBanc.Text = null;
                        }
                        else
                        {
                            cbbEntBanc.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_Entidade_Bancaria_Conta_Pagar().Rows)
                            {
                                cbbEntBanc.Items.Add((dr["id_ent_bancaria"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        //
                        if (SelectedRow.Cells[38].Value.ToString() != "0")
                        {
                            if (bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_EntBancaria_ContaPagar(_ComboboxEntBancaria_Valor) != null)
                            {
                                foreach (DataRow dr in bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_EntBancaria_ContaPagar(_ComboboxEntBancaria_Valor).Rows)
                                {
                                    cbbEntBanc.Text = dr["id_ent_bancaria"].ToString() + "—" + dr["descricao"].ToString();
                                }
                                _ComboboxEntBancaria_Valor = null;
                            }
                        }
                        //
                        if (cbbGrupo.Text != "")
                        {
                            cbbGrupo.Items.Clear();
                            if (bllContasPagar.Sel_Grupo_Conta_Pagar() == null)
                            {
                                cbbGrupo.Text = null;
                            }
                            else
                            {
                                cbbGrupo.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Grupo_Conta_Pagar().Rows)
                                {
                                    cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            //
                            if (bllContasPagar.Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Pagar(_ComboboxGrupo_Valor) != null)
                            {
                                foreach (DataRow dr in bllContasPagar.Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Pagar(_ComboboxGrupo_Valor).Rows)
                                {
                                    cbbGrupo.Text = dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString();
                                }
                                _ComboboxGrupo_Valor = null;
                            }
                            else
                            {
                                _ComboboxGrupo_Valor = null;
                                cbbGrupo.Text = null;
                            }
                            //
                            if (_ComboboxSubgrupo_Valor != "")
                            {
                                cbbSubGrupo.Items.Clear();
                                if (bllContasPagar.Sel_SubGrupo_Conta_Pagar(cbbGrupo.Text) == null)
                                {
                                    cbbSubGrupo.Text = null;
                                }
                                else
                                {
                                    cbbSubGrupo.Items.Add("");
                                    foreach (DataRow dr in bllContasPagar.Sel_SubGrupo_Conta_Pagar(cbbGrupo.Text).Rows)
                                    {
                                        cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                    }
                                }
                                //
                                if (bllContasPagar.Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Pagar(_ComboboxSubgrupo_Valor, cbbGrupo.Text) != null)
                                {
                                    foreach (DataRow dr in bllContasPagar.Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Pagar(_ComboboxSubgrupo_Valor, cbbGrupo.Text).Rows)
                                    {
                                        cbbSubGrupo.Text = dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString();
                                    }
                                    _ComboboxSubgrupo_Valor = null;
                                }
                                else
                                {
                                    _ComboboxSubgrupo_Valor = null;
                                    cbbSubGrupo.Text = null;
                                }
                            }
                        }
                        //
                        if (cbbTipoEmitente.SelectedIndex == 1)
                        {
                            if (cbbEmitente.Text != "")
                            {
                                _ComboboxEmitente_Valor = cbbEmitente.Text;
                                cbbEmitente.Items.Clear();
                                if (bllContasPagar.Sel_Cliente_Cont() == null)
                                {
                                    cbbEmitente.Text = null;
                                }
                                else
                                {
                                    cbbEmitente.Items.Add("");
                                    foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                                    {
                                        cbbEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                                    }
                                }

                                if (bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaPagar(_ComboboxEmitente_Valor) != null)
                                {
                                    foreach (DataRow dr in bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaPagar(_ComboboxEmitente_Valor).Rows)
                                    {
                                        cbbEmitente.Text = dr["id_cliente"].ToString() + "—" + dr["nome"].ToString();
                                    }
                                    _ComboboxEmitente_Valor = null;
                                }
                                else
                                {
                                    _ComboboxEmitente_Valor = null;
                                    cbbEmitente.Text = null;
                                }
                            }
                        }
                        else if (cbbTipoEmitente.SelectedIndex == 2)
                        {
                            if (cbbEmitente.Text != "")
                            {
                                _ComboboxEmitente_Valor = cbbEmitente.Text;
                                cbbEmitente.Items.Clear();
                                if (bllContasPagar.Sel_Forn_Cont() == null)
                                {
                                    cbbEmitente.Text = null;
                                }
                                else
                                {
                                    cbbEmitente.Items.Add("");
                                    foreach (DataRow dr in bllContasPagar.Sel_Forn_Cont().Rows)
                                    {
                                        cbbEmitente.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                                    }
                                }

                                if (bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaPagar(_ComboboxEmitente_Valor) != null)
                                {
                                    foreach (DataRow dr in bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaPagar(_ComboboxEmitente_Valor).Rows)
                                    {
                                        cbbEmitente.Text = dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString();
                                    }
                                    _ComboboxEmitente_Valor = null;
                                }
                            }
                            else
                            {
                                _ComboboxEmitente_Valor = null;
                                cbbEmitente.Text = null;
                            }
                        }
                        else if (cbbTipoEmitente.SelectedIndex == 3)
                        {
                            if (cbbEmitente.Text != "")
                            {
                                _ComboboxEmitente_Valor = cbbEmitente.Text;
                                cbbEmitente.Items.Clear();
                                if (bllContasPagar.Sel_Func_Cont() == null)
                                {
                                    cbbEmitente.Text = null;
                                }
                                else
                                {
                                    cbbEmitente.Items.Add("");
                                    foreach (DataRow dr in bllContasPagar.Sel_Func_Cont().Rows)
                                    {
                                        cbbEmitente.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                                    }
                                }

                                if (bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaPagar(_ComboboxEmitente_Valor) != null)
                                {
                                    foreach (DataRow dr in bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaPagar(_ComboboxEmitente_Valor).Rows)
                                    {
                                        cbbEmitente.Text = dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString();
                                    }
                                    _ComboboxEmitente_Valor = null;
                                }
                            }
                            else
                            {
                                _ComboboxEmitente_Valor = null;
                                cbbEmitente.Text = null;
                            }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtConta.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxEmitente_Valor = null;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadContasPagar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDesconto.Text == "" & txtValorDesconto.Text != "")
                {
                    txtValorDesconto_Leave(sender, e);
                }
                if (txtValorDesconto.Text == "" & txtDesconto.Text != "")
                {
                    txtDesconto_Leave(sender, e);
                }
                //
                if (txtMulta.Text == "" & txtValorMulta.Text != "")
                {
                    txtValorMulta_Leave(sender, e);
                }
                if (txtValorMulta.Text == "" & txtMulta.Text != "")
                {
                    txtMulta_Leave(sender, e);
                }
                //
                if (cbbTipoEmitente.SelectedIndex == 1)
                {
                    if (cbbEmitente.Text != "")
                    {
                        _ComboboxEmitente_Valor = cbbEmitente.Text;
                        cbbEmitente.Items.Clear();
                        if (bllContasPagar.Sel_Cliente_Cont() == null)
                        {
                            cbbEmitente.Text = null;
                        }
                        else
                        {
                            cbbEmitente.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                            {
                                cbbEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }

                        if (bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaPagar(_ComboboxEmitente_Valor) != null)
                        {
                            foreach (DataRow dr in bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaPagar(_ComboboxEmitente_Valor).Rows)
                            {
                                cbbEmitente.Text = dr["id_cliente"].ToString() + "—" + dr["nome"].ToString();
                            }
                            _ComboboxEmitente_Valor = null;
                        }
                        else
                        {
                            _ComboboxEmitente_Valor = null;
                            cbbEmitente.Text = null;
                        }
                    }
                }
                else if (cbbTipoEmitente.SelectedIndex == 2)
                {
                    if (cbbEmitente.Text != "")
                    {
                        _ComboboxEmitente_Valor = cbbEmitente.Text;
                        cbbEmitente.Items.Clear();
                        if (bllContasPagar.Sel_Forn_Cont() == null)
                        {
                            cbbEmitente.Text = null;
                        }
                        else
                        {
                            cbbEmitente.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_Forn_Cont().Rows)
                            {
                                cbbEmitente.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }

                        if (bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaPagar(_ComboboxEmitente_Valor) != null)
                        {
                            foreach (DataRow dr in bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaPagar(_ComboboxEmitente_Valor).Rows)
                            {
                                cbbEmitente.Text = dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString();
                            }
                            _ComboboxEmitente_Valor = null;
                        }
                    }
                    else
                    {
                        _ComboboxEmitente_Valor = null;
                        cbbEmitente.Text = null;
                    }
                }
                else if (cbbTipoEmitente.SelectedIndex == 3)
                {
                    if (cbbEmitente.Text != "")
                    {
                        _ComboboxEmitente_Valor = cbbEmitente.Text;
                        cbbEmitente.Items.Clear();
                        if (bllContasPagar.Sel_Func_Cont() == null)
                        {
                            cbbEmitente.Text = null;
                        }
                        else
                        {
                            cbbEmitente.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_Func_Cont().Rows)
                            {
                                cbbEmitente.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }

                        if (bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaPagar(_ComboboxEmitente_Valor) != null)
                        {
                            foreach (DataRow dr in bllContasPagar.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaPagar(_ComboboxEmitente_Valor).Rows)
                            {
                                cbbEmitente.Text = dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString();
                                _ComboboxEmitente_Valor = null;
                            }
                        }
                        else
                        {
                            _ComboboxEmitente_Valor = null;
                            cbbEmitente.Text = null;
                        }
                    }
                }

                _ComboboxGrupo_Valor = cbbGrupo.Text;
                _ComboboxSubgrupo_Valor = cbbSubGrupo.Text;

                if (cbbGrupo.Text != "")
                {
                    cbbGrupo.Items.Clear();
                    if (bllContasPagar.Sel_Grupo_Conta_Pagar() == null)
                    {
                        cbbGrupo.Text = null;
                    }
                    else
                    {
                        cbbGrupo.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Grupo_Conta_Pagar().Rows)
                        {
                            cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    //
                    if (bllContasPagar.Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Pagar(_ComboboxGrupo_Valor) != null)
                    {
                        foreach (DataRow dr in bllContasPagar.Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Pagar(_ComboboxGrupo_Valor).Rows)
                        {
                            cbbGrupo.Text = dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString();
                        }
                        _ComboboxGrupo_Valor = null;
                    }
                    else
                    {
                        _ComboboxGrupo_Valor = null;
                        cbbGrupo.Text = null;
                    }
                    //
                    if (_ComboboxSubgrupo_Valor != "")
                    {
                        cbbSubGrupo.Items.Clear();
                        if (bllContasPagar.Sel_SubGrupo_Conta_Pagar(cbbGrupo.Text) == null)
                        {
                            cbbSubGrupo.Text = null;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_SubGrupo_Conta_Pagar(cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        //
                        cbbSubGrupo.Text = _ComboboxSubgrupo_Valor;
                        //
                        if (_ComboboxSubgrupo_Valor != "")
                        {
                            if (bllContasPagar.Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Pagar(_ComboboxSubgrupo_Valor, cbbGrupo.Text) != null)
                            {
                                foreach (DataRow dr in bllContasPagar.Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Pagar(_ComboboxSubgrupo_Valor, cbbGrupo.Text).Rows)
                                {
                                    cbbSubGrupo.Text = dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString();
                                }
                                _ComboboxSubgrupo_Valor = null;
                            }
                            else
                            {
                                _ComboboxSubgrupo_Valor = null;
                                cbbSubGrupo.Text = null;
                            }
                        }
                    }
                }
                //               
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (txtOcorrenciaParcela.Text == "" || txtDescricao.Text == "" || mtxtDataEmissao.Text == "" || mtxtDataVencimento.Text == "" || cbbTipoDocumento.Text == "" || cbbTipoEmitente.Text == "" || cbbEmitente.Text == "" || txtValorDocumento.Text == "" || cbbGrupo.Text == "" || cbbSubGrupo.Text == "" || txtValorDocumento.Text == "0,00")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Parcela ], [ Descrição ], [ Data de Emissão ],\n[ Data de Vencimento ], [ Tipo de Documento ], [ Emitente ],\n[ Grupo ], [ Subgrupo ] e [ Valor ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        txtDescricao.Select();
                    }
                    else
                    {
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (_Comando_Atualizar == true)
                        {
                            if (bllContasPagar.Sel_Conta_Pagar_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                dtConta.DataSource = null;
                                rbtnDescricao.Checked = true;
                                ModoPesquisa();
                                Limpar();
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                            }
                            else
                            {
                                bllContasPagar.Alterar(txtCodigo.Text, txtPalavraChave.Text.Trim(), txtContratoMatServ.Text.Trim(), txtOcorrenciaParcela.Text.Trim(), txtDescricao.Text.Trim(), txtCodBarra.Text.Trim(), mtxtDataEmissao.Text, mtxtDataVencimento.Text, cbbTipoDocumento.Text, cbbTipoEmitente.Text, cbbEmitente.Text, txtValorDocumento.Text.Trim(), mtxtDataDesconto.Text, txtDesconto.Text.Trim(), txtValorDesconto.Text.Trim(), txtMulta.Text.Trim(), txtValorMulta.Text.Trim(), rtxtObs.Text.Trim(), txtNDocumento.Text.Trim(), txtMora.Text.Trim(), cbbGrupo.Text, cbbSubGrupo.Text, cbbEntBanc.Text);
                                //
                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UMA CONTA A PAGAR", "CONTAS A PAGAR", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                //
                                dtConta.DataSource = bllContasPagar.Sel_Conta_A_Alt(txtCodigo.Text);
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                //
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                _ComboboxGrupo_Valor = null;
                                _ComboboxSubgrupo_Valor = null;
                                _ComboboxEmitente_Valor = null;
                                //
                                ModoPesquisa();
                                //
                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                if (bllLembrete.Sel_Codigo_Tabela_Geradora(txtCodigo.Text, "CONTAS A PAGAR") != null)
                                {
                                    string codigo = bllLembrete.Sel_Codigo_Tabela_Geradora(txtCodigo.Text, "CONTAS A PAGAR");
                                    DialogResult = MessageBox.Show("Deseja alterar também os dados do lembrete associado a esta Conta a Pagar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        using (FrmUtilAgenda Agenda = new FrmUtilAgenda(_Usuario, _Cod_PDV_Computador, 1, codigo))
                                        {
                                            if (Agenda.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bllContasPagar.Salvar(txtPalavraChave.Text.Trim(), txtContratoMatServ.Text.Trim(), txtOcorrenciaParcela.Text.Trim(), txtDescricao.Text.Trim(), txtCodBarra.Text.Trim(), mtxtDataEmissao.Text, mtxtDataVencimento.Text, cbbTipoDocumento.Text, cbbTipoEmitente.Text, cbbEmitente.Text, txtValorDocumento.Text.Trim(), mtxtDataDesconto.Text, txtDesconto.Text.Trim(), txtValorDesconto.Text.Trim(), txtMulta.Text.Trim(), txtValorMulta.Text.Trim(), rtxtObs.Text.Trim(), txtNDocumento.Text.Trim(), txtMora.Text.Trim(), cbbGrupo.Text, cbbSubGrupo.Text, cbbEntBanc.Text, null, null, null);

                            dtConta.DataSource = bllContasPagar.Sel_Conta_A_Sal();

                            bllRegistroAtividades.Salvar("SALVOU UMA CONTA A PAGAR", "CONTAS A PAGAR", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            _ComboboxGrupo_Valor = null;
                            _ComboboxSubgrupo_Valor = null;
                            _ComboboxEmitente_Valor = null;

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar cadastrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar cadastrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            if (bllUsuario.Sel_Criar_Lemb_Conta_Pagar_Usuario(_Usuario) == true)
                            {
                                DialogResult = MessageBox.Show("Deseja criar um lembrete para esta Conta a Pagar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    DataGridViewRow SelectedRow = dtConta.Rows[dtConta.CurrentRow.Index];
                                    //
                                    using (FrmUtilCadLembrete Lembrete = new FrmUtilCadLembrete(null, SelectedRow.Cells[7].Value.ToString(), null, "LEMBRETE DE CONTA A PAGAR", "LEMBRETE DE CONTA A PAGAR DE CÓDIGO " + SelectedRow.Cells[0].Value.ToString().Trim() + "  NO VALOR DE " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + " R$ DO " + SelectedRow.Cells[9].Value.ToString() + " " + SelectedRow.Cells[10].Value.ToString() + "-" + SelectedRow.Cells[11].Value.ToString() + ".", null, false, _Usuario, _Cod_PDV_Computador, 2, "CONTAS A PAGAR", SelectedRow.Cells[0].Value.ToString()))
                                    {
                                        if (Lembrete.ShowDialog() == DialogResult.OK)
                                        {
                                            this.DialogResult = DialogResult.None;
                                        }
                                    }
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            //
                            ModoPesquisa();

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    txtDescricao.Select();
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
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtConta.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxEmitente_Valor = null;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodas.Checked == true)
                {
                    if (bllContasPagar.Sel_Conta_Todas() == null)
                    {
                        dtConta.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtConta.DataSource = bllContasPagar.Sel_Conta_Todas();
                        dtConta.Select();
                    }
                }
                else if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllContasPagar.Sel_Conta_Descricao(txtpDescricao.Text) == null)
                        {
                            dtConta.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtConta.DataSource = bllContasPagar.Sel_Conta_Descricao(txtpDescricao.Text);
                            dtConta.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllContasPagar.Sel_Conta_Codigo(txtpCodigo.Text) == null)
                        {
                            dtConta.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtConta.DataSource = bllContasPagar.Sel_Conta_Codigo(txtpCodigo.Text);
                            dtConta.Select();
                        }
                    }
                }
                else if (rbtnCodBarra.Checked == true)
                {
                    if (txtpBarra.Text != "")
                    {
                        if (bllContasPagar.Sel_Conta_Codigo_Barra(txtpBarra.Text) == null)
                        {
                            dtConta.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtConta.DataSource = bllContasPagar.Sel_Conta_Codigo_Barra(txtpBarra.Text);
                            dtConta.Select();
                        }
                    }
                }
                else if (rbtnEmitente.Checked == true)
                {
                    if (cbbpEmitente.Text != "" & cbbpTipoEmitente.Text != "")
                    {
                        if (bllContasPagar.Sel_Conta_Emitente(cbbpEmitente.Text, cbbpTipoEmitente.Text) == null)
                        {
                            dtConta.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtConta.DataSource = bllContasPagar.Sel_Conta_Emitente(cbbpEmitente.Text, cbbpTipoEmitente.Text);
                            dtConta.Select();
                        }
                    }
                    else if (cbbpEmitente.Text == "" & cbbpTipoEmitente.Text != "")
                    {
                        if (bllContasPagar.Sel_Conta_Tipo_Emitente(cbbpTipoEmitente.Text) == null)
                        {
                            dtConta.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtConta.DataSource = bllContasPagar.Sel_Conta_Tipo_Emitente(cbbpTipoEmitente.Text);
                            dtConta.Select();
                        }
                    }
                }
                else if (rbtnNDocumento.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllContasPagar.Sel_Conta_N_Documento(txtpCodigo.Text) == null)
                        {
                            dtConta.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtConta.DataSource = bllContasPagar.Sel_Conta_N_Documento(txtpCodigo.Text);
                            dtConta.Select();
                        }
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou conta a pagar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou conta a pagar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtConta.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxEmitente_Valor = null;
            }
        }

        private void rbtnTodas_CheckedChanged(object sender, EventArgs e)
        {
            cbbpEmitente.Visible = false;
            cbbpTipoEmitente.Visible = false;
            btnpProcurar.Visible = false;
            txtpBarra.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(631, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void rbtnTodas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtConta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtConta.Rows[e.RowIndex];
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                txtContratoMatServ.Text = SelectedRow.Cells[2].Value.ToString();
                txtOcorrenciaParcela.Text = SelectedRow.Cells[3].Value.ToString();
                txtNDocumento.Text = SelectedRow.Cells[4].Value.ToString();
                txtCodBarra.Text = SelectedRow.Cells[5].Value.ToString();
                mtxtDataEmissao.Text = SelectedRow.Cells[6].Value.ToString();
                mtxtDataVencimento.Text = SelectedRow.Cells[7].Value.ToString();
                cbbTipoDocumento.Text = SelectedRow.Cells[8].Value.ToString();
                cbbTipoEmitente.Text = SelectedRow.Cells[9].Value.ToString();
                cbbEmitente.Items.Clear();
                cbbEmitente.Items.Add(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString());
                cbbEmitente.Text = SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString();
                cbbGrupo.Items.Clear();
                cbbGrupo.Items.Add(SelectedRow.Cells[12].Value.ToString() + "—" + SelectedRow.Cells[13].Value.ToString());
                cbbGrupo.Text = SelectedRow.Cells[12].Value.ToString() + "—" + SelectedRow.Cells[13].Value.ToString();
                cbbSubGrupo.Items.Clear();
                cbbSubGrupo.Items.Add(SelectedRow.Cells[14].Value.ToString() + "—" + SelectedRow.Cells[15].Value.ToString());
                cbbSubGrupo.Text = SelectedRow.Cells[14].Value.ToString() + "—" + SelectedRow.Cells[15].Value.ToString();
                dtConta.Columns[16].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtConta.Columns[16].DefaultCellStyle.Format = "n2";
                txtValorDocumento.Text = Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR"));
                mtxtDataDesconto.Text = SelectedRow.Cells[18].Value.ToString();
                dtConta.Columns[19].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtConta.Columns[19].DefaultCellStyle.Format = "n2";
                txtDesconto.Text = Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtConta.Columns[20].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtConta.Columns[20].DefaultCellStyle.Format = "n2";
                txtValorDesconto.Text = Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtConta.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtConta.Columns[21].DefaultCellStyle.Format = "n2";
                txtMulta.Text = Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtConta.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtConta.Columns[22].DefaultCellStyle.Format = "n2";
                txtValorMulta.Text = Convert.ToDecimal(SelectedRow.Cells[22].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtConta.Columns[23].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtConta.Columns[23].DefaultCellStyle.Format = "n2";
                txtMora.Text = Convert.ToDecimal(SelectedRow.Cells[23].Value).ToString("n2", new CultureInfo("pt-BR"));
                cbbEntBanc.Items.Clear();
                rtxtObs.Text = SelectedRow.Cells[30].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[31].Value.ToString();
                if (SelectedRow.Cells[38].Value.ToString() != "0")
                {
                    cbbEntBanc.Items.Add(SelectedRow.Cells[38].Value.ToString() + "—" + SelectedRow.Cells[39].Value.ToString());
                    cbbEntBanc.Text = SelectedRow.Cells[38].Value.ToString() + "—" + SelectedRow.Cells[39].Value.ToString();
                }

                dtConta.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtConta.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                if (SelectedRow.Cells[25].Value.ToString() == "PENDENTE")
                {
                    lblValorSituacao.Text = "PENDENTE";
                    lblValorSituacao.ForeColor = Color.Red;
                    lblCxSituacao.BackColor = Color.Red;
                }
                else if (SelectedRow.Cells[25].Value.ToString() == "EFETUADO")
                {
                    lblValorSituacao.Text = "EFETUADO";
                    lblValorSituacao.ForeColor = Color.Green;
                    lblCxSituacao.BackColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellEnter da grade de dados dtConta.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellEnter da grade de dados dtConta.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtConta.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxEmitente_Valor = null;
            }
        }

        private void txtCodBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbEntBanc.Select();
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtContratoMatServ.Select();
            }
        }

        private void cbbTipoCobranca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataEmissao.Select();
            }
        }

        private void mtxtDataEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataVencimento.Select();
            }
        }

        private void mtxtDataVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbGrupo.Select();
            }
        }

        private void mtxtDataDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDesconto.Select();
            }
        }

        private void txtMulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMulta.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtValorMulta.Select();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                Limpar();
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnDuplicar.Enabled = true;
            }
            else
            {
                if (dtConta.DataSource == null)
                {
                    Limpar();
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnDuplicar.Enabled = true;
                }
            }
            _Inserir_Atualizar = false;
            _ComboboxEmitente_Valor = null;
            _ComboboxGrupo_Valor = null;
            _ComboboxSubgrupo_Valor = null;
            ModoPesquisa();
        }

        private void mtxtDataEmissao_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataEmissao.Text == "")
            {
                mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void mtxtDataVencimento_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataVencimento.Text == "")
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void mtxtDataDesconto_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataDesconto.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataDesconto.Text == "")
            {
                mtxtDataDesconto.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataDesconto.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void dtConta_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtConta.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                btnDuplicar.Enabled = false;
                dtConta.Enabled = false;
                lblCxSituacao.Visible = false;
                lblValorSituacao.Visible = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnDuplicar.Enabled = true;
                dtConta.Enabled = true;
                lblCxSituacao.Visible = true;
                lblValorSituacao.Visible = true;

                List<string> cor = new List<string>();
                List<string> grupo = new List<string>();

                if (bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A PAGAR") != null)
                {
                    for (int i = 0; i < bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A PAGAR").Rows.Count; i++)
                    {
                        DataRow dr = bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A PAGAR").Rows[i];
                        //
                        if (dr["cor_destaque"].ToString() != null & dr["cor_destaque"].ToString() != "")
                        {
                            cor.Add(dr["cor_destaque"].ToString());
                            grupo.Add(dr["id_grupo"].ToString());
                        }
                    }
                }

                for (int i = 0; i < dtConta.Rows.Count; i++)
                {
                    for (int u = 0; u < cor.Count; u++)
                    {
                        if (cor[u] == "")
                        {
                            dtConta.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        else if (cor[u] == "1" & grupo[u] == dtConta.Rows[i].Cells[12].Value.ToString())
                        {
                            dtConta.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                        else if (cor[u] == "2" & grupo[u] == dtConta.Rows[i].Cells[12].Value.ToString())
                        {
                            dtConta.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                        }
                        else if (cor[u] == "3" & grupo[u] == dtConta.Rows[i].Cells[12].Value.ToString())
                        {
                            dtConta.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                        }
                        else if (cor[u] == "4" & grupo[u] == dtConta.Rows[i].Cells[12].Value.ToString())
                        {
                            dtConta.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        else if (cor[u] == "5" & grupo[u] == dtConta.Rows[i].Cells[12].Value.ToString())
                        {
                            dtConta.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                        }
                        else if (cor[u] == "6" & grupo[u] == dtConta.Rows[i].Cells[12].Value.ToString())
                        {
                            dtConta.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void dtConta_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtConta.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllContasPagar.Sel_Conta_Pagar_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtConta.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir esta Conta a Pagar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllContasPagar.Sel_Conta_Pendente_True_Mult(txtCodigo.Text) == false)
                        {
                            MessageBox.Show("Não é possível excluir uma Conta a Pagar [ Efetuada ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            btnExcluir.Select();
                        }
                        else if (bllContasPagar.Sel_Contas_Pagar_Pagamento_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("A Conta a Pagar selecionada está sendo utilizada por um Pagamento, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtConta.Select();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;

                            if (bllLembrete.Sel_Codigo_Tabela_Geradora(txtCodigo.Text, "CONTAS A PAGAR") != null)
                            {
                                string codigo = bllLembrete.Sel_Codigo_Tabela_Geradora(txtCodigo.Text, "CONTAS A PAGAR");
                                //
                                bllLembrete.Excluir(codigo);
                                //
                                bllLembrete.Excluir_Usuario_Lembrete(codigo);
                            }
                            //
                            bllContasPagar.Excluir(txtCodigo.Text, _Cod_PDV_Computador);
                            //
                            bllRegistroAtividades.Salvar("EXCLUIU UMA CONTA A PAGAR", "CONTAS A PAGAR", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            if (rbtnTodas.Checked == true)
                            {
                                if (bllContasPagar.Sel_Conta_Todas() == null)
                                {
                                    dtConta.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtConta.DataSource = bllContasPagar.Sel_Conta_Todas();
                                    dtConta.Select();
                                }
                            }
                            else if (rbtnDescricao.Checked == true)
                            {
                                if (txtpDescricao.Text != "")
                                {
                                    if (bllContasPagar.Sel_Conta_Descricao(txtpDescricao.Text) == null)
                                    {
                                        dtConta.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtConta.DataSource = bllContasPagar.Sel_Conta_Descricao(txtpDescricao.Text);
                                        dtConta.Select();
                                    }
                                }
                                else
                                {
                                    dtConta.DataSource = null;
                                    Limpar();
                                }
                            }
                            else if (rbtnEmitente.Checked == true)
                            {
                                if (cbbpEmitente.Text != "" & cbbpTipoEmitente.Text != "")
                                {
                                    if (bllContasPagar.Sel_Conta_Emitente(cbbpEmitente.Text, cbbpTipoEmitente.Text) == null)
                                    {
                                        dtConta.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtConta.DataSource = bllContasPagar.Sel_Conta_Emitente(cbbpEmitente.Text, cbbpTipoEmitente.Text);
                                        dtConta.Select();
                                    }
                                }
                                else if (cbbpEmitente.Text == "" & cbbpTipoEmitente.Text != "")
                                {
                                    if (bllContasPagar.Sel_Conta_Tipo_Emitente(cbbpTipoEmitente.Text) == null)
                                    {
                                        dtConta.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtConta.DataSource = bllContasPagar.Sel_Conta_Tipo_Emitente(cbbpTipoEmitente.Text);
                                        dtConta.Select();
                                    }
                                }
                                else
                                {
                                    dtConta.DataSource = null;
                                    Limpar();
                                }
                            }
                            else
                            {
                                dtConta.DataSource = null;
                                Limpar();
                            }
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        if (dtConta.DataSource != null)
                        {
                            dtConta.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtConta.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxEmitente_Valor = null;
            }
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllContasPagar.Sel_Conta_Pagar_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtConta.Select();
                }
                else
                {
                    if (bllContasPagar.Sel_Conta_Pendente_True_Mult(txtCodigo.Text) == false)
                    {
                        MessageBox.Show("Não é possível multiplicar uma Conta a Pagar [ Efetuada ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else if (txtContratoMatServ.Text == "")
                    {
                        MessageBox.Show("Não é possível multiplicar uma Conta que não possua número de contrato, matrícula ou código do serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        pEnabled.Enabled = false;
                        using (FrmCadContaAdicionarParcelas Multi = new FrmCadContaAdicionarParcelas(0))
                        {
                            if (Multi.ShowDialog() == DialogResult.OK)
                            {

                                bllContasPagar._Data_Emissao_Multiplicada = mtxtDataEmissao.Text;
                                bllContasPagar._Data_Vencimento_Multiplicada = mtxtDataVencimento.Text;
                                bllContasPagar._Data_Desconto_Multiplicada = mtxtDataDesconto.Text;
                                bllContasPagar._N_Documento_Multiplicada = txtNDocumento.Text;
                                //
                                bllContasPagar.Multiplicar(txtContratoMatServ.Text.Trim(), txtDescricao.Text.Trim(), cbbTipoDocumento.Text, cbbTipoEmitente.Text, cbbEmitente.Text, txtValorDocumento.Text, txtDesconto.Text, txtValorDesconto.Text, txtMulta.Text, txtValorMulta.Text, txtMora.Text, txtOcorrenciaParcela.Text, cbbGrupo.Text, cbbSubGrupo.Text);
                                //
                                bllRegistroAtividades.Salvar("SALVOU UMA OU MAIS CONTAS A PAGAR", "CONTAS A PAGAR", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                //
                                dtConta.DataSource = bllContasPagar.Sel_Conta_Emitente(cbbEmitente.Text, cbbTipoEmitente.Text);
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar multiplicada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a pagar multiplicada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                //
                                bllContasPagar._Data_Emissao_Multiplicada = null;
                                bllContasPagar._Data_Vencimento_Multiplicada = null;
                                bllContasPagar._Dias = null;
                                bllContasPagar._Parcela = null;
                                bllContasPagar._Data_Desconto_Multiplicada = null;
                                bllContasPagar._N_Documento_Multiplicada = null;
                                //
                                ModoPesquisa();
                                //
                                MessageBox.Show("O(s) dado(s) foram(foi) salvo(s) com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                this.DialogResult = DialogResult.None;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDuplicar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDuplicar.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtConta.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxEmitente_Valor = null;
            }
            pEnabled.Enabled = true;
        }

        private void txtNumeroDocumento_Enter(object sender, EventArgs e)
        {
            txtContratoMatServ.BackColor = Color.LightBlue;
        }

        private void txtNumeroDocumento_Leave(object sender, EventArgs e)
        {
            if (txtContratoMatServ.Text.Contains("'") || txtContratoMatServ.Text.Contains(";") || txtContratoMatServ.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtContratoMatServ.Text = null;
                txtContratoMatServ.Select();
            }
            else
            {
                if (_Inserir_Atualizar == true)
                {
                    try
                    {
                        if (txtContratoMatServ.Text != "")
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllContasPagar.Sel_Conta_Ndoc_ContMatServ_Alt(txtCodigo.Text, txtNDocumento.Text.Trim(), txtContratoMatServ.Text.Trim()) == true)
                                {
                                    MessageBox.Show("O Contrato/Matrícula/Serviço informado(a) já está cadastrado(a) para o Número do Documento informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtContratoMatServ.Text = null;
                                    txtContratoMatServ.Select();
                                }
                            }
                            else
                            {
                                if (bllContasPagar.Sel_Conta_Ndoc_ContMatServ(txtNDocumento.Text.Trim(), txtContratoMatServ.Text.Trim()) == true)
                                {
                                    MessageBox.Show("O Contrato/Matrícula/Serviço informado(a) já está cadastrado(a) para o Número do Documento informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtContratoMatServ.Text = null;
                                    txtContratoMatServ.Select();
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
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPalavraChave.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPalavraChave.");
                        }
                        txtContratoMatServ.Text = null;
                    }
                }
            }
            txtContratoMatServ.BackColor = Color.White;
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtOcorrenciaParcela.Select();
            }
        }

        private void dtConta_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, emitente, código, código de barras, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void txtParcela_Leave(object sender, EventArgs e)
        {
            if (txtOcorrenciaParcela.Text == "0" || txtOcorrenciaParcela.Text == "00" || txtOcorrenciaParcela.Text == "000" || txtOcorrenciaParcela.Text == "0000")
            {
                MessageBox.Show("O campo [ Parcela ] não pode ser 0.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtOcorrenciaParcela.Text = null;
            }
            //
            if (txtOcorrenciaParcela.Text.Contains("'") || txtOcorrenciaParcela.Text.Contains(";") || txtOcorrenciaParcela.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtOcorrenciaParcela.Text = null;
                txtOcorrenciaParcela.Select();
            }
            txtOcorrenciaParcela.BackColor = Color.White;
        }

        private void txtParcela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtNDocumento.Select();
            }
        }

        private void txtParcela_Enter(object sender, EventArgs e)
        {
            txtOcorrenciaParcela.BackColor = Color.LightBlue;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera, multiplica e exclui registros.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Clicando no botão [ Adicionar ] parcelas > você estará adicionando as parcelas da conta selecionada na tabela.\n\n5 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ].\n\n6 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtConta_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtConta.DefaultCellStyle.Font = new Font(dtConta.Font, FontStyle.Bold);

                dtConta.Columns[0].HeaderText = "Código";
                dtConta.Columns[1].HeaderText = "Descrição";
                dtConta.Columns[2].HeaderText = "Contrato/Mátricula/Serviço";
                dtConta.Columns[3].HeaderText = "Parcela(s)";
                dtConta.Columns[4].HeaderText = "Nº do Documento";
                dtConta.Columns[5].HeaderText = "Código de Barras";
                dtConta.Columns[6].HeaderText = "Data de Emissão";
                dtConta.Columns[7].HeaderText = "Data de Vencimento";
                dtConta.Columns[8].HeaderText = "Tipo do Documento";
                dtConta.Columns[9].HeaderText = "Tipo de Emitente";
                dtConta.Columns[10].HeaderText = "Cód. do Emitente";
                dtConta.Columns[11].HeaderText = "Nome/Razão Social do Emitente";
                dtConta.Columns[12].HeaderText = "Cód. do Grupo";
                dtConta.Columns[13].HeaderText = "Descrição do Grupo";
                dtConta.Columns[14].HeaderText = "Cód. do Sub-Grupo";
                dtConta.Columns[15].HeaderText = "Descrição do Sub-Grupo";
                dtConta.Columns[16].HeaderText = "Valor (R$)";
                dtConta.Columns[17].Visible = false;
                dtConta.Columns[18].HeaderText = "Desconto Até";
                dtConta.Columns[19].HeaderText = "Desconto (%)";
                dtConta.Columns[20].HeaderText = "Valor do Desconto (R$)";
                dtConta.Columns[21].HeaderText = "Multa (%)";
                dtConta.Columns[22].HeaderText = "Valor da Multa (R$)";
                dtConta.Columns[23].HeaderText = "Juros (a.m) (%)";
                dtConta.Columns[24].Visible = false;
                dtConta.Columns[25].Visible = false;
                dtConta.Columns[26].Visible = false;
                dtConta.Columns[27].Visible = false;
                dtConta.Columns[28].Visible = false;
                dtConta.Columns[29].Visible = false;
                dtConta.Columns[30].HeaderText = "Observações";
                dtConta.Columns[31].HeaderText = "Palavra-Chave";
                dtConta.Columns[32].Visible = false;
                dtConta.Columns[33].Visible = false;
                dtConta.Columns[34].Visible = false;
                dtConta.Columns[35].Visible = false;
                dtConta.Columns[36].Visible = false;
                dtConta.Columns[37].Visible = false;
                dtConta.Columns[38].HeaderText = "Cód. da Ent. Bancária";
                dtConta.Columns[39].HeaderText = "Descrição da Entidade Bancária";
                dtConta.Columns[40].Visible = false;
                dtConta.Columns[41].HeaderText = "Descontar Caixa";


                dtConta.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[39].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[39].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[41].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtConta.Columns[41].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtConta.Columns[0].Width = 95;
                dtConta.Columns[1].Width = 425;
                dtConta.Columns[2].Width = 168;
                dtConta.Columns[3].Width = 115;
                dtConta.Columns[4].Width = 142;
                dtConta.Columns[5].Width = 500;
                dtConta.Columns[6].Width = 150;
                dtConta.Columns[7].Width = 150;
                dtConta.Columns[8].Width = 200;
                dtConta.Columns[9].Width = 150;
                dtConta.Columns[10].Width = 125;
                dtConta.Columns[11].Width = 325;
                dtConta.Columns[12].Width = 105;
                dtConta.Columns[13].Width = 325;
                dtConta.Columns[14].Width = 125;
                dtConta.Columns[15].Width = 325;
                dtConta.Columns[16].Width = 162;
                dtConta.Columns[18].Width = 150;
                dtConta.Columns[19].Width = 150;
                dtConta.Columns[20].Width = 150;
                dtConta.Columns[21].Width = 150;
                dtConta.Columns[22].Width = 150;
                dtConta.Columns[23].Width = 150;
                dtConta.Columns[30].Width = 500;
                dtConta.Columns[31].Width = 150;
                dtConta.Columns[38].Width = 150;
                dtConta.Columns[39].Width = 325;
                dtConta.Columns[41].Width = 125;

                lblRegistros.Text = "Registros: " + dtConta.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtProd.");
                }
                dtConta.DataSource = null;
            }
        }

        private void dtConta_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void cbbTipoDocumento_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoDocumento_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoEmitente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbTipoEmitente.SelectedIndex == 1)
                {
                    using (FrmPesqCliente Pesq = new FrmPesqCliente(5, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Pesq.ShowDialog() == DialogResult.OK)
                        {
                            cbbEmitente.Items.Clear();
                            //
                            if (bllContasPagar.Sel_Cliente_Cont() == null)
                            {
                                cbbEmitente.Text = null;
                            }
                            else
                            {
                                cbbEmitente.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                                {
                                    cbbEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        cbbEmitente.Text = bllContasPagar._Emitente_PesqContaPagar_Tabela;
                        bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
                        cbbEmitente.Select();
                    }
                }
                else if (cbbTipoEmitente.SelectedIndex == 2)
                {
                    using (FrmPesqFornecedor Pesq = new FrmPesqFornecedor(3, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Pesq.ShowDialog() == DialogResult.OK)
                        {
                            cbbEmitente.Items.Clear();
                            //
                            if (bllContasPagar.Sel_Forn_Cont() == null)
                            {
                                cbbEmitente.Text = null;
                            }
                            else
                            {
                                cbbEmitente.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Forn_Cont().Rows)
                                {
                                    cbbEmitente.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        cbbEmitente.Text = bllContasPagar._Emitente_PesqContaPagar_Tabela;
                        bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
                        cbbEmitente.Select();
                    }
                }
                else if (cbbTipoEmitente.SelectedIndex == 3)
                {
                    using (FrmPesqFuncionario Pesq = new FrmPesqFuncionario(3, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Pesq.ShowDialog() == DialogResult.OK)
                        {
                            cbbEmitente.Items.Clear();
                            //
                            if (bllContasPagar.Sel_Func_Cont() == null)
                            {
                                cbbEmitente.Text = null;
                            }
                            else
                            {
                                cbbEmitente.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Func_Cont().Rows)
                                {
                                    cbbEmitente.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        cbbEmitente.Text = bllContasPagar._Emitente_PesqContaPagar_Tabela;
                        bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
                        cbbEmitente.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbEmitente.Text = null;
                bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
            }
            pEnabled.Enabled = true;
        }

        private void cbbEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEmitente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoEmitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbEmitente.Select();
            }
        }

        private void cbbEmitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipoDocumento.Select();
            }
        }

        private void cbbTipoEmitente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                try
                {
                    cbbEmitente.Items.Clear();
                    if (cbbTipoEmitente.SelectedIndex == 0)
                    {
                        cbbEmitente.Enabled = false;
                        cbbEmitente.Text = null;
                        btnProcurar.Enabled = false;
                    }
                    else if (cbbTipoEmitente.SelectedIndex == 1)
                    {
                        if (bllContasPagar.Sel_Cliente_Cont() == null)
                        {
                            cbbEmitente.Enabled = false;
                            cbbEmitente.Text = null;
                        }
                        else
                        {
                            cbbEmitente.Enabled = true;
                            btnProcurar.Enabled = true;
                            cbbEmitente.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                            {
                                cbbEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                    }
                    else if (cbbTipoEmitente.SelectedIndex == 2)
                    {
                        if (bllContasPagar.Sel_Forn_Cont() == null)
                        {
                            cbbEmitente.Enabled = false;
                            cbbEmitente.Text = null;
                        }
                        else
                        {
                            cbbEmitente.Enabled = true;
                            btnProcurar.Enabled = true;
                            cbbEmitente.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_Forn_Cont().Rows)
                            {
                                cbbEmitente.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                    }
                    else if (cbbTipoEmitente.SelectedIndex == 3)
                    {
                        if (bllContasPagar.Sel_Func_Cont() == null)
                        {
                            cbbEmitente.Enabled = false;
                            cbbEmitente.Text = null;
                        }
                        else
                        {
                            cbbEmitente.Enabled = true;
                            btnProcurar.Enabled = true;
                            cbbEmitente.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_Func_Cont().Rows)
                            {
                                cbbEmitente.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbTipoEmitente.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbTipoEmitente.");
                    }
                    cbbEmitente.Items.Clear();
                    cbbEmitente.Text = null;
                    cbbTipoEmitente.Text = null;
                }
            }
        }

        private void txtValorMulta_Enter(object sender, EventArgs e)
        {
            txtValorMulta.BackColor = Color.LightBlue;
        }

        private void txtValorMulta_Leave(object sender, EventArgs e)
        {
            if (txtValorMulta.Text.Contains("'") || txtValorMulta.Text.Contains(";") || txtValorMulta.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtValorMulta.Text = null;
                txtValorMulta.Select();
            }
            else
            {
                if (txtValorMulta.Text != "")
                {
                    try
                    {
                        txtValorMulta.Text = Convert.ToDecimal(txtValorMulta.Text).ToString("n2", new CultureInfo("pt-BR"));

                        if (txtValorDocumento.Text != "")
                        {
                            txtMulta.Text = Convert.ToDecimal(bllContasPagar.Calculo_ValorMulta(txtValorDocumento.Text, txtValorMulta.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtMulta.Text = "0,00";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorMulta.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtValorMulta.");
                        }
                        txtValorMulta.Text = null;
                    }
                }
            }
            txtValorMulta.BackColor = Color.White;
        }

        private void txtpBarra_Enter(object sender, EventArgs e)
        {
            txtpBarra.BackColor = Color.LightBlue;
        }

        private void txtpBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        txtpBarra.Text = null;
                        txtpBarra.Select();
                    }
                    else
                    {
                        if (txtpBarra.Text != "")
                        {
                            if (bllContasPagar.Sel_Conta_Codigo_Barra(txtpBarra.Text) == null)
                            {
                                dtConta.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtConta.DataSource = bllContasPagar.Sel_Conta_Codigo_Barra(txtpBarra.Text);
                                dtConta.Select();
                            }
                        }
                        else
                        {
                            btnPesquisar.Select();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keyPress da caixa de texto txtpBarra.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keyPress da caixa de texto txtpBarra.");
                    }
                    txtpBarra.Text = null;
                }
            }
        }

        private void txtpBarra_Leave(object sender, EventArgs e)
        {
            if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpBarra.Text = null;
                txtpBarra.Select();
            }
            txtpBarra.BackColor = Color.White;
        }

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
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
                if (txtDesconto.Text != "")
                {
                    try
                    {
                        txtDesconto.Text = Convert.ToDecimal(txtDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));

                        if (txtValorDocumento.Text != "")
                        {
                            txtValorDesconto.Text = Convert.ToDecimal(bllContasPagar.Calculo_Desconto(txtValorDocumento.Text, txtDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtValorDesconto.Text = "0,00";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDesconto.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDesconto.");
                        }
                        txtDesconto.Text = null;
                    }
                }
            }
            txtDesconto.BackColor = Color.White;
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
                if (txtValorDesconto.Text != "")
                {
                    try
                    {
                        txtValorDesconto.Text = Convert.ToDecimal(txtValorDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));

                        if (txtValorDocumento.Text != "")
                        {
                            txtDesconto.Text = Convert.ToDecimal(bllContasPagar.Calculo_ValorDesconto(txtValorDocumento.Text, txtValorDesconto.Text)).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            txtDesconto.Text = "0,00";
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
            }
            txtValorDesconto.BackColor = Color.White;
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbpTipoEmitente.SelectedIndex == 1)
                {
                    using (FrmPesqCliente Pesq = new FrmPesqCliente(5, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Pesq.ShowDialog() == DialogResult.OK)
                        {
                            cbbpEmitente.Items.Clear();
                            //
                            if (bllContasPagar.Sel_Cliente_Cont() == null)
                            {
                                cbbpEmitente.Text = null;
                            }
                            else
                            {
                                cbbpEmitente.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                                {
                                    cbbpEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        cbbpEmitente.Text = bllContasPagar._Emitente_PesqContaPagar_Tabela;
                        bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
                        cbbpEmitente.Select();
                    }
                }
                else if (cbbpTipoEmitente.SelectedIndex == 2)
                {
                    using (FrmPesqFornecedor Pesq = new FrmPesqFornecedor(3, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Pesq.ShowDialog() == DialogResult.OK)
                        {
                            cbbpEmitente.Items.Clear();
                            //
                            if (bllContasPagar.Sel_Forn_Cont() == null)
                            {
                                cbbpEmitente.Text = null;
                            }
                            else
                            {
                                cbbpEmitente.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Forn_Cont().Rows)
                                {
                                    cbbpEmitente.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        cbbpEmitente.Text = bllContasPagar._Emitente_PesqContaPagar_Tabela;
                        bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
                        cbbpEmitente.Select();
                    }
                }
                else if (cbbpTipoEmitente.SelectedIndex == 3)
                {
                    using (FrmPesqFuncionario Pesq = new FrmPesqFuncionario(3, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Pesq.ShowDialog() == DialogResult.OK)
                        {
                            cbbpEmitente.Items.Clear();
                            //
                            if (bllContasPagar.Sel_Func_Cont() == null)
                            {
                                cbbpEmitente.Text = null;
                            }
                            else
                            {
                                cbbpEmitente.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Func_Cont().Rows)
                                {
                                    cbbpEmitente.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                        }
                        cbbpEmitente.Text = bllContasPagar._Emitente_PesqContaPagar_Tabela;
                        bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
                        cbbpEmitente.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbpEmitente.Text = null;
                bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
            }
            pEnabled.Enabled = true;
        }

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoEmitente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoEmitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbpEmitente.Enabled != false)
                {
                    cbbpEmitente.Select();
                }
                else
                {
                    btnPesquisar.Select();
                }
            }
        }

        private void cbbpTipoEmitente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpEmitente.Items.Clear();
                if (cbbpTipoEmitente.SelectedIndex == 0)
                {
                    cbbpEmitente.Text = null;
                    cbbpEmitente.Enabled = false;
                    btnpProcurar.Enabled = false;
                }
                else if (cbbpTipoEmitente.SelectedIndex == 1)
                {
                    if (bllContasPagar.Sel_Cliente_Cont() == null)
                    {
                        cbbpEmitente.Text = null;
                        cbbpEmitente.Enabled = false;
                    }
                    else
                    {
                        cbbpEmitente.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpEmitente.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                        {
                            cbbpEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbpTipoEmitente.SelectedIndex == 2)
                {
                    if (bllContasPagar.Sel_Forn_Cont() == null)
                    {
                        cbbpEmitente.Text = null;
                        cbbpEmitente.Enabled = false;
                    }
                    else
                    {
                        cbbpEmitente.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpEmitente.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Forn_Cont().Rows)
                        {
                            cbbpEmitente.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbpTipoEmitente.SelectedIndex == 3)
                {
                    if (bllContasPagar.Sel_Func_Cont() == null)
                    {
                        cbbpEmitente.Text = null;
                        cbbpEmitente.Enabled = false;
                    }
                    else
                    {
                        cbbpEmitente.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpEmitente.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Func_Cont().Rows)
                        {
                            cbbpEmitente.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbpTipoEmitente.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbpTipoEmitente.");
                }
                cbbpEmitente.Items.Clear();
                cbbpEmitente.Text = null;
                cbbpTipoEmitente.Text = null;
            }
        }

        private void cbbpEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpEmitente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpEmitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtDesconto_Enter(object sender, EventArgs e)
        {
            txtDesconto.BackColor = Color.LightBlue;
        }

        private void txtValorDesconto_Enter(object sender, EventArgs e)
        {
            txtValorDesconto.BackColor = Color.LightBlue;
        }

        private void txtNDocumento_Enter(object sender, EventArgs e)
        {
            txtNDocumento.BackColor = Color.LightBlue;
        }

        private void txtNDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbTipoEmitente.Select();
            }
        }

        private void txtNDocumento_Leave(object sender, EventArgs e)
        {
            if (txtNDocumento.Text.Contains("'") || txtNDocumento.Text.Contains(";") || txtNDocumento.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNDocumento.Text = null;
                txtNDocumento.Select();
            }
            else
            {
                if (_Inserir_Atualizar == true)
                {
                    try
                    {
                        if (txtNDocumento.Text != "")
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllContasPagar.Sel_Conta_Ndoc_ContMatServ_Alt(txtCodigo.Text, txtNDocumento.Text.Trim(), txtContratoMatServ.Text.Trim()) == true)
                                {
                                    MessageBox.Show("O Número do Documento informado já está cadastrado para o(a) Contrato/Matrícula/Serviço informado(a).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtNDocumento.Text = null;
                                    txtNDocumento.Select();
                                }
                            }
                            else
                            {
                                if (bllContasPagar.Sel_Conta_Ndoc_ContMatServ(txtNDocumento.Text.Trim(), txtContratoMatServ.Text.Trim()) == true)
                                {
                                    MessageBox.Show("O Número do Documento informado já está cadastrado para o(a) Contrato/Matrícula/Serviço informado(a).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtNDocumento.Text = null;
                                    txtNDocumento.Select();
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
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPalavraChave.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPalavraChave.");
                        }
                        txtNDocumento.Text = null;
                        txtNDocumento.Select();
                    }
                }
            }
            txtNDocumento.BackColor = Color.White;
        }

        private void txtValorDocumento_TextChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                mtxtDataDesconto.Text = "";
                txtDesconto.Text = "";
                txtValorDesconto.Text = "";
                txtMulta.Text = "";
                txtValorMulta.Text = "";
                txtMora.Text = "";
                if (txtValorDocumento.Text == "" || txtValorDocumento.Text == "0,00" || txtValorDocumento.Text == "0" || txtValorDocumento.Text == "0,0")
                {
                    lblDescontoData.Enabled = false;
                    mtxtDataDesconto.Enabled = false;
                    txtDesconto.Enabled = false;
                    lblDesconto.Enabled = false;
                    lblValorDesconto.Enabled = false;
                    txtValorDesconto.Enabled = false;
                    lblMulta.Enabled = false;
                    txtMulta.Enabled = false;
                    lblValorMulta.Enabled = false;
                    txtValorMulta.Enabled = false;
                    lblMora.Enabled = false;
                    txtMora.Enabled = false;
                    lblPorcentagem1.Enabled = false;
                    lblPorcentagem2.Enabled = false;
                    lblPorcentagem3.Enabled = false;
                    btnSelecionarData3.Enabled = false;
                }
                else
                {
                    lblDescontoData.Enabled = true;
                    mtxtDataDesconto.Enabled = true;
                    txtDesconto.Enabled = true;
                    lblDesconto.Enabled = true;
                    lblValorDesconto.Enabled = true;
                    txtValorDesconto.Enabled = true;
                    lblMulta.Enabled = true;
                    txtMulta.Enabled = true;
                    lblValorMulta.Enabled = true;
                    txtValorMulta.Enabled = true;
                    lblMora.Enabled = true;
                    txtMora.Enabled = true;
                    lblPorcentagem1.Enabled = true;
                    lblPorcentagem2.Enabled = true;
                    lblPorcentagem3.Enabled = true;
                    btnSelecionarData3.Enabled = true;
                }
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
                txtValorDesconto.Select();
            }
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
                txtMulta.Select();
            }
        }

        private void FrmCadContasPagar_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllContasPagar._FrmCadContasPagar_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContasPagar foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContasPagar foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadContasPagar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadContasPagar.");
                }
            }
        }

        private void txtMora_Enter(object sender, EventArgs e)
        {
            txtMora.BackColor = Color.LightBlue;
        }

        private void txtMora_Leave(object sender, EventArgs e)
        {
            if (txtMora.Text.Contains("'") || txtMora.Text.Contains(";") || txtMora.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtMora.Text = null;
                txtMora.Select();
            }
            else
            {
                if (txtMora.Text != "")
                {
                    try
                    {
                        txtMora.Text = Convert.ToDecimal(txtMora.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtMulta.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtMulta.");
                        }
                        txtMora.Text = null;
                    }
                }
            }
            txtMora.BackColor = Color.White;
        }

        private void txtMora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMora.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                tabcCadastro.SelectedTab = tabcCadastro2;
            }
        }

        private void btnSelecionarData3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoDocumento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData2_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(1))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataEmissao.Text = bllContasPagar._Data_DatePicker1;
                    mtxtDataVencimento.Text = bllContasPagar._Data_DatePicker2;
                    bllContasPagar._Data_DatePicker1 = null;
                    bllContasPagar._Data_DatePicker2 = null;
                    mtxtDataVencimento.Select();
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSelecionarData3_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(0))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataDesconto.Text = bllContasPagar._Data_DatePicker1;
                    bllContasPagar._Data_DatePicker1 = null;
                    mtxtDataDesconto.Select();
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnAviso_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAviso_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAviso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Atenção, o aplicativo SISTEMA SEVEN se propõe a auxiliar o usuário como simples referência e verificação de cálculos diversos. Este serviço não deve ser utilizado em substituição a um profissional habilitado. O usuário que utiliza este serviço o faz por sua conta e risco, e aceita que o aplicativo não tem qualquer responsabilidade por danos de qualquer natureza resultantes desta utilização.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;

        }

        private void cbbGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbSubGrupo.Enabled != false)
                {
                    cbbSubGrupo.Select();
                }
                else
                {
                    tabcCadastro.SelectedTab = tabcCadastro2;
                }
            }
        }

        private void rtxtObs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void rtxtObs_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + rtxtObs.Text.Length + "/200";
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
            rtxtObs.SelectionStart = 0;
            rtxtObs.SelectionLength = rtxtObs.Text.Length;
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Contains("'") || rtxtObs.Text.Contains(";") || rtxtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                rtxtObs.Text = null;
                rtxtObs.Select();
            }
            rtxtObs.BackColor = Color.White;
        }

        private void cbbSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSubGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSubGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                try
                {
                    if (cbbGrupo.Text != "")
                    {
                        string[] items = cbbGrupo.SelectedItem.ToString().Split('—');
                        cbbSubGrupo.Items.Clear();
                        if (bllContasPagar.Sel_SubGrupo_Conta_Pagar(items[0]) == null)
                        {
                            cbbSubGrupo.Text = null;
                            cbbSubGrupo.Enabled = false;
                            btnProcurar2.Enabled = false;
                            lblSubGrupo.Enabled = false;
                            lblAsteriscoSubGrupo.Enabled = false;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_SubGrupo_Conta_Pagar(items[0]).Rows)
                            {
                                cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbSubGrupo.Enabled = true;
                                btnProcurar2.Enabled = true;
                                lblSubGrupo.Enabled = true;
                                lblAsteriscoSubGrupo.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        cbbSubGrupo.Items.Clear();
                        cbbSubGrupo.Text = null;
                        cbbSubGrupo.Enabled = false;
                        btnProcurar2.Enabled = false;
                        lblSubGrupo.Enabled = false;
                        lblAsteriscoSubGrupo.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do botão cbbGrupo.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do botão cbbGrupo.");
                    }
                    cbbGrupo.Text = null;
                    cbbSubGrupo.Text = null;
                }
            }
        }

        private void btnProcurarGrupo_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(2))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbGrupo.Items.Clear();
                        if (bllContasPagar.Sel_Grupo_Conta_Pagar() == null)
                        {
                            cbbGrupo.Text = null;
                            cbbSubGrupo.Items.Clear();
                            cbbSubGrupo.Enabled = false;
                            cbbSubGrupo.Text = null;
                            btnProcurar2.Enabled = false;
                            lblSubGrupo.Enabled = false;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_Grupo_Conta_Pagar().Rows)
                            {
                                cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbSubGrupo.Enabled = true;
                                btnProcurar2.Enabled = true;
                                lblSubGrupo.Enabled = true;
                            }
                        }
                        cbbGrupo.Text = bllContasPagar._Grupo_PesqGrupo_Tabela;
                        bllContasPagar._Grupo_PesqGrupo_Tabela = null;
                        cbbGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        cbbGrupo.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurar2_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbGrupo.Text != "")
                {
                    string[] items = cbbGrupo.Text.Split('—');

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 1))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbSubGrupo.Items.Clear();
                            if (bllContasPagar.Sel_SubGrupo_Conta_Pagar(items[0]) == null)
                            {
                                cbbSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_SubGrupo_Conta_Pagar(items[0]).Rows)
                                {
                                    cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            cbbSubGrupo.Text = bllContasPagar._SubGrupo_PesqSubGrupo_Tabela;
                            bllContasPagar._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbSubGrupo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar2.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar2.");
                }
                cbbSubGrupo.Text = null;
            }
            pEnabled.Enabled = true;
        }

        private void cbbSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorDocumento.Select();
            }
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tabControl1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tabcCadastro2_Enter(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                txtPalavraChave.Select();
            }
        }

        private void tabpCadastro1_Enter(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                txtDescricao.Select();
            }
        }

        private void mtxtDataEmissao_KeyDown(object sender, KeyEventArgs e)
        {
            mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataEmissao.Text == "" & e.KeyCode == Keys.Insert)
            {
                mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void mtxtDataVencimento_KeyDown(object sender, KeyEventArgs e)
        {
            mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataVencimento.Text == "" & e.KeyCode == Keys.Insert)
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void mtxtDataDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            mtxtDataDesconto.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataDesconto.Text == "" & e.KeyCode == Keys.Insert)
            {
                mtxtDataDesconto.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataDesconto.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void txtValorDaConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorDocumento.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (mtxtDataDesconto.Enabled == true)
                {
                    mtxtDataDesconto.Select();
                }
                else
                {
                    cbbTipoEmitente.Select();
                }
            }
        }

        private void rbtnNDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNDocumento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNContratoMatriculaServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNContratoMatriculaServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNDocumento_CheckedChanged(object sender, EventArgs e)
        {
            cbbpEmitente.Visible = false;
            cbbpTipoEmitente.Visible = false;
            btnpProcurar.Visible = false;
            txtpBarra.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = true;
            txtpCodigo.MaxLength = 10;
            lblPesquisar.Location = new Point(523, 21);
            lblPesquisar.Text = "Digite o Nº do Documento:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void cbbEntBanc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEntBanc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbEntBanc_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEntBanc_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEntBanc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEntBanc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEntBanc_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqEntidadeBancaria Ent = new FrmPesqEntidadeBancaria(0))
            {
                if (Ent.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbEntBanc.Items.Clear();
                        if (bllContasPagar.Sel_Entidade_Bancaria_Conta_Pagar() == null)
                        {
                            cbbEntBanc.Text = null;
                        }
                        else
                        {
                            cbbEntBanc.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_Entidade_Bancaria_Conta_Pagar().Rows)
                            {
                                cbbEntBanc.Items.Add((dr["id_ent_bancaria"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbEntBanc.Text = bllContasPagar._Entidade_Bancaria_PesqEntidadeBancaria_Tabela;
                        bllContasPagar._Entidade_Bancaria_PesqEntidadeBancaria_Tabela = null;
                        cbbEntBanc.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                        }
                        cbbEntBanc.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void dtConta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 38 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void txtValorMulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorMulta.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtMora.Select();
            }
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCodBarra.Select();
            }
        }

        private void txtPalavraChave_Enter(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtPalavraChave.Text != "")
            {
                try
                {
                    if (txtPalavraChave.Text.Contains(";") || txtPalavraChave.Text.Contains("'") || txtPalavraChave.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        txtPalavraChave.Text = null;
                        txtPalavraChave.Select();
                    }
                    else
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllContasPagar.Sel_Conta_Palavra_Chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
                            }
                            else
                            {
                                if (bllContasPagar.Sel_Conta_Palavra_Chave(txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPalavraChave.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtPalavraChave.");
                    }
                    txtPalavraChave.Text = null;
                }
            }
            txtPalavraChave.BackColor = Color.White;
        }
    }
}
