using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllSubGrupo
    {
        public static bool _FrmCadSubgrupo_Ativo;
        public static bool _FrmRelSubgrupo_Ativo;
        public static string _Grupo_PesqGrupo_Tabela;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static void Salvar(string descricao, string palavra_chave, string grupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Sub.Palavra_Chave = "null";
                    }
                    else
                    {
                        Sub.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    string[] items = grupo.Split('—');
                    //
                    Sub.Cod_Grupo = Convert.ToInt16(items[0]);
                    Sub.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Sub.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Salvar_SubGrupo(Sub);
                }
            }
        }

        public static void Alterar(string codigo, string descricao, string grupo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Sub.Palavra_Chave = "null";
                    }
                    else
                    {
                        Sub.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    Sub.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    string[] items = grupo.Split('—');
                    //
                    Sub.Cod_Grupo = Convert.ToInt16(items[0]);
                    Sub.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    con.Alterar_SubGrupo(Sub);
                }
            }
        }

        public static bool Sel_Subgrupo_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Subgrupo_Ainda_Existe(Sub);
                }
            }
        }

        public static DataTable Sel_Sub_Data_Nome(string descricao, string data, string data1)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                string SqlDescricao;
                //
                if (descricao.Contains("%"))
                {
                    SqlDescricao = "WHERE descricao LIKE '" + descricao + "'";
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
                return con.Sel_Sub_Data_Nome(SqlDescricao, SqlData);
            }
        }

        public static DataTable Sel_Sub_Data_Grupo(string grupo, string data, string data1)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                string SqlGrupo;

                if (grupo == "")
                {
                    SqlGrupo = "";
                }
                else
                {
                    string[] items = grupo.Split('—');
                    //
                    SqlGrupo = "WHERE id_grupo='" + items[0] + "'";
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
                return con.Sel_Sub_Data_Grupo(SqlGrupo, SqlData);
            }
        }

        public static DataTable Sel_Sub_Data_Grupo_Todos(string data, string data1)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;

                if (data.Contains("_") || data1.Contains("_"))
                {
                    SqlData = "WHERE data_cadastro BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                }
                else
                {
                    SqlData = "WHERE data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                }
                //
                return con.Sel_Sub_Data_Grupo_Todos(SqlData);
            }
        }

        public static void Alterar_Descricao_Subgrupo_Conta_Receber(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    Sub.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_Subgrupo_Conta_Receber(Sub);
                }
            }
        }

        public static void Alterar_Descricao_Subgrupo_Produto(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    Sub.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_Subgrupo_Produtos(Sub);
                }
            }
        }

        public static void Alterar_Descricao_Subgrupo_Contas_Pagar(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    Sub.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_Subgrupo_Contas_Pagar(Sub);
                }
            }
        }

        public static bool Val_SubGrupo_Descricao(string descricao, string grupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Descricao = descricao;
                    if (grupo != "")
                    {
                        string[] items = grupo.Split('—');
                        Sub.Cod_Grupo = Convert.ToInt16(items[0]);
                    }
                    else
                    {
                        Sub.Cod_Grupo = 0;
                    }
                    return con.Val_SubGrupo_Descricao(Sub);
                }
            }
        }

        public static DataTable Sel_ComboboxGrupo_Valor_A_Alterar_SubGrupo(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    string[] items = cbbgrupo.Split('—');
                    Sub.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxGrupo_Valor_A_Alterar_SubGrupo(Sub);
                }
            }
        }

        public static bool Val_SubGrupo_Descricao_Alt(string codigo, string descricao, string grupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    Sub.Descricao = descricao;
                    if (grupo != "")
                    {
                        string[] items = grupo.Split('—');
                        Sub.Cod_Grupo = Convert.ToInt16(items[0]);
                    }
                    else
                    {
                        Sub.Cod_Grupo = 0;
                    }
                    if (con.Val_SubGrupo_Descricao_Alt(Sub) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_SubGrupo_Descricao_Alt(Sub) == 0)
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

        public static bool Sel_SubGrupo_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Palavra_Chave = palavra_chave;
                    if (con.Sel_SubGrupo_Palavra_Chave_Alt(Sub) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_SubGrupo_Palavra_Chave_Alt(Sub) == 0)
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

        public static DataTable Sel_Grupo_SubGrupo()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Grupo_SubGrupo();
            }
        }

        public static bool Sel_SubGrupo_Palavra_Chave_Ver(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Palavra_Chave = palavra_chave;
                    return con.Sel_SubGrupo_Palavra_Chave_Ver(Sub);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_SubGrupo(Sub);
                }
            }
        }

        public static DataTable Sel_SubGrupo_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_SubGrupo_A_Alt(Sub);
                }
            }
        }

        public static DataTable Sel_SubGrupo_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    return con.Sel_SubGrupo_A_Sal(Sub);
                }
            }
        }

        public static DataTable Sel_SubGrupo_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Sub.Pesquisar = pesquisar;
                        return con.Sel_SubGrupo_Descricao_Like(Sub);
                    }
                    else
                    {
                        Sub.Pesquisar = pesquisar;
                        return con.Sel_SubGrupo_Descricao(Sub);
                    }
                }
            }
        }

        public static DataTable Sel_SubGrupo_Descricao_Pesq(string pesquisar, string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Pesquisar = pesquisar;
                    Sub.Cod_Grupo = Convert.ToInt16(codigo);
                    return con.Sel_SubGrupo_Descricao_Pesq(Sub);
                }
            }
        }

        public static DataTable Sel_SubGrupo_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Pesquisar = pesquisar;
                    return con.Sel_SubGrupo_Codigo(Sub);
                }
            }
        }

        public static DataTable Sel_SubGrupo_Codigo_Pesq(string pesquisar, string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Pesquisar = pesquisar;
                    Sub.Cod_Grupo = Convert.ToInt16(codigo);
                    return con.Sel_SubGrupo_Codigo_Pesq(Sub);
                }
            }
        }

        public static DataTable Sel_SubGrupo_Grupo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    string[] items = pesquisar.Split('—');
                    Sub.Pesquisar = items[0];
                    return con.Sel_SubGrupo_Grupo(Sub);
                }
            }
        }

        public static DataTable Sel_SubGrupo_Palavra_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Pesquisar = pesquisar;
                    return con.Sel_SubGrupo_Palavra_Chave(Sub);
                }
            }
        }

        public static DataTable Sel_SubGrupo_Palavra_Chave_Pesq(string pesquisar, string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Pesquisar = pesquisar;
                    Sub.Cod_Grupo = Convert.ToInt16(codigo);
                    return con.Sel_SubGrupo_Palavra_Chave_Pesq(Sub);
                }
            }
        }

        public static bool Sel_SubGrupo_Prod_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_SubGrupo_Prod_Ver(Sub);
                }
            }
        }

        public static bool Sel_SubGrupo_Conta_Receber_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_SubGrupo_Conta_Receber_Ver(Sub);
                }
            }
        }

        public static bool Sel_SubGrupo_Conta_Pagar_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_SubGrupo_Conta_Pagar_Ver(Sub);
                }
            }
        }

        public static DataTable Sel_SubGrupo_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    return con.Sel_SubGrupo_Todos(Sub);
                }
            }
        }

        public static DataTable Sel_SubGrupo_Todos_Pesq(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Cod_Grupo = Convert.ToInt16(codigo);
                    return con.Sel_SubGrupo_Todos_Pesq(Sub);
                }
            }
        }
    }
}
