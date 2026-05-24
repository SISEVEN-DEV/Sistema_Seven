using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllHistCaixa
    {
        public static bool _FrmRelHistCaixa_Aberto;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static string _Tipo_Impressao;
        public static bool _Mostrar_Logo_Marca_Imp;
        public static string _Impressora;
        public static string _Numero_Copias;

        public static string _Hist_PesqUsuario_Tabela;
        public static string _Hist_PesqCompPDV_Tabela;

        public static DataTable Sel_Usuario_HistCaixa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_HistCaixa();
            }
        }

        public static DataTable Sel_Comp_PDV_HistCaixa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Comp_PDV_HistCaixa();
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Vendas(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Hist_Total_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Hist_Total_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Hist_Total_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        valor += Convert.ToDecimal(dr[0]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Real_Vendas(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Hist_Total_Real_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Hist_Total_Real_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Hist_Total_Real_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        valor += Convert.ToDecimal(dr[0]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Vendas_Nota_Pomissoria(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE venda.data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND venda.id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND venda.id_usuario=" + items[0];
                }
                //
                if (con.Sel_Caixa_Dados_Hist_Total_Vendas_Nota_Pomissoria(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Hist_Total_Vendas_Nota_Pomissoria(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Hist_Total_Vendas_Nota_Pomissoria(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];
                        valor += Convert.ToDecimal(dr[0]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Descontos_Vendas(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Hist_Total_Descontos_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Hist_Total_Descontos_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Hist_Total_Descontos_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        valor += Convert.ToDecimal(dr[0]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Acrescimos_Vendas(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Hist_Total_Acrescimos_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Hist_Total_Acrescimos_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Hist_Total_Acrescimos_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        valor += Convert.ToDecimal(dr[0]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Real_Vendas_A_Vista(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Hist_Total_Real_Vendas_A_Vista(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Hist_Total_Real_Vendas_A_Vista(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Hist_Total_Real_Vendas_A_Vista(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        valor += Convert.ToDecimal(dr[0]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Cancelamentos(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Hist_Total_Cancelamentos(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Hist_Total_Cancelamentos(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Hist_Total_Cancelamentos(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        valor += Convert.ToDecimal(dr[0]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Devolucao(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE devolucao.data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND devolucao.id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND devolucao.id_usuario=" + items[0];
                }
                //
                if (con.Sel_Caixa_Dados_Hist_Total_Devolucao(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Hist_Total_Devolucao(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Hist_Total_Devolucao(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        valor += Convert.ToDecimal(dr[0]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Conta_Receber_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Conta_Receber_Hist_Total_Pago(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Conta_Receber_Hist_Total_Pago(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Conta_Receber_Hist_Total_Pago(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        valor += Convert.ToDecimal(dr["valor_pago"]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Vendas_Qtde(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                int valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Hist_Total_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    valor = con.Sel_Caixa_Dados_Hist_Total_Vendas(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count;
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static DataTable Sel_Caixa_Dados_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;

                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;

                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                return con.Sel_Caixa_Dados_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario);
            }
        }

        public static string Sel_Caixa_Dados_Conta_Pagar_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Conta_Pagar_Hist_Total_Pago(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Conta_Pagar_Hist_Total_Pago(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Conta_Pagar_Hist_Total_Pago(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];
                        //
                        valor += Convert.ToDecimal(dr["valor_pago"]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Sup_Hist_Qtdeg(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    int valor = 0;

                    string[] items;

                    string SqlDataHora;
                    string SqlCodPdvComputador;
                    string SqlUsuario;

                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                    if (con.Sel_Caixa_Dados_Sup_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        valor = con.Sel_Caixa_Dados_Sup_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count;
                    }
                    else
                    {
                        valor = 0;
                    }
                    //
                    return valor.ToString();
                }
            }
        }

        public static string Sel_Caixa_Dados_Sup_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Sup_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Sup_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Sup_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        valor += Convert.ToDecimal(dr[0]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Cancelamentos_Qtdeg(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    int valor = 0;
                    //
                    string[] items;
                    //
                    string SqlDataHora;
                    string SqlCodPdvComputador;
                    string SqlUsuario;
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                    if (con.Sel_Caixa_Dados_Hist_Total_Cancelamentos(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        valor = con.Sel_Caixa_Dados_Hist_Total_Cancelamentos(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count;
                    }
                    else
                    {
                        valor = 0;
                    }
                    //
                    return valor.ToString();
                }
            }
        }

        public static string Sel_Caixa_Dados_Hist_Total_Devolucao_Qtde(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    int valor = 0;
                    //
                    string[] items;
                    //
                    string SqlDataHora;
                    string SqlCodPdvComputador;
                    string SqlUsuario;
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE devolucao.data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND devolucao.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND devolucao.id_usuario=" + items[0];
                    }
                    //
                    if (con.Sel_Caixa_Dados_Hist_Total_Devolucao(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        valor = con.Sel_Caixa_Dados_Hist_Total_Devolucao(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count;
                    }
                    else
                    {
                        valor = 0;
                    }
                    //
                    return valor.ToString();
                }
            }
        }

        public static string Sel_Caixa_Dados_Sang_Hist_Qtdeg(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    int valor = 0;
                    //
                    string[] items;
                    //
                    string SqlDataHora;
                    string SqlCodPdvComputador;
                    string SqlUsuario;
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                    if (con.Sel_Caixa_Dados_Sang_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        valor = con.Sel_Caixa_Dados_Sang_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count;
                    }
                    else
                    {
                        valor = 0;
                    }
                    //
                    return valor.ToString();
                }
            }
        }

        public static string Sel_Caixa_Dados_Sang_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                decimal valor = 0;
                //
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
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
                if (con.Sel_Caixa_Dados_Sang_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Sang_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Sang_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        valor += Convert.ToDecimal(dr[0]);
                    }
                }
                else
                {
                    valor = 0;
                }
                //
                return valor.ToString();
            }
        }

        public static string Sel_Caixa_Dados_Pagamento_Dev_Dinheiro_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE pagamento_devolucao.data_devolucao BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND pagamento_devolucao.id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND pagamento_devolucao.id_usuario=" + items[0];
                }
                //
                decimal vVDev = 0;
                //
                if (con.Sel_Caixa_Dados_Pagamento_Dev_Dinheiro_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Dev_Dinheiro_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Pagamento_Dev_Dinheiro_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];
                        vVDev += Convert.ToDecimal(dr[0]);
                    }
                    //
                    vVDev.ToString();
                }
                else
                {
                    vVDev = 0;
                }
                //
                return (vVDev).ToString();
            }
        }

        public static string Sel_Caixa_Dados_Pagamento_Dinheiro_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE pagamento_venda.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND pagamento_venda.id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND pagamento_venda.id_usuario=" + items[0];
                }
                //
                decimal vVenda = 0;
                decimal vContaReceber = 0;
                decimal vSuprimento = 0;
                //
                if (con.Sel_Caixa_Dados_Pagamento_Dinheiro_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Dinheiro_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Pagamento_Dinheiro_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];
                        vVenda += Convert.ToDecimal(dr[0]);
                    }
                    //
                    vVenda.ToString();
                }
                else
                {
                    vVenda = 0;
                }
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE pagamento_conta_receber.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND pagamento_conta_receber.id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND pagamento_conta_receber.id_usuario=" + items[0];
                }
                //
                if (con.Sel_Caixa_Dados_Pagamento_Dinheiro_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Dinheiro_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Pagamento_Dinheiro_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        vContaReceber += Convert.ToDecimal(dr[0]);
                    }
                    //
                    vContaReceber.ToString();
                }
                else
                {
                    vContaReceber = 0;
                }
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE sangria_suprimento.data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND sangria_suprimento.id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND sangria_suprimento.id_usuario=" + items[0];
                }
                //
                if (con.Sel_Caixa_Dados_Pagamento_Dinheiro_Suprimento_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Dinheiro_Suprimento_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Pagamento_Dinheiro_Suprimento_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        vSuprimento += Convert.ToDecimal(dr[0]);
                    }
                    //
                    vSuprimento.ToString();
                }
                else
                {
                    vSuprimento = 0;
                }
                //
                return (vVenda + vContaReceber + vSuprimento).ToString();
            }
        }

        public static string Sel_Abert_Caixa_Dados_Troco(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;

                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;

                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE venda.data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND venda.id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND venda.id_usuario=" + items[0];
                }
                //
                decimal vTrocoVenda;
                decimal vTrocoContaReceber;
                //
                if (con.Sel_Caixa_Dados_Troco_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != "")
                {
                    vTrocoVenda = Convert.ToDecimal(con.Sel_Caixa_Dados_Troco_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario));
                }
                else
                {
                    vTrocoVenda = 0;
                }
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE conta_receber.data_baixa BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND conta_receber.id_pdv_computador_baixa=" + cod_pdv_computador;
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND conta_receber.id_usuario_baixa=" + items[0];
                }
                //
                if (con.Sel_Caixa_Dados_Troco_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != "")
                {
                    vTrocoContaReceber = Convert.ToDecimal(con.Sel_Caixa_Dados_Troco_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario));
                }
                else
                {
                    vTrocoContaReceber = 0;
                }
                //
                return (vTrocoVenda + vTrocoContaReceber).ToString();
            }
        }

        public static string Sel_Caixa_Dados_Pagamento_Cartao_Credito_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;
                //
                string SqlDataHora;
                string SqlCodPdvComputador;
                string SqlUsuario;
                //
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE pagamento_venda.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND pagamento_venda.id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND pagamento_venda.id_usuario=" + items[0];
                }
                //
                decimal vVenda = 0;
                decimal vContaReceber = 0;
                //
                if (con.Sel_Caixa_Dados_Pagamento_Cartao_Credito_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Cartao_Credito_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Pagamento_Cartao_Credito_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        vVenda += Convert.ToDecimal(dr[0]);
                    }
                    //
                    vVenda.ToString();
                }
                else
                {
                    vVenda = 0;
                }
                //              
                if (data_inicio.Contains("_") & data_fim.Contains("_"))
                {
                    SqlDataHora = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = " 00:00:00";
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
                    SqlDataHora = "WHERE pagamento_conta_receber.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND pagamento_conta_receber.id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND pagamento_conta_receber.id_usuario=" + items[0];
                }
                //
                if (con.Sel_Caixa_Dados_Pagamento_Cartao_Credito_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                {
                    for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Cartao_Credito_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                    {
                        DataRow dr = con.Sel_Caixa_Dados_Pagamento_Cartao_Credito_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                        vContaReceber += Convert.ToDecimal(dr[0]);
                    }
                    //
                    vContaReceber.ToString();
                }
                else
                {
                    vContaReceber = 0;
                }
                //
                return (vVenda + vContaReceber).ToString();
            }
        }

        public static string Sel_Caixa_Dados_Pagamento_Cartao_Debito_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string[] items;
                    //
                    string SqlDataHora;
                    string SqlCodPdvComputador;
                    string SqlUsuario;
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_venda.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_venda.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_venda.id_usuario=" + items[0];
                    }
                    //
                    decimal vVenda = 0;
                    decimal vContaReceber = 0;
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Cartao_Debito_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Cartao_Debito_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Cartao_Debito_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vVenda += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vVenda.ToString();
                    }
                    else
                    {
                        vVenda = 0;
                    }
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_conta_receber.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_conta_receber.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_conta_receber.id_usuario=" + items[0];
                    }
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Cartao_Debito_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Cartao_Debito_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Cartao_Debito_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];
                            vContaReceber += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vContaReceber.ToString();
                    }
                    else
                    {
                        vContaReceber = 0;
                    }
                    //
                    return (vVenda + vContaReceber).ToString();
                }
            }
        }

        public static string Sel_Caixa_Dados_Pagamento_Pix_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string[] items;
                    //
                    string SqlDataHora;
                    string SqlCodPdvComputador;
                    string SqlUsuario;
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_venda.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_venda.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_venda.id_usuario=" + items[0];
                    }
                    //
                    decimal vVenda = 0;
                    decimal vContaReceber = 0;
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Pix_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Pix_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Pix_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vVenda += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vVenda.ToString();
                    }
                    else
                    {
                        vVenda = 0;
                    }
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_conta_receber.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_conta_receber.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_conta_receber.id_usuario=" + items[0];
                    }
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Pix_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Pix_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Pix_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vContaReceber += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vContaReceber.ToString();
                    }
                    else
                    {
                        vContaReceber = 0;
                    }
                    //
                    return (vVenda + vContaReceber).ToString();
                }
            }
        }

        public static string Sel_Caixa_Dados_Pagamento_Alimentacao_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string[] items;
                    //
                    string SqlDataHora;
                    string SqlCodPdvComputador;
                    string SqlUsuario;
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_venda.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_venda.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_venda.id_usuario=" + items[0];
                    }
                    //
                    decimal vVenda = 0;
                    decimal vContaReceber = 0;
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Alimentacao_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Alimentacao_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Alimentacao_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vVenda += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vVenda.ToString();
                    }
                    else
                    {
                        vVenda = 0;
                    }
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_conta_receber.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_conta_receber.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_conta_receber.id_usuario=" + items[0];
                    }
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Alimentacao_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Alimentacao_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Alimentacao_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vContaReceber += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vContaReceber.ToString();
                    }
                    else
                    {
                        vContaReceber = 0;
                    }
                    //
                    return (vVenda + vContaReceber).ToString();
                }
            }
        }

        public static string Sel_Caixa_Dados_Pagamento_Refeicao_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string[] items;
                    //
                    string SqlDataHora;
                    string SqlCodPdvComputador;
                    string SqlUsuario;
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_venda.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_venda.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_venda.id_usuario=" + items[0];
                    }
                    //
                    decimal vVenda = 0;
                    decimal vContaReceber = 0;
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Refeicao_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Refeicao_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Refeicao_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vVenda += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vVenda.ToString();
                    }
                    else
                    {
                        vVenda = 0;
                    }
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_conta_receber.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_conta_receber.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_conta_receber.id_usuario=" + items[0];
                    }
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Refeicao_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Refeicao_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Refeicao_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vContaReceber += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vContaReceber.ToString();
                    }
                    else
                    {
                        vContaReceber = 0;
                    }
                    //
                    return (vVenda + vContaReceber).ToString();
                }
            }
        }

        public static string Sel_Caixa_Dados_Pagamento_Credito_Loja_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string[] items;
                    //
                    string SqlDataHora;
                    string SqlCodPdvComputador;
                    string SqlUsuario;
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_venda.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_venda.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_venda.id_usuario=" + items[0];
                    }
                    //
                    decimal vVenda = 0;
                    decimal vContaReceber = 0;
                    decimal vDev = 0;
                    //                    
                    if (con.Sel_Caixa_Dados_Pagamento_Credito_Loja_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Credito_Loja_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Credito_Loja_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vVenda += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vVenda.ToString();
                    }
                    else
                    {
                        vVenda = 0;
                    }
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_conta_receber.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_conta_receber.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_conta_receber.id_usuario=" + items[0];
                    }
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Credito_Loja_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Credito_Loja_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Credito_Loja_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vContaReceber += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vContaReceber.ToString();
                    }
                    else
                    {
                        vContaReceber = 0;
                    }
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_devolucao.data_devolucao BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_devolucao.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_devolucao.id_usuario=" + items[0];
                    }
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Credito_Loja_Devolucao_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Credito_Loja_Devolucao_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Credito_Loja_Devolucao_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vContaReceber += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vDev.ToString();
                    }
                    else
                    {
                        vDev = 0;
                    }
                    //
                    return (vVenda + vContaReceber + vDev).ToString();
                }
            }
        }

        public static string Sel_Caixa_Dados_Pagamento_Cheque_Hist(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string[] items;
                    //
                    string SqlDataHora;
                    string SqlCodPdvComputador;
                    string SqlUsuario;
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_venda.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_venda.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_venda.id_usuario=" + items[0];
                    }
                    //
                    decimal vVenda = 0;
                    decimal vContaReceber = 0;
                    //                  
                    if (con.Sel_Caixa_Dados_Pagamento_Cheque_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Cheque_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Cheque_Venda_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vVenda += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vVenda.ToString();
                    }
                    else
                    {
                        vVenda = 0;
                    }
                    //
                    if (data_inicio.Contains("_") & data_fim.Contains("_"))
                    {
                        SqlDataHora = "";
                    }
                    else
                    {
                        if (hora_inicio.Contains("_"))
                        {
                            hora_inicio = " 00:00:00";
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
                        SqlDataHora = "WHERE pagamento_conta_receber.data_pagamento BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    }
                    //
                    if (cod_pdv_computador == "")
                    {
                        SqlCodPdvComputador = "";
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND pagamento_conta_receber.id_pdv_computador=" + cod_pdv_computador;
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsuario = " AND pagamento_conta_receber.id_usuario=" + items[0];
                    }
                    //
                    if (con.Sel_Caixa_Dados_Pagamento_Cheque_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario) != null)
                    {
                        for (int i = 0; i < con.Sel_Caixa_Dados_Pagamento_Cheque_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Caixa_Dados_Pagamento_Cheque_Conta_Receber_Hist(SqlDataHora, SqlCodPdvComputador, SqlUsuario).Rows[i];

                            vContaReceber += Convert.ToDecimal(dr[0]);
                        }
                        //
                        vContaReceber.ToString();
                    }
                    else
                    {
                        vContaReceber = 0;
                    }
                    //
                    return (vVenda + vContaReceber).ToString();
                }
            }
        }
    }
}
