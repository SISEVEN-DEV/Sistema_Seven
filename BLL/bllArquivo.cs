using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class bllArquivo
    {
        public static bool _FrmCadArquivo_Ativo;

        public static void Salvar(string palavra_chave, string descricao, string tabela, string caminho, string observacao) 
        {
            using (Con7BD con = new Con7BD()) 
            {
                using (Arquivo Arq = new Arquivo()) 
                {
                    Arq.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Arq.Tabela = tabela.Insert(tabela.Length, "'").Insert(0, "'");
                    //
                    Arq.Caminho = caminho.Insert(caminho.Length, "'").Insert(0, "'");
                    //
                    if (observacao == "")
                    {
                        Arq.Observacao = "null";
                    }
                    else
                    {
                        Arq.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (palavra_chave == "")
                    {
                        Arq.Palavra_Chave = "null";
                    }
                    else
                    {
                        Arq.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Salvar_Arquivo(Arq);        
                }  
            }
        }

        public static void Salvar_Configuracoes(bool excluir_arq_diretorio, bool sel_varios_tipo_arq) 
        {
            using (ConOperationBD con = new ConOperationBD()) 
            {
                using (Arquivo Arq = new Arquivo()) 
                {
                    if (excluir_arq_diretorio == false)
                    {
                        Arq.Excluir_Arquivo_Dir = 0;
                    }
                    else
                    {
                        Arq.Excluir_Arquivo_Dir = 1;
                    }
                    //
                    if (sel_varios_tipo_arq == false)
                    {
                        Arq.Sel_Varios_Tipo_Arq = 0;
                    }
                    else
                    {
                        Arq.Sel_Varios_Tipo_Arq = 1;
                    }
                    con.Salvar_Config_Arquivo(Arq);
                }            
            }        
        }

        public static void Alterar_Configuracoes(bool excluir_arq_diretorio, bool sel_varios_tipo_arq) 
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    if (excluir_arq_diretorio == false)
                    {
                        Arq.Excluir_Arquivo_Dir = 0;
                    }
                    else 
                    {
                        Arq.Excluir_Arquivo_Dir = 1;
                    }
                    //
                    if (sel_varios_tipo_arq == false)
                    {
                        Arq.Sel_Varios_Tipo_Arq = 0;
                    }
                    else
                    {
                        Arq.Sel_Varios_Tipo_Arq = 1;
                    }
                    con.Alterar_Config_Arquivo(Arq);
                }
            }        
        }

        public static DataTable Sel_Tabela_Arquivo_Configuracoes() 
        {
            using (ConOperationBD con = new ConOperationBD()) 
            {
               return con.Sel_Tabela_Arquivo_Configuracoes();
            }        
        }

        public static void Alterar(string codigo, string palavra_chave, string descricao, string tabela, string caminho, string observacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    Arq.Codigo = Convert.ToInt16(codigo);
                    //
                    Arq.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Arq.Tabela = tabela.Insert(tabela.Length, "'").Insert(0, "'");
                    //
                    Arq.Caminho = caminho.Insert(caminho.Length, "'").Insert(0, "'");
                    //
                    if (observacao == "")
                    {
                        Arq.Observacao = "null";
                    }
                    else
                    {
                        Arq.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (palavra_chave == "")
                    {
                        Arq.Palavra_Chave = "null";
                    }
                    else
                    {
                        Arq.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Alterar_Arquivo(Arq);
                }
            }
        }

        public static void Excluir(string codigo) 
        {
            using (Con7BD con = new Con7BD()) 
            {
                using (Arquivo Arq = new Arquivo()) 
                {
                    Arq.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Arquivo(Arq);
                }
            }        
        }

        public static DataTable Sel_Arquivo_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Arquivo_A_Sal();
            }
        }

        public static DataTable Sel_Arquivo_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    Arq.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Arquivo_A_Alt(Arq);
                }
            }
        }

        public static DataTable Sel_Arquivo_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    Arq.Pesquisar = pesquisar;
                    return con.Sel_Arquivo_Descricao(Arq);
                }
            }
        }

        public static DataTable Sel_PesqArquivo_Descricao(string pesquisar, byte formulario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    if (formulario == 0)
                    {
                        Arq.Tabela = "ALUNO";
                    }
                    else if (formulario == 1)
                    {
                        Arq.Tabela = "FORNECEDOR";
                    }
                    Arq.Pesquisar = pesquisar;
                    return con.Sel_PesqArquivo_Descricao(Arq);
                }
            }
        }

        public static DataTable Sel_PesqArquivo_Codigo(string pesquisar, byte formulario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    if (formulario == 0)
                    {
                        Arq.Tabela = "ALUNO";
                    }
                    else if (formulario == 1) 
                    {
                        Arq.Tabela = "FORNECEDOR";
                    }
                    Arq.Pesquisar = pesquisar;
                    return con.Sel_PesqArquivo_Codigo(Arq);
                }
            }
        }

        public static DataTable Sel_PesqArquivo_Palavra_Chave(string pesquisar, byte formulario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    if (formulario == 0)
                    {
                        Arq.Tabela = "ALUNO";
                    }
                    else if (formulario == 1)
                    {
                        Arq.Tabela = "FORNECEDOR";
                    }
                    Arq.Pesquisar = pesquisar;
                    return con.Sel_PesqArquivo_Palavra_Chave(Arq);
                }
            }
        }

        public static DataTable Sel_PesqArquivo_Todos(byte formulario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    if (formulario == 0)
                    {
                        Arq.Tabela = "ALUNO";
                    }
                    else if (formulario == 1)
                    {
                        Arq.Tabela = "FORNECEDOR";
                    }
                    return con.Sel_PesqArquivo_Todos(Arq);
                }
            }
        }

        public static DataTable Sel_Arquivo_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    Arq.Pesquisar = pesquisar;
                    return con.Sel_Arquivo_Codigo(Arq);
                }
            }
        }

        public static DataTable Sel_Arquivo_Palavra_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    Arq.Pesquisar = pesquisar;
                    return con.Sel_Arquivo_Palavra_Chave(Arq);
                }
            }
        }

        public static DataTable Sel_Arquivo_Tabela(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    Arq.Pesquisar = pesquisar;
                    return con.Sel_Arquivo_Tabela(Arq);
                }
            }
        }

        public static DataTable Sel_Arquivo_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Arquivo_Todos();
            }
        }

        public static bool Sel_Arquivo_Descricao_Val(string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    Arq.Descricao = descricao;
                    return con.Sel_Arquivo_Descricao_Val(Arq);
                }
            }
        }

        public static bool Sel_Arquivo_Palavra_Chave_Val(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    Arq.Palavra_Chave = palavra_chave;
                    return con.Sel_Arquivo_Palavra_Chave_Val(Arq);
                }
            }
        }

        public static bool Sel_Arquivo_Descricao_Alt(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    Arq.Descricao = descricao;
                    if (con.Sel_Arquivo_Descricao_Alt(Arq) == codigo)
                    {
                        return false;
                    }
                    else if (con.Sel_Arquivo_Descricao_Alt(Arq) == null)
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

        public static bool Sel_Arquivo_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Arquivo Arq = new Arquivo())
                {
                    Arq.Palavra_Chave = palavra_chave;
                    if (con.Sel_Arquivo_Palavra_Chave_Alt(Arq) == codigo)
                    {
                        return false;
                    }
                    else if (con.Sel_Arquivo_Palavra_Chave_Alt(Arq) == null)
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

        public static bool Sel_Excluir_Arquivo_Dir()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                if (con.Sel_Excluir_Arquivo_Dir() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool Sel_Varios_Tipos_Arquivo_Dir()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                if (con.Sel_Varios_Tipos_Arquivo_Dir() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}
