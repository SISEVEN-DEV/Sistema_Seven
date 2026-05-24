using BLL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmPesqUsuario : Form
    {
        public FrmPesqUsuario(byte formulario, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmPesqUsuario_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqUsuario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqUsuario iniciado.");
                }
                rbtnNomeUsuario.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqUsuario.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void rbtnNomeUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNomeUsuario_MouseLeave(object sender, EventArgs e)
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

        private void rbtnFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnFuncionario_MouseLeave(object sender, EventArgs e)
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

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpFuncionario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpFuncionario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            using (FrmPesqFuncionario Func = new FrmPesqFuncionario(1, _Usuario, _Cod_PDV_Computador))
            {
                if (Func.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpFuncionario.Items.Clear();
                        if (bllUsuario.Sel_Funcionario_Usuario() == null)
                        {
                            cbbpFuncionario.Text = null;
                        }
                        else
                        {
                            foreach (DataRow dr in bllUsuario.Sel_Funcionario_Usuario().Rows)
                            {
                                cbbpFuncionario.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        //                                              
                        cbbpFuncionario.Text = bllUsuario._User_PesqFuncionario_Tabela;
                        bllUsuario._User_PesqFuncionario_Tabela = null;
                        cbbpFuncionario.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnpProcurar.");
                        }
                        bllUsuario._User_PesqFuncionario_Tabela = null;
                        cbbpFuncionario.Text = null;
                    }
                }
            }
        }

        private void FrmPesqUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtpNomeUsuario_Enter(object sender, EventArgs e)
        {
            txtpNomeUsuario.BackColor = Color.LightBlue;
        }

        private void txtpNomeUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void cbbpFuncionario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtpNomeUsuario_Leave(object sender, EventArgs e)
        {
            if (txtpNomeUsuario.Text.Contains("'") || txtpNomeUsuario.Text.Contains(";") || txtpNomeUsuario.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpNomeUsuario.Text = null;
                txtpNomeUsuario.Select();
            }
            txtpNomeUsuario.BackColor = Color.White;
        }

        private void rbtnNomeUsuario_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurar.Visible = false;
            txtpCodigo.Visible = false;
            txtpNomeUsuario.Visible = true;
            cbbpFuncionario.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Text = "Digite o nome:";
            lblPesquisar.Location = new Point(319, 21);
            txtpNomeUsuario.Text = null;
            txtpNomeUsuario.Select();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurar.Visible = false;
            txtpCodigo.Visible = true;
            txtpNomeUsuario.Visible = false;
            cbbpFuncionario.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(367, 21);
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpFuncionario.Items.Clear();
                cbbpFuncionario.Items.Add("");
                if (bllUsuario.Sel_Funcionario_Usuario() == null)
                {
                    cbbpFuncionario.Text = null;
                }
                else
                {
                    foreach (DataRow dr in bllUsuario.Sel_Funcionario_Usuario().Rows)
                    {
                        cbbpFuncionario.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do combo cbbpFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do combo cbbpFuncionario.");
                }
                cbbpFuncionario.Text = null;
            }
            //
            btnpProcurar.Visible = true;
            txtpCodigo.Visible = false;
            txtpNomeUsuario.Visible = false;
            cbbpFuncionario.Visible = true;
            lblPesquisar.Text = "Escolha o funcionário:";
            lblPesquisar.Location = new Point(113, 21);
            cbbpFuncionario.Text = null;
            cbbpFuncionario.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            btnpProcurar.Visible = false;
            txtpCodigo.Visible = false;
            txtpNomeUsuario.Visible = false;
            cbbpFuncionario.Visible = false;
            btnpProcurar.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(379, 21);
            btnPesquisar.Select();
        }

        private void FrmPesqUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqUsuario foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqUsuario foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmPesqUsuario.");
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnNomeUsuario.Checked == true)
                {
                    if (txtpNomeUsuario.Text != "")
                    {
                        if (bllUsuario.Sel_Usuario_Nome_Usuario(txtpNomeUsuario.Text) == null)
                        {
                            dtUsuario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtUsuario.DataSource = bllUsuario.Sel_Usuario_Nome_Usuario(txtpNomeUsuario.Text);
                            dtUsuario.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllUsuario.Sel_Codigo_User(txtpCodigo.Text) == null)
                        {
                            dtUsuario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtUsuario.DataSource = bllUsuario.Sel_Codigo_User(txtpCodigo.Text);
                            dtUsuario.Select();
                        }
                    }
                }
                else if (rbtnFuncionario.Checked == true)
                {
                    if (rbtnFuncionario.Text != "")
                    {
                        if (bllUsuario.Sel_Funcionario_User(cbbpFuncionario.Text) == null)
                        {
                            dtUsuario.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtUsuario.DataSource = bllUsuario.Sel_Funcionario_User(cbbpFuncionario.Text);
                            dtUsuario.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    if (bllUsuario.Sel_Usuario_Todos() == null)
                    {
                        dtUsuario.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtUsuario.DataSource = bllUsuario.Sel_Usuario_Todos();
                        dtUsuario.Select();
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou usuário.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou usuário.");
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
                dtUsuario.DataSource = null;
                rbtnNomeUsuario.Checked = true;
            }
        }

        private void dtUsuario_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtUsuario.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtUsuario.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtUsuario_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtUsuario.Columns[0].HeaderText = "Código";
            dtUsuario.Columns[1].HeaderText = "Nome";
            dtUsuario.Columns[2].Visible = false;
            dtUsuario.Columns[3].HeaderText = "Cód. do Funcionário";
            dtUsuario.Columns[4].HeaderText = "Nome do Funcionário";
            dtUsuario.Columns[5].Visible = false;

            dtUsuario.Columns[0].Width = 70;
            dtUsuario.Columns[1].Width = 298;
            dtUsuario.Columns[3].Width = 130;
            dtUsuario.Columns[4].Width = 550;

            dtUsuario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtUsuario.DefaultCellStyle.Font = new Font(dtUsuario.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtUsuario.Rows.Count;
        }

        private void dtUsuario_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtUsuario.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtUsuario_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtUsuario.DataSource == null)
            {
                btnIncluir.Enabled = false;
                dtUsuario.Enabled = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                dtUsuario.Enabled = true;
            }
        }

        private void cbbpFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpFuncionario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por nome, código, funcionário e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllRegistroAtividades._Reg_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllHistCaixa._Hist_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllSaidasProdutos._Saidas_Prod_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 3)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllAbert_Fech_Caixa._Abert_Fech_Cx_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 4)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllFluxoCaixa._Fluxo_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 5)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllVenda._Venda_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 6)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllSangriaSuprimento._SangriaSuprimento_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 7)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllDevolucao._Devolucao_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 8)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllOrcamento._Orc_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 9)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllControleCheque._Usuario_PesqControleCheque = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 10)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllLembrete._Usuario_PesqLembrete = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 11)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllOS._Usuario_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtUsuario_DoubleClick(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllRegistroAtividades._Reg_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllHistCaixa._Hist_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllSaidasProdutos._Saidas_Prod_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 3)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllAbert_Fech_Caixa._Abert_Fech_Cx_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 4)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllFluxoCaixa._Fluxo_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 5)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllVenda._Venda_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 6)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllSangriaSuprimento._SangriaSuprimento_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 7)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllDevolucao._Devolucao_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 8)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllOrcamento._Orc_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 9)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllControleCheque._Usuario_PesqControleCheque = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 10)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllLembrete._Usuario_PesqLembrete = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 11)
            {
                btnIncluir.Select();
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                bllOS._Usuario_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtUsuario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void dtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_Formulario == 0)
                {
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllRegistroAtividades._Reg_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllHistCaixa._Hist_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllSaidasProdutos._Saidas_Prod_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 3)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllAbert_Fech_Caixa._Abert_Fech_Cx_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 4)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllFluxoCaixa._Fluxo_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 5)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllVenda._Venda_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 6)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllSangriaSuprimento._SangriaSuprimento_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 7)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllDevolucao._Devolucao_PesqUsuarioTabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 8)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllOrcamento._Orc_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 9)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllControleCheque._Usuario_PesqControleCheque = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 10)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllLembrete._Usuario_PesqLembrete = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 11)
                {
                    btnIncluir.Select();
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    bllOS._Usuario_PesqUsuario_Tabela = SelectedRow.Cells[0].Value.ToString() + "—" + SelectedRow.Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {

        }
    }
}
