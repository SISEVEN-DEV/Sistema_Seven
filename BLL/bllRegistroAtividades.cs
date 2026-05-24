using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllRegistroAtividades
    {
        public static bool _FrmRelRegistroAtividades_Ativo;

        public static string _Reg_PesqUsuario_Tabela;
        public static string _Reg_PesqFuncionario_Tabela;
        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static void Salvar(string descricao, string nome_tabela, string cod_registro, string usuario, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (RegistroAtividades Reg = new RegistroAtividades())
                {
                    Reg.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Reg.Data = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss").Replace('/', '.') + "'";
                    //
                    Reg.Horario = "'" + DateTime.Now.ToString("HH:mm:ss").Replace('/', '.') + "'";
                    //
                    Reg.Nome_Tabela = nome_tabela.Insert(nome_tabela.Length, "'").Insert(0, "'");
                    //
                    Reg.Cod_Registro = Convert.ToInt32(cod_registro);
                    //
                    usuario = usuario.Replace("Usuário(a): ", "");
                    string[] items = usuario.Split('—');
                    //
                    Reg.Cod_Usuario = Convert.ToInt16(items[0]);
                    //
                    Reg.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Reg.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    con.Salvar_Registro(Reg);
                }
            }
        }

        public static DataTable Sel_Registro_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (RegistroAtividades Reg = new RegistroAtividades())
                {
                    Reg.Pesquisar = pesquisar;
                    return con.Sel_Registro_Codigo(Reg);
                }
            }
        }

        public static DataTable Sel_Registro_Usuario_Data_Hor_Tab_User(string data, string data1, string horario, string horario1, string tabela, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string SqlUsuario;
                    string SqlData;
                    string SqlTabela;

                    string[] items = usuario.Split('—');
                    //
                    SqlUsuario = "WHERE id_usuario='" + items[0] + "'";
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "";
                    }
                    else
                    {
                        if (horario.Contains("_"))
                        {
                            horario = "";
                        }
                        else
                        {
                            horario = " " + horario;
                        }
                        //
                        if (horario1.Contains("_"))
                        {
                            horario1 = " 23:59:59";
                        }
                        else
                        {
                            horario1 = " " + horario1;
                        }
                        //
                        SqlData = " AND data BETWEEN '" + data.Replace("/", ".") + horario + "' AND '" + data1.Replace("/", ".") + horario1 + "'";
                    }
                    //
                    if (tabela == "")
                    {
                        SqlTabela = "";
                    }
                    else
                    {
                        SqlTabela = " AND nome_tabela='" + tabela + "'";
                    }
                    //
                    return con.Sel_Registro_Usuario_Data_Hor_Tab_User(SqlUsuario, SqlData, SqlTabela);
                }
            }
        }

        public static DataTable Sel_Registro_Usuario_Data_Hor_Tab_Cod_Registro(string data, string data1, string horario, string horario1, string tabela, string cod_registro)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string SqlCodRegistro;
                    string SqlData;
                    string SqlTabela;
                    //
                    SqlCodRegistro = "WHERE id_registro='" + cod_registro + "'";
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "";
                    }
                    else
                    {
                        if (horario.Contains("_"))
                        {
                            horario = "";
                        }
                        else
                        {
                            horario = " " + horario;
                        }
                        //
                        if (horario1.Contains("_"))
                        {
                            horario1 = " 23:59:59";
                        }
                        else
                        {
                            horario1 = " " + horario1;
                        }
                        //
                        SqlData = " AND data BETWEEN '" + data.Replace("/", ".") + horario + "' AND '" + data1.Replace("/", ".") + horario1 + "'";
                    }
                    //
                    if (tabela == "")
                    {
                        SqlTabela = "";
                    }
                    else
                    {
                        SqlTabela = " AND nome_tabela='" + tabela + "'";
                    }
                    //
                    return con.Sel_Registro_Usuario_Data_Hor_Tab_Cod_Registro(SqlCodRegistro, SqlData, SqlTabela);
                }
            }
        }

        public static DataTable Sel_Usuario_Registro()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Registro();
            }
        }

        public static int Sel_Dados_Tabela_Reg_Ativ_Existe()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Dados_Tabela_Reg_Ativ_Existe();
            }
        }

        public static DataTable Sel_Registro_Usuario_Data_Hor_Tab(string data, string data1, string horario, string horario1, string tabela)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string SqlData;
                    string SqlTabela;
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "WHERE data BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                    }
                    else
                    {
                        if (horario.Contains("_"))
                        {
                            horario = "";
                        }
                        else
                        {
                            horario = " " + horario;
                        }
                        //
                        if (horario1.Contains("_"))
                        {
                            horario1 = " 23:59:59";
                        }
                        else
                        {
                            horario1 = " " + horario1;
                        }
                        //
                        SqlData = "WHERE data BETWEEN '" + data.Replace("/", ".") + horario + "' AND '" + data1.Replace("/", ".") + horario1 + "'";
                    }
                    //
                    if (tabela == "")
                    {
                        SqlTabela = "";
                    }
                    else
                    {
                        SqlTabela = " AND nome_tabela='" + tabela + "'";
                    }
                    //                    
                    return con.Sel_Registro_Usuario_Data_Hor_Tab(SqlData, SqlTabela);
                }
            }
        }
    }
}
