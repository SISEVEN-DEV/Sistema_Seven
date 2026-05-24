using DAL;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading;
using ACBrLib.NFe;
using System.Text;
using System.Windows.Forms;
using ACBrLib.Core.DFe;
using ACBrLib.Core.NFe;

namespace BLL
{
    public class bllDFe
    {
        public static bool _FrmCadDocFiscais_Ativo;
        public static bool _FrmRelDocFiscais_Ativo;
        public static bool _FrmCadNFeNFCe_Ativo;
        public static bool _FrmMenuNFeNFCe_Ativo;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        //
        public static string _FornDFe_Prod_PesqFornClieFunc_Tabela;
        public static string _FornDFe_Cfop_PesqCfop_Tabela;
        public static string _FornDFe_Produto_PesqProduto_Tabela;
        public static string _FornDFe_Orcamento_PesqProduto_Tabela;
        public static string _Forma_Pagamento_PesqFormaPagamento_Tabela;

        public static byte _Tipo_Captura;
        public static string _Cod_Orcamento;
        public static string _Cod_Venda;
        public static string _Cod_DFe;
        public static string _Chave_DFe;
        //
        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;
        //
        public static bool _Consumidor_Final;
        public static string _Tipo_Operacao;
        public static string _JustificativaInutCancelCorr;
        //
        public static string _Cod_CFOP_Cadastro;

