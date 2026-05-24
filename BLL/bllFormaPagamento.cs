using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Threading;

namespace BLL
{
    public class bllFormaPagamento
    {
        public static bool _FrmCadFormaPagamento_Ativo;
        public static bool _FrmSimuFormaPagamento_Ativo;
        public static bool _FrmRelFormaPagamento_Ativo;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Entidade_Bancaria_PesqEntidadeBancaria_Tabela;

        public static string _Cod_Forma_Pagamento_Cadastro;

        public static void Salvar(string descricao, string multa, string entrada, string parcela, string dia_primeiro_pagamento, string tipo, string juros_mora, string desconto_fixo_porc, string acrescimo_fixo_porc, string entidade_bancaria, string tipo_operacao, string desconto_porc, string dia_duracao_desconto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Pag.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    Pag.Parcela = Convert.ToInt16(parcela);
                    //
                    Pag.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (multa == "" || multa == null)
                    {
                        Pag.Multa_Porc = 0;
                    }
                    else
                    {
                        if (multa.Contains("."))
                        {
                            Pag.Multa_Porc = Convert.ToDecimal(multa.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Multa_Porc = Convert.ToDecimal(multa.Replace(",", "."));
                        }
                    }
                    //
                    if (desconto_fixo_porc == "" || desconto_fixo_porc == null)
                    {
                        Pag.Desconto_Fixo_Porc = 0;
                    }
                    else
                    {
                        if (desconto_fixo_porc.Contains("."))
                        {
                            Pag.Desconto_Fixo_Porc = Convert.ToDecimal(desconto_fixo_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Desconto_Fixo_Porc = Convert.ToDecimal(desconto_fixo_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (acrescimo_fixo_porc == "" || acrescimo_fixo_porc == null)
                    {
                        Pag.Acrescimo_Fixo_Porc = 0;
                    }
                    else
                    {
                        if (acrescimo_fixo_porc.Contains("."))
                        {
                            Pag.Acrescimo_Fixo_Porc = Convert.ToDecimal(acrescimo_fixo_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Acrescimo_Fixo_Porc = Convert.ToDecimal(acrescimo_fixo_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (entrada == "" || entrada == null)
                    {
                        Pag.Entrada_Porc = 0;
                    }
                    else
                    {
                        if (entrada.Contains("."))
                        {
                            Pag.Entrada_Porc = Convert.ToDecimal(entrada.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Entrada_Porc = Convert.ToDecimal(entrada.Replace(",", "."));
                        }
                    }
                    //
                    Pag.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    if (dia_primeiro_pagamento == "" || dia_primeiro_pagamento == null)
                    {
                        Pag.Dia_Primeiro_Pagamento = 0;
                    }
                    else
                    {
                        Pag.Dia_Primeiro_Pagamento = Convert.ToInt16(dia_primeiro_pagamento);
                    }
                    //
                    if (juros_mora == "" || juros_mora == null)
                    {
                        Pag.Juros_Mora_Porc = 0;
                    }
                    else
                    {
                        if (juros_mora.Contains("."))
                        {
                            Pag.Juros_Mora_Porc = Convert.ToDecimal(juros_mora.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Juros_Mora_Porc = Convert.ToDecimal(juros_mora.Replace(",", "."));
                        }
                    }
                    //
                    if (entidade_bancaria == "" || entidade_bancaria == null)
                    {
                        Pag.Cod_Entidade_Bancaria = 0;
                        //
                        Pag.Desc_Entidade_Bancaria = "null";
                    }
                    else
                    {
                        string[] items = entidade_bancaria.Split('—');
                        //
                        Pag.Cod_Entidade_Bancaria = Convert.ToInt16(items[0]);
                        //
                        Pag.Desc_Entidade_Bancaria = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    Pag.Tipo_Operacao = tipo_operacao.Insert(tipo_operacao.Length, "'").Insert(0, "'");
                    //
                    if (desconto_porc == "" || desconto_porc == null)
                    {
                        Pag.Desconto_Porc = 0;
                    }
                    else
                    {
                        if (desconto_porc.Contains("."))
                        {
                            Pag.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (dia_duracao_desconto == "")
                    {
                        Pag.Dia_Duracao_Desconto = 0;
                    }
                    else
                    {
                        Pag.Dia_Duracao_Desconto = Convert.ToInt16(dia_duracao_desconto);
                    }
                    //
                    con.Salvar_Forma_Pagamento(Pag);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static bool Sel_Forma_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Forma_Ainda_Existe(Pag);
                }
            }
        }

        public static DataTable Sel_Plano_Nota_Prom_Existe(string parcela, string entrada_porc, string multa_porc, string juros_mora_porc)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Forma = new FormaPagamento())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Forma.Parcela = Convert.ToInt16(parcela);
                    //
                    if (entrada_porc == "")
                    {
                        Forma.Entrada_Porc = 0;
                    }
                    else
                    {
                        if (entrada_porc.Contains("."))
                        {
                            Forma.Entrada_Porc = Convert.ToDecimal(entrada_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Forma.Entrada_Porc = Convert.ToDecimal(entrada_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (multa_porc == "")
                    {
                        Forma.Multa_Porc = 0;
                    }
                    else
                    {
                        if (multa_porc.Contains("."))
                        {
                            Forma.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Forma.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (juros_mora_porc == "")
                    {
                        Forma.Juros_Mora_Porc = 0;
                    }
                    else
                    {
                        if (juros_mora_porc.Contains("."))
                        {
                            Forma.Juros_Mora_Porc = Convert.ToDecimal(juros_mora_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Forma.Juros_Mora_Porc = Convert.ToDecimal(juros_mora_porc.Replace(",", "."));
                        }
                    }
                    //
                    DataTable Retorno = con.Sel_Plano_Nota_Prom_Existe(Forma);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    //
                    return Retorno;
                }
            }
        }

        public static bool Sel_Forma_Pagamento_Conta_Pagar_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Forma_Pagamento_Conta_Pagar_Ver(Pag);
                }
            }
        }

        public static string Sel_Ultima_Forma_Pagamento()
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    return con.Sel_Ultima_Forma_Pagamento();
                }
            }
        }

        public static bool Sel_Forma_Pagamento_Venda_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Forma_Pagamento_Venda_Ver(Pag);
                }
            }
        }

        public static bool Sel_Forma_Pagamento_Conta_Receber_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Forma_Pagamento_Conta_Receber_Ver(Pag);
                }
            }
        }

        public static bool Sel_Forma_Pagamento_Devolucao_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Forma_Pagamento_Devolucao_Ver(Pag);
                }
            }
        }

