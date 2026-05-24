using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Threading;

namespace BLL
{
    public class bllTransportador
    {
        public static void Salvar_Temp(string tipo_transporte, string tipo_frete, string fornecedor, string veiculo, string codigo_antt, string placa, string uf, string especie, string marca, string quantidade, string numeracao, string peso_bruto, string peso_liquido, string cod_conexao_configuracoes, string valor_frete)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Transportador_Temp Transp = new Transportador_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (tipo_transporte == "Veículo Próprio")
                    {
                        Transp.Tipo_Transporte = "'PROPRIO'";
                    }
                    else if (tipo_transporte == "De Terceiros")
                    {
                        Transp.Tipo_Transporte = "'TERCEIROS'";
                    }
                    else if (tipo_transporte == "Sem Transporte")
                    {
                        Transp.Tipo_Transporte = "'SEM TRANSPORTE'";
                    }
                    //
                    if (tipo_frete == "Frete por conta do Emitente")
                    {
                        Transp.Tipo_Frete = "'EMITENTE'";
                    }
                    else if (tipo_frete == "Frete por conta do Destinatário")
                    {
                        Transp.Tipo_Frete = "'DESTINATARIO'";
                    }
                    else
                    {
                        Transp.Tipo_Frete = "null";
                    }
                    //
                    if (fornecedor == null || fornecedor == "")
                    {
                        Transp.Cod_Fornecedor = 0;
                        Transp.Nome_Fornecedor = "null";
                    }
                    else
                    {
                        string[] itens = fornecedor.Split('—');
                        //
                        Transp.Cod_Fornecedor = Convert.ToInt32(itens[0]);
                        Transp.Nome_Fornecedor = itens[1].Insert(itens[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (veiculo == "" || veiculo == null)
                    {
                        Transp.Veiculo = "null";
                    }
                    else
                    {
                        Transp.Veiculo = veiculo.Insert(veiculo.Length, "'").Insert(0, "'");
                    }
                    //
                    if (codigo_antt == "" || codigo_antt == null)
                    {
                        Transp.Codigo_ANTT = "null";
                    }
                    else
                    {
                        Transp.Codigo_ANTT = codigo_antt.Insert(codigo_antt.Length, "'").Insert(0, "'");
                    }
                    //
                    if (placa == "" || placa == null)
                    {
                        Transp.Placa = "null";
                    }
                    else
                    {
                        Transp.Placa = placa.Insert(placa.Length, "'").Insert(0, "'");
                    }
                    //
                    if (uf == "" || uf == null)
                    {
                        Transp.UF = "null";
                    }
                    else
                    {
                        Transp.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    }
                    //
                    if (especie == "" || especie == null)
                    {
                        Transp.Especie = "null";
                    }
                    else
                    {
                        Transp.Especie = especie.Insert(especie.Length, "'").Insert(0, "'");
                    }
                    //
                    if (marca == "" || marca == null)
                    {
                        Transp.Marca = "null";
                    }
                    else
                    {
                        Transp.Marca = marca.Insert(marca.Length, "'").Insert(0, "'");
                    }
                    //
                    if (quantidade == "" || quantidade == null)
                    {
                        Transp.Quantidade = 0;
                    }
                    else
                    {
                        Transp.Quantidade = Convert.ToInt32(quantidade);
                    }
                    //
                    if (numeracao == "" || codigo_antt == null)
                    {
                        Transp.Numeracao = "null";
                    }
                    else
                    {
                        Transp.Numeracao = numeracao.Insert(numeracao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (peso_bruto == "" || peso_bruto == null)
                    {
                        Transp.Peso_Bruto = 0;
                    }
                    else
                    {
                        if (peso_bruto.Contains("."))
                        {
                            Transp.Peso_Bruto = Convert.ToDecimal(peso_bruto.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Peso_Bruto = Convert.ToDecimal(peso_bruto.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (peso_liquido == "" || peso_liquido == null)
                    {
                        Transp.Peso_Liquido = 0;
                    }
                    else
                    {
                        if (peso_liquido.Contains("."))
                        {
                            Transp.Peso_Liquido = Convert.ToDecimal(peso_liquido.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Peso_Liquido = Convert.ToDecimal(peso_liquido.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    Transp.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    if (valor_frete == "" || valor_frete == null)
                    {
                        Transp.Valor_Frete = 0;
                    }
                    else
                    {
                        if (valor_frete.Contains("."))
                        {
                            Transp.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    con.Salvar_Transportador_Temp(Transp);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Temp(string cod_conexao_configuracoes, string tipo_transporte, string tipo_frete, string fornecedor, string veiculo, string codigo_antt, string placa, string uf, string especie, string marca, string quantidade, string numeracao, string peso_bruto, string peso_liquido, string valor_frete)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Transportador_Temp Transp = new Transportador_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Transp.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    if (tipo_transporte == "Veículo Próprio")
                    {
                        Transp.Tipo_Transporte = "'PROPRIO'";
                    }
                    else if (tipo_transporte == "De Terceiros")
                    {
                        Transp.Tipo_Transporte = "'TERCEIROS'";
                    }
                    else if (tipo_transporte == "Sem Transporte")
                    {
                        Transp.Tipo_Transporte = "'SEM TRANSPORTE'";
                    }
                    //
                    if (tipo_frete == "Frete por conta do Emitente")
                    {
                        Transp.Tipo_Frete = "'EMITENTE'";
                    }
                    else if (tipo_frete == "Frete por conta do Destinatário")
                    {
                        Transp.Tipo_Frete = "'DESTINATARIO'";
                    }
                    else
                    {
                        Transp.Tipo_Frete = "null";
                    }
                    //
                    if (fornecedor == null || fornecedor == "")
                    {
                        Transp.Cod_Fornecedor = 0;
                        Transp.Nome_Fornecedor = "null";
                    }
                    else
                    {
                        string[] itens = fornecedor.Split('—');
                        //
                        Transp.Cod_Fornecedor = Convert.ToInt32(itens[0]);
                        Transp.Nome_Fornecedor = itens[1].Insert(itens[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (veiculo == "" || veiculo == null)
                    {
                        Transp.Veiculo = "null";
                    }
                    else
                    {
                        Transp.Veiculo = veiculo.Insert(veiculo.Length, "'").Insert(0, "'");
                    }
                    //
                    if (codigo_antt == "" || codigo_antt == null)
                    {
                        Transp.Codigo_ANTT = "null";
                    }
                    else
                    {
                        Transp.Codigo_ANTT = codigo_antt.Insert(codigo_antt.Length, "'").Insert(0, "'");
                    }
                    //
                    if (placa == "" || placa == null)
                    {
                        Transp.Placa = "null";
                    }
                    else
                    {
                        Transp.Placa = placa.Insert(placa.Length, "'").Insert(0, "'");
                    }
                    //
                    if (uf == "" || uf == null)
                    {
                        Transp.UF = "null";
                    }
                    else
                    {
                        Transp.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    }
                    //
                    if (especie == "" || especie == null)
                    {
                        Transp.Especie = "null";
                    }
                    else
                    {
                        Transp.Especie = especie.Insert(especie.Length, "'").Insert(0, "'");
                    }
                    //
                    if (marca == "" || marca == null)
                    {
                        Transp.Marca = "null";
                    }
                    else
                    {
                        Transp.Marca = marca.Insert(marca.Length, "'").Insert(0, "'");
                    }
                    //
                    if (quantidade == "" || quantidade == null)
                    {
                        Transp.Quantidade = 0;
                    }
                    else
                    {
                        Transp.Quantidade = Convert.ToInt32(quantidade);
                    }
                    //
                    if (numeracao == "" || codigo_antt == null)
                    {
                        Transp.Numeracao = "null";
                    }
                    else
                    {
                        Transp.Numeracao = numeracao.Insert(numeracao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (peso_bruto == "" || peso_bruto == null)
                    {
                        Transp.Peso_Bruto = 0;
                    }
                    else
                    {
                        if (peso_bruto.Contains("."))
                        {
                            Transp.Peso_Bruto = Convert.ToDecimal(peso_bruto.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Peso_Bruto = Convert.ToDecimal(peso_bruto.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (peso_liquido == "" || peso_liquido == null)
                    {
                        Transp.Peso_Liquido = 0;
                    }
                    else
                    {
                        if (peso_liquido.Contains("."))
                        {
                            Transp.Peso_Liquido = Convert.ToDecimal(peso_liquido.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Peso_Liquido = Convert.ToDecimal(peso_liquido.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (valor_frete == "" || valor_frete == null)
                    {
                        Transp.Valor_Frete = 0;
                    }
                    else
                    {
                        if (valor_frete.Contains("."))
                        {
                            Transp.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    con.Alterar_Transportador_Temp(Transp);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }
    



    public static void Salvar(string tipo_transporte, string tipo_frete, string fornecedor, string veiculo, string codigo_antt, string placa, string uf, string especie, string marca, string quantidade, string numeracao, string peso_bruto, string peso_liquido, string cod_dfe, string valor_frete)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Transportador Transp = new Transportador())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (tipo_transporte == "Veículo Próprio")
                    {
                        Transp.Tipo_Transporte = "'PROPRIO'";
                    }
                    else if (tipo_transporte == "De Terceiros")
                    {
                        Transp.Tipo_Transporte = "'TERCEIROS'";
                    }
                    else if (tipo_transporte == "Sem Transporte")
                    {
                        Transp.Tipo_Transporte = "'SEM TRANSPORTE'";
                    }
                    //
                    if (tipo_frete == "Frete por conta do Emitente")
                    {
                        Transp.Tipo_Frete = "'EMITENTE'";
                    }
                    else if (tipo_frete == "Frete por conta do Destinatário")
                    {
                        Transp.Tipo_Frete = "'DESTINATARIO'";
                    }
                    else
                    {
                        Transp.Tipo_Frete = "null";
                    }
                    //
                    if (fornecedor == null || fornecedor == "")
                    {
                        Transp.Cod_Fornecedor = 0;
                        Transp.Nome_Fornecedor = "null";
                    }
                    else
                    {
                        string[] itens = fornecedor.Split('—');
                        //
                        Transp.Cod_Fornecedor = Convert.ToInt32(itens[0]);
                        Transp.Nome_Fornecedor = itens[1].Insert(itens[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (veiculo == "" || veiculo == null)
                    {
                        Transp.Veiculo = "null";
                    }
                    else
                    {
                        Transp.Veiculo = veiculo.Insert(veiculo.Length, "'").Insert(0, "'");
                    }
                    //
                    if (codigo_antt == "" || codigo_antt == null)
                    {
                        Transp.Codigo_ANTT = "null";
                    }
                    else
                    {
                        Transp.Codigo_ANTT = codigo_antt.Insert(codigo_antt.Length, "'").Insert(0, "'");
                    }
                    //
                    if (placa == "" || placa == null)
                    {
                        Transp.Placa = "null";
                    }
                    else
                    {
                        Transp.Placa = placa.Insert(placa.Length, "'").Insert(0, "'");
                    }
                    //
                    if (uf == "" || uf == null)
                    {
                        Transp.UF = "null";
                    }
                    else
                    {
                        Transp.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    }
                    //
                    if (especie == "" || especie == null)
                    {
                        Transp.Especie = "null";
                    }
                    else
                    {
                        Transp.Especie = especie.Insert(especie.Length, "'").Insert(0, "'");
                    }
                    //
                    if (marca == "" || marca == null)
                    {
                        Transp.Marca = "null";
                    }
                    else
                    {
                        Transp.Marca = marca.Insert(marca.Length, "'").Insert(0, "'");
                    }
                    //
                    if (quantidade == "" || quantidade == null)
                    {
                        Transp.Quantidade = 0;
                    }
                    else
                    {
                        Transp.Quantidade = Convert.ToInt32(quantidade);
                    }
                    //
                    if (numeracao == "" || codigo_antt == null)
                    {
                        Transp.Numeracao = "null";
                    }
                    else
                    {
                        Transp.Numeracao = numeracao.Insert(numeracao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (peso_bruto == "" || peso_bruto == null)
                    {
                        Transp.Peso_Bruto = 0;
                    }
                    else
                    {
                        if (peso_bruto.Contains("."))
                        {
                            Transp.Peso_Bruto = Convert.ToDecimal(peso_bruto.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Peso_Bruto = Convert.ToDecimal(peso_bruto.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (peso_liquido == "" || peso_liquido == null)
                    {
                        Transp.Peso_Liquido = 0;
                    }
                    else
                    {
                        if (peso_liquido.Contains("."))
                        {
                            Transp.Peso_Liquido = Convert.ToDecimal(peso_liquido.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Peso_Liquido = Convert.ToDecimal(peso_liquido.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    Transp.Cod_DFe = Convert.ToInt32(cod_dfe);
                    //
                    if (valor_frete == "" || valor_frete == null)
                    {
                        Transp.Valor_Frete = 0;
                    }
                    else
                    {
                        if (valor_frete.Contains("."))
                        {
                            Transp.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    con.Salvar_Transportador(Transp);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Dados_Transportador(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Transportador Transp = new Transportador())
                {
                    Transp.Cod_DFe = Convert.ToInt32(cod_dfe);
                    return con.Sel_Dados_Transportador(Transp);
                }
            }
        }

        public static DataTable Sel_Dados_Transportador_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Transportador_Temp Transp = new Transportador_Temp())
                {
                    Transp.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    return con.Sel_Dados_Transportador_Temp(Transp);
                }
            }
        }

        public static void Alterar(string cod_dfe, string tipo_transporte, string tipo_frete, string fornecedor, string veiculo, string codigo_antt, string placa, string uf, string especie, string marca, string quantidade, string numeracao, string peso_bruto, string peso_liquido, string valor_frete)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Transportador Transp = new Transportador())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Transp.Cod_DFe = Convert.ToInt32(cod_dfe);
                    //
                    if (tipo_transporte == "Veículo Próprio")
                    {
                        Transp.Tipo_Transporte = "'PROPRIO'";
                    }
                    else if (tipo_transporte == "De Terceiros")
                    {
                        Transp.Tipo_Transporte = "'TERCEIROS'";
                    }
                    else if (tipo_transporte == "Sem Transporte")
                    {
                        Transp.Tipo_Transporte = "'SEM TRANSPORTE'";
                    }
                    //
                    if (tipo_frete == "Frete por conta do Emitente")
                    {
                        Transp.Tipo_Frete = "'EMITENTE'";
                    }
                    else if (tipo_frete == "Frete por conta do Destinatário")
                    {
                        Transp.Tipo_Frete = "'DESTINATARIO'";
                    }
                    else
                    {
                        Transp.Tipo_Frete = "null";
                    }
                    //
                    if (fornecedor == null || fornecedor == "")
                    {
                        Transp.Cod_Fornecedor = 0;
                        Transp.Nome_Fornecedor = "null";
                    }
                    else
                    {
                        string[] itens = fornecedor.Split('—');
                        //
                        Transp.Cod_Fornecedor = Convert.ToInt32(itens[0]);
                        Transp.Nome_Fornecedor = itens[1].Insert(itens[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (veiculo == "" || veiculo == null)
                    {
                        Transp.Veiculo = "null";
                    }
                    else
                    {
                        Transp.Veiculo = veiculo.Insert(veiculo.Length, "'").Insert(0, "'");
                    }
                    //
                    if (codigo_antt == "" || codigo_antt == null)
                    {
                        Transp.Codigo_ANTT = "null";
                    }
                    else
                    {
                        Transp.Codigo_ANTT = codigo_antt.Insert(codigo_antt.Length, "'").Insert(0, "'");
                    }
                    //
                    if (placa == "" || placa == null)
                    {
                        Transp.Placa = "null";
                    }
                    else
                    {
                        Transp.Placa = placa.Insert(placa.Length, "'").Insert(0, "'");
                    }
                    //
                    if (uf == "" || uf == null)
                    {
                        Transp.UF = "null";
                    }
                    else
                    {
                        Transp.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    }
                    //
                    if (especie == "" || especie == null)
                    {
                        Transp.Especie = "null";
                    }
                    else
                    {
                        Transp.Especie = especie.Insert(especie.Length, "'").Insert(0, "'");
                    }
                    //
                    if (marca == "" || marca == null)
                    {
                        Transp.Marca = "null";
                    }
                    else
                    {
                        Transp.Marca = marca.Insert(marca.Length, "'").Insert(0, "'");
                    }
                    //
                    if (quantidade == "" || quantidade == null)
                    {
                        Transp.Quantidade = 0;
                    }
                    else
                    {
                        Transp.Quantidade = Convert.ToInt32(quantidade);
                    }
                    //
                    if (numeracao == "" || codigo_antt == null)
                    {
                        Transp.Numeracao = "null";
                    }
                    else
                    {
                        Transp.Numeracao = numeracao.Insert(numeracao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (peso_bruto == "" || peso_bruto == null)
                    {
                        Transp.Peso_Bruto = 0;
                    }
                    else
                    {
                        if (peso_bruto.Contains("."))
                        {
                            Transp.Peso_Bruto = Convert.ToDecimal(peso_bruto.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Peso_Bruto = Convert.ToDecimal(peso_bruto.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (peso_liquido == "" || peso_liquido == null)
                    {
                        Transp.Peso_Liquido = 0;
                    }
                    else
                    {
                        if (peso_liquido.Contains("."))
                        {
                            Transp.Peso_Liquido = Convert.ToDecimal(peso_liquido.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Peso_Liquido = Convert.ToDecimal(peso_liquido.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (valor_frete == "" || valor_frete == null)
                    {
                        Transp.Valor_Frete = 0;
                    }
                    else
                    {
                        if (valor_frete.Contains("."))
                        {
                            Transp.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Transp.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    con.Alterar_Transportador(Transp);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }
    }
}
