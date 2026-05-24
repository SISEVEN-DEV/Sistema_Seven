using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Threading;

namespace BLL
{
    public class bllAbert_Fech_Caixa
    {
        public static bool _FrmRelCaixas_Aberto;

        public static string _Abert_Fech_Cx_PesqUsuarioTabela;
        public static string _Abert_Fech_Cx_PesqCompPDV_Tabela;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static void Salvar_Fechamento(string saldo_final, string total_quebra_caixa, string observacoes, string cod_pdv_computador, string usuario, string cod_abert_fech_caixa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Abertura_Fechamento_Caixa Cx = new Abertura_Fechamento_Caixa())
                {
                    Cx.Data_Fechamento = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Cx.Hora_Fechamento = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //                

                    //
                    Cx.Codigo = Convert.ToInt32(cod_abert_fech_caixa);
                    //
                    if (saldo_final.Contains("."))
                    {
                        Cx.Saldo_Final = Convert.ToDecimal(saldo_final.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Cx.Saldo_Final = Convert.ToDecimal(saldo_final.Replace(",", "."));
                    }
                    //
                    if (total_quebra_caixa.Contains("."))
                    {
                        Cx.Total_Quebra_Caixa = Convert.ToDecimal(total_quebra_caixa.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Cx.Total_Quebra_Caixa = Convert.ToDecimal(total_quebra_caixa.Replace(",", "."));
                    }
                    //
                    if (observacoes == "")
                    {
                        Cx.Observacoes = "null";
                    }
                    else
                    {
                        Cx.Observacoes = observacoes.Insert(observacoes.Length, "'").Insert(0, "'");
                    }
                    //
                    usuario = usuario.Remove(0, 12);
                    string[] items = usuario.Split('—');
                    //
                    Cx.Cod_Usuario_Fechamento = Convert.ToInt16(items[0]);
                    //
                    Cx.Nome_Usuario_Fechamento = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Fechamento_Caixa(Cx);
                    //                   
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static string Sel_Data_Abert_Ultima_Abert_Fech_Caixa(string id_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Abertura_Fechamento_Caixa Cx = new Abertura_Fechamento_Caixa())
                {
                    string[] items = id_pdv_computador.Split('/');
                    Cx.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    return con.Sel_Data_Abert_Ultima_Abert_Fech_Caixa(Cx);
                }
            }
        }

        public static void Salvar_Item_Abert_Fech_Caixa(string cod_forma_pagamento, string tipo, string totais, string valor_informado, string quebra_caixa, string cod_abert_fech_caixa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Abertura_Fechamento_Caixa Item = new Item_Abertura_Fechamento_Caixa())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Forma_Pagamento = Convert.ToInt16(cod_forma_pagamento);
                    //
                    Item.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //                  
                    if (totais.Contains("."))
                    {
                        Item.Total = Convert.ToDecimal(totais.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Total = Convert.ToDecimal(totais.Replace(",", "."));
                    }
                    //
                    if (valor_informado.Contains("."))
                    {
                        Item.Valor_Informado = Convert.ToDecimal(valor_informado.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Informado = Convert.ToDecimal(valor_informado.Replace(",", "."));
                    }
                    //
                    if (quebra_caixa.Contains("."))
                    {
                        Item.Quebra_Caixa = Convert.ToDecimal(quebra_caixa.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Quebra_Caixa = Convert.ToDecimal(quebra_caixa.Replace(",", "."));
                    }
                    //
                    Item.Cod_Abertura_Fechamento_Caixa = Convert.ToInt32(cod_abert_fech_caixa);
                    //
                    con.Salvar_Item_Abert_Fech_Caixa(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static string Sel_Ultima_Abert_Fech_Caixa(string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Abertura_Fechamento_Caixa Cx = new Abertura_Fechamento_Caixa())
                {
                    string[] items = cod_pdv_computador.Split('/');
                    Cx.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    return con.Sel_Ultima_Abert_Fech_Caixa(Cx);
                }
            }
        }

        public static DataTable Sel_Data_Ultimo_Fech_Caixa_PDV(string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string[] items = cod_pdv_computador.Split('/');
                    Vend.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    return con.Sel_Data_Ultimo_Fech_Caixa_PDV(Vend);
                }
            }
        }

        public static string SomvarTotais(string dinheiro, string ccredito, string cdebito, string pix, string cheque, string vale_alim_ref)
        {
            decimal retorno;
            retorno = Convert.ToDecimal(dinheiro) + Convert.ToDecimal(ccredito) + Convert.ToDecimal(cdebito) + Convert.ToDecimal(pix) + Convert.ToDecimal(vale_alim_ref) + Convert.ToDecimal(cheque);
            return retorno.ToString();
        }

        public static string SomvarQuebraCaixa(string dinheiro, string ccredito, string cdebito, string pix, string cheque, string vale_alim_ref)
        {
            decimal retorno;
            retorno = Convert.ToDecimal(dinheiro) + Convert.ToDecimal(ccredito) + Convert.ToDecimal(cdebito) + Convert.ToDecimal(pix) + Convert.ToDecimal(cheque) + Convert.ToDecimal(vale_alim_ref);
            return retorno.ToString();
        }

        public static string SomvarValorInformado(string dinheiro, string ccredito, string cdebito, string pix, string cheque, string vale_alim_ref)
        {
            if (dinheiro == "")
            {
                dinheiro = dinheiro = "0";
            }
            //
            if (ccredito == "")
            {
                ccredito = ccredito = "0";
            }
            //
            if (cdebito == "")
            {
                cdebito = cdebito = "0";
            }
            //
            if (pix == "")
            {
                pix = pix = "0";
            }
            //
            if (cheque == "")
            {
                cheque = cheque = "0";
            }
            //
            if (vale_alim_ref == "")
            {
                vale_alim_ref = vale_alim_ref = "0";
            }
            //
            decimal retorno;
            retorno = Convert.ToDecimal(dinheiro) + Convert.ToDecimal(ccredito) + Convert.ToDecimal(cdebito) + Convert.ToDecimal(pix) + Convert.ToDecimal(cheque) + Convert.ToDecimal(vale_alim_ref);
            return retorno.ToString();
        }















        public static void Salvar_Abertura(string saldo_inicial, string cod_pdv_computador, string usuario, string nome_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Abertura_Fechamento_Caixa Cx = new Abertura_Fechamento_Caixa())
                {
                    Cx.Nome_Computador = nome_computador.Insert(nome_computador.Length, "'").Insert(0, "'");
                    //
                    Cx.Data_Abertura = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Cx.Hora_Abertura = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (saldo_inicial.Contains("."))
                    {
                        Cx.Saldo_Inicial = Convert.ToDecimal(saldo_inicial.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Cx.Saldo_Inicial = Convert.ToDecimal(saldo_inicial.Replace(",", "."));
                    }
                    //
                    Cx.Data_Fechamento = "null";
                    //
                    Cx.Hora_Fechamento = "null";
                    //
                    Cx.Saldo_Final = 0;
                    //
                    Cx.Total_Quebra_Caixa = 0;
                    //
                    string[] items = cod_pdv_computador.Split('/');
                    Cx.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    Cx.Observacoes = "null";
                    //
                    usuario = usuario.Remove(0, 12);
                    items = usuario.Split('—');
                    //
                    Cx.Cod_Usuario_Abertura = Convert.ToInt16(items[0]);
                    //
                    Cx.Nome_Usuario_Abertura = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Cx.Cod_Usuario_Fechamento = 0;
                    //
                    Cx.Nome_Usuario_Fechamento = "null";
                    //
                    con.Salvar_Abertura_Caixa(Cx);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static byte Sel_Aberto_Fechado_Caixa(string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Abertura_Fechamento_Caixa Cx = new Abertura_Fechamento_Caixa())
                {
                    string[] items = cod_pdv_computador.Split('/');
                    Cx.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    if (con.Sel_Aberto_Fechado_Caixa(Cx) != null)
                    {
                        if (con.Sel_Aberto_Fechado_Caixa(Cx) == "ABERTO")
                        {
                            return 0;
                        }
                        else if (con.Sel_Aberto_Fechado_Caixa(Cx) == "PAUSADO")
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
        }

        public static void Alterar_Abertura_Pausa(string cod_pdv_computador, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Abertura_Fechamento_Caixa Cx = new Abertura_Fechamento_Caixa())
                {
                    string[] items = cod_pdv_computador.Split('/');
                    Cx.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    Cx.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Abertura_Pausa(Cx);
                }
            }
        }

        public static void Alterar_Abertura_Abrir(string cod_pdv_computador, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Abertura_Fechamento_Caixa Cx = new Abertura_Fechamento_Caixa())
                {
                    string[] items = cod_pdv_computador.Split('/');
                    Cx.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    Cx.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Abertura_Abrir(Cx);
                }
            }
        }

