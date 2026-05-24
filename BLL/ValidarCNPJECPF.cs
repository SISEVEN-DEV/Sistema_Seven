using ACBrLib.ConsultaCNPJ;
using DAL;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BLL
{
    public class ValidarCNPJECPF
    {
        public static void BuscarCNPJ(string cnpjmascarado, string cnpj, string cod_pdv_computador, byte formulario, string usuario)
        {
            ACBrConsultaCNPJ ACBrCNPJ;
            if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "cnpj.ini"))
            {
                ACBrCNPJ = new ACBrConsultaCNPJ(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "cnpj.ini");
            }
            else
            {
                ACBrCNPJ = new ACBrConsultaCNPJ();
            }
            //
            var ret = ACBrCNPJ.Consultar(cnpj);
            //
            string[] items = ret.Split('\n');
            //
            string bairro = null;
            string cep = null;
            string cidade = null;
            string complemento = null;
            string endereco = null;
            string fantasia = null;
            string numero = null;
            string nome = null;
            string inscricao_estadual = null;
            string uf = null;
            string codigo_municipio = null;
            for (int i = 0; i < items.Length; i++)
            {
                string[] item = items[i].Split('=');
                if (item[0] == "Bairro")
                {
                    bairro = Regex.Replace(item[1].ToUpper(), @"\r\n|\r|\n", "");
                }
                else if (item[0] == "CEP")
                {
                    cep = Regex.Replace(item[1], @"\r\n|\r|\n", "");
                }
                else if (item[0] == "Cidade")
                {
                    cidade = Regex.Replace(item[1].ToUpper(), @"\r\n|\r|\n", "");
                }
                else if (item[0] == "Complemento")
                {
                    complemento = Regex.Replace(item[1].ToUpper(), @"\r\n|\r|\n", "");
                }
                else if (item[0] == "Endereco")
                {
                    endereco = Regex.Replace(item[1].ToUpper(), @"\r\n|\r|\n", "");
                }
                else if (item[0] == "Fantasia")
                {
                    fantasia = Regex.Replace(item[1].ToUpper(), @"\r\n|\r|\n", "");
                }
                else if (item[0] == "Numero")
                {
                    numero = Regex.Replace(item[1], @"\r\n|\r|\n", "");
                }
                else if (item[0] == "RazaoSocial")
                {
                    nome = Regex.Replace(item[1].ToUpper(), @"\r\n|\r|\n", "");
                }
                else if (item[0] == "InscricaoEstadual")
                {
                    inscricao_estadual = Regex.Replace(item[1], @"\r\n|\r|\n", "");
                }
                else if (item[0] == "UF")
                {
                    uf = Regex.Replace(item[1], @"\r\n|\r|\n", "");
                }
            }
            //
            if (nome == "" || nome == null)
            {
                throw new InvalidOperationException("O Sistema não conseguiu encontrar os dados do CNPJ informado.");
            }
            //
            string caminhoArquivo = null;
            if (uf == "AC")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Acre\Acre.txt";
            }
            else if (uf == "AL")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Alagoas\Alagoas.txt";
            }
            else if (uf == "AM")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Amazonas\Amazonas.txt";
            }
            else if (uf == "AP")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Amapa\Amapa.txt";
            }
            else if (uf == "BA")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Bahia\Bahia.txt";
            }
            else if (uf == "CE")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Ceara\Ceara.txt";
            }
            else if (uf == "DF")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Distrito Federal\Distrito Federal.txt";
            }
            else if (uf == "ES")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Espirito Santo\Espirito Santo.txt";
            }
            else if (uf == "GO")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Goias\Goias.txt";
            }
            else if (uf == "MA")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Maranhao\Maranhao.txt";
            }
            else if (uf == "MG")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Minas Gerais\Minas Gerais.txt";
            }
            else if (uf == "MS")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Mato Grosso do Sul\Mato Grosso do Sul.txt";
            }
            else if (uf == "MT")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Mato Grosso\Mato Grosso.txt";
            }
            else if (uf == "PA")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Para\Para.txt";
            }
            else if (uf == "PB")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Paraiba\Paraiba.txt";
            }
            else if (uf == "PE")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Pernambuco\Pernambuco.txt";
            }
            else if (uf == "PI")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Piaui\Piaui.txt";
            }
            else if (uf == "PR")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Parana\Parana.txt";
            }
            else if (uf == "RJ")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Rio de Janeiro\Rio de Janeiro.txt";
            }
            else if (uf == "RN")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Rio Grande do Norte\Rio Grande do Norte.txt";
            }
            else if (uf == "RO")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Rondonia\Rondonia.txt";
            }
            else if (uf == "RR")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Roraima\Roraima.txt";
            }
            else if (uf == "RS")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Rio Grande do Sul\Rio Grande do Sul.txt";
            }
            else if (uf == "SC")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Santa Catarina\Santa Catarina.txt";
            }
            else if (uf == "SE")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Sergipe\Sergipe.txt";
            }
            else if (uf == "SP")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Sao Paulo\Sao Paulo.txt";
            }
            else if (uf == "TO")
            {
                caminhoArquivo = @"C:\Sistema SEVEN\Config\UF\Tocantins\Tocantins.txt";
            }
            //
            foreach (string linha in File.ReadLines(caminhoArquivo))
            {
                string linhaSemAcento = ValidarData.RemoverAcentos(linha);
                string cidadeSemAcento = ValidarData.RemoverAcentos(cidade);

                if (linhaSemAcento.Contains(cidadeSemAcento))
                {
                    var item = linha.Split('—');

                    if (item.Length > 1)
                    {
                        codigo_municipio = item[1].Trim();
                        break;
                    }
                }
            }
            //
            cep = cep.Insert(2, ".").Insert(6, "-");
            //
            if (formulario == 0)
            {
                bllClieCons.Salvar(nome, null, null, null, cnpjmascarado, null, null, null, endereco, numero, complemento, bairro, cidade, uf, cep, null, null, null, null, null, null, null, null, null, null, null, "Pessoa Jurídica", fantasia, null, "ATIVO", null, null, null, null, null, null, null, null, null, null, null, null, null, null, cod_pdv_computador, "4—CLIENTES NO GERAL", "4—GERAL", codigo_municipio);
                //
                DataRow dr = bllClieCons.Sel_Clie_CPFCNPJ(cnpjmascarado).Rows[0];
                //
                bllRegistroAtividades.Salvar("SALVOU UM CONSUMIDOR.", "CONSUMIDOR", dr["id_cliente"].ToString(), usuario, cod_pdv_computador);
                //
                bllClieCons._CNPJ_PesqCNPJ_Tabela = cnpjmascarado;
            }
            else if (formulario == 1)
            {
                bllFornecedor.Salvar(nome, cnpjmascarado, inscricao_estadual, null, cep, endereco, cidade, uf, complemento, bairro, null, null, numero, null, fantasia, null, null, "Pessoa Jurídica", null, null, null, cod_pdv_computador, codigo_municipio);
                //
                DataRow dr = bllFornecedor.Sel_F_Cnpj(cnpjmascarado).Rows[0];
                //
                bllRegistroAtividades.Salvar("SALVOU UM FORNECEDOR.", "FORNECEDOR", dr["id_fornecedor"].ToString(), usuario, cod_pdv_computador);
                //
                bllFornecedor._CNPJ_PesqCNPJ_Tabela = cnpjmascarado;
            }
            else if (formulario == 2)
            {
                bllMinhaEmpresa._CNPJ_Dados = nome + "—" + cnpjmascarado + "—" + inscricao_estadual + "—" + cep + "—" + endereco + "—" + cidade + "—" + uf + "—" + complemento + "—" + bairro + "—" + numero + "—" + fantasia + "—" + codigo_municipio;
            }
        }

        public static bool ValidaCNPJ(string vrCNPJ)
        {
            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(
                     CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] *
                        int.Parse(ftmt.Substring(
                          nrDig + 1, 1)));
                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] *
                        int.Parse(ftmt.Substring(
                          nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == 0);

                    else
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == (
                        11 - resultado[nrDig]));

                }

                return (CNPJOk[0] && CNPJOk[1]);

            }
            catch
            {
                return false;
            }
        }

        public static bool ValidarCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];
            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;

            }
            else
                if (numeros[10] != 11 - resultado)
                return false;
            return true;
        }
    }
}
