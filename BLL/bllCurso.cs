using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;


namespace BLL
{
    public class bllCurso
    {
        public static bool _FrmCadCurso_Ativo;

        public static void Salvar(string palavra_chave, string descricao, string valor_curso, string observacao, string sigla) 
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso())
                {
                    Cur.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_curso.Contains("."))
                    {
                        Cur.Valor_Curso = Convert.ToDecimal(valor_curso.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Cur.Valor_Curso = Convert.ToDecimal(valor_curso.Replace(",", "."));
                    }
                    //
                    if (observacao == "")
                    {
                        Cur.Observacao = "null";
                    }
                    else
                    {
                        Cur.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (palavra_chave == "")
                    {
                        Cur.Palavra_Chave = "null";
                    }
                    else
                    {
                        Cur.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    if (sigla == "")
                    {
                        Cur.Sigla = "null";
                    }
                    else 
                    {
                        Cur.Sigla = sigla.Insert(sigla.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Salvar_Curso(Cur);
                }
            }
        }

        public static void Alterar(string codigo, string palavra_chave, string descricao, string valor_curso, string sigla, string observacao)
        {
            using (Con7BD con = new Con7BD()) 
            {
                using (Curso Cur = new Curso()) 
                {
                    Cur.Codigo = Convert.ToInt16(codigo);
                    Cur.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_curso.Contains("."))
                    {
                        Cur.Valor_Curso = Convert.ToDecimal(valor_curso.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Cur.Valor_Curso = Convert.ToDecimal(valor_curso.Replace(",", "."));
                    }
                    //
                    if (sigla == "")
                    {
                        Cur.Sigla = "null";
                    }
                    else
                    {
                        Cur.Sigla = sigla.Insert(sigla.Length, "'").Insert(0, "'");
                    }
                    //
                    if (observacao == "")
                    {
                        Cur.Observacao = "null";
                    }
                    else
                    {
                        Cur.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (palavra_chave == "")
                    {
                        Cur.Palavra_Chave = "null";
                    }
                    else
                    {
                        Cur.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Alterar_Curso(Cur);
                }          
            }
        }

        public static void Excluir(string codigo) 
        {
            using (Con7BD con = new Con7BD()) 
            {
                using (Curso Cur = new Curso()) 
                {
                    Cur.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Curso(Cur);       
                }
            }       
        }          

        public static DataTable Sel_Cur_A_Sal() 
        {
            using (Con7BD con = new Con7BD()) 
            {
                return con.Sel_Cur_A_Sal();   
            }        
        }

        public static DataTable Sel_Curso_Disci()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Curso_Disci();
            }
        }  
        
        public static DataTable Sel_Cur_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso()) 
                {
                    Cur.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Cur_A_Alt(Cur);             
                }                
            }
        }

        public static DataTable Sel_Descricao_Curso(string pesquisar) 
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso()) 
                {
                    Cur.Pesquisar = pesquisar;
                    return con.Sel_Descricao_Curso(Cur);                    
                }            
            } 
        }        

        public static DataTable Sel_Palavra_Chave_Curso(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso())
                {
                    Cur.Pesquisar = pesquisar;
                    return con.Sel_Palavra_Chave_Curso(Cur);
                }
            }
        }

        public static DataTable Sel_Sigla_Curso(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso())
                {
                    Cur.Pesquisar = pesquisar;
                    return con.Sel_Sigla_Curso(Cur);
                }
            }
        }

        public static DataTable Sel_Professor_Curso()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Professor_Curso();
            }
        }

        public static DataTable Sel_Codigo_Curso(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso())
                {
                    Cur.Pesquisar = pesquisar;
                    return con.Sel_Codigo_Curso(Cur);
                }
            }
        }

        public static DataTable Sel_Todos_Curso()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Todos_Curso();
            }
        }

        public static bool Val_Curso_Sigla(string sigla)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso())
                {
                    Cur.Sigla = sigla;
                    return con.Val_Curso_Sigla(Cur);
                }
            }
        }

        public static bool Val_Curso_Descricao(string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso())
                {
                    Cur.Descricao = descricao;
                    return con.Val_Curso_Descricao(Cur);
                }
            }
        }

        public static bool Val_Curso_Palavra_Chave(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso())
                {
                    Cur.Palavra_Chave = palavra_chave;
                    return con.Val_Curso_Palavra_Chave(Cur);
                }
            }
        }

        public static bool Val_Curso_Descricao_Alt(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso())
                {
                    Cur.Codigo = Convert.ToInt16(codigo);
                    Cur.Descricao = descricao;
                    if (con.Val_Curso_Descricao_Alt(Cur) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Curso_Descricao_Alt(Cur) == 0)
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

        public static bool Val_Curso_Sigla_Alt(string codigo, string sigla)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso())
                {
                    Cur.Codigo = Convert.ToInt16(codigo);
                    Cur.Sigla = sigla;
                    if (con.Val_Curso_Sigla_Alt(Cur) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Curso_Sigla_Alt(Cur) == 0)
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

        public static bool Val_Curso_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Curso Cur = new Curso())
                {
                    Cur.Codigo = Convert.ToInt16(codigo);
                    Cur.Palavra_Chave = palavra_chave;
                    if (con.Val_Curso_Palavra_Chave_Alt(Cur) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Curso_Palavra_Chave_Alt(Cur) == 0)
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
    }
}