        public static DataTable Sel_Abert_Caixa_Dados(string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Abertura_Fechamento_Caixa Cx = new Abertura_Fechamento_Caixa())
                {
                    string[] items = cod_pdv_computador.Split('/');
                    Cx.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    usuario = usuario.Remove(0, 12);
                    items = usuario.Split('—');
                    //
                    Cx.Cod_Usuario_Abertura = Convert.ToInt16(items[0]);
                    //
                    return con.Sel_Abert_Caixa_Dados(Cx);
                }
            }
        }



























        public static DataTable Sel_Usuario_Caixa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Caixa();
            }
        }

        public static DataTable Sel_Cod_PDV_Caixa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cod_PDV_Caixa();
            }
        }

        public static DataTable Sel_Abert_Fech_Caixa_Cod(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Abertura_Fechamento_Caixa Cx = new Abertura_Fechamento_Caixa())
                {
                    Cx.Pesquisar = pesquisar;
                    return con.Sel_Abert_Fech_Caixa_Cod(Cx);
                }
            }
        }

        public static DataTable Sel_Item_Abert_Fech_Caixa(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Abertura_Fechamento_Caixa Abert = new Abertura_Fechamento_Caixa())
                {
                    Abert.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Item_Abert_Fech_Caixa(Abert);
                }
            }
        }

        public static DataTable Sel_Fechamento_Caixa_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Fechamento_Caixa_A_Sal();
            }
        }

        public static DataTable Sel_Abert_Fech_Caixa_Data_Abertura(string data_inicio, string data_fim, string usuario_abertura, string usuario_fechamento, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;

                string SqlDataAbertura;
                string SqlUsuarioAbertura;
                string SqlUsuarioFechamento;
                string SqlCodPdvComputador;
                //
                SqlDataAbertura = "WHERE abert_fech_caixa.data_abertura BETWEEN '" + data_inicio.Replace("/", ".") + " 00:00' AND '" + data_fim.Replace("/", ".") + " 23.59'";
                //
                if (usuario_abertura == "")
                {
                    SqlUsuarioAbertura = "";
                }
                else
                {
                    items = usuario_abertura.Split('—');
                    SqlUsuarioAbertura = " AND abert_fech_caixa.id_usuario_abertura=" + items[0];
                }
                //
                if (usuario_fechamento == "")
                {
                    SqlUsuarioFechamento = "";
                }
                else
                {
                    items = usuario_fechamento.Split('—');
                    SqlUsuarioFechamento = " AND abert_fech_caixa.id_usuario_fechamento=" + items[0];
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
                return con.Sel_Abert_Fech_Caixa_Data_Abertura(SqlDataAbertura, SqlUsuarioAbertura, SqlUsuarioFechamento, SqlCodPdvComputador);
            }
        }

        public static DataTable Sel_Abert_Fech_Caixa_Data_Fechamento(string data_inicio, string data_fim, string usuario_abertura, string usuario_fechamento, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;

                string SqlDataFechamento;
                string SqlUsuarioAbertura;
                string SqlUsuarioFechamento;
                string SqlCodPdvComputador;
                //
                SqlDataFechamento = "WHERE abert_fech_caixa.data_fechamento BETWEEN '" + data_inicio.Replace("/", ".") + " 00:00' AND '" + data_fim.Replace("/", ".") + " 23.59'";
                //
                if (usuario_abertura == "")
                {
                    SqlUsuarioAbertura = "";
                }
                else
                {
                    items = usuario_abertura.Split('—');
                    SqlUsuarioAbertura = " AND abert_fech_caixa.id_usuario_abertura=" + items[0];
                }
                //
                if (usuario_fechamento == "")
                {
                    SqlUsuarioFechamento = "";
                }
                else
                {
                    items = usuario_fechamento.Split('—');
                    SqlUsuarioFechamento = " AND abert_fech_caixa.id_usuario_fechamento=" + items[0];
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
                return con.Sel_Abert_Fech_Caixa_Data_Fechamento(SqlDataFechamento, SqlUsuarioAbertura, SqlUsuarioFechamento, SqlCodPdvComputador);
            }
        }

        public static DataTable Sel_Abert_Fech_Caixa_Todos(string usuario_abertura, string usuario_fechamento, string cod_pdv_computador, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;

                string SqlSituacao;
                string SqlUsuarioAbertura;
                string SqlUsuarioFechamento;
                string SqlCodPdvComputador;
                //
                if (situacao == "")
                {
                    SqlSituacao = "";
                }
                else
                {
                    SqlSituacao = "WHERE abert_fech_caixa.situacao='" + situacao + "'";
                }
                //
                if (usuario_abertura == "")
                {
                    SqlUsuarioAbertura = "";
                }
                else
                {
                    items = usuario_abertura.Split('—');
                    if (situacao == "")
                    {
                        SqlUsuarioAbertura = "WHERE abert_fech_caixa.id_usuario_abertura=" + items[0];
                    }
                    else
                    {
                        SqlUsuarioAbertura = " AND abert_fech_caixa.id_usuario_abertura=" + items[0];
                    }
                }
                //
                if (usuario_fechamento == "")
                {
                    SqlUsuarioFechamento = "";
                }
                else
                {
                    items = usuario_fechamento.Split('—');
                    if (situacao == "" & usuario_abertura == "")
                    {
                        SqlUsuarioFechamento = "WHERE abert_fech_caixa.id_usuario_fechamento=" + items[0];
                    }
                    else
                    {
                        SqlUsuarioFechamento = " AND abert_fech_caixa.id_usuario_fechamento=" + items[0];
                    }
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    if (situacao == "" & usuario_abertura == "" & usuario_fechamento == "")
                    {
                        SqlCodPdvComputador = "WHERE id_pdv_computador=" + cod_pdv_computador;
                    }
                    else
                    {
                        SqlCodPdvComputador = " AND id_pdv_computador=" + cod_pdv_computador;
                    }
                }
                return con.Sel_Abert_Fech_Caixa_Todos(SqlSituacao, SqlUsuarioAbertura, SqlUsuarioFechamento, SqlCodPdvComputador);
            }
        }
    }
}
