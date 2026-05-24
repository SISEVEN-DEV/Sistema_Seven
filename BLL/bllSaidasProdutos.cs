using DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public class bllSaidasProdutos
    {
        public static bool _FrmRelSaidasProdutos_Aberto;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        public static string _Saidas_Prod_PesqCliente_Tabela;
        public static string _Saidas_Prod_PesqForn_Tabela;
        public static string _Saidas_Prod_PesqProd_Tabela;
        public static string _Saidas_Prod_PesqGrupo_Tabela;
        public static string _Saidas_Prod_PesqUsuarioTabela;
        public static string _Saidas_Prod_PesqCompPDV_Tabela;
        public static string _Saidas_Prod_PesqCCFOP_Tabela;
        public static string _Saidas_Prod_PesqServ_Tabela;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static DataTable Sel_Produtos_Saidas_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Produtos_Saidas_Prod();
            }
        }

        public static DataTable Sel_Servicos_Saidas_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Servicos_Saidas_Prod();
            }
        }

        public static DataTable Sel_Cfop_Dfe_Saida_Produtos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cfop_Dfe_Saida_Produtos();
            }
        }

        public static DataTable Sel_Cod_PDV_Saidas_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cod_PDV_Saidas_Prod();
            }
        }

        public static DataTable Sel_Consumidor_Saidas_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Consumidor_Saidas_Prod();
            }
        }

        public static DataTable Sel_Grupo_Saidas_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Grupo_Saidas_Prod();
            }
        }

        public static DataTable Sel_Fornecedor_Saidas_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Fornecedor_Saidas_Prod();
            }
        }

        public static DataTable Sel_Usuario_Saidas_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Saidas_Prod();
            }
        }

        public static DataTable Sel_Saidas_Produtos_Dados(string data_inicio, string data_fim, string produto, string consumidor, string fornecedor, string tipo, string usuario, string um, string cod_pdv_computador, string hora_inicio, string hora_fim, string cod_venda, string finalidade, string csosn, string cfop, string servico, string tipoitem)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;

                string SqlData = "";
                string SqlDataDfe = "";
                string SqlProduto = "";
                string SqlProdutoDfe = "";
                string SqlUsuario = "";
                string SqlConsumidor = "";
                string SqlConsumidorDfe = "";
                string SqlFornecedor = "";
                string SqlFornecedorDfe = "";
                string SqlTipo = "";
                string SqlTipoDfe = "";
                string SqlUm = "";
                string SqlUmDfe = "";
                string SqlCodPdvComputador = "";
                string SqlCodVenda = "";
                string SqlCodVendaDfe = "";
                string SqlFinalidadeDfe = "";
                string SqlCSOSNDfe = "";
                string SqlCFOPDfe = "";
                string SqlServico = "";
                string SqlTabelaServico = "";
                string SqlTabelaProduto = "";
                string SqlCompServico = "";
                string SqlCompProduto = "";
                string SqlTipoItem = "";
                string SqlTipoItemDfe = "";
                //
                if (data_inicio.Contains("_") || data_fim.Contains("_"))
                {
                    SqlData = "WHERE venda.data BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                    SqlDataDfe = "WHERE dfe.data_cadastro BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
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
                    SqlData = "WHERE venda.data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                    SqlDataDfe = "WHERE dfe.data_cadastro BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (tipo == "")
                {
                    SqlTipo = "";
                }
                else
                {
                    if (tipo == "DAV")
                    {
                        SqlTipo = " AND (venda.tipo='DAV' OR venda.tipo='DAV/NFCe' OR venda.tipo='DAV/NFe')";
                        SqlTipoDfe = " AND dfe.modelo=0";
                    }
                    else if (tipo == "NFSe")
                    {
                        SqlTipo = " AND (venda.tipo='NFSe' OR venda.tipo='NFSe/NFCe' OR venda.tipo='NFSe/NFe')";
                        SqlTipoDfe = " AND dfe.modelo=0";
                    }
                    else if (tipo == "SERVICO")
                    {
                        SqlTipo = " AND (venda.tipo='SERVICO' OR venda.tipo='SERVICO/NFCe' OR venda.tipo='SERVICO/NFe')";
                        SqlTipoDfe = " AND dfe.modelo=0";
                    }
                    else if (tipo == "NFCe")
                    {
                        SqlTipo = " AND (venda.tipo='NFCe' OR venda.tipo='SERVICO/NFCe' OR venda.tipo='NFSe/NFCe' OR venda.tipo='DAV/NFCe')";
                        SqlTipoDfe = " AND dfe.modelo=65";
                    }
                    else if (tipo == "NFe")
                    {
                        SqlTipo = " AND (venda.tipo='NFe' OR venda.tipo='SERVICO/NFe' OR venda.tipo='NFSe/NFe' OR venda.tipo='DAV/NFe')";
                        SqlTipoDfe = " AND dfe.modelo=55";
                    }
                }
                //
                if (produto == "")
                {
                    SqlProduto = "";
                    SqlProdutoDfe = "";
                }
                else
                {
                    items = produto.Split('—');
                    SqlProduto = " AND produto.id_produto=" + items[0] + " AND item_venda.tipo='PRODUTO'";
                    SqlProdutoDfe = " AND produto.id_produto=" + items[0];
                    SqlTabelaProduto = ", produto ";
                    SqlCompServico = " AND item_venda.id_produto=produto.id_produto";
                }
                //
                if (servico == "")
                {
                    SqlServico = "";
                }
                else
                {
                    items = servico.Split('—');
                    SqlServico = " AND servico.id_servico=" + items[0] + " AND item_venda.tipo='SERVICO'";
                    SqlProdutoDfe = " AND produto.id_produto=0";
                    SqlTabelaServico = ", servico ";
                    SqlCompServico = " AND item_venda.id_produto=servico.id_servico";
                }
                //
                if (consumidor == "")
                {
                    SqlConsumidor = "";
                    SqlConsumidorDfe = "";
                }
                else
                {
                    items = consumidor.Split('—');
                    SqlConsumidor = " AND venda.id_consumidor=" + items[0];
                    SqlConsumidorDfe = " AND dfe.id_emitente_destinatario=" + items[0];
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
                if (um == "")
                {
                    SqlUm = "";
                    SqlUmDfe = "";
                }
                else
                {
                    SqlUm = " AND item_venda.um='" + um + "'";
                    SqlUmDfe = " AND item_dfe.um='" + um + "'";
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
                if (cod_venda == "")
                {
                    SqlCodVenda = "";
                    SqlCodVendaDfe = "";
                }
                else
                {
                    SqlCodVenda = " AND venda.id_venda=" + cod_venda;
                    SqlCodVendaDfe = "AND dfe.id_venda=" + cod_venda;
                }
                //
                if (csosn == "")
                {
                    SqlCSOSNDfe = "";
                }
                else
                {
                    SqlCSOSNDfe = " AND item_dfe.csosn=" + csosn;
                }
                //
                if (cfop == "")
                {
                    SqlCFOPDfe = "";
                }
                else
                {
                    SqlCFOPDfe = " AND item_dfe.cfop=" + cfop;
                }
                //
                if (finalidade == "")
                {
                    SqlFinalidadeDfe = "";
                }
                else
                {
                    SqlFinalidadeDfe = " AND dfe.finalidade='" + finalidade + "' AND dfe.finalidade<>'ENTRADA' AND dfe.finalidade<>'RETORNO'";
                }
                //
                if (tipoitem == "")
                {
                    SqlTipoItem = "";
                }
                else
                {
                    SqlTipoItem = " AND item_venda.tipo='" + tipoitem + "'";
                    if ((finalidade != "" || cfop != "" || csosn != "") & tipoitem == "SERVICO")
                    {
                        SqlTipoItemDfe = " AND produto.id_produto=0";
                    }
                    else
                    {
                        SqlTipoItemDfe = "";
                    }
                }
                //
                if (finalidade != "" || cfop != "" || csosn != "")
                {
                    if (fornecedor == "")
                    {
                        SqlFornecedorDfe = " entrada_produto.id_produto=produto.id_produto ";
                        return con.Sel_Saidas_Produtos_Dados_Dfe(SqlDataDfe, SqlProdutoDfe, SqlConsumidorDfe, SqlFornecedorDfe, SqlUmDfe, SqlFinalidadeDfe, SqlCSOSNDfe, SqlCFOPDfe, SqlTipoDfe, SqlTipoItemDfe);
                    }
                    else
                    {
                        items = fornecedor.Split('—');
                        SqlFornecedorDfe = " entrada_produto.id_fornecedor=" + items[0] + " AND entrada_produto.id_produto=produto.id_produto ";
                        if (con.Sel_Fornecedor_Entrada_Produto_Exist_Saida(items[0]) == null)
                        {
                            return null;
                        }
                        else
                        {
                            return con.Sel_Saidas_Produtos_Dados_Dfe(SqlDataDfe, SqlProdutoDfe, SqlConsumidorDfe, SqlFornecedorDfe, SqlUmDfe, SqlFinalidadeDfe, SqlCSOSNDfe, SqlCFOPDfe, SqlTipoDfe, SqlTipoItem);
                        }
                    }
                }
                else
                {
                    if (fornecedor == "")
                    {
                        SqlFornecedor = " entrada_produto.id_produto=item_venda.id_produto ";
                        SqlFornecedorDfe = " entrada_produto.id_produto=item_venda.id_produto ";
                        return con.Sel_Saidas_Produtos_Dados(SqlData, SqlProduto, SqlConsumidor, SqlFornecedor, SqlTipo, SqlUsuario, SqlUm, SqlCodPdvComputador, SqlCodVenda, SqlServico, SqlCompServico, SqlTabelaServico, SqlCompProduto, SqlTabelaProduto, SqlTipoItem);
                    }
                    else
                    {
                        items = fornecedor.Split('—');
                        SqlFornecedor = " entrada_produto.id_fornecedor=" + items[0] + " AND entrada_produto.id_produto=item_venda.id_produto ";
                        SqlFornecedorDfe = " entrada_produto.id_fornecedor=" + items[0] + " AND entrada_produto.id_produto=item_venda.id_produto ";
                        if (con.Sel_Fornecedor_Entrada_Produto_Exist_Saida(items[0]) == null)
                        {
                            return null;
                        }
                        else
                        {
                            return con.Sel_Saidas_Produtos_Dados(SqlData, SqlProduto, SqlConsumidor, SqlFornecedor, SqlTipo, SqlUsuario, SqlUm, SqlCodPdvComputador, SqlCodVenda, SqlServico, SqlCompServico, SqlTabelaServico, SqlCompProduto, SqlTabelaProduto, SqlTipoItem);
                        }
                    }
                }
            }
        }
    }
}
