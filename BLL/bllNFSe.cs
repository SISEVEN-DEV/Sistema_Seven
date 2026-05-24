using DAL;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using ACBrLib.NFSe;

namespace BLL
{
    public class bllNFSe
    {
        public static bool _FrmMenuNFSe_Ativo;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;


        public static void Salvar(string cliente_consumidor, string preco, string serie, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (NFSE Nfse = new NFSE())
                {
                    Nfse.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Nfse.Serie = serie.Insert(serie.Length, "'").Insert(0, "'");
                    //
                    Nfse.Numero_NF = con.Sel_Dfe_Ultimo_Cod_NFSe_Adicionado() + 1;
                    //
                    string[] items = cliente_consumidor.Split('—');
                    Nfse.Cod_Consumidor = Convert.ToInt32(items[0]);
                    Nfse.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    Nfse.CPF_CNPJ_Consumidor = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                    //
                    if (preco.Contains("."))
                    {
                        Nfse.Preco = Convert.ToDecimal(preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Nfse.Preco = Convert.ToDecimal(preco.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    Nfse.Data_Emissao = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm") + "'";
                    //
                    Nfse.Hora_Emissao = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Nfse.Situacao = "'PENDENTE'";
                    //
                    Nfse.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    con.Salvar_NFSe(Nfse);
                }
                //
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
        }

        public static bool Sel_NFSe_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (NFSE Nfse = new NFSE())
                {
                    Nfse.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_NFSe_Ainda_Existe(Nfse);
                }
            }
        }

        public static void Salvar_Item_NFSE(string cod_item, string cod_servico, string descricao, string preco, string cod_item_servico, string aliquota, string cod_nfse)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_NFSe Item = new Item_NFSe())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Item.Cod_Item = Convert.ToInt32(cod_item);
                    //
                    Item.Cod_Servico = Convert.ToInt32(cod_servico);
                    //
                    Item.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (preco.Contains("."))
                    {
                        Item.Preco = Convert.ToDecimal(preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Preco = Convert.ToDecimal(preco.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    Item.Cod_Item_Servico = Convert.ToInt32(cod_item_servico);
                    //
                    if (aliquota.Contains("."))
                    {
                        Item.Aliquota = Convert.ToDecimal(aliquota.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Item.Aliquota = Convert.ToDecimal(aliquota.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    Item.Cod_NFSe = Convert.ToInt32(cod_nfse);
                    //
                    con.Salvar_Item_NFSe(Item);
                }
                //
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
        }

        public static int Sel_Ultima_NFSe()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ultima_NFSe();
            }
        }

        public static DataTable Sel_NFSe_Codigo(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (NFSE NFSe = new NFSE())
                {
                    NFSe.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_NFSe_Codigo(NFSe);
                }
            }
        }

        public static DataTable Sel_Item_NFSe_Codigo(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (NFSE NFSe = new NFSE())
                {
                    NFSe.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Item_NFSe_Codigo(NFSe);
                }
            }
        }

        public static DataTable Sel_NFSe_Menu_NFSe(string data_cad, string data_cad1, string horario_cad, string horario_cad1, string situacao, string numero, string codigo, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlEmissao;
                string SqlDataCadastro;
                string SqlSituacao;
                string SqlNumero;
                string SqlCodigo;
                string SqlCod_OS;
                //
                SqlEmissao = "WHERE numero_nf<>0";
                //
                if (data_cad.Contains("_") || data_cad1.Contains("_"))
                {
                    SqlDataCadastro = "";
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
                    SqlDataCadastro = " AND data_cadastro BETWEEN '" + data_cad.Replace("/", ".") + horario_cad + "' AND '" + data_cad1.Replace("/", ".") + horario_cad1 + "'";
                }
                //
                if (situacao == "" || situacao == null)
                {
                    SqlSituacao = "";
                }
                else
                {
                    SqlSituacao = " AND situacao='" + situacao + "'";
                }
                //
                if (numero == "" || numero == null)
                {
                    SqlNumero = "";
                }
                else
                {
                    SqlNumero = " AND numero_nf='" + numero + "'";
                }
                //
                if (codigo == "" || codigo == null)
                {
                    SqlCodigo = "";
                }
                else
                {
                    SqlCodigo = " AND id_nfse='" + codigo + "'";
                }
                //
                if (cod_os == "" || cod_os == null)
                {
                    SqlCod_OS = "";
                }
                else
                {
                    SqlCod_OS = " AND id_os='" + cod_os + "'";
                }
                //
                return con.Sel_NFSe_Menu_NFSe(SqlDataCadastro, SqlEmissao, SqlSituacao, SqlNumero, SqlCodigo, SqlCod_OS);
            }
        }

