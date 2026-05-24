using DAL;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BLL
{
    public class bllMinhaEmpresa
    {
        public static string _Url_Imagem;
        public static string _Nome_Arquivo;
        public static bool _Mostrar_Imagem;
        public static bool _Excluir_Imagem;
        public static string _CNPJ_Dados;

        public static void Salvar(string nome_empresa, string cpf, string ie_rg, string fantasia, string endereco, string numero, string complemento, string bairro, string uf, string cidade, string cep, string telefone, string celular, string email, string localizacao, string referencia, string imagem_logo, string genero, string pessoa, string cod_pdv_computador, string nome_empresa_contador, string cpf_contador, string ie_rg_contador, string fantasia_contador, string endereco_contador, string numero_contador, string complemento_contador, string bairro_contador, string uf_contador, string cidade_contador, string cep_contador, string telefone_contador, string celular_contador, string email_contador, string localizacao_contador, string referencia_contador, string genero_contador, string pessoa_contador, string cnpj, string cnpj_contador, string email_empresa, string senha_email_empresa, string crt, string cfop_trib_fora, string cfop_trib_dentro, string cfop_subs_dentro, string cfop_subs_fora, string serie_nfe, string serie_nfce, string codigo_municipio, string inscricao_municipal, bool backup_automatico, string ult_num_nfce, string ult_num_nfe, string ult_num_nfse, bool _ult_num_nfe, bool _ult_num_nfce, bool _ult_num_nfse)
        {
            using (Con7BD con = new Con7BD())
            {
                using (MinhaEmpresa Emp = new MinhaEmpresa())
                {
                    Emp.Codigo = 1;
                    //
                    Emp.Empresa = nome_empresa.Insert(nome_empresa.Length, "'").Insert(0, "'");
                    //
                    if (pessoa == "Pessoa Física")
                    {
                        Emp.Pessoa = 0;
                        Emp.CPF_CNPJ = cpf.Insert(cpf.Length, "'").Insert(0, "'");
                    }
                    else
                    {
                        Emp.Pessoa = 1;
                        Emp.CPF_CNPJ = cnpj.Insert(cnpj.Length, "'").Insert(0, "'");
                    }
                    //
                    if (ie_rg == "")
                    {
                        Emp.IE_RG = "null";
                    }
                    else
                    {
                        Emp.IE_RG = ie_rg.Insert(ie_rg.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fantasia == "")
                    {
                        Emp.Fantasia = "null";
                    }
                    else
                    {
                        Emp.Fantasia = fantasia.Insert(fantasia.Length, "'").Insert(0, "'");
                    }
                    //
                    Emp.Endereco = endereco.Insert(endereco.Length, "'").Insert(0, "'");
                    Emp.Numero = Convert.ToInt32(numero);
                    //
                    if (complemento == "")
                    {
                        Emp.Complemento = "null";
                    }
                    else
                    {
                        Emp.Complemento = complemento.Insert(complemento.Length, "'").Insert(0, "'");
                    }
                    //
                    Emp.Bairro = bairro.Insert(bairro.Length, "'").Insert(0, "'");
                    Emp.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    Emp.Cidade = cidade.Insert(cidade.Length, "'").Insert(0, "'");
                    Emp.Codigo_Municipio = codigo_municipio.Insert(codigo_municipio.Length, "'").Insert(0, "'");
                    Emp.CEP = cep.Insert(cep.Length, "'").Insert(0, "'");
                    //                    
                    if (telefone == "(  )     -" || telefone == "(__) ____-____")
                    {
                        Emp.Telefone = "null";
                    }
                    else
                    {
                        Emp.Telefone = telefone.Insert(telefone.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular == "(  )      -" || celular == "(__) _____-____")
                    {
                        Emp.Celular = "null";
                    }
                    else
                    {
                        Emp.Celular = celular.Insert(celular.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email == "")
                    {
                        Emp.Email = "null";
                    }
                    else
                    {
                        Emp.Email = email.Insert(email.Length, "'").Insert(0, "'");
                    }
                    //
                    if (referencia == "")
                    {
                        Emp.Referencia = "null";
                    }
                    else
                    {
                        Emp.Referencia = referencia.Insert(referencia.Length, "'").Insert(0, "'");
                    }
                    //          
                    if (localizacao == "")
                    {
                        Emp.Localizacao = "null";
                    }
                    else
                    {
                        Emp.Localizacao = localizacao.Insert(localizacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (genero == "")
                    {
                        Emp.Genero = "null";
                    }
                    else
                    {
                        Emp.Genero = genero.Insert(genero.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_empresa_contador == "")
                    {
                        Emp.Empresa_Contador = "null";
                    }
                    else
                    {
                        Emp.Empresa_Contador = nome_empresa_contador.Insert(nome_empresa_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (pessoa_contador == "Pessoa Física")
                    {
                        Emp.Pessoa_Contador = 0;
                        if (cpf_contador == "   .   .   -" || cpf_contador == "___.___.___-__" || cpf_contador == "" || cpf_contador == null)
                        {
                            Emp.CPF_CNPJ_Contador = "null";
                        }
                        else
                        {
                            Emp.CPF_CNPJ_Contador = cpf_contador.Insert(cpf_contador.Length, "'").Insert(0, "'");
                        }
                    }
                    else
                    {
                        Emp.Pessoa_Contador = 1;
                        if (cnpj_contador == "  .   .   /    -" || cnpj_contador == "__.___.___/____-__" || cnpj_contador == "" || cnpj_contador == null)
                        {
                            Emp.CPF_CNPJ_Contador = "null";
                        }
                        else
                        {
                            Emp.CPF_CNPJ_Contador = cnpj_contador.Insert(cnpj_contador.Length, "'").Insert(0, "'");
                        }
                    }
                    //
                    if (ie_rg_contador == "")
                    {
                        Emp.IE_RG_Contador = "null";
                    }
                    else
                    {
                        Emp.IE_RG_Contador = ie_rg_contador.Insert(ie_rg_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fantasia_contador == "")
                    {
                        Emp.Fantasia_Contador = "null";
                    }
                    else
                    {
                        Emp.Fantasia_Contador = fantasia_contador.Insert(fantasia_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (endereco_contador == "")
                    {
                        Emp.Endereco_Contador = "null";
                    }
                    else
                    {
                        Emp.Endereco_Contador = endereco_contador.Insert(endereco_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (numero_contador == "")
                    {
                        Emp.Numero_Contador = 0;
                    }
                    else
                    {
                        Emp.Numero_Contador = Convert.ToInt32(numero_contador);
                    }
                    //
                    if (complemento_contador == "")
                    {
                        Emp.Complemento_Contador = "null";
                    }
                    else
                    {
                        Emp.Complemento_Contador = complemento_contador.Insert(complemento_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (bairro_contador == "")
                    {
                        Emp.Bairro_Contador = "null";
                    }
                    else
                    {
                        Emp.Bairro_Contador = bairro_contador.Insert(bairro_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (uf_contador == "")
                    {
                        Emp.UF_Contador = "null";
                    }
                    else
                    {
                        Emp.UF_Contador = uf_contador.Insert(uf_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cidade_contador == "")
                    {
                        Emp.Cidade_Contador = "null";
                    }
                    else
                    {
                        Emp.Cidade_Contador = cidade_contador.Insert(cidade_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cep_contador == "  .   -")
                    {
                        Emp.CEP_Contador = "null";
                    }
                    else
                    {
                        Emp.CEP_Contador = cep_contador.Insert(cep_contador.Length, "'").Insert(0, "'");
                    }
                    //                    
                    if (telefone_contador == "(  )     -" || telefone_contador == "(__) ____-____")
                    {
                        Emp.Telefone_Contador = "null";
                    }
                    else
                    {
                        Emp.Telefone_Contador = telefone_contador.Insert(telefone_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular_contador == "(  )      -" || celular_contador == "(__) _____-____")
                    {
                        Emp.Celular_Contador = "null";
                    }
                    else
                    {
                        Emp.Celular_Contador = celular_contador.Insert(celular_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email_contador == "")
                    {
                        Emp.Email_Contador = "null";
                    }
                    else
                    {
                        Emp.Email_Contador = email_contador.Insert(email_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (referencia_contador == "")
                    {
                        Emp.Referencia_Contador = "null";
                    }
                    else
                    {
                        Emp.Referencia_Contador = referencia_contador.Insert(referencia_contador.Length, "'").Insert(0, "'");
                    }
                    //          
                    if (localizacao_contador == "")
                    {
                        Emp.Localizacao_Contador = "null";
                    }
                    else
                    {
                        Emp.Localizacao_Contador = localizacao_contador.Insert(localizacao_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (genero_contador == "")
                    {
                        Emp.Genero_Contador = "null";
                    }
                    else
                    {
                        Emp.Genero_Contador = genero_contador.Insert(genero_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email_empresa == "")
                    {
                        Emp.Email_Empresa = "null";
                    }
                    else
                    {
                        Emp.Email_Empresa = email_empresa.Insert(email_empresa.Length, "'").Insert(0, "'");
                    }
                    //
                    if (senha_email_empresa == "")
                    {
                        Emp.Senha_Email_Empresa = "null";
                    }
                    else
                    {
                        Emp.Senha_Email_Empresa = senha_email_empresa.Insert(senha_email_empresa.Length, "'").Insert(0, "'");
                    }
                    //
                    Emp.CRT = crt.Insert(crt.Length, "'").Insert(0, "'");
                    //
                    if (cfop_trib_dentro == "")
                    {
                        Emp.CFOP_Trib_Dentro = 0;
                    }
                    else
                    {
                        Emp.CFOP_Trib_Dentro = Convert.ToInt16(cfop_trib_dentro);
                    }
                    //
                    if (cfop_trib_fora == "")
                    {
                        Emp.CFOP_Trib_Fora = 0;
                    }
                    else
                    {
                        Emp.CFOP_Trib_Fora = Convert.ToInt16(cfop_trib_fora);
                    }
                    //
                    if (cfop_subs_dentro == "")
                    {
                        Emp.CFOP_Subs_Dentro = 0;
                    }
                    else
                    {
                        Emp.CFOP_Subs_Dentro = Convert.ToInt16(cfop_subs_dentro);
                    }
                    //
                    if (cfop_subs_fora == "")
                    {
                        Emp.CFOP_Subs_Fora = 0;
                    }
                    else
                    {
                        Emp.CFOP_Subs_Fora = Convert.ToInt16(cfop_subs_fora);
                    }
                    //
                    if (serie_nfe == "")
                    {
                        Emp.Serie_NFe = 0;
                    }
                    else
                    {
                        Emp.Serie_NFe = Convert.ToInt16(serie_nfe);
                    }
                    //
                    if (serie_nfce == "")
                    {
                        Emp.Serie_NFCe = 0;
                    }
                    else
                    {
                        Emp.Serie_NFCe = Convert.ToInt16(serie_nfce);
                    }
                    //
                    if (inscricao_municipal == "")
                    {
                        Emp.Inscricao_Municipal = "null";
                    }
                    else
                    {
                        Emp.Inscricao_Municipal = inscricao_municipal.Insert(inscricao_municipal.Length, "'").Insert(0, "'");
                    }
                    //
                    if (imagem_logo != null)
                    {
                        Image original = Image.FromFile(imagem_logo);
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
                        Emp.Imagem_Logo = imagemBytes;
                    }
                    //
                    if (backup_automatico == true)
                    {
                        Emp.Backup_Automatico = 1;
                    }
                    else
                    {
                        Emp.Backup_Automatico = 0;
                    }
                    //
                    if (_ult_num_nfe == true)
                    {
                        if (ult_num_nfe == "")
                        {
                            Emp.Ult_Num_NFe = 0;
                        }
                        else
                        {
                            Emp.Ult_Num_NFe = Convert.ToInt32(ult_num_nfe);
                        }
                    }
                    else
                    {
                        Emp.Ult_Num_NFe = 0;
                    }
                    //
                    if (_ult_num_nfce == true)
                    {
                        if (ult_num_nfce == "")
                        {
                            Emp.Ult_Num_NFCe = 0;
                        }
                        else
                        {
                            Emp.Ult_Num_NFCe = Convert.ToInt32(ult_num_nfce);
                        }
                    }
                    else
                    {
                        Emp.Ult_Num_NFCe = 0;
                    }
                    //
                    if (_ult_num_nfse == true)
                    {
                        if (ult_num_nfse == "")
                        {
                            Emp.Ult_Num_NFSe = 0;
                        }
                        else
                        {
                            Emp.Ult_Num_NFSe = Convert.ToInt32(ult_num_nfse);
                        }
                    }
                    else
                    {
                        Emp.Ult_Num_NFSe = 0;
                    }
                    //
                    con.Salvar_Minha_Empresa(Emp);
                }
            }
        }

        public static void Alterar(string nome_empresa, string cpf, string ie_rg, string fantasia, string endereco, string numero, string complemento, string bairro, string uf, string cidade, string cep, string telefone, string celular, string email, string localizacao, string referencia, string imagem_logo, string genero, string pessoa, string cod_pdv_computador, string nome_empresa_contador, string cpf_contador, string ie_rg_contador, string fantasia_contador, string endereco_contador, string numero_contador, string complemento_contador, string bairro_contador, string uf_contador, string cidade_contador, string cep_contador, string telefone_contador, string celular_contador, string email_contador, string localizacao_contador, string referencia_contador, string genero_contador, string pessoa_contador, string cnpj, string cnpj_contador, string email_empresa, string senha_email_empresa, string crt, string cfop_trib_fora, string cfop_trib_dentro, string cfop_subs_dentro, string cfop_subs_fora, string serie_nfe, string serie_nfce, string codigo_municipio, string inscricao_municipal, bool backup_automatico, string ult_num_nfce, string ult_num_nfe, string ult_num_nfse, bool _ult_num_nfe, bool _ult_num_nfce, bool _ult_num_nfse)
        {
            using (Con7BD con = new Con7BD())
            {
                using (MinhaEmpresa Emp = new MinhaEmpresa())
                {
                    Emp.Codigo = 1;
                    //
                    Emp.Empresa = nome_empresa.Insert(nome_empresa.Length, "'").Insert(0, "'");
                    //
                    if (pessoa == "Pessoa Física")
                    {
                        Emp.Pessoa = 0;
                        Emp.CPF_CNPJ = cpf.Insert(cpf.Length, "'").Insert(0, "'");
                    }
                    else
                    {
                        Emp.Pessoa = 1;
                        Emp.CPF_CNPJ = cnpj.Insert(cnpj.Length, "'").Insert(0, "'");
                    }
                    //
                    if (ie_rg == "")
                    {
                        Emp.IE_RG = "null";
                    }
                    else
                    {
                        Emp.IE_RG = ie_rg.Insert(ie_rg.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fantasia == "")
                    {
                        Emp.Fantasia = "null";
                    }
                    else
                    {
                        Emp.Fantasia = fantasia.Insert(fantasia.Length, "'").Insert(0, "'");
                    }
                    //
                    Emp.Endereco = endereco.Insert(endereco.Length, "'").Insert(0, "'");
                    Emp.Numero = Convert.ToInt32(numero);
                    //
                    if (complemento == "")
                    {
                        Emp.Complemento = "null";
                    }
                    else
                    {
                        Emp.Complemento = complemento.Insert(complemento.Length, "'").Insert(0, "'");
                    }
                    //
                    Emp.Bairro = bairro.Insert(bairro.Length, "'").Insert(0, "'");
                    Emp.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    Emp.Cidade = cidade.Insert(cidade.Length, "'").Insert(0, "'");
                    Emp.Codigo_Municipio = codigo_municipio.Insert(codigo_municipio.Length, "'").Insert(0, "'");
                    Emp.CEP = cep.Insert(cep.Length, "'").Insert(0, "'");
                    //                    
                    if (telefone == "(  )     -" || telefone == "(__) ____-____")
                    {
                        Emp.Telefone = "null";
                    }
                    else
                    {
                        Emp.Telefone = telefone.Insert(telefone.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular == "(  )      -" || celular == "(__) _____-____")
                    {
                        Emp.Celular = "null";
                    }
                    else
                    {
                        Emp.Celular = celular.Insert(celular.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email == "")
                    {
                        Emp.Email = "null";
                    }
                    else
                    {
                        Emp.Email = email.Insert(email.Length, "'").Insert(0, "'");
                    }
                    //
                    if (referencia == "")
                    {
                        Emp.Referencia = "null";
                    }
                    else
                    {
                        Emp.Referencia = referencia.Insert(referencia.Length, "'").Insert(0, "'");
                    }
                    //          
                    if (localizacao == "")
                    {
                        Emp.Localizacao = "null";
                    }
                    else
                    {
                        Emp.Localizacao = localizacao.Insert(localizacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (genero == "")
                    {
                        Emp.Genero = "null";
                    }
                    else
                    {
                        Emp.Genero = genero.Insert(genero.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_empresa_contador == "")
                    {
                        Emp.Empresa_Contador = "null";
                    }
                    else
                    {
                        Emp.Empresa_Contador = nome_empresa_contador.Insert(nome_empresa_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (pessoa_contador == "Pessoa Física")
                    {
                        Emp.Pessoa_Contador = 0;
                        if (cpf_contador == "   .   .   -" || cpf_contador == "___.___.___-__" || cpf_contador == null || cpf_contador == "")
                        {
                            Emp.CPF_CNPJ_Contador = "null";
                        }
                        else
                        {
                            Emp.CPF_CNPJ_Contador = cpf_contador.Insert(cpf_contador.Length, "'").Insert(0, "'");
                        }
                    }
                    else
                    {
                        Emp.Pessoa_Contador = 1;
                        if (cnpj_contador == "  .   .   /    -" || cnpj_contador == "__.___.___/____-__" || cnpj_contador == "" || cnpj_contador == null)
                        {
                            Emp.CPF_CNPJ_Contador = "null";
                        }
                        else
                        {
                            Emp.CPF_CNPJ_Contador = cnpj_contador.Insert(cnpj_contador.Length, "'").Insert(0, "'");
                        }
                    }
                    //
                    if (ie_rg_contador == "")
                    {
                        Emp.IE_RG_Contador = "null";
                    }
                    else
                    {
                        Emp.IE_RG_Contador = ie_rg_contador.Insert(ie_rg_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fantasia_contador == "")
                    {
                        Emp.Fantasia_Contador = "null";
                    }
                    else
                    {
                        Emp.Fantasia_Contador = fantasia_contador.Insert(fantasia_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (endereco_contador == "")
                    {
                        Emp.Endereco_Contador = "null";
                    }
                    else
                    {
                        Emp.Endereco_Contador = endereco_contador.Insert(endereco_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (numero_contador == "")
                    {
                        Emp.Numero_Contador = 0;
                    }
                    else
                    {
                        Emp.Numero_Contador = Convert.ToInt32(numero_contador);
                    }
                    //
                    if (complemento_contador == "")
                    {
                        Emp.Complemento_Contador = "null";
                    }
                    else
                    {
                        Emp.Complemento_Contador = complemento_contador.Insert(complemento_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (bairro_contador == "")
                    {
                        Emp.Bairro_Contador = "null";
                    }
                    else
                    {
                        Emp.Bairro_Contador = bairro_contador.Insert(bairro_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (uf_contador == "")
                    {
                        Emp.UF_Contador = "null";
                    }
                    else
                    {
                        Emp.UF_Contador = uf_contador.Insert(uf_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cidade_contador == "")
                    {
                        Emp.Cidade_Contador = "null";
                    }
                    else
                    {
                        Emp.Cidade_Contador = cidade_contador.Insert(cidade_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cep_contador == "  .   -")
                    {
                        Emp.CEP_Contador = "null";
                    }
                    else
                    {
                        Emp.CEP_Contador = cep_contador.Insert(cep_contador.Length, "'").Insert(0, "'");
                    }
                    //                    
                    if (telefone_contador == "(  )     -" || telefone_contador == "(__) ____-____")
                    {
                        Emp.Telefone_Contador = "null";
                    }
                    else
                    {
                        Emp.Telefone_Contador = telefone_contador.Insert(telefone_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular_contador == "(  )      -" || celular_contador == "(__) _____-____")
                    {
                        Emp.Celular_Contador = "null";
                    }
                    else
                    {
                        Emp.Celular_Contador = celular_contador.Insert(celular_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email_contador == "")
                    {
                        Emp.Email_Contador = "null";
                    }
                    else
                    {
                        Emp.Email_Contador = email_contador.Insert(email_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (referencia_contador == "")
                    {
                        Emp.Referencia_Contador = "null";
                    }
                    else
                    {
                        Emp.Referencia_Contador = referencia_contador.Insert(referencia_contador.Length, "'").Insert(0, "'");
                    }
                    //          
                    if (localizacao_contador == "")
                    {
                        Emp.Localizacao_Contador = "null";
                    }
                    else
                    {
                        Emp.Localizacao_Contador = localizacao_contador.Insert(localizacao_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (genero_contador == "")
                    {
                        Emp.Genero_Contador = "null";
                    }
                    else
                    {
                        Emp.Genero_Contador = genero_contador.Insert(genero_contador.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email_empresa == "")
                    {
                        Emp.Email_Empresa = "null";
                    }
                    else
                    {
                        Emp.Email_Empresa = email_empresa.Insert(email_empresa.Length, "'").Insert(0, "'");
                    }
                    //
                    if (senha_email_empresa == "")
                    {
                        Emp.Senha_Email_Empresa = "null";
                    }
                    else
                    {
                        Emp.Senha_Email_Empresa = senha_email_empresa.Insert(senha_email_empresa.Length, "'").Insert(0, "'");
                    }
                    //
                    Emp.CRT = crt.Insert(crt.Length, "'").Insert(0, "'");
                    //
                    if (cfop_trib_dentro == "")
                    {
                        Emp.CFOP_Trib_Dentro = 0;
                    }
                    else
                    {
                        Emp.CFOP_Trib_Dentro = Convert.ToInt16(cfop_trib_dentro);
                    }
                    //
                    if (cfop_trib_fora == "")
                    {
                        Emp.CFOP_Trib_Fora = 0;
                    }
                    else
                    {
                        Emp.CFOP_Trib_Fora = Convert.ToInt16(cfop_trib_fora);
                    }
                    //
                    if (cfop_subs_dentro == "")
                    {
                        Emp.CFOP_Subs_Dentro = 0;
                    }
                    else
                    {
                        Emp.CFOP_Subs_Dentro = Convert.ToInt16(cfop_subs_dentro);
                    }
                    //
                    if (cfop_subs_fora == "")
                    {
                        Emp.CFOP_Subs_Fora = 0;
                    }
                    else
                    {
                        Emp.CFOP_Subs_Fora = Convert.ToInt16(cfop_subs_fora);
                    }
                    //
                    if (serie_nfe == "")
                    {
                        Emp.Serie_NFe = 0;
                    }
                    else
                    {
                        Emp.Serie_NFe = Convert.ToInt16(serie_nfe);
                    }
                    //
                    if (serie_nfce == "")
                    {
                        Emp.Serie_NFCe = 0;
                    }
                    else
                    {
                        Emp.Serie_NFCe = Convert.ToInt16(serie_nfce);
                    }
                    //
                    if (inscricao_municipal == "")
                    {
                        Emp.Inscricao_Municipal = "null";
                    }
                    else
                    {
                        Emp.Inscricao_Municipal = inscricao_municipal.Insert(inscricao_municipal.Length, "'").Insert(0, "'");
                    }
                    //
                    if (backup_automatico == true)
                    {
                        Emp.Backup_Automatico = 1;
                    }
                    else
                    {
                        Emp.Backup_Automatico = 0;
                    }
                    //
                    if (_ult_num_nfe == true)
                    {
                        if (ult_num_nfe == "")
                        {
                            Emp.Ult_Num_NFe = 0;
                        }
                        else
                        {
                            Emp.Ult_Num_NFe = Convert.ToInt32(ult_num_nfe);
                        }
                    }
                    else
                    {
                        Emp.Ult_Num_NFe = 0;
                    }
                    //
                    if (_ult_num_nfce == true)
                    {
                        if (ult_num_nfce == "")
                        {
                            Emp.Ult_Num_NFCe = 0;
                        }
                        else
                        {
                            Emp.Ult_Num_NFCe = Convert.ToInt32(ult_num_nfce);
                        }
                    }
                    else
                    {
                        Emp.Ult_Num_NFCe = 0;
                    }
                    //
                    if (_ult_num_nfse == true)
                    {
                        if (ult_num_nfse == "")
                        {
                            Emp.Ult_Num_NFSe = 0;
                        }
                        else
                        {
                            Emp.Ult_Num_NFSe = Convert.ToInt32(ult_num_nfse);
                        }
                    }
                    else
                    {
                        Emp.Ult_Num_NFSe = 0;
                    }
                    //
                    con.Alterar_Minha_Empresa(Emp);
                }
            }
        }

        public static void Alterar_Imagem_Logo(string codigo, string imagem_logo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (MinhaEmpresa Emp = new MinhaEmpresa())
                {
                    Emp.Codigo = Convert.ToByte(codigo);
                    //
                    bool nulo;
                    if (imagem_logo != null)
                    {
                        Image original = Image.FromFile(imagem_logo);
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
                        Emp.Imagem_Logo = imagemBytes;
                        //
                        nulo = false;
                    }
                    else
                    {
                        nulo = true;
                    }
                    //
                    con.Alterar_Imagem_Logo(Emp, nulo);
                }
            }
        }

        public static DataTable Sel_Cfop_Minha_Empresa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cfop_Minha_Empresa();
            }
        }

        public static string Sel_Cidade_Empresa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cidade_Empresa();
            }
        }

        public static string Sel_CEP_Empresa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_CEP_Empresa();
            }
        }

        public static string Sel_Imagem_Logo_Empresa()
        {
            using (Con7BD con = new Con7BD())
            {
                if (con.Sel_Imagem_Logo_Empresa() != null)
                {
                    string caminhoArquivo;
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\OS"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Logo");
                        caminhoArquivo = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Logo\logo.jpg";
                    }
                    else
                    {
                        caminhoArquivo = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Logo\logo.jpg";
                    }
                    //
                    File.WriteAllBytes(caminhoArquivo, con.Sel_Imagem_Logo_Empresa());

                    return caminhoArquivo;
                }
                else
                {
                    return "";
                }
            }
        }

        public static string Sel_FAX_Empresa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_FAX_Empresa();
            }
        }


        public static string Sel_Empresa_CPFCNPJ()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Empresa_CPFCNPJ();
            }
        }


        public static string Sel_Nome_Empresa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Nome_Empresa();
            }
        }

        public static string Sel_Email_Contador_Contabilidade()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Email_Contador_Contabilidade();
            }
        }

        public static string Sel_Empresa_Fantasia()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Empresa_Fantasia();
            }
        }

        public static string Sel_Empresa_CRT()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Empresa_CRT();
            }
        }

        public static string Sel_Empresa_Serie_NFCe()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Empresa_Serie_NFCe();
            }
        }

        public static string Sel_Empresa_CFOP_Trib_Dentro()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Empresa_CFOP_Trib_Dentro();
            }
        }

        public static string Sel_Empresa_CFOP_Subs_Dentro()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Empresa_CFOP_Subs_Dentro();
            }
        }

        public static string Sel_Empresa_Serie_NFe()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Empresa_Serie_NFe();
            }
        }

        public static bool Sel_Empresa_Backup_Automatico()
        {
            using (Con7BD con = new Con7BD())
            {
                if (con.Sel_Empresa_Backup_Automatico() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static DataTable Sel_Dados_Minha_Empresa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Dados_Minha_Empresa();
            }
        }

        public static int Sel_Empresa_Ult_Num_NFe()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Empresa_Ult_Num_NFe();
            }
        }

        public static int Sel_Empresa_Ult_Num_NFCe()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Empresa_Ult_Num_NFCe();
            }
        }

        public static void Alterar_Ult_Num_NFe()
        {
            using (Con7BD con = new Con7BD())
            {
                using (MinhaEmpresa Emp = new MinhaEmpresa())
                {
                    Emp.Codigo = 1;
                    //
                    Emp.Ult_Num_NFe = 0;
                    //
                    con.Alterar_Ult_Num_NFe(Emp);
                }
            }
        }

        public static void Alterar_Ult_Num_NFCe()
        {
            using (Con7BD con = new Con7BD())
            {
                using (MinhaEmpresa Emp = new MinhaEmpresa())
                {
                    Emp.Codigo = 1;
                    //
                    Emp.Ult_Num_NFCe = 0;
                    //
                    con.Alterar_Ult_Num_NFCe(Emp);
                }
            }
        }
    }
}

