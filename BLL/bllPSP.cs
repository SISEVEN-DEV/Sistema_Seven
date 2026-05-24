using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class bllPSP
    {
        public static bool _FrmCadPSPPIX_Ativo;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;

        public static string _Celular;
        public static string _PSPPIX_PesqPSPPIX_Tabela;

        public static void Alterar(string codigo, string nome_psp, string tipo_chave, string acess_token, string ambiente, string timeout, string nome_recebedor, string uf, string cidade, string cep, string chave_pix)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.Codigo = Convert.ToInt16(codigo);
                    //
                    Psp.Nome_PSP = nome_psp.Insert(nome_psp.Length, "'").Insert(0, "'");
                    //
                    Psp.Tipo_Chave = tipo_chave.Insert(tipo_chave.Length, "'").Insert(0, "'");
                    //
                    if (acess_token == "" || acess_token == null)
                    {
                        Psp.Acess_Token = "null";
                    }
                    else
                    {
                        Psp.Acess_Token = acess_token.Insert(acess_token.Length, "'").Insert(0, "'");
                    }
                    //
                    Psp.Ambiente = ambiente.Insert(ambiente.Length, "'").Insert(0, "'");
                    //
                    Psp.Timeout = Convert.ToInt32(timeout);
                    //
                    Psp.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    //
                    Psp.Cidade = cidade.Insert(cidade.Length, "'").Insert(0, "'");
                    //
                    Psp.CEP = cep.Insert(cep.Length, "'").Insert(0, "'");
                    //
                    Psp.Nome_Recebedor = nome_recebedor.Insert(nome_recebedor.Length, "'").Insert(0, "'");
                    //
                    Psp.Chave_PIX = chave_pix.Insert(chave_pix.Length, "'").Insert(0, "'");
                    //
                    if (nome_psp == "MERCADO PAGO")
                    {
                        Psp.Scopes = "'[scCobWrite,scCobRead,scPixWrite,scPixRead]'";
                        Psp.QRDinamico = 0;
                    }
                    else
                    {
                        Psp.Scopes = "null";
                        Psp.QRDinamico = 0;
                    }
                    //
                    con.Alterar_PSP(Psp);
                }
            }
        }

        public static bool Sel_Chave_Pix_Alt(string codigo, string chave_pix)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.Chave_PIX = chave_pix;
                    if (con.Sel_Chave_Pix_Alt(Psp) == codigo)
                    {
                        return false;
                    }
                    else if (con.Sel_Chave_Pix_Alt(Psp) == null)
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

        public static bool Sel_Chave_Pix(string chave_pix)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.Chave_PIX = chave_pix;
                    return con.Sel_Chave_Pix(Psp);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_PSP(Psp);
                }
            }
        }

        public static DataTable Sel_PSPPIX_PSP()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_PSPPIX_PSP();
            }
        }


        public static void Salvar(string nome_psp, string tipo_chave, string acess_token, string ambiente, string timeout, string nome_recebedor, string uf, string cidade, string cep, string chave_pix)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.Nome_PSP = nome_psp.Insert(nome_psp.Length, "'").Insert(0, "'");
                    //
                    Psp.Tipo_Chave = tipo_chave.Insert(tipo_chave.Length, "'").Insert(0, "'");
                    //
                    if (acess_token == "" || acess_token == null)
                    {
                        Psp.Acess_Token = "null";
                    }
                    else
                    {
                        Psp.Acess_Token = acess_token.Insert(acess_token.Length, "'").Insert(0, "'");
                    }
                    //
                    Psp.Ambiente = ambiente.Insert(ambiente.Length, "'").Insert(0, "'");
                    //
                    Psp.Timeout = Convert.ToInt32(timeout);
                    //
                    Psp.UF = uf.Insert(uf.Length, "'").Insert(0, "'");
                    //
                    Psp.Cidade = cidade.Insert(cidade.Length, "'").Insert(0, "'");
                    //
                    Psp.CEP = cep.Insert(cep.Length, "'").Insert(0, "'");
                    //
                    Psp.Nome_Recebedor = nome_recebedor.Insert(nome_recebedor.Length, "'").Insert(0, "'");
                    //
                    Psp.Chave_PIX = chave_pix.Insert(chave_pix.Length, "'").Insert(0, "'");
                    //
                    if (nome_psp == "MERCADO PAGO")
                    {
                        Psp.Scopes = "'[scCobWrite,scCobRead,scPixWrite,scPixRead]'";
                        Psp.QRDinamico = 0;
                    }
                    else
                    {
                        Psp.Scopes = "null";
                        Psp.QRDinamico = 0;
                    }
                    //
                    con.Salvar_PSP(Psp);
                }
            }
        }

        public static DataTable Sel_PSP_A_Sal()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_PSP_A_Sal();
            }
        }

        public static DataTable Sel_PSP_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_PSP_A_Alt(Psp);
                }
            }
        }

        public static DataTable Sel_PSP_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_PSP_Todos();
            }
        }

        public static DataTable Sel_PSP_QRDinamico(byte qrdinamico)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.QRDinamico = qrdinamico;
                    //
                    return con.Sel_PSP_QRDinamico(Psp);
                }
            }
        }

        public static DataTable Sel_PSP_Nome(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.Pesquisar = pesquisar;
                    return con.Sel_PSP_Nome(Psp);
                }
            }
        }

        public static DataTable Sel_PSP_Tipo_Chave(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.Pesquisar = pesquisar;
                    return con.Sel_PSP_Tipo_Chave(Psp);
                }
            }
        }

        public static DataTable Sel_PSP_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.Pesquisar = pesquisar;
                    //
                    return con.Sel_PSP_Codigo(Psp);
                }
            }
        }











        public static bool Sel_PSP_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (PSP Psp = new PSP())
                {
                    Psp.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_PSP_Ainda_Existe(Psp);
                }
            }
        }










    }
}
