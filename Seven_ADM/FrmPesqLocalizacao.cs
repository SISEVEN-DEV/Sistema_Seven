using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqLocalizacao : Form
    {
        public FrmPesqLocalizacao(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        byte _Formulario;

        private void FrmPesqLocalizacao_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqLocalizacao iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqLocalizacao iniciado.");
                }
                rbtnDescricao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqLocalizacao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqLocalizacao.");
                }
                this.DialogResult = DialogResult.None;
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

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
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

        private void dtLocalizacao_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtLocalizacao.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtLocalizacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(204, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = true;
            txtpDescricao.Text = null;
            txtpPalavraChave.Visible = false;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(419, 21);
            txtpCodigo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Text = null;
            txtpPalavraChave.Visible = false;
            txtpCodigo.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite a palavra-chave:";
            lblPesquisar.Location = new Point(338, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Visible = true;
            txtpPalavraChave.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(429, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
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
                this.DialogResult = DialogResult.None;
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {

                if (rbtnTodos.Checked == true)
                {
                    if (bllLocalizacao.Sel_Localizacao_Todos() == null)
                    {
                        dtLocalizacao.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtLocalizacao.DataSource = bllLocalizacao.Sel_Localizacao_Todos();
                        dtLocalizacao.Select();
                    }
                }
                else if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllLocalizacao.Sel_Localizacao_Descricao(txtpDescricao.Text) == null)
                        {
                            dtLocalizacao.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtLocalizacao.DataSource = bllLocalizacao.Sel_Localizacao_Descricao(txtpDescricao.Text);
                            dtLocalizacao.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllLocalizacao.Sel_Localizacao_Codigo(txtpCodigo.Text) == null)
                        {
                            dtLocalizacao.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtLocalizacao.DataSource = bllLocalizacao.Sel_Localizacao_Codigo(txtpCodigo.Text);
                            dtLocalizacao.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllLocalizacao.Sel_Localizacao_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtLocalizacao.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtLocalizacao.DataSource = bllLocalizacao.Sel_Localizacao_Palavra_Chave(txtpPalavraChave.Text);
                            dtLocalizacao.Select();
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou localizacao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou localizacao.");
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
                dtLocalizacao.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void dtLocalizacao_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtLocalizacao.Columns[0].HeaderText = "Código";
            dtLocalizacao.Columns[1].HeaderText = "Descrição";
            dtLocalizacao.Columns[2].HeaderText = "Palavra-Chave";
            dtLocalizacao.Columns[3].Visible = false;

            dtLocalizacao.Columns[0].Width = 95;
            dtLocalizacao.Columns[1].Width = 515;
            dtLocalizacao.Columns[2].Width = 105;

            dtLocalizacao.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLocalizacao.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLocalizacao.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLocalizacao.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLocalizacao.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtLocalizacao.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtLocalizacao.DefaultCellStyle.Font = new Font(dtLocalizacao.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtLocalizacao.Rows.Count;
        }

        private void dtLocalizacao_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtLocalizacao_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtLocalizacao.DataSource == null)
            {
                btnIncluir.Enabled = false;
                dtLocalizacao.Enabled = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                dtLocalizacao.Enabled = true;
            }
        }

        private void dtLocalizacao_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtLocalizacao.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtLocalizacao.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtLocalizacao.Rows[dtLocalizacao.CurrentRow.Index];
                bllProduto._Localizacao_PesqLocalizacao_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtLocalizacao.Rows[dtLocalizacao.CurrentRow.Index];
                bllInventario._Localizacao_PesqLocalizacao_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtLocalizacao_DoubleClick(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtLocalizacao.Rows[dtLocalizacao.CurrentRow.Index];
                bllProduto._Localizacao_PesqLocalizacao_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtLocalizacao.Rows[dtLocalizacao.CurrentRow.Index];
                bllInventario._Localizacao_PesqLocalizacao_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
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

        private void FrmPesqLocalizacao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtLocalizacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_Formulario == 0)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtLocalizacao.Rows[dtLocalizacao.CurrentRow.Index];
                    bllProduto._Localizacao_PesqLocalizacao_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtLocalizacao.Rows[dtLocalizacao.CurrentRow.Index];
                    bllInventario._Localizacao_PesqLocalizacao_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void FrmPesqLocalizacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqLocalizacao foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqLocalizacao foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqLocalizacao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqLocalizacao.");
                }
            }
        }
    }
}
