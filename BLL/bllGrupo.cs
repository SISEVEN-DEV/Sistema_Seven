using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllGrupo
    {
        public static bool _FrmCadGrupo_Ativo;
        public static bool _FrmRelGrupo_Ativo;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static void Salvar(string descricao, string palavra_chave, string tabela_destino, string cor_destaque)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Grup.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    Grup.Tabela_Destino = tabela_destino.Insert(tabela_destino.Length, "'").Insert(0, "'");
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Grup.Palavra_Chave = "null";
                    }
                    else
                    {
                        Grup.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //               
                    if (cor_destaque == "" || cor_destaque == null)
                    {
                        Grup.Cor_Destaque = "null";
                    }
                    else
                    {
                        Grup.Cor_Destaque = cor_destaque.Insert(cor_destaque.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Salvar_Grupo(Grup);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Grupo(Grup);
                }
            }
        }

        public static bool Sel_Grupo_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Grupo_Ainda_Existe(Grup);
                }
            }
        }

        public static DataTable Sel_Grupo_TabelaDestino(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Pesquisar = pesquisar;
                    return con.Sel_Grupo_Data_TabelaDestino(Grup);
                }
            }
        }

        public static void Salvar_SubGrupoASalGrupo(string descricao, string palavra_chave, string grupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (SubGrupo Sub = new SubGrupo())
                {
                    Sub.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    if (palavra_chave == "")
                    {
                        Sub.Palavra_Chave = "null";
                    }
                    else
                    {
                        Sub.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    string[] items = grupo.Split('-');
                    //
                    Sub.Cod_Grupo = Convert.ToInt16(items[0]);
                    Sub.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Sub.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Salvar_SubGrupoASalGrupo(Sub);
                }
            }
        }

        public static void Alterar(string codigo, string descricao, string palavra_chave, string tabela_destino, string cor_destaque)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    //
                    Grup.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Grup.Tabela_Destino = tabela_destino.Insert(tabela_destino.Length, "'").Insert(0, "'");
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Grup.Palavra_Chave = "null";
                    }
                    else
                    {
                        Grup.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //                    
                    if (cor_destaque == "" || cor_destaque == null)
                    {
                        Grup.Cor_Destaque = "null";
                    }
                    else
                    {
                        Grup.Cor_Destaque = cor_destaque.Insert(cor_destaque.Length, "'").Insert(0, "'");
                    }
                    con.Alterar_Grupo(Grup);
                }
            }
        }

        public static DataTable Sel_Grupo_Data_Todos(string data, string data1)
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
                return con.Sel_Grupo_Data_Todos(SqlData);
            }
        }

        public static DataTable Sel_Grupo_Data_Descricao(string data, string data1, string descricao)
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
                return con.Sel_Grupo_Data_Descricao(SqlData, SqlDescricao);
            }
        }

        public static DataTable Sel_Grupo_Data_TipoTabela(string data, string data1, string tabela_destino)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string SqlTabelaDestino;
                    string SqlData;

                    if (tabela_destino == "")
                    {
                        SqlTabelaDestino = "";
                    }
                    else
                    {
                        SqlTabelaDestino = "WHERE tabela_destino='" + tabela_destino + "'";
                    }
                    //

                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "";
                    }
                    else
                    {
                        if (tabela_destino != "")
                        {
                            SqlData = " AND data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                        }
                        else
                        {
                            SqlData = "WHERE data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                        }
                    }
                    //
                    return con.Sel_Grupo_Data_TipoTabela(SqlData, SqlTabelaDestino);
                }
            }
        }

        public static void Alterar_Descricao_Grupo_Produto(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    Grup.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_Grupo_Produto(Grup);
                }
            }
        }

        public static void Alterar_Descricao_Grupo_Conta_Receber(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    Grup.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_Grupo_Conta_Receber(Grup);
                }
            }
        }

        public static void Alterar_Descricao_Grupo_Conta_Pagar(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    Grup.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_Grupo_Conta_pagar(Grup);
                }
            }
        }


        public static void Alterar_Descricao_SubGrupo_Grupo(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    Grup.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    con.Alterar_Descricao_SubGrupo_Grupo(Grup);
                }
            }
        }

        public static bool Val_Grupo_Descricao_Alt(string codigo, string descricao, string tabela_destino)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    Grup.Descricao = descricao;
                    Grup.Tabela_Destino = tabela_destino;
                    if (con.Val_Grupo_Descricao_Alt(Grup) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Grupo_Descricao_Alt(Grup) == 0)
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

        public static bool Val_Grupo_Descricao(string descricao, string tabela_destino)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Descricao = descricao;
                    Grup.Tabela_Destino = tabela_destino;
                    return con.Val_Grupo_Descricao(Grup);
                }
            }
        }

        public static bool Sel_Grupo_Palavra_Chave_Ver(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Palavra_Chave = palavra_chave;
                    return con.Sel_Grupo_Palavra_Chave_Ver(Grup);
                }
            }
        }

        public static DataTable Sel_Grupo_Cor_Destaque(string tabela_destino)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Tabela_Destino = tabela_destino;
                    return con.Sel_Grupo_Cor_Destaque(Grup);
                }
            }
        }

        public static bool Sel_Grupo_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Palavra_Chave = palavra_chave;
                    if (con.Sel_Grupo_Palavra_Chave_Alt(Grup) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Grupo_Palavra_Chave_Alt(Grup) == 0)
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

        public static DataTable Sel_Grupo_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Grupo_A_Alt(Grup);
                }
            }
        }

        public static DataTable Sel_Grupo_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Grupo_A_Sal();
            }
        }

        public static DataTable Sel_Grupo_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Grup.Pesquisar = pesquisar;
                        return con.Sel_Grupo_Descricao_Like(Grup);
                    }
                    else
                    {
                        Grup.Pesquisar = pesquisar;
                        return con.Sel_Grupo_Descricao(Grup);
                    }
                }
            }
        }

        public static DataTable Sel_Grupo_Descricao_Pesq(string pesquisar, byte formulario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Pesquisar = pesquisar;
                    if (formulario == 0)
                    {
                        Grup.Tabela_Destino = "PRODUTOS";
                    }
                    else if (formulario == 2)
                    {
                        Grup.Tabela_Destino = "CONTAS A PAGAR";
                    }
                    else if (formulario == 3)
                    {
                        Grup.Tabela_Destino = "CONTAS A RECEBER";
                    }
                    else if (formulario == 4)
                    {
                        Grup.Tabela_Destino = "PRODUTOS";
                    }
                    else if (formulario == 4)
                    {
                        Grup.Tabela_Destino = "CLIENTES";
                    }
                    else if (formulario == 6)
                    {
                        Grup.Tabela_Destino = "SERVICOS";
                    }
                    else if (formulario == 7)
                    {
                        Grup.Tabela_Destino = "DOCUMENTOS";
                    }
                    //
                    return con.Sel_Grupo_Descricao_Pesq(Grup);
                }
            }
        }

        public static bool Sel_Grup_Prod_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);

                    return con.Sel_Grup_Prod_Ver(Grup);
                }
            }
        }

        public static bool Sel_Grup_SubGrupo_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Grup_SubGrupo_Ver(Grup);
                }
            }
        }

        public static bool Sel_Grup_Conta_Pagar_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Grup_Conta_Pagar_Ver(Grup);
                }
            }
        }

        public static bool Sel_Grup_Conta_Receber_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Grup_Conta_Receber_Ver(Grup);
                }
            }
        }

        public static DataTable Sel_Grupo_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Pesquisar = pesquisar;
                    return con.Sel_Grupo_Codigo(Grup);
                }
            }
        }

        public static DataTable Sel_Grupo_Codigo_Pesq(string pesquisar, byte formulario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Pesquisar = pesquisar;
                    if (formulario == 0)
                    {
                        Grup.Tabela_Destino = "PRODUTOS";
                    }
                    else if (formulario == 2)
                    {
                        Grup.Tabela_Destino = "CONTAS A PAGAR";
                    }
                    else if (formulario == 3)
                    {
                        Grup.Tabela_Destino = "CONTAS A RECEBER";
                    }
                    else if (formulario == 4)
                    {
                        Grup.Tabela_Destino = "PRODUTOS";
                    }
                    else if (formulario == 5)
                    {
                        Grup.Tabela_Destino = "CLIENTES";
                    }
                    else if (formulario == 6)
                    {
                        Grup.Tabela_Destino = "SERVICOS";
                    }
                    else if (formulario == 7)
                    {
                        Grup.Tabela_Destino = "DOCUMENTOS";
                    }
                    //
                    return con.Sel_Grupo_Codigo_Pesq(Grup);
                }
            }
        }

        public static DataTable Sel_Grupo_Palavra_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Pesquisar = pesquisar;
                    return con.Sel_Grupo_Palavra_Chave(Grup);
                }
            }
        }

        public static DataTable Sel_Grupo_Palavra_Chave_Pesq(string pesquisar, byte formulario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    Grup.Pesquisar = pesquisar;
                    if (formulario == 0)
                    {
                        Grup.Tabela_Destino = "PRODUTOS";
                    }
                    else if (formulario == 2)
                    {
                        Grup.Tabela_Destino = "CONTAS A PAGAR";
                    }
                    else if (formulario == 3)
                    {
                        Grup.Tabela_Destino = "CONTAS A RECEBER";
                    }
                    else if (formulario == 4)
                    {
                        Grup.Tabela_Destino = "PRODUTOS";
                    }
                    else if (formulario == 5)
                    {
                        Grup.Tabela_Destino = "PRODUTOS";
                    }
                    else if (formulario == 6)
                    {
                        Grup.Tabela_Destino = "SERVICOS";
                    }
                    else if (formulario == 7)
                    {
                        Grup.Tabela_Destino = "DOCUMENTOS";
                    }
                    //
                    return con.Sel_Grupo_Palavra_Chave_Pesq(Grup);
                }
            }
        }


        public static DataTable Sel_Grupo_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    return con.Sel_Grupo_Todos(Grup);
                }
            }
        }

        public static DataTable Sel_Grupo_Todos_Pesq(byte formulario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Grupo Grup = new Grupo())
                {
                    if (formulario == 0)
                    {
                        Grup.Tabela_Destino = "PRODUTOS";
                    }
                    else if (formulario == 2)
                    {
                        Grup.Tabela_Destino = "CONTAS A PAGAR";
                    }
                    else if (formulario == 3)
                    {
                        Grup.Tabela_Destino = "CONTAS A RECEBER";
                    }
                    else if (formulario == 4)
                    {
                        Grup.Tabela_Destino = "PRODUTOS";
                    }
                    else if (formulario == 5)
                    {
                        Grup.Tabela_Destino = "CLIENTES";
                    }
                    else if (formulario == 6)
                    {
                        Grup.Tabela_Destino = "SERVICOS";
                    }
                    else if (formulario == 7)
                    {
                        Grup.Tabela_Destino = "DOCUMENTOS";
                    }
                    //
                    return con.Sel_Grupo_Todos_Pesq(Grup);
                }
            }
        }
    }
}
