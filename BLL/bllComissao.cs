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
    public class bllComissao
    {
        public static bool _FrmRelComissao_Ativo;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static string _Func_PesqFuncionario_Tabela;
        public static string _Cod_OS;
        public static string _Cod_Venda;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static void Salvar(string funcionario, string valor, string comissao_porc, string cod_venda, string cod_os, int qtde_funcionario) 
        {
            using (Con7BD con = new Con7BD()) 
            {
                using (Comissao Com = new Comissao())
                {
                    Com.Data = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Com.Horario = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items;
                    //
                    items = funcionario.Split('—');
                    //
                    Com.Cod_Funcionario = Convert.ToInt16(items[0]);
                    Com.Nome_Funcionario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (valor.Contains("."))
                    {
                        Com.Valor = Convert.ToDecimal(valor.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Com.Valor = Convert.ToDecimal(valor.Replace(",", "."));
                    }
                    //
                    if (comissao_porc.Contains("."))
                    {
                        Com.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Com.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(",", "."));
                    }
                    //
                    Com.Cod_Venda = Convert.ToInt32(cod_venda);
                    //
                    Com.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    decimal percentual = Com.Comissao_Porc / 100;
                    Com.Valor_Comissao = Math.Round(percentual * Com.Valor / qtde_funcionario, 2);
                    //
                    Com.Situacao = "'PENDENTE'";
                    //
                    con.Salvar_Comissao(Com);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Comissao_Codigo(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Comissao Com = new Comissao())
                {
                    Com.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Comissao_Codigo(Com);
                }
            }
        }


        public static DataTable Sel_Comissao_Data_Hora_Os_Vend_Func_Sit_Todos(string data, string data1, string horario_cad, string horario_cad1, string cod_os, string cod_venda, string funcionario, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items;
                    string SqlData;
                    string SqlCodOS;
                    string SqlCodVenda;
                    string SqlFuncionario;
                    string SqlSituacao;
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "WHERE data BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " 23:59:59'";
                    }
                    else
                    {
                        if (horario_cad.Contains("_"))
                        {
                            horario_cad = "";
                        }
                        else
                        {
                            horario_cad = " " + horario_cad;
                        }
                        //
                        if (horario_cad1.Contains("_"))
                        {
                            horario_cad1 = " 23:59:59";
                        }
                        else
                        {
                            horario_cad1 = " " + horario_cad1;
                        }
                        //
                        SqlData = "WHERE data BETWEEN '" + data.Replace("/", ".") + horario_cad + "' AND '" + data1.Replace("/", ".") + horario_cad1 + "'";
                    }
                    //
                    if (cod_os == "")
                    {
                        SqlCodOS = "";
                    }
                    else
                    {
                        SqlCodOS = " AND id_os=" + cod_os;
                    }
                    //
                    if (cod_venda == "")
                    {
                        SqlCodVenda = "";
                    }
                    else
                    {
                        SqlCodVenda = " AND id_venda=" + cod_venda;
                    }
                    //
                    if (funcionario == "")
                    {
                        SqlFuncionario = "";
                    }
                    else
                    {
                        items = funcionario.Split('—');
                        SqlFuncionario = " AND id_funcionario=" + items[0];
                    }
                    //
                    if (situacao == "")
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    //
                    return con.Sel_Comissao_Data_Hora_Os_Vend_Func_Sit_Todos(SqlData, SqlCodOS, SqlCodVenda, SqlFuncionario, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Funcionario_Com()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Funcionario_Com();
            }
        }

        public static bool Sel_Baixa_Comissao_Aconteceu(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Comissao Com = new Comissao())
                {
                    Com.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Baixa_Comissao_Aconteceu(Com);
                }
            }
        }

    }
}
