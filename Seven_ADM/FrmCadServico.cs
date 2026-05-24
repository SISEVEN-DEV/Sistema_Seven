using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadServico : Form
    {
        public FrmCadServico(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar = false;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Formulario;
        private string _ComboboxServico_Valor = null;
        private string _ComboboxGrupo_Valor = null;
        private string _ComboboxSubGrupo_Valor = null;
        private bool _Visao_Geral_Serv = false;

        private void FrmCadServico_Load(object sender, EventArgs e)
        {
            try
            {
                bllServico._FrmCadServico_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadServico iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadServico iniciado.");
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadServico.");
                }
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtDescricao.Text = null;
            txtPreco.Text = null;
            cbbItemServico.Text = null;
            txtAliquota.Text = null;
            txtComissao.Text = null;
            txtAcrescimo.Text = null;
            txtDesconto.Text = null;
            cbbGrupo.Text = null;
            cbbSubGrupo.Text = null;
            cbbSituacao.Text = null;
            mtxtDataCadastro.Text = null;
            mtxtDataUltVenda.Text = null;
            mtxtHorarioultVenda.Text = null;
            txtTempVendeu.Text = null;
            txtFrequenciaVenda.Text = null;
            mtxtDataUltAltSistema.Text = null;
            mtxtHorarioUltAltSistema.Text = null;
            txtTotalVendido.Text = null;
        }

        private void Ativar() 
        {
            txtDescricao.Enabled = true;
            txtPreco.Enabled = true;
            cbbItemServico.Enabled = true;
            txtAliquota.Enabled = true;
            txtComissao.Enabled = true;
            txtAcrescimo.Enabled = true;
            txtDesconto.Enabled = true;
            cbbGrupo.Enabled = true;
            cbbSubGrupo.Enabled = true;
            cbbSituacao.Enabled = true;
            lblNome_Desc.Enabled = true;
            lblAsterisco1.Enabled = true;
            lblPreco.Enabled = true;
            lblAsterisco5.Enabled = true;
            lblComissao.Enabled = true;
            lblItemServico.Enabled = true;
            lblPorcentagem1.Enabled = true;
            lblPorcentagem2.Enabled = true;
            lblPorcentagem3.Enabled = true;
            lblItemServico.Enabled = true;
            btnProcurarServico.Enabled = true;
            lblAliquota.Enabled = true;
            lblAsterisco6.Enabled = true;
            lblAcrescimo.Enabled = true;
            lblDesconto.Enabled = true;
            lblSituacao.Enabled = true;
            lblAsterisco2.Enabled = true;
            cbbSituacao.Enabled = true;
            grbBox4.Enabled = true;
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
            lblTotalVendido.Enabled = false;
            txtTotalVendido.Enabled = false;
            lblFrequenciaVenda.Enabled = false;
            txtFrequenciaVenda.Enabled = false;
            lblUltAlteracaoCadastro.Enabled = false;
            mtxtDataUltAltSistema.Enabled = false;
            mtxtHorarioUltAltSistema.Enabled = false;
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
            lblTotalVendido.Enabled = true;
            txtTotalVendido.Enabled = true;
            lblFrequenciaVenda.Enabled = true;
            txtFrequenciaVenda.Enabled = true;
            lblUltAlteracaoCadastro.Enabled = true;
            mtxtDataUltAltSistema.Enabled = true;
            mtxtHorarioUltAltSistema.Enabled = true;
            btnGerarPDF.Enabled = true;
        }
        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            btnNovo.Enabled = true;
            lblCodigo.Enabled = false;
            txtCodigo.Enabled = false;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtServico.DataSource != null)
            {
                dtServico.Enabled = true;
                dtServico.Select();
            }
            lblCodigo.Enabled = false;
            txtCodigo.Enabled = false;
            txtDescricao.Enabled = false;
            txtPreco.Enabled = false;
            cbbItemServico.Enabled = false;
            txtAliquota.Enabled = false;
            txtComissao.Enabled = false;
            txtAcrescimo.Enabled = false;
            txtDesconto.Enabled = false;
            cbbGrupo.Enabled = false;
            cbbSubGrupo.Enabled = false;
            cbbSituacao.Enabled = false;
            lblCodigo.Enabled = false;
            lblNome_Desc.Enabled = false;
            lblAsterisco1.Enabled = false;
            lblPreco.Enabled = false;
            lblAsterisco5.Enabled = false;
            lblComissao.Enabled = false;
            lblItemServico.Enabled = false;
            lblPorcentagem1.Enabled = false;
            lblPorcentagem2.Enabled = false;
            lblPorcentagem3.Enabled = false;
            lblItemServico.Enabled = false;
            btnProcurarServico.Enabled = false;
            lblAliquota.Enabled = false;
            lblAsterisco6.Enabled = false;
            lblAcrescimo.Enabled = false;
            lblDesconto.Enabled = false;
            lblSituacao.Enabled = false;
            lblAsterisco2.Enabled = false;
            cbbSituacao.Enabled = false;
            grbBox4.Enabled = false;
        }

        private void FrmCadServico_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            cbbpSituacao.Visible = false;
            lblSubGrupo1.Visible = false;
            cbbpGrupo.Visible = false;
            cbbpSubGrupo.Visible = false;
            btnpProcurarSub1.Visible = false;
            btnpProcurarServico.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(312, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = true;
            txtpDescricao.Text = null;
            cbbpItemServico.Visible = false;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            cbbpSituacao.Visible = false;
            lblSubGrupo1.Visible = false;
            cbbpGrupo.Visible = false;
            cbbpSubGrupo.Visible = false;
            btnpProcurarSub1.Visible = false;
            btnpProcurarServico.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(484, 21);
            txtpCodigo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Text = null;
            cbbpItemServico.Visible = false;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            cbbpSituacao.Visible = false;
            lblSubGrupo1.Visible = false;
            cbbpGrupo.Visible = false;
            cbbpSubGrupo.Visible = false;
            btnpProcurarSub1.Visible = false;
            btnpProcurarServico.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(537, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            cbbpItemServico.Visible = false;
            btnPesquisar.Select();
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

        private void rbtnTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodos_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtPreco_Enter(object sender, EventArgs e)
        {
            txtPreco.BackColor = Color.LightBlue;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPreco.Select();
            }
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                if (txtDescricao.Text.Trim() == "" || txtPreco.Text == "" || txtAliquota.Text == "" || cbbGrupo.Text == "" || cbbSubGrupo.Text == "" || cbbSituacao.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\rCampos: [ Descrição ], [ Alíquota ], [ Grupo ], [ Sub-Grupo ],\n[ Preço ] e [ Situação ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtDescricao.Select();
                }
                else
                {
                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllServico.Sel_Servico_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dtServico.DataSource = null;
                                rbtnDescricao.Checked = true;
                                ModoPesquisa();
                                Limpar();
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                            }
                            else
                            {
                                bllServico.Alterar(txtCodigo.Text, txtDescricao.Text.Trim(), txtPreco.Text, cbbItemServico.Text, txtAliquota.Text, txtComissao.Text, txtAcrescimo.Text.Trim(), txtDesconto.Text.Trim(), cbbGrupo.Text, cbbSubGrupo.Text, cbbSituacao.Text);

                                //bllGrupo.Alterar_Descricao_SubGrupo_Grupo(txtCodigo.Text, txtDescricao.Text.Trim());

                                dtServico.DataSource = bllServico.Sel_Servico_A_Alt(txtCodigo.Text);

                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM SERVICO", "SERVICOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Serviço alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Serviço alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }

                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;

                                ModoPesquisa();

                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                //
                                if (_Formulario == 1)
                                {
                                    DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];
                                    //
                                    bllServico._Cod_Servico_Cadastro = SelectedRow.Cells[0].Value.ToString();
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
                            bllServico.Salvar(txtDescricao.Text.Trim(), txtPreco.Text, cbbItemServico.Text, txtAliquota.Text, txtComissao.Text, txtAcrescimo.Text.Trim(), txtDesconto.Text.Trim(), cbbGrupo.Text, cbbSubGrupo.Text, cbbSituacao.Text);

                            dtServico.DataSource = bllServico.Sel_Servico_A_Sal();

                            bllRegistroAtividades.Salvar("SALVOU UM SERVICO", "SERVICOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Serviço cadastrado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Serviço cadastrado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            ModoPesquisa();

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            if (_Formulario == 1)
                            {
                                DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];
                                //
                                bllServico._Cod_Servico_Cadastro = SelectedRow.Cells[0].Value.ToString();
                                //
                                this.DialogResult = DialogResult.OK;
                            }
                            //
                            tabcCadastro.SelectedTab = tabpCadastro1;
                            //
                            Ativar_Visao_Geral();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        _Comando_Atualizar = false;
                        _Inserir_Atualizar = false;
                        dtServico.DataSource = null;
                        Limpar();
                        ModoPesquisa();
                        rbtnDescricao.Checked = true;
                    }
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
                txtDescricao.Select();
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text != "")
            {
                try
                {
                    if (txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        txtDescricao.Text = null;
                        txtDescricao.Select();
                    }
                    else
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllServico.Val_Servico_Descricao_Alt(txtCodigo.Text, txtDescricao.Text) == true)
                                {
                                    MessageBox.Show("A Descrição informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtDescricao.Text = null;
                                    txtDescricao.Select();
                                }
                            }
                            else
                            {
                                if (bllServico.Val_Servico_Descricao(txtDescricao.Text) == true)
                                {
                                    MessageBox.Show("A Descrição informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtDescricao.Text = null;
                                    txtDescricao.Select();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescricao.");
                    }
                    txtDescricao.Text = null;
                }
            }
            txtDescricao.BackColor = Color.White;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                dtServico.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                dtServico.Enabled = false;
                grbBox1.Enabled = false;
                Ativar();
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Visible = true;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = true;
                txtDescricao.Select();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = true;
                Limpar();
                txtAliquota.Text = "0,00";
                cbbSituacao.Text = "ATIVO";
                tabcCadastro.SelectedTab = tabpCadastro1;
                //
                cbbItemServico.Items.Clear();
                if (bllServico.Sel_Item_Servico_Serv() == null)
                {
                    cbbItemServico.Text = null;
                }
                else
                {
                    cbbItemServico.Items.Add("");
                    foreach (DataRow dr in bllServico.Sel_Item_Servico_Serv().Rows)
                    {
                        cbbItemServico.Items.Add(dr["ncm"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
                //
                cbbGrupo.Items.Clear();
                if (bllServico.Sel_Grupo_Serv() == null)
                {
                    cbbGrupo.Text = null;
                }
                else
                {
                    cbbGrupo.Items.Add("");
                    foreach (DataRow dr in bllServico.Sel_Grupo_Serv().Rows)
                    {
                        cbbGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
                //
                cbbGrupo.Text = "5—SERVICOS NO GERAL";
                cbbSubGrupo.Text = "5—GERAL";
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
                dtServico.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                _Inserir_Atualizar = false;
                _Comando_Atualizar = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                Limpar();
            }
            else
            {
                if (dtServico.DataSource == null)
                {
                    Limpar();
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;

                }
            }
            _Inserir_Atualizar = false;
            ModoPesquisa();
            Ativar_Visao_Geral();
            tabcCadastro.SelectedTab = tabpCadastro1;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllServico.Sel_Servico_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtServico.Select();
                }
                else
                {
                    dtServico.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    Ativar();
                    btnNovo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    grbBox1.Enabled = false;
                    dtServico.Enabled = false;
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                    txtDescricao.Select();
                    _Comando_Atualizar = true;
                    _Inserir_Atualizar = true;
                    _ComboboxServico_Valor = cbbItemServico.Text;
                    _ComboboxGrupo_Valor = cbbGrupo.Text;
                    _ComboboxSubGrupo_Valor = cbbSubGrupo.Text;
                    //
                    DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];
                    //
                    cbbItemServico.Items.Clear();
                    if (bllServico.Sel_Item_Servico_Serv() == null)
                    {
                        cbbItemServico.Text = null;
                    }
                    else
                    {
                        cbbItemServico.Items.Add("");
                        foreach (DataRow dr in bllServico.Sel_Item_Servico_Serv().Rows)
                        {
                            cbbItemServico.Items.Add(dr["ncm"].ToString() + "—" + dr["descricao"].ToString());
                        }
                    }
                    //
                    if (SelectedRow.Cells[3].Value.ToString() != "0")
                    {
                        if (bllServico.Sel_ComboboxServico_Valor_A_Alterar(_ComboboxServico_Valor) != null)
                        {
                            foreach (DataRow dr in bllServico.Sel_ComboboxServico_Valor_A_Alterar(_ComboboxServico_Valor).Rows)
                            {
                                cbbItemServico.Text = dr["ncm"].ToString() + "—" + dr["descricao"].ToString();
                            }
                            _ComboboxServico_Valor = null;
                        }
                        else
                        {
                            _ComboboxServico_Valor = null;
                            cbbItemServico.Text = null;
                        }
                    }
                    //
                    if (cbbGrupo.Text != "")
                    {
                        cbbGrupo.Items.Clear();
                        if (bllServico.Sel_Grupo_Serv() == null)
                        {
                            cbbGrupo.Text = null;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllServico.Sel_Grupo_Serv().Rows)
                            {
                                cbbGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                            }
                        }
                    }
                    //
                    if (bllServico.Sel_ComboboxGrupoServ_Valor_A_Alterar(_ComboboxGrupo_Valor) != null)
                    {
                        foreach (DataRow dr in bllServico.Sel_ComboboxGrupoServ_Valor_A_Alterar(_ComboboxGrupo_Valor).Rows)
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
                    if (cbbSubGrupo.Enabled != false & cbbGrupo.Text != "")
                    {
                        cbbSubGrupo.Items.Clear();
                        if (bllServico.Sel_SubGrupo_Serv(cbbGrupo.Text) == null)
                        {
                            cbbSubGrupo.Text = null;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllServico.Sel_SubGrupo_Serv(cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
                            }
                        }

                        if (bllServico.Sel_ComboboxSubGrupoServ_Valor_A_Alterar(_ComboboxSubGrupo_Valor, cbbGrupo.Text) != null)
                        {
                            foreach (DataRow dr in bllServico.Sel_ComboboxSubGrupoServ_Valor_A_Alterar(_ComboboxSubGrupo_Valor, cbbGrupo.Text).Rows)
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
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtServico.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllServico.Sel_Servico_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtServico.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Serviço?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        if (bllServico.Sel_OS_Servico_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("Este registro está sendo utilizado por Ordem de Serviço, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            bllServico.Excluir(txtCodigo.Text);

                            bllRegistroAtividades.Salvar("EXCLUIU UM SERVICO", "SERVICOS", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Serviço excluído. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Serviço excluído. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            if (rbtnDescricao.Checked == true)
                            {
                                if (txtpDescricao.Text != "")
                                {
                                    if (bllServico.Sel_Servico_Descricao(txtpDescricao.Text, "") == null)
                                    {
                                        dtServico.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtServico.DataSource = bllServico.Sel_Servico_Descricao(txtpDescricao.Text, "");
                                        dtServico.Select();
                                    }
                                }
                                else
                                {
                                    dtServico.DataSource = null;
                                    Limpar();
                                }
                            }
                            else if (rbtnTodos.Checked == true)
                            {
                                if (bllServico.Sel_Servico_Todos("") == null)
                                {
                                    dtServico.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtServico.DataSource = bllServico.Sel_Servico_Todos("");
                                    dtServico.Select();
                                }
                            }
                            else if (rbtnGrupo.Checked == true)
                            {
                                if (cbbpGrupo.Text != "")
                                {
                                    if (cbbpGrupo.Text != "" && cbbpSubGrupo.Text == "")
                                    {
                                        if (bllServico.Sel_Serv_Grupo(cbbpGrupo.Text, "") == null)
                                        {
                                            dtServico.DataSource = null;
                                            Limpar();
                                        }
                                        else
                                        {
                                            dtServico.DataSource = bllServico.Sel_Serv_Grupo(cbbpGrupo.Text, "");
                                            dtServico.Select();
                                        }
                                    }
                                    else
                                    {
                                        if (bllServico.Sel_Serv_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "") == null)
                                        {
                                            dtServico.DataSource = null;
                                            Limpar();
                                        }
                                        else
                                        {
                                            dtServico.DataSource = bllServico.Sel_Serv_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "");
                                            dtServico.Select();
                                        }
                                    }
                                }
                                else
                                {
                                    dtServico.DataSource = null;
                                    Limpar();
                                }
                            }
                            else
                            {
                                dtServico.DataSource = null;
                                Limpar();
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        if (dtServico.DataSource != null)
                        {
                            dtServico.Select();
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
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtServico.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
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
                        if (bllServico.Sel_Servico_Descricao(txtpDescricao.Text, "") == null)
                        {
                            dtServico.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtServico.DataSource = bllServico.Sel_Servico_Descricao(txtpDescricao.Text, "");
                            dtServico.Select();
                        }
                    }
                }
                else if (rbtnItemServico.Checked == true)
                {
                    if (cbbpItemServico.Text != "")
                    {
                        if (bllServico.Sel_Servico_Item_Servico(cbbpItemServico.Text, "") == null)
                        {
                            dtServico.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtServico.DataSource = bllServico.Sel_Servico_Item_Servico(cbbpItemServico.Text, "");
                            dtServico.Select();
                        }
                    }
                }
                else if (rbtnSituacao.Checked == true)
                {
                    if (cbbpSituacao.Text != "")
                    {
                        if (bllServico.Sel_Servico_Situacao(cbbpSituacao.Text) == null)
                        {
                            dtServico.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtServico.DataSource = bllServico.Sel_Servico_Situacao(cbbpSituacao.Text);
                            dtServico.Select();
                        }
                    }
                }
                else if (rbtnGrupo.Checked == true)
                {
                    if (cbbpGrupo.Text != "")
                    {
                        if (cbbpGrupo.Text != "" && cbbpSubGrupo.Text == "")
                        {
                            if (bllServico.Sel_Serv_Grupo(cbbpGrupo.Text, "") == null)
                            {
                                dtServico.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                Limpar();
                            }
                            else
                            {
                                dtServico.DataSource = bllServico.Sel_Serv_Grupo(cbbpGrupo.Text, "");
                                dtServico.Select();
                            }
                        }
                        else
                        {
                            if (bllServico.Sel_Serv_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "") == null)
                            {
                                dtServico.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                Limpar();
                            }
                            else
                            {
                                dtServico.DataSource = bllServico.Sel_Serv_Grupo_SubGrupo(cbbpGrupo.Text, cbbpSubGrupo.Text, "");
                                dtServico.Select();
                            }
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllServico.Sel_Servico_Codigo(txtpCodigo.Text, "") == null)
                        {
                            dtServico.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtServico.DataSource = bllServico.Sel_Servico_Codigo(txtpCodigo.Text, "");
                            dtServico.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllServico.Sel_Servico_Todos("") == null)
                    {
                        dtServico.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtServico.DataSource = bllServico.Sel_Servico_Todos("");
                        dtServico.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou servico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou servico.");
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
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtServico.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
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
                txtComissao.Select();
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

        private void FrmCadServico_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadServico foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadServico foi finalizado.");
                }
                bllServico._FrmCadServico_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadServico.");
                }
            }
        }

        private void dtServico_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtServico.Columns[0].HeaderText = "Código";
            dtServico.Columns[1].HeaderText = "Descrição";
            dtServico.Columns[2].HeaderText = "Preço (R$)";
            dtServico.Columns[3].HeaderText = "Cód. Item de Serviço";
            dtServico.Columns[4].HeaderText = "Descrição de Serviço";
            dtServico.Columns[5].HeaderText = "Aliquota (%)";
            dtServico.Columns[6].HeaderText = "Comissão (%)";
            dtServico.Columns[7].HeaderText = "Acréscimo (%)";
            dtServico.Columns[8].HeaderText = "Desconto (%)";
            dtServico.Columns[9].HeaderText = "Cód. do Grupo";
            dtServico.Columns[10].HeaderText = "Descrição do Grupo";
            dtServico.Columns[11].HeaderText = "Cód. do Subg-Gupo";
            dtServico.Columns[12].HeaderText = "Descrição do Sub-Grupo";
            dtServico.Columns[13].HeaderText = "Situação";
            dtServico.Columns[14].Visible = false;

            dtServico.Columns[0].Width = 95;
            dtServico.Columns[1].Width = 325;
            dtServico.Columns[2].Width = 113;
            dtServico.Columns[3].Width = 165;
            dtServico.Columns[4].Width = 500;
            dtServico.Columns[5].Width = 113;
            dtServico.Columns[6].Width = 113;
            dtServico.Columns[7].Width = 113;
            dtServico.Columns[8].Width = 113;
            dtServico.Columns[9].Width = 150;
            dtServico.Columns[10].Width = 250;
            dtServico.Columns[11].Width = 150;
            dtServico.Columns[12].Width = 250;
            dtServico.Columns[13].Width = 150;

            dtServico.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtServico.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtServico.DefaultCellStyle.Font = new Font(dtServico.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtServico.Rows.Count;
        }

        private void dtServico_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];

                dtServico.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtServico.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                dtServico.Columns[2].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[2].DefaultCellStyle.Format = "n2";
                txtPreco.Text = Convert.ToDecimal(SelectedRow.Cells[2].Value).ToString("n2", new CultureInfo("pt-BR"));
                cbbItemServico.Items.Clear();
                if (SelectedRow.Cells[3].Value.ToString() != "0")
                {
                    cbbItemServico.Items.Add(SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString());
                    cbbItemServico.Text = SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                }
                dtServico.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[5].DefaultCellStyle.Format = "n2";
                txtAliquota.Text = Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtServico.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[6].DefaultCellStyle.Format = "n2";
                txtComissao.Text = Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtServico.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[7].DefaultCellStyle.Format = "n2";
                txtAcrescimo.Text = Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtServico.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtServico.Columns[8].DefaultCellStyle.Format = "n2";
                txtDesconto.Text = Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR"));
                cbbGrupo.Items.Clear();
                cbbGrupo.Items.Add(SelectedRow.Cells[9].Value.ToString() + "—" + SelectedRow.Cells[10].Value.ToString());
                cbbGrupo.Text = SelectedRow.Cells[9].Value.ToString() + "—" + SelectedRow.Cells[10].Value.ToString();
                cbbSubGrupo.Items.Clear();
                cbbSubGrupo.Items.Add(SelectedRow.Cells[11].Value.ToString() + "—" + SelectedRow.Cells[12].Value.ToString());
                cbbSubGrupo.Text = SelectedRow.Cells[11].Value.ToString() + "—" + SelectedRow.Cells[12].Value.ToString();
                cbbSituacao.Text = SelectedRow.Cells[13].Value.ToString();
                //
                mtxtDataCadastro.Text = SelectedRow.Cells[14].Value.ToString();
                //
                if (_Visao_Geral_Serv == true)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtServico.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtServico.DataSource = null;
                Limpar();
                ModoPesquisa();
                rbtnDescricao.Checked = true;
            }
        }

        private void Executar_Visao_Geral()
        {
            DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];
            //
            DataRow dr;
            //
            if (bllServico.Sel_Serv_Data_Hora_Ult_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllServico.Sel_Serv_Data_Hora_Ult_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[0];
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
            if (bllServico.Sel_Serv_Total_Valor_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllServico.Sel_Serv_Total_Valor_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[0];
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
            if (bllServico.Sel_Serv_Frequencia_Venda(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllServico.Sel_Serv_Frequencia_Venda(SelectedRow.Cells[0].Value.ToString()).Rows[0];
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
           
            //
            if (bllServico.Sel_Serv_Data_Hora_Ult_Alteracao(SelectedRow.Cells[0].Value.ToString()) != null)
            {
                dr = bllServico.Sel_Serv_Data_Hora_Ult_Alteracao(SelectedRow.Cells[0].Value.ToString()).Rows[0];
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
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou no botão: [ Novo ] ou no botão: [ Alterar ] e não deseja continuar nessas opções, clique no botão: [ Cancelar ].\n\n5 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, item de serviço, grupo, subgrupo situação e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtServico_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtServico.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtServico.Enabled = false;
                //
                Desativar_Visao_Geral();
            }
            else
            {
                Ativar_Visao_Geral();
                //
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                dtServico.Enabled = true;
            }
        }

        private void dtServico_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtServico.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtServico_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void btnProcurarServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbItemServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbItemServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbItemServico_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbItemServico_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarServico_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqItemServico ItemServico = new FrmPesqItemServico(cbbItemServico.Text))
            {
                if (ItemServico.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbItemServico.Items.Clear();
                        if (bllServico.Sel_Item_Servico_Serv() == null)
                        {
                            cbbItemServico.Text = null;
                        }
                        else
                        {
                            cbbItemServico.Items.Add("");
                            foreach (DataRow dr in bllServico.Sel_Item_Servico_Serv().Rows)
                            {
                                cbbItemServico.Items.Add(dr["ncm"].ToString() + "—" + dr["descricao"].ToString());
                            }
                        }
                        //
                        cbbItemServico.Text = bllServico._ItemServico_PesqItemServico_Tabela;
                        bllServico._ItemServico_PesqItemServico_Tabela = null;
                        cbbItemServico.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarServico.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarServico.");
                        }
                        cbbItemServico.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbItemServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAliquota.Select();
            }
        }

        private void rbtnItemServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnItemServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnItemServico_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpSituacao.Visible = false;
                lblSubGrupo1.Visible = false;
                ttpServico.SetToolTip(btnpProcurarServico, "Clique para pesquisar um Item de Serviço.");
                cbbpGrupo.Visible = false;
                cbbpSubGrupo.Visible = false;
                btnpProcurarSub1.Visible = false;
                btnpProcurarServico.Visible = true;
                lblPesquisar.Text = "Escolha o item de serviço:";
                lblPesquisar.Location = new Point(269, 21);
                txtpCodigo.Visible = false;
                txtpDescricao.Visible = false;
                txtpDescricao.Text = null;
                cbbpItemServico.Visible = true;
                cbbpItemServico.Select();
                cbbpItemServico.Items.Clear();
                //
                if (bllServico.Sel_Item_Servico_Serv() == null)
                {
                    cbbpItemServico.Text = null;
                }
                else
                {
                    cbbpItemServico.Items.Add("");
                    foreach (DataRow dr in bllServico.Sel_Item_Servico_Serv().Rows)
                    {
                        cbbpItemServico.Items.Add(dr["ncm"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
        }

        private void cbbpItemServico_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpItemServico_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpItemServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpItemServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurarServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurarServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurarServico_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (rbtnItemServico.Checked == true)
                {
                    using (FrmPesqItemServico ItemServico = new FrmPesqItemServico(null))
                    {
                        if (ItemServico.ShowDialog() == DialogResult.OK)
                        {

                            cbbpItemServico.Items.Clear();
                            if (bllServico.Sel_Item_Servico_Serv() == null)
                            {
                                cbbpItemServico.Text = null;
                            }
                            else
                            {
                                cbbpItemServico.Items.Add("");
                                foreach (DataRow dr in bllServico.Sel_Item_Servico_Serv().Rows)
                                {
                                    cbbpItemServico.Items.Add(dr["ncm"].ToString() + "—" + dr["descricao"].ToString());
                                }
                            }
                            //
                            cbbpItemServico.Text = bllServico._ItemServico_PesqItemServico_Tabela;
                            bllServico._ItemServico_PesqItemServico_Tabela = null;
                            cbbpItemServico.Select();

                        }
                    }
                }
                else if (rbtnGrupo.Checked == true)
                {
                    using (FrmPesqGrupo Grupo = new FrmPesqGrupo(6))
                    {
                        if (Grupo.ShowDialog() == DialogResult.OK)
                        {
                            cbbpGrupo.Items.Clear();
                            if (bllServico.Sel_Grupo_Serv() == null)
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
                                foreach (DataRow dr in bllServico.Sel_Grupo_Serv().Rows)
                                {
                                    cbbpGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                                    cbbpSubGrupo.Enabled = true;
                                    btnpProcurarSub1.Enabled = true;
                                    lblSubGrupo1.Enabled = true;
                                }
                            }
                            cbbpGrupo.Text = bllServico._Grupo_PesqGrupo_Tabela;
                            bllServico._Grupo_PesqGrupo_Tabela = null;
                            cbbpGrupo.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurarServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurarServico.");
                }
                cbbpItemServico.Text = null;
                bllServico._Grupo_PesqGrupo_Tabela = null;
                bllServico._ItemServico_PesqItemServico_Tabela = null; 
            }
            pEnabled.Enabled = true;
        }

        private void cbbpItemServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtAliquota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAliquota.Text.Contains(",") && e.KeyChar == (char)44)
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

        private void txtAliquota_Enter(object sender, EventArgs e)
        {
            txtAliquota.BackColor = Color.LightBlue;
        }

        private void txtAliquota_Leave(object sender, EventArgs e)
        {
            if (txtAliquota.Text != "")
            {
                if (txtAliquota.Text.Contains("'") || txtAliquota.Text.Contains(";") || txtAliquota.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtAliquota.Text = null;
                    txtAliquota.Select();
                }
                else
                {
                    try
                    {
                        txtAliquota.Text = Convert.ToDecimal(txtAliquota.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliquota.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliquota.");
                        }
                        txtAliquota.Text = null;
                    }
                }
            }
            txtAliquota.BackColor = Color.White;
        }

        private void dtServico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 9 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 11 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void dtServico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtComissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtComissao.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbItemServico.Select();
            }
        }

        private void txtComissao_Leave(object sender, EventArgs e)
        {
            if (txtComissao.Text != "")
            {
                if (txtComissao.Text.Contains("'") || txtComissao.Text.Contains(";") || txtComissao.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtComissao.Text = null;
                    txtComissao.Select();
                }
                else
                {
                    try
                    {
                        txtComissao.Text = Convert.ToDecimal(txtComissao.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliquota.");
                        }

                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAliquota.");
                        }
                        txtAliquota.Text = null;
                    }
                }
            }
            txtComissao.BackColor = Color.White;
        }

        private void txtComissao_Enter(object sender, EventArgs e)
        {
            txtComissao.BackColor = Color.LightBlue;
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
                txtDesconto.Select();
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
                cbbSituacao.Select();
            }
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

        private void txtAcrescimo_Enter(object sender, EventArgs e)
        {
            txtAcrescimo.BackColor = Color.LightBlue;
        }

        private void txtDesconto_Enter(object sender, EventArgs e)
        {
            txtDesconto.BackColor = Color.LightBlue;
        }

        private void rbtnGrupo_CheckedChanged(object sender, EventArgs e)
        {
            cbbpSituacao.Visible = false;
            lblSubGrupo1.Visible = true;
            ttpServico.SetToolTip(btnpProcurarServico, "Clique para pesquisar um Grupo.");
            cbbpGrupo.Visible = true;
            cbbpSubGrupo.Visible = true;
            btnpProcurarSub1.Visible = true;
            btnpProcurarServico.Visible = true;
            lblPesquisar.Text = "Escolha o grupo:";
            lblPesquisar.Location = new Point(288, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            txtpDescricao.Text = null;
            cbbpItemServico.Visible = false;
            cbbpGrupo.Select();

            try
            {
                cbbpGrupo.Items.Clear();
                cbbpSubGrupo.Items.Clear();
                if (bllServico.Sel_Grupo_Serv() == null)
                {
                    cbbpGrupo.Text = null;
                }
                else
                {
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllServico.Sel_Grupo_Serv().Rows)
                    {
                        cbbpGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
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
        }

        private void cbbpGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void cbbpSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                btnPesquisar.Select();
            }
        }

        private void cbbpGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.SelectedItem.ToString().Split('—');
                    cbbpSubGrupo.Items.Clear();
                    if (bllServico.Sel_SubGrupo_Serv(items[0]) == null)
                    {
                        cbbpSubGrupo.Text = null;
                        cbbpSubGrupo.Enabled = false;
                        btnpProcurarSub1.Enabled = false;
                        lblSubGrupo1.Enabled = false;
                    }
                    else
                    {
                        cbbpSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllServico.Sel_SubGrupo_Serv(items[0]).Rows)
                        {
                            cbbpSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
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

        private void btnpProcurarSub1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.Text.Split('—');

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 4))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbpSubGrupo.Items.Clear();
                            if (bllServico.Sel_SubGrupo_Serv(items[0]) == null)
                            {
                                cbbpSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbpSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllServico.Sel_SubGrupo_Serv(items[0]).Rows)
                                {
                                    cbbpSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
                                }
                            }
                            cbbpSubGrupo.Text = bllServico._SubGrupo_PesqSubGrupo_Tabela;
                            bllServico._SubGrupo_PesqSubGrupo_Tabela = null;
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
                        if (bllServico.Sel_SubGrupo_Serv(items[0]) == null)
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
                            foreach (DataRow dr in bllServico.Sel_SubGrupo_Serv(items[0]).Rows)
                            {
                                cbbSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
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

        private void cbbGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                if (cbbSubGrupo.Enabled == true)
                {
                    cbbSubGrupo.Select();
                }
                else
                {
                    tabcCadastro.SelectedTab = tabcCadastro4;
                }
            }
        }

        private void cbbSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                tabcCadastro.SelectedTab = tabcCadastro4;
            }
        }

        private void btnProcurar1_Click(object sender, EventArgs e)
        {
            try
            {
                pEnabled.Enabled = false;
                using (FrmPesqGrupo Grupo = new FrmPesqGrupo(6))
                {
                    if (Grupo.ShowDialog() == DialogResult.OK)
                    {
                        cbbGrupo.Items.Clear();
                        if (bllServico.Sel_Grupo_Serv() == null)
                        {
                            cbbGrupo.Text = null;
                            cbbSubGrupo.Enabled = false;
                            cbbSubGrupo.Text = null;
                            btnProcurar2.Enabled = false;
                            lblSubGrupo.Enabled = false;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllServico.Sel_Grupo_Serv().Rows)
                            {
                                cbbGrupo.Items.Add(dr["id_grupo"].ToString() + "—" + dr["descricao"].ToString());
                                cbbSubGrupo.Enabled = true;
                                btnProcurar2.Enabled = true;
                                lblSubGrupo.Enabled = true;
                            }
                        }
                        cbbGrupo.Text = bllServico._Grupo_PesqGrupo_Tabela;
                        bllServico._Grupo_PesqGrupo_Tabela = null;
                        cbbpGrupo.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurarServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurarServico.");
                }
                cbbpGrupo.Text = null;
                bllServico._Grupo_PesqGrupo_Tabela = null;
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

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 4))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbSubGrupo.Items.Clear();
                            if (bllServico.Sel_SubGrupo_Serv(items[0]) == null)
                            {
                                cbbSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllServico.Sel_SubGrupo_Serv(items[0]).Rows)
                                {
                                    cbbSubGrupo.Items.Add(dr["id_subgrupo"].ToString() + "—" + dr["descricao"].ToString());
                                }
                            }
                            cbbSubGrupo.Text = bllServico._SubGrupo_PesqSubGrupo_Tabela;
                            bllServico._SubGrupo_PesqSubGrupo_Tabela = null;
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

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbGrupo.Select();
            }
        }

        private void rbtnSituacao_CheckedChanged(object sender, EventArgs e)
        {
            lblSubGrupo1.Visible = false;
            cbbpGrupo.Visible = false;
            cbbpSubGrupo.Visible = false;
            btnpProcurarSub1.Visible = false;
            btnpProcurarServico.Visible = true;
            lblPesquisar.Text = "Escolha a situação:";
            lblPesquisar.Location = new Point(448, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            txtpDescricao.Text = null;
            cbbpItemServico.Visible = false;
            cbbpSituacao.Visible = true;
            cbbpSituacao.Select();
        }

        private void cbbpSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void tabcCadastro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tabcCadastro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tabcCadastro4_Enter(object sender, EventArgs e)
        {
            try
            {
                _Visao_Geral_Serv = true;
                //
                if (dtServico.DataSource != null & (_Inserir_Atualizar == true & _Comando_Atualizar == true))
                {
                    Executar_Visao_Geral();
                }
                else if (dtServico.DataSource != null & (_Inserir_Atualizar == false & _Comando_Atualizar == false))
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

        private void tabpCadastro1_Enter(object sender, EventArgs e)
        {
            _Visao_Geral_Serv = false;
            if (_Inserir_Atualizar == true)
            {
                txtDescricao.Select();
            }
        }

        private void picbInterrogacao5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta seção exibe uma visão geral do Serviço no sistema.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
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
                                DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];
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
                                textFormatter1.DrawString("VISÃO GERAL DO SERVIÇO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 7 + Incrementar + Margem_Topo, 198, 24));
                                textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 12 + Incrementar + Margem_Topo, 198, 24));
                                //
                                Margem_Topo = Margem_Topo - 14;
                                //
                                textFormatter2.DrawString("Serviço: " + SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 36 + Margem_Topo, 198, 7));
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
                                textFormatter2.DrawString("Total Vendido: " + Convert.ToDecimal(txtTotalVendido.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 76 + Margem_Topo, 198, 7));
                                //
                                mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                if (mtxtDataUltAltSistema.Text == "")
                                {
                                    mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: ", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 86 + Margem_Topo, 198, 7));
                                }
                                else
                                {
                                    mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: " + mtxtDataUltAltSistema.Text + " " + mtxtHorarioUltAltSistema.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 86 + Margem_Topo, 198, 7));
                                }
                                textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, 106 + Margem_Topo, 198, 16));
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
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Servico"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Servico");
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Servico\Servico.pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Servico\Servico.pdf");
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
                                DataGridViewRow SelectedRow = dtServico.Rows[dtServico.CurrentRow.Index];
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
                                textFormatter1.DrawString("VISÃO GERAL DO SERVIÇO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 10 + Margem_Topo, 595, 13));
                                textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 16 + Margem_Topo, 595, 24));
                                //
                                Margem_Topo = Margem_Topo - 14;
                                //
                                textFormatter2.DrawString("Serviço: " + SelectedRow.Cells[0].Value.ToString() + "-" + SelectedRow.Cells[1].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 47 + Margem_Topo, 595, 7));
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
                                  //
                                textFormatter2.DrawString("Total Vendido: " + Convert.ToDecimal(txtTotalVendido.Text).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 103 + Margem_Topo, 595, 7));
                                //
                                mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                if (mtxtDataUltAltSistema.Text == "")
                                {
                                    mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: ", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 117 + Margem_Topo, 595, 7));
                                }
                                else
                                {
                                    mtxtDataUltAltSistema.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                    textFormatter2.DrawString("Data e Horário da última alteração no Sistema: " + mtxtDataUltAltSistema.Text + " " + mtxtHorarioUltAltSistema.Text, fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 117 + Margem_Topo, 595, 7));
                                }
                                //
                                textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, 145 + Margem_Topo, 585, 11));
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
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Servico"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Servico");
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Servico\Servico.pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Servico\Servico.pdf");
                                }
                            }
                        }
                    }
                }
                //
                AbrirPDF.Pdf(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Servico\Servico.pdf");
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

        private void mtxtDataCadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
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

        private void mtxtHorarioUltAltSistema_KeyPress(object sender, KeyPressEventArgs e)
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
                btnSalvar.Select();
            }
        }
    }
}
