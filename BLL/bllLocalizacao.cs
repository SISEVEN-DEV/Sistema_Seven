using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllLocalizacao
    {
        public static bool _FrmCadLocalizacaoProd_Ativo;
        public static bool _FrmRelLocalizacaoProd_Ativo;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static void Salvar(string descricao, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Loc.Palavra_Chave = "null";
                    }
                    else
                    {
                        Loc.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    Loc.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Localizacao(Loc);
                }
            }
        }

        public static void Alterar(string codigo, string descricao, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Codigo = Convert.ToInt16(codigo);
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Loc.Palavra_Chave = "null";
                    }
                    else
                    {
                        Loc.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    Loc.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Localizacao(Loc);
                }
            }
        }

        public static DataTable Sel_Localizacao_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Localizacao_A_Alt(Loc);
                }
            }
        }

        public static bool Sel_Localizacao_Descricao_Ver(string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Descricao = descricao;
                    return con.Sel_Localizacao_Descricao_Ver(Loc);
                }
            }
        }

        public static void Excluir_Localizacao_Produto(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Localizacao_Produto(Loc);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Localizacao(Loc);
                }
            }
        }

        public static void Alterar_Descricao_Localizacao_Produto(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Codigo = Convert.ToInt16(codigo);
                    Loc.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_Localizacao_Produto(Loc);
                }
            }
        }

        public static bool Sel_Localizacao_Ineventario_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Localizacao_Ineventario_Ver(Loc);
                }
            }
        }

        public static bool Sel_Localizacao_Produto_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_localizacao_Produto_Ver(Loc);
                }
            }
        }

        public static bool Sel_Localizacao_Descricao_Alt(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Descricao = descricao;
                    if (con.Sel_Localizacao_Descricao_Alt(Loc) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Localizacao_Descricao_Alt(Loc) == 0)
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

        public static DataTable Sel_Localizacao_Data_Descricao(string data, string data1, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlDescricao;
                string SqlData;

                if (descricao == "")
                {
                    SqlDescricao = "";
                }
                else
                {
                    if (descricao.Contains("%"))
                    {
                        SqlDescricao = "WHERE descricao LIKE '" + descricao + "'";
                    }
                    else
                    {
                        SqlDescricao = "WHERE descricao STARTING WITH '" + descricao + "'";
                    }
                }
                //
                if (data.Contains("_") || data1.Contains("_"))
                {
                    SqlData = "";
                }
                else
                {
                    if (descricao != "")
                    {
                        SqlData = " AND data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                    }
                    else
                    {
                        SqlData = "WHERE data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                    }
                }
                //
                return con.Sel_Localizacao_Data_Descricao(SqlData, SqlDescricao);
            }
        }

        public static DataTable Sel_Localizacao_Data_Todos(string data, string data1)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                //
                if (data.Contains("_") || data1.Contains("_"))
                {
                    SqlData = "WHERE data_cadastro BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                }
                else
                {
                    SqlData = "WHERE data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                }
                //
                return con.Sel_Localizacao_Data_Todos(SqlData);
            }
        }

        public static DataTable Sel_Localizacao_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Loc.Pesquisar = pesquisar;
                        return con.Sel_Localizacao_Descricao_Like(Loc);
                    }
                    else
                    {
                        Loc.Pesquisar = pesquisar;
                        return con.Sel_Localizacao_Descricao(Loc);
                    }
                }
            }
        }

        public static DataTable Sel_Localizacao_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    return con.Sel_Localizacao_Todos();
                }
            }
        }

        public static DataTable Sel_Localizacao_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Pesquisar = pesquisar;
                    return con.Sel_Localizacao_Codigo(Loc);
                }
            }
        }

        public static DataTable Sel_Localizacao_Palavra_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Pesquisar = pesquisar;
                    return con.Sel_Localizacao_Palavra_Chave(Loc);
                }
            }
        }

        public static bool Sel_Localizacao_Palavra_Chave_Ver(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Palavra_Chave = palavra_chave;
                    return con.Sel_Localizacao_Palavra_Chave_Ver(Loc);
                }
            }
        }

        public static bool Sel_Localizacao_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Palavra_Chave = palavra_chave;
                    if (con.Sel_Localizacao_Palavra_Chave_Alt(Loc) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Localizacao_Palavra_Chave_Alt(Loc) == 0)
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

        public static bool Sel_Localizacao_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Localizacao Loc = new Localizacao())
                {
                    Loc.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Localizacao_Ainda_Existe(Loc);
                }
            }
        }

        public static DataTable Sel_Localizacao_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Localizacao_A_Sal();
            }
        }
    }
}
