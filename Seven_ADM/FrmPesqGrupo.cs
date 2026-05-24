using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqGrupo : Form
    {
        public FrmPesqGrupo(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void FrmPesqGrupo_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqGrupo iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqGrupo iniciado.");
                }
                rbtnDescricao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqGrupo.");
                }
                this.DialogResult = DialogResult.Abort;
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

        private void rbtnTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodos_MouseLeave(object sender, EventArgs e)
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

        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmPesqGrupo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            txtpNome.Visible = true;
            lblPesquisar.Location = new Point(169, 19);
            lblPesquisar.Text = "Digite a descrição:";
            txtpNome.Text = null;
            txtpNome.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = true;
            txtpNome.Visible = false;
            lblPesquisar.Location = new Point(456, 19);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = true;
            txtpCodigo.Visible = false;
            txtpNome.Visible = false;
            lblPesquisar.Location = new Point(380, 19);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtpPalavraChave.Visible = false;
            txtpCodigo.Visible = false;
            txtpNome.Visible = false;
            lblPesquisar.Location = new Point(469, 19);
            lblPesquisar.Text = "Exibir todo o cadastro:";
            btnPesquisar.Select();
        }

        private void txtpNome_Enter(object sender, EventArgs e)
        {
            txtpNome.BackColor = Color.LightBlue;
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

        private void txtpNome_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void dtPesquisa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtPesquisa.Columns[0].HeaderText = "Código";
            dtPesquisa.Columns[1].HeaderText = "Descrição";
            dtPesquisa.Columns[2].HeaderText = "Tabela";
            dtPesquisa.Columns[3].HeaderText = "Palavra-Chave";
            dtPesquisa.Columns[4].Visible = false;
            dtPesquisa.Columns[5].HeaderText = "Cor Destaque";

            dtPesquisa.Columns[0].Width = 95;
            dtPesquisa.Columns[1].Width = 350;
            dtPesquisa.Columns[2].Width = 275;
            dtPesquisa.Columns[3].Width = 125;
            dtPesquisa.Columns[5].Width = 125;

            dtPesquisa.DefaultCellStyle.Font = new Font(dtPesquisa.Font, FontStyle.Bold);

            dtPesquisa.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblRegistros.Text = "Registros: " + dtPesquisa.Rows.Count;

            for (int i = 0; i < dtPesquisa.Rows.Count; i++)
            {
                if (dtPesquisa.Rows[i].Cells[5].Value.ToString() == "")
                {
                    dtPesquisa.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else if (dtPesquisa.Rows[i].Cells[5].Value.ToString() == "1")
                {
                    dtPesquisa.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                }
                else if (dtPesquisa.Rows[i].Cells[5].Value.ToString() == "2")
                {
                    dtPesquisa.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                }
                else if (dtPesquisa.Rows[i].Cells[5].Value.ToString() == "3")
                {
                    dtPesquisa.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                }
                else if (dtPesquisa.Rows[i].Cells[5].Value.ToString() == "4")
                {
                    dtPesquisa.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                }
                else if (dtPesquisa.Rows[i].Cells[5].Value.ToString() == "5")
                {
                    dtPesquisa.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                }
                else if (dtPesquisa.Rows[i].Cells[5].Value.ToString() == "6")
                {
                    dtPesquisa.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private void dtPesquisa_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtPesquisa_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtPesquisa.DataSource == null)
            {
                btnIncluir.Enabled = false;
                dtPesquisa.Enabled = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                dtPesquisa.Enabled = true;
            }
        }

        private void dtPesquisa_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtPesquisa.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtPesquisa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtPesquisa_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtPesquisa.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtPesquisa.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtPesquisa_DoubleClick(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllProduto._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllSubGrupo._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllContasPagar._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 3)
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllContasReceber._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 4)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllSaidasProdutos._Saidas_Prod_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 5)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllClieCons._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 6)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllServico._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 7)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllDocumentos._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllProduto._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllSubGrupo._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllContasPagar._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 3)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllContasReceber._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 4)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllSaidasProdutos._Saidas_Prod_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 5)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllClieCons._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 6)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllServico._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 7)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                bllDocumentos._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Formulario == 1)
                {
                    if (rbtnDescricao.Checked == true)
                    {
                        if (txtpNome.Text != "")
                        {
                            if (bllGrupo.Sel_Grupo_Descricao(txtpNome.Text) == null)
                            {
                                dtPesquisa.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtPesquisa.DataSource = bllGrupo.Sel_Grupo_Descricao(txtpNome.Text);
                                dtPesquisa.Select();
                            }
                        }
                    }
                    else if (rbtnCodigo.Checked == true)
                    {
                        if (txtpCodigo.Text != "")
                        {
                            if (bllGrupo.Sel_Grupo_Codigo(txtpCodigo.Text) == null)
                            {
                                dtPesquisa.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtPesquisa.DataSource = bllGrupo.Sel_Grupo_Codigo(txtpCodigo.Text);
                                dtPesquisa.Select();
                            }
                        }
                    }
                    else if (rbtnPalavraChave.Checked == true)
                    {
                        if (txtpPalavraChave.Text != "")
                        {
                            if (bllGrupo.Sel_Grupo_Palavra_Chave(txtpPalavraChave.Text) == null)
                            {
                                dtPesquisa.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtPesquisa.DataSource = bllGrupo.Sel_Grupo_Palavra_Chave(txtpPalavraChave.Text);
                                dtPesquisa.Select();
                            }
                        }
                    }
                    else if (rbtnTodos.Checked == true)
                    {
                        if (bllGrupo.Sel_Grupo_Todos() == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllGrupo.Sel_Grupo_Todos();
                            dtPesquisa.Select();
                        }
                    }
                }
                else
                {
                    if (rbtnDescricao.Checked == true)
                    {
                        if (txtpNome.Text != "")
                        {
                            if (bllGrupo.Sel_Grupo_Descricao_Pesq(txtpNome.Text, _Formulario) == null)
                            {
                                dtPesquisa.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtPesquisa.DataSource = bllGrupo.Sel_Grupo_Descricao_Pesq(txtpNome.Text, _Formulario);
                                dtPesquisa.Select();
                            }
                        }
                    }
                    else if (rbtnCodigo.Checked == true)
                    {
                        if (txtpCodigo.Text != "")
                        {
                            if (bllGrupo.Sel_Grupo_Codigo_Pesq(txtpCodigo.Text, _Formulario) == null)
                            {
                                dtPesquisa.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtPesquisa.DataSource = bllGrupo.Sel_Grupo_Codigo_Pesq(txtpCodigo.Text, _Formulario);
                                dtPesquisa.Select();
                            }
                        }
                    }
                    else if (rbtnPalavraChave.Checked == true)
                    {
                        if (txtpPalavraChave.Text != "")
                        {
                            if (bllGrupo.Sel_Grupo_Palavra_Chave_Pesq(txtpPalavraChave.Text, _Formulario) == null)
                            {
                                dtPesquisa.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtPesquisa.DataSource = bllGrupo.Sel_Grupo_Palavra_Chave_Pesq(txtpPalavraChave.Text, _Formulario);
                                dtPesquisa.Select();
                            }
                        }
                    }
                    else if (rbtnTodos.Checked == true)
                    {
                        if (bllGrupo.Sel_Grupo_Todos_Pesq(_Formulario) == null)
                        {
                            dtPesquisa.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtPesquisa.DataSource = bllGrupo.Sel_Grupo_Todos_Pesq(_Formulario);
                            dtPesquisa.Select();
                        }
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou grupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou grupo.");
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
                dtPesquisa.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void FrmPesqGrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqGrupo foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqGrupo foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqGrupo.");
                }
            }
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
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

        private void dtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_Formulario == 0)
                {
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllProduto._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllSubGrupo._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllContasPagar._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 3)
                {
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllContasReceber._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 4)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllSaidasProdutos._Saidas_Prod_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 5)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllClieCons._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 6)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllServico._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 7)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    bllDocumentos._Grupo_PesqGrupo_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
