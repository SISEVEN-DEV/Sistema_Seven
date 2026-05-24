using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqItemServico : Form
    {
        public FrmPesqItemServico(string item_servico)
        {
            InitializeComponent();
            _Item_Servico = item_servico;
        }

        private string _Item_Servico;

        private void FrmPesqItemServico_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqItemServico iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqItemServico iniciado.");
                }
                rbtnCodigo.Checked = true;
                //
                if (_Item_Servico != null)
                {
                    string[] items = _Item_Servico.Split('—');
                    //
                    txtpItemServico.Text = items[0];
                    //
                    btnPesquisar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqItemServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqItemServico.");
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

        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
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

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpNCM_Enter(object sender, EventArgs e)
        {
            txtpItemServico.BackColor = Color.LightBlue;
        }

        private void txtpNCM_Leave(object sender, EventArgs e)
        {
            if (txtpItemServico.Text.Contains("'") || txtpItemServico.Text.Contains(";") || txtpItemServico.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpItemServico.Text = null;
                txtpItemServico.Select();
            }
            txtpItemServico.BackColor = Color.White;
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpItemServico.Visible = true;
            txtpDescricao.Visible = false;
            lblPesquisar.Location = new Point(525, 21);
            lblPesquisar.Text = "Digite o item de serviço:";
            txtpItemServico.Text = null;
            txtpItemServico.Select();
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtpItemServico.Visible = false;
            txtpDescricao.Visible = true;
            lblPesquisar.Location = new Point(347, 21);
            lblPesquisar.Text = "Digite a descrição:";
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtpItemServico.Visible = false;
            txtpDescricao.Visible = false;
            lblPesquisar.Location = new Point(618, 21);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por item de serviço, descrição e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllIBPT.Sel_IBPT_Servico_Descricao(txtpDescricao.Text) == null)
                        {
                            dtItemServico.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtItemServico.DataSource = bllIBPT.Sel_IBPT_Servico_Descricao(txtpDescricao.Text);
                            dtItemServico.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpItemServico.Text != "")
                    {
                        txtpItemServico.Text = txtpItemServico.Text.Replace(".", "");
                        //
                        if (bllIBPT.Sel_IBPT_Servico(txtpItemServico.Text) == null)
                        {
                            dtItemServico.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtItemServico.DataSource = bllIBPT.Sel_IBPT_Servico(txtpItemServico.Text);
                            dtItemServico.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllIBPT.Sel_IBPT_Servico_Todos() == null)
                    {
                        dtItemServico.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtItemServico.DataSource = bllIBPT.Sel_IBPT_Servico_Todos();
                        dtItemServico.Select();
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
                dtItemServico.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void FrmPesqItemServico_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void dtNCM_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtItemServico.Rows[dtItemServico.CurrentRow.Index];
                bllServico._ItemServico_PesqItemServico_Tabela = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento DoubleClick do datagridview dtItemServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento DoubleClick do datagridview dtItemServico.");
                }
            }
        }

        private void dtNCM_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtItemServico.Columns[0].Visible = false;
            dtItemServico.Columns[1].HeaderText = "Item de Serviço";
            dtItemServico.Columns[2].HeaderText = "Descrição";
            dtItemServico.Columns[3].HeaderText = "Tributo Federal";
            dtItemServico.Columns[4].HeaderText = "Tributo Fed. Importado";
            dtItemServico.Columns[5].HeaderText = "Tributo Estadual";
            dtItemServico.Columns[6].HeaderText = "Tributo Municipal";
            dtItemServico.Columns[7].Visible = false;

            dtItemServico.Columns[1].Width = 150;
            dtItemServico.Columns[2].Width = 515;
            dtItemServico.Columns[3].Width = 150;
            dtItemServico.Columns[4].Width = 150;
            dtItemServico.Columns[5].Width = 150;
            dtItemServico.Columns[6].Width = 150;

            dtItemServico.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemServico.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtItemServico.DefaultCellStyle.Font = new Font(dtItemServico.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtItemServico.Rows.Count;
        }

        private void dtNCM_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtItemServico.DataSource == null)
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

        private void dtNCM_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtItemServico.DataSource == null)
            {
                dtItemServico.Enabled = false;
                btnIncluir.Enabled = false;
            }
            else
            {
                dtItemServico.Enabled = true;
                btnIncluir.Enabled = true;
            }
        }

        private void dtNCM_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtItemServico.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtItemServico.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                dtItemServico.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItemServico.Columns[3].DefaultCellStyle.Format = "n2";
                dtItemServico.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItemServico.Columns[4].DefaultCellStyle.Format = "n2";
                dtItemServico.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItemServico.Columns[5].DefaultCellStyle.Format = "n2";
                dtItemServico.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItemServico.Columns[6].DefaultCellStyle.Format = "n2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtItemServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtItemServico.");
                }
                rbtnDescricao.Checked = true;
                dtItemServico.DataSource = null;
            }
        }

        private void dtItemServico_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtItemServico.Rows[dtItemServico.CurrentRow.Index];

                if (e.KeyCode == Keys.Enter)
                {
                    btnIncluir.Select();
                    bllServico._ItemServico_PesqItemServico_Tabela = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyDown do datagridview dtItemServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyDown do datagridview dtItemServico.");
                }
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtItemServico.Rows[dtItemServico.CurrentRow.Index];
                //
                btnIncluir.Select();
                bllServico._ItemServico_PesqItemServico_Tabela = SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyDown do datagridview dtItemServico.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyDown do datagridview dtItemServico.");
                }
            }
        }

        private void dtItemServico_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }
    }
}
