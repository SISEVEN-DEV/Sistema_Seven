using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllLetreiro
    {
        public static DataTable Sel_Mensagem_Letreiro()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Mensagem_Letreiro();
            }
        }

        public static string Sel_Quantidade_Lembrete()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Quantidade_Lembrete();
            }
        }

        public static void Salvar_Letreiro(string mensagem, string cor, string tipo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Letreiro Let = new Letreiro())
                {
                    Let.Codigo = Convert.ToInt16(con.Sel_Ultimo_Cod_Letreiro_Adicionado() + 1);
                    //
                    Let.Mensagem = mensagem.Insert(mensagem.Length, "'").Insert(0, "'");
                    //
                    if (cor == "")
                    {
                        Let.Cor = 0;
                    }
                    else
                    {
                        Let.Cor = Convert.ToByte(cor);
                    }
                    //
                    if (tipo == "")
                    {
                        Let.Tipo = "null";
                    }
                    else
                    {
                        Let.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Salvar_Letreiro(Let);
                }
            }
        }

        public static void Alterar_Letreiro(string mensagem, string tipo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Letreiro Let = new Letreiro())
                {
                    Let.Mensagem = mensagem.Insert(mensagem.Length, "'").Insert(0, "'");
                    //
                    if (tipo == "")
                    {
                        Let.Tipo = "null";
                    }
                    else
                    {
                        Let.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Alterar_Letreiro(Let);
                }
            }
        }

        public static void Excluir_Letreiro(string tipo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Letreiro Let = new Letreiro())
                {
                    if (tipo == "")
                    {
                        Let.Tipo = "null";
                    }
                    else
                    {
                        Let.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Excluir_Letreiro(Let);
                }
            }
        }

        public static bool Sel_Tipo_Letreiro_Existe(string tipo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Letreiro Let = new Letreiro())
                {
                    Let.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    return con.Sel_Tipo_Letreiro_Existe(Let);
                }
            }
        }
    }
}
