using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllMultiploCodigoBarra
    {
        public static void Salvar(string cod_item, string cod_barra, string cod_produto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (MultiplosCodigoBarra Mult = new MultiplosCodigoBarra())
                {
                    Mult.Cod_Item = Convert.ToInt16(cod_item);
                    //
                    Mult.Cod_Barra = cod_barra.Insert(cod_barra.Length, "'").Insert(0, "'");
                    //
                    Mult.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    con.Salvar_Multiplo_Cod_Barra(Mult);
                }
            }
        }

        public static void Salvar_Items_Cod_Barras_Temp(int codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (MultiplosCodigoBarra Mult = new MultiplosCodigoBarra())
                {
                    for (int i = 0; i < Sel_Multiplo_Cod_Barra_Todos_Temp().Rows.Count; i++)
                    {
                        DataRow dr = Sel_Multiplo_Cod_Barra_Todos_Temp().Rows[i];
                        //
                        Mult.Cod_Item = Convert.ToInt16(dr["id_mult_cod_barra"].ToString());
                        //
                        Mult.Cod_Barra = "'" + dr["cod_barra"].ToString() + "'";
                        //
                        Mult.Cod_Produto = codigo;
                        //
                        con.Salvar_Multiplo_Cod_Barra(Mult);
                    }
                }
            }
        }

        public static void Salvar_Temp(string codigo, string cod_barra)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (MultiplosCodigoBarra_Temp Mult = new MultiplosCodigoBarra_Temp())
                {
                    Mult.Codigo = Convert.ToInt16(codigo);
                    //
                    Mult.Cod_Barra = cod_barra.Insert(cod_barra.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Multiplo_Cod_Barra_Temp(Mult);
                }
            }
        }

        public static void Excluir_Items_Codigo_Barra_Atual()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                con.Excluir_Items_Codigo_Barra_Atual();
            }
        }


        public static bool Sel_Codigo_Barras_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (MultiplosCodigoBarra Mult = new MultiplosCodigoBarra())
                {
                    Mult.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Codigo_Barras_Ainda_Existe(Mult);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (MultiplosCodigoBarra Mult = new MultiplosCodigoBarra())
                {
                    Mult.Codigo = Convert.ToInt32(codigo);
                    //
                    con.Excluir_Codigo_Barra(Mult);
                }
            }
        }

        public static void Excluir_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (MultiplosCodigoBarra_Temp Mult = new MultiplosCodigoBarra_Temp())
                {
                    Mult.Codigo = Convert.ToInt32(codigo);
                    //
                    con.Excluir_Codigo_Barra_Temp(Mult);
                }
            }
        }

        public static DataTable Sel_Multiplo_Cod_Barra_Todos_Temp()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Multiplo_Cod_Barra_Todos_Temp();
            }
        }


        public static DataTable Sel_Multiplo_Cod_Barra_Todos(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (MultiplosCodigoBarra Mult = new MultiplosCodigoBarra())
                {
                    Mult.Pesquisar = pesquisar;
                    return con.Sel_Multiplo_Cod_Barra_Todos(Mult);
                }
            }
        }

        public static bool Val_Mult_Barra(string barra)
        {
            using (Con7BD con = new Con7BD())
            {
                using (MultiplosCodigoBarra Mult = new MultiplosCodigoBarra())
                {
                    Mult.Cod_Barra = barra;
                    return con.Val_Mult_Barra(Mult);
                }
            }
        }

        public static void Atualizar_Item_Dt_Barra(int item_atual, int total_item)
        {
            using (Con7BD con = new Con7BD())
            {
                using (MultiplosCodigoBarra Mult = new MultiplosCodigoBarra())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Mult.Cod_Item = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dt_Barra(Mult, item.ToString());
                    }
                }
            }
        }

        public static void Atualizar_Item_Dt_Barra_Temp(int item_atual, int total_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (MultiplosCodigoBarra_Temp Mult = new MultiplosCodigoBarra_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Mult.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dt_Barra_Temp(Mult, item.ToString());
                    }
                }
            }
        }

        public static bool Val_Mult_Barra_Temp(string barra)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (MultiplosCodigoBarra_Temp Mult = new MultiplosCodigoBarra_Temp())
                {
                    Mult.Cod_Barra = barra;
                    return con.Val_Mult_Barra_Temp(Mult);
                }
            }
        }

    }
}
