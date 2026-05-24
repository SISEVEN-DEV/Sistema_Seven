using DAL;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace BLL
{
    public class bllFornecedor
    {
        public static string _Url_Imagem;
        public static string _Nome_Arquivo;
        public static bool _Mostrar_Imagem;
        public static bool _Excluir_Imagem;
        public static bool _FrmCadFornecedor_Ativo;
        public static bool _FrmRelFornecedor_Ativo;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Cod_Forn_Cadastro;
        public static string _CNPJ_PesqCNPJ_Tabela;

        public static void Alterar(string codigo, string nome, string cpf_cnpj, string ie_rg, string telefone, string cep, string endereco, string cidade, string uf, string complemento, string bairro, string email, string celular, string numero, string fax, string fantasia, string d_nascimento, string observacoes, string pessoa, string sexo, string palavra_chave, string cod_pdv_computador, string codigo_municipio)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    Forn.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Forn.Palavra_Chave = "null";
                    }
                    else
                    {
                        Forn.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    if (ie_rg == "" || ie_rg == null)
                    {
                        Forn.IE_RG = "null";
                    }
                    else
                    {
                        Forn.IE_RG = ie_rg.Insert(ie_rg.Length, "'").Insert(0, "'");
                    }
                    //                    
                    if (telefone == "(__) ____-____" || telefone == "(  )     -" || telefone == "" || telefone == null)
                    {
                        Forn.Telefone = "null";
                    }
                    else
                    {
                        Forn.Telefone = telefone.Insert(telefone.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular == "(__) _____-____" || celular == "(  )      -" || celular == "" || celular == null)
                    {
                        Forn.Celular = "null";
                    }
                    else
                    {
                        Forn.Celular = celular.Insert(celular.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fax == "(__) ____-____" || fax == "(  )     -" || fax == "" || fax == null)
                    {
                        Forn.FAX = "null";
                    }
                    else
                    {
                        Forn.FAX = fax.Insert(fax.Length, "'").Insert(0, "'");
                    }
                    //
                    Forn.Endereco = endereco.Insert(endereco.Length, "'").Insert(0, "'");
                    //
                    if (Regex.IsMatch(numero, @"\d"))
                    {
                        Forn.Numero = Convert.ToInt32(Regex.Replace(numero, @"\D", ""));
                    }
                    else
                    {
                        Forn.Numero = 0;
                    }
                    //
                    Forn.Bairro = bairro.Insert(bairro.Length, "'").Insert(0, "'");
                    Forn.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    if (cpf_cnpj == "___.___.___-__" || cpf_cnpj == "   .   .   -" || cpf_cnpj == "  .   .   /    -" || cpf_cnpj == "__.___.___/____-__" || cpf_cnpj == "" || cpf_cnpj == null)
                    {
                        Forn.CPF_CNPJ = "null";
                    }
                    else
                    {
                        Forn.CPF_CNPJ = cpf_cnpj.Insert(cpf_cnpj.Length, "'").Insert(0, "'");
                    }
                    //
                    if (complemento == "" || complemento == null)
                    {
                        Forn.Complemento = "null";
                    }
                    else
                    {
                        Forn.Complemento = complemento.Insert(complemento.Length, "'").Insert(0, "'");
                    }
                    //              
                    Forn.CEP = cep.Insert(cep.Length, "'").Insert(0, "'");
                    Forn.Cidade = cidade.Insert(cidade.Length, "'").Insert(0, "'");
                    //
                    if (email == "" || email == null)
                    {
                        Forn.Email = "null";
                    }
                    else
                    {
                        Forn.Email = email.Insert(email.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fantasia == "" || fantasia == null)
                    {
                        Forn.Fantasia = "null";
                    }
                    else
                    {
                        Forn.Fantasia = fantasia.Insert(fantasia.Length, "'").Insert(0, "'");
                    }
                    //                    
                    if (pessoa == "Pessoa Física")
                    {
                        Forn.Pessoa = 0;
                    }
                    else
                    {
                        Forn.Pessoa = 1;
                    }
                    //
                    if (d_nascimento == "" || d_nascimento == "__/__/____" || d_nascimento == "  /  /" || d_nascimento == "" || d_nascimento == null)
                    {
                        Forn.Data_Nascimento = "null";
                    }
                    else
                    {
                        Forn.Data_Nascimento = d_nascimento.Insert(d_nascimento.Length, "'").Insert(0, "'").Replace('/', '.');
                    }
                    //
                    if (observacoes == "" || observacoes == null)
                    {
                        Forn.Observacao = "null";
                    }
                    else
                    {
                        Forn.Observacao = observacoes.Insert(observacoes.Length, "'").Insert(0, "'");
                    }
                    if (sexo == "" || sexo == null)
                    {
                        Forn.Genero = "null";
                    }
                    else
                    {
                        Forn.Genero = sexo.Insert(sexo.Length, "'").Insert(0, "'");
                    }
                    //
                    Forn.Codigo_Municipio = codigo_municipio.Insert(codigo_municipio.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Forn(Forn);
                }
            }
        }

        public static void Alterar_Forn_Conta_Pagar(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    Forn.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Forn_Conta_Pagar(Forn);
                }
            }
        }

        public static void Alterar_Forn_DFe(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    Forn.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Forn_DFe(Forn);
                }
            }
        }

        public static void Alterar_Forn_Transportador(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    Forn.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Forn_Transportador(Forn);
                }
            }
        }

        public static void Alterar_Forn_Conta_Receber(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    Forn.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Forn_Conta_Receber(Forn);
                }
            }
        }

        public static void Salvar(string nome, string cpf_cnpj, string ie_rg, string telefone, string cep, string endereco, string cidade, string uf, string complemento, string bairro, string email, string celular, string numero, string fax, string fantasia, string d_nascimento, string observacoes, string pessoa, string sexo, string palavra_chave, string imagem_forn, string cod_pdv_computador, string codigo_municipio)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    //
                    Forn.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Forn.Palavra_Chave = "null";
                    }
                    else
                    {
                        Forn.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    if (ie_rg == "" || ie_rg == null)
                    {
                        Forn.IE_RG = "null";
                    }
                    else
                    {
                        Forn.IE_RG = ie_rg.Insert(ie_rg.Length, "'").Insert(0, "'");
                    }
                    //                    
                    if (telefone == "(__) ____-____" || telefone == "(  )     -" || telefone == "" || telefone == null)
                    {
                        Forn.Telefone = "null";
                    }
                    else
                    {
                        Forn.Telefone = telefone.Insert(telefone.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular == "(__) _____-____" || celular == "(  )      -" || celular == "" || celular == null)
                    {
                        Forn.Celular = "null";
                    }
                    else
                    {
                        Forn.Celular = celular.Insert(celular.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fax == "(__) ____-____" || fax == "(  )     -" || fax == "" || fax == null)
                    {
                        Forn.FAX = "null";
                    }
                    else
                    {
                        Forn.FAX = fax.Insert(fax.Length, "'").Insert(0, "'");
                    }
                    //
                    Forn.Endereco = endereco.Insert(endereco.Length, "'").Insert(0, "'");
                    //
                    if (Regex.IsMatch(numero, @"\d"))
                    {
                        Forn.Numero = Convert.ToInt32(Regex.Replace(numero, @"\D", ""));
                    }
                    else
                    {
                        Forn.Numero = 0;
                    }
                    //
                    Forn.Bairro = bairro.Insert(bairro.Length, "'").Insert(0, "'");
                    Forn.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    if (cpf_cnpj == "___.___.___-__" || cpf_cnpj == "   .   .   -" || cpf_cnpj == "  .   .   /    -" || cpf_cnpj == "__.___.___/____-__" || cpf_cnpj == "" || cpf_cnpj == null)
                    {
                        Forn.CPF_CNPJ = "null";
                    }
                    else
                    {
                        Forn.CPF_CNPJ = cpf_cnpj.Insert(cpf_cnpj.Length, "'").Insert(0, "'");
                    }
                    //
                    if (complemento == "" || complemento == null)
                    {
                        Forn.Complemento = "null";
                    }
                    else
                    {
                        Forn.Complemento = complemento.Insert(complemento.Length, "'").Insert(0, "'");
                    }
                    //              
                    Forn.CEP = cep.Insert(cep.Length, "'").Insert(0, "'");
                    Forn.Cidade = cidade.Insert(cidade.Length, "'").Insert(0, "'");
                    //
                    if (email == "" || email == null)
                    {
                        Forn.Email = "null";
                    }
                    else
                    {
                        Forn.Email = email.Insert(email.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fantasia == "" || fantasia == null)
                    {
                        Forn.Fantasia = "null";
                    }
                    else
                    {
                        Forn.Fantasia = fantasia.Insert(fantasia.Length, "'").Insert(0, "'");
                    }
                    //                    
                    if (pessoa == "Pessoa Física")
                    {
                        Forn.Pessoa = 0;
                    }
                    else
                    {
                        Forn.Pessoa = 1;
                    }
                    //
                    if (d_nascimento == "" || d_nascimento == null || d_nascimento == "__/__/____" || d_nascimento == "  /  /" || d_nascimento == "")
                    {
                        Forn.Data_Nascimento = "null";
                    }
                    else
                    {
                        Forn.Data_Nascimento = d_nascimento.Insert(d_nascimento.Length, "'").Insert(0, "'").Replace('/', '.');
                    }
                    //
                    if (observacoes == "" || observacoes == null)
                    {
                        Forn.Observacao = "null";
                    }
                    else
                    {
                        Forn.Observacao = observacoes.Insert(observacoes.Length, "'").Insert(0, "'");
                    }
                    if (sexo == "" || sexo == null)
                    {
                        Forn.Genero = "null";
                    }
                    else
                    {
                        Forn.Genero = sexo.Insert(sexo.Length, "'").Insert(0, "'");
                    }
                    //
                    Forn.Codigo_Municipio = codigo_municipio.Insert(codigo_municipio.Length, "'").Insert(0, "'");
                    //
                    if (imagem_forn != null)
                    {
                        Image original = Image.FromFile(imagem_forn);
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
                        Forn.Imagem_Forn= imagemBytes;
                    }
                    //
                    con.Salvar_Forn(Forn);
                }
            }
        }

        public static void Alterar_Imagem_Forn(string codigo, string imagem_forn)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    //
                    bool nulo;
                    if (imagem_forn != null)
                    {
                        Image original = Image.FromFile(imagem_forn);
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
                        Forn.Imagem_Forn = imagemBytes;
                        //
                        nulo = false;
                    }
                    else
                    {
                        nulo = true;
                    }
                    //
                    con.Alterar_Imagem_Forn(Forn, nulo);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Forn(Forn);
                }
            }
        }

        public static bool Sel_Fornecedor_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Fornecedor_Ainda_Existe(Forn);
                }
            }
        }

        public static DataTable Sel_F_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_F_A_Alt(Forn);
                }
            }
        }

        public static DataTable Sel_F_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_F_A_Sal();
            }
        }

        public static DataTable Sel_F_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_F_Todos();
            }
        }

        public static DataTable Sel_F_Nome(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Forn.Pesquisar = pesquisar;
                        return con.Sel_F_Nome_Like(Forn);
                    }
                    else
                    {
                        Forn.Pesquisar = pesquisar;
                        return con.Sel_F_Nome(Forn);
                    }
                }
            }
        }

        public static DataTable Sel_F_IERG(string pesquisar, byte pessoa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Pesquisar = pesquisar;
                    Forn.Pessoa = pessoa;
                    return con.Sel_F_IERG(Forn);
                }
            }
        }

        public static DataTable Sel_F_Cod(string pesquisa)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Pesquisar = pesquisa;
                    return con.Sel_F_Cod(Forn);
                }
            }
        }

        public static DataTable Sel_F_Palavra_chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Pesquisar = pesquisar;
                    return con.Sel_F_Palavra_chave(Forn);
                }
            }
        }

        public static DataTable Sel_F_Cpf(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Pesquisar = pesquisar;
                    return con.Sel_F_Cpf(Forn);
                }
            }
        }

        public static DataTable Sel_F_Cnpj(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Pesquisar = pesquisar;
                    return con.Sel_F_Cnpj(Forn);
                }
            }
        }

        public static bool Sel_F_CNPJCPF(string cnpjcpf)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.CPF_CNPJ = cnpjcpf;
                    return con.Sel_F_CNPJCPF(Forn);
                }
            }
        }

        public static bool Sel_F_CNPJCPF_Alt(string codigo, string cnpjcpf)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    Forn.CPF_CNPJ = cnpjcpf;
                    if (con.Sel_F_CNPJCPF_Alt(Forn) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_F_CNPJCPF_Alt(Forn) == 0)
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

        public static bool Sel_F_RG_alt(string codigo, string ierg)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    Forn.IE_RG = ierg;
                    if (con.Sel_F_RG_Alt(Forn) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_F_RG_Alt(Forn) == 0)
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

        public static bool Sel_F_IE_alt(string codigo, string ierg)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    Forn.IE_RG = ierg;
                    if (con.Sel_F_IE_Alt(Forn) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_F_IE_Alt(Forn) == 0)
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

        public static bool Sel_F_Ie(string ierg)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.IE_RG = ierg;
                    return con.Sel_F_Ie(Forn);
                }
            }
        }

        public static bool Sel_Forn_Palavra_chave(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Palavra_Chave = palavra_chave;
                    return con.Sel_Forn_Palavra_chave(Forn);
                }
            }
        }

        public static bool Sel_Forn_Palavra_chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    Forn.Palavra_Chave = palavra_chave;
                    if (con.Sel_Forn_Palavra_chave_Alt(Forn) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Forn_Palavra_chave_Alt(Forn) == 0)
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

        public static bool Sel_F_Rg(string ierg)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.IE_RG = ierg;
                    return con.Sel_F_Rg(Forn);
                }
            }
        }

        public static DataTable Sel_Forn_Data_UF_Cidade_Pessoa_Todos(string data, string data1, string uf, string cidade, string pessoa, string telefone, string celular, string email)
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
                    return con.Sel_Forn_Data_UF_Cidade_Pessoa_Todos(SqlData, SqlUf, SqlCidade, SqlPessoa, SqlTelefone, SqlCelular, SqlEmail);
                }
            }
        }

        public static DataTable Sel_Forn_Data_UF_Cidade_Pessoa_Nome(string data, string nome_razao_social, string data1, string uf, string cidade, string pessoa, string telefone, string celular, string email)
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
                    string SqlNome_razao_social;

                    if (nome_razao_social.Contains("%"))
                    {
                        SqlNome_razao_social = "WHERE nome LIKE '" + nome_razao_social + "'";
                    }
                    else
                    {
                        SqlNome_razao_social = "WHERE nome STARTING WITH '" + nome_razao_social + "'";
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
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "";
                    }
                    else
                    {
                        SqlData = " AND data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
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
                    return con.Sel_Forn_Data_UF_Cidade_Pessoa_Nome(SqlData, SqlUf, SqlCidade, SqlPessoa, SqlTelefone, SqlCelular, SqlEmail, SqlNome_razao_social);
                }
            }
        }

      

        public static bool Sel_Forn_Conta_Pagar_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Forn_Conta_Pagar_Ver(Forn);
                }
            }
        }

        public static bool Sel_Forn_Conta_Receber_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Forn_Conta_Receber_Ver(Forn);
                }
            }
        }

        public static bool Sel_Forn_DFe_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Forn_DFe_Ver(Forn);
                }
            }
        }

        public static bool Sel_Forn_Transportador_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Fornecedor Forn = new Fornecedor())
                {
                    Forn.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Forn_Transportador_Ver(Forn);
                }
            }
        }
    }
}
