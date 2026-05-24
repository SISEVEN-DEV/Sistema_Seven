using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqNCM : Form
    {
        public FrmPesqNCM(string ncm, string excecao_ncm)
        {
            InitializeComponent();
            _NCM = ncm;
            _Excecao_NCM = excecao_ncm;
        }

        private string _NCM;
        private string _Excecao_NCM;

        private void FrmPesquisarNCM_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesquisarNCM iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesquisarNCM iniciado.");
                }
                rbtnCodigo.Checked = true;
                //
                if (_NCM != null)
                {
                    txtpNCM.Text = _NCM;
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    _Excecao_NCM = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesquisarNCM.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesquisarNCM.");
                }
            }
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNomeAluno_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnExcecao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnExcecao_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void txtpNCM_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtpNCM_Leave(object sender, EventArgs e)
        {
            if (txtpNCM.Text.Contains("'") || txtpNCM.Text.Contains(";") || txtpNCM.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpNCM.Text = null;
                txtpNCM.Select();
            }
            txtpNCM.BackColor = Color.White;
        }

        private void txtpNCM_Enter(object sender, EventArgs e)
        {
            txtpNCM.BackColor = Color.LightBlue;
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpNCM.Visible = true;
            txtpDescricao.Visible = false;
            lblPesquisar.Location = new Point(588, 21);
            lblPesquisar.Text = "Digite o ncm:";
            txtpNCM.Text = null;
            txtpNCM.Select();
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtpNCM.Visible = false;
            txtpDescricao.Visible = true;
            lblPesquisar.Location = new Point(347, 21);
            lblPesquisar.Text = "Digite a descrição:";
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnExcecao_CheckedChanged(object sender, EventArgs e)
        {
            txtpNCM.Visible = true;
            txtpDescricao.Visible = false;
            lblPesquisar.Location = new Point(503, 21);
            lblPesquisar.Text = "Digite o código da exceção:";
            txtpNCM.Text = null;
            txtpNCM.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtpNCM.Visible = false;
            txtpDescricao.Visible = false;
            lblPesquisar.Location = new Point(618, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            btnIncluir.Select();
            DataGridViewRow SelectedRow = dtNCM.Rows[dtNCM.CurrentRow.Index];
            bllProduto._NCM_PesqNCM_Tabela = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void FrmPesquisarNCM_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesquisarNCM foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesquisarNCM foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesquisarNCM.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesquisarNCM.");
                }
            }
        }

        private void FrmPesquisarNCM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por ncm, descrição, exceção e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllIBPT.Sel_IBPT_Descricao(txtpDescricao.Text) == null)
                        {
                            dtNCM.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtNCM.DataSource = bllIBPT.Sel_IBPT_Descricao(txtpDescricao.Text);
                            dtNCM.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpNCM.Text != "")
                    {
                        txtpNCM.Text = txtpNCM.Text.Replace(".", "");
                        //
                        if (bllIBPT.Sel_IBPT_NCM(txtpNCM.Text, _Excecao_NCM) == null)
                        {
                            dtNCM.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtNCM.DataSource = bllIBPT.Sel_IBPT_NCM(txtpNCM.Text, _Excecao_NCM);
                            dtNCM.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllIBPT.Sel_IBPT_Todos() == null)
                    {
                        dtNCM.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtNCM.DataSource = bllIBPT.Sel_IBPT_Todos();
                        dtNCM.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou ncm.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou ncm.");
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
                dtNCM.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void dtNCM_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtNCM.Columns[0].Visible = false;
            dtNCM.Columns[1].HeaderText = "NCM";
            dtNCM.Columns[2].HeaderText = "Descrição";
            dtNCM.Columns[3].HeaderText = "Tributo Federal";
            dtNCM.Columns[4].HeaderText = "Tributo Fed. Importado";
            dtNCM.Columns[5].HeaderText = "Tributo Estadual";
            dtNCM.Columns[6].HeaderText = "Tributo Municipal";
            dtNCM.Columns[7].HeaderText = "Exceção";

            dtNCM.Columns[1].Width = 150;
            dtNCM.Columns[2].Width = 515;
            dtNCM.Columns[3].Width = 150;
            dtNCM.Columns[4].Width = 150;
            dtNCM.Columns[5].Width = 150;
            dtNCM.Columns[6].Width = 150;
            dtNCM.Columns[7].Width = 100;

            dtNCM.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNCM.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtNCM.DefaultCellStyle.Font = new Font(dtNCM.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtNCM.Rows.Count;
        }

        private void dtNCM_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtNCM_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtNCM.DataSource == null)
            {
                dtNCM.Enabled = false;
                btnIncluir.Enabled = false;
            }
            else
            {
                dtNCM.Enabled = true;
                btnIncluir.Enabled = true;
            }
        }

        private void dtNCM_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtNCM.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtNCM.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                dtNCM.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtNCM.Columns[3].DefaultCellStyle.Format = "n2";
                dtNCM.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtNCM.Columns[4].DefaultCellStyle.Format = "n2";
                dtNCM.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtNCM.Columns[5].DefaultCellStyle.Format = "n2";
                dtNCM.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtNCM.Columns[6].DefaultCellStyle.Format = "n2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtNCM.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtNCM.");
                }
                rbtnDescricao.Checked = true;
                dtNCM.DataSource = null;
            }
        }

        private void dtNCM_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtNCM.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtNCM_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtNCM_DoubleClick(object sender, EventArgs e)
        {
            btnIncluir.Select();
            DataGridViewRow SelectedRow = dtNCM.Rows[dtNCM.CurrentRow.Index];
            bllProduto._NCM_PesqNCM_Tabela = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void dtNCM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtNCM.Rows[dtNCM.CurrentRow.Index];
                bllProduto._NCM_PesqNCM_Tabela = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[7].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
