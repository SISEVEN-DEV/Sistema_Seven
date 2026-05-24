using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqFormaPagamento : Form
    {
        public FrmPesqFormaPagamento(byte formulario, string codigo_pagamento, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Codigo = codigo_pagamento;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Formulario;
        string _Codigo;
        string _Usuario;
        string _Cod_PDV_Computador;

        private void FrmPesqFormaPagamento_Load(object sender, EventArgs e)
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

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqFormaPagamento iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqFormaPagamento iniciado.");
                }
                if (_Codigo == null || _Codigo == "")
                {
                    rbtnDescricao.Checked = true;
                }
                else
                {
                    rbtnCodigo.Checked = true;
                    txtpCodigo.Text = _Codigo;
                    btnPesquisar_Click(sender, e);
                }
                //
                if (bllUsuario.Sel_Permitir_Cadastrar_PDV_Usuario(_Usuario) == true)
                {
                    btnCadastrar.Visible = true;
                }
                else
                {
                    btnCadastrar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqFormaPagamento.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtpDescricao.Visible = true;
            txtpCodigo.Visible = false;
            cbbpTipoPagamento.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(315, 21);
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = true;
            cbbpTipoPagamento.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(520, 21);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTodas_CheckedChanged(object sender, EventArgs e)
        {
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            cbbpTipoPagamento.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(531, 21);
            btnPesquisar.Select();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo_operacao;
                if (_Formulario == 3 || _Formulario == 4)
                {
                    tipo_operacao = "SAIDA";
                }
                else
                {
                    tipo_operacao = "ENTRADA";
                }
                //
                if (rbtnTodas.Checked == true)
                {
                    if (bllFormaPagamento.Sel_Forma_Pagar_Todos(tipo_operacao, true) == null)
                    {
                        dtFormaPagamento.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_Todos(tipo_operacao, true);
                        dtFormaPagamento.Select();
                    }
                }
                else if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllFormaPagamento.Sel_Forma_Pagar_Descricao(txtpDescricao.Text, tipo_operacao, true) == null)
                        {
                            dtFormaPagamento.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_Descricao(txtpDescricao.Text, tipo_operacao, true);
                            dtFormaPagamento.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllFormaPagamento.Sel_Forma_Pagar_Codigo(txtpCodigo.Text, tipo_operacao, true) == null)
                        {
                            dtFormaPagamento.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_Codigo(txtpCodigo.Text, tipo_operacao, true);
                            dtFormaPagamento.Select();
                        }
                    }
                }
                else if (rbtnTipo.Checked == true)
                {
                    if (cbbpTipoPagamento.Text != "")
                    {
                        if (bllFormaPagamento.Sel_Forma_Tipo_Pagamento(cbbpTipoPagamento.Text, tipo_operacao, true) == null)
                        {
                            dtFormaPagamento.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Tipo_Pagamento(cbbpTipoPagamento.Text, tipo_operacao, true);
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
            }
        }

        private void dtFormaPagamento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtFormaPagamento.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[3].DefaultCellStyle.Format = "n2";
                dtFormaPagamento.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[4].DefaultCellStyle.Format = "n2";
                dtFormaPagamento.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[5].DefaultCellStyle.Format = "n2";
                dtFormaPagamento.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[6].DefaultCellStyle.Format = "n2";
                dtFormaPagamento.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[7].DefaultCellStyle.Format = "n2";
                dtFormaPagamento.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtFormaPagamento.Columns[14].DefaultCellStyle.Format = "n2";

                dtFormaPagamento.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtFormaPagamento.DefaultCellStyle.SelectionForeColor = Color.Black;
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

        private void btnIncluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncluir_MouseLeave(object sender, EventArgs e)
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

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpDescricao.Text = null;
            }
            txtpDescricao.BackColor = Color.White;
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            if (txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpCodigo.Text = null;
                txtpCodigo.BackColor = Color.White;
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

        private void cbbpTipoPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void FrmPesqFormaPagamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtFormaPagamento_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFormaPagamento.DataSource == null)
            {
                dtFormaPagamento.Enabled = false;
                btnIncluir.Enabled = false;
            }
            else
            {
                dtFormaPagamento.Enabled = true;
                btnIncluir.Enabled = true;
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, tipo de pagamento e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtFormaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    btnIncluir.Select();
                    if (_Formulario == 0)
                    {
                        DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                        //
                        if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                        {
                            bllVenda._PDV_PesqForma_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        }
                        else
                        {
                            bllVenda._PDV_PesqForma_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 1)
                    {
                        DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                        //
                        if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                        {
                            MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtFormaPagamento.Select();
                        }
                        else
                        {
                            bllContasReceber._Forma_Pagamento_PesqFormaPagamento_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 2)
                    {
                        DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                        //
                        if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                        {
                            MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para uma entrada de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtFormaPagamento.Select();
                        }
                        else
                        {
                            bllVenda._PDV_PesqForma_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 3)
                    {
                        DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                        //
                        if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                        {
                            MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtFormaPagamento.Select();
                        }
                        else
                        {
                            bllContasPagar._Forma_Pag_PesqFormaPag_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 4)
                    {
                        DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                        //
                        if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                        {
                            MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtFormaPagamento.Select();
                        }
                        else
                        {
                            bllContasPagar._Forma_Pag_PesqFormaPag_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 5)
                    {
                        DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                        //
                        if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                        {
                            MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtFormaPagamento.Select();
                        }
                        else
                        {
                            bllPedAnotaAI._Pagamento_PesqPagamento_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do dtFormaPagamento.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keydown do dtFormaPagamento.");
                    }
                }
            }
        }

        private void dtFormaPagamento_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnIncluir.Select();
                if (_Formulario == 0)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        bllVenda._PDV_PesqForma_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    }
                    else
                    {
                        bllVenda._PDV_PesqForma_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtFormaPagamento.Select();
                    }
                    else
                    {
                        bllContasReceber._Forma_Pagamento_PesqFormaPagamento_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 2)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para uma entrada de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtFormaPagamento.Select();
                    }
                    else
                    {
                        bllVenda._PDV_PesqForma_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 3)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtFormaPagamento.Select();
                    }
                    else
                    {
                        bllContasPagar._Forma_Pag_PesqFormaPag_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 4)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtFormaPagamento.Select();
                    }
                    else
                    {
                        bllContasPagar._Forma_Pag_PesqFormaPag_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 5)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtFormaPagamento.Select();
                    }
                    else
                    {
                        bllPedAnotaAI._Pagamento_PesqPagamento_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento doubleclick do dtFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento doubleclick do dtFormaPagamento.");
                }
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                btnIncluir.Select();
                if (_Formulario == 0)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        bllVenda._PDV_PesqForma_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    }
                    else
                    {
                        bllVenda._PDV_PesqForma_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtFormaPagamento.Select();
                    }
                    else
                    {
                        bllContasReceber._Forma_Pagamento_PesqFormaPagamento_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 2)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para uma entrada de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtFormaPagamento.Select();
                    }
                    else
                    {
                        bllVenda._PDV_PesqForma_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 3)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtFormaPagamento.Select();
                    }
                    else
                    {
                        bllContasPagar._Forma_Pag_PesqFormaPag_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 4)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtFormaPagamento.Select();
                    }
                    else
                    {
                        bllContasPagar._Forma_Pag_PesqFormaPag_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (_Formulario == 5)
                {
                    DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                    //
                    if (SelectedRow.Cells[2].Value.ToString() == "NOTA PROMISSORIA")
                    {
                        MessageBox.Show("Não é possível adicionar a forma de pagamento [ Nota Promissória ] para um pagamento de Nota Promissória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtFormaPagamento.Select();
                    }
                    else
                    {
                        bllPedAnotaAI._Pagamento_PesqPagamento_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
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
            }
        }

        private void FrmPesqFormaPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário pesquisar FrmPesqFormaPagamento foi finalizado.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário pesquisar FrmPesqFormaPagamento foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqFormaPagamento.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
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

        private void rbtnTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTipo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTipo_CheckedChanged(object sender, EventArgs e)
        {
            txtpDescricao.Visible = false;
            txtpCodigo.Visible = false;
            cbbpTipoPagamento.Visible = true;
            lblPesquisar.Text = "Escolha o tipo de pagamento:";
            lblPesquisar.Location = new Point(339, 21);
            cbbpTipoPagamento.Text = null;
            cbbpTipoPagamento.Select();
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

        private void dtFormaPagamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void btnCadastrar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadastrar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllLicenca.Verificar_Data_Licenca() != null)
                {
                    DataRow drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                    //
                    if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 0)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar hoje em " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 1)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar em 1 dia " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 2)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar em 2 dias " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 3)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar em 3 dias " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 4)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar em 4 dias " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 5)
                    {
                        DialogResult = MessageBox.Show("ATENÇÃO!\nA licença do seu software vai expirar em 5 dias " + drLic["data_expiracao"].ToString().Remove(10) + ".\n\nDeseja aplicar a licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                            {
                                if (Lic.ShowDialog() == DialogResult.OK)
                                {
                                    drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                    //
                                    MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else if (bllLicenca.Verificar_Licenca(DateTime.Now.ToShortDateString()) != true)
                    {
                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(0))
                        {
                            if (Lic.ShowDialog() == DialogResult.OK)
                            {
                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                //
                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                //
                using (FrmCadFormaPagamento Pag = new FrmCadFormaPagamento(_Usuario, _Cod_PDV_Computador, 1))
                {
                    if (Pag.ShowDialog() == DialogResult.OK)
                    {
                        if (bllFormaPagamento.Sel_Forma_Pagar_Codigo(bllFormaPagamento._Cod_Forma_Pagamento_Cadastro, "", true) == null)
                        {
                            dtFormaPagamento.DataSource = null;
                        }
                        else
                        {
                            dtFormaPagamento.DataSource = bllFormaPagamento.Sel_Forma_Pagar_Codigo(bllFormaPagamento._Cod_Forma_Pagamento_Cadastro, "", true);
                            dtFormaPagamento.Select();
                        }
                    }
                    //
                    bllFormaPagamento._Cod_Forma_Pagamento_Cadastro = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnCadastrar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnCadastrar.");
                }
            }
        }

        private void dtFormaPagamento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
