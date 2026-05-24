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
    public partial class FrmCadFormaPagamento : Form
    {
        public FrmCadFormaPagamento(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
        }

        private bool _Comando_Atualizar;
        private bool _Inserir_Atualizar;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _ComboboxEntBancaria_Valor = null;
        private byte _Formulario;

        private void FrmCadFormaPagamento_Load(object sender, EventArgs e)
        {
            try
            {
                bllFormaPagamento._FrmCadFormaPagamento_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFormaPagamento iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFormaPagamento iniciado.");
                }
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
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFormaPagamento.");
                }
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtDescricao.Text = null;
            txtJurosPorc.Text = null;
            txtParcela.Text = null;
            txtPrimeiroPagamento.Text = null;
            txtEntradaPorc.Text = null;
            txtAcrescimoFixoPorc.Text = null;
            cbbTipo.Text = null;
            txtJurosAtrasoPorc.Text = null;
            txtDescontoFixoPorc.Text = null;
            cbbTipoOp.Text = null;
            txtDesconto.Text = null;
            txtDuracaoDesconto.Text = null;
        }

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            lblCodigo.Enabled = false;
            txtCodigo.Enabled = false;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtFormaPagamento.DataSource != null)
            {
                dtFormaPagamento.Enabled = true;
                dtFormaPagamento.Select();
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

        private void rbtnFormaPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnFormaPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTodas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodas_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadFormaPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllFormaPagamento._FrmCadFormaPagamento_Ativo = false;
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFormaPagamento foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFormaPagamento foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFormaPagamento.");
                }
            }
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadFormaPagamento_KeyUp(object sender, KeyEventArgs e)
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

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Text = null;
                txtDescricao.Select();
            }
            else
            {
                try
                {
                    if (txtDescricao.Text != "")
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllFormaPagamento.Sel_Forma_Descricao_Alt(txtCodigo.Text, txtDescricao.Text) == true)
                                {
                                    MessageBox.Show("A Descrição informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtDescricao.Text = null;
                                    txtDescricao.Select();
                                }
                            }
                            else
                            {
                                if (bllFormaPagamento.Sel_Forma_Descricao(txtDescricao.Text) == true)
                                {
                                    MessageBox.Show("A Descrição informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtJuros_Enter(object sender, EventArgs e)
        {
            txtJurosPorc.BackColor = Color.LightBlue;
        }

        private void txtJuros_Leave(object sender, EventArgs e)
        {
            if (txtJurosPorc.Text.Contains("'") || txtJurosPorc.Text.Contains(";") || txtJurosPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJurosPorc.Text = null;
                txtJurosPorc.Select();
            }
            else
            {
                if (txtJurosPorc.Text != "")
                {
                    try
                    {
                        txtJurosPorc.Text = Convert.ToDecimal(txtJurosPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtEntrada_Enter(object sender, EventArgs e)
        {
            txtEntradaPorc.BackColor = Color.LightBlue;
        }

        private void txtEntrada_Leave(object sender, EventArgs e)
        {
            if (txtEntradaPorc.Text.Contains("'") || txtEntradaPorc.Text.Contains(";") || txtEntradaPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEntradaPorc.Text = null;
                txtEntradaPorc.Select();
            }
            else
            {
                if (txtEntradaPorc.Text != "")
                {
                    try
                    {
                        txtEntradaPorc.Text = Convert.ToDecimal(txtEntradaPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtEntradaPorc.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtEntradaPorc.");
                        }
                        txtEntradaPorc.Text = null;
                    }
                }
            }
            txtEntradaPorc.BackColor = Color.White;
        }

        private void txtParcela_Enter(object sender, EventArgs e)
        {
            txtParcela.BackColor = Color.LightBlue;
        }

        private void txtParcela_Leave(object sender, EventArgs e)
        {
            if (txtParcela.Text.Contains("'") || txtParcela.Text.Contains(";") || txtParcela.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtParcela.Text = null;
                txtParcela.Select();
            }
            txtParcela.BackColor = Color.White;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbTipoOp.SelectedIndex == 0)
                {
                    txtDescontoFixoPorc.Select();
                }
                else
                {
                    btnSalvar.Select();
                }
            }
        }

        private void txtJuros_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEntrada_KeyPress(object sender, KeyPressEventArgs e)
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
                txtDescontoFixoPorc.Select();
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

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpDescricao.Text = null;
                txtpDescricao.Select();
            }
            txtpDescricao.BackColor = Color.White;
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpPalavraChave.Text = null;
                txtpPalavraChave.Select();
            }
            txtpPalavraChave.BackColor = Color.White;
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

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            if (txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpCodigo.Text = null;
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
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

        private void cbbpTipoPagamento_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoPagamento_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtpDescricao.Visible = true;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            cbbpTipoPagamento.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(397, 19);
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = true;
            cbbpTipoPagamento.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(602, 19);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnFormaPagamento_CheckedChanged(object sender, EventArgs e)
        {
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            cbbpTipoPagamento.Visible = true;
            lblPesquisar.Text = "Escolha o tipo de pagamento:";
            lblPesquisar.Location = new Point(423, 19);
            cbbpTipoPagamento.Text = null;
            cbbpTipoPagamento.Select();
        }

        private void rbtnTodas_CheckedChanged(object sender, EventArgs e)
        {
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            cbbpTipoPagamento.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(613, 19);
            btnPesquisar.Select();
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, tipo de pagamento e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você altera os dados já cadastrados no sistema clicando na caixa de texto em que você deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ].\n\n5 - Simular: Clique para simular a forma de pagamento selecionada.\n\n6 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPrimeiroPagamento_Enter(object sender, EventArgs e)
        {
            txtPrimeiroPagamento.BackColor = Color.LightBlue;
        }

        private void txtPrimeiroPagamento_Leave(object sender, EventArgs e)
        {
            if (txtPrimeiroPagamento.Text.Contains("'") || txtPrimeiroPagamento.Text.Contains(";") || txtPrimeiroPagamento.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrimeiroPagamento.Text = null;
                txtPrimeiroPagamento.Select();
            }
            txtPrimeiroPagamento.BackColor = Color.White;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodas.Checked == true)
                {
                    if (bllFormaPagamento.Sel_Forma_Pagar_Todos("", true) == null)
                    {
                        dtFormaPagamento.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_Todos("", true);
                        dtFormaPagamento.Select();
                    }
                }
                else if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllFormaPagamento.Sel_Forma_Pagar_Descricao(txtpDescricao.Text, "", true) == null)
                        {
                            dtFormaPagamento.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_Descricao(txtpDescricao.Text, "", true);
                            dtFormaPagamento.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllFormaPagamento.Sel_Forma_Pagar_Codigo(txtpCodigo.Text, "", true) == null)
                        {
                            dtFormaPagamento.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_Codigo(txtpCodigo.Text, "", true);
                            dtFormaPagamento.Select();
                        }
                    }
                }
                else if (rbtnTipoJuro.Checked == true)
                {
                    if (cbbpTipoPagamento.Text != "")
                    {
                        if (bllFormaPagamento.Sel_Forma_Tipo_Pagamento(cbbpTipoPagamento.Text, "", true) == null)
                        {
                            dtFormaPagamento.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Tipo_Pagamento(cbbpTipoPagamento.Text, "", true);
                            dtFormaPagamento.Select();
                        }
                    }
                }
                // 
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou forma de pagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou forma de pagamento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtFormaPagamento.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
            }
        }

        private void txtPrimeiroPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtJurosPorc.Select();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtFormaPagamento.DefaultCellStyle.SelectionBackColor = Color.White;
            dtFormaPagamento.Enabled = false;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            Limpar();
            _Inserir_Atualizar = true;
            //
            try
            {
                cbbEntBanc.Items.Clear();
                if (bllFormaPagamento.Sel_Entidade_Bancaria_Forma_Pagamento() == null)
                {
                    cbbEntBanc.Enabled = false;
                    cbbEntBanc.Text = null;
                }
                else
                {
                    cbbEntBanc.Enabled = true;
                    btnProcurarEntBanc.Enabled = true;
                    cbbEntBanc.Items.Add("");
                    foreach (DataRow dr in bllFormaPagamento.Sel_Entidade_Bancaria_Forma_Pagamento().Rows)
                    {
                        cbbEntBanc.Items.Add((dr["id_ent_bancaria"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbTipoOp.Text = "ENTRADA";
                cbbTipo.Text = "DINHEIRO";
                cbbTipo_SelectedIndexChanged(sender, e);
                cbbTipo.Select();
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
                dtFormaPagamento.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxEntBancaria_Valor = null;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllFormaPagamento.Sel_Forma_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtFormaPagamento.Select();
                }
                else
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];

                    dtFormaPagamento.DefaultCellStyle.SelectionBackColor = Color.White;
                    dtFormaPagamento.Enabled = false;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnCancelar.Visible = true;
                    lblCodigo.Enabled = true;
                    txtCodigo.Enabled = true;
                    btnNovo.Enabled = false;
                    btnSalvar.Enabled = true;
                    txtCodigo.Enabled = true;
                    cbbTipo.Select();
                    _Inserir_Atualizar = true;
                    _Comando_Atualizar = true;
                    //
                    _ComboboxEntBancaria_Valor = cbbEntBanc.Text;
                    //
                    cbbEntBanc.Items.Clear();
                    if (bllFormaPagamento.Sel_Entidade_Bancaria_Forma_Pagamento() == null)
                    {
                        cbbEntBanc.Text = null;
                    }
                    else
                    {
                        cbbEntBanc.Items.Add("");
                        foreach (DataRow dr in bllFormaPagamento.Sel_Entidade_Bancaria_Forma_Pagamento().Rows)
                        {
                            cbbEntBanc.Items.Add((dr["id_ent_bancaria"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    //
                    if (SelectedRow.Cells[11].Value.ToString() != "0")
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dtFormaPagamento.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (txtDescricao.Text.Trim() == "" || cbbTipo.Text == "" || txtParcela.Text.Trim() == "" || txtParcela.Text.Trim() == "0" || cbbTipoOp.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n [ Tipo ], [ Tipo de Pagamento ], [ Descrição ] e [ Parcela(s) ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbbTipo.Select();
                }
                else
                {
                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllFormaPagamento.Sel_Forma_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                dtFormaPagamento.DataSource = null;
                                rbtnDescricao.Checked = true;
                                ModoPesquisa();
                                Limpar();
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                            }
                            else
                            {
                                bllFormaPagamento.Alterar(txtCodigo.Text, txtDescricao.Text.Trim(), txtJurosPorc.Text.Trim(), txtEntradaPorc.Text.Trim(), txtParcela.Text.Trim(), txtPrimeiroPagamento.Text.Trim(), cbbTipo.Text, txtJurosAtrasoPorc.Text.Trim(), txtDescontoFixoPorc.Text.Trim(), txtAcrescimoFixoPorc.Text.Trim(), cbbEntBanc.Text, cbbTipoOp.Text, txtDesconto.Text, txtDuracaoDesconto.Text);

                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UMA FORMA DE PAGAMENTO", "FORMAS DE PAGAMENTO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                                dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_A_Alt(txtCodigo.Text);

                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Forma alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Forma alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }

                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;

                                ModoPesquisa();

                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (_Formulario == 1)
                                {
                                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                                    //
                                    bllFormaPagamento._Cod_Forma_Pagamento_Cadastro = SelectedRow.Cells[0].Value.ToString();
                                    //
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                        }
                        else
                        {
                            bllFormaPagamento.Salvar(txtDescricao.Text.Trim(), txtJurosPorc.Text.Trim(), txtEntradaPorc.Text.Trim(), txtParcela.Text.Trim(), txtPrimeiroPagamento.Text.Trim(), cbbTipo.Text, txtJurosAtrasoPorc.Text.Trim(), txtDescontoFixoPorc.Text.Trim(), txtAcrescimoFixoPorc.Text.Trim(), cbbEntBanc.Text, cbbTipoOp.Text, txtDesconto.Text.Trim(), txtDuracaoDesconto.Text.Trim());

                            dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_A_Sal();

                            bllRegistroAtividades.Salvar("SALVOU UMA FORMA DE PAGAMENTO", "FORMAS DE PAGAMENTO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Forma cadstrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Forma cadstrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            ModoPesquisa();
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            if (_Formulario == 1)
                            {
                                DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                                //
                                bllFormaPagamento._Cod_Forma_Pagamento_Cadastro = SelectedRow.Cells[0].Value.ToString();
                                //
                                this.DialogResult = DialogResult.OK;
                            }
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
                        dtFormaPagamento.DataSource = null;
                        rbtnDescricao.Checked = true;
                        ModoPesquisa();
                        Limpar();
                        _Comando_Atualizar = false;
                        _Inserir_Atualizar = false;
                    }
                }
            }
            else
            {
                cbbTipo.Select();
            }
        }

        private void dtFormaPagamento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtFormaPagamento.Rows[e.RowIndex];
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                cbbTipo.Text = SelectedRow.Cells[2].Value.ToString();
                dtFormaPagamento.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[3].DefaultCellStyle.Format = "n2";
                txtEntradaPorc.Text = Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtFormaPagamento.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[4].DefaultCellStyle.Format = "n2";
                txtDescontoFixoPorc.Text = Convert.ToDecimal(SelectedRow.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtFormaPagamento.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[5].DefaultCellStyle.Format = "n2";
                txtAcrescimoFixoPorc.Text = Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtFormaPagamento.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[6].DefaultCellStyle.Format = "n2";
                txtJurosPorc.Text = Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR"));
                dtFormaPagamento.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[7].DefaultCellStyle.Format = "n2";
                txtJurosAtrasoPorc.Text = Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR"));
                txtParcela.Text = SelectedRow.Cells[8].Value.ToString();
                txtPrimeiroPagamento.Text = SelectedRow.Cells[9].Value.ToString();
                cbbEntBanc.Items.Clear();
                if (SelectedRow.Cells[11].Value.ToString() != "0")
                {
                    cbbEntBanc.Items.Add(SelectedRow.Cells[11].Value.ToString() + "—" + SelectedRow.Cells[12].Value.ToString());
                    cbbEntBanc.Text = SelectedRow.Cells[11].Value.ToString() + "—" + SelectedRow.Cells[12].Value.ToString();
                }
                cbbTipoOp.Text = SelectedRow.Cells[13].Value.ToString();
                dtFormaPagamento.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[14].DefaultCellStyle.Format = "n2";
                txtDesconto.Text = Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR"));
                txtDuracaoDesconto.Text = SelectedRow.Cells[15].Value.ToString();

                dtFormaPagamento.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtFormaPagamento.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                {
                    btnSimular.Enabled = true;
                }
                else
                {
                    btnSimular.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtFormaPagamento.");
                }
                dtFormaPagamento.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
            }
        }

        private void dtFormaPagamento_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFormaPagamento.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtFormaPagamento.Enabled = false;
                btnSimular.Enabled = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                dtFormaPagamento.Enabled = true;
                btnSimular.Enabled = true;
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

        private void dtFormaPagamento_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtFormaPagamento.Columns[0].HeaderText = "Código";
            dtFormaPagamento.Columns[1].HeaderText = "Descrição";
            dtFormaPagamento.Columns[2].HeaderText = "Tipo de Pagamento";
            dtFormaPagamento.Columns[3].HeaderText = "Entrada (%)";
            dtFormaPagamento.Columns[4].HeaderText = "Desconto Fixo (%)";
            dtFormaPagamento.Columns[5].HeaderText = "Acréscimo Fixo (%)";
            dtFormaPagamento.Columns[6].HeaderText = "Multa (%)";
            dtFormaPagamento.Columns[7].HeaderText = "Juros Mora (%)";
            dtFormaPagamento.Columns[8].HeaderText = "Parcela(s)";
            dtFormaPagamento.Columns[9].HeaderText = "Prazo para Primeiro Pagamento (Dias)";
            dtFormaPagamento.Columns[10].Visible = false;
            dtFormaPagamento.Columns[11].HeaderText = "Cód. da Ent. Bancária";
            dtFormaPagamento.Columns[12].HeaderText = "Descrição da Entidade Bancária";
            dtFormaPagamento.Columns[13].HeaderText = "Tipo";
            dtFormaPagamento.Columns[14].HeaderText = "Desconto (%)";
            dtFormaPagamento.Columns[15].HeaderText = "Duração do Desconto (Dias)";


            dtFormaPagamento.Columns[0].Width = 85;
            dtFormaPagamento.Columns[1].Width = 325;
            dtFormaPagamento.Columns[2].Width = 175;
            dtFormaPagamento.Columns[3].Width = 150;
            dtFormaPagamento.Columns[4].Width = 150;
            dtFormaPagamento.Columns[5].Width = 150;
            dtFormaPagamento.Columns[6].Width = 150;
            dtFormaPagamento.Columns[7].Width = 150;
            dtFormaPagamento.Columns[8].Width = 95;
            dtFormaPagamento.Columns[9].Width = 220;
            dtFormaPagamento.Columns[11].Width = 150;
            dtFormaPagamento.Columns[12].Width = 325;
            dtFormaPagamento.Columns[13].Width = 150;
            dtFormaPagamento.Columns[14].Width = 150;
            dtFormaPagamento.Columns[15].Width = 220;

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
            dtFormaPagamento.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblRegistros.Text = "Registros: " + dtFormaPagamento.Rows.Count;
        }

        private void dtFormaPagamento_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                Limpar();
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            else
            {
                if (dtFormaPagamento.DataSource == null)
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
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllFormaPagamento.Sel_Forma_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtFormaPagamento.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir esta Forma de Pagamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllFormaPagamento.Sel_Forma_Pagamento_Conta_Pagar_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("A Forma de Pagamento selecionada está sendo utilizada por uma Conta a Pagar, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFormaPagamento.Select();
                        }
                        else if (bllFormaPagamento.Sel_Forma_Pagamento_Venda_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("A Forma de Pagamento selecionada está sendo utilizada por uma Venda, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFormaPagamento.Select();
                        }
                        else if (bllFormaPagamento.Sel_Forma_Pagamento_Conta_Receber_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("A Forma de Pagamento selecionada está sendo utilizada por uma Conta a Receber, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFormaPagamento.Select();
                        }
                        else if (bllFormaPagamento.Sel_Forma_Pagamento_Devolucao_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("A Forma de Pagamento selecionada está sendo utilizada por uma Devolução, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFormaPagamento.Select();
                        }
                        else if (bllFormaPagamento.Sel_Forma_Pagamento_DFe_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("A Forma de Pagamento selecionada está sendo utilizada por um DFe, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtFormaPagamento.Select();
                        }
                        else
                        {
                            bllFormaPagamento.Excluir(txtCodigo.Text);
                            //
                            bllRegistroAtividades.Salvar("EXCLUIU UMA FORMA DE PAGAMENTO", "FORMAS DE PAGAMENTO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Forma excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Forma excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            if (rbtnTodas.Checked == true)
                            {
                                if (bllFormaPagamento.Sel_Forma_Pagar_Todos("", true) == null)
                                {
                                    dtFormaPagamento.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_Todos("", true);
                                    dtFormaPagamento.Select();
                                }
                            }
                            else if (rbtnDescricao.Checked == true)
                            {
                                if (txtpDescricao.Text != "")
                                {
                                    if (bllFormaPagamento.Sel_Forma_Pagar_Descricao(txtpDescricao.Text, "", true) == null)
                                    {
                                        dtFormaPagamento.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_Descricao(txtpDescricao.Text, "", true);
                                        dtFormaPagamento.Select();
                                    }
                                }
                                else
                                {
                                    dtFormaPagamento.DataSource = null;
                                    Limpar();
                                }
                            }
                            else if (rbtnTipoJuro.Checked == true)
                            {
                                if (cbbpTipoPagamento.Text != "")
                                {
                                    if (bllFormaPagamento.Sel_Forma_Tipo_Pagamento(cbbpTipoPagamento.Text, "", true) == null)
                                    {
                                        dtFormaPagamento.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Tipo_Pagamento(cbbpTipoPagamento.Text, "", true);
                                        dtFormaPagamento.Select();
                                    }
                                }
                                else
                                {
                                    dtFormaPagamento.DataSource = null;
                                    Limpar();
                                }
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        if (dtFormaPagamento.DataSource != null)
                        {
                            dtFormaPagamento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                dtFormaPagamento.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
            }
        }

        private void cbbTipo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void cbbTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtJurosAtrasoPorc_Enter(object sender, EventArgs e)
        {
            txtJurosAtrasoPorc.BackColor = Color.LightBlue;
        }

        private void txtJurosAtrasoPorc_Leave(object sender, EventArgs e)
        {
            if (txtJurosAtrasoPorc.Text.Contains("'") || txtJurosAtrasoPorc.Text.Contains(";") || txtJurosAtrasoPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJurosAtrasoPorc.Text = null;
                txtJurosAtrasoPorc.Select();
            }
            else
            {
                if (txtJurosAtrasoPorc.Text != "")
                {
                    try
                    {
                        txtJurosAtrasoPorc.Text = Convert.ToDecimal(txtJurosAtrasoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtJurosPorc.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtJurosPorc.");
                        }
                        txtJurosAtrasoPorc.Text = null;
                    }
                }
            }
            txtJurosAtrasoPorc.BackColor = Color.White;
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
                txtDesconto.Select();
            }
        }

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                if (cbbTipo.SelectedIndex == 0)
                {
                    txtParcela.Text = "1";
                    lblParcela.Enabled = false;
                    txtParcela.Enabled = false;
                    lblEntrada.Enabled = false;
                    txtEntradaPorc.Enabled = false;
                    txtEntradaPorc.Text = "0,00";
                    if (cbbTipoOp.SelectedIndex == 0)
                    {
                        lblDescontoFixo.Enabled = true;
                        txtDescontoFixoPorc.Enabled = true;
                        txtAcrescimoFixoPorc.Enabled = true;
                        label5.Enabled = true;
                        lblPorcentagem5.Enabled = true;
                        lblPorcentagem6.Enabled = true;
                    }
                    else
                    {
                        lblDescontoFixo.Enabled = false;
                        txtDescontoFixoPorc.Enabled = false;
                        txtAcrescimoFixoPorc.Enabled = false;
                        label5.Enabled = false;
                        lblPorcentagem5.Enabled = false;
                        lblPorcentagem6.Enabled = false;
                    }
                    txtPrimeiroPagamento.Text = "0";
                    lblPrimeiroPagamento.Enabled = false;
                    txtPrimeiroPagamento.Enabled = false;
                    lblJuros.Enabled = false;
                    txtJurosPorc.Enabled = false;
                    txtJurosPorc.Text = "0,00";
                    lblJurosAtraso.Enabled = false;
                    txtJurosAtrasoPorc.Enabled = false;
                    txtJurosAtrasoPorc.Text = "0,00";
                    lblDias.Enabled = false;
                    lblPorcentagem2.Enabled = false;
                    lblPorcentagem3.Enabled = false;
                    label2.Enabled = false;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    label3.Enabled = false;
                    txtDesconto.Enabled = false;
                    lblPorcentagem4.Enabled = false;
                    lblDesconto.Enabled = false;
                    lblDuracaoDesconto.Enabled = false;
                    label11.Enabled = false;
                    txtDuracaoDesconto.Enabled = false;
                    lblDias1.Enabled = false;
                }
                else if (cbbTipo.SelectedIndex == 1)
                {
                    txtParcela.Text = "1";
                    lblParcela.Enabled = false;
                    txtParcela.Enabled = false;
                    lblEntrada.Enabled = false;
                    txtEntradaPorc.Enabled = false;
                    txtEntradaPorc.Text = "0,00";
                    if (cbbTipoOp.SelectedIndex == 0)
                    {
                        lblDescontoFixo.Enabled = true;
                        txtDescontoFixoPorc.Enabled = true;
                        txtAcrescimoFixoPorc.Enabled = true;
                        label5.Enabled = true;
                        lblPorcentagem5.Enabled = true;
                        lblPorcentagem6.Enabled = true;
                    }
                    else
                    {
                        lblDescontoFixo.Enabled = false;
                        txtDescontoFixoPorc.Enabled = false;
                        txtAcrescimoFixoPorc.Enabled = false;
                        label5.Enabled = false;
                        lblPorcentagem5.Enabled = false;
                        lblPorcentagem6.Enabled = false;
                    }
                    txtPrimeiroPagamento.Text = "0";
                    lblPrimeiroPagamento.Enabled = false;
                    txtPrimeiroPagamento.Enabled = false;
                    lblJuros.Enabled = false;
                    txtJurosPorc.Enabled = false;
                    txtJurosPorc.Text = "0,00";
                    lblJurosAtraso.Enabled = false;
                    txtJurosAtrasoPorc.Enabled = false;
                    txtJurosAtrasoPorc.Text = "0,00";
                    lblDias.Enabled = false;
                    lblPorcentagem2.Enabled = false;
                    lblPorcentagem3.Enabled = false;
                    label2.Enabled = false;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    label3.Enabled = false;
                    txtDesconto.Enabled = false;
                    lblPorcentagem4.Enabled = false;
                    lblDesconto.Enabled = false;
                    lblDuracaoDesconto.Enabled = false;
                    label11.Enabled = false;
                    txtDuracaoDesconto.Enabled = false;
                    lblDias1.Enabled = false;
                }
                else if (cbbTipo.SelectedIndex == 2)
                {
                    txtParcela.Text = "1";
                    lblParcela.Enabled = false;
                    txtParcela.Enabled = false;
                    lblEntrada.Enabled = false;
                    txtEntradaPorc.Enabled = false;
                    txtEntradaPorc.Text = "0,00";
                    if (cbbTipoOp.SelectedIndex == 0)
                    {
                        lblDescontoFixo.Enabled = true;
                        txtDescontoFixoPorc.Enabled = true;
                        txtAcrescimoFixoPorc.Enabled = true;
                        label5.Enabled = true;
                        lblPorcentagem5.Enabled = true;
                        lblPorcentagem6.Enabled = true;
                    }
                    else
                    {
                        lblDescontoFixo.Enabled = false;
                        txtDescontoFixoPorc.Enabled = false;
                        txtAcrescimoFixoPorc.Enabled = false;
                        label5.Enabled = false;
                        lblPorcentagem5.Enabled = false;
                        lblPorcentagem6.Enabled = false;
                    }
                    txtPrimeiroPagamento.Text = "0";
                    lblPrimeiroPagamento.Enabled = false;
                    txtPrimeiroPagamento.Enabled = false;
                    lblJuros.Enabled = false;
                    txtJurosPorc.Enabled = false;
                    txtJurosPorc.Text = "0,00";
                    lblJurosAtraso.Enabled = false;
                    txtJurosAtrasoPorc.Enabled = false;
                    txtJurosAtrasoPorc.Text = "0,00";
                    lblDias.Enabled = false;
                    lblPorcentagem2.Enabled = false;
                    lblPorcentagem3.Enabled = false;
                    label2.Enabled = false;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    label3.Enabled = false;
                    txtDesconto.Enabled = false;
                    lblPorcentagem4.Enabled = false;
                    lblDesconto.Enabled = false;
                    lblDuracaoDesconto.Enabled = false;
                    label11.Enabled = false;
                    txtDuracaoDesconto.Enabled = false;
                    lblDias1.Enabled = false;
                }
                else if (cbbTipo.SelectedIndex == 3)
                {
                    if (cbbTipoOp.SelectedIndex == 1)
                    {
                        MessageBox.Show("Não é possível selecionar [ Nota Promissória ] para\n[ Saída ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipo.SelectedIndex = 0;
                    }
                    else
                    {
                        txtParcela.Text = "1";
                        lblParcela.Enabled = true;
                        txtParcela.Enabled = true;
                        lblEntrada.Enabled = true;
                        txtEntradaPorc.Enabled = true;
                        txtEntradaPorc.Text = null;
                        if (cbbTipoOp.SelectedIndex == 0)
                        {
                            lblDescontoFixo.Enabled = true;
                            txtDescontoFixoPorc.Enabled = true;
                            txtAcrescimoFixoPorc.Enabled = true;
                            label5.Enabled = true;
                            lblPorcentagem5.Enabled = true;
                            lblPorcentagem6.Enabled = true;
                        }
                        else
                        {
                            lblDescontoFixo.Enabled = false;
                            txtDescontoFixoPorc.Enabled = false;
                            txtAcrescimoFixoPorc.Enabled = false;
                            label5.Enabled = false;
                            lblPorcentagem5.Enabled = false;
                            lblPorcentagem6.Enabled = false;
                        }
                        txtPrimeiroPagamento.Text = null;
                        lblPrimeiroPagamento.Enabled = true;
                        txtPrimeiroPagamento.Enabled = true;
                        lblJuros.Enabled = true;
                        txtJurosPorc.Enabled = true;
                        txtJurosPorc.Text = "2,00";
                        lblJurosAtraso.Enabled = true;
                        txtJurosAtrasoPorc.Enabled = true;
                        txtJurosAtrasoPorc.Text = "1,00";
                        lblDias.Enabled = true;
                        lblPorcentagem2.Enabled = true;
                        lblPorcentagem3.Enabled = true;
                        label2.Enabled = true;
                        lblDescricao.Enabled = true;
                        txtDescricao.Enabled = true;
                        label3.Enabled = true;
                        txtPrimeiroPagamento.Text = "30";
                        txtDesconto.Enabled = true;
                        lblPorcentagem4.Enabled = true;
                        lblDesconto.Enabled = true;
                        lblDuracaoDesconto.Enabled = true;
                        label11.Enabled = true;
                        txtDuracaoDesconto.Enabled = true;
                        lblDias1.Enabled = true;
                    }
                }
                else if (cbbTipo.SelectedIndex == 4)
                {
                    txtParcela.Text = "1";
                    lblParcela.Enabled = false;
                    txtParcela.Enabled = false;
                    lblEntrada.Enabled = false;
                    txtEntradaPorc.Enabled = false;
                    txtEntradaPorc.Text = "0,00";
                    if (cbbTipoOp.SelectedIndex == 0)
                    {
                        lblDescontoFixo.Enabled = true;
                        txtDescontoFixoPorc.Enabled = true;
                        txtAcrescimoFixoPorc.Enabled = true;
                        label5.Enabled = true;
                        lblPorcentagem5.Enabled = true;
                        lblPorcentagem6.Enabled = true;
                    }
                    else
                    {
                        lblDescontoFixo.Enabled = false;
                        txtDescontoFixoPorc.Enabled = false;
                        txtAcrescimoFixoPorc.Enabled = false;
                        label5.Enabled = false;
                        lblPorcentagem5.Enabled = false;
                        lblPorcentagem6.Enabled = false;
                    }
                    txtPrimeiroPagamento.Text = "0";
                    lblPrimeiroPagamento.Enabled = false;
                    txtPrimeiroPagamento.Enabled = false;
                    lblJuros.Enabled = false;
                    txtJurosPorc.Enabled = false;
                    txtJurosPorc.Text = "0,00";
                    lblJurosAtraso.Enabled = false;
                    txtJurosAtrasoPorc.Enabled = false;
                    txtJurosAtrasoPorc.Text = "0,00";
                    lblPorcentagem1.Enabled = false;
                    lblDias.Enabled = false;
                    lblPorcentagem2.Enabled = false;
                    lblPorcentagem3.Enabled = false;
                    label2.Enabled = false;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    label3.Enabled = false;
                    txtDesconto.Enabled = false;
                    lblPorcentagem4.Enabled = false;
                    lblDesconto.Enabled = false;
                    lblDuracaoDesconto.Enabled = false;
                    label11.Enabled = false;
                    txtDuracaoDesconto.Enabled = false;
                    lblDias1.Enabled = false;
                }
                else if (cbbTipo.SelectedIndex == 5)
                {
                    txtParcela.Text = "1";
                    lblParcela.Enabled = false;
                    txtParcela.Enabled = false;
                    lblEntrada.Enabled = false;
                    txtEntradaPorc.Enabled = false;
                    txtEntradaPorc.Text = "0,00";
                    if (cbbTipoOp.SelectedIndex == 0)
                    {
                        lblDescontoFixo.Enabled = true;
                        txtDescontoFixoPorc.Enabled = true;
                        txtAcrescimoFixoPorc.Enabled = true;
                        label5.Enabled = true;
                        lblPorcentagem5.Enabled = true;
                        lblPorcentagem6.Enabled = true;
                    }
                    else
                    {
                        lblDescontoFixo.Enabled = false;
                        txtDescontoFixoPorc.Enabled = false;
                        txtAcrescimoFixoPorc.Enabled = false;
                        label5.Enabled = false;
                        lblPorcentagem5.Enabled = false;
                        lblPorcentagem6.Enabled = false;
                    }
                    txtPrimeiroPagamento.Text = "0";
                    lblPrimeiroPagamento.Enabled = false;
                    txtPrimeiroPagamento.Enabled = false;
                    lblJuros.Enabled = false;
                    txtJurosPorc.Enabled = false;
                    txtJurosPorc.Text = "0,00";
                    lblJurosAtraso.Enabled = false;
                    txtJurosAtrasoPorc.Enabled = false;
                    txtJurosAtrasoPorc.Text = "0,00";
                    lblPorcentagem1.Enabled = false;
                    lblDias.Enabled = false;
                    lblPorcentagem2.Enabled = false;
                    lblPorcentagem3.Enabled = false;
                    label2.Enabled = false;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    label3.Enabled = false;
                    txtDesconto.Enabled = false;
                    lblPorcentagem4.Enabled = false;
                    lblDesconto.Enabled = false;
                    lblDuracaoDesconto.Enabled = false;
                    label11.Enabled = false;
                    txtDuracaoDesconto.Enabled = false;
                    lblDias1.Enabled = false;
                }
                else if (cbbTipo.SelectedIndex == 6)
                {
                    txtParcela.Text = "1";
                    lblParcela.Enabled = false;
                    txtParcela.Enabled = false;
                    lblEntrada.Enabled = false;
                    txtEntradaPorc.Enabled = false;
                    txtEntradaPorc.Text = "0,00";
                    if (cbbTipoOp.SelectedIndex == 0)
                    {
                        lblDescontoFixo.Enabled = true;
                        txtDescontoFixoPorc.Enabled = true;
                        txtAcrescimoFixoPorc.Enabled = true;
                        label5.Enabled = true;
                        lblPorcentagem5.Enabled = true;
                        lblPorcentagem6.Enabled = true;
                    }
                    else
                    {
                        lblDescontoFixo.Enabled = false;
                        txtDescontoFixoPorc.Enabled = false;
                        txtAcrescimoFixoPorc.Enabled = false;
                        label5.Enabled = false;
                        lblPorcentagem5.Enabled = false;
                        lblPorcentagem6.Enabled = false;
                    }
                    txtPrimeiroPagamento.Text = "0";
                    lblPrimeiroPagamento.Enabled = false;
                    txtPrimeiroPagamento.Enabled = false;
                    lblJuros.Enabled = false;
                    txtJurosPorc.Enabled = false;
                    txtJurosPorc.Text = "0,00";
                    lblJurosAtraso.Enabled = false;
                    txtJurosAtrasoPorc.Enabled = false;
                    txtJurosAtrasoPorc.Text = "0,00";
                    lblPorcentagem1.Enabled = false;
                    lblDias.Enabled = false;
                    lblPorcentagem2.Enabled = false;
                    lblPorcentagem3.Enabled = false;
                    label2.Enabled = false;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    label3.Enabled = false;
                    txtDesconto.Enabled = false;
                    lblPorcentagem4.Enabled = false;
                    lblDesconto.Enabled = false;
                    lblDuracaoDesconto.Enabled = false;
                    label11.Enabled = false;
                    txtDuracaoDesconto.Enabled = false;
                    lblDias1.Enabled = false;
                }
                else if (cbbTipo.SelectedIndex == 7)
                {
                    txtParcela.Text = "1";
                    lblParcela.Enabled = false;
                    txtParcela.Enabled = false;
                    lblEntrada.Enabled = false;
                    txtEntradaPorc.Enabled = false;
                    txtEntradaPorc.Text = "0,00";
                    if (cbbTipoOp.SelectedIndex == 0)
                    {
                        lblDescontoFixo.Enabled = true;
                        txtDescontoFixoPorc.Enabled = true;
                        txtAcrescimoFixoPorc.Enabled = true;
                        label5.Enabled = true;
                        lblPorcentagem5.Enabled = true;
                        lblPorcentagem6.Enabled = true;
                    }
                    else
                    {
                        lblDescontoFixo.Enabled = false;
                        txtDescontoFixoPorc.Enabled = false;
                        txtAcrescimoFixoPorc.Enabled = false;
                        label5.Enabled = false;
                        lblPorcentagem5.Enabled = false;
                        lblPorcentagem6.Enabled = false;
                    }
                    txtPrimeiroPagamento.Text = "0";
                    lblPrimeiroPagamento.Enabled = false;
                    txtPrimeiroPagamento.Enabled = false;
                    lblJuros.Enabled = false;
                    txtJurosPorc.Enabled = false;
                    txtJurosPorc.Text = "0,00";
                    lblJurosAtraso.Enabled = false;
                    txtJurosAtrasoPorc.Enabled = false;
                    txtJurosAtrasoPorc.Text = "0,00";
                    lblPorcentagem1.Enabled = false;
                    lblDias.Enabled = false;
                    lblPorcentagem2.Enabled = false;
                    lblPorcentagem3.Enabled = false;
                    label2.Enabled = false;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    label3.Enabled = false;
                    txtDesconto.Enabled = false;
                    lblPorcentagem4.Enabled = false;
                    lblDesconto.Enabled = false;
                    lblDuracaoDesconto.Enabled = false;
                    label11.Enabled = false;
                    txtDuracaoDesconto.Enabled = false;
                    lblDias1.Enabled = false;
                }
                else if (cbbTipo.SelectedIndex == 8)
                {
                    txtParcela.Text = "1";
                    lblParcela.Enabled = false;
                    txtParcela.Enabled = false;
                    lblEntrada.Enabled = false;
                    txtEntradaPorc.Enabled = false;
                    txtEntradaPorc.Text = "0,00";
                    if (cbbTipoOp.SelectedIndex == 0)
                    {
                        lblDescontoFixo.Enabled = true;
                        txtDescontoFixoPorc.Enabled = true;
                        txtAcrescimoFixoPorc.Enabled = true;
                        label5.Enabled = true;
                        lblPorcentagem5.Enabled = true;
                        lblPorcentagem6.Enabled = true;
                    }
                    else
                    {
                        lblDescontoFixo.Enabled = false;
                        txtDescontoFixoPorc.Enabled = false;
                        txtAcrescimoFixoPorc.Enabled = false;
                        label5.Enabled = false;
                        lblPorcentagem5.Enabled = false;
                        lblPorcentagem6.Enabled = false;
                    }
                    txtPrimeiroPagamento.Text = "0";
                    lblPrimeiroPagamento.Enabled = false;
                    txtPrimeiroPagamento.Enabled = false;
                    lblJuros.Enabled = false;
                    txtJurosPorc.Enabled = false;
                    txtJurosPorc.Text = "0,00";
                    lblJurosAtraso.Enabled = false;
                    txtJurosAtrasoPorc.Enabled = false;
                    txtJurosAtrasoPorc.Text = "0,00";
                    lblPorcentagem1.Enabled = false;
                    lblDias.Enabled = false;
                    lblPorcentagem2.Enabled = false;
                    lblPorcentagem3.Enabled = false;
                    label2.Enabled = false;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    label3.Enabled = false;
                    txtDesconto.Enabled = false;
                    lblPorcentagem4.Enabled = false;
                    lblDesconto.Enabled = false;
                    lblDuracaoDesconto.Enabled = false;
                    label11.Enabled = false;
                    txtDuracaoDesconto.Enabled = false;
                    lblDias1.Enabled = false;
                }
            }
        }

        private void txtDescontoFixoPorc_Enter(object sender, EventArgs e)
        {
            txtDescontoFixoPorc.BackColor = Color.LightBlue;
        }

        private void txtDescontoFixoPorc_Leave(object sender, EventArgs e)
        {
            if (txtDescontoFixoPorc.Text.Contains("'") || txtDescontoFixoPorc.Text.Contains(";") || txtDescontoFixoPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescontoFixoPorc.Text = null;
                txtDescontoFixoPorc.Select();
            }
            else
            {
                if (txtDescontoFixoPorc.Text != "")
                {
                    try
                    {
                        txtDescontoFixoPorc.Text = Convert.ToDecimal(txtDescontoFixoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescontoFixoPorc.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDescontoFixoPorc.");
                        }
                        txtDescontoFixoPorc.Text = null;
                    }
                }
            }
            txtDescontoFixoPorc.BackColor = Color.White;
        }

        private void txtDescontoFixoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDescontoFixoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtAcrescimoFixoPorc.Select();
            }
        }

        private void txtAcrescimoFixoPorc_Enter(object sender, EventArgs e)
        {
            txtAcrescimoFixoPorc.BackColor = Color.LightBlue;
        }

        private void txtAcrescimoFixoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAcrescimoFixoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (txtPrimeiroPagamento.Enabled == false)
                {
                    btnSalvar.Select();
                }
                else
                {
                    txtPrimeiroPagamento.Select();
                }
            }
        }

        private void txtAcrescimoFixoPorc_Leave(object sender, EventArgs e)
        {
            if (txtAcrescimoFixoPorc.Text.Contains("'") || txtAcrescimoFixoPorc.Text.Contains(";") || txtAcrescimoFixoPorc.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAcrescimoFixoPorc.Text = null;
                txtAcrescimoFixoPorc.Select();
            }
            else
            {
                if (txtAcrescimoFixoPorc.Text != "")
                {
                    try
                    {
                        txtAcrescimoFixoPorc.Text = Convert.ToDecimal(txtAcrescimoFixoPorc.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAcrescimoFixoPorc.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAcrescimoFixoPorc.");
                        }
                        txtAcrescimoFixoPorc.Text = null;
                    }
                }
            }
            txtAcrescimoFixoPorc.BackColor = Color.White;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipoOp.Select();
            }
        }

        private void btnReciboRegistro_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Trim() == "" || cbbTipo.Text == "" || txtParcela.Text.Trim() == "" || txtParcela.Text.Trim() == "0")
            {
                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Tipo de Pagamento ], [ Descrição ] e [ Parcela(s) ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbbTipo.Select();
            }
            else
            {
                pEnabled.Enabled = false;
                using (FrmSimularFormaPagamento Pag = new FrmSimularFormaPagamento(txtDescricao.Text.Trim(), cbbTipo.Text, txtParcela.Text.Trim(), txtEntradaPorc.Text.Trim(), txtDescontoFixoPorc.Text.Trim(), txtAcrescimoFixoPorc.Text.Trim(), txtPrimeiroPagamento.Text.Trim(), txtJurosPorc.Text.Trim(), txtJurosAtrasoPorc.Text.Trim(), 1))
                {
                    if (Pag.ShowDialog() == DialogResult.Abort)
                    {
                        txtpPalavraChave.Select();
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnReciboRegistro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnReciboRegistro_MouseLeave(object sender, EventArgs e)
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

        private void cbbEntBanc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEntBanc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarEntBanc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarEntBanc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarEntBanc_Click(object sender, EventArgs e)
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

        private void cbbTipoOp_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoOp_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoOp_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoOp_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                if (cbbTipoOp.SelectedIndex == 0)
                {
                    if (cbbTipo.SelectedIndex != 3)
                    {
                        txtParcela.Text = "1";
                        lblParcela.Enabled = false;
                        txtParcela.Enabled = false;
                        lblEntrada.Enabled = false;
                        txtEntradaPorc.Enabled = false;
                        txtEntradaPorc.Text = "0,00";
                        lblDescontoFixo.Enabled = true;
                        txtDescontoFixoPorc.Enabled = true;
                        label5.Enabled = true;
                        txtAcrescimoFixoPorc.Enabled = true;
                        txtPrimeiroPagamento.Text = "0";
                        lblPrimeiroPagamento.Enabled = false;
                        txtPrimeiroPagamento.Enabled = false;
                        lblJuros.Enabled = false;
                        txtJurosPorc.Enabled = false;
                        txtJurosPorc.Text = "0,00";
                        lblJurosAtraso.Enabled = false;
                        txtJurosAtrasoPorc.Enabled = false;
                        txtJurosAtrasoPorc.Text = "0,00";
                        lblPorcentagem1.Enabled = false;
                        lblDias.Enabled = false;
                        lblPorcentagem2.Enabled = false;
                        lblPorcentagem3.Enabled = false;
                        label2.Enabled = false;
                        lblDescricao.Enabled = true;
                        txtDescricao.Enabled = true;
                        lblPorcentagem5.Enabled = true;
                        lblPorcentagem6.Enabled = true;
                        label3.Enabled = false;
                    }
                    else
                    {
                        cbbTipo_SelectedIndexChanged(sender, e);
                    }
                    lblDescontoFixo.Enabled = true;
                    txtDescontoFixoPorc.Enabled = true;
                    txtDescontoFixoPorc.Text = "0,00";
                    lblPorcentagem5.Enabled = true;
                    label5.Enabled = true;
                    txtAcrescimoFixoPorc.Enabled = true;
                    txtAcrescimoFixoPorc.Text = "0,00";
                    lblPorcentagem6.Enabled = true;
                    label6.Enabled = false;
                    cbbEntBanc.Enabled = false;
                    btnProcurarEntBanc.Enabled = false;

                }
                else if (cbbTipoOp.SelectedIndex == 1)
                {
                    txtParcela.Text = "1";
                    lblParcela.Enabled = false;
                    txtParcela.Enabled = false;
                    lblEntrada.Enabled = false;
                    txtEntradaPorc.Enabled = false;
                    txtEntradaPorc.Text = "0,00";
                    lblDescontoFixo.Enabled = true;
                    txtDescontoFixoPorc.Enabled = true;
                    label5.Enabled = true;
                    txtAcrescimoFixoPorc.Enabled = true;
                    txtPrimeiroPagamento.Text = "0";
                    lblPrimeiroPagamento.Enabled = false;
                    txtPrimeiroPagamento.Enabled = false;
                    lblJuros.Enabled = false;
                    txtJurosPorc.Enabled = false;
                    txtJurosPorc.Text = "0,00";
                    lblJurosAtraso.Enabled = false;
                    txtJurosAtrasoPorc.Enabled = false;
                    txtJurosAtrasoPorc.Text = "0,00";
                    lblPorcentagem1.Enabled = false;
                    lblDias.Enabled = false;
                    lblPorcentagem2.Enabled = false;
                    lblPorcentagem3.Enabled = false;
                    label2.Enabled = false;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    lblPorcentagem5.Enabled = true;
                    lblPorcentagem6.Enabled = true;
                    lblDescontoFixo.Enabled = false;
                    txtDescontoFixoPorc.Enabled = false;
                    txtDescontoFixoPorc.Text = "0,00";
                    lblPorcentagem5.Enabled = false;
                    label5.Enabled = false;
                    txtAcrescimoFixoPorc.Enabled = false;
                    txtAcrescimoFixoPorc.Text = "0,00";
                    lblPorcentagem6.Enabled = false;
                    label3.Enabled = false;
                    label6.Enabled = true;
                    cbbEntBanc.Enabled = true;
                    btnProcurarEntBanc.Enabled = true;
                }
                cbbTipo_SelectedIndexChanged(sender, e);
            }
        }

        private void cbbEntBanc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void cbbTipoOp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipo.Select();
            }
        }

        private void dtFormaPagamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void txtDesconto_Enter(object sender, EventArgs e)
        {
            txtDesconto.BackColor = Color.LightBlue;
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            if (txtDesconto.Text.Contains("'") || txtDesconto.Text.Contains(";") || txtDesconto.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDescontoFixoPorc.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtDuracaoDesconto.Select();
            }
        }

        private void txtDuracaoDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void txtDuracaoDesconto_Leave(object sender, EventArgs e)
        {
            if (txtDuracaoDesconto.Text.Contains("'") || txtDuracaoDesconto.Text.Contains(";") || txtDuracaoDesconto.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDuracaoDesconto.Text = null;
                txtDuracaoDesconto.Select();
            }
            txtDuracaoDesconto.BackColor = Color.White;
        }

        private void txtDuracaoDesconto_Enter(object sender, EventArgs e)
        {
            txtDuracaoDesconto.BackColor = Color.LightBlue;
        }
    }
}
