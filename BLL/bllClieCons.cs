using DAL;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace BLL
{
    public class bllClieCons
    {
        public static string _Url_Imagem;
        public static string _Nome_Arquivo;
        public static bool _Mostrar_Imagem;
        public static bool _Excluir_Imagem;

        public static bool _FrmCadClieCons_Ativo;

        public static bool _FrmRelCliente_Ativo;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static string _Grupo_PesqGrupo_Tabela;
        public static string _SubGrupo_PesqSubGrupo_Tabela;

        public static string _Cod_ClieCons_Cadastro;
        public static string _CNPJ_PesqCNPJ_Tabela;

        public static void Salvar(string nome, string data_nascimento, string palavra_chave, string rg, string cpf_cnpj, string telefone, string celular, string email, string endereco, string numero, string complemento, string bairro, string cidade, string uf, string cep, string genero, string observacao, string nome_pai, string cpf_pai, string celular_pai, string email_pai, string nome_mae, string cpf_mae, string celular_mae, string email_mae, string imagem_cliente, string pessoa, string fantasia, string fax, string situacao, string credito, string avalista, string cpf_aval, string rg_aval, string email_aval, string endereco_aval, string bairro_aval, string uf_aval, string cidade_aval, string numero_aval, string complento_aval, string cep_aval, string telefone_aval, string celular_aval, string cod_pdv_computador, string grupo, string subgrupo, string codigo_municipio)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Data_Cadastro = DateTime.Now.ToShortDateString().Replace('/', '.');
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Clie.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Clie.Palavra_Chave = "null";
                    }
                    else
                    {
                        Clie.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    if (rg == "" || rg == null)
                    {
                        Clie.IE_RG = "null";
                    }
                    else
                    {
                        Clie.IE_RG = rg.Insert(rg.Length, "'").Insert(0, "'").Replace(".", ""); 
                    }
                    //
                    if (data_nascimento == "__/__/____" || data_nascimento == "  /  /" || data_nascimento == "" || data_nascimento == null)
                    {
                        Clie.Data_Nascimento = "null";
                    }
                    else
                    {
                        Clie.Data_Nascimento = data_nascimento.Insert(data_nascimento.Length, "'").Insert(0, "'").Replace('/', '.');
                    }
                    //
                    if (cpf_cnpj == "___.___.___-__" || cpf_cnpj == "   .   .   -" || cpf_cnpj == "  .   .   /    -" || cpf_cnpj == "__.___.___/____-__" || cpf_cnpj == "" || cpf_cnpj == null)
                    {
                        Clie.CPF_CNPJ = "null";
                    }
                    else
                    {
                        Clie.CPF_CNPJ = cpf_cnpj.Insert(cpf_cnpj.Length, "'").Insert(0, "'");
                    }
                    //
                    if (telefone == "(__) ____-____" || telefone == "(  )     -" || telefone_aval == "" || telefone_aval == null)
                    {
                        Clie.Telefone = "null";
                    }
                    else
                    {
                        Clie.Telefone = telefone.Insert(telefone.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fax == "(__) ____-____" || fax == "(  )     -" || fax == "" || fax == null)
                    {
                        Clie.FAX = "null";
                    }
                    else
                    {
                        Clie.FAX = fax.Insert(fax.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular == "(__) _____-____" || celular == "(  )      -" || celular == "" || celular == null)
                    {
                        Clie.Celular = "null";
                    }
                    else
                    {
                        Clie.Celular = celular.Insert(celular.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fantasia == "" || fantasia == null)
                    {
                        Clie.Fantasia = "null";
                    }
                    else
                    {
                        Clie.Fantasia = fantasia.Insert(fantasia.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email == "" || email == null)
                    {
                        Clie.Email = "null";
                    }
                    else
                    {
                        Clie.Email = email.Insert(email.Length, "'").Insert(0, "'");
                    }
                    //
                    if (pessoa == "Pessoa Física")
                    {
                        Clie.Pessoa = 0;
                    }
                    else
                    {
                        Clie.Pessoa = 1;
                    }
                    //
                    Clie.Endereco = endereco.Insert(endereco.Length, "'").Insert(0, "'");
                    //
                    if (Regex.IsMatch(numero, @"\d"))
                    {
                        Clie.Numero = Convert.ToInt32(Regex.Replace(numero, @"\D", ""));
                    }
                    else
                    {
                        Clie.Numero = 0;
                    }
                    //
                    if (complemento == "" || complemento == null)
                    {
                        Clie.Complemento = "null";
                    }
                    else
                    {
                        Clie.Complemento = complemento.Insert(complemento.Length, "'").Insert(0, "'");
                    }
                    //
                    Clie.Bairro = bairro.Insert(bairro.Length, "'").Insert(0, "'");
                    Clie.Cidade = cidade.Insert(cidade.Length, "'").Insert(0, "'");
                    Clie.Uf = uf.Insert(uf.Length, "'").Insert(0, "'");
                    Clie.Cep = cep.Insert(cep.Length, "'").Insert(0, "'");
                    //
                    if (genero == "" || genero == null)
                    {
                        Clie.Genero = "null";
                    }
                    else
                    {
                        Clie.Genero = genero.Insert(genero.Length, "'").Insert(0, "'");
                    }
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Clie.Observacao = "null";
                    }
                    else
                    {
                        Clie.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_pai == "" || nome_pai == null)
                    {
                        Clie.Nome_Pai = "null";
                    }
                    else
                    {
                        Clie.Nome_Pai = nome_pai.Insert(nome_pai.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cpf_pai == "___.___.___-__" || cpf_pai == "   .   .   -" || cpf_pai == "" || cpf_pai == null)
                    {
                        Clie.CPF_Pai = "null";
                    }
                    else
                    {
                        Clie.CPF_Pai = cpf_pai.Insert(cpf_pai.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular_pai == "(__) _____-____" || celular_pai == "(  )      -" || celular_pai == "" || celular_pai == null)
                    {
                        Clie.Celular_Pai = "null";
                    }
                    else
                    {
                        Clie.Celular_Pai = celular_pai.Insert(celular_pai.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email_pai == "" || email_pai == null)
                    {
                        Clie.Email_Pai = "null";
                    }
                    else
                    {
                        Clie.Email_Pai = email_pai.Insert(email_pai.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_mae == "" || nome_mae == null)
                    {
                        Clie.Nome_Mae = "null";
                    }
                    else
                    {
                        Clie.Nome_Mae = nome_mae.Insert(nome_mae.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cpf_mae == "___.___.___-__" || cpf_mae == "   .   .   -" || cpf_mae == "" || cpf_mae == null)
                    {
                        Clie.CPF_Mae = "null";
                    }
                    else
                    {
                        Clie.CPF_Mae = cpf_mae.Insert(cpf_mae.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular_mae == "(__) _____-____" || celular_mae == "(  )      -" || celular_mae == "" || celular_mae == null)
                    {
                        Clie.Celular_Mae = "null";
                    }
                    else
                    {
                        Clie.Celular_Mae = celular_mae.Insert(celular_mae.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email_mae == "" || email_mae == null)
                    {
                        Clie.Email_Mae = "null";
                    }
                    else
                    {
                        Clie.Email_Mae = email_mae.Insert(email_mae.Length, "'").Insert(0, "'");
                    }
                    //  
                    Clie.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    if (credito == "" || credito == null)
                    {
                        Clie.Credito = 0;
                    }
                    else
                    {
                        if (credito.Contains("."))
                        {
                            Clie.Credito = Convert.ToDecimal(credito.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Clie.Credito = Convert.ToDecimal(credito.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    Clie.Saldo = 0;
                    //
                    Clie.Saldo_Credito_Loja = 0;
                    //
                    if (avalista == "" || avalista == null)
                    {
                        Clie.Avalista = "null";
                    }
                    else
                    {
                        Clie.Avalista = avalista.Insert(avalista.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cpf_aval == "___.___.___-__" || cpf_aval == "   .   .   -" || cpf_aval == "" || cpf_aval == null)
                    {
                        Clie.CPF_Avalista = "null";
                    }
                    else
                    {
                        Clie.CPF_Avalista = cpf_aval.Insert(cpf_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (rg_aval == "" || rg_aval == null)
                    {
                        Clie.RG_Avalista = "null";
                    }
                    else
                    {
                        Clie.RG_Avalista = rg_aval.Insert(rg_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email_aval == "" || email_aval == null)
                    {
                        Clie.Email_Avalista = "null";
                    }
                    else
                    {
                        Clie.Email_Avalista = email_aval.Insert(email_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (endereco_aval == "" || endereco_aval == null)
                    {
                        Clie.Endereco_Avalista = "null";
                    }
                    else
                    {
                        Clie.Endereco_Avalista = endereco_aval.Insert(endereco_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (bairro_aval == "" || bairro_aval == null)
                    {
                        Clie.Bairro_Avalista = "null";
                    }
                    else
                    {
                        Clie.Bairro_Avalista = bairro_aval.Insert(bairro_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (uf_aval == "" || uf_aval == null)
                    {
                        Clie.UF_Avalista = "null";
                    }
                    else
                    {
                        Clie.UF_Avalista = uf_aval.Insert(uf_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cidade_aval == "" || cidade_aval == null)
                    {
                        Clie.Cidade_Avalista = "null";
                    }
                    else
                    {
                        Clie.Cidade_Avalista = cidade_aval.Insert(cidade_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (numero_aval == "" || numero_aval == null)
                    {
                        Clie.Numero_Avalista = 0;
                    }
                    else
                    {
                        Clie.Numero_Avalista = Convert.ToInt32(numero_aval);
                    }
                    //
                    if (complento_aval == "" || complento_aval == null)
                    {
                        Clie.Complemento_Avalista = "null";
                    }
                    else
                    {
                        Clie.Complemento_Avalista = complento_aval.Insert(complento_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cep_aval == "  .   -" || cep_aval == "__.___-___" || cep_aval == "" || cep_aval == null)
                    {
                        Clie.CEP_Avalista = "null";
                    }
                    else
                    {
                        Clie.CEP_Avalista = cep_aval.Insert(cep_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (telefone_aval == "(__) ____-____" || telefone_aval == "(  )     -" || telefone_aval == "" || telefone_aval == null)
                    {
                        Clie.Telefone_Avalista = "null";
                    }
                    else
                    {
                        Clie.Telefone_Avalista = telefone_aval.Insert(telefone_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular_aval == "(__) _____-____" || celular_aval == "(  )      -" || celular_aval == "" || celular_aval == null)
                    {
                        Clie.Celular_Avalista = "null";
                    }
                    else
                    {
                        Clie.Celular_Avalista = celular_aval.Insert(celular_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    string[] items = grupo.Split('—');
                    //
                    Clie.Cod_Grupo = Convert.ToInt16(items[0]);
                    Clie.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = subgrupo.Split('—');
                    //
                    Clie.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    Clie.Desc_SubGrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Clie.Codigo_Municipio = codigo_municipio.Insert(codigo_municipio.Length, "'").Insert(0, "'");
                    //
                    if (imagem_cliente != null)
                    {
                        Image original = Image.FromFile(imagem_cliente);
                        //
                        Image redimensionada = RedimensionarImagem.Redimensionar(original, 225, 225);
                        //
                        byte[] imagemBytes;
                        //
                        using (MemoryStream ms = new MemoryStream())
                        {
                            redimensionada.Save(ms, ImageFormat.Jpeg); // ou PNG, se preferir
                            imagemBytes = ms.ToArray();
                        }
                        //
                        Clie.Imagem_Cliente = imagemBytes;
                    }
                    //
                    con.Salvar_Cliente(Clie);
                    //                   
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static bool Sel_Cliente_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Cliente_Ainda_Existe(Clie);
                }
            }
        }

        public static void Alterar_CPF_CNPJ_Clie_Zerado(string nome, string cpf_cnpj)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    if (nome == "" || nome == null)
                    {
                        Clie.Nome = "'CONSUMIDOR NAO IDENTIFICADO'";
                    }
                    else
                    {
                        Clie.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cpf_cnpj == "___.___.___-__" || cpf_cnpj == "   .   .   -" || cpf_cnpj == "  .   .   /    -" || cpf_cnpj == "__.___.___/____-__" || cpf_cnpj == "" || cpf_cnpj == null)
                    {
                        Clie.CPF_CNPJ = "null";
                    }
                    else
                    {
                        Clie.CPF_CNPJ = cpf_cnpj.Insert(cpf_cnpj.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Alterar_CPF_CNPJ_Clie_Zerado(Clie);
                }
            }
        }


        public static void Alterar(string codigo, string nome, string data_nascimento, string palavra_chave, string rg, string cpf_cnpj, string telefone, string celular, string email, string endereco, string numero, string complemento, string bairro, string cidade, string uf, string cep, string genero, string observacao, string nome_pai, string cpf_pai, string celular_pai, string email_pai, string nome_mae, string cpf_mae, string celular_mae, string email_mae, string pessoa, string fantasia, string fax, string situacao, string credito, string avalista, string cpf_aval, string rg_aval, string email_aval, string endereco_aval, string bairro_aval, string uf_aval, string cidade_aval, string numero_aval, string complento_aval, string cep_aval, string telefone_aval, string celular_aval, string cod_pdv_computador, string grupo, string subgrupo, string novo_codigo, string id, string codigo_municipio)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Clie.Codigo = Convert.ToInt32(codigo);
                    Clie.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Clie.Palavra_Chave = "null";
                    }
                    else
                    {
                        Clie.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //

                    if (rg == "" || rg == null)
                    {
                        Clie.IE_RG = "null";
                    }
                    else
                    {
                        Clie.IE_RG = rg.Insert(rg.Length, "'").Insert(0, "'").Replace(".", "");
                    }
                    //
                    if (data_nascimento == "__/__/____" || data_nascimento == "  /  /" || data_nascimento == "" || data_nascimento == null)
                    {
                        Clie.Data_Nascimento = "null";
                    }
                    else
                    {
                        Clie.Data_Nascimento = data_nascimento.Insert(data_nascimento.Length, "'").Insert(0, "'").Replace('/', '.');
                    }

                    //
                    if (cpf_cnpj == "___.___.___-__" || cpf_cnpj == "   .   .   -" || cpf_cnpj == "  .   .   /    -" || cpf_cnpj == "__.___.___/____-__" || cpf_cnpj == "" || cpf_cnpj == null)
                    {
                        Clie.CPF_CNPJ = "null";
                    }
                    else
                    {
                        Clie.CPF_CNPJ = cpf_cnpj.Insert(cpf_cnpj.Length, "'").Insert(0, "'");
                    }
                    //

                    if (telefone == "(__) ____-____" || telefone == "(  )     -" || telefone == "" || telefone == null)
                    {
                        Clie.Telefone = "null";
                    }
                    else
                    {
                        Clie.Telefone = telefone.Insert(telefone.Length, "'").Insert(0, "'");
                    }

                    //
                    if (fax == "(__) ____-____" || fax == "(  )     -" || fax == "" || fax == null)
                    {
                        Clie.FAX = "null";
                    }
                    else
                    {
                        Clie.FAX = fax.Insert(fax.Length, "'").Insert(0, "'");
                    }

                    //
                    if (fantasia == "" || fantasia == null)
                    {
                        Clie.Fantasia = "null";
                    }
                    else
                    {
                        Clie.Fantasia = fantasia.Insert(fantasia.Length, "'").Insert(0, "'");
                    }

                    //
                    if (pessoa == "Pessoa Física")
                    {
                        Clie.Pessoa = 0;
                    }
                    else
                    {
                        Clie.Pessoa = 1;
                    }
                    //
                    if (celular == "(__) _____-____" || celular == "(  )      -" || celular == "" || celular == null)
                    {
                        Clie.Celular = "null";
                    }
                    else
                    {
                        Clie.Celular = celular.Insert(celular.Length, "'").Insert(0, "'");
                    }
                    //

                    if (email == "" || email == null)
                    {
                        Clie.Email = "null";
                    }
                    else
                    {
                        Clie.Email = email.Insert(email.Length, "'").Insert(0, "'");
                    }
                    //
                    Clie.Endereco = endereco.Insert(endereco.Length, "'").Insert(0, "'");
                    //
                    if (Regex.IsMatch(numero, @"\d"))
                    {
                        Clie.Numero = Convert.ToInt32(Regex.Replace(numero, @"\D", ""));
                    }
                    else
                    {
                        Clie.Numero = 0;
                    }
                    //
                    if (complemento == "" || complemento == null)
                    {
                        Clie.Complemento = "null";
                    }
                    else
                    {
                        Clie.Complemento = complemento.Insert(complemento.Length, "'").Insert(0, "'");
                    }

                    //
                    Clie.Bairro = bairro.Insert(bairro.Length, "'").Insert(0, "'");
                    Clie.Cidade = cidade.Insert(cidade.Length, "'").Insert(0, "'");
                    Clie.Uf = uf.Insert(uf.Length, "'").Insert(0, "'");
                    Clie.Cep = cep.Insert(cep.Length, "'").Insert(0, "'");
                    //
                    if (genero == "" || genero == null)
                    {
                        Clie.Genero = "null";
                    }
                    else
                    {
                        Clie.Genero = genero.Insert(genero.Length, "'").Insert(0, "'");
                    }
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Clie.Observacao = "null";
                    }
                    else
                    {
                        Clie.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }

                    if (nome_pai == "" || nome_pai == null)
                    {
                        Clie.Nome_Pai = "null";
                    }
                    else
                    {
                        Clie.Nome_Pai = nome_pai.Insert(nome_pai.Length, "'").Insert(0, "'");
                    }

                    //  
                    if (cpf_pai == "___.___.___-__" || cpf_pai == "   .   .   -" || cpf_pai == "" || cpf_pai == null)
                    {
                        Clie.CPF_Pai = "null";
                    }
                    else
                    {
                        Clie.CPF_Pai = cpf_pai.Insert(cpf_pai.Length, "'").Insert(0, "'");
                    }

                    //
                    if (celular_pai == "(__) _____-____" || celular_pai == "(  )      -" || celular_pai == "" || celular_pai == null)
                    {
                        Clie.Celular_Pai = "null";
                    }
                    else
                    {
                        Clie.Celular_Pai = celular_pai.Insert(celular_pai.Length, "'").Insert(0, "'");
                    }

                    //
                    if (email_pai == "" || email_pai == null)
                    {
                        Clie.Email_Pai = "null";
                    }
                    else
                    {
                        Clie.Email_Pai = email_pai.Insert(email_pai.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_mae == "" || nome_mae == null)
                    {
                        Clie.Nome_Mae = "null";
                    }
                    else
                    {
                        Clie.Nome_Mae = nome_mae.Insert(nome_mae.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cpf_mae == "___.___.___-__" || cpf_mae == "   .   .   -" || cpf_mae == "" || cpf_mae == null)
                    {
                        Clie.CPF_Mae = "null";
                    }
                    else
                    {
                        Clie.CPF_Mae = cpf_mae.Insert(cpf_mae.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular_mae == "(__) _____-____" || celular_mae == "(  )      -" || celular_mae == "" || celular_mae == null)
                    {
                        Clie.Celular_Mae = "null";
                    }
                    else
                    {
                        Clie.Celular_Mae = celular_mae.Insert(celular_mae.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email_mae == "" || email_mae == null)
                    {
                        Clie.Email_Mae = "null";
                    }
                    else
                    {
                        Clie.Email_Mae = email_mae.Insert(email_mae.Length, "'").Insert(0, "'");
                    }
                    //  
                    Clie.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    if (credito == "" || credito == null)
                    {
                        Clie.Credito = 0;
                    }
                    else
                    {
                        if (credito.Contains("."))
                        {
                            Clie.Credito = Convert.ToDecimal(credito.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Clie.Credito = Convert.ToDecimal(credito.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (avalista == "" || avalista == null)
                    {
                        Clie.Avalista = "null";
                    }
                    else
                    {
                        Clie.Avalista = avalista.Insert(avalista.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cpf_aval == "___.___.___-__" || cpf_aval == "   .   .   -" || cpf_aval == "" || cpf_aval == null)
                    {
                        Clie.CPF_Avalista = "null";
                    }
                    else
                    {
                        Clie.CPF_Avalista = cpf_aval.Insert(cpf_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (rg_aval == "" || rg_aval == null)
                    {
                        Clie.RG_Avalista = "null";
                    }
                    else
                    {
                        Clie.RG_Avalista = rg_aval.Insert(rg_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email_aval == "" || email_aval == null)
                    {
                        Clie.Email_Avalista = "null";
                    }
                    else
                    {
                        Clie.Email_Avalista = email_aval.Insert(email_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (endereco_aval == "" || endereco_aval == null)
                    {
                        Clie.Endereco_Avalista = "null";
                    }
                    else
                    {
                        Clie.Endereco_Avalista = endereco_aval.Insert(endereco_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (bairro_aval == "" || bairro_aval == null)
                    {
                        Clie.Bairro_Avalista = "null";
                    }
                    else
                    {
                        Clie.Bairro_Avalista = bairro_aval.Insert(bairro_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (uf_aval == "" || uf_aval == null)
                    {
                        Clie.UF_Avalista = "null";
                    }
                    else
                    {
                        Clie.UF_Avalista = uf_aval.Insert(uf_aval.Length, "'").Insert(0, "'");
                    }

                    //
                    if (cidade_aval == "" || cidade_aval == null)
                    {
                        Clie.Cidade_Avalista = "null";
                    }
                    else
                    {
                        Clie.Cidade_Avalista = cidade_aval.Insert(cidade_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (numero_aval == "" || numero_aval == null)
                    {
                        Clie.Numero_Avalista = 0;
                    }
                    else
                    {
                        Clie.Numero_Avalista = Convert.ToInt32(numero_aval);
                    }
                    //
                    if (complento_aval == "" || complento_aval == null)
                    {
                        Clie.Complemento_Avalista = "null";
                    }
                    else
                    {
                        Clie.Complemento_Avalista = complento_aval.Insert(complento_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cep_aval == "  .   -" || cep_aval == "__.___-___" || cep_aval == "" || cep_aval == null)
                    {
                        Clie.CEP_Avalista = "null";
                    }
                    else
                    {
                        Clie.CEP_Avalista = cep_aval.Insert(cep_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (telefone_aval == "(__) ____-____" || telefone_aval == "(  )     -" || telefone_aval == "" || telefone_aval == null)
                    {
                        Clie.Telefone_Avalista = "null";
                    }
                    else
                    {
                        Clie.Telefone_Avalista = telefone_aval.Insert(telefone_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular_aval == "(__) _____-____" || celular_aval == "(  )      -" || celular_aval == "" || celular_aval == null)
                    {
                        Clie.Celular_Avalista = "null";
                    }
                    else
                    {
                        Clie.Celular_Avalista = celular_aval.Insert(celular_aval.Length, "'").Insert(0, "'");
                    }
                    //
                    string[] items = grupo.Split('—');
                    Clie.Cod_Grupo = Convert.ToInt16(items[0]);
                    Clie.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = subgrupo.Split('—');
                    //
                    Clie.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    Clie.Desc_SubGrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Clie.Codigo_Municipio = codigo_municipio.Insert(codigo_municipio.Length, "'").Insert(0, "'");
                    //
                    Clie.Data_Ult_Alteracao = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    con.Alterar_Cliente(Clie, novo_codigo);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_IE(string codigo, string ie)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    //
                    if (ie == "" || ie == null)
                    {
                        Clie.IE_RG = "null";
                    }
                    else
                    {
                        Clie.IE_RG = ie.Insert(ie.Length, "'").Insert(0, "'").Replace(".", "");
                    }
                    //
                    con.Alterar_IE(Clie);
                }
            }
        }

        public static void Alterar_Imagem_Cliente(string codigo, string imagem_cliente)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    //
                    bool nulo;
                    if (imagem_cliente != null)
                    {
                        Image original = Image.FromFile(imagem_cliente);
                        //
                        Image redimensionada = RedimensionarImagem.Redimensionar(original, 225, 225);
                        //
                        byte[] imagemBytes;
                        //
                        using (MemoryStream ms = new MemoryStream())
                        {
                            redimensionada.Save(ms, ImageFormat.Jpeg); // ou PNG, se preferir
                            imagemBytes = ms.ToArray();
                        }
                        //
                        Clie.Imagem_Cliente = imagemBytes;
                        //
                        nulo = false;
                    }
                    else
                    {
                        nulo = true;
                    }
                    //
                    con.Alterar_Imagem_Cliente(Clie, nulo);
                }
            }
        }

        public static void Alterar_Nome_Clie_Conta_Pagar(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    Clie.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Nome_Clie_Conta_Pagar(Clie);
                }
            }
        }

        public static void Alterar_Nome_Clie_Conta_Receber(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    Clie.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Nome_Clie_Conta_Receber(Clie);
                }
            }
        }

        public static void Alterar_Nome_Clie_Devolucao(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    Clie.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Nome_Clie_Devolucao(Clie);
                }
            }
        }

        public static void Alterar_Nome_Clie_Orcamento(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    Clie.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Nome_Clie_Orcamento(Clie);
                }
            }
        }

        public static DataTable Sel_Grupo_Clie()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Grupo_Clie();
            }
        }

        public static DataTable Sel_SubGrupo_Clie(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items = cbbgrupo.Split('—');
                    Clie.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_SubGrupo_Clie(Clie);
                }
            }
        }

        public static void Alterar_Nome_Clie_DFe(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    Clie.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Nome_Clie_DFe(Clie);
                }
            }
        }

        public static void Alterar_Nome_Clie_OS(string codigo, string nome, string cpf_cnpj)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    Clie.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    if (cpf_cnpj == "___.___.___-__" || cpf_cnpj == "   .   .   -" || cpf_cnpj == "  .   .   /    -" || cpf_cnpj == "__.___.___/____-__" || cpf_cnpj == "" || cpf_cnpj == null)
                    {
                        Clie.CPF_CNPJ = "null";
                    }
                    else
                    {
                        Clie.CPF_CNPJ = cpf_cnpj.Insert(cpf_cnpj.Length, "'").Insert(0, "'");
                    }
                    con.Alterar_Nome_Clie_OS(Clie);
                }
            }
        }


        public static void Alterar_Nome_Clie_Vendas(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    Clie.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Nome_Clie_Vendas(Clie);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Clie(Clie);
                }
            }
        }

        public static DataTable Sel_Cliente_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_A_Sal();
            }
        }

        public static DataTable Sel_Clie_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Cliente = new ClieCons())
                {
                    Cliente.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Clie_A_Alt(Cliente);
                }
            }
        }

        public static DataTable Sel_Clie_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Clie_Todos();
            }
        }

        public static DataTable Sel_Clie_Todos_Ativo()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Clie_Todos_Ativo();
            }
        }

        public static DataTable Sel_Clie_Data_UF_Cidade_Pessoa_Todos(string data, string data1, string uf, string cidade, string pessoa, string telefone, string celular, string email, string cpf_aval, string nome_aval, string grupo, string subgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string SqlData;
                    string SqlUf;
                    string SqlCidade;
                    string SqlPessoa;
                    string SqlTelefone;
                    string SqlCelular;
                    string SqlEmail;
                    string SqlNomeAval;
                    string SqlCPFAval;
                    string SqlGrupo;
                    string SqlSubGrupo;
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "WHERE data_cadastro BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                    }
                    else
                    {
                        SqlData = "WHERE data_cadastro BETWEEN '" + data.Replace("/", ".") + " 00:00:00" + "' AND '" + data1.Replace("/", ".") + " 23:59:59" + "'";
                    }
                    //
                    if (pessoa == "PESSOA FÍSICA")
                    {
                        SqlPessoa = " AND pessoa=0";
                    }
                    else if (pessoa == "PESSOA JURÍDICA")
                    {
                        SqlPessoa = " AND pessoa=1";
                    }
                    else
                    {
                        SqlPessoa = "";
                    }
                    //
                    if (uf == "")
                    {
                        SqlUf = "";
                    }
                    else
                    {
                        SqlUf = " AND uf='" + uf + "'";
                    }
                    //
                    if (cidade == "")
                    {
                        SqlCidade = "";
                    }
                    else
                    {
                        SqlCidade = " AND cidade='" + cidade + "'";
                    }
                    //
                    if (telefone == "(  )     -")
                    {
                        SqlTelefone = "";
                    }
                    else
                    {
                        SqlTelefone = " AND telefone='" + telefone + "'";
                    }
                    //
                    if (celular == "(  )      -")
                    {
                        SqlCelular = "";
                    }
                    else
                    {
                        SqlCelular = " AND celular='" + celular + "'";
                    }
                    //
                    if (email == "")
                    {
                        SqlEmail = "";
                    }
                    else
                    {
                        if (email.Contains("%"))
                        {
                            SqlEmail = " AND email LIKE '" + email + "'";
                        }
                        else
                        {
                            SqlEmail = " AND email STARTING WITH '" + email + "'";
                        }
                    }
                    //
                    if (cpf_aval == "   .   .   -" || cpf_aval == "___.___.___-__")
                    {
                        SqlCPFAval = "";
                    }
                    else
                    {
                        SqlCPFAval = " AND cpf_avalista='" + cpf_aval + "'";
                    }
                    //
                    if (nome_aval == "")
                    {
                        SqlNomeAval = "";
                    }
                    else
                    {
                        if (nome_aval.Contains("%"))
                        {
                            SqlNomeAval = " AND avalista LIKE '" + nome_aval + "'";
                        }
                        else
                        {
                            SqlNomeAval = " AND avalista STARTING WITH '" + nome_aval + "'";
                        }
                    }
                    //
                    string[] items;
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
                        SqlSubGrupo = "";
                    }
                    else
                    {
                        items = subgrupo.Split('—');
                        SqlSubGrupo = " AND id_subgrupo='" + items[0] + "'";
                    }
                    //
                    return con.Sel_Clie_Data_UF_Cidade_Pessoa_Todos(SqlData, SqlUf, SqlCidade, SqlPessoa, SqlTelefone, SqlCelular, SqlEmail, SqlCPFAval, SqlNomeAval, SqlGrupo, SqlSubGrupo);
                }
            }
        }

        public static DataTable Sel_Clie_Nome(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Clie.Pesquisar = pesquisar;
                        return con.Sel_Clie_Nome_Like(Clie);
                    }
                    else
                    {
                        Clie.Pesquisar = pesquisar;
                        return con.Sel_Clie_Nome(Clie);
                    }
                }
            }
        }

        public static DataTable Sel_Clie_Nome_Ativo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Clie.Pesquisar = pesquisar;
                        return con.Sel_Clie_Nome_Like_Ativo(Clie);
                    }
                    else
                    {
                        Clie.Pesquisar = pesquisar;
                        return con.Sel_Clie_Nome_Ativo(Clie);
                    }
                }
            }
        }

        public static DataTable Sel_Clie_Data_UF_Cidade_Pessoa_Nome(string data, string data1, string uf, string cidade, string pessoa, string nome_razao_social, string telefone, string celular, string email, string nome_aval, string cpf_aval, string grupo, string subgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string SqlNomeRazao;
                    string SqlData;
                    string SqlUf;
                    string SqlCidade;
                    string SqlPessoa;
                    string SqlTelefone;
                    string SqlCelular;
                    string SqlEmail;
                    string SqlNomeAval;
                    string SqlCPFAval;
                    string SqlGrupo;
                    string SqlSubGrupo;
                    //
                    if (nome_razao_social.Contains("%"))
                    {
                        SqlNomeRazao = "WHERE nome LIKE '" + nome_razao_social + "'";
                    }
                    else
                    {
                        SqlNomeRazao = "WHERE nome STARTING WITH '" + nome_razao_social + "'";
                    }
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "";
                    }
                    else
                    {
                        SqlData = " AND data_cadastro BETWEEN '" + data.Replace("/", ".") + " 00:00:00" + "' AND '" + data1.Replace("/", ".") + " 23:59:59" + "'";
                    }
                    //
                    if (pessoa == "PESSOA FÍSICA")
                    {
                        SqlPessoa = " AND pessoa=0";
                    }
                    else if (pessoa == "PESSOA JURÍDICA")
                    {
                        SqlPessoa = " AND pessoa=1";
                    }
                    else
                    {
                        SqlPessoa = "";
                    }
                    //
                    if (uf == "")
                    {
                        SqlUf = "";
                    }
                    else
                    {
                        SqlUf = " AND uf='" + uf + "'";
                    }
                    //
                    if (cidade == "")
                    {
                        SqlCidade = "";
                    }
                    else
                    {
                        SqlCidade = " AND cidade='" + cidade + "'";
                    }
                    //
                    if (telefone == "(  )     -")
                    {
                        SqlTelefone = "";
                    }
                    else
                    {
                        SqlTelefone = " AND telefone='" + telefone + "'";
                    }
                    //
                    if (celular == "(  )      -")
                    {
                        SqlCelular = "";
                    }
                    else
                    {
                        SqlCelular = " AND celular='" + celular + "'";
                    }
                    //
                    if (email == "")
                    {
                        SqlEmail = "";
                    }
                    else
                    {
                        if (email.Contains("%"))
                        {
                            SqlEmail = " AND email LIKE '" + email + "'";
                        }
                        else
                        {
                            SqlEmail = " AND email STARTING WITH '" + email + "'";
                        }
                    }
                    //
                    if (cpf_aval == "   .   .   -" || cpf_aval == "___.___.___-__")
                    {
                        SqlCPFAval = "";
                    }
                    else
                    {
                        SqlCPFAval = " AND cpf_avalista='" + cpf_aval + "'";
                    }
                    //
                    if (nome_aval == "")
                    {
                        SqlNomeAval = "";
                    }
                    else
                    {
                        if (nome_aval.Contains("%"))
                        {
                            SqlNomeAval = " AND avalista LIKE '" + nome_aval + "'";
                        }
                        else
                        {
                            SqlNomeAval = " AND avalista STARTING WITH '" + nome_aval + "'";
                        }
                    }
                    //
                    string[] items;
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
                        SqlSubGrupo = "";
                    }
                    else
                    {
                        items = subgrupo.Split('—');
                        SqlSubGrupo = " AND id_subgrupo='" + items[0] + "'";
                    }
                    //
                    return con.Sel_Clie_Data_UF_Cidade_Pessoa_Nome(SqlData, SqlUf, SqlCidade, SqlPessoa, SqlNomeRazao, SqlTelefone, SqlCelular, SqlEmail, SqlCPFAval, SqlNomeAval, SqlGrupo, SqlSubGrupo);
                }
            }
        }

        public static DataTable Sel_Clie_Data_UF_Cidade_Pessoa_CPF_Resp(string data, string data1, string uf, string cidade, string pessoa, string cpf_responsavel, string telefone, string celular, string email, string nome_aval, string cpf_aval, string grupo, string subgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string SqlCPFResp;
                    string SqlData;
                    string SqlUf;
                    string SqlCidade;
                    string SqlPessoa;
                    string SqlTelefone;
                    string SqlCelular;
                    string SqlEmail;
                    string SqlNomeAval;
                    string SqlCPFAval;
                    string SqlGrupo;
                    string SqlSubGrupo;
                    //
                    SqlCPFResp = "WHERE cpf_pai='" + cpf_responsavel + "' or cpf_mae='" + cpf_responsavel + "'";
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "";
                    }
                    else
                    {
                        SqlData = " AND data_cadastro BETWEEN '" + data.Replace("/", ".") + " 00:00:00" + "' AND '" + data1.Replace("/", ".") + " 23:59:59" + "'";
                    }
                    //
                    if (pessoa == "PESSOA FÍSICA")
                    {
                        SqlPessoa = " AND pessoa=0";
                    }
                    else if (pessoa == "PESSOA JURÍDICA")
                    {
                        SqlPessoa = " AND pessoa=1";
                    }
                    else
                    {
                        SqlPessoa = "";
                    }
                    //
                    if (uf == "")
                    {
                        SqlUf = "";
                    }
                    else
                    {
                        SqlUf = " AND uf='" + uf + "'";
                    }
                    //
                    if (cidade == "")
                    {
                        SqlCidade = "";
                    }
                    else
                    {
                        SqlCidade = " AND cidade='" + cidade + "'";
                    }
                    //
                    if (telefone == "(  )     -")
                    {
                        SqlTelefone = "";
                    }
                    else
                    {
                        SqlTelefone = " AND telefone='" + telefone + "'";
                    }
                    //
                    if (celular == "(  )      -")
                    {
                        SqlCelular = "";
                    }
                    else
                    {
                        SqlCelular = " AND celular='" + celular + "'";
                    }
                    //
                    if (email == "")
                    {
                        SqlEmail = "";
                    }
                    else
                    {
                        if (email.Contains("%"))
                        {
                            SqlEmail = " AND email LIKE '" + email + "'";
                        }
                        else
                        {
                            SqlEmail = " AND email STARTING WITH '" + email + "'";
                        }
                    }
                    //
                    if (cpf_aval == "   .   .   -" || cpf_aval == "___.___.___-__")
                    {
                        SqlCPFAval = "";
                    }
                    else
                    {
                        SqlCPFAval = " AND cpf_avalista='" + cpf_aval + "'";
                    }
                    //
                    if (nome_aval == "")
                    {
                        SqlNomeAval = "";
                    }
                    else
                    {
                        if (nome_aval.Contains("%"))
                        {
                            SqlNomeAval = " AND avalista LIKE '" + nome_aval + "'";
                        }
                        else
                        {
                            SqlNomeAval = " AND avalista STARTING WITH '" + nome_aval + "'";
                        }
                    }
                    //
                    string[] items;
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
                        SqlSubGrupo = "";
                    }
                    else
                    {
                        items = subgrupo.Split('—');
                        SqlSubGrupo = " AND id_subgrupo='" + items[0] + "'";
                    }
                    //
                    return con.Sel_Clie_Data_UF_Cidade_Pessoa_CPF_Resp(SqlData, SqlUf, SqlCidade, SqlPessoa, SqlCPFResp, SqlTelefone, SqlCelular, SqlEmail, SqlCPFAval, SqlNomeAval, SqlGrupo, SqlSubGrupo);
                }
            }
        }

        public static DataTable Sel_Cliente_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Pesquisar = pesquisar;
                    return con.Sel_Cliente_Codigo(Clie);
                }
            }
        }

        public static DataTable Sel_Cliente_Codigo_Ativo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Pesquisar = pesquisar;
                    return con.Sel_Cliente_Codigo_Ativo(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_CPFCNPJ(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Pesquisar = pesquisar;
                    if (con.Sel_Clie_CPFCNPJ(Clie) == null)
                    {
                        Clie.Pesquisar = pesquisar.Replace(".", "").Replace("-", "").Replace("/", "");
                        return con.Sel_Clie_CPFCNPJ(Clie);
                    }
                    else
                    {
                        return con.Sel_Clie_CPFCNPJ(Clie);
                    }
                }
            }
        }

        public static DataTable Sel_Clie_CPFCNPJ_Ativo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Pesquisar = pesquisar;
                    if (con.Sel_Clie_CPFCNPJ_Ativo(Clie) == null)
                    {
                        Clie.Pesquisar = pesquisar.Replace(".", "").Replace("-", "").Replace("/", "");
                        return con.Sel_Clie_CPFCNPJ_Ativo(Clie);
                    }
                    else
                    {
                        return con.Sel_Clie_CPFCNPJ_Ativo(Clie);
                    }
                }
            }
        }

        public static DataTable Sel_ComboboxGrupo_Valor_A_Alterar_Clie(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items = cbbgrupo.Split('—');
                    Clie.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxGrupo_Valor_A_Alterar_Clie(Clie);
                }
            }
        }

        public static DataTable Sel_ComboboxSubGrupo_Valor_A_Alterar_Clie(string cbbsubgrupo, string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items = cbbsubgrupo.Split('—');
                    Clie.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    items = cbbgrupo.Split('—');
                    Clie.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxSubGrupo_Valor_A_Alterar_Clie(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_IERG(string pesquisar, byte pessoa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Pesquisar = pesquisar;
                    Clie.Pessoa = pessoa;
                    return con.Sel_Clie_IERG(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_IERG_Ativo(string pesquisar, byte pessoa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Pesquisar = pesquisar;
                    Clie.Pessoa = pessoa;
                    return con.Sel_Clie_IERG_Ativo(Clie);
                }
            }
        }

        public static DataTable Sel_Cliente_CPF_Resp(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Pesquisar = pesquisar;
                    return con.Sel_Cliente_CPF_Resp(Clie);
                }
            }
        }

        public static DataTable Sel_Cliente_CPF_Resp_Ativo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Pesquisar = pesquisar;
                    return con.Sel_Cliente_CPF_Resp_Ativo(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Palavra_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Pesquisar = pesquisar;
                    return con.Sel_Clie_Palavra_Chave(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Palavra_Chave_Ativo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Pesquisar = pesquisar;
                    return con.Sel_Clie_Palavra_Chave_Ativo(Clie);
                }
            }
        }

        public static bool Sel_C_CPF_CNPJ(string cpf_cnpj)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.CPF_CNPJ = cpf_cnpj;
                    return con.Sel_C_CPF_CNPJ(Clie);
                }
            }
        }

        public static bool Sel_C_Palavra_Chave(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Palavra_Chave = palavra_chave;
                    return con.Sel_C_Palavra_Chave(Clie);
                }
            }
        }

        public static bool Sel_Situacao_Cliente_Bloqueado(string codigo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    //
                    Clie.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    return con.Sel_Situacao_Cliente_Bloqueado(Clie);
                }
            }
        }

        public static bool Sel_C_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Palavra_Chave = palavra_chave;
                    if (con.Sel_C_Palavra_Chave_Alt(Clie) == codigo)
                    {
                        return false;
                    }
                    else if (con.Sel_C_Palavra_Chave_Alt(Clie) == null)
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

        public static string Sel_Cliente_Alerta_Observacao(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Cliente_Alerta_Observacao(Clie);
                }
            }
        }

        public static bool Sel_Cliente_Saldo_Creditor_Ver(string consumidor, string valor_real_promissoria)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items = consumidor.Split('—');
                    Clie.Codigo = Convert.ToInt32(items[0]);
                    //
                    DataRow dr = con.Sel_Cliente_Saldo_Creditor_Ver(Clie).Rows[0];
                    //
                    if ((Convert.ToDecimal(dr["saldo"]) + Convert.ToDecimal(valor_real_promissoria)) > Convert.ToDecimal(dr["credito"]))
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

        public static void Baixa_Saldo_Clie(string codigo, string valor_real, string valor_entrada)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    decimal entrada;
                    if (valor_entrada.Contains("."))
                    {
                        entrada = Convert.ToDecimal(valor_entrada.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        entrada = Convert.ToDecimal(valor_entrada.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", ""));
                    }
                    //
                    decimal valor;
                    if (valor_real.Contains("."))
                    {
                        valor = Convert.ToDecimal(valor_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        valor = Convert.ToDecimal(valor_real.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", ""));
                    }
                    //
                    //MessageBox.Show(valor + " " + entrada + " " + con.Sel_Cliente_Saldo(Clie));
                    Clie.Saldo = (valor - entrada) + con.Sel_Cliente_Saldo(Clie);
                    //
                    con.Baixa_Saldo_Clie(Clie);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Atualizar_Saldo_Clie(string codigo, string valor_real)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    decimal valor;
                    if (valor_real.Contains("."))
                    {
                        valor = Convert.ToDecimal(valor_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        valor = Convert.ToDecimal(valor_real.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", ""));
                    }
                    //
                    //MessageBox.Show(valor.ToString() + " " + con.Sel_Cliente_Saldo(Clie).ToString());
                    Clie.Saldo = con.Sel_Cliente_Saldo(Clie) - valor;
                    //
                    con.Atualizar_Saldo_Clie(Clie);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static bool Sel_C_CPF_CNPJ_Alt(string codigo, string cpf_cnpj)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.CPF_CNPJ = cpf_cnpj;
                    if (con.Sel_C_CPF_CNPJ_Alt(Clie) == codigo)
                    {
                        return false;
                    }
                    else if (con.Sel_C_CPF_CNPJ_Alt(Clie) == null)
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

        public static bool Sel_Cliente_Contas_Pagar_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Cliente_Contas_Pagar_Ver(Clie);
                }
            }
        }

        public static bool Sel_Cliente_Contas_Receber_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Cliente_Contas_Receber_Ver(Clie);
                }
            }
        }

        public static bool Sel_Cliente_Devolucao_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Cliente_Devolucao_Ver(Clie);
                }
            }
        }

        public static bool Sel_Cliente_Orcamento_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Cliente_Orcamento_Ver(Clie);
                }
            }
        }

        public static bool Sel_Cliente_Venda_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Cliente_Venda_Ver(Clie);
                }
            }
        }

        public static bool Sel_Cliente_OS_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Cliente_OS_Ver(Clie);
                }
            }
        }

        public static bool Sel_Cliente_DFe_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Cliente_DFe_Ver(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Data_Hora_Ult_Compra(string codigo) 
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Clie_Data_Hora_Ult_Compra(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Total_Compra(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Clie_Total_Compra(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Valor_Total_Compra(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Clie_Valor_Total_Compra(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Valor_Medio_Total_Compra(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Clie_Valor_Medio_Total_Compra(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Qtde_Produto_Compra(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Clie_Qtde_Produto_Compra(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Qtde_Servico_Compra(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Clie_Qtde_Servico_Compra(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Intervalo_Compra(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Clie_Intervalo_Compra(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Conta_Receber_Atrasada(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Clie_Conta_Receber_Atrasada(Clie);
                }
            }
        }

        public static DataTable Sel_Clie_Data_Hora_Ult_Alteracao(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Clie.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Clie_Data_Hora_Ult_Alteracao(Clie);
                }
            }
        }

    }
}
