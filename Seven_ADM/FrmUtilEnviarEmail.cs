using BLL;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmUtilEnviarEmail : Form
    {
        public FrmUtilEnviarEmail(byte formulario, string cod_pdv_computador, string usuario, string anexos, string mensagem, string assunto, string email_cliente_consumidor)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Usuario = usuario;
            _Anexos = anexos;
            _Mensagem = mensagem;
            _Assunto = assunto;
            _Email_Cliente_Consumidor = email_cliente_consumidor;
        }

        private string _Cod_PDV_Computador;
        private string _Usuario;
        private string _Anexos;
        private string _Mensagem;
        private byte _Formulario;
        private string _Assunto;
        private string _Email_Cliente_Consumidor;

        private void FrmUtilEnviarEmail_Load(object sender, EventArgs e)
        {
            try
            {
                bllEnviarEmail.FrmUtilEnviarEmail_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilEnviarEmail iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilEnviarEmail iniciado.");
                }
                //
                DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                //
                txtMeuEmail.Text = dr["email_empresa"].ToString();
                //
                txtNome.Text = dr["nome"].ToString();
                //
                txtAnexo.Text = _Anexos;
                //
                if (_Anexos != null)
                {
                    string[] itens = txtAnexo.Text.Split(';');
                    //
                    lblQtde.Text = "Arquivos: " + (itens.Length - 1).ToString();
                    btnLimparAnexo.Enabled = true;
                }
                txtMsg.Text = _Mensagem;
                //
                txtAssunto.Text = _Assunto;
                //
                txtPara.Text = _Email_Cliente_Consumidor;
                //
                if (_Formulario == 1)
                {
                    if (txtPara.Text == "")
                    {
                        MessageBox.Show("O e-mail do contador não está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtMeuEmail.Select();
                    }
                    else
                    {
                        btnEnviar_Click(sender, e);

                    }
                }
                else
                {
                    txtMeuEmail.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmUtilEnviarEmail.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmUtilEnviarEmail.");
                }
            }
        }

        private void txtPara_Enter(object sender, EventArgs e)
        {
            txtPara.BackColor = Color.LightBlue;
        }

        private void txtPara_Leave(object sender, EventArgs e)
        {
            if (!txtPara.Text.Contains("@") && txtPara.Text != "")
            {
                MessageBox.Show("Endereço de e-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtPara.Text = null;
            }
            txtPara.BackColor = Color.White;
        }

        private void txtPara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAssunto.Select();
            }
        }

        private void txtAssunto_Enter(object sender, EventArgs e)
        {
            txtAssunto.BackColor = Color.LightBlue;
        }

        private void txtAssunto_Leave(object sender, EventArgs e)
        {
            txtAssunto.BackColor = Color.White;
        }

        private void txtAssunto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMsg.Select();
            }
        }

        private void btnAnexar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAnexar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnLimparAnexo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnLimparAnexo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEnviar_MouseLeave(object sender, EventArgs e)
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

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMeuEmail.Text == "" || txtNome.Text == "" || txtPara.Text == "" || txtMsg.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Meu e-mail ], [ Meu nome ], [ Para (Destinatário ] e\n[ Mensagem ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtMeuEmail.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Confirmar envio do e-mail?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        if (txtAssunto.Text == "")
                        {
                            DialogResult = MessageBox.Show("O campo [ Assunto ] não foi preenchido, deseja enviar esta mensagem sem assunto?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.No)
                            {
                                this.DialogResult = DialogResult.None;
                                return;
                            }
                        }
                        //
                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                        //
                        if (dr["senha_email_empresa"].ToString() == "" || txtMeuEmail.Text != dr["email_empresa"].ToString())
                        {
                            using (FrmSenhaEmail Senha = new FrmSenhaEmail())
                            {
                                if (Senha.ShowDialog() == DialogResult.OK)
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            bllEnviarEmail._Senha = dr["senha_email_empresa"].ToString();
                        }
                        //
                        pgbProgresso.Visible = true;
                        lblProgresso.Visible = true;
                        bckwIndeterminado.RunWorkerAsync();
                        pgbProgresso.MarqueeAnimationSpeed = 2;
                        this.Cursor = Cursors.WaitCursor;
                        grbBox1.Enabled = false;
                        grbBox2.Enabled = false;
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
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnLogar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnLogar.");
                }
            }
        }

        private void txtMeuEmail_Enter(object sender, EventArgs e)
        {
            txtMeuEmail.BackColor = Color.LightBlue;
        }

        private void txtMeuEmail_Leave(object sender, EventArgs e)
        {
            if (txtMeuEmail.Text.Contains("'") || txtMeuEmail.Text.Contains(";") || txtMeuEmail.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtMeuEmail.Text = null;
                txtMeuEmail.Select();
            }
            else if (!txtMeuEmail.Text.Contains("@") && txtMeuEmail.Text != "")
            {
                MessageBox.Show("Endereço de e-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtMeuEmail.Text = null;
                txtMeuEmail.Select();
            }
            //
            if (txtMeuEmail.Text != "")
            {
                string email = txtMeuEmail.Text.ToLower();
                if (!email.Contains("@hotmail") & !email.Contains("@outlook") & !email.Contains("@gmail"))
                {
                    MessageBox.Show("Endereço de e-mail inválido ou sem suporte para envio neste aplicativo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtMeuEmail.Text = null;
                }
            }
            //
            txtMeuEmail.BackColor = Color.White;
        }

        private void txtMeuEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNome.Select();
            }
        }

        private void FrmUtilEnviarEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnexar_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    file.InitialDirectory = @"C:\";
                    file.Multiselect = true;
                    file.Multiselect = false;

                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        btnLimparAnexo.Enabled = true;
                        if (txtAnexo.Text == null || txtAnexo.Text == "")
                        {
                            txtAnexo.Text = file.FileName.Insert(file.FileName.Length, ";");
                            btnLimparAnexo.Enabled = true;
                            string[] separadordelinha = txtAnexo.Text.Split(';');
                            lblQtde.Text = "Arquivos: " + (separadordelinha.Length - 1).ToString();
                        }
                        else
                        {
                            txtAnexo.Text = txtAnexo.Text + "\n" + file.FileName.Insert(file.FileName.Length, ";");
                            string[] separadordelinha = txtAnexo.Text.Split(';');
                            lblQtde.Text = "Arquivos: " + (separadordelinha.Length - 1).ToString();
                        }
                        btnAnexar.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnAnexar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnAnexar.");
                }
                btnAnexar.Select();
            }
        }

        private void btnLimparAnexo_Click(object sender, EventArgs e)
        {
            txtAnexo.Text = null;
            btnLimparAnexo.Enabled = false;
            lblQtde.Text = "Arquivos: 0";
        }

        private void pcibAnexo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Meu e-mail: E-mail remetente que irá enviar uma mensagem.\n2 - Meu nome: Nome do remetente que irá enviar a mensagem.\n3 - Para (Destinatário): Quem irá receber a mensagem.\n4 - Assunto: Assunto do e-mail.\n5 - Anexar um arquivo: Permite adicionar arquivos deste computador na mensagem.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void pcibAnexo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibAnexo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmUtilEnviarEmail_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllEnviarEmail.FrmUtilEnviarEmail_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilEnviarEmail foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilEnviarEmail foi finalizado.");
                }
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmUtilEnviarEmail.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmUtilEnviarEmail.");
                }
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPara.Select();
            }
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.LightBlue;
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.White;
        }

        private void btnProcurarCliente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarCliente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            using (FrmPesqCliente Clie = new FrmPesqCliente(8, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] items = txtPara.Text.Split(';');
                        //
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (items[i] == bllEnviarEmail._Cliente_PesqCliente_Tabela)
                            {
                                MessageBox.Show("O Email já foi informado anteriormente \nno campo [ Para(Destinatário) ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bllEnviarEmail._Cliente_PesqCliente_Tabela = null;
                                return;
                            }
                        }
                        //
                        txtPara.Text = txtPara.Text + bllEnviarEmail._Cliente_PesqCliente_Tabela + ";";
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = null;
                        txtPara.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        txtMeuEmail.Text = null;
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = null;
                    }
                }
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                //
                pgbProgresso.Value = 0;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnSair.Enabled = true;
                bllEnviarEmail._Senha = null;
            }
            else
            {
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnSair.Enabled = true;
                bllEnviarEmail._Senha = null;
                //
                try
                {
                    MessageBox.Show("O E-mail foi enviado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    //
                    if (_Formulario == 0)
                    {
                        bllRegistroAtividades.Salvar("ENVIO DE E-MAIL", "EMAIL", "0", _Usuario, _Cod_PDV_Computador);
                    }
                    else if (_Formulario == 1)
                    {
                        bllRegistroAtividades.Salvar("ENVIO DE E-MAIL DE UM DFE", "EMAIL", "0", _Usuario, _Cod_PDV_Computador);
                    }
                    else if (_Formulario == 2)
                    {
                        bllRegistroAtividades.Salvar("ENVIO DE E-MAIL DE UM ORÇAMENTO", "EMAIL", "0", _Usuario, _Cod_PDV_Computador);
                    }
                    else if (_Formulario == 3)
                    {
                        bllRegistroAtividades.Salvar("ENVIO DE E-MAIL DE UM ANIVERSARIANTE", "EMAIL", "0", _Usuario, _Cod_PDV_Computador);
                    }
                    else if (_Formulario == 4)
                    {
                        bllRegistroAtividades.Salvar("ENVIO DE E-MAIL DE UMA VENDA", "EMAIL", "0", _Usuario, _Cod_PDV_Computador);
                    }
                    else if (_Formulario == 5)
                    {
                        bllRegistroAtividades.Salvar("ENVIO DE E-MAIL DE UM DOCUMENTO", "EMAIL", "0", _Usuario, _Cod_PDV_Computador);
                    }
                    //
                    if (_Formulario == 0)
                    {
                        DialogResult = MessageBox.Show("Deseja manter os dados do ultimo e-mail?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.No)
                        {
                            this.DialogResult = DialogResult.None;
                            DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                            //
                            txtMeuEmail.Text = dr["email_empresa"].ToString();
                            //
                            txtNome.Text = dr["nome"].ToString();
                            //
                            txtPara.Text = null;
                            //
                            txtAssunto.Text = null;
                            //
                            txtAnexo.Text = null;
                            //
                            txtMsg.Text = null;
                            //
                            btnLimparAnexo_Click(sender, e);
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Abort;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    //
                    pgbProgresso.MarqueeAnimationSpeed = 0;
                    pgbProgresso.Value = 100;
                    this.Cursor = Cursors.Default;
                    pgbProgresso.Visible = false;
                    lblProgresso.Visible = false;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnSair.Enabled = true;
                    bllEnviarEmail._Senha = null;
                }
            }
        }

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            int porta = Convert.ToInt32(bllConfiguracaoSistema.Sel_Porta_Email());

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(txtMeuEmail.Text.Trim(), txtNome.Text.Trim());

            foreach (var enderecos in txtPara.Text.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mailMessage.To.Add(enderecos);
            }
            //
            mailMessage.Subject = txtAssunto.Text.Trim();
            //
            mailMessage.IsBodyHtml = true;
            string mensagem;
            string quote = "\"";
            mensagem = txtMsg.Text;
            mensagem = mensagem + Environment.NewLine + Environment.NewLine + "<br><br><b>Enviado Pelo App Sistema SEVEN</b><br><a href=" + quote + "https://www.siseven.com" + quote + ">www.siseven.com.br</a>";
            mailMessage.Body = mensagem;
            //
            if (txtAnexo.Text != "")
            {
                string[] separadordelinha = txtAnexo.Text.Split(';');
                //
                for (byte row = 0; row < Convert.ToByte(separadordelinha.Length - 1); row++)
                {
                    Attachment anexar = new Attachment(separadordelinha[row].Trim());
                    mailMessage.Attachments.Add(anexar);
                }
            }
            //
            mailMessage.Priority = MailPriority.High;
            //}
            string email = txtMeuEmail.Text.ToLower();
            //
            if (email.Contains("@hotmail") || email.Contains("@outlook"))
            {
                SmtpClient smtpCliente = new SmtpClient("smtp.office365.com", porta);
                smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpCliente.UseDefaultCredentials = false;
                smtpCliente.Credentials = new NetworkCredential(email, bllEnviarEmail._Senha);
                smtpCliente.EnableSsl = true;
                smtpCliente.Send(mailMessage);
            }
            else if (email.Contains("@gmail"))
            {
                SmtpClient smtpCliente = new SmtpClient("smtp.gmail.com", porta);
                smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpCliente.UseDefaultCredentials = false;
                smtpCliente.EnableSsl = true;
                smtpCliente.Credentials = new NetworkCredential(txtMeuEmail.Text.Trim(), bllEnviarEmail._Senha);
                smtpCliente.Send(mailMessage);
            }
            else
            {
                MessageBox.Show("Endereço de e-mail inválido ou sem suporte para envio neste aplicativo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            //
            mailMessage.Dispose();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisarForn_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisarForn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            using (FrmPesqFuncionario Func = new FrmPesqFuncionario(5, _Usuario, _Cod_PDV_Computador))
            {
                if (Func.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] items = txtPara.Text.Split(';');
                        //
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (items[i] == bllEnviarEmail._Cliente_PesqCliente_Tabela)
                            {
                                MessageBox.Show("O Email já foi informado anteriormente \nno campo [ Para(Destinatário) ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bllEnviarEmail._Cliente_PesqCliente_Tabela = null;
                                return;
                            }
                        }
                        //
                        txtPara.Text = txtPara.Text + bllEnviarEmail._Cliente_PesqCliente_Tabela + ";";
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = null;
                        txtPara.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFuncionario.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFuncionario.");
                        }
                        txtMeuEmail.Text = null;
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = null;
                    }
                }
            }
        }

        private void btnPesquisarForn_Click(object sender, EventArgs e)
        {
            using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(5, _Usuario, _Cod_PDV_Computador))
            {
                if (Forn.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] items = txtPara.Text.Split(';');
                        //
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (items[i] == bllEnviarEmail._Cliente_PesqCliente_Tabela)
                            {
                                MessageBox.Show("O Email já foi informado anteriormente \nno campo [ Para(Destinatário) ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bllEnviarEmail._Cliente_PesqCliente_Tabela = null;
                                return;
                            }
                        }
                        //
                        txtPara.Text = txtPara.Text + bllEnviarEmail._Cliente_PesqCliente_Tabela + ";";
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = null;
                        txtPara.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarForn.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarForn.");
                        }
                        txtMeuEmail.Text = null;
                        bllEnviarEmail._Cliente_PesqCliente_Tabela = null;
                    }
                }
            }
        }

        private void txtMsg_Enter(object sender, EventArgs e)
        {
            txtMsg.BackColor = Color.LightBlue;
        }

        private void txtMsg_Leave(object sender, EventArgs e)
        {
            txtMsg.BackColor = Color.White;
        }

        private void txtMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (bllEnviarEmail.Sel_Html_Email() == true)
            {
                if (e.KeyChar == 13)
                {
                    btnEnviar.Select();
                }
            }
            */
        }

        private void txtMsg_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + txtMsg.Text.Length + "/500";
        }
    }
}