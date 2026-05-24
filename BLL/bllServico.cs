using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class bllServico
    {
        public static string _Grupo_PesqGrupo_Tabela;
        public static string _SubGrupo_PesqSubGrupo_Tabela;
        public static bool _FrmCadServico_Ativo;
        public static string _ItemServico_PesqItemServico_Tabela;

        public static string _Cod_Servico_Cadastro;

        public static void Salvar(string descricao, string preco, string item_servico, string aliquota, string comissao, string acrescimo_porc, string desconto_porc, string grupo, string subgrupo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Serv.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (preco.Contains("."))
                    {
                        Serv.Preco = Convert.ToDecimal(preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Serv.Preco = Convert.ToDecimal(preco.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    string[] items;
                    if (item_servico == "" || item_servico == null)
                    {
                        Serv.Cod_Item_Servico = 0;
                        //
                        Serv.Desc_Item_Servico = "null";
                    }
                    else
                    {
                        items = item_servico.Split('—');
                        //
                        Serv.Cod_Item_Servico = Convert.ToInt32(items[0]);
                        //
                        Serv.Desc_Item_Servico = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (aliquota.Contains("."))
                    {
                        Serv.Aliquota = Convert.ToDecimal(aliquota.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Serv.Aliquota = Convert.ToDecimal(aliquota.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (comissao == "" || comissao == null)
                    {
                        Serv.Comissao = 0;
                    }
                    else
                    {
                        if (comissao.Contains("."))
                        {
                            Serv.Comissao = Convert.ToDecimal(comissao.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Serv.Comissao = Convert.ToDecimal(comissao.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (acrescimo_porc == "" || acrescimo_porc == null)
                    {
                        Serv.Acrescimo_Porc = 0;
                    }
                    else
                    {
                        if (acrescimo_porc.Contains("."))
                        {
                            Serv.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Serv.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (desconto_porc == "" || desconto_porc == null)
                    {
                        Serv.Desconto_Porc = 0;
                    }
                    else
                    {
                        if (desconto_porc.Contains("."))
                        {
                            Serv.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Serv.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    items = grupo.Split('—');
                    //
                    Serv.Cod_Grupo = Convert.ToInt16(items[0]);
                    Serv.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = subgrupo.Split('—');
                    Serv.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    Serv.Desc_SubGrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Serv.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Servico(Serv);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Grupo_Serv()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Grupo_Serv();
            }
        }

        public static DataTable Sel_ComboboxGrupoServ_Valor_A_Alterar(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    string[] items = cbbgrupo.Split('—');
                    Serv.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxGrupoServ_Valor_A_Alterar(Serv);
                }
            }
        }

        public static DataTable Sel_SubGrupo_Serv(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    string[] items = cbbgrupo.Split('—');
                    Serv.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_SubGrupo_Serv(Serv);
                }
            }
        }

        public static DataTable Sel_ComboboxSubGrupoServ_Valor_A_Alterar(string cbbsubgrupo, string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    string[] items = cbbsubgrupo.Split('—');
                    Serv.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    items = cbbgrupo.Split('—');
                    Serv.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxSubGrupoServ_Valor_A_Alterar(Serv);
                }
            }
        }

        public static void Alterar(string codigo, string descricao, string preco, string item_servico, string aliquota, string comissao, string acrescimo_porc, string desconto_porc, string grupo, string subgrupo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Serv.Codigo = Convert.ToInt32(codigo);
                    //
                    Serv.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (preco.Contains("."))
                    {
                        Serv.Preco = Convert.ToDecimal(preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Serv.Preco = Convert.ToDecimal(preco.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    string[] items;
                    if (item_servico == "" || item_servico == null)
                    {
                        Serv.Cod_Item_Servico = 0;
                        //
                        Serv.Desc_Item_Servico = "null";
                    }
                    else
                    {
                        items = item_servico.Split('—');
                        //
                        Serv.Cod_Item_Servico = Convert.ToInt32(items[0]);
                        //
                        Serv.Desc_Item_Servico = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (aliquota.Contains("."))
                    {
                        Serv.Aliquota = Convert.ToDecimal(aliquota.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Serv.Aliquota = Convert.ToDecimal(aliquota.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (comissao == "" || comissao == null)
                    {
                        Serv.Comissao = 0;
                    }
                    else
                    {
                        if (comissao.Contains("."))
                        {
                            Serv.Comissao = Convert.ToDecimal(comissao.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Serv.Comissao = Convert.ToDecimal(comissao.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (acrescimo_porc == "" || acrescimo_porc == null)
                    {
                        Serv.Acrescimo_Porc = 0;
                    }
                    else
                    {
                        if (acrescimo_porc.Contains("."))
                        {
                            Serv.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Serv.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (desconto_porc == "" || desconto_porc == null)
                    {
                        Serv.Desconto_Porc = 0;
                    }
                    else
                    {
                        if (desconto_porc.Contains("."))
                        {
                            Serv.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Serv.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    items = grupo.Split('—');
                    //
                    Serv.Cod_Grupo = Convert.ToInt16(items[0]);
                    Serv.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = subgrupo.Split('—');
                    Serv.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    Serv.Desc_SubGrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Serv.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Servico(Serv);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Serv_Grupo(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    string[] items = pesquisar.Split('—');
                    Serv.Pesquisar = items[0];
                    return con.Sel_Serv_Grupo(Serv, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Serv_Grupo_SubGrupo(string pesquisar, string subgrupo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    string[] items = pesquisar.Split('—');
                    Serv.Pesquisar = items[0];
                    items = subgrupo.Split('—');
                    return con.Sel_Serv_Grupo_SubGrupo(Serv, items[0], SqlSituacao);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Servico(Serv);
                }
            }
        }

        public static bool Sel_Servico_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Servico_Ainda_Existe(Serv);
                }
            }
        }

        public static DataTable Sel_Servico_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Servico_A_Sal();
            }
        }

        public static DataTable Sel_Item_Servico_Serv()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Item_Servico_Serv();
            }
        }

        public static DataTable Sel_ComboboxServico_Valor_A_Alterar(string cbbservico)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    string[] items = cbbservico.Split('—');
                    Serv.Cod_Item_Servico = Convert.ToInt32(items[0]);
                    return con.Sel_ComboboxServico_Valor_A_Alterar(Serv);
                }
            }
        }

        public static bool Sel_OS_Servico_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_OS_Servico_Ver(Serv);
                }
            }
        }

        public static DataTable Sel_Servico_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Servico_A_Alt(Serv);
                }
            }
        }

        public static bool Val_Servico_Descricao(string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Descricao = descricao;
                    return con.Val_Servico_Descricao(Serv);
                }
            }
        }

        public static bool Val_Servico_Descricao_Alt(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Codigo = Convert.ToInt16(codigo);
                    Serv.Descricao = descricao;
                    if (con.Val_Servico_Descricao_Alt(Serv) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Servico_Descricao_Alt(Serv) == 0)
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

        public static DataTable Sel_Servico_Descricao(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    if (pesquisar.Contains("%"))
                    {
                        Serv.Pesquisar = pesquisar;
                        return con.Sel_Servico_Descricao_Like(Serv, SqlSituacao);
                    }
                    else
                    {
                        Serv.Pesquisar = pesquisar;
                        return con.Sel_Servico_Descricao(Serv, SqlSituacao);
                    }
                }
            }
        }

        public static DataTable Sel_Servico_Situacao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Pesquisar = pesquisar;
                    return con.Sel_Servico_Situacao(Serv);
                }
            }
        }

        public static DataTable Sel_Servico_Item_Servico(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    string[] items = pesquisar.Split('—');
                    Serv.Pesquisar = items[0];
                    return con.Sel_Servico_Item_Servico(Serv, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Servico_Codigo(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    Serv.Pesquisar = pesquisar;
                    return con.Sel_Servico_Codigo(Serv, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Servico_Todos(string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = "WHERE situacao='" + situacao + "'";
                    }
                    //
                    return con.Sel_Servico_Todos(Serv, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Serv_Data_Hora_Ult_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Serv_Data_Hora_Ult_Venda(Serv);
                }
            }
        }

        public static DataTable Sel_Serv_Frequencia_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Serv_Frequencia_Venda(Serv);
                }
            }
        }

        public static DataTable Sel_Serv_Total_Valor_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Servico Serv = new Servico())
                {
                    Serv.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Serv_Total_Valor_Venda(Serv);
                }
            }
        }

        public static DataTable Sel_Serv_Data_Hora_Ult_Alteracao(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_Data_Hora_Ult_Alteracao(Prod);
                }
            }
        }
    }
}
