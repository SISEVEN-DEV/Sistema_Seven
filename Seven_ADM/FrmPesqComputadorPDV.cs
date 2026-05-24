using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqComputadorPDV : Form
    {
        public FrmPesqComputadorPDV(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void FrmPesqComputadorPDV_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqComputadorPDV iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqComputadorPDV iniciado.");
                }
                //
                rbtnNome.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqComputadorPDV.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqComputadorPDV.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnPesquisar.Select();
            try
            {
                if (rbtnNome.Checked == true)
                {
                    if (txtpNome.Text != "")
                    {
                        if (bllCadastroComputadores.Sel_Nome_Computador_CadComputador(txtpNome.Text) == null)
                        {
                            dtCompPDV.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtCompPDV.DataSource = bllCadastroComputadores.Sel_Nome_Computador_CadComputador(txtpNome.Text);
                            dtCompPDV.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllCadastroComputadores.Sel_Codigo_Computador_CadComputador(txtpCodigo.Text) == null)
                        {
                            dtCompPDV.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtCompPDV.DataSource = bllCadastroComputadores.Sel_Codigo_Computador_CadComputador(txtpCodigo.Text);
                            dtCompPDV.Select();
                        }
                    }
                }
                else if (rbtnTipo.Checked == true)
                {
                    if (cbbTipo.Text != "")
                    {
                        if (bllCadastroComputadores.Sel_Tipo_Computador_CadComputador(cbbTipo.Text) == null)
                        {
                            dtCompPDV.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtCompPDV.DataSource = bllCadastroComputadores.Sel_Tipo_Computador_CadComputador(cbbTipo.Text);
                            dtCompPDV.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllCadastroComputadores.Sel_Todos_Computador_CadComputador() == null)
                    {
                        dtCompPDV.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtCompPDV.DataSource = bllCadastroComputadores.Sel_Todos_Computador_CadComputador();
                        dtCompPDV.Select();
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
                dtCompPDV.DataSource = null;
                rbtnNome.Checked = true;
            }
        }

        private void rbtnNome_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNome_MouseLeave(object sender, EventArgs e)
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

        private void dtCompPDV_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtCompPDV.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtCompPDV_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtCompPDV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtCompPDV.Columns[0].HeaderText = "Código";
                dtCompPDV.Columns[1].HeaderText = "Nome";
                dtCompPDV.Columns[2].Visible = false;
                dtCompPDV.Columns[3].HeaderText = "Tipo";
                dtCompPDV.Columns[4].Visible = false;
                dtCompPDV.Columns[5].Visible = false;

                dtCompPDV.Columns[0].Width = 70;
                dtCompPDV.Columns[1].Width = 275;
                dtCompPDV.Columns[3].Width = 173;

                dtCompPDV.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCompPDV.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCompPDV.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCompPDV.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCompPDV.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCompPDV.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtCompPDV.DefaultCellStyle.Font = new Font(dtCompPDV.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtCompPDV.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtCompPDV.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtCompPDV.");
                }
                dtCompPDV.DataSource = null;
                rbtnNome.Checked = true;
            }

        }

        private void dtCompPDV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtCompPDV.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtCompPDV.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtCompPDV_DoubleClick(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllHistCaixa._Hist_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllVenda._Hist_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllAbert_Fech_Caixa._Abert_Fech_Cx_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 3)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllFluxoCaixa._Fluxo_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 4)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllSaidasProdutos._Saidas_Prod_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 5)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllSangriaSuprimento._SangriaSuprimento_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 6)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllDevolucao._Devolucao_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 7)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllOrcamento._Orc_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }

        }

        private void dtCompPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_Formulario == 0)
                {
                    DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                    bllHistCaixa._Hist_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                    bllVenda._Hist_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                    bllAbert_Fech_Caixa._Abert_Fech_Cx_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 3)
                {
                    DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                    bllFluxoCaixa._Fluxo_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 4)
                {
                    DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                    bllSaidasProdutos._Saidas_Prod_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 5)
                {
                    DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                    bllSangriaSuprimento._SangriaSuprimento_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 6)
                {
                    DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                    bllDevolucao._Devolucao_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 7)
                {
                    DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                    bllOrcamento._Orc_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }

            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllHistCaixa._Hist_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllVenda._Hist_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllAbert_Fech_Caixa._Abert_Fech_Cx_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 3)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllFluxoCaixa._Fluxo_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 4)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllSaidasProdutos._Saidas_Prod_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 5)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllSangriaSuprimento._SangriaSuprimento_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 6)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllDevolucao._Devolucao_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 7)
            {
                DataGridViewRow SelectedRow = dtCompPDV.Rows[dtCompPDV.CurrentRow.Index];
                bllOrcamento._Orc_PesqCompPDV_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void FrmPesqComputadorPDV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmPesqComputadorPDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqComputadorPDV foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqComputadorPDV foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqComputadorPDV.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqComputadorPDV.");
                }
            }
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.LightBlue;
        }

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpNome_Leave(object sender, EventArgs e)
        {
            if (txtpNome.Text.Contains("'") || txtpNome.Text.Contains(";") || txtpNome.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpNome.Text = null;
                txtpNome.Select();
            }
            txtpNome.BackColor = Color.White;
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

        private void rbtnNome_CheckedChanged(object sender, EventArgs e)
        {
            cbbTipo.Visible = false;
            txtpCodigo.Visible = false;
            txtpNome.Visible = true;
            lblPesquisar.Text = "Digite o nome:";
            lblPesquisar.Location = new Point(207, 21);
            txtpNome.Text = null;
            txtpNome.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            cbbTipo.Visible = false;
            txtpCodigo.Visible = true;
            txtpNome.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(365, 21);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged_1(object sender, EventArgs e)
        {
            cbbTipo.Visible = false;
            txtpCodigo.Visible = false;
            txtpNome.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(379, 21);
            btnPesquisar.Select();
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por nome, código, tipo e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;

        }

        private void dtCompPDV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void rbtnTipo_CheckedChanged(object sender, EventArgs e)
        {
            cbbTipo.Visible = true;
            txtpCodigo.Visible = false;
            txtpNome.Visible = false;
            lblPesquisar.Text = "Escolha o tipo:";
            lblPesquisar.Location = new Point(304, 21);
            cbbTipo.Text = null;
            cbbTipo.Select();
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
                btnPesquisar.Select();
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

        private void rbtnTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTipo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtCompPDV_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtCompPDV.DataSource == null)
            {
                btnIncluir.Enabled = false;
                dtCompPDV.Enabled = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                dtCompPDV.Enabled = true;
            }
        }
    }
}
