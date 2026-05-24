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
    public class bllPrecificacao
    {
        public static void Salvar(string item, string cod_produto, string novo_preco, string margem, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Precificacao Prec = new Precificacao())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Prec.Cod_Item = Convert.ToInt16(item);
                    //
                    Prec.Cod_Produto = Convert.ToInt32(item);
                    //
                    if (novo_preco.Contains("."))
                    {
                        Prec.Novo_Preco = Convert.ToDecimal(novo_preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prec.Novo_Preco = Convert.ToDecimal(novo_preco.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (margem == "" || margem == null)
                    {
                        Prec.Margem = 0;
                    }
                    else
                    {
                        if (margem.Contains("."))
                        {
                            Prec.Margem = Convert.ToDecimal(margem.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prec.Margem = Convert.ToDecimal(margem.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    Prec.Cod_DFe = Convert.ToInt32(cod_dfe);
                    //
                    con.Salvar_Precificacao(Prec);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar(string item, string cod_produto, string novo_preco, string margem, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Precificacao Prec = new Precificacao())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Prec.Cod_Item = Convert.ToInt16(item);
                    //
                    Prec.Cod_Produto = Convert.ToInt32(item);
                    //
                    if (novo_preco.Contains("."))
                    {
                        Prec.Novo_Preco = Convert.ToDecimal(novo_preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prec.Novo_Preco = Convert.ToDecimal(novo_preco.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (margem == "" || margem == null)
                    {
                        Prec.Margem = 0;
                    }
                    else
                    {
                        if (margem.Contains("."))
                        {
                            Prec.Margem = Convert.ToDecimal(margem.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prec.Margem = Convert.ToDecimal(margem.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    Prec.Cod_DFe = Convert.ToInt32(cod_dfe);
                    //
                    con.Alterar_Precificacao(Prec);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir(string item, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Precificacao Prec = new Precificacao())
                {
                    Prec.Cod_Item = Convert.ToInt16(item);
                    //
                    Prec.Cod_DFe = Convert.ToInt32(cod_dfe);
                    //
                    con.Excluir_Precificacao(Prec);
                }
            }
        }

        public static DataTable Sel_Items_DFe_Precificacao(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Item.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    return con.Sel_Items_DFe_Precificacao(Item);
                }
            }
        }

        public static string Sel_Ult_Dfe_Item_Produto(string cod_produto, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Precificacao Prec = new Precificacao())
                {
                    string retorno = "0";
                    //
                    Prec.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    if (con.Sel_Ult_Dfe_Item_Produto(Prec) != null)
                    {
                        DataRow dr = con.Sel_Ult_Dfe_Item_Produto(Prec).Rows[0];
                        //
                        Prec.Cod_DFe = Convert.ToInt32(dr[0]);
                        //
                        if (Prec.Cod_DFe != Convert.ToInt32(cod_dfe))
                        {
                            if (con.Sel_Ult_Item_DFe_Produto(Prec) != null)
                            {
                                dr = con.Sel_Ult_Item_DFe_Produto(Prec).Rows[0];
                                //
                                retorno = ((Convert.ToDecimal(dr["total"]) + Convert.ToDecimal(dr["valor_icms"]) + Convert.ToDecimal(dr["valor_ipi"]) + Convert.ToDecimal(dr["valor_icms_st"]) - Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo"])) / Convert.ToDecimal(dr["quantidade"])).ToString();
                            }
                        }
                    }
                    //
                    if(retorno == "0")
                    {
                        if (Sel_Item_DFe_Associado_Produto(cod_produto) != null) 
                        {
                            string[] items = Sel_Item_DFe_Associado_Produto(cod_produto).Split('—');
                            //
                            Prec.Cod_DFe = Convert.ToInt32(items[1]);
                            //
                            Prec.Cod_Item = Convert.ToInt16(items[0]);
                            //
                            if (Prec.Cod_DFe != Convert.ToInt32(cod_dfe))
                            {
                                if (con.Sel_Ult_Item_DFe_Produto_Associado(Prec) != null)
                                {
                                    DataRow dr = con.Sel_Ult_Item_DFe_Produto_Associado(Prec).Rows[0];
                                    //
                                    retorno = ((Convert.ToDecimal(dr["total"]) + Convert.ToDecimal(dr["valor_icms"]) + Convert.ToDecimal(dr["valor_ipi"]) + Convert.ToDecimal(dr["valor_icms_st"]) - Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo"])) / Convert.ToDecimal(dr["quantidade"])).ToString();
                                }
                            }
                        }
                    }
                    //
                    return retorno;
                }
            }
        }

        public static string Sel_Ult_Preco_Produto(string cod_produto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Precificacao Prec = new Precificacao())
                {
                    Prec.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    return con.Sel_Ult_Preco_Produto(Prec);
                }
            }
        }

        public static string Sel_Item_DFe_Associado_Produto(string cod_produto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Precificacao Prec = new Precificacao())
                {
                    Prec.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    return con.Sel_Item_DFe_Associado_Produto(Prec);
                }
            }
        }
    }
}
