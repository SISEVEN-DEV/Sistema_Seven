using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace _7_Sistema_Config
{
    public partial class FrmConexoes : Form
    {
        public FrmConexoes()
        {
            InitializeComponent();
        }

        private bool _Comando_Atualizar = false;
        private bool _Inserir_Atualizar;
        int _UltimaLinha_Sel;

        private void FrmConexoes_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConexoes iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConexoes iniciado.");
                }
                //
                if (bllConexao.Sel_Todos_Conexao() == null)
                {
                    btnNovo.Select();
                }
                else
                {
                    dtConect.DataSource = bllConexao.Sel_Todos_Conexao();
                    dtConect.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConexoes.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConexoes.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Limpar()
        {
            txtCodigo.Text = null;
            cbbTipoConexao.Text = null;
            txtCaminhoBanco.Text = null;
            txtNomeServIP.Text = null;
            txtEntidade.Text = null;
            txtSenha.Text = null;
            txtOrdem.Text = null;
            txtPorta.Text = null;
            txtComputadorServidor.Text = null;
        }

        public void ModoPesquisa()
        {
            txtSenha.PasswordChar = '●';
            grbBox1.Enabled = false;
            btnNovo.Enabled = true;
            btnCancelar.Visible = false;
            btnSalvar.Enabled = false;
            dtConect.Enabled = true;
            dtConect.Select();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dtConect.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtConect.Enabled = false;
            grbBox1.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Visible = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            Limpar();
            _Comando_Atualizar = false;
            cbbTipoConexao.Text = "LOCAL";
            cbbTipoConexao.Select();
            _Inserir_Atualizar = true;
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
                if (dtConect.DataSource == null)
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

        private void FrmConexoes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void cbbTipoConexao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTipoConexao.SelectedIndex == 0)
            {
                string[] items = txtCaminhoBanco.Text.Split(':');
                //
                if (items[0] != @"C" & txtCaminhoBanco.Text != "" & txtCaminhoBanco.Text.Contains(":"))
                {
                    txtCaminhoBanco.Text = null;
                    MessageBox.Show("Para usar ':', é necessário selecionar a conexão em rede.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //
                btnEscolherLocal.Enabled = true;
                txtPorta.Enabled = false;
                txtPorta.Text = null;
                btnInserirNomeServidor.Enabled = true;
            }
            else if (cbbTipoConexao.SelectedIndex == 1)
            {
                string[] items = txtCaminhoBanco.Text.Split(':');
                //
                if (items[0] == @"C" & txtCaminhoBanco.Text != "" & txtCaminhoBanco.Text.Contains(":"))
                {
                    txtCaminhoBanco.Text = null;
                    MessageBox.Show("É necessário informar o nome do computador Servidor para usar a conexão em rede.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //
                btnEscolherLocal.Enabled = false;
                txtPorta.Enabled = false;
                txtPorta.Text = null;
                btnInserirNomeServidor.Enabled = false;
            }
            else if (cbbTipoConexao.SelectedIndex == 2)
            {
                string[] items = txtCaminhoBanco.Text.Split(':');
                //
                if (items[0] == @"C" & txtCaminhoBanco.Text != "" & txtCaminhoBanco.Text.Contains(":"))
                {
                    txtCaminhoBanco.Text = null;
                    MessageBox.Show("É necessário informar o nome do computador Servidor para usar a conexão em rede.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //
                btnEscolherLocal.Enabled = false;
                txtPorta.Enabled = true;
                txtPorta.Text = null;
                btnInserirNomeServidor.Enabled = false;
            }
        }

        private void btnEscolherLocal_Click(object sender, EventArgs e)
        {
            if (cbbTipoConexao.SelectedIndex == 0)
            {
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    file.Title = "Selecione um banco de dados";
                    file.Filter = "Banco de dados no formato:(*.FDB)|*.FDB";
                    file.InitialDirectory = @"C:\Sistema SEVEN\Bancos";

                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        if (file.FileName.Length > 60)
                        {
                            MessageBox.Show("O caminho escolhido é muito longo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            txtCaminhoBanco.Text = file.FileName;
                            if (file.FileName.Substring(0, 3) == @"C:\")
                            {
                                cbbTipoConexao.Text = "LOCAL";
                            }
                            else
                            {
                                MessageBox.Show(@"O banco de dados do sistema precisa ser instalado apenas no disco local C:\", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtCaminhoBanco.Text = null;
                                this.DialogResult = DialogResult.None;
                            }
                        }
                    }
                }
            }
        }

        private void txtNomeServIP_Leave(object sender, EventArgs e)
        {
            if (txtNomeServIP.Text.Contains(";") || txtNomeServIP.Text.Contains("'") || txtNomeServIP.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNomeServIP.Text = null;
                txtNomeServIP.Select();
            }
            txtNomeServIP.BackColor = Color.White;
        }

        private void txtCaminhoBanco_Leave(object sender, EventArgs e)
        {
            if (cbbTipoConexao.Text != "REDE")
            {
                string[] items = txtCaminhoBanco.Text.Split(':');
                //
                if (items[0] != @"C" & txtCaminhoBanco.Text != "" & txtCaminhoBanco.Text.Contains(":"))
                {
                    txtCaminhoBanco.Text = null;
                    MessageBox.Show("Para usar ':', é necessário selecionar a conexão em rede.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                string[] items = txtCaminhoBanco.Text.Split(':');
                //
                if (items[0] == @"C" & txtCaminhoBanco.Text != "" & txtCaminhoBanco.Text.Contains(":"))
                {
                    txtCaminhoBanco.Text = null;
                    MessageBox.Show("É necessário informar o nome do computador Servidor para usar a conexão em rede.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (txtCaminhoBanco.Text.Contains(";") || txtCaminhoBanco.Text.Contains("'") || txtCaminhoBanco.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCaminhoBanco.Text = null;
                txtCaminhoBanco.Select();
            }
            txtCaminhoBanco.BackColor = Color.White;
        }

        private void txtCaminhoBanco_Enter(object sender, EventArgs e)
        {
            txtCaminhoBanco.BackColor = Color.LightBlue;
        }

        private void txtNomeServIP_Enter(object sender, EventArgs e)
        {
            txtNomeServIP.BackColor = Color.LightBlue;
        }

        private void txtNomeServIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSenha.Select();
            }
        }

        private void txtCaminhoBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtOrdem.Select();
            }
        }

        private void txtEntidade_Enter(object sender, EventArgs e)
        {
            txtEntidade.BackColor = Color.LightBlue;
        }

        private void txtEntidade_Leave(object sender, EventArgs e)
        {
            if (txtEntidade.Text != "")
            {
                if (txtEntidade.Text.Contains(";") || txtEntidade.Text.Contains("'") || txtEntidade.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEntidade.Text = null;
                }
                else
                {
                    try
                    {
                        if (_Inserir_Atualizar == true)
                        {
                            if (_Comando_Atualizar == false)
                            {
                                if (bllConexao.Sel_Entidade_Ver_Nome(txtEntidade.Text) == true)
                                {
                                    MessageBox.Show("A Entidade informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtEntidade.Text = null;
                                    txtEntidade.Select();
                                }
                            }
                            else
                            {
                                if (bllConexao.Sel_Entidade_Ver_Nome_Alt(txtCodigo.Text, txtEntidade.Text) == true)
                                {
                                    MessageBox.Show("A Entidade informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtEntidade.Text = null;
                                    txtEntidade.Select();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do textbox txtEntidade.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave do textbox txtEntidade.");
                        }
                        txtEntidade.Text = null;
                    }
                }
            }
            //
            txtEntidade.BackColor = Color.White;
        }

        private void txtEntidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
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

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtComputadorServidor.Select();
            }
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

        private void dtConect_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtConect.Columns[0].HeaderText = "Código";
            dtConect.Columns[1].HeaderText = "Este Computador";
            dtConect.Columns[2].HeaderText = "Caminho para o Banco de Dados";
            dtConect.Columns[3].HeaderText = "Senha de Autorização";
            dtConect.Columns[4].HeaderText = "Tipo de Conexão";
            dtConect.Columns[5].HeaderText = "Ordem";
            dtConect.Columns[6].HeaderText = "Entidade";
            dtConect.Columns[7].HeaderText = "Nome do Servidor";
            dtConect.Columns[8].HeaderText = "Porta";
            dtConect.Columns[7].DisplayIndex = 2;
            dtConect.Columns[8].DisplayIndex = 5;
            dtConect.Columns[4].DisplayIndex = 1;

            dtConect.Columns[0].Width = 85;
            dtConect.Columns[1].Width = 220;
            dtConect.Columns[2].Width = 280;
            dtConect.Columns[3].Width = 135;
            dtConect.Columns[4].Width = 150;
            dtConect.Columns[5].Width = 85;
            dtConect.Columns[6].Width = 220;
            dtConect.Columns[7].Width = 220;
            dtConect.Columns[8].Width = 125;

            dtConect.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtConect.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtConect.DefaultCellStyle.Font = new Font(dtConect.Font, FontStyle.Bold);

            lblRegistros.Text = "Registros: " + dtConect.Rows.Count;
        }

        private void dtConect_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtConect_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtConect.Rows[dtConect.CurrentRow.Index];

                dtConect.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtConect.DefaultCellStyle.SelectionForeColor = Color.Black;

                txtCodigo.Text = SelectedRow.Cells[0].Value.ToString();
                txtNomeServIP.Text = SelectedRow.Cells[1].Value.ToString();
                txtCaminhoBanco.Text = SelectedRow.Cells[2].Value.ToString();
                txtSenha.Text = SelectedRow.Cells[3].Value.ToString();
                cbbTipoConexao.Text = SelectedRow.Cells[4].Value.ToString();
                txtOrdem.Text = SelectedRow.Cells[5].Value.ToString();
                txtEntidade.Text = SelectedRow.Cells[6].Value.ToString();
                txtComputadorServidor.Text = SelectedRow.Cells[7].Value.ToString();
                txtPorta.Text = SelectedRow.Cells[8].Value.ToString();
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
                dtConect.DataSource = null;
                dtConect.Select();
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void dtConect_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                dtConect.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('\u25CF', e.Value.ToString().Length);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dtConect.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            dtConect.Enabled = false;
            grbBox1.Enabled = true;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Visible = true;
            btnSalvar.Enabled = true;
            cbbTipoConexao.Select();
            _Comando_Atualizar = true;
            _Inserir_Atualizar = true;
        }

        private void dtConect_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtConect.DataSource == null)
            {
                dtConect.Enabled = false;
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
            }
            else
            {
                dtConect.Enabled = true;
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
            }
        }

        private void dtConect_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtConect.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtConect_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoConexao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNomeServIP.Select();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //try
            //{
                txtCaminhoBanco.Select();
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (_Comando_Atualizar == true)
                    {
                        if (txtOrdem.Text != "")
                        {
                            if (bllConexao.Sel_Conexao_Ordem_Alt(txtCodigo.Text, txtOrdem.Text) == true)
                            {
                                DialogResult = MessageBox.Show("A Ordem informada já está cadastrada, deseja substituir a ordem existente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                    //
                                    if (bllConexao.Sel_Ult_Ordem_Existe() == null)
                                    {
                                        txtOrdem.Text = "1";
                                    }
                                    else
                                    {
                                        txtOrdem.Text = bllConexao.Sel_Ult_Ordem_Existe();
                                    }
                                    //
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (bllConexao.Sel_Ult_Ordem_Existe() == null)
                            {
                                txtOrdem.Text = "1";
                            }
                            else
                            {
                                txtOrdem.Text = bllConexao.Sel_Ult_Ordem_Existe();
                            }
                        }
                    }
                    else
                    {
                        if (txtOrdem.Text != "")
                        {
                            if (bllConexao.Sel_Conexao_Ordem_Ver(txtOrdem.Text.Trim()) == true)
                            {
                                MessageBox.Show("A Ordem informada já está cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                    }
                    //
                    this.DialogResult = DialogResult.None;
                    if (cbbTipoConexao.Text == "" || txtNomeServIP.Text.Trim() == "" || txtCaminhoBanco.Text.Trim().Trim() == "" || txtEntidade.Text.Trim().Trim() == "" || txtSenha.Text.Trim().Trim() == "" || txtOrdem.Text.Trim() == "" || txtComputadorServidor.Text.Trim() == "")
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: \n[ Tipo de Conexão ], [ Este Computador ], [ Senha de Autorização ], [ Nome do Servidor ], [ Caminho para o banco de dados ], [ Ordem ] e [ Entidade ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipoConexao.Select();
                    }
                    else if (txtOrdem.Text.Trim() == "0")
                    {
                        MessageBox.Show("O campo Ordem não pode ser 0.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        if (_Comando_Atualizar == true)
                        {
                            _UltimaLinha_Sel = dtConect.Rows[dtConect.CurrentRow.Index].Index;

                            DataGridViewRow SelectedRow = dtConect.Rows[dtConect.CurrentRow.Index];

                            bllConexao.Alterar(txtCodigo.Text, txtCaminhoBanco.Text.Trim(), cbbTipoConexao.Text, txtNomeServIP.Text.Trim(), txtEntidade.Text.Trim(), txtSenha.Text.Trim(), txtOrdem.Text.Trim(), SelectedRow.Cells[5].Value.ToString(), txtComputadorServidor.Text, txtPorta.Text);

                            dtConect.DataSource = bllConexao.Sel_Todos_Conexao();

                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão alterada. Cod: " + txtCodigo.Text + " | Tipo de Conexao: " + cbbTipoConexao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão alterada. Cod: " + txtCodigo.Text + " | Tipo de Conexao: " + cbbTipoConexao.Text);
                            }
                            //
                            _Comando_Atualizar = false;
                            //
                            ModoPesquisa();
                            //
                            dtConect.CurrentCell = dtConect.Rows[_UltimaLinha_Sel].Cells[0];
                            //
                            dtConect.Rows[_UltimaLinha_Sel].Selected = true;
                            //
                            dtConect.FirstDisplayedScrollingRowIndex = _UltimaLinha_Sel;
                            //
                            if (bllConfiguracaoSistema.Sel_Tabela_Configuracao_Local_Configuracoes(bllConexao._Codigo_Conexao) == null) 
                            {
                                bllConfiguracaoSistema.Salvar_Local("0", "0", "0", "0", "0", "0", "0", "0", false, "", @"C:\Sistema SEVEN\Config\Miscellaneous\logo.png", "ESTICADA", false, true, false, "Obrigado e volte sempre!", false, "Impressora Térmica(80mm)(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", null, null, null, null, null, txtCodigo.Text, false, "3", "6", "DAV", true);
                            }
                            //
                            MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            bllConexao.Salvar(txtCaminhoBanco.Text.Trim(), cbbTipoConexao.Text, txtNomeServIP.Text.Trim(), txtEntidade.Text.Trim(), txtSenha.Text.Trim(), txtOrdem.Text.Trim(), txtComputadorServidor.Text, txtPorta.Text);
                            //
                            dtConect.DataSource = bllConexao.Sel_Todos_Conexao();
                            //
                            _Comando_Atualizar = false;
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão cadastrada. Cod: " + txtCodigo.Text + " | Tipo de Conexao: " + cbbTipoConexao.Text);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão cadastrada. Cod: " + txtCodigo.Text + " | Tipo de Conexao: " + cbbTipoConexao.Text);
                            }
                            //
                            ModoPesquisa();
                            //
                            dtConect.CurrentCell = dtConect.Rows[dtConect.Rows.Count - 1].Cells[0];
                            //
                            dtConect.Rows[dtConect.Rows.Count - 1].Selected = true;
                            //
                            dtConect.FirstDisplayedScrollingRowIndex = dtConect.Rows.Count - 1;
                            //
                            bllConfiguracaoSistema.Salvar_Local("0", "0", "0", "0", "0", "0", "0", "0", false, "", @"C:\Sistema SEVEN\Config\Miscellaneous\logo.png", "ESTICADA", false, true, false, "Obrigado e volte sempre!", false, "Impressora Térmica(80mm)(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", null, null, null, null, null, txtCodigo.Text, false, "3", "6", "DAV", true);
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    cbbTipoConexao.Select();
                }
                //
                _Inserir_Atualizar = false;
            /*
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
                dtConect.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
                _Inserir_Atualizar = false;
            }
            */
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja excluir esta conexão?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Local(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Layout_PDV(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Dado_PDV_Atual(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_DFE_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Conta_Pagar_Pgto_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Conta_Receber_Pgto_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Devolucao_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Dev_Prod_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Dfe_Pgto_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Dfe_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Orcamento_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Os_Funcionario_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Os_Pgto_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Os_Produto_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Parcelamento_Dfe(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_PDV_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Item_Servico_Temp(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_SMS_Configuracoes(txtCodigo.Text);
                    //
                    bllConfiguracaoSistema.Excluir_Configuracao_Transportador_Temp(txtCodigo.Text);
                    //
                    bllConexao.Excluir(txtCodigo.Text);
                    //
                    bllConexao.Atualizar_Item_Dt_Conexao(dtConect.CurrentRow.Index + 1, dtConect.Rows.Count);

                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão excluída. Cod: " + txtCodigo.Text + " | Tipo: " + cbbTipoConexao.Text);
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Conexão excluída. Cod: " + txtCodigo.Text + " | Tipo: " + cbbTipoConexao.Text);
                    }
                    //
                    if (bllConexao.Sel_Todos_Conexao() == null)
                    {
                        dtConect.DataSource = null;
                        Limpar();
                    }
                    else
                    {
                        dtConect.DataSource = bllConexao.Sel_Todos_Conexao();
                        dtConect.Select();
                    }
                    MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirMini.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirMini.");
                }
                dtConect.DataSource = null;
                ModoPesquisa();
                Limpar();
                _Comando_Atualizar = false;
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tipo de Conexão:\n\n1 - LOCAL: Significa que o banco de dados que irá ser informado no aplicativo estará localizado neste computador.\n\n2 - REDE (LAN): Significa que o banco de dados que irá ser informado no aplicativo está localizado em um outro computador.\n\n3 - REDE (VPS): Significa que o banco de dados que irá ser informado no aplicativo está localizado em um servidor distante.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNomeDestePC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSenha.Select();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbbTipoConexao.Select();
        }

        private void txtOrdem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtEntidade.Select();
            }
        }

        private void txtOrdem_Leave(object sender, EventArgs e)
        {
            if (txtOrdem.Text.Contains(";") || txtOrdem.Text.Contains("'") || txtOrdem.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtOrdem.Text = null;
                txtOrdem.Select();
            }
            txtOrdem.BackColor = Color.White;
        }

        private void txtOrdem_Enter(object sender, EventArgs e)
        {
            txtOrdem.BackColor = Color.LightBlue;
        }

        private void FrmConexoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConexoes foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConexoes foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmConexoes.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmConexoes.");
                }
            }
        }

        private void btnInserirNomeComputador_Click(object sender, EventArgs e)
        {
            txtNomeServIP.Text = Environment.MachineName;
        }

        private void btnInserirNomeComputador_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnInserirNomeComputador_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEscolherLocal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEscolherLocal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void cbbTipoConexao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoConexao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoConexao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoConexao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtCaminhoBanco_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComputadorServidor_Leave(object sender, EventArgs e)
        {
            if (txtComputadorServidor.Text.Contains(";") || txtComputadorServidor.Text.Contains("'") || txtComputadorServidor.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtComputadorServidor.Text = null;
                txtComputadorServidor.Select();
            }
            txtComputadorServidor.BackColor = Color.White;
        }

        private void txtComputadorServidor_Enter(object sender, EventArgs e)
        {
            txtComputadorServidor.BackColor = Color.LightBlue;
        }

        private void txtComputadorServidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtPorta.Enabled == false)
                {
                    txtCaminhoBanco.Select();
                }
                else
                {
                    txtPorta.Select();
                }
                   
            }
        }

        private void txtPorta_Enter(object sender, EventArgs e)
        {
            txtPorta.BackColor = Color.LightBlue;
        }

        private void txtPorta_Leave(object sender, EventArgs e)
        {
            if (txtPorta.Text.Contains(";") || txtPorta.Text.Contains("'") || txtPorta.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtPorta.Text = null;
                txtPorta.Select();
            }
            txtPorta.BackColor = Color.White;
        }

        private void txtPorta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            { 
                txtCaminhoBanco.Select();
            }
        }

        private void btnInserirNomeServidor_Click(object sender, EventArgs e)
        {
            txtComputadorServidor.Text = Environment.MachineName;
        }
    }
}
