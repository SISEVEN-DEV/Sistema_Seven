using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Threading;

namespace BLL
{
    public class bllEntradasProdutos
    {
        public static bool _FrmRelEntradasProdutos_Aberto;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        public static string _FornProd_Prod_PesqForn_Tabela;
        public static string _FornProd_Prod_PesqProd_Tabela;
        public static string _Cliente_PesqCliente_Tabela;
        public static string _Cod_DFe;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Data_Entrada;
        public static string _Fornecedor;
        public static string _Quantidade;

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntradaProduto Ent = new EntradaProduto())
                {
                    Ent.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Entrada_Produto(Ent);
                }
            }
        }

        public static void Salvar(string codigo, string desccricao, string data_entrada, string fornecedor, string quantidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntradaProduto Ent = new EntradaProduto())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Ent.Data_Compra = data_entrada.Insert(data_entrada.Length, "'").Insert(0, "'").Replace('/', '.');
                    //
                    Ent.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    if (fornecedor == "" || fornecedor == null)
                    {
                        Ent.Cod_Fornecedor = 0;
                        Ent.Nome_Fornecedor = "null";
                    }
                    else
                    {
                        string[] items = fornecedor.Split('-');
                        Ent.Cod_Fornecedor = Convert.ToInt32(items[0]);
                        Ent.Nome_Fornecedor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Ent.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Ent.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Ent.Cod_Produto = Convert.ToInt32(codigo);
                    Ent.Desc_Produto = desccricao.Insert(desccricao.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Entrada_Produto(Ent);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }


        public static DataTable Sel_Entrada_Prod_Todos(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntradaProduto Ent = new EntradaProduto())
                {
                    Ent.Cod_Produto = Convert.ToInt32(codigo);
                    return con.Sel_Entrada_Prod_Todos(Ent);
                }
            }
        }

        public static DataTable Sel_ComboboxFornecedor_Valor_A_Alterar(string cbbfornecedor)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntradaProduto Est = new EntradaProduto())
                {
                    string[] items = cbbfornecedor.Split('-');
                    Est.Cod_Fornecedor = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxFornecedor_Valor_A_Alterar(Est);
                }
            }
        }

        public static void Sel_Prod_Reduzir_Saldo_Atual_Cad_Prod(string codigo, string quantidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (EntradaProduto Ent = new EntradaProduto())
                {
                    decimal Quantidade = Convert.ToDecimal(quantidade);
                    //
                    Ent.Cod_Produto = Convert.ToInt32(codigo);
                    //
                    if ((con.Sel_Prod_Reduzir_Saldo_Atual_Cad_Prod(Ent) - Quantidade) == Convert.ToDecimal("0,00"))
                    {
                        Ent.Quantidade = 0;
                    }
                    else
                    {
                        Ent.Quantidade = con.Sel_Prod_Reduzir_Saldo_Atual_Cad_Prod(Ent) - Quantidade;
                    }
                    //
                    con.Atualizar_Saldo_Produto_Ent(Ent);
                }
            }
        }

        public static string Sel_Ent_Ultimo_Cod_Adicionado()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ent_Ultimo_Cod_Adicionado().ToString();
            }
        }

        public static DataTable Sel_Produtos_FornProd()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Produtos_FornProd();
            }
        }

        public static DataTable Sel_Fornecedor_FornProd()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Fornecedor_FornProd();
            }
        }

        public static DataTable Sel_Cliente_Ent()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_Ent();
            }
        }

        public static DataTable Sel_Fornecedores_Prod_Dados(string data_inicio, string data_fim, string produto, string fornecedor, string tipo, string hora_inicio, string hora_fim, string cliente, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;
                string SqlProduto;
                string SqlFornecedorEnt;
                string SqlFornecedorDfe;
                string SqlClienteDfe;
                string SqlClienteEnt;
                string SqlDataEnt;
                string SqlDataDfe;
                string SqlCodDFeDFe;
                string SqlCodDFeEnt;
                //
                if (data_inicio.Contains("_") || data_fim.Contains("_"))
                {
                    SqlDataEnt = "WHERE entrada_produto.data_cadastro BETWEEN '21.07.2010 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                    SqlDataDfe = "WHERE dfe.data_emissao BETWEEN '21.07.2010 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = "";
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
                    SqlDataEnt = "WHERE entrada_produto.data_entrada BETWEEN '" + data_inicio.Replace('/', '.') + hora_inicio + "' AND '" + data_fim.Replace('/', '.') + hora_fim + "'";
                    SqlDataDfe = "WHERE dfe.data_emissao BETWEEN '" + data_inicio.Replace('/', '.') + hora_inicio + "' AND '" + data_fim.Replace('/', '.') + hora_fim + "'";
                }
                //               
                if (fornecedor == "")
                {
                    SqlFornecedorEnt = "";
                    SqlFornecedorDfe = "";
                }
                else
                {
                    items = fornecedor.Split('—');
                    SqlFornecedorEnt = " AND entrada_produto.id_fornecedor=" + items[0];
                    SqlFornecedorDfe = " AND dfe.id_emitente_destinatario=" + items[0];
                }
                //
                if (cliente == "")
                {
                    SqlClienteDfe = "";
                    SqlClienteEnt = "";
                }
                else
                {
                    items = cliente.Split('—');
                    SqlClienteDfe = " AND dfe.id_emitente_destinatario=" + items[0] + " AND dfe.emissao='PRÓPRIA'";
                    SqlClienteEnt = " AND produto.palavra_chave=';'";
                }
                //
                if (produto == "")
                {
                    SqlProduto = "";
                }
                else
                {
                    items = produto.Split('—');
                    SqlProduto = " AND produto.id_produto=" + items[0];
                }
                //
                if (cod_dfe == "")
                {
                    SqlCodDFeDFe = "";
                    SqlCodDFeEnt = "";
                }
                else
                {
                    SqlCodDFeDFe = " AND dfe.id_dfe=" + cod_dfe;
                    SqlCodDFeEnt = " AND produto.palavra_chave=';'";
                }
                //
                if (tipo == "MANUAL")
                {
                    return con.Sel_Fornecedores_Prod_Dados_Ent(SqlProduto, SqlFornecedorEnt, SqlDataEnt);
                }
                else if (tipo == "DFe")
                { 
                    return con.Sel_Fornecedores_Prod_Dados_Dfe(SqlProduto, SqlFornecedorDfe, SqlDataDfe, SqlClienteDfe, SqlCodDFeDFe);
                }
                else
                {
                    return con.Sel_Fornecedores_Prod_Dados(SqlProduto, SqlFornecedorEnt, SqlDataEnt, SqlFornecedorDfe, SqlDataDfe, SqlClienteDfe, SqlCodDFeDFe, SqlClienteEnt, SqlCodDFeEnt);
                }
            }
        }
    }
}