        public static bool Sel_C_DFe_Chave(string chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Chave_DFe = chave;
                    return con.Sel_C_DFe_Chave(Nfe);
                }
            }
        }

        public static bool Transmitir_NFCe(string cod_dfe, string cod_pdv_computador, bool contingencia)
        {
            try
            {
                bool retorno;
                //
                DataRow drDFe = bllDFe.Sel_Nfe_Codigo(cod_dfe).Rows[0];
                //
                ACBrNFe ACBrNFe;
                if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                {
                    ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                }
                else
                {
                    ACBrNFe = new ACBrNFe();
                }
                //
                if (bllDFe.CriarDFeNFCe(cod_dfe, cod_pdv_computador, contingencia) == true)
                {
                    ACBrNFe.Config.ModeloDF = ACBrLib.Core.NFe.ModeloNFe.moNFCe;
                    //
                    ACBrNFe.CarregarINI(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\nfce" + drDFe["numero_nf"].ToString() + ".ini");
                    //
                    if (contingencia == false)
                    {
                        var ret = ACBrNFe.Enviar(1, sincrono: true);
                        //
                        if (ret.Envio.CStat == 100)
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "TRANSMITIDA", cod_dfe, ret.Envio.NProt);
                            //
                            drDFe = bllDFe.Sel_Nfe_Codigo(cod_dfe).Rows[0];
                            //
                            if (bllXML.Sel_Dados_XML(cod_dfe) == null)
                            {
                                if (File.Exists(drDFe["caminho_dfe"].ToString()) == true)
                                {
                                    bllXML.Salvar(cod_dfe, File.ReadAllText(drDFe["caminho_dfe"].ToString(), Encoding.UTF8), true);
                                }
                                else
                                {
                                    MessageBox.Show("O XML não foi encontrado para inclusão no banco de dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            //
                            retorno = true;
                        }
                        else if (ret.Envio.CStat == 110)
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "DENEGADA", cod_dfe, ret.Envio.NProt);
                            retorno = false;
                        }
                        else if (ret.Envio.CStat == 150)
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "TRANSMITIDA", cod_dfe, ret.Envio.NProt);
                            //
                            drDFe = bllDFe.Sel_Nfe_Codigo(cod_dfe).Rows[0];
                            //
                            if (bllXML.Sel_Dados_XML(cod_dfe) == null)
                            {
                                if (File.Exists(drDFe["caminho_dfe"].ToString()) == true)
                                {
                                    bllXML.Salvar(cod_dfe, File.ReadAllText(drDFe["caminho_dfe"].ToString(), Encoding.UTF8), true);
                                }
                                else
                                {
                                    MessageBox.Show("O XML não foi encontrado para inclusão no banco de dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            //
                            retorno = true;
                        }
                        else if (ret.Envio.CStat == 204)
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "PENDENTE", cod_dfe, ret.Envio.NProt);
                            retorno = false;
                        }
                        else if (ret.Envio.CStat == 206)
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "INUTILIZADA", cod_dfe, ret.Envio.NProt);
                            retorno = false;
                        }
                        else if (ret.Envio.CStat == 218)
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "CANCELADA", cod_dfe, ret.Envio.NProt);
                            retorno = false;
                        }
                        else if (ret.Envio.CStat == 256)
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "INUTILIZADA", cod_dfe, ret.Envio.NProt);
                            retorno = false;
                        }
                        else if (ret.Envio.CStat == 301)
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "DENEGADA", cod_dfe, ret.Envio.NProt);
                            retorno = false;
                        }
                        else if (ret.Envio.CStat == 302)
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "DENEGADA", cod_dfe, ret.Envio.NProt);
                            retorno = false;
                        }
                        else if (ret.Envio.CStat == 539)
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "PENDENTE", cod_dfe, ret.Envio.NProt);
                            retorno = false;
                        }
                        else
                        {
                            bllDFe.Alterar_Situacao_DFe(ret.Envio.CStat.ToString(), "PENDENTE", cod_dfe, ret.Envio.NProt);
                            retorno = false;
                        }
                    }
                    else
                    {
                        retorno = false;
                        //
                        ACBrNFe.Assinar();
                        var ret = ACBrNFe.ObterXml(0);
                    }
                    //
                    ACBrNFe.Config.DANFe.NFCe.MargemEsquerda = Convert.ToInt32(bllConfiguracaoSistema.Sel_Margem_Esq_NFCe(bllConexao._Codigo_Conexao));
                    ACBrNFe.Config.DANFe.NFCe.MargemDireita = Convert.ToInt32(bllConfiguracaoSistema.Sel_Margem_Dir_NFCe(bllConexao._Codigo_Conexao));
                    ACBrNFe.Config.DANFe.NFCe.ImprimeQRCodeLateral = true;
                    //
                    if (contingencia == false & retorno == true)
                    {
                        if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)")
                        {
                            ACBrNFe.Config.DANFe.NFCe.TipoRelatorioBobina = TipoRelatorioBobina.tpFortes;
                            if (bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao) == null)
                            {
                                ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                                ACBrNFe.Imprimir(bMostrarPreview: false, nNumCopias: 1, bViaConsumidor: true);
                            }
                            else
                            {
                                ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                                ACBrNFe.Imprimir(bMostrarPreview: false, cImpressora: bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao), nNumCopias: 1, bViaConsumidor: true);
                            }
                        }
                        else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "A4(Mostrar na Tela)")
                        {
                            ACBrNFe.Config.DANFe.NFCe.TipoRelatorioBobina = TipoRelatorioBobina.tpFortesA4;
                            ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                            ACBrNFe.Imprimir(cImpressora: bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao), bMostrarPreview: true, bViaConsumidor: true);
                        }
                        else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)(Mostrar na Tela)")
                        {
                            ACBrNFe.Config.DANFe.NFCe.TipoRelatorioBobina = TipoRelatorioBobina.tpFortes;
                            ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                            ACBrNFe.Imprimir(cImpressora: bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao), bMostrarPreview: true, bViaConsumidor: true, bSimplificado: false);
                        }
                    }
                    else if (contingencia == true & retorno == false)
                    {
                        if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)")
                        {
                            ACBrNFe.Config.DANFe.NFCe.TipoRelatorioBobina = TipoRelatorioBobina.tpFortes;
                            if (bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao) == null)
                            {
                                ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                                ACBrNFe.Imprimir(bMostrarPreview: false, nNumCopias: 1, bViaConsumidor: true);
                                //
                                ACBrNFe.Imprimir(bMostrarPreview: false, nNumCopias: 1, bViaConsumidor: false);
                            }
                            else
                            {
                                ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                                ACBrNFe.Imprimir(bMostrarPreview: false, cImpressora: bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao), nNumCopias: 1, bViaConsumidor: true);
                                //
                                ACBrNFe.Imprimir(bMostrarPreview: false, cImpressora: bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao), nNumCopias: 1, bViaConsumidor: false);
                            }
                        }
                        else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "A4(Mostrar na Tela)")
                        {
                            ACBrNFe.Config.DANFe.NFCe.TipoRelatorioBobina = TipoRelatorioBobina.tpFortesA4;
                            ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                            ACBrNFe.Imprimir(cImpressora: bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao), bMostrarPreview: true, bViaConsumidor: true);
                            //
                            ACBrNFe.Imprimir(cImpressora: bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao), bMostrarPreview: true, bViaConsumidor: false, bSimplificado: false);
                        }
                        else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)(Mostrar na Tela)")
                        {
                            ACBrNFe.Config.DANFe.NFCe.TipoRelatorioBobina = TipoRelatorioBobina.tpFortes;
                            ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                            ACBrNFe.Imprimir(cImpressora: bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao), bMostrarPreview: true, bViaConsumidor: true);
                            //
                            ACBrNFe.Imprimir(cImpressora: bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao), bMostrarPreview: true, bViaConsumidor: false);
                        }
                    }
                    //
                    ACBrNFe.Dispose();
                    ACBrNFe = null;
                    //
                }
                else
                {
                    retorno = false;
                }
                //
                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Transmitir_NFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Transmitir_NFCe.");
                }
                return false;
            }
        }

        public static bool CriarDFeNFCe(string cod_dfe, string cod_pdv_computador, bool contingencia)
        {
            ACBrNFe ACBrNFe;
            if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
            {
                ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
            }
            else
            {
                ACBrNFe = new ACBrNFe();
            }
            //
            string[] items;
            //
            decimal base_calculo_icms = 0;
            decimal base_calculo_icms_st = 0;
            decimal total_aprox_trib = 0;
            decimal total_aprox_trib_mun = 0;
            decimal total_aprox_trib_estadual = 0;
            decimal total_aprox_trib_federal = 0;
            //
            DataRow drDFe = bllDFe.Sel_Nfe_Codigo(cod_dfe).Rows[0];
            //
            DataRow drMinhaEmpresa = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
            //
            string criarini = null;
            //
            string versao = null;
            if (ACBrNFe.Config.VersaoDF.ToString() == "ve200")
            {
                versao = "2.00";
            }
            else if (ACBrNFe.Config.VersaoDF.ToString() == "ve300")
            {
                versao = "3.00";
            }
            else if (ACBrNFe.Config.VersaoDF.ToString() == "ve310")
            {
                versao = "3.10";
            }
            else if (ACBrNFe.Config.VersaoDF.ToString() == "ve400")
            {
                versao = "4.00";
            }
            //
            string cUF = null;
            if (drMinhaEmpresa["UF"].ToString() == "AC")
            {
                cUF = "12";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "AL")
            {
                cUF = "27";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "AP")
            {
                cUF = "16";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "AM")
            {
                cUF = "13";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "BA")
            {
                cUF = "29";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "CE")
            {
                cUF = "23";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "DF")
            {
                cUF = "53";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "ES")
            {
                cUF = "32";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "GO")
            {
                cUF = "52";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "MA")
            {
                cUF = "21";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "MT")
            {
                cUF = "51";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "MS")
            {
                cUF = "50";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "MG")
            {
                cUF = "31";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "PA")
            {
                cUF = "15";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "PB")
            {
                cUF = "25";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "PR")
            {
                cUF = "41";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "PE")
            {
                cUF = "26";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "PI")
            {
                cUF = "22";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "RJ")
            {
                cUF = "33";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "RN")
            {
                cUF = "24";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "RS")
            {
                cUF = "43";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "RO")
            {
                cUF = "11";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "RR")
            {
                cUF = "14";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "SC")
            {
                cUF = "42";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "SP")
            {
                cUF = "35";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "SE")
            {
                cUF = "28";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "TO")
            {
                cUF = "17";
            }
            //
            string cNF = null;
            cNF = drDFe["codigo_aleatorio"].ToString();
            //
            string natOp = null;
            natOp = drDFe["descricao_cfop_natop"].ToString();
            //
            string indPag = null;
            /*
            if (bllDFe.Sel_Formas_Pagamento_DFe(cod_dfe) != null)
            {
                indPag = "1";
            }
            else
            {
                indPag = "0";
            }
            */
            //
            string mod = drDFe["modelo"].ToString();
            //
            string serie = drDFe["serie"].ToString();
            //
            string nNF = drDFe["numero_nf"].ToString();
            //
            string dhEmi = drDFe["data_emissao"].ToString().Remove(10) + " " + drDFe["hora_emissao"].ToString();
            //
            string tpNF = "1";
            //VERIFICAR
            string finNFe = "0";
            //
            string idDest = "1";
            //
            string tpImp = "4";
            //
            string tpEmis = null;
            if (contingencia == false)
            {
                if (ACBrNFe.Config.FormaEmissao.ToString() == "teNormal")
                {
                    tpEmis = "1";
                }
                else if (ACBrNFe.Config.FormaEmissao.ToString() == "teContingencia")
                {
                    tpEmis = "2";
                }
                else if (ACBrNFe.Config.FormaEmissao.ToString() == "teSCAN")
                {
                    tpEmis = "3";
                }
                else if (ACBrNFe.Config.FormaEmissao.ToString() == "teDPEC")
                {
                    tpEmis = "4";
                }
                else if (ACBrNFe.Config.FormaEmissao.ToString() == "teFSDA")
                {
                    tpEmis = "5";
                }
                else if (ACBrNFe.Config.FormaEmissao.ToString() == "teSVCAN")
                {
                    tpEmis = "6";
                }
                else if (ACBrNFe.Config.FormaEmissao.ToString() == "teSVCRS")
                {
                    tpEmis = "7";
                }
                else if (ACBrNFe.Config.FormaEmissao.ToString() == "teSVCSP")
                {
                    tpEmis = "8";
                }
                else if (ACBrNFe.Config.FormaEmissao.ToString() == "teOffLine")
                {
                    tpEmis = "9";
                }
            }
            else
            {
                tpEmis = "9";
            }
            //
            string chaveNFeNFCe = ACBrNFe.GerarChave(Convert.ToInt32(cUF), Convert.ToInt32(cNF), Convert.ToInt32(drDFe["modelo"]), Convert.ToInt32(serie), Convert.ToInt32(nNF), Convert.ToInt32(tpEmis), Convert.ToDateTime(drDFe["data_emissao"]), drMinhaEmpresa["cpf_cnpj"].ToString());
            string chaveNFeNFCeMascarada = chaveNFeNFCe.Insert(2, "-").Insert(7, "-").Insert(10, ".").Insert(14, ".").Insert(18, "/").Insert(23, "-").Insert(26, "-").Insert(29, "-").Insert(33, "-").Insert(37, ".").Insert(41, ".").Insert(45, "-").Insert(47, "-").Insert(50, ".").Insert(54, ".").Insert(58, "-");
            //
            if (drDFe["chave_dfe"].ToString() == null || drDFe["chave_dfe"].ToString() != chaveNFeNFCeMascarada)
            {
                bllDFe.Alterar_Chave_DFe(chaveNFeNFCeMascarada, drDFe["id_dfe"].ToString());
                //
                string mes;
                if (Convert.ToDateTime(drDFe["data_emissao"]).Month < 10)
                {
                    mes = "0" + Convert.ToDateTime(drDFe["data_emissao"]).Month;
                }
                else
                {
                    mes = Convert.ToDateTime(drDFe["data_emissao"]).Month.ToString();
                }
                //
                bllDFe.Alterar_Caminho_DFe(ACBrNFe.Config.PathNFe + @"\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\NFCe\" + Convert.ToDateTime(drDFe["data_emissao"]).Year + mes + @"\NFCe\" + chaveNFeNFCe + "-nfe.xml", drDFe["id_dfe"].ToString());
            }
            string cDV = chaveNFeNFCe.Substring(43);
            //
            string tpAmb = null;
            if (ACBrNFe.Config.Ambiente == TipoAmbiente.taProducao)
            {
                tpAmb = "1";
            }
            else
            {
                tpAmb = "2";
            }
            //
            string indFinal = null;
            indFinal = "1";
            //
            string indPres = null;
            indPres = "1";
            //
            string verProc = null;
            items = cod_pdv_computador.Split('/');
            verProc = "siseven " + items[0].Replace("Versão: ", "");
            //
            string dhCont = null;
            if (contingencia == false)
            {
                dhCont = "0";
            }
            else
            {
                dhCont = drDFe["data_emissao"].ToString().Remove(10) + " " + drDFe["hora_emissao"].ToString();
            }
            //
            string xJust = null;
            if (contingencia == true)
            {
                xJust = "Sem acesso a internet";
            }
            //VERIFICAR
            //DOCUMENTOS REFERENCIADOS
            //****************************
            //EMITENTE
            string CRT = null;
            if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL")
            {
                CRT = "1";
            }
            else if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL - MEI")
            {
                CRT = "4";
            }
            //
            string CNPJCPF = null;
            CNPJCPF = drMinhaEmpresa["cpf_cnpj"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
            //
            string xNome = null;
            xNome = drMinhaEmpresa["nome"].ToString();
            //
            string xFant = null;
            xFant = drMinhaEmpresa["fantasia"].ToString();
            //
            string IE = null;
            IE = drMinhaEmpresa["ie_rg"].ToString().ToString().Replace(".", "").Replace("-", "");
            //
            string IEST = null;
            IEST = "";
            //
            string IM = null;
            IM = "";
            //
            string CNAE = null;
            CNAE = "";
            //
            string xLgr = null;
            xLgr = drMinhaEmpresa["endereco"].ToString();
            //
            string nro = null;
            nro = drMinhaEmpresa["numero"].ToString();
            //
            string xCpl = null;
            xCpl = drMinhaEmpresa["complemento"].ToString();
            //
            string xBairro = null;
            xBairro = drMinhaEmpresa["bairro"].ToString();
            //
            string cMun = null;
            cMun = drMinhaEmpresa["codigo_municipio"].ToString();
            //
            string xMun = null;
            xMun = drMinhaEmpresa["cidade"].ToString();
            //
            string UF = null;
            UF = drMinhaEmpresa["uf"].ToString();
            //
            string CEP = null;
            CEP = drMinhaEmpresa["cep"].ToString().Replace(".", "").Replace("-", "");
            //
            string Fone = null;
            if (drMinhaEmpresa["telefone"].ToString() != null)
            {
                Fone = drMinhaEmpresa["telefone"].ToString();
            }
            else
            {
                Fone = drMinhaEmpresa["celular"].ToString();
            }
            //
            //NOTA AVULSA
            //****************************
            //DESTINARIO
            string idEstrangeiro = null;
            string CNPJCPF_Dest = null;
            string xNome_Dest = null;
            string indIEDest = null;
            string IE_Dest = null;
            string ISUF = null;
            string IM_Dest = null;
            string Email = null;
            string xLgr_Dest = null;
            string nro_Dest = null;
            string xCpl_Dest = null;
            string xBairro_Dest = null;
            string cMun_Dest = null;
            string xMun_Dest = null;
            string UF_Dest = null;
            string CEP_Dest = null;
            string cPais_Dest = null;
            string xPais_Dest = null;
            string Fone_Dest = null;
            //
            DataRow drDestinatario;
            if (drDFe["id_emitente_destinatario"].ToString() != "0")
            {
                if (bllClieCons.Sel_Cliente_Codigo(drDFe["id_emitente_destinatario"].ToString()) != null)
                {
                    drDestinatario = bllClieCons.Sel_Cliente_Codigo(drDFe["id_emitente_destinatario"].ToString()).Rows[0];
                }
                else
                {
                    throw new InvalidOperationException("O Cliente/Consumidor de código [ " + drDFe["id_emitente_destinatario"].ToString() + " ] não foi encontrado.");
                }
                //
                CNPJCPF_Dest = drDestinatario["cpf_cnpj"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
                //
                if (drDestinatario["nome"].ToString() != "CONSUMIDOR FINAL")
                {
                    xNome_Dest = drDestinatario["nome"].ToString();
                }
                //
                indIEDest = "9";
            }            
            //
            //AUTXML
            //
            string CPFCNPJ_Autxml = null;
            if (drMinhaEmpresa["cpf_cnpj_contador"].ToString() == null || drMinhaEmpresa["cpf_cnpj_contador"].ToString() == "")
            {
                CPFCNPJ_Autxml = "13937073000156";
            }
            else
            {
                CPFCNPJ_Autxml = drMinhaEmpresa["cpf_cnpj_contador"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
            }
            //
            //PRODUTOS
            //
            string produtos_imposto = "";
            if (bllDFe.Sel_Items_DFe(drDFe["id_dfe"].ToString()) != null)
            {
                for (int i = 0; i < bllDFe.Sel_Items_DFe(drDFe["id_dfe"].ToString()).Rows.Count; i++)
                {
                    DataRow drItems;
                    if (bllDFe.Sel_Items_DFe(drDFe["id_dfe"].ToString()) != null)
                    {
                        drItems = bllDFe.Sel_Items_DFe(drDFe["id_dfe"].ToString()).Rows[i];
                    }
                    else
                    {

                        throw new InvalidOperationException("O Item [ " + (i + 1) + " ] não foi encontrado.");
                    }
                    //
                    produtos_imposto += "[Produto" + Convert.ToInt32(drItems["id_item"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string cProd = null;
                    cProd = drItems["id_produto"].ToString();
                    produtos_imposto += Environment.NewLine + "cProd=" + cProd;
                    //
                    DataRow drProduto;
                    if (bllProduto.Sel_Prod_Codigo(drItems["id_produto"].ToString(), "") != null)
                    {
                        drProduto = bllProduto.Sel_Prod_Codigo(drItems["id_produto"].ToString(), "").Rows[0];
                    }
                    else
                    {
                        throw new InvalidOperationException("O Produto do item [ " + drDFe["id_dfe"].ToString() + " ] não foi encontrado.");
                    }
                    //
                    string cEAN = null;
                    cEAN = drProduto["cod_barra"].ToString();
                    produtos_imposto += Environment.NewLine + "cEAN=" + cEAN;
                    //
                    string cEANTrib = null;
                    cEANTrib = drProduto["cod_barra"].ToString();
                    produtos_imposto += Environment.NewLine + "cEANTrib=" + cEANTrib;
                    //
                    string xProd = null;
                    xProd = drItems["descricao"].ToString();
                    produtos_imposto += Environment.NewLine + "xProd=" + xProd;
                    //
                    string NCM = null;
                    NCM = drProduto["ncm"].ToString().Replace(".", "");
                    produtos_imposto += Environment.NewLine + "NCM=" + NCM;
                    //produtos_imposto += Environment.NewLine + "NCM=12345678";
                    //
                    string CEST = null;
                    CEST = drProduto["cest"].ToString().Replace(".", "");
                    produtos_imposto += Environment.NewLine + "CEST=" + CEST;
                    //
                    string EXTIPI = null;
                    if (drProduto["excecao_ncm"].ToString() != "")
                    {
                        EXTIPI = Convert.ToInt32(drProduto["excecao_ncm"]).ToString("D3", new CultureInfo("pt-BR"));
                    }
                    produtos_imposto += Environment.NewLine + "EXTIPI=" + EXTIPI;
                    //
                    string CFOP = null;
                    CFOP = drItems["cfop"].ToString();
                    produtos_imposto += Environment.NewLine + "CFOP=" + CFOP;
                    //
                    string uCom = null;
                    uCom = drItems["um"].ToString();
                    produtos_imposto += Environment.NewLine + "uCom=" + uCom;
                    //
                    string qCom = null;
                    qCom = drItems["quantidade"].ToString();
                    produtos_imposto += Environment.NewLine + "qCom=" + qCom;
                    //
                    string vUnCom = null;
                    vUnCom = drItems["valor_unitario"].ToString();
                    produtos_imposto += Environment.NewLine + "vUnCom=" + vUnCom;
                    //
                    string vProd = null;
                    vProd = drItems["total"].ToString();
                    produtos_imposto += Environment.NewLine + "vProd=" + vProd;
                    //
                    string uTrib = null;
                    uTrib = drProduto["um"].ToString();
                    produtos_imposto += Environment.NewLine + "uTrib=" + uTrib;
                    //
                    string qTrib = null;
                    qTrib = drItems["quantidade"].ToString();
                    produtos_imposto += Environment.NewLine + "qTrib=" + qTrib;
                    //
                    string vUnTrib = null;
                    vUnTrib = drItems["valor_unitario"].ToString();
                    produtos_imposto += Environment.NewLine + "vUnTrib=" + vUnTrib;
                    //
                    string vSeg = null;
                    vSeg = "0.00";
                    produtos_imposto += Environment.NewLine + "vSeg=" + vSeg;
                    //
                    string vDesc = null;
                    vDesc = drItems["valor_desconto"].ToString();
                    produtos_imposto += Environment.NewLine + "vDesc=" + vDesc;
                    //
                    string vOutro = null;
                    vOutro = drItems["valor_acrescimo"].ToString();
                    produtos_imposto += Environment.NewLine + "vOutro=" + vOutro;
                    //
                    string xPed = null;
                    xPed = "";
                    produtos_imposto += Environment.NewLine + "xPed=" + xPed;
                    //
                    string nItemPed = null;
                    nItemPed = "";
                    produtos_imposto += Environment.NewLine + "nItemPed=" + nItemPed;
                    //
                    string nFCI = null;
                    nFCI = "";
                    produtos_imposto += Environment.NewLine + "nFCI=" + nFCI;
                    //
                    string nRECOPI = null;
                    nRECOPI = "";
                    produtos_imposto += Environment.NewLine + "nRECOPI=" + nRECOPI;
                    //
                    string pDevol = null;
                    pDevol = "";
                    produtos_imposto += Environment.NewLine + "pDevol=" + pDevol;
                    //
                    string vIPIDevol = null;
                    produtos_imposto += Environment.NewLine + "vIPIDevol=" + vIPIDevol;
                    //
                    decimal trib_federal = 0;
                    decimal trib_federal_imp = 0;
                    decimal trib_estadual = 0;
                    decimal trib_municipal = 0;
                    decimal total = 0;
                    DataRow drIBPT;
                    if (bllIBPT.Sel_IBPT_NCM(drProduto["ncm"].ToString(), drProduto["excecao_ncm"].ToString()) != null)
                    {
                        drIBPT = bllIBPT.Sel_IBPT_NCM(drProduto["ncm"].ToString(), drProduto["excecao_ncm"].ToString()).Rows[0];
                    }
                    else
                    {
                        throw new InvalidOperationException("O NCM do Produto [ " + drItems["id_produto"].ToString() + " ] não foi encontrado na tabela IBPT.");
                    }
                    //
                    trib_federal = Convert.ToDecimal(bllDFe.Calculo_IBPT(drItems["valor_total"].ToString(), drIBPT["trib_federal"].ToString()));
                    //decimal trib_federal_imp = Convert.ToDecimal(bllDFe.Calculo_IBPT(drItems["valor_total"].ToString(), drIBPT["trib_federal_importado"].ToString()));
                    trib_federal_imp = 0;
                    trib_estadual = Convert.ToDecimal(bllDFe.Calculo_IBPT(drItems["valor_total"].ToString(), drIBPT["trib_estadual"].ToString()));
                    trib_municipal = Convert.ToDecimal(bllDFe.Calculo_IBPT(drItems["valor_total"].ToString(), drIBPT["trib_municipal"].ToString()));
                    total = trib_federal + trib_federal_imp + trib_estadual + trib_municipal;
                    //
                    total_aprox_trib_mun += trib_municipal;
                    //
                    total_aprox_trib_estadual += trib_estadual;
                    //
                    total_aprox_trib_federal += trib_federal;
                    //
                    total_aprox_trib += total;
                    //
                    string vTotTrib = null;
                    //if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL")
                    //{
                    vTotTrib = total.ToString();
                    //}
                    //else if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL - MEI")
                    //{
                    //    vTotTrib = "0";
                    //}
                    produtos_imposto += Environment.NewLine + "vTotTrib=" + vTotTrib;
                    //
                    string infAdProd = null;
                    infAdProd = "";
                    produtos_imposto += Environment.NewLine + "infAdProd=" + infAdProd;
                    //
                    string indEscala = null;
                    indEscala = "";
                    produtos_imposto += Environment.NewLine + "indEscala=" + indEscala;
                    //
                    string CNPJFab = null;
                    CNPJFab = "";
                    produtos_imposto += Environment.NewLine + "CNPJFab=" + CNPJFab;
                    //
                    string cBenef = null;
                    cBenef = "";
                    produtos_imposto += Environment.NewLine + "cBenef=" + cBenef;
                    //
                    //IMPOSTOS
                    //
                    produtos_imposto += Environment.NewLine + Environment.NewLine + "[ICMS" + Convert.ToInt32(drItems["id_item"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string CSOSN = null;
                    CSOSN = drProduto["csosn"].ToString();
                    produtos_imposto += Environment.NewLine + "CSOSN=" + CSOSN;
                    //
                    string orig = null;
                    orig = drProduto["cst"].ToString().Remove(1, 2);
                    produtos_imposto += Environment.NewLine + "orig=" + orig;
                    //
                    string vBC_Prod = null;
                    //
                    string pICMS_Prod = null;
                    //
                    string vICMS_Prod = null;
                    //
                    if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL")
                    {
                        vBC_Prod = drItems["valor_base_calculo"].ToString();
                        //
                        pICMS_Prod = drItems["aliq_icms"].ToString();
                        //
                        vICMS_Prod = drItems["valor_icms"].ToString();
                    }
                    else if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL - MEI")
                    {
                        vBC_Prod = "0";
                        //
                        pICMS_Prod = "0";
                        //
                        vICMS_Prod = "0";
                    }
                    //
                    produtos_imposto += Environment.NewLine + "vBC=" + vBC_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "pICMS=" + pICMS_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "vICMS=" + vICMS_Prod;
                    //
                    produtos_imposto += Environment.NewLine + Environment.NewLine + "[IPI" + Convert.ToInt32(drItems["id_item"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string CST_IPI = null;
                    CST_IPI = "53";
                    produtos_imposto += Environment.NewLine + "CST=" + CST_IPI;
                    //
                    produtos_imposto += Environment.NewLine + Environment.NewLine + "[PIS" + Convert.ToInt32(drItems["id_item"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string CST_PIS = null;
                    CST_PIS = "01";
                    produtos_imposto += Environment.NewLine + "CST=" + CST_PIS;
                    //
                    produtos_imposto += Environment.NewLine + Environment.NewLine + "[COFINS" + Convert.ToInt32(drItems["id_item"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string CST_COFINS = null;
                    CST_COFINS = "01";
                    produtos_imposto += Environment.NewLine + "CST=" + CST_COFINS;
                    //
                    base_calculo_icms += Convert.ToDecimal(drItems["valor_base_calculo"]);
                    //
                    base_calculo_icms_st += Convert.ToDecimal(drItems["valor_base_calculo_st"]);
                    //
                    produtos_imposto += Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                throw new InvalidOperationException("O DFe não possui Produtos.");
            }
            //
            //TOTAL
            //
            string vBC = null;
            //
            string vICMS = null;
            //
            //string vBCST = null;
            //
            //string vST = null;
            //
            if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL")
            {
                vBC = "0";
                //
                vICMS = "0";
                //
                //vBCST = "0";
                //
                //vST = "0";
                /*
                vBC = base_calculo_icms.ToString();
                //
                vICMS = drDFe["icms"].ToString();
                //
                vBCST = base_calculo_icms_st.ToString();
                //
                vST = drDFe["icms_st"].ToString();
                */
            }
            else if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL - MEI")
            {
                vBC = "0";
                //
                vICMS = "0";
                //
                //vBCST = "0";
                //
                //vST = "0";
            }
            //
            string vProd_Total = null;
            vProd_Total = drDFe["total_produtos"].ToString();
            //
            string vDesc_Total = null;
            vDesc_Total = drDFe["descontos"].ToString();
            //
            string vOutro_Total = null;
            vOutro_Total = drDFe["despesas"].ToString();
            //
            string vNF = null;
            vNF = drDFe["valor_total_nf"].ToString();
            string vTotTrib_Total = null;
            vTotTrib_Total = total_aprox_trib.ToString();
            //TRANSPORTADOR
            string modFrete = null;
            modFrete = "9";
            //
            //DADOS ADICIONAIS
            //
            string infCpl = null;
            string mensagem = null;
            if (bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao) != null)
            {
                mensagem = Environment.NewLine + Environment.NewLine + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao);
            }
            infCpl = "Tributos Mun. " + Convert.ToDecimal(total_aprox_trib_mun).ToString("n2", new CultureInfo("pt-BR")) + " R$ Est. " + Convert.ToDecimal(total_aprox_trib_estadual).ToString("n2", new CultureInfo("pt-BR")) + " R$ Fed. " + Convert.ToDecimal(total_aprox_trib_federal).ToString("n2", new CultureInfo("pt-BR")) + " R$.";         
            //
            //PAGAMENTO
            //
            string pagamento = null;
            if (bllDFe.Sel_Formas_Pagamento_DFe(drDFe["id_dfe"].ToString()) != null)
            {
                decimal total_pago = 0;
                for (int i = 0; i < bllDFe.Sel_Formas_Pagamento_DFe(drDFe["id_dfe"].ToString()).Rows.Count; i++)
                {
                    DataRow drPagamento = bllDFe.Sel_Formas_Pagamento_DFe(drDFe["id_dfe"].ToString()).Rows[i];
                    //
                    pagamento += "[pag" + Convert.ToInt32(drPagamento["id_item_pagamento"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string tPag = null;
                    if (drPagamento["tipo"].ToString() == "DINHEIRO")
                    {
                        tPag = "01";
                    }
                    else if (drPagamento["tipo"].ToString() == "CARTAO DE CREDITO")
                    {
                        tPag = "03";
                    }
                    else if (drPagamento["tipo"].ToString() == "CARTAO DE DEBITO")
                    {
                        tPag = "04";
                    }
                    else if (drPagamento["tipo"].ToString() == "PIX")
                    {
                        tPag = "20";
                    }
                    else if (drPagamento["tipo"].ToString() == "CREDITO LOJA")
                    {
                        tPag = "21";
                    }
                    else if (drPagamento["tipo"].ToString() == "CHEQUE")
                    {
                        tPag = "02";
                    }
                    else if (drPagamento["tipo"].ToString() == "NOTA PROMISSORIA")
                    {
                        tPag = "05";
                    }
                    else if (drPagamento["tipo"].ToString() == "PIX (DINAMICO)")
                    {
                        tPag = "17";
                    }
                    else if (drPagamento["tipo"].ToString() == "VALE ALIMENTACAO")
                    {
                        tPag = "10";
                    }
                    else if (drPagamento["tipo"].ToString() == "VALE REFEICAO")
                    {
                        tPag = "11";
                    }
                    pagamento += Environment.NewLine + "tPag=" + tPag;
                    //
                    string vPag = null;
                    vPag = drPagamento["valor_pago"].ToString();
                    pagamento += Environment.NewLine + "vPag=" + vPag;
                    //
                    string tpIntegra = null;
                    if (tPag == "03")
                    {
                        tpIntegra = "2";
                    }
                    else if (tPag == "04")
                    {
                        tpIntegra = "2";
                    }
                    pagamento += Environment.NewLine + "tpIntegra=" + tpIntegra;
                    //
                    total_pago += Convert.ToDecimal(drPagamento["valor_pago"]);
                    string vTroco = null;
                    if (i == bllDFe.Sel_Formas_Pagamento_DFe(drDFe["id_dfe"].ToString()).Rows.Count - 1)
                    {
                        if (total_pago > Convert.ToDecimal(drDFe["valor_total_nf"]))
                        {
                            decimal troco = total_pago - Convert.ToDecimal(drDFe["valor_total_nf"]);
                            vTroco = troco.ToString();
                            pagamento += Environment.NewLine + "vTroco=" + vTroco;
                        }
                    }
                    //
                    pagamento += Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                pagamento += "[pag001]";
                //
                string tPag = null;
                tPag = "90";
                pagamento += Environment.NewLine + "tPag=" + tPag;
                //
                string vPag = null;
                vPag = "0";
                pagamento += Environment.NewLine + "vPag=" + vPag;
            }
            //
            criarini = @"[infNFe]
versao=" + versao + @"

[Identificacao]
cUF=" + cUF + @"
cNF=" + cNF + @"
natOp=" + natOp + @"
indPag=" + indPag + @"
mod=" + mod + @"
serie=" + serie + @"
nNF=" + nNF + @"
dhEmi=" + dhEmi + @"
tpNF=" + tpNF + @"
idDest=" + idDest + @"
tpImp=" + tpImp + @"
tpEmis=" + tpEmis + @"
cDV=" + cDV + @"
tpAmb=" + tpAmb + @"
finNFe=" + finNFe + @"
indFinal=" + indFinal + @"
indPres=" + indPres + @"
procEmi=0
verProc=" + verProc + @"
dhCont=" + dhCont + @"
xJust =" + xJust + @"

[Emitente]
CRT=" + CRT + @"
CNPJCPF=" + CNPJCPF + @"
xNome=" + xNome + @"
xFant=" + xFant + @"
IE=" + IE + @"
IEST=" + IEST + @"
IM=" + IM + @"
CNAE=" + CNAE + @"
xLgr=" + xLgr + @"
nro=" + nro + @"
xCpl=" + xCpl + @"
xBairro=" + xBairro + @"
cMun=" + cMun + @"
xMun=" + xMun + @"
cUF=" + cUF + @"
UF=" + UF + @"
CEP=" + CEP + @"

[autXML01]
CNPJCPF=" + CPFCNPJ_Autxml + @"

[Destinatario]
idEstrangeiro=" + idEstrangeiro + @"
CNPJCPF=" + CNPJCPF_Dest + @"
xNome=" + xNome_Dest + @"
indIEDest=" + indIEDest + @"
IE=" + IE_Dest + @"
ISUF=" + ISUF + @"
IM=" + IM_Dest + @"
Email=" + Email + @"
xLgr=" + xLgr_Dest + @"
nro=" + nro_Dest + @"
xCpl=" + xCpl_Dest + @"
xBairro=" + xBairro_Dest + @"
cMun=" + cMun_Dest + @"
xMun=" + xMun_Dest + @"
UF=" + UF_Dest + @"
CEP=" + CEP_Dest + @"
cPais=" + cPais_Dest + @"
xPais=" + xPais_Dest + @"
Fone=" + Fone_Dest + @"

" + produtos_imposto + @"[Total]
vBC=" + vBC + @"
vICMS=" + vICMS + @"
vProd=" + vProd_Total + @"
vDesc=" + vDesc_Total + @"
vOutro=" + vOutro_Total + @"
vNF =" + vNF + @"
vTotTrib= " + vTotTrib_Total + @"

[Transportador]
modFrete=" + modFrete + @"

" + pagamento + @"

[DadosAdicionais]
infCpl = " + infCpl
;
            //
            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\" + CNPJCPF))
            {
                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\" + CNPJCPF);
            }
            //
            File.WriteAllText(@"C:\Windows\Temp\Sistema SEVEN\" + CNPJCPF + @"\nfce" + nNF + ".ini", criarini, Encoding.UTF8);
            //
            return true;
        }

        public static void CriarDFeNFe(string cod_dfe, string cod_pdv_computador)
        {
            ACBrNFe ACBrNFe;
            if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
            {
                ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
            }
            else
            {
                ACBrNFe = new ACBrNFe();
            }
            //
            string[] items;
            //
            decimal base_calculo_icms = 0;
            decimal valor_icms = 0;
            decimal base_calculo_icms_st = 0;
            decimal valor_icms_st = 0;
            decimal total_aprox_trib = 0;
            decimal total_aprox_trib_mun = 0;
            decimal total_aprox_trib_estadual = 0;
            decimal total_aprox_trib_federal = 0;
            //
            DataRow drDFe = bllDFe.Sel_Nfe_Codigo(cod_dfe).Rows[0];
            //
            DataRow drMinhaEmpresa = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
            //
            string criarini = null;
            //
            string versao = null;
            //
            if (ACBrNFe.Config.VersaoDF.ToString() == "ve200")
            {
                versao = "2.00";
            }
            else if (ACBrNFe.Config.VersaoDF.ToString() == "ve300")
            {
                versao = "3.00";
            }
            else if (ACBrNFe.Config.VersaoDF.ToString() == "ve310")
            {
                versao = "3.10";
            }
            else if (ACBrNFe.Config.VersaoDF.ToString() == "ve400")
            {
                versao = "4.00";
            }
            //
            string cUF = null;
            if (drMinhaEmpresa["UF"].ToString() == "AC")
            {
                cUF = "12";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "AL")
            {
                cUF = "27";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "AP")
            {
                cUF = "16";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "AM")
            {
                cUF = "13";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "BA")
            {
                cUF = "29";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "CE")
            {
                cUF = "23";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "DF")
            {
                cUF = "53";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "ES")
            {
                cUF = "32";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "GO")
            {
                cUF = "52";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "MA")
            {
                cUF = "21";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "MT")
            {
                cUF = "51";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "MS")
            {
                cUF = "50";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "MG")
            {
                cUF = "31";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "PA")
            {
                cUF = "15";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "PB")
            {
                cUF = "25";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "PR")
            {
                cUF = "41";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "PE")
            {
                cUF = "26";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "PI")
            {
                cUF = "22";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "RJ")
            {
                cUF = "33";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "RN")
            {
                cUF = "24";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "RS")
            {
                cUF = "43";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "RO")
            {
                cUF = "11";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "RR")
            {
                cUF = "14";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "SC")
            {
                cUF = "42";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "SP")
            {
                cUF = "35";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "SE")
            {
                cUF = "28";
            }
            else if (drMinhaEmpresa["UF"].ToString() == "TO")
            {
                cUF = "17";
            }
            //
            string cNF = null;
            cNF = drDFe["codigo_aleatorio"].ToString();
            //
            string natOp = null;
            if (drDFe["descricao_cfop_natop"].ToString().Contains("—"))
            {
                items = drDFe["descricao_cfop_natop"].ToString().Split('—');
                //
                if (bllCFOP.Sel_CFOP_Codigo(items[0]) != null)
                {
                    DataRow drItems = bllCFOP.Sel_CFOP_Codigo(items[0]).Rows[0];
                    //
                    natOp = drItems["descricao"].ToString();
                }
                else
                {
                    throw new InvalidOperationException("A Natureza da Operação não foi encontrada.");
                }
            }
            else
            {
                natOp = drDFe["descricao_cfop_natop"].ToString();
            }
            //
            string indPag = null;
            /*
            if (drDFe["finalidade"].ToString() == "SAÍDA")
            {
                if (bllDFe.Sel_Formas_Pagamento_DFe(cod_dfe) != null)
                {
                    indPag = "1";
                }
                else
                {
                    indPag = "0";
                }
            }
            else
            {
                indPag = "0";
            }
            */
            //
            string mod = drDFe["modelo"].ToString();
            //
            string serie = drDFe["serie"].ToString();
            //
            string nNF = drDFe["numero_nf"].ToString();
            //          
            string dhEmi = drDFe["data_emissao"].ToString().Remove(10) + " " + drDFe["hora_emissao"].ToString();
            //
            string dhSaiEnt = null;
            if (drDFe["data_saida"].ToString() == null || drDFe["data_saida"].ToString() == "")
            {
                dhSaiEnt = "";
            }
            else
            {
                DateTime DataSaida = Convert.ToDateTime(drDFe["data_saida"].ToString());
                //
                //dhSaiEnt = DataSaida.ToString("yyyy/MM/dd").Replace('/', '-') + "T" + drDFe["hora_saida"].ToString() + "-" + utc;
                dhSaiEnt = DataSaida.ToString("dd/MM/yyyy") + " " + drDFe["hora_saida"].ToString();
            }
            //
            string tpNF = null;
            string finNFe = null;
            if (drDFe["finalidade"].ToString() == "SAIDA")
            {
                tpNF = "1";
                finNFe = "1";
            }
            else if (drDFe["finalidade"].ToString() == "ENTRADA")
            {
                tpNF = "0";
                finNFe = "1";
            }
            else if (drDFe["finalidade"].ToString() == "DEVOLUCAO")
            {
                tpNF = "1";
                finNFe = "4";
            }
            else if (drDFe["finalidade"].ToString() == "RETORNO")
            {
                tpNF = "0";
                finNFe = "4";
            }
            else if (drDFe["finalidade"].ToString() == "COMPLEMENTAR")
            {
                tpNF = "1";
                finNFe = "2";
            }
            else if (drDFe["finalidade"].ToString() == "OUTROS")
            {
                tpNF = "1";
                finNFe = "3";
            }
            //
            string idDest = null;
            if (drDFe["descricao_cfop_natop"].ToString() != null & drDFe["descricao_cfop_natop"].ToString() != "")
            {
                idDest = drDFe["descricao_cfop_natop"].ToString();
                //
                if (drDFe["descricao_cfop_natop"].ToString().Substring(0, 1) == "1")
                {
                    idDest = "1";
                }
                else if (drDFe["descricao_cfop_natop"].ToString().Substring(0, 1) == "2")
                {
                    idDest = "2";
                }
                if (drDFe["descricao_cfop_natop"].ToString().Substring(0, 1) == "5")
                {
                    idDest = "1";
                }
                else if (drDFe["descricao_cfop_natop"].ToString().Substring(0, 1) == "6")
                {
                    idDest = "2";
                }
                else if (drDFe["descricao_cfop_natop"].ToString().Substring(0, 1) == "7")
                {
                    idDest = "3";
                }
                else
                {
                    if (!drDFe["descricao_cfop_natop"].ToString().Contains("—") & drDFe["descricao_cfop_natop"].ToString() == "VENDA DE MERCADORIA")
                    {
                        idDest = "1";
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("A Natureza da Operação/CFOP Predominante não foi não foi encontrado.");
            }
            //
            string cMunFG = drMinhaEmpresa["codigo_municipio"].ToString();
            //
            string tpImp = "1";
            //
            string tpEmis = null;
            if (ACBrNFe.Config.FormaEmissao.ToString() == "teNormal")
            {
                tpEmis = "1";
            }
            else if (ACBrNFe.Config.FormaEmissao.ToString() == "teContingencia")
            {
                tpEmis = "2";
            }
            else if (ACBrNFe.Config.FormaEmissao.ToString() == "teSCAN")
            {
                tpEmis = "3";
            }
            else if (ACBrNFe.Config.FormaEmissao.ToString() == "teDPEC")
            {
                tpEmis = "4";
            }
            else if (ACBrNFe.Config.FormaEmissao.ToString() == "teFSDA")
            {
                tpEmis = "5";
            }
            else if (ACBrNFe.Config.FormaEmissao.ToString() == "teSVCAN")
            {
                tpEmis = "6";
            }
            else if (ACBrNFe.Config.FormaEmissao.ToString() == "teSVCRS")
            {
                tpEmis = "7";
            }
            else if (ACBrNFe.Config.FormaEmissao.ToString() == "teSVCSP")
            {
                tpEmis = "8";
            }
            else if (ACBrNFe.Config.FormaEmissao.ToString() == "teOffLine")
            {
                tpEmis = "9";
            }
            //
            string chaveNFeNFCe = ACBrNFe.GerarChave(Convert.ToInt32(cUF), Convert.ToInt32(cNF), Convert.ToInt32(drDFe["modelo"]), Convert.ToInt32(serie), Convert.ToInt32(nNF), Convert.ToInt32(tpEmis), Convert.ToDateTime(drDFe["data_emissao"]), drMinhaEmpresa["cpf_cnpj"].ToString());
            string chaveNFeNFCeMascarada = chaveNFeNFCe.Insert(2, "-").Insert(7, "-").Insert(10, ".").Insert(14, ".").Insert(18, "/").Insert(23, "-").Insert(26, "-").Insert(29, "-").Insert(33, "-").Insert(37, ".").Insert(41, ".").Insert(45, "-").Insert(47, "-").Insert(50, ".").Insert(54, ".").Insert(58, "-");
            //
            if (drDFe["chave_dfe"].ToString() == null || drDFe["chave_dfe"].ToString() != chaveNFeNFCeMascarada)
            {
                bllDFe.Alterar_Chave_DFe(chaveNFeNFCeMascarada, drDFe["id_dfe"].ToString());
                //
                string mes;
                if (Convert.ToDateTime(drDFe["data_emissao"]).Month < 10)
                {
                    mes = "0" + Convert.ToDateTime(drDFe["data_emissao"]).Month;
                }
                else
                {
                    mes = Convert.ToDateTime(drDFe["data_emissao"]).Month.ToString();
                }
                //
                bllDFe.Alterar_Caminho_DFe(ACBrNFe.Config.PathNFe + @"\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\NFe\" + Convert.ToDateTime(drDFe["data_emissao"]).Year + mes + @"\NFe\" + chaveNFeNFCe + "-nfe.xml", drDFe["id_dfe"].ToString());
            }
            //
            string cDV = chaveNFeNFCe.Substring(43);
            //
            string tpAmb = null;
            if (ACBrNFe.Config.Ambiente == ACBrLib.Core.DFe.TipoAmbiente.taProducao)
            {
                tpAmb = "1";
            }
            else
            {
                tpAmb = "2";
            }
            //
            string indFinal = null;
            if (Convert.ToByte(drDFe["consumidor_final"]) == 0)
            {
                indFinal = "0";
            }
            else if (Convert.ToByte(drDFe["consumidor_final"]) == 1)
            {
                indFinal = "1";
            }
            //
            //
            string indPres = null;
            if (drDFe["tipo_operacao"].ToString() == "OPERACAO PRESENCIAL")
            {
                indPres = "1";
            }
            else if (drDFe["tipo_operacao"].ToString() == "OPERACAO PELA INTERNET")
            {
                indPres = "2";
            }
            else if (drDFe["tipo_operacao"].ToString() == "OPERACAO NAO PRESENCIAL")
            {
                indPres = "9";
            }
            else
            {
                indPres = "1";
            }
            //
            string verProc = null;
            items = cod_pdv_computador.Split('/');
            verProc = "siseven " + items[0].Replace("Versão: ", "");
            //
            string dhCont = null;
            //VERIFICAR
            dhCont = "0";
            //
            string xJust = null;
            //VERIFICAR
            xJust = "";
            //
            //DOCUMENTOS REFERENCIADOS
            //
            string nfe_ref = "";
            if (bllDFe.Sel_Referencia_DFe(drDFe["id_dfe"].ToString()) != null)
            {
                for (int i = 0; i < bllDFe.Sel_Referencia_DFe(drDFe["id_dfe"].ToString()).Rows.Count; i++)
                {
                    DataRow drItems = bllDFe.Sel_Referencia_DFe(drDFe["id_dfe"].ToString()).Rows[i];
                    nfe_ref += Environment.NewLine + "[NFRef" + Convert.ToInt32(drItems["item_referencia"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    items = drItems["chave_dfe"].ToString().Split('-');
                    string Tipo = null;
                    if (items[4] == "55")
                    {
                        Tipo = "NFE";
                        nfe_ref += Environment.NewLine + "Tipo=" + Tipo;
                    }
                    //
                    string refNFe = drItems["chave_dfe"].ToString();
                    nfe_ref += Environment.NewLine + "refNFe=" + refNFe + Environment.NewLine;
                }
            }
            //
            //EMITENTE
            //
            string CRT = null;
            if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL")
            {
                CRT = "1";
            }
            else if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL - MEI")
            {
                CRT = "4";
            }
            //
            string CNPJCPF = null;
            CNPJCPF = drMinhaEmpresa["cpf_cnpj"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
            //
            string xNome = null;
            xNome = drMinhaEmpresa["nome"].ToString();
            //
            string xFant = null;
            xFant = drMinhaEmpresa["fantasia"].ToString();
            //
            string IE = null;
            IE = drMinhaEmpresa["ie_rg"].ToString().ToString().Replace(".", "").Replace("-", "");
            //
            string IEST = null;
            IEST = "";
            //
            string IM = null;
            IM = "";
            //
            string CNAE = null;
            CNAE = "";
            //
            string xLgr = null;
            xLgr = drMinhaEmpresa["endereco"].ToString();
            //
            string nro = null;
            nro = drMinhaEmpresa["numero"].ToString();
            //
            string xCpl = null;
            xCpl = drMinhaEmpresa["complemento"].ToString();
            //
            string xBairro = null;
            xBairro = drMinhaEmpresa["bairro"].ToString();
            //
            string cMun = null;
            cMun = drMinhaEmpresa["codigo_municipio"].ToString();
            //
            string xMun = null;
            xMun = drMinhaEmpresa["cidade"].ToString();
            //
            string UF = null;
            UF = drMinhaEmpresa["uf"].ToString();
            //
            string CEP = null;
            CEP = drMinhaEmpresa["cep"].ToString().Replace(".", "").Replace("-", "");
            //
            string cPais = null;
            cPais = "1058";
            //
            string xPais = null;
            xPais = "BRASIL";
            //
            string Fone = null;
            if (drMinhaEmpresa["telefone"].ToString() != null)
            {
                Fone = drMinhaEmpresa["telefone"].ToString();
            }
            else
            {
                Fone = drMinhaEmpresa["celular"].ToString();
            }
            //
            //NOTA AVULSA
            //****************************
            //DESTINARIO
            string idEstrangeiro = null;
            string CNPJCPF_Dest = null;
            string xNome_Dest = null;
            string indIEDest = null;
            string IE_Dest = null;
            string ISUF = null;
            string IM_Dest = null;
            string Email = null;
            string xLgr_Dest = null;
            string nro_Dest = null;
            string xCpl_Dest = null;
            string xBairro_Dest = null;
            string cMun_Dest = null;
            string xMun_Dest = null;
            string UF_Dest = null;
            string CEP_Dest = null;
            string cPais_Dest = null;
            string xPais_Dest = null;
            string Fone_Dest = null;
            //
            DataRow drDestinatario;
            if (drDFe["tipo_emitente_destinatario"].ToString() == "CLIENTES")
            {
                if (bllClieCons.Sel_Cliente_Codigo(drDFe["id_emitente_destinatario"].ToString()) != null)
                {
                    drDestinatario = bllClieCons.Sel_Cliente_Codigo(drDFe["id_emitente_destinatario"].ToString()).Rows[0];
                }
                else
                {
                    throw new InvalidOperationException("O Cliente/Consumidor de código [ " + drDFe["id_emitente_destinatario"].ToString() + " ] não foi encontrado.");
                }
                //
                idEstrangeiro = "";
                //
                CNPJCPF_Dest = drDestinatario["cpf_cnpj"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
                //
                xNome_Dest = drDestinatario["nome"].ToString();
                //
                if (Convert.ToByte(drDestinatario["pessoa"]) == 1)
                {
                    if (drDestinatario["ie_rg"].ToString() == "")
                    {
                        IE_Dest = null;
                    }
                    else
                    {
                        IE_Dest = drDestinatario["ie_rg"].ToString();
                    }
                }
                else
                {
                    IE_Dest = null;
                }
                //
                ISUF = null;
                //
                Email = drDestinatario["email"].ToString();
                //
                xLgr_Dest = drDestinatario["endereco"].ToString();
                //
                nro_Dest = drDestinatario["numero"].ToString();
                //
                xCpl_Dest = drDestinatario["complemento"].ToString();
                //
                xBairro_Dest = drDestinatario["bairro"].ToString();
                //
                cMun_Dest = drDestinatario["codigo_municipio"].ToString();
                //
                xMun_Dest = drDestinatario["cidade"].ToString();
                //
                UF_Dest = drDestinatario["uf"].ToString();
                //
                CEP_Dest = drDestinatario["cep"].ToString().Replace(".", "").Replace("-", "");
                //
                cPais_Dest = "1058";
                //
                xPais_Dest = "BRASIL";
                //
                if (drDestinatario["telefone"].ToString() != null)
                {
                    Fone_Dest = drDestinatario["telefone"].ToString();
                }
                else
                {
                    Fone_Dest = drDestinatario["celular"].ToString();
                }
                //
                //NÃO CONTRIBUINTE CONSUMIDOR FINAL
                //
                if (Convert.ToByte(drDestinatario["pessoa"]) == 0)
                {
                    indFinal = "1";
                    indIEDest = "9";
                }
                else
                {
                    if (IE_Dest != null)
                    {
                        indIEDest = "1";
                    }
                    else
                    {
                        indIEDest = "2";
                    }
                }
            }
            else
            {
                if (bllFornecedor.Sel_F_Cod(drDFe["id_emitente_destinatario"].ToString()) != null)
                {
                    drDestinatario = bllFornecedor.Sel_F_Cod(drDFe["id_emitente_destinatario"].ToString()).Rows[0];
                }
                else
                {
                    throw new InvalidOperationException("O Fornecedor de código [ " + drDFe["id_emitente_destinatario"].ToString() + " ] não foi encontrado.");
                }
                //
                idEstrangeiro = "";
                //
                CNPJCPF_Dest = drDestinatario["cpf_cnpj"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
                //
                xNome_Dest = drDestinatario["nome"].ToString();
                //
                indIEDest = "9";
                //
                if (Convert.ToByte(drDestinatario["pessoa"]) == 1)
                {
                    IE_Dest = drDestinatario["ie_rg"].ToString();
                }
                else
                {
                    IE_Dest = null;
                }
                //
                ISUF = null;
                //
                Email = drDestinatario["email"].ToString();
                //
                xLgr_Dest = drDestinatario["endereco"].ToString();
                //
                nro_Dest = drDestinatario["numero"].ToString();
                //
                xCpl_Dest = drDestinatario["complemento"].ToString();
                //
                xBairro_Dest = drDestinatario["bairro"].ToString();
                //
                cMun_Dest = drDestinatario["codigo_municipio"].ToString();
                //
                xMun_Dest = drDestinatario["cidade"].ToString();
                //
                UF_Dest = drDestinatario["uf"].ToString();
                //
                CEP_Dest = drDestinatario["cep"].ToString().Replace(".", "").Replace("-", "");
                //
                cPais_Dest = "1058";
                //
                xPais_Dest = "BRASIL";
                //
                if (drDestinatario["telefone"].ToString() != null)
                {
                    Fone_Dest = drDestinatario["telefone"].ToString();
                }
                else
                {
                    Fone_Dest = drDestinatario["celular"].ToString();
                }
                //
                //NÃO CONTRIBUINTE CONSUMIDOR FINAL
                //
                if (Convert.ToByte(drDestinatario["pessoa"]) == 0)
                {
                    indFinal = "1";
                    indIEDest = "9";
                }
                else
                {
                    if (IE_Dest != null)
                    {
                        indIEDest = "1";
                    }
                    else
                    {
                        indIEDest = "2";
                    }
                }
            }
            //
            //AUTXML
            //
            string CPFCNPJ_Autxml = null;
            if (drMinhaEmpresa["cpf_cnpj_contador"].ToString() == null || drMinhaEmpresa["cpf_cnpj_contador"].ToString() == "")
            {
                CPFCNPJ_Autxml = "13937073000156";
            }
            else
            {
                CPFCNPJ_Autxml = drMinhaEmpresa["cpf_cnpj_contador"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
            }
            //
            //PRODUTOS
            //
            string produtos_imposto = "";
            if (bllDFe.Sel_Items_DFe(drDFe["id_dfe"].ToString()) != null)
            {
                for (int i = 0; i < bllDFe.Sel_Items_DFe(drDFe["id_dfe"].ToString()).Rows.Count; i++)
                {
                    DataRow drItems;
                    if (bllDFe.Sel_Items_DFe(drDFe["id_dfe"].ToString()) != null)
                    {
                        drItems = bllDFe.Sel_Items_DFe(drDFe["id_dfe"].ToString()).Rows[i];
                    }
                    else
                    {
                        throw new InvalidOperationException("O Item [ " + (i + 1) + " ] não foi encontrado.");
                    }
                    //
                    produtos_imposto += "[Produto" + Convert.ToInt32(drItems["id_item"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string cProd = null;
                    cProd = drItems["id_produto"].ToString();
                    produtos_imposto += Environment.NewLine + "cProd=" + cProd;
                    //
                    DataRow drProduto;
                    if (bllProduto.Sel_Prod_Codigo(drItems["id_produto"].ToString(), "") != null)
                    {
                        drProduto = bllProduto.Sel_Prod_Codigo(drItems["id_produto"].ToString(), "").Rows[0];
                    }
                    else
                    {
                        throw new InvalidOperationException("O Produto do item [ " + drDFe["id_dfe"].ToString() + " ] não foi encontrado.");
                    }
                    //
                    string cEAN = null;
                    cEAN = drProduto["cod_barra"].ToString();
                    produtos_imposto += Environment.NewLine + "cEAN=" + cEAN;
                    //
                    string cEANTrib = null;
                    cEANTrib = drProduto["cod_barra"].ToString();
                    produtos_imposto += Environment.NewLine + "cEANTrib=" + cEANTrib;
                    //
                    string xProd = null;
                    xProd = drItems["descricao"].ToString();
                    produtos_imposto += Environment.NewLine + "xProd=" + xProd;
                    //
                    string NCM = null;
                    NCM = drProduto["ncm"].ToString().Replace(".", "");
                    produtos_imposto += Environment.NewLine + "NCM=" + NCM;
                    //produtos_imposto += Environment.NewLine + "NCM=12345678";
                    //
                    string CEST = null;
                    CEST = drProduto["cest"].ToString().Replace(".", "");
                    produtos_imposto += Environment.NewLine + "CEST=" + CEST;
                    //
                    string EXTIPI = null;
                    if (drProduto["excecao_ncm"].ToString() != "")
                    {
                        EXTIPI = Convert.ToInt32(drProduto["excecao_ncm"]).ToString("D3", new CultureInfo("pt-BR"));
                    }
                    produtos_imposto += Environment.NewLine + "EXTIPI=" + EXTIPI;
                    //
                    string CFOP = null;
                    CFOP = drItems["cfop"].ToString();
                    produtos_imposto += Environment.NewLine + "CFOP=" + CFOP;
                    //
                    string uCom = null;
                    uCom = drItems["um"].ToString();
                    produtos_imposto += Environment.NewLine + "uCom=" + uCom;
                    //
                    string qCom = null;
                    qCom = drItems["quantidade"].ToString();
                    produtos_imposto += Environment.NewLine + "qCom=" + qCom;
                    //
                    string vUnCom = null;
                    vUnCom = drItems["valor_unitario"].ToString();
                    produtos_imposto += Environment.NewLine + "vUnCom=" + vUnCom;
                    //
                    string vProd = null;
                    vProd = drItems["total"].ToString();
                    produtos_imposto += Environment.NewLine + "vProd=" + vProd;
                    //
                    string uTrib = null;
                    uTrib = drProduto["um"].ToString();
                    produtos_imposto += Environment.NewLine + "uTrib=" + uTrib;
                    //
                    string qTrib = null;
                    qTrib = drItems["quantidade"].ToString();
                    produtos_imposto += Environment.NewLine + "qTrib=" + qTrib;
                    //
                    string vUnTrib = null;
                    vUnTrib = drItems["valor_unitario"].ToString();
                    produtos_imposto += Environment.NewLine + "vUnTrib=" + vUnTrib;
                    //
                    string vFrete = null;
                    vFrete = "0.00";
                    produtos_imposto += Environment.NewLine + "vFrete=" + vFrete;
                    //
                    string vSeg = null;
                    vSeg = "0.00";
                    produtos_imposto += Environment.NewLine + "vSeg=" + vSeg;
                    //
                    string vDesc = null;
                    vDesc = drItems["valor_desconto"].ToString();
                    produtos_imposto += Environment.NewLine + "vDesc=" + vDesc;
                    //
                    string vOutro = null;
                    vOutro = drItems["valor_acrescimo"].ToString();
                    produtos_imposto += Environment.NewLine + "vOutro=" + vOutro;
                    //
                    string indTot = null;
                    indTot = "1";
                    produtos_imposto += Environment.NewLine + "indTot=" + indTot;
                    //
                    string xPed = null;
                    xPed = "";
                    produtos_imposto += Environment.NewLine + "xPed=" + xPed;
                    //
                    string nItemPed = null;
                    nItemPed = "";
                    produtos_imposto += Environment.NewLine + "nItemPed=" + nItemPed;
                    //
                    string nFCI = null;
                    nFCI = "";
                    produtos_imposto += Environment.NewLine + "nFCI=" + nFCI;
                    //
                    string nRECOPI = null;
                    nRECOPI = "";
                    produtos_imposto += Environment.NewLine + "nRECOPI=" + nRECOPI;
                    //
                    string pDevol = null;
                    pDevol = "";
                    produtos_imposto += Environment.NewLine + "pDevol=" + pDevol;
                    //
                    string vIPIDevol = null;
                    vIPIDevol = "";
                    produtos_imposto += Environment.NewLine + "vIPIDevol=" + vIPIDevol;
                    //
                    DataRow drIBPT;
                    if (bllIBPT.Sel_IBPT_NCM(drProduto["ncm"].ToString(), drProduto["excecao_ncm"].ToString()) != null)
                    {
                        drIBPT = bllIBPT.Sel_IBPT_NCM(drProduto["ncm"].ToString(), drProduto["excecao_ncm"].ToString()).Rows[0];
                    }
                    else
                    {
                        throw new InvalidOperationException("O NCM do Produto [ " + drItems["id_produto"].ToString() + " ] não foi encontrado na tabela IBPT.");
                    }
                    //
                    decimal trib_federal = Convert.ToDecimal(bllDFe.Calculo_IBPT(drItems["valor_total"].ToString(), drIBPT["trib_federal"].ToString()));
                    //decimal trib_federal_imp = Convert.ToDecimal(bllDFe.Calculo_IBPT(drItems["valor_total"].ToString(), drIBPT["trib_federal_importado"].ToString()));
                    decimal trib_federal_imp = 0;
                    decimal trib_estadual = Convert.ToDecimal(bllDFe.Calculo_IBPT(drItems["valor_total"].ToString(), drIBPT["trib_estadual"].ToString()));
                    decimal trib_municipal = Convert.ToDecimal(bllDFe.Calculo_IBPT(drItems["valor_total"].ToString(), drIBPT["trib_municipal"].ToString()));
                    decimal total = trib_federal + trib_federal_imp + trib_estadual + trib_municipal;
                    //
                    total_aprox_trib_mun += trib_municipal;
                    //
                    total_aprox_trib_estadual += trib_estadual;
                    //
                    total_aprox_trib_federal += trib_federal;
                    //
                    total_aprox_trib += total;
                    //
                    string vTotTrib = null;
                    vTotTrib = total.ToString();
                    //
                    produtos_imposto += Environment.NewLine + "vTotTrib=" + vTotTrib;
                    //
                    string infAdProd = null;
                    infAdProd = "";
                    produtos_imposto += Environment.NewLine + "infAdProd=" + infAdProd;
                    //
                    string indEscala = null;
                    indEscala = "";
                    produtos_imposto += Environment.NewLine + "indEscala=" + indEscala;
                    //
                    string CNPJFab = null;
                    CNPJFab = "";
                    produtos_imposto += Environment.NewLine + "CNPJFab=" + CNPJFab;
                    //
                    string cBenef = null;
                    cBenef = "";
                    produtos_imposto += Environment.NewLine + "cBenef=" + cBenef;
                    //
                    //IMPOSTOS
                    //
                    produtos_imposto += Environment.NewLine + Environment.NewLine + "[ICMS" + Convert.ToInt32(drItems["id_item"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string CSOSN = null;
                    CSOSN = drItems["csosn"].ToString();
                    produtos_imposto += Environment.NewLine + "CSOSN=" + CSOSN;
                    //
                    string orig = null;
                    orig = drItems["cst"].ToString().Remove(1, 2);
                    produtos_imposto += Environment.NewLine + "orig=" + orig;
                    //
                    string modBC_Prod = null;
                    //
                    string vBC_Prod = null;
                    //
                    string pICMS_Prod = null;
                    //
                    string vICMS_Prod = null;
                    //
                    string pRedBC_Prod = null;
                    //
                    string modBCST_Prod = null;
                    //
                    string pMVAST_Prod = null;
                    //
                    string pRedBCST_Prod = null;
                    //
                    string vBCST_Prod = null;
                    //
                    string pICMSST_Prod = null;
                    //
                    string vICMSST_Prod = null;
                    //
                    //string pCredSN_Prod = null;
                    //
                    //string vCredICMSSN = null;
                    //
                    if (CSOSN == "102")
                    {
                        vBC_Prod = "0";
                        //
                        pICMS_Prod = "0";
                        //
                        vICMS_Prod = "0";
                    }
                    else if (CSOSN == "900")
                    {
                        modBC_Prod = "0";
                        //
                        vBC_Prod = drItems["valor_base_calculo"].ToString();
                        //
                        pRedBC_Prod = drItems["reducao_bc"].ToString();
                        //
                        pICMS_Prod = drItems["aliq_icms"].ToString();
                        //
                        vICMS_Prod = drItems["valor_icms"].ToString();
                        //
                        modBCST_Prod = "0";
                        //
                        pMVAST_Prod = drItems["mva"].ToString();
                        //
                        pRedBCST_Prod = "0";
                        //
                        vBCST_Prod = drItems["valor_base_calculo_st"].ToString();
                        //
                        pICMSST_Prod = drItems["aliq_icms_st"].ToString();
                        //
                        vICMSST_Prod = drItems["valor_icms_st"].ToString();
                        //
                        base_calculo_icms += Convert.ToDecimal(drItems["valor_base_calculo"]);
                        //
                        base_calculo_icms_st += Convert.ToDecimal(drItems["valor_base_calculo_st"]);
                        //
                        valor_icms += Convert.ToDecimal(drItems["valor_icms"]);
                        //
                        valor_icms_st += Convert.ToDecimal(drItems["valor_icms_st"]);
                    }
                    else
                    {
                        vBC_Prod = "0";
                        //
                        pICMS_Prod = "0";
                        //
                        vICMS_Prod = "0";
                    }
                    //
                    produtos_imposto += Environment.NewLine + "modBC=" + modBC_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "vBC=" + vBC_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "pRedBC=" + pRedBC_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "pICMS=" + pICMS_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "vICMS=" + vICMS_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "modBCST=" + modBCST_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "pMVAST=" + pMVAST_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "pRedBCST=" + pRedBCST_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "vBCST=" + vBCST_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "pICMSST=" + pICMSST_Prod;
                    //
                    produtos_imposto += Environment.NewLine + "vICMSST=" + vICMSST_Prod;
                    //
                    produtos_imposto += Environment.NewLine + Environment.NewLine + "[IPI" + Convert.ToInt32(drItems["id_item"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string CST_IPI = null;
                    CST_IPI = "99";
                    produtos_imposto += Environment.NewLine + "CST=" + CST_IPI;
                    //
                    string cEnq = null;
                    cEnq = "999";
                    produtos_imposto += Environment.NewLine + "cEnq=" + cEnq;
                    //
                    produtos_imposto += Environment.NewLine + Environment.NewLine + "[PIS" + Convert.ToInt32(drItems["id_item"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string CST_PIS = null;
                    CST_PIS = "99";
                    produtos_imposto += Environment.NewLine + "CST=" + CST_PIS;
                    //
                    produtos_imposto += Environment.NewLine + Environment.NewLine + "[COFINS" + Convert.ToInt32(drItems["id_item"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string CST_COFINS = null;
                    CST_COFINS = "99";
                    produtos_imposto += Environment.NewLine + "CST=" + CST_COFINS;
                    //
                    produtos_imposto += Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                throw new InvalidOperationException("O DFe não possui Produtos.");
            }
            //
            //TOTAL
            //
            string vBC = null;
            //
            string vICMS = null;
            //
            string vBCST = null;
            //
            string vST = null;
            //
            vBC = base_calculo_icms.ToString();
            //
            vICMS = valor_icms.ToString();
            //
            vBCST = base_calculo_icms_st.ToString();
            //
            vST = valor_icms_st.ToString();
            //
            string vProd_Total = null;
            vProd_Total = drDFe["total_produtos"].ToString();
            //
            string vDesc_Total = null;
            vDesc_Total = drDFe["descontos"].ToString();
            //
            string vOutro_Total = null;
            vOutro_Total = drDFe["despesas"].ToString();
            //
            string vNF = null;
            vNF = drDFe["valor_total_nf"].ToString();
            //
            string vTotTrib_Total = null;
            vTotTrib_Total = total_aprox_trib.ToString();
            //
            //TRANSPORTADOR
            //
            //string modFrete = null;
            //
            //PAGAMENTO
            //
            string pagamento = null;
            if (bllDFe.Sel_Formas_Pagamento_DFe(drDFe["id_dfe"].ToString()) != null)
            {
                decimal total_pago = 0;
                for (int i = 0; i < bllDFe.Sel_Formas_Pagamento_DFe(drDFe["id_dfe"].ToString()).Rows.Count; i++)
                {
                    DataRow drPagamento = bllDFe.Sel_Formas_Pagamento_DFe(drDFe["id_dfe"].ToString()).Rows[i];
                    //
                    pagamento += "[pag" + Convert.ToInt32(drPagamento["id_item_pagamento"]).ToString("D3", new CultureInfo("pt-BR")) + "]";
                    //
                    string tPag = null;
                    if (drPagamento["tipo"].ToString() == "DINHEIRO")
                    {
                        tPag = "01";
                    }
                    else if (drPagamento["tipo"].ToString() == "CARTAO DE CREDITO")
                    {
                        tPag = "03";
                    }
                    else if (drPagamento["tipo"].ToString() == "CARTAO DE DEBITO")
                    {
                        tPag = "04";
                    }
                    else if (drPagamento["tipo"].ToString() == "PIX")
                    {
                        tPag = "20";
                    }
                    else if (drPagamento["tipo"].ToString() == "CREDITO LOJA")
                    {
                        tPag = "21";
                    }
                    else if (drPagamento["tipo"].ToString() == "CHEQUE")
                    {
                        tPag = "02";
                    }
                    else if (drPagamento["tipo"].ToString() == "NOTA PROMISSORIA")
                    {
                        tPag = "05";
                    }
                    else if (drPagamento["tipo"].ToString() == "PIX (DINAMICO)")
                    {
                        tPag = "17";
                    }
                    else if (drPagamento["tipo"].ToString() == "VALE ALIMENTACAO")
                    {
                        tPag = "10";
                    }
                    else if (drPagamento["tipo"].ToString() == "VALE REFEICAO")
                    {
                        tPag = "11";
                    }
                    pagamento += Environment.NewLine + "tPag=" + tPag;
                    //
                    string vPag = null;
                    vPag = drPagamento["valor_pago"].ToString();
                    pagamento += Environment.NewLine + "vPag=" + vPag;
                    //
                    string tpIntegra = null;
                    if (tPag == "03")
                    {
                        tpIntegra = "2";
                    }
                    else if (tPag == "04")
                    {
                        tpIntegra = "2";
                    }
                    pagamento += Environment.NewLine + "tpIntegra=" + tpIntegra;
                    //
                    total_pago += Convert.ToDecimal(drPagamento["valor_pago"]);
                    string vTroco = null;
                    if (i == bllDFe.Sel_Formas_Pagamento_DFe(drDFe["id_dfe"].ToString()).Rows.Count - 1)
                    {
                        if (total_pago > Convert.ToDecimal(drDFe["valor_total_nf"]))
                        {
                            decimal troco = total_pago - Convert.ToDecimal(drDFe["valor_total_nf"]);
                            vTroco = troco.ToString();
                            pagamento += Environment.NewLine + "vTroco=" + vTroco;
                        }
                    }
                    //
                    pagamento += Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                pagamento += "[pag001]";
                //
                string tPag = null;
                tPag = "90";
                pagamento += Environment.NewLine + "tPag=" + tPag;
                //
                string vPag = null;
                vPag = "0";
                pagamento += Environment.NewLine + "vPag=" + vPag;
            }
            //
            string infCpl = null;
            infCpl = drDFe["observacao"].ToString() + " ";
            //
            string traco = null;
            if (drDFe["observacao"].ToString() != "")
            {
                traco = "-";
            }
            //
            string tributos = null;
            if (drDFe["finalidade"].ToString() == "SAIDA")
            {
                tributos = "Tributos Totais Incidentes(Lei Federal 12.741/12) Mun. " + Convert.ToDecimal(total_aprox_trib_mun).ToString("n2", new CultureInfo("pt-BR")) + " R$ Est. " + Convert.ToDecimal(total_aprox_trib_estadual).ToString("n2", new CultureInfo("pt-BR")) + " R$ Fed. " + Convert.ToDecimal(total_aprox_trib_federal).ToString("n2", new CultureInfo("pt-BR")) + " R$.";
            }
            //
            infCpl = infCpl + traco + tributos + " DOCUMENTO EMITIDO POR ME OU EPP OPTANTE PELO SIMPLES NACIONAL. ESTABELECIMENTO IMPEDIDO DE RECOLHER O ICMS/ISS PELO SIMPLES, NOS TERMOS DO § 1º DO ART. 20 DA LC 123/2006";
            //
            criarini = @"[infNFe]
versao=" + versao + @"

[Identificacao]
cUF=" + cUF + @"
cNF=" + cNF + @"
natOp=" + natOp + @"
indPag=" + indPag + @"
mod=" + mod + @"
serie=" + serie + @"
nNF=" + nNF + @"
dhEmi=" + dhEmi + @"
dhSaiEnt=" + dhSaiEnt + @"
tpNF=" + tpNF + @"
idDest=" + idDest + @"
cMunFG=" + cMunFG + @"
tpImp=" + tpImp + @"
tpEmis=" + tpEmis + @"
cDV=" + cDV + @"
tpAmb=" + tpAmb + @"
finNFe=" + finNFe + @"
indFinal=" + indFinal + @"
indPres=" + indPres + @"
procEmi=0
verProc=" + verProc + @"
dhCont=" + dhCont + @"
xJust=" + xJust + @"
" + nfe_ref + @"
[Emitente]
CRT=" + CRT + @"
CNPJCPF=" + CNPJCPF + @"
xNome=" + xNome + @"
xFant=" + xFant + @"
IE=" + IE + @"
IEST=" + IEST + @"
IM=" + IM + @"
CNAE=" + CNAE + @"
xLgr=" + xLgr + @"
nro=" + nro + @"
xCpl=" + xCpl + @"
xBairro=" + xBairro + @"
cMun=" + cMun + @"
xMun=" + xMun + @"
cUF=" + cUF + @"
UF=" + UF + @"
CEP=" + CEP + @"
cPais=" + cPais + @"
xPais=" + xPais + @"

[autXML01]
CNPJCPF=" + CPFCNPJ_Autxml + @"

[Destinatario]
idEstrangeiro=" + idEstrangeiro + @"
CNPJCPF=" + CNPJCPF_Dest + @"
xNome=" + xNome_Dest + @"
indIEDest=" + indIEDest + @"
IE=" + IE_Dest + @"
ISUF=" + ISUF + @"
IM=" + IM_Dest + @"
Email=" + Email + @"
xLgr=" + xLgr_Dest + @"
nro=" + nro_Dest + @"
xCpl=" + xCpl_Dest + @"
xBairro=" + xBairro_Dest + @"
cMun=" + cMun_Dest + @"
xMun=" + xMun_Dest + @"
UF=" + UF_Dest + @"
CEP=" + CEP_Dest + @"
cPais=" + cPais_Dest + @"
xPais=" + xPais_Dest + @"
Fone=" + Fone_Dest + @"

" + produtos_imposto + @"[Total]
vBC=" + vBC + @"
vICMS=" + vICMS + @"
vBCST=" + vBCST + @"
vST=" + vST + @"
vProd=" + vProd_Total + @"
vDesc=" + vDesc_Total + @"
vOutro=" + vOutro_Total + @"
vNF =" + vNF + @"
vTotTrib=" + vTotTrib_Total + @"

" + pagamento + @"

[DadosAdicionais]
infCpl=" + infCpl
;
            //
            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\" + CNPJCPF))
            {
                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\" + CNPJCPF);
            }
            //
            File.WriteAllText(@"C:\Windows\Temp\Sistema SEVEN\" + CNPJCPF + @"\nfe" + nNF + ".ini", criarini, Encoding.UTF8);
        }

        public static DataTable Sel_Forma_Pagamento_DFe()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Forma_Pagamento_DFe();
            }
        }

        public static void Salvar_Pagamento_DFe(string cod_item_pagamento, string forma_pagamento, string valor_pagamento, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_DFe Pgto = new Pagamento_DFe())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items = forma_pagamento.Split('—');
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
                    Pgto.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    //
                    //
                    con.Salvar_Pagamento_DFe(Pgto);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Formas_Pagamento_DFe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_DFe Pgto = new Pagamento_DFe())
                {
                    Pgto.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Formas_Pagamento_DFe(Pgto);
                }
            }
        }


        public static void Salvar_Forma_Pagamento_DFe_Temp(string item, string forma_pagamento, string valor_pagamento, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Pgto_Temp Pgto = new Item_DFe_Pgto_Temp())
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
                    Pgto.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Salvar_Forma_Pagamento_DFe_Temp(Pgto);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Item_DFe_Pgto_Todas_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Pgto_Temp Pgto = new Item_DFe_Pgto_Temp())
                {
                    Pgto.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Item_DFe_Pgto_Todas_Temp(Pgto);
                }
            }
        }

        public static DataTable Sel_Item_DFe_Pgto_Todas(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_DFe Pgto = new Pagamento_DFe())
                {
                    Pgto.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    //
                    return con.Sel_Item_DFe_Pgto_Todas(Pgto);
                }
            }
        }

        
        public static void Excluir_Item_Pgto_DFe(string cod_pagamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_DFe Pgto = new Pagamento_DFe())
                {
                    Pgto.Codigo = Convert.ToInt16(cod_pagamento);
                    //
                    con.Excluir_Item_Pgto_DFe(Pgto);
                }
            }
        }
        

        public static void Excluir_Item_Pgto_DFe_Temp(string cod_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Pgto_Temp Pgto = new Item_DFe_Pgto_Temp())
                {
                    Pgto.Codigo = Convert.ToInt16(cod_item);
                    con.Excluir_Item_Pgto_DFe_Temp(Pgto);
                }
            }
        }

        public static void Excluir_Item_DFe_Pgto_Atual(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Pgto_Temp Pgto = new Item_DFe_Pgto_Temp())
                {
                    Pgto.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Item_DFe_Pgto_Atual(Pgto);
                }
            }
        }

        public static void Atualizar_Item_Dt_Pgto_DFe(int item_atual, int total_item)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_DFe Pgto = new Pagamento_DFe())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Pgto.Cod_Item_Pagamento = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dt_Pgto_DFe(Pgto, item.ToString());
                    }
                }
            }
        }

        public static void Atualizar_Item_Dt_Pgto_DFe_Temp(int item_atual, int total_item, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Pgto_Temp Pgto = new Item_DFe_Pgto_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Pgto.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        Pgto.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                        con.Atualizar_Item_Dt_Pgto_DFe_Temp(Pgto, item.ToString());
                    }
                }
            }
        }

        public static void Atualizar_Item_Dt_Referencia_DFe_Temp(int item_atual, int total_item, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ReferenciaDFe_Temp Ref = new ReferenciaDFe_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Ref.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        Ref.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                        con.Atualizar_Item_Dt_Referencia_DFe_Temp(Ref, item.ToString());
                    }
                }
            }
        }

        public static void Vincular_Venda_DFe(string cod_venda, string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE DFe = new DFE())
                {
                    DFe.Cod_Venda = Convert.ToInt32(cod_venda);
                    //
                    DFe.Codigo = Convert.ToInt32(codigo);
                    //
                    con.Vincular_Venda_DFe(DFe);
                }
            }
        }


        public static void Atualizar_Item_Dt_Referencia_DFe(int item_atual, int total_item, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ReferenciaDFe Ref = new ReferenciaDFe())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Ref.Codigo = Convert.ToInt16(i);
                        Ref.Cod_DFe = Convert.ToInt32(cod_dfe);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dt_Referencia_DFe(Ref, item.ToString());
                    }
                }
            }
        }

        public static bool Sel_C_DFe_Codigo_Num_Emit_Serie(string numero, string emitente, string serie, string modelo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    if (modelo == "MODELO 55 (NFe)")
                    {
                        Nfe.Modelo = "55";
                    }
                    else
                    {
                        Nfe.Modelo = "65";
                    }
                    //
                    if (numero == null || numero == "")
                    {
                        Nfe.Numero_NF = 0;
                    }
                    else
                    {
                        Nfe.Numero_NF = Convert.ToInt32(numero);
                    }
                    //
                    if (emitente == null || emitente == "")
                    {
                        Nfe.Cod_Emitente_Destinatario = 0;
                    }
                    else
                    {
                        string[] items = emitente.Split('—');
                        Nfe.Cod_Emitente_Destinatario = Convert.ToInt32(items[0]);
                    }
                    //
                    if (serie == null || serie == "")
                    {
                        Nfe.Serie = 0;
                    }
                    else
                    {
                        Nfe.Serie = Convert.ToInt32(serie);
                    }
                    //
                    return con.Sel_C_DFe_Codigo_Num_Emit_Serie(Nfe);
                }
            }
        }

        public static bool Sel_C_DFe_Codigo_Num_Emit_Serie_Alt(string codigo, string numero, string emitente, string serie, string modelo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    if (modelo == "MODELO 55 (NFe)")
                    {
                        Nfe.Modelo = "55";
                    }
                    else
                    {
                        Nfe.Modelo = "65";
                    }
                    //
                    if (numero == null || numero == "")
                    {
                        Nfe.Numero_NF = 0;
                    }
                    else
                    {
                        Nfe.Numero_NF = Convert.ToInt32(numero);
                    }
                    //
                    if (emitente == null || emitente == "")
                    {
                        Nfe.Cod_Emitente_Destinatario = 0;
                    }
                    else
                    {
                        string[] items = emitente.Split('—');
                        Nfe.Cod_Emitente_Destinatario = Convert.ToInt32(items[0]);
                    }
                    //
                    if (serie == null || serie == "")
                    {
                        Nfe.Serie = 0;
                    }
                    else
                    {
                        Nfe.Serie = Convert.ToInt32(serie);
                    }
                    //
                    if (con.Sel_C_DFe_Codigo_Num_Emit_Serie_Alt(Nfe) == codigo)
                    {
                        return false;
                    }
                    else if (con.Sel_C_DFe_Codigo_Num_Emit_Serie_Alt(Nfe) == null)
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

        public static bool Sel_C_DFe_Chave_Alt(string codigo, string cpf_cnpj)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Chave_DFe = cpf_cnpj;
                    if (con.Sel_C_DFe_Chave_Alt(Nfe) == codigo)
                    {
                        return false;
                    }
                    else if (con.Sel_C_DFe_Chave_Alt(Nfe) == null)
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

        public static DataTable Sel_Dfe_Data_Emissao(string data, string data1, string emissao)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                string SqlEmissao;
                SqlData = "WHERE data_emissao BETWEEN '" + data.Replace('/', '.') + " 00:00:00' AND '" + data1.Replace('/', '.') + " 23:59:59'";
                if (emissao != "")
                {
                    SqlEmissao = " AND emissao='" + emissao + "'";
                }
                else
                {
                    SqlEmissao = "";
                }
                //
                return con.Sel_Dfe_Data_Emissao(SqlData, SqlEmissao);
            }
        }

        public static DataTable Sel_Dfe_Data_Cadastro(string data, string data1, string emissao)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                string SqlEmissao;
                SqlData = "WHERE data_emissao BETWEEN '" + data.Replace('/', '.') + " 00:00:00' AND '" + data1.Replace('/', '.') + " 23:59:59'";
                if (emissao != "")
                {
                    SqlEmissao = " AND emissao='" + emissao + "'";
                }
                else
                {
                    SqlEmissao = "";
                }
                //
                return con.Sel_Dfe_Data_Cadastro(SqlData, SqlEmissao);
            }
        }

        public static DataTable Sel_Nfe_Cod(string pesquisar, string emissao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Pesquisar = pesquisar;
                    //
                    string SqlEmissao;
                    if (emissao != "")
                    {
                        SqlEmissao = " AND emissao='" + emissao + "'";
                    }
                    else
                    {
                        SqlEmissao = "";
                    }
                    //
                    return con.Sel_Nfe_Cod(Nfe, SqlEmissao);
                }
            }
        }

        public static DataTable Sel_Nfe_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Pesquisar = pesquisar;
                    return con.Sel_Nfe_Codigo(Nfe);
                }
            }
        }

        public static DataTable Sel_Nfe_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Pesquisar = pesquisar;
                    return con.Sel_Nfe_Chave(Nfe);
                }
            }
        }

        public static DataTable Sel_Nfe_Numero_NF(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Pesquisar = pesquisar;
                    return con.Sel_Nfe_Numero_NF(Nfe);
                }
            }
        }

        public static DataTable Sel_Nfe_Numero(string pesquisar, string emissao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Pesquisar = pesquisar;
                    //
                    string SqlEmissao;
                    if (emissao != "")
                    {
                        SqlEmissao = " AND emissao='" + emissao + "'";
                    }
                    else
                    {
                        SqlEmissao = "";
                    }
                    //
                    return con.Sel_Nfe_Numero(Nfe, SqlEmissao);
                }
            }
        }

        public static void Alterar_Estoque_Produto_NFe(string codigo, string quantidade, bool adicionar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (adicionar == false)
                    {
                        if (quantidade.Contains("."))
                        {
                            Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) - Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) - Convert.ToDecimal(quantidade.Replace(",", "."));
                        }
                    }
                    else
                    {
                        if (quantidade.Contains("."))
                        {
                            Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) + Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) + Convert.ToDecimal(quantidade.Replace(",", "."));
                        }
                    }
                    //
                    con.Alterar_Estoque_Produto_NFe(Prod);
                }
                //
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
        }


        public static DataTable Sel_CFOP_Codigo_CFOP_DFe(string pesquisar, string finalidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    if (finalidade != null)
                    {
                        Cfop.Pesquisar = pesquisar;
                        //
                        Cfop.Finalidade = finalidade;
                        //
                        return con.Sel_CFOP_Codigo_CFOP_DFe_Finalidade(Cfop);
                    }
                    else
                    {
                        Cfop.Pesquisar = pesquisar;
                        //
                        return con.Sel_CFOP_Codigo_CFOP_DFe(Cfop);
                    }
                }
            }
        }

        public static DataTable Sel_CFOP_Todos_DFe(string finalidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    if (finalidade != null)
                    {
                        Cfop.Finalidade = finalidade;
                        //
                        return con.Sel_CFOP_Todos_DFe_Finalidade(Cfop);
                    }
                    else
                    {
                        return con.Sel_CFOP_Todos_DFe();
                    }
                }
            }
        }

        public static DataTable Sel_CFOP_Descricao_DFe(string pesquisar, string finalidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    if (finalidade != null)
                    {
                        Cfop.Finalidade = finalidade;
                        //
                        if (pesquisar.Contains("%"))
                        {
                            Cfop.Pesquisar = pesquisar;
                            return con.Sel_CFOP_Descricao_Like_DFe_Finalidade(Cfop);
                        }
                        else
                        {
                            Cfop.Pesquisar = pesquisar;
                            return con.Sel_CFOP_Descricao_DFe_Finalidade(Cfop);
                        }
                    }
                    else
                    {
                        if (pesquisar.Contains("%"))
                        {
                            Cfop.Pesquisar = pesquisar;
                            return con.Sel_CFOP_Descricao_Like_DFe(Cfop);
                        }
                        else
                        {
                            Cfop.Pesquisar = pesquisar;
                            return con.Sel_CFOP_Descricao_DFe(Cfop);
                        }
                    }
                }
            }
        }

        public static DataTable Sel_Cfop_Dfe(string finalidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    if (finalidade != null)
                    {
                        Cfop.Finalidade = finalidade;
                        //
                        return con.Sel_Cfop_Dfe_Finalidade(Cfop);
                    }
                    else
                    {
                        return con.Sel_Cfop_Dfe(Cfop);
                    }
                }
            }
        }

        public static DataTable Sel_Nfe_Todos(string emissao)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlEmissao;
                if (emissao != "")
                {
                    SqlEmissao = "WHERE emissao='" + emissao + "'";
                }
                else
                {
                    SqlEmissao = "";
                }
                //
                return con.Sel_Nfe_Todos(SqlEmissao);
            }
        }

        public static void Atualizar_Item_Dt_Item(int item_atual, int total_item)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Items = new Item_DFe())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dt_Item(Items, item.ToString());
                    }
                }
            }
        }

        public static DataTable Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Emissao_Todos(string data_ent, string data_ent1, string horario_ent, string horario_ent1, string data_saida, string data_saida1, string horario_saida, string horario_saida1, string modelo, string emissao, string emitente_destinatrio, string produto, string cfop_natureza_op, string tipo_emit_dest, string finalidade, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;
                    string SqlData_Ent;
                    string SqlData_Cadastro;
                    string SqlModelo;
                    string SqlEmissao;
                    string SqlEmitDest;
                    string SqlProduto;
                    string SqlProduto1;
                    string SqlProduto2;
                    string SqlProduto3;
                    string SqlCFOPNat;
                    string SqlFinalidade;
                    string SqlSItuacao;

                    if (emissao == "")
                    {
                        SqlEmissao = "WHERE dfe.emissao<>''";
                    }
                    else
                    {
                        SqlEmissao = "WHERE dfe.emissao='" + emissao + "'";
                    }

                    if (data_ent.Contains("_") || data_ent1.Contains("_"))
                    {
                        SqlData_Ent = "";
                    }
                    else
                    {
                        if (horario_ent.Contains("_"))
                        {
                            horario_ent = "";
                        }
                        else
                        {
                            horario_ent = " " + horario_ent;
                        }
                        //
                        if (horario_ent1.Contains("_"))
                        {
                            horario_ent1 = " 23:59:59";
                        }
                        else
                        {
                            horario_ent1 = " " + horario_ent1;
                        }
                        //
                        SqlData_Ent = " AND dfe.data_emissao BETWEEN '" + data_ent.Replace("/", ".") + horario_ent + "' AND '" + data_ent1.Replace("/", ".") + horario_ent1 + "'";
                    }
                    //
                    if (data_saida.Contains("_") || data_saida1.Contains("_"))
                    {
                        SqlData_Cadastro = "";
                    }
                    else
                    {
                        if (horario_saida.Contains("_"))
                        {
                            horario_saida = "";
                        }
                        else
                        {
                            horario_saida = " " + horario_saida;
                        }
                        //
                        if (horario_saida1.Contains("_"))
                        {
                            horario_saida1 = " 23:59:59";
                        }
                        else
                        {
                            horario_saida1 = " " + horario_saida1;
                        }
                        //
                        SqlData_Cadastro = " AND dfe.data_cadastro BETWEEN '" + data_saida.Replace("/", ".") + horario_saida + "' AND '" + data_saida1.Replace("/", ".") + horario_saida1 + "'";
                    }
                    //
                    if (modelo == "")
                    {
                        SqlModelo = "";
                    }
                    else
                    {
                        if (modelo == "MODELO 55 (NFe)")
                        {
                            modelo = "55";
                        }
                        else
                        {
                            modelo = "65";
                        }
                        SqlModelo = " AND dfe.modelo='" + modelo + "'";
                    }
                    //
                    if (tipo_emit_dest == "")
                    {
                        SqlEmitDest = "";
                    }
                    else
                    {
                        if (emitente_destinatrio == "")
                        {
                            SqlEmitDest = " AND dfe.tipo_emitente_destinatario='" + tipo_emit_dest + "'";
                        }
                        else
                        {
                            items = emitente_destinatrio.Split('—');
                            SqlEmitDest = " AND dfe.tipo_emitente_destinatario='" + tipo_emit_dest + "' AND id_emitente_destinatario='" + items[0] + "'";
                        }
                    }
                    //
                    if (produto == "")
                    {
                        SqlProduto = "(SELECT COUNT (id_produto) FROM item_dfe WHERE item_dfe.id_dfe=dfe.id_dfe) as produto";
                        SqlProduto1 = "";
                        SqlProduto2 = "";
                        SqlProduto3 = "";
                    }
                    else
                    {
                        items = produto.Split('—');
                        SqlProduto = "(SELECT FIRST 1 id_produto FROM item_dfe WHERE item_dfe.id_produto=" + items[0] + ") || '—' || (SELECT FIRST 1 descricao FROM item_dfe WHERE item_dfe.id_produto=" + items[0] + ") as produto";
                        SqlProduto1 = " AND item_dfe.id_produto=" + items[0];
                        SqlProduto2 = ", item_dfe ";
                        SqlProduto3 = " AND item_dfe.id_dfe=dfe.id_dfe";
                    }
                    //
                    if (cfop_natureza_op == "")
                    {
                        SqlCFOPNat = "";
                    }
                    else
                    {
                        items = cfop_natureza_op.Split('—');
                        SqlCFOPNat = " AND dfe.descricao_cfop_natop='" + items[1] + "'";
                    }
                    //
                    if (finalidade == "")
                    {
                        SqlFinalidade = "";
                    }
                    else
                    {
                        SqlFinalidade = " AND dfe.finalidade='" + finalidade + "'";
                    }
                    //
                    if (situacao == "")
                    {
                        SqlSItuacao = "";
                    }
                    else
                    {
                        SqlSItuacao = " AND dfe.situacao='" + situacao + "'";
                    }
                    //
                    return con.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Emissao_Todos(SqlData_Ent, SqlData_Cadastro, SqlModelo, SqlEmissao, SqlEmitDest, SqlProduto, SqlProduto1, SqlCFOPNat, SqlFinalidade, SqlProduto2, SqlProduto3, SqlSItuacao);
                }
            }
        }

        public static DataTable Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Numero_NF(string data_ent, string data_ent1, string horario_ent, string horario_ent1, string data_saida, string data_saida1, string horario_saida, string horario_saida1, string modelo, string emissao, string emitente_destinatrio, string produto, string cfop_natureza_op, string tipo_emit_dest, string finalidade, string situacao, string numero_nf)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;
                    string SqlData_Ent;
                    string SqlData_Cadastro;
                    string SqlModelo;
                    string SqlNumeroNF;
                    string SqlEmissao;
                    string SqlEmitDest;
                    string SqlProduto;
                    string SqlProduto1;
                    string SqlProduto2;
                    string SqlProduto3;
                    string SqlCFOPNat;
                    string SqlFinalidade;
                    string SqlSItuacao;
                    //
                    SqlNumeroNF = "WHERE dfe.numero_nf=" + numero_nf;
                    //
                    if (emissao == "")
                    {
                        SqlEmissao = "";
                    }
                    else
                    {
                        SqlEmissao = " AND dfe.emissao='" + emissao + "'";
                    }
                    //
                    if (data_ent.Contains("_") || data_ent1.Contains("_"))
                    {
                        SqlData_Ent = "";
                    }
                    else
                    {
                        if (horario_ent.Contains("_"))
                        {
                            horario_ent = "";
                        }
                        else
                        {
                            horario_ent = " " + horario_ent;
                        }
                        //
                        if (horario_ent1.Contains("_"))
                        {
                            horario_ent1 = " 23:59:59";
                        }
                        else
                        {
                            horario_ent1 = " " + horario_ent1;
                        }
                        //
                        SqlData_Ent = " AND dfe.data_emissao BETWEEN '" + data_ent.Replace("/", ".") + horario_ent + "' AND '" + data_ent1.Replace("/", ".") + horario_ent1 + "'";
                    }
                    //
                    if (data_saida.Contains("_") || data_saida1.Contains("_"))
                    {
                        SqlData_Cadastro = "";
                    }
                    else
                    {
                        if (horario_saida.Contains("_"))
                        {
                            horario_saida = "";
                        }
                        else
                        {
                            horario_saida = " " + horario_saida;
                        }
                        //
                        if (horario_saida1.Contains("_"))
                        {
                            horario_saida1 = " 23:59:59";
                        }
                        else
                        {
                            horario_saida1 = " " + horario_saida1;
                        }
                        //
                        SqlData_Cadastro = " AND dfe.data_cadastro BETWEEN '" + data_saida.Replace("/", ".") + horario_saida + "' AND '" + data_saida1.Replace("/", ".") + horario_saida1 + "'";
                    }
                    //
                    if (modelo == "")
                    {
                        SqlModelo = "";
                    }
                    else
                    {
                        if (modelo == "MODELO 55 (NFe)")
                        {
                            modelo = "55";
                        }
                        else
                        {
                            modelo = "65";
                        }
                        SqlModelo = " AND dfe.modelo='" + modelo + "'";
                    }
                    //
                    if (tipo_emit_dest == "")
                    {
                        SqlEmitDest = "";
                    }
                    else
                    {
                        if (emitente_destinatrio == "")
                        {
                            SqlEmitDest = " AND dfe.tipo_emitente_destinatario='" + tipo_emit_dest + "'";
                        }
                        else
                        {
                            items = emitente_destinatrio.Split('—');
                            SqlEmitDest = " AND dfe.tipo_emitente_destinatario='" + tipo_emit_dest + "' AND id_emitente_destinatario='" + items[0] + "'";
                        }
                    }
                    //
                    if (produto == "")
                    {
                        SqlProduto = "(SELECT COUNT (id_produto) FROM item_dfe WHERE item_dfe.id_dfe=dfe.id_dfe) as produto";
                        SqlProduto1 = "";
                        SqlProduto2 = "";
                        SqlProduto3 = "";
                    }
                    else
                    {
                        items = produto.Split('—');
                        SqlProduto = "(SELECT FIRST 1 id_produto FROM item_dfe WHERE item_dfe.id_produto=" + items[0] + ") || '—' || (SELECT FIRST 1 descricao FROM item_dfe WHERE item_dfe.id_produto=" + items[0] + ") as produto";
                        SqlProduto1 = " AND item_dfe.id_produto=" + items[0];
                        SqlProduto2 = ", item_dfe ";
                        SqlProduto3 = " AND item_dfe.id_dfe=dfe.id_dfe";
                    }
                    //
                    if (cfop_natureza_op == "")
                    {
                        SqlCFOPNat = "";
                    }
                    else
                    {
                        items = cfop_natureza_op.Split('—');
                        SqlCFOPNat = " AND dfe.descricao_cfop_natop='" + items[1] + "'";
                    }
                    //
                    if (finalidade == "")
                    {
                        SqlFinalidade = "";
                    }
                    else
                    {
                        SqlFinalidade = " AND dfe.finalidade='" + finalidade + "'";
                    }
                    //
                    if (situacao == "")
                    {
                        SqlSItuacao = "";
                    }
                    else
                    {
                        SqlSItuacao = " AND dfe.situacao='" + situacao + "'";
                    }
                    //
                    return con.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Numero_NF(SqlData_Ent, SqlData_Cadastro, SqlModelo, SqlNumeroNF, SqlEmitDest, SqlProduto, SqlProduto1, SqlCFOPNat, SqlFinalidade, SqlProduto2, SqlProduto3, SqlSItuacao, SqlEmissao);
                }
            }
        }

        public static DataTable Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda(string data_ent, string data_ent1, string horario_ent, string horario_ent1, string data_saida, string data_saida1, string horario_saida, string horario_saida1, string modelo, string emissao, string emitente_destinatrio, string produto, string cfop_natureza_op, string tipo_emit_dest, string finalidade, string situacao, string cod_venda)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;
                    string SqlData_Ent;
                    string SqlData_Cadastro;
                    string SqlModelo;
                    string SqlCodVenda;
                    string SqlEmissao;
                    string SqlEmitDest;
                    string SqlProduto;
                    string SqlProduto1;
                    string SqlProduto2;
                    string SqlProduto3;
                    string SqlCFOPNat;
                    string SqlFinalidade;
                    string SqlSItuacao;
                    //
                    SqlCodVenda = "WHERE dfe.id_venda=" + cod_venda;
                    //
                    if (emissao == "" || emissao == null)
                    {
                        SqlEmissao = "";
                    }
                    else
                    {
                        SqlEmissao = " AND dfe.emissao='" + emissao + "'";
                    }
                    //
                    if (data_ent.Contains("_") || data_ent1.Contains("_"))
                    {
                        SqlData_Ent = "";
                    }
                    else
                    {
                        if (horario_ent.Contains("_"))
                        {
                            horario_ent = "";
                        }
                        else
                        {
                            horario_ent = " " + horario_ent;
                        }
                        //
                        if (horario_ent1.Contains("_"))
                        {
                            horario_ent1 = " 23:59:59";
                        }
                        else
                        {
                            horario_ent1 = " " + horario_ent1;
                        }
                        //
                        SqlData_Ent = " AND dfe.data_emissao BETWEEN '" + data_ent.Replace("/", ".") + horario_ent + "' AND '" + data_ent1.Replace("/", ".") + horario_ent1 + "'";
                    }
                    //
                    if (data_saida.Contains("_") || data_saida1.Contains("_"))
                    {
                        SqlData_Cadastro = "";
                    }
                    else
                    {
                        if (horario_saida.Contains("_"))
                        {
                            horario_saida = "";
                        }
                        else
                        {
                            horario_saida = " " + horario_saida;
                        }
                        //
                        if (horario_saida1.Contains("_"))
                        {
                            horario_saida1 = " 23:59:59";
                        }
                        else
                        {
                            horario_saida1 = " " + horario_saida1;
                        }
                        //
                        SqlData_Cadastro = " AND dfe.data_cadastro BETWEEN '" + data_saida.Replace("/", ".") + horario_saida + "' AND '" + data_saida1.Replace("/", ".") + horario_saida1 + "'";
                    }
                    //
                    if (modelo == "" || modelo == null)
                    {
                        SqlModelo = "";
                    }
                    else
                    {
                        if (modelo == "MODELO 55 (NFe)")
                        {
                            modelo = "55";
                        }
                        else
                        {
                            modelo = "65";
                        }
                        SqlModelo = " AND dfe.modelo='" + modelo + "'";
                    }
                    //
                    if (tipo_emit_dest == "" || tipo_emit_dest == null)
                    {
                        SqlEmitDest = "";
                    }
                    else
                    {
                        if (emitente_destinatrio == "")
                        {
                            SqlEmitDest = " AND dfe.tipo_emitente_destinatario='" + tipo_emit_dest + "'";
                        }
                        else
                        {
                            items = emitente_destinatrio.Split('—');
                            SqlEmitDest = " AND dfe.tipo_emitente_destinatario='" + tipo_emit_dest + "' AND id_emitente_destinatario='" + items[0] + "'";
                        }
                    }
                    //
                    if (produto == "" || produto == null)
                    {
                        SqlProduto = "(SELECT COUNT (id_produto) FROM item_dfe WHERE item_dfe.id_dfe=dfe.id_dfe) as produto";
                        SqlProduto1 = "";
                        SqlProduto2 = "";
                        SqlProduto3 = "";
                    }
                    else
                    {
                        items = produto.Split('—');
                        SqlProduto = "(SELECT FIRST 1 id_produto FROM item_dfe WHERE item_dfe.id_produto=" + items[0] + ") || '—' || (SELECT FIRST 1 descricao FROM item_dfe WHERE item_dfe.id_produto=" + items[0] + ") as produto";
                        SqlProduto1 = " AND item_dfe.id_produto=" + items[0];
                        SqlProduto2 = ", item_dfe ";
                        SqlProduto3 = " AND item_dfe.id_dfe=dfe.id_dfe";
                    }
                    //
                    if (cfop_natureza_op == "" || cfop_natureza_op == null)
                    {
                        SqlCFOPNat = "";
                    }
                    else
                    {
                        items = cfop_natureza_op.Split('—');
                        SqlCFOPNat = " AND dfe.descricao_cfop_natop='" + items[1] + "'";
                    }
                    //
                    if (finalidade == "" || finalidade == null)
                    {
                        SqlFinalidade = "";
                    }
                    else
                    {
                        SqlFinalidade = " AND dfe.finalidade='" + finalidade + "'";
                    }
                    //
                    if (situacao == "" || situacao == null)
                    {
                        SqlSItuacao = "";
                    }
                    else
                    {
                        SqlSItuacao = " AND dfe.situacao='" + situacao + "'";
                    }
                    //
                    return con.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda(SqlData_Ent, SqlData_Cadastro, SqlModelo, SqlCodVenda, SqlEmitDest, SqlProduto, SqlProduto1, SqlCFOPNat, SqlFinalidade, SqlProduto2, SqlProduto3, SqlSItuacao, SqlEmissao);
                }
            }
        }

        public static DataTable Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Devolucao(string data_ent, string data_ent1, string horario_ent, string horario_ent1, string data_saida, string data_saida1, string horario_saida, string horario_saida1, string modelo, string emissao, string emitente_destinatrio, string produto, string cfop_natureza_op, string tipo_emit_dest, string finalidade, string situacao, string cod_devolucao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;
                    string SqlData_Ent;
                    string SqlData_Cadastro;
                    string SqlModelo;
                    string SqlCodDevolucao;
                    string SqlEmissao;
                    string SqlEmitDest;
                    string SqlProduto;
                    string SqlProduto1;
                    string SqlProduto2;
                    string SqlProduto3;
                    string SqlCFOPNat;
                    string SqlFinalidade;
                    string SqlSItuacao;
                    //
                    SqlCodDevolucao = "WHERE dfe.id_devolucao=" + cod_devolucao;
                    //
                    if (emissao == "")
                    {
                        SqlEmissao = "";
                    }
                    else
                    {
                        SqlEmissao = " AND dfe.emissao='" + emissao + "'";
                    }
                    //
                    if (data_ent.Contains("_") || data_ent1.Contains("_"))
                    {
                        SqlData_Ent = "";
                    }
                    else
                    {
                        if (horario_ent.Contains("_"))
                        {
                            horario_ent = "";
                        }
                        else
                        {
                            horario_ent = " " + horario_ent;
                        }
                        //
                        if (horario_ent1.Contains("_"))
                        {
                            horario_ent1 = " 23:59:59";
                        }
                        else
                        {
                            horario_ent1 = " " + horario_ent1;
                        }
                        //
                        SqlData_Ent = " AND dfe.data_emissao BETWEEN '" + data_ent.Replace("/", ".") + horario_ent + "' AND '" + data_ent1.Replace("/", ".") + horario_ent1 + "'";
                    }
                    //
                    if (data_saida.Contains("_") || data_saida1.Contains("_"))
                    {
                        SqlData_Cadastro = "";
                    }
                    else
                    {
                        if (horario_saida.Contains("_"))
                        {
                            horario_saida = "";
                        }
                        else
                        {
                            horario_saida = " " + horario_saida;
                        }
                        //
                        if (horario_saida1.Contains("_"))
                        {
                            horario_saida1 = " 23:59:59";
                        }
                        else
                        {
                            horario_saida1 = " " + horario_saida1;
                        }
                        //
                        SqlData_Cadastro = " AND dfe.data_cadastro BETWEEN '" + data_saida.Replace("/", ".") + horario_saida + "' AND '" + data_saida1.Replace("/", ".") + horario_saida1 + "'";
                    }
                    //
                    if (modelo == "")
                    {
                        SqlModelo = "";
                    }
                    else
                    {
                        if (modelo == "MODELO 55 (NFe)")
                        {
                            modelo = "55";
                        }
                        else
                        {
                            modelo = "65";
                        }
                        SqlModelo = " AND dfe.modelo='" + modelo + "'";
                    }
                    //
                    if (tipo_emit_dest == "")
                    {
                        SqlEmitDest = "";
                    }
                    else
                    {
                        if (emitente_destinatrio == "")
                        {
                            SqlEmitDest = " AND dfe.tipo_emitente_destinatario='" + tipo_emit_dest + "'";
                        }
                        else
                        {
                            items = emitente_destinatrio.Split('—');
                            SqlEmitDest = " AND dfe.tipo_emitente_destinatario='" + tipo_emit_dest + "' AND id_emitente_destinatario='" + items[0] + "'";
                        }
                    }
                    //
                    if (produto == "")
                    {
                        SqlProduto = "(SELECT COUNT (id_produto) FROM item_dfe WHERE item_dfe.id_dfe=dfe.id_dfe) as produto";
                        SqlProduto1 = "";
                        SqlProduto2 = "";
                        SqlProduto3 = "";
                    }
                    else
                    {
                        items = produto.Split('—');
                        SqlProduto = "(SELECT FIRST 1 id_produto FROM item_dfe WHERE item_dfe.id_produto=" + items[0] + ") || '—' || (SELECT FIRST 1 descricao FROM item_dfe WHERE item_dfe.id_produto=" + items[0] + ") as produto";
                        SqlProduto1 = " AND item_dfe.id_produto=" + items[0];
                        SqlProduto2 = ", item_dfe ";
                        SqlProduto3 = " AND item_dfe.id_dfe=dfe.id_dfe";
                    }
                    //
                    if (cfop_natureza_op == "")
                    {
                        SqlCFOPNat = "";
                    }
                    else
                    {
                        items = cfop_natureza_op.Split('—');
                        SqlCFOPNat = " AND dfe.descricao_cfop_natop='" + items[1] + "'";
                    }
                    //
                    if (finalidade == "")
                    {
                        SqlFinalidade = "";
                    }
                    else
                    {
                        SqlFinalidade = " AND dfe.finalidade='" + finalidade + "'";
                    }
                    //
                    if (situacao == "")
                    {
                        SqlSItuacao = "";
                    }
                    else
                    {
                        SqlSItuacao = " AND dfe.situacao='" + situacao + "'";
                    }
                    //
                    return con.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Devolucao(SqlData_Ent, SqlData_Cadastro, SqlModelo, SqlCodDevolucao, SqlEmitDest, SqlProduto, SqlProduto1, SqlCFOPNat, SqlFinalidade, SqlProduto2, SqlProduto3, SqlSItuacao, SqlEmissao);
                }
            }
        }

        public static DataTable Sel_Dfe_Menu_NFe_NFCe(string data_cad, string data_cad1, string horario_cad, string horario_cad1, string modelo, string situacao, string numero, string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlEmissao;
                string SqlDataCadastro;
                string SqlModelo;
                string SqlSituacao;
                string SqlNumero;
                string SqlCodigo;
                //
                SqlEmissao = "WHERE dfe.emissao='PRÓPRIA'";
                //
                if (data_cad.Contains("_") || data_cad1.Contains("_"))
                {
                    SqlDataCadastro= "";
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
                    SqlDataCadastro = " AND dfe.data_cadastro BETWEEN '" + data_cad.Replace("/", ".") + horario_cad + "' AND '" + data_cad1.Replace("/", ".") + horario_cad1 + "'";
                }
                //
                if (modelo == "" || modelo == null)
                {
                    SqlModelo = "";
                }
                else
                {
                    if (modelo == "MODELO 55 (NFe)")
                    {
                        modelo = "55";
                    }
                    else
                    {
                        modelo = "65";
                    }
                    SqlModelo = " AND dfe.modelo='" + modelo + "'";
                }
                //
                if (situacao == "" || situacao == null)
                {
                    SqlSituacao = "";
                }
                else
                {
                    SqlSituacao = " AND dfe.situacao='" + situacao + "'";
                }
                //
                if (numero == "" || numero == null)
                {
                    SqlNumero = "";
                }
                else
                {
                    SqlNumero = " AND dfe.numero_nf='" + numero + "'";
                }
                //
                if (codigo == "" || codigo == null)
                {
                    SqlCodigo = "";
                }
                else
                {
                    SqlCodigo = " AND dfe.id_dfe='" + codigo + "'";
                }
                //
                return con.Sel_Dfe_Menu_NFe_NFCe(SqlDataCadastro, SqlModelo, SqlEmissao, SqlSituacao, SqlNumero, SqlCodigo);
            }
        }

        public static void Salvar_Associacao_Item(string item, string produto, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Item = Convert.ToInt16(item);
                    //
                    string[] items = produto.Split('—');
                    Item.Cod_Produto = Convert.ToInt32(items[0]);
                    //
                    Item.Descricao = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Item.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    //
                    con.Salvar_Associacao_Item(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Associacao_Item(string item, string produto, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Item = Convert.ToInt16(item);
                    //
                    if (produto == null || produto == "")
                    {
                        Item.Cod_Produto = 0;
                        //
                        Item.Descricao = "null";
                    }
                    else
                    {
                        string[] items = produto.Split('—');
                        Item.Cod_Produto = Convert.ToInt32(items[0]);
                        //
                        Item.Descricao = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    Item.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    //
                    con.Alterar_Associacao_Item(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir_Associacao_Item(string item, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Item.Cod_Item = Convert.ToInt16(item);
                    //
                    Item.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    //
                    con.Excluir_Associacao_Item(Item);
                }
            }
        }

        public static void Atualizar_Item_Dt_Item_Temp(int item_atual, int total_item, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Temp Items = new Item_DFe_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                        con.Atualizar_Item_Dt_Item_Temp(Items, item.ToString());
                    }
                }
            }
        }

        public static DataTable Sel_Produto_DFe(string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlSituacao;
                if (situacao == "" || situacao == null)
                {
                    SqlSituacao = "";
                }
                else
                {
                    SqlSituacao = " AND situacao='" + situacao + "'";
                }
                //
                return con.Sel_Produto_DFe(SqlSituacao);
            }
        }




        public static DataTable Sel_Fornecedor_DFe()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Fornecedor_DFe();
            }
        }

        public static DataTable Sel_Cliente_DFe()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_DFe();
            }
        }

        public static DataTable Sel_ComboboxEmitente_Valor_A_Alterar_Forn(string cbbemitente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    string[] items = cbbemitente.Split('—');
                    NFe.Cod_Emitente_Destinatario = Convert.ToInt32(items[0]);
                    return con.Sel_ComboboxEmitente_Valor_A_Alterar_Forn(NFe);
                }
            }
        }

        public static DataTable Sel_ComboboxEmitente_Valor_A_Alterar_Clie(string cbbemitente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    string[] items = cbbemitente.Split('—');
                    NFe.Cod_Emitente_Destinatario = Convert.ToInt32(items[0]);
                    return con.Sel_ComboboxEmitente_Valor_A_Alterar_Clie(NFe);
                }
            }
        }

        public static void Salvar_icms_icms_st_base_total_trib(string codigo, string icms, string icms_st, string base_calculo_icms, string base_calculo_icms_st, string total_aprox_trib)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    NFe.Codigo = Convert.ToInt32(codigo);
                    //
                    if (icms.Contains("."))
                    {
                        NFe.ICMS = Convert.ToDecimal(icms.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        NFe.ICMS = Convert.ToDecimal(icms.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (icms_st.Contains("."))
                    {
                        NFe.ICMS_ST = Convert.ToDecimal(icms_st.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        NFe.ICMS_ST = Convert.ToDecimal(icms_st.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (base_calculo_icms.Contains("."))
                    {
                        NFe.Base_Calculo_ICMS = Convert.ToDecimal(base_calculo_icms.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        NFe.Base_Calculo_ICMS = Convert.ToDecimal(base_calculo_icms.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (base_calculo_icms_st.Contains("."))
                    {
                        NFe.Base_Calculo_ICMS_ST = Convert.ToDecimal(base_calculo_icms_st.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        NFe.Base_Calculo_ICMS_ST = Convert.ToDecimal(base_calculo_icms_st.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (total_aprox_trib.Contains("."))
                    {
                        NFe.Total_Aprox_Trib = Convert.ToDecimal(total_aprox_trib.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        NFe.Total_Aprox_Trib = Convert.ToDecimal(total_aprox_trib.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    con.Salvar_icms_icms_st(NFe);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static int Sel_Dfe_Ultimo_Cod_NFe_NFCe_Adicionado(string modelo, string serie)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.Modelo = modelo.Insert(modelo.Length, "'").Insert(0, "'");
                    //
                    NFe.Serie = Convert.ToInt32(serie);
                    //
                    return con.Sel_Dfe_Ultimo_Cod_NFe_NFCe_Adicionado(NFe) + 1;
                }
            }
        }

        public static void Salvar(string chave_acesso, string emissao, string modelo, string numero_nf, string serie, string data_emissao, string hora_emissao, string data_saida, string hora_saida, string emitente, string observacao, string total_produtos, string descontos, string frete, string despesas, string valor_total_nf, string natureza_operacao, bool importado, string cod_pdv_computador, string tipo_emitente, string seguro, string ipi, bool propria, string finalidade, bool consumidor_final, string tipo_operacao, string situacao, string n_seq_cce, string cod_venda, string cod_devolucao, bool venda)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (chave_acesso == "" || chave_acesso == null || chave_acesso == "  -    -  .   .   /    -  -  -   -   .   .   - -  .   .   -")
                    {
                        NFe.Chave_DFe = "null";
                    }
                    else
                    {
                        NFe.Chave_DFe = chave_acesso.Insert(chave_acesso.Length, "'").Insert(0, "'");
                    }
                    //
                    if (emissao == null || emissao == "")
                    {
                        NFe.Emissao = "'TERCEIROS'";
                    }
                    else
                    {
                        NFe.Emissao = emissao.Insert(emissao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (modelo == "MODELO 55 (NFe)" || modelo == "55")
                    {
                        NFe.Modelo = "55";
                    }
                    else
                    {
                        NFe.Modelo = "65";
                    }
                    //
                    NFe.Serie = Convert.ToInt32(serie);
                    //
                    if (propria == true)
                    {
                        if (NFe.Modelo == "55")
                        {
                            if (bllMinhaEmpresa.Sel_Empresa_Ult_Num_NFe() != 0)
                            {
                                NFe.Numero_NF = bllMinhaEmpresa.Sel_Empresa_Ult_Num_NFe();
                                //
                                bllMinhaEmpresa.Alterar_Ult_Num_NFe();
                            }
                            else
                            {
                                NFe.Numero_NF = bllDFe.Sel_Dfe_Ultimo_Cod_NFe_NFCe_Adicionado(NFe.Modelo, serie);
                            }
                        }
                        else
                        {
                            if (bllMinhaEmpresa.Sel_Empresa_Ult_Num_NFCe() != 0)
                            {
                                NFe.Numero_NF = bllMinhaEmpresa.Sel_Empresa_Ult_Num_NFCe();
                                //
                                bllMinhaEmpresa.Alterar_Ult_Num_NFCe();
                            }
                            else
                            {
                                NFe.Numero_NF = bllDFe.Sel_Dfe_Ultimo_Cod_NFe_NFCe_Adicionado(NFe.Modelo, serie);
                            }
                        }
                    }
                    else
                    {
                        NFe.Numero_NF = Convert.ToInt32(numero_nf);
                    }
                    //
                    NFe.Data_Emissao = "'" + data_emissao.Replace('/', '.') + " " + hora_emissao.Remove(5) + "'";
                    //
                    NFe.Hora_Emissao = hora_emissao.Insert(hora_emissao.Length, "'").Insert(0, "'");
                    //
                    if (data_saida == "" || data_saida == "  /  /" || data_saida == "__/__/____" || data_saida == null)
                    {
                        NFe.Data_Saida = "null";
                    }
                    else
                    {
                        if (hora_saida == "" || hora_saida == "  :  :" || hora_saida == "__:__:__" || hora_saida == null)
                        {
                            NFe.Data_Saida = data_saida.Insert(data_saida.Length, "'").Insert(0, "'").Replace('/', '.');
                        }
                        else
                        {
                            NFe.Data_Saida = "'" + data_saida.Replace('/', '.') + " " + hora_saida.Remove(5) + "'";
                        }
                    }
                    //
                    if (hora_emissao == "" || hora_emissao == "  :  :" || hora_emissao == "__:__:__" || hora_emissao == null)
                    {
                        NFe.Hora_Emissao = "null";
                    }
                    else
                    {
                        NFe.Hora_Emissao = hora_emissao.Insert(hora_emissao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (hora_saida == "" || hora_saida == "  :  :" || hora_saida == "__:__:__" || hora_saida == null)
                    {
                        NFe.Hora_Saida = "null";
                    }
                    else
                    {
                        NFe.Hora_Saida = hora_saida.Insert(hora_saida.Length, "'").Insert(0, "'");
                    }
                    //
                    NFe.Tipo_Emitente_Destinatario = tipo_emitente.Insert(tipo_emitente.Length, "'").Insert(0, "'");
                    //
                    string[] items;
                    //
                    if (emitente == "" || emitente == null)
                    {
                        NFe.Cod_Emitente_Destinatario = 0;
                        NFe.Nome_Emitente_Destinatario = "'CONSUMIDOR NAO IDENTIFICADO'";
                        NFe.CPF_CNPJ_Emitente_Destinatario = "null";
                    }
                    else
                    {
                        items = emitente.Split('—');
                        NFe.Cod_Emitente_Destinatario = Convert.ToInt32(items[0]);
                        NFe.Nome_Emitente_Destinatario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                        NFe.CPF_CNPJ_Emitente_Destinatario = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                    }
                    //
                    if (total_produtos.Contains("."))
                    {
                        NFe.Total_Produtos = Convert.ToDecimal(total_produtos.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        NFe.Total_Produtos = Convert.ToDecimal(total_produtos.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (descontos == "" || descontos == null)
                    {
                        NFe.Descontos = 0;
                    }
                    else
                    {
                        if (descontos.Contains("."))
                        {
                            NFe.Descontos = Convert.ToDecimal(descontos.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            NFe.Descontos = Convert.ToDecimal(descontos.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (frete == "" || frete ==  null)
                    {
                        NFe.Frete = 0;
                    }
                    else
                    {
                        if (descontos.Contains("."))
                        {
                            NFe.Frete = Convert.ToDecimal(frete.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            NFe.Frete = Convert.ToDecimal(frete.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (despesas == "" || despesas == null)
                    {
                        NFe.Despesas = 0;
                    }
                    else
                    {
                        if (despesas.Contains("."))
                        {
                            NFe.Despesas = Convert.ToDecimal(despesas.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            NFe.Despesas = Convert.ToDecimal(despesas.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (valor_total_nf.Contains("."))
                    {
                        NFe.Valor_Total_NF = Convert.ToDecimal(valor_total_nf.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        NFe.Valor_Total_NF = Convert.ToDecimal(valor_total_nf.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (observacao == "" || observacao == null)
                    {
                        NFe.Observacao = "null";
                    }
                    else
                    {
                        NFe.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (natureza_operacao == "" || natureza_operacao == null)
                    {
                        NFe.Descricao_CFOP = "null";
                    }
                    else
                    {
                        NFe.Descricao_CFOP = natureza_operacao.Insert(natureza_operacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (importado == true)
                    {
                        NFe.Importado = 1;
                    }
                    else
                    {
                        NFe.Importado = 0;
                    }
                    //
                    if (seguro == "" || seguro == null)
                    {
                        NFe.Seguro = 0;
                    }
                    else
                    {
                        if (seguro.Contains("."))
                        {
                            NFe.Seguro = Convert.ToDecimal(seguro.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            NFe.Seguro = Convert.ToDecimal(seguro.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (ipi == "" || ipi == null)
                    {
                        NFe.IPI = 0;
                    }
                    else
                    {
                        if (ipi.Contains("."))
                        {
                            NFe.IPI = Convert.ToDecimal(ipi.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            NFe.IPI = Convert.ToDecimal(ipi.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (situacao == "" || situacao == null)
                    {
                        NFe.Situacao = "null";
                    }
                    else
                    {
                        NFe.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    }
                  
                    //
                    if (propria == false)
                    {
                        NFe.Codigo_Aleatorio = "null";
                    }
                    else
                    {
                        Random random = new Random();

                        string resultado = string.Empty;

                        for (int i = 0; i < 8; i++)
                        {
                            resultado += random.Next(0, 10).ToString();
                        }

                        NFe.Codigo_Aleatorio = resultado;

                    }
                    //
                    if (finalidade == "" || finalidade == null)
                    {
                        NFe.Finalidade = "null";
                    }
                    else
                    { 
                        NFe.Finalidade = finalidade.Insert(finalidade.Length, "'").Insert(0, "'");
                    }
                    //
                    if (consumidor_final == false)
                    {
                        NFe.Consumidor_Final = 0;
                    }
                    else
                    {
                        NFe.Consumidor_Final = Convert.ToByte(consumidor_final);
                    }
                    //
                    if (tipo_operacao == "" || tipo_operacao == null)
                    {
                        NFe.Tipo_Operacao = "null";
                    }
                    else
                    {
                        NFe.Tipo_Operacao = tipo_operacao.Insert(tipo_operacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (n_seq_cce == null || n_seq_cce == "")
                    {
                        NFe.N_Seq_CCe = 0;
                    }
                    else
                    {
                        NFe.N_Seq_CCe = Convert.ToInt16(n_seq_cce);
                    }
                    //
                    if (cod_venda == null || cod_venda == "")
                    {
                        NFe.Cod_Venda = 0;
                    }
                    else
                    {
                        NFe.Cod_Venda = Convert.ToInt32(cod_venda);
                    }
                    //
                    if (cod_devolucao == null || cod_devolucao == "")
                    {
                        NFe.Cod_Devolucao = 0;
                    }
                    else
                    {
                        NFe.Cod_Devolucao = Convert.ToInt32(cod_devolucao);
                    }
                    //
                    if (venda == false)
                    {
                        NFe.Origem_Venda = 0;
                    }
                    else
                    {
                        NFe.Origem_Venda = 1;
                    }
                    //
                    con.Salvar_DFe(NFe);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_DFe_Temp(string finalidade, string modelo, string data_saida, string hora_saida, string destinatario, string observacao, string natureza_operacao, string cod_conexao_configuracoes, string tipo_emitente, bool consumidor_final, string tipo_operacao, string cod_dfe)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (DFE_Temp NFe = new DFE_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    NFe.Finalidade = finalidade.Insert(finalidade.Length, "'").Insert(0, "'");
                    //
                    if (modelo == "MODELO 55 (NFe)")
                    {
                        NFe.Modelo = "55";
                    }
                    else
                    {
                        NFe.Modelo = "65";
                    }
                    //
                    if (data_saida == "" || data_saida == "  /  /" || data_saida == "__/__/____")
                    {
                        NFe.Data_Saida = "null";
                    }
                    else
                    {
                        if (hora_saida == "" || hora_saida == "  :  :" || hora_saida == "__:__:__")
                        {
                            NFe.Data_Saida = data_saida.Insert(data_saida.Length, "'").Insert(0, "'").Replace('/', '.');
                        }
                        else
                        {
                            NFe.Data_Saida = "'" + data_saida.Replace('/', '.') + " " + hora_saida.Remove(5) + "'";
                        }
                    }
                    //
                    if (hora_saida == "" || hora_saida == "  :  :" || hora_saida == "__:__:__")
                    {
                        NFe.Hora_Saida = "null";
                    }
                    else
                    {
                        NFe.Hora_Saida = hora_saida.Insert(hora_saida.Length, "'").Insert(0, "'");
                    }
                    //
                    NFe.Tipo_Emitente_Destinatario = tipo_emitente.Insert(tipo_emitente.Length, "'").Insert(0, "'");
                    //
                    string[] items;
                    //
                    if (destinatario == "")
                    {
                        NFe.Cod_Emitente_Destinatario = 0;
                        NFe.Nome_Emitente_Destinatario = "null";
                        NFe.CPF_CNPJ_Emitente_Destinatario = "null";
                    }
                    else
                    {
                        items = destinatario.Split('—');
                        NFe.Cod_Emitente_Destinatario = Convert.ToInt32(items[0]);
                        NFe.Nome_Emitente_Destinatario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                        NFe.CPF_CNPJ_Emitente_Destinatario = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                    }
                    //
                    if (observacao == "")
                    {
                        NFe.Observacao = "null";
                    }
                    else
                    {
                        NFe.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (natureza_operacao == "")
                    {
                        NFe.Cod_CFOP = 0;
                        NFe.Descricao_CFOP = "null";
                    }
                    else
                    {
                        items = natureza_operacao.Split('—');
                        NFe.Cod_CFOP = Convert.ToInt32(items[0]);
                        NFe.Descricao_CFOP = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    NFe.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    if (consumidor_final == false)
                    {
                        NFe.Consumidor_Final = 0;
                    }
                    else
                    {
                        NFe.Consumidor_Final = 1;
                    }
                    //
                    if (tipo_operacao == "" || tipo_operacao == null)
                    {
                        NFe.Tipo_Operacao = "null";
                    }
                    else
                    {
                        NFe.Tipo_Operacao = tipo_operacao.Insert(tipo_operacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cod_dfe == null || cod_dfe == "")
                    {
                        NFe.Cod_DFe = 0;
                    }
                    else
                    {
                        NFe.Cod_DFe = Convert.ToInt32(cod_dfe);
                    }
                    //
                    con.Salvar_DFe_Temp(NFe);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir_DFe_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (DFE_Temp NFe = new DFE_Temp())
                {
                    NFe.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_DFe_Temp(NFe);
                }
            }
        }

        public static void Alterar_Chave_DFe(string chave, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.Chave_DFe = chave.Insert(chave.Length, "'").Insert(0, "'");
                    //
                    NFe.Codigo = Convert.ToInt32(cod_dfe);
                    //
                    con.Alterar_Chave_DFe(NFe);
                }
            }
        }

        public static void Alterar_CFOP_Item_DFe(string cfop, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Item.CFOP = cfop.Insert(cfop.Length, "'").Insert(0, "'");
                    //
                    Item.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    //
                    con.Alterar_CFOP_Item_DFe(Item);
                }
            }
        }

        public static void Alterar_CFOP_Item_DFe_Temp(string cfop, string cod_coenxao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Temp Item = new Item_DFe_Temp())
                {
                    Item.CFOP = cfop.Insert(cfop.Length, "'").Insert(0, "'");
                    //
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_coenxao_configuracoes);
                    //
                    con.Alterar_CFOP_Item_DFe_Temp(Item);
                }
            }
        }

        public static void Alterar_Caminho_DFe(string caminho_dfe, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.Caminho_Dfe = caminho_dfe.Insert(caminho_dfe.Length, "'").Insert(0, "'");
                    //
                    NFe.Codigo = Convert.ToInt32(cod_dfe);
                    //
                    con.Alterar_Caminho_DFe(NFe);
                }
            }
        }

        public static void Alterar_N_Seq_CCe(string n_seq_cce, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.N_Seq_CCe = Convert.ToInt16(n_seq_cce);
                    //
                    NFe.Codigo = Convert.ToInt32(cod_dfe);
                    //
                    con.Alterar_N_Seq_CCe(NFe);
                }
            }
        }

        public static void Alterar_Data_Emissao_DFe(string data_emissao, string hora_emissao, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.Data_Emissao = "'" + data_emissao.Replace('/', '.') + " " + hora_emissao.Remove(5) + "'";
                    //
                    NFe.Hora_Emissao = hora_emissao.Insert(hora_emissao.Length, "'").Insert(0, "'");
                    //
                    NFe.Codigo = Convert.ToInt32(cod_dfe);
                    //
                    con.Alterar_Data_Emissao_DFe(NFe);
                }
            }
        }

        public static void Alterar_Situacao_DFe(string status, string situcao, string cod_dfe, string nprotocolo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.Status = status.Insert(status.Length, "'").Insert(0, "'");
                    //
                    NFe.Codigo = Convert.ToInt32(cod_dfe);
                    //
                    NFe.Situacao = situcao.Insert(situcao.Length, "'").Insert(0, "'");
                    //
                    if (nprotocolo == null || nprotocolo == "")
                    {
                        NFe.N_Protocolo = "null";
                    }
                    else
                    {
                        NFe.N_Protocolo = nprotocolo.Insert(nprotocolo.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Alterar_Situacao_DFe(NFe);
                }
            }
        }

        public static void Alterar_DFe_Temp(string finalidade, string modelo, string data_saida, string hora_saida, string destinatario, string observacao, string natureza_operacao, string cod_conexao_configuracoes, string tipo_emitente, bool consumidor_final, string tipo_operacao, string cod_dfe)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (DFE_Temp NFe = new DFE_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    NFe.Finalidade = finalidade.Insert(finalidade.Length, "'").Insert(0, "'");
                    //
                    if (modelo == "MODELO 55 (NFe)")
                    {
                        NFe.Modelo = "55";
                    }
                    else
                    {
                        NFe.Modelo = "65";
                    }
                    //
                    if (data_saida == "" || data_saida == "  /  /" || data_saida == "__/__/____")
                    {
                        NFe.Data_Saida = "null";
                    }
                    else
                    {
                        if (hora_saida == "" || hora_saida == "  :  :" || hora_saida == "__:__:__")
                        {
                            NFe.Data_Saida = data_saida.Insert(data_saida.Length, "'").Insert(0, "'").Replace('/', '.');
                        }
                        else
                        {
                            NFe.Data_Saida = "'" + data_saida.Replace('/', '.') + " " + hora_saida.Remove(5) + "'";
                        }
                    }
                    //
                    if (hora_saida == "" || hora_saida == "  :  :" || hora_saida == "__:__:__")
                    {
                        NFe.Hora_Saida = "null";
                    }
                    else
                    {
                        NFe.Hora_Saida = hora_saida.Insert(hora_saida.Length, "'").Insert(0, "'");
                    }
                    //
                    NFe.Tipo_Emitente_Destinatario = tipo_emitente.Insert(tipo_emitente.Length, "'").Insert(0, "'");
                    //
                    string[] items;
                    //
                    if (destinatario == "")
                    {
                        NFe.Cod_Emitente_Destinatario = 0;
                        NFe.Nome_Emitente_Destinatario = "null";
                        NFe.CPF_CNPJ_Emitente_Destinatario = "null";
                    }
                    else
                    {
                        items = destinatario.Split('—');
                        NFe.Cod_Emitente_Destinatario = Convert.ToInt32(items[0]);
                        NFe.Nome_Emitente_Destinatario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                        NFe.CPF_CNPJ_Emitente_Destinatario = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                    }
                    //
                    if (observacao == "")
                    {
                        NFe.Observacao = "null";
                    }
                    else
                    {
                        NFe.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (natureza_operacao == "")
                    {
                        NFe.Cod_CFOP = 0;
                        NFe.Descricao_CFOP = "null";
                    }
                    else
                    {
                        items = natureza_operacao.Split('—');
                        NFe.Cod_CFOP = Convert.ToInt32(items[0]);
                        NFe.Descricao_CFOP = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    NFe.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    if (consumidor_final == false)
                    {
                        NFe.Consumidor_Final = 0;
                    }
                    else
                    {
                        NFe.Consumidor_Final = 1;
                    }
                    //
                    if (tipo_operacao == "" || tipo_operacao == null)
                    {
                        NFe.Tipo_Operacao = "null";
                    }
                    else
                    {
                        NFe.Tipo_Operacao = tipo_operacao.Insert(tipo_operacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cod_dfe == null || cod_dfe == "")
                    {
                        NFe.Cod_DFe = 0;
                    }
                    else
                    {
                        NFe.Cod_DFe = Convert.ToInt32(cod_dfe);
                    }
                    //
                    con.Alterar_DFe_Temp(NFe);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static int Sel_Dfe_Ultimo_Cod_Adicionado()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Dfe_Ultimo_Cod_Adicionado();
            }
        }

        public static int Sel_Dfe_N_Seq_CCe(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.Codigo = Convert.ToInt32(cod_dfe);
                    //
                    return con.Sel_Dfe_N_Seq_CCe(NFe) + 1;
                }
            }
        }

        public static bool Sel_Dfe_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Dfe_Ainda_Existe(Nfe);
                }
            }
        }

        public static bool Sel_Dfe_Existe_Conta_Pagar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Dfe_Existe_Conta_Pagar(Nfe);
                }
            }
        }

        public static bool Sel_Item_Dfe_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Item.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Item_Dfe_Ainda_Existe(Item);
                }
            }
        }

        public static DataTable Sel_DFe_A_Salvar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_DFe_A_Salvar();
            }
        }

        public static DataTable Sel_DFe_A_Alterar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_DFe_A_Alterar(Nfe);
                }
            }
        }

        public static DataTable Sel_Items_DFe(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Item.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    return con.Sel_Items_DFe(Item);
                }
            }
        }

        public static DataTable Sel_Items_Associar_DFe(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Item.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    return con.Sel_Items_Associar_DFe(Item);
                }
            }
        }

        public static DataTable Sel_Referencia_DFe(string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ReferenciaDFe Ref = new ReferenciaDFe())
                {
                    Ref.Cod_DFe = Convert.ToInt32(cod_dfe);
                    return con.Sel_Referencia_DFe(Ref);
                }
            }
        }

        public static bool Sel_Situacao_Emissao_DFe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    //
                    if (con.Sel_Situacao_Emissao_DFe(Nfe) == null)
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

        public static DataTable Sel_Items_DFe_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Temp Item = new Item_DFe_Temp())
                {
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    return con.Sel_Items_DFe_Temp(Item);
                }
            }
        }

        public static DataTable Sel_Dados_DFe_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Temp Item = new Item_DFe_Temp())
                {
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    return con.Sel_Dados_DFe_Temp(Item);
                }
            }
        }

        public static void Atualizar_Saldo_Produto_Exclusao_Dfe(string codigo, string quantidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (quantidade.Contains("."))
                    {
                        if (con.Sel_Dados_Produto_Venda(Prod) < 0)
                        {
                            Prod.Saldo_Atual = con.Sel_Dados_Produto_Venda(Prod) + Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Saldo_Atual = con.Sel_Dados_Produto_Venda(Prod) - Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                        }
                    }
                    else
                    {
                        if (con.Sel_Dados_Produto_Venda(Prod) < 0)
                        {
                            Prod.Saldo_Atual = con.Sel_Dados_Produto_Venda(Prod) + Convert.ToDecimal(quantidade.Replace(",", "."));
                        }
                        else
                        {
                            Prod.Saldo_Atual = con.Sel_Dados_Produto_Venda(Prod) - Convert.ToDecimal(quantidade.Replace(",", "."));
                        }
                    }
                    //
                    con.Atualizar_Saldo_Produto_Exclusao_Dfe(Prod);
                }
            }
        }

        public static void Excluir(string codigo, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_DFe(NFe);
                }
            }
        }

        public static void Excluir_Transportador(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Transportador_DFe(Nfe);
                }
            }
        }

        public static void Excluir_Validade_DFe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Validade_DFe(Nfe);
                }
            }
        }

        public static void Excluir_Pagamento_DFe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Pagamento_DFe(Nfe);
                }
            }
        }

        public static void Excluir_Precificacao_DFe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Precificacao_DFe(Nfe);
                }
            }
        }

        public static void Excluir_Associar_Item_DFe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Associar_Item_DFe(Nfe);
                }
            }
        }

        public static void Excluir_Items_DFe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Items_DFe(Nfe);
                }
            }
        }

        public static void Excluir_Referencia_DFe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE Nfe = new DFE())
                {
                    Nfe.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Referencia_DFe(Nfe);
                }
            }
        }

        public static void Excluir_Item(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Item.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Item_DFe(Item);
                }
            }
        }

        public static void Excluir_Item_DFe_Temp(string codigo, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Temp Item = new Item_DFe_Temp())
                {
                    Item.Codigo = Convert.ToInt16(codigo);
                    //
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Item_DFe_Temp(Item);
                }
            }
        }

        public static void Excluir_Todos_Referencia_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ReferenciaDFe_Temp Item = new ReferenciaDFe_Temp())
                {
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Todos_Referencia_Temp(Item);
                }
            }
        }

        public static void Excluir_Todos_Transportador_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ReferenciaDFe_Temp Item = new ReferenciaDFe_Temp())
                {
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Todos_Transportador_Temp(Item);
                }
            }
        }

        public static void Excluir_Todos_Item_DFe_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Temp Item = new Item_DFe_Temp())
                {
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Todos_Item_DFe_Temp(Item);
                }
            }
        }

        public static string Calculo_Valor_Item(string valor_unitario, string quantidade)
        {
            if (valor_unitario == "")
            {
                valor_unitario = "0,00";
            }
            //
            if (quantidade == "")
            {
                quantidade = "0,00";
            }
            //
            decimal valor = Convert.ToDecimal(valor_unitario);
            decimal qtde = Convert.ToDecimal(quantidade);
            valor = valor * qtde; ;
            return Math.Round(valor, 2).ToString();
        }

        public static string Calculo_Reducao_Valor_Base_Calculo_ICMS(string valor_base_calculo_icms, string valor_aliq_icms, string valor_percentual)
        {
            if (valor_base_calculo_icms == "")
            {
                valor_base_calculo_icms = "0,00";
            }
            //
            if (valor_aliq_icms == "")
            {
                valor_aliq_icms = "0,00";
            }
            //
            if (valor_percentual == "")
            {
                valor_percentual = "0,00";
            }
            //
            decimal base_calculo_icms = Convert.ToDecimal(valor_base_calculo_icms);
            decimal aliq_icms = Convert.ToDecimal(valor_aliq_icms);
            decimal percentual = Convert.ToDecimal(valor_percentual);
            //
            decimal fatorReducao = 1 - (percentual / 100);
            decimal baseReduzida = base_calculo_icms * fatorReducao;
            //
            decimal valoricms = baseReduzida * (aliq_icms / 100);
            //
            return Math.Round(baseReduzida, 2).ToString() + "—" + Math.Round(valoricms, 2).ToString();
        }

        public static string Calculo_Reducao_Valor_Base_Calculo_ICMS_ST(string valor_total_operacao, string valor_aliq_icms_st, string valor_percentual, string valor_mva)
        {
            if (valor_total_operacao == "")
            {
                valor_total_operacao = "0,00";
            }
            //
            if (valor_aliq_icms_st == "")
            {
                valor_aliq_icms_st = "0,00";
            }
            //
            if (valor_percentual == "")
            {
                valor_percentual = "0,00";
            }
            //
            if (valor_mva == "")
            {
                valor_mva = "0,00";
            }
            //
            decimal total_operacao = Convert.ToDecimal(valor_total_operacao);
            decimal aliq_icms_st = Convert.ToDecimal(valor_aliq_icms_st);
            decimal percentual = Convert.ToDecimal(valor_percentual);
            decimal mva = Convert.ToDecimal(valor_mva);
            //
            decimal basecommva = total_operacao;
            decimal basereducao = basecommva * (1 - (percentual / 100));
            decimal icmsst = basereducao * (aliq_icms_st / 100);
            //decimal icmsproprio = total_operacao * (aliq_icms_st / 100);
            //decimal icmsstrecolher = icmsst - icmsproprio;
            //
            return Math.Round(basereducao, 2).ToString() + "—" + Math.Round(icmsst, 2).ToString();
        }

        public static string Calculo_Valor_Base_Calculo_ICMS(string valor_unitario, string quantidade, string desconto, string acrescimo)
        {
            if (valor_unitario == "")
            {
                valor_unitario = "0,00";
            }
            //
            if (quantidade == "")
            {
                quantidade = "0,00";
            }
            //
            if (desconto == "")
            {
                desconto = "0,00";
            }
            //
            if (acrescimo == "")
            {
                acrescimo = "0,00";
            }
            //
            decimal valor = Convert.ToDecimal(valor_unitario);
            decimal qtde = Convert.ToDecimal(quantidade);
            decimal desc = Convert.ToDecimal(desconto);
            decimal acresc = Convert.ToDecimal(acrescimo);
            valor = (valor + acresc - desc) * qtde; ;
            return Math.Round(valor, 2).ToString();
        }

        public static string Calculo_Valor_Base_Calculo_ICMS_ST(string valor_unitario, string quantidade, string desconto, string acrescimo, string margem_agregada)
        {
            if (valor_unitario == "")
            {
                valor_unitario = "0,00";
            }
            //
            if (quantidade == "")
            {
                quantidade = "0,00";
            }
            //
            if (desconto == "")
            {
                desconto = "0,00";
            }
            //
            if (acrescimo == "")
            {
                acrescimo = "0,00";
            }
            //
            if (margem_agregada == "")
            {
                margem_agregada = "0,00";
            }
            //
            decimal valor = Convert.ToDecimal(valor_unitario);
            decimal qtde = Convert.ToDecimal(quantidade);
            decimal desc = Convert.ToDecimal(desconto);
            decimal acresc = Convert.ToDecimal(acrescimo);
            decimal mva = Convert.ToDecimal(margem_agregada) / 100;
            valor = ((valor + acresc - desc) * qtde) * (1 + mva);
            return Math.Round(valor, 2).ToString();
        }

        public static string Calculo_Valor_IPI(string total, string aliquota)
        {
            if (total == "")
            {
                total = "0,00";
            }
            //
            if (aliquota == "")
            {
                aliquota = "0,00";
            }
            //
            decimal base_calculo = Convert.ToDecimal(total);
            decimal aliq = Convert.ToDecimal(aliquota) / 100;
            base_calculo = (base_calculo * aliq); ;
            return Math.Round(base_calculo, 2).ToString();
        }


        public static string Calculo_Valor_ICMS(string valor_base_calculo, string aliquota)
        {
            if (valor_base_calculo == "")
            {
                valor_base_calculo = "0,00";
            }
            //
            if (aliquota == "")
            {
                aliquota = "0,00";
            }
            //
            decimal base_calculo = Convert.ToDecimal(valor_base_calculo);
            decimal aliq = Convert.ToDecimal(aliquota) / 100;
            base_calculo = (base_calculo * aliq); ;
            return Math.Round(base_calculo, 2).ToString();
        }

        public static string Calculo_Valormargem_Precificacao(string valor_custo_unitario, string valor_margem)
        {
            if (valor_custo_unitario == "")
            {
                valor_custo_unitario = "0,00";
            }
            //
            if (valor_margem == "")
            {
                valor_margem = "0,00";
            }
            //
            decimal custo_unitario = Convert.ToDecimal(valor_custo_unitario);
            decimal margem = Convert.ToDecimal(valor_margem) / 100;
            decimal total = custo_unitario + (custo_unitario * margem);
            return Math.Round(total, 2).ToString();
        }



        public static string Calculo_Valor_ICMS_ST(string base_calculo_st, string aliquota_st, string valor_unitario, string quantidade, string aliquota)
        {
            if (base_calculo_st == "")
            {
                base_calculo_st = "0,00";
            }
            //
            if (aliquota_st == "")
            {
                aliquota_st = "0,00";
            }
            //
            decimal icms_st;
            decimal base_calculo = Convert.ToDecimal(base_calculo_st);
            decimal aliq_st = Convert.ToDecimal(aliquota_st) / 100;
            icms_st = (base_calculo * aliq_st);
            //
            if (valor_unitario == "")
            {
                valor_unitario = "0,00";
            }
            //
            if (quantidade == "")
            {
                quantidade = "0,00";
            }
            //
            if (aliquota == "")
            {
                quantidade = "0,00";
            }
            //
            decimal icms;
            decimal aliq = Convert.ToDecimal(aliquota) / 100;
            decimal valor = Convert.ToDecimal(valor_unitario);
            decimal qtde = Convert.ToDecimal(quantidade);
            icms = (valor * qtde) * aliq;
            icms_st = icms_st - icms;
            return Math.Round(icms_st, 2).ToString();
        }

        public static string Calculo_Desconto(string valor_documento, string desconto_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(desconto_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_IBPT(string valor_produto, string aliq_ibpt)
        {
            decimal valor = Convert.ToDecimal(valor_produto);
            decimal percentual = Convert.ToDecimal(aliq_ibpt) / 100;
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

        public static string Calculo_Valor_Item_Desc_Acresc(string valor_total, string valor_desconto, string valor_acrescimo, string valor_ipi, string valor_frete)
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
            if (valor_ipi == "")
            {
                valor_ipi = "0,00";
            }
            //
            if (valor_frete == "")
            {
                valor_frete = "0,00";
            }
            //
            decimal valor = Convert.ToDecimal(valor_total);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal acrescimo = Convert.ToDecimal(valor_acrescimo);
            decimal ipi = Convert.ToDecimal(valor_ipi);
            decimal frete = Convert.ToDecimal(valor_frete);
            valor = ((valor + acrescimo + ipi + frete) - desconto);
            return Math.Round(valor, 2).ToString();
        }

        public static string Calculo_Valor_Aprox_Trib(string valor_total, string produto)
        {
            if (valor_total == "")
            {
                valor_total = "0,00";
            }
            //
            if (produto != "")
            {
                string[] items = produto.Split('—');
                //
                DataRow drProduto = bllProduto.Sel_Prod_Codigo(items[0], "").Rows[0];
                //
                decimal trib_federal = 0;
                decimal trib_federal_imp = 0;
                decimal trib_estadual = 0;
                decimal trib_municipal = 0;
                decimal total = 0;
                DataRow drIBPT;
                //
                if (bllIBPT.Sel_IBPT_NCM(drProduto["ncm"].ToString(), drProduto["excecao_ncm"].ToString()) != null)
                {
                    drIBPT = bllIBPT.Sel_IBPT_NCM(drProduto["ncm"].ToString(), drProduto["excecao_ncm"].ToString()).Rows[0];
                }
                else
                {
                    throw new InvalidOperationException("O NCM do Produto [ " + items[0] + " ] não foi encontrado na tabela IBPT.");
                }
                //
                trib_federal = Convert.ToDecimal(bllDFe.Calculo_IBPT(valor_total, drIBPT["trib_federal"].ToString()));
                //decimal trib_federal_imp = Convert.ToDecimal(bllDFe.Calculo_IBPT(drItems["valor_total"].ToString(), drIBPT["trib_federal_importado"].ToString()));
                trib_federal_imp = 0;
                trib_estadual = Convert.ToDecimal(bllDFe.Calculo_IBPT(valor_total, drIBPT["trib_estadual"].ToString()));
                trib_municipal = Convert.ToDecimal(bllDFe.Calculo_IBPT(valor_total, drIBPT["trib_municipal"].ToString()));
                total = trib_federal + trib_federal_imp + trib_estadual + trib_municipal;
                //
                return total.ToString();
            }
            else
            {
                return "0,00";
            }
        }

        public static void Salvar_Items(string item, string produto, string ncm, string cest, string cst, string aliquota_icms, string csosn, string cfop, string quantidade, string quantidade_embalagem, string valor_total, string preco_valor_unitario, string valor_desconto, string valor_acrescimo, string valor_total_real, string valor_icms, string valor_base_calculo, string cod_dfe, string valor_icms_st, string aliquota_icms_st, string mva, string base_calculo_icms_st, string reducao_bc, string um, string total_aprox_trib, string aliquota_ipi, string valor_ipi, string reducao_bc_st, string cst_ibs_cbs, string cclass_trib, string aliq_ibs_mun, string aliq_ibs_est, string aliq_cbs, string valor_frete)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Item = Convert.ToInt16(Convert.ToInt32(item) + 1);
                    //
                    string[] items = produto.Split('—');
                    Item.Cod_Produto = Convert.ToInt32(items[0]);
                    //
                    Item.Descricao = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Item.NCM = ncm.Insert(ncm.Length, "'").Insert(0, "'");
                    //
                    if (cst == "" || cst == null)
                    {
                        Item.CST = "null";
                    }
                    else
                    {
                        Item.CST = cst.Insert(cst.Length, "'").Insert(0, "'");
                    }
                    //
                    if (aliquota_icms.Contains("."))
                    {
                        Item.Aliquota = Convert.ToDecimal(aliquota_icms.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliquota = Convert.ToDecimal(aliquota_icms.Replace(",", "."));
                    }
                    //
                    if (csosn == "" || csosn == null)
                    {
                        Item.CSOSN = "null";
                    }
                    else
                    {
                        Item.CSOSN = csosn.Insert(csosn.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cest == "" || cest == null)
                    {
                        Item.CEST = "null";
                    }
                    else
                    {
                        Item.CEST = cest.Insert(cest.Length, "'").Insert(0, "'");
                    }
                    //
                    Item.CFOP = cfop.Insert(cfop.Length, "'").Insert(0, "'");
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
                    if (quantidade_embalagem.Contains("."))
                    {
                        Item.Quantidade_Embalagem = Convert.ToDecimal(quantidade_embalagem.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Quantidade_Embalagem = Convert.ToDecimal(quantidade_embalagem.Replace(",", "."));
                    }
                    //
                    if (preco_valor_unitario.Contains("."))
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(preco_valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(preco_valor_unitario.Replace(",", "."));
                    }
                    //
                    if (valor_total.Contains("."))
                    {
                        Item.Total = Convert.ToDecimal(valor_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Total = Convert.ToDecimal(valor_total.Replace(",", "."));
                    }
                    //
                    if (valor_desconto == "" || valor_desconto == null)
                    {
                        Item.Valor_Desconto = 0;
                    }
                    else
                    {
                        if (valor_desconto.Contains("."))
                        {
                            Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_acrescimo == "" || valor_acrescimo == null)
                    {
                        Item.Valor_Acrescimo = 0;
                    }
                    else
                    {
                        if (valor_acrescimo.Contains("."))
                        {
                            Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_total_real.Contains("."))
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total_real.Replace(",", "."));
                    }
                    //
                    if (valor_base_calculo.Contains("."))
                    {
                        Item.Valor_Base_Calculo = Convert.ToDecimal(valor_base_calculo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Base_Calculo = Convert.ToDecimal(valor_base_calculo.Replace(",", "."));
                    }
                    //
                    if (valor_icms.Contains("."))
                    {
                        Item.Valor_Icms = Convert.ToDecimal(valor_icms.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Icms = Convert.ToDecimal(valor_icms.Replace(",", "."));
                    }
                    //
                    Item.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    //
                    if (valor_icms_st == "" || valor_icms_st == null)
                    {
                        Item.Valor_Icms_St = 0;
                    }
                    else
                    {
                        if (valor_icms_st.Contains("."))
                        {
                            Item.Valor_Icms_St = Convert.ToDecimal(valor_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Icms_St = Convert.ToDecimal(valor_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (aliquota_icms_st == "" || aliquota_icms_st == null)
                    {
                        Item.Aliquota_ST = 0;
                    }
                    else
                    {
                        if (aliquota_icms_st.Contains("."))
                        {
                            Item.Aliquota_ST = Convert.ToDecimal(aliquota_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Aliquota_ST = Convert.ToDecimal(aliquota_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (mva == "" || mva == null)
                    {
                        Item.MVA = 0;
                    }
                    else
                    {
                        if (mva.Contains("."))
                        {
                            Item.MVA = Convert.ToDecimal(mva.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.MVA = Convert.ToDecimal(mva.Replace(",", "."));
                        }
                    }
                    //
                    if (base_calculo_icms_st == "" || base_calculo_icms_st == null)
                    {
                        Item.Valor_Base_Calculo_St = 0;
                    }
                    else
                    {
                        if (base_calculo_icms_st.Contains("."))
                        {
                            Item.Valor_Base_Calculo_St = Convert.ToDecimal(base_calculo_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Base_Calculo_St = Convert.ToDecimal(base_calculo_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (reducao_bc == "" || reducao_bc == null)
                    {
                        Item.Reducao_BC = 0;
                    }
                    else
                    {
                        if (reducao_bc.Contains("."))
                        {
                            Item.Reducao_BC = Convert.ToDecimal(reducao_bc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Reducao_BC = Convert.ToDecimal(reducao_bc.Replace(",", "."));
                        }
                    }
                    //
                    if (um == "UNID" || um == "UND")
                    {
                        Item.UM = "'UN'";
                    }
                    else if (um == "PCT")
                    {
                        Item.UM = "'PC'";
                    }
                    else
                    {
                        Item.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    }
                   
                    //
                    if (total_aprox_trib == "" || total_aprox_trib == null)
                    {
                        Item.Total_Aprox_Tributos = 0;
                    }
                    else
                    {
                        if (total_aprox_trib.Contains("."))
                        {
                            Item.Total_Aprox_Tributos = Convert.ToDecimal(total_aprox_trib.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Total_Aprox_Tributos = Convert.ToDecimal(total_aprox_trib.Replace(",", "."));
                        }
                    }
                    //
                    if (aliquota_ipi == "" || aliquota_ipi == null)
                    {
                        Item.Aliquota_IPI = 0;
                    }
                    else
                    {
                        if (aliquota_ipi.Contains("."))
                        {
                            Item.Aliquota_IPI = Convert.ToDecimal(aliquota_ipi.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Aliquota_IPI = Convert.ToDecimal(aliquota_ipi.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_ipi == "" || valor_ipi == null)
                    {
                        Item.Valor_IPI = 0;
                    }
                    else
                    {
                        if (valor_ipi.Contains("."))
                        {
                            Item.Valor_IPI = Convert.ToDecimal(valor_ipi.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_IPI = Convert.ToDecimal(valor_ipi.Replace(",", "."));
                        }
                    }
                    //
                    if (reducao_bc_st == "" || reducao_bc_st == null)
                    {
                        Item.Reducao_BC_ST = 0;
                    }
                    else
                    {
                        if (reducao_bc_st.Contains("."))
                        {
                            Item.Reducao_BC_ST = Convert.ToDecimal(reducao_bc_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Reducao_BC_ST = Convert.ToDecimal(reducao_bc_st.Replace(",", "."));
                        }
                    }
                    //
                    Item.CST_IBS_CBS = cst_ibs_cbs.Insert(cst_ibs_cbs.Length, "'").Insert(0, "'");
                    //
                    Item.CClass_Trib = cclass_trib.Insert(cclass_trib.Length, "'").Insert(0, "'");
                    //
                    if (aliq_ibs_mun.Contains("."))
                    {
                        Item.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_ibs_est.Contains("."))
                    {
                        Item.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_cbs.Contains("."))
                    {
                        Item.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (valor_frete == "" || valor_frete == null)
                    {
                        Item.Valor_Frete = 0;
                    }
                    else
                    {
                        if (valor_frete.Contains("."))
                        {
                            Item.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    con.Salvar_Item_DFe(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static bool Val_Referencia_Chave_Alt_Temp(string codigo, string chave_dfe)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ReferenciaDFe_Temp Ref = new ReferenciaDFe_Temp())
                {
                    Ref.Codigo = Convert.ToInt16(codigo);
                    Ref.Chave_DFe = chave_dfe;
                    if (con.Val_Referencia_Chave_Alt_Temp(Ref) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Referencia_Chave_Alt_Temp(Ref) == 0)
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

        public static bool Val_Referencia_Chave_Alt(string codigo, string chave_dfe, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ReferenciaDFe Ref = new ReferenciaDFe())
                {
                    Ref.Codigo = Convert.ToInt16(codigo);
                    Ref.Chave_DFe = chave_dfe;
                    Ref.Cod_DFe = Convert.ToInt32(cod_dfe);
                    if (con.Val_Referencia_Chave_Alt(Ref) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Referencia_Chave_Alt(Ref) == 0)
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

        public static void Excluir_Referencia(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ReferenciaDFe Ref = new ReferenciaDFe())
                {
                    Ref.Codigo = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Referencia(Ref);
                }
            }
        }

        public static void Excluir_Referencia_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ReferenciaDFe_Temp Ref = new ReferenciaDFe_Temp())
                {
                    Ref.Codigo = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Referencia_Temp(Ref);
                }
            }
        }

        public static void Salvar_Referencia_Temp(string codigo, string chave_dfe, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ReferenciaDFe_Temp Ref = new ReferenciaDFe_Temp())
                {
                    Ref.Codigo = Convert.ToInt16(Convert.ToInt32(codigo) + 1);

                    Ref.Chave_DFe = chave_dfe.Insert(chave_dfe.Length, "'").Insert(0, "'");
                    //
                    Ref.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Salvar_Referencia_Temp(Ref);
                }
            }
        }

        public static void Salvar_Referencia(string codigo, string chave_dfe, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ReferenciaDFe Ref = new ReferenciaDFe())
                {
                    Ref.Cod_Item_Referencia = Convert.ToInt16(Convert.ToInt32(codigo) + 1);

                    Ref.Chave_DFe = chave_dfe.Insert(chave_dfe.Length, "'").Insert(0, "'");
                    //
                    Ref.Cod_DFe = Convert.ToInt32(cod_dfe);
                    //
                    con.Salvar_Referencia(Ref);
                }
            }
        }

        public static void Salvar_Referencia_DFe(string cod_item_referencia, string chave_dfe, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ReferenciaDFe Ref = new ReferenciaDFe())
                {
                    Ref.Cod_Item_Referencia = Convert.ToInt16(cod_item_referencia);
                    //
                    Ref.Chave_DFe = chave_dfe.Insert(chave_dfe.Length, "'").Insert(0, "'");
                    //
                    Ref.Cod_DFe = Convert.ToInt32(cod_dfe);
                    //
                    con.Salvar_Referencia_DFe(Ref);
                }
            }
        }

        public static void Alterar_Referencia(string codigo, string chave_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ReferenciaDFe Ref = new ReferenciaDFe())
                {
                    Ref.Codigo = Convert.ToInt16(codigo);
                    //
                    Ref.Chave_DFe = chave_dfe.Insert(chave_dfe.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Referencia(Ref);
                }
            }
        }

        public static void Alterar_Dados_Cons_Presenca_DFe(string codigo, bool consumidor_final, string tipo_operacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.Codigo = Convert.ToInt16(codigo);
                    //
                    if (consumidor_final == false)
                    {
                        NFe.Consumidor_Final = 0;
                    }
                    else
                    {
                        NFe.Consumidor_Final = Convert.ToByte(consumidor_final);
                    }
                    //
                    if (tipo_operacao == "" || tipo_operacao == null)
                    {
                        NFe.Tipo_Operacao = "null";
                    }
                    else
                    {
                        NFe.Tipo_Operacao = tipo_operacao.Insert(tipo_operacao.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Alterar_Dados_Cons_Presenca_DFe(NFe);
                }
            }
        }

        public static void Alterar_Referencia_Temp(string codigo, string chave_dfe, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ReferenciaDFe_Temp Ref = new ReferenciaDFe_Temp())
                {
                    Ref.Codigo = Convert.ToInt16(codigo);
                    //
                    Ref.Chave_DFe = chave_dfe.Insert(chave_dfe.Length, "'").Insert(0, "'");
                    //
                    Ref.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Alterar_Referencia_Temp(Ref);
                }
            }
        }

        public static DataTable Sel_Referencia_DFe_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ReferenciaDFe_Temp Ref = new ReferenciaDFe_Temp())
                {
                    Ref.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    return con.Sel_Referencia_DFe_Temp(Ref);
                }
            }
        }

        public static bool Val_Referencia_Chave_Temp(string chave_dfe)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ReferenciaDFe_Temp Ref = new ReferenciaDFe_Temp())
                {
                    Ref.Chave_DFe = chave_dfe;
                    return con.Val_Referencia_Chave_Temp(Ref);
                }
            }
        }

        public static bool Val_Referencia_Chave(string chave_dfe, string cod_dfe)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ReferenciaDFe Ref = new ReferenciaDFe())
                {
                    Ref.Chave_DFe = chave_dfe;
                    Ref.Cod_DFe = Convert.ToInt32(cod_dfe);
                    return con.Val_Referencia_Chave(Ref);
                }
            }
        }

        public static void Salvar_Items_Temp(string item, string produto, string ncm, string cest, string cst, string aliquota_icms, string csosn, string cfop, string quantidade, string quantidade_embalagem, string valor_total, string preco_valor_unitario, string valor_desconto, string valor_acrescimo, string valor_total_real, string valor_icms, string valor_base_calculo, string cod_conexao_configuracoes, string valor_icms_st, string aliquota_icms_st, string mva, string base_calculo_icms_st, string reducao_bc, string um, string total_aprox_trib, string valor_ipi, string aliquota_ipi, string reducao_bc_st, string cst_ibs_cbs, string cclass_trib, string aliq_ibs_mun, string aliq_ibs_est, string aliq_cbs, string valor_frete)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Temp Item = new Item_DFe_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Item = Convert.ToInt16(Convert.ToInt32(item) + 1);
                    //
                    string[] items = produto.Split('—');
                    Item.Cod_Produto = Convert.ToInt32(items[0]);
                    //
                    Item.Descricao = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Item.NCM = ncm.Insert(ncm.Length, "'").Insert(0, "'");
                    //
                    if (cst == "" || cst == null)
                    {
                        Item.CST = "null";
                    }
                    else
                    {
                        Item.CST = cst.Insert(cst.Length, "'").Insert(0, "'");
                    }
                    //
                    if (aliquota_icms.Contains("."))
                    {
                        Item.Aliquota = Convert.ToDecimal(aliquota_icms.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliquota = Convert.ToDecimal(aliquota_icms.Replace(",", "."));
                    }
                    //
                    if (csosn == "" || csosn == null)
                    {
                        Item.CSOSN = "null";
                    }
                    else
                    {
                        Item.CSOSN = csosn.Insert(csosn.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cest == "" || cest == null)
                    {
                        Item.CEST = "null";
                    }
                    else
                    {
                        Item.CEST = cest.Insert(cest.Length, "'").Insert(0, "'");
                    }
                    //
                    Item.CFOP = cfop.Insert(cfop.Length, "'").Insert(0, "'");
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
                    if (quantidade_embalagem.Contains("."))
                    {
                        Item.Quantidade_Embalagem = Convert.ToDecimal(quantidade_embalagem.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Quantidade_Embalagem = Convert.ToDecimal(quantidade_embalagem.Replace(",", "."));
                    }
                    //
                    if (preco_valor_unitario.Contains("."))
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(preco_valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(preco_valor_unitario.Replace(",", "."));
                    }
                    //
                    if (valor_total.Contains("."))
                    {
                        Item.Total = Convert.ToDecimal(valor_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Total = Convert.ToDecimal(valor_total.Replace(",", "."));
                    }
                    //
                    if (valor_desconto == "" || valor_desconto == null)
                    {
                        Item.Valor_Desconto = 0;
                    }
                    else
                    {
                        if (valor_desconto.Contains("."))
                        {
                            Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_acrescimo == "" || valor_acrescimo == null)
                    {
                        Item.Valor_Acrescimo = 0;
                    }
                    else
                    {
                        if (valor_acrescimo.Contains("."))
                        {
                            Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_total_real.Contains("."))
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total_real.Replace(",", "."));
                    }
                    //
                    if (valor_base_calculo.Contains("."))
                    {
                        Item.Valor_Base_Calculo = Convert.ToDecimal(valor_base_calculo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Base_Calculo = Convert.ToDecimal(valor_base_calculo.Replace(",", "."));
                    }
                    //
                    if (valor_icms.Contains("."))
                    {
                        Item.Valor_Icms = Convert.ToDecimal(valor_icms.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Icms = Convert.ToDecimal(valor_icms.Replace(",", "."));
                    }
                    //
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    if (valor_icms_st == "" || valor_icms_st == null)
                    {
                        Item.Valor_Icms_St = 0;
                    }
                    else
                    {
                        if (valor_icms_st.Contains("."))
                        {
                            Item.Valor_Icms_St = Convert.ToDecimal(valor_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Icms_St = Convert.ToDecimal(valor_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (aliquota_icms_st == "" || aliquota_icms_st == null)
                    {
                        Item.Aliquota_ST = 0;
                    }
                    else
                    {
                        if (aliquota_icms_st.Contains("."))
                        {
                            Item.Aliquota_ST = Convert.ToDecimal(aliquota_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Aliquota_ST = Convert.ToDecimal(aliquota_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (mva == "" || mva == null)
                    {
                        Item.MVA = 0;
                    }
                    else
                    {
                        if (mva.Contains("."))
                        {
                            Item.MVA = Convert.ToDecimal(mva.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.MVA = Convert.ToDecimal(mva.Replace(",", "."));
                        }
                    }
                    //
                    if (base_calculo_icms_st == "" || base_calculo_icms_st == null)
                    {
                        Item.Valor_Base_Calculo_St = 0;
                    }
                    else
                    {
                        if (base_calculo_icms_st.Contains("."))
                        {
                            Item.Valor_Base_Calculo_St = Convert.ToDecimal(base_calculo_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Base_Calculo_St = Convert.ToDecimal(base_calculo_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (reducao_bc == "" || reducao_bc == null)
                    {
                        Item.Reducao_BC = 0;
                    }
                    else
                    {
                        if (reducao_bc.Contains("."))
                        {
                            Item.Reducao_BC = Convert.ToDecimal(reducao_bc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Reducao_BC = Convert.ToDecimal(reducao_bc.Replace(",", "."));
                        }
                    }
                    //
                    Item.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (total_aprox_trib == "" || total_aprox_trib == null)
                    {
                        Item.Total_Aprox_Trib = 0;
                    }
                    else
                    {
                        if (total_aprox_trib.Contains("."))
                        {
                            Item.Total_Aprox_Trib = Convert.ToDecimal(total_aprox_trib.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Total_Aprox_Trib = Convert.ToDecimal(total_aprox_trib.Replace(",", "."));
                        }
                    }
                    //
                    if (aliquota_ipi == "" || aliquota_ipi == null)
                    {
                        Item.Aliquota_IPI = 0;
                    }
                    else
                    {
                        if (aliquota_ipi.Contains("."))
                        {
                            Item.Aliquota_IPI = Convert.ToDecimal(aliquota_ipi.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Aliquota_IPI = Convert.ToDecimal(aliquota_ipi.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_ipi == "" || valor_ipi == null)
                    {
                        Item.Valor_IPI = 0;
                    }
                    else
                    {
                        if (valor_ipi.Contains("."))
                        {
                            Item.Valor_IPI = Convert.ToDecimal(valor_ipi.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_IPI = Convert.ToDecimal(valor_ipi.Replace(",", "."));
                        }
                    }
                    //
                    if (reducao_bc_st == "" || reducao_bc_st == null)
                    {
                        Item.Reducao_BC_ST = 0;
                    }
                    else
                    {
                        if (reducao_bc_st.Contains("."))
                        {
                            Item.Reducao_BC_ST = Convert.ToDecimal(reducao_bc_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Reducao_BC_ST = Convert.ToDecimal(reducao_bc_st.Replace(",", "."));
                        }
                    }
                    //
                    Item.CST_IBS_CBS = cst_ibs_cbs.Insert(cst_ibs_cbs.Length, "'").Insert(0, "'");
                    //
                    Item.CClass_Trib = cclass_trib.Insert(cclass_trib.Length, "'").Insert(0, "'");
                    //
                    if (aliq_ibs_mun.Contains("."))
                    {
                        Item.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_ibs_est.Contains("."))
                    {
                        Item.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_cbs.Contains("."))
                    {
                        Item.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (valor_frete == "" || valor_frete == null)
                    {
                        Item.Valor_Frete = 0;
                    }
                    else
                    {
                        if (valor_frete.Contains("."))
                        {
                            Item.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    con.Salvar_Item_DFe_Temp(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Items(string item, string produto, string ncm, string cest, string cst, string aliquota_icms, string csosn, string cfop, string quantidade, string quantidade_embalagem, string valor_total, string preco_valor_unitario, string valor_desconto, string valor_acrescimo, string valor_total_real, string valor_icms, string valor_base_calculo, string cod_dfe, string valor_icms_st, string aliquota_icms_st, string mva, string base_calculo_icms_st, string reducao_bc, string um, string total_aprox_trib, string aliquota_ipi, string valor_ipi, string reducao_bc_st, string cst_ibs_cbs, string cclass_trib, string aliq_ibs_mun, string aliq_ibs_est, string aliq_cbs, string valor_frete)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_DFe Item = new Item_DFe())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Item = Convert.ToInt16(item);
                    //
                    string[] items = produto.Split('—');
                    Item.Cod_Produto = Convert.ToInt32(items[0]);
                    //
                    Item.Descricao = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Item.NCM = ncm.Insert(ncm.Length, "'").Insert(0, "'");
                    //
                    Item.CST = cst.Insert(cst.Length, "'").Insert(0, "'");
                    //
                    if (aliquota_icms.Contains("."))
                    {
                        Item.Aliquota = Convert.ToDecimal(aliquota_icms.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliquota = Convert.ToDecimal(aliquota_icms.Replace(",", "."));
                    }
                    //
                    Item.CSOSN = csosn.Insert(csosn.Length, "'").Insert(0, "'");
                    //
                    if (cest == "")
                    {
                        Item.CEST = "null";
                    }
                    else
                    {
                        Item.CEST = cest.Insert(cest.Length, "'").Insert(0, "'");
                    }
                    //
                    Item.CFOP = cfop.Insert(cfop.Length, "'").Insert(0, "'");
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
                    if (quantidade_embalagem.Contains("."))
                    {
                        Item.Quantidade_Embalagem = Convert.ToDecimal(quantidade_embalagem.Replace(".", "").Replace(",", "."));

                    }
                    else
                    {
                        Item.Quantidade_Embalagem = Convert.ToDecimal(quantidade_embalagem.Replace(",", "."));
                    }
                    //
                    if (preco_valor_unitario.Contains("."))
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(preco_valor_unitario.Replace(".", "").Replace(",", "."));

                    }
                    else
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(preco_valor_unitario.Replace(",", "."));
                    }
                    //
                    if (valor_total.Contains("."))
                    {
                        Item.Total = Convert.ToDecimal(valor_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Total = Convert.ToDecimal(valor_total.Replace(",", "."));
                    }
                    //
                    if (valor_desconto == "" || valor_desconto == null)
                    {
                        Item.Valor_Desconto = 0;
                    }
                    else
                    {
                        if (valor_desconto.Contains("."))
                        {
                            Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_acrescimo == "" || valor_acrescimo == null)
                    {
                        Item.Valor_Acrescimo = 0;
                    }
                    else
                    {
                        if (valor_acrescimo.Contains("."))
                        {
                            Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_total_real.Contains("."))
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total_real.Replace(",", "."));
                    }
                    //
                    if (valor_base_calculo.Contains("."))
                    {
                        Item.Valor_Base_Calculo = Convert.ToDecimal(valor_base_calculo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Base_Calculo = Convert.ToDecimal(valor_base_calculo.Replace(",", "."));
                    }
                    //
                    if (valor_icms.Contains("."))
                    {
                        Item.Valor_Icms = Convert.ToDecimal(valor_icms.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Icms = Convert.ToDecimal(valor_icms.Replace(",", "."));
                    }
                    //
                    Item.Cod_Dfe = Convert.ToInt32(cod_dfe);
                    //
                    if (valor_icms_st == "" || valor_icms_st == null)
                    {
                        Item.Valor_Icms_St = 0;
                    }
                    else
                    {
                        if (valor_icms_st.Contains("."))
                        {
                            Item.Valor_Icms_St = Convert.ToDecimal(valor_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Icms_St = Convert.ToDecimal(valor_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (aliquota_icms_st == "" || aliquota_icms_st == null)
                    {
                        Item.Aliquota_ST = 0;
                    }
                    else
                    {
                        if (aliquota_icms_st.Contains("."))
                        {
                            Item.Aliquota_ST = Convert.ToDecimal(aliquota_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Aliquota_ST = Convert.ToDecimal(aliquota_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (mva == "" || mva == null)
                    {
                        Item.MVA = 0;
                    }
                    else
                    {
                        if (mva.Contains("."))
                        {
                            Item.MVA = Convert.ToDecimal(mva.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.MVA = Convert.ToDecimal(mva.Replace(",", "."));
                        }
                    }
                    //
                    if (base_calculo_icms_st == "" || base_calculo_icms_st == null)
                    {
                        Item.Valor_Base_Calculo_St = 0;
                    }
                    else
                    {
                        if (base_calculo_icms_st.Contains("."))
                        {
                            Item.Valor_Base_Calculo_St = Convert.ToDecimal(base_calculo_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Base_Calculo_St = Convert.ToDecimal(base_calculo_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (reducao_bc == "" || reducao_bc == null)
                    {
                        Item.Reducao_BC = 0;
                    }
                    else
                    {
                        if (reducao_bc.Contains("."))
                        {
                            Item.Reducao_BC = Convert.ToDecimal(reducao_bc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Reducao_BC = Convert.ToDecimal(reducao_bc.Replace(",", "."));
                        }
                    }
                    //
                    Item.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (total_aprox_trib == "" || total_aprox_trib == null)
                    {
                        Item.Total_Aprox_Tributos = 0;
                    }
                    else
                    {
                        if (total_aprox_trib.Contains("."))
                        {
                            Item.Total_Aprox_Tributos = Convert.ToDecimal(total_aprox_trib.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Total_Aprox_Tributos = Convert.ToDecimal(total_aprox_trib.Replace(",", "."));
                        }
                    }
                    //
                    if (aliquota_ipi == "" || aliquota_ipi == null)
                    {
                        Item.Aliquota_IPI = 0;
                    }
                    else
                    {
                        if (aliquota_ipi.Contains("."))
                        {
                            Item.Aliquota_IPI = Convert.ToDecimal(aliquota_ipi.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Aliquota_IPI = Convert.ToDecimal(aliquota_ipi.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_ipi == "" || valor_ipi == null)
                    {
                        Item.Valor_IPI = 0;
                    }
                    else
                    {
                        if (valor_ipi.Contains("."))
                        {
                            Item.Valor_IPI = Convert.ToDecimal(valor_ipi.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_IPI = Convert.ToDecimal(valor_ipi.Replace(",", "."));
                        }
                    }
                    //
                    if (reducao_bc_st == "" || reducao_bc_st == null)
                    {
                        Item.Reducao_BC_ST = 0;
                    }
                    else
                    {
                        if (reducao_bc_st.Contains("."))
                        {
                            Item.Reducao_BC_ST = Convert.ToDecimal(reducao_bc_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Reducao_BC_ST = Convert.ToDecimal(reducao_bc_st.Replace(",", "."));
                        }
                    }
                    //
                    Item.CST_IBS_CBS = cst_ibs_cbs.Insert(cst_ibs_cbs.Length, "'").Insert(0, "'");
                    //
                    Item.CClass_Trib = cclass_trib.Insert(cclass_trib.Length, "'").Insert(0, "'");
                    //
                    if (aliq_ibs_mun.Contains("."))
                    {
                        Item.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_ibs_est.Contains("."))
                    {
                        Item.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_cbs.Contains("."))
                    {
                        Item.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (valor_frete == "" || valor_frete == null)
                    {
                        Item.Valor_Frete = 0;
                    }
                    else
                    {
                        if (valor_frete.Contains("."))
                        {
                            Item.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    con.Alterar_Item_DFe(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Items_Temp(string item, string produto, string ncm, string cest, string cst, string aliquota_icms, string csosn, string cfop, string quantidade, string quantidade_embalagem, string valor_total, string preco_valor_unitario, string valor_desconto, string valor_acrescimo, string valor_total_real, string valor_icms, string valor_base_calculo, string cod_conexao_configuracoes, string valor_icms_st, string aliquota_icms_st, string mva, string base_calculo_icms_st, string reducao_bc, string um, string total_trib_aprox, string valor_ipi, string aliquota_ipi, string reducao_bc_st, string cst_ibs_cbs, string cclass_trib, string aliq_ibs_mun, string aliq_ibs_est, string aliq_cbs, string valor_frete)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_DFe_Temp Item = new Item_DFe_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Item = Convert.ToInt16(item);
                    //
                    string[] items = produto.Split('—');
                    Item.Cod_Produto = Convert.ToInt32(items[0]);
                    //
                    Item.Descricao = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Item.NCM = ncm.Insert(ncm.Length, "'").Insert(0, "'");
                    //
                    Item.CST = cst.Insert(cst.Length, "'").Insert(0, "'");
                    //
                    if (aliquota_icms.Contains("."))
                    {
                        Item.Aliquota = Convert.ToDecimal(aliquota_icms.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliquota = Convert.ToDecimal(aliquota_icms.Replace(",", "."));
                    }
                    //
                    Item.CSOSN = csosn.Insert(csosn.Length, "'").Insert(0, "'");
                    //
                    if (cest == "")
                    {
                        Item.CEST = "null";
                    }
                    else
                    {
                        Item.CEST = cest.Insert(cest.Length, "'").Insert(0, "'");
                    }
                    //
                    Item.CFOP = cfop.Insert(cfop.Length, "'").Insert(0, "'");
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
                    if (quantidade_embalagem.Contains("."))
                    {
                        Item.Quantidade_Embalagem = Convert.ToDecimal(quantidade_embalagem.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Quantidade_Embalagem = Convert.ToDecimal(quantidade_embalagem.Replace(",", "."));
                    }
                    //
                    if (preco_valor_unitario.Contains("."))
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(preco_valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Unitario = Convert.ToDecimal(preco_valor_unitario.Replace(",", "."));
                    }
                    //
                    if (valor_total.Contains("."))
                    {
                        Item.Total = Convert.ToDecimal(valor_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Total = Convert.ToDecimal(valor_total.Replace(",", "."));
                    }
                    //
                    if (valor_desconto == "" || valor_desconto == null)
                    {
                        Item.Valor_Desconto = 0;
                    }
                    else
                    {
                        if (valor_desconto.Contains("."))
                        {
                            Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_acrescimo == "" || valor_acrescimo == null)
                    {
                        Item.Valor_Acrescimo = 0;
                    }
                    else
                    {
                        if (valor_acrescimo.Contains("."))
                        {
                            Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_total_real.Contains("."))
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Total = Convert.ToDecimal(valor_total_real.Replace(",", "."));
                    }
                    //
                    if (valor_base_calculo.Contains("."))
                    {
                        Item.Valor_Base_Calculo = Convert.ToDecimal(valor_base_calculo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Base_Calculo = Convert.ToDecimal(valor_base_calculo.Replace(",", "."));
                    }
                    //
                    if (valor_icms.Contains("."))
                    {
                        Item.Valor_Icms = Convert.ToDecimal(valor_icms.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Icms = Convert.ToDecimal(valor_icms.Replace(",", "."));
                    }
                    //
                    Item.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    if (valor_icms_st.Contains("."))
                    {
                        Item.Valor_Icms_St = Convert.ToDecimal(valor_icms_st.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Valor_Icms_St = Convert.ToDecimal(valor_icms_st.Replace(",", "."));
                    }
                    //
                    if (valor_icms_st == "" || valor_icms_st == null)
                    {
                        Item.Valor_Icms_St = 0;
                    }
                    else
                    {
                        if (valor_icms_st.Contains("."))
                        {
                            Item.Valor_Icms_St = Convert.ToDecimal(valor_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Icms_St = Convert.ToDecimal(valor_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (aliquota_icms_st == "" || aliquota_icms_st == null)
                    {
                        Item.Aliquota_ST = 0;
                    }
                    else
                    {
                        if (aliquota_icms_st.Contains("."))
                        {
                            Item.Aliquota_ST = Convert.ToDecimal(aliquota_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Aliquota_ST = Convert.ToDecimal(aliquota_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (mva == "" || mva == null)
                    {
                        Item.MVA = 0;
                    }
                    else
                    {
                        if (mva.Contains("."))
                        {
                            Item.MVA = Convert.ToDecimal(mva.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.MVA = Convert.ToDecimal(mva.Replace(",", "."));
                        }
                    }
                    //
                    if (base_calculo_icms_st == "" || base_calculo_icms_st == null)
                    {
                        Item.Valor_Base_Calculo_St = 0;
                    }
                    else
                    {
                        if (base_calculo_icms_st.Contains("."))
                        {
                            Item.Valor_Base_Calculo_St = Convert.ToDecimal(base_calculo_icms_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Base_Calculo_St = Convert.ToDecimal(base_calculo_icms_st.Replace(",", "."));
                        }
                    }
                    //
                    if (reducao_bc == "" || reducao_bc == null)
                    {
                        Item.Reducao_BC = 0;
                    }
                    else
                    {
                        if (reducao_bc.Contains("."))
                        {
                            Item.Reducao_BC = Convert.ToDecimal(reducao_bc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Reducao_BC = Convert.ToDecimal(reducao_bc.Replace(",", "."));
                        }
                    }
                    //
                    Item.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (total_trib_aprox == "" || total_trib_aprox == null)
                    {
                        Item.Total_Aprox_Trib = 0;
                    }
                    else
                    {
                        if (total_trib_aprox.Contains("."))
                        {
                            Item.Total_Aprox_Trib = Convert.ToDecimal(total_trib_aprox.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Total_Aprox_Trib = Convert.ToDecimal(total_trib_aprox.Replace(",", "."));
                        }
                    }
                    //
                    if (aliquota_ipi == "" || aliquota_ipi == null)
                    {
                        Item.Aliquota_IPI = 0;
                    }
                    else
                    {
                        if (aliquota_ipi.Contains("."))
                        {
                            Item.Aliquota_IPI = Convert.ToDecimal(aliquota_ipi.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Aliquota_IPI = Convert.ToDecimal(aliquota_ipi.Replace(",", "."));
                        }
                    }
                    //
                    if (valor_ipi == "" || valor_ipi == null)
                    {
                        Item.Valor_IPI = 0;
                    }
                    else
                    {
                        if (valor_ipi.Contains("."))
                        {
                            Item.Valor_IPI = Convert.ToDecimal(valor_ipi.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_IPI = Convert.ToDecimal(valor_ipi.Replace(",", "."));
                        }
                    }
                    //
                    if (reducao_bc_st == "" || reducao_bc_st == null)
                    {
                        Item.Reducao_BC_ST = 0;
                    }
                    else
                    {
                        if (reducao_bc.Contains("."))
                        {
                            Item.Reducao_BC_ST = Convert.ToDecimal(reducao_bc_st.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Reducao_BC_ST = Convert.ToDecimal(reducao_bc_st.Replace(",", "."));
                        }
                    }
                    //
                    Item.CST_IBS_CBS = cst_ibs_cbs.Insert(cst_ibs_cbs.Length, "'").Insert(0, "'");
                    //
                    Item.CClass_Trib = cclass_trib.Insert(cclass_trib.Length, "'").Insert(0, "'");
                    //
                    if (aliq_ibs_mun.Contains("."))
                    {
                        Item.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_ibs_est.Contains("."))
                    {
                        Item.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_cbs.Contains("."))
                    {
                        Item.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (valor_frete == "" || valor_frete == null)
                    {
                        Item.Valor_Frete = 0;
                    }
                    else
                    {
                        if (valor_frete.Contains("."))
                        {
                            Item.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Item.Valor_Frete = Convert.ToDecimal(valor_frete.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    con.Alterar_Item_DFe_Temp(Item);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void GerarDANFE(string cod_dfe, string cod_pdv_computador, bool tipoimpiressao) 
        {
            ACBrNFe ACBrNFe;
            if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
            {
                ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
            }
            else
            {
                ACBrNFe = new ACBrNFe();
            }
            //
            DataRow drDFe = bllDFe.Sel_Nfe_Codigo(cod_dfe).Rows[0];
            //
            bool xml_salvo;
            if (bllXML.Sel_Dados_XML(cod_dfe) != null)
            {
                xml_salvo = true;
            }
            else
            {
                xml_salvo = false;
            }
            //
            bool simplificado = false;
            if (drDFe["modelo"].ToString() == "65")
            {
                ACBrNFe.Config.DANFe.NFCe.MargemEsquerda = Convert.ToInt32(bllConfiguracaoSistema.Sel_Margem_Esq_NFCe(bllConexao._Codigo_Conexao));
                ACBrNFe.Config.DANFe.NFCe.MargemDireita = Convert.ToInt32(bllConfiguracaoSistema.Sel_Margem_Dir_NFCe(bllConexao._Codigo_Conexao));
                ACBrNFe.Config.DANFe.NFCe.ImprimeQRCodeLateral = true;
                //
                if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "A4(Mostrar na Tela)")
                {
                    ACBrNFe.Config.DANFe.NFCe.TipoRelatorioBobina = TipoRelatorioBobina.tpFortesA4;
                }
                else
                {
                    ACBrNFe.Config.DANFe.NFCe.TipoRelatorioBobina = TipoRelatorioBobina.tpFortes;
                }
            }
            else
            {
                if (tipoimpiressao == false)
                {
                    simplificado = true;
                }
                else if (tipoimpiressao == true)
                {
                    simplificado = false;
                }
            }
            //
            if (File.Exists(drDFe["caminho_dfe"].ToString()) == true & drDFe["situacao"].ToString() == "PENDENTE")
            {
                if (drDFe["modelo"].ToString() == "55")
                {
                    ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                    //
                    if (simplificado == true)
                    {
                        ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true, bSimplificado: true);
                    }
                    else
                    {
                        ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true);
                    }
                    //
                    ACBrNFe.Dispose();
                    ACBrNFe = null;
                }
                else
                {
                    ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                    //
                    ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true);
                    //
                    ACBrNFe.Dispose();
                    ACBrNFe = null;
                }
            }
            else if (!File.Exists(drDFe["caminho_dfe"].ToString()) == true & drDFe["situacao"].ToString() == "PENDENTE" & xml_salvo == true)
            {
                DataRow drXML = bllXML.Sel_Dados_XML(cod_dfe).Rows[0];
                //
                string caminho;
                if (drDFe["caminho_dfe"].ToString() == null || drDFe["caminho_dfe"].ToString() == "")
                {
                    string modelo;
                    if (drDFe["modelo"].ToString() == "65")
                    {
                        modelo = "NFCe";
                    }
                    else
                    {
                        modelo = "NFe";
                    }
                    //
                    caminho = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\" + modelo + drDFe["numero_nf"].ToString() + ".xml";
                    //
                    string[] diretorio = caminho.Split('\\');
                    //
                    if (!Directory.Exists(diretorio[0] + @"\" + diretorio[1] + @"\" + diretorio[2] + @"\" + diretorio[3]))
                    {
                        Directory.CreateDirectory(diretorio[0] + @"\" + diretorio[1] + @"\" + diretorio[2] + @"\" + diretorio[3]);
                    }
                    //
                    if (!drXML["texto_xml"].ToString().Contains("<?xml version="))
                    {
                        File.WriteAllText(caminho, drXML["texto_xml"].ToString().Insert(0, "<?xml version=\"1.0\" encoding=\"utf-8\"?>"), Encoding.UTF8);
                    }
                    else
                    {
                        File.WriteAllText(caminho, drXML["texto_xml"].ToString(), Encoding.UTF8);
                    }
                }
                else
                {
                    caminho = drDFe["caminho_dfe"].ToString();
                    //
                    string[] diretorio = caminho.Split('\\');
                    //
                    if (!Directory.Exists(diretorio[0] + @"\" + diretorio[1] + @"\" + diretorio[2] + @"\" + diretorio[3] + @"\" + diretorio[4] + @"\" + diretorio[5] + @"\" + diretorio[6]))
                    {
                        Directory.CreateDirectory(diretorio[0] + @"\" + diretorio[1] + @"\" + diretorio[2] + @"\" + diretorio[3] + @"\" + diretorio[4] + @"\" + diretorio[5] + @"\" + diretorio[6]);
                    }
                    //
                    if (!drXML["texto_xml"].ToString().Contains("<?xml version="))
                    {
                        File.WriteAllText(caminho, drXML["texto_xml"].ToString().Insert(0, "<?xml version=\"1.0\" encoding=\"utf-8\"?>"), Encoding.UTF8);
                    }
                    else
                    {
                        File.WriteAllText(caminho, drXML["texto_xml"].ToString(), Encoding.UTF8);
                    }
                }
                //
                ACBrNFe.CarregarXML(caminho);
                //
                if (simplificado == true)
                {
                    ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true, bSimplificado: true);
                }
                else
                {
                    ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true);
                }
                //
                ACBrNFe.Dispose();
                ACBrNFe = null;
            }
            else if (File.Exists(drDFe["caminho_dfe"].ToString()) == true & drDFe["situacao"].ToString() != "PENDENTE")
            {
                ACBrNFe.CarregarXML(drDFe["caminho_dfe"].ToString());
                //
                if (simplificado == true)
                {
                    ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true, bSimplificado: true);
                }
                else
                {
                    ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true);
                }
                //
                ACBrNFe.Dispose();
                ACBrNFe = null;
            }
            else if (!File.Exists(drDFe["caminho_dfe"].ToString()) == true & drDFe["situacao"].ToString() != "PENDENTE" & xml_salvo == true)
            {
                DataRow drXML = bllXML.Sel_Dados_XML(cod_dfe).Rows[0];
                //
                string caminho;
                if (drDFe["caminho_dfe"].ToString() == null || drDFe["caminho_dfe"].ToString() == "")
                {
                    string modelo;
                    if (drDFe["modelo"].ToString() == "65")
                    {
                        modelo = "NFCe";
                    }
                    else
                    {
                        modelo = "NFe";
                    }
                    //
                    caminho = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\" + modelo + drDFe["numero_nf"].ToString() + ".xml";
                    //
                    string[] diretorio = caminho.Split('\\');
                    //
                    if (!Directory.Exists(diretorio[0] + @"\" + diretorio[1] + @"\" + diretorio[2] + @"\" + diretorio[3]))
                    {
                        Directory.CreateDirectory(diretorio[0] + @"\" + diretorio[1] + @"\" + diretorio[2] + @"\" + diretorio[3]);
                    }
                    //
                    if (!drXML["texto_xml"].ToString().Contains("<?xml version="))
                    {
                        File.WriteAllText(caminho, drXML["texto_xml"].ToString().Insert(0, "<?xml version=\"1.0\" encoding=\"utf-8\"?>"), Encoding.UTF8);
                    }
                    else
                    {
                        File.WriteAllText(caminho, drXML["texto_xml"].ToString(), Encoding.UTF8);
                    }
                }
                else
                {
                    caminho = drDFe["caminho_dfe"].ToString();

                    string[] diretorio = caminho.Split('\\');
                    //
                    if (!Directory.Exists(diretorio[0] + @"\" + diretorio[1] + @"\" + diretorio[2] + @"\" + diretorio[3] + @"\" + diretorio[4] + @"\" + diretorio[5] + @"\" + diretorio[6])) 
                    {
                        Directory.CreateDirectory(diretorio[0] + @"\" + diretorio[1] + @"\" + diretorio[2] + @"\" + diretorio[3] + @"\" + diretorio[4] + @"\" + diretorio[5] + @"\" + diretorio[6]);
                    }
                    //
                    if (!drXML["texto_xml"].ToString().Contains("<?xml version="))
                    {
                        File.WriteAllText(caminho, drXML["texto_xml"].ToString().Insert(0, "<?xml version=\"1.0\" encoding=\"utf-8\"?>"), Encoding.UTF8);
                    }
                    else
                    {
                        File.WriteAllText(caminho, drXML["texto_xml"].ToString(), Encoding.UTF8);
                    }
                }
                //
                ACBrNFe.CarregarXML(caminho);
                //
                if (simplificado == true)
                {
                    ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true, bSimplificado: true);
                }
                else
                {
                    ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true);
                }
                //
                ACBrNFe.Dispose();
                ACBrNFe = null;
            }
            else
            {
                if (drDFe["modelo"].ToString() == "55")
                {
                    bllDFe.CriarDFeNFe(cod_dfe, cod_pdv_computador);
                    //
                    ACBrNFe.LimparLista();
                    //
                    ACBrNFe.CarregarINI(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\nfe" + drDFe["numero_nf"].ToString() + ".ini");
                    //
                    var ret = ACBrNFe.ObterXml(0);
                    //
                    string criararqxml = ret;
                    //
                    File.WriteAllText(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\nfe" + drDFe["numero_nf"].ToString() + ".xml", criararqxml, Encoding.UTF8);
                    //
                    ACBrNFe.CarregarXML(criararqxml);
                    if (simplificado == true)
                    {
                        ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true, bSimplificado: true);
                    }
                    else
                    {
                        ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true);
                    }
                    //
                    ACBrNFe.Dispose();
                    ACBrNFe = null;
                }
                else
                {
                    bllDFe.CriarDFeNFCe(cod_dfe, cod_pdv_computador, true);
                    //
                    ACBrNFe.LimparLista();
                    //
                    ACBrNFe.CarregarINI(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\nfce" + drDFe["numero_nf"].ToString() + ".ini");
                    //
                    var ret = ACBrNFe.ObterXml(0);
                    //
                    string criararqxml = ret;
                    //
                    File.WriteAllText(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\nfce" + drDFe["numero_nf"].ToString() + ".xml", criararqxml, Encoding.UTF8);
                    //
                    ACBrNFe.CarregarXML(criararqxml);
                    ACBrNFe.Imprimir(bMostrarPreview: true, nNumCopias: 1, bViaConsumidor: true);
                    //
                    ACBrNFe.Dispose();
                    ACBrNFe = null;
                }
            }
        }

        public static void Alterar(string codigo, string chave_acesso, string emissao, string modelo, string numero_nf, string serie, string data_emissao, string hora_emissao, string data_saida, string hora_saida, string emitente, string observacao, string total_produtos, string descontos, string frete, string despesas, string valor_total_nf, string natureza_operacao, string tipo_emitente, string seguro, string ipi, string finalidade, bool consumidor_final, string tipo_operacao, bool venda)
        {
            using (Con7BD con = new Con7BD())
            {
                using (DFE NFe = new DFE())
                {
                    NFe.Codigo = Convert.ToInt32(codigo);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (chave_acesso == "" || chave_acesso == "  -    -  .   .   /    -  -  -   -   .   .   - -  .   .   -" || chave_acesso == null)
                    {
                        NFe.Chave_DFe = "null";
                    }
                    else
                    {
                        NFe.Chave_DFe = chave_acesso.Insert(chave_acesso.Length, "'").Insert(0, "'");
                    }
                    //
                    if (emissao == null || emissao == "")
                    {
                        NFe.Emissao = "'TERCEIROS'";
                    }
                    else
                    {
                        NFe.Emissao = emissao.Insert(emissao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (modelo == "MODELO 55 (NFe)")
                    {
                        NFe.Modelo = "55";
                    }
                    else
                    {
                        NFe.Modelo = "65";
                    }
                    //
                    NFe.Numero_NF = Convert.ToInt32(numero_nf);
                    //
                    NFe.Serie = Convert.ToInt32(serie);
                    //
                    if (data_emissao == "" || data_emissao == "  /  /" || data_emissao == "__/__/____" || data_emissao == null)
                    {
                        NFe.Data_Emissao = "null";
                    }
                    else
                    {
                        if (hora_emissao == "" || hora_emissao == "  :  :" || hora_emissao == "__:__:__")
                        {
                            NFe.Data_Emissao = data_emissao.Insert(data_emissao.Length, "'").Insert(0, "'").Replace('/', '.');
                        }
                        else
                        {
                            NFe.Data_Emissao = "'" + data_emissao.Replace('/', '.') + " " + hora_emissao.Remove(5) + "'";
                        }
                    }
                    //
                    if (data_saida == "" || data_saida == "  /  /" || data_saida == "__/__/____" || data_saida == null)
                    {
                        NFe.Data_Saida = "null";
                    }
                    else
                    {
                        if (hora_saida == "" || hora_saida == "  :  :" || hora_saida == "__:__:__")
                        {
                            NFe.Data_Saida = data_saida.Insert(data_saida.Length, "'").Insert(0, "'").Replace('/', '.');
                        }
                        else
                        {
                            NFe.Data_Saida = "'" + data_saida.Replace('/', '.') + " " + hora_saida.Remove(5) + "'";
                        }
                    }
                    //
                    if (hora_emissao == "" || hora_emissao == "  :  :" || hora_emissao == "__:__:__" || hora_emissao == null)
                    {
                        NFe.Hora_Emissao = "null";
                    }
                    else
                    {
                        NFe.Hora_Emissao = hora_emissao.Insert(hora_emissao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (hora_saida == "" || hora_saida == "  :  :" || hora_saida == "__:__:__" || hora_saida == null)
                    {
                        NFe.Hora_Saida = "null";
                    }
                    else
                    {
                        NFe.Hora_Saida = hora_saida.Insert(hora_saida.Length, "'").Insert(0, "'");
                    }
                    //
                    NFe.Tipo_Emitente_Destinatario = tipo_emitente.Insert(tipo_emitente.Length, "'").Insert(0, "'");
                    //
                    string[] items;
                    //
                    if (emitente == "" || emitente == null)
                    {
                        NFe.Cod_Emitente_Destinatario = 0;
                        NFe.Nome_Emitente_Destinatario = "null";
                        NFe.CPF_CNPJ_Emitente_Destinatario = "0";
                    }
                    else
                    {
                        items = emitente.Split('—');
                        NFe.Cod_Emitente_Destinatario = Convert.ToInt32(items[0]);
                        NFe.Nome_Emitente_Destinatario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                        NFe.CPF_CNPJ_Emitente_Destinatario = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                    }
                    //
                    if (total_produtos.Contains("."))
                    {
                        NFe.Total_Produtos = Convert.ToDecimal(total_produtos.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        NFe.Total_Produtos = Convert.ToDecimal(total_produtos.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (descontos == "" || descontos == null)
                    {
                        NFe.Descontos = 0;
                    }
                    else
                    {
                        if (descontos.Contains("."))
                        {
                            NFe.Descontos = Convert.ToDecimal(descontos.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            NFe.Descontos = Convert.ToDecimal(descontos.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (frete == "" || frete == null)
                    {
                        NFe.Frete = 0;
                    }
                    else
                    {
                        if (descontos.Contains("."))
                        {
                            NFe.Frete = Convert.ToDecimal(frete.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            NFe.Frete = Convert.ToDecimal(frete.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (despesas == "" || despesas == null)
                    {
                        NFe.Despesas = 0;
                    }
                    else
                    {
                        if (despesas.Contains("."))
                        {
                            NFe.Despesas = Convert.ToDecimal(despesas.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            NFe.Despesas = Convert.ToDecimal(despesas.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (valor_total_nf.Contains("."))
                    {
                        NFe.Valor_Total_NF = Convert.ToDecimal(valor_total_nf.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        NFe.Valor_Total_NF = Convert.ToDecimal(valor_total_nf.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (observacao == "" || observacao == null)
                    {
                        NFe.Observacao = "null";
                    }
                    else
                    {
                        NFe.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (natureza_operacao == "" || natureza_operacao == null)
                    {
                        NFe.Descricao_CFOP = "null";
                    }
                    else
                    {
                        NFe.Descricao_CFOP = natureza_operacao.Insert(natureza_operacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (seguro == "" || seguro == null)
                    {
                        NFe.Seguro = 0;
                    }
                    else
                    {
                        if (seguro.Contains("."))
                        {
                            NFe.Seguro = Convert.ToDecimal(seguro.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            NFe.Seguro = Convert.ToDecimal(seguro.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (ipi == "" || ipi == null)
                    {
                        NFe.IPI = 0;
                    }
                    else
                    {
                        if (ipi.Contains("."))
                        {
                            NFe.IPI = Convert.ToDecimal(ipi.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            NFe.IPI = Convert.ToDecimal(ipi.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (finalidade == "" || finalidade == null)
                    {
                        NFe.Finalidade = "null";
                    }
                    else
                    {
                        NFe.Finalidade = finalidade.Insert(finalidade.Length, "'").Insert(0, "'");
                    }
                    //
                    if (consumidor_final == false)
                    {
                        NFe.Consumidor_Final = 0;
                    }
                    else
                    {
                        NFe.Consumidor_Final = Convert.ToByte(consumidor_final);
                    }
                    //
                    if (tipo_operacao == "" || tipo_operacao == null)
                    {
                        NFe.Tipo_Operacao = "null";
                    }
                    else
                    {
                        NFe.Tipo_Operacao = tipo_operacao.Insert(tipo_operacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (venda == false)
                    {
                        NFe.Origem_Venda = 0;
                    }
                    else
                    {
                        NFe.Origem_Venda = 1;
                    }
                    //
                    con.Alterar_DFe(NFe);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }
    }
}
