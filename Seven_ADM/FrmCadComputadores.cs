using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadComputadores : Form
    {
        public FrmCadComputadores(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private bool _Comando_Atualizar = false;
        private byte _Formulario;
        int _UltimaLinha_Sel;
        private bool _Inserir_Atualizar;

        private void FrmCadComputadores_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\7 Sistema\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\7 Sistema\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\7 Sistema\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\7 Sistema\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadComputadores iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadComputadores iniciado.");
                }
                //
                if (bllCadastroComputadores.Sel_Todos_Computador_CadComputador() == null)
                {
                    btnNovo.Select();
                }
                else
                {
                    dtComp.DataSource = bllCadastroComputadores.Sel_Todos_Computador_CadComputador();
                    dtComp.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadComputadores.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadComputadores.");
                }
                this.Close();
            }
        }
        private void Limpar()
        {
            txtCodigo.Text = null;
            txtTipo.Text = null;
            txtSenha.Text = null;
            txtNomeDestePC.Text = null;
        }

        public void ModoPesquisa()
        {
            txtSenha.PasswordChar = '●';
            grbBox1.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtComp.Enabled = true;
            dtComp.Select();
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

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadComputadores_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtComp.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtComp.Enabled = false;
            grbBox1.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            Limpar();
            _Comando_Atualizar = false;
            _Inserir_Atualizar = true;
            if (dtComp.Rows.Count == 0)
            {
                txtTipo.Text = "SERVIDOR";
                txtNomeDestePC.ReadOnly = true;
                lblNomeComp.ForeColor = Color.Blue;
                txtNomeDestePC.Text = Dns.GetHostName();
                txtSenha.Select();
            }
            else
            {
                txtTipo.Text = "TERMINAL";
                txtNomeDestePC.ReadOnly = false;
                lblNomeComp.ForeColor = Color.Black;
                lblNomeComp.Select();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                dtComp.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                dtComp.Enabled = false;
                grbBox1.Enabled = true;
                btnNovo.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Visible = true;
                btnSalvar.Enabled = true;
                _Inserir_Atualizar = true;
                _Comando_Atualizar = true;
                //
                DataGridViewRow SelectedRow = dtComp.Rows[dtComp.CurrentRow.Index];
                //
                if (SelectedRow.Cells[2].Value.ToString() == "SERVIDOR")
                {
                    txtNomeDestePC.ReadOnly = true;
                    lblNomeComp.ForeColor = Color.Blue;
                    txtSenha.Select();
                }
                else
                {
                    txtNomeDestePC.ReadOnly = false;
                    lblNomeComp.ForeColor = Color.Black;
                    lblNomeComp.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
                dtComp.DataSource = null;
                Limpar();
                ModoPesquisa();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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
                if (dtComp.DataSource == null)
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
            ModoPesquisa();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
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
            txtSenha.Select();
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text.Contains("'") || txtSenha.Text.Contains(";") || txtSenha.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtSenha.Select();
                txtSenha.Text = null;
            }
            txtSenha.BackColor = Color.White;
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.LightBlue;
        }

        private void txtNomeDestePC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTipo.Select();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNomeDestePC.Select();
            }
        }

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSenha.Select();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (txtNomeDestePC.Text.Trim() == "" || txtSenha.Text.Trim() == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n< Nome do Computador >, < Senha de Autorização >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtSenha.Select();
                    }
                    else
                    {
                        if (_Comando_Atualizar == true)
                        {
                            _UltimaLinha_Sel = dtComp.Rows[dtComp.CurrentRow.Index].Index;

                            bllCadastroComputadores.Alterar(txtCodigo.Text, txtNomeDestePC.Text.Trim(), txtSenha.Text.Trim(), txtTipo.Text);

                            dtComp.DataSource = bllCadastroComputadores.Sel_Todos_Computador_CadComputador();

                            using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador alterado. Cod: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeDestePC.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador alterado. Cod: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeDestePC.Text);
                            }
                            //
                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            //
                            ModoPesquisa();
                            //
                            dtComp.CurrentCell = dtComp.Rows[_UltimaLinha_Sel].Cells[0];
                            //
                            dtComp.Rows[_UltimaLinha_Sel].Selected = true;
                            //
                            dtComp.FirstDisplayedScrollingRowIndex = _UltimaLinha_Sel;
                            //
                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllCadastroComputadores.Salvar(txtNomeDestePC.Text.Trim(), txtSenha.Text.Trim(), txtTipo.Text);

                            dtComp.DataSource = bllCadastroComputadores.Sel_Todos_Computador_CadComputador();

                            using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador cadastrado. Cod: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeDestePC.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador cadastrado. Cod: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeDestePC.Text);
                            }
                            //
                            _Comando_Atualizar = false;
                            _Inserir_Atualizar = false;
                            //
                            ModoPesquisa();
                            //
                            dtComp.CurrentCell = dtComp.Rows[dtComp.Rows.Count - 1].Cells[0];
                            //
                            dtComp.Rows[dtComp.Rows.Count - 1].Selected = true;
                            //
                            dtComp.FirstDisplayedScrollingRowIndex = dtComp.Rows.Count - 1;
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (_Formulario == 0)
                            {
                                this.DialogResult = DialogResult.Abort;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    txtSenha.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                dtComp.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dtComp_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtComp.Columns[0].HeaderText = "Código";
            dtComp.Columns[1].HeaderText = "Nome do Computador";
            dtComp.Columns[2].HeaderText = "Tipo de Computador";
            dtComp.Columns[3].Visible = false;

            dtComp.Columns[0].Width = 70;
            dtComp.Columns[1].Width = 516;
            dtComp.Columns[2].Width = 171;

            dtComp.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComp.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComp.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComp.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComp.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComp.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtComp.DefaultCellStyle.Font = new Font(dtComp.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtComp.Rows.Count;
        }

        private void dtComp_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtComp.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtComp.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtComp.Rows[dtComp.CurrentRow.Index];

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtNomeDestePC.Text = SelectedRow.Cells[1].Value.ToString();
                txtTipo.Text = SelectedRow.Cells[2].Value.ToString();
                txtSenha.Text = SelectedRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtComp.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtComp.");
                }
                Limpar();
                _Comando_Atualizar = false;
                dtComp.DataSource = null;
                ModoPesquisa();
            }
        }

        private void dtComp_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtComp.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtComp_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtComp_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtComp.DataSource == null)
            {
                dtComp.Enabled = false;
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
            }
            else
            {
                dtComp.Enabled = true;
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
            }
        }

        private void FrmCadComputadores_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadComputadores foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadComputadores foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadComputadores.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadComputadores.");
                }
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Senha de Autorização: Cadastre a senha que permitirá a conexão ao aplicativo quando requisitada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtComp_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtComp.Rows[dtComp.CurrentRow.Index];

                if (SelectedRow.Cells[2].Value.ToString() == "SERVIDOR")
                {
                    MessageBox.Show("Não é possível excluir o computador servidor deste banco de dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtComp.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este computador?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        string strHostName = Dns.GetHostName();

                        if (strHostName == txtNomeDestePC.Text)
                        {
                            DialogResult = MessageBox.Show("ATENÇÃO! Você está pestes a excluir a conexão atual deste computador no banco de dados, após a exclusão o aplicativo será finalizado, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                                bllCadastroComputadores.Excluir(txtCodigo.Text);

                                bllCadastroComputadores.Atualizar_Item_Dt_Computadores(dtComp.CurrentRow.Index + 1, dtComp.Rows.Count);

                                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador excluído. Cód: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeDestePC.Text);
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador excluído. Cód: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeDestePC.Text);
                                }

                                if (bllCadastroComputadores.Sel_Todos_Computador_CadComputador() == null)
                                {
                                    dtComp.DataSource = null;
                                    Limpar();
                                }
                                else
                                {
                                    dtComp.DataSource = bllCadastroComputadores.Sel_Todos_Computador_CadComputador();
                                    dtComp.Select();
                                }
                                //
                                MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                Application.Exit();
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            bllCadastroComputadores.Excluir(txtCodigo.Text);

                            bllCadastroComputadores.Atualizar_Item_Dt_Computadores(dtComp.CurrentRow.Index + 1, dtComp.Rows.Count);

                            using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador excluído. Cód: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeDestePC.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador excluído. Cód: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeDestePC.Text);
                            }

                            if (bllCadastroComputadores.Sel_Todos_Computador_CadComputador() == null)
                            {
                                dtComp.DataSource = null;
                                Limpar();
                            }
                            else
                            {
                                dtComp.DataSource = bllCadastroComputadores.Sel_Todos_Computador_CadComputador();
                                dtComp.Select();
                            }
                            //
                            MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                dtComp.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void txtNomeDestePC_Leave(object sender, EventArgs e)
        {
            if (txtNomeDestePC.Text != "")
            {
                try
                {
                    if (txtNomeDestePC.Text.Contains(";") || txtNomeDestePC.Text.Contains("'") || txtNomeDestePC.Text.Contains("="))
                    {
                        MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNomeDestePC.Text = null;
                        txtNomeDestePC.Select();
                    }
                    else
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == true)
                            {
                                if (bllCadastroComputadores.Val_Comp_Nome_Comp_PC_Alt(txtCodigo.Text, txtNomeDestePC.Text) == true)
                                {
                                    MessageBox.Show("O Nome do Computador informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtNomeDestePC.Text = null;
                                    txtNomeDestePC.Select();
                                }
                            }
                            else
                            {
                                if (bllCadastroComputadores.Val_Comp_Nome_Comp_PC(txtNomeDestePC.Text) == true)
                                {
                                    MessageBox.Show("O Nome do Computador informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    txtNomeDestePC.Text = null;
                                    txtNomeDestePC.Select();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNomeDestePC.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtNomeDestePC.");
                    }
                    txtNomeDestePC.Text = null;
                }
            }
            txtNomeDestePC.BackColor = Color.White;
        }
    }
}
