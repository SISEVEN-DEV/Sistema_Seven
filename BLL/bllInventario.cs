using DAL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;


namespace BLL //AllocationRequest
{
    public class bllInventario
    {
        public static bool _FrmInventario_Ativo;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        public static string _Inv_Prod_PesqProd_Tabela;
        public static string _Localizacao_PesqLocalizacao_Tabela;
        public static string _Multiplicador;
        public static bool _Tipo;
        public static string _Grupo;
        public static string _SubGrupo;

        public static void Salvar(string data, string data1, string descricao, string localizacao, bool inv_contabil)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Inventario Inv = new Inventario())
                {
                    Inv.Data_Inicial = data.Insert(data.Length, "'").Insert(0, "'").Replace('/', '.');
                    //
                    Inv.Data_Final = data1.Insert(data1.Length, "'").Insert(0, "'").Replace('/', '.');
                    //
                    if (descricao == null || descricao == "")
                    {
                        Inv.Descricao = "null";
                    }
                    else
                    {
                        Inv.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    }
                    //
                    Inv.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    if (localizacao == null || localizacao == "")
                    {
                        Inv.Cod_Localizacao = 0;
                        Inv.Desc_Localizacao = "null";
                    }
                    else
                    {
                        string[] items = localizacao.Split('—');
                        Inv.Cod_Localizacao = Convert.ToInt16(items[0]);
                        Inv.Desc_Localizacao = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (inv_contabil == true)
                    {
                        Inv.Inv_Contabil = 1;
                    }
                    else
                    {
                        Inv.Inv_Contabil = 0;
                    }
                    //
                    con.Salvar_Inventario(Inv);
                }
            }
        }

        public static void Alterar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Inventario Inv = new Inventario())
                {
                    Inv.Codigo = Convert.ToInt32(codigo); 
                    //
                    con.Alterar_Inventario(Inv);
                }
            }
        }

        public static DataTable Sel_Localizacao_Inv()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Localizacao_Inv();
            }
        }

        public static void Salvar_Item_Inventario(string produto, string inv_saldo_atual, string inv_custo_medio_atual, string inv_total_atual, string um, string ncm, string cod_inventario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] itens = produto.Split('—');
                    //
                    Inv.Cod_Produto = Convert.ToInt32(itens[0]);
                    //
                    Inv.Descricao = itens[1].Insert(itens[1].Length, "'").Insert(0, "'");
                    //
                    Inv.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (inv_saldo_atual.Contains("."))
                    {
                        Inv.Inv_Saldo_Atual = Convert.ToDecimal(inv_saldo_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Saldo_Atual = Convert.ToDecimal(inv_saldo_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (inv_total_atual.Contains("."))
                    {
                        Inv.Inv_Total_Atual = Convert.ToDecimal(inv_total_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Total_Atual = Convert.ToDecimal(inv_total_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (inv_custo_medio_atual.Contains("."))
                    {
                        Inv.Inv_Custo_Medio_Atual = Convert.ToDecimal(inv_custo_medio_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Custo_Medio_Atual = Convert.ToDecimal(inv_custo_medio_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    Inv.Quantidade = 0;
                    //
                    Inv.Total_Medio = 0;
                    //
                    Inv.Custo_Medio = 0;
                    //
                    Inv.Ult_Quantidade = 0;
                    //
                    Inv.Ult_Custo = 0;
                    //
                    Inv.Ult_Total = 0;
                    //
                    Inv.NCM = ncm.Insert(ncm.Length, "'").Insert(0, "'");
                    //
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    con.Salvar_Item_Inventario(Inv);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Item_Novo_Inventario(string produto, string inv_saldo_atual, string quantidade, string total_medio, string ult_quantidade, string total, string valor_desconto, string valor_acrescimo, string um, string ncm, string cod_inventario, string icms, string icms_st, string ipi)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    decimal valor;
                    string[] itens = produto.Split('—');
                    //
                    Inv.Cod_Produto = Convert.ToInt32(itens[0]);
                    //
                    Inv.Descricao = itens[1].Insert(itens[1].Length, "'").Insert(0, "'");
                    //
                    Inv.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (inv_saldo_atual.Contains("."))
                    {
                        Inv.Inv_Saldo_Atual = Convert.ToDecimal(inv_saldo_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Saldo_Atual = Convert.ToDecimal(inv_saldo_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Inv.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Quantidade = Convert.ToDecimal(quantidade.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (total_medio.Contains("."))
                    {
                        Inv.Total_Medio = Convert.ToDecimal(total_medio.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", ".")) - Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(icms.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(icms_st.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(ipi.Replace(".", "").Replace(",", ".")); ;
                    }
                    else
                    {
                        Inv.Total_Medio = Convert.ToDecimal(total_medio.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", "")) + Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", ".")) - Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(icms.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(icms_st.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(ipi.Replace(".", "").Replace(",", ".")); ;
                    }
                    //
                    if (Inv.Quantidade != 0 & Inv.Total_Medio != 0)
                    {
                        valor = Inv.Total_Medio / Inv.Quantidade;
                        Inv.Custo_Medio = Math.Round(valor, 2);
                    }
                    else
                    {
                        Inv.Custo_Medio = 0;
                    }
                    //
                    Inv.Inv_Custo_Medio_Atual = Inv.Custo_Medio;
                    //
                    Inv.Inv_Total_Atual = Inv.Inv_Saldo_Atual * Inv.Inv_Custo_Medio_Atual;
                    //
                    if (ult_quantidade.Contains("."))
                    {
                        Inv.Ult_Quantidade = Convert.ToDecimal(ult_quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Ult_Quantidade = Convert.ToDecimal(ult_quantidade.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (total.Contains("."))
                    {
                        Inv.Ult_Custo = Convert.ToDecimal(total.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", ".")) - Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(icms.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(icms_st.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(ipi.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Ult_Custo = Convert.ToDecimal(total.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", "")) + Convert.ToDecimal(valor_acrescimo.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", "")) - Convert.ToDecimal(valor_desconto.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", "")) + Convert.ToDecimal(icms.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(icms_st.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(ipi.Replace(".", "").Replace(",", "."));
                    }
                    valor = Inv.Ult_Quantidade * Inv.Ult_Custo;
                    Inv.Ult_Total = Math.Round(valor, 2);
                    //
                    Inv.NCM = ncm.Insert(ncm.Length, "'").Insert(0, "'");
                    //
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    con.Salvar_Item_Novo_Inventario(Inv);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static bool Val_Inv_Prod(string produto, string cod_inventario, string um)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    string[] items = produto.Split('—');
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    Inv.Cod_Produto = Convert.ToInt32(items[0]);
                    Inv.UM = um;
                    return con.Val_Inv_Prod(Inv);
                }
            }
        }

        public static bool Val_Inv_Prod_Alt(string codigo, string produto, string cod_inventario, string um)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Inv.Codigo = Convert.ToInt32(codigo);
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    Inv.UM = um;
                    //
                    string[] items = produto.Split('—');
                    Inv.Cod_Produto = Convert.ToInt32(items[0]);
                    if (con.Val_Inv_Prod_Alt(Inv) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Inv_Prod_Alt(Inv) == 0)
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

        public static void Alterar_Item_Inventario(string produto, string inv_saldo_atual, string inv_custo_medio_atual, string inv_total_atual, string um, string ncm, string cod_inventario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] itens = produto.Split('—');
                    //
                    Inv.Cod_Produto = Convert.ToInt32(itens[0]);
                    //
                    Inv.Descricao = itens[1].Insert(itens[1].Length, "'").Insert(0, "'");
                    //
                    Inv.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (inv_saldo_atual.Contains("."))
                    {
                        Inv.Inv_Saldo_Atual = Convert.ToDecimal(inv_saldo_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Saldo_Atual = Convert.ToDecimal(inv_saldo_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (inv_total_atual.Contains("."))
                    {
                        Inv.Inv_Total_Atual = Convert.ToDecimal(inv_total_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Total_Atual = Convert.ToDecimal(inv_total_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (inv_custo_medio_atual.Contains("."))
                    {
                        Inv.Inv_Custo_Medio_Atual = Convert.ToDecimal(inv_custo_medio_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Custo_Medio_Atual = Convert.ToDecimal(inv_custo_medio_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    Inv.NCM = ncm.Insert(ncm.Length, "'").Insert(0, "'");
                    //
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    con.Alterar_Item_Inventario(Inv);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Item_Novo_Inventario(string produto, string inv_saldo_atual, string quantidade, string total_medio, string ult_quantidade, string total, string valor_desconto, string valor_acrescimo, string um, string ncm, string cod_inventario, string icms, string icms_st, string ipi)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    decimal valor;
                    string[] itens = produto.Split('—');
                    //
                    Inv.Cod_Produto = Convert.ToInt32(itens[0]);
                    //
                    Inv.Descricao = itens[1].Insert(itens[1].Length, "'").Insert(0, "'");
                    //
                    Inv.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (inv_saldo_atual.Contains("."))
                    {
                        Inv.Inv_Saldo_Atual = Convert.ToDecimal(inv_saldo_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Saldo_Atual = Convert.ToDecimal(inv_saldo_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Inv.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Quantidade = Convert.ToDecimal(quantidade.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (total_medio.Contains("."))
                    {
                        Inv.Total_Medio = Convert.ToDecimal(total_medio.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Total_Medio = Convert.ToDecimal(total_medio.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (Inv.Quantidade != 0 & Inv.Total_Medio != 0)
                    {
                        valor = Inv.Total_Medio / Inv.Quantidade;
                        Inv.Custo_Medio = Math.Round(valor, 2);
                    }
                    else
                    {
                        Inv.Custo_Medio = 0;
                    }
                    //
                    Inv.Inv_Custo_Medio_Atual = Inv.Custo_Medio;
                    //
                    Inv.Inv_Total_Atual = Inv.Inv_Saldo_Atual * Inv.Inv_Custo_Medio_Atual;
                    //
                    if (ult_quantidade.Contains("."))
                    {
                        Inv.Ult_Quantidade = Convert.ToDecimal(ult_quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Ult_Quantidade = Convert.ToDecimal(ult_quantidade.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (total.Contains("."))
                    {
                        Inv.Ult_Custo = Convert.ToDecimal(total.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", ".")) - Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(icms.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(icms_st.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(ipi.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Ult_Custo = Convert.ToDecimal(total.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", "")) + Convert.ToDecimal(valor_acrescimo.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", "")) - Convert.ToDecimal(valor_desconto.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", "")) + Convert.ToDecimal(icms.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(icms_st.Replace(".", "").Replace(",", ".")) + Convert.ToDecimal(ipi.Replace(".", "").Replace(",", "."));
                    }
                    //
                    valor = Inv.Ult_Quantidade * Inv.Ult_Custo;
                    Inv.Ult_Total = Math.Round(valor, 2);
                    //
                    Inv.NCM = ncm.Insert(ncm.Length, "'").Insert(0, "'");
                    //
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    con.Alterar_Item_Novo_Inventario(Inv);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Custo_Medio_Atual_Ajuste_Inv(string cod_inventario, string cod_produto, string inv_custo_medio_atual, string inv_total_atual)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    Inv.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    if (inv_custo_medio_atual.Contains("."))
                    {
                        Inv.Inv_Custo_Medio_Atual = Convert.ToDecimal(inv_custo_medio_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Custo_Medio_Atual = Convert.ToDecimal(inv_custo_medio_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (inv_total_atual.Contains("."))
                    {
                        Inv.Inv_Total_Atual = Convert.ToDecimal(inv_total_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Total_Atual = Convert.ToDecimal(inv_total_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    con.Alterar_Custo_Medio_Atual_Ajuste_Inv(Inv);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Saldo_Atual_Ajuste_Inv(string cod_inventario, string cod_produto, string inv_saldo_atual, string inv_total_atual)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    Inv.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    if (inv_saldo_atual.Contains("."))
                    {
                        Inv.Inv_Saldo_Atual = Convert.ToDecimal(inv_saldo_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Saldo_Atual = Convert.ToDecimal(inv_saldo_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (inv_total_atual.Contains("."))
                    {
                        Inv.Inv_Total_Atual = Convert.ToDecimal(inv_total_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Inv.Inv_Total_Atual = Convert.ToDecimal(inv_total_atual.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    con.Alterar_Saldo_Atual_Ajuste_Inv(Inv);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

                }
            }
        }
        
        public static void Alterar_Saldo_Produto_Inv(string codigo, string saldo_adicionado)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (saldo_adicionado == "" || saldo_adicionado == null)
                    {
                        Prod.Saldo_Atual = con.Sel_Saldo_Atual_Produto(Prod);
                    }
                    else
                    {
                        if (saldo_adicionado.Contains("."))
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(saldo_adicionado.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(saldo_adicionado.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    con.Alterar_Saldo_Produto_Inv(Prod);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Sincronizar_Estoque_Produto_Inv(string cod_produto, string saldo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(cod_produto);
                    //
                    if (saldo == "" || saldo == null)
                    {
                        Prod.Saldo_Atual = 0;
                    }
                    else
                    {
                        if (saldo.Contains("."))
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(saldo.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(saldo.Replace(",", "."));
                        }
                    }
                    //
                    con.Sincronizar_Estoque_Produto_Inv(Prod);
                }
            }
        }

        public static void Zerar_Estoque_Produto_Inv()
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    con.Zerar_Estoque_Produto_Inv(Prod);
                }
            }
        }

        public static string Calculo_Estoque_Atual(string saldo_atual, string custo_atual)
        {
            if (saldo_atual == "" || saldo_atual == null)
            {
                saldo_atual = "0";
            }
            //
            if (custo_atual == "" || custo_atual == null)
            {
                custo_atual = "0";
            }
            //
            decimal valor_saldo = Convert.ToDecimal(saldo_atual);
            decimal valor_custo_medio = Convert.ToDecimal(custo_atual);
            decimal retorno = valor_saldo * valor_custo_medio;
            return Math.Round(retorno, 2).ToString();
        }

        public static DataTable Sel_Item_Inventario_A_Salvar(string cod_inventario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    return con.Sel_Item_Inventario_A_Salvar(Inv);
                }
            }
        }

        public static DataTable Sel_Item_Inventario_A_Alterar(string cod_produto, string cod_inventario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Inv.Cod_Produto = Convert.ToInt32(cod_produto);
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    return con.Sel_Item_Inventario_A_Alterar(Inv);
                }
            }
        }

        public static DataTable Sel_Inventario_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Inventario_Todos();
            }
        }

        public static DataTable Sel_Inventario_Codigo(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Inventario Inv = new Inventario())
                {
                    Inv.Codigo = Convert.ToInt32(codigo);
                    //
                    return con.Sel_Inventario_Codigo(Inv);
                }
            }
        }

        public static string Sel_Ultimo_Cod_Inventario_Adicionado()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ultimo_Cod_Inventario_Adicionado();
            }
        }

        public static string Sel_Ultima_Data_Inventario_Adicionado()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ultima_Data_Inventario_Adicionado();
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Inventario Inv = new Inventario())
                {
                    Inv.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Inventario(Inv);
                }
            }
        }

        public static bool Sel_Inventario_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Inventario Inv = new Inventario())
                {
                    Inv.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Inventario_Ainda_Existe(Inv);
                }
            }
        }

        public static DataTable Sel_Inventario_Item_Existe(string cod_produto, string cod_inventario, string um)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Inv.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    Inv.UM = um;
                    //
                    return con.Sel_Inventario_Item_Existe(Inv);
                }
            }
        }

        public static void Excluir_Items_Inventario(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Inventario Inv = new Inventario())
                {
                    Inv.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Items_Inventario(Inv);
                }
            }
        }

        public static DataTable Sel_ComboboxProduto_Valor_A_Alterar(string cbbproduto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    string[] items = cbbproduto.Split('—');
                    Inv.Cod_Produto = Convert.ToInt32(items[0]);
                    return con.Sel_ComboboxProduto_Valor_A_Alterar(Inv);
                }
            }
        }

        public static DataTable Sel_Produtos_Inv_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Produtos_Inv_Prod();
            }
        }

        public static DataTable Sel_Prod_Inv_Cod(string produto, string cod_inventario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    string[] item = produto.Split('—');
                    //
                    Inv.Cod_Produto = Convert.ToInt32(item[0]);
                    //
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    return con.Sel_Prod_Inv_Cod(Inv);
                }
            }
        }

        public static DataTable Sel_Prod_Inv_Cod_Barra(string barra, string cod_inventario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Inv.Pesquisar = barra;
                    //
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    return con.Sel_Prod_Inv_Cod_Barra(Inv);
                }
            }
        }

        public static DataTable Sel_Prod_Inv_Todos(string cod_inventario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    //
                    return con.Sel_Prod_Inv_Todos(Inv);
                }
            }
        }

        public static bool Sel_Situacao_Inventario(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Inventario Inv = new Inventario())
                {
                    Inv.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Situacao_Inventario(Inv);
                }
            }
        }

        public static bool Sel_Produto_Inv_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Inv.Cod_Produto = Convert.ToInt32(codigo);
                    return con.Sel_Produto_Inv_Ainda_Existe(Inv);
                }
            }
        }

        public static void Excluir_Item_Inventario(string codigo, string cod_inventario, string um)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Inventario Inv = new Item_Inventario())
                {
                    Inv.Cod_Produto = Convert.ToInt32(codigo);
                    Inv.Cod_Inventario = Convert.ToInt32(cod_inventario);
                    Inv.UM = um;
                    //
                    con.Excluir_Item_Inventario(Inv);
                }
            }
        }

    }
}
