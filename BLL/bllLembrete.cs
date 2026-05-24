using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllLembrete
    {
        public static bool _FrmUtiAgenda_Ativo;
        public static bool _FrmUtiLembrete_Ativo;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        public static string _Usuario_PesqLembrete;
        public static string _Ocorrencia;
        public static string _Data_Vencimento_Multiplicada;
        public static string _Dias;

        public static void Baixa_Lembrete(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(codigo);
                    con.Baixa_Lembrete(Lemb);
                }
            }
        }

        public static void Pendente_Lembrete(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(codigo);
                    con.Pendente_Lembrete(Lemb);
                }
            }
        }

        public static bool Sel_Lembrete_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Lembrete_Ainda_Existe(Lemb);
                }
            }
        }

        public static string Sel_Codigo_Tabela_Geradora(string codigo, string tabela_geradora)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Cod_Fato_Gerador = Convert.ToInt32(codigo);
                    Lemb.Tabela_Geradora = tabela_geradora;
                    return con.Sel_Codigo_Tabela_Geradora(Lemb);
                }
            }
        }

        public static void Salvar(string data, string hora, string descricao, string observacao, string som_alarme, string primeiro_item_lview_usuario, int qtde_lview_usuario, string tabela_geradora, string cod_fato_gerador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Data = data.Insert(data.Length, "'").Insert(0, "'").Replace('/', '.');
                    //
                    Lemb.Horario = hora.Insert(hora.Length, "'").Insert(0, "'");
                    //
                    Lemb.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (observacao == "" | observacao == null)
                    {
                        Lemb.Observacao = "null";
                    }
                    else
                    {
                        Lemb.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    Lemb.Som_Alarme = som_alarme.Insert(som_alarme.Length, "'").Insert(0, "'");
                    //                    
                    if (qtde_lview_usuario > 1)
                    {
                        Lemb.Detalhe_Usuario = primeiro_item_lview_usuario + " e mais " + qtde_lview_usuario + ".";
                    }
                    else
                    {
                        Lemb.Detalhe_Usuario = primeiro_item_lview_usuario;
                    }
                    //
                    if (tabela_geradora == "" || tabela_geradora == null)
                    {
                        Lemb.Tabela_Geradora = "null";
                    }
                    else
                    {
                        Lemb.Tabela_Geradora = tabela_geradora.Insert(tabela_geradora.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cod_fato_gerador == "" || cod_fato_gerador == null)
                    {
                        Lemb.Cod_Fato_Gerador = 0;
                    }
                    else
                    {
                        Lemb.Cod_Fato_Gerador = Convert.ToInt32(cod_fato_gerador);
                    }
                    //
                    Lemb.Situacao = "'ABERTO'";
                    //
                    con.Salvar_Lembrete(Lemb);
                }
            }
        }

        public static void Multiplicar(string hora, string descricao, string observacao, string som_alarme, string detalhe, string ocorrencia_atual, string codigo_ant)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    int Ocorrencia_Atual = Convert.ToInt32(ocorrencia_atual) + 1;

                    for (int a = 1; a <= Convert.ToInt32(_Ocorrencia); a++)
                    {
                        DateTime d = Convert.ToDateTime(_Data_Vencimento_Multiplicada);
                        _Data_Vencimento_Multiplicada = d.AddDays(Convert.ToDouble(_Dias)).ToString("dd/MM/yyyy");
                        Lemb.Data = "'" + _Data_Vencimento_Multiplicada.Replace('/', '.') + "'";
                        //
                        Lemb.Horario = hora.Insert(hora.Length, "'").Insert(0, "'");
                        //
                        Lemb.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                        //
                        if (observacao == "")
                        {
                            Lemb.Observacao = "null";
                        }
                        else
                        {
                            Lemb.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                        }
                        //
                        Lemb.Som_Alarme = som_alarme.Insert(som_alarme.Length, "'").Insert(0, "'");
                        //                    
                        Lemb.Detalhe_Usuario = detalhe;
                        //
                        Lemb.Situacao = "'ABERTO'";
                        //
                        Lemb.Tabela_Geradora = "null";
                        //
                        Lemb.Cod_Fato_Gerador = 0;
                        //
                        con.Salvar_Lembrete(Lemb);
                        //
                        string codigo = bllLembrete.Sel_Lembrete_Ultimo_Cod_Adicionado();
                        //
                        for (int i = 0; i < bllLembrete.Sel_Ver_Dados_Usuario_Lembrete(codigo_ant).Rows.Count; i++)
                        {
                            DataRow dr = bllLembrete.Sel_Ver_Dados_Usuario_Lembrete(codigo_ant).Rows[i];
                            //
                            Salvar_Usuario_Lembrete(codigo, dr["id_usuario"].ToString(), dr["nome_usuario"].ToString(), _Data_Vencimento_Multiplicada, Lemb.Horario.Replace("'", ""));
                        }
                        //
                        Ocorrencia_Atual++;
                    }
                }
            }
        }

        public static DataTable Sel_Usuario_Lembrete()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Lembrete();
            }
        }

        public static DataTable Sel_Ver_Usuario_Lembrete(string id_lembrete)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(id_lembrete);
                    return con.Sel_Ver_Usuario_Lembrete(Lemb);
                }
            }
        }

        public static void Alterar(string codigo, string data, string hora, string descricao, string observacao, string som_alarme, string primeiro_item_lview_usuario, int qtde_lview_usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(codigo);
                    //
                    Lemb.Data = data.Insert(data.Length, "'").Insert(0, "'").Replace('/', '.');
                    //
                    Lemb.Horario = hora.Insert(hora.Length, "'").Insert(0, "'");
                    //
                    Lemb.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (observacao == "")
                    {
                        Lemb.Observacao = "null";
                    }
                    else
                    {
                        Lemb.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    Lemb.Som_Alarme = som_alarme.Insert(som_alarme.Length, "'").Insert(0, "'");
                    //                    
                    if (qtde_lview_usuario > 1)
                    {
                        Lemb.Detalhe_Usuario = primeiro_item_lview_usuario + " e mais " + (qtde_lview_usuario - 1) + ".";
                    }
                    else
                    {
                        Lemb.Detalhe_Usuario = primeiro_item_lview_usuario;
                    }
                    //
                    con.Alterar_Lembrete(Lemb);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Lembrete(Lemb);
                }
            }
        }

        public static void Salvar_Usuario_Lembrete(string codigo, string id_usuario, string nome, string data, string hora)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(codigo);
                    Lemb.Codigo_Usuario = Convert.ToInt16(id_usuario);
                    Lemb.Nome_Usuario = nome.Insert(nome.Length, "'").Insert(0, "'");
                    Lemb.Data = data.Insert(data.Length, "'").Insert(0, "'").Replace('/', '.');
                    Lemb.Horario = hora.Insert(hora.Length, "'").Insert(0, "'");
                    con.Salvar_Usuario_Lembrete(Lemb);
                }
            }
        }

        public static void Excluir_Usuario_Lembrete(string id_lembrete)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(id_lembrete);
                    con.Excluir_Usuario_Lembrete(Lemb);
                }
            }
        }

        public static bool Ver_Usuario_Horario_Data(string usuario, string data, string hora)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    string[] items = usuario.Split('—');
                    Lemb.Codigo_Usuario = Convert.ToInt16(items[0]);
                    Lemb.Data = data.Replace('/', '.');
                    Lemb.Horario = hora;
                    return con.Ver_Usuario_Horario_Data(Lemb);
                }
            }
        }

        public static bool Ver_Usuario_Horario_Data_Alt(string codigo, string usuario, string data, string hora)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    string[] items = usuario.Split('—');
                    Lemb.Codigo_Usuario = Convert.ToInt16(items[0]);
                    Lemb.Data = data.Replace('/', '.');
                    Lemb.Horario = hora;
                    if (con.Ver_Usuario_Horario_Data_Alt(Lemb) == codigo)
                    {
                        return false;
                    }
                    else if (con.Ver_Usuario_Horario_Data_Alt(Lemb) == null)
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

        public static string Sel_Lembrete_Ultimo_Cod_Adicionado()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Lembrete_Ultimo_Cod_Adicionado();
            }
        }

        public static DataTable Sel_Ver_Dados_Usuario_Lembrete(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Ver_Dados_Usuario_Lembrete(Lemb);
                }
            }
        }

        public static DataTable Sel_Lembrete_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Lembrete_A_Sal();
            }
        }

        public static DataTable Sel_Lembrete_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Lembrete_A_Alt(Lemb);
                }
            }
        }

        public static DataTable Sel_Lembrete_Todos(string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlSituacao;

                if (situacao == "ABERTO")
                {
                    SqlSituacao = "WHERE situacao='ABERTO'";
                }
                else if (situacao == "PENDENTE")
                {
                    SqlSituacao = "WHERE situacao='PENDENTE'";
                }
                else
                {
                    SqlSituacao = "";
                }
                //
                return con.Sel_Lembrete_Todos(SqlSituacao);
            }
        }

        public static DataTable Sel_Lembrete_Descricao(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    string SqlSituacao;
                    //
                    if (situacao == "ABERTO")
                    {
                        SqlSituacao = " AND situacao='ABERTO'";
                    }
                    else if (situacao == "PENDENTE")
                    {
                        SqlSituacao = " AND situacao='PENDENTE'";
                    }
                    else
                    {
                        SqlSituacao = "";
                    }
                    //
                    Lemb.Pesquisar = pesquisar;
                    return con.Sel_Lembrete_Descricao(Lemb, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Lembrete_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Pesquisar = pesquisar;
                    return con.Sel_Lembrete_Codigo(Lemb);
                }
            }
        }

        public static DataTable Sel_Lembrete_Data(string data1, string data2, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    string SqlSituacao;
                    string SqlData;
                    SqlData = "WHERE data BETWEEN '" + data1.Replace('/', '.') + "' AND '" + data2.Replace('/', '.') + "'";
                    //
                    if (situacao == "ABERTO")
                    {
                        SqlSituacao = " AND situacao='ABERTO'";
                    }
                    else if (situacao == "PENDENTE")
                    {
                        SqlSituacao = " AND situacao='PENDENTE'";
                    }
                    else
                    {
                        SqlSituacao = "";
                    }
                    //
                    return con.Sel_Lembrete_Data(SqlData, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Lembrete_Usuario(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    string SqlSituacao;
                    //
                    if (situacao == "ABERTO")
                    {
                        SqlSituacao = " AND situacao='ABERTO'";
                    }
                    else if (situacao == "PENDENTE")
                    {
                        SqlSituacao = " AND situacao='PENDENTE'";
                    }
                    else
                    {
                        SqlSituacao = "";
                    }
                    //
                    string[] items = pesquisar.Replace("Usuário(a): ", "").Split('—');
                    Lemb.Pesquisar = items[0];
                    return con.Sel_Lembrete_Usuario(Lemb, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Lembrete_Tabela_Geradora(string codigo, string situacao, string tabela)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    string SqlSituacao;
                    string SqlTabela;
                    string SqlCodigo;
                    //
                    SqlTabela = "WHERE tabela_geradora='" + tabela + "'";
                    //
                    if (situacao == "ABERTO")
                    {
                        SqlSituacao = " AND situacao='ABERTO'";
                    }
                    else if (situacao == "PENDENTE")
                    {
                        SqlSituacao = " AND situacao='PENDENTE'";
                    }
                    else
                    {
                        SqlSituacao = "";
                    }
                    //
                    if (codigo == "")
                    {
                        SqlCodigo = "";
                    }
                    else
                    {
                        SqlCodigo = " AND id_fato_gerador=" + codigo;
                    }
                    //
                    return con.Sel_Lembrete_Tabela_Geradora(SqlTabela, SqlSituacao, SqlCodigo);
                }
            }
        }

        public static DataTable Sel_Alarme_Dia_Hora(string data, string hora, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    string[] items = usuario.Split('—');
                    //
                    Lemb.Codigo_Usuario = Convert.ToInt16(items[0]);
                    Lemb.Data = data.Insert(data.Length, "'").Insert(0, "'").Replace('/', '.');
                    Lemb.Horario = hora.Insert(hora.Length, "'").Insert(0, "'");
                    return con.Sel_Alarme_Dia_Hora(Lemb);
                }
            }
        }

        public static DataTable Sel_Alarme_Dia_Hora_Dados(string codigo_lembrete)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(codigo_lembrete);
                    return con.Sel_Alarme_Dia_Hora_Dados(Lemb);
                }
            }
        }

        public static DataTable Sel_Lembrete_Usuarios()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Lembrete_Usuarios();
            }
        }

        public static bool Sel_Ver_Lemb_Fechado(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Lembrete Lemb = new Lembrete())
                {
                    Lemb.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Ver_Lemb_Fechado(Lemb);
                }
            }
        }
    }
}