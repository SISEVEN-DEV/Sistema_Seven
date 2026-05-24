namespace BLL
{
    public class bllFeedback
    {
        public static bool _FrmContatoFeedBack_Ativo;

        public static void EnviarEmail(string mensagem, string anexo, string qtde, string nome, string cpf_cnpj, string ie_rg, string endereco, string numero, string bairro, string cidade, string uf)
        {
            /* string email = bllMinhaEmpresa.Sel_Email_Empresa();
             string senha = bllMinhaEmpresa.Sel_Senha_Email_Empresa();

             MailMessage mailMessage = new MailMessage();

             mailMessage.From = new MailAddress(email, nome);

             mailMessage.To.Add("7sistema.suporte@gmail.com");
             mailMessage.Subject = "Feedback Sistema SEVEN";
             mailMessage.IsBodyHtml = false;
             mailMessage.Body = mensagem + Environment.NewLine + Environment.NewLine + Environment.NewLine + "Nome/Razão Social: " + nome + Environment.NewLine + "CPF/CNPJ: " + cpf_cnpj + Environment.NewLine + "Inscrição Estadual/RG: " + ie_rg + Environment.NewLine + "Endereço: " + endereco + Environment.NewLine + "Bairro: " + bairro + Environment.NewLine + "Numero: " + numero + Environment.NewLine + "Cidade: " + cidade + Environment.NewLine + "UF: " + uf;

             if (qtde != "0")
             {
                 for (byte row = 0; row < Convert.ToByte(qtde); row++)
                 {
                     string[] separadordelinha = anexo.Split(';');
                     Attachment anexar = new Attachment(separadordelinha[row].Trim());
                     mailMessage.Attachments.Add(anexar);
                 }
             }

             if (email.Contains("@hotmail") || email.Contains("@outlook") || email.Contains("@Outlook") || email.Contains("@Hotmail"))
             {
                 SmtpClient smtpCliente = new SmtpClient(bllEnviarEmail.Sel_Smtp_Hotmail_Outlook(), bllEnviarEmail.Sel_Porta_Hotmail_Outlook());
                 smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                 smtpCliente.UseDefaultCredentials = false;
                 smtpCliente.EnableSsl = true;
                 smtpCliente.Credentials = new NetworkCredential(email, senha);
                 if (bllEnviarEmail.Sel_SSL_Email() == true)
                 {
                     smtpCliente.EnableSsl = true;
                 }
                 else
                 {
                     smtpCliente.EnableSsl = false;
                 }
                 smtpCliente.Send(mailMessage);                      
             }
             else if (email.Contains("@gmail") || email.Contains("@Gmail"))
             {
                 SmtpClient smtpCliente = new SmtpClient(bllEnviarEmail.Sel_Smtp_Gmail(), bllEnviarEmail.Sel_Porta_Gmail());
                 smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                 smtpCliente.UseDefaultCredentials = false;
                 smtpCliente.EnableSsl = true;
                 smtpCliente.Credentials = new NetworkCredential(email, senha);
                 if (bllEnviarEmail.Sel_SSL_Email() == true)
                 {
                     smtpCliente.EnableSsl = true;
                 }
                 else
                 {
                     smtpCliente.EnableSsl = false;
                 }
                 smtpCliente.Send(mailMessage);
            }
             else if (email.Contains("@Yahoo") || email.Contains("@yahoo"))
             {
                 SmtpClient smtpCliente = new SmtpClient(bllEnviarEmail.Sel_Smtp_Yahoo_Logo(), bllEnviarEmail.Sel_Porta_Yahoo());
                 smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                 smtpCliente.UseDefaultCredentials = false;
                 smtpCliente.EnableSsl = true;
                 smtpCliente.Credentials = new NetworkCredential(email, email);
                 if (bllEnviarEmail.Sel_SSL_Email() == true)
                 {
                     smtpCliente.EnableSsl = true;
                 }
                 else
                 {
                     smtpCliente.EnableSsl = false;
                 }

                 smtpCliente.Send(mailMessage);
             }
             */
        }
    }
}
