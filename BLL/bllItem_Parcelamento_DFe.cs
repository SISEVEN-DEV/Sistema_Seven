using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class bllItem_Parcelamento_DFe
    {
        public static string _Quantidade;
        public static string _Data_Vencimento_Multiplicada;

        public static void Salvar(string ocorrencia_parc, string valor, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Parcelamento_DFe Parc = new Item_Parcelamento_DFe())
                {
                    Parc.Ocorrencia_Parc = Convert.ToInt16(ocorrencia_parc);
                    //
                    DateTime d = Convert.ToDateTime(_Data_Vencimento_Multiplicada);
                    _Data_Vencimento_Multiplicada = d.AddDays(Convert.ToDouble("30")).ToString("dd/MM/yyyy");
                    Parc.Data_Vencimento = "'" + _Data_Vencimento_Multiplicada.Replace('/', '.') + " 23:59:59'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (valor.Contains("."))
                    {
                        Parc.Valor = Math.Round(Convert.ToDecimal(valor.Replace(".", "").Replace(",", ".")) / Convert.ToDecimal(bllItem_Parcelamento_DFe._Quantidade));
                    }
                    else
                    {
                        Parc.Valor = Math.Round(Convert.ToDecimal(valor.Replace(",", ".")) / Convert.ToDecimal(bllItem_Parcelamento_DFe._Quantidade));
                    }
                    //
                    Parc.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Salvar_Item_Parcelamento_DFe(Parc);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar(string ocorrencia_parc, string valor, string data_vencimento, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Parcelamento_DFe Parc = new Item_Parcelamento_DFe())
                {
                    Parc.Ocorrencia_Parc = Convert.ToInt16(ocorrencia_parc);
                    //
                    Parc.Data_Vencimento = "'" + data_vencimento.Replace('/', '.') + " 23:59:59'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (valor.Contains("."))
                    {
                        Parc.Valor = Convert.ToDecimal(valor.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Parc.Valor = Convert.ToDecimal(valor.Replace(",", "."));
                    }
                    //
                    Parc.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Alterar_Item_Parcelamento_DFe(Parc);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Item_Parcelamento_DFe_Todos(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Parcelamento_DFe Parc = new Item_Parcelamento_DFe())
                {
                    Parc.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Item_Parcelamento_DFe_Todos(Parc);
                }
            }
        }

        public static void Excluir_Todos_Item_Parcelamento_DFe_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Parcelamento_DFe Parc = new Item_Parcelamento_DFe())
                {
                    Parc.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Todos_Item_Parcelamento_DFe_Temp(Parc);
                }
            }
        }
    }
}
