using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace _7_Sistema_Config
{
    public partial class FrmCadastroComputadores : Form
    {
        public FrmCadastroComputadores()
        {
            InitializeComponent();
        }

        private bool _Comando_Atualizar = false;
        int _UltimaLinha_Sel;

        private void FrmCadastroComputadores_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadastroComputadores iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadastroComputadores iniciado.");
                }
                //
                if (bllConexao.Sel_Todos_Computadores() == null)
                {
                    btnNovo.Select();
                }
                else
                {
                    dtComputadores.DataSource = bllConexao.Sel_Todos_Computadores();
                    dtComputadores.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadastroComputadores.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadastroComputadores.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            cbbTipo.Text = null;
            txtNomeComputador.Text = null;
            txtSenha.Text = null;
        }

        public void ModoPesquisa()
        {
            txtSenha.PasswordChar = '●';
            grbBox1.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtComputadores.Enabled = true;
            dtComputadores.Select();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtComputadores.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtComputadores.Enabled = false;
            grbBox1.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            Limpar();
            _Comando_Atualizar = false;
            //
            if (dtComputadores.Rows.Count == 0)
            {
                cbbTipo.Text = "SERVIDOR";
            }
            else
            {
                cbbTipo.Text = "TERMINAL";
            }
            //
            txtNomeComputador.Select();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void FrmCadastroComputadores_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
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
                if (dtComputadores.DataSource == null)
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
            ModoPesquisa();
        }

        private void txtNomeComputador_Leave(object sender, EventArgs e)
        {
            if (txtNomeComputador.Text.Contains(";") || txtNomeComputador.Text.Contains("'") || txtNomeComputador.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNomeComputador.Text = null;
                txtNomeComputador.Select();
            }
            txtNomeComputador.BackColor = Color.White;
        }

        private void txtNomeComputador_Enter(object sender, EventArgs e)
        {
            txtNomeComputador.BackColor = Color.LightBlue;
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text.Contains(";") || txtSenha.Text.Contains("'") || txtSenha.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtSenha.Text = null;
                txtSenha.Select();
            }
            txtSenha.BackColor = Color.White;
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.LightBlue;
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

        private void btnVer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNomeComputador_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtComputadores_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtComputadores.Columns[0].HeaderText = "Código";
            dtComputadores.Columns[1].HeaderText = "Nome do Computador";
            dtComputadores.Columns[2].HeaderText = "Senha de Autorização";
            dtComputadores.Columns[3].HeaderText = "Tipo de Conexão";
            dtComputadores.Columns[4].Visible = false;
            dtComputadores.Columns[5].Visible = false;
            //
            dtComputadores.Columns[0].Width = 85;
            dtComputadores.Columns[1].Width = 367;
            dtComputadores.Columns[2].Width = 135;
            dtComputadores.Columns[3].Width = 150;
            //
            dtComputadores.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComputadores.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComputadores.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComputadores.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComputadores.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComputadores.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComputadores.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtComputadores.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            dtComputadores.DefaultCellStyle.Font = new Font(dtComputadores.Font, FontStyle.Bold);
            //
            lblRegistros.Text = "Registros: " + dtComputadores.Rows.Count;
        }

        private void dtComputadores_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtComputadores_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtComputadores.Rows[dtComputadores.CurrentRow.Index];

                dtComputadores.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtComputadores.DefaultCellStyle.SelectionForeColor = Color.Black;

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtNomeComputador.Text = SelectedRow.Cells[1].Value.ToString();
                txtSenha.Text = SelectedRow.Cells[2].Value.ToString();
                cbbTipo.Text = SelectedRow.Cells[3].Value.ToString();
                if (Convert.ToByte(SelectedRow.Cells[4].Value) == 1)
                {
                    chkbADM.Enabled = true;
                    chkbADM.Checked = true;
                }
                else
                {
                    chkbADM.Enabled = false;
                    chkbADM.Checked = false;
                }
                //
                if (Convert.ToByte(SelectedRow.Cells[5].Value) == 1)
                {
                    chkbPDV.Enabled = true;
                    chkbPDV.Checked = true;
                }
                else
                {
                    chkbPDV.Enabled = false;
                    chkbPDV.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtConect.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtConect.");
                }
                dtComputadores.DataSource = null;
                dtComputadores.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void dtComputadores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                dtComputadores.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('\u25CF', e.Value.ToString().Length);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dtComputadores.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtComputadores.Enabled = false;
            grbBox1.Enabled = true;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnSalvar.Enabled = true;
            txtNomeComputador.Select();
            _Comando_Atualizar = true;
        }

        private void dtComputadores_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtComputadores.DataSource == null)
            {
                dtComputadores.Enabled = false;
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
            }
            else
            {
                dtComputadores.Enabled = true;
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
            }
        }

        private void dtComputadores_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtComputadores.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtComputadores_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadastroComputadores_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadastroComputadores foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadastroComputadores foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadastroComputadores.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadastroComputadores.");
                }
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

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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
                    if (txtNomeComputador.Text.Trim() == "" || txtSenha.Text.Trim().Trim() == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: \n[ Nome do Computador ] e [ Senha de Autorização ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtNomeComputador.Select();
                    }
                    else
                    {
                        if (_Comando_Atualizar == true)
                        {
                            _UltimaLinha_Sel = dtComputadores.Rows[dtComputadores.CurrentRow.Index].Index;

                            DataGridViewRow SelectedRow = dtComputadores.Rows[dtComputadores.CurrentRow.Index];

                            bllCadastroComputadores.Alterar(txtCodigo.Text, txtNomeComputador.Text.Trim(), txtSenha.Text.Trim(), cbbTipo.Text, chkbADM.Checked, chkbPDV.Checked);

                            dtComputadores.DataSource = bllCadastroComputadores.Sel_Todos_Computador_CadComputador();

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador alterado. Cod: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeComputador.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador alterado. Cod: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeComputador.Text);
                            }
                            //
                            _Comando_Atualizar = false;
                            //
                            ModoPesquisa();
                            //
                            dtComputadores.CurrentCell = dtComputadores.Rows[_UltimaLinha_Sel].Cells[0];
                            //
                            dtComputadores.Rows[_UltimaLinha_Sel].Selected = true;
                            //
                            dtComputadores.FirstDisplayedScrollingRowIndex = _UltimaLinha_Sel;
                            //
                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllCadastroComputadores.Salvar(txtNomeComputador.Text.Trim(), txtSenha.Text.Trim(), cbbTipo.Text, chkbADM.Checked, chkbPDV.Checked);
                            //
                             //
                            dtComputadores.DataSource = bllCadastroComputadores.Sel_Todos_Computador_CadComputador();
                            //
                            _Comando_Atualizar = false;
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador cadastrado. Cod: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeComputador.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador cadastrado. Cod: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeComputador.Text);
                            }
                            //
                            //
                            ModoPesquisa();
                            //
                            dtComputadores.CurrentCell = dtComputadores.Rows[dtComputadores.Rows.Count - 1].Cells[0];
                            //
                            dtComputadores.Rows[dtComputadores.Rows.Count - 1].Selected = true;
                            //
                            dtComputadores.FirstDisplayedScrollingRowIndex = dtComputadores.Rows.Count - 1;
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    txtNomeComputador.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvarMini.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvarMini.");
                }
                dtComputadores.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNomeComputador.Text = Environment.MachineName;
        }

        private void btnInserirNomeComputador_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnInserirNomeComputador_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtComputadores.Rows[dtComputadores.CurrentRow.Index];

                DialogResult = MessageBox.Show("Deseja excluir este computador?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (bllCadastroComputadores.Sel_Computador_Fluxo_Ver(txtCodigo.Text) == true)
                    {
                        MessageBox.Show("O Computador selecionado está sendo utilizado por um Fluxo de Caixa, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtComputadores.Select();
                    }
                    else if (bllCadastroComputadores.Sel_Computador_Abert_Fech_Caixa_Ver(txtCodigo.Text) == true)
                    {
                        MessageBox.Show("O Computador selecionado está sendo utilizado por uma Abertura Fechamento de Caixa, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtComputadores.Select();
                    }
                    else if (bllCadastroComputadores.Sel_Computador_Devolucao_Ver(txtCodigo.Text) == true)
                    {
                        MessageBox.Show("O Computador selecionado está sendo utilizado por uma Devolução, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtComputadores.Select();
                    }
                    else if (bllCadastroComputadores.Sel_Computador_Orcamento_Ver(txtCodigo.Text) == true)
                    {
                        MessageBox.Show("O Computador selecionado está sendo utilizado por um Orçamento, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtComputadores.Select();
                    }
                    else if (bllCadastroComputadores.Sel_Computador_Registro_Atividade_Ver(txtCodigo.Text) == true)
                    {
                        MessageBox.Show("O Computador selecionado está sendo utilizado por um Registro de Atividades, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtComputadores.Select();
                    }
                    else if (bllCadastroComputadores.Sel_Adm_Aberto_Ver(txtCodigo.Text) == true)
                    {
                        MessageBox.Show("O Computador selecionado está sendo utilizado agora por Sistema SEVEN - ADM, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtComputadores.Select();
                    }
                    else if (bllCadastroComputadores.Sel_Pdv_Aberto_Ver(txtCodigo.Text) == true)
                    {
                        MessageBox.Show("O Computador selecionado está sendo utilizado agora por Sistema SEVEN - PDV, não é possível excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        dtComputadores.Select();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        string strHostName = Dns.GetHostName();
                        //
                        this.DialogResult = DialogResult.None;
                        bllCadastroComputadores.Excluir(txtCodigo.Text);
                        //
                        bllCadastroComputadores.Atualizar_Item_Dt_Computadores(dtComputadores.CurrentRow.Index + 1, dtComputadores.Rows.Count);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador excluído. Cód: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeComputador.Text);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Computador excluído. Cód: " + txtCodigo.Text + " | Nome do Computador: " + txtNomeComputador.Text);
                        }
                        //
                        if (bllCadastroComputadores.Sel_Todos_Computador_CadComputador() == null)
                        {
                            dtComputadores.DataSource = null;
                            Limpar();
                        }
                        else
                        {
                            dtComputadores.DataSource = bllCadastroComputadores.Sel_Todos_Computador_CadComputador();
                            dtComputadores.Select();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                dtComputadores.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Nome do Computador: Cadastre o nome do computador que ficará cadastrado no sistema.\n\n2 - Senha de Autorização: Cadastre a senha que permitirá a conexão ao aplicativo quando requisitada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void chkbPDV_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPDV_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbADM_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbADM_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnLimparRegistroAtividades_Click(object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja limpar os registros de atividades deste banco de dados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    bllCadastroComputadores.Apagar_Registro_Atividades();
                    MessageBox.Show("Registro de atividades apagado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    txtNomeComputador.Select();
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvarMini.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvarMini.");
                }
                dtComputadores.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }
    }
}
