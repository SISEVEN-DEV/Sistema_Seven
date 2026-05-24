using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Threading;

namespace BLL
{
    public class bllContasReceber
    {
        public static bool _FrmCadContaReceber_Ativo;
        public static bool _FrmRelContaReceber_Ativo;
        public static bool _FrmOpeBaixaContaReceber_Ativo;

        public static byte _Tipo_Impressao_Relatorio;
        public static string _Nome_Arquivo;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Consumidor_PesqContaReceber;
        public static string _Grupo_PesqGrupo_Tabela;
        public static string _SubGrupo_PesqSubGrupo_Tabela;
        public static string _Forma_Pagamento_PesqFormaPagamento_Tabela;
        public static string _Valor_Credito_Loja;
        public static byte _Desfazer_Baixa;




        public static string _Parcela;
        public static string _Dias;
        public static string _Data_Emissao_Multiplicada;
        public static string _Data_Vencimento_Multiplicada;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static void Salvar(string ocorrencia_parc, string descricao, string data_emissao, string data_vencimento, string grupo, string subgrupo, string valor_documento, string consumidor, string observacao, string tipo_consumidor, string palavra_chave, string tipo_documento, string valor_total_pago, string usuario_baixa, string data_baixa, string hora_baixa, string cod_venda, string situacao, string cod_pdv_computador_baixa, string cod_controle_cheque)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Data_Cadastro = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Conta.Palavra_Chave = "null";
                    }
                    else
                    {
                        Conta.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    Conta.Ocorrencia_Parc = Convert.ToInt16(ocorrencia_parc);
                    //
                    Conta.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Conta.Data_Emissao = "'" + data_emissao.Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Conta.Data_Vencimento = "'" + data_vencimento.Replace('/', '.') + " 23:59:59'";
                    //
                    Conta.Tipo_Consumidor = tipo_consumidor.Insert(tipo_consumidor.Length, "'").Insert(0, "'");
                    //
                    string[] items = consumidor.Split('—');
                    Conta.Cod_Consumidor = Convert.ToInt32(items[0]);
                    //
                    Conta.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = grupo.Split('—');
                    Conta.Cod_Grupo = Convert.ToInt16(items[0]);
                    //
                    Conta.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = subgrupo.Split('—');
                    Conta.Cod_Subgrupo = Convert.ToInt16(items[0]);
                    //
                    Conta.Desc_Subgrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    //
                    if (valor_documento.Contains("."))
                    {
                        Conta.Valor_Documento = Convert.ToDecimal(valor_documento.Replace(".", "").Replace(",", "."));
                        Conta.Valor_Real = Convert.ToDecimal(valor_documento.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Valor_Documento = Convert.ToDecimal(valor_documento.Replace(",", "."));
                        Conta.Valor_Real = Convert.ToDecimal(valor_documento.Replace(",", "."));
                    }
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Conta.Observacao = "null";
                    }
                    else
                    {
                        Conta.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    Conta.Data_Desconto = "null";
                    //
                    Conta.Desconto_Porc = 0;
                    //
                    Conta.Valor_Desconto = 0;
                    //
                    Conta.Multa_Porc = 0;
                    //
                    Conta.Valor_Multa = 0;
                    //
                    Conta.Juros_Am_Porc = 0;
                    //
                    Conta.Valor_Juros_Am = 0;
                    //
                    Conta.N_Promissoria = 0;
                    //
                    Conta.Tipo_Documento = tipo_documento.Insert(tipo_documento.Length, "'").Insert(0, "'");
                    //
                    Conta.Cod_Venda = Convert.ToInt32(cod_venda);
                    //
                    if (valor_total_pago.Contains("."))
                    {
                        Conta.Valor_Total_Pago = Convert.ToDecimal(valor_total_pago.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Valor_Total_Pago = Convert.ToDecimal(valor_total_pago.Replace(",", "."));
                    }
                    //
                    if (usuario_baixa == "" || usuario_baixa == null)
                    {
                        Conta.Cod_Usuario_Baixa = 0;
                        Conta.Nome_Usuario_Baixa = "null";
                    }
                    else
                    {
                        items = usuario_baixa.Remove(0, 12).Split('—');
                        //
                        Conta.Cod_Usuario_Baixa = Convert.ToInt16(items[0]);
                        Conta.Nome_Usuario_Baixa = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (data_baixa == "" || data_baixa == null)
                    {
                        Conta.Data_Baixa = "null";
                    }
                    else
                    {
                        Conta.Data_Baixa = "'" + data_baixa.Replace('/', '.') + " " + hora_baixa + "'";
                    }
                    //
                    if (hora_baixa == "" || hora_baixa == null)
                    {
                        Conta.Hora_Baixa = "null";
                    }
                    else
                    {
                        Conta.Hora_Baixa = hora_baixa.Insert(hora_baixa.Length, "'").Insert(0, "'");
                    }
                    //
                    Conta.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    if (cod_pdv_computador_baixa == "" || cod_pdv_computador_baixa == null)
                    {
                        Conta.Cod_PDV_Computador_Baixa = 0;
                    }
                    else
                    {
                        items = cod_pdv_computador_baixa.Split('/');
                        Conta.Cod_PDV_Computador_Baixa = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    }
                    //
                    if (cod_controle_cheque == "" || cod_controle_cheque == null)
                    {
                        Conta.Cod_Controle_Cheque = 0;
                    }
                    else
                    {
                        Conta.Cod_Controle_Cheque = Convert.ToInt32(cod_controle_cheque);
                    }
                    con.Salvar_Conta_Receber(Conta);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static bool Sel_Contas_Receber_Pagamento_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Contas_Receber_Pagamento_Ver(Conta);
                }
            }
        }


        public static bool Sel_Conta_Receber_Parcela_Existe_N_Promissoria(string parcela, string n_promissoria)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Ocorrencia_Parc = Convert.ToInt16(Convert.ToInt16(parcela) + 1);
                    Conta.N_Promissoria = Convert.ToInt32(n_promissoria);
                    return con.Sel_Conta_Receber_Parcela_Existe_N_Promissoria(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Desc(string descricao, string data_pag, string data_pag1, string data_emi, string data_emi1, string data_venc, string data_venc1, string grupo, string subgrupo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;

                    string SqlDescricao;
                    string SqlDataPag;
                    string SqlDataEmi;
                    string SqlDataVenc;
                    string SqlGrupo;
                    string SqlSubgrupo;
                    string SqlSituacao;

                    if (descricao == "")
                    {
                        SqlDescricao = "";
                    }
                    else
                    {
                        if (descricao.Contains("%"))
                        {
                            SqlDescricao = "WHERE descricao LIKE '" + descricao + "'";
                        }
                        else
                        {
                            SqlDescricao = "WHERE descricao STARTING WITH '" + descricao + "'";
                        }
                    }
                    //
                    if (data_pag.Contains("_") || data_pag1.Contains("_"))
                    {
                        SqlDataPag = "";
                    }
                    else
                    {
                        SqlDataPag = " AND data_baixa BETWEEN '" + data_pag.Replace("/", ".") + "' AND '" + data_pag1.Replace("/", ".") + "'";
                    }
                    //
                    if (data_emi.Contains("_") || data_emi1.Contains("_"))
                    {
                        SqlDataEmi = "";
                    }
                    else
                    {
                        SqlDataEmi = " AND data_emissao BETWEEN '" + data_emi.Replace("/", ".") + "' AND '" + data_emi1.Replace("/", ".") + "'";
                    }
                    //
                    if (data_venc.Contains("_") || data_venc1.Contains("_"))
                    {
                        SqlDataVenc = "";
                    }
                    else
                    {
                        SqlDataVenc = " AND data_vencimento BETWEEN '" + data_venc.Replace("/", ".") + "' AND '" + data_venc1.Replace("/", ".") + "'";
                    }
                    //
                    if (grupo == "")
                    {
                        SqlGrupo = "";
                    }
                    else
                    {
                        items = grupo.Split('—');
                        SqlGrupo = " AND id_grupo='" + items[0] + "'";
                    }
                    //
                    if (subgrupo == "")
                    {
                        SqlSubgrupo = "";
                    }
                    else
                    {
                        items = subgrupo.Split('—');
                        SqlSubgrupo = " AND id_subgrupo='" + items[0] + "'";
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
                    return con.Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Desc(SqlDescricao, SqlDataPag, SqlDataEmi, SqlDataVenc, SqlGrupo, SqlSubgrupo, SqlSituacao);
                }
            }
        }

        public static void Desfazer_refazer_Baixa_Conta_Receber(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    //                    
                    con.Desfazer_refazer_Baixa_Conta_Receber(Conta);
                }
            }
        }

        public static void Salvar_Baixa_Pagamento_Conta_Receber(string codigo, string valor_juros_am, string valor_real, string data_pagamento, string valor_total_pago, string troco, string usuario, bool ignorar_juros_am, bool ignorar_multa, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Data_Baixa = "'" + data_pagamento.Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Conta.Hora_Baixa = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Conta.Codigo = Convert.ToInt32(codigo);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (valor_juros_am.Contains("."))
                    {
                        Conta.Valor_Juros_Am = Convert.ToDecimal(valor_juros_am.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Valor_Juros_Am = Convert.ToDecimal(valor_juros_am.Replace(",", "."));
                    }
                    //
                    if (valor_real.Contains("."))
                    {
                        Conta.Valor_Real = Convert.ToDecimal(valor_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Valor_Real = Convert.ToDecimal(valor_real.Replace(",", "."));
                    }
                    //
                    if (valor_total_pago.Contains("."))
                    {
                        Conta.Valor_Total_Pago = Convert.ToDecimal(valor_total_pago.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Valor_Total_Pago = Convert.ToDecimal(valor_total_pago.Replace(",", "."));
                    }
                    //
                    if (troco.Contains("."))
                    {
                        Conta.Troco = Convert.ToDecimal(troco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Troco = Convert.ToDecimal(troco.Replace(",", "."));
                    }
                    //
                    usuario = usuario.Remove(0, 12);
                    string[] items = usuario.Split('—');
                    //
                    Conta.Cod_Usuario_Baixa = Convert.ToInt16(items[0]);
                    //
                    Conta.Nome_Usuario_Baixa = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (ignorar_juros_am == true)
                    {
                        Conta.Ignorar_Juros_Am = 1;
                    }
                    else
                    {
                        Conta.Ignorar_Juros_Am = 0;
                    }
                    //
                    if (ignorar_multa == true)
                    {
                        Conta.Ignorar_Multa = 1;
                    }
                    else
                    {
                        Conta.Ignorar_Multa = 0;
                    }
                    //
                    items = cod_pdv_computador.Split('/');
                    Conta.Cod_PDV_Computador_Baixa = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    con.Salvar_Baixa_Pagamento_Conta_Receber(Conta);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Baixa_Pagamento_Parcial_Conta_Receber(string codigo, string valor_total_pago, string data_pagamento, string data_vencimento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    //
                    if (Convert.ToDateTime(data_pagamento + " " + DateTime.Now.ToShortTimeString()) > Convert.ToDateTime(data_vencimento + " 23:59:59"))
                    {
                        Conta.Baixa_Apos_Vencimento = 1;
                    }
                    else
                    {
                        Conta.Baixa_Apos_Vencimento = 0;
                    }
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (valor_total_pago.Contains("."))
                    {
                        Conta.Valor_Total_Pago = Convert.ToDecimal(valor_total_pago.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Valor_Total_Pago = Convert.ToDecimal(valor_total_pago.Replace(",", "."));
                    }
                    //
                    con.Salvar_Baixa_Pagamento_Parcial_Conta_Receber(Conta);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Pagamento_Conta_Receber_Temp(string item, string forma_pagamento, string valor_pagamento, byte pagamento_parcial)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Conta_Receber_Pgto_Temp Pgto = new Item_Conta_Receber_Pgto_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Pgto.Codigo = Convert.ToInt16(item);
                    //
                    string[] items = forma_pagamento.Split('—');
                    //
                    Pgto.Cod_Pagamento = Convert.ToInt16(items[0]);
                    //
                    Pgto.Tipo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (valor_pagamento.Contains("."))
                    {
                        Pgto.Valor_Pago = Convert.ToDecimal(valor_pagamento.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Pgto.Valor_Pago = Convert.ToDecimal(valor_pagamento.Replace(",", "."));
                    }
                    //
                    Pgto.Pagamento_Parcial = pagamento_parcial;
                    //
                    con.Salvar_Pagamento_Conta_Receber_Temp(Pgto);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Pagamento_Conta_Receber(string cod_item_pagamento, string forma_pagamento, string valor_pagamento, string cod_conta_receber, string data_pagamento, byte pagamento_parcial, string usuario, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_Conta_Receber Pgto = new Pagamento_Conta_Receber())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items = forma_pagamento.Split('—');
                    //
                    Pgto.Data_Pagamento = "'" + data_pagamento.Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Pgto.Hora_Pagamento = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Pgto.Cod_Item_Pagamento = Convert.ToInt16(cod_item_pagamento);
                    //
                    Pgto.Cod_Pagamento = Convert.ToInt16(items[0]);
                    //
                    Pgto.Tipo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (valor_pagamento.Contains("."))
                    {
                        Pgto.Valor_Pago = Convert.ToDecimal(valor_pagamento.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Pgto.Valor_Pago = Convert.ToDecimal(valor_pagamento.Replace(",", "."));
                    }
                    //
                    Pgto.Cod_Conta_Receber = Convert.ToInt32(cod_conta_receber);
                    //
                    Pgto.Pagamento_Parcial = pagamento_parcial;
                    //
                    usuario = usuario.Remove(0, 12);
                    //
                    items = usuario.Split('—');
                    //
                    Pgto.Cod_Usuario = Convert.ToInt16(items[0]);
                    Pgto.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Pgto.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    con.Salvar_Pagamento_Conta_Receber(Pgto);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Pagamento_Conta_Receber_Todas(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Pagamento_Conta_Receber_Todas(Conta);
                }
            }
        }

        public static void Salvar_Forma_Pagamento_Conta_Receber(string item, string forma_pagamento, string valor_pagamento, byte pagamento_parcial, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Conta_Receber_Pgto_Temp Pgto = new Item_Conta_Receber_Pgto_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Pgto.Codigo = Convert.ToInt16(item);
                    //
                    string[] items = forma_pagamento.Split('—');
                    //
                    Pgto.Cod_Pagamento = Convert.ToInt16(items[0]);
                    //
                    Pgto.Tipo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (valor_pagamento.Contains("."))
                    {
                        Pgto.Valor_Pago = Convert.ToDecimal(valor_pagamento.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Pgto.Valor_Pago = Convert.ToDecimal(valor_pagamento.Replace(",", "."));
                    }
                    //
                    Pgto.Pagamento_Parcial = pagamento_parcial;
                    //
                    Pgto.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Salvar_Forma_Pagamento_Conta_Receber(Pgto);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Formas_Pagamento_Conta_Receber(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Formas_Pagamento_Conta_Receber(Conta);
                }
            }
        }

        public static bool Sel_Pagamento_Conta_Receber_Existe(string cod_conta_receber, string cod_item_pagamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_Conta_Receber Pag = new Pagamento_Conta_Receber())
                {
                    Pag.Cod_Conta_Receber = Convert.ToInt32(cod_conta_receber);
                    Pag.Cod_Item_Pagamento = Convert.ToInt16(cod_item_pagamento);
                    return con.Sel_Pagamento_Conta_Receber_Existe(Pag);
                }
            }
        }

        public static DataTable Sel_Item_Conta_Receber_Pgto_Todas(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Conta_Receber_Pgto_Temp Items = new Item_Conta_Receber_Pgto_Temp())
                {
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Item_Conta_Receber_Pgto_Todas(Items);
                }
            }
        }

        public static void Excluir_Item_Conta_Receber_Pgto_Atual(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Conta_Receber_Pgto_Temp Pgto = new Item_Conta_Receber_Pgto_Temp())
                {
                    Pgto.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Item_Conta_Receber_Pgto_Atual(Pgto);
                }
            }
        }

        public static void Excluir_Pagamento_Conta_Receber(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Pagamento_Conta_Receber(Conta);
                }
            }
        }



        public static void Excluir_Item(string cod_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Conta_Receber_Pgto_Temp Pgto = new Item_Conta_Receber_Pgto_Temp())
                {
                    Pgto.Codigo = Convert.ToInt16(cod_item);
                    con.Excluir_Item_Pgto_Conta_Receber(Pgto);
                }
            }
        }

        public static void Atualizar_Item_Dt_Pgto_Conta_Receber(int item_atual, int total_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Conta_Receber_Pgto_Temp Pgto = new Item_Conta_Receber_Pgto_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Pgto.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dt_Pgto_Conta_Receber(Pgto, item.ToString());
                    }
                }
            }
        }

        public static string Calculo_Juros_Am(string juros_am_porc, string valor_documento, string data_vencimento, string data_recebimento)
        {
            DateTime Vencimento = Convert.ToDateTime(data_vencimento);
            DateTime Recebimento = Convert.ToDateTime(data_recebimento);
            decimal juros_am = Convert.ToDecimal(juros_am_porc);
            decimal total_documento = Convert.ToDecimal(valor_documento);
            decimal resultado_porc;
            decimal retorno;
            decimal total_dias;
            //
            total_dias = Convert.ToDecimal((Convert.ToDateTime(Recebimento) - Convert.ToDateTime(Vencimento)).TotalDays);
            //
            if (total_dias > 0)
            {
                resultado_porc = Math.Round(((juros_am / 30) * total_dias), 2);
                //
                retorno = (total_documento * resultado_porc) / 100;
            }
            else
            {
                retorno = 0;
            }
            //
            return retorno.ToString();
        }

        public static string Calculo_Valor_Real(string valor_juros_am, string valor_desconto, string valor_multa, string valor_documento, string valor_vencimento, string valor_data_pagamento, bool pagamento_parcial)
        {
            decimal juros_am = Convert.ToDecimal(valor_juros_am);
            decimal multa = Convert.ToDecimal(valor_multa);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal retorno;
            //

            if (Convert.ToDateTime(valor_data_pagamento) > Convert.ToDateTime(valor_vencimento))
            {
                desconto = 0;
            }
            /*
            else if (pagamento_parcial == true)
            {
                desconto = 0;
            }
            */
            //
            if (Convert.ToDateTime(valor_data_pagamento) <= Convert.ToDateTime(valor_vencimento))
            {
                multa = 0;
            }
            //
            retorno = (juros_am + multa + valor) - desconto;
            //
            return retorno.ToString();
        }

        public static DataTable Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Todos(string data_pag, string data_pag1, string data_emi, string data_emi1, string data_venc, string data_venc1, string grupo, string subgrupo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {

                string[] items;
                string SqlDataCad;
                string SqlDataPag;
                string SqlDataEmi;
                string SqlDataVenc;
                string SqlGrupo;
                string SqlSubgrupo;
                string SqlSituacao;
                //
                SqlDataCad = "WHERE data_cadastro BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                //
                if (data_pag.Contains("_") || data_pag1.Contains("_"))
                {
                    SqlDataPag = "";
                }
                else
                {
                    SqlDataPag = " AND data_baixa BETWEEN '" + data_pag.Replace("/", ".") + " 00:00:00' AND '" + data_pag1.Replace("/", ".") + " 23:59:59'";
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
                if (data_emi.Contains("_") || data_emi1.Contains("_"))
                {
                    SqlDataEmi = "";
                }
                else
                {
                    SqlDataEmi = " AND data_emissao BETWEEN '" + data_emi.Replace("/", ".") + " 00:00:00' AND '" + data_emi1.Replace("/", ".") + " 23:59:59'";
                }
                //
                if (data_venc.Contains("_") || data_venc1.Contains("_"))
                {
                    SqlDataVenc = "";
                }
                else
                {
                    SqlDataVenc = " AND data_vencimento BETWEEN '" + data_venc.Replace("/", ".") + " 00:00:00' AND '" + data_venc1.Replace("/", ".") + " 23:59:59'";
                }
                //
                if (grupo == "")
                {
                    SqlGrupo = "";
                }
                else
                {
                    items = grupo.Split('—');
                    SqlGrupo = " AND id_grupo='" + items[0] + "'";
                }
                //
                if (subgrupo == "")
                {
                    SqlSubgrupo = "";
                }
                else
                {
                    items = subgrupo.Split('—');
                    SqlSubgrupo = " AND id_subgrupo='" + items[0] + "'";
                }
                //
                return con.Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Todos(SqlDataCad, SqlDataPag, SqlDataEmi, SqlDataVenc, SqlGrupo, SqlSubgrupo, SqlSituacao);
            }
        }

        public static DataTable Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Emit(string tipo_consumidor, string emitente, string data_pag, string data_pag1, string data_emi, string data_emi1, string data_venc, string data_venc1, string grupo, string subgrupo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;

                    string SqlTipoConsumidor;
                    string SqlEmitente;
                    string SqlDataPag;
                    string SqlDataEmi;
                    string SqlDataVenc;
                    string SqlGrupo;
                    string SqlSubgrupo;
                    string SqlSituacao;

                    if (tipo_consumidor == "")
                    {
                        SqlTipoConsumidor = "";
                    }
                    else
                    {
                        SqlTipoConsumidor = "WHERE tipo_consumidor='" + tipo_consumidor + "'";
                    }
                    //
                    if (emitente == "")
                    {
                        SqlEmitente = "";
                    }
                    else
                    {
                        items = emitente.Split('—');
                        SqlEmitente = " AND id_consumidor='" + items[0] + "'";
                    }
                    //
                    if (data_pag.Contains("_") || data_pag1.Contains("_"))
                    {
                        SqlDataPag = "";
                    }
                    else
                    {
                        SqlDataPag = " AND data_baixa BETWEEN '" + data_pag.Replace("/", ".") + "' AND '" + data_pag1.Replace("/", ".") + "'";
                    }
                    //
                    if (data_emi.Contains("_") || data_emi1.Contains("_"))
                    {
                        SqlDataEmi = "";
                    }
                    else
                    {
                        SqlDataEmi = " AND data_emissao BETWEEN '" + data_emi.Replace("/", ".") + "' AND '" + data_emi1.Replace("/", ".") + "'";
                    }
                    //
                    if (data_venc.Contains("_") || data_venc1.Contains("_"))
                    {
                        SqlDataVenc = "";
                    }
                    else
                    {
                        SqlDataVenc = " AND data_vencimento BETWEEN '" + data_venc.Replace("/", ".") + "' AND '" + data_venc1.Replace("/", ".") + "'";
                    }
                    //
                    if (grupo == "")
                    {
                        SqlGrupo = "";
                    }
                    else
                    {
                        items = grupo.Split('—');
                        SqlGrupo = " AND id_grupo='" + items[0] + "'";
                    }
                    //
                    if (subgrupo == "")
                    {
                        SqlSubgrupo = "";
                    }
                    else
                    {
                        items = subgrupo.Split('—');
                        SqlSubgrupo = " AND id_subgrupo='" + items[0] + "'";
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
                    return con.Sel_Conta_Receber_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Emit(SqlTipoConsumidor, SqlEmitente, SqlDataPag, SqlDataEmi, SqlDataVenc, SqlGrupo, SqlSubgrupo, SqlSituacao);
                }
            }
        }

        public static bool Sel_Alterar_Conta_Receber_Fechada()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                if (con.Sel_Alterar_Conta_Receber_Fechada() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void Multiplicar(string descricao, string tipo_consumidor, string consumidor, string valor_documento, string parcela_atual, string grupo, string subgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    int Parcela_Atual = Convert.ToInt32(parcela_atual) + 1;

                    for (int a = 1; a <= Convert.ToInt32(_Parcela); a++)
                    {
                        Conta.Data_Cadastro = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + "'";
                        //
                        Conta.Palavra_Chave = "null";
                        //
                        Conta.Ocorrencia_Parc = Convert.ToInt16(Parcela_Atual);
                        //
                        Conta.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                        //
                        DateTime d = Convert.ToDateTime(_Data_Vencimento_Multiplicada);
                        _Data_Vencimento_Multiplicada = d.AddDays(Convert.ToDouble(_Dias)).ToString("dd/MM/yyyy");
                        Conta.Data_Vencimento = "'" + _Data_Vencimento_Multiplicada.Replace('/', '.') + " 23:59:59'";
                        //
                        DateTime c = Convert.ToDateTime(_Data_Emissao_Multiplicada);
                        _Data_Emissao_Multiplicada = c.AddDays(Convert.ToDouble(_Dias)).ToString("dd/MM/yyyy");
                        Conta.Data_Emissao = _Data_Emissao_Multiplicada.Insert(_Data_Emissao_Multiplicada.Length, "'").Insert(0, "'").Replace('/', '.');
                        //
                        Conta.Tipo_Consumidor = tipo_consumidor.Insert(tipo_consumidor.Length, "'").Insert(0, "'");
                        //
                        string[] items = consumidor.Split('—');
                        Conta.Cod_Consumidor = Convert.ToInt32(items[0]);
                        //
                        Conta.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                        //
                        items = grupo.Split('—');
                        Conta.Cod_Grupo = Convert.ToInt16(items[0]);
                        //
                        Conta.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                        //
                        items = subgrupo.Split('—');
                        Conta.Cod_Subgrupo = Convert.ToInt16(items[0]);
                        //
                        Conta.Desc_Subgrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");

                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        //
                        if (valor_documento.Contains("."))
                        {
                            Conta.Valor_Documento = Convert.ToDecimal(valor_documento.Replace(".", "").Replace(",", "."));
                            Conta.Valor_Real = Convert.ToDecimal(valor_documento.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Valor_Documento = Convert.ToDecimal(valor_documento.Replace(",", "."));
                            Conta.Valor_Real = Convert.ToDecimal(valor_documento.Replace(",", "."));
                        }
                        //
                        Conta.Observacao = "null";
                        //
                        Conta.Data_Desconto = "null";
                        //
                        Conta.Desconto_Porc = 0;
                        //
                        Conta.Valor_Desconto = 0;
                        //
                        Conta.Multa_Porc = 0;
                        //
                        Conta.Valor_Multa = 0;
                        //
                        Conta.Juros_Am_Porc = 0;
                        //
                        Conta.Valor_Juros_Am = 0;
                        //
                        Conta.N_Promissoria = 0;
                        //
                        Conta.Tipo_Documento = "'OUTROS'";
                        //
                        Conta.Cod_Venda = 0;
                        //
                        Conta.Valor_Total_Pago = 0;
                        //
                        Conta.Cod_Usuario_Baixa = 0;
                        Conta.Nome_Usuario_Baixa = "null";
                        //
                        Conta.Data_Baixa = "null";
                        //
                        Conta.Hora_Baixa = "null";
                        //
                        Conta.Situacao = "'PENDENTE'";
                        //
                        Conta.Cod_PDV_Computador_Baixa = 0;
                        //
                        Conta.Cod_Controle_Cheque = 0;
                        //
                        con.Salvar_Conta_Receber(Conta);
                        Parcela_Atual++;
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    }
                }
            }
        }

        public static bool Sel_Conta_Receber_Aberta_True_Mult(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Conta_Receber_Aberta_True_Mult(Conta);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Conta_Receber(Conta);
                    /*
                    if (Directory.Exists(bllConfiguracoes.Sel_Digitalizacao_Local_7_dir() + @"\Conta a Pagar\" + codigo + @"\Comprovante"))
                    {
                        DirectoryInfo Dir = new DirectoryInfo(bllConfiguracoes.Sel_Digitalizacao_Local_7_dir() + @"\Conta a Pagar\" + codigo);

                        foreach (FileInfo fi in Dir.GetFiles())
                        {
                            fi.Delete();
                        }

                        foreach (DirectoryInfo di in Dir.GetDirectories())
                        {
                            di.Delete(true);
                        }

                        Directory.Delete(bllConfiguracoes.Sel_Digitalizacao_Local_7_dir() + @"\Conta a Pagar\" + codigo);
                    }
                    */
                }
            }
        }

        public static string Sel_Credito_Loja_Cliente_Conta_Receber(string cod_consumidor)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(cod_consumidor);
                    return con.Sel_Credito_Loja_Cliente_Conta_Receber(Clie);
                }
            }
        }


        public static bool Sel_Conta_Receber_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Conta_Receber_Ainda_Existe(Conta);
                }
            }
        }

        public static void Alterar(string codigo, string ocorrencia_parc, string descricao, string data_emissao, string data_vencimento, string grupo, string subgrupo, string valor_documento, string consumidor, string observacao, string tipo_consumidor, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Data_Cadastro = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Conta.Codigo = Convert.ToInt32(codigo);
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Conta.Palavra_Chave = "null";
                    }
                    else
                    {
                        Conta.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    Conta.Ocorrencia_Parc = Convert.ToInt16(ocorrencia_parc);
                    //
                    Conta.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Conta.Data_Emissao = data_emissao.Insert(data_emissao.Length, "'").Insert(0, "'").Replace('/', '.');
                    //
                    Conta.Data_Vencimento = data_vencimento.Insert(data_vencimento.Length, "'").Insert(0, "'").Replace('/', '.');
                    //
                    Conta.Tipo_Consumidor = tipo_consumidor.Insert(tipo_consumidor.Length, "'").Insert(0, "'");
                    //
                    string[] items = consumidor.Split('—');
                    Conta.Cod_Consumidor = Convert.ToInt32(items[0]);
                    //
                    Conta.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = grupo.Split('—');
                    Conta.Cod_Grupo = Convert.ToInt16(items[0]);
                    //
                    Conta.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = subgrupo.Split('—');
                    Conta.Cod_Subgrupo = Convert.ToInt16(items[0]);
                    //
                    Conta.Desc_Subgrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    //
                    if (valor_documento.Contains("."))
                    {
                        Conta.Valor_Documento = Convert.ToDecimal(valor_documento.Replace(".", "").Replace(",", "."));
                        Conta.Valor_Real = Convert.ToDecimal(valor_documento.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Valor_Documento = Convert.ToDecimal(valor_documento.Replace(",", "."));
                        Conta.Valor_Real = Convert.ToDecimal(valor_documento.Replace(",", "."));
                    }
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Conta.Observacao = "null";
                    }
                    else
                    {
                        Conta.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Alterar_Conta_Receber(Conta);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Conta_Receber_Codigo_Barra(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Pesquisar = pesquisar;
                    return con.Sel_Conta_Receber_Codigo_Barra(Conta);
                }
            }
        }

        public static DataTable Sel_Forma_Pagamento_Conta_Receber()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Forma_Pagamento_Conta_Receber();
            }
        }

        public static DataTable Sel_Grupo_Conta_Receber()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Grupo_Conta_Receber();
            }
        }

        public static DataTable Sel_Dados_Consumidor_Conta_Receber(string cod_consumidor, string tipo_consumidor)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Cod_Consumidor = Convert.ToInt32(cod_consumidor);
                    //
                    if (tipo_consumidor == "CLIENTES")
                    {
                        Conta.Tipo_Consumidor = "CLIENTE";
                    }
                    else if (tipo_consumidor == "FORNECEDORES")
                    {
                        Conta.Tipo_Consumidor = "FORNECEDOR";
                    }
                    else if (tipo_consumidor == "FUNCIONARIOS")
                    {
                        Conta.Tipo_Consumidor = "FUNCIONARIO";
                    }
                    //
                    return con.Sel_Dados_Consumidor_Conta_Receber(Conta);
                }
            }
        }

        public static DataTable Sel_Pagamento_Conta_Receber(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Pagamento_Conta_Receber(Conta);
                }
            }
        }

        public static DataTable Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Receber(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    string[] items = cbbgrupo.Split('—');
                    Conta.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Receber(Conta);
                }
            }
        }

        public static DataTable Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Receber(string cbbsubgrupo, string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    string[] items = cbbsubgrupo.Split('—');
                    Conta.Cod_Subgrupo = Convert.ToInt16(items[0]);
                    items = cbbgrupo.Split('—');
                    Conta.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Receber(Conta);
                }
            }
        }

        public static DataTable Sel_Ver_Forma_Pagamento_Conta_Receber(string forma_pagamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    string[] items = forma_pagamento.Split('—');
                    Pag.Codigo = Convert.ToInt16(items[0]);
                    return con.Sel_Ver_Forma_Pagamento_Conta_Receber(Pag);
                }
            }
        }

        public static DataTable Sel_Conta_Receber_Consumidor(string pesquisar, string tipo_consumidor)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    string[] items = pesquisar.Split('—');
                    return con.Sel_Conta_Receber_Consumidor(items[0], tipo_consumidor);
                }
            }
        }

        public static bool Sel_Baixa_Conta_Receber_Aconteceu(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Baixa_Conta_Receber_Aconteceu(Conta);
                }
            }
        }

        public static void Alterar_Situacao_Conta_Receber_Venda(string codigo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Cod_Venda = Convert.ToInt32(codigo);
                    //
                    Conta.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Situacao_Conta_Receber_Venda(Conta);
                }
            }
        }

        public static void Alterar_Situacao_Conta_Receber_Controle_Cheque(string codigo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Cod_Controle_Cheque = Convert.ToInt32(codigo);
                    //
                    Conta.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Situacao_Conta_Receber_Controle_Cheque(Conta);
                }
            }
        }

        public static bool Sel_Excluir_Conta_Receber_Fechada()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                if (con.Sel_Excluir_Conta_Receber_Fechada() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static DataTable Sel_Conta_Tipo_Consumidor(string tipo_consumidor)
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Conta_Tipo_Consumidor(tipo_consumidor);
            }
        }

        public static DataTable Sel_Conta_Receber_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Conta_Receber_A_Sal();
            }
        }

        public static DataTable Sel_Conta_Receber_Todas()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Conta_Receber_Todas();
            }
        }

        public static DataTable Sel_Conta_Receber_N_Promissoria(String n_promissoria)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Pesquisar = n_promissoria;
                    return con.Sel_Conta_Receber_N_Promissoria(Conta);
                }

            }
        }

        public static DataTable Sel_Conta_Descricao_Receber(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Conta.Pesquisar = pesquisar;
                        return con.Sel_Conta_Descricao_Receber_Like(Conta);
                    }
                    else
                    {
                        Conta.Pesquisar = pesquisar;
                        return con.Sel_Conta_Descricao_Receber(Conta);
                    }
                }
            }
        }

        public static DataTable Sel_Conta_Codigo_Receber(string codigo, string tipo_documento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    string SqlCodigo;
                    string SqlTipoDocumento;
                    //
                    SqlCodigo = "WHERE id_conta_receber=" + codigo;
                    //
                    if (tipo_documento == "")
                    {
                        SqlTipoDocumento = "";
                    }
                    else
                    {
                        SqlTipoDocumento = " AND tipo_documento='" + tipo_documento + "'";
                    }

                    return con.Sel_Conta_Codigo_Receber(SqlCodigo, SqlTipoDocumento);
                }
            }
        }

        public static DataTable Sel_Conta_Codigo_Venda_Receber(string cod_venda)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Pesquisar = cod_venda;
                    //
                    return con.Sel_Conta_Codigo_Venda_Receber(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_Codigo_Controle_Cheque_Receber(string cod_controle_cheque)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Pesquisar = cod_controle_cheque;
                    //
                    return con.Sel_Conta_Codigo_Controle_Cheque_Receber(Conta);
                }
            }
        }


        public static DataTable Sel_Conta_Palavra_Chave_Receber(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Pesquisar = pesquisar;
                    return con.Sel_Conta_Palavra_Chave_Receber(Conta);
                }
            }
        }

        public static DataTable Sel_Cliente_Conta_Receber()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_Conta_Receber();
            }
        }

        public static DataTable Sel_Forn_Conta_Receber()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Forn_Conta_Receber();
            }
        }

        public static DataTable Sel_Func_Conta_Receber()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Func_Conta_Receber();
            }
        }

        public static DataTable Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaReceber(string cbbemitente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    string[] items = cbbemitente.Split('—');
                    Conta.Cod_Consumidor = Convert.ToInt32(items[0]);
                    return con.Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaReceber(Conta);
                }
            }
        }

        public static DataTable Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaReceber(string cbbemitente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    string[] items = cbbemitente.Split('—');
                    Conta.Cod_Consumidor = Convert.ToInt32(items[0]);
                    return con.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaReceber(Conta);
                }
            }
        }

        public static DataTable Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaReceber(string cbbemitente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    string[] items = cbbemitente.Split('—');
                    Conta.Cod_Consumidor = Convert.ToInt32(items[0]);
                    return con.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaReceber(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_Receber_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Conta_Receber_A_Alt(Conta);
                }
            }
        }

        public static bool Sel_Conta_Receber_Palavra_Chave(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Palavra_Chave = palavra_chave;
                    return con.Sel_Conta_Receber_Palavra_Chave(Conta);
                }
            }
        }

        public static bool Sel_Conta_Receber_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Palavra_Chave = palavra_chave;
                    if (con.Sel_Conta_Receber_Palavra_Chave_Alt(Conta) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Conta_Receber_Palavra_Chave_Alt(Conta) == 0)
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

        public static DataTable Sel_SubGrupo_Conta_Receber(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string[] items = cbbgrupo.Split('—');
                    Prod.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_SubGrupo_Prod(Prod);
                }
            }
        }

        public static string Calculo_Multa(string valor_documento, string multa_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(multa_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Desconto(string valor_documento, string desconto_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(desconto_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Sel_Ultimo_Cod_Conta_Receber()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ultimo_Cod_Conta_Receber();
            }
        }

        public static bool Sel_Situacao_Conta(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasReceber Conta = new ContasReceber())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    if (con.Sel_Situacao_Conta_Receber(Conta) == "ABERTA")
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
