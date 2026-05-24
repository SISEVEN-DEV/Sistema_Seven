using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Threading;

namespace BLL
{
    public class bllOrcamento
    {
        public static bool _FrmRelOrcamento_Ativo;
        public static bool _FrmOrcamento_Ativo;

        public static string _Orc_PesqConsumidor_Tabela;
        public static string _Orc_PesqUsuario_Tabela;
        public static string _Orc_PesqProduto_Tabela;
        public static string _Orc_PesqFuncionario_Tabela;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        public static string _Celular_CadCelular_Tabela;

        public static string _Quantidade;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Acrescimo_Porc;
        public static string _Valor_Acrescimo;
        public static string _Desconto_Porc;
        public static string _Valor_Desconto;
        public static string _Valor_Real;
        public static byte _Tipo_Envio;

        public static string _Orc_PesqCompPDV_Tabela;

        public static DataTable Sel_Cliente_Orc()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_Orc();
            }
        }

        public static DataTable Sel_Usuario_Orc()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Orc();
            }
        }

        public static DataTable Sel_Cod_PDV_Orc()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cod_PDV_Orc();
            }
        }

        public static void Alterar_CPF_CNPJ_Orcamento(string codigo, string cpf_cnpj)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                    Orc.CPF_CNPJ_Consumidor = cpf_cnpj.Insert(cpf_cnpj.Length, "'").Insert(0, "'");
                    //
                    using (ClieCons Clie = new ClieCons())
                    {
                        Clie.Pesquisar = cpf_cnpj;
                        if (con.Sel_Clie_CPFCNPJ(Clie) == null)
                        {
                            Orc.Cod_Consumidor = 0;
                            Orc.Nome_Consumidor = "null";

                        }
                        else
                        {
                            DataRow dr = con.Sel_Clie_CPFCNPJ(Clie).Rows[0];
                            Orc.Cod_Consumidor = Convert.ToInt32(dr["id_cliente"]);
                            Orc.Nome_Consumidor = "'" + dr["nome"].ToString() + "'";
                        }
                        con.Alterar_CPF_CNPJ_Orcamento(Orc);
                    }
                }
            }
        }

        public static void Salvar(string cliente, string usuario, string validade, string observacao, string valor_total, string cod_pdv_computador, string valor_total_real, string valor_desconto_item, string valor_acrescimo_item, string hora_validade, string desconto_porc, string acrescimo_porc, string valor_desconto, string valor_acrescimo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items;
                    if (cliente == "")
                    {
                        Orc.Cod_Consumidor = 0;
                        Orc.Nome_Consumidor = "null";
                        Orc.CPF_CNPJ_Consumidor = "null";
                    }
                    else
                    {
                        items = cliente.Split('—');
                        Orc.Cod_Consumidor = Convert.ToInt32(items[0]);
                        Orc.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                        //
                        if (items.Length > 2)
                        {
                            Orc.CPF_CNPJ_Consumidor = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                        }
                        else
                        {
                            Orc.CPF_CNPJ_Consumidor = "null";
                        }
                    }
                    //
                    items = usuario.Replace("Usuário(a): ", "").Split('—');
                    Orc.Cod_Usuario = Convert.ToInt16(items[0]);
                    Orc.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Orc.Hora = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    if (hora_validade == "" || hora_validade == "  :  :" || hora_validade == "__:__:__")
                    {
                        Orc.Hora_Validade = "null";
                    }
                    else
                    {
                        Orc.Hora_Validade = hora_validade.Insert(hora_validade.Length, "'").Insert(0, "'");
                    }
                    //
                    Orc.Data = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss").Trim() + "'";
                    //
                    if (validade == "" || validade == "  /  /" || validade == "__/__/____")
                    {
                        Orc.Data_Validade = "null";
                    }
                    else
                    {
                        if (Orc.Hora_Validade == "null")
                        {
                            Orc.Data_Validade = "'" + validade.Replace('/', '.') + " 23:59:59'";
                        }
                        else
                        {
                            Orc.Data_Validade = "'" + validade.Replace('/', '.') + " " + hora_validade + "'";
                        }
                    }
                    //
                    if (observacao == "")
                    {
                        Orc.Observacao = "null";
                    }
                    else
                    {
                        Orc.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (valor_total.Contains("."))
                    {
                        Orc.Valor_Total = Convert.ToDecimal(valor_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Orc.Valor_Total = Convert.ToDecimal(valor_total.Replace(",", "."));
                    }
                    //
                    if (valor_total_real.Contains("."))
                    {
                        Orc.Valor_Total_Real = Convert.ToDecimal(valor_total_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Orc.Valor_Total_Real = Convert.ToDecimal(valor_total_real.Replace(",", "."));
                    }
                    //
                    items = cod_pdv_computador.Split('/');
                    Orc.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    Orc.Situacao = "'PENDENTE'";
                    //
                    if (valor_acrescimo_item.Contains("."))
                    {
                        Orc.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Orc.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(",", "."));
                    }
                    //
                    if (valor_desconto_item.Contains("."))
                    {
                        Orc.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Orc.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Orc.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Orc.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Orc.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Orc.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (acrescimo_porc.Contains("."))
                    {
                        Orc.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Orc.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(",", "."));
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        Orc.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Orc.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", "."));
                    }
                    //
                    con.Salvar_Orcamento(Orc);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Situacao_Orcamento(string codigo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                    //
                    Orc.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Situacao_Orcamento(Orc);
                }
            }
        }

        public static bool Sel_Situacao_Orc(string situacao, string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                    Orc.Situacao = situacao;
                    return con.Sel_Situacao_Orc(Orc);
                }
            }
        }

        public static void Excluir_Cab_Orcamento_Operation(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    Dado.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);

                    con.Excluir_Cab_Orcamento_Operation(Dado);
                }
            }
        }

        public static DataTable Sel_Dados_Orcamento_A_Finalizar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Dados_Orcamento_A_Finalizar();
            }
        }

        public static DataTable Sel_Dados_Orcamento(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Dados_Orcamento(Orc);
                }
            }
        }

        public static void Salvar_Itens_Orc_Operation(string item, string cod_produto, string descricao, string quantidade, string um, string vl_unit, string desconto_porc, string acrescimo_porc, string cod_conexao_configuracoes, byte tabela)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Orc_Temp Items = new Item_Orc_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Item_Orc = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
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
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (vl_unit.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(vl_unit.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(vl_unit.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    if (acrescimo_porc.Contains("."))
                    {
                        decimal perc_acresc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", ".")) / 100;
                        Items.Valor_Acrescimo_Item = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_acresc = Convert.ToDecimal(acrescimo_porc.Replace(",", ".")) / 100;
                        Items.Valor_Acrescimo_Item = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        decimal perc_desc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", ".")) / 100;
                        Items.Valor_Desconto_Item = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_desc = Convert.ToDecimal(desconto_porc.Replace(",", ".")) / 100;
                        Items.Valor_Desconto_Item = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo_Item - Items.Valor_Desconto_Item;
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    Items.Tabela = tabela;
                    //
                    con.Salvar_Itens_Orc_Operation(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Itens_Orc_Operation_Direto(string item, string cod_produto, string descricao, string quantidade, string um, string vl_unit, string valor_desconto_item, string valor_acrescimo_item, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Orc_Temp Items = new Item_Orc_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Item_Orc = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
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
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (vl_unit.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(vl_unit.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(vl_unit.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    if (valor_acrescimo_item.Contains("."))
                    {
                        Items.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(",", "."));
                    }
                    //
                    if (valor_desconto_item.Contains("."))
                    {
                        Items.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo_Item - Items.Valor_Desconto_Item;
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Salvar_Itens_Orc_Operation(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Orcamento(Orc);
                }
            }
        }

        public static void Salvar_Itens_Orc(string item, string cod_item_orc, string descricao, string quantidade, string um, string vl_unit, string valor_total, string cod_orc, string valor_desconto_item, string valor_acrescimo_item, string desconto_orc, string valor_desconto_orc, bool ultimo_item, bool primeiro_item, string acrescimo_orc, string valor_acrescimo_orc, byte tabela)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Orc Item = new Item_Orc())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Orcamento = Convert.ToInt32(cod_orc);
                    //
                    Item.Cod_Item = Convert.ToInt16(item);
                    //
                    Item.Cod_Item_Orc = Convert.ToInt32(cod_item_orc);
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
                    if (valor_total.Contains("."))
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total.Replace(",", "."));
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
                    if (Convert.ToDecimal(desconto_orc) == 0)
                    {
                        Item.Valor_Desconto = 0;
                    }
                    else
                    {
                        if (desconto_orc.Contains("."))
                        {
                            desconto_orc = desconto_orc.Replace(".", "").Replace(",", ".");
                        }
                        else
                        {
                            desconto_orc = desconto_orc.Replace(",", ".");
                        }
                        //
                        if (valor_desconto_orc.Contains("."))
                        {
                            valor_desconto_orc = valor_desconto_orc.Replace(".", "").Replace(",", ".");
                        }
                        else
                        {
                            valor_desconto_orc = valor_desconto_orc.Replace(",", ".");
                        }
                        //
                        if (con.Sel_Valor_Desc_Valor_Acresc_Item_Orc(Item) != null)
                        {
                            DataRow dr;
                            decimal valordescitems = 0;
                            //
                            for (int i = 0; i < con.Sel_Valor_Desc_Valor_Acresc_Item_Orc(Item).Rows.Count; i++)
                            {
                                dr = con.Sel_Valor_Desc_Valor_Acresc_Item_Orc(Item).Rows[i];
                                valordescitems += Convert.ToDecimal(dr["valor_desconto"].ToString());
                            }
                            //
                            if (valordescitems < Convert.ToDecimal(valor_desconto_orc))
                            {
                                if (ultimo_item == true & primeiro_item == false)
                                {
                                    decimal valor_total_desconto = Convert.ToDecimal(valor_desconto_orc) - valordescitems;

                                    Item.Valor_Desconto = valor_total_desconto;
                                }
                                else
                                {
                                    decimal percentual = Convert.ToDecimal(desconto_orc) / 100;
                                    //
                                    Item.Valor_Desconto = Math.Round(percentual * Item.Valor_Total, 2);
                                }
                            }
                        }
                        else
                        {
                            if (primeiro_item == true & ultimo_item == false)
                            {
                                Item.Valor_Desconto = Convert.ToDecimal(valor_desconto_orc);
                            }
                            else
                            {
                                decimal percentual = Convert.ToDecimal(desconto_orc) / 100;
                                //
                                Item.Valor_Desconto = Math.Round(percentual * Item.Valor_Total, 2);
                            }
                        }
                    }
                    //
                    if (Convert.ToDecimal(acrescimo_orc) == 0)
                    {
                        Item.Valor_Acrescimo = 0;
                    }
                    else
                    {
                        if (acrescimo_orc.Contains("."))
                        {
                            acrescimo_orc = acrescimo_orc.Replace(".", "").Replace(",", ".");
                        }
                        else
                        {
                            acrescimo_orc = acrescimo_orc.Replace(",", ".");
                        }
                        //
                        if (valor_acrescimo_orc.Contains("."))
                        {
                            valor_acrescimo_orc = valor_acrescimo_orc.Replace(".", "").Replace(",", ".");
                        }
                        else
                        {
                            valor_acrescimo_orc = valor_acrescimo_orc.Replace(",", ".");
                        }
                        //
                        if (con.Sel_Valor_Desc_Valor_Acresc_Item_Orc(Item) != null)
                        {
                            DataRow dr;
                            decimal valoracrescitems = 0;
                            //
                            for (int i = 0; i < con.Sel_Valor_Desc_Valor_Acresc_Item_Orc(Item).Rows.Count; i++)
                            {
                                dr = con.Sel_Valor_Desc_Valor_Acresc_Item_Orc(Item).Rows[i];
                                valoracrescitems += Convert.ToDecimal(dr["valor_acrescimo"].ToString());
                            }
                            //
                            if (valoracrescitems < Convert.ToDecimal(valor_acrescimo_orc))
                            {
                                if (ultimo_item == true & primeiro_item == false)
                                {
                                    decimal valor_total_acrescimo = Convert.ToDecimal(valor_acrescimo_orc) - valoracrescitems;
                                    Item.Valor_Acrescimo = valor_total_acrescimo;
                                }
                                else
                                {
                                    decimal percentual = Convert.ToDecimal(acrescimo_orc) / 100;
                                    //
                                    Item.Valor_Acrescimo = Math.Round(percentual * Item.Valor_Total, 2);
                                }
                            }
                        }
                        else
                        {
                            if (primeiro_item == true & ultimo_item == false)
                            {
                                Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo_orc);
                            }
                            else
                            {
                                decimal percentual = Convert.ToDecimal(acrescimo_orc) / 100;
                                //
                                Item.Valor_Acrescimo = Math.Round(percentual * Item.Valor_Total, 2);
                            }
                        }
                    }
                    //
                    Item.Tabela = tabela;
                    //
                    Item.Valor_Total_A_Desc_Acresc = Item.Valor_Total + Item.Valor_Acrescimo - Item.Valor_Desconto + Item.Valor_Acrescimo_Item - Item.Valor_Desconto_Item;
                    //
                    con.Salvar_Itens_Orcamento(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Desconto_Acrescimo_Orcamento(string codigo, string cod_item)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Orc Item = new Item_Orc())
                {
                    Item.Cod_Orcamento = Convert.ToInt32(codigo);
                    Item.Cod_Item = Convert.ToInt16(cod_item);
                    return con.Sel_Desconto_Acrescimo_Orcamento(Item);
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

        public static string Calculo_Valor_Item_Orc(string preco, string quantidade)
        {
            decimal valor = Convert.ToDecimal(preco);
            decimal qtde = Convert.ToDecimal(quantidade);
            valor = valor * qtde;
            return Math.Round(valor, 2).ToString();
        }

        public static string Calculo_Valor_Item_Desc_Acresc_Orc(string preco, string valor_desconto, string valor_acrescimo)
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
            valor = valor + acrescimo - desconto;
            return valor.ToString();
        }

        public static string Calculo_Valor_Desc_Acresc_Orc(string preco, string valor_desconto, string valor_acrescimo)
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
            valor = ((valor + acrescimo) - desconto);
            return Math.Round(valor, 2).ToString();
        }

        public static void Excluir_Orc_Atual(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Orc_Temp item = new Item_Orc_Temp())
                {
                    item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    
                    con.Excluir_Orc_Atual(item);
                }
            }
        }

        public static DataTable Sel_Item_Orc_Todos(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Orc_Temp Item = new Item_Orc_Temp())
                {
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Item_Orc_Todos(Item);
                }
            }
        }

        public static DataTable Sel_Cab_Orcamento_Todos(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    Dado.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Cab_Orcamento_Todos(Dado);
                }
            }
        }

        public static void Atualizar_Item_Dt_Prod(int item_atual, int total_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Orc Items = new Item_Orc())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dt_Prod(Items, item.ToString());
                    }
                }
            }
        }

        public static void Excluir_Item(string cod_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Orc Items = new Item_Orc())
                {
                    Items.Codigo = Convert.ToInt16(cod_item);
                    con.Excluir_Item_Orc(Items);
                }
            }
        }

        public static DataTable Sel_Itens_Orcamento_Orc(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Itens_Orcamento_Orc(Orc);
                }
            }
        }

        public static void Excluir_Item_Orcamento(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Orc Orc = new Item_Orc())
                {
                    Orc.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Item_Orcamento(Orc);
                }
            }
        }

        public static bool Sel_Orcamento_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Orcamento_Ainda_Existe(Orc);
                }
            }
        }

        public static DataTable Sel_DataCad_DataVal_Usuario_Consumidor_Orc_Todos(string data_cad, string data_cad1, string data_val, string data_val1, string usuario, string consumidor, string hora, string hora1, string situacao, string hora_val, string hora_val1, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;
                    string SqlDataCad;
                    string SqlDataVal;
                    string SqlUsusario;
                    string SqlConsumidor;
                    string SqlSituacao;
                    string SqlCodPdvComputador;
                    //
                    if (data_cad.Contains("_") || data_cad1.Contains("_"))
                    {
                        SqlDataCad = "WHERE data BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                    }
                    else
                    {
                        if (hora.Contains("_"))
                        {
                            hora = " 00:00:00";
                        }
                        else
                        {
                            hora = " " + hora;
                        }
                        //
                        if (hora1.Contains("_"))
                        {
                            hora1 = " 23:59:59";
                        }
                        else
                        {
                            hora1 = " " + hora1;
                        }
                        //
                        SqlDataCad = "WHERE data BETWEEN '" + data_cad.Replace("/", ".") + hora + "' AND '" + data_cad1.Replace("/", ".") + hora1 + "'";
                    }
                    //
                    if (data_val.Contains("_") || data_val1.Contains("_"))
                    {
                        SqlDataVal = "";
                    }
                    else
                    {
                        if (hora_val.Contains("_"))
                        {
                            hora_val = " 00:00:00";
                        }
                        else
                        {
                            hora_val = " " + hora_val;
                        }
                        //
                        if (hora_val1.Contains("_"))
                        {
                            hora_val1 = " 23:59:59";
                        }
                        else
                        {
                            hora_val1 = " " + hora_val1;
                        }
                        //
                        SqlDataVal = " AND data_validade BETWEEN '" + data_val.Replace("/", ".") + hora_val + "' AND '" + data_val1.Replace("/", ".") + hora_val1 + "'";
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsusario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsusario = " AND id_usuario=" + items[0];
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
                    if (situacao == "")
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
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
                    return con.Sel_DataCad_DataVal_Usuario_Consumidor_Orc_Todos(SqlDataCad, SqlDataVal, SqlUsusario, SqlConsumidor, SqlSituacao, SqlCodPdvComputador);
                }
            }
        }

        public static DataTable Sel_Orcamento_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Pesquisar = pesquisar;
                    return con.Sel_Orcamento_Codigo(Orc);
                }
            }
        }

        public static DataTable Sel_Orcamento_Consumidor(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    string[] itens = pesquisar.Split('—');
                    Orc.Pesquisar = itens[0];
                    return con.Sel_Orcamento_Consumidor(Orc);
                }
            }
        }

        public static DataTable Sel_Orcamento_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Orcamento_Todos();
            }
        }

        public static DataTable Sel_Orcamento_Data_Cadastro(string data, string data1)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                SqlData = "WHERE data BETWEEN '" + data.Replace('/', '.') + " 00:00:00' AND '" + data1.Replace('/', '.') + " 23:59:59'";
                return con.Sel_Orcamento_Data_Criacao(SqlData);
            }
        }

        public static bool Sel_Cod_Produto_Existe_Orc(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Orc_Temp Orc = new Item_Orc_Temp())
                {
                    Orc.Cod_Item_Orc = Convert.ToInt32(codigo);
                    //
                    return con.Sel_Cod_Produto_Existe_Orc(Orc);
                }
            }
        }

        public static bool Sel_Cod_Servico_Existe_Orc(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Orc_Temp Orc = new Item_Orc_Temp())
                {
                    Orc.Cod_Item_Orc = Convert.ToInt32(codigo);
                    //
                    return con.Sel_Cod_Servico_Existe_Orc(Orc);
                }
            }
        }

        public static void Alterar_Dados_Orcamento_PDV(string consumidor, string data_validade, string horario_validade, string observacao, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    if (consumidor == "" || consumidor == null)
                    {
                        Dado.Cod_Consumidor_Orc = 0;
                        //
                        Dado.Nome_Consumidor_Orc = "null";
                        //
                        Dado.CPF_CNPJ_Consumidor_Orc = "null";
                    }
                    else
                    {
                        string[] items = consumidor.Split('—');

                        Dado.Cod_Consumidor_Orc = Convert.ToInt32(items[0]);
                        //
                        Dado.Nome_Consumidor_Orc = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                        //
                        if (items.Length > 2)
                        {
                            Dado.CPF_CNPJ_Consumidor_Orc = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                        }
                        else
                        {
                            Dado.CPF_CNPJ_Consumidor_Orc = "null";
                        }
                    }
                    //
                    if (horario_validade == "" || horario_validade == "  :  :" || horario_validade == "__:__:__" || horario_validade == null)
                    {
                        Dado.Horario_Validade = "null";
                    }
                    else
                    {
                        Dado.Horario_Validade = horario_validade.Insert(horario_validade.Length, "'").Insert(0, "'");
                    }
                    //
                    if (data_validade == "" || data_validade == "  /  /" || data_validade == "__/__/____" || data_validade == null)
                    {
                        Dado.Data_Validade = "null";
                    }
                    else
                    {
                        if (Dado.Horario_Validade == "null")
                        {
                            Dado.Data_Validade = "'" + data_validade.Replace('/', '.') + " 00:00:00'";
                        }
                        else
                        {
                            Dado.Data_Validade = "'" + data_validade.Replace('/', '.') + " " + horario_validade + "'";
                        }
                    }
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Dado.Observacao_Orc = "null";
                    }
                    else
                    {
                        Dado.Observacao_Orc = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    Dado.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Alterar_Dados_Orcamento_PDV(Dado);
                }
            }
        }

        public static bool Sel_Situacao_Orcamento(string codigo, string tipo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                    Orc.Situacao = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    return con.Sel_Situacao_Orcamento(Orc);
                }
            }
        }

        public static DataTable Sel_Cod_Orcamento_Existe_PDV(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                    //
                    return con.Sel_Cod_Orcamento_Existe_PDV(Orc);
                }
            }
        }

        public static bool Sel_Data_Validade_Orc_PDV(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                    //
                    DataRow dr = con.Sel_Data_Validade_Orc_PDV(Orc).Rows[0];
                    //
                    if (dr["data_validade"].ToString() == "")
                    {
                        return true;
                    }
                    else
                    {
                        if (Convert.ToDateTime(dr["data_validade"]) < DateTime.Now)
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
        }
    }
}
