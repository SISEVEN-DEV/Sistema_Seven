using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace BLL
{
    
    public class bllDisciplina
    {
        public static bool _FrmCadDisciplina_Ativo;

        public static void Salvar(string palavra_chave, string descricao, string carga_horaria, string tipo_disciplina, string observacao) 
        {
            using (Con7BD con = new Con7BD()) 
            {
                using (Disciplina Disci = new Disciplina()) 
                {
                    if (palavra_chave == "")
                    {
                        Disci.Palavra_Chave = "null";
                    }
                    else
                    {
                        Disci.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    Disci.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    Disci.Tipo_Disciplina = tipo_disciplina.Insert(tipo_disciplina.Length, "'").Insert(0, "'");
                    Disci.Carga_Horaria = carga_horaria.Insert(carga_horaria.Length, "'").Insert(0, "'");
                    //
                    if (observacao == "")
                    {
                        Disci.Observacao = "null";
                    }
                    else
                    {
                        Disci.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    con.Salvar_Disciplina(Disci);
                }          
            } 
        }

        public static void Alterar(string codigo, string palavra_chave, string descricao, string carga_horaria, string tipo_disciplina, string observacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Disciplina Disci = new Disciplina())
                {
                    Disci.Codigo = Convert.ToInt16(codigo);
                    if (palavra_chave == "")
                    {
                        Disci.Palavra_Chave = "null";
                    }
                    else
                    {
                        Disci.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    Disci.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    Disci.Tipo_Disciplina = tipo_disciplina.Insert(tipo_disciplina.Length, "'").Insert(0, "'");
                    Disci.Carga_Horaria = carga_horaria.Insert(carga_horaria.Length, "'").Insert(0, "'");
                    //
                    if (observacao == "")
                    {
                        Disci.Observacao = "null";
                    }
                    else
                    {
                        Disci.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    con.Alterar_Disciplina(Disci);
                }
            }
        }

        public static bool Val_Disci_Descricao(string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Disciplina Disci = new Disciplina())
                {
                    Disci.Descricao = descricao;
                    return con.Val_Disci_Descricao(Disci);
                }
            }
        }

        public static bool Val_Disci_Descricao_Alt(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Disciplina Disci = new Disciplina())
                {
                    Disci.Codigo = Convert.ToInt16(codigo);
                    Disci.Descricao = descricao;
                    if (con.Val_Disci_Descricao_Alt(Disci) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Disci_Descricao_Alt(Disci) == 0)
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

        public static bool Val_Disci_Palavra_Chave(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Disciplina Disci = new Disciplina())
                {
                    Disci.Palavra_Chave = palavra_chave;
                    return con.Val_Disci_Palavra_Chave(Disci);
                }
            }
        }

        public static bool Val_Disci_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Disciplina Disci = new Disciplina())
                {
                    Disci.Codigo = Convert.ToInt16(codigo);
                    Disci.Palavra_Chave = palavra_chave;
                    if (con.Val_Disci_Palavra_Chave_Alt(Disci) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Disci_Palavra_Chave_Alt(Disci) == 0)
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

        public static void Excluir (string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Disciplina Disci = new Disciplina())
                {
                    Disci.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Disciplina(Disci);        
                }      
            }        
        }        

        public static DataTable Sel_Disciplina_A_Salvar() 
        {
            using (Con7BD con = new Con7BD()) 
            {
                return con.Sel_Disciplina_A_Salvar();            
            }        
        }

        public static DataTable Sel_Disciplina_A_Alterar(string codigo) 
        {
            using (Con7BD con = new Con7BD()) 
            {
                using (Disciplina Disci = new Disciplina()) 
                {
                    Disci.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Disciplina_A_Alterar(Disci);
                }            
            }        
        }

        public static DataTable Sel_Disci_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Disciplina Disci = new Disciplina())
                {
                    Disci.Pesquisar = pesquisar;
                    return con.Sel_Disci_Codigo(Disci);
                }
            }
        }

        public static DataTable Sel_Disci_Palavra_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Disciplina Disci = new Disciplina())
                {
                    Disci.Pesquisar = pesquisar;
                    return con.Sel_Disci_Palavra_Chave(Disci);
                }
            }
        }

        public static DataTable Sel_Disci_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Disci_Todos();
            }
        }

        public static DataTable Sel_Disci_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Disciplina Disci = new Disciplina())
                {
                    Disci.Pesquisar = pesquisar;
                    return con.Sel_Disci_Descricao(Disci);
                }
            }
        }       

        public static DataTable Sel_Disci_Tipo_Disciplina(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Disciplina Disci = new Disciplina())
                {
                    Disci.Pesquisar = pesquisar;
                    return con.Sel_Disci_Tipo_Disciplina(Disci);
                }
            }
        }
    }
}
