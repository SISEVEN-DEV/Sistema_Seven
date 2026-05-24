using DAL;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllPedAnotaAI
    {
        public static string _Pagamento_PesqPagamento_Tabela;
        public static string _PedAnotaAi_PesqProduto_Tabela;

        public static DataTable Sel_Ped_Anota_Ai_Data_Cad_Situacao(string data_cad, string data_cad1, string horario_cad, string horario_cad1, string situacao, string codigo, string pagamento)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                string SqlSituacao;
                string SqlPagamento;
                string SqlCodigo;
                //
                if (data_cad.Contains("_") || data_cad1.Contains("_"))
                {
                    SqlData = "WHERE ped_anota_ai.data BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " 23:59:59'";
                }
                else
                {
                    if (horario_cad.Contains("_"))
                    {
                        horario_cad = "";
                    }
                    else
                    {
                        horario_cad = " " + horario_cad;
                    }
                    //
                    if (horario_cad1.Contains("_"))
                    {
                        horario_cad1 = " 23:59:59";
                    }
                    else
                    {
                        horario_cad1 = " " + horario_cad1;
                    }
                    //
                    SqlData = "WHERE ped_anota_ai.data BETWEEN '" + data_cad.Replace("/", ".") + horario_cad + "' AND '" + data_cad1.Replace("/", ".") + horario_cad1 + "'";
                }
                //
                if (situacao == "" || situacao == null)
                {
                    SqlSituacao = "";
                }
                else
                {
                    SqlSituacao = " AND ped_anota_ai.situacao='" + situacao + "'";
                }
                //
                string[] items;
                if (pagamento == "")
                {
                    SqlPagamento = "";
                }
                else
                {
                    items = pagamento.Split('—');
                    SqlPagamento = " AND pagamento_ped_anota_ai.id_pagamento=" + items[0];
                }
                //
                if (codigo == "" || codigo == null)
                {
                    SqlCodigo = "";
                }
                else
                {
                    SqlCodigo = " AND ped_anota_ai.id_ped_anota_ai='" + codigo + "'";
                }
                //
                return con.Sel_Ped_Anota_Ai_Data_Cad_Situacao(SqlData, SqlSituacao, SqlPagamento, SqlCodigo);
            }
        }

        public static DataTable Sel_Ped_Anota_Ai_Items(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Ped_Anota_Ai Ped = new Ped_Anota_Ai())
                {
                    Ped.Codigo = Convert.ToInt32(codigo);
                    //
                    return con.Sel_Ped_Anota_Ai_Items(Ped);
                }
            }
        }

        public static DataTable Sel_Forma_Pagamento_Ped_Anota_AI()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Forma_Pagamento_Ped_Anota_AI();
            }
        }


        public static DataTable Sel_Ped_Anota_Ai_Items_Pagamento(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Ped_Anota_Ai Ped = new Ped_Anota_Ai())
                {
                    Ped.Codigo = Convert.ToInt32(codigo);
                    //
                    return con.Sel_Ped_Anota_Ai_Items_Pagamento(Ped);
                }
            }
        }

        public static void Alterar_Item_Ped_Anota_Ai(string cod_item, string cod_pedido, string produto) 
        {
            using (Con7BD con = new Con7BD()) 
            {
                using (Item_Ped_Anota_Ai Ped = new Item_Ped_Anota_Ai()) 
                {
                    Ped.Cod_Item = Convert.ToInt16(cod_item);
                    //
                    Ped.Cod_Ped_Anota_Ai = Convert.ToInt32(cod_pedido);
                    //
                    string[] items = produto.Split('—');
                    Ped.Cod_Produto = Convert.ToInt32(items[0]);
                    //
                    Ped.Descricao = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Item_Ped_Anota_Ai(Ped);

                }
            }
        }

        public static void Alterar_Pagamento_Ped_Anota_Ai(string cod_pagamento, string cod_pedido, string forma_pagamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_Ped_Anota_Ai Pag = new Pagamento_Ped_Anota_Ai())
                {
                    Pag.Cod_Item_Pagamento = Convert.ToInt16(cod_pagamento);
                    //
                    Pag.Cod_Ped_Anota_Ai = Convert.ToInt32(cod_pedido);
                    //
                    string[] items = forma_pagamento.Split('—');
                    Pag.Cod_Pagamento = Convert.ToInt16(items[0]);
                    //
                    Pag.Tipo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Pagamento_Ped_Anota_Ai(Pag);

                }
            }
        }
    }
}
