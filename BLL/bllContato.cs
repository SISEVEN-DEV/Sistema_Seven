using DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public class bllContato
    {
        public static void Salvar(string codigo, string telefone, string celular, string fax, string site, string email, string senha)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    Contato.Codigo = Convert.ToInt16(codigo);
                    //
                    if (telefone == "(__) ____-____" || telefone == "(  )     -")
                    {
                        Contato.Telefone = "null";
                    }
                    else
                    {
                        Contato.Telefone = telefone.Insert(telefone.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular == "(__) _____-____" || celular == "(  )      -")
                    {
                        Contato.Celular = "null";
                    }
                    else
                    {
                        Contato.Celular = celular.Insert(celular.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fax == "(__) ____-____" || fax == "(  )     -")
                    {
                        Contato.FAX = "null";
                    }
                    else
                    {
                        Contato.FAX = fax.Insert(fax.Length, "'").Insert(0, "'");
                    }
                    //
                    if (site == "")
                    {
                        Contato.Site = "null";
                    }
                    else
                    {
                        Contato.Site = site.Insert(site.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email == "")
                    {
                        Contato.Email = "null";
                    }
                    else
                    {
                        Contato.Email = email.Insert(email.Length, "'").Insert(0, "'");
                    }
                    //
                    if (senha == "")
                    {
                        Contato.Senha = "null";
                    }
                    else
                    {
                        Contato.Senha = senha.Insert(senha.Length, "'").Insert(0, "'");
                    }
                    con.Salvar_Contato(Contato);
                }
            }
        }

        public static void Alterar(string codigo, string telefone, string celular, string fax, string site, string email, string senha, string codigo_atual)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    Contato.Codigo = Convert.ToInt16(codigo_atual);
                    //
                    if (telefone == "(__) ____-____" || telefone == "(  )     -")
                    {
                        Contato.Telefone = "null";
                    }
                    else
                    {
                        Contato.Telefone = telefone.Insert(telefone.Length, "'").Insert(0, "'");
                    }
                    //
                    if (celular == "(__) _____-____" || celular == "(  )      -")
                    {
                        Contato.Celular = "null";
                    }
                    else
                    {
                        Contato.Celular = celular.Insert(celular.Length, "'").Insert(0, "'");
                    }
                    //
                    if (fax == "(__) ____-____" || fax == "(  )     -")
                    {
                        Contato.FAX = "null";
                    }
                    else
                    {
                        Contato.FAX = fax.Insert(fax.Length, "'").Insert(0, "'");
                    }
                    //
                    if (site == "")
                    {
                        Contato.Site = "null";
                    }
                    else
                    {
                        Contato.Site = site.Insert(site.Length, "'").Insert(0, "'");
                    }
                    //
                    if (email == "")
                    {
                        Contato.Email = "null";
                    }
                    else
                    {
                        Contato.Email = email.Insert(email.Length, "'").Insert(0, "'");
                    }
                    //
                    if (senha == "")
                    {
                        Contato.Senha = "null";
                    }
                    else
                    {
                        Contato.Senha = senha.Insert(senha.Length, "'").Insert(0, "'");
                    }
                    con.Alterar_Contato(Contato, codigo);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    Contato.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Contato(Contato);
                }
            }
        }

        public static DataTable Sel_Contato_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    Contato.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Contato_A_Alt(Contato);
                }
            }
        }

        public static DataTable Sel_Contato_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    return con.Sel_Contato_A_Sal();
                }
            }
        }

        public static string Sel_Cod_Contato()
        {
            using (Con7BD con = new Con7BD())
            {
                if (con.Sel_Cod_Contato() == null)
                {
                    return "1";
                }
                else
                {
                    return (Convert.ToInt32(con.Sel_Cod_Contato()) + Convert.ToInt32(1)).ToString();
                }
            }
        }

        public static bool Sel_Contato_Cod(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Cont = new Contato())
                {
                    Cont.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Contato_Cod(Cont);
                }
            }
        }

        public static bool Val_Contato_Alt(string codigo, string codigo_atual)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Cont = new Contato())
                {
                    Cont.Codigo = Convert.ToInt16(codigo);
                    if (con.Val_Contato_Alt(Cont, codigo_atual) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Contato_Alt(Cont, codigo_atual) == 0)
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
        public static DataTable Sel_Contato_Email(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    Contato.Pesquisar = pesquisar;
                    return con.Sel_Contato_Email(Contato);
                }
            }
        }

        public static DataTable Sel_Contato_Site(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    Contato.Pesquisar = pesquisar;
                    return con.Sel_Contato_Site(Contato);
                }
            }
        }

        public static DataTable Sel_Contato_Telefone(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    Contato.Pesquisar = pesquisar;
                    return con.Sel_Contato_Telefone(Contato);
                }
            }
        }

        public static DataTable Sel_Contato_Fax(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    Contato.Pesquisar = pesquisar;
                    return con.Sel_Contato_Fax(Contato);
                }
            }
        }

        public static DataTable Sel_Contato_Celular(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    Contato.Pesquisar = pesquisar;
                    return con.Sel_Contato_Celular(Contato);
                }
            }
        }

        public static DataTable Sel_Contato_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    Contato.Pesquisar = pesquisar;
                    return con.Sel_Contato_Codigo(Contato);
                }
            }
        }

        public static DataTable Sel_Contato_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                using (Contato Contato = new Contato())
                {
                    return con.Sel_Contato_Todos();
                }
            }
        }

        public static void ImprimirOrc(DataGridView dgv, string registro)
        {

        }
    }
}