        public static bool Sel_Forma_Pagamento_DFe_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Forma_Pagamento_DFe_Ver(Pag);
                }
            }
        }

        public static void Alterar(string codigo, string descricao, string multa, string entrada, string parcela, string dia_primeiro_pagamento, string tipo, string juros_mora, string desconto_fixo_porc, string acrescimo_fixo_porc, string entidade_bancaria, string tipo_operacao, string desconto_porc, string dia_duracao_desconto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                    Pag.Codigo = Convert.ToInt16(codigo);
                    //
                    Pag.Parcela = Convert.ToInt16(parcela);
                    //
                    Pag.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //                    
                    if (multa == "")
                    {
                        Pag.Multa_Porc = 0;
                    }
                    else
                    {
                        if (multa.Contains("."))
                        {
                            Pag.Multa_Porc = Convert.ToDecimal(multa.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Multa_Porc = Convert.ToDecimal(multa.Replace(",", "."));
                        }
                    }
                    //
                    if (entrada == "")
                    {
                        Pag.Entrada_Porc = 0;
                    }
                    else
                    {
                        if (entrada.Contains("."))
                        {
                            Pag.Entrada_Porc = Convert.ToDecimal(entrada.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Entrada_Porc = Convert.ToDecimal(entrada.Replace(",", "."));
                        }
                    }
                    //
                    Pag.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    if (dia_primeiro_pagamento == "")
                    {
                        Pag.Dia_Primeiro_Pagamento = 0;
                    }
                    else
                    {
                        Pag.Dia_Primeiro_Pagamento = Convert.ToInt16(dia_primeiro_pagamento);
                    }
                    //  
                    if (desconto_fixo_porc == "")
                    {
                        Pag.Desconto_Fixo_Porc = 0;
                    }
                    else
                    {
                        if (desconto_fixo_porc.Contains("."))
                        {
                            Pag.Desconto_Fixo_Porc = Convert.ToDecimal(desconto_fixo_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Desconto_Fixo_Porc = Convert.ToDecimal(desconto_fixo_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (acrescimo_fixo_porc == "")
                    {
                        Pag.Acrescimo_Fixo_Porc = 0;
                    }
                    else
                    {
                        if (acrescimo_fixo_porc.Contains("."))
                        {
                            Pag.Acrescimo_Fixo_Porc = Convert.ToDecimal(acrescimo_fixo_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Acrescimo_Fixo_Porc = Convert.ToDecimal(acrescimo_fixo_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (juros_mora == "")
                    {
                        Pag.Juros_Mora_Porc = 0;
                    }
                    else
                    {
                        if (juros_mora.Contains("."))
                        {
                            Pag.Juros_Mora_Porc = Convert.ToDecimal(juros_mora.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Juros_Mora_Porc = Convert.ToDecimal(juros_mora.Replace(",", "."));
                        }
                    }
                    //
                    if (entidade_bancaria == "")
                    {
                        Pag.Cod_Entidade_Bancaria = 0;
                        //
                        Pag.Desc_Entidade_Bancaria = "null";
                    }
                    else
                    {
                        string[] items = entidade_bancaria.Split('—');
                        //
                        Pag.Cod_Entidade_Bancaria = Convert.ToInt16(items[0]);
                        //
                        Pag.Desc_Entidade_Bancaria = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    Pag.Tipo_Operacao = tipo_operacao.Insert(tipo_operacao.Length, "'").Insert(0, "'");
                    //
                    if (desconto_porc == "")
                    {
                        Pag.Desconto_Porc = 0;
                    }
                    else
                    {
                        if (desconto_porc.Contains("."))
                        {
                            Pag.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Pag.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", "."));
                        }
                    }
                    //
                    if (dia_duracao_desconto == "")
                    {
                        Pag.Dia_Duracao_Desconto = 0;
                    }
                    else
                    {
                        Pag.Dia_Duracao_Desconto = Convert.ToInt16(dia_duracao_desconto);
                    }
                    //
                    con.Alterar_Forma_Pagamento(Pag);
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
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Forma_Pagamento(Pag);
                }
            }
        }

        public static DataTable Sel_Forma_Pagar_Todos(string tipo_operacao, bool nota_promissoria)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlTipoOperacao;
                string SqlNotaPromissoria;

                if (tipo_operacao == "ENTRADA")
                {
                    SqlTipoOperacao = "WHERE tipo_operacao='" + tipo_operacao + "'";
                }
                else if (tipo_operacao == "SAIDA")
                {
                    SqlTipoOperacao = "WHERE tipo_operacao='" + tipo_operacao + "'";
                }
                else
                {
                    SqlTipoOperacao = "";
                }
                //
                if (tipo_operacao == "")
                {
                    if (nota_promissoria == false)
                    {
                        SqlNotaPromissoria = "WHERE tipo<>'NOTA PROMISSORIA'";
                    }
                    else
                    {
                        SqlNotaPromissoria = "";
                    }
                }
                else
                {
                    if (nota_promissoria == false)
                    {
                        SqlNotaPromissoria = " AND tipo<>'NOTA PROMISSORIA'";
                    }
                    else
                    {
                        SqlNotaPromissoria = "";
                    }
                }
                //
                return con.Sel_Forma_Pagar_Todos(SqlTipoOperacao, SqlNotaPromissoria);
            }
        }

        public static DataTable Sel_Forma_Pagar_Descricao(string descricao, string tipo_operacao, bool nota_promissoria)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    string SqlTipoOperacao;
                    string SqlDescricao;
                    string SqlNotaPromissoria;

                    if (descricao.Contains("%"))
                    {
                        SqlDescricao = "WHERE descricao LIKE '" + descricao + "'";
                    }
                    else
                    {
                        SqlDescricao = "WHERE descricao STARTING WITH '" + descricao + "'";
                    }

                    if (tipo_operacao == "ENTRADA")
                    {
                        SqlTipoOperacao = " AND tipo_operacao='" + tipo_operacao + "'";
                    }
                    else if (tipo_operacao == "SAIDA")
                    {
                        SqlTipoOperacao = " AND tipo_operacao='" + tipo_operacao + "'";
                    }
                    else
                    {
                        SqlTipoOperacao = "";
                    }
                    //
                    if (nota_promissoria == false)
                    {
                        SqlNotaPromissoria = " AND tipo<>'NOTA PROMISSORIA'";
                    }
                    else
                    {
                        SqlNotaPromissoria = "";
                    }
                    //
                    return con.Sel_Forma_Pagar_Descricao(SqlDescricao, SqlTipoOperacao, SqlNotaPromissoria);
                }
            }
        }

        public static DataTable Sel_Forma_Pagar_Codigo(string pesquisar, string tipo_operacao, bool nota_promissoria)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Pesquisar = pesquisar;

                    string SqlTipoOperacao;
                    string SqlNotaPromissoria;

                    if (tipo_operacao == "ENTRADA")
                    {
                        SqlTipoOperacao = " AND tipo_operacao='" + tipo_operacao + "'";
                    }
                    else if (tipo_operacao == "SAIDA")
                    {
                        SqlTipoOperacao = " AND tipo_operacao='" + tipo_operacao + "'";
                    }
                    else
                    {
                        SqlTipoOperacao = "";
                    }
                    //
                    if (nota_promissoria == false)
                    {
                        SqlNotaPromissoria = " AND tipo<>'NOTA PROMISSORIA'";
                    }
                    else
                    {
                        SqlNotaPromissoria = "";
                    }
                    //
                    return con.Sel_Forma_Pagar_Codigo(Pag, SqlTipoOperacao, SqlNotaPromissoria);
                }
            }
        }

        public static DataTable Sel_Forma_Pagar_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Forma_Pagar_A_Sal();
            }
        }

        public static DataTable Sel_Forma_Pagar_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Forma_Pagar_A_Alt(Pag);
                }
            }
        }

        public static bool Sel_Forma_Descricao_Alt(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Descricao = descricao;
                    if (con.Sel_Forma_Descricao_Alt(Pag) == codigo)
                    {
                        return false;
                    }
                    else if (con.Sel_Forma_Descricao_Alt(Pag) == null)
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

        public static bool Sel_Forma_Descricao(string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Descricao = descricao;
                    return con.Sel_Forma_Descricao(Pag);
                }
            }
        }

        public static DataTable Sel_Forma_Tipo_Pagamento(string pesquisar, string tipo_operacao, bool nota_promissoria)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Pesquisar = pesquisar;

                    string SqlTipoOperacao;
                    string SqlNotaPromissoria;

                    if (tipo_operacao == "ENTRADA")
                    {
                        SqlTipoOperacao = " AND tipo_operacao='" + tipo_operacao + "'";
                    }
                    else if (tipo_operacao == "SAIDA")
                    {
                        SqlTipoOperacao = " AND tipo_operacao='" + tipo_operacao + "'";
                    }
                    else
                    {
                        SqlTipoOperacao = "";
                    }
                    //
                    if (nota_promissoria == false)
                    {
                        SqlNotaPromissoria = " AND tipo<>'NOTA PROMISSORIA'";
                    }
                    else
                    {
                        SqlNotaPromissoria = "";
                    }
                    return con.Sel_Forma_Tipo_Pagamento(Pag, SqlTipoOperacao, SqlNotaPromissoria);
                }
            }
        }

        public static string Simular_Forma_Pagamento_Resumida(string parcelas, string entrada_porc, string valor_venda, string desconto_fixo, string acrescimo_fixo)
        {
            StringBuilder str = new StringBuilder();
            //
            decimal valor = Convert.ToDecimal(valor_venda);
            //
            decimal percentualEnt = Convert.ToDecimal(entrada_porc) / 100;
            decimal entrada = Math.Round((percentualEnt * valor), 2);
            //
            decimal percentualDescFix = Convert.ToDecimal(desconto_fixo) / 100;
            decimal desconto_Fix = Math.Round((percentualDescFix * valor), 2);
            //
            decimal percentualAcreFix = Convert.ToDecimal(acrescimo_fixo) / 100;
            decimal acrescimo_Fix = Math.Round((percentualAcreFix * valor), 2);
            //
            decimal valor_atualizado = Math.Round((valor + acrescimo_Fix) - entrada - desconto_Fix, 2);
            //
            decimal valor_parcela = Convert.ToDecimal(parcelas);
            //
            decimal valor_apos_parcela = Math.Round(Convert.ToDecimal(valor_atualizado) / valor_parcela, 2);
            //
            decimal dizima_sobrando = valor_atualizado - (valor_apos_parcela * valor_parcela);
            //
            //str.Append(valor_atualizado + " R$ => ");
            //
            if (desconto_fixo != "0,00" & desconto_fixo != "0")
            {
                str.Append(" Desc.: -" + desconto_fixo + "%");
            }
            //
            if (acrescimo_fixo != "0,00" & acrescimo_fixo != "0")
            {
                str.Append(" Acresc.: +" + acrescimo_fixo + "%");
            }
            //
            if (entrada_porc != "0,00")
            {
                if (parcelas != "1")
                {
                    str.Append(" Entr.: " + entrada + " + 1 x = " + (valor_apos_parcela + dizima_sobrando) + " + " + (valor_parcela - 1) + " x " + valor_apos_parcela);
                }
                else
                {
                    str.Append(" Entr.: " + entrada + " + 1 x = " + valor_apos_parcela);
                }
            }
            else
            {
                if (parcelas != "1")
                {
                    str.Append(" 1 x = " + (valor_apos_parcela + dizima_sobrando) + " + " + (valor_parcela - 1) + " x " + valor_apos_parcela);
                }
                else
                {
                    str.Append(" 1 x = " + valor_apos_parcela);
                }
            }
            //            
            return str.ToString();
        }

        public static DataTable Sel_Entidade_Bancaria_Forma_Pagamento()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Entidade_Bancaria_Forma_Pagamento();
            }
        }

        public static string Simular_Forma_Pagamento(string tipo, string parcelas, string entrada, string multa, string primeiro_pgto_parcela, string juros_mora, string valor_venda, string descricao, string desconto_fixo, string acrescimo_fixo)
        {
            StringBuilder str = new StringBuilder();
            //
            str.Append("Pagamento em ");
            //
            if (tipo == "NOTA PROMISSORIA")
            {
                str.Append("Nota Promissória");
            }
            else if (tipo == "DINHEIRO")
            {
                str.Append("Dinheiro");
            }
            else if (tipo == "CARTAO DE CREDITO")
            {
                str.Append("Cartão de Crédito");
            }
            else if (tipo == "CARTAO DE DEBITO")
            {
                str.Append("Cartão de Débito");
            }
            else if (tipo == "PIX")
            {
                str.Append("PIX");
            }
            //
            str.Append(", no valor de " + valor_venda + " R$");
            //
            if (desconto_fixo != "")
            {
                str.Append(", com desconto fixo de -" + desconto_fixo + "%");
            }
            //
            if (acrescimo_fixo != "")
            {
                str.Append(", com acréscimo fixo de +" + acrescimo_fixo + "%");
            }
            //
            if (entrada != "0,00")
            {
                str.Append(", com entrada de " + entrada + " %");
            }
            else
            {
                str.Append(", sem entrada");
            }
            //
            str.Append(", com " + parcelas + " parcela(s)");
            //      
            if (primeiro_pgto_parcela != "0")
            {
                str.Append(", com pagamento da primeira parcela em até " + primeiro_pgto_parcela + " dias");
            }
            //
            if (multa != "")
            {
                str.Append(", com multa de +" + multa + "%");
            }
            //
            if (juros_mora != "")
            {
                str.Append(", com juros mora de +" + juros_mora + "%");
            }
            //
            if (descricao != "")
            {
                str.Append(", na descrição " + descricao + ".");
            }
            else
            {
                str.Append(".");
            }
            //
            return str.ToString();
        }
    }
}
