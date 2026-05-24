using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqCFOP : Form
    {
        public FrmPesqCFOP(byte formulario, string finalidade, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Finalidade = finalidade;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Formulario;
        private string _Finalidade;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmPesqCFOP_Load(object sender, EventArgs e)
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
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqCFOP iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqCFOP iniciado.");
                }
                rbtnCodigo.Checked = true;
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
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqCFOP.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqCFOP.");
                }
                this.DialogResult = DialogResult.None;
            }
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

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite o código do CFOP:";
            lblPesquisar.Location = new Point(415, 21);
            txtpCodigo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(254, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = true;
            txtpCodigo.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(479, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            btnPesquisar.Select();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(_Formulario == 1)
                {
                    if (rbtnDescricao.Checked == true)
                    {
                        if (txtpDescricao.Text != "")
                        {
                            if (bllDFe.Sel_CFOP_Descricao_DFe(txtpDescricao.Text, _Finalidade) == null)
                            {
                                dtCFOP.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtCFOP.DataSource = bllDFe.Sel_CFOP_Descricao_DFe(txtpDescricao.Text, _Finalidade);
                                dtCFOP.Select();
                            }
                        }
                    }
                    else if (rbtnCodigo.Checked == true)
                    {
                        if (txtpCodigo.Text != "")
                        {
                            if (bllDFe.Sel_CFOP_Codigo_CFOP_DFe(txtpCodigo.Text, _Finalidade) == null)
                            {
                                dtCFOP.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtCFOP.DataSource = bllDFe.Sel_CFOP_Codigo_CFOP_DFe(txtpCodigo.Text, _Finalidade);
                                dtCFOP.Select();
                            }
                        }
                    }
                    else if (rbtnTodos.Checked == true)
                    {
                        if (bllDFe.Sel_CFOP_Todos_DFe(_Finalidade) == null)
                        {
                            dtCFOP.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtCFOP.DataSource = bllDFe.Sel_CFOP_Todos_DFe(_Finalidade);
                            dtCFOP.Select();
                        }
                    }
                }
                else
                {
                    if (rbtnDescricao.Checked == true)
                    {
                        if (txtpDescricao.Text != "")
                        {
                            if (bllCFOP.Sel_CFOP_Descricao(txtpDescricao.Text) == null)
                            {
                                dtCFOP.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtCFOP.DataSource = bllCFOP.Sel_CFOP_Descricao(txtpDescricao.Text);
                                dtCFOP.Select();
                            }
                        }
                    }
                    else if (rbtnCodigo.Checked == true)
                    {
                        if (txtpCodigo.Text != "")
                        {
                            if (bllCFOP.Sel_CFOP_Codigo(txtpCodigo.Text) == null)
                            {
                                dtCFOP.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtCFOP.DataSource = bllCFOP.Sel_CFOP_Codigo(txtpCodigo.Text);
                                dtCFOP.Select();
                            }
                        }
                    }
                    else if (rbtnTodos.Checked == true)
                    {
                        if (bllCFOP.Sel_CFOP_Todos() == null)
                        {
                            dtCFOP.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtCFOP.DataSource = bllCFOP.Sel_CFOP_Todos();
                            dtCFOP.Select();
                        }
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou cfop.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou cfop.");
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
                dtCFOP.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void dtCFOP_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtCFOP.Rows.Count;

            dtCFOP.Columns[0].HeaderText = "Código do CFOP";
            dtCFOP.Columns[1].HeaderText = "Descrição";
            dtCFOP.Columns[2].HeaderText = "Finalidade";


            dtCFOP.Columns[0].Width = 125;
            dtCFOP.Columns[1].Width = 492;
            dtCFOP.Columns[2].Width = 175;

            dtCFOP.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtCFOP.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtCFOP.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtCFOP.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtCFOP.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtCFOP.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtCFOP.DefaultCellStyle.Font = new Font(dtCFOP.Font, FontStyle.Bold);
        }

        private void dtCFOP_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtCFOP_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtCFOP.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtCFOP.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtCFOP_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtCFOP.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtCFOP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtCFOP_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtCFOP.DataSource == null)
            {
                btnIncluir.Enabled = false;
                dtCFOP.Enabled = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                dtCFOP.Enabled = true;
            }
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void FrmPesqCFOP_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqCFOP foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqCFOP foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqCFOP.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqCFOP.");
                }
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por código do cfop, descrição  e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                DataGridViewRow SelectedRow = dtCFOP.Rows[dtCFOP.CurrentRow.Index];
                bllDFe._FornDFe_Cfop_PesqCfop_Tabela = SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                DataGridViewRow SelectedRow = dtCFOP.Rows[dtCFOP.CurrentRow.Index];
                bllDFe._FornDFe_Cfop_PesqCfop_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                DataGridViewRow SelectedRow = dtCFOP.Rows[dtCFOP.CurrentRow.Index];
                bllSaidasProdutos._Saidas_Prod_PesqCCFOP_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtCFOP_DoubleClick(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                DataGridViewRow SelectedRow = dtCFOP.Rows[dtCFOP.CurrentRow.Index];
                bllDFe._FornDFe_Cfop_PesqCfop_Tabela = SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                DataGridViewRow SelectedRow = dtCFOP.Rows[dtCFOP.CurrentRow.Index];
                bllDFe._FornDFe_Cfop_PesqCfop_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                DataGridViewRow SelectedRow = dtCFOP.Rows[dtCFOP.CurrentRow.Index];
                bllSaidasProdutos._Saidas_Prod_PesqCCFOP_Tabela = SelectedRow.Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtCFOP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_Formulario == 0)
                {
                    DataGridViewRow SelectedRow = dtCFOP.Rows[dtCFOP.CurrentRow.Index];
                    bllDFe._FornDFe_Cfop_PesqCfop_Tabela = SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    DataGridViewRow SelectedRow = dtCFOP.Rows[dtCFOP.CurrentRow.Index];
                    bllDFe._FornDFe_Cfop_PesqCfop_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    DataGridViewRow SelectedRow = dtCFOP.Rows[dtCFOP.CurrentRow.Index];
                    bllSaidasProdutos._Saidas_Prod_PesqCCFOP_Tabela = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
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

        private void FrmPesqCFOP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpDescricao.Text = null;
                txtpDescricao.Select();
            }
            txtpDescricao.BackColor = Color.White;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            if (txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpCodigo.Text = null;
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
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
                this.Enabled = false;
                if (bllUsuario.Sel_Cadastrar_CFOP_NatOp(_Usuario) == true)
                {
                    using (FrmCadCFOP CFOP = new FrmCadCFOP(_Usuario, _Cod_PDV_Computador, 1))
                    {
                        if (CFOP.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllCFOP.Sel_CFOP_Codigo(bllCFOP._Cod_CFOP_Cadastro) == null)
                            {
                                dtCFOP.DataSource = null;
                            }
                            else
                            {
                                dtCFOP.DataSource = bllCFOP.Sel_CFOP_Codigo(bllCFOP._Cod_CFOP_Cadastro);
                                dtCFOP.Select();
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                        //
                        bllCFOP._Cod_CFOP_Cadastro = null;
                    }
                }
                else
                {
                    MessageBox.Show("O Usuário atual não possui permissão para Cadastrar CFOP.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnCadastrar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnCadastrar.");
                }
            }
            this.Enabled = true;
        }
    }
}
