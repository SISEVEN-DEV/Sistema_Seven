using _7_Sistema_Config;
using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema_SEVEN_Config
{
    public partial class FrmLocalizarBanco : Form
    {
        public FrmLocalizarBanco(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void btnEscolherLocal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEscolherLocal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnContinuar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnContinuar_MouseLeave(object sender, EventArgs e)
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

        private void FrmLocalizarBanco_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLocalizarBanco iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLocalizarBanco iniciado.");
                }
                //
                if (bllConexao._Tipo != "")
                {
                    cbbTipoConexao.Text = bllConexao._Tipo;
                }
                //
                if (bllConexao._Caminho != "")
                {
                    txtCaminhoBanco.Text = bllConexao._Caminho;
                }
                txtCaminhoBanco.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLocalizarBanco.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLocalizarBanco.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtCaminhoBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (btnEscolherLocal.Enabled == true)
                {
                    btnEscolherLocal.Select();
                }
                else
                {
                    btnContinuar.Select();
                }
            }
        }

        private void txtCaminhoBanco_Enter(object sender, EventArgs e)
        {
            txtCaminhoBanco.BackColor = Color.LightBlue;
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
            //
            if (txtCaminhoBanco.Text.Contains(";") || txtCaminhoBanco.Text.Contains("'") || txtCaminhoBanco.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCaminhoBanco.Text = null;
                txtCaminhoBanco.Select();
            }
            txtCaminhoBanco.BackColor = Color.White;
        }

        private void FrmLocalizarBanco_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmLocalizarBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLocalizarBanco foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLocalizarBanco foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmLocalizarBanco.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmLocalizarBanco.");
                }
            }
        }

        private void btnEscolherLocal_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Title = "Selecione um banco de dados";
                file.Filter = "Banco de dados no formato:(*.FDB)|*.FDB";
                file.InitialDirectory = @"C:\Sistema SEVEN\Bancos";
                file.Multiselect = false;


                if (file.ShowDialog() == DialogResult.OK)
                {
                    if (file.FileName.Length > 60)
                    {

                        MessageBox.Show("O caminho escolhido é muito longo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
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

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            txtCaminhoBanco.Select();
            btnContinuar.Select();
            if (txtCaminhoBanco.Text.Trim() == "" || cbbTipoConexao.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Tipo ] e [ Caminho ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtCaminhoBanco.Select();
            }
            else
            {
                try
                {
                    if (_Formulario == 0)
                    {
                        bllConexao.Sel_Conexao_Completa_Cadastro_Computador(txtCaminhoBanco.Text.Trim(), cbbTipoConexao.Text);
                        //
                        bllConexao._Tipo = cbbTipoConexao.Text;
                        //
                        bllConexao._Caminho = txtCaminhoBanco.Text;
                        //
                        using (FrmCadastroComputadores Cad = new FrmCadastroComputadores())
                        {
                            if (Cad.ShowDialog() == DialogResult.Abort)
                            {
                                this.DialogResult = DialogResult.Abort;
                            }
                        }
                    }
                    else if (_Formulario == 1)
                    {
                        bllConexao.Sel_Conexao_Completa_Cadastro_Computador(txtCaminhoBanco.Text.Trim(), cbbTipoConexao.Text);
                        //
                        bllConexao._Tipo = cbbTipoConexao.Text;
                        //
                        bllConexao._Caminho = txtCaminhoBanco.Text;
                        //
                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware())
                        {
                            if (Lic.ShowDialog() == DialogResult.Abort)
                            {
                                this.DialogResult = DialogResult.Abort;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnContinuar.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnContinuar.");
                    }
                }
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
                btnEscolherLocal.Enabled = true;
                //
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
                btnEscolherLocal.Enabled = false;
                //
                string[] items = txtCaminhoBanco.Text.Split(':');
                //
                if (items[0] == @"C" & txtCaminhoBanco.Text != "" & txtCaminhoBanco.Text.Contains(":"))
                {
                    txtCaminhoBanco.Text = null;
                    MessageBox.Show("É necessário informar o nome do computador Servidor para usar a conexão em rede.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
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

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Ex Local: C:\Sistema SEVEN\Banco\7.FDB" + Environment.NewLine + Environment.NewLine + @"Ex Rede: NomeDoComputadorNaRede:C:\Sistema SEVEN\Banco\7.FDB" + Environment.NewLine + Environment.NewLine + @"Ex Rede: 192.168.0.1:C:\Sistema SEVEN\Banco\7.FDB", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtNomeComputadorLocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCaminhoBanco.Select();
            }
        }
    }
}
