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
    public partial class FrmCadContasReceber : Form
    {
        public FrmCadContasReceber(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar;
        private string _ComboboxConsumidor_Valor;
        private string _Usuario;
        private string _ComboboxGrupo_Valor = null;
        private string _ComboboxSubgrupo_Valor = null;
        private string _Cod_PDV_Computador;

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            grbBox2.Enabled = false;
            btnNovo.Enabled = true;
            lblCodigo.Enabled = false;
            txtCodigo.Enabled = false;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            if (dtContaReceber.DataSource != null)
            {
                dtContaReceber.Enabled = true;
                dtContaReceber.Select();
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtParcela.Text = null;
            txtDescricao.Text = null;
            mtxtDataEmissao.Text = null;
            mtxtDataVencimento.Text = null;
            cbbTipoConsumidor.Text = null;
            cbbConsumidor.Items.Clear();
            cbbConsumidor.Text = null;
            cbbGrupo.Items.Clear();
            cbbGrupo.Text = null;
            cbbSubGrupo.Items.Clear();
            cbbSubGrupo.Text = null;
            txtValorDocumento.Text = null;
            txtPalavraChave.Text = null;
            rtxtObs.Text = null;
        }

        private void FrmCadContaReceber_Load(object sender, EventArgs e)
        {
            try
            {
                bllContasReceber._FrmCadContaReceber_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContasReceber iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContasReceber iniciado.");
                }
                //
                rbtnDescricao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadContasReceber.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadContasReceber.");
                }
                //
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
                txtDescricao.Select();
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
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
                cbbTipoConsumidor.Select();
            }
        }

        private void cbbGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbSubGrupo.Enabled == false)
                {
                    rtxtObs.Select();
                }
                else
                {
                    cbbSubGrupo.Select();
                }
            }
        }

        private void cbbGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbGrupo_MouseLeave(object sender, EventArgs e)
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

        private void cbbSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtValorDocumento_Enter(object sender, EventArgs e)
        {
            txtValorDocumento.BackColor = Color.LightBlue;
        }

        private void txtValorDocumento_Leave(object sender, EventArgs e)
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

        private void cbbTipoEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoEmitente_DropDownClosed(object sender, EventArgs e)
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

        private void cbbEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEmitente_DropDownClosed(object sender, EventArgs e)
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

        private void btnProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDestinatario_MouseLeave(object sender, EventArgs e)
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

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
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

        private void btnProcurarGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarSubgrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarSubgrupo_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpConsumidor.Visible = false;
            cbbpTipoConsumidor.Visible = false;
            txtpDescricao.Visible = true;
            btnpProcurar.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(338, 21);
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadContasReceber_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllContasReceber._FrmCadContaReceber_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContasReceber foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadContasReceber foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadContasReceber.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadContasReceber.");
                }
            }
        }

        private void rbtnDestinatario_CheckedChanged(object sender, EventArgs e)
        {
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpConsumidor.Visible = true;
            cbbpTipoConsumidor.Visible = true;
            txtpDescricao.Visible = false;
            btnpProcurar.Visible = true;
            lblPesquisar.Text = "Localizar destinatário em:";
            lblPesquisar.Location = new Point(159, 21);
            cbbpConsumidor.Text = null;
            cbbpTipoConsumidor.Text = "CLIENTES";
            cbbpTipoConsumidor.Select();
            //
            try
            {
                cbbpConsumidor.Items.Clear();
                if (cbbpTipoConsumidor.SelectedIndex == 1)
                {
                    if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                    {
                        cbbpConsumidor.Enabled = false;
                        cbbpConsumidor.Text = null;
                    }
                    else
                    {
                        cbbpConsumidor.Enabled = true;
                        cbbpConsumidor.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                        {
                            cbbpConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
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
                cbbpConsumidor.Text = null;
            }
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpCodigo.Visible = true;
            txtpPalavraChave.Visible = false;
            cbbpConsumidor.Visible = false;
            cbbpTipoConsumidor.Visible = false;
            txtpDescricao.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(467, 21);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = true;
            cbbpConsumidor.Visible = false;
            cbbpTipoConsumidor.Visible = false;
            txtpDescricao.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Text = "Digite a palavra-chave:";
            lblPesquisar.Location = new Point(424, 21);
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnTodas_CheckedChanged(object sender, EventArgs e)
        {
            txtpCodigo.Visible = false;
            txtpPalavraChave.Visible = false;
            cbbpConsumidor.Visible = false;
            cbbpTipoConsumidor.Visible = false;
            txtpDescricao.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(515, 21);
            btnPesquisar.Select();
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

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
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

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, destinatário, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui registros.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você atualiza os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Clicando no botão [ Adicionar Parcelas ] você estará adicionando as parcelas da conta selecionada na tabela.\n\n5 - Se por algum um motivo você clicou nos botões [ Novo ] ou [ Alterar ] e não deseja continuar nessas opções, clique no botão [ Cancelar ].\n\n6 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmCadContasReceber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cbbpTipoDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoDestinatario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoDestinatario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpDestinatario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpDestinatario_DropDownStyleChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpConsumidor.Items.Clear();
                if (cbbpTipoConsumidor.SelectedIndex == 0)
                {
                    cbbpConsumidor.Text = null;
                    cbbpConsumidor.Enabled = false;
                    btnpProcurar.Enabled = false;
                }
                else if (cbbpTipoConsumidor.SelectedIndex == 1)
                {
                    if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                    {
                        cbbpConsumidor.Text = null;
                        cbbpConsumidor.Enabled = false;
                    }
                    else
                    {
                        cbbpConsumidor.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpConsumidor.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                        {
                            cbbpConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbpTipoConsumidor.SelectedIndex == 2)
                {
                    if (bllContasReceber.Sel_Forn_Conta_Receber() == null)
                    {
                        cbbpConsumidor.Text = null;
                        cbbpConsumidor.Enabled = false;
                    }
                    else
                    {
                        cbbpConsumidor.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpConsumidor.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_Forn_Conta_Receber().Rows)
                        {
                            cbbpConsumidor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbpTipoConsumidor.SelectedIndex == 3)
                {
                    if (bllContasReceber.Sel_Func_Conta_Receber() == null)
                    {
                        cbbpConsumidor.Text = null;
                        cbbpConsumidor.Enabled = false;
                    }
                    else
                    {
                        cbbpConsumidor.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpConsumidor.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_Func_Conta_Receber().Rows)
                        {
                            cbbpConsumidor.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbpTipoConsumidor.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbpTipoConsumidor.");
                }
                cbbpConsumidor.Items.Clear();
                cbbpConsumidor.Text = null;
                cbbpTipoConsumidor.Text = null;
            }
        }

        private void cbbpTipoDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbpConsumidor.Enabled != false)
                {
                    cbbpConsumidor.Select();
                }
                else
                {
                    btnPesquisar.Select();
                }
            }
        }

        private void cbbpDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpPalavraChave.Text = null;
                txtpPalavraChave.Select();
            }
            txtpPalavraChave.BackColor = Color.White;
        }

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void dtContaReceber_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtContaReceber.Columns[0].HeaderText = "Código";
                dtContaReceber.Columns[1].HeaderText = "Descrição";
                dtContaReceber.Columns[2].Visible = false;
                dtContaReceber.Columns[3].HeaderText = "Parcela(s)";
                dtContaReceber.Columns[4].HeaderText = "Data de Emissão";
                dtContaReceber.Columns[5].HeaderText = "Data de Vencimento";
                dtContaReceber.Columns[6].Visible = false;
                dtContaReceber.Columns[7].HeaderText = "Tipo de Consumidor";
                dtContaReceber.Columns[8].HeaderText = "Cód. do Consumidor";
                dtContaReceber.Columns[9].HeaderText = "Nome/Razão Social do Consumidor";
                dtContaReceber.Columns[10].HeaderText = "Cód. do Grupo";
                dtContaReceber.Columns[11].HeaderText = "Descrição do Grupo";
                dtContaReceber.Columns[12].HeaderText = "Cód. do Sub-Grupo";
                dtContaReceber.Columns[13].HeaderText = "Descrição do Sub-Grupo";
                dtContaReceber.Columns[14].HeaderText = "Valor (R$)";
                dtContaReceber.Columns[15].Visible = false;
                dtContaReceber.Columns[16].Visible = false;
                dtContaReceber.Columns[17].Visible = false;
                dtContaReceber.Columns[18].Visible = false;
                dtContaReceber.Columns[19].Visible = false;
                dtContaReceber.Columns[20].Visible = false;
                dtContaReceber.Columns[21].Visible = false;
                dtContaReceber.Columns[22].Visible = false;
                dtContaReceber.Columns[23].Visible = false;
                dtContaReceber.Columns[24].Visible = false;
                dtContaReceber.Columns[25].Visible = false;
                dtContaReceber.Columns[26].Visible = false;
                dtContaReceber.Columns[27].Visible = false;
                dtContaReceber.Columns[28].HeaderText = "Observações";
                dtContaReceber.Columns[29].HeaderText = "Palavra-Chave";
                dtContaReceber.Columns[30].Visible = false;
                dtContaReceber.Columns[31].Visible = false;
                dtContaReceber.Columns[32].Visible = false;
                dtContaReceber.Columns[33].Visible = false;
                dtContaReceber.Columns[34].Visible = false;
                dtContaReceber.Columns[35].Visible = false;
                dtContaReceber.Columns[36].Visible = false;
                dtContaReceber.Columns[37].Visible = false;

                dtContaReceber.DefaultCellStyle.Font = new Font(dtContaReceber.Font, FontStyle.Bold);

                dtContaReceber.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaReceber.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtContaReceber.Columns[0].Width = 95;
                dtContaReceber.Columns[1].Width = 325;
                dtContaReceber.Columns[3].Width = 146;
                dtContaReceber.Columns[4].Width = 150;
                dtContaReceber.Columns[5].Width = 150;
                dtContaReceber.Columns[7].Width = 150;
                dtContaReceber.Columns[8].Width = 135;
                dtContaReceber.Columns[9].Width = 325;
                dtContaReceber.Columns[10].Width = 105;
                dtContaReceber.Columns[11].Width = 325;
                dtContaReceber.Columns[12].Width = 125;
                dtContaReceber.Columns[13].Width = 325;
                dtContaReceber.Columns[14].Width = 162;
                dtContaReceber.Columns[28].Width = 500;
                dtContaReceber.Columns[29].Width = 150;

                lblRegistros.Text = "Registros: " + dtContaReceber.Rows.Count;

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
                dtContaReceber.DataSource = null;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodas.Checked == true)
                {
                    if (bllContasReceber.Sel_Conta_Receber_Todas() == null)
                    {
                        dtContaReceber.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        Limpar();
                    }
                    else
                    {
                        dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Todas();
                        dtContaReceber.Select();
                    }
                }
                else if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Descricao_Receber(txtpDescricao.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Descricao_Receber(txtpDescricao.Text);
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Palavra_Chave_Receber(txtpPalavraChave.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Palavra_Chave_Receber(txtpPalavraChave.Text);
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Codigo_Receber(txtpCodigo.Text, "OUTROS") == null)
                        {
                            dtContaReceber.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Codigo_Receber(txtpCodigo.Text, "OUTROS");
                        }
                    }
                }
                else if (rbtnDestinatario.Checked == true)
                {
                    if (cbbpConsumidor.Text != "" & cbbpTipoConsumidor.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Receber_Consumidor(cbbpConsumidor.Text, cbbpTipoConsumidor.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Consumidor(cbbpConsumidor.Text, cbbpTipoConsumidor.Text);
                            dtContaReceber.Select();
                        }
                    }
                    else if (cbbpConsumidor.Text == "" & cbbpTipoConsumidor.Text != "")
                    {
                        if (bllContasReceber.Sel_Conta_Tipo_Consumidor(cbbpTipoConsumidor.Text) == null)
                        {
                            dtContaReceber.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            Limpar();
                        }
                        else
                        {
                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Tipo_Consumidor(cbbpTipoConsumidor.Text);
                            dtContaReceber.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxConsumidor_Valor = null;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtContaReceber.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtContaReceber.Enabled = false;
            grbBox1.Enabled = false;
            grbBox2.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnDuplicar.Enabled = false;
            btnSalvar.Enabled = true;
            cbbSubGrupo.Enabled = false;
            lblSubGrupo.Enabled = false;
            lblAsteriscoSubGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            Limpar();
            _Comando_Atualizar = false;
            _Inserir_Atualizar = true;
            //
            txtParcela.Text = "1";
            cbbTipoConsumidor.Text = "CLIENTES";
            //
            txtPalavraChave.Select();
            //
            try
            {
                cbbGrupo.Items.Clear();
                cbbSubGrupo.Items.Clear();
                if (bllContasReceber.Sel_Grupo_Conta_Receber() == null)
                {
                    cbbGrupo.Text = null;
                    cbbSubGrupo.Items.Clear();
                    cbbSubGrupo.Enabled = false;
                    cbbSubGrupo.Text = null;
                    btnProcurarSubgrupo.Enabled = false;
                    lblSubGrupo.Enabled = false;
                }
                else
                {
                    cbbGrupo.Items.Add("");
                    foreach (DataRow dr in bllContasReceber.Sel_Grupo_Conta_Receber().Rows)
                    {
                        cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
                //
                cbbConsumidor.Items.Clear();
                //
                if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                {
                    cbbConsumidor.Enabled = false;
                    cbbConsumidor.Text = null;
                }
                else
                {
                    cbbConsumidor.Enabled = true;
                    btnProcurar.Enabled = true;
                    cbbConsumidor.Items.Add("");
                    foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                    {
                        cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
                //
                cbbGrupo.Text = "3—CONTAS A RECEBER NO GERAL";
                cbbSubGrupo.Text = "3—GERAL";
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
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxConsumidor_Valor = null;
            }
        }

        private void txtParcela_Enter(object sender, EventArgs e)
        {
            txtParcela.BackColor = Color.LightBlue;
        }

        private void txtParcela_Leave(object sender, EventArgs e)
        {
            if (txtParcela.Text == "0" || txtParcela.Text == "00" || txtParcela.Text == "000" || txtParcela.Text == "0000")
            {
                MessageBox.Show("O campo [ Parcela ] não pode ser 0.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtParcela.Text = null;
            }
            //
            if (txtParcela.Text.Contains("'") || txtParcela.Text.Contains(";") || txtParcela.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtParcela.Text = null;
                txtParcela.Select();
            }
            txtParcela.BackColor = Color.White;
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
            mtxtDataEmissao.BackColor = Color.White;
        }

        private void mtxtDataVencimento_Enter(object sender, EventArgs e)
        {
            mtxtDataVencimento.BackColor = Color.LightBlue;
        }

        private void mtxtDataVencimento_Leave(object sender, EventArgs e)
        {
            mtxtDataVencimento.BackColor = Color.White;
        }

        private void cbbSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                rtxtObs.Select();
            }
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

        private void mtxtDataEmissao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataEmissao.Text == "")
                {
                    mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
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

        private void mtxtDataVencimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataVencimento.Text == "")
                {
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
        }

        private void btnSelecionarData2_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(2))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataEmissao.Text = bllContasReceber._Data_DatePicker1;
                    mtxtDataVencimento.Text = bllContasReceber._Data_DatePicker2;
                    bllContasReceber._Data_DatePicker1 = null;
                    bllContasReceber._Data_DatePicker2 = null;
                    mtxtDataVencimento.Select();
                }
            }
            pEnabled.Enabled = true;
        }

        private void txtValorDocumento_KeyPress(object sender, KeyPressEventArgs e)
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
                cbbGrupo.Select();
            }
        }

        private void cbbTipoDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbConsumidor.Enabled == true)
                {
                    cbbConsumidor.Select();
                }
                else
                {
                    txtValorDocumento.Select();
                }
            }
        }

        private void cbbDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtValorDocumento.Select();
            }
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
                        if (bllContasReceber.Sel_SubGrupo_Conta_Receber(items[0]) == null)
                        {
                            cbbSubGrupo.Text = null;
                            cbbSubGrupo.Enabled = false;
                            btnProcurarSubgrupo.Enabled = false;
                            lblSubGrupo.Enabled = false;
                            lblAsteriscoSubGrupo.Enabled = false;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllContasReceber.Sel_SubGrupo_Conta_Receber(items[0]).Rows)
                            {
                                cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbSubGrupo.Enabled = true;
                                btnProcurarSubgrupo.Enabled = true;
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
                        btnProcurarSubgrupo.Enabled = false;
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _ComboboxConsumidor_Valor = cbbConsumidor.Text;
                //
                if (cbbTipoConsumidor.SelectedIndex == 1)
                {
                    if (cbbConsumidor.Text != "")
                    {
                        cbbConsumidor.Items.Clear();
                        if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                        {
                            cbbConsumidor.Text = null;
                        }
                        else
                        {
                            cbbConsumidor.Items.Add("");
                            foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }

                        if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaReceber(_ComboboxConsumidor_Valor) != null)
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaReceber(_ComboboxConsumidor_Valor).Rows)
                            {
                                cbbConsumidor.Text = dr["id_cliente"].ToString() + "—" + dr["nome"].ToString();
                            }
                            _ComboboxConsumidor_Valor = null;
                        }
                        else
                        {
                            _ComboboxConsumidor_Valor = null;
                            cbbConsumidor.Text = null;
                        }
                    }
                }
                else if (cbbTipoConsumidor.SelectedIndex == 2)
                {
                    if (cbbConsumidor.Text != "")
                    {
                        cbbConsumidor.Items.Clear();
                        if (bllContasReceber.Sel_Forn_Conta_Receber() == null)
                        {
                            cbbConsumidor.Text = null;
                        }
                        else
                        {
                            cbbConsumidor.Items.Add("");
                            foreach (DataRow dr in bllContasReceber.Sel_Forn_Conta_Receber().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }

                        if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaReceber(_ComboboxConsumidor_Valor) != null)
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaReceber(_ComboboxConsumidor_Valor).Rows)
                            {
                                cbbConsumidor.Text = dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString();
                            }
                            _ComboboxConsumidor_Valor = null;
                        }
                    }
                    else
                    {
                        _ComboboxConsumidor_Valor = null;
                        cbbConsumidor.Text = null;
                    }
                }
                else if (cbbTipoConsumidor.SelectedIndex == 3)
                {
                    if (cbbConsumidor.Text != "")
                    {
                        cbbConsumidor.Items.Clear();
                        if (bllContasReceber.Sel_Func_Conta_Receber() == null)
                        {
                            cbbConsumidor.Text = null;
                        }
                        else
                        {
                            cbbConsumidor.Items.Add("");
                            foreach (DataRow dr in bllContasReceber.Sel_Func_Conta_Receber().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }

                        if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaReceber(_ComboboxConsumidor_Valor) != null)
                        {
                            foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaReceber(_ComboboxConsumidor_Valor).Rows)
                            {
                                cbbConsumidor.Text = dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString();
                                _ComboboxConsumidor_Valor = null;
                            }
                        }
                        else
                        {
                            _ComboboxConsumidor_Valor = null;
                            cbbConsumidor.Text = null;
                        }
                    }
                }

                _ComboboxGrupo_Valor = cbbGrupo.Text;
                _ComboboxSubgrupo_Valor = cbbSubGrupo.Text;

                if (cbbGrupo.Text != "")
                {
                    cbbGrupo.Items.Clear();
                    if (bllContasReceber.Sel_Grupo_Conta_Receber() == null)
                    {
                        cbbGrupo.Text = null;
                    }
                    else
                    {
                        cbbGrupo.Items.Add("");
                        foreach (DataRow dr in bllContasReceber.Sel_Grupo_Conta_Receber().Rows)
                        {
                            cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                    //
                    if (bllContasReceber.Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Receber(_ComboboxGrupo_Valor) != null)
                    {
                        foreach (DataRow dr in bllContasReceber.Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Receber(_ComboboxGrupo_Valor).Rows)
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
                        if (bllContasReceber.Sel_SubGrupo_Conta_Receber(cbbGrupo.Text) == null)
                        {
                            cbbSubGrupo.Text = null;
                        }
                        else
                        {
                            cbbSubGrupo.Items.Add("");
                            foreach (DataRow dr in bllContasReceber.Sel_SubGrupo_Conta_Receber(cbbGrupo.Text).Rows)
                            {
                                cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        //
                        cbbSubGrupo.Text = _ComboboxSubgrupo_Valor;
                        //
                        if (_ComboboxSubgrupo_Valor != "")
                        {
                            if (bllContasReceber.Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Receber(_ComboboxSubgrupo_Valor, cbbGrupo.Text) != null)
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Receber(_ComboboxSubgrupo_Valor, cbbGrupo.Text).Rows)
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

                    if (txtParcela.Text == "" || txtDescricao.Text == "" || mtxtDataEmissao.Text == "" || mtxtDataVencimento.Text == "" || cbbTipoConsumidor.Text == "" || cbbConsumidor.Text == "" || txtValorDocumento.Text == "" || cbbGrupo.Text == "" || cbbSubGrupo.Text == "" || txtValorDocumento.Text == "0,00")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Parcela ], [ Descrição ], [ Data de Emissão ],\n[ Data de Vencimento ], [ Destinatário ], [ Valor ],\n[ Grupo ] e [ Subgrupo ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        mtxtDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (_Comando_Atualizar == true)
                        {
                            if (bllContasReceber.Sel_Conta_Receber_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                dtContaReceber.DataSource = null;
                                rbtnDescricao.Checked = true;
                                ModoPesquisa();
                                Limpar();
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                            }
                            else
                            {
                                bllContasReceber.Alterar(txtCodigo.Text, txtParcela.Text.Trim(), txtDescricao.Text.Trim(), mtxtDataEmissao.Text, mtxtDataVencimento.Text, cbbGrupo.Text, cbbSubGrupo.Text, txtValorDocumento.Text.Trim(), cbbConsumidor.Text, rtxtObs.Text.Trim(), cbbTipoConsumidor.Text, txtPalavraChave.Text.Trim());
                                //
                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UMA CONTA A RECEBER.", "CONTAS A RECEBER", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                                dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_A_Alt(txtCodigo.Text);

                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a receber alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a receber alterada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }

                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                _ComboboxGrupo_Valor = null;
                                _ComboboxSubgrupo_Valor = null;
                                _ComboboxConsumidor_Valor = null;

                                ModoPesquisa();

                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                //
                                if (bllLembrete.Sel_Codigo_Tabela_Geradora(txtCodigo.Text, "CONTAS A RECEBER") != null)
                                {
                                    string codigo = bllLembrete.Sel_Codigo_Tabela_Geradora(txtCodigo.Text, "CONTAS A RECEBER");
                                    DialogResult = MessageBox.Show("Deseja alterar também os dados do lembrete associado a esta Conta a Receber?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            bllContasReceber.Salvar(txtParcela.Text.Trim(), txtDescricao.Text.Trim(), mtxtDataEmissao.Text.Trim(), mtxtDataVencimento.Text.Trim(), cbbGrupo.Text, cbbSubGrupo.Text, txtValorDocumento.Text.Trim(), cbbConsumidor.Text, rtxtObs.Text.Trim(), cbbTipoConsumidor.Text, txtPalavraChave.Text.Trim(), "OUTROS", "0", "", "", "", "0", "PENDENTE", "", "");

                            dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_A_Sal();

                            bllRegistroAtividades.Salvar("SALVOU UMA CONTA A RECEBER.", "CONTAS A RECEBER", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);

                            DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];

                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            _ComboboxGrupo_Valor = null;
                            _ComboboxSubgrupo_Valor = null;
                            _ComboboxConsumidor_Valor = null;

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a receber cadastrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a receber cadastrada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            if (bllUsuario.Sel_Criar_Lemb_Conta_Receber_Usuario(_Usuario) == true)
                            {
                                DialogResult = MessageBox.Show("Deseja criar um lembrete para esta Conta a Receber?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    using (FrmUtilCadLembrete Lembrete = new FrmUtilCadLembrete(null, SelectedRow.Cells[5].Value.ToString(), null, "LEMBRETE DE CONTA A RECEBER", "LEMBRETE DE CONTA A RECEBER DE CÓDIGO " + SelectedRow.Cells[0].Value.ToString().Trim() + "  NO VALOR DE " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + " R$ DO " + SelectedRow.Cells[7].Value.ToString() + " " + SelectedRow.Cells[8].Value.ToString() + "-" + SelectedRow.Cells[9].Value.ToString() + ".", null, false, _Usuario, _Cod_PDV_Computador, 2, "CONTAS A RECEBER", SelectedRow.Cells[0].Value.ToString()))
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
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                else
                {
                    txtPalavraChave.Select();
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
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxConsumidor_Valor = null;
            }
        }

        private void dtContaReceber_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtContaReceber.Rows[e.RowIndex];
                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtDescricao.Text = SelectedRow.Cells[1].Value.ToString();
                txtParcela.Text = SelectedRow.Cells[3].Value.ToString();
                mtxtDataEmissao.Text = SelectedRow.Cells[4].Value.ToString();
                mtxtDataVencimento.Text = SelectedRow.Cells[5].Value.ToString();
                cbbTipoConsumidor.Text = SelectedRow.Cells[7].Value.ToString();
                cbbConsumidor.Items.Clear();
                cbbConsumidor.Items.Add(SelectedRow.Cells[8].Value.ToString() + "—" + SelectedRow.Cells[9].Value.ToString());
                cbbConsumidor.Text = SelectedRow.Cells[8].Value.ToString() + "—" + SelectedRow.Cells[9].Value.ToString();
                cbbGrupo.Items.Clear();
                cbbGrupo.Items.Add(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString());
                cbbGrupo.Text = SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString();
                cbbSubGrupo.Items.Clear();
                cbbSubGrupo.Items.Add(SelectedRow.Cells[12].Value.ToString() + "—" + SelectedRow.Cells[13].Value.ToString());
                cbbSubGrupo.Text = SelectedRow.Cells[12].Value.ToString() + "—" + SelectedRow.Cells[13].Value.ToString();
                dtContaReceber.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaReceber.Columns[14].DefaultCellStyle.Format = "n2";
                txtValorDocumento.Text = Convert.ToDecimal(SelectedRow.Cells[14].Value).ToString("n2", new CultureInfo("pt-BR"));
                rtxtObs.Text = SelectedRow.Cells[28].Value.ToString();
                txtPalavraChave.Text = SelectedRow.Cells[29].Value.ToString();
                //
                dtContaReceber.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtContaReceber.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                if (SelectedRow.Cells[23].Value.ToString() == "PENDENTE")
                {
                    lblValorSituacao.Text = "PENDENTE";
                    lblValorSituacao.ForeColor = Color.Red;
                    lblCxSituacao.BackColor = Color.Red;
                }
                else if (SelectedRow.Cells[23].Value.ToString() == "FINALIZADA")
                {
                    lblValorSituacao.Text = "FINALIZADA";
                    lblValorSituacao.ForeColor = Color.Green;
                    lblCxSituacao.BackColor = Color.Green;
                }
                else if (SelectedRow.Cells[23].Value.ToString() == "CANCELADA")
                {
                    lblValorSituacao.Text = "CANCELADA";
                    lblValorSituacao.ForeColor = Color.Red;
                    lblCxSituacao.BackColor = Color.Red;
                }
                else if (SelectedRow.Cells[23].Value.ToString() == "DEVOLVIDA")
                {
                    lblValorSituacao.Text = "DEVOLVIDA";
                    lblValorSituacao.ForeColor = Color.Orange;
                    lblCxSituacao.BackColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellEnter da grade de dados dtContaReceber.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellEnter da grade de dados dtContaReceber.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxConsumidor_Valor = null;
            }
        }

        private void cbbTipoConsumidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Inserir_Atualizar == true)
            {
                try
                {
                    cbbConsumidor.Items.Clear();
                    if (cbbTipoConsumidor.SelectedIndex == 0)
                    {
                        cbbConsumidor.Enabled = false;
                        cbbConsumidor.Text = null;
                        btnProcurar.Enabled = false;
                    }
                    else if (cbbTipoConsumidor.SelectedIndex == 1)
                    {
                        if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                        {
                            cbbConsumidor.Enabled = false;
                            cbbConsumidor.Text = null;
                        }
                        else
                        {
                            cbbConsumidor.Enabled = true;
                            btnProcurar.Enabled = true;
                            cbbConsumidor.Items.Add("");
                            foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                    }
                    else if (cbbTipoConsumidor.SelectedIndex == 2)
                    {
                        if (bllContasReceber.Sel_Forn_Conta_Receber() == null)
                        {
                            cbbConsumidor.Enabled = false;
                            cbbConsumidor.Text = null;
                        }
                        else
                        {
                            cbbConsumidor.Enabled = true;
                            btnProcurar.Enabled = true;
                            cbbConsumidor.Items.Add("");
                            foreach (DataRow dr in bllContasReceber.Sel_Forn_Conta_Receber().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                    }
                    else if (cbbTipoConsumidor.SelectedIndex == 3)
                    {
                        if (bllContasReceber.Sel_Func_Conta_Receber() == null)
                        {
                            cbbConsumidor.Enabled = false;
                            cbbConsumidor.Text = null;
                        }
                        else
                        {
                            cbbConsumidor.Enabled = true;
                            btnProcurar.Enabled = true;
                            cbbConsumidor.Items.Add("");
                            foreach (DataRow dr in bllContasReceber.Sel_Func_Conta_Receber().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbTipoConsumidor.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbTipoConsumidor.");
                    }
                    cbbConsumidor.Items.Clear();
                    cbbConsumidor.Text = null;
                    cbbTipoConsumidor.Text = null;
                }
            }
        }

        private void btnProcurarGrupo_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmPesqGrupo Grupo = new FrmPesqGrupo(3))
                {
                    if (Grupo.ShowDialog() == DialogResult.OK)
                    {

                        cbbGrupo.Items.Clear();
                        if (bllContasReceber.Sel_Grupo_Conta_Receber() == null)
                        {
                            cbbGrupo.Text = null;
                            cbbSubGrupo.Items.Clear();
                            cbbSubGrupo.Enabled = false;
                            cbbSubGrupo.Text = null;
                            btnProcurarSubgrupo.Enabled = false;
                            lblSubGrupo.Enabled = false;
                        }
                        else
                        {
                            cbbGrupo.Items.Add("");
                            foreach (DataRow dr in bllContasReceber.Sel_Grupo_Conta_Receber().Rows)
                            {
                                cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                cbbSubGrupo.Enabled = true;
                                btnProcurarSubgrupo.Enabled = true;
                                lblSubGrupo.Enabled = true;
                            }
                        }
                        cbbGrupo.Text = bllContasReceber._Grupo_PesqGrupo_Tabela;
                        bllContasReceber._Grupo_PesqGrupo_Tabela = null;
                        cbbGrupo.Select();
                    }
                }
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
            pEnabled.Enabled = true;
        }

        private void btnProcurarSubgrupo_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbGrupo.Text != "")
                {
                    string[] items = cbbGrupo.Text.Split('—');

                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 2))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbSubGrupo.Items.Clear();
                            if (bllContasReceber.Sel_SubGrupo_Conta_Receber(items[0]) == null)
                            {
                                cbbSubGrupo.Text = null;
                            }
                            else
                            {
                                cbbSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_SubGrupo_Conta_Receber(items[0]).Rows)
                                {
                                    cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            cbbSubGrupo.Text = bllContasReceber._SubGrupo_PesqSubGrupo_Tabela;
                            bllContasReceber._SubGrupo_PesqSubGrupo_Tabela = null;
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

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbTipoConsumidor.Text == "CLIENTES")
                {
                    using (FrmPesqCliente Clie = new FrmPesqCliente(6, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Clie.ShowDialog() == DialogResult.OK)
                        {
                            cbbConsumidor.Items.Clear();
                            if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                            {
                                cbbConsumidor.Text = null;
                            }
                            else
                            {
                                cbbConsumidor.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                                {
                                    cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                            //
                            cbbConsumidor.Text = bllContasReceber._Consumidor_PesqContaReceber;
                            bllContasReceber._Consumidor_PesqContaReceber = null;
                            cbbConsumidor.Select();
                        }
                    }
                }
                else if (cbbTipoConsumidor.Text == "FORNECEDORES")
                {
                    using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(4, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Forn.ShowDialog() == DialogResult.OK)
                        {
                            cbbConsumidor.Items.Clear();
                            if (bllContasReceber.Sel_Forn_Conta_Receber() == null)
                            {
                                cbbConsumidor.Text = null;
                            }
                            else
                            {
                                cbbConsumidor.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Forn_Conta_Receber().Rows)
                                {
                                    cbbConsumidor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                            //
                            cbbConsumidor.Text = bllContasReceber._Consumidor_PesqContaReceber;
                            bllContasReceber._Consumidor_PesqContaReceber = null;
                            cbbConsumidor.Select();
                        }
                    }
                }
                else if (cbbTipoConsumidor.Text == "FUNCIONARIOS")
                {
                    using (FrmPesqFuncionario Func = new FrmPesqFuncionario(4, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Func.ShowDialog() == DialogResult.OK)
                        {
                            cbbConsumidor.Items.Clear();
                            if (bllContasReceber.Sel_Func_Conta_Receber() == null)
                            {
                                cbbConsumidor.Text = null;
                            }
                            else
                            {
                                cbbConsumidor.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Func_Conta_Receber().Rows)
                                {
                                    cbbConsumidor.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                            //
                            cbbConsumidor.Text = bllContasReceber._Consumidor_PesqContaReceber;
                            bllContasReceber._Consumidor_PesqContaReceber = null;
                            cbbConsumidor.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbConsumidor.Text = null;
                bllContasReceber._Consumidor_PesqContaReceber = null;
            }
            pEnabled.Enabled = true;
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
                if (dtContaReceber.DataSource == null)
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
            _ComboboxConsumidor_Valor = null;
            _ComboboxGrupo_Valor = null;
            _ComboboxSubgrupo_Valor = null;
            ModoPesquisa();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllContasReceber.Sel_Conta_Receber_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtContaReceber.Select();
                }
                else
                {
                    DataGridViewRow SelectedRow = dtContaReceber.Rows[dtContaReceber.CurrentRow.Index];
                    if (bllContasReceber.Sel_Conta_Receber_Aberta_True_Mult(SelectedRow.Cells[0].Value.ToString()) == false)
                    {
                        MessageBox.Show("Não é possível alterar uma Conta [ Finalizada ] ou\n[ Renegociada ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtContaReceber.Select();
                    }
                    else
                    {
                        dtContaReceber.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                        btnNovo.Enabled = false;
                        btnCancelar.Visible = true;
                        btnAlterar.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnDuplicar.Enabled = false;
                        btnSalvar.Enabled = true;
                        grbBox1.Enabled = false;
                        grbBox2.Enabled = true;
                        txtParcela.Enabled = true;
                        cbbSubGrupo.Enabled = true;
                        lblSubGrupo.Enabled = true;
                        lblAsteriscoSubGrupo.Enabled = true;
                        btnProcurarSubgrupo.Enabled = true;
                        dtContaReceber.Enabled = false;
                        _Comando_Atualizar = true;
                        _Inserir_Atualizar = true;
                        lblCodigo.Enabled = true;
                        txtCodigo.Enabled = true;
                        txtPalavraChave.Select();
                        //
                        _ComboboxConsumidor_Valor = cbbConsumidor.Text;
                        _ComboboxGrupo_Valor = cbbGrupo.Text;
                        _ComboboxSubgrupo_Valor = cbbSubGrupo.Text;
                        //
                        if (cbbGrupo.Text != "")
                        {
                            cbbGrupo.Items.Clear();
                            if (bllContasReceber.Sel_Grupo_Conta_Receber() == null)
                            {
                                cbbGrupo.Text = null;
                            }
                            else
                            {
                                cbbGrupo.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Grupo_Conta_Receber().Rows)
                                {
                                    cbbGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            //
                            if (bllContasReceber.Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Receber(_ComboboxGrupo_Valor) != null)
                            {
                                foreach (DataRow dr in bllContasReceber.Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Receber(_ComboboxGrupo_Valor).Rows)
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
                                if (bllContasReceber.Sel_SubGrupo_Conta_Receber(cbbGrupo.Text) == null)
                                {
                                    cbbSubGrupo.Text = null;
                                }
                                else
                                {
                                    cbbSubGrupo.Items.Add("");
                                    foreach (DataRow dr in bllContasReceber.Sel_SubGrupo_Conta_Receber(cbbGrupo.Text).Rows)
                                    {
                                        cbbSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                    }
                                }
                                //
                                if (bllContasReceber.Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Receber(_ComboboxSubgrupo_Valor, cbbGrupo.Text) != null)
                                {
                                    foreach (DataRow dr in bllContasReceber.Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Receber(_ComboboxSubgrupo_Valor, cbbGrupo.Text).Rows)
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
                        if (cbbTipoConsumidor.SelectedIndex == 1)
                        {
                            if (cbbConsumidor.Text != "")
                            {
                                cbbConsumidor.Items.Clear();
                                if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                                {
                                    cbbConsumidor.Text = null;
                                }
                                else
                                {
                                    cbbConsumidor.Items.Add("");
                                    foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                                    {
                                        cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                                    }
                                }

                                if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaReceber(_ComboboxConsumidor_Valor) != null)
                                {
                                    foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaReceber(_ComboboxConsumidor_Valor).Rows)
                                    {
                                        cbbConsumidor.Text = dr["id_cliente"].ToString() + "—" + dr["nome"].ToString();
                                    }
                                    _ComboboxConsumidor_Valor = null;
                                }
                                else
                                {
                                    _ComboboxConsumidor_Valor = null;
                                    cbbConsumidor.Text = null;
                                }
                            }
                        }
                        else if (cbbTipoConsumidor.SelectedIndex == 2)
                        {
                            if (cbbConsumidor.Text != "")
                            {
                                cbbConsumidor.Items.Clear();
                                if (bllContasReceber.Sel_Forn_Conta_Receber() == null)
                                {
                                    cbbConsumidor.Text = null;
                                }
                                else
                                {
                                    cbbConsumidor.Items.Add("");
                                    foreach (DataRow dr in bllContasReceber.Sel_Forn_Conta_Receber().Rows)
                                    {
                                        cbbConsumidor.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                                    }
                                }

                                if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaReceber(_ComboboxConsumidor_Valor) != null)
                                {
                                    foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaReceber(_ComboboxConsumidor_Valor).Rows)
                                    {
                                        cbbConsumidor.Text = dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString();
                                    }
                                    _ComboboxConsumidor_Valor = null;
                                }
                            }
                            else
                            {
                                _ComboboxConsumidor_Valor = null;
                                cbbConsumidor.Text = null;
                            }
                        }
                        else if (cbbTipoConsumidor.SelectedIndex == 3)
                        {
                            if (cbbConsumidor.Text != "")
                            {
                                cbbConsumidor.Items.Clear();
                                if (bllContasReceber.Sel_Func_Conta_Receber() == null)
                                {
                                    cbbConsumidor.Text = null;
                                }
                                else
                                {
                                    cbbConsumidor.Items.Add("");
                                    foreach (DataRow dr in bllContasReceber.Sel_Func_Conta_Receber().Rows)
                                    {
                                        cbbConsumidor.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                                    }
                                }

                                if (bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaReceber(_ComboboxConsumidor_Valor) != null)
                                {
                                    foreach (DataRow dr in bllContasReceber.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaReceber(_ComboboxConsumidor_Valor).Rows)
                                    {
                                        cbbConsumidor.Text = dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString();
                                    }
                                    _ComboboxConsumidor_Valor = null;
                                }
                            }
                            else
                            {
                                _ComboboxConsumidor_Valor = null;
                                cbbConsumidor.Text = null;
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
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxConsumidor_Valor = null;
            }
        }

        private void dtContaReceber_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtContaReceber_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtContaReceber.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtContaReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtContaReceber_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtContaReceber.DataSource == null)
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                dtContaReceber.Enabled = false;
                btnDuplicar.Enabled = false;
                lblCxSituacao.Visible = false;
                lblValorSituacao.Visible = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                dtContaReceber.Enabled = true;
                btnDuplicar.Enabled = true;
                lblCxSituacao.Visible = true;
                lblValorSituacao.Visible = true;

                List<string> cor = new List<string>();
                List<string> grupo = new List<string>();

                if (bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A RECEBER") != null)
                {
                    for (int i = 0; i < bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A RECEBER").Rows.Count; i++)
                    {
                        DataRow dr = bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A RECEBER").Rows[i];
                        //
                        if (dr["cor_destaque"].ToString() != null & dr["cor_destaque"].ToString() != "")
                        {
                            cor.Add(dr["cor_destaque"].ToString());
                            grupo.Add(dr["id_grupo"].ToString());
                        }
                    }
                }

                for (int i = 0; i < dtContaReceber.Rows.Count; i++)
                {
                    for (int u = 0; u < cor.Count; u++)
                    {
                        if (cor[u] == "")
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        else if (cor[u] == "1" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                        else if (cor[u] == "2" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                        }
                        else if (cor[u] == "3" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                        }
                        else if (cor[u] == "4" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        else if (cor[u] == "5" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                        }
                        else if (cor[u] == "6" & grupo[u] == dtContaReceber.Rows[i].Cells[10].Value.ToString())
                        {
                            dtContaReceber.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllContasReceber.Sel_Conta_Receber_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtContaReceber.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir esta Conta a Receber?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllContasReceber.Sel_Conta_Receber_Aberta_True_Mult(txtCodigo.Text) == false)
                        {
                            MessageBox.Show("Não é possível excluir uma Conta [ Finalizada ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            btnExcluir.Select();
                        }
                        else if (bllContasReceber.Sel_Contas_Receber_Pagamento_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("A Conta a Receber selecionada está sendo utilizada por um Pagamento, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtContaReceber.Select();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            bllContasReceber.Excluir(txtCodigo.Text);
                            //
                            if (bllLembrete.Sel_Codigo_Tabela_Geradora(txtCodigo.Text, "CONTAS A RECEBER") != null)
                            {
                                string codigo = bllLembrete.Sel_Codigo_Tabela_Geradora(txtCodigo.Text, "CONTAS A RECEBER");
                                //
                                bllLembrete.Excluir(codigo);
                                //
                                bllLembrete.Excluir_Usuario_Lembrete(codigo);
                            }
                            //
                            bllRegistroAtividades.Salvar("EXCLUIU UMA CONTA A RECEBER.", "CONTAS A RECEBER", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a receber excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a receber excluída. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                            }
                            //
                            if (rbtnTodas.Checked == true)
                            {
                                if (bllContasReceber.Sel_Conta_Receber_Todas() == null)
                                {
                                    dtContaReceber.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Todas();
                                    dtContaReceber.Select();
                                }
                            }
                            else if (rbtnDescricao.Checked == true)
                            {
                                if (txtpDescricao.Text != "")
                                {
                                    if (bllContasReceber.Sel_Conta_Descricao_Receber(txtpDescricao.Text) == null)
                                    {
                                        dtContaReceber.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Descricao_Receber(txtpDescricao.Text);
                                        dtContaReceber.Select();
                                    }
                                }
                                else
                                {
                                    dtContaReceber.DataSource = null;
                                    Limpar();
                                }
                            }
                            else if (rbtnDestinatario.Checked == true)
                            {
                                if (cbbpConsumidor.Text != "" & cbbpTipoConsumidor.Text != "")
                                {
                                    if (bllContasReceber.Sel_Conta_Receber_Consumidor(cbbpConsumidor.Text, cbbpTipoConsumidor.Text) == null)
                                    {
                                        dtContaReceber.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Consumidor(cbbpConsumidor.Text, cbbpTipoConsumidor.Text);
                                        dtContaReceber.Select();
                                    }
                                }
                                else if (cbbpConsumidor.Text == "" & cbbpTipoConsumidor.Text != "")
                                {
                                    if (bllContasReceber.Sel_Conta_Tipo_Consumidor(cbbpTipoConsumidor.Text) == null)
                                    {
                                        dtContaReceber.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Tipo_Consumidor(cbbpTipoConsumidor.Text);
                                        dtContaReceber.Select();
                                    }
                                }
                                else
                                {
                                    dtContaReceber.DataSource = null;
                                    Limpar();
                                }
                            }
                            else
                            {
                                dtContaReceber.DataSource = null;
                                Limpar();
                            }
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            this.DialogResult = DialogResult.None;

                        }
                    }
                    else
                    {
                        if (dtContaReceber.DataSource != null)
                        {
                            dtContaReceber.Select();
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
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxConsumidor_Valor = null;
            }
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbpTipoConsumidor.Text == "CLIENTES")
                {
                    using (FrmPesqCliente Clie = new FrmPesqCliente(6, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Clie.ShowDialog() == DialogResult.OK)
                        {
                            cbbpConsumidor.Items.Clear();
                            if (bllContasReceber.Sel_Cliente_Conta_Receber() == null)
                            {
                                cbbpConsumidor.Text = null;
                            }
                            else
                            {
                                cbbpConsumidor.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Cliente_Conta_Receber().Rows)
                                {
                                    cbbpConsumidor.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString());
                                }
                            }
                            cbbpConsumidor.Text = bllContasReceber._Consumidor_PesqContaReceber;
                            bllContasReceber._Consumidor_PesqContaReceber = null;
                            cbbpConsumidor.Select();
                        }
                    }
                }
                else if (cbbpTipoConsumidor.Text == "FORNECEDORES")
                {
                    using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(4, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Forn.ShowDialog() == DialogResult.OK)
                        {
                            cbbpConsumidor.Items.Clear();
                            if (bllContasReceber.Sel_Forn_Conta_Receber() == null)
                            {
                                cbbpConsumidor.Text = null;
                            }
                            else
                            {
                                cbbpConsumidor.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Forn_Conta_Receber().Rows)
                                {
                                    cbbpConsumidor.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString());
                                }
                            }
                            cbbpConsumidor.Text = bllContasReceber._Consumidor_PesqContaReceber;
                            bllContasReceber._Consumidor_PesqContaReceber = null;
                            cbbpConsumidor.Select();
                        }
                    }
                }
                else if (cbbpTipoConsumidor.Text == "FUNCIONARIOS")
                {
                    using (FrmPesqFuncionario Func = new FrmPesqFuncionario(4, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Func.ShowDialog() == DialogResult.OK)
                        {
                            cbbpConsumidor.Items.Clear();
                            if (bllContasReceber.Sel_Func_Conta_Receber() == null)
                            {
                                cbbpConsumidor.Text = null;
                            }
                            else
                            {
                                cbbpConsumidor.Items.Add("");
                                foreach (DataRow dr in bllContasReceber.Sel_Func_Conta_Receber().Rows)
                                {
                                    cbbpConsumidor.Items.Add(dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString());
                                }
                            }
                            cbbpConsumidor.Text = bllContasReceber._Consumidor_PesqContaReceber;
                            bllContasReceber._Consumidor_PesqContaReceber = null;
                            cbbpConsumidor.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbpConsumidor.Text = null;
                bllContasReceber._Consumidor_PesqContaReceber = null;
            }
            pEnabled.Enabled = true;
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
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

        private void rtxtObs_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + rtxtObs.Text.Length + "/200";
        }

        private void txtPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtParcela.Select();
            }
        }

        private void txtPalavraChave_Enter(object sender, EventArgs e)
        {
            txtPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtPalavraChave.Text.Contains("'") || txtPalavraChave.Text.Contains(";") || txtPalavraChave.Text.Contains("="))
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
                    try
                    {
                        if (txtPalavraChave.Text != "")
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllContasReceber.Sel_Conta_Receber_Palavra_Chave_Alt(txtCodigo.Text, txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
                                }
                            }
                            else
                            {
                                if (bllContasReceber.Sel_Conta_Receber_Palavra_Chave(txtPalavraChave.Text) == true)
                                {
                                    MessageBox.Show("A Palavra-Chave informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtPalavraChave.Text = null;
                                    txtPalavraChave.Select();
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
            }
            txtPalavraChave.BackColor = Color.White;
        }

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnDuplicar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDuplicar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (bllContasReceber.Sel_Conta_Receber_Ainda_Existe(txtCodigo.Text) == false)
                {
                    MessageBox.Show("Não é possível adiconar parcelas pois este registro pois o mesmo já foi excluído..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtContaReceber.Select();
                }
                else
                {
                    if (bllContasReceber.Sel_Conta_Receber_Aberta_True_Mult(txtCodigo.Text) == false)
                    {
                        MessageBox.Show("Não é possível multiplicar uma Conta [ Finalizada ] ou\n[ Renegociada ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        using (FrmCadContaAdicionarParcelas Multi = new FrmCadContaAdicionarParcelas(1))
                        {
                            if (Multi.ShowDialog() == DialogResult.OK)
                            {

                                bllContasReceber._Data_Emissao_Multiplicada = mtxtDataEmissao.Text;
                                bllContasReceber._Data_Vencimento_Multiplicada = mtxtDataVencimento.Text;
                                //
                                bllContasReceber.Multiplicar(txtDescricao.Text.Trim(), cbbTipoConsumidor.Text, cbbConsumidor.Text, txtValorDocumento.Text, txtParcela.Text, cbbGrupo.Text, cbbSubGrupo.Text);
                                //
                                bllRegistroAtividades.Salvar("SALVOU UMA OU MAIS CONTAS A RECEBER", "CONTAS A RECEBER", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                //
                                dtContaReceber.DataSource = bllContasReceber.Sel_Conta_Receber_Consumidor(cbbConsumidor.Text, cbbTipoConsumidor.Text);
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a receber multiplicada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conta a receber multiplicada. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text);
                                }
                                //
                                bllContasReceber._Data_Emissao_Multiplicada = null;
                                bllContasReceber._Data_Vencimento_Multiplicada = null;
                                bllContasReceber._Dias = null;
                                bllContasReceber._Parcela = null;
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
                dtContaReceber.DataSource = null;
                rbtnDescricao.Checked = true;
                ModoPesquisa();
                _ComboboxGrupo_Valor = null;
                _ComboboxSubgrupo_Valor = null;
                _ComboboxConsumidor_Valor = null;
            }
            pEnabled.Enabled = true;
        }

        private void dtContaReceber_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 5 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPalavraChave.Select();
            }
        }
    }
}
