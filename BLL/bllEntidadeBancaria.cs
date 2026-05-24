using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllEntidadeBancaria
    {
        public static bool _FrmCadEntidadeBancaria_Ativo;

        public static void Alterar(string codigo, string descricao, string palavra_chave, string codigo_compe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo = Convert.ToInt16(codigo);
                    //
                    Ent.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Ent.Palavra_Chave = "null";
                    }
                    else
                    {
                        Ent.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //  
                    if (codigo_compe == "" || codigo_compe == null)
                    {
                        Ent.Codigo_Compe = 0;
                    }
                    else
                    {
                        Ent.Codigo_Compe = Convert.ToInt32(codigo_compe);
                    }
                    //
                    con.Alterar_Entidade_Bancaria(Ent);
                }
            }
        }

        public static bool Sel_Entidade_Bancaria_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Palavra_Chave = palavra_chave;
                    if (con.Sel_Entidade_Bancaria_Palavra_Chave_Alt(Ent) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Entidade_Bancaria_Palavra_Chave_Alt(Ent) == 0)
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

        public static bool Sel_Entidade_Bancaria_Codigo_Compe_Alt(string codigo, string codigo_compe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo_Compe = Convert.ToInt32(codigo_compe);
                    if (con.Sel_Entidade_Bancaria_Codigo_Compe_Alt(Ent) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Entidade_Bancaria_Codigo_Compe_Alt(Ent) == 0)
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

        public static bool Sel_Entidade_Bancaria_Palavra_Chave_Ver(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Palavra_Chave = palavra_chave;
                    return con.Sel_Entidade_Bancaria_Palavra_Chave_Ver(Ent);
                }
            }
        }

        public static bool Sel_Entidade_Bancaria_Codigo_Compe_Ver(string codigo_compe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo_Compe = Convert.ToInt32(codigo_compe);
                    return con.Sel_Entidade_Bancaria_Codigo_Compe_Ver(Ent);
                }
            }
        }

        public static void Alterar_Descricao_Conta_Pagar_Entidade_Bancaria(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo = Convert.ToInt16(codigo);
                    Ent.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_Conta_Pagar_Entidade_Bancaria(Ent);
                }
            }
        }

        public static void Alterar_Descricao_Forma_Pagamento_Entidade_Bancaria(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo = Convert.ToInt16(codigo);
                    Ent.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_Forma_Pagamento_Entidade_Bancaria(Ent);
                }
            }
        }

        public static void Salvar(string descricao, string palavra_chave, string codigo_compe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Ent.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Ent.Palavra_Chave = "null";
                    }
                    else
                    {
                        Ent.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //                
                    if (codigo_compe == "" || codigo_compe == null)
                    {
                        Ent.Codigo_Compe = 0;
                    }
                    else
                    {
                        Ent.Codigo_Compe = Convert.ToInt32(codigo_compe);
                    }
                    //
                    con.Salvar_Entidade_Bancaria(Ent);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Entidade_Bancaria(Ent);
                }
            }
        }

        public static DataTable Sel_Entidade_Bancaria_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Ent.Pesquisar = pesquisar;
                        return con.Sel_Entidade_Bancaria_Descricao_Like(Ent);
                    }
                    else
                    {
                        Ent.Pesquisar = pesquisar;
                        return con.Sel_Entidade_Bancaria_Descricao(Ent);
                    }
                }
            }
        }

        public static DataTable Sel_Entidade_Bancaria_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Pesquisar = pesquisar;
                    return con.Sel_Entidade_Bancaria_Codigo(Ent);
                }
            }
        }

        public static DataTable Sel_Entidade_Bancaria_Codigo_Compe(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Pesquisar = pesquisar;
                    return con.Sel_Entidade_Bancaria_Codigo_Compe(Ent);
                }
            }
        }

        public static DataTable Sel_Entidade_Bancaria_Palavra_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Pesquisar = pesquisar;
                    return con.Sel_Entidade_Bancaria_Palavra_Chave(Ent);
                }
            }
        }

        public static DataTable Sel_Entidade_Bancaria_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Entidade_Bancaria_Todos();
            }
        }

        public static bool Val_Entidade_Bancaria_Descricao_Alt(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo = Convert.ToInt16(codigo);
                    Ent.Descricao = descricao;
                    if (con.Val_Entidade_Bancaria_Descricao_Alt(Ent) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Entidade_Bancaria_Descricao_Alt(Ent) == 0)
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

        public static bool Val_Entidade_Bancaria_Descricao(string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Descricao = descricao;
                    return con.Val_Entidade_Bancaria_Descricao(Ent);
                }
            }
        }

        public static DataTable Sel_Entidade_Bancaria_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Entidade_Bancaria_A_Alt(Ent);
                }
            }
        }

        public static DataTable Sel_Entidade_Bancaria_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Entidade_Bancaria_A_Sal();
            }
        }

        public static void Excluir_Entidade_Bancaria_Conta_Pagar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Entidade_Bancaria_Conta_Pagar(Ent);
                }
            }
        }

        public static bool Sel_Entidade_Bancaria_Conta_Pagar_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Entidade_Bancaria_Conta_Pagar_Ver(Ent);
                }
            }
        }

        public static bool Sel_Entidade_Bancaria_Forma_Pagamento_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Entidade_Bancaria_Forma_Pagamento_Ver(Ent);
                }
            }
        }

        public static bool Sel_Entidade_Bancaria_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntidadeBancaria Ent = new EntidadeBancaria())
                {
                    Ent.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Entidade_Bancaria_Ainda_Existe(Ent);
                }
            }
        }

    }
}
