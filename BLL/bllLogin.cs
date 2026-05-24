using DAL;
using System.Diagnostics;


namespace BLL
{
    public class bllLogin
    {
        //remover
        public static bool _FrmLogin_Ativo;

        public static string LoginSelect(string usuario, string senha)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Login Login = new Login())
                {
                    Login.Nome = usuario;
                    Login.Senha = senha;
                    if (con.LoginSelect(Login) == null)
                    {
                        return null;
                    }
                    else
                    {
                        return con.LoginSelect(Login);
                    }
                }
            }
        }

        public static bool LoginSelectFuncao(string usuario, string senha, string funcao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Login Login = new Login())
                {
                    Login.Nome = usuario;
                    Login.Senha = senha;
                    //
                    string SqlFuncao = null;
                    //
                    if (funcao == "Excluir_Item")
                    {
                        SqlFuncao = " AND permitir_canc_exc_item_venda=1";
                    }
                    else if (funcao == "Realizar_Orcamento")
                    {
                        SqlFuncao = " AND realizar_orcamento=1";
                    }
                    else if (funcao == "Realizar_Devolucao")
                    {
                        SqlFuncao = " AND realizar_devolucao=1";
                    }
                    else if (funcao == "Capturar_Orcamento")
                    {
                        SqlFuncao = " AND capturar_orcamento=1";
                    }
                    else if (funcao == "Capturar_Devolucao")
                    {
                        SqlFuncao = " AND capturar_devolucao=1";
                    }
                    else if (funcao == "Permitir_Desc_Pag")
                    {
                        SqlFuncao = " AND permitir_desc_pag=1";
                    }
                    else if (funcao == "Permitir_Acresc_Pag")
                    {
                        SqlFuncao = " AND permitir_acresc_pag=1";
                    }
                    else if (funcao == "Permitir_Fin_PDV")
                    {
                        SqlFuncao = " AND permitir_fin_pdv=1";
                    }
                    else if (funcao == "Permitir_Alt_Prod_Item")
                    {
                        SqlFuncao = " AND permitir_alt_prod_item=1";
                    }
                    else if (funcao == "Permitir_Real_Conta_Receber")
                    {
                        SqlFuncao = " AND permitir_real_conta_receber=1";
                    }
                    else if (funcao == "Permitir_Real_Conta_Pagar")
                    {
                        SqlFuncao = " AND permitir_real_conta_pagar=1";
                    }
                    else if (funcao == "Permitir_Real_SangSup")
                    {
                        SqlFuncao = " AND permitir_real_sangsup=1";
                    }
                    else if (funcao == "Permitir_Abrir_Caixa")
                    {
                        SqlFuncao = " AND permitir_abrir_caixa=1";
                    }
                    else if (funcao == "Permitir_Fechar_Caixa")
                    {
                        SqlFuncao = " AND permitir_fechar_caixa=1";
                    }
                    else if (funcao == "Capturar_Venda")
                    {
                        SqlFuncao = " AND capturar_venda=1";
                    }
                    //
                    return con.LoginSelectFuncao(Login, SqlFuncao);
                }
            }
        }

        public static int VerificarProcesso(string nome)
        {
            int quantidade = 0;
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName == nome)
                {
                    quantidade = quantidade + 1;
                }
            }
            return quantidade;
        }
    }
}
