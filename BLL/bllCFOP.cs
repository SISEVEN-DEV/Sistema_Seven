using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllCFOP
    {
        public static bool _FrmCadCFOP_Ativo;
        public static string _Cod_CFOP_Cadastro;
        public static void Salvar(string descricao, string cod_cfop, string finalidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    if (descricao == null || descricao == "")
                    {
                        Cfop.Descricao = "null";
                    }
                    else
                    {
                        Cfop.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    }
                    //
                    Cfop.Cod_CFOP = Convert.ToInt16(cod_cfop);
                    //
                    Cfop.Finalidade = finalidade.Insert(finalidade.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_CFOP(Cfop);
                }
            }
        }

        public static void Alterar(string codigo_cfop, string descricao, string finalidade, string cofigo_cfop_ant)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Cod_CFOP = Convert.ToInt16(codigo_cfop);
                    //
                    if (descricao == null || descricao == "")
                    {
                        Cfop.Descricao = "null";
                    }
                    else
                    {
                        Cfop.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    }
                    //
                    Cfop.Finalidade = finalidade.Insert(finalidade.Length, "'").Insert(0, "'");
                    //
                    Cfop.Pesquisar = cofigo_cfop_ant.Insert(cofigo_cfop_ant.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_CFOP(Cfop);
                }
            }
        }

        public static bool Sel_CFOP_DFe_Ver(string cod_cfop)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Cod_CFOP = Convert.ToInt16(cod_cfop);
                    //
                    return con.Sel_CFOP_DFe_Ver(Cfop);
                }
            }
        }

        public static bool Val_CFOP_Codigo_CFOP(string cod_cfop)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Cod_CFOP = Convert.ToInt16(cod_cfop);
                    return con.Val_CFOP_Codigo_CFOP(Cfop);
                }
            }
        }

        public static bool Val_CFOP_Descricao_Alt(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Cod_CFOP = Convert.ToInt16(codigo);
                    Cfop.Descricao = descricao;
                    if (con.Val_CFOP_Descricao_Alt(Cfop) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_CFOP_Descricao_Alt(Cfop) == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public static bool Val_CFOP_Descricao(string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Descricao = descricao;
                    return con.Val_CFOP_Descricao(Cfop);
                }
            }
        }

        public static DataTable Sel_CFOP_A_Alt(string codigo_cfop)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Cod_CFOP = Convert.ToInt16(codigo_cfop);
                    return con.Sel_CFOP_A_Alt(Cfop);
                }
            }
        }

        public static DataTable Sel_CFOP_Finalidade(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Pesquisar = pesquisar;
                    return con.Sel_CFOP_Finalidade(Cfop);
                }
            }
        }

        public static DataTable Sel_CFOP_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Pesquisar = pesquisar;
                    return con.Sel_CFOP_Codigo_CFOP(Cfop);
                }
            }
        }

        public static DataTable Sel_CFOP_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_CFOP_Todos();
            }
        }

        public static bool Sel_CFOP_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Cod_CFOP = Convert.ToInt16(codigo);
                    return con.Sel_CFOP_Ainda_Existe(Cfop);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Cod_CFOP = Convert.ToInt16(codigo);
                    con.Excluir_CFOP(Cfop);
                }
            }
        }

        public static DataTable Sel_CFOP_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Cfop.Pesquisar = pesquisar;
                        return con.Sel_CFOP_Descricao_Like(Cfop);
                    }
                    else
                    {
                        Cfop.Pesquisar = pesquisar;
                        return con.Sel_CFOP_Descricao(Cfop);
                    }
                }
            }
        }
    }
}
