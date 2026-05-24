using DAL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BLL
{
    public class bllVenda
    {
        public static bool _FrmRelVenda_Ativo;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Cliente_PesqCliente_Tabela;
        public static string _Venda_PesqUsuarioTabela;
        public static string _Hist_PesqCompPDV_Tabela;
        public static string _Observacai_Venda_Tabela;
        public static string _Pagamento_PesqPagamento_Tabela;

        public static string _Justificativa_Cancelamento;

        public static string _Quantidade;
        public static string _PDV_PesqCliente_Tabela;
        public static string _PDV_PesqProduto_Tabela;
        public static string _PDV_PesqForma_Tabela;
        public static string _Total;
        public static string _Total_Real;
        public static string _Desconto_Porc;
        public static string _Valor_Desconto;
        public static string _Valor_Desconto_Item;
        public static string _Acrescimo_Porc;
        public static string _Valor_Acrescimo;
        public static string _Valor_Acrescimo_Item;
        public static string _Troco;
        public static string _Valor_Total_Pago;
        public static string _Observacao;
        public static string _Forma_Ent_Pagamento_Promissoria;
        public static bool _Nota_Promissoria;
        public static string _Valor_Entrada_Promissoria;
        public static string _N_Parcela;
        public static string _Descricao_Produto;
        public static string _Valor_Credito_Loja;
        public static string _Cod_Orcamento;
        public static string _Cod_OS;
        public static string _Cod_Venda;
        public static string _Cod_Orcamento_Orc;
        public static string _Cod_Devolucao;
        public static string _Valor_Desconto_Devolucao;
        public static byte _Tipo_Informar_Cliente;
        public static byte _Tipo_Captura;
        public static byte _Tipo_Envio;
        public static byte _Excluir_Item;
        public static byte _Realizar_Orcamento;
        public static byte _Realizar_Devolucao;
        public static byte _Capturar_Orcamento;
        public static byte _Capturar_Devolucao;
        public static byte _Permitir_Desc_Pag;
        public static byte _Permitir_Acresc_Pag;
        public static byte _Permitir_Fin_PDV;
        public static byte _Permitir_Alt_Prod_Item;
        public static byte _Permitir_Real_Conta_Receber;
        public static byte _Permitir_Real_Conta_Pagar;
        public static byte _Permitir_Real_SangSup;
        public static byte _Permitir_Abrir_Caixa;
        public static byte _Permitir_Fechar_Caixa;
        public static byte _Permitir_Pausar_Caixa;
        public static byte _Permitir_Vis_Hist_Caixa;
        public static string _Cod_Produto_Cadastro;
        public static string _Cod_Consumidor_Cadastro;
        public static string _Cod_Forma_Pagamento_Cadastro;
        public static byte _Permitir_Venda_N_Prom_S_Credito;
        public static byte _Permitir_Venda_S_Credito_Loja;
        public static string _Valor_Cheque;
        public static byte _Capturar_Venda;
        //
        public static string _Parcela_Plano;
        public static string _Entrada_Plano;
        public static string _Multa_Plano;
        public static string _Juros_Mora_Plano;
        public static string _Cod_Nota_Promissoria_Plano;
        //
        public static byte _Opcao_Menu_BigPicture;
        public static string _Celular_CadCelular_Tabela;


        public static DataTable Sel_Usuario_Vend()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Vend();
            }
        }

        public static DataTable Sel_Cliente_Vend()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_Vend();
            }
        }

        public static DataTable Sel_Cod_PDV_Vend()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cod_PDV_Vend();
            }
        }

        public static DataTable Sel_Forma_Pagamento_Venda()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Forma_Pagamento_Venda();
            }
        }

        public static DataTable Sel_Venda_DataCad_HoraCad_Usuario_Tipo_Situacao_PDV_Todos(string data, string data1, string horario_cad, string horario_cad1, string usuario, string tipo, string cod_pdv, string consumidor, string cod_orcamento, string cod_devolucao, string valor, string valor1, string pagamento, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items;
                    string SqlData;
                    string SqlUsusario;
                    string SqlTipo;
                    string SqlCodPDV;
                    string SqlConsumidor;
                    string SqlOrcamento;
                    string SqlDevolucao;
                    string SqlValor;
                    string SqlPagamento;
                    string SqlOS;
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "WHERE venda.data BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " 23:59:59'";
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
                        SqlData = "WHERE venda.data BETWEEN '" + data.Replace("/", ".") + horario_cad + "' AND '" + data1.Replace("/", ".") + horario_cad1 + "'";
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsusario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsusario = " AND venda.id_usuario=" + items[0];
                    }
                    //
                    if (tipo == "")
                    {
                        SqlTipo = "";
                    }
                    else
                    {
                        SqlTipo = " AND venda.tipo='" + tipo + "'";
                    }
                    //
                    if (cod_pdv == "")
                    {
                        SqlCodPDV = "";
                    }
                    else
                    {
                        SqlCodPDV = " AND venda.id_pdv_computador=" + cod_pdv;
                    }
                    //
                    if (consumidor == "")
                    {
                        SqlConsumidor = "";
                    }
                    else
                    {
                        items = consumidor.Split('—');
                        SqlConsumidor = " AND venda.id_consumidor=" + items[0];
                    }
                    //
                    if (cod_orcamento == "")
                    {
                        SqlOrcamento = "";
                    }
                    else
                    {
                        SqlOrcamento = " AND venda.id_orcamento=" + cod_orcamento;
                    }
                    //
                    if (cod_devolucao == "")
                    {
                        SqlDevolucao = "";
                    }
                    else
                    {
                        SqlDevolucao = " AND venda.id_devolucao=" + cod_devolucao;
                    }
                    //
                    if (valor == "" & valor1 == "")
                    {
                        SqlValor = "";
                    }
                    else
                    {
                        decimal dvalor;
                        decimal dvalor1;
                        //
                        if (valor == "")
                        {
                            valor = "0";
                        }
                        //
                        if (valor.Contains("."))
                        {
                            dvalor = Convert.ToDecimal(valor.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            dvalor = Convert.ToDecimal(valor.Replace(",", ".").Replace(";", ""));
                        }
                        //
                        if (valor1 != "")
                        {
                            //
                            if (valor1.Contains("."))
                            {
                                dvalor1 = Convert.ToDecimal(valor1.Replace(".", "").Replace(",", "."));
                            }
                            else
                            {
                                dvalor1 = Convert.ToDecimal(valor1.Replace(",", ".").Replace(";", ""));
                            }
                            //
                            SqlValor = " AND venda.valor_real BETWEEN '" + dvalor + "' AND '" + dvalor1 + "'";
                        }
                        else
                        {
                            dvalor1 = 0;

                            SqlValor = " AND venda.valor_real=" + dvalor;
                        }
                    }
                    //
                    if (pagamento == "")
                    {
                        SqlPagamento = "";
                    }
                    else
                    {
                        items = pagamento.Split('—');
                        SqlPagamento = " AND pagamento_venda.id_pagamento=" + items[0];
                    }
                    //
                    if (cod_os == "")
                    {
                        SqlOS = "";
                    }
                    else
                    {
                        SqlOS = " AND venda.id_os=" + cod_os;
                    }
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    //
                    return con.Sel_Venda_DataCad_HoraCad_Usuario_Tipo_Situacao_PDV_Todos(SqlData, SqlUsusario, SqlTipo, SqlCodPDV, SqlConsumidor, SqlOrcamento, SqlDevolucao, SqlValor, SqlPagamento, SqlOS);
                }
            }
        }

        public static bool Sel_Venda_DFe_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Venda_DFe_Ver(Vend);
                }
            }
        }

        public static bool Sel_Venda_OS_Ver(string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Cod_OS = Convert.ToInt32(cod_os);
                    return con.Sel_Venda_OS_Ver(Vend);
                }
            }
        }

        public static bool Sel_Venda_Devolucao_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Venda_Devolucao_Ver(Vend);
                }
            }
        }

        public static bool Sel_Devolucao_Venda_Ver(string cod_devolucao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Cod_Devolucao = Convert.ToInt32(cod_devolucao);
                    return con.Sel_Devolucao_Venda_Ver(Vend);
                }
            }
        }

        public static DataTable Sel_Venda_DataCad_HoraCad_Usuario_Tipo_Situacao_PDV_Todos_Resumido(string data, string data1, string horario_cad, string horario_cad1, string usuario, string tipo, string cod_pdv, string consumidor, string cod_orcamento, string cod_devolucao, string valor, string valor1, string pagamento, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items;
                    string SqlData;
                    string SqlUsusario;
                    string SqlTipo;
                    string SqlCodPDV;
                    string SqlConsumidor;
                    string SqlOrcamento;
                    string SqlDevolucao;
                    string SqlValor;
                    string SqlPagamento;
                    string SqlOS;

                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "WHERE venda.data BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " 23:59:59'";
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
                        SqlData = "WHERE venda.data BETWEEN '" + data.Replace("/", ".") + horario_cad + "' AND '" + data1.Replace("/", ".") + horario_cad1 + "'";
                    }
                    //
                    if (usuario == "")
                    {
                        SqlUsusario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsusario = " AND venda.id_usuario=" + items[0];
                    }
                    //
                    if (tipo == "")
                    {
                        SqlTipo = "";
                    }
                    else
                    {
                        SqlTipo = " AND venda.tipo='" + tipo + "'";
                    }
                    //
                    if (cod_pdv == "")
                    {
                        SqlCodPDV = "";
                    }
                    else
                    {
                        SqlCodPDV = " AND venda.id_pdv_computador=" + cod_pdv;
                    }
                    //
                    if (consumidor == "")
                    {
                        SqlConsumidor = "";
                    }
                    else
                    {
                        items = consumidor.Split('—');
                        SqlConsumidor = " AND venda.id_consumidor=" + items[0];
                    }
                    //
                    if (cod_orcamento == "")
                    {
                        SqlOrcamento = "";
                    }
                    else
                    {
                        SqlOrcamento = " AND venda.id_orcamento=" + cod_orcamento;
                    }
                    //
                    if (cod_devolucao == "")
                    {
                        SqlDevolucao = "";
                    }
                    else
                    {
                        SqlDevolucao = " AND venda.id_devolucao=" + cod_devolucao;
                    }
                    //
                    if (valor == "" & valor1 == "")
                    {
                        SqlValor = "";
                    }
                    else
                    {
                        decimal dvalor;
                        decimal dvalor1;
                        //
                        if (valor == "")
                        {
                            valor = "0";
                        }
                        //
                        if (valor.Contains("."))
                        {
                            dvalor = Convert.ToDecimal(valor.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            dvalor = Convert.ToDecimal(valor.Replace(",", ".").Replace(";", ""));
                        }
                        //
                        if (valor1 != "")
                        {
                            if (valor1.Contains("."))
                            {
                                dvalor1 = Convert.ToDecimal(valor1.Replace(".", "").Replace(",", "."));
                            }
                            else
                            {
                                dvalor1 = Convert.ToDecimal(valor1.Replace(",", ".").Replace(";", ""));
                            }
                            //
                            SqlValor = " AND venda.valor_real BETWEEN '" + dvalor + "' AND '" + dvalor1 + "'";
                        }
                        else
                        {
                            dvalor1 = 0;

                            SqlValor = " AND venda.valor_real=" + dvalor;
                        }
                    }
                    //
                    if (pagamento == "")
                    {
                        SqlPagamento = "";
                    }
                    else
                    {
                        items = pagamento.Split('—');
                        SqlPagamento = " AND pagamento_venda.id_pagamento=" + items[0];
                    }
                    //
                    if (cod_os == "")
                    {
                        SqlOS = "";
                    }
                    else
                    {
                        SqlOS = " AND venda.id_os=" + cod_os;
                    }
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    //
                    return con.Sel_Venda_DataCad_HoraCad_Usuario_Tipo_Situacao_PDV_Todos_Resumido(SqlData, SqlUsusario, SqlTipo, SqlCodPDV, SqlConsumidor, SqlOrcamento, SqlDevolucao, SqlValor, SqlPagamento, SqlOS);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Venda(Vend);
                }
            }
        }

        public static DataTable Sel_Venda_Codigo(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Venda_Codigo(Vend);
                }
            }
        }

        public static DataTable Sel_Formas_Pagamento_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Formas_Pagamento_Venda(Vend);
                }
            }
        }

        public static DataTable Sel_Itens_Venda_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Itens_Venda_Venda(Vend);
                }
            }
        }

        public static bool Sel_Situacao_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Situacao_Venda(Vend);
                }
            }
        }

        public static void Remover_CPF_CNPJ(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    //
                    con.Remover_CPF_CNPJ(Vend);
                }
            }
        }

        public static void Atualizar_Saldo_Produto_Excluir_Venda(string codigo, string quantidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (quantidade.Contains("."))
                    {
                        Prod.Saldo_Atual = con.Sel_Dados_Produto_Venda(Prod) + Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Saldo_Atual = con.Sel_Dados_Produto_Venda(Prod) + Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    con.Atualizar_Saldo_Produto_Excluir_Venda(Prod);
                }
            }
        }

        public static void Excluir_Item_Venda_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Item_Venda_Venda(Vend);
                }
            }
        }

        public static void Excluir_Pagamento_Venda_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Pagamento_Venda_Venda(Vend);
                }
            }
        }

        public static bool Sel_Venda_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Venda_Ainda_Existe(Vend);
                }
            }
        }

        public static void Alterar_CPF_CNPJ_Venda(string codigo, string cpf_cnpj)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    Vend.CPF_CNPJ_Consumidor = cpf_cnpj.Insert(cpf_cnpj.Length, "'").Insert(0, "'");
                    //
                    using (ClieCons Clie = new ClieCons())
                    {
                        Clie.Pesquisar = cpf_cnpj;
                        if (con.Sel_Clie_CPFCNPJ(Clie) == null)
                        {
                            Vend.Cod_Consumidor = 0;
                            Vend.Nome_Consumidor = "null";

                        }
                        else
                        {
                            DataRow dr = con.Sel_Clie_CPFCNPJ(Clie).Rows[0];
                            Vend.Cod_Consumidor = Convert.ToInt32(dr["id_cliente"]);
                            Vend.Nome_Consumidor = "'" + dr["nome"].ToString() + "'";
                        }
                        con.Alterar_CPF_CNPJ_Venda(Vend);
                    }
                }
            }
        }


        public static List<string> _PDV_Forma_Pagamento = new List<string>();
        public static List<string> _Dados_Cheque = new List<string>();

        public static void Salvar_Venda(string consumidor, string desconto_porc, string valor_desconto, string acrescimo_porc, string valor_acrescimo, string tipo, string valor, string valor_real, string observacao, string usuario, string cod_pdv_computador, string troco, string valor_total_pago, string valor_acrescimo_item, string valor_desconto_item, string cod_orcamento, string cod_devolucao, string cod_os, bool parcial)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Data = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Vend.Hora = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items;
                    //
                    if (consumidor == "" || consumidor == null || consumidor == "Não identificado.")
                    {
                        Vend.Cod_Consumidor = 0;
                        Vend.Nome_Consumidor = "null";
                        Vend.CPF_CNPJ_Consumidor = "null";
                    }
                    else
                    {
                        items = consumidor.Split('—');
                        //
                        if (items[0] == "0")
                        {
                            if (items.Length == 2)
                            {
                                Vend.Cod_Consumidor = 0;
                                Vend.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                                Vend.CPF_CNPJ_Consumidor = "null";
                            }
                            else
                            {
                                Vend.Cod_Consumidor = 0;
                                Vend.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                                Vend.CPF_CNPJ_Consumidor = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                            }
                        }
                        else
                        {
                            items = consumidor.Split('—');
                            Vend.Cod_Consumidor = Convert.ToInt32(items[0]);
                            Vend.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                            Vend.CPF_CNPJ_Consumidor = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                        }
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        Vend.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Vend.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Vend.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Vend.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (acrescimo_porc.Contains("."))
                    {
                        Vend.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Vend.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Vend.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Vend.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo_item.Contains("."))
                    {
                        Vend.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Vend.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(",", "."));
                    }
                    //
                    if (valor_desconto_item.Contains("."))
                    {
                        Vend.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Vend.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(",", "."));
                    }
                    //
                    Vend.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    if (valor.Contains("."))
                    {
                        Vend.Valor = Convert.ToDecimal(valor.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Vend.Valor = Convert.ToDecimal(valor.Replace(",", "."));
                    }
                    //
                    if (valor_real.Contains("."))
                    {
                        Vend.Valor_Real = Convert.ToDecimal(valor_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Vend.Valor_Real = Convert.ToDecimal(valor_real.Replace(",", "."));
                    }
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Vend.Observacao = "null";
                    }
                    else
                    {
                        Vend.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    items = usuario.Replace("Usuário(a): ", "").Split('—');
                    Vend.Cod_Usuario = Convert.ToInt16(items[0]);
                    Vend.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Vend.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº Comp.: ", "").Replace("Nº PDV: ", ""));
                    //
                    if (troco.Contains("."))
                    {
                        Vend.Troco = Convert.ToDecimal(troco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Vend.Troco = Convert.ToDecimal(troco.Replace(",", "."));
                    }
                    //
                    if (valor_total_pago.Contains("."))
                    {
                        Vend.Valor_Total_Pago = Convert.ToDecimal(valor_total_pago.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Vend.Valor_Total_Pago = Convert.ToDecimal(valor_total_pago.Replace(",", "."));
                    }
                    //
                    if (cod_orcamento == "" || cod_orcamento == null)
                    {
                        Vend.Cod_Orcamento = 0;
                    }
                    else
                    {
                        Vend.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    }
                    //
                    if (cod_devolucao == "" || cod_devolucao == null)
                    {
                        Vend.Cod_Devolucao = 0;
                    }
                    else
                    {
                        Vend.Cod_Devolucao = Convert.ToInt32(cod_devolucao);
                    }
                    //
                    if (cod_os == "" || cod_os == null)
                    {
                        Vend.Cod_OS = 0;
                    }
                    else
                    {
                        Vend.Cod_OS = Convert.ToInt32(cod_os);
                    }
                    //
                    if (parcial == true)
                    {
                        Vend.Parcial = 1;
                    }
                    else
                    {
                        Vend.Parcial = 0;
                    }
                    //
                    con.Salvar_Venda(Vend);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Baixa_Credito_Loja_Cliente(string cod_consumidor, string valor)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Clie.Codigo = Convert.ToInt32(cod_consumidor);
                    //
                    if (valor.Contains("."))
                    {
                        Clie.Saldo_Credito_Loja = Convert.ToDecimal(con.Sel_Credito_Loja_Cliente_PDV(Clie)) - Convert.ToDecimal(valor.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Clie.Saldo_Credito_Loja = Convert.ToDecimal(con.Sel_Credito_Loja_Cliente_PDV(Clie)) - Convert.ToDecimal(valor.Replace(",", "."));
                    }
                    //
                    con.Baixa_Credito_Loja_Cliente(Clie);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Estoque_Produto_PDV(string codigo, string quantidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (quantidade.Contains("."))
                    {
                        Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) - Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) - Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    con.Alterar_Estoque_Produto_PDV(Prod);
                }
            }
        }

        /*
        public static void Retornar_Estoque_Produto_PDV(string codigo, string quantidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (quantidade.Contains("."))
                    {
                        Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) + Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) + Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    con.Retornar_Estoque_Produto_PDV(Prod);
                }
            }
        }
        */

        /*
        public static bool Sel_Cod_Orcamento_Existe_PDV(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    Orc.Codigo = Convert.ToInt32(codigo);
                     return con.Sel_Cod_Orcamento_Existe_PDV(Orc);
                }
            }
        }
        */
        public static void Salvar_Forma_Pagamento(string item, string cod_pagamento, string tipo_forma_pagamento, string valor_pagamento, string cod_venda, string data, string hora, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_Venda Pgto = new Pagamento_Venda())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Pgto.Cod_Item_Pagamento = Convert.ToInt16(item);
                    //
                    Pgto.Cod_Pagamento = Convert.ToInt16(cod_pagamento);
                    //
                    Pgto.Tipo = tipo_forma_pagamento.Insert(tipo_forma_pagamento.Length, "'").Insert(0, "'");
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
                    Pgto.Cod_Venda = Convert.ToInt32(cod_venda);
                    //
                    Pgto.Data_Pagamento = "'" + data.Replace("/", ".") + " " + hora.Insert(hora.Length, ":00") + "'";
                    //
                    Pgto.Hora_Pagamento = hora.Insert(hora.Length, "'").Insert(0, "'");
                    //
                    usuario = usuario.Remove(0, 12);
                    string[] items = usuario.Split('—');
                    //
                    Pgto.Cod_Usuario = Convert.ToInt16(items[0]);
                    Pgto.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Pgto.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    con.Salvar_Pagamento_Venda(Pgto);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Itens_Venda(string item, string cod_produto, string descricao, string quantidade, string um, string vl_unit, string cod_venda, string valor_desconto_venda, string valor_acrescimo_venda, string valor_venda, bool ultimo_item, string total_itens, string valor_acrescimo_item, string valor_desconto_item, string valor_total, bool primeiro_item, string desconto_venda, string acrescimo_venda, string tipo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_PDV Item = new Item_PDV())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Venda = Convert.ToInt32(cod_venda);
                    //
                    Item.Cod_Item = Convert.ToInt16(item);
                    //
                    Item.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Item.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (quantidade.Contains("."))
                    {
                        Item.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Item.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (vl_unit.Contains("."))
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(vl_unit.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(vl_unit.Replace(",", "."));
                    }
                    //
                    if (valor_total.Contains("."))
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total.Replace(",", "."));
                    }
                    //
                    if (valor_desconto_item.Contains("."))
                    {
                        Item.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo_item.Contains("."))
                    {
                        Item.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(",", "."));
                    }
                    //
                    if (valor_venda.Contains("."))
                    {
                        valor_venda = valor_venda.Replace(".", "").Replace(",", ".");
                    }
                    else
                    {
                        valor_venda = valor_venda.Replace(",", ".");
                    }
                    //
                    if (Convert.ToDecimal(desconto_venda) == 0)
                    {
                        Item.Valor_Desconto = 0;
                    }
                    else
                    {
                        if (desconto_venda.Contains("."))
                        {
                            desconto_venda = desconto_venda.Replace(".", "").Replace(",", ".");
                        }
                        else
                        {
                            desconto_venda = desconto_venda.Replace(",", ".");
                        }
                        //
                        if (valor_desconto_venda.Contains("."))
                        {
                            valor_desconto_venda = valor_desconto_venda.Replace(".", "").Replace(",", ".");
                        }
                        else
                        {
                            valor_desconto_venda = valor_desconto_venda.Replace(",", ".");
                        }
                        //
                        if (con.Sel_Valor_Desc_Valor_Acresc_Item_Venda(Item) != null)
                        {
                            DataRow dr;
                            decimal valordescitems = 0;
                            //
                            for (int i = 0; i < con.Sel_Valor_Desc_Valor_Acresc_Item_Venda(Item).Rows.Count; i++)
                            {
                                dr = con.Sel_Valor_Desc_Valor_Acresc_Item_Venda(Item).Rows[i];
                                valordescitems += Convert.ToDecimal(dr["valor_desconto"].ToString());
                            }
                            //
                            if (valordescitems < Convert.ToDecimal(valor_desconto_venda))
                            {
                                if (ultimo_item == true & primeiro_item == false)
                                {
                                    decimal valor_total_desconto = Convert.ToDecimal(valor_desconto_venda) - valordescitems;
                                    Item.Valor_Desconto = valor_total_desconto;
                                }
                                else
                                {
                                    decimal percentual = Convert.ToDecimal(desconto_venda) / 100;
                                    //
                                    Item.Valor_Desconto = Math.Round(percentual * Item.Valor_Total, 2);
                                }
                            }
                        }
                        else
                        {
                            if (primeiro_item == true & ultimo_item == false)
                            {
                                Item.Valor_Desconto = Convert.ToDecimal(valor_desconto_venda);
                            }
                            else
                            {
                                decimal percentual = Convert.ToDecimal(desconto_venda) / 100;
                                //
                                Item.Valor_Desconto = Math.Round(percentual * Item.Valor_Total, 2);
                            }
                        }
                    }
                    //              
                    if (Convert.ToDecimal(acrescimo_venda) == 0)
                    {
                        Item.Valor_Acrescimo = 0;
                    }
                    else
                    {
                        if (acrescimo_venda.Contains("."))
                        {
                            acrescimo_venda = acrescimo_venda.Replace(".", "").Replace(",", ".");
                        }
                        else
                        {
                            acrescimo_venda = acrescimo_venda.Replace(",", ".");
                        }
                        //
                        if (valor_acrescimo_venda.Contains("."))
                        {
                            valor_acrescimo_venda = valor_acrescimo_venda.Replace(".", "").Replace(",", ".");
                        }
                        else
                        {
                            valor_acrescimo_venda = valor_acrescimo_venda.Replace(",", ".");
                        }
                        //
                        if (con.Sel_Valor_Desc_Valor_Acresc_Item_Venda(Item) != null)
                        {
                            DataRow dr;
                            decimal valoracrescitems = 0;
                            //
                            for (int i = 0; i < con.Sel_Valor_Desc_Valor_Acresc_Item_Venda(Item).Rows.Count; i++)
                            {
                                dr = con.Sel_Valor_Desc_Valor_Acresc_Item_Venda(Item).Rows[i];
                                valoracrescitems += Convert.ToDecimal(dr["valor_acrescimo"].ToString());
                            }
                            //
                            if (valoracrescitems < Convert.ToDecimal(valor_acrescimo_venda))
                            {
                                if (ultimo_item == true & primeiro_item == false)
                                {
                                    decimal valor_total_acrescimo = Convert.ToDecimal(valor_acrescimo_venda) - valoracrescitems;
                                    Item.Valor_Acrescimo = valor_total_acrescimo;
                                }
                                else
                                {
                                    decimal percentual = Convert.ToDecimal(acrescimo_venda) / 100;
                                    //
                                    Item.Valor_Acrescimo = Math.Round(percentual * Item.Valor_Total, 2);
                                }
                            }
                        }
                        else
                        {
                            if (primeiro_item == true & ultimo_item == false)
                            {
                                Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo_venda);
                            }
                            else
                            {
                                decimal percentual = Convert.ToDecimal(acrescimo_venda) / 100;
                                //
                                Item.Valor_Acrescimo = Math.Round(percentual * Item.Valor_Total, 2);
                            }
                        }
                    }
                    //
                    Item.Valor_Total_A_Desc_Acresc = Item.Valor_Total + Item.Valor_Acrescimo - Item.Valor_Desconto + Item.Valor_Acrescimo_Item - Item.Valor_Desconto_Item;
                    //
                    Item.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Itens_Venda(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Dados_Venda_A_Finalizar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Dados_Venda_A_Finalizar();
            }
        }

        public static DataTable Sel_Dados_Nota_Promissoria_PDV(string cod_pagamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(cod_pagamento);
                    return con.Sel_Dados_Nota_Promissoria_PDV(Pag);
                }
            }
        }


        public static void Salvar_Conta_Receber(string ocorrencia_parc, string descricao, string consumidor, string valor_documento, string qtde_parcelas, string valor_entrada, string multa_porc, string juros_am_porc, string cod_venda, string desconto_porc, string dia_duracao_desconto, string dia_primeiro_pagamento)
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
                    Conta.Palavra_Chave = "null";
                    //
                    Conta.Ocorrencia_Parc = Convert.ToInt16(ocorrencia_parc);
                    //
                    Conta.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Conta.Data_Emissao = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    double dias = Convert.ToDouble(dia_primeiro_pagamento);
                    //
                    Conta.Data_Vencimento = "'" + DateTime.Now.AddDays(dias * Convert.ToDouble(ocorrencia_parc)).ToString("dd/MM/yyyy").Replace('/', '.') + " 23:59:59'";
                    //
                    Conta.Tipo_Documento = "'NOTA PROMISSORIA'";
                    //
                    Conta.Tipo_Consumidor = "'CLIENTES'";
                    //
                    string[] items = consumidor.Split('—');
                    Conta.Cod_Consumidor = Convert.ToInt32(items[0]);
                    //
                    Conta.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Conta.Cod_Grupo = 3;
                    //
                    Conta.Desc_Grupo = "'CONTAS A RECEBER NO GERAL'";
                    //                    
                    Conta.Cod_Subgrupo = 3;
                    //
                    Conta.Desc_Subgrupo = "'GERAL'";
                    //
                    decimal entrada;
                    if (valor_entrada.Contains("."))
                    {
                        entrada = Convert.ToDecimal(valor_entrada.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        entrada = Convert.ToDecimal(valor_entrada.Replace(",", "."));
                    }
                    //
                    decimal valor;
                    if (valor_documento.Contains("."))
                    {
                        valor = Convert.ToDecimal(valor_documento.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        valor = Convert.ToDecimal(valor_documento.Replace(",", "."));
                    }
                    //
                    decimal valor_atualizado = valor - entrada;
                    //
                    decimal valor_parcela = Convert.ToDecimal(qtde_parcelas);
                    //
                    decimal valor_apos_parcela = Math.Round(Convert.ToDecimal(valor_atualizado) / valor_parcela, 2);
                    //
                    decimal dizima_sobrando = valor_atualizado - (valor_apos_parcela * valor_parcela);
                    //
                    if (ocorrencia_parc == "1")
                    {
                        Conta.Valor_Documento = (valor_apos_parcela + dizima_sobrando);
                        Conta.Valor_Real = (valor_apos_parcela + dizima_sobrando);
                    }
                    else
                    {
                        Conta.Valor_Documento = valor_apos_parcela;
                        Conta.Valor_Real = valor_apos_parcela;
                    }
                    //
                    if (multa_porc.Contains("."))
                    {
                        Conta.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(",", "."));
                    }
                    //
                    Conta.Valor_Multa = Convert.ToDecimal(bllContasReceber.Calculo_Multa(Conta.Valor_Documento.ToString(), Conta.Multa_Porc.ToString()));
                    //
                    Conta.Observacao = "null";
                    //
                    if (dia_duracao_desconto == "0")
                    {
                        Conta.Data_Desconto = "null";
                    }
                    else
                    {
                        if (ocorrencia_parc == "1")
                        {
                            Conta.Data_Desconto = "'" + DateTime.Now.AddDays(Convert.ToDouble(dia_duracao_desconto)).ToString("dd/MM/yyyy").Replace('/', '.') + " 23:59:59'";
                        }
                        else
                        {
                            Conta.Data_Desconto = "'" + DateTime.Now.AddDays((dias * (Convert.ToDouble(ocorrencia_parc) - 1)) + Convert.ToDouble(dia_duracao_desconto)).ToString("dd/MM/yyyy").Replace('/', '.') + " 23:59:59'";
                        }
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        Conta.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", "."));
                    }
                    //
                    Conta.Valor_Desconto = Convert.ToDecimal(bllContasReceber.Calculo_Desconto(Conta.Valor_Documento.ToString(), Conta.Desconto_Porc.ToString()));
                    //
                    if (multa_porc.Contains("."))
                    {
                        Conta.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Multa_Porc = Convert.ToDecimal(multa_porc.Replace(",", "."));
                    }
                    //
                    Conta.Valor_Multa = Convert.ToDecimal(bllContasReceber.Calculo_Multa(Conta.Valor_Documento.ToString(), Conta.Multa_Porc.ToString()));
                    //
                    if (juros_am_porc.Contains("."))
                    {
                        Conta.Juros_Am_Porc = Convert.ToDecimal(juros_am_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Conta.Juros_Am_Porc = Convert.ToDecimal(juros_am_porc.Replace(",", "."));
                    }
                    //
                    Conta.Valor_Juros_Am = 0;
                    //
                    Conta.N_Promissoria = con.Sel_Conta_Receber_Ultimo_N_Promissoria() + 1;
                    //
                    Conta.Tipo_Documento = "'NOTA PROMISSORIA'";
                    //
                    Conta.Cod_Venda = Convert.ToInt32(cod_venda);
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
                    con.Salvar_Conta_Receber(Conta);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Dados_Pagamento_Venda(string cod_venda)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_Venda Pag = new Pagamento_Venda())
                {
                    Pag.Cod_Venda = Convert.ToInt32(cod_venda);
                    return con.Sel_Dados_Pagamento_Venda(Pag);
                }
            }
        }

        public static DataTable Sel_Produtos_Venda_PDV()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Dados_Venda_A_Finalizar();
            }
        }

        public static void Salvar_Items_PDV(string item, string cod_produto, string descricao, string valor_unitario, string um, string quantidade, string acrescimo_porc, string desconto_porc, string tabela, string cod_conexao_configuracoes, string tipo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_PDV_Temp Items = new Item_PDV_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (acrescimo_porc.Contains("."))
                    {
                        decimal perc_acresc = Math.Round(Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", ".")) / 100, 2);
                        Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_acresc = Math.Round(Convert.ToDecimal(acrescimo_porc.Replace(",", ".")) / 100, 2);
                        Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        decimal perc_desc = Math.Round(Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", ".")) / 100, 2);
                        Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_desc = Math.Round(Convert.ToDecimal(desconto_porc.Replace(",", ".")) / 100, 2);
                        Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo - Items.Valor_Desconto;
                    //
                    if (tabela == "Tabela [1]")
                    {
                        Items.Cod_Tabela = 1;
                    }
                    else
                    {
                        Items.Cod_Tabela = 2;
                    }
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    Items.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Item_PDV(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_PDV_Orcamento(string item, string cod_produto, string descricao, string valor_unitario, string um, string quantidade, string valor_total_acrescimo, string valor_total_desconto, string tabela, string cod_conexao_configuracoes, string tipo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_PDV_Temp Items = new Item_PDV_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (valor_total_acrescimo.Contains("."))
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_total_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_total_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_total_desconto.Contains("."))
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_total_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_total_desconto.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo - Items.Valor_Desconto;
                    //
                    if (tabela == "Tabela [1]")
                    {
                        Items.Cod_Tabela = 1;
                    }
                    else
                    {
                        Items.Cod_Tabela = 2;
                    }
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    Items.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Item_PDV(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_PDV_Devolucao(string item, string cod_produto, string descricao, string valor_unitario, string um, string quantidade, string valor_acrescimo, string valor_desconto, string valor_total_a_desc_acresc, string cod_conexao_configuracoes, string tipo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_PDV_Temp Items = new Item_PDV_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));

                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));

                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));

                    }
                    else
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));

                    }
                    else
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_total_a_desc_acresc.Contains("."))
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(".", "").Replace(",", "."));

                    }
                    else
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(",", "."));
                    }
                    //
                    Items.Cod_Tabela = 1;
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Items.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Item_PDV(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir_Item(string codigo, string tabela)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_PDV_Temp Items = new Item_PDV_Temp())
                {
                    Items.Codigo = Convert.ToInt16(codigo);
                    //
                    if (tabela == "Tabela [1]")
                    {
                        Items.Cod_Tabela = 1;
                    }
                    else
                    {
                        Items.Cod_Tabela = 2;
                    }
                    //
                    con.Excluir_Item_PDV(Items);
                }
            }
        }

        public static void Excluir_Venda_Atual_PDV(string tabela, string cod_conexao_configuraceos)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_PDV_Temp Item = new Item_PDV_Temp())
                {
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuraceos);

                    if (tabela == "Tabela [1]")
                    {
                        con.Excluir_Venda_Atual_PDV(Item);
                    }
                    else
                    {
                        Item.Cod_Tabela = 2;
                        //
                        con.Excluir_Venda_Atual_PDV_Tabela(Item);
                    }
                }
            }
        }

        public static string Sel_Ultima_Conta_Receber_PDV()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ultima_Conta_Receber_PDV();
            }
        }

        public static string Sel_Ultima_Venda()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ultima_Venda();
            }
        }

        public static void Salvar_Pagamento_Conta_Receber_PDV(string cod_item_pagamento, string forma_pagamento, string valor_pagamento, string cod_conta_receber, string usuario, string cod_pdv_computador, string data_pagamento, string hora_pagamento)
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

                    Pgto.Data_Pagamento = "'" + data_pagamento.Replace('/', '.') + " " + hora_pagamento + "'";
                    //
                    Pgto.Hora_Pagamento = "'" + hora_pagamento + "'";
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
                    Pgto.Pagamento_Parcial = 0;
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
                    con.Salvar_Pagamento_Conta_Receber_PDV(Pgto);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir_Consumidor_PDV(string tabela, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    Dado.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    if (tabela == "Tabela [1]")
                    {
                        con.Excluir_Consumidor_PDV(Dado);
                    }
                    else
                    {
                        con.Excluir_Consumidor_PDV_Tabela_2(Dado);
                    }
                }
            }
        }

        public static string Sel_Cod_Ultima_Venda(string id_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string[] items = id_pdv_computador.Split('/');
                    Vend.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", ""));
                    //
                    items = usuario.Replace("Usuário(a): ", "").Split('—');
                    Vend.Cod_Usuario = Convert.ToInt16(items[0]);
                    //
                    return con.Sel_Cod_Ultima_Venda(Vend);
                }
            }
        }

        public static string Sel_Cod_Ultimo_Orcamento(string id_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Orcamento Orc = new Orcamento())
                {
                    string[] items = id_pdv_computador.Split('/');
                    Orc.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", ""));
                    //
                    items = usuario.Replace("Usuário(a): ", "").Split('—');
                    Orc.Cod_Usuario = Convert.ToInt16(items[0]);
                    //
                    return con.Sel_Cod_Ultimo_Orcamento(Orc);
                }
            }
        }

        public static string Sel_Cod_Ultima_Devolucao(string id_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Devolucao Dev = new Devolucao())
                {
                    string[] items = id_pdv_computador.Split('/');
                    Dev.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", ""));
                    //
                    items = usuario.Replace("Usuário(a): ", "").Split('—');
                    Dev.Cod_Usuario = Convert.ToInt16(items[0]);
                    //
                    return con.Sel_Cod_Ultima_Devolucao(Dev);
                }
            }
        }

        public static void Excluir_Devolucao_PDV(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    Dado.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);

                    con.Excluir_Devolucao_PDV(Dado);
                }
            }
        }

        public static void Excluir_Orcamento_PDV(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual()) 
                {
                    Dado.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Orcamento_PDV(Dado);
                }
                
            }
        }

        public static void Excluir_Orcamento_Orc_PDV(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    Dado.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);

                    con.Excluir_Orcamento_Orc_PDV(Dado);
                }
            }
        }

        public static void Excluir_Dados_Atuais_PDV(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    Dado.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);

                    con.Excluir_Dados_Atuais_PDV(Dado);
                }
            }
        }

        public static string Calculo_Valor_Desconto_Forma_Pagamento(string valor_documento, string valor_desconto)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal retorno = (desconto) / valor * 100;
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Desconto_Porc_Forma_Pagamento(string valor_documento, string desconto_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(desconto_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Acrescimo_Porc_Forma_Pagamento(string valor_documento, string acrescimo_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(acrescimo_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Acrescimo(string valor_documento, string acrescimo_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(acrescimo_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_ValorAcrescimo(string valor_documento, string valor_acrescimo)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal desconto = Convert.ToDecimal(valor_acrescimo);
            decimal retorno = (desconto) / valor * 100;
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Valor_Acrescimo_Forma_Pagamento(string valor_documento, string valor_acrescimo)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal desconto = Convert.ToDecimal(valor_acrescimo);
            decimal retorno = (desconto) / valor * 100;
            return Math.Round(retorno, 2).ToString();
        }


        public static string Calculo_Valor_Venda(string valor_documento, string valor_desconto, string valor_acrescimo)
        {
            if (valor_desconto == "")
            {
                valor_desconto = "0,00";
            }
            //
            if (valor_acrescimo == "")
            {
                valor_acrescimo = "0,00";
            }
            //
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal acrescimo = Convert.ToDecimal(valor_acrescimo);
            valor = (valor + acrescimo) - desconto;
            return Math.Round(valor, 2).ToString();
        }

        public static void Alterar_Quantidade_Item(string cod_item, string quantidade, string valor_unitario, string acrescimo_porc, string desconto_porc)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_PDV_Temp Items = new Item_PDV_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(cod_item);
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    decimal perc_acresc = Math.Round(Convert.ToDecimal(acrescimo_porc) / 100, 2);
                    Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    //
                    decimal perc_desc = Math.Round(Convert.ToDecimal(desconto_porc) / 100, 2);
                    Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo - Items.Valor_Desconto;
                    //
                    con.Alterar_Quantidade_Item(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Venda_Data_Venda(string data, string data1)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                SqlData = "WHERE data BETWEEN '" + data.Replace('/', '.') + " 00:00:00' AND '" + data1.Replace('/', '.') + " 23:59:59'";
                return con.Sel_Venda_Data_Venda(SqlData);
            }
        }

        public static DataTable Sel_Venda_Consumidor(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    string[] itens = pesquisar.Split('—');
                    Vend.Pesquisar = itens[0];
                    return con.Sel_Venda_Consumidor(Vend);
                }
            }
        }

        public static DataTable Sel_Venda_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Venda_Todos();
            }
        }

        public static void Alterar_Unitario_Item(string cod_item, string quantidade, string valor_unitario, string acrescimo_porc, string desconto_porc)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_PDV_Temp Items = new Item_PDV_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(cod_item);
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));

                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    //
                    decimal perc_acresc = Convert.ToDecimal(acrescimo_porc) / 100;
                    Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    //
                    decimal perc_desc = Convert.ToDecimal(desconto_porc) / 100;
                    Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo - Items.Valor_Desconto;
                    //
                    con.Alterar_Unitario_Item(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Item_PDV_Todos(string tabela, string cod_pdv_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_PDV_Temp Item = new Item_PDV_Temp())
                {
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_pdv_configuracoes);
                    //
                    if (tabela == "Tabela [1]")
                    {
                        Item.Cod_Tabela = 1;
                    }
                    else
                    {
                        Item.Cod_Tabela = 2;
                    }
                    //
                    return con.Sel_Item_PDV_Todos(Item);
                }
            }
        }

        public static DataTable Sel_Dados_Atuais_PDV(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_PDV_Temp Item = new Item_PDV_Temp())
                {
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Dados_Atuais_PDV(Item);
                }
            }
        }

        public static DataTable Sel_PDV_Dados_Cliente_Codigo(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_PDV_Dados_Cliente_Codigo(Clie);
                }
            }
        }

        public static void Atualizar_Item_Dt_Item(int item_atual, int total_item, string tabela, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_PDV_Temp Items = new Item_PDV_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        //
                        if (tabela == "Tabela [1]")
                        {
                            Items.Cod_Tabela = 1;
                        }
                        else
                        {
                            Items.Cod_Tabela = 2;
                        }
                        //
                        Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                        con.Atualizar_Item_Dt_Item(Items, item.ToString());
                    }
                }
            }
        }

        public static void Salvar_Dados_Atuais_PDV(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Cone = new Conexao())
                {
                    Cone.Codigo = Convert.ToInt16(codigo);
                    //
                    con.Salvar_Dados_Atuais_PDV(Cone);
                }

            }
        }

        public static void Alterar_Consumidor_PDV(string codigo, string nome, string cpf_cnpj, string tabela, string cod_pdv_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    if (tabela == "Tabela [1]")
                    {
                        Dado.Cod_Consumidor_PDV = Convert.ToInt32(codigo);
                        //
                        Dado.Nome_Consumidor_PDV = nome.Insert(nome.Length, "'").Insert(0, "'");
                        //
                        if (cpf_cnpj == "   .   .   -" || cpf_cnpj == "___.___.___-__" || cpf_cnpj == "  .   .   /    -" || cpf_cnpj == "__.___.___/____-__")
                        {
                            Dado.CPF_CNPJ_Consumidor_PDV = "null";
                        }
                        else
                        {
                            Dado.CPF_CNPJ_Consumidor_PDV = cpf_cnpj.Insert(cpf_cnpj.Length, "'").Insert(0, "'");
                        }
                        //
                        Dado.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_pdv_configuracoes);
                        //
                        con.Alterar_Consumidor_PDV(Dado);
                    }
                    else
                    {
                        Dado.Cod_Consumidor_PDV_2 = Convert.ToInt32(codigo);
                        //
                        Dado.Nome_Consumidor_PDV_2 = nome.Insert(nome.Length, "'").Insert(0, "'");
                        //
                        if (cpf_cnpj == "   .   .   -" || cpf_cnpj == "___.___.___-__" || cpf_cnpj == "  .   .   /    -" || cpf_cnpj == "__.___.___/____-__")
                        {
                            Dado.CPF_CNPJ_Consumidor_PDV_2 = "null";
                        }
                        else
                        {
                            Dado.CPF_CNPJ_Consumidor_PDV_2 = cpf_cnpj.Insert(cpf_cnpj.Length, "'").Insert(0, "'");
                        }
                        //
                        Dado.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_pdv_configuracoes);
                        //
                        con.Alterar_Consumidor_PDV_Tabela_2(Dado);
                    }
                }
            }
        }

        public static void Alterar_Devolucao_PDV(string codigo, string valor_desconto_devolucao)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Dado.Cod_Devolucao = Convert.ToInt32(codigo);
                    //
                    if (valor_desconto_devolucao != null)
                    {
                        if (valor_desconto_devolucao.Contains("."))
                        {
                            Dado.Valor_Desconto_Devolucao = Convert.ToDecimal(valor_desconto_devolucao.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Dado.Valor_Desconto_Devolucao = Convert.ToDecimal(valor_desconto_devolucao.Replace(",", "."));
                        }
                    }
                    else
                    {
                        Dado.Valor_Desconto_Devolucao = 0;
                    }
                    //
                    con.Alterar_Devolucao_PDV(Dado);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Tipo_Venda_PDV(string codigo, string tipo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt32(codigo);
                    //
                    Vend.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Tipo_Venda_PDV(Vend);
                }
            }
        }

        public static void Alterar_Orcamento_PDV(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    Dado.Cod_Orcamento = Convert.ToInt32(codigo);
                    //
                    con.Alterar_Orcamento_PDV(Dado);
                }
            }
        }

        public static void Alterar_Venda_PDV(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    Dado.Cod_Venda = Convert.ToInt32(codigo);
                    //
                    con.Alterar_Venda_PDV(Dado);
                }
            }
        }

        public static void Alterar_Orcamento_Orc_PDV(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Dado_PDV_Atual Dado = new Dado_PDV_Atual())
                {
                    Dado.Cod_Orcamento_Orc = Convert.ToInt32(codigo);
                    //
                    con.Alterar_Orcamento_Orc_PDV(Dado);
                }
            }
        }

        public static string Calculo_ValorDesconto(string valor_documento, string valor_desconto)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal retorno = (desconto) / valor * 100;
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Valor_Item_Desc_Acresc_Item(string preco, string valor_desconto, string valor_acrescimo, string quantidade)
        {
            if (valor_desconto == "")
            {
                valor_desconto = "0,00";
            }
            //
            if (valor_acrescimo == "")
            {
                valor_acrescimo = "0,00";
            }
            //
            decimal valor = Convert.ToDecimal(preco);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal acrescimo = Convert.ToDecimal(valor_acrescimo);
            decimal qtde = Convert.ToDecimal(quantidade);
            valor = ((valor + acrescimo) - desconto) * qtde;
            return Math.Round(valor, 2).ToString();
        }

        public static string Calculo_Desconto(string valor_documento, string desconto_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(desconto_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Valor_Item(string preco, string quantidade)
        {
            decimal valor = Convert.ToDecimal(preco);
            decimal qtde = Convert.ToDecimal(quantidade);
            valor = valor * qtde;
            return Math.Round(valor, 2).ToString();
        }

        public static DataTable Sel_Forma_Pagamento_PDV()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Forma_Pagamento_PDV();
            }
        }

        public static DataTable Sel_Dados_Usuario_PDV(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    using (Usuario User = new Usuario())
                    {
                        string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                        User.Codigo = Convert.ToInt16(items[0]);
                        Func.Codigo = con.Sel_Dados_Usuario_PDV(User);
                        return con.Sel_Dados_Funcionario_PDV(Func);
                    }
                }
            }
        }

        public static DataTable Sel_Forma_Pagamento_Codigo_PDV(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Forma_Pagamento_Codigo_PDV(Pag);
                }
            }
        }

        public static DataTable Sel_Dfe_Venda_Cod_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Vend = new Venda())
                {
                    Vend.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Dfe_Venda_Cod_Venda(Vend);
                }
            }
        }

        public static DataTable Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(string forma_pagamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    string[] items = forma_pagamento.Split('—');
                    Pag.Codigo = Convert.ToInt16(items[0]);
                    return con.Sel_Forma_Pagamento_Desc_Acresc_Fixo_Porc_PDV(Pag);
                }
            }
        }

        public static DataTable Sel_Ver_Forma_Pagamento_PDV(string forma_pagamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    string[] items = forma_pagamento.Split('—');
                    Pag.Codigo = Convert.ToInt16(items[0]);
                    return con.Sel_Ver_Forma_Pagamento_PDV(Pag);
                }
            }
        }

        public static string Calculo_Valor_Entrada_Porc_PDV(string valor_total, string entrada_porc)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    decimal valor = Convert.ToDecimal(valor_total);
                    decimal percentual = Convert.ToDecimal(entrada_porc) / 100;
                    decimal retorno = (percentual * valor);
                    return Math.Round(retorno, 2).ToString();
                }
            }
        }

        public static string Sel_Credito_Loja_Cliente_PDV(string consumidor)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    if (consumidor != "Não identificado.")
                    {
                        string[] items = consumidor.Split('—');
                        Clie.Codigo = Convert.ToInt32(items[0]);
                        return con.Sel_Credito_Loja_Cliente_PDV(Clie);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static DataTable Sel_Forma_Pagamento_Promissoria_P_Entrada(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FormaPagamento Pag = new FormaPagamento())
                {
                    Pag.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Forma_Pagamento_Promissoria_P_Entrada(Pag);
                }
            }
        }

        public static DataTable Sel_Desconto_Acrescimo_Venda(string codigo, string cod_item)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_PDV Item = new Item_PDV())
                {
                    Item.Cod_Venda = Convert.ToInt32(codigo);
                    Item.Cod_Item = Convert.ToInt16(cod_item);
                    return con.Sel_Desconto_Acrescimo_Venda(Item);
                }
            }
        }


        public static DataTable Sel_Nota_Promissoria_Dados_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Venda Venda = new Venda())
                {
                    Venda.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Nota_Promissoria_Dados_Venda(Venda);
                }
            }
        }


        public static string GerarDAV(byte trabalho, string cod_venda)
        {
            if (trabalho == 0)
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                    byte pessoa;
                    //
                    nome = drPDF["nome"].ToString();
                    fantasia = drPDF["fantasia"].ToString();
                    cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                    ie_rg = drPDF["ie_rg"].ToString();
                    endereco = drPDF["endereco"].ToString();
                    numero = drPDF["numero"].ToString();
                    bairro = drPDF["bairro"].ToString();
                    cidade = drPDF["cidade"].ToString();
                    uf = drPDF["uf"].ToString();
                    cep = drPDF["cep"].ToString();
                    pessoa = Convert.ToByte(drPDF["pessoa"]);
                    //
                    var page = doc.AddPage();
                    //
                    page.Width = 595;
                    page.Height = 842;
                    //
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var textFormatter4 = new XTextFormatter(graphics);
                    //
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 12);
                    var fonte3 = new XFont("Microsoft Sans Serif", 11);
                    var fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                    //
                    bool PrimeiraPagina = true;
                    int registros;
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //                                   
                    if (bllVenda._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        Margem_Topo = Margem_Topo + 5;
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 280 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                        imagem1.Dispose();
                        registros = 14;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                        registros = 16;
                    }
                    //
                    textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 595, 13));
                    //
                    textFormatter1.DrawString(fantasia, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 98 + Margem_Topo, 595, 13));
                    //
                    textFormatter1.DrawString(cpf_cnpj + "   " + ie_rg, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 111 + Margem_Topo, 595, 13));
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 124 + Margem_Topo, 595, 45);
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 124 + Margem_Topo, 595, 45));
                    //
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 160 + Margem_Topo, 595, 24));
                    textFormatter1.DrawString("DAV - Documento Auxiliar de Venda", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 169 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 175 + Margem_Topo, 595, 24));
                    //
                    textFormatter2.DrawString(" #       Código               Descrição                                                               Qtde.        UN.        Vl.Unit        Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 185 + Margem_Topo, 595, 13));
                    //
                    int Incrementar = 0;
                    //
                    DataRow drVenda = bllVenda.Sel_Venda_Codigo(cod_venda).Rows[0];
                    //
                    for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count; i++)
                    {
                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows[i];
                        //
                        if (PrimeiraPagina == true)
                        {
                            if (i == bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "                      " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 203 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 203 + Margem_Topo, 100, 13));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 216 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 216 + Margem_Topo, 100, 13));
                                //
                                if (drVenda["valor_desconto"].ToString() != "0" || drVenda["valor_desconto_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 198, 13));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(drVenda["valor_desconto"]) + Convert.ToDecimal(drVenda["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 229 + Margem_Topo, 100, 13));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                if (drVenda["valor_acrescimo"].ToString() != "0" || drVenda["valor_acrescimo_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(drVenda["valor_acrescimo"]) + Convert.ToDecimal(drVenda["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 229 + Margem_Topo, 100, 8));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                textFormatter2.DrawString("Valor a Pagar R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor_real"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 229 + Margem_Topo, 100, 13));
                                //
                                textFormatter2.DrawString("FORMA PAGAMENTO", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString("VALOR PAGO R$", fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 242 + Margem_Topo, 100, 13));
                                //
                                for (int b = 0; b < bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows.Count; b++)
                                {
                                    drPDF = bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows[b];
                                    //
                                    string tipo = drPDF["tipo"].ToString();
                                    //
                                    if (tipo == "DINHEIRO")
                                    {
                                        textFormatter2.DrawString("Dinheiro", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 198, 13));
                                    }
                                    else if (tipo == "CARTAO DE DEBITO")
                                    {
                                        textFormatter2.DrawString("Cartão Débito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 198, 13));
                                    }
                                    else if (tipo == "CARTAO DE CREDITO")
                                    {
                                        textFormatter2.DrawString("Cartão Crédito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 198, 13));
                                    }
                                    else if (tipo == "NOTA PROMISSORIA")
                                    {
                                        textFormatter2.DrawString("À Prazo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 198, 13));
                                    }
                                    else if (tipo == "PIX")
                                    {
                                        textFormatter2.DrawString("Pagamento Instantâneo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 198, 13));
                                    }
                                    else if (tipo == "CREDITO LOJA")
                                    {
                                        textFormatter2.DrawString("Crédito Loja", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 198, 13));
                                    }
                                    //
                                    textFormatter3.DrawString(Convert.ToDecimal(drPDF["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 255 + Margem_Topo, 100, 13));
                                    //
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                if (drVenda["troco"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Troco R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 198, 13));
                                    textFormatter3.DrawString(Convert.ToDecimal(drVenda["troco"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 255 + Margem_Topo, 100, 13));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                if (drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    textFormatter1.DrawString(drVenda["id_consumidor"].ToString() + "-" + drVenda["nome_consumidor"].ToString() + Environment.NewLine + drVenda["cpf_cnpj_consumidor"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 26));
                                    Incrementar = Incrementar + 24;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                //
                                textFormatter1.DrawString("DAV nº: " + cod_venda + "   " + drVenda["data"].ToString().Remove(10) + "   " + drVenda["hora"].ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 13));
                                //
                                if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == false)
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 268 + Margem_Topo, 595, 72));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 268 + Margem_Topo, 595, 72));
                                    }
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 294 + Margem_Topo, 585, 11));
                                }
                                else if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == true & dr["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n________________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 268 + Margem_Topo, 595, 72));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n________________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 268 + Margem_Topo, 595, 72));
                                    }

                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 324 + Margem_Topo, 585, 11));
                                }
                                else
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 268 + Margem_Topo, 595, 72));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 268 + Margem_Topo, 595, 72));
                                    }
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 294 + Margem_Topo, 585, 11));
                                }
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "                      " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                            }
                            //
                            if (i == registros - 5 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 4 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 3 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 2 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 1 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                        else
                        {
                            if (i == bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 38 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "                      " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 38 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 43 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 43 + Margem_Topo, 100, 13));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 56 + Margem_Topo, 100, 13));
                                //
                                if (drVenda["valor_desconto"].ToString() != "0" || drVenda["valor_desconto_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 198, 13));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(drVenda["valor_desconto"]) + Convert.ToDecimal(drVenda["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 69 + Margem_Topo, 100, 13));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                if (drVenda["valor_acrescimo"].ToString() != "0" || drVenda["valor_acrescimo_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(drVenda["valor_acrescimo"].ToString()) + Convert.ToDecimal(drVenda["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 69 + Margem_Topo, 100, 8));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                textFormatter2.DrawString("Valor a Pagar R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor_real"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 69 + Margem_Topo, 100, 13));
                                //
                                textFormatter2.DrawString("FORMA PAGAMENTO", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString("VALOR PAGO R$", fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 82 + Margem_Topo, 100, 13));
                                //
                                for (int b = 0; b < bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows.Count; b++)
                                {
                                    drPDF = bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows[b];
                                    //
                                    string tipo = drPDF["tipo"].ToString();
                                    //
                                    if (tipo == "DINHEIRO")
                                    {
                                        textFormatter2.DrawString("Dinheiro", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 198, 13));
                                    }
                                    else if (tipo == "CARTAO DE DEBITO")
                                    {
                                        textFormatter2.DrawString("Cartão Débito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 198, 13));
                                    }
                                    else if (tipo == "CARTAO DE CREDITO")
                                    {
                                        textFormatter2.DrawString("Cartão Crédito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 198, 13));
                                    }
                                    else if (tipo == "NOTA PROMISSORIA")
                                    {
                                        textFormatter2.DrawString("À Prazo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 198, 13));
                                    }
                                    else if (tipo == "PIX")
                                    {
                                        textFormatter2.DrawString("Pagamento Instantâneo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 198, 13));
                                    }
                                    else if (tipo == "CREDITO LOJA")
                                    {
                                        textFormatter2.DrawString("Crédito Loja", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 198, 13));
                                    }
                                    //
                                    textFormatter3.DrawString(Convert.ToDecimal(drPDF["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 95 + Margem_Topo, 100, 13));
                                    //
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                if (drVenda["troco"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Troco R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 198, 13));
                                    textFormatter3.DrawString(Convert.ToDecimal(drVenda["troco"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 95 + Margem_Topo, 100, 13));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                if (drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    textFormatter1.DrawString(drVenda["id_consumidor"].ToString() + "-" + drVenda["nome_consumidor"].ToString() + Environment.NewLine + drVenda["cpf_cnpj_consumidor"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 26));
                                    Incrementar = Incrementar + 24;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                //
                                textFormatter1.DrawString("DAV nº: " + cod_venda + "   " + drVenda["data"].ToString().Remove(10) + "   " + drVenda["hora"].ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 13));
                                //
                                if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == false)
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 108 + Margem_Topo, 595, 72));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 108 + Margem_Topo, 595, 72));
                                    }
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 134 + Margem_Topo, 585, 11));
                                }
                                else if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == true & drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n________________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 108 + Margem_Topo, 595, 72));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n________________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 108 + Margem_Topo, 595, 72));
                                    }
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 164 + Margem_Topo, 585, 11));
                                }
                                else
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 108 + Margem_Topo, 595, 72));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 108 + Margem_Topo, 595, 72));
                                    }
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 134 + Margem_Topo, 585, 11));
                                }
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 38 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "                      " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 38 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                            }
                            //
                            if (i == registros - 5 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 4 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 3 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 2 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 1 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 19;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                    }
                    //
                    PdfSecuritySettings security = doc.SecuritySettings;
                    //
                    security.PermitAccessibilityExtractContent = false;
                    security.PermitAnnotations = false;
                    security.PermitAssembleDocument = false;
                    security.PermitExtractContent = false;
                    security.PermitFormsFill = true;
                    security.PermitFullQualityPrint = false;
                    security.PermitModifyDocument = false;
                    security.PermitPrint = true;
                    //
                    string mes;
                    if (Convert.ToDateTime(drVenda["data"]).Month < 10)
                    {
                        mes = "0" + Convert.ToDateTime(drVenda["data"].ToString()).Month;
                    }
                    else
                    {
                        mes = Convert.ToDateTime(drVenda["data"].ToString()).Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + cod_venda + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + cod_venda + ".pdf");
                    }
                    //
                    return @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + cod_venda + ".pdf";
                }
            }
            else if (trabalho == 1)
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                    byte pessoa;
                    //
                    nome = drPDF["nome"].ToString();
                    fantasia = drPDF["fantasia"].ToString();
                    cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                    ie_rg = drPDF["ie_rg"].ToString();
                    endereco = drPDF["endereco"].ToString();
                    numero = drPDF["numero"].ToString();
                    bairro = drPDF["bairro"].ToString();
                    cidade = drPDF["cidade"].ToString();
                    uf = drPDF["uf"].ToString();
                    cep = drPDF["cep"].ToString();
                    pessoa = Convert.ToByte(drPDF["pessoa"]);
                    //
                    var page = doc.AddPage();
                    //
                    page.Width = 203;
                    page.Height = 842;
                    //                       
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var textFormatter4 = new XTextFormatter(graphics);
                    //
                    var fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                    var fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                    var fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                    var fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    int Incrementar = 0;
                    bool PrimeiraPagina = true;
                    int registros;
                    //
                    if (bllVenda._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                        imagem1.Dispose();
                        registros = 30;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                        registros = 32;
                    }
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 85 + Margem_Topo, 198, 16);
                    if (nome.Length > 30)
                    {
                        if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                        {
                            textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                        }
                        Incrementar = Incrementar + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 8));
                    }
                    //
                    if (fantasia.Length > 30)
                    {
                        if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                        {
                            textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 16));
                        }
                        Incrementar = Incrementar + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 8));
                    }
                    //
                    textFormatter1.DrawString(cpf_cnpj + "   " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                    //
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 109 + Margem_Topo, 198, 24));
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    Incrementar = Incrementar - 15;
                    //
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter1.DrawString("DAV - Documento Auxiliar de Venda", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 150 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + Incrementar + Margem_Topo, 198, 24));
                    //
                    textFormatter2.DrawString(" #   Código  Descrição                    Qtde.   UN.   Vl.Unit   Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 160 + Margem_Topo, 198, 8));
                    //
                    Incrementar = Incrementar + 1;
                    //
                    DataRow drVenda = bllVenda.Sel_Venda_Codigo(cod_venda).Rows[0];
                    //
                    for (int linha = 0; linha < bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count; linha++)
                    {
                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows[linha];
                        //
                        if (PrimeiraPagina == true)
                        {
                            if (linha == bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 14;
                                //
                                Incrementar = Incrementar + 5;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 8));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                Incrementar = Incrementar + 8;
                                //
                                if (drVenda["valor_desconto"].ToString() != "0" || drVenda["valor_desconto_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(drVenda["valor_desconto"]) + Convert.ToDecimal(drVenda["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["valor_acrescimo"].ToString() != "0" || drVenda["valor_acrescimo_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(drVenda["valor_acrescimo"]) + Convert.ToDecimal(drVenda["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                textFormatter2.DrawString("Valor a Pagar R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor_real"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                //
                                textFormatter2.DrawString("FORMA PAGAMENTO", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString("VALOR PAGO R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                //
                                for (int i = 0; i < bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows.Count; i++)
                                {
                                    drPDF = bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows[i];
                                    //
                                    string tipo = drPDF["tipo"].ToString();
                                    //
                                    if (tipo == "DINHEIRO")
                                    {
                                        textFormatter2.DrawString("Dinheiro", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CARTAO DE DDBITO")
                                    {
                                        textFormatter2.DrawString("Cartão Débito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CARTAO DE CREDITO")
                                    {
                                        textFormatter2.DrawString("Cartão Crédito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "NOTA PROMISSORIA")
                                    {
                                        textFormatter2.DrawString("À Prazo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "PIX")
                                    {
                                        textFormatter2.DrawString("Pagamento Instantâneo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CREDITO LOJA")
                                    {
                                        textFormatter2.DrawString("Crédito Loja", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    //
                                    textFormatter3.DrawString(Convert.ToDecimal(drPDF["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    //
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["troco"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Troco R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    textFormatter3.DrawString(Convert.ToDecimal(drVenda["troco"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    textFormatter1.DrawString(drVenda["id_consumidor"].ToString() + "-" + drVenda["nome_consumidor"].ToString() + Environment.NewLine + drVenda["cpf_cnpj_consumidor"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 16));
                                    Incrementar = Incrementar + 14;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                //
                                textFormatter1.DrawString("DAV nº: " + cod_venda + "   " + drVenda["data"].ToString().Remove(10) + "   " + drVenda["hora"].ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                //
                                if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == false)
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString().ToString() + "-" + drVenda["nome_usuario"].ToString().ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 16));
                                }
                                else if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == true & drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n____________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n____________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 222 + Margem_Topo, 198, 16));
                                }
                                else
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 16));
                                }
                                //
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"] + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 14;
                            }
                            //
                            if (linha == registros - 5 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 4 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 3 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 2 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 1 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                        else
                        {
                            if (linha == bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 14;
                                //
                                Incrementar = Incrementar + 5;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                Incrementar = Incrementar + 8;
                                //
                                if (drVenda["valor_desconto"].ToString() != "0" || drVenda["valor_desconto_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(drVenda["valor_desconto"]) + Convert.ToDecimal(drVenda["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["valor_acrescimo"].ToString() != "0" || drVenda["valor_acrescimo_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(drVenda["valor_acrescimo"]) + Convert.ToDecimal(drVenda["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                textFormatter2.DrawString("Valor a Pagar R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor_real"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                //
                                textFormatter2.DrawString("FORMA PAGAMENTO", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString("VALOR PAGO R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                //
                                for (int i = 0; i < bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows.Count; i++)
                                {
                                    drPDF = bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows[i];
                                    //
                                    string tipo = drPDF["tipo"].ToString();
                                    //
                                    if (tipo == "DINHEIRO")
                                    {
                                        textFormatter2.DrawString("Dinheiro", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CARTAO DE DEBITO")
                                    {
                                        textFormatter2.DrawString("Cartão Débito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CARTAO DE CREDITO")
                                    {
                                        textFormatter2.DrawString("Cartão Crédito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "NOTA PROMISSORIA")
                                    {
                                        textFormatter2.DrawString("À Prazo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "PIX")
                                    {
                                        textFormatter2.DrawString("Pagamento Instantâneo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CREDITO LOJA")
                                    {
                                        textFormatter2.DrawString("Crédito Loja", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    //
                                    textFormatter3.DrawString(Convert.ToDecimal(drPDF["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    //
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["troco"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Troco R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    textFormatter3.DrawString(Convert.ToDecimal(drVenda["troco"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    textFormatter1.DrawString(drVenda["id_consumidor"].ToString() + "-" + drVenda["nome_usuario"].ToString() + Environment.NewLine + drVenda["cpf_cnpj_consumidor"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 16));
                                    Incrementar = Incrementar + 14;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                //
                                textFormatter1.DrawString("DAV nº: " + cod_venda + "   " + drVenda["data"].ToString().Remove(10) + "   " + drVenda["hora"].ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                //
                                if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == false)
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 16));
                                }
                                else if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == true & drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n____________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n____________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 64 + Margem_Topo, 198, 16));
                                }
                                else
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 16));
                                }
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 14;
                            }
                            //
                            if (linha == registros - 5 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 4 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 3 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 2 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 1 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                    }
                    //
                    PdfSecuritySettings security = doc.SecuritySettings;
                    //
                    security.PermitAccessibilityExtractContent = false;
                    security.PermitAnnotations = false;
                    security.PermitAssembleDocument = false;
                    security.PermitExtractContent = false;
                    security.PermitFormsFill = true;
                    security.PermitFullQualityPrint = false;
                    security.PermitModifyDocument = false;
                    security.PermitPrint = true;
                    //
                    string mes;
                    if (Convert.ToDateTime(drVenda["data"]).Month < 10)
                    {
                        mes = "0" + Convert.ToDateTime(drVenda["data"]).Month;
                    }
                    else
                    {
                        mes = Convert.ToDateTime(drVenda["data"]).Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + cod_venda + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + cod_venda + ".pdf");
                    }
                    //
                    return @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + cod_venda + ".pdf";
                }
            }
            else
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                    byte pessoa;
                    //
                    nome = drPDF["nome"].ToString();
                    fantasia = drPDF["fantasia"].ToString();
                    cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                    ie_rg = drPDF["ie_rg"].ToString();
                    endereco = drPDF["endereco"].ToString();
                    numero = drPDF["numero"].ToString();
                    bairro = drPDF["bairro"].ToString();
                    cidade = drPDF["cidade"].ToString();
                    uf = drPDF["uf"].ToString();
                    cep = drPDF["cep"].ToString();
                    pessoa = Convert.ToByte(drPDF["pessoa"]);
                    //
                    var page = doc.AddPage();
                    //
                    page.Width = 140;
                    page.Height = 842;
                    //                       
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var textFormatter4 = new XTextFormatter(graphics);
                    //
                    var fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                    var fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                    var fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                    var fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    int Incrementar = 0;
                    bool PrimeiraPagina = true;
                    int registros;
                    //
                    if (bllVenda._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                        registros = 30;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                        registros = 32;
                    }
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 85 + Margem_Topo, 198, 16);
                    if (nome.Length > 30)
                    {
                        if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                        {
                            textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 128, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 128, 16));
                        }
                        Incrementar = Incrementar + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 128, 8));
                    }
                    //
                    if (fantasia.Length > 30)
                    {
                        if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                        {
                            textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 128, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 128, 16));
                        }
                        Incrementar = Incrementar + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 128, 8));
                    }
                    //
                    textFormatter2.DrawString(cpf_cnpj + "   " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                    //
                    textFormatter2.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 109 + Margem_Topo, 198, 24));
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    Incrementar = Incrementar - 15;
                    //
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter1.DrawString("DAV - Documento Auxiliar de Venda", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 150 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + Incrementar + Margem_Topo, 128, 24));
                    //
                    textFormatter2.DrawString("#Cód. Descrição Qtde. UN. Vl.Unit Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 160 + Margem_Topo, 198, 8));
                    //
                    Incrementar = Incrementar + 1;
                    //
                    DataRow drVenda = bllVenda.Sel_Venda_Codigo(cod_venda).Rows[0];
                    //
                    for (int linha = 0; linha < bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count; linha++)
                    {
                        DataRow dr = bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows[linha];
                        //
                        if (PrimeiraPagina == true)
                        {
                            if (linha == bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(45 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(55 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 14;
                                //
                                Incrementar = Incrementar + 5;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 128, 8));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 128, 8));
                                Incrementar = Incrementar + 8;
                                //
                                if (drVenda["valor_desconto"].ToString() != "0" || drVenda["valor_desconto_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(drVenda["valor_desconto"]) + Convert.ToDecimal(drVenda["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 128, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["valor_acrescimo"].ToString() != "0" || drVenda["valor_acrescimo_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(drVenda["valor_acrescimo"]) + Convert.ToDecimal(drVenda["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 128, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                textFormatter2.DrawString("Valor a Pagar R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor_real"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 128, 8));
                                //
                                textFormatter2.DrawString("FORMA PAGAMENTO VALOR PAGO R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                //
                                for (int i = 0; i < bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows.Count; i++)
                                {
                                    drPDF = bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows[i];
                                    //
                                    string tipo = drPDF["tipo"].ToString();
                                    //
                                    if (tipo == "DINHEIRO")
                                    {
                                        textFormatter2.DrawString("Dinheiro", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CARTAO DE DEBITO")
                                    {
                                        textFormatter2.DrawString("Cartão Débito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CARTAO DE CREDITO")
                                    {
                                        textFormatter2.DrawString("Cartão Crédito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "NOTA PROMISSORIA")
                                    {
                                        textFormatter2.DrawString("À Prazo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "PIX")
                                    {
                                        textFormatter2.DrawString("Pagamento Instantâneo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CREDITO LOJA")
                                    {
                                        textFormatter2.DrawString("Crédito Loja", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    }
                                    //
                                    textFormatter3.DrawString(Convert.ToDecimal(drPDF["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 128, 8));
                                    //
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["troco"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Troco R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    textFormatter3.DrawString(Convert.ToDecimal(drVenda["troco"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 128, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    textFormatter2.DrawString(drVenda["id_consumidor"].ToString() + "-" + drVenda["nome_consumidor"].ToString() + Environment.NewLine + drVenda["cpf_cnpj_consumidor"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 16));
                                    Incrementar = Incrementar + 14;
                                }
                                else
                                {
                                    textFormatter2.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                //
                                textFormatter2.DrawString("PED nº: " + cod_venda + " " + drVenda["data"].ToString().Remove(10) + " " + drVenda["hora"].ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 190 + Margem_Topo, 198, 8));
                                //
                                if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == false)
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter2.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter2.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter2.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 16));
                                }
                                else if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == true & drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter2.DrawString("SEM VALOR FISCAL\n____________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter2.DrawString("SEM VALOR FISCAL\n____________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter2.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 222 + Margem_Topo, 198, 16));
                                }
                                else
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter2.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter2.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter2.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 16));
                                }
                                //
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"] + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(45 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(55 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 14;
                            }
                            //
                            if (linha == registros - 5 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 4 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 3 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 2 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 1 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                        else
                        {
                            if (linha == bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(45 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(55 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 14;
                                //
                                Incrementar = Incrementar + 5;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 128, 8));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 128, 8));
                                Incrementar = Incrementar + 8;
                                //
                                if (drVenda["valor_desconto"].ToString() != "0" || drVenda["valor_desconto_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(drVenda["valor_desconto"]) + Convert.ToDecimal(drVenda["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 128, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["valor_acrescimo"].ToString() != "0" || drVenda["valor_acrescimo_item"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(drVenda["valor_acrescimo"]) + Convert.ToDecimal(drVenda["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 128, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                textFormatter2.DrawString("Valor a Pagar R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(drVenda["valor_real"]).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 128, 8));
                                //
                                textFormatter2.DrawString("FORMA PAGAMENTO VALOR PAGO R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                //
                                for (int i = 0; i < bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows.Count; i++)
                                {
                                    drPDF = bllVenda.Sel_Dados_Pagamento_Venda(cod_venda).Rows[i];
                                    //
                                    string tipo = drPDF["tipo"].ToString();
                                    //
                                    if (tipo == "DINHEIRO")
                                    {
                                        textFormatter2.DrawString("Dinheiro", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CARTAO DE DEBITO")
                                    {
                                        textFormatter2.DrawString("Cartão Débito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CARTAO DE CREDITO")
                                    {
                                        textFormatter2.DrawString("Cartão Crédito", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "NOTA PROMISSORIA")
                                    {
                                        textFormatter2.DrawString("À Prazo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "PIX")
                                    {
                                        textFormatter2.DrawString("Pagamento Instantâneo", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    else if (tipo == "CREDITO LOJA")
                                    {
                                        textFormatter2.DrawString("Crédito Loja", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    }
                                    //
                                    textFormatter3.DrawString(Convert.ToDecimal(drPDF["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 128, 8));
                                    //
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["troco"].ToString() != "0")
                                {
                                    textFormatter2.DrawString("Troco R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    textFormatter3.DrawString(Convert.ToDecimal(drVenda["troco"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 128, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    textFormatter1.DrawString(drVenda["id_consumidor"].ToString() + "-" + drVenda["nome_consumidor"].ToString() + Environment.NewLine + drVenda["cpf_cnpj_consumidor"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 16));
                                    Incrementar = Incrementar + 14;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                //
                                textFormatter1.DrawString("PED. nº: " + cod_venda + " " + drVenda["data"].ToString().Remove(10) + " " + drVenda["hora"].ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 32 + Margem_Topo, 198, 8));
                                //
                                if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == false)
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 16));
                                }
                                else if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == true & drVenda["cpf_cnpj_consumidor"].ToString() != "")
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n____________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n____________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 64 + Margem_Topo, 198, 16));
                                }
                                else
                                {
                                    if (bllConfiguracaoSistema.Sel_Mostrar_Inf_Usuario(bllConexao._Codigo_Conexao) == true)
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) + Environment.NewLine + "Operador: " + drVenda["id_usuario"].ToString() + "-" + drVenda["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    else
                                    {
                                        textFormatter1.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 64));
                                    }
                                    //
                                    Incrementar = Incrementar + 24;
                                    //
                                    textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 40 + Margem_Topo, 198, 16));
                                }
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"].ToString() + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(45 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(55 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 14;
                            }
                            //
                            if (linha == registros - 5 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 4 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 3 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 2 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 1 & bllVenda.Sel_Itens_Venda_Venda(cod_venda).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 37;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                    }
                    //
                    PdfSecuritySettings security = doc.SecuritySettings;
                    //
                    security.PermitAccessibilityExtractContent = false;
                    security.PermitAnnotations = false;
                    security.PermitAssembleDocument = false;
                    security.PermitExtractContent = false;
                    security.PermitFormsFill = true;
                    security.PermitFullQualityPrint = false;
                    security.PermitModifyDocument = false;
                    security.PermitPrint = true;
                    //
                    string mes;
                    if (Convert.ToDateTime(drVenda["data"]).Month < 10)
                    {
                        mes = "0" + Convert.ToDateTime(drVenda["data"]).Month;
                    }
                    else
                    {
                        mes = Convert.ToDateTime(drVenda["data"]).Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + cod_venda + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + cod_venda + ".pdf");
                    }
                    //
                    return @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + cod_venda + ".pdf";
                }
            }
        }
       

        public static async Task UploadPdfAsync(string caminhoPdf, string celular)
        {
            var url = "https://www.siseven.com.br/api/upload/upload";

            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(5);

            var form = new MultipartFormDataContent();

            var fs = File.OpenRead(caminhoPdf);
            var streamContent = new StreamContent(fs);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            form.Add(streamContent, "arquivo", Path.GetFileName(caminhoPdf));

            var response = await client.PostAsync(url, form);

            var resposta = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                /*
                MessageBox.Show(
            $"Status: {(int)response.StatusCode}\n\n{resposta}",
            "Erro no Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                */
                MessageBox.Show("Ocorreu um ou mais erros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultado = JsonConvert.DeserializeObject<RespostaUploadDFe>(resposta);

            MessageBox.Show("O Upload foi realizado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string mensagem = "Olá! O cupom da sua *Venda* está disponível em:\n" + resultado.url;
            
            Clipboard.SetText(mensagem);
            
            string encodedMessage = HttpUtility.UrlEncode(mensagem);

            string whatsapp = $"https://wa.me/55{celular}?text={encodedMessage}";

            Process.Start(new ProcessStartInfo
            {
                FileName = whatsapp,
                UseShellExecute = true
            });
        }
    }
}
