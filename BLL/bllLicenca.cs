using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllLicenca
    {
        public static void Salvar(string data_atual, string chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Licenca Lic = new Licenca())
                {
                    //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Lic.Data_Renovacao = data_atual.Insert(data_atual.Length, "'").Insert(0, "'").Replace("/", ".");
                    //
                    Lic.Data_Recente = data_atual.Insert(data_atual.Length, "'").Insert(0, "'").Replace("/", ".");
                    //
                    DateTime trinta_dias = Convert.ToDateTime(data_atual);
                    string data = trinta_dias.AddDays(Convert.ToDouble(30)).ToString("dd/MM/yyyy");
                    Lic.Data_Expiracao = data.Insert(data.Length, "'").Insert(0, "'").Replace("/", ".");
                    //
                    Lic.Chave = chave.Insert(chave.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Licenca(Lic);
                    //
                    //Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    //Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Periodo_Avaliacao(string data_atual, string chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Licenca Lic = new Licenca())
                {
                    //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Lic.Data_Renovacao = data_atual.Insert(data_atual.Length, "'").Insert(0, "'").Replace("/", ".");
                    //
                    Lic.Data_Recente = data_atual.Insert(data_atual.Length, "'").Insert(0, "'").Replace("/", ".");
                    //
                    DateTime trinta_dias = Convert.ToDateTime(data_atual);
                    string data = trinta_dias.AddDays(Convert.ToDouble(7)).ToString("dd/MM/yyyy");
                    Lic.Data_Expiracao = data.Insert(data.Length, "'").Insert(0, "'").Replace("/", ".");
                    //
                    Lic.Chave = chave.Insert(chave.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Licenca(Lic);
                    //
                    //Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    //Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static bool Verificar_Licenca(string data_atual)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Licenca Lic = new Licenca())
                {
                    Lic.Pesquisar = data_atual.Insert(data_atual.Length, "'").Insert(0, "'").Replace("/", ".");
                    //
                    if (con.Verificar_Data_Licenca() != null)
                    {
                        DataRow dr = con.Verificar_Data_Licenca().Rows[0];
                        //
                        if (Convert.ToDateTime(data_atual) < Convert.ToDateTime(dr["data_renovacao"].ToString()))
                        {
                            return false;
                        }
                        else if (Convert.ToDateTime(data_atual) < Convert.ToDateTime(dr["data_recente"].ToString()))
                        {
                            return false;
                        }
                        else if (Convert.ToDateTime(data_atual) > Convert.ToDateTime(dr["data_expiracao"].ToString()))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static DataTable Verificar_Data_Licenca()
        {
            using (Con7BD con = new Con7BD())
            {
                using (Licenca Lic = new Licenca())
                {
                    return con.Verificar_Data_Licenca();
                }
            }
        }

        public static bool Sel_Dados_Licenca()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Dados_Licenca();
            }
        }







    }
}
