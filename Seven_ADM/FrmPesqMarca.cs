using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqMarca : Form
    {
        public FrmPesqMarca(byte formulario, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmPesqMarca_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqMarca iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqMarca iniciado.");
                }
                rbtnDescricao.Checked = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqMarca.");
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

        private void rbtnOrigem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnOrigem_MouseLeave(object sender, EventArgs e)
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

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite a descrição:";
            lblPesquisar.Location = new Point(254, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = true;
            txtpDescricao.Text = null;
            txtpDescricao.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(469, 21);
            txtpCodigo.Visible = true;
            txtpDescricao.Visible = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnOrigem_CheckedChanged(object sender, EventArgs e)
        {
            cbbpOrigemPais.Visible = true;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Escolha a origem:";
            lblPesquisar.Location = new Point(320, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            cbbpOrigemPais.Text = null;
            cbbpOrigemPais.Select();
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = true;
            lblPesquisar.Text = "Digite a palavra-chave:";
            lblPesquisar.Location = new Point(388, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            cbbpOrigemPais.Visible = false;
            txtpPalavraChave.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(479, 21);
            txtpCodigo.Visible = false;
            txtpDescricao.Visible = false;
            btnPesquisar.Select();
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void cbbpOrigemPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
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
                if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        if (bllMarca.Sel_Marca_Descricao(txtpDescricao.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Descricao(txtpDescricao.Text);
                            dtMarca.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllMarca.Sel_Marca_Codigo(txtpCodigo.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Codigo(txtpCodigo.Text);
                            dtMarca.Select();
                        }
                    }
                }
                else if (rbtnOrigem.Checked == true)
                {
                    if (rbtnOrigem.Text != "")
                    {
                        if (bllMarca.Sel_Marca_Origem(cbbpOrigemPais.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Origem(cbbpOrigemPais.Text);
                            dtMarca.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllMarca.Sel_Marca_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtMarca.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtMarca.DataSource = bllMarca.Sel_Marca_Palavra_Chave(txtpPalavraChave.Text);
                            dtMarca.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllMarca.Sel_Marca_Todas() == null)
                    {
                        dtMarca.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtMarca.DataSource = bllMarca.Sel_Marca_Todas();
                        dtMarca.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou marca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou marca.");
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
                dtMarca.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void dtMarca_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtMarca.Columns[0].HeaderText = "Código";
                dtMarca.Columns[1].HeaderText = "Descrição";
                dtMarca.Columns[2].HeaderText = "Origem";
                dtMarca.Columns[3].HeaderText = "País";
                dtMarca.Columns[4].HeaderText = "Palavra-Chave";
                dtMarca.Columns[5].Visible = false;

                DataGridViewRow SelectedRow = dtMarca.Rows[dtMarca.CurrentRow.Index];

                dtMarca.Columns[0].Width = 55;
                dtMarca.Columns[1].Width = 350;
                dtMarca.Columns[2].Width = 275;
                dtMarca.Columns[3].Width = 275;
                dtMarca.Columns[4].Width = 95;

                dtMarca.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtMarca.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtMarca.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtMarca.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtMarca.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtMarca.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtMarca.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtMarca.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtMarca.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtMarca.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtMarca.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtMarca.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtMarca.DefaultCellStyle.Font = new Font(dtMarca.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtMarca.");
                }
                dtMarca.DataSource = null;
                rbtnDescricao.Checked = true;
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

        private void FrmPesqMarca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtMarca_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblRegistros.Text = "Registros: " + dtMarca.Rows.Count;
        }

        private void dtMarca_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtMarca_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtMarca.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtMarca_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtMarca_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtMarca.DataSource == null)
            {
                btnIncluir.Enabled = false;
                dtMarca.Enabled = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                dtMarca.Enabled = true;
            }
        }

        private void FrmPesqMarca_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqMarca foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqMarca foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqMarca.");
                }
            }
        }

        private void dtMarca_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtMarca.Rows[dtMarca.CurrentRow.Index];
                //
                if (_Formulario == 0)
                {
                    bllProduto._Marca_PesqMarca_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    bllOS._Marca_PesqMarca_Tabela = SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtMarca.");
                }
            }
        }

        private void dtMarca_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow SelectedRow = dtMarca.Rows[dtMarca.CurrentRow.Index];
                    //
                    if (_Formulario == 0)
                    {
                        bllProduto._Marca_PesqMarca_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 1)
                    {
                        bllOS._Marca_PesqMarca_Tabela = SelectedRow.Cells[1].Value.ToString();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do botão btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do botão btnIncluir.");
                }
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, origem, palavra-chave e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbpOrigemPais_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpOrigemPais_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpOrigemPais_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpOrigemPais_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtMarca.Rows[dtMarca.CurrentRow.Index];
                //
                if (_Formulario == 0)
                {
                    bllProduto._Marca_PesqMarca_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    bllOS._Marca_PesqMarca_Tabela = SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do botão btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do botão btnIncluir.");
                }
            }
        }

        private void dtMarca_DataMemberChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Cadastrar_Marcas(_Usuario) == true)
                {
                    using (FrmCadMarca Marca = new FrmCadMarca(_Usuario, _Cod_PDV_Computador, 1))
                    {
                        if (Marca.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (bllMarca.Sel_Marca_Codigo(bllMarca._Cod_Marca_Cadastro) == null)
                            {
                                dtMarca.DataSource = null;
                            }
                            else
                            {
                                dtMarca.DataSource = bllMarca.Sel_Marca_Codigo(bllMarca._Cod_Marca_Cadastro);
                                dtMarca.Select();
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                        //
                        bllMarca._Cod_Marca_Cadastro = null;
                    }
                }
                else
                {
                    MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Produtos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnCadastrar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadastrar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
