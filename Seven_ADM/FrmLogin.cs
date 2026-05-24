using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        bool _Primeiro_Acesso = false;

        private List<string> Conexao_Codigo = new List<string>();

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }
                //
                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sistema SEVEN - Admnistração iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sistema SEVEN - Admnistração iniciado.");
                }
                //
                ServiceController Service = new ServiceController("FirebirdGuardianDefaultInstance");
                //
                switch (Service.Status)
                {
                    case ServiceControllerStatus.Running:
                        break;
                    default:
                        DialogResult = MessageBox.Show("O serviço do banco de dados não está ativo, deseja ativar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            Service.Start();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("O aplicativo necessita do serviço de banco de dados para inicializar, inicie o serviço e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Application.Exit();
                            break;
                        }
                }
                //
                if (bllCadastroComputadores.Sel_Computadores_Op_Ver_Codigo() == null)
                {
                    _Primeiro_Acesso = true;
                    bllConexao.Salvar(@"C:\Sistema SEVEN\Bancos\7.FDB", "LOCAL", Environment.MachineName, "Sistema SEVEN", "123", "1", Environment.MachineName, null);
                    bllConfiguracaoSistema.Salvar_Local("0", "0", "0", "0", "0", "0", "0", "0", false, "", @"C:\Sistema SEVEN\Config\Miscellaneous\logo.png", "ESTICADA", false, true, false, "Obrigado e volte sempre!", false, "Impressora Térmica(80mm)(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", null, null, null, null, null, "1", false, "3", "6", "DAV", true);
                }
                //
                if (bllLogin.VerificarProcesso("Seven_ADM") > 1)
                {
                    MessageBox.Show("O aplicativo Sistema SEVEN - Admnistração já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
                else
                {
                    if (bllConexao.Sel_Conexao_Empresa_Todas() == null)
                    {
                        cbbEmpresa.Text = null;
                        btnLogar.Enabled = false;
                    }
                    else
                    {
                        string largura = Screen.PrimaryScreen.Bounds.Width.ToString();
                        string altura = Screen.PrimaryScreen.Bounds.Height.ToString();
                        //
                        if (bllConexao.Sel_Conexao_Empresa_Todas().Rows.Count == 1)
                        {
                            btnQtdeEntidades.Visible = false;
                            cbbEmpresa.Visible = false;
                            pcibLogo.Location = new Point(16, -16);
                            lblEmpresa.Text = "Logar:";
                            lblAsterisco3.Visible = false;
                            lblEmpresa.Location = new Point(231, -1);
                            grbBox1.Size = new Size(490, 86);
                            grbBox1.Location = new Point(16, 268);
                            lblUsuario.Location = new Point(132, 31);
                            lblSenha.Location = new Point(149, 57);
                            lblAsterisco1.Location = new Point(185, 27);
                            lblAsterisco2.Location = new Point(185, 54);
                            txtUsuario.Location = new Point(198, 28);
                            txtSenha.Location = new Point(198, 54);
                            btnVer.Location = new Point(316, 51);
                        }
                        else
                        {
                            btnQtdeEntidades.Visible = true;
                            cbbEmpresa.Visible = true;
                            pcibLogo.Location = new Point(16, -49);
                            lblEmpresa.Text = "Empresa/Entidade:";
                            lblAsterisco3.Location = new Point(116, 12);
                            lblAsterisco3.Visible = true;
                            lblEmpresa.Location = new Point(6, 16);
                            grbBox1.Size = new Size(490, 119);
                            grbBox1.Location = new Point(16, 235);
                            lblUsuario.Location = new Point(132, 69);
                            lblSenha.Location = new Point(149, 95);
                            lblAsterisco1.Location = new Point(185, 65);
                            lblAsterisco2.Location = new Point(185, 91);
                            txtUsuario.Location = new Point(198, 66);
                            txtSenha.Location = new Point(198, 92);
                            btnVer.Location = new Point(316, 89);
                        }
                        //
                        foreach (DataRow dr in bllConexao.Sel_Conexao_Empresa_Todas().Rows)
                        {
                            Conexao_Codigo.Add(dr["id_conexao_configuracoes"].ToString());
                            cbbEmpresa.Items.Add(dr["entidade"].ToString());
                        }
                        cbbEmpresa.SelectedIndex = 0;
                        btnLogar.Enabled = true;
                    }
                }
                //
                if (cbbEmpresa.Items.Count > 1)
                {
                    btnQtdeEntidades.Enabled = true;
                    timerEntidade.Start();
                    btnQtdeEntidades.Text = cbbEmpresa.Items.Count.ToString();
                }
                else
                {
                    btnQtdeEntidades.Enabled = false;
                }
                //
                /*
                if (bllCadastroComputadores.Sel_Computadores_Ver_Codigo(Environment.MachineName) == null & bllUsuario.Sel_Usuario_Todos() == null)
                {
                    _Primeiro_Acesso = true;
                    bllConfiguracaoSistema.Salvar_Local("0", "0", "0", "0", "0", "0", "0", "0", false, "", @"C:\Sistema SEVEN\Config\Miscellaneous\logo.png", "ESTICADA", false, true, false, "Obrigado e volte sempre!", false, "Impressora Térmica(80mm)(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", "A4(Mostrar na Tela)", null, null, null, null, null, bllConexao._Codigo_Conexao, false, "3", "6", "DAV");
                }
                */
                //
                if (_Primeiro_Acesso == true)
                {
                    if (bllConfiguracaoSistema.Sel_Tabela_Configuracao_Global_Configuracoes() == null)
                    {
                        bllConfiguracaoSistema.Salvar_Global(false, false, true, false, false, false, false, "587", false);
                    }
                    //
                    bllCadastroComputadores.Salvar(Environment.MachineName, "123", "SERVIDOR", true, true);
                    bllUsuario._Funcoes_Iniciais = true;
                    bllUsuario.Salvar("ADM", "123", null);
                    bllAbert_Fech_Caixa.Salvar_Abertura("0,00", "/Nº PDV: 1", "Usuário(a): 1—ADM", Environment.MachineName.ToUpper());
                    //
                    using (FrmMessageBoxTempo Mess = new FrmMessageBoxTempo())
                    {
                        if (Mess.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                    //
                    txtUsuario.Text = "ADM";
                    txtSenha.Text = "123";
                    //
                    btnLogar.Select();
                }
                else
                {
                    if (bllRegistroAtividades.Sel_Dados_Tabela_Reg_Ativ_Existe() == 0)
                    {
                        txtUsuario.Text = "ADM";
                        txtSenha.Text = "123";
                    }
                    //
                    txtUsuario.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLogin.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLogin.");
                }
            }
            //
            try
            {
                bllVersao.LimparArquivosOld();
            }
            catch (Exception ex)
            {
                if (bllConexao.Sel_Conexao_Empresa_Todas().Rows.Count == 1)
                {
                    cbbEmpresa.Visible = false;
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLogin.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLogin.");
                }

            }
        }

        private async void btnLogar_ClickAsync(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" || txtSenha.Text.Trim() == "")
            {
                MessageBox.Show("Os campos [ Usuário ] e [ Senha ] são obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    if (bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text) == null)
                    {
                        MessageBox.Show("O nome de usuário e/ou senha estão incorretos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (bllLicenca.Verificar_Licenca(DateTime.Now.ToShortDateString()) == true)
                        {
                            MessageBox.Show("Bem-vindo Senhor(a): " + txtUsuario.Text, "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            bllUsuario.Nome_Usuario_Logado = txtUsuario.Text;
                            //
                            bllConexao._Usuario = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text);
                            //
                            bllConexao._Descricao_Entidade = cbbEmpresa.Text.Trim();
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            bool conexao = await bllVersao.VerificarInternet();
                            //
                            if (conexao == true)
                            {
                                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                {
                                    if (bllVersao.VerificarAtualizacoesSQL_CPF_CNPJ() == true)
                                    {
                                        bllVersao.BaixarAtualizacoesSQL_CPF_CNPJ();
                                    }
                                }
                            }
                            //
                            if (bllLicenca.Verificar_Licenca(DateTime.Now.ToShortDateString()) == true)
                            {
                                MessageBox.Show("Bem-vindo Senhor(a): " + txtUsuario.Text, "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                bllUsuario.Nome_Usuario_Logado = txtUsuario.Text;
                                //
                                bllConexao._Usuario = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text);
                                //
                                bllConexao._Descricao_Entidade = cbbEmpresa.Text.Trim();
                                //
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(0))
                                {
                                    if (Lic.ShowDialog() == DialogResult.OK)
                                    {
                                        MessageBox.Show("Bem-vindo Senhor(a): " + txtUsuario.Text, "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //
                                        bllUsuario.Nome_Usuario_Logado = txtUsuario.Text;
                                        //
                                        bllConexao._Usuario = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text);
                                        //
                                        bllConexao._Descricao_Entidade = cbbEmpresa.Text.Trim();
                                        //
                                        this.DialogResult = DialogResult.OK;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnLogar.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnLogar.");
                    }
                    txtUsuario.Text = null;
                    txtSenha.Text = null;
                }
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
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
                btnLogar.Select();
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.LightBlue;
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Contains("'") || txtUsuario.Text.Contains(";") || txtUsuario.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = null;
            }
            txtUsuario.BackColor = Color.White;
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
            }
            txtSenha.BackColor = Color.White;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnLogar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_Enter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta é a seção aonde o usuário (você) acessa o sistema.\r1 - Clicando no combobox [ Empresa ] você estará selecionando a empresa que o usuário (você) irá acessar. >.\nApós, preencha os campos de usuário e senha cadastrados na empresa selecionada após clique em logar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void cbbEmpresa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEmpresa_MouseLeave(object sender, EventArgs e)
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

        private void cbbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbEmpresa.Text != "")
                {
                    bllConexao.Sel_Conexao_Completa_Con(Conexao_Codigo[cbbEmpresa.SelectedIndex]);
                    bllConexao.Sel_Descricao_Conexao_Atual(Conexao_Codigo[cbbEmpresa.SelectedIndex]);
                    bllConexao._Codigo_Conexao = Conexao_Codigo[cbbEmpresa.SelectedIndex];
                }
                txtUsuario.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do cbbEmpresa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do cbbEmpresa.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void lblSiseven_MouseMove(object sender, MouseEventArgs e)
        {
            lblSiseven.ForeColor = Color.Blue;
            lblSiseven.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);
            this.Cursor = Cursors.Hand;
        }

        private void lblSiseven_MouseLeave(object sender, EventArgs e)
        {
            lblSiseven.ForeColor = Color.Black;
            lblSiseven.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
            this.Cursor = Cursors.Default;
        }

        private void lblSiseven_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("www.siseven.com.br");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lblSiseven.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lblSiseven.");
                }
            }
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sistema SEVEN - Admnistração finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sistema SEVEN - Admnistração finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmLogin.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmLogin.");
                }
            }
        }

        private void btnQtdeEntidades_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnQtdeEntidades_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnQtdeEntidades_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este software possui " + btnQtdeEntidades.Text + " Empresas/Entidades cadastradas.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timerEntidade_Tick(object sender, EventArgs e)
        {
            if (btnQtdeEntidades.ForeColor == Color.Black)
            {
                btnQtdeEntidades.ForeColor = Color.Red;
            }
            else
            {
                btnQtdeEntidades.ForeColor = Color.Black;
            }
        }

        private void lblTelzap_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://wa.me/5575982716595?text=Ol%C3%A1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão toolStripMenuItem1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão toolStripMenuItem1.");
                }
            }
        }

        private void lblTelzap_MouseLeave(object sender, EventArgs e)
        {
            lblTelzap.ForeColor = Color.Black;
            lblTelzap.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
            this.Cursor = Cursors.Default;

        }

        private void lblTelzap_MouseMove(object sender, MouseEventArgs e)
        {
            lblTelzap.ForeColor = Color.Blue;
            lblTelzap.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);
            this.Cursor = Cursors.Hand;
        }
    }
}
