using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllEnviarEmail
    {
        public static bool FrmUtilEnviarEmail_Ativo;

        public static string _Cliente_PesqCliente_Tabela;

        public static string _Senha;

        public static void EnviarEmail(string para, string assunto, string mensagem, string anexo, string qtde, string nome)
        {

        }

        public static void Salvar_Config_Email_Enviar(string smtp_hotmail_outlook, string porta_hotmail_outlook, string smtp_gmail, string porta_gmail, string smtp_yahoo, string porta_yahoo, string prioridade, bool habilitar_ssl, bool html)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (DAL.EnviarEmail Email = new EnviarEmail())
                {
                    if (smtp_hotmail_outlook == "")
                    {
                        Email.Smtp_Hotmail_Outlook = "null";
                    }
                    else
                    {
                        Email.Smtp_Hotmail_Outlook = smtp_hotmail_outlook.Insert(smtp_hotmail_outlook.Length, "'").Insert(0, "'");
                    }
                    //
                    if (porta_hotmail_outlook == "")
                    {
                        Email.Porta_Hotmail_Outlook = 0;
                    }
                    else
                    {
                        Email.Porta_Hotmail_Outlook = Convert.ToInt32(porta_hotmail_outlook);
                    }
                    //
                    if (smtp_gmail == "")
                    {
                        Email.Smtp_Gmail = "null";
                    }
                    else
                    {
                        Email.Smtp_Gmail = smtp_gmail.Insert(smtp_gmail.Length, "'").Insert(0, "'");
                    }
                    //
                    if (porta_gmail == "")
                    {
                        Email.Porta_Gmail = 0;
                    }
                    else
                    {
                        Email.Porta_Gmail = Convert.ToInt32(porta_gmail);
                    }
                    //
                    if (smtp_yahoo == "")
                    {
                        Email.Smtp_Yahoo = "null";
                    }
                    else
                    {
                        Email.Smtp_Yahoo = smtp_yahoo.Insert(smtp_yahoo.Length, "'").Insert(0, "'");
                    }
                    //
                    if (porta_yahoo == "")
                    {
                        Email.Porta_Yahoo = 0;
                    }
                    else
                    {
                        Email.Porta_Yahoo = Convert.ToInt32(porta_yahoo);
                    }
                    //
                    if (prioridade == "MÉDIA")
                    {
                        Email.Prioridade = "'MEDIA'";
                    }
                    else
                    {
                        Email.Prioridade = prioridade.Insert(prioridade.Length, "'").Insert(0, "'");
                    }
                    //
                    if (habilitar_ssl == true)
                    {
                        Email.SSL = 1;
                    }
                    else
                    {
                        Email.SSL = 0;
                    }
                    //
                    if (html == true)
                    {
                        Email.Html = 1;
                    }
                    else
                    {
                        Email.Html = 0;
                    }
                    con.Salvar_Config_Email_Enviar(Email);
                }
            }
        }

        public static void Alterar_Config_Email_Enviar(string smtp_hotmail_outlook, string porta_hotmail_outlook, string smtp_gmail, string porta_gmail, string smtp_yahoo, string porta_yahoo, string prioridade, bool habilitar_ssl, bool html)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (DAL.EnviarEmail Email = new EnviarEmail())
                {
                    if (smtp_hotmail_outlook == "")
                    {
                        Email.Smtp_Hotmail_Outlook = "null";
                    }
                    else
                    {
                        Email.Smtp_Hotmail_Outlook = smtp_hotmail_outlook.Insert(smtp_hotmail_outlook.Length, "'").Insert(0, "'");
                    }
                    //
                    if (porta_hotmail_outlook == "")
                    {
                        Email.Porta_Hotmail_Outlook = 0;
                    }
                    else
                    {
                        Email.Porta_Hotmail_Outlook = Convert.ToInt32(porta_hotmail_outlook);
                    }
                    //
                    if (smtp_gmail == "")
                    {
                        Email.Smtp_Gmail = "null";
                    }
                    else
                    {
                        Email.Smtp_Gmail = smtp_gmail.Insert(smtp_gmail.Length, "'").Insert(0, "'");
                    }
                    //
                    if (porta_gmail == "")
                    {
                        Email.Porta_Gmail = 0;
                    }
                    else
                    {
                        Email.Porta_Gmail = Convert.ToInt32(porta_gmail);
                    }
                    //
                    if (smtp_yahoo == "")
                    {
                        Email.Smtp_Yahoo = "null";
                    }
                    else
                    {
                        Email.Smtp_Yahoo = smtp_yahoo.Insert(smtp_yahoo.Length, "'").Insert(0, "'");
                    }
                    //
                    if (porta_yahoo == "")
                    {
                        Email.Porta_Yahoo = 0;
                    }
                    else
                    {
                        Email.Porta_Yahoo = Convert.ToInt32(porta_yahoo);
                    }
                    //
                    if (prioridade == "MÉDIA")
                    {
                        Email.Prioridade = "'MEDIA'";
                    }
                    else
                    {
                        Email.Prioridade = prioridade.Insert(prioridade.Length, "'").Insert(0, "'");
                    }
                    //
                    if (habilitar_ssl == true)
                    {
                        Email.SSL = 1;
                    }
                    else
                    {
                        Email.SSL = 0;
                    }
                    //
                    if (html == true)
                    {
                        Email.Html = 1;
                    }
                    else
                    {
                        Email.Html = 0;
                    }
                    con.Alterar_Config_Email_Enviar(Email);
                }
            }
        }

        public static DataTable Sel_Tabela_Email_Configuracoes()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Tabela_Email_Configuracoes();
            }
        }

        public static string Sel_Smtp_Hotmail_Outlook()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Smtp_Hotmail_Outlook();
            }
        }

        public static int Sel_Porta_Hotmail_Outlook()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Porta_Hotmail_Outlook();
            }
        }

        public static int Sel_Porta_Gmail()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Porta_Gmail();
            }
        }

        public static int Sel_Porta_Yahoo()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Porta_Yahoo();
            }
        }

        public static string Sel_Smtp_Gmail()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Smtp_Gmail();
            }
        }

        public static string Sel_Smtp_Yahoo_Logo()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Smtp_Yahoo();
            }
        }

        public static bool Sel_SSL_Email()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                if (con.Sel_SSL_Email() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string Sel_Prioridade_Email()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Prioridade_Email();
            }
        }

        public static bool Sel_Html_Email()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                if (con.Sel_Html_Email() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
