using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Threading;

namespace BLL
{
    public class bllDevolucao
    {
        public static string _Quantidade;
        public static string _Consumidor_PesqDev;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        public static byte _Tipo_Dev_Forma;
        public static bool _FrmRelDevolucao_Ativo;

        public static string _Devolucao_PesqVendaTabela;
        public static string _Devolucao_PesqUsuarioTabela;
        public static string _Devolucao_PesqCompPDV_Tabela;
        public static string _Devolucao_Prod_PesqProd_Tabela;
        public static string _Devolucao_Prod_PesqCliente_Tabela;
        public static string _Justificativa_Cancelamento;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static void Salvar_Devolucao(string consumidor, string valor, string usuario, string cod_pdv_computador, string cod_venda, int contem_produto, byte forma_devolucao, string valor_novos_itens, string valor_devolvido)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Data = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Dev.Hora = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items;
                    if (consumidor == null)
                    {
                        Dev.Cod_Consumidor = 0;
                        Dev.Nome_Consumidor = "null";
                        Dev.CPF_CNPJ_Consumidor = "null";
                    }
                    else
                    {
                        items = consumidor.Split('—');
                        ClieCons Clie = new ClieCons();
                        Clie.Codigo = Convert.ToInt32(items[0]);
                        //
                        DataRow dr = con.Sel_PDV_Dados_Cliente_Codigo(Clie).Rows[0];
                        //
                        Dev.Cod_Consumidor = Convert.ToInt32(items[0]);
                        Dev.Nome_Consumidor = dr["nome"].ToString().Insert(dr["nome"].ToString().Length, "'").Insert(0, "'");
                        Dev.CPF_CNPJ_Consumidor = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                    }
                    //
                    if (valor.Contains("."))
                    {
                        Dev.Valor = Convert.ToDecimal(valor.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Dev.Valor = Convert.ToDecimal(valor.Replace(",", "."));
                    }
                    //
                    items = usuario.Replace("Usuário(a): ", "").Split('—');
                    Dev.Cod_Usuario = Convert.ToInt16(items[0]);
                    Dev.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Dev.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", ""));
                    //
                    Dev.Cod_Venda = Convert.ToInt32(cod_venda);
                    //
                    if (valor_devolvido.Contains("."))
                    {
                        Dev.Valor_Devolvido = Convert.ToDecimal(valor_devolvido.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Dev.Valor_Devolvido = Convert.ToDecimal(valor_devolvido.Replace(",", "."));
                    }
                    //
                    if (valor_novos_itens.Contains("."))
                    {
                        Dev.Valor_Novos_Itens = Convert.ToDecimal(valor_novos_itens.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Dev.Valor_Novos_Itens = Convert.ToDecimal(valor_novos_itens.Replace(",", "."));
                    }
                    //
                    string tipo;
                    if (contem_produto > 0)
                    {
                        if ((Dev.Valor <= Dev.Valor_Novos_Itens))
                        {
                            tipo = "DEVOLUCAO DE PRODUTOS";
                        }
                        else
                        {
                            tipo = "DEVOLUCAO PARCIAL DE PRODUTOS";
                        }
                    }
                    else
                    {
                        tipo = "";
                    }
                    //
                    if (forma_devolucao == 1)
                    {
                        if (contem_produto > 0)
                        {
                            tipo = tipo + " COM DEVOLUCAO EM DINHEIRO";
                        }
                        else
                        {
                            tipo = tipo + "DEVOLUCAO EM DINHEIRO";
                        }
                    }
                    else if (forma_devolucao == 2)
                    {
                        if (contem_produto > 0)
                        {
                            tipo = tipo + " COM DEVOLUCAO EM CREDITO LOJA";
                        }
                        else
                        {
                            tipo = tipo + "DEVOLUCAO EM CREDITO LOJA";
                        }
                    }
                    //
                    Dev.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Devolucao(Dev);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Adicionar_Credito_Loja_Cliente(string consumidor, string valor)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] itens = consumidor.Split('—');
                    //
                    Clie.Codigo = Convert.ToInt32(itens[0]);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (valor.Contains("."))
                    {
                        Clie.Saldo_Credito_Loja = Convert.ToDecimal(valor.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(con.Sel_Credito_Loja_Cliente_Dev(Clie).Replace(',', '.'));
                    }
                    else
                    {
                        Clie.Saldo_Credito_Loja = Convert.ToDecimal(valor.Replace(",", ".")) + Convert.ToDecimal(con.Sel_Credito_Loja_Cliente_Dev(Clie).Replace(',', '.'));
                    }
                    //
                    con.Adicionar_Credito_Loja_Cliente(Clie);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Itens_Devolucao(string item, string cod_produto, string descricao, string quantidade, string um, string vl_unit, string vl_total, string cod_devolucao, string valor_desconto, string valor_acrescimo, string valor_desconto_item, string valor_acrescimo_item, string valor_total_apos_desc_acresc)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Devolucao Item = new Item_Devolucao())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Item = Convert.ToInt16(item);
                    //
                    Item.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Item.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (quantidade.Contains("."))
                    {
                        Item.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Item.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (vl_unit.Contains("."))
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(vl_unit.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(vl_unit.Replace(",", "."));
                    }
                    //
                    if (vl_total.Contains("."))
                    {
                        Item.Valor_Total = Convert.ToDecimal(vl_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Total = Convert.ToDecimal(vl_total.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_desconto_item.Contains("."))
                    {
                        Item.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo_item.Contains("."))
                    {
                        Item.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(",", "."));
                    }
                    //
                    if (valor_total_apos_desc_acresc.Contains("."))
                    {
                        Item.Valor_Total_Apos_Desc_Acresc = Convert.ToDecimal(valor_total_apos_desc_acresc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Total_Apos_Desc_Acresc = Convert.ToDecimal(valor_total_apos_desc_acresc.Replace(",", "."));
                    }
                    //
                    Item.Cod_Devolucao = Convert.ToInt32(cod_devolucao);
                    //
                    con.Salvar_Itens_Devolucao(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static bool Sel_DFe_Devolucao_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_DFe_Devolucao_Ver(Dev);
                }
            }
        }

        public static void Salvar_Novos_Itens_Devolucao(string item, string cod_produto, string descricao, string quantidade, string um, string vl_unit, string vl_total, string cod_devolucao, string valor_desconto_item, string valor_acrescimo_item, string valor_total_a_desc_acresc)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Dev_Prod Item = new Item_Dev_Prod())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Item = Convert.ToInt16(item);
                    //
                    Item.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Item.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (quantidade.Contains("."))
                    {
                        Item.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Item.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (vl_unit.Contains("."))
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(vl_unit.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(vl_unit.Replace(",", "."));
                    }
                    //
                    if (vl_total.Contains("."))
                    {
                        Item.Valor_Total = Convert.ToDecimal(vl_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Total = Convert.ToDecimal(vl_total.Replace(",", "."));
                    }
                    //
                    Item.Cod_Devolucao = Convert.ToInt32(cod_devolucao);
                    //
                    if (valor_desconto_item.Contains("."))
                    {
                        Item.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo_item.Contains("."))
                    {
                        Item.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(",", "."));
                    }
                    //
                    if (valor_total_a_desc_acresc.Contains("."))
                    {
                        Item.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(",", "."));
                    }
                    //
                    con.Salvar_Novos_Itens_Devolucao(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Dados_Devolucao_A_Finalizar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    //
                    return con.Sel_Dados_Devolucao_A_Finalizar(Dev);
                }
            }
        }

