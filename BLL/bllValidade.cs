using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllValidade
    {
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static bool _FrmRelValidade_Ativo;
        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Validade_Prod_PesqProd_Tabela;

        public static bool Sel_Validade_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Validade Val = new Validade())
                {
                    Val.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Validade_Ainda_Existe(Val);
                }
            }
        }

        public static void Salvar(string n_lote, string data_validade, string produto, string cod_dfe, string data_fabricacao, string horario_fabricacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Validade Val = new Validade())
                {
                    Val.Data_Cadastro = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + "'";
                    //
                    if (n_lote == null || n_lote == "")
                    {
                        Val.N_Lote = "null";
                    }
                    else
                    {
                        Val.N_Lote = n_lote.Insert(n_lote.Length, "'").Insert(0, "'");
                    }
                    //
                    Val.Data_Validade = data_validade.Insert(data_validade.Length, "'").Insert(0, "'").Replace('/', '.');
                    //
                    string[] items = produto.Split('—');
                    //
                    Val.Cod_Produto = Convert.ToInt32(items[0]);
                    //
                    Val.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    //
                    if (data_fabricacao == "" || data_fabricacao == "  /  /" || data_fabricacao == "__/__/____" || data_fabricacao == null)
                    {
                        Val.Data_Fabricacao = "null";
                    }
                    else
                    {
                        Val.Data_Fabricacao = "'" + data_fabricacao.Replace('/', '.') + " " + horario_fabricacao + "'";
                    }
                    //
                    if (horario_fabricacao == "" || horario_fabricacao == "  :  :" || horario_fabricacao == "__:__:__" || horario_fabricacao == null)
                    {
                        Val.Horario_Fabricacao = "null";
                    }
                    else
                    {
                        Val.Horario_Fabricacao = horario_fabricacao.Insert(horario_fabricacao.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Salvar_Validade(Val);
                }
            }
        }

        public static DataTable Sel_Validade_DataCad_Produto_Todos(string data, string data1, string produto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;
                    string SqlData;
                    string SqlProduto;

                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "WHERE data_cadastro BETWEEN '21.07.1994' AND '" + DateTime.Now.ToShortDateString().Replace('/', '.') + "'";
                    }
                    else
                    {
                        SqlData = "WHERE data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                    }
                    //
                    if (produto == "")
                    {
                        SqlProduto = "";
                    }
                    else
                    {
                        items = produto.Split('—');
                        SqlProduto = " AND id_produto=" + items[0];
                    }
                    //
                    return con.Sel_Validade_DataCad_Produto_Todos(SqlData, SqlProduto);
                }
            }
        }

        public static DataTable Sel_Validade_DataCad_Produto_Codigo(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string SqlCodigo;
                    SqlCodigo = "WHERE id_validade=" + codigo;
                    //
                    return con.Sel_Validade_DataCad_Produto_Data_Codigo(SqlCodigo);
                }
            }
        }

        public static DataTable Sel_Validade_DataCad_Produto_Data_Validade(string data, string data1, string produto, string data_validade, string data_validade1)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;
                    string SqlData;
                    string SqlProduto;
                    string SqlDataValidade;

                    SqlDataValidade = "WHERE data_validade BETWEEN '" + data_validade.Replace("/", ".") + "' AND '" + data_validade1.Replace("/", ".") + "'";
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
                    if (produto == "")
                    {
                        SqlProduto = "";
                    }
                    else
                    {
                        items = produto.Split('—');
                        SqlProduto = " AND id_produto=" + items[0];
                    }
                    //
                    return con.Sel_Validade_DataCad_Produto_Data_Validade(SqlData, SqlProduto, SqlDataValidade);
                }
            }
        }

        public static DataTable Sel_Validade_DataCad_Produto_N_Lote(string data, string data1, string produto, string n_lote)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;
                    string SqlData;
                    string SqlProduto;
                    string SqlLote;

                    SqlLote = "WHERE n_lote='" + n_lote + "'";
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
                    if (produto == "")
                    {
                        SqlProduto = "";
                    }
                    else
                    {
                        items = produto.Split('—');
                        SqlProduto = " AND id_produto=" + items[0];
                    }
                    //
                    return con.Sel_Validade_DataCad_Produto_N_Lote(SqlData, SqlProduto, SqlLote);
                }
            }
        }


        public static void Alterar(string codigo, string n_lote, string data_validade, string produto, string cod_dfe, string data_fabricacao, string horario_fabricacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Validade Val = new Validade())
                {
                    Val.Codigo = Convert.ToInt32(codigo);
                    //
                    if (n_lote == null || n_lote == "")
                    {
                        Val.N_Lote = "null";
                    }
                    else
                    {
                        Val.N_Lote = n_lote.Insert(n_lote.Length, "'").Insert(0, "'");
                    }
                    //
                    Val.Data_Validade = data_validade.Insert(data_validade.Length, "'").Insert(0, "'").Replace('/', '.');
                    //
                    string[] items = produto.Split('—');
                    //
                    Val.Cod_Produto = Convert.ToInt32(items[0]);
                    //
                    Val.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    //
                    if (data_fabricacao == "" || data_fabricacao == "  /  /" || data_fabricacao == "__/__/____" || data_fabricacao == null)
                    {
                        Val.Data_Fabricacao = "null";
                    }
                    else
                    {
                        Val.Data_Fabricacao = "'" + data_fabricacao.Replace('/', '.') + " " + horario_fabricacao + "'";
                    }
                    //
                    if (horario_fabricacao == "" || horario_fabricacao == "  :  :" || horario_fabricacao == "__:__:__" || horario_fabricacao == null)
                    {
                        Val.Horario_Fabricacao = "null";
                    }
                    else
                    {
                        Val.Horario_Fabricacao = horario_fabricacao.Insert(horario_fabricacao.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Alterar_Validade(Val);
                }
            }
        }

        public static DataTable Sel_Validade_A_Salvar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Validade_A_Salvar();
            }
        }

        public static DataTable Sel_Validade_A_Alterar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Validade Val = new Validade())
                {
                    Val.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Validade_A_Alterar(Val);
                }
            }
        }

        public static DataTable Sel_Validade_Codigo(string pesquisar, string produto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Validade Val = new Validade())
                {
                    Val.Pesquisar = pesquisar;
                    //
                    string[] items = produto.Split('—');
                    Val.Cod_Produto = Convert.ToInt32(items[0]);
                    return con.Sel_Validade_Codigo(Val);
                }
            }
        }

        public static DataTable Sel_Validade_Data_Validade(string data, string data1, string produto)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                string[] items = produto.Split('—');
                //
                SqlData = "WHERE data_validade BETWEEN '" + data.Replace('/', '.') + "' AND '" + data1.Replace('/', '.') + "' AND id_produto=" + items[0];
                return con.Sel_Validade_Data_Validade(SqlData);
            }
        }

        public static DataTable Sel_Validade_N_Lote(string pesquisar, string produto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Validade Val = new Validade())
                {
                    Val.Pesquisar = pesquisar;
                    string[] items = produto.Split('—');
                    //
                    Val.Cod_Produto = Convert.ToInt32(items[0]);
                    return con.Sel_Validade_N_Lote(Val);
                }
            }
        }

        public static DataTable Sel_Validade_Todos(string produto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Validade Val = new Validade())
                {
                    string[] items = produto.Split('—');
                    Val.Cod_Produto = Convert.ToInt32(items[0]);
                    return con.Sel_Validade_Todos(Val);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Validade Val = new Validade())
                {
                    Val.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Validade(Val);
                }
            }
        }

        public static DataTable Sel_Items_DFe_Validade(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(cod_dfe);
                    return con.Sel_Items_DFe_Validae(Nfe);
                }
            }
        }

        public static DataTable Sel_Produtos_Validade_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Produtos_Validade_Prod();
            }
        }

        public static DataTable Sel_Prod_Todos_Validade(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    string SqlProduto = "";
                    //
                    Nfe.Codigo = Convert.ToInt32(cod_dfe);
                    //
                    if (con.Sel_Items_DFe_Validae(Nfe) != null)
                    {
                        for (int i = 0; i < con.Sel_Items_DFe_Validae(Nfe).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Items_DFe_Validae(Nfe).Rows[i];
                            //
                            if (i == 0)
                            {
                                SqlProduto = SqlProduto + " AND id_produto=" + dr["id_produto"].ToString();
                            }
                            else
                            {
                                SqlProduto = SqlProduto + " OR id_produto=" + dr["id_produto"].ToString();
                            }
                        }
                    }
                    //
                    return con.Sel_Prod_Todos_Validade(SqlProduto);
                }
            }
        }
    }
}
