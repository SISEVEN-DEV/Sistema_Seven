using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Threading;

namespace BLL
{
    public class bllContasPagar
    {
        public static string _Parcela;
        public static string _Dias;
        public static string _Data_Emissao_Multiplicada;
        public static string _Data_Vencimento_Multiplicada;
        public static string _Data_Desconto_Multiplicada;
        public static string _N_Documento_Multiplicada;

        public static bool _FrmRelContaPagar_Ativo;
        public static bool _FrmCadContasPagar_Ativo;
        public static bool _FrmOpeBaixaContaPagar_Ativo;


        public static bool _FrmContasPagarMostrar;
        public static string _Emitente_PesqContaPagar;
        public static string _Emitente_PesqContaPagar_Tabela;
        public static string _Grupo_PesqGrupo_Tabela;
        public static string _Entidade_Bancaria_PesqEntidadeBancaria_Tabela;
        public static string _SubGrupo_PesqSubGrupo_Tabela;
        public static string _Forma_Pag_PesqFormaPag_Tabela;

        public static bool _Mostrar_Logo_Sistema;
        public static bool _Mostrar_Logo_Empresa;
        public static bool _Mostrar_Inf_Empresa;

        public static bool _ImprimirSalvar;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static byte _Tipo_Impressao_Relatorio;
        public static string _Nome_Arquivo;
        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static DataTable Sel_Forn_Cont()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Forn_Cont();
            }
        }

        public static DataTable Sel_Func_Cont()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Func_Cont();
            }
        }

        public static DataTable Sel_Cliente_Cont()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_Cont();
            }
        }

        public static DataTable Sel_Codigo_Tabela_Geradora_Conta_Pagar(string codigo, string tabela_geradora)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Cod_Fato_Gerador = Convert.ToInt32(codigo);
                    Conta.Tabela_Geradora = tabela_geradora;
                    return con.Sel_Codigo_Tabela_Geradora_Conta_Pagar(Conta);
                }
            }
        }

        public static bool Sel_Baixa_Conta_Pagar_Aconteceu(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Baixa_Conta_Pagar_Aconteceu(Conta);
                }
            }
        }

        public static bool Sel_Pagamento_Conta_Pagar_Existe(string cod_conta_pagar, string cod_item_pagamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_Conta_Pagar Pag = new Pagamento_Conta_Pagar())
                {
                    Pag.Cod_Conta_Pagar = Convert.ToInt32(cod_conta_pagar);
                    Pag.Cod_Item_Pagamento = Convert.ToInt16(cod_item_pagamento);
                    return con.Sel_Pagamento_Conta_Pagar_Existe(Pag);
                }
            }
        }

        public static bool Sel_Contas_Pagar_Pagamento_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Contas_Pagar_Pagamento_Ver(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Desc(string descricao, string data_emi, string data_emi1, string data_venc, string data_venc1, string grupo, string subgrupo, string situacao, string data_pag, string data_pag1)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;

                    string SqlDescricao;
                    string SqlDataEmi;
                    string SqlDataVenc;
                    string SqlGrupo;
                    string SqlSubgrupo;
                    string SqlSituacao;
                    string SqlDataPag;

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
                    if (data_pag.Contains("_") || data_pag1.Contains("_"))
                    {
                        SqlDataPag = "";
                    }
                    else
                    {
                        SqlDataPag = " AND data_baixa BETWEEN '" + data_pag.Replace("/", ".") + "' AND '" + data_pag1.Replace("/", ".") + "'";
                    }
                    //
                    return con.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Desc(SqlDescricao, SqlDataEmi, SqlDataVenc, SqlGrupo, SqlSubgrupo, SqlSituacao, SqlDataPag);
                }
            }
        }

        public static DataTable Sel_Forma_Pagamento_Conta_Pagar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Forma_Pagamento_Conta_Pagar();
            }
        }

        public static void Desfazer_Refazer_Baixa_Conta_Pagar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    //                    
                    con.Desfazer_Refazer_Baixa_Conta_Pagar(Conta);
                }
            }
        }

        public static DataTable Sel_Formas_Pagamento_Conta_Pagar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Formas_Pagamento_Conta_Pagar(Conta);
                }
            }
        }

        public static void Excluir_Pagamento_Conta_Pagar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Pagamento_Conta_Pagar(Conta);
                }
            }
        }

        public static DataTable Sel_Dados_Emitente_Conta_Pagar(string cod_emitente, string tipo_emitente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Cod_Emitente = Convert.ToInt32(cod_emitente);
                    //
                    if (tipo_emitente == "CLIENTES")
                    {
                        Conta.Tipo_Emitente = "CLIENTE";
                    }
                    else if (tipo_emitente == "FORNECEDORES")
                    {
                        Conta.Tipo_Emitente = "FORNECEDOR";
                    }
                    else if (tipo_emitente == "FUNCIONARIOS")
                    {
                        Conta.Tipo_Emitente = "FUNCIONARIO";
                    }
                    //
                    return con.Sel_Dados_Emitente_Conta_Pagar(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Emit(string tipo_emitente, string emitente, string data_emi, string data_emi1, string data_venc, string data_venc1, string grupo, string subgrupo, string situacao, string data_pag, string data_pag1)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;

                    string SqlTipoEmitente;
                    string SqlEmitente;
                    string SqlDataEmi;
                    string SqlDataVenc;
                    string SqlGrupo;
                    string SqlSubgrupo;
                    string SqlSituacao;
                    string SqlDataPag;

                    if (tipo_emitente == "")
                    {
                        SqlTipoEmitente = "";
                    }
                    else
                    {
                        SqlTipoEmitente = "WHERE tipo_emitente='" + tipo_emitente + "'";
                    }
                    //
                    if (emitente == "")
                    {
                        SqlEmitente = "";
                    }
                    else
                    {
                        items = emitente.Split('—');
                        SqlEmitente = " AND id_emitente='" + items[0] + "'";
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
                    if (data_pag.Contains("_") || data_pag1.Contains("_"))
                    {
                        SqlDataPag = "";
                    }
                    else
                    {
                        SqlDataPag = " AND data_baixa BETWEEN '" + data_pag.Replace("/", ".") + "' AND '" + data_pag1.Replace("/", ".") + "'";
                    }
                    //
                    return con.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Emit(SqlTipoEmitente, SqlEmitente, SqlDataEmi, SqlDataVenc, SqlGrupo, SqlSubgrupo, SqlSituacao, SqlDataPag);
                }
            }
        }

        public static void Excluir_Item(string cod_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Conta_Pagar_Pgto_Temp Pgto = new Item_Conta_Pagar_Pgto_Temp())
                {
                    Pgto.Codigo = Convert.ToInt16(cod_item);
                    con.Excluir_Item_Pgto_Conta_Pagar(Pgto);
                }
            }
        }

        public static DataTable Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Todos(string data_emi, string data_emi1, string data_venc, string data_venc1, string grupo, string subgrupo, string situacao, string data_pag, string data_pag1)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;
                    string SqlDataEmi;
                    string SqlDataVenc;
                    string SqlGrupo;
                    string SqlSubgrupo;
                    string SqlSituacao;
                    string SqlDataPag;

                    if (situacao == "")
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = "WHERE situacao='" + situacao + "'";
                    }
                    //                   
                    if (data_emi.Contains("_") || data_emi1.Contains("_"))
                    {
                        SqlDataEmi = "";
                    }
                    else
                    {
                        if (situacao == "")
                        {
                            SqlDataEmi = "WHERE data_emissao BETWEEN '" + data_emi.Replace("/", ".") + "' AND '" + data_emi1.Replace("/", ".") + "'";
                        }
                        else
                        {
                            SqlDataEmi = " AND data_emissao BETWEEN '" + data_emi.Replace("/", ".") + "' AND '" + data_emi1.Replace("/", ".") + "'";
                        }
                    }
                    //
                    if (data_venc.Contains("_") || data_venc1.Contains("_"))
                    {
                        SqlDataVenc = "";
                    }
                    else
                    {
                        if (situacao == "" & (data_emi.Contains("_") & data_emi1.Contains("_")))
                        {
                            SqlDataVenc = "WHERE data_vencimento BETWEEN '" + data_venc.Replace("/", ".") + "' AND '" + data_venc1.Replace("/", ".") + "'";
                        }
                        else
                        {
                            SqlDataVenc = " AND data_vencimento BETWEEN '" + data_venc.Replace("/", ".") + "' AND '" + data_venc1.Replace("/", ".") + "'";
                        }
                    }
                    //
                    if (grupo == "")
                    {
                        SqlGrupo = "";
                    }
                    else
                    {
                        if (situacao == "" & (data_emi.Contains("_") & data_emi1.Contains("_")) & (data_venc.Contains("_") & data_venc1.Contains("_")))
                        {
                            items = grupo.Split('—');
                            SqlGrupo = "WHERE id_grupo='" + items[0] + "'";
                        }
                        else
                        {
                            items = grupo.Split('—');
                            SqlGrupo = " AND id_grupo='" + items[0] + "'";
                        }
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
                    if (data_pag.Contains("_") || data_pag1.Contains("_"))
                    {
                        SqlDataPag = "";
                    }
                    else
                    {
                        if (situacao == "" & (data_emi.Contains("_") & data_emi1.Contains("_")) & (data_venc.Contains("_") & data_venc1.Contains("_")) & grupo == "")
                        {
                            SqlDataPag = "WHERE data_baixa BETWEEN '" + data_pag.Replace("/", ".") + "' AND '" + data_pag1.Replace("/", ".") + "'";
                        }
                        else
                        {
                            SqlDataPag = " AND data_baixa BETWEEN '" + data_pag.Replace("/", ".") + "' AND '" + data_pag1.Replace("/", ".") + "'";
                        }
                    }
                    //
                    return con.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Todos(SqlDataEmi, SqlDataVenc, SqlGrupo, SqlSubgrupo, SqlSituacao, SqlDataPag);
                }
            }
        }

        public static bool Sel_Conta_Pagar_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Conta_Pagar_Ainda_Existe(Conta);
                }
            }
        }

        public static bool Sel_Conta_Pendente_True_Mult(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Conta_Pendente_True_Mult(Conta);
                }
            }
        }

        public static void Salvar(string palavra_chave, string contrato_mat_serv, string ocorrencia_parc, string descricao, string cod_barra, string data_emissao, string data_vencimento, string tipo_documento, string tipo_emitente, string emitente, string valor_documento, string data_desconto, string desconto_porc, string valor_desconto, string multa_porc, string valor_multa, string observacao, string ndocumento, string juros_am_porc, string grupo, string subgrupo, string entidade_bancaria, string tabela_geradora, string cod_fato_gerador, string cod_pdv_computador_baixa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Data_Cadastro = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + "'";

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
                    if (contrato_mat_serv == "" || contrato_mat_serv == null)
                    {
                        Conta.Contrato_Mat_Serv = "null";
                    }
                    else
                    {
                        Conta.Contrato_Mat_Serv = contrato_mat_serv.Insert(contrato_mat_serv.Length, "'").Insert(0, "'");
                    }
                    //
                    Conta.Ocorrencia_Parc = Convert.ToInt16(ocorrencia_parc);
                    //
                    Conta.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (cod_barra == "" || cod_barra == null)
                    {
                        Conta.Cod_Barra = "null";
                    }
                    else
                    {
                        Conta.Cod_Barra = cod_barra.Insert(cod_barra.Length, "'").Insert(0, "'");
                    }
                    //
                    Conta.Data_Emissao = "'" + data_emissao.Replace('/', '.') + " 00:00:00'";
                    //
                    Conta.Data_Vencimento = "'" + data_vencimento.Replace('/', '.') + " 23:59:59'";
                    //
                    Conta.Tipo_Documento = tipo_documento.Insert(tipo_documento.Length, "'").Insert(0, "'");
                    //
                    Conta.Tipo_Emitente = tipo_emitente.Insert(tipo_emitente.Length, "'").Insert(0, "'");
                    //
                    string[] items = emitente.Split('—');
                    Conta.Cod_Emitente = Convert.ToInt32(items[0]);
                    //
                    Conta.Nome_Emitente = items[1].Insert(items[1].Length, "'").Insert(0, "'");
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
                    if (data_desconto == "" || data_desconto == "__/__/____" || data_desconto == "  /  /" || data_desconto == null)
                    {
                        Conta.Data_Desconto = "null";
                    }
                    else
                    {
                        Conta.Data_Desconto = "'" + data_desconto.Replace('/', '.') + " 23:59:59'";
                    }
                    //
                    if (desconto_porc == "" || desconto_porc == null)
                    {
                        Conta.Desconto_Porc = 0;
                    }
                    else
                    {
                        if (desconto_porc.Contains("."))
                        {
                            Conta.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_desconto == "" || valor_desconto == null)
                    {
                        Conta.Valor_Desconto = 0;
                    }
                    else
                    {
                        if (valor_desconto.Contains("."))
                        {
                            Conta.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                        }
                    }
                    //
                    if (multa_porc == "" || multa_porc == null)
                    {
                        Conta.Multa_Porc = 0;
                    }
                    else
                    {
                        if (multa_porc.Contains("."))
                        {
                            Conta.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_multa == "" || valor_multa == null)
                    {
                        Conta.Valor_Multa = 0;
                    }
                    else
                    {
                        if (valor_multa.Contains("."))
                        {
                            Conta.Valor_Multa = Convert.ToDecimal(valor_multa.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Valor_Multa = Convert.ToDecimal(valor_multa.Replace(",", "."));
                        }
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
                    if (ndocumento == "" || ndocumento == null)
                    {
                        Conta.Numero_Documento = "null";
                    }
                    else
                    {
                        Conta.Numero_Documento = ndocumento.Insert(ndocumento.Length, "'").Insert(0, "'");
                    }
                    //
                    if (juros_am_porc == "" || juros_am_porc == null)
                    {
                        Conta.Juros_Am_Porc = 0;
                    }
                    else
                    {
                        if (juros_am_porc.Contains("."))
                        {
                            Conta.Juros_Am_Porc = Convert.ToDecimal(juros_am_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Juros_Am_Porc = Convert.ToDecimal(juros_am_porc.Replace(",", "."));
                        }
                    }
                    //               
                    if (entidade_bancaria == "" || entidade_bancaria == null)
                    {
                        Conta.Cod_Entidade_Bancaria = 0;
                        //
                        Conta.Desc_Entidade_Bancaria = "null";
                    }
                    else
                    {
                        items = entidade_bancaria.Split('—');
                        //
                        Conta.Cod_Entidade_Bancaria = Convert.ToInt16(items[0]);
                        //
                        Conta.Desc_Entidade_Bancaria = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (tabela_geradora == "" || tabela_geradora == null)
                    {
                        Conta.Tabela_Geradora = "null";
                    }
                    else
                    {
                        Conta.Tabela_Geradora = tabela_geradora.Insert(tabela_geradora.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cod_fato_gerador == "" || cod_fato_gerador == null)
                    {
                        Conta.Cod_Fato_Gerador = 0;
                    }
                    else
                    {
                        Conta.Cod_Fato_Gerador = Convert.ToInt32(cod_fato_gerador);
                    }
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
                    con.Salvar_Conta(Conta);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }


        public static string Sel_Ultimo_Cod_Conta_Pagar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ultimo_Cod_Conta_Pagar();
            }
        }

        public static DataTable Sel_Grupo_Conta_Pagar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Grupo_Conta_Pagar();
            }
        }

        public static DataTable Sel_Entidade_Bancaria_Conta_Pagar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Entidade_Bancaria_Conta_Pagar();
            }
        }

        public static bool Sel_Conta_Ndoc_ContMatServ(string ndoc, string contmatserv)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Numero_Documento = ndoc;
                    Conta.Contrato_Mat_Serv = contmatserv;
                    return con.Sel_Conta_Ndoc_ContMatServ(Conta);
                }
            }
        }

        public static bool Sel_Conta_Ndoc_ContMatServ_Alt(string codigo, string ndoc, string contmatserv)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Numero_Documento = ndoc;
                    Conta.Contrato_Mat_Serv = contmatserv;
                    if (con.Sel_Conta_Ndoc_ContMatServ_Alt(Conta) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Conta_Ndoc_ContMatServ_Alt(Conta) == 0)
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

        public static DataTable Sel_SubGrupo_Conta_Pagar(string cbbgrupo)
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

        public static DataTable Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Pagar(string cbbsubgrupo, string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    string[] items = cbbsubgrupo.Split('—');
                    Conta.Cod_Subgrupo = Convert.ToInt16(items[0]);
                    items = cbbgrupo.Split('—');
                    Conta.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxSubGrupo_Valor_A_Alterar_Conta_Pagar(Conta);
                }
            }
        }

        public static void Multiplicar(string contrato_mat_serv, string descricao, string tipo_documento, string tipo_emitente, string emitente, string valor_documento, string desconto_porc, string valor_desconto, string multa_porc, string valor_multa, string mora_porc, string parcela_atual, string grupo, string subgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    int Parcela_Atual = Convert.ToInt32(parcela_atual) + 1;

                    for (int a = 1; a <= Convert.ToInt32(_Parcela); a++)
                    {
                        Conta.Data_Cadastro = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + "'";
                        //
                        Conta.Palavra_Chave = "null";
                        //
                        Conta.Contrato_Mat_Serv = contrato_mat_serv.Insert(contrato_mat_serv.Length, "'").Insert(0, "'");
                        //
                        Conta.Ocorrencia_Parc = Convert.ToInt16(Parcela_Atual);
                        //
                        Conta.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                        //
                        Conta.Cod_Barra = "null";
                        //
                        DateTime d = Convert.ToDateTime(_Data_Vencimento_Multiplicada);
                        _Data_Vencimento_Multiplicada = d.AddDays(Convert.ToDouble(_Dias)).ToString("dd/MM/yyyy");
                        Conta.Data_Vencimento = "'" + _Data_Vencimento_Multiplicada.Replace('/', '.') + " 23:59:59'";
                        //
                        DateTime c = Convert.ToDateTime(_Data_Emissao_Multiplicada);
                        _Data_Emissao_Multiplicada = c.AddDays(Convert.ToDouble(_Dias)).ToString("dd/MM/yyyy");
                        Conta.Data_Emissao = "'" + _Data_Emissao_Multiplicada.Replace('/', '.') + " 00:00:00'";
                        //
                        if (_Data_Desconto_Multiplicada == "" || _Data_Desconto_Multiplicada == "__/__/____" || _Data_Desconto_Multiplicada == "  /  /")
                        {
                            Conta.Data_Desconto = "null";
                        }
                        else
                        {
                            DateTime x = Convert.ToDateTime(_Data_Desconto_Multiplicada);
                            _Data_Desconto_Multiplicada = x.AddDays(Convert.ToDouble(_Dias)).ToString("dd/MM/yyyy");
                            Conta.Data_Desconto = "'" + _Data_Desconto_Multiplicada.Replace('/', '.') + " 23:59:59'";
                        }
                        //                        
                        if (_N_Documento_Multiplicada == "")
                        {
                            Conta.Numero_Documento = "null";
                        }
                        else
                        {
                            _N_Documento_Multiplicada = (Convert.ToInt64(_N_Documento_Multiplicada) + 1).ToString();
                            Conta.Numero_Documento = _N_Documento_Multiplicada.Insert(_N_Documento_Multiplicada.Length, "'").Insert(0, "'");
                        }
                        //
                        Conta.Tipo_Documento = tipo_documento.Insert(tipo_documento.Length, "'").Insert(0, "'");
                        //
                        if (contrato_mat_serv == "")
                        {
                            Conta.Contrato_Mat_Serv = "null";
                        }
                        else
                        {
                            Conta.Contrato_Mat_Serv = contrato_mat_serv.Insert(contrato_mat_serv.Length, "'").Insert(0, "'");
                        }
                        //
                        Conta.Tipo_Emitente = tipo_emitente.Insert(tipo_emitente.Length, "'").Insert(0, "'");
                        //
                        string[] items = emitente.Split('—');
                        Conta.Cod_Emitente = Convert.ToInt32(items[0]);
                        //
                        Conta.Nome_Emitente = items[1].Insert(items[1].Length, "'").Insert(0, "'");
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
                        if (desconto_porc == "")
                        {
                            Conta.Desconto_Porc = 0;
                        }
                        else
                        {
                            if (desconto_porc.Contains("."))
                            {
                                Conta.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                            }
                            else
                            {
                                Conta.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", "."));
                            }
                        }
                        //
                        if (valor_desconto == "")
                        {
                            Conta.Valor_Desconto = 0;
                        }
                        else
                        {
                            if (valor_desconto.Contains("."))
                            {
                                Conta.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                            }
                            else
                            {
                                Conta.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                            }
                        }
                        //
                        if (multa_porc == "")
                        {
                            Conta.Multa_Porc = 0;
                        }
                        else
                        {
                            if (multa_porc.Contains("."))
                            {
                                Conta.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(".", "").Replace(",", "."));
                            }
                            else
                            {
                                Conta.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(",", "."));
                            }
                        }
                        //
                        if (valor_multa == "")
                        {
                            Conta.Valor_Multa = 0;
                        }
                        else
                        {
                            if (valor_multa.Contains("."))
                            {
                                Conta.Valor_Multa = Convert.ToDecimal(valor_multa.Replace(".", "").Replace(",", "."));
                            }
                            else
                            {
                                Conta.Valor_Multa = Convert.ToDecimal(valor_multa.Replace(",", "."));
                            }
                        }
                        //
                        if (mora_porc == "")
                        {
                            Conta.Juros_Am_Porc = 0;
                        }
                        else
                        {
                            if (mora_porc.Contains("."))
                            {
                                Conta.Juros_Am_Porc = Convert.ToDecimal(mora_porc.Replace(".", "").Replace(",", "."));
                            }
                            else
                            {
                                Conta.Juros_Am_Porc = Convert.ToDecimal(mora_porc.Replace(",", "."));
                            }
                        }
                        //
                        Conta.Observacao = "null";
                        //
                        con.Salvar_Conta(Conta);
                        Parcela_Atual++;
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    }
                }
            }
        }

        public static void Alterar(string codigo, string palavra_chave, string contrato_mat_serv, string ocorrencia_parc, string descricao, string cod_barra, string data_emissao, string data_vencimento, string tipo_documento, string tipo_emitente, string emitente, string valor_documento, string data_desconto, string desconto_porc, string valor_desconto, string multa_porc, string valor_multa, string observacao, string ndocumento, string juros_am_porc, string grupo, string subgrupo, string entidade_bancaria)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

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
                    if (contrato_mat_serv == "" || contrato_mat_serv == null)
                    {
                        Conta.Contrato_Mat_Serv = "null";
                    }
                    else
                    {
                        Conta.Contrato_Mat_Serv = contrato_mat_serv.Insert(contrato_mat_serv.Length, "'").Insert(0, "'");
                    }
                    //
                    Conta.Ocorrencia_Parc = Convert.ToInt16(ocorrencia_parc);
                    //
                    Conta.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (cod_barra == "" || cod_barra == null)
                    {
                        Conta.Cod_Barra = "null";
                    }
                    else
                    {
                        Conta.Cod_Barra = cod_barra.Insert(cod_barra.Length, "'").Insert(0, "'");
                    }
                    //
                    Conta.Data_Emissao = "'" + data_emissao.Replace('/', '.') + " 00:00:00'";
                    //
                    Conta.Data_Vencimento = "'" + data_vencimento.Replace('/', '.') + " 23:59:59'";
                    //
                    Conta.Tipo_Documento = tipo_documento.Insert(tipo_documento.Length, "'").Insert(0, "'");
                    //
                    Conta.Tipo_Emitente = tipo_emitente.Insert(tipo_emitente.Length, "'").Insert(0, "'");
                    //
                    string[] items = emitente.Split('—');
                    Conta.Cod_Emitente = Convert.ToInt32(items[0]);
                    //
                    Conta.Nome_Emitente = items[1].Insert(items[1].Length, "'").Insert(0, "'");
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
                    if (data_desconto == "" || data_desconto == "__/__/____" || data_desconto == "  /  /" || data_desconto == null)
                    {
                        Conta.Data_Desconto = "null";
                    }
                    else
                    {
                        Conta.Data_Desconto = "'" + data_desconto.Replace('/', '.') + " 23:59:59'";
                    }
                    //
                    if (desconto_porc == "" || desconto_porc == null)
                    {
                        Conta.Desconto_Porc = 0;
                    }
                    else
                    {
                        if (desconto_porc.Contains("."))
                        {
                            Conta.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_desconto == "" || valor_desconto == null)
                    {
                        Conta.Valor_Desconto = 0;
                    }
                    else
                    {
                        if (valor_desconto.Contains("."))
                        {
                            Conta.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                        }
                    }
                    //
                    if (multa_porc == "" || multa_porc == null)
                    {
                        Conta.Multa_Porc = 0;
                    }
                    else
                    {
                        if (multa_porc.Contains("."))
                        {
                            Conta.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_multa == "" || valor_multa == null)
                    {
                        Conta.Valor_Multa = 0;
                    }
                    else
                    {
                        if (valor_multa.Contains("."))
                        {
                            Conta.Valor_Multa = Convert.ToDecimal(valor_multa.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Valor_Multa = Convert.ToDecimal(valor_multa.Replace(",", "."));
                        }
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
                    if (ndocumento == "" || ndocumento == null)
                    {
                        Conta.Numero_Documento = "null";
                    }
                    else
                    {
                        Conta.Numero_Documento = ndocumento.Insert(ndocumento.Length, "'").Insert(0, "'");
                    }
                    //
                    if (juros_am_porc == "" || juros_am_porc == null)
                    {
                        Conta.Juros_Am_Porc = 0;
                    }
                    else
                    {
                        if (juros_am_porc.Contains("."))
                        {
                            Conta.Juros_Am_Porc = Convert.ToDecimal(juros_am_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Conta.Juros_Am_Porc = Convert.ToDecimal(juros_am_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (entidade_bancaria == "" || entidade_bancaria == null)
                    {
                        Conta.Cod_Entidade_Bancaria = 0;
                        //
                        Conta.Desc_Entidade_Bancaria = "null";
                    }
                    else
                    {
                        items = entidade_bancaria.Split('—');
                        //
                        Conta.Cod_Entidade_Bancaria = Convert.ToInt16(items[0]);
                        //
                        Conta.Desc_Entidade_Bancaria = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    con.Alterar_Conta(Conta);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir(string codigo, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Conta(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Conta_A_Sal();
            }
        }

        public static DataTable Sel_Conta_Todas()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Conta_Todas();
            }
        }

        public static DataTable Sel_Conta_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Conta.Pesquisar = pesquisar;
                        return con.Sel_Conta_Descricao_Like(Conta);
                    }
                    else
                    {
                        Conta.Pesquisar = pesquisar;
                        return con.Sel_Conta_Descricao(Conta);
                    }
                }
            }
        }

        public static DataTable Sel_Conta_Tabela_Geradora(string tabela, string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    string SqlTabela;
                    string SqlCodigo;
                    //
                    SqlTabela = "WHERE tabela_geradora='" + tabela + "'";
                    //
                    if (codigo == "")
                    {
                        SqlCodigo = "";
                    }
                    else
                    {
                        SqlCodigo = " AND id_fato_gerador=" + codigo;
                    }
                    //
                    return con.Sel_Conta_Tabela_Geradora(SqlTabela, SqlCodigo);
                }
            }
        }

        public static DataTable Sel_Conta_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Pesquisar = pesquisar;
                    return con.Sel_Conta_Codigo(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_N_Documento(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Pesquisar = pesquisar;
                    return con.Sel_Conta_N_Documento(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Contrato(string cont_mat_serv, string data_emi, string data_emi1, string data_venc, string data_venc1, string grupo, string subgrupo, string situacao, string data_pag, string data_pag1)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;

                    string SqlContMatServ;
                    string SqlDataEmi;
                    string SqlDataVenc;
                    string SqlGrupo;
                    string SqlSubgrupo;
                    string SqlSituacao;
                    string SqlDataPag;

                    if (cont_mat_serv == "")
                    {
                        SqlContMatServ = "";
                    }
                    else
                    {

                        SqlContMatServ = "WHERE contrato_serv_mat='" + cont_mat_serv + "'";
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
                    if (data_pag.Contains("_") || data_pag1.Contains("_"))
                    {
                        SqlDataPag = "";
                    }
                    else
                    {
                        SqlDataPag = " AND data_baixa BETWEEN '" + data_pag.Replace("/", ".") + "' AND '" + data_pag1.Replace("/", ".") + "'";
                    }
                    //
                    return con.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Contrato(SqlContMatServ, SqlDataEmi, SqlDataVenc, SqlGrupo, SqlSubgrupo, SqlSituacao, SqlDataPag);
                }
            }
        }

        public static DataTable Sel_Conta_Pagar_ContratoMatriculaServico(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Pesquisar = pesquisar;
                    return con.Sel_Conta_Pagar_ContratoMatriculaServico(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_Codigo_Barra(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Pesquisar = pesquisar;
                    return con.Sel_Conta_Codigo_Barra(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_Emitente(string pesquisar, string tipo_emitente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    string[] items = pesquisar.Split('—');
                    return con.Sel_Conta_Emitente(items[0], tipo_emitente);
                }
            }
        }

        public static DataTable Sel_Conta_Tipo_Emitente(string tipo_emitente)
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Conta_Tipo_Emitente(tipo_emitente);
            }
        }

        public static DataTable Sel_Conta_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Conta_A_Alt(Conta);
                }
            }
        }

        public static DataTable Sel_Conta_Codigo_Palavra_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Pesquisar = pesquisar;
                    return con.Sel_Conta_Codigo_Palavra_Chave(Conta);
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

        public static string Calculo_Multa(string valor_documento, string multa_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(multa_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_ValorMulta(string valor_documento, string valor_multa)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal desconto = Convert.ToDecimal(valor_multa);
            decimal retorno = (desconto) / valor * 100;
            return Math.Round(retorno, 2).ToString();
        }

        public static void Salvar_Forma_Pagamento(string item, string forma_pagamento, string valor_pagamento, byte pagamento_parcial, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Conta_Pagar_Pgto_Temp Pgto = new Item_Conta_Pagar_Pgto_Temp())
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
                    con.Salvar_Pagamento_Conta_Pagar(Pgto);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Pagamento_Conta_Pagar(string cod_item_pagamento, string forma_pagamento, string valor_pagamento, string cod_conta_receber, string desc_conta_receber, string data_pagamento, byte pagamento_parcial, string usuario, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_Conta_Pagar Pgto = new Pagamento_Conta_Pagar())
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
                    Pgto.Cod_Conta_Pagar = Convert.ToInt32(cod_conta_receber);
                    //
                    Pgto.Pagamento_Parcial = pagamento_parcial;
                    //
                    usuario = usuario.Remove(0, 12);
                    items = usuario.Split('—');
                    //
                    Pgto.Cod_Usuario = Convert.ToInt16(items[0]);
                    //
                    Pgto.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Pgto.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    con.Salvar_Pagamento_Conta_Pagar(Pgto);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Item_Conta_Pagar_Pgto_Todas()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Item_Conta_Pagar_Pgto_Todas();
            }
        }

        public static void Atualizar_Item_Dt_Pgto_Conta_Pagar(int item_atual, int total_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Conta_Pagar_Pgto_Temp Pgto = new Item_Conta_Pagar_Pgto_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Pgto.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dt_Pgto_Conta_Pagar(Pgto, item.ToString());
                    }
                }
            }
        }

        public static void Salvar_Baixa_Pagamento_Conta_Pagar(string codigo, string valor_juros_am, string valor_real, string data_baixa, string valor_total_pago, string troco, string usuario, string cod_pdv_computador_baixa, bool descontar_caixa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Data_Baixa = "'" + data_baixa.Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
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
                    items = cod_pdv_computador_baixa.Split('/');
                    Conta.Cod_PDV_Computador_Baixa = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    if (descontar_caixa == true)
                    {
                        Conta.Descontar_Caixa = 1;
                    }
                    else
                    {
                        Conta.Descontar_Caixa = 0;
                    }
                    //                   
                    con.Salvar_Baixa_Pagamento_Conta_Pagar(Conta);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Baixa_Pagamento_Parcial_Conta_Pagar(string codigo, string valor_real, string valor_total_pago, string data_baixa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    //
                    Conta.Data_Baixa = "'" + data_baixa.Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Conta.Hora_Baixa = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
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
                    con.Salvar_Baixa_Pagamento_Parcial_Conta_Pagar(Conta);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir_Item_Conta_Pagar_Pgto_Atual()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                con.Excluir_Item_Conta_Pagar_Pgto_Atual();
            }
        }

        public static DataTable Sel_Pagamento_Conta_Pagar_Todas(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Pagamento_Conta_Pagar_Todas(Conta);
                }
            }
        }

        public static DataTable Sel_Pagamento_Conta_Pagar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Pagamento_Conta_Pagar(Conta);
                }
            }
        }

        public static string Calculo_Valor_Real(string valor_juros_am, string valor_desconto, string valor_multa, string valor_documento, string valor_vencimento, string valor_data_pagamento)
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

        public static bool Sel_Conta_Palavra_Chave(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Palavra_Chave = palavra_chave;
                    return con.Sel_Conta_Palavra_Chave(Conta);
                }
            }
        }

        public static bool Sel_Conta_Barra(string barra)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Cod_Barra = barra;
                    return con.Sel_Conta_Barra(Conta);
                }
            }
        }

        public static bool Sel_Conta_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Palavra_Chave = palavra_chave;
                    if (con.Sel_Conta_Palavra_Chave_Alt(Conta) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Conta_Palavra_Chave_Alt(Conta) == 0)
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

        public static bool Sel_Conta_Barra_Alt(string codigo, string barra)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    Conta.Cod_Barra = barra;
                    if (con.Sel_Conta_Barra_Alt(Conta) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Conta_Barra_Alt(Conta) == 0)
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

        public static DataTable Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaPagar(string cbbemitente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    string[] items = cbbemitente.Split('—');
                    Conta.Cod_Emitente = Convert.ToInt32(items[0]);
                    return con.Sel_ComboboxFuncao_Valor_A_Alterar_Cliente_ContaPagar(Conta);
                }
            }
        }

        public static DataTable Sel_ComboboxFuncao_Valor_A_Alterar_EntBancaria_ContaPagar(string cbbentbancaria)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    string[] items = cbbentbancaria.Split('—');
                    Conta.Cod_Entidade_Bancaria = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxFuncao_Valor_A_Alterar_EntBancaria_ContaPagar(Conta);
                }
            }
        }

        public static DataTable Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaPagar(string cbbemitente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    string[] items = cbbemitente.Split('—');
                    Conta.Cod_Emitente = Convert.ToInt32(items[0]);
                    return con.Sel_ComboboxFuncao_Valor_A_Alterar_Fornecedor_ContaPagar(Conta);
                }
            }
        }

        public static DataTable Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaPagar(string cbbemitente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    string[] items = cbbemitente.Split('—');
                    Conta.Cod_Emitente = Convert.ToInt32(items[0]);
                    return con.Sel_ComboboxFuncao_Valor_A_Alterar_Funcionario_ContaPagar(Conta);
                }
            }
        }

        public static DataTable Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Pagar(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ContasPagar Conta = new ContasPagar())
                {
                    string[] items = cbbgrupo.Split('—');
                    Conta.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxGrupo_Valor_A_Alterar_Conta_Pagar(Conta);
                }
            }
        }
    }
}