        public static DataTable Sel_Dados_Devolucao(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Dados_Devolucao(Dev);
                }
            }
        }

        public static DataTable Sel_Codigo_Vendas_Dev(string pesquisar, string data_abertura_caixa, string data_atual)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Pesquisar = pesquisar;
                    return con.Sel_Codigo_Vendas_Dev(Vend, data_abertura_caixa.Replace("/", "."), data_atual.Replace("/", "."));
                }
            }
        }

        public static DataTable Sel_Consumidor_Vendas_Dev(string pesquisar, string data_abertura_caixa, string data_atual)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string[] itens = pesquisar.Split('—');
                    Vend.Pesquisar = itens[0];
                    return con.Sel_Consumidor_Vendas_Dev(Vend, data_abertura_caixa.Replace("/", "."), data_atual.Replace("/", "."));
                }
            }
        }

        public static DataTable Sel_Data_Vendas_Dev(string data, string data1, string horario, string horario1, string data_abertura_caixa, string data_atual)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string SqlData;
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
                    return con.Sel_Data_Vendas_Dev(SqlData, data_abertura_caixa.Replace("/", "."), data_atual.Replace("/", "."));
                }
            }
        }


        public static string Sel_Ultima_Devolucao()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ultima_Devolucao();
            }
        }

        public static DataTable Sel_Todas_Vendas_Dev(string data_abertura_caixa, string data_atual)
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Todas_Vendas_Dev(data_abertura_caixa.Replace("/", "."), data_atual.Replace("/", "."));
            }
        }

        public static void Salvar_Todos_Itens_Venda_Dev_Codigo(string codigo, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con1 = new ConOperationBD())
            {
                using (Con7BD con = new Con7BD())
                {
                    using (Venda Pdv = new Venda())
                    {
                        using (Item_Devolucao_Temp Item = new Item_Devolucao_Temp())
                        {
                            Pdv.Codigo = Convert.ToInt32(codigo);
                            //
                            if (con.Sel_Todas_Itens_Venda_Dev_Codigo(Pdv) != null)
                            {
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                                //
                                for (int i = 0; i < con.Sel_Todas_Itens_Venda_Dev_Codigo(Pdv).Rows.Count; i++)
                                {
                                    DataRow dr = con.Sel_Todas_Itens_Venda_Dev_Codigo(Pdv).Rows[i];
                                    //
                                    Item.Codigo = Convert.ToInt16(dr["id_item"]);
                                    Item.Cod_Produto = Convert.ToInt32(dr["id_produto"]);
                                    Item.Descricao = "'" + dr["descricao"].ToString() + "'";
                                    Item.Quantidade = Convert.ToDecimal(dr["quantidade"].ToString().Replace(",", "."));
                                    Item.UM = "'" + dr["um"].ToString() + "'";
                                    Item.Valor_Unitario = Convert.ToDecimal(dr["valor_unitario"]);
                                    Item.Valor_Total = Convert.ToDecimal(dr["valor_total"]);
                                    Item.Valor_Desconto = Convert.ToDecimal(dr["valor_desconto"]);
                                    Item.Valor_Acrescimo = Convert.ToDecimal(dr["valor_acrescimo"]);
                                    Item.Valor_Desconto_Item = Convert.ToDecimal(dr["valor_desconto_item"]);
                                    Item.Valor_Acrescimo_Item = Convert.ToDecimal(dr["valor_acrescimo_item"]);
                                    Item.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(dr["valor_total_a_desc_acresc"]);
                                    Item.Cod_Conexoes_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                                    //
                                    con1.Salvar_Item_Devolucao(Item);
                                }
                                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                            }
                        }
                    }
                }
            }
        }

        public static DataTable Sel_Todas_Itens_Venda_Dev()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Venda Vend = new Venda())
                {
                    return con.Sel_Todas_Itens_Venda_Dev();
                }
            }
        }

        public static bool Sel_Existe_Devolucao(string cod_venda)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Cod_Venda = Convert.ToInt32(cod_venda);
                    return con.Sel_Existe_Devolucao(Dev);
                }
            }
        }

        public static void Excluir_Item_Dev_Prod(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Devolucao_Temp Items = new Item_Devolucao_Temp())
                {
                    Items.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Item_Dev_Prod(Items);
                }
            }
        }

        public static void Salvar_Item_Dev_Prod(string item, string cod_produto, string descricao, string valor_unitario, string um, string quantidade, string desconto_porc, string acrescimo_porc, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Dev_Prod_Temp Items = new Item_Dev_Prod_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (acrescimo_porc.Contains("."))
                    {
                        decimal perc_acresc = Math.Round(Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", ".")) / 100, 2);
                        Items.Valor_Acrescimo_Item = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_acresc = Math.Round(Convert.ToDecimal(acrescimo_porc.Replace(",", ".")) / 100, 2);
                        Items.Valor_Acrescimo_Item = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        decimal perc_desc = Math.Round(Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", ".")) / 100, 2);
                        Items.Valor_Desconto_Item = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_desc = Math.Round(Convert.ToDecimal(desconto_porc.Replace(",", ".")) / 100, 2);
                        Items.Valor_Desconto_Item = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo_Item - Items.Valor_Desconto_Item;
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Salvar_Item_Dev_Prod(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Todos_Itens_Dev_Prod_Temp()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Todos_Itens_Dev_Prod_Temp();
            }
        }

        public static void Atualizar_Item_Dev_Prod(int item_atual, int total_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Devolucao_Temp Items = new Item_Devolucao_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dev_Prod(Items, item.ToString());
                    }
                }
            }
        }

        public static void Alterar_Itens_Devolucao(string item, string quantidade, string valor_unitario, string valor_acrescimo, string valor_desconto, string valor_acrescimo_item, string valor_desconto_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Devolucao_Temp Item = new Item_Devolucao_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Codigo = Convert.ToInt16(item);
                    //
                    if (quantidade.Contains("."))
                    {
                        Item.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    Item.Valor_Total = Item.Valor_Unitario * Item.Quantidade;
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo_item.Contains("."))
                    {
                        Item.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(",", "."));
                    }
                    //
                    if (valor_desconto_item.Contains("."))
                    {
                        Item.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(",", "."));
                    }
                    //
                    Item.Valor_Total_A_Desc_Acresc = (Item.Valor_Unitario * Item.Quantidade) + (Item.Valor_Acrescimo + Item.Valor_Acrescimo_Item) - (Item.Valor_Desconto + Item.Valor_Desconto_Item);
                    //
                    con.Alterar_Itens_Devolucao(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir_Devolucao_Atual(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Devolucao_Temp Dev = new Item_Devolucao_Temp())
                {
                    Dev.Cod_Conexoes_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Devolucao_Atual(Dev);
                }                
            }
        }

        public static decimal Sel_Quantidade_Item_Venda_Dev(string cod_venda)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Pdv = new Venda())
                {
                    Pdv.Codigo = Convert.ToInt32(cod_venda);
                    return con.Sel_Quantidade_Item_Venda_Dev(Pdv);
                }
            }
        }

        public static DataTable Sel_Cliente_Dev()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_Dev();
            }
        }

        public static DataTable Sel_Usuario_Dev()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Dev();
            }
        }

        public static DataTable Sel_Cod_PDV_Dev()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cod_PDV_Dev();
            }
        }

        public static void Excluir_Dev_Prod_Atual(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Devolucao_Temp Dev = new Item_Devolucao_Temp())
                {
                    Dev.Cod_Conexoes_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Dev_Prod_Atual(Dev);
                }
            }
        }

        public static DataTable Sel_Codigo_Dev(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Pesquisar = pesquisar;
                    return con.Sel_Codigo_Dev(Dev);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Devolucao(Dev);
                }
            }
        }

        public static void Excluir_Devolucao_Item_Devolucao(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Devolucao_Item_Devolucao(Dev);
                }
            }
        }

        public static void Excluir_Devolucao_Pagamento(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Devolucao_Pagamento(Dev);
                }
            }
        }

        public static void Excluir_Devolucao_Item_Dev_Prod(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Devolucao_Item_Dev_Prod(Dev);
                }
            }
        }

        public static bool Sel_Devolucao_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Devolucao_Ainda_Existe(Dev);
                }
            }
        }

        public static DataTable Sel_Devolucao_Todos(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string usuario, string cod_pdv_computador, string consumidor, string tipo_devolucao)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;
                //
                string SqlData;
                string SqlUsuario;
                string SqlCodPdvComputador;
                string SqlConsumidor;
                string SqlTipoDevolucao;
                //
                if (data_inicio.Contains("_") || data_fim.Contains("_"))
                {
                    SqlData = "WHERE data BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = "";
                    }
                    else
                    {
                        hora_inicio = " " + hora_inicio;
                    }
                    //
                    if (hora_fim.Contains("_"))
                    {
                        hora_fim = " 23:59:59";
                    }
                    else
                    {
                        hora_fim = " " + hora_fim;
                    }
                    //
                    SqlData = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND id_usuario=" + items[0];
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (consumidor == "")
                {
                    SqlConsumidor = "";
                }
                else
                {
                    items = consumidor.Split('—');
                    SqlConsumidor = " AND id_consumidor=" + items[0];
                }
                //
                if (tipo_devolucao == "")
                {
                    SqlTipoDevolucao = "";
                }
                else
                {
                    SqlTipoDevolucao = " AND tipo='" + tipo_devolucao + "'";
                }
                //
                return con.Sel_Devolucao_Todos(SqlData, SqlUsuario, SqlCodPdvComputador, SqlConsumidor, SqlTipoDevolucao);
            }
        }

        public static DataTable Sel_Devolucao_Cod_Venda(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string usuario, string cod_pdv_computador, string consumidor, string tipo_devolucao, string cod_venda)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;
                //
                string SqlVenda;
                string SqlData;
                string SqlUsuario;
                string SqlCodPdvComputador;
                string SqlConsumidor;
                string SqlTipoDevolucao;
                //
                SqlVenda = "WHERE id_venda=" + cod_venda;
                //
                if (data_inicio.Contains("_") || data_fim.Contains("_"))
                {
                    SqlData = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = "";
                    }
                    else
                    {
                        hora_inicio = " " + hora_inicio;
                    }
                    //
                    if (hora_fim.Contains("_"))
                    {
                        hora_fim = " 23:59:59";
                    }
                    else
                    {
                        hora_fim = " " + hora_fim;
                    }
                    //
                    SqlData = " AND data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND id_usuario=" + items[0];
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (consumidor == "")
                {
                    SqlConsumidor = "";
                }
                else
                {
                    items = consumidor.Split('—');
                    SqlConsumidor = " AND id_consumidor=" + items[0];
                }
                //
                if (tipo_devolucao == "")
                {
                    SqlTipoDevolucao = "";
                }
                else
                {
                    SqlTipoDevolucao = " AND tipo='" + tipo_devolucao + "'";
                }
                //
                return con.Sel_Devolucao_Cod_Venda(SqlData, SqlUsuario, SqlCodPdvComputador, SqlConsumidor, SqlTipoDevolucao, SqlVenda);
            }
        }

        public static DataTable Sel_Itens_Devolucao(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Itens_Devolucao(Dev);
                }
            }
        }

        public static DataTable Sel_Itens_Prod_Devolucao(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Itens_Prod_Devolucao(Dev);
                }
            }
        }

        public static string Calculo_Desconto(string valor_documento, string desconto_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(desconto_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Valor_Item_Dev(string preco, string quantidade)
        {
            decimal valor = Convert.ToDecimal(preco);
            decimal qtde = Convert.ToDecimal(quantidade);
            valor = valor * qtde;
            return Math.Round(valor, 2).ToString();
        }

        public static string Calculo_ValorDesconto(string valor_documento, string valor_desconto)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal retorno = (desconto) / valor * 100;
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Acrescimo(string valor_documento, string acrescimo_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(acrescimo_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_ValorAcrescimo(string valor_documento, string valor_acrescimo)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal desconto = Convert.ToDecimal(valor_acrescimo);
            decimal retorno = (desconto) / valor * 100;
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Valor_Item_Desc_Acresc_Dev(string preco, string valor_desconto, string valor_acrescimo, string quantidade)
        {
            if (valor_desconto == "")
            {
                valor_desconto = "0,00";
            }
            //
            if (valor_acrescimo == "")
            {
                valor_acrescimo = "0,00";
            }
            //
            decimal valor = Convert.ToDecimal(preco);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal acrescimo = Convert.ToDecimal(valor_acrescimo);
            decimal qtde = Convert.ToDecimal(quantidade);
            valor = ((valor + acrescimo) - desconto) * qtde;
            return Math.Round(valor, 2).ToString();
        }

        public static void Salvar_Pagamento_Devolucao(string item, string cod_pagamento, string tipo_forma_pagamento, string valor_devolucao, string cod_devolucao, string data, string hora, string usuario, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_Devolucao Pgto = new Pagamento_Devolucao())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Pgto.Cod_Item_Devolucao = Convert.ToInt16(item);
                    //
                    Pgto.Cod_Pagamento = Convert.ToInt16(cod_pagamento);
                    //
                    Pgto.Tipo = tipo_forma_pagamento.Insert(tipo_forma_pagamento.Length, "'").Insert(0, "'");
                    //
                    if (valor_devolucao.Contains("."))
                    {
                        Pgto.Valor_Devolucao = Convert.ToDecimal(valor_devolucao.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Pgto.Valor_Devolucao = Convert.ToDecimal(valor_devolucao.Replace(",", "."));
                    }
                    //
                    Pgto.Cod_Devolucao = Convert.ToInt32(cod_devolucao);
                    //
                    Pgto.Data_Devolucao = "'" + data.Replace("/", ".") + " " + hora + "'";
                    //
                    Pgto.Hora_Devolucao = hora.Insert(hora.Length, "'").Insert(0, "'");
                    //
                    string[] items;
                    items = usuario.Replace("Usuário(a): ", "").Split('—');
                    Pgto.Cod_Usuario = Convert.ToInt16(items[0]);
                    Pgto.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Pgto.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", ""));
                    //
                    con.Salvar_Pagamento_Devolucao(Pgto);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Formas_Pagamento_Devolucao(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    Dev.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Formas_Pagamento_Devolucao(Dev);
                }
            }
        }

        public static void Alterar_Estoque_Produto_Devolucao(string codigo, string quantidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (quantidade.Contains("."))
                    {
                        Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) + Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) + Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    con.Alterar_Estoque_Produto_Devolucao(Prod);
                }
            }
        }
    }
}

