using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllMarca
    {
        public static bool _FrmCadMarca_Ativo;
        public static bool _FrmRelMarca_Ativo;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static string _Cod_Marca_Cadastro;


        public static void Salvar(string descricao, string palavra_chave, string origem, string pais)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    Marc.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Marc.Palavra_Chave = "null";
                    }
                    else
                    {
                        Marc.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    Marc.Origem = origem.Insert(origem.Length, "'").Insert(0, "'");
                    //
                    if (pais == "" || pais == null)
                    {
                        Marc.Pais = "null";
                    }
                    else
                    {
                        Marc.Pais = pais.Insert(pais.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Salvar_Marca(Marc);
                }
            }
        }

        public static bool Sel_Marca_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marca = new Marca())
                {
                    Marca.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Marca_Ainda_Existe(Marca);
                }
            }
        }

        public static void Alterar(string codigo, string descricao, string palavra_chave, string origem, string pais)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Codigo = Convert.ToInt16(codigo);

                    Marc.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Marc.Palavra_Chave = "null";
                    }
                    else
                    {
                        Marc.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    Marc.Origem = origem.Insert(origem.Length, "'").Insert(0, "'");
                    //
                    if (pais == "" || pais == null)
                    {
                        Marc.Pais = "null";
                    }
                    else
                    {
                        Marc.Pais = pais.Insert(pais.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Alterar_Marca(Marc);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Marca(Marc);
                }
            }
        }

        public static DataTable Sel_Marca_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Marca_A_Alt(Marc);
                }
            }
        }

        public static DataTable Sel_Marca_A_Salvar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Marca_A_Salvar();
            }
        }

        public static DataTable Sel_Marca_Todas()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Marca_Todas();
            }
        }

        public static DataTable Sel_Marca_Descricao(string pesquisa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    if (pesquisa.Contains("%"))
                    {
                        Marc.Pesquisar = pesquisa;
                        return con.Sel_Marca_Descricao_Like(Marc);
                    }
                    else
                    {
                        Marc.Pesquisar = pesquisa;
                        return con.Sel_Marca_Descricao(Marc);
                    }
                }
            }
        }

        public static DataTable Sel_Marca_Codigo(string pesquisa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Pesquisar = pesquisa;
                    return con.Sel_Marca_Codigo(Marc);
                }
            }
        }

        public static DataTable Sel_Marca_Origem(string pesquisa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Pesquisar = pesquisa;
                    return con.Sel_Marca_Origem(Marc);
                }
            }
        }

        public static DataTable Sel_Marca_Palavra_Chave(string pesquisa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Pesquisar = pesquisa;
                    return con.Sel_Marca_Palavra_Chave(Marc);
                }
            }
        }

        public static bool Sel_Marca_Palavra_Chave_Ver(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Palavra_Chave = palavra_chave;
                    return con.Sel_Marca_Palavra_Chave_Ver(Marc);
                }
            }
        }

        public static bool Sel_Marca_Descricao_Ver(string descricao, string pais)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Descricao = descricao;
                    Marc.Pais = pais;
                    return con.Sel_Marca_Descricao_Ver(Marc);
                }
            }
        }

        public static bool Sel_Marca_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Palavra_Chave = palavra_chave;
                    if (con.Sel_Marca_Palavra_Chave_Alt(Marc) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Marca_Palavra_Chave_Alt(Marc) == 0)
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

        public static bool Sel_Marca_Descricao_Alt(string codigo, string descricao, string pais)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Descricao = descricao;
                    Marc.Pais = pais;
                    if (con.Sel_Marca_Descricao_Alt(Marc) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Marca_Descricao_Alt(Marc) == 0)
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

        public static void Alterar_Descricao_Marca_Produto(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Codigo = Convert.ToInt16(codigo);
                    Marc.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_Marca_Produto(Marc);
                }
            }
        }

        public static bool Sel_Marca_Produto_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Marca_Produto_Ver(Marc);
                }
            }
        }

        public static void Excluir_Marca_Produto(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Marca Marc = new Marca())
                {
                    Marc.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Marca_Produto(Marc);
                }
            }
        }

        public static DataTable Sel_Marca_Data_Pais_Descricao(string data, string data1, string descricao, string pais)
        {
            using (Con7BD con = new Con7BD())
            {

                string SqlDescricao;
                string SqlData;
                string SqlPais;
                //
                if (descricao == "")
                {
                    SqlDescricao = "";
                }
                else
                {
                    SqlDescricao = "WHERE descricao STARTING WITH '" + descricao + "'";
                }
                //
                if (data.Contains("_") || data1.Contains("_"))
                {
                    SqlData = "";
                }
                else
                {
                    SqlData = " AND data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                }
                //
                if (pais == "")
                {
                    SqlPais = "";
                }
                else
                {
                    SqlPais = " AND pais='" + pais + "'";
                }
                //
                return con.Sel_Marca_Data_Pais_Descricao(SqlData, SqlDescricao, SqlPais);
            }

        }

        public static DataTable Sel_Marca_Data_Pais_Origem(string data, string data1, string origem, string pais)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string SqlOrigem;
                    string SqlData;
                    string SqlPais;
                    //
                    if (origem == "")
                    {
                        SqlOrigem = "";
                    }
                    else
                    {
                        SqlOrigem = "WHERE origem='" + origem + "'";
                    }
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "";
                    }
                    else
                    {
                        SqlData = " AND data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                    }
                    //
                    if (pais == "")
                    {
                        SqlPais = "";
                    }
                    else
                    {
                        SqlPais = " AND pais='" + pais + "'";
                    }
                    //
                    return con.Sel_Marca_Data_Pais_Origem(SqlData, SqlOrigem, SqlPais);
                }
            }
        }

        public static DataTable Sel_Marca_Data_Pais_Todos(string data, string data1, string pais)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string SqlData;
                    string SqlPais;
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "";
                    }
                    else
                    {
                        SqlData = "WHERE data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                    }
                    //
                    if (pais == "")
                    {
                        SqlPais = "";
                    }
                    else
                    {
                        if (data.Contains("_") || data1.Contains("_"))
                        {
                            SqlPais = "WHERE pais='" + pais + "'";
                        }
                        else
                        {
                            SqlPais = " AND pais='" + pais + "'";
                        }
                    }
                    //
                    return con.Sel_Marca_Data_Pais_Todos(SqlData, SqlPais);
                }
            }
        }
    }
}
