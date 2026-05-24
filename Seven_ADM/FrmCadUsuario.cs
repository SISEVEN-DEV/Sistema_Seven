using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadUsuario : Form
    {
        public FrmCadUsuario(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private bool _Comando_Atualizar;
        private bool _Inserir_Atualizar;
        private string _ComboboxFunc_Valor;
        private string _Cod_PDV_Computador;

        private void ModoPesquisa()
        {
            grbBox1.Enabled = true;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            txtCodigo.Enabled = false;
            lblCodigo.Enabled = false;
            btnSalvar.Enabled = false;
            if (dtUsuario.DataSource != null)
            {
                dtUsuario.Enabled = true;
                dtUsuario.Select();
            }
            grbBox2.Enabled = false;
        }

        private void FrmCadUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                bllUsuario._FrmCadUsuario_Ativo = true;
                //
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadUsuario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadUsuario iniciado.");
                }
                //               
                rbtnNomeUsuario.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadUsuario.");
                }
                this.Close();
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            txtNome_usuario.Text = null;
            txtSenha.Text = null;
            cbbFuncionario.Text = null;
        }

        private void txtNome_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == 32))
            {
                e.Handled = true;
            }
            //
            if (e.KeyChar == 13)
            {
                if (txtSenha.Enabled == false)
                {
                    cbbFuncionario.Select();
                }
                else
                {
                    txtSenha.Select();
                }
            }
        }

        private void txtNome_usuario_Enter(object sender, EventArgs e)
        {
            txtNome_usuario.BackColor = Color.LightBlue;
        }

        private void txtNome_usuario_Leave(object sender, EventArgs e)
        {
            if (txtNome_usuario.Text != "")
            {
                if (txtNome_usuario.Text.Contains(";") || txtNome_usuario.Text.Contains("'") || txtNome_usuario.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome_usuario.Text = null;
                }
                else
                {
                    try
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == false)
                            {
                                if (bllUsuario.Sel_Usuario_Ver_Nome(txtNome_usuario.Text) == true)
                                {
                                    MessageBox.Show("O Nome informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtNome_usuario.Text = null;
                                    txtNome_usuario.Select();
                                }
                            }
                            else
                            {
                                if (bllUsuario.Sel_Usuario_Ver_Nome_Alt(txtCodigo.Text, txtNome_usuario.Text) == true)
                                {
                                    MessageBox.Show("O Nome informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtNome_usuario.Text = null;
                                    txtNome_usuario.Select();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do textbox txtNome_usuario.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do textbox txtNome_usuario.");
                        }
                        txtNome_usuario.Text = null;
                    }
                }
            }
            txtNome_usuario.BackColor = Color.White;
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFuncionario.Select();
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.LightBlue;
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text.Contains("'") || txtSenha.Text.Contains(";") || txtSenha.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Text = null;
                txtSenha.Select();
            }
            txtSenha.BackColor = Color.White;
        }

        private void FrmCadUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnVer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (txtSenha.PasswordChar == '●')
            {
                txtSenha.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '●';
            }
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
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

        private void cbbpGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFuncoes_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnFuncoes_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
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
            lblPesquisar.Location = new Point(155, 21);
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

        private void txtpNomeUsuario_Enter(object sender, EventArgs e)
        {
            txtpNomeUsuario.BackColor = Color.LightBlue;
        }

        private void txtpNomeUsuario_Leave(object sender, EventArgs e)
        {
            if (txtpNomeUsuario.Text.Contains("'") || txtpNomeUsuario.Text.Contains(";") || txtpNomeUsuario.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpNomeUsuario.Text = null;
            }
            txtpNomeUsuario.BackColor = Color.White;
        }

        private void txtpNomeUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == 32))
            {
                e.Handled = true;
            }
            //
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

        private void cbbpFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void dtUsuario_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtUsuario.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtUsuario.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtNome_usuario.Text = SelectedRow.Cells[1].Value.ToString();
                if (bllUsuario.Sel_Permitir_Vis_Senha_Usuario(_Usuario) == true)
                {
                    txtSenha.Text = SelectedRow.Cells[2].Value.ToString();
                }
                else
                {
                    txtSenha.Text = "";
                }
                cbbFuncionario.Items.Clear();
                if (SelectedRow.Cells[3].Value.ToString() != "0")
                {
                    cbbFuncionario.Items.Add(SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString());
                    cbbFuncionario.Text = SelectedRow.Cells[3].Value.ToString() + "—" + SelectedRow.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtUsuario.");
                }
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                rbtnNomeUsuario.Checked = true;
                dtUsuario.DataSource = null;
                ModoPesquisa();
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
                            Limpar();
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
                            Limpar();
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
                            Limpar();
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
                        Limpar();
                    }
                    else
                    {
                        dtUsuario.DataSource = bllUsuario.Sel_Usuario_Todos();
                        dtUsuario.Select();
                    }
                }
                //
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
                dtUsuario.DataSource = null;
                rbtnNomeUsuario.Checked = true;
                ModoPesquisa();
            }
        }

        private void dtUsuario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                dtUsuario.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('\u25CF', e.Value.ToString().Length);
            }
            //
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
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

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por nome, código, funcionário e todos os dados cadastrados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtUsuario_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtUsuario.Columns[0].HeaderText = "Código";
            dtUsuario.Columns[1].HeaderText = "Nome";
            if (bllUsuario.Sel_Permitir_Vis_Senha_Usuario(_Usuario) == true)
            {
                dtUsuario.Columns[2].HeaderText = "Senha";
                dtUsuario.Columns[2].Width = 150;
            }
            else
            {
                dtUsuario.Columns[2].Visible = false;
            }
            dtUsuario.Columns[3].HeaderText = "Cod. do Funcionário";
            dtUsuario.Columns[4].HeaderText = "Nome do Funcionário";
            dtUsuario.Columns[5].Visible = false;

            dtUsuario.Columns[0].Width = 70;
            dtUsuario.Columns[1].Width = 298;
            dtUsuario.Columns[3].Width = 135;
            dtUsuario.Columns[4].Width = 550;

            dtUsuario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtUsuario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private void cbbFuncionario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFuncionario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFuncionario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
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
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            pEnabled.Enabled = true;
        }

        private void btnProcurarFuncionario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarFuncionario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarFuncionario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqFuncionario Func = new FrmPesqFuncionario(1, _Usuario, _Cod_PDV_Computador))
            {
                if (Func.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbFuncionario.Items.Clear();

                        if (bllUsuario.Sel_Funcionario_Usuario() == null)
                        {
                            cbbFuncionario.Text = null;
                        }
                        else
                        {
                            foreach (DataRow dr in bllUsuario.Sel_Funcionario_Usuario().Rows)
                            {
                                cbbFuncionario.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }

                        cbbFuncionario.Text = bllUsuario._User_PesqFuncionario_Tabela;
                        bllUsuario._User_PesqFuncionario_Tabela = null;
                        cbbFuncionario.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarFuncionario.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarFuncionario.");
                        }
                        bllUsuario._User_PesqFuncionario_Tabela = null;
                        cbbFuncionario.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void dtUsuario_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtUsuario.DataSource == null)
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                dtUsuario.Enabled = false;
            }
            else
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                dtUsuario.Enabled = true;
            }
        }

        private void cbbFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void FrmCadUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadUsuario foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadUsuario foi finalizado.");
                }
                bllUsuario._FrmCadUsuario_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadUsuario.");
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtUsuario.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtUsuario.Enabled = false;
            grbBox1.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            grbBox2.Enabled = true;
            Limpar();
            _Comando_Atualizar = false;
            _Inserir_Atualizar = true;
            bllUsuario._Funcoes_Salvas = false;
            //
            lblSenha.Enabled = true;
            txtSenha.Enabled = true;
            lblAsterisco.Enabled = true;
            btnVer.Enabled = true;
            try
            {
                cbbFuncionario.Items.Clear();
                cbbFuncionario.Items.Add("");
                if (bllUsuario.Sel_Funcionario_Usuario() == null)
                {
                    cbbFuncionario.Text = null;
                }
                else
                {
                    foreach (DataRow dr in bllUsuario.Sel_Funcionario_Usuario().Rows)
                    {
                        cbbFuncionario.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                bllUsuario._Funcoes_Salvas = false;
                bllUsuario._Funcoes_Salvas = false;
                dtUsuario.DataSource = null;
                rbtnNomeUsuario.Checked = true;
                ModoPesquisa();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dtUsuario.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtUsuario.Enabled = false;
            grbBox1.Enabled = false;
            btnNovo.Enabled = false;
            btnCancelar.Visible = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            grbBox2.Enabled = true;
            _Comando_Atualizar = true;
            _Inserir_Atualizar = true;
            bllUsuario._Funcoes_Salvas = false;
            lblCodigo.Enabled = true;
            txtCodigo.Enabled = true;
            txtNome_usuario.Select();
            //
            if (bllUsuario.Sel_Permitir_Vis_Senha_Usuario(_Usuario) == true)
            {
                txtSenha.Enabled = true;
                btnVer.Enabled = true;
                lblSenha.Enabled = true;
                lblAsterisco.Enabled = true;
            }
            else
            {
                txtSenha.Enabled = false;
                btnVer.Enabled = false;
                lblSenha.Enabled = false;
                lblAsterisco.Enabled = false;
            }

            try
            {
                _ComboboxFunc_Valor = cbbFuncionario.Text;
                //
                DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                //
                cbbFuncionario.Items.Clear();
                if (bllUsuario.Sel_Funcionario_Usuario() == null)
                {
                    cbbFuncionario.Text = null;
                }
                else
                {
                    cbbFuncionario.Items.Add("");
                    foreach (DataRow dr in bllUsuario.Sel_Funcionario_Usuario().Rows)
                    {
                        cbbFuncionario.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }

                //
                if (SelectedRow.Cells[3].Value.ToString() != "0")
                {
                    if (bllUsuario.Sel_ComboboxFunc_Valor_A_Alterar(_ComboboxFunc_Valor) != null)
                    {
                        foreach (DataRow dr in bllUsuario.Sel_ComboboxFunc_Valor_A_Alterar(_ComboboxFunc_Valor).Rows)
                        {
                            cbbFuncionario.Text = dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString();
                        }
                        _ComboboxFunc_Valor = null;
                    }
                    else
                    {
                        _ComboboxFunc_Valor = null;
                        cbbFuncionario.Text = null;
                    }
                }
                //
                if (bllUsuario.Sel_Funcoes_Usuario(SelectedRow.Cells[0].Value.ToString()) != null)
                {
                    DataRow dr = bllUsuario.Sel_Funcoes_Usuario(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    if (Convert.ToByte(dr["realizar_orcamento"]) == 0)
                    {
                        bllUsuario._Realizar_Orcamento = false;
                    }
                    else
                    {
                        bllUsuario._Realizar_Orcamento = true;
                    }
                    //
                    if (Convert.ToByte(dr["realizar_devolucao"]) == 0)
                    {
                        bllUsuario._Realizar_Devolucao = false;
                    }
                    else
                    {
                        bllUsuario._Realizar_Devolucao = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_canc_exc_item_venda"]) == 0)
                    {
                        bllUsuario._Permitir_Canc_Exc_Item_Venda = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Canc_Exc_Item_Venda = true;
                    }
                    //
                    if (Convert.ToByte(dr["capturar_orcamento"]) == 0)
                    {
                        bllUsuario._Capturar_Orcamento = false;
                    }
                    else
                    {
                        bllUsuario._Capturar_Orcamento = true;
                    }
                    //
                    if (Convert.ToByte(dr["capturar_devolucao"]) == 0)
                    {
                        bllUsuario._Capturar_Devolucao = false;
                    }
                    else
                    {
                        bllUsuario._Capturar_Devolucao = true;
                    }
                    //
                    if (Convert.ToByte(dr["permissao_usuarios"]) == 0)
                    {
                        bllUsuario._Permissao_Usuarios = false;
                    }
                    else
                    {
                        bllUsuario._Permissao_Usuarios = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_desc_pag"]) == 0)
                    {
                        bllUsuario._Permitir_Desc_Pag = false;
                        bllUsuario._Desconto_Porc_Max_Venda = "0,00";
                    }
                    else
                    {
                        bllUsuario._Permitir_Desc_Pag = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_acresc_pag"]) == 0)
                    {
                        bllUsuario._Permitir_Acresc_Pag = false;
                        bllUsuario._Acrescimo_Porc_Max_Venda = "0,00";
                    }
                    else
                    {
                        bllUsuario._Permitir_Acresc_Pag = false;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_fin_pdv"]) == 0)
                    {
                        bllUsuario._Permitir_Fin_PDV = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Fin_PDV = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_alt_prod_item"]) == 0)
                    {
                        bllUsuario._Permitir_Alt_Prod_Item = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Alt_Prod_Item = true;
                    }
                    //
                    if (Convert.ToByte(dr["mostrar_dados_prod_item"]) == 0)
                    {
                        bllUsuario._Mostrar_Dados_Prod_Item = false;
                    }
                    else
                    {
                        bllUsuario._Mostrar_Dados_Prod_Item = true;
                    }
                    //
                    bllUsuario._Acrescimo_Porc_Max_Venda = dr["acrescimo_porc_max_venda"].ToString();
                    //
                    bllUsuario._Desconto_Porc_Max_Venda = dr["desconto_porc_max_venda"].ToString();
                    //
                    if (Convert.ToByte(dr["permitir_abrir_caixa"]) == 0)
                    {
                        bllUsuario._Permitir_Abrir_Caixa = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Abrir_Caixa = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_fechar_caixa"]) == 0)
                    {
                        bllUsuario._Permitir_Fechar_Caixa = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Fechar_Caixa = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_real_sangsup"]) == 0)
                    {
                        bllUsuario._Permitir_Real_SangSup = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Real_SangSup = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_real_conta_receber"]) == 0)
                    {
                        bllUsuario._Permitir_Real_Conta_Receber = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Real_Conta_Receber = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_real_conta_pagar"]) == 0)
                    {
                        bllUsuario._Permitir_Real_Conta_Pagar = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Real_Conta_Pagar = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_vis_hist_caixa"]) == 0)
                    {
                        bllUsuario._Permitir_Vis_Hist_Caixa = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Vis_Hist_Caixa = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_cliente"]) == 0)
                    {
                        bllUsuario._Cadastrar_Cliente_Consumidor = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Cliente_Consumidor = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_conta_pagar"]) == 0)
                    {
                        bllUsuario._Cadastrar_Conta_Pagar = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Conta_Pagar = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_conta_receber"]) == 0)
                    {
                        bllUsuario._Cadastrar_Conta_Receber = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Conta_Receber = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_entidade_bancaria"]) == 0)
                    {
                        bllUsuario._Cadastrar_Entidade_Bancaria = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Entidade_Bancaria = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_forma_pagamento"]) == 0)
                    {
                        bllUsuario._Cadastrar_Forma_Pagamento = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Forma_Pagamento = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_fornecedor"]) == 0)
                    {
                        bllUsuario._Cadastrar_Fornecedor = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Fornecedor = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_funcionario"]) == 0)
                    {
                        bllUsuario._Cadastrar_Funcionario = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Funcionario = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_grupo"]) == 0)
                    {
                        bllUsuario._Cadastrar_Grupo = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Grupo = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_localizacao"]) == 0)
                    {
                        bllUsuario._Cadastrar_Localizacao = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Localizacao = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_marca"]) == 0)
                    {
                        bllUsuario._Cadastrar_Marca = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Marca = true;
                    }
                    //
                    //
                    if (Convert.ToByte(dr["cadastrar_produto"]) == 0)
                    {
                        bllUsuario._Cadastrar_Produto = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Produto = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_subgrupo"]) == 0)
                    {
                        bllUsuario._Cadastrar_Subgrupo = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Subgrupo = true;
                    }
                    //
                    if (Convert.ToByte(dr["cadastrar_usuario"]) == 0)
                    {
                        bllUsuario._Cadastrar_Usuario = false;
                    }
                    else
                    {
                        bllUsuario._Cadastrar_Usuario = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_pausar_caixa"]) == 0)
                    {
                        bllUsuario._Permitir_Pausar_Caixa = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Pausar_Caixa = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_vis_hist_caixa"]) == 0)
                    {
                        bllUsuario._Permitir_Vis_Hist_Caixa = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Vis_Hist_Caixa = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_cad_no_pdv"]) == 0)
                    {
                        bllUsuario._Permitir_Cad_No_Pdv = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Cad_No_Pdv = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_venda_n_prom_s_credito"]) == 0)
                    {
                        bllUsuario._Permitir_Venda_N_Prom_S_Credito = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Venda_N_Prom_S_Credito = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_abert_fech_caixa"]) == 0)
                    {
                        bllUsuario._Rel_Abert_Fech_Caixa = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Abert_Fech_Caixa = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_cliente_consumidor"]) == 0)
                    {
                        bllUsuario._Rel_Cliente_Consumidor = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Cliente_Consumidor = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_conta_pagar"]) == 0)
                    {
                        bllUsuario._Rel_Conta_Pagar = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Conta_Pagar = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_conta_receber"]) == 0)
                    {
                        bllUsuario._Rel_Conta_Receber = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Conta_Receber = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_produto"]) == 0)
                    {
                        bllUsuario._Rel_Produtos_Servico = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Produtos_Servico = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_orcamento"]) == 0)
                    {
                        bllUsuario._Rel_Orcamento = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Orcamento = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_venda"]) == 0)
                    {
                        bllUsuario._Rel_Venda = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Venda = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_grupo"]) == 0)
                    {
                        bllUsuario._Rel_Grupo = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Grupo = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_funcionario"]) == 0)
                    {
                        bllUsuario._Rel_Funcionario = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Funcionario = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_forma_pagamento"]) == 0)
                    {
                        bllUsuario._Rel_Formas_Pagamento = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Formas_Pagamento = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_fornecedor"]) == 0)
                    {
                        bllUsuario._Rel_Fornecedor = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Fornecedor = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_subgrupo"]) == 0)
                    {
                        bllUsuario._Rel_Subgrupo = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Subgrupo = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_hist_caixa"]) == 0)
                    {
                        bllUsuario._Rel_Historico_Caixa = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Historico_Caixa = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_fluxo_caixa"]) == 0)
                    {
                        bllUsuario._Rel_Fluxo_Caixa = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Fluxo_Caixa = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_saida_produto"]) == 0)
                    {
                        bllUsuario._Rel_Saida_Produto = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Saida_Produto = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_entrada_produto"]) == 0)
                    {
                        bllUsuario._Rel_Entrada_Produto = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Entrada_Produto = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_sangria_suprimento"]) == 0)
                    {
                        bllUsuario._Rel_Sangria_Suprimento = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Sangria_Suprimento = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_devolucao_servico"]) == 0)
                    {
                        bllUsuario._Rel_Devolucao_Servico = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Devolucao_Servico = true;
                    }
                    //
                    if (Convert.ToByte(dr["perm_vis_senha_usuario"]) == 0)
                    {
                        bllUsuario._Permitir_Vis_Senha_Usuario = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Vis_Senha_Usuario = true;
                    }
                    //
                    if (Convert.ToByte(dr["perm_ign_multa_juros_rec"]) == 0)
                    {
                        bllUsuario._Permitir_Ignorar_Multa_Juros_Receber = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Ignorar_Multa_Juros_Receber = true;
                    }
                    //
                    if (Convert.ToByte(dr["perm_exc_sang_sup"]) == 0)
                    {
                        bllUsuario._Permitir_Exc_Sang_Sup = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Exc_Sang_Sup = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_usuario"]) == 0)
                    {
                        bllUsuario._Rel_Usuario = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Usuario = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_marca"]) == 0)
                    {
                        bllUsuario._Rel_Marca = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Marca = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_localizacao"]) == 0)
                    {
                        bllUsuario._Rel_Localizacao = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Localizacao = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_venda_s_credito_loja"]) == 0)
                    {
                        bllUsuario._Permitir_Venda_S_Credito_Loja = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Venda_S_Credito_Loja = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_alt_dados_emp"]) == 0)
                    {
                        bllUsuario._Permitir_Alt_Dados_Emp = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Alt_Dados_Emp = true;
                    }
                    //
                    if (Convert.ToByte(dr["permitir_alt_dados_config"]) == 0)
                    {
                        bllUsuario._Permitir_Alt_Dados_Config = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Alt_Dados_Config = true;
                    }
                    //
                    if (Convert.ToByte(dr["perm_atu_zer_est"]) == 0)
                    {
                        bllUsuario._Permitir_Atualizar_Zerar_Estoque = false;
                    }
                    else
                    {
                        bllUsuario._Permitir_Atualizar_Zerar_Estoque = true;
                    }
                    //
                    if (Convert.ToByte(dr["rel_estoque"]) == 0)
                    {
                        bllUsuario._Rel_Estoque = false;
                    }
                    else
                    {
                        bllUsuario._Rel_Estoque = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dtUsuario.DataSource = null;
                rbtnNomeUsuario.Checked = true;
                ModoPesquisa();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string[] items = _Usuario.Split('-');

                if (items[0] == txtCodigo.Text)
                {
                    MessageBox.Show("Nâo é possível excluir o usuário: " + _Usuario + " pois o mesmo está atualmente logado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este usuário?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllUsuario.Sel_User_Abert_Fech_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por uma Abertura ou Fechamento de Caixa, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Cadastro_Computadores_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por um Cadastro de Computadores, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Conta_Pagar_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por uma Conta a Pagar, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Conta_Receber_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por uma Conta a Receber, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Devolucao_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por uma Devolução, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Fluxo_Caixa_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por uma Fluxo de Caixa, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Orcamento_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por um Orçamento, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Pagamento_Conta_Pagar_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por um Pagamento de Conta a Pagar, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Pagamento_Conta_Receber_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por um Pagamento de Conta a Receber, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Registro_Atividade_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por um Registro de Atividades, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Sangria_Suprimento_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por uma Sangria/Surpriemto, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else if (bllUsuario.Sel_User_Venda_Ver(txtCodigo.Text) == true)
                        {
                            MessageBox.Show("O Usuário selecionado está sendo utilizado por uma Venda, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            dtUsuario.Select();
                        }
                        else
                        {
                            bllUsuario.Excluir(txtCodigo.Text);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Usuário excluído. Cod: " + txtCodigo.Text + " | Nome de Usuário: " + txtNome_usuario.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Usuário excluído. Cod: " + txtCodigo.Text + " | Nome de Usuário: " + txtNome_usuario.Text);
                            }
                            //
                            if (rbtnNomeUsuario.Checked == true)
                            {
                                if (txtpNomeUsuario.Text != "")
                                {
                                    if (bllUsuario.Sel_Usuario_Nome_Usuario(txtpNomeUsuario.Text) == null)
                                    {
                                        dtUsuario.DataSource = null;
                                        Limpar();
                                    }
                                    else
                                    {
                                        dtUsuario.DataSource = bllUsuario.Sel_Usuario_Nome_Usuario(txtpNomeUsuario.Text);
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
                                        Limpar();
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
                                    Limpar();
                                }
                                else
                                {
                                    dtUsuario.DataSource = bllUsuario.Sel_Usuario_Todos();
                                    dtUsuario.Select();
                                }
                            }
                            else
                            {
                                dtUsuario.DataSource = null;
                                Limpar();
                            }
                            //  
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (dtUsuario.DataSource != null)
                        {
                            dtUsuario.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                txtpNomeUsuario.Text = null;
                dtUsuario.DataSource = null;
                rbtnNomeUsuario.Checked = true;
                txtpNomeUsuario.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Comando_Atualizar == true)
            {
                _Comando_Atualizar = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                Limpar();
            }
            else
            {
                if (dtUsuario.DataSource == null)
                {
                    Limpar();
                }
                else
                {
                    Limpar();
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                }
            }
            _Inserir_Atualizar = false;
            bllUsuario._Funcoes_Salvas = false;
            ModoPesquisa();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cbbFuncionario.Text != "")
            {
                _ComboboxFunc_Valor = cbbFuncionario.Text;
                cbbFuncionario.Items.Clear();
                if (bllUsuario.Sel_Funcionario_Usuario() == null)
                {
                    cbbFuncionario.Text = null;
                }
                else
                {
                    foreach (DataRow dr in bllUsuario.Sel_Funcionario_Usuario().Rows)
                    {
                        cbbFuncionario.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
                //
                if (bllUsuario.Sel_ComboboxFunc_Valor_A_Alterar(_ComboboxFunc_Valor) != null)
                {
                    foreach (DataRow dr in bllUsuario.Sel_ComboboxFunc_Valor_A_Alterar(_ComboboxFunc_Valor).Rows)
                    {
                        cbbFuncionario.Text = dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString();
                    }
                    _ComboboxFunc_Valor = null;
                }
                else
                {
                    _ComboboxFunc_Valor = null;
                    cbbFuncionario.Text = null;
                }
            }
            //
            btnSalvar.Select();
            //
            DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (_Comando_Atualizar == true & bllUsuario.Sel_Permitir_Vis_Senha_Usuario(_Usuario) == false)
                {
                    DataGridViewRow SelectedRow = dtUsuario.Rows[dtUsuario.CurrentRow.Index];
                    //
                    txtSenha.Text = SelectedRow.Cells[2].Value.ToString();
                }
                //
                if (txtNome_usuario.Text.Trim() == "" || txtSenha.Text.Trim() == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Nome ] e [ Senha ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNome_usuario.Select();
                    if (_Comando_Atualizar == true & bllUsuario.Sel_Permitir_Vis_Senha_Usuario(_Usuario) == false)
                    {
                        txtSenha.Text = "";
                    }
                }
                else
                {
                    try
                    {
                        if (_Comando_Atualizar == true)
                        {
                            if (bllUsuario.Sel_Usuario_Ainda_Existe(txtCodigo.Text) == false)
                            {
                                MessageBox.Show("Não é possível alterar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                                _Comando_Atualizar = false;
                                _Inserir_Atualizar = false;
                                dtUsuario.DataSource = null;
                                Limpar();
                                ModoPesquisa();
                                rbtnNomeUsuario.Checked = true;
                            }
                            else
                            {
                                bllUsuario.Alterar(txtCodigo.Text, txtNome_usuario.Text.Trim(), txtSenha.Text.Trim(), cbbFuncionario.Text);
                                //
                                bllUsuario.Alterar_User_Cadastro_Computadores_Adm(txtCodigo.Text, txtNome_usuario.Text);
                                bllUsuario.Alterar_User_Cadastro_Computadores_Pdv(txtCodigo.Text, txtNome_usuario.Text);
                                //
                                bllUsuario._Realizar_Orcamento = false;
                                bllUsuario._Realizar_Devolucao = false;
                                bllUsuario._Permitir_Canc_Exc_Item_Venda = false;
                                bllUsuario._Capturar_Orcamento = false;
                                bllUsuario._Capturar_Devolucao = false;
                                bllUsuario._Permissao_Usuarios = false;
                                bllUsuario._Permitir_Desc_Pag = false;
                                bllUsuario._Permitir_Acresc_Pag = false;
                                bllUsuario._Permitir_Fin_PDV = false;
                                bllUsuario._Permitir_Alt_Prod_Item = false;
                                bllUsuario._Mostrar_Dados_Prod_Item = false;
                                bllUsuario._Desconto_Porc_Max_Venda = null;
                                bllUsuario._Acrescimo_Porc_Max_Venda = null;
                                bllUsuario._Permitir_Abrir_Caixa = false;
                                bllUsuario._Permitir_Fechar_Caixa = false;
                                bllUsuario._Permitir_Real_SangSup = false;
                                bllUsuario._Permitir_Real_Conta_Receber = false;
                                bllUsuario._Permitir_Real_Conta_Pagar = false;
                                bllUsuario._Cadastrar_Cliente_Consumidor = false;
                                bllUsuario._Cadastrar_Conta_Pagar = false;
                                bllUsuario._Cadastrar_Conta_Receber = false;
                                bllUsuario._Cadastrar_Entidade_Bancaria = false;
                                bllUsuario._Cadastrar_Forma_Pagamento = false;
                                bllUsuario._Cadastrar_Fornecedor = false;
                                bllUsuario._Cadastrar_Funcionario = false;
                                bllUsuario._Cadastrar_Grupo = false;
                                bllUsuario._Cadastrar_Localizacao = false;
                                bllUsuario._Cadastrar_Marca = false;
                                bllUsuario._Cadastrar_Produto = false;
                                bllUsuario._Cadastrar_Subgrupo = false;
                                bllUsuario._Cadastrar_Usuario = false;
                                bllUsuario._Permitir_Pausar_Caixa = false;
                                bllUsuario._Permitir_Vis_Hist_Caixa = false;
                                bllUsuario._Permitir_Cad_No_Pdv = false;
                                bllUsuario._Permitir_Venda_N_Prom_S_Credito = false;
                                bllUsuario._Rel_Abert_Fech_Caixa = false;
                                bllUsuario._Rel_Cliente_Consumidor = false;
                                bllUsuario._Rel_Conta_Pagar = false;
                                bllUsuario._Rel_Conta_Receber = false;
                                bllUsuario._Rel_Produtos_Servico = false;
                                bllUsuario._Rel_Orcamento = false;
                                bllUsuario._Rel_Venda = false;
                                bllUsuario._Rel_Grupo = false;
                                bllUsuario._Rel_Funcionario = false;
                                bllUsuario._Rel_Formas_Pagamento = false;
                                bllUsuario._Rel_Fornecedor = false;
                                bllUsuario._Rel_Subgrupo = false;
                                bllUsuario._Rel_Historico_Caixa = false;
                                bllUsuario._Rel_Fluxo_Caixa = false;
                                bllUsuario._Rel_Saida_Produto = false;
                                bllUsuario._Rel_Entrada_Produto = false;
                                bllUsuario._Rel_Sangria_Suprimento = false;
                                bllUsuario._Rel_Devolucao_Servico = false;
                                bllUsuario._Permitir_Vis_Senha_Usuario = false;
                                bllUsuario._Permitir_Ignorar_Multa_Juros_Receber = false;
                                bllUsuario._Permitir_Exc_Sang_Sup = false;
                                bllUsuario._Rel_Usuario = false;
                                bllUsuario._Rel_Marca = false;
                                bllUsuario._Rel_Localizacao = false;
                                bllUsuario._Permitir_Venda_S_Credito_Loja = false;
                                bllUsuario._Permitir_Alt_Dados_Emp = false;
                                bllUsuario._Permitir_Alt_Dados_Config = false;
                                bllUsuario._Permitir_Atualizar_Zerar_Estoque = false;
                                bllUsuario._Rel_Estoque = false;
                                bllUsuario._Permitir_Excluir_Inventario = false;
                                bllUsuario._Capturar_Venda = false;
                                bllUsuario._Cadastrar_Servico = false;
                                bllUsuario._Permitir_Excluir_OS = false;
                                bllUsuario._Cadastrar_OS = false;
                                bllUsuario._Cadastrar_PSPPIX = false;
                                bllUsuario._Acessar_Menu_NFe_NFCe = false;
                                bllUsuario._Acessar_Menu_NFSe = false;
                                bllUsuario._Cadastrar_NFe = false;
                                bllUsuario._Rel_Comissao = false;
                                bllUsuario._Rel_Controle_Cheque = false;
                                bllUsuario._Rel_OS = false;
                                //                            
                                _Comando_Atualizar = false;
                                //
                                dtUsuario.DataSource = bllUsuario.Sel_Usuario_A_Alterar(txtCodigo.Text);
                                //
                                bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM USUARIO", "USUARIO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Usuário alterado. Cod: " + txtCodigo.Text + " | Nome: " + txtNome_usuario.Text.Trim());
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Usuário alterado. Cod: " + txtCodigo.Text + " | Nome: " + txtNome_usuario.Text.Trim());
                                }
                                //
                                ModoPesquisa();
                                //                              
                                MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bllUsuario._Funcoes_Salvas = false;
                                //
                                txtSenha.PasswordChar = '●';
                            }
                        }
                        else
                        {
                            bllUsuario.Salvar(txtNome_usuario.Text.Trim(), txtSenha.Text.Trim(), cbbFuncionario.Text);
                            //
                            dtUsuario.DataSource = bllUsuario.Sel_Usuario_A_Salvar();
                            //                            
                            bllUsuario._Realizar_Orcamento = false;
                            bllUsuario._Realizar_Devolucao = false;
                            bllUsuario._Permitir_Canc_Exc_Item_Venda = false;
                            bllUsuario._Capturar_Orcamento = false;
                            bllUsuario._Capturar_Devolucao = false;
                            bllUsuario._Permissao_Usuarios = false;
                            bllUsuario._Permitir_Desc_Pag = false;
                            bllUsuario._Permitir_Acresc_Pag = false;
                            bllUsuario._Permitir_Fin_PDV = false;
                            bllUsuario._Permitir_Alt_Prod_Item = false;
                            bllUsuario._Mostrar_Dados_Prod_Item = false;
                            bllUsuario._Desconto_Porc_Max_Venda = null;
                            bllUsuario._Acrescimo_Porc_Max_Venda = null;
                            bllUsuario._Permitir_Abrir_Caixa = false;
                            bllUsuario._Permitir_Fechar_Caixa = false;
                            bllUsuario._Permitir_Real_SangSup = false;
                            bllUsuario._Permitir_Real_Conta_Receber = false;
                            bllUsuario._Permitir_Real_Conta_Pagar = false;
                            bllUsuario._Cadastrar_Cliente_Consumidor = false;
                            bllUsuario._Cadastrar_Conta_Pagar = false;
                            bllUsuario._Cadastrar_Conta_Receber = false;
                            bllUsuario._Cadastrar_Entidade_Bancaria = false;
                            bllUsuario._Cadastrar_Forma_Pagamento = false;
                            bllUsuario._Cadastrar_Fornecedor = false;
                            bllUsuario._Cadastrar_Funcionario = false;
                            bllUsuario._Cadastrar_Grupo = false;
                            bllUsuario._Cadastrar_Localizacao = false;
                            bllUsuario._Cadastrar_Marca = false;
                            bllUsuario._Cadastrar_Produto = false;
                            bllUsuario._Cadastrar_Subgrupo = false;
                            bllUsuario._Cadastrar_Usuario = false;
                            bllUsuario._Permitir_Pausar_Caixa = false;
                            bllUsuario._Permitir_Vis_Hist_Caixa = false;
                            bllUsuario._Permitir_Cad_No_Pdv = false;
                            bllUsuario._Permitir_Venda_N_Prom_S_Credito = false;
                            bllUsuario._Rel_Abert_Fech_Caixa = false;
                            bllUsuario._Rel_Cliente_Consumidor = false;
                            bllUsuario._Rel_Conta_Pagar = false;
                            bllUsuario._Rel_Conta_Receber = false;
                            bllUsuario._Rel_Produtos_Servico = false;
                            bllUsuario._Rel_Orcamento = false;
                            bllUsuario._Rel_Venda = false;
                            bllUsuario._Rel_Grupo = false;
                            bllUsuario._Rel_Funcionario = false;
                            bllUsuario._Rel_Formas_Pagamento = false;
                            bllUsuario._Rel_Fornecedor = false;
                            bllUsuario._Rel_Subgrupo = false;
                            bllUsuario._Rel_Historico_Caixa = false;
                            bllUsuario._Rel_Fluxo_Caixa = false;
                            bllUsuario._Rel_Saida_Produto = false;
                            bllUsuario._Rel_Entrada_Produto = false;
                            bllUsuario._Rel_Sangria_Suprimento = false;
                            bllUsuario._Rel_Devolucao_Servico = false;
                            bllUsuario._Permitir_Vis_Senha_Usuario = false;
                            bllUsuario._Permitir_Ignorar_Multa_Juros_Receber = false;
                            bllUsuario._Permitir_Exc_Sang_Sup = false;
                            bllUsuario._Rel_Usuario = false;
                            bllUsuario._Rel_Marca = false;
                            bllUsuario._Rel_Localizacao = false;
                            bllUsuario._Permitir_Venda_S_Credito_Loja = false;
                            bllUsuario._Permitir_Alt_Dados_Emp = false;
                            bllUsuario._Permitir_Alt_Dados_Config = false;
                            bllUsuario._Permitir_Atualizar_Zerar_Estoque = false;
                            bllUsuario._Rel_Estoque = false;
                            bllUsuario._Permitir_Excluir_Inventario = false;
                            bllUsuario._Capturar_Venda = false;
                            bllUsuario._Cadastrar_Servico = false;
                            bllUsuario._Permitir_Excluir_OS = false;
                            bllUsuario._Cadastrar_OS = false;
                            bllUsuario._Cadastrar_PSPPIX = false;
                            bllUsuario._Acessar_Menu_NFe_NFCe = false;
                            bllUsuario._Acessar_Menu_NFSe = false;
                            bllUsuario._Cadastrar_NFe = false;
                            bllUsuario._Rel_Comissao = false;
                            bllUsuario._Rel_Controle_Cheque = false;
                            bllUsuario._Rel_OS = false;
                            //
                            _Comando_Atualizar = false;
                            //
                            bllRegistroAtividades.Salvar("SALVOU UM USUARIO", "USUARIO", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Usuário cadastrado. Cod: " + txtCodigo.Text + " | Nome: " + txtNome_usuario.Text.Trim());
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Usuário cadastrado. Cod: " + txtCodigo.Text + " | Nome: " + txtNome_usuario.Text.Trim());
                            }
                            //
                            ModoPesquisa();
                            //                        
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bllUsuario._Funcoes_Salvas = false;
                            //
                            txtSenha.PasswordChar = '●';
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                        }
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                        txtpNomeUsuario.Text = null;
                        dtUsuario.DataSource = null;
                        rbtnNomeUsuario.Checked = true;
                        txtpNomeUsuario.Select();
                        ModoPesquisa();
                        Limpar();
                        _Comando_Atualizar = false;
                        bllUsuario._Funcoes_Salvas = false;
                    }
                }
            }
            else
            {
                txtNome_usuario.Select();
            }
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

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde você insere, altera e exclui dados.\n\n1 - Clicando no botão [ Novo ] você insere novos dados, ao finalizar clique no botão [ Salvar ].\n\n2 - Clicando no botão [ Alterar ] você alterar os dados já cadastrados no sistema clicando na caixa de texto em que deseja alterar, ao finalizar clique no botão [ Salvar ].\n\n3 - Clicando no botao [ Excluir ] você estará excluindo os dados selecionados na tabela.\n\n4 - Se por algum um motivo você clicou no botão: [ Novo ] ou no botão: [ Alterar ] e não deseja continuar nessas opções, clique no botão: [ Cancelar ].\n\n5 - Asterisco Vermelho (*): Significa que esse campo é obrigatório e precisa ser preenchido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFuncoes_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmCadFuncaoUsuario Func = new FrmCadFuncaoUsuario(txtCodigo.Text))
                {
                    if (Func.ShowDialog() == DialogResult.OK)
                    {
                        btnFuncoes.Select();
                        bllUsuario._Funcoes_Salvas = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFuncoes.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFuncoes.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void grbBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNome_usuario.Select();
            }
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
