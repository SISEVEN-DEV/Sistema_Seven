using DAL;
using System;

namespace BLL
{
    public class bllSMS
    {
        public static bool _FrmUtilEnviarSMS_Ativo;

        public static string _Destinatario_SMS;

        public static void Salvar(string porta, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (SMS SMS = new SMS())
                {
                    SMS.Porta = porta.Insert(porta.Length, "'").Insert(0, "'");
                    //
                    SMS.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Salvar_Config_SMS(SMS);
                }
            }
        }

        public static void Alterar(string porta, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (SMS SMS = new SMS())
                {
                    SMS.Porta = porta.Insert(porta.Length, "'").Insert(0, "'");
                    //
                    SMS.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Alterar_Config_SMS(SMS);
                }
            }
        }

        public static string Sel_Porta_SMS(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (SMS SMS = new SMS())
                {
                    SMS.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Porta_SMS(SMS);
                }
            }
        }



    }
}