        public static string Calculo_Valor_ISS(string valor_base_calculo, string aliquota)
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

        public static void CriarNFSe(string cod_nfse, string cod_pdv_computador)
        {
            ACBrNFSe ACBrNFSe;
            if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfse.ini"))
            {
                ACBrNFSe = new ACBrNFSe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfse.ini");
            }
            else
            {
                ACBrNFSe = new ACBrNFSe();
            }
            //
            string[] items;
            //
            DataRow drNFSe = bllNFSe.Sel_NFSe_Codigo(cod_nfse).Rows[0];
            //
            DataRow drMinhaEmpresa = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
            //
            string criarini = null;
            //
            //IDENTIFICACAO NFSE
            string numero = drNFSe["numero_nf"].ToString();
            //
            //IDENTIFICACAO RPS
            //
            string situacaotrib = "tp";
            //
            string producao = "2";
            //
            string status = "1";
            //
            string outrasinformacoes = "Pagamento a Vista";
            //
            string tipotributacaorps = "T";
            //
            string serieprestacao = "";
            //
            numero = drNFSe["numero_nf"].ToString();
            //
            string serie = drNFSe["serie"].ToString();
            //
            string tipo = "1";
            //
            string dataemissao = drNFSe["data_emissao"].ToString().Remove(10);
            //
            string competencia = drNFSe["data_emissao"].ToString().Remove(10);
            //
            string naturezaoperacao = "1";
            //
            string percentualcargatributaria = "0";
            //
            string valorcargatributaria = "0";
            //
            string percentualcargatributariamunicipal = "0";
            //
            string valorcargatributariamunicipal = "0";
            //
            string percentualcargatributariaestadual = "0";
            //
            string valorcargatributariaestadual = "0";
            //
            string veraplic = null;
            items = cod_pdv_computador.Split('/');
            veraplic = "siseven " + items[0].Replace("Versão: ", "");
            //
            //PRESTADOR
            //
            string regime = "1";
            //
            string optantesn = null;
            if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL")
            {
                optantesn = "1";
            }
            else if (drMinhaEmpresa["CRT"].ToString() == "SIMPLES NACIONAL - MEI")
            {
                optantesn = "1";
            }
            //
            string incentivadorcultural = "2";
            //
            string cpfcnpj = drMinhaEmpresa["cpf_cnpj"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
            //
            string inscricaomunicipal = drMinhaEmpresa["inscricao_municipal"].ToString();
            //
            string nif = null;
            //
            string caepf = null;
            //
            string inscricaoestadual = drMinhaEmpresa["ie_rg"].ToString();
            //
            string razaosocial = drMinhaEmpresa["nome"].ToString();
            //
            string nomefantasia = drMinhaEmpresa["fantasia"].ToString();
            //
            string logradouro = drMinhaEmpresa["endereco"].ToString();
            //
            string numeroprestador = drMinhaEmpresa["numero"].ToString();
            //
            string complemento = drMinhaEmpresa["complemento"].ToString();
            //
            string bairro = drMinhaEmpresa["bairro"].ToString();
            //
            string codigomunicipio = drMinhaEmpresa["codigo_municipio"].ToString();
            //
            string uf = drMinhaEmpresa["uf"].ToString();
            //
            string codpais = "0";
            //
            string xpais = "BRASIL";
            //
            string cep = drMinhaEmpresa["cep"].ToString().Replace(".", "").Replace("-", "");
            //
            string telefone = null;
            if (drMinhaEmpresa["telefone"].ToString() != null)
            {
                telefone = drMinhaEmpresa["telefone"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace("_", "");
            }
            else
            {
                telefone = drMinhaEmpresa["celular"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace("_", "");
            }
            //
            string email = drMinhaEmpresa["email"].ToString();
            //
            //TOMADOR
            //
            DataRow drDestinatario = bllClieCons.Sel_Cliente_Codigo(drNFSe["id_consumidor"].ToString()).Rows[0];
            //
            string tipotomador = "1";
            //
            string cpfcnpjtomador = drDestinatario["cpf_cnpj"].ToString().Replace(".", "").Replace("-", "").Replace("/", ""); ;
            //
            string inscricaomunicipaltomador = null;
            //
            string niftomador = null;
            //
            string caepftomador = null;
            //
            string inscricaoestadualtomador = null;
            if (Convert.ToByte(drDestinatario["pessoa"]) == 1)
            {
                inscricaoestadualtomador = drDestinatario["ie_rg"].ToString();
            }
            //
            string razaosocialtomador = drDestinatario["nome"].ToString();
            //
            string tipologradourotomador = "RUA";
            //
            string logradourotomador = drDestinatario["endereco"].ToString();
            //
            string numerotomador = drDestinatario["numero"].ToString();
            //
            string complementotomador = drDestinatario["complemento"].ToString();
            //
            string bairrotomador = drDestinatario["bairro"].ToString();
            //
            string codigomunicipiotomador = drDestinatario["codigo_municipio"].ToString();
            //
            string xmunicipio = drDestinatario["cidade"].ToString();
            //
            string uftomador = drDestinatario["uf"].ToString();
            //
            string codigopaistomador = "0";
            //
            string ceptomador = drDestinatario["cep"].ToString().Replace(".", "").Replace("-", "");
            //
            string xpaistomador = "BRASIL";
            //
            string telefonetomador = null;
            if (drDestinatario["telefone"].ToString() != null)
            {
                telefonetomador = drDestinatario["telefone"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace("_", "");
            }
            else
            {
                telefonetomador = drDestinatario["celular"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace("_", "");
            }
            //
            string emailtomnador = drDestinatario["email"].ToString();
            //
            string atualizatomador = "2";
            //
            string tomadorexterior = "2";
            //
            //SERVICO
            //
            DataRow drServico = Sel_Item_NFSe_Codigo(cod_nfse).Rows[0];
            //
            string itemlistaservico = drServico["id_item_servico"].ToString();
            //
            string codigocnae = "";
            //
            string codigotributacaomunicipio = "";
            //
            string discriminacao = drServico["descricao"].ToString();
            //
            string codigomunicipioservico = drMinhaEmpresa["codigo_municipio"].ToString();
            //
            string codigopaisservico = "1058";
            //
            string exigibilidadeiss = "1";
            //
            string municipioincidencia = drMinhaEmpresa["codigo_municipio"].ToString();
            //
            string ufprestacaoservico = drMinhaEmpresa["uf"].ToString();
            //
            string responsavelretencao = "1";
            //
            string operacao = "A";
            //
            string tributacao = "C";
            //
            string codigonbs = null;
            //
            //VALORES
            //
            string valorservicos = drNFSe["total_servicos"].ToString();
            //
            string valordeducoes = "0";
            //
            string aliquotadeducoes = "0";
            //
            string valorpis = "0";
            //
            string aliquotapis = "0";
            //
            string valorcofins = "0";
            //
            string aliquotacofins = "0";
            //
            string valorinss = "0";
            //
            string valorir = "0";
            //
            string valorcsII = "0";
            //
            string issretido = "0";
            //
            string outrasretencoes = "0";
            //
            string descontoincondicionado = "0";
            //
            //string descontocondicionado = "0";
            //
            string basecalculo = drNFSe["total_servicos"].ToString();
            //
            string aliquota = drServico["aliquota"].ToString();
            //
            string aliquotasn = "0";
            //
            string valoriss = null;
            valoriss = Calculo_Valor_ISS(basecalculo, aliquota);
            //
            string valorissretido = "0";
            //
            string valorliquidonfse = drNFSe["total_servicos"].ToString();


            criarini = @"[IdentificacaoNFSe]
numero=" + numero + @"

[IdentificacaoRps]
SituacaoTrib=" + situacaotrib + @"
Producao=" + producao + @"
Status=" + status + @"
OutrasInformacoes=" + outrasinformacoes + @"
TipoTributacaoRps=" + tipotributacaorps + @"
SeriePrestacao=" + serieprestacao + @"
Numero=" + numero + @"
Serie=" + serie + @"
Tipo=" + tipo + @"
DataEmissao=" + dataemissao + @"
Competencia=" + competencia + @"
NaturezaOperacao=" + naturezaoperacao + @"
PercentualCargaTributaria=" + percentualcargatributaria + @"
ValorCargaTributaria=" + valorcargatributaria + @"
PercentualCargaTributariaMunicipal=" + percentualcargatributariamunicipal + @"
ValorCargaTributariaMunicipal=" + valorcargatributariamunicipal + @"
PercentualCargaTributariaEstadual=" + percentualcargatributariaestadual + @"
ValorCargaTributariaEstadual=" + valorcargatributariaestadual + @"
verAplic=" + veraplic + @"

[Prestador]
Regime=" + regime + @"
OptanteSN=" + optantesn + @"
IncentivadorCultural=" + incentivadorcultural + @"
CNPJ=" + cpfcnpj + @"
InscricaoMunicipal=" + inscricaomunicipal + @"
NIF=" + nif + @"
CAEPF=" + caepf + @"
RazaoSocial=" + razaosocial + @"
NomeFantasia=" + nomefantasia + @"
Logradouro=" + logradouro + @"
Numero=" + numeroprestador + @"
Complemento=" + complemento + @"
Bairro=" + bairro + @"
CodigoMunicipio=" + codigomunicipio + @"
UF=" + uf + @"
CodigoPais=" + codpais + @"
xPais=" + xpais + @"
CEP=" + cep + @"
Telefone=" + telefone + @"
Email=" + email + @"

[Tomador]
Tipo=" + tipotomador + @"
CNPJCPF=" + cpfcnpjtomador + @"
InscricaoMunicipal=" + inscricaomunicipaltomador + @"
NIF=" + niftomador + @"
CAEPF=" + caepftomador + @"
InscricaoEstadual=" + inscricaoestadualtomador + @"
RazaoSocial=" + razaosocialtomador + @"
TipoLogradouro=" + tipologradourotomador + @"
Logradouro=" + logradourotomador + @"
Numero=" + numerotomador + @"
Complemento=" + complementotomador + @"
Bairro=" + bairrotomador + @"
CodigoMunicipio=" + codigomunicipiotomador + @"
xMunicipio=" + xmunicipio + @"
UF=" + uftomador + @"
CodigoPais=" + codigopaistomador + @"
CEP=" + ceptomador + @"
xPais=" + xpaistomador + @"
Telefone=" + telefonetomador + @"
Email=" + emailtomnador + @"
AtualizaTomador=" + atualizatomador + @"
TomadorExterior=" + tomadorexterior + @"

[Servico]
ItemListaServico=" + itemlistaservico + @"
CodigoCnae=" + codigocnae + @"
CodigoTributacaoMunicipio=" + codigotributacaomunicipio + @"
Discriminacao=" + discriminacao + @"
CodigoMunicipio=" + codigomunicipioservico + @"
CodigoPais=" + codigopaisservico + @"
ExigibilidadeISS=" + exigibilidadeiss + @"
MunicipioIncidencia=" + municipioincidencia + @"
UFPrestacao=" + ufprestacaoservico + @"
ResponsavelRetencao=" + responsavelretencao + @"
Operacao=" + operacao + @"
Tributacao=" + tributacao + @"
CodigoNBS=" + codigonbs + @"

[Valores]
ValorServicos=" + valorservicos + @"
ValorDeducoes=" + valordeducoes + @"
AliquotaDeducoes=" + aliquotadeducoes + @"
ValorPis=" + valorpis + @"
AliquotaPis=" + aliquotapis + @"
ValorCofins=" + valorcofins + @"
AliquotaCofins=" + aliquotacofins + @"
ValorInss=" + valorinss + @"
ValorIr=" + valorir + @"
ValorCsll=" + valorcsII + @"
ISSRetido=" + issretido + @"
OutrasRetencoes=" + outrasretencoes + @"
DescontoIncondicionado=" + descontoincondicionado + @"
DescontoCondicionado= " + descontoincondicionado + @"
BaseCalculo=" + basecalculo + @"
Aliquota=" + aliquota + @"
AliquotaSN=" + aliquotasn + @"
ValorIss=" + valoriss + @"
ValorIssRetido=" + valorissretido + @"
ValorLiquidoNfse=" + valorliquidonfse;
            //
            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\" + cpfcnpj))
            {
                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\" + cpfcnpj);
            }
            //
            File.WriteAllText(@"C:\Windows\Temp\Sistema SEVEN\" + cpfcnpj + @"\nfse" + numero + ".ini", criarini, Encoding.UTF8);
        }

        public static string CancelarNFSe(string cod_nfse, string cod_pdv_computador, string justificativa)
        {
            ACBrNFSe ACBrNFSe = new ACBrNFSe();
            //
            //string[] items;
            //
            DataRow drNFSe = bllNFSe.Sel_NFSe_Codigo(cod_nfse).Rows[0];
            //
            DataRow drMinhaEmpresa = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
            //
            string criarini = null;
            //
            //IDENTIFICACAO NFSE
            string numeronfse = drNFSe["numero_nf"].ToString();
            //
            string serienfse = drNFSe["serie"].ToString();
            //
            string chavenfse = null;
            //
            string dataemissao = drNFSe["data_emissao"].ToString().Remove(10);
            //
            string codcancelamento = "1";
            //
            string motcancelamento = justificativa;
            //
            string numerolote = "1";
            //
            string numerorps = drNFSe["numero_nf"].ToString();
            //
            string serierps = drNFSe["serie"].ToString();
            //
            string valornfse = drNFSe["totalservicos"].ToString();
            //
            string codverificacao = null;
            //
            string email = null;
            //
            string numeronfsesubst = null;
            //
            string serienfsesubst = drNFSe["serie"].ToString();
            //
            string codserv = null;
            //
            string tipo = "1";

            criarini = @"[CancelarNFSe]
NumeroNFSe=" + numeronfse + @"
SerieNFSe=" + serienfse + @"
ChaveNFSe=" + chavenfse + @"
DataEmissaoNFSe=" + dataemissao + @"
CodCancelamento=" + codcancelamento + @"
MotCancelamento=" + motcancelamento + @"
NumeroLote=" + numerolote + @"
NumeroRps=" + numerorps + @"
SerieRps=" + serierps + @"
ValorNFSe=" + valornfse + @"
CodVerificacao=" + codverificacao + @"
email=" + email + @"
NumeroNFSeSubst=" + numeronfsesubst + @"
SerieNFSeSubst=" + serienfsesubst + @"
CodServ=" + codserv + @"
Tipo=" + tipo;
            //
            string cpfcnpj = drMinhaEmpresa["cpf_cnpj"].ToString().Replace(".", "").Replace("-", "").Replace("/", "");
            //
            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\" + cpfcnpj))
            {
                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\" + cpfcnpj);
            }
            //
            File.WriteAllText(@"C:\Windows\Temp\Sistema SEVEN\" + cpfcnpj + @"\nfse" + numeronfse + "canc.ini", criarini, Encoding.UTF8);
            //
            return @"C:\Windows\Temp\Sistema SEVEN\" + cpfcnpj + @"\nfse" + numeronfse + "canc.ini";
        }
    }
}
