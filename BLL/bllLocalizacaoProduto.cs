using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace BLL
{
    public class bllLocalizacaoProduto
    {
        public static bool _FrmCadLocalizacaoProd_Ativo;

        public static void Salvar(string descricao, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (LocalizacaoProduto Loc = new LocalizacaoProduto())
                {
                    Loc.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    if (palavra_chave == "")
                    {
                        Loc.Palavra_Chave = "null";
                    }
                    else
                    {
                        Loc.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    Loc.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Localizacao(Loc);
                }
            }
        }

        public static void Alterar(string codigo, string descricao, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (LocalizacaoProduto Loc = new LocalizacaoProduto())
                {
                    Loc.Codigo = Convert.ToInt16(codigo);
                    if (palavra_chave == "")
                    {
                        Loc.Palavra_Chave = "null";
                    }
                    else
                    {
                        Loc.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    Loc.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Localizacao(Loc);
                }
            }
        }

        public static DataTable Sel_Localizacao_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (LocalizacaoProduto Loc = new LocalizacaoProduto())
                { 
                    Loc.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Localizacao_A_Alt(Loc);
                }
            }
        }

        public static bool Sel_Localizacao_Descricao_Ver(string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (LocalizacaoProduto Loc = new LocalizacaoProduto())
                {
                    Loc.Descricao = descricao;
                    return con.Sel_Localizacao_Descricao_Ver(Loc);
                }
            }
        }

        public static bool Sel_Localizacao_Descricao_Alt(string codigo, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (LocalizacaoProduto Loc = new LocalizacaoProduto())
                {
                    Loc.Descricao = descricao;
                    if (con.Sel_Localizacao_Descricao_Alt(Loc) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Localizacao_Descricao_Alt(Loc) == 0)
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


        public static DataTable Sel_Localizacao_Descricao(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (LocalizacaoProduto Sub = new LocalizacaoProduto())
                {
                    Sub.Pesquisar = pesquisar;
                    return con.Sel_Localizacao_Descricao(Sub);
                }
            }
        }

        public static DataTable Sel_Localizacao_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (LocalizacaoProduto Sub = new LocalizacaoProduto())
                {
                    Sub.Pesquisar = pesquisar;
                    return con.Sel_Localizacao_Codigo(Sub);
                }
            }
        }

        public static DataTable Sel_Localizacao_Palavra_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (LocalizacaoProduto Sub = new LocalizacaoProduto())
                {
                    Sub.Pesquisar = pesquisar;
                    return con.Sel_Localizacao_Palavra_Chave(Sub);
                }
            }
        }

        public static DataTable Sel_Localizacao_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Localizacao_A_Sal();
            }
        }
    }
}
