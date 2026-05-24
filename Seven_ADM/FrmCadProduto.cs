using ACBrLib.NCM;
using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadProduto : Form
    {
        public FrmCadProduto(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
        }

        private bool _Comando_Atualizar = false;
        private bool _Contem_Imagem = false;
        private bool _Inserir_Atualizar = false;
        private string _ComboboxGrupo_Valor = null;
        private string _ComboboxSubGrupo_Valor = null;
        private string _ComboboxMarca_Valor = null;
        private string _ComboboxLocalizacao_Valor = null;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Formulario;
        private string _Excecao_NCM;
        private bool _Visao_Geral_Prod = false;

        private void FrmImagem_Load(object sender, EventArgs e)
        {
            try
            {
                bllProduto._FrmCadProduto_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadProduto iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadProduto iniciado.");
                }
                //
                rbtnDescricao.Checked = true;
                //
                if (_Formulario == 1)
                {
                    btnExcluir.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadProduto.");
                }
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtPalavraChave.Text = null;
            txtDescricao.Text = null;
            cbbUM.Text = null;
            cbbMarca.Text = null;
            cbbGrupo.Text = null;
            cbbSubGrupo.Text = null;
            txtBarra.Text = null;
            txtPreco.Text = null;
            txtObs.Text = null;
            txtReferencia.Text = null;
            cbbLocalizacao.Text = null;
            txtEstoqueMin.Text = null;
            txtEstoqueMax.Text = null;
            txtSaldoAtual.Text = null;
            txtAdicionado.Text = null;
            txtAcrescimo.Text = null;
            txtDesconto.Text = null;
            txtAliqICMS.Text = null;
            txtNCM.Text = null;
            txtCEST.Text = null;
            cbbCSOSN.Text = null;
            cbbCSTA.Text = null;
            cbbCSTB.Text = null;
            chkbAlertarEstoque.Checked = false;
            chkbDestEstoqueBaixo.Checked = false;
            _Excecao_NCM = null;
            txtEx.Text = null;
            mtxtDataCadastro.Text = null;
            mtxtDataUltVenda.Text = null;
            mtxtHorarioultVenda.Text = null;
            txtTempVendeu.Text = null;
            txtFrequenciaVenda.Text = null;
            txtQtdeVendida.Text = null;
            txtQtdeMedio.Text = null;
            txtTotalVendido.Text = null;
            mtxtDataUltEntrada.Text = null;
            mtxtHoraUltEntrada.Text = null;
            txtQtdeUltEntrada.Text = null;
            txtFrequenciaEntrada.Text = null;
            mtxtDataUltAltSistema.Text = null;
            mtxtHorarioUltAltSistema.Text = null;
            cbbSituacao.Text = null;
        }

        public void Ativar()
        {
            lblPalavraChave.Enabled = true;
            txtPalavraChave.Enabled = true;
            lblNome_Desc.Enabled = true;
            txtDescricao.Enabled = true;
            lblTipo.Enabled = true;
            cbbUM.Enabled = true;
            pcibInterrogacao3.Enabled = true;
            btnProcurar4.Enabled = true;
            lblLocalizacao.Enabled = true;
            cbbLocalizacao.Enabled = true;
            txtObs.Enabled = true;
            lblObservacao.Enabled = true;
            grbBox4.Enabled = true;
            grbBox5.Enabled = true;
            lblBarras.Enabled = true;
            btnProcurar4.Enabled = true;
            txtBarra.Enabled = true;
            lblPreco.Enabled = true;
            txtPreco.Enabled = true;
            lblReferencia.Enabled = true;
            txtReferencia.Enabled = true;
            lblMarca.Enabled = true;
            cbbMarca.Enabled = true;
            btnProcurar3.Enabled = true;
            lblAsterisco1.Enabled = true;
            lblAsterisco2.Enabled = true;
            lblAsterisco3.Enabled = true;
            lblAsterisco4.Enabled = true;
            lblAsterisco5.Enabled = true;
            txtAcrescimo.Enabled = true;
            txtDesconto.Enabled = true;
            lblAcrescimo.Enabled = true;
            lblDesconto.Enabled = true;
            label3.Enabled = true;
            label5.Enabled = true;
            lblAsterisco5.Enabled = true;
            lblQtdeCar.Enabled = true;
            btnCodigoBarra.Enabled = true;
            grbICMS.Enabled = true;
            lblNCM.Enabled = true;
            txtNCM.Enabled = true;
            btnPesquisarNCM.Enabled = true;
            btnVerificarValidade.Enabled = true;
            lblCEST.Enabled = true;
            txtCEST.Enabled = true;
            grbIBSCBS.Enabled = true;
            grbCBS.Enabled = true;
            lblEx.Enabled = true;
            txtEx.Enabled = true;
            cbbSituacao.Enabled = true;
            lblAsterisco6.Enabled = true;
            lblSituacao.Enabled = true;
        }

        private void ModoPesquisa()
        {
            txtAcrescimo.Enabled = false;
            txtDesconto.Enabled = false;
            lblAcrescimo.Enabled = false;
            lblDesconto.Enabled = false;
            label3.Enabled = false;
            lblAsterisco5.Enabled = false;
            label5.Enabled = false;
            lblAsterisco1.Enabled = false;
            lblAsterisco2.Enabled = false;
            lblAsterisco3.Enabled = false;
            lblAsterisco4.Enabled = false;
            lblAsterisco5.Enabled = false;
            txtCodigo.Enabled = false;
            lblCodigo.Enabled = false;
            lblPalavraChave.Enabled = false;
            txtPalavraChave.Enabled = false;
            lblNome_Desc.Enabled = false;
            txtDescricao.Enabled = false;
            lblTipo.Enabled = false;
            cbbUM.Enabled = false;
            btnProcurar4.Enabled = true;
            lblLocalizacao.Enabled = false;
            btnProcurar4.Enabled = false;
            cbbLocalizacao.Enabled = false;
            pcibInterrogacao3.Enabled = false;
            grbBox4.Enabled = false;
            grbBox5.Enabled = false;
            lblBarras.Enabled = false;
            txtBarra.Enabled = false;
            lblPreco.Enabled = false;
            txtPreco.Enabled = false;
            lblObservacao.Enabled = false;
            txtObs.Enabled = false;
            lblReferencia.Enabled = false;
            txtReferencia.Enabled = false;
            lblMarca.Enabled = false;
            cbbMarca.Enabled = false;
            btnProcurar3.Enabled = false;
            grbBox1.Enabled = true;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            lblQtdeCar.Enabled = false;
            grbICMS.Enabled = false;
            btnCodigoBarra.Enabled = false;
            if (dtProd.DataSource != null)
            {
                dtProd.Enabled = true;
                dtProd.Select();
            }
            lblNCM.Enabled = false;
            txtNCM.Enabled = false;
            btnPesquisarNCM.Enabled = false;
            btnVerificarValidade.Enabled = false;
            lblCEST.Enabled = false;
            txtCEST.Enabled = false;
            grbIBSCBS.Enabled = false;
            grbCBS.Enabled = false;
            lblEx.Enabled = false;
            txtEx.Enabled = false;
            cbbSituacao.Enabled = false;
            lblAsterisco6.Enabled = false;
            lblSituacao.Enabled = false;
        }

        private void rbtnNome_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = true;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(337, 21);
            lblPesquisar.Text = "Digite a descrição:";
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = true;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(567, 21);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnBarra_CheckedChanged(object sender, EventArgs e)
        {
            txtpBarra.MaxLength = 60;
            txtpBarra.CharacterCasing = CharacterCasing.Normal;
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = true;
            lblPesquisar.Location = new Point(415, 21);
            lblPesquisar.Text = "Digite o código de barras:";
            txtpBarra.Text = null;
            txtpBarra.Select();
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUM.Select();
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescricao.Text = null;
                txtDescricao.Select();
            }
            txtDescricao.BackColor = Color.White;
        }

        private void cbbEMB_UND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbLocalizacao.Select();
            }
        }

        private void cbbGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbSubGrupo.Enabled == false)
                {
                    txtBarra.Select();
                }
                else
                {
                    cbbSubGrupo.Select();
                }
            }
        }

        private void txtBarra_Enter(object sender, EventArgs e)
        {
            txtBarra.BackColor = Color.LightBlue;
        }

        private void txtBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAcrescimo.Select();
            }
        }

        private void txtBarra_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBarra.Text != "")
                {
                    if (txtBarra.Text.Contains(";") || txtBarra.Text.Contains("'") || txtBarra.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        txtBarra.Text = null;
                        txtBarra.Select();
                    }
                    else
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllProduto.Val_Prod_Barra_Alt(txtCodigo.Text, txtBarra.Text) == true)
                                {
                                    DataRow dr = bllProduto.Sel_Prod_Barra(txtBarra.Text, "").Rows[0];
                                    //
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.\n\nProduto:\n[ " + dr["id_produto"].ToString() + " - " + dr["descricao"].ToString() + " - " + Convert.ToDecimal(dr["preco"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + " ]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtBarra.Text = null;
                                    txtBarra.Select();
                                }
                                else if (bllMultiploCodigoBarra.Val_Mult_Barra(txtBarra.Text) == true)
                                {
                                    DataRow dr = bllProduto.Sel_Prod_Barra(txtBarra.Text, "").Rows[0];
                                    //
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.\n\nProduto:\n[ " + dr["id_produto"].ToString() + " - " + dr["descricao"].ToString() + " - " + Convert.ToDecimal(dr["preco"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + " ]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtBarra.Text = null;
                                    txtBarra.Select();
                                }
                            }
                            else
                            {
                                if (bllProduto.Val_Prod_Barra(txtBarra.Text) == true)
                                {
                                    DataRow dr = bllProduto.Sel_Prod_Barra(txtBarra.Text, "").Rows[0];
                                    //
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.\n\nProduto:\n[ " + dr["id_produto"].ToString() + " - " + dr["descricao"].ToString() + " - " + Convert.ToDecimal(dr["preco"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + " ]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtBarra.Text = null;
                                    txtBarra.Select();
                                }
                                else if (bllMultiploCodigoBarra.Val_Mult_Barra(txtBarra.Text) == true)
                                {
                                    DataRow dr = bllProduto.Sel_Prod_Barra(txtBarra.Text, "").Rows[0];
                                    //
                                    MessageBox.Show("O Código de Barras informado já está cadastrado.\n\nProduto:\n[ " + dr["id_produto"].ToString() + " - " + dr["descricao"].ToString() + " - " + Convert.ToDecimal(dr["preco"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + " ]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtBarra.Text = null;
                                    txtBarra.Select();
                                }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtBarra.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtBarra.");
                }
                txtBarra.Text = null;
            }
            txtBarra.BackColor = Color.White;
        }

        private void txtPreco_Enter(object sender, EventArgs e)
        {
            txtPreco.BackColor = Color.LightBlue;
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
                cbbMarca.Select();
            }
        }

        private void txtPreco_Leave(object sender, EventArgs e)
        {
            if (txtPreco.Text != "")
            {
                if (txtPreco.Text.Contains("'") || txtPreco.Text.Contains(";") || txtPreco.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtPreco.Text = null;
                    txtPreco.Select();
                }
                else
                {
                    try
                    {
                        txtPreco.Text = Convert.ToDecimal(txtPreco.Text).ToString("n2", new CultureInfo("pt-BR"));
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
            txtPreco.BackColor = Color.White;
        }

        private void FrmCadProduto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtPalavraChave_Enter(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
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
                                if (bllProduto.Val_Prod_Palavra_Chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
                            }
                            else
                            {
                                if (bllProduto.Val_Prod_Palavra_Chave(txtPalavraChave.Text) == true)
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAcrescimo.Text.Trim() == "")
                {
                    txtAcrescimo.Text = "0,00";
                }
                //
                if (txtDesconto.Text.Trim() == "")
                {
                    txtDesconto.Text = "0,00";
                }
                //
                _ComboboxGrupo_Valor = cbbGrupo.Text;
                _ComboboxSubGrupo_Valor = cbbSubGrupo.Text;
                _ComboboxMarca_Valor = cbbMarca.Text;
                _ComboboxLocalizacao_Valor = cbbLocalizacao.Text;
                //
                if (cbbMarca.Text != "")
                {
                    cbbMarca.Items.Clear();
                    if (bllProduto.Sel_Marca_Prod() == null)
                    {
                        cbbMarca.Text = null;
                    }
                    else
                    {
                        cbbMarca.Items.Add("");
                        foreach (DataRow dr in bllProduto.Sel_Marca_Prod().Rows)
                        {
                            cbbMarca.Items.Add((dr["id_marca"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    if (bllProduto.Sel_ComboboxMarca_Valor_A_Alterar(_ComboboxMarca_Valor) != null)
                    {
                        foreach (DataRow dr in bllProduto.Sel_ComboboxMarca_Valor_A_Alterar(_ComboboxMarca_Valor).Rows)
                        {
                            cbbMarca.Text = dr["id_marca"].ToString() + "—" + dr["descricao"].ToString();
                            _ComboboxMarca_Valor = null;
                        }
                    }
                    else
                    {
                        _ComboboxMarca_Valor = null;
                        cbbMarca.Text = null;
                    }
                }
                //
                if (cbbLocalizacao.Text != "")
                {
                    cbbLocalizacao.Items.Clear();
                    if (bllProduto.Sel_Localizacao_Prod() == null)
                    {
                        cbbLocalizacao.Text = null;
                    }
                    else
                    {
                        cbbLocalizacao.Items.Add("");
                        foreach (DataRow dr in bllProduto.Sel_Localizacao_Prod().Rows)
                        {
                            cbbLocalizacao.Items.Add((dr["id_localizacao"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    if (bllProduto.Sel_ComboboxLocalizacao_Valor_A_Alterar(_ComboboxLocalizacao_Valor) != null)
                    {
                        foreach (DataRow dr in bllProduto.Sel_ComboboxLocalizacao_Valor_A_Alterar(_ComboboxLocalizacao_Valor).Rows)
                        {
                            cbbLocalizacao.Text = dr["id_localizacao"].ToString() + "—" + dr["descricao"].ToString();
                            _ComboboxLocalizacao_Valor = null;
                        }
                    }
                    else
                    {
                        _ComboboxLocalizacao_Valor = null;
                        cbbLocalizacao.Text = null;
                    }
                }
                //
                if (cbbGrupo.Text != "")
                {
                    cbbGrupo.Items.Clear();
                    if (bllProduto.Sel_Grupo_Prod() == null)
                    {
                        cbbGrupo.Text = null;
                    }
                    else
                    {
                        cbbGrupo.Items.Add("");
                        foreach (DataRow dr in bllProduto.Sel_Grupo_Prod().Rows)
                        {
                            cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    if (bllProduto.Sel_ComboboxGrupo_Valor_A_Alterar(_ComboboxGrupo_Valor) != null)
                    {
                        foreach (DataRow dr in bllProduto.Sel_ComboboxGrupo_Valor_A_Alterar(_ComboboxGrupo_Valor).Rows)
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
                }
                //
                if (cbbSubGrupo.Enabled != false & cbbGrupo.Text != "")
                {
                    cbbSubGrupo.Items.Clear();
                    if (bllProduto.Sel_SubGrupo_Prod(cbbGrupo.Text) == null)
                    {
                        cbbSubGrupo.Text = null;
                    }
                    else
                    {
                        cbbSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllProduto.Sel_SubGrupo_Prod(cbbGrupo.Text).Rows)
                        {
                            cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    cbbSubGrupo.Text = _ComboboxSubGrupo_Valor;

                    if (cbbSubGrupo.Text != "")
                    {
                        if (bllProduto.Sel_ComboboxSubGrupo_Valor_A_Alterar_Produto(_ComboboxSubGrupo_Valor, cbbGrupo.Text) != null)
                        {
                            foreach (DataRow dr in bllProduto.Sel_ComboboxSubGrupo_Valor_A_Alterar_Produto(_ComboboxSubGrupo_Valor, cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Text = dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString();
                            }
                            _ComboboxSubGrupo_Valor = null;

                        }
                        else
                        {
                            _ComboboxSubGrupo_Valor = null;
                            cbbSubGrupo.Text = null;
                        }
                    }
                }
                else
                {
                    cbbSubGrupo.Items.Clear();
                    cbbSubGrupo.Text = null;
                    _ComboboxSubGrupo_Valor = null;
                    _ComboboxGrupo_Valor = null;
                }
                //
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (txtDescricao.Text.Trim() == "" || cbbUM.Text == "" || cbbGrupo.Text == "" || cbbSubGrupo.Text == "" || txtPreco.Text.Trim() == "" || txtAliqICMS.Text.Trim() == "" || cbbCSTB.Text == "" || cbbCSOSN.Text == "" || cbbCSTAIBSCBS.Text == "" || cbbCSTBIBSCBS.Text == "" || cbbCClassTrib.Text == "" || txtAliqIBSMun.Text == "" || txtAliqIBSEstadual.Text == "" || txtAliqCBS.Text == "" || cbbSituacao.Text == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Descrição ], [ UM ], [ Grupo ], [ Sub-Grupo ], [ Preço ], [ ICMS ], [ IBS e CBS ] e [ Situação ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtPalavraChave.Select();
                    }
                    else if (txtPreco.Text.Trim() == "0,00" || txtPreco.Text.Trim() == "0")
                    {
                        MessageBox.Show("Valor informado no campo Preço inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtPreco.Select();
                    }
                    else
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllProduto.Sel_Produto_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                dtProd.DataSource = null;
                                rbtnDescricao.Checked = true;
                                ModoPesquisa();
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                lblLegendaImagem.Visible = false;
                                _Inserir_Atualizar = false;
                                _Contem_Imagem = false;
                                _Comando_Atualizar = false;
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllProduto._Url_Imagem = null;
                                bllEntradasProdutos._Data_Entrada = null;
                                bllEntradasProdutos._Fornecedor = null;
                                bllEntradasProdutos._Quantidade = null;
                            }
                            else
                            {
                                bllProduto.Alterar(txtCodigo.Text, txtPalavraChave.Text.Trim(), txtDescricao.Text.Trim(), cbbUM.Text, cbbMarca.Text, cbbGrupo.Text, cbbSubGrupo.Text, txtBarra.Text.Trim(), txtPreco.Text.Trim(), txtReferencia.Text.Trim(), cbbLocalizacao.Text, txtObs.Text.Trim(), txtEstoqueMin.Text.Trim(), txtEstoqueMax.Text.Trim(), txtAdicionado.Text, txtAcrescimo.Text.Trim(), txtDesconto.Text.Trim(), chkbAlertarEstoque.Checked, chkbDestEstoqueBaixo.Checked, _Cod_PDV_Computador, txtNCM.Text.Trim(), txtCEST.Text.Trim(), cbbCSTA.Text + cbbCSTB.Text, txtAliqICMS.Text.Trim(), cbbCSOSN.Text.Trim(), _Excecao_NCM, cbbCSTAIBSCBS.Text + cbbCSTBIBSCBS.Text, cbbCClassTrib.Text, txtAliqIBSMun.Text, txtAliqIBSEstadual.Text, txtAliqCBS.Text, cbbSituacao.Text);
                                //
                                if (_Contem_Imagem == true)
                                {
                                    if (bllProduto._Url_Imagem != null)
                                    {
                                        bllProduto.Alterar_Imagem_Produto(txtCodigo.Text, bllProduto._Url_Imagem);
                                    }
                                }
                                else
                                {
                                    bllProduto.Alterar_Imagem_Produto(txtCodigo.Text, bllProduto._Url_Imagem);
                                }
                                //
                                if (bllEntradasProdutos._Quantidade != null & bllEntradasProdutos._Data_Entrada != null)
                                {
                                    bllEntradasProdutos.Salvar(txtCodigo.Text, txtDescricao.Text.Trim(), bllEntradasProdutos._Data_Entrada, bllEntradasProdutos._Fornecedor, bllEntradasProdutos._Quantidade);
                                    bllRegistroAtividades.Salvar("SALVOU UMA ENTRADA", "ENTRADA DE PRODUTOS", bllEntradasProdutos.Sel_Ent_Ultimo_Cod_Adicionado(), _Usuario, _Cod_PDV_Computador);
                                }
                                //
                                dtProd.DataSource = bllProduto.Sel_Prod_A_Alt(txtCodigo.Text);
                                //
                                pcibImagem.Image = null;
                                pcibImagem.ImageLocation = null;
                                bllProduto._Url_Imagem = null;
                                bllEntradasProdutos._Data_Entrada = null;
                                bllEntradasProdutos._Fornecedor = null;
                                bllEntradasProdutos._Quantidade = null;
                                //
                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM PRODUTO", "PRODUTOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Produto alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Produto alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                //
                                _Comando_Atualizar = false;
                                //
                                ModoPesquisa();
                                //
                                _Inserir_Atualizar = false;
                                //
                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                //
                                if (_Formulario == 1)
                                {
                                    bllProduto._Cod_Produto_Cadastro = txtCodigo.Text;
                                    //
                                    this.DialogResult = DialogResult.OK;
                                }
                                //
                                tabcCadastro.SelectedTab = tabpCadastro1;
                                //
                                Ativar_Visao_Geral();
                            }
                        }
                        else
                        {
                            bllProduto.Salvar(txtPalavraChave.Text.Trim(), txtDescricao.Text.Trim(), cbbUM.Text, cbbMarca.Text, cbbGrupo.Text, cbbSubGrupo.Text, txtBarra.Text, txtPreco.Text.Trim(), txtReferencia.Text.Trim(), cbbLocalizacao.Text, txtObs.Text.Trim(), bllProduto._Url_Imagem, txtEstoqueMin.Text.Trim(), txtEstoqueMax.Text.Trim(), txtAdicionado.Text, txtAcrescimo.Text.Trim(), txtDesconto.Text.Trim(), chkbAlertarEstoque.Checked, chkbDestEstoqueBaixo.Checked, txtNCM.Text.Trim(), txtCEST.Text.Trim(), cbbCSTA.Text + cbbCSTB.Text, txtAliqICMS.Text, cbbCSOSN.Text.Trim(), false, _Excecao_NCM, cbbCSTAIBSCBS.Text + cbbCSTBIBSCBS.Text, cbbCClassTrib.Text, txtAliqIBSMun.Text, txtAliqIBSEstadual.Text, txtAliqCBS.Text, cbbSituacao.Text);
                            //
                            dtProd.DataSource = bllProduto.Sel_Prod_A_Salvar();
                            //
                            int codigo = bllProduto.Sel_Prod_Ultimo_Cod_Adicionado();
                            //
                            if (bllMultiploCodigoBarra.Sel_Multiplo_Cod_Barra_Todos_Temp() != null)
                            {
                                bllMultiploCodigoBarra.Salvar_Items_Cod_Barras_Temp(codigo);
                            }
                            //
                            bllRegistroAtividades.Salvar("SALVOU UM PRODUTO", "PRODUTOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //
                            if (bllEntradasProdutos._Quantidade != null & bllEntradasProdutos._Data_Entrada != null)
                            {
                                bllEntradasProdutos.Salvar(txtCodigo.Text, txtDescricao.Text.Trim(), bllEntradasProdutos._Data_Entrada, bllEntradasProdutos._Fornecedor, bllEntradasProdutos._Quantidade);
                                bllRegistroAtividades.Salvar("SALVOU UMA ENTRADA", "ENTRADA DE PRODUTOS", bllEntradasProdutos.Sel_Ent_Ultimo_Cod_Adicionado(), _Usuario, _Cod_PDV_Computador);
                            }
                            //
                            pcibImagem.Image = null;
                            pcibImagem.ImageLocation = null;
                            bllProduto._Url_Imagem = null;
                            bllEntradasProdutos._Data_Entrada = null;
                            bllEntradasProdutos._Fornecedor = null;
                            bllEntradasProdutos._Quantidade = null;
                            bllMultiploCodigoBarra.Excluir_Items_Codigo_Barra_Atual();
                            //
                            txtAdicionado.Text = "0,00";
                            //
                            _Comando_Atualizar = false;
                          
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Produto cadastrado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Produto cadastrado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            ModoPesquisa();
                            //
                            _Inserir_Atualizar = false;
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            if (_Formulario == 1)
                            {
                                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                //
                                bllProduto._Cod_Produto_Cadastro = SelectedRow.Cells[0].Value.ToString();
                                //
                                this.DialogResult = DialogResult.OK;
                            }
                            //
                            tabcCadastro.SelectedTab = tabpCadastro1;
                            //
                            Ativar_Visao_Geral();
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    txtPalavraChave.Select();
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
                dtProd.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                lblLegendaImagem.Visible = false;
                _Inserir_Atualizar = false;
                _Contem_Imagem = false;
                _Comando_Atualizar = false;
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllProduto._Url_Imagem = null;
                bllEntradasProdutos._Data_Entrada = null;
                bllEntradasProdutos._Fornecedor = null;
                bllEntradasProdutos._Quantidade = null;
                bllMultiploCodigoBarra.Excluir_Items_Codigo_Barra_Atual();
                tabcCadastro.SelectedTab = tabpCadastro1;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Descricao(txtpDescricao.Text, "") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Descricao(txtpDescricao.Text, "");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Codigo(txtpCodigo.Text, "") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Codigo(txtpCodigo.Text, "");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Palavra_Chave(txtpPalavraChave.Text, "") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Palavra_Chave(txtpPalavraChave.Text, "");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnBarra.Checked == true)
                {
                    if (txtpBarra.Text != "")
                    {
                        if (bllProduto.Sel_Prod_Barra(txtpBarra.Text, "") == null)
                        {
                            dtProd.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtProd.DataSource = bllProduto.Sel_Prod_Barra(txtpBarra.Text, "");
                            dtProd.Select();
                        }
                    }
                }
                else if (rbtnGrupo.Checked == true)
                {
                    if (cbbpGrupo.Text != "")
                    {
                        if (cbbpGrupo.Text != "" && cbbpSubGrupo.Text == "")
                        {
                            if (bllProduto.Sel_Prod_Grupo(cbbpGrupo.Text, "") == null)
                            {
                                dtProd.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                Limpar();
                            }
                            else
                            {
                                dtProd.DataSource = bllProduto.Sel_Prod_Grupo(cbbpGrupo.Text, "");
                                dtProd.Select();
                            }
                        }
                        else
                        {
                            if (bllProduto.Sel_Prod_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "") == null)
                            {
                                dtProd.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                Limpar();
                            }
                            else
                            {
                                dtProd.DataSource = bllProduto.Sel_Prod_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "");
                                dtProd.Select();
                            }
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllProduto.Sel_Prod_Todos("") == null)
                    {
                        dtProd.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtProd.DataSource = bllProduto.Sel_Prod_Todos("");
                        dtProd.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou produto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou produto.");
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
                dtProd.DataSource = null;
                txtpDescricao.Select();
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Contem_Imagem = false;
                _Comando_Atualizar = false;
            }
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpDescricao_Leave(object sender, EventArgs e)
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

        private void txtpBarra_Enter(object sender, EventArgs e)
        {
            txtpBarra.BackColor = Color.LightBlue;
        }

        private void txtpBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbtnBarra.Checked == true)
                {
                    if (txtpBarra.Text == "")
                    {
                        btnPesquisar.Select();
                    }
                    else if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        txtpBarra.Text = null;
                        txtpBarra.Select();
                    }
                    else
                    {
                        try
                        {
                            if (bllProduto.Sel_Prod_Barra(txtpBarra.Text, "") == null)
                            {
                                dtProd.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtProd.DataSource = bllProduto.Sel_Prod_Barra(txtpBarra.Text, "");
                                dtProd.Select();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.DialogResult = DialogResult.None;
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keypress da caixa de texto txtpBarra.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keypress da caixa de texto txtpBarra.");
                            }
                            txtpBarra.Text = null;
                            txtpBarra.Select();
                        }
                    }
                }
                else
                {
                    btnPesquisar.Select();
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

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
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

        private void cbbpGrupoFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void Desativar_Visao_Geral() 
        {
            lblDataCadastro.Enabled = false;
            mtxtDataCadastro.Enabled = false;
            lblDataHorarioUltCompra.Enabled = false;
            mtxtDataUltVenda.Enabled = false;
            mtxtHorarioultVenda.Enabled = false;
            lblTempoVenda.Enabled = false;
            lblHa.Enabled = false;
            txtTempVendeu.Enabled = false;
            lblDias.Enabled = false;
            lblQuantidadeVendida.Enabled = false;
            txtQtdeVendida.Enabled = false;
            lblQtdeMedia.Enabled = false;
            txtQtdeMedio.Enabled = false;
            lblTotalVendido.Enabled = false;
            txtTotalVendido.Enabled = false;
            lblFrequenciaVenda.Enabled = false;
            txtFrequenciaVenda.Enabled = false;
            lblDataUltEntrada.Enabled = false;
            mtxtDataUltEntrada.Enabled = false;
            mtxtHoraUltEntrada.Enabled = false;
            lblQtdeUltEntrada.Enabled = false;
            txtQtdeUltEntrada.Enabled = false;
            lblUltAlteracaoCadastro.Enabled = false;
            mtxtDataUltAltSistema.Enabled = false;
            mtxtHorarioUltAltSistema.Enabled = false;
            txtFrequenciaEntrada.Enabled = false;
            lblFrequenciaEntrada.Enabled = false;
            btnGerarPDF.Enabled = false;
        }

        private void Ativar_Visao_Geral()
        {
            lblDataCadastro.Enabled = true;
            mtxtDataCadastro.Enabled = true;
            lblDataHorarioUltCompra.Enabled = true;
            mtxtDataUltVenda.Enabled = true;
            mtxtHorarioultVenda.Enabled = true;
            lblTempoVenda.Enabled = true;
            lblHa.Enabled = true;
            txtTempVendeu.Enabled = true;
            lblDias.Enabled = true;
            lblQuantidadeVendida.Enabled = true;
            txtQtdeVendida.Enabled = true;
            lblQtdeMedia.Enabled = true;
            txtQtdeMedio.Enabled = true;
            lblTotalVendido.Enabled = true;
            txtTotalVendido.Enabled = true;
            lblFrequenciaVenda.Enabled = true;
            txtFrequenciaVenda.Enabled = true;
            lblDataUltEntrada.Enabled = true;
            mtxtDataUltEntrada.Enabled = true;
            mtxtHoraUltEntrada.Enabled = true;
            lblQtdeUltEntrada.Enabled = true;
            txtQtdeUltEntrada.Enabled = true;
            lblUltAlteracaoCadastro.Enabled = true;
            mtxtDataUltAltSistema.Enabled = true;
            mtxtHorarioUltAltSistema.Enabled = true;
            txtFrequenciaEntrada.Enabled = true;
            lblFrequenciaEntrada.Enabled = true;
            btnGerarPDF.Enabled = true;
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtProd.Enabled = false;
            grbBox1.Enabled = false;
            Ativar();
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Visible = true;
            btnCadastrarValidade.Enabled = false;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            _Inserir_Atualizar = true;
            _Comando_Atualizar = false;
            Limpar();
            pcibAjudaFoto.Enabled = true;
            pcibImagem.Image = null;
            pcibImagem.ImageLocation = null;
            lblLegendaImagem.Text = "Adicionar imagem.";
            txtDescricao.Select();
            lblLegendaImagem.Visible = true;
            cbbSubGrupo.Enabled = false;
            btnProcurar2.Enabled = false;
            cbbSituacao.Text = "ATIVO";
            txtAdicionado.Text = "0,00";
            txtSaldoAtual.Text = "0,00";
            cbbCSTA.Text = "0";
            cbbCSTB.Text = "00";
            txtAliqICMS.Text = "20,50";
            cbbCSOSN.Text = "102";
            cbbCSTAIBSCBS.Text = "0";
            cbbCSTBIBSCBS.Text = "00";
            cbbCClassTrib.Text = "00001";
            txtAliqIBSMun.Text = "0,00";
            txtAliqIBSEstadual.Text = "0,10";
            txtAliqCBS.Text = "0,90";
            tabcCadastro.SelectedTab = tabpCadastro1;
           
            //
            try
            {
                cbbGrupo.Items.Clear();
                if (bllProduto.Sel_Grupo_Prod() == null)
                {
                    cbbGrupo.Text = null;
                }
                else
                {
                    cbbGrupo.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Grupo_Prod().Rows)
                    {
                        cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbMarca.Items.Clear();
                if (bllProduto.Sel_Marca_Prod() == null)
                {
                    cbbMarca.Text = null;
                }
                else
                {
                    cbbMarca.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Marca_Prod().Rows)
                    {
                        cbbMarca.Items.Add((dr["id_marca"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbLocalizacao.Items.Clear();
                if (bllProduto.Sel_Localizacao_Prod() == null)
                {
                    cbbLocalizacao.Text = null;
                }
                else
                {
                    cbbLocalizacao.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Localizacao_Prod().Rows)
                    {
                        cbbLocalizacao.Items.Add((dr["id_localizacao"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbGrupo.Text = "1—PRODUTOS NO GERAL";
                cbbSubGrupo.Text = "1—GERAL";
                cbbUM.Text = "UN";
                //
                Desativar_Visao_Geral();
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
                dtProd.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                lblLegendaImagem.Visible = false;
                _Inserir_Atualizar = false;
                _Contem_Imagem = false;
                _Comando_Atualizar = false;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllProduto.Sel_Produto_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtProd.Select();
                }
                else
                {
                    dtProd.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    dtProd.Enabled = false;
                    grbBox1.Enabled = false;
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnCadastrarValidade.Enabled = false;
                    btnSalvar.Enabled = true;
                    Ativar();
                    pcibAjudaFoto.Enabled = true;
                    if (_Contem_Imagem == false)
                    {
                        lblLegendaImagem.Text = "Adicionar imagem.";
                        pcibImagem.Image = null;
                        pcibImagem.ImageLocation = null;
                    }
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                    txtDescricao.Select();
                    _Inserir_Atualizar = true;
                    _Comando_Atualizar = true;
                    txtSaldoAtual.Text = bllProduto.Sel_Saldo_Atual_Produto(txtCodigo.Text).ToString("n2", new CultureInfo("pt-BR"));
                    _ComboboxGrupo_Valor = cbbGrupo.Text;
                    _ComboboxLocalizacao_Valor = cbbLocalizacao.Text;
                    _ComboboxSubGrupo_Valor = cbbSubGrupo.Text;
                    _ComboboxMarca_Valor = cbbMarca.Text;
                    //
                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                    //
                    cbbMarca.Items.Clear();
                    if (bllProduto.Sel_Marca_Prod() == null)
                    {
                        cbbMarca.Text = null;
                    }
                    else
                    {
                        cbbMarca.Items.Add("");
                        foreach (DataRow dr in bllProduto.Sel_Marca_Prod().Rows)
                        {
                            cbbMarca.Items.Add((dr["id_marca"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    //
                    if (SelectedRow.Cells[4].Value.ToString() != "0")
                    {
                        if (bllProduto.Sel_ComboboxMarca_Valor_A_Alterar(_ComboboxMarca_Valor) != null)
                        {
                            foreach (DataRow dr in bllProduto.Sel_ComboboxMarca_Valor_A_Alterar(_ComboboxMarca_Valor).Rows)
                            {
                                cbbMarca.Text = dr["id_marca"].ToString() + "—" + dr["descricao"].ToString();
                            }
                            _ComboboxMarca_Valor = null;
                        }
                        else
                        {
                            _ComboboxMarca_Valor = null;
                            cbbMarca.Text = null;
                        }
                    }
                    //                
                    cbbLocalizacao.Items.Clear();
                    if (bllProduto.Sel_Localizacao_Prod() == null)
                    {
                        cbbLocalizacao.Text = null;
                    }
                    else
                    {
                        cbbLocalizacao.Items.Add("");
                        foreach (DataRow dr in bllProduto.Sel_Localizacao_Prod().Rows)
                        {
                            cbbLocalizacao.Items.Add((dr["id_localizacao"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    //
                    if (SelectedRow.Cells[12].Value.ToString() != "0")
                    {
                        if (bllProduto.Sel_ComboboxLocalizacao_Valor_A_Alterar(_ComboboxLocalizacao_Valor) != null)
                        {
                            foreach (DataRow dr in bllProduto.Sel_ComboboxLocalizacao_Valor_A_Alterar(_ComboboxLocalizacao_Valor).Rows)
                            {
                                cbbLocalizacao.Text = dr["id_localizacao"].ToString() + "—" + dr["descricao"].ToString();
                            }
                            _ComboboxLocalizacao_Valor = null;
                        }
                        else
                        {
                            _ComboboxLocalizacao_Valor = null;
                            cbbLocalizacao.Text = null;
                        }
                    }
                    //
                    if (cbbGrupo.Text != "")
                    {
                        cbbGrupo.Items.Clear();
                        if (bllProduto.Sel_Grupo_Prod() == null)
                        {
                            cbbGrupo.Text = null;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_Grupo_Prod().Rows)
                            {
                                cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                    }
                    //
                    if (bllProduto.Sel_ComboboxGrupo_Valor_A_Alterar(_ComboboxGrupo_Valor) != null)
                    {
                        foreach (DataRow dr in bllProduto.Sel_ComboboxGrupo_Valor_A_Alterar(_ComboboxGrupo_Valor).Rows)
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

                    if (cbbSubGrupo.Enabled != false & cbbGrupo.Text != "")
                    {
                        cbbSubGrupo.Items.Clear();
                        if (bllProduto.Sel_SubGrupo_Prod(cbbGrupo.Text) == null)
                        {
                            cbbSubGrupo.Text = null;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_SubGrupo_Prod(cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }

                        if (bllProduto.Sel_ComboboxSubGrupo_Valor_A_Alterar_Produto(_ComboboxSubGrupo_Valor, cbbGrupo.Text) != null)
                        {
                            foreach (DataRow dr in bllProduto.Sel_ComboboxSubGrupo_Valor_A_Alterar_Produto(_ComboboxSubGrupo_Valor, cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Text = dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString();
                            }
                            _ComboboxSubGrupo_Valor = null;
                        }
                        else
                        {
                            _ComboboxSubGrupo_Valor = null;
                            cbbSubGrupo.Text = null;
                        }
                    }
                    else
                    {
                        cbbSubGrupo.Items.Clear();
                        cbbSubGrupo.Text = null;
                        _ComboboxSubGrupo_Valor = null;
                        _ComboboxGrupo_Valor = null;
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
                dtProd.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                lblLegendaImagem.Visible = false;
                _Inserir_Atualizar = false;
                _Contem_Imagem = false;
                _Comando_Atualizar = false;
            }
        }

        private void cbbEMB_UND_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEMB_UND_DropDownClosed(object sender, EventArgs e)
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSair_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnBarra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnBarra_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpGrupoFornecedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupoFornecedor_DropDownClosed(object sender, EventArgs e)
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

        private void rbtnGrupo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpGrupo.Items.Clear();
                cbbpSubGrupo.Items.Clear();
                if (bllProduto.Sel_Grupo_Prod() == null)
                {
                    cbbpGrupo.Text = null;
                }
                else
                {
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllProduto.Sel_Grupo_Prod().Rows)
                    {
                        cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do combo cbbpGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do combo cbbpGrupo.");
                }
                cbbpGrupo.Text = null;
            }
            //
            cbbpSubGrupo.Text = null;
            btnpProcurar.Visible = true;
            btnpProcurarSub1.Visible = true;
            cbbpSubGrupo.Visible = true;
            cbbpSubGrupo.Enabled = false;
            btnpProcurarSub1.Enabled = false;
            lblSubGrupo1.Visible = true;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(366, 21);
            lblPesquisar.Text = "Escolha o grupo:";
            cbbpGrupo.Text = null;
            cbbpSubGrupo.Text = null;
            cbbpGrupo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(619, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCadastrarValidade.Enabled = true;
                Limpar();
            }
            else
            {
                if (dtProd.DataSource == null)
                {
                    Limpar();
                    pcibImagem.Image = null;
                    pcibImagem.ImageLocation = null;
                    lblLegendaImagem.Visible = false;
                    btnCadastrarValidade.Enabled = false;
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnCadastrarValidade.Enabled = true;
                }
            }
            _Inserir_Atualizar = false;
            pcibImagem.Image = null;
            pcibImagem.ImageLocation = null;
            bllProduto._Url_Imagem = null;
            bllProduto._Preco_Venda = null;
            bllEntradasProdutos._Data_Entrada = null;
            bllEntradasProdutos._Fornecedor = null;
            bllEntradasProdutos._Quantidade = null;
            bllMultiploCodigoBarra.Excluir_Items_Codigo_Barra_Atual();
            ModoPesquisa();
            Ativar_Visao_Geral();
            tabcCadastro.SelectedTab = tabpCadastro1;
        }

        private void dtProd_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                //
                dtProd.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                //
                if (SelectedRow.DefaultCellStyle.ForeColor == Color.Black)
                {
                    dtProd.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else if (SelectedRow.DefaultCellStyle.ForeColor == Color.Red)
                {
                    dtProd.DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                //
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                cbbUM.Text = SelectedRow.Cells[2].Value.ToString();
                dtProd.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[3].DefaultCellStyle.Format = "n2";
                txtPreco.Text = Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR"));
                cbbMarca.Items.Clear();
                if (SelectedRow.Cells[4].Value.ToString() != "0")
                {
                    cbbMarca.Items.Add(SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[5].Value.ToString());
                    cbbMarca.Text = SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[5].Value.ToString();
                }
                cbbGrupo.Items.Clear();
                cbbGrupo.Items.Add(SelectedRow.Cells[6].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString());
                cbbGrupo.Text = SelectedRow.Cells[6].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString();
                cbbSubGrupo.Items.Clear();
                cbbSubGrupo.Items.Add(SelectedRow.Cells[8].Value.ToString() + "—" + SelectedRow.Cells[9].Value.ToString());
                cbbSubGrupo.Text = SelectedRow.Cells[8].Value.ToString() + "—" + SelectedRow.Cells[9].Value.ToString();
                txtBarra.Text = SelectedRow.Cells[10].Value.ToString();
                txtReferencia.Text = SelectedRow.Cells[11].Value.ToString();
                if (SelectedRow.Cells[12].Value.ToString() != "0")
                {
                    cbbLocalizacao.Items.Add(SelectedRow.Cells[12].Value.ToString() + "—" + SelectedRow.Cells[13].Value.ToString());
                    cbbLocalizacao.Text = SelectedRow.Cells[12].Value.ToString() + "—" + SelectedRow.Cells[13].Value.ToString();
                }
                txtEstoqueMin.Text = Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[15].DefaultCellStyle.Format = "n2";
                txtEstoqueMax.Text = Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[16].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[16].DefaultCellStyle.Format = "n2";
                txtSaldoAtual.Text = Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[17].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[17].DefaultCellStyle.Format = "n2";
                txtObs.Text = SelectedRow.Cells[18].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[19].Value.ToString();
                txtAdicionado.Text = "0,00";
                txtAcrescimo.Text = Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[21].DefaultCellStyle.Format = "n2";
                txtDesconto.Text = Convert.ToDecimal(SelectedRow.Cells[22].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[22].DefaultCellStyle.Format = "n2";
                //
                /*
                if ((rbtnCodigo.Checked == true || rbtnBarra.Checked == true || rbtnPalavraChave.Checked == true) & _Inserir_Atualizar == false)
                {
                    txtNCM.Text = SelectedRow.Cells[28].Value.ToString();
                    if (SelectedRow.Cells[26].Value.ToString() != "")
                    {
                        cbbCSTA.Text = SelectedRow.Cells[29].Value.ToString().Remove(1);
                        cbbCSTB.Text = SelectedRow.Cells[29].Value.ToString().Remove(0, 1);
                    }
                    //
                    txtAliqICMS.Text = Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR"));
                    dtProd.Columns[30].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                    dtProd.Columns[30].DefaultCellStyle.Format = "n2";
                    cbbCSOSN.Text = SelectedRow.Cells[31].Value.ToString();
                    txtCEST.Text = SelectedRow.Cells[32].Value.ToString();
                }
                else
                {
                */
                txtNCM.Text = SelectedRow.Cells[25].Value.ToString();
                if (SelectedRow.Cells[26].Value.ToString() != "")
                {
                    cbbCSTA.Text = SelectedRow.Cells[26].Value.ToString().Remove(1);
                    cbbCSTB.Text = SelectedRow.Cells[26].Value.ToString().Remove(0, 1);
                }
                //
                txtAliqICMS.Text = Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[27].DefaultCellStyle.Format = "n2";
                cbbCSOSN.Text = SelectedRow.Cells[28].Value.ToString();
                txtCEST.Text = SelectedRow.Cells[29].Value.ToString();
                //
                //if ((rbtnCodigo.Checked == true || rbtnPalavraChave.Checked == true || rbtnBarra.Checked == true) & _Inserir_Atualizar == false)
                //{
                _Excecao_NCM = SelectedRow.Cells[33].Value.ToString();
                txtEx.Text = SelectedRow.Cells[33].Value.ToString();
                if (SelectedRow.Cells[34].Value.ToString() != "")
                {
                    cbbCSTAIBSCBS.Text = SelectedRow.Cells[34].Value.ToString().Remove(1);
                    cbbCSTBIBSCBS.Text = SelectedRow.Cells[34].Value.ToString().Remove(0, 1);
                }
                cbbCClassTrib.Text = SelectedRow.Cells[35].Value.ToString();
                txtAliqIBSMun.Text = Convert.ToDecimal(SelectedRow.Cells[36].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[36].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[36].DefaultCellStyle.Format = "n2";
                txtAliqIBSEstadual.Text = Convert.ToDecimal(SelectedRow.Cells[37].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[37].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[37].DefaultCellStyle.Format = "n2";
                txtAliqCBS.Text = Convert.ToDecimal(SelectedRow.Cells[38].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtProd.Columns[38].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtProd.Columns[38].DefaultCellStyle.Format = "n2";
                cbbSituacao.Text = SelectedRow.Cells[39].Value.ToString();
                /*
                    }
                    else
                    {
                        _Excecao_NCM = SelectedRow.Cells[30].Value.ToString();
                        txtEx.Text = SelectedRow.Cells[30].Value.ToString();
                        if (SelectedRow.Cells[31].Value.ToString() != "")
                        {
                            cbbCSTAIBSCBS.Text = SelectedRow.Cells[31].Value.ToString().Remove(1);
                            cbbCSTBIBSCBS.Text = SelectedRow.Cells[31].Value.ToString().Remove(0, 1);
                        }
                        cbbCClassTrib.Text = SelectedRow.Cells[32].Value.ToString();
                        txtAliqIBSMun.Text = Convert.ToDecimal(SelectedRow.Cells[33].Value).ToString("n2", new CultureInfo("pt-BR"));
                        dtProd.Columns[33].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                        dtProd.Columns[33].DefaultCellStyle.Format = "n2";
                        txtAliqIBSEstadual.Text = Convert.ToDecimal(SelectedRow.Cells[34].Value).ToString("n2", new CultureInfo("pt-BR"));
                        dtProd.Columns[34].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                        dtProd.Columns[34].DefaultCellStyle.Format = "n2";
                        txtAliqCBS.Text = Convert.ToDecimal(SelectedRow.Cells[35].Value).ToString("n2", new CultureInfo("pt-BR"));
                        dtProd.Columns[35].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                        dtProd.Columns[35].DefaultCellStyle.Format = "n2";
                    }
                */
                //
                if (Convert.ToByte(SelectedRow.Cells[23].Value) == 1)
                {
                    chkbAlertarEstoque.Checked = true;
                }
                else
                {
                    chkbAlertarEstoque.Checked = false;
                }
                //
                if (Convert.ToByte(SelectedRow.Cells[24].Value) == 1)
                {
                    chkbDestEstoqueBaixo.Checked = true;
                }
                else
                {
                    chkbDestEstoqueBaixo.Checked = false;
                }
                //
                if (SelectedRow.Cells[14].Value != DBNull.Value)
                {
                    byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
                    //
                    using (MemoryStream ms = new MemoryStream(imagemBytes))
                    {
                        Image imagem = Image.FromStream(ms);
                        pcibImagem.Image = imagem;
                        pcibImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    //
                    _Contem_Imagem = true;
                    lblLegendaImagem.Visible = false;
                }
                else
                {
                    lblLegendaImagem.Visible = true;
                    _Contem_Imagem = false;
                    lblLegendaImagem.Text = "Sem imagem para este registro.";
                    pcibImagem.Image = null;
                    pcibImagem.ImageLocation = null;
                }
                //
                mtxtDataCadastro.Text = SelectedRow.Cells[20].Value.ToString();
                //
                if (_Visao_Geral_Prod == true)
                {
                    Executar_Visao_Geral();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtProd.");
                }
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                lblLegendaImagem.Visible = false;
                _Inserir_Atualizar = false;
                _Contem_Imagem = false;
                _Comando_Atualizar = false;
            }
        }

        private void Executar_Visao_Geral()
        {
            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
            //
            DataRow dr;
            //
            if (bllProduto.Sel_Prod_Data_Hora_Ult_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllProduto.Sel_Prod_Data_Hora_Ult_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr["data"] != null & dr["data"] != DBNull.Value)
                {
                    mtxtDataUltVenda.Text = dr["data"].ToString().Remove(10);
                    //
                    txtTempVendeu.Text = (Convert.ToDateTime(DateTime.Now.ToShortDateString()) - Convert.ToDateTime(mtxtDataUltVenda.Text)).TotalDays.ToString();
                }
                else
                {
                    mtxtDataUltVenda.Text = null;
                    //
                    txtTempVendeu.Text = "0";
                }
                //
                if (dr["hora"] != null & dr["hora"] != DBNull.Value)
                {
                    mtxtHorarioultVenda.Text = dr["hora"].ToString();
                }
                else
                {
                    mtxtHorarioultVenda.Text = null;
                }

            }
            else
            {
                mtxtDataUltVenda.Text = null;
                //
                mtxtHorarioultVenda.Text = null;
                //
                txtTempVendeu.Text = "0";
            }
            //
            if (bllProduto.Sel_Prod_Qtde_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllProduto.Sel_Prod_Qtde_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtQtdeVendida.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtQtdeVendida.Text = "0,00";
                }
            }
            else
            {
                txtQtdeVendida.Text = "0,00";
            }
            //
            if (bllProduto.Sel_Prod_Qtde_Media_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllProduto.Sel_Prod_Qtde_Media_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtQtdeMedio.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtQtdeMedio.Text = "0,00";
                }
            }
            else
            {
                txtQtdeMedio.Text = "0,00";
            }
            //
            if (bllProduto.Sel_Prod_Total_Valor_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllProduto.Sel_Prod_Total_Valor_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtTotalVendido.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtTotalVendido.Text = "0,00";
                }
            }
            else
            {
                txtTotalVendido.Text = "0,00";
            }
            //
            if (bllProduto.Sel_Prod_Frequencia_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllProduto.Sel_Prod_Frequencia_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtFrequenciaVenda.Text = dr[0].ToString();
                }
                else
                {
                    txtFrequenciaVenda.Text = "0";
                }
            }
            else
            {
                txtFrequenciaVenda.Text = "0";
            }
            //
            if (bllProduto.Sel_Prod_Data_Hora_Ult_Entrada(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllProduto.Sel_Prod_Data_Hora_Ult_Entrada(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    mtxtDataUltEntrada.Text = dr[0].ToString().Remove(10);
                }
                else
                {
                    mtxtDataUltEntrada.Text = null;
                }
                //
                if (dr[1] != null & dr[1] != DBNull.Value)
                {
                    mtxtHoraUltEntrada.Text = dr[1].ToString();
                }
                else
                {
                    mtxtHoraUltEntrada.Text = null;
                }

            }
            else
            {
                mtxtDataUltEntrada.Text = null;
                //
                mtxtHoraUltEntrada.Text = null;
            }
            //
            if (bllProduto.Sel_Prod_Qtde_Ult_Entrada(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllProduto.Sel_Prod_Qtde_Ult_Entrada(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtQtdeUltEntrada.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtQtdeUltEntrada.Text = "0,00";
                }
            }
            else
            {
                txtQtdeUltEntrada.Text = "0,00";
            }
            //
            if (bllProduto.Sel_Prod_Data_Hora_Ult_Alteracao(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllProduto.Sel_Prod_Data_Hora_Ult_Alteracao(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr["data_ult_alteracao"] != null & dr["data_ult_alteracao"] != DBNull.Value)
                {
                    mtxtDataUltAltSistema.Text = dr["data_ult_alteracao"].ToString().Remove(10);
                    //
                    mtxtHorarioUltAltSistema.Text = dr["data_ult_alteracao"].ToString().Substring(11);
                }
                else
                {
                    mtxtDataUltAltSistema.Text = null;
                    //
                    mtxtHorarioUltAltSistema.Text = null;
                }
            }
            else
            {
                mtxtDataUltAltSistema.Text = null;
                //
                mtxtHorarioUltAltSistema.Text = null;
            }
            //
            if (bllProduto.Sel_Prod_Frequencia_Entrada(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllProduto.Sel_Prod_Frequencia_Entrada(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                if (dr[0] != null & dr[0] != DBNull.Value)
                {
                    txtFrequenciaEntrada.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
                }
                else
                {
                    txtFrequenciaEntrada.Text = "0,00";
                }
            }
            else
            {
                txtFrequenciaEntrada.Text = "0,00";
            }
            /*
           //
           if (bllClieCons.Sel_Clie_Valor_Total_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
           {
               dr = bllClieCons.Sel_Clie_Valor_Total_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
               //
               if (dr[0] != null & dr[0] != DBNull.Value)
               {
                   txtGastoCompras.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
               }
               else
               {
                   txtGastoCompras.Text = "0,00";
               }
           }
           else
           {
               txtGastoCompras.Text = "0,00";
           }
           //
           if (bllClieCons.Sel_Clie_Valor_Medio_Total_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
           {
               dr = bllClieCons.Sel_Clie_Valor_Medio_Total_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
               //
               if (dr[0] != null & dr[0] != DBNull.Value)
               {
                   txtTicketMedio.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
               }
               else
               {
                   txtTicketMedio.Text = "0,00";
               }
           }
           else
           {
               txtTicketMedio.Text = "0,00";
           }
           //
           if (bllClieCons.Sel_Clie_Qtde_Produto_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
           {
               dr = bllClieCons.Sel_Clie_Qtde_Produto_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
               //
               if (dr[0] != null & dr[0] != DBNull.Value)
               {
                   txtQtdeProduto.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
               }
               else
               {
                   txtQtdeProduto.Text = "0,00";
               }
           }
           else
           {
               txtQtdeProduto.Text = "0,00";
           }
           //
           if (bllClieCons.Sel_Clie_Qtde_Servico_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
           {
               dr = bllClieCons.Sel_Clie_Qtde_Servico_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
               //
               if (dr[0] != null & dr[0] != DBNull.Value)
               {
                   txtQtdeServico.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
               }
               else
               {
                   txtQtdeServico.Text = "0,00";
               }
           }
           else
           {
               txtQtdeServico.Text = "0,00";
           }
           //
           if (bllClieCons.Sel_Clie_Intervalo_Compra(SelectedRow.Cells[0].Value.ToString()) != null)
           {
               dr = bllClieCons.Sel_Clie_Intervalo_Compra(SelectedRow.Cells[0].Value.ToString()).Rows[0];
               //
               if (dr[0] != null & dr[0] != DBNull.Value)
               {
                   txtIntervalo.Text = dr[0].ToString();
               }
               else
               {
                   txtIntervalo.Text = "0";
               }
           }
           else
           {
               txtIntervalo.Text = "0";
           }
           //
           if (bllClieCons.Sel_Clie_Conta_Receber_Atrasada(SelectedRow.Cells[0].Value.ToString()) != null)
           {
               dr = bllClieCons.Sel_Clie_Conta_Receber_Atrasada(SelectedRow.Cells[0].Value.ToString()).Rows[0];
               //
               if (dr[0] != null & dr[0] != DBNull.Value)
               {
                   txtTotalEmAtraso.Text = Convert.ToDecimal(dr[0]).ToString("n2", new CultureInfo("pt-BR"));
               }
               else
               {
                   txtTotalEmAtraso.Text = "0,00";
               }
           }
           else
           {
               txtTotalEmAtraso.Text = "0,00";
           }
           */
        }

        private Image AdjustImageOrientation(Image image)
        {
            if (image.PropertyIdList.Contains(0x0112)) // 0x0112 é o ID do campo EXIF de orientação
            {
                int orientation = image.GetPropertyItem(0x0112).Value[0];
                RotateFlipType rotateFlipType = RotateFlipType.RotateNoneFlipNone;

                switch (orientation)
                {
                    case 2:
                        rotateFlipType = RotateFlipType.RotateNoneFlipX;
                        break;
                    case 3:
                        rotateFlipType = RotateFlipType.Rotate180FlipNone;
                        break;
                    case 4:
                        rotateFlipType = RotateFlipType.Rotate180FlipX;
                        break;
                    case 5:
                        rotateFlipType = RotateFlipType.Rotate90FlipX;
                        break;
                    case 6:
                        rotateFlipType = RotateFlipType.Rotate90FlipNone;
                        break;
                    case 7:
                        rotateFlipType = RotateFlipType.Rotate270FlipX;
                        break;
                    case 8:
                        rotateFlipType = RotateFlipType.Rotate270FlipNone;
                        break;
                }

                if (rotateFlipType != RotateFlipType.RotateNoneFlipNone)
                {
                    image.RotateFlip(rotateFlipType);
                }
            }

            return image;
        }

        private void dtProd_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtProd.DataSource == null)
            {
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllProduto._Url_Imagem = null;
                pcibImagem.Enabled = false;
                lblLegendaImagem.Visible = false;
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                pcibAjudaFoto.Enabled = false;
                _Contem_Imagem = false;
                dtProd.Enabled = false;
                btnCadastrarValidade.Enabled = false;
                //
                Desativar_Visao_Geral();
            }
            else
            {
                pcibImagem.Enabled = true;
                dtProd.Enabled = true;
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                lblLegendaImagem.Visible = true;
                pcibAjudaFoto.Enabled = true;
                btnCadastrarValidade.Enabled = true;
                //
                Ativar_Visao_Geral();
                //
                List<string> cor = new List<string>();
                List<string> grupo = new List<string>();
                //
                if (bllGrupo.Sel_Grupo_Cor_Destaque("PRODUTOS") != null)
                {
                    for (int i = 0; i < bllGrupo.Sel_Grupo_Cor_Destaque("PRODUTOS").Rows.Count; i++)
                    {
                        DataRow dr = bllGrupo.Sel_Grupo_Cor_Destaque("PRODUTOS").Rows[i];
                        //
                        if (dr["cor_destaque"].ToString() != null & dr["cor_destaque"].ToString() != "")
                        {
                            cor.Add(dr["cor_destaque"].ToString());
                            grupo.Add(dr["id_grupo"].ToString());
                        }
                    }
                }
                //
                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    for (int u = 0; u < cor.Count; u++)
                    {
                        if (cor[u] == "")
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        else if (cor[u] == "1" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                        else if (cor[u] == "2" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                        }
                        else if (cor[u] == "3" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                        }
                        else if (cor[u] == "4" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        else if (cor[u] == "5" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                        }
                        else if (cor[u] == "6" & grupo[u] == dtProd.Rows[i].Cells[6].Value.ToString())
                        {
                            dtProd.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void dtProd_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtProd.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtProd_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtProd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtProd.Columns[0].HeaderText = "Código";
                dtProd.Columns[1].HeaderText = "Descrição";
                dtProd.Columns[2].HeaderText = "UM";
                dtProd.Columns[3].HeaderText = "Preço (R$)";
                dtProd.Columns[4].HeaderText = "Cód. da Marca";
                dtProd.Columns[5].HeaderText = "Descrição da Marca";
                dtProd.Columns[6].HeaderText = "Cód. do Grupo";
                dtProd.Columns[7].HeaderText = "Descrição do Grupo";
                dtProd.Columns[8].HeaderText = "Cód. do Sub-Grupo";
                dtProd.Columns[9].HeaderText = "Descrição do Sub-Grupo";
                dtProd.Columns[10].HeaderText = "Código de Barras*";
                dtProd.Columns[11].HeaderText = "Referência";
                dtProd.Columns[12].HeaderText = "Cód. da Localização";
                dtProd.Columns[13].HeaderText = "Descrição da Localização";
                dtProd.Columns[14].Visible = false;
                dtProd.Columns[15].HeaderText = "Estoque Mín.";
                dtProd.Columns[16].HeaderText = "Estoque Máx.";
                dtProd.Columns[17].HeaderText = "Saldo Atual";
                dtProd.Columns[18].HeaderText = "Observações";
                dtProd.Columns[19].HeaderText = "Palavra-Chave";
                dtProd.Columns[20].Visible = false;
                dtProd.Columns[21].HeaderText = "Acréscimo (%)";
                dtProd.Columns[22].HeaderText = "Desconto (%)";
                dtProd.Columns[23].Visible = false;
                dtProd.Columns[24].Visible = false;
                dtProd.Columns[25].HeaderText = "NCM";
                dtProd.Columns[26].HeaderText = "CST";
                dtProd.Columns[27].HeaderText = "Alíquota (%)";
                dtProd.Columns[28].HeaderText = "CSOSN";
                dtProd.Columns[29].HeaderText = "CEST";
                //
                //if ((rbtnCodigo.Checked == true || rbtnPalavraChave.Checked == true || rbtnBarra.Checked == true) & _Inserir_Atualizar == false)
                //{
                    dtProd.Columns[30].Visible = false;
                    dtProd.Columns[31].Visible = false;
                    dtProd.Columns[32].Visible = false;
                    dtProd.Columns[33].HeaderText = "Ex.";
                    dtProd.Columns[34].HeaderText = "CST IBS/CBS";
                    dtProd.Columns[35].HeaderText = "Cód. Sit. Trib. (cClassTrib)";
                    dtProd.Columns[36].HeaderText = "Alíq. IBS Mun. (%)";
                    dtProd.Columns[37].HeaderText = "Alíq. IBS Est. (%)";
                    dtProd.Columns[38].HeaderText = "Alíq. CBS (%)";
                    dtProd.Columns[39].HeaderText = "Situação";
            //
                    dtProd.Columns[33].Width = 46;
                    dtProd.Columns[34].Width = 125;
                    dtProd.Columns[35].Width = 175;
                    dtProd.Columns[36].Width = 125;
                    dtProd.Columns[37].Width = 125;
                    dtProd.Columns[38].Width = 110;
                    dtProd.Columns[39].Width = 110;
                    //
                    dtProd.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[37].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[39].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[39].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            /*
                }
                else
                {
                    dtProd.Columns[30].HeaderText = "Ex.";
                    dtProd.Columns[31].HeaderText = "CST IBS/CBS";
                    dtProd.Columns[32].HeaderText = "Cód. Sit. Trib. (cClassTrib)";
                    dtProd.Columns[33].HeaderText = "Alíq. IBS Mun. (%)";
                    dtProd.Columns[34].HeaderText = "Alíq. IBS Est. (%)";
                    dtProd.Columns[35].HeaderText = "Alíq. CBS (%)";
                    //
                    dtProd.Columns[30].Width = 46;
                    dtProd.Columns[31].Width = 125;
                    dtProd.Columns[32].Width = 175;
                    dtProd.Columns[33].Width = 125;
                    dtProd.Columns[34].Width = 125;
                    dtProd.Columns[35].Width = 110;
                    //
                    dtProd.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProd.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            */
            //
                dtProd.Columns[0].Width = 85;
                dtProd.Columns[1].Width = 320;
                dtProd.Columns[2].Width = 46;
                dtProd.Columns[3].Width = 155;
                dtProd.Columns[4].Width = 115;
                dtProd.Columns[5].Width = 250;
                dtProd.Columns[6].Width = 115;
                dtProd.Columns[7].Width = 325;
                dtProd.Columns[8].Width = 125;
                dtProd.Columns[9].Width = 325;
                dtProd.Columns[10].Width = 325;
                dtProd.Columns[11].Width = 185;
                dtProd.Columns[12].Width = 135;
                dtProd.Columns[13].Width = 325;
                dtProd.Columns[15].Width = 125;
                dtProd.Columns[16].Width = 125;
                dtProd.Columns[17].Width = 95;
                dtProd.Columns[18].Width = 500;
                dtProd.Columns[19].Width = 95;
                dtProd.Columns[21].Width = 150;
                dtProd.Columns[22].Width = 150;
                dtProd.Columns[25].Width = 110;
                dtProd.Columns[26].Width = 90;
                dtProd.Columns[27].Width = 110;
                dtProd.Columns[28].Width = 90;
                dtProd.Columns[29].Width = 110;

                dtProd.DefaultCellStyle.Font = new Font(dtProd.Font, FontStyle.Bold);

                dtProd.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtProd.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblRegistros.Text = "Registros: " + dtProd.Rows.Count;

                for (int i = 0; i < dtProd.Rows.Count; i++)
                {
                    if (bllProduto.Sel_Dest_Est_Negativo_Prod(dtProd.Rows[i].Cells[0].Value.ToString()) == true)
                    {
                        dtProd.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (bllProduto.Sel_Alert_Est_Max_Min_Prod(dtProd.Rows[i].Cells[0].Value.ToString()) == true)
                    {
                        if (bllProduto.Ver_Estoque_Min_Prod(dtProd.Rows[i].Cells[0].Value.ToString(), "1"))
                        {
                            dtProd.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        dtProd.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
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
                dtProd.DataSource = null;
            }
        }

        private void dtProd_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Inserir_Atualizar == true)
                {
                    pEnabled.Enabled = false;
                    using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 4))
                    {
                        if (Imagem.ShowDialog() == DialogResult.OK)
                        {
                            if (bllProduto._Url_Imagem == null)
                            {
                                if (_Contem_Imagem == true)
                                {
                                    if (bllProduto._Excluir_Imagem == true)
                                    {
                                        pcibImagem.Image = null;
                                        pcibImagem.ImageLocation = null;
                                        lblLegendaImagem.Visible = true;
                                        bllProduto._Excluir_Imagem = false;
                                        _Contem_Imagem = false;
                                    }
                                    else if (bllProduto._Mostrar_Imagem == true)
                                    {
                                        if (_Comando_Atualizar == true)
                                        {
                                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                            //
                                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\"))
                                            {
                                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\");
                                            }
                                            byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
                                            string caminho = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                                            File.WriteAllBytes(caminho, imagemBytes);
                                            Process.Start(caminho);
                                            bllProduto._Mostrar_Imagem = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblLegendaImagem.Visible = false;
                                _Contem_Imagem = true;
                                pcibImagem.ImageLocation = bllProduto._Url_Imagem;
                                //
                                if (bllProduto._Excluir_Imagem == true)
                                {
                                    pcibImagem.Image = null;
                                    pcibImagem.ImageLocation = null;
                                    bllProduto._Url_Imagem = null;
                                    lblLegendaImagem.Visible = true;
                                    bllProduto._Excluir_Imagem = false;
                                    _Contem_Imagem = false;
                                }
                                else if (bllProduto._Mostrar_Imagem == true)
                                {
                                    Process.Start(bllProduto._Url_Imagem);
                                    bllProduto._Mostrar_Imagem = false;
                                }
                            }
                        }
                    }
                    pEnabled.Enabled = true;
                }
                else
                {
                    if (_Contem_Imagem == true)
                    {
                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtProd.DataSource != null)
                        {
                            MessageBox.Show("Sem imagem para este registro. Para adicionar uma imagem clique no botão [ Alterar ] após clique em\n[ Adicionar imagem ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                }
                //
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllProduto._Url_Imagem = null;
                bllProduto._Mostrar_Imagem = false;
                bllProduto._Excluir_Imagem = false;
            }
        }

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Inserir_Atualizar == true)
                {
                    pEnabled.Enabled = false;
                    using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 4))
                    {
                        if (Imagem.ShowDialog() == DialogResult.OK)
                        {
                            if (bllProduto._Url_Imagem == null)
                            {
                                if (_Contem_Imagem == true)
                                {
                                    if (bllProduto._Excluir_Imagem == true)
                                    {
                                        pcibImagem.Image = null;
                                        pcibImagem.ImageLocation = null;
                                        lblLegendaImagem.Visible = true;
                                        bllProduto._Excluir_Imagem = false;
                                        _Contem_Imagem = false;
                                    }
                                    else if (bllProduto._Mostrar_Imagem == true)
                                    {
                                        if (_Comando_Atualizar == true)
                                        {
                                            DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                            //
                                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\"))
                                            {
                                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\");
                                            }
                                            byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
                                            string caminho = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                                            File.WriteAllBytes(caminho, imagemBytes);
                                            Process.Start(caminho);
                                            bllProduto._Mostrar_Imagem = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblLegendaImagem.Visible = false;
                                _Contem_Imagem = true;
                                pcibImagem.ImageLocation = bllProduto._Url_Imagem;
                                //
                                if (bllProduto._Excluir_Imagem == true)
                                {
                                    pcibImagem.Image = null;
                                    pcibImagem.ImageLocation = null;
                                    bllProduto._Url_Imagem = null;
                                    lblLegendaImagem.Visible = true;
                                    bllProduto._Excluir_Imagem = false;
                                    _Contem_Imagem = false;
                                }
                                else if (bllProduto._Mostrar_Imagem == true)
                                {
                                    Process.Start(bllProduto._Url_Imagem);
                                    bllProduto._Mostrar_Imagem = false;
                                }
                            }
                        }
                    }
                    pEnabled.Enabled = true;
                }
                else
                {
                    if (_Contem_Imagem == true)
                    {
                        DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                        if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\"))
                        {
                            Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\");
                        }
                        byte[] imagemBytes = (byte[])SelectedRow.Cells[14].Value;
                        string caminho = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + SelectedRow.Cells[0].Value.ToString() + ".jpg";
                        File.WriteAllBytes(caminho, imagemBytes);
                        Process.Start(caminho);
                    }
                    else
                    {
                        if (dtProd.DataSource != null)
                        {
                            MessageBox.Show("Sem imagem para este registro. Para adicionar uma imagem clique no botão [ Alterar ] após clique em\n[ Adicionar imagem ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                }
                //
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllProduto._Url_Imagem = null;
                bllProduto._Mostrar_Imagem = false;
                bllProduto._Excluir_Imagem = false;
            }
        }

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);

            if (dtProd.DataSource != null || _Inserir_Atualizar == true)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void pcibImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Black;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void lblLegendaImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);
            if (dtProd.DataSource != null || _Inserir_Atualizar == true)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void lblLegendaImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            lblLegendaImagem.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, código de barras, grupo e sub-grupo, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllProduto.Sel_Produto_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtProd.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Produto?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        if (bllProduto.Sel_Produto_Venda_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Produto selecionado está sendo utilizado por uma Venda, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtProd.Select();
                        }
                        else if (bllProduto.Sel_Produto_Orcamento_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Produto selecionado está sendo utilizado por um Orçamento, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtProd.Select();
                        }
                        else if (bllProduto.Sel_Produto_Devolucao_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Produto selecionado está sendo utilizado por uma Devolução, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtProd.Select();
                        }
                        else if (bllProduto.Sel_Produto_Dfe_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Produto selecionado está sendo utilizado por um DFe, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtProd.Select();
                        }
                        else if (bllProduto.Sel_Produto_OS_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Produto selecionado está sendo utilizado por uma O.S., não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtProd.Select();
                        }
                        else
                        {
                            bllProduto.Excluir_Mult_Barra_Prod(txtCodigo.Text);
                            bllProduto.Excluir_Entrada_Produto_Prod(txtCodigo.Text);
                            bllProduto.Excluir_Validade_Prod(txtCodigo.Text);
                            bllProduto.Excluir(txtCodigo.Text);

                            bllRegistroAtividades.Salvar("EXCLUIU UM PRODUTO", "PRODUTOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Produto excluído. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Produto excluído. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            if (rbtnDescricao.Checked == true)
                            {
                                if (txtpDescricao.Text == "")
                                {
                                    dtProd.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    if (bllProduto.Sel_Prod_Descricao(txtpDescricao.Text, "") == null)
                                    {
                                        dtProd.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtProd.DataSource = bllProduto.Sel_Prod_Descricao(txtpDescricao.Text, "");
                                        dtProd.Select();
                                    }
                                }
                            }
                            else if (rbtnGrupo.Checked == true)
                            {
                                if (cbbpGrupo.Text != "")
                                {
                                    if (cbbpGrupo.Text != "" & cbbpSubGrupo.Text == "")
                                    {
                                        if (bllProduto.Sel_Prod_Grupo(cbbpGrupo.Text, "") == null)
                                        {
                                            dtProd.DataSource = null;
                                            Limpar();
                                        }
                                        else
                                        {
                                            dtProd.DataSource = bllProduto.Sel_Prod_Grupo(cbbpGrupo.Text, "");
                                            dtProd.Select();
                                        }
                                    }
                                    else
                                    {
                                        if (bllProduto.Sel_Prod_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "") == null)
                                        {
                                            dtProd.DataSource = null;
                                            Limpar();
                                        }
                                        else
                                        {
                                            dtProd.DataSource = bllProduto.Sel_Prod_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "");
                                            dtProd.Select();
                                        }
                                    }
                                }
                            }
                            else if (rbtnPalavraChave.Checked == true)
                            {
                                if (txtpPalavraChave.Text == "")
                                {
                                    dtProd.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    if (bllProduto.Sel_Prod_Palavra_Chave(txtpPalavraChave.Text, "") == null)
                                    {
                                        dtProd.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtProd.DataSource = bllProduto.Sel_Prod_Palavra_Chave(txtpPalavraChave.Text, "");
                                        dtProd.Select();
                                    }
                                }
                            }
                            else if (rbtnTodos.Checked == true)
                            {
                                if (bllProduto.Sel_Prod_Todos("") == null)
                                {
                                    dtProd.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtProd.DataSource = bllProduto.Sel_Prod_Todos("");
                                    dtProd.Select();
                                }
                            }
                            else
                            {
                                dtProd.DataSource = null;
                                Limpar();
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
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
                dtProd.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                pcibImagem.Image = null;
                pcibImagem.ImageLocation = null;
                bllProduto._Url_Imagem = null;
                lblLegendaImagem.Visible = false;
                _Inserir_Atualizar = false;
                _Contem_Imagem = false;
                _Comando_Atualizar = false;
            }
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = true;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = false;
            lblPesquisar.Location = new Point(524, 21);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpPalavraChave.Text = null;
                txtpPalavraChave.Select();
            }
            txtpPalavraChave.BackColor = Color.White;
        }

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Sem imagem para este registro: Significa que ou o registro foi adicionado sem imagem ou a imagem foi removida.\n\n2 - Adicionar imagem: Clique em [ Adicionar imagem ] para adicionar uma imagem ao registro.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void pcibAjudaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAjudaFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você altera os dados já cadastrados no sistema clicando na caixa de texto em que você deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ].\n\n5 - Asterisco Escuro (*): Significa que esse campo pode possuir um ou mais valores.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmCadProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadProduto foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadProduto foi finalizado.");
                }
                bllProduto._FrmCadProduto_Ativo = false;
                bllProduto._Preco_Venda = null;
                bllEntradasProdutos._Data_Entrada = null;
                bllEntradasProdutos._Fornecedor = null;
                bllEntradasProdutos._Quantidade = null;
                bllMultiploCodigoBarra.Excluir_Items_Codigo_Barra_Atual();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadProduto.");
                }
            }
        }

        private void btnAdicionarEstoque_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmCadProdutoEntrada Est = new FrmCadProdutoEntrada(txtCodigo.Text, _Usuario, _Cod_PDV_Computador))
                {
                    if (Est.ShowDialog() == DialogResult.Abort)
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllEntradasProdutos._Quantidade == null)
                            {
                                txtAdicionado.Text = "0,00";
                            }
                            else
                            {
                                txtAdicionado.Text = bllEntradasProdutos._Quantidade;
                            }
                            txtSaldoAtual.Text = bllProduto.Sel_Saldo_Atual_Produto(txtCodigo.Text).ToString("n2", new CultureInfo("pt-BR"));
                        }
                        else
                        {
                            if (bllEntradasProdutos._Quantidade == null)
                            {
                                txtAdicionado.Text = "0,00";
                            }
                            else
                            {
                                txtAdicionado.Text = bllEntradasProdutos._Quantidade;
                            }
                            txtAdicionado.Select();
                        }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadProduto.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnpProcurar1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar1_MouseLeave(object sender, EventArgs e)
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

        private void btnpProcurar1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(0))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbGrupo.Items.Clear();
                        if (bllProduto.Sel_Grupo_Prod() == null)
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
                            foreach (DataRow dr in bllProduto.Sel_Grupo_Prod().Rows)
                            {
                                cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbSubGrupo.Enabled = true;
                                btnProcurar2.Enabled = true;
                                lblSubGrupo.Enabled = true;
                            }
                        }

                        cbbGrupo.Text = bllProduto._Grupo_PesqGrupo_Tabela;
                        bllProduto._Grupo_PesqGrupo_Tabela = null;
                        cbbGrupo.Select();
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

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 0))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbSubGrupo.Items.Clear();
                            if (bllProduto.Sel_SubGrupo_Prod(items[0]) == null)
                            {
                                cbbSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllProduto.Sel_SubGrupo_Prod(items[0]).Rows)
                                {
                                    cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            cbbSubGrupo.Text = bllProduto._SubGrupo_PesqSubGrupo_Tabela;
                            bllProduto._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbSubGrupo.Select();
                        }
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

        private void cbbGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
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
                        if (bllProduto.Sel_SubGrupo_Prod(items[0]) == null)
                        {
                            cbbSubGrupo.Text = null;
                            cbbSubGrupo.Enabled = false;
                            btnProcurar2.Enabled = false;
                            lblSubGrupo.Enabled = false;
                            lblAsterisco4.Enabled = false;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_SubGrupo_Prod(items[0]).Rows)
                            {
                                cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbSubGrupo.Enabled = true;
                                btnProcurar2.Enabled = true;
                                lblSubGrupo.Enabled = true;
                                lblAsterisco4.Enabled = true;
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
                        lblAsterisco4.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
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

        private void cbbSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAdicionarEstoque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAdicionarEstoque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtEstoqueMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEstoqueMin.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtEstoqueMax.Select();
            }
        }

        private void txtEstoqueMin_Enter(object sender, EventArgs e)
        {
            txtEstoqueMin.BackColor = Color.LightBlue;
        }

        private void txtEstoqueMin_Leave(object sender, EventArgs e)
        {
            if (txtEstoqueMin.Text != "")
            {
                if (txtEstoqueMin.Text.Contains("'") || txtEstoqueMin.Text.Contains(";") || txtEstoqueMin.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtEstoqueMin.Text = null;
                    txtEstoqueMin.Select();
                }
                else
                {
                    try
                    {
                        txtEstoqueMin.Text = Convert.ToDecimal(txtEstoqueMin.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtEstoqueMin.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtEstoqueMin.");
                        }
                        txtEstoqueMin.Text = null;
                    }
                }
            }
            txtEstoqueMin.BackColor = Color.White;
        }

        private void txtEstoqueMax_Enter(object sender, EventArgs e)
        {
            txtEstoqueMax.BackColor = Color.LightBlue;
        }

        private void txtEstoqueMax_Leave(object sender, EventArgs e)
        {
            if (txtEstoqueMax.Text != "")
            {
                if (txtEstoqueMax.Text.Contains("'") || txtEstoqueMax.Text.Contains(";") || txtEstoqueMax.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtEstoqueMax.Text = null;
                    txtEstoqueMax.Select();
                }
                else
                {
                    try
                    {
                        txtEstoqueMax.Text = Convert.ToDecimal(txtEstoqueMax.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtEstoqueMin.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtEstoqueMin.");
                        }
                        txtEstoqueMax.Text = null;
                    }
                }
            }
            txtEstoqueMax.BackColor = Color.White;
        }

        private void txtEstoqueMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEstoqueMax.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtSaldoAtual.Select();
            }
        }

        private void txtReferencia_Enter(object sender, EventArgs e)
        {
            txtReferencia.BackColor = Color.LightBlue;
        }

        private void txtReferencia_Leave(object sender, EventArgs e)
        {
            if (txtReferencia.Text.Contains(";") || txtReferencia.Text.Contains("'") || txtReferencia.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtReferencia.Text = null;
                txtReferencia.Select();
            }
            txtReferencia.BackColor = Color.White;
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void rbtnReferencia_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnReferencia_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnReferencia_CheckedChanged(object sender, EventArgs e)
        {
            txtpBarra.MaxLength = 25;
            txtpBarra.CharacterCasing = CharacterCasing.Upper;
            btnpProcurarSub1.Visible = false;
            cbbpSubGrupo.Visible = false;
            lblSubGrupo1.Visible = false;
            btnpProcurar.Visible = false;
            btnpProcurarSub1.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpGrupo.Visible = false;
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            txtpBarra.Visible = true;
            lblPesquisar.Location = new Point(453, 21);
            lblPesquisar.Text = "Digite a referência:";
            txtpBarra.Text = null;
            txtpBarra.Select();
        }

        private void cbbpGrupoFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.SelectedItem.ToString().Split('—');
                    cbbpSubGrupo.Items.Clear();
                    if (bllProduto.Sel_SubGrupo_Prod(items[0]) == null)
                    {
                        cbbpSubGrupo.Text = null;
                        cbbpSubGrupo.Enabled = false;
                        btnpProcurarSub1.Enabled = false;
                        lblSubGrupo1.Enabled = false;
                    }
                    else
                    {
                        cbbpSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllProduto.Sel_SubGrupo_Prod(items[0]).Rows)
                        {
                            cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            cbbpSubGrupo.Enabled = true;
                            btnpProcurarSub1.Enabled = true;
                            lblSubGrupo1.Enabled = true;
                        }
                    }
                }
                else
                {
                    cbbpSubGrupo.Items.Clear();
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnpProcurarSub1.Enabled = false;
                    lblSubGrupo1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do cbbpGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do cbbpGrupo.");
                }
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Text = null;
            }
        }

        private void cbbpGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpSubGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSubGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurarSub1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurarSub1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(0))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpGrupo.Items.Clear();
                        if (bllProduto.Sel_Grupo_Prod() == null)
                        {
                            cbbpGrupo.Text = null;
                            cbbpSubGrupo.Enabled = false;
                            cbbpSubGrupo.Text = null;
                            btnpProcurarSub1.Enabled = false;
                            lblSubGrupo1.Enabled = false;
                        }
                        else
                        {
                            cbbpGrupo.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_Grupo_Prod().Rows)
                            {
                                cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbpSubGrupo.Enabled = true;
                                btnpProcurarSub1.Enabled = true;
                                lblSubGrupo1.Enabled = true;
                            }
                        }

                        cbbpGrupo.Text = bllProduto._Grupo_PesqGrupo_Tabela;
                        bllProduto._Grupo_PesqGrupo_Tabela = null;
                        cbbpGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        cbbpGrupo.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbpSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtSaldoAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAdicionado.Select();
            }
        }

        private void cbbSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtBarra.Select();
            }
        }

        private void btnpProcurarSub1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.Text.Split('—');

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 0))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbpSubGrupo.Items.Clear();

                            if (bllProduto.Sel_SubGrupo_Prod(items[0]) == null)
                            {
                                cbbpSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbpSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllProduto.Sel_SubGrupo_Prod(items[0]).Rows)
                                {
                                    cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            cbbpSubGrupo.Text = bllProduto._SubGrupo_PesqSubGrupo_Tabela;
                            bllProduto._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbpSubGrupo.Select();
                        }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarSub1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarSub1.");
                }
                cbbpSubGrupo.Text = null;
            }
            pEnabled.Enabled = true;
        }

        private void txtObs_Enter(object sender, EventArgs e)
        {
            txtObs.BackColor = Color.LightBlue;
        }

        private void txtObs_Leave(object sender, EventArgs e)
        {
            if (txtObs.Text.Contains(";") || txtObs.Text.Contains("'") || txtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtObs.Text = null;
                txtObs.Select();
            }
            txtObs.BackColor = Color.White;
        }

        private void txtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                tabcCadastro.SelectedTab = tabcCadastro4;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPalavraChave.Select();
            }
        }


        private void btnAdicionarLucro_Click(object sender, EventArgs e)
        {
            using (FrmCadProdPrecoVenda Preco = new FrmCadProdPrecoVenda())
            {
                if (Preco.ShowDialog() == DialogResult.Abort)
                {
                    txtPreco.Text = bllProduto._Preco_Venda;
                    txtPreco.Select();
                }
            }
        }

        private void btnAdicionarLucro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAdicionarLucro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtObs_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + txtObs.Text.Length + "/200";
        }

        private void cbbMarca_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbMarca_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbMarca_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbMarca_MouseLeave(object sender, EventArgs e)
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

        private void cbbMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEstoqueMin.Select();
            }
        }

        private void btnProcurar3_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqMarca Marca = new FrmPesqMarca(0, _Usuario, _Cod_PDV_Computador))
            {
                if (Marca.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbMarca.Items.Clear();
                        if (bllProduto.Sel_Marca_Prod() == null)
                        {
                            cbbMarca.Text = null;
                        }
                        else
                        {
                            cbbMarca.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_Marca_Prod().Rows)
                            {
                                cbbMarca.Items.Add((dr["id_marca"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        //
                        cbbMarca.Text = bllProduto._Marca_PesqMarca_Tabela;
                        bllProduto._Marca_PesqMarca_Tabela = null;
                        cbbMarca.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar3.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar3.");
                        }
                        cbbMarca.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void dtProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            if (e.ColumnIndex == 12 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void lblTipo_Click(object sender, EventArgs e)
        {

        }

        private void btnApagarAtual_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnApagarAtual_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnApagarAtual_Click(object sender, EventArgs e)
        {
            bllEntradasProdutos._Data_Entrada = null;
            bllEntradasProdutos._Fornecedor = null;
            bllEntradasProdutos._Quantidade = null;
            txtAdicionado.Text = "0,00";
        }

        private void txtAgregado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                tabcCadastro.SelectedTab = tabpCadastro3;
            }
        }

        private void btnApagarLucro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnApagarLucro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbLocalizacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbLocalizacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbLocalizacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbLocalizacao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbLocalizacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbGrupo.Select();
            }
        }

        private void btnProcurar4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tabcCadastro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tabcCadastro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tabpCadastro2_Enter(object sender, EventArgs e)
        {
            _Visao_Geral_Prod = false;
            if (_Inserir_Atualizar == true)
            {
                txtReferencia.Select();
            }
        }

        private void btnProcurar4_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqLocalizacao Localizacao = new FrmPesqLocalizacao(0))
            {
                if (Localizacao.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbLocalizacao.Items.Clear();
                        if (bllProduto.Sel_Localizacao_Prod() == null)
                        {
                            cbbLocalizacao.Text = null;
                        }
                        else
                        {
                            cbbLocalizacao.Items.Add("");
                            foreach (DataRow dr in bllProduto.Sel_Localizacao_Prod().Rows)
                            {
                                cbbLocalizacao.Items.Add(dr["id_localizacao"].ToString() + "—" + dr["descricao"].ToString());
                            }
                        }
                        //
                        cbbLocalizacao.Text = bllProduto._Localizacao_PesqLocalizacao_Tabela;
                        bllProduto._Localizacao_PesqLocalizacao_Tabela = null;
                        cbbLocalizacao.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar4.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar4.");
                        }
                        cbbLocalizacao.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Unidade de Medida:\n\nUN  => Unidade\nCX  => Caixa\nKG  => Quilograma\nM  => Metro", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblNome_Desc_Click(object sender, EventArgs e)
        {

        }

        private void txtDesconto_Enter(object sender, EventArgs e)
        {
            txtDesconto.BackColor = Color.LightBlue;
        }

        private void txtAcrescimo_Enter(object sender, EventArgs e)
        {
            txtAcrescimo.BackColor = Color.LightBlue;
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
                txtPreco.Select();
            }
        }

        private void txtAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
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
                txtDesconto.Select();
            }
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
                try
                {
                    if (txtDesconto.Text != "")
                    {
                        txtDesconto.Text = Convert.ToDecimal(txtDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
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
            //
            txtDesconto.BackColor = Color.White;
        }

        private void txtAcrescimo_Leave(object sender, EventArgs e)
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
                try
                {
                    if (txtAcrescimo.Text != "")
                    {
                        txtAcrescimo.Text = Convert.ToDecimal(txtAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));
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
            //
            txtAcrescimo.BackColor = Color.White;
        }

        private void chkbAlertarEstoque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbAlertarEstoque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbDestEstoqueBaixo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbDestEstoqueBaixo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCodigoBarra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCodigoBarra_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCodigoBarra_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                string cod_barra;
                if (_Comando_Atualizar == true)
                {
                    DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                    //
                    cod_barra = SelectedRow.Cells[10].Value.ToString();
                }
                else
                {
                    cod_barra = txtBarra.Text;
                }
                //
                using (FrmMultiploCodigoBarra Est = new FrmMultiploCodigoBarra(txtCodigo.Text, cod_barra))
                {
                    if (Est.ShowDialog() == DialogResult.Abort)
                    {
                        txtBarra.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadProduto.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void txtNCM_Enter(object sender, EventArgs e)
        {
            txtNCM.BackColor = Color.LightBlue;
        }

        private void txtNCM_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtNCM.Text != "")
                {
                    if (txtNCM.Text.Contains(";") || txtNCM.Text.Contains("'") || txtNCM.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        txtNCM.Text = null;
                        txtNCM.Select();
                    }
                    else
                    {
                        txtNCM.Text = txtNCM.Text.Replace(".", "");
                        //
                        if (txtNCM.Text.Length != 8)
                        {
                            MessageBox.Show("o tamanho do NCM informado não é válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNCM.Text = null;
                            txtNCM.Select();
                        }
                        else if (bllProduto.Val_Prod_NCM(txtNCM.Text.Trim()) == false)
                        {
                            MessageBox.Show("NCM não encontrado na tabela IBPT.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNCM.Text = null;
                            txtNCM.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNCM.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNCM.");
                }
                txtNCM.Text = null;
            }
            txtNCM.BackColor = Color.White;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            txtCEST.BackColor = Color.LightBlue;
        }

        private void txtCEST_Leave(object sender, EventArgs e)
        {
            if (txtCEST.Text != "")
            {
                if (txtCEST.Text.Contains(";") || txtCEST.Text.Contains("'") || txtCEST.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtCEST.Text = null;
                    txtCEST.Select();
                }
                else
                {
                    txtCEST.Text = txtCEST.Text.Replace(".", "");
                    //

                }
            }
            txtCEST.BackColor = Color.White;
        }

        private void txtAliqICMS_Leave(object sender, EventArgs e)
        {
            if (txtAliqICMS.Text != "")
            {
                if (txtAliqICMS.Text.Contains("'") || txtAliqICMS.Text.Contains(";") || txtAliqICMS.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtAliqICMS.Text = null;
                    txtAliqICMS.Select();
                }
                else
                {
                    try
                    {
                        txtAliqICMS.Text = Convert.ToDecimal(txtAliqICMS.Text).ToString("n2", new CultureInfo("pt-BR"));
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

        private void txtAliqICMS_Enter(object sender, EventArgs e)
        {
            txtAliqICMS.BackColor = Color.LightBlue;
        }


        private void txtNCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtEx.Select();
            }
        }

        private void txtCEST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbCSTA.Select();
            }
        }

        private void txtCST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtAliqICMS.Select();
            }
        }

        private void cbbCSTA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtAliqICMS.Enabled == true)
                {
                    txtAliqICMS.Select();
                }
                else
                {
                    cbbCSOSN.Select();
                }
            }
        }

        private void cbbCSTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCSTB.Select();
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

        private void cbbCSTB_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCSTB_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCSTB_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCSTB_DropDownClosed(object sender, EventArgs e)
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

        private void cbbCSOSN_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCSOSN_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCSOSN_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCSOSN_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCSOSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCSTAIBSCBS.Select();
            }
        }

        private void cbbCSTB_Leave(object sender, EventArgs e)
        {

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
        }

        private void chkbAlertarEstoque_CheckedChanged(object sender, EventArgs e)
        {

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
                txtAliqICMS.Enabled = false;
                txtAliqICMS.Text = "20,50";
            }
            else if (cbbCSOSN.Text == "201")
            {
                txtAliqICMS.Enabled = true;
                txtAliqICMS.Text = "20,50";
            }
            else if (cbbCSOSN.Text == "202")
            {
                txtAliqICMS.Enabled = true;
                txtAliqICMS.Text = "20,50";
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

        private void btnCadastrarValidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadastrarValidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCadastrarValidade_Click(object sender, EventArgs e)
        {
            try
            {
                pEnabled.Enabled = false;
                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];

                using (FrmCadValidade Val = new FrmCadValidade(2, _Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString(), null))
                {
                    if (Val.ShowDialog() == DialogResult.Abort)
                    {
                        pEnabled.Enabled = true;
                        //
                        if (dtProd.DataSource != null)
                        {
                            dtProd.Select();
                        }
                        else
                        {
                            btnNovo.Select();
                        }
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarValidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarValidade.");
                }
            }
            
        }

        private void btnPesquisarNCM_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisarNCM_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisarNCM_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqNCM NCM = new FrmPesqNCM(txtNCM.Text, _Excecao_NCM))
            {
                if (NCM.ShowDialog() == DialogResult.OK)
                {
                    string[] items = bllProduto._NCM_PesqNCM_Tabela.Split('—');
                    txtNCM.Text = items[0];
                    _Excecao_NCM = items[1];
                    bllProduto._NCM_PesqNCM_Tabela = null;

                }
            }
            pEnabled.Enabled = true;
        }

        private void btnVerificarValidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVerificarValidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVerificarValidade_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNCM.Text.Trim() == "")
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ NCM ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    ACBrNCM NCM = new ACBrNCM();
                    //
                    MessageBox.Show(NCM.Validar(txtNCM.Text), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnVerificarValidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnVerificarValidade.");
                }
                txtNCM.Text = null;
            }
        }

        private void tabpCadastro3_Enter(object sender, EventArgs e)
        {
            _Visao_Geral_Prod = false;
            if (_Inserir_Atualizar == true)
            {
                txtNCM.Select();
            }
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

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabpCadastro1_Enter(object sender, EventArgs e)
        {
            _Visao_Geral_Prod = false;
            if (_Inserir_Atualizar == true)
            {
                txtPalavraChave.Select();
            }
        }

        private void txtAliqCBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAliqCBS.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                tabcCadastro.SelectedTab = tabpCadastro2;
            }
        }

        private void txtAliqCBS_Enter(object sender, EventArgs e)
        {
            //txtAliqCBS.BackColor = Color.LightBlue;
        }

        private void txtAliqCBS_Leave(object sender, EventArgs e)
        {
            if (txtAliqCBS.Text != "")
            {
                if (txtAliqCBS.Text.Contains("'") || txtAliqCBS.Text.Contains(";") || txtAliqCBS.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtAliqCBS.Text = null;
                    txtAliqCBS.Select();
                }
                else
                {
                    try
                    {
                        txtAliqCBS.Text = Convert.ToDecimal(txtAliqCBS.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqCBS.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqCBS.");
                        }
                        txtAliqCBS.Text = null;
                    }
                }
            }
            //txtAliqCBS.BackColor = Color.White;
        }

        private void txtEx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCEST.Select();
            }
        }

        private void txtAliqIBSMun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAliqIBSMun.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtAliqIBSEstadual.Select();
            }
        }

        private void txtAliqIBSMun_Leave(object sender, EventArgs e)
        {
            if (txtAliqIBSMun.Text != "")
            {
                if (txtAliqIBSMun.Text.Contains("'") || txtAliqIBSMun.Text.Contains(";") || txtAliqIBSMun.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtAliqIBSMun.Text = null;
                    txtAliqIBSMun.Select();
                }
                else
                {
                    try
                    {
                        txtAliqIBSMun.Text = Convert.ToDecimal(txtAliqIBSMun.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqIBSMun.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqIBSMun.");
                        }
                        txtAliqIBSMun.Text = null;
                    }
                }
            }
            //txtAliqIBSMun.BackColor = Color.White;
        }

        private void txtAliqIBSMun_Enter(object sender, EventArgs e)
        {
            //txtAliqIBSMun.BackColor = Color.LightBlue;
        }

        private void txtAliqIBSEstadual_Enter(object sender, EventArgs e)
        {
            //txtAliqIBSEstadual.BackColor = Color.LightBlue;
        }

        private void txtAliqIBSEstadual_Leave(object sender, EventArgs e)
        {
            if (txtAliqIBSEstadual.Text != "")
            {
                if (txtAliqIBSEstadual.Text.Contains("'") || txtAliqIBSEstadual.Text.Contains(";") || txtAliqIBSEstadual.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtAliqIBSEstadual.Text = null;
                    txtAliqIBSEstadual.Select();
                }
                else
                {
                    try
                    {
                        txtAliqIBSEstadual.Text = Convert.ToDecimal(txtAliqIBSEstadual.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqIBSEstadual.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliqIBSEstadual.");
                        }
                        txtAliqIBSEstadual.Text = null;
                    }
                }
            }
            //txtAliqIBSEstadual.BackColor = Color.White;
        }

        private void txtAliqIBSEstadual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAliqIBSEstadual.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtAliqCBS.Select();
            }
        }

        private void cbbCClassTrib_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAliqIBSMun.Select();
            }
        }

        private void cbbCSTBIBSCBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCClassTrib.Select();
            }
        }

        private void cbbCSTAIBSCBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCSTBIBSCBS.Select();
            }
        }

        private void pcibAjuda1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IBS e CBS:\n\nLEI COMPLEMENTAR Nº 214, DE 16 DE JANEIRO DE 2025\n\nInstitui o Imposto sobre Bens e Serviços (IBS), a Contribuição Social sobre Bens e Serviços (CBS) e o Imposto Seletivo (IS); cria o Comitê Gestor do IBS e altera a legislação tributária.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnPrecificar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                //
                using (FrmPrecificarItems Val = new FrmPrecificarItems(_Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString(), 1))
                {
                    if (Val.ShowDialog() == DialogResult.OK)
                    {
                        dtProd.Select();
                    }
                    else
                    {
                        dtProd.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarValidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCadastrarValidade.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void dtProd_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            try
            {
                _Visao_Geral_Prod = true;
                //
                if (dtProd.DataSource != null & (_Inserir_Atualizar == true & _Comando_Atualizar == true))
                {
                    Executar_Visao_Geral();
                }
                else if (dtProd.DataSource != null & (_Inserir_Atualizar == false & _Comando_Atualizar == false))
                {
                    Executar_Visao_Geral();
                }
                //
                if (_Inserir_Atualizar == true)
                {
                    mtxtDataCadastro.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento enter do tabcCadastro4.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento enter do tabcCadastro4.");
                }
            }
        }

        private void mtxtDataCadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13) 
            {
                mtxtDataUltVenda.Select();
            }
        }

        private void mtxtDataUltVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioultVenda.Select();
            }
        }

        private void mtxtHorarioultVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTempVendeu.Select();
            }
        }

        private void txtTempVendeu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtFrequenciaVenda.Select();
            }
        }

        private void txtFrequenciaVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQtdeVendida.Select();
            }
        }

        private void txtQtdeVendida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQtdeMedio.Select();
            }
        }

        private void txtQtdeMedio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTotalVendido.Select();
            }
        }

        private void txtTotalVendido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataUltEntrada.Select();
            }
        }

        private void mtxtDataUltEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHoraUltEntrada.Select();
            }
        }

        private void mtxtHoraUltEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQtdeUltEntrada.Select();
            }
        }

        private void txtQtdeUltEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtFrequenciaEntrada.Select();
            }
        }

        private void txtFrequenciaEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataUltAltSistema.Select();
            }
        }

        private void mtxtDataUltAltSistema_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioUltAltSistema.Select();
            }
        }

        private void btnGerarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                pEnabled.Enabled = false;
                using (FrmInfImpressao Imp = new FrmInfImpressao(52))
                {
                    if (Imp.ShowDialog() == DialogResult.OK)
                    {
                        if (bllClieCons._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                        {
                            using (var doc = new PdfDocument())
                            {
                                var page = doc.AddPage();
                                //
                                page.Width = 203;
                                page.Height = 842;
                                //                       
                                var graphics = XGraphics.FromPdfPage(page);
                                var textFormatter1 = new XTextFormatter(graphics);
                                var textFormatter2 = new XTextFormatter(graphics);
                                var textFormatter3 = new XTextFormatter(graphics);
                                var textFormatter4 = new XTextFormatter(graphics);
                                //
                                var fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                var fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                var fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                var fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                                //
                                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                //
                                XPen pen1 = new XPen(XColors.AntiqueWhite);
                                XPen pen = new XPen(XColors.Black);
                                //
                                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                //
                                StringFormat Sf1 = new StringFormat();
                                Sf1.Alignment = StringAlignment.Near;
                                //
                                StringFormat Sf2 = new StringFormat();
                                Sf2.Alignment = StringAlignment.Far;
                                //
                                int Incrementar = 0;
                                //
                                textFormatter1.DrawString(bllMinhaEmpresa.Sel_Nome_Empresa(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 198, 12));
                                Margem_Topo = Margem_Topo + 12;
                                textFormatter1.DrawString(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 198, 12));
                                Margem_Topo = Margem_Topo + 12;
                                //
                                textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 1 + Incrementar + Margem_Topo, 198, 24));
                                textFormatter1.DrawString("VISÃO GERAL DO PRODUTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 198, 24));
                                textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 12 + Incrementar + Margem_Topo, 198, 24));
                                //
                                Margem_Topo = Margem_Topo - 14;
                                //
                                textFormatter2.DrawString("Produto: " + SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 36 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Data de Cadastro: " + mtxtDataCadastro.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 46 + Margem_Topo, 198, 7));
                                //
                                mtxtDataUltVenda.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                if (mtxtDataUltVenda.Text == "")
                                {
                                    mtxtDataUltVenda.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última Venda: ", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 7));

                                }
                                else
                                {
                                    mtxtDataUltVenda.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última Venda: " + mtxtDataUltVenda.Text + " " + mtxtHorarioultVenda.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 7));
                                }
                                //
                                Margem_Topo = Margem_Topo + 10;
                                textFormatter2.DrawString("Há quanto tempo vendeu? Há " + txtTempVendeu.Text + " dia(s).", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Frequência de Venda: " + txtFrequenciaVenda.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 66 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Quantidade Vendida: " + txtQtdeVendida.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 76 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Quantidade Média: " + txtQtdeMedio.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 86 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Total Vendido: " + Convert.ToDecimal(txtTotalVendido.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 96 + Margem_Topo, 198, 7));
                                //
                                mtxtDataUltEntrada.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                if (mtxtDataUltEntrada.Text == "")
                                {
                                    mtxtDataUltEntrada.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data de e Horário da última Entrada (DFe): ", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 106 + Margem_Topo, 198, 7));
                                }
                                else
                                {
                                    mtxtDataUltEntrada.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data de e Horário da última Entrada (DFe): " + mtxtDataUltEntrada.Text + " " + mtxtHoraUltEntrada.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 106 + Margem_Topo, 198, 7));
                                }
                                //
                                textFormatter2.DrawString("Quantidade da última Entrada (DFe): " + txtQtdeUltEntrada.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 116 + Margem_Topo, 198, 7));
                                //
                                textFormatter2.DrawString("Frequeência de Entrada: " + txtFrequenciaEntrada.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 126 + Margem_Topo, 198, 7));
                                //
                                Margem_Topo = Margem_Topo + 10;
                                mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                if (mtxtDataUltAltSistema.Text == "")
                                {
                                    mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: ", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 126 + Margem_Topo, 198, 7));
                                }
                                else
                                {
                                    mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: " + mtxtDataUltAltSistema.Text + " " + mtxtHorarioUltAltSistema.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 126 + Margem_Topo, 198, 7));
                                }
                                textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, 146 + Margem_Topo, 198, 16));
                                //
                                PdfSecuritySettings security = doc.SecuritySettings;
                                //
                                security.PermitAccessibilityExtractContent = false;
                                security.PermitAnnotations = false;
                                security.PermitAssembleDocument = false;
                                security.PermitExtractContent = false;
                                security.PermitFormsFill = true;
                                security.PermitFullQualityPrint = false;
                                security.PermitModifyDocument = false;
                                security.PermitPrint = true;
                                //                   
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Produtos"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Produtos");
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Produtos\Produtos.pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Produtos\Produtos.pdf");
                                }
                            }
                        }
                        else if (bllClieCons._Tipo_Impressao == "PDF A4")
                        {
                            using (var doc = new PdfDocument())
                            {
                                var page = doc.AddPage();
                                //
                                page.Width = 595;
                                page.Height = 842;
                                //                       
                                var graphics = XGraphics.FromPdfPage(page);
                                var textFormatter1 = new XTextFormatter(graphics);
                                var textFormatter2 = new XTextFormatter(graphics);
                                var textFormatter3 = new XTextFormatter(graphics);
                                var textFormatter4 = new XTextFormatter(graphics);
                                //
                                var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                var fonte2 = new XFont("Microsoft Sans Serif", 12);
                                var fonte3 = new XFont("Microsoft Sans Serif", 11);
                                var fonte4 = new XFont("Microsoft Sans Serif", 10);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                                //
                                XPen pen1 = new XPen(XColors.AntiqueWhite);
                                XPen pen = new XPen(XColors.Black);
                                //
                                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                //
                                DataGridViewRow SelectedRow = dtProd.Rows[dtProd.CurrentRow.Index];
                                //
                                StringFormat Sf1 = new StringFormat();
                                Sf1.Alignment = StringAlignment.Near;
                                //
                                StringFormat Sf2 = new StringFormat();
                                Sf2.Alignment = StringAlignment.Far;
                                //
                                int Incrementar = 0;
                                //
                                textFormatter1.DrawString(bllMinhaEmpresa.Sel_Nome_Empresa() + "    " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 10 + Margem_Topo, 595, 13));
                                //
                                Margem_Topo = Convert.ToInt16(Margem_Topo + 17);
                                //
                                textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 1 + Margem_Topo, 595, 24));
                                textFormatter1.DrawString("VISÃO GERAL DO PRODUTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 10 + Margem_Topo, 595, 13));
                                textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 16 + Margem_Topo, 595, 24));
                                //
                                Margem_Topo = Margem_Topo - 14;
                                //
                                textFormatter2.DrawString("Produto: " + SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 47 + Margem_Topo, 595, 7));
                                //
                                Margem_Topo = Margem_Topo + 14;
                                textFormatter2.DrawString("Data de Cadastro: " + mtxtDataCadastro.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 47 + Margem_Topo, 595, 7));
                                //
                                mtxtDataUltVenda.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                if (mtxtDataUltVenda.Text == "")
                                {
                                    mtxtDataUltVenda.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última Venda: ", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 61 + Margem_Topo, 595, 7));

                                }
                                else
                                {
                                    mtxtDataUltVenda.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última Venda: " + mtxtDataUltVenda.Text + " " + mtxtHorarioultVenda.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 61 + Margem_Topo, 595, 7));
                                }
                                //
                                textFormatter2.DrawString("Há quanto tempo vendeu? Há " + txtTempVendeu.Text + " dia(s).", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 75 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Frequência de Venda: " + txtFrequenciaVenda.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 89 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Quantidade Vendida: " + txtQtdeVendida.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 103 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Quantidade Média: " + txtQtdeMedio.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 117 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Total Vendido: " + Convert.ToDecimal(txtTotalVendido.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 131 + Margem_Topo, 595, 7));
                                //
                                mtxtDataUltEntrada.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                if (mtxtDataUltEntrada.Text == "")
                                {
                                    mtxtDataUltEntrada.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data de e Horário da última Entrada (DFe): ", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 145 + Margem_Topo, 595, 7));
                                }
                                else
                                {
                                    mtxtDataUltEntrada.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data de e Horário da última Entrada (DFe): " + mtxtDataUltEntrada.Text + " " + mtxtHoraUltEntrada.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 145 + Margem_Topo, 595, 7));
                                }
                                //
                                textFormatter2.DrawString("Quantidade da última Entrada (DFe): " + txtQtdeUltEntrada.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 159 + Margem_Topo, 595, 7));
                                //
                                textFormatter2.DrawString("Frequeência de Entrada: " + txtFrequenciaEntrada.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 173 + Margem_Topo, 595, 7));
                                //
                                Margem_Topo = Margem_Topo + 14;
                                mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                if (mtxtDataUltAltSistema.Text == "")
                                {
                                    mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: ", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 173 + Margem_Topo, 595, 7));
                                }
                                else
                                {
                                    mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: " + mtxtDataUltAltSistema.Text + " " + mtxtHorarioUltAltSistema.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 173 + Margem_Topo, 595, 7));
                                }
                                //
                                textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, 216 + Margem_Topo, 585, 11));
                                //
                                PdfSecuritySettings security = doc.SecuritySettings;
                                //
                                security.PermitAccessibilityExtractContent = false;
                                security.PermitAnnotations = false;
                                security.PermitAssembleDocument = false;
                                security.PermitExtractContent = false;
                                security.PermitFormsFill = true;
                                security.PermitFullQualityPrint = false;
                                security.PermitModifyDocument = false;
                                security.PermitPrint = true;
                                //                   
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Produtos"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Produtos");
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Produtos\Produtos.pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Produtos\Produtos.pdf");
                                }
                            }
                        }
                    }
                }
                //
                AbrirPDF.Pdf(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Produtos\Produtos.pdf");
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerarPDF.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerarPDF.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void mtxtHorarioUltAltSistema_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (btnSalvar.Enabled == false)
                {
                    dtProd.Select();
                }
                else
                {
                    btnSalvar.Select();
                }
            }
        }

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtObs.Select();
            }
        }

        private void picbInterrogacao5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta seção exibe uma visão geral do Produto no sistema.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbSubGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSubGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
