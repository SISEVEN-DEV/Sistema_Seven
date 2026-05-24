using DAL;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BLL
{
    public class bllFuncionario
    {
        public static bool _FrmCadFuncionario_Ativo;
        public static bool _FrmRelFuncionario_Ativo;
        public static string _Url_Imagem;
        public static string _Nome_Arquivo;
        public static bool _Mostrar_Imagem;
        public static bool _Excluir_Imagem;

        public static string _Funcao_PesqFuncao_Tabela;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static string _Cod_Funcionario_Cadastro;

        public static void Alterar(string codigo, string nome, string cpf, string rg, string telefone, string cep, string endereco, string cidade, string uf, string complemento, string bairro, string email, string celular, string numero, string fax, string d_nascimento, string observacoes, string sexo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    Func.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Func.Palavra_Chave = "null";
                    }
                    else
                    {
                        Func.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    if (rg == "" || rg == null)
                    {
                        Func.RG = "null";
                    }
                    else
                    {
                        Func.RG = rg.Insert(rg.Length, "'").Insert(0, "'");
                    }
                    //                    
                    if (telefone == "(__) ____-____" || telefone == "(  )     -" || telefone == "" || telefone == null)
                    {
                        Func.Telefone = "null";
                    }
                    else
                    {
                        Func.Telefone = telefone.Insert(telefone.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular == "(__) _____-____" || celular == "(  )      -" || celular == "" || celular == null)
                    {
                        Func.Celular = "null";
                    }
                    else
                    {
                        Func.Celular = celular.Insert(celular.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fax == "(__) ____-____" || fax == "(  )     -" || fax == "" || fax == null)
                    {
                        Func.FAX = "null";
                    }
                    else
                    {
                        Func.FAX = fax.Insert(fax.Length, "'").Insert(0, "'");
                    }
                    //
                    Func.Endereco = endereco.Insert(endereco.Length, "'").Insert(0, "'");
                    //
                    Func.Numero = Convert.ToInt32(numero);
                    //
                    Func.Bairro = bairro.Insert(bairro.Length, "'").Insert(0, "'");

                    Func.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    //
                    if (cpf == "___.___.___-__" || cpf == "   .   .   -" || cpf == "" || cpf == null)
                    {
                        Func.CPF = "null";
                    }
                    else
                    {
                        Func.CPF = cpf.Insert(cpf.Length, "'").Insert(0, "'");
                    }
                    //
                    if (complemento == "" || complemento == null)
                    {
                        Func.Complemento = "null";
                    }
                    else
                    {
                        Func.Complemento = complemento.Insert(complemento.Length, "'").Insert(0, "'");
                    }
                    //             
                    Func.CEP = cep.Insert(cep.Length, "'").Insert(0, "'");
                    Func.Cidade = cidade.Insert(cidade.Length, "'").Insert(0, "'");
                    //                   
                    if (email == "" || email == null)
                    {
                        Func.Email = "null";
                    }
                    else
                    {
                        Func.Email = email.Insert(email.Length, "'").Insert(0, "'");
                    }
                    //
                    if (d_nascimento == "" || d_nascimento == "__/__/____" || d_nascimento == "  /  /" || d_nascimento == "" || d_nascimento == null)
                    {
                        Func.Data_Nascimento = "null";
                    }
                    else
                    {
                        Func.Data_Nascimento = d_nascimento.Insert(d_nascimento.Length, "'").Insert(0, "'").Replace('/', '.');
                    }
                    //
                    if (observacoes == "" || observacoes == null)
                    {
                        Func.Observacao = "null";
                    }
                    else
                    {
                        Func.Observacao = observacoes.Insert(observacoes.Length, "'").Insert(0, "'");
                    }
                    //
                    if (sexo == "" || sexo == null)
                    {
                        Func.Sexo = "null";
                    }
                    else
                    {
                        Func.Sexo = sexo.Insert(sexo.Length, "'").Insert(0, "'");
                    }
                    //           
                   
                    con.Alterar_Funcionario(Func);
                }
            }
        }

        public static bool Sel_Funcionario_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Funcionario_Ainda_Existe(Func);
                }
            }
        }

        public static void Alterar_Func_Conta_Receber(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    Func.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Func_Conta_Receber(Func);
                }
            }
        }

        public static void Alterar_Func_Conta_Pagar(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    Func.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Func_Conta_Pagar(Func);
                }
            }
        }

        public static void Alterar_Func_Usuario(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    Func.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_Func_Usuario(Func);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Funcionario(Func);
                }
            }
        }

        public static void Salvar(string nome, string cpf, string rg, string telefone, string cep, string endereco, string cidade, string uf, string complemento, string bairro, string email, string celular, string numero, string fax, string d_nascimento, string observacoes, string sexo, string palavra_chave, string imagem_func, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Nome = nome.Insert(nome.Length, "'").Insert(0, "'");
                    Func.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Func.Palavra_Chave = "null";
                    }
                    else
                    {
                        Func.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    if (rg == "" || rg == null)
                    {
                        Func.RG = "null";
                    }
                    else
                    {
                        Func.RG = rg.Insert(rg.Length, "'").Insert(0, "'");
                    }
                    //                    
                    if (telefone == "(__) ____-____" || telefone == "(  )     -" || telefone == "" || telefone == null)
                    {
                        Func.Telefone = "null";
                    }
                    else
                    {
                        Func.Telefone = telefone.Insert(telefone.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular == "(__) _____-____" || celular == "(  )      -" || celular == "" || celular == null)
                    {
                        Func.Celular = "null";
                    }
                    else
                    {
                        Func.Celular = celular.Insert(celular.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fax == "(__) ____-____" || fax == "(  )     -" || fax == "" || fax == null)
                    {
                        Func.FAX = "null";
                    }
                    else
                    {
                        Func.FAX = fax.Insert(fax.Length, "'").Insert(0, "'");
                    }
                    //
                    Func.Endereco = endereco.Insert(endereco.Length, "'").Insert(0, "'");
                    //
                    Func.Numero = Convert.ToInt32(numero);
                    //
                    Func.Bairro = bairro.Insert(bairro.Length, "'").Insert(0, "'");
                    Func.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    //
                    if (cpf == "___.___.___-__" || cpf == "   .   .   -" || cpf == "" || cpf == null)
                    {
                        Func.CPF = "null";
                    }
                    else
                    {
                        Func.CPF = cpf.Insert(cpf.Length, "'").Insert(0, "'");
                    }
                    //
                    if (complemento == "" || complemento == null)
                    {
                        Func.Complemento = "null";
                    }
                    else
                    {
                        Func.Complemento = complemento.Insert(complemento.Length, "'").Insert(0, "'");
                    }
                    //              
                    Func.CEP = cep.Insert(cep.Length, "'").Insert(0, "'");
                    Func.Cidade = cidade.Insert(cidade.Length, "'").Insert(0, "'");
                    //
                    if (email == "" || email == null)
                    {
                        Func.Email = "null";
                    }
                    else
                    {
                        Func.Email = email.Insert(email.Length, "'").Insert(0, "'");
                    }
                    //
                    if (d_nascimento == "" || d_nascimento == "__/__/____" || d_nascimento == "  /  /" || d_nascimento == "" || d_nascimento == null)
                    {
                        Func.Data_Nascimento = "null";
                    }
                    else
                    {
                        Func.Data_Nascimento = d_nascimento.Insert(d_nascimento.Length, "'").Insert(0, "'").Replace('/', '.');
                    }
                    //
                    if (observacoes == "" || observacoes == null)
                    {
                        Func.Observacao = "null";
                    }
                    else
                    {
                        Func.Observacao = observacoes.Insert(observacoes.Length, "'").Insert(0, "'");
                    }
                    //
                    if (sexo == "" || sexo == null)
                    {
                        Func.Sexo = "null";
                    }
                    else
                    {
                        Func.Sexo = sexo.Insert(sexo.Length, "'").Insert(0, "'");
                    }
                    //
                    if (imagem_func != null)
                    {
                        Image original = Image.FromFile(imagem_func);
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
                        Func.Imagem_Func = imagemBytes;
                    }
                    //
                    con.Salvar_Funcionario(Func);
                }
            }
        }

        public static void Alterar_Imagem_Funcionario(string codigo, string imagem_func)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    //
                    bool nulo;
                    if (imagem_func != null)
                    {
                        Image original = Image.FromFile(imagem_func);
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
                        Func.Imagem_Func = imagemBytes;
                        //
                        nulo = false;
                    }
                    else
                    {
                        nulo = true;
                    }
                    //
                    con.Alterar_Imagem_Funcionario(Func, nulo);
                }
            }
        }

        public static DataTable Sel_Funcionario_A_Salvar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Funcionario_A_Salvar();
            }
        }

        public static DataTable Sel_Func_Data_UF_Cidade_Nome_Email_Telefone_Celular(string nome, string data, string data1, string uf, string cidade, string telefone, string celular, string email)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                string SqlUf;
                string SqlCidade;
                string SqlTelefone;
                string SqlCelular;
                string SqlEmail;
                string SqlNome;
                //
                if (nome == "")
                {
                    SqlNome = "";
                }
                else
                {
                    if (nome.Contains("%"))
                    {
                        SqlNome = "WHERE nome LIKE '" + nome + "'";
                    }
                    else
                    {
                        SqlNome = "WHERE nome STARTING WITH '" + nome + "'";
                    }
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
                return con.Sel_Func_Data_UF_Cidade_Nome_Email_Telefone_Celular(SqlNome, SqlData, SqlUf, SqlCidade, SqlTelefone, SqlCelular, SqlEmail);
            }
        }

        public static DataTable Sel_Func_Data_UF_Cidade_Pessoa_Todos(string data, string data1, string uf, string cidade, string telefone, string celular, string email)
        {
            using (Con7BD con = new Con7BD())
            {
                string SqlData;
                string SqlUf;
                string SqlCidade;
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
                return con.Sel_Func_Data_UF_Cidade_Pessoa_Todos(SqlData, SqlUf, SqlCidade, SqlTelefone, SqlCelular, SqlEmail);
            }
        }

        public static DataTable Sel_Funcionario_A_Alterar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Funcionario_A_Alterar(Func);
                }
            }
        }

        public static DataTable Sel_Funcionario_Nome(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    if (pesquisar.Contains("%"))
                    {
                        Func.Pesquisar = pesquisar;
                        return con.Sel_Funcionario_Nome_Like(Func);
                    }
                    else
                    {
                        Func.Pesquisar = pesquisar;
                        return con.Sel_Funcionario_Nome(Func);
                    }
                }
            }
        }

        public static DataTable Sel_Funcionario_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Funcionario_Todos();
            }
        }

        public static DataTable Sel_Funcionario_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Pesquisar = pesquisar;
                    return con.Sel_Funcionario_Codigo(Func);
                }
            }
        }

        public static DataTable Sel_Funcionario_CPF(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Pesquisar = pesquisar;
                    return con.Sel_Funcionario_CPF(Func);
                }
            }
        }

        public static DataTable Sel_Funcionario_RG(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Prof = new Funcionario())
                {
                    Prof.Pesquisar = pesquisar;
                    return con.Sel_Funcionario_RG(Prof);
                }
            }
        }

        public static bool Sel_Func_Palavra_Chave(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Palavra_Chave = palavra_chave;
                    return con.Sel_Func_Palavra_Chave(Func);
                }
            }
        }

        public static bool Sel_Func_Palavra_chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    Func.Palavra_Chave = palavra_chave;
                    if (con.Sel_Func_Palavra_chave_Alt(Func) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Func_Palavra_chave_Alt(Func) == 0)
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

        public static bool Sel_Func_RG(string rg)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.RG = rg;
                    return con.Sel_Func_RG(Func);
                }
            }
        }

        public static bool Sel_Func_RG_Alt(string codigo, string rg)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    Func.RG = rg;
                    if (con.Sel_Func_RG_Alt(Func) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Func_RG_Alt(Func) == 0)
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

        public static bool Sel_Func_CNPJCPF(string cnpjcpf)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.CPF = cnpjcpf;
                    return con.Sel_Func_CNPJCPF(Func);
                }
            }
        }

        public static bool Sel_Func_CNPJCPF_Alt(string codigo, string cnpjcpf)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Codigo = Convert.ToInt16(codigo);
                    Func.CPF = cnpjcpf;
                    if (con.Sel_Func_CNPJCPF_Alt(Func) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Func_CNPJCPF_Alt(Func) == 0)
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

        public static DataTable Sel_Funcionario_Palavra_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Funcionario Func = new Funcionario())
                {
                    Func.Pesquisar = pesquisar;
                    return con.Sel_Funcionario_Palavra_Chave(Func);
                }
            }
        }
    }
}
