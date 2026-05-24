using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllIBPT
    {
        public static DataTable Sel_IBPT_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (IBPT NCM = new IBPT())
                {
                    if (pesquisar.Contains("%"))
                    {
                        NCM.Pesquisar = pesquisar;
                        return con.Sel_IBPT_Descricao_Like(NCM);
                    }
                    else
                    {
                        NCM.Pesquisar = pesquisar;
                        return con.Sel_IBPT_Descricao(NCM);
                    }
                }
            }
        }

        public static DataTable Sel_IBPT_Servico_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (IBPT NCM = new IBPT())
                {
                    if (pesquisar.Contains("%"))
                    {
                        NCM.Pesquisar = pesquisar;
                        return con.Sel_IBPT_Descricao_Servico_Like(NCM);
                    }
                    else
                    {
                        NCM.Pesquisar = pesquisar;
                        return con.Sel_IBPT_Servico_Descricao(NCM);
                    }
                }
            }
        }

        public static DataTable Sel_IBPT_NCM(string ncm, string excecao)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlNCM;
                string SqlExcecao;
                //
                if (ncm == null || ncm == "")
                {
                    return null;
                }
                else
                {
                    SqlNCM = "WHERE ncm=" + ncm;
                }
                //
                if (excecao == null || excecao == "")
                {
                    SqlExcecao = "";
                }
                else
                {
                    SqlExcecao = " AND excecao=" + excecao;
                }
                //
                return con.Sel_IBPT_NCM(SqlNCM, SqlExcecao);
            }
        }

        public static DataTable Sel_IBPT_Servico(string ncm)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlNCM;
                //
                if (ncm == null || ncm == "")
                {
                    return null;
                }
                else
                {
                    SqlNCM = "WHERE ncm=" + ncm;
                }
                //
                return con.Sel_IBPT_Servico(SqlNCM);
            }
        }

        public static DataTable Sel_IBPT_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                using (IBPT NCM = new IBPT())
                {
                    return con.Sel_IBPT_Todos();
                }
            }
        }

        public static DataTable Sel_IBPT_Servico_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                using (IBPT NCM = new IBPT())
                {
                    return con.Sel_IBPT_Servico_Todos();
                }
            }
        }
    }
}
