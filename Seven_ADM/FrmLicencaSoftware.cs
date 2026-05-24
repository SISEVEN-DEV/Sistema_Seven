using BLL;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmLicencaSoftware : Form
    {
        public FrmLicencaSoftware(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        byte _Formulario;
        int tentativa = 4;

        private void FrmAddEmpresaBanco_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLicencaSoftware iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLicencaSoftware iniciado.");
                }
                //
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null & bllLicenca.Sel_Dados_Licenca() == false)
                {
                    lblInserir.Text = "Período de Avaliação";
                    //
                    lblChaveSistema.Text = "O período de avaliação do sistema é de: (7 dias)\nClique no botão para iniciar.";
                    lblSuporte.Visible = false;
                    //
                    lblChave.Visible = false;
                    txtChave.Visible = false;
                    //
                    btnIniciarAvaliacao.Select();
                    btnIniciarAvaliacao.Visible = true;
                    btnAplicar.Visible = false;
                    lblPonto.Visible = false;
                    pcibWhats.Visible = false;
                }
                else
                {
                    lblInserir.Text = "Inserir a chave do Sistema";
                    //
                    lblChaveSistema.Text = "A chave do sistema pode estar no seu whatsapp ou \ne-mail para mais informações contate o";
                    lblSuporte.Visible = true;
                    //
                    lblChave.Visible = true;
                    txtChave.Visible = true;
                    //
                    txtChave.Enabled = true;
                    txtChave.Select();
                    //
                    btnIniciarAvaliacao.Visible = false;
                    btnAplicar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLicencaSoftware.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLicencaSoftware.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmLicencaSoftware_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLicencaSoftware foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLicencaSoftware foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmLicencaSoftware.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmLicencaSoftware.");
                }
            }
        }

        private void txtChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAplicar.Select();
            }
        }

        private void FrmLicencaSoftware_KeyUp(object sender, KeyEventArgs e)
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

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAplicar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAplicar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblSuporte_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblSuporte_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                string ultchave;
                if (bllLicenca.Verificar_Data_Licenca() != null)
                {
                    DataRow dr = bllLicenca.Verificar_Data_Licenca().Rows[0];
                    //
                    ultchave = dr["chave"].ToString();
                }
                else
                {
                    ultchave = "";
                }
                //
                if (txtChave.Text.Trim() == "")
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Chave ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtChave.Select();
                }
                else if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() == null)
                {
                    MessageBox.Show("[ CPF/CNPJ ] da Empresa não encontrado.\nÉ necessário inserir as informações da empresa para aplicar a chave.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtChave.Select();
                }
                else if (ultchave == txtChave.Text)
                {
                    MessageBox.Show("A chave informada já foi informada anteriormente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtChave.Select();
                }
                else
                {
                    string chave;
                    //
                    if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Length == 14)
                    {
                        if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "0" || bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "2" || bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "4" || bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "6" || bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "8")
                        {
                            decimal valor = Convert.ToDecimal(DateTime.Now.Day) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(2, 1));
                            //
                            decimal valor2 = Convert.ToDecimal(DateTime.Now.Month) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(4, 1));
                            //
                            decimal valor3 = Convert.ToDecimal(DateTime.Now.Year) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(6, 1)); ;
                            //
                            decimal valor4 = Convert.ToDecimal(DateTime.Now.Day) + Convert.ToDecimal(DateTime.Now.Month) + Convert.ToDecimal(DateTime.Now.Year);
                            //
                            chave = bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) + valor.ToString() + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(7, 1) + valor2.ToString() + valor3.ToString() + valor4.ToString();
                            //
                            if (chave == txtChave.Text)
                            {
                                bllLicenca.Salvar(DateTime.Now.ToShortDateString(), txtChave.Text.Trim());
                                //
                                MessageBox.Show("Chave aplicada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                if (tentativa == 0)
                                {

                                    MessageBox.Show("A Chave informada é inválida, quantidade de tentativas esgotadas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    if (_Formulario == 0)
                                    {
                                        Application.Exit();
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.Abort;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("A Chave informada é inválida, tente novamente.\n\nResta(m) apenas [ " + tentativa + " ] tentativa(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    tentativa = tentativa - 1;
                                    txtChave.Text = null;
                                    txtChave.Select();
                                }
                            }
                        }
                        else
                        {
                            decimal valor = Convert.ToDecimal(DateTime.Now.Day) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(2, 1));
                            //
                            decimal valor2 = Convert.ToDecimal(DateTime.Now.Month) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(4, 1));
                            //
                            decimal valor3 = Convert.ToDecimal(DateTime.Now.Year) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(6, 1)); ;
                            //
                            decimal valor4 = Convert.ToDecimal(DateTime.Now.Day) + Convert.ToDecimal(DateTime.Now.Month) + Convert.ToDecimal(DateTime.Now.Year);
                            //
                            chave = bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(7, 1) + valor.ToString() + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) + valor2.ToString() + valor3.ToString() + valor4.ToString();
                            //
                            if (chave == txtChave.Text)
                            {
                                bllLicenca.Salvar(DateTime.Now.ToShortDateString(), txtChave.Text.Trim());
                                //
                                MessageBox.Show("Chave aplicada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                if (tentativa == 0)
                                {
                                    MessageBox.Show("A Chave informada é inválida, quantidade de tentativas esgotadas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    if (_Formulario == 0)
                                    {
                                        Application.Exit();
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.Abort;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("A Chave informada é inválida, tente novamente.\n\nResta(m) apenas [ " + tentativa + " ] tentativa(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    tentativa = tentativa - 1;
                                    txtChave.Text = null;
                                    txtChave.Select();
                                }
                            }
                        }
                    }
                    else if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Length == 11)
                    {
                        if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "0" || bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "2" || bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "4" || bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "6" || bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "8")
                        {
                            decimal valor = Convert.ToDecimal(DateTime.Now.Day) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(2, 1));
                            //
                            decimal valor2 = Convert.ToDecimal(DateTime.Now.Month) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(4, 1));
                            //
                            decimal valor3 = Convert.ToDecimal(DateTime.Now.Year) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(6, 1)); ;
                            //
                            decimal valor4 = Convert.ToDecimal(DateTime.Now.Day) + Convert.ToDecimal(DateTime.Now.Month) + Convert.ToDecimal(DateTime.Now.Year);
                            //
                            chave = bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) + valor.ToString() + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(7, 1) + valor2.ToString() + valor3.ToString() + valor4.ToString();
                            //
                            if (chave == txtChave.Text)
                            {
                                bllLicenca.Salvar(DateTime.Now.ToShortDateString(), txtChave.Text.Trim());
                                //
                                MessageBox.Show("Chave aplicada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                if (tentativa == 0)
                                {
                                    MessageBox.Show("A Chave informada é inválida, quantidade de tentativas esgotadas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    if (_Formulario == 0)
                                    {
                                        Application.Exit();
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.Abort;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("A Chave informada é inválida, tente novamente.\n\nResta(m) apenas [ " + tentativa + " ] tentativa(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    tentativa = tentativa - 1;
                                    txtChave.Text = null;
                                    txtChave.Select();
                                }
                            }
                        }
                        else
                        {
                            decimal valor = Convert.ToDecimal(DateTime.Now.Day) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(2, 1));
                            //
                            decimal valor2 = Convert.ToDecimal(DateTime.Now.Month) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(4, 1));
                            //
                            decimal valor3 = Convert.ToDecimal(DateTime.Now.Year) * Convert.ToDecimal(bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(6, 1)); ;
                            //
                            decimal valor4 = Convert.ToDecimal(DateTime.Now.Day) + Convert.ToDecimal(DateTime.Now.Month) + Convert.ToDecimal(DateTime.Now.Year);
                            //
                            chave = bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(7, 1) + valor.ToString() + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) + valor2.ToString() + valor3.ToString() + valor4.ToString();
                            //
                            if (chave == txtChave.Text)
                            {
                                bllLicenca.Salvar(DateTime.Now.ToShortDateString(), txtChave.Text.Trim());
                                //
                                MessageBox.Show("Chave aplicada com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                if (tentativa == 0)
                                {
                                    MessageBox.Show("A Chave informada é inválida, quantidade de tentativas esgotadas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    if (_Formulario == 0)
                                    {
                                        Application.Exit();
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.Abort;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("A Chave informada é inválida, tente novamente.\n\nResta(m) apenas [ " + tentativa + " ] tentativa(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                    tentativa = tentativa - 1;
                                    txtChave.Text = null;
                                    txtChave.Select();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("CPF/CNPJ informado está incorreto verifique e tente novamente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAplicar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAplicar.");
                }
                txtChave.Text = null;
            }
        }

        private void btnIniciarAvaliacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIniciarAvaliacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnIniciarAvaliacao_Click(object sender, EventArgs e)
        {
            try
            {
                bllLicenca.Salvar_Periodo_Avaliacao(DateTime.Now.ToShortDateString(), "AVALIACAO");
                //
                MessageBox.Show("Período de avaliação de [ 7 dias ] iniciado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIniciarAvaliacao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIniciarAvaliacao.");
                }
                txtChave.Text = null;
            }
        }

        private void lblSuporte_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Nosso número de suporte é: (75) 9 8271-6595\n\nNosso e-mail é: 7sistema.suporte@gmail.com\n\n\n\nDeseja entrar em contato pelo whatsapp?", "Suporte Técnico", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.Yes)
                {
                    Process.Start("https://wa.me/5575982716595?text=Ol%C3%A1");
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
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

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Nosso número de suporte é: (75) 9 8271-6595\n\nNosso e-mail é: 7sistema.suporte@gmail.com\n\n\n\nDeseja entrar em contato pelo whatsapp?", "Suporte Técnico", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.Yes)
                {
                    Process.Start("https://wa.me/5575982716595?text=Ol%C3%A1");
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
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
    }
}
