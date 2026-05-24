using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Threading;

namespace BLL
{
    public class bllFluxoCaixa
    {
        public static bool _FrmRelFluxoCaixa_Aberto;
        //
        public static string _Fluxo_PesqUsuarioTabela;
        public static string _Fluxo_PesqCompPDV_Tabela;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        //
        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static DataTable Sel_Usuario_Fluxo_Caixa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Fluxo_Caixa();
            }
        }

        public static DataTable Sel_Cod_PDV_Fluxo_Caixa()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cod_PDV_Fluxo_Caixa();
            }
        }

        public static void Salvar(string data, string hora, string tipo, string descricao, string valor, string cod_fato_gerador, string usuario, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FluxoCaixa Fluxo = new FluxoCaixa())
                {
                    Fluxo.Data = "'" + data.Replace('/', '.') + " " + hora + "'";
                    //
                    Fluxo.Hora = hora.Insert(hora.Length, "'").Insert(0, "'");
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Fluxo.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    Fluxo.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor.Contains("."))
                    {
                        Fluxo.Valor = Convert.ToDecimal(valor.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Fluxo.Valor = Convert.ToDecimal(valor.Replace(",", "."));
                    }
                    //
                    if (descricao == "ABERTURA DE CAIXA")
                    {
                        Fluxo.Saldo = Fluxo.Valor;
                    }
                    else
                    {
                        if (Fluxo.Tipo == "'SAIDA'")
                        {
                            Fluxo.Saldo = con.Sel_Fluxo_Ultimo_Saldo_Adicionado() - Fluxo.Valor;
                        }
                        else if (Fluxo.Tipo == "'ENTRADA'")
                        {
                            Fluxo.Saldo = con.Sel_Fluxo_Ultimo_Saldo_Adicionado() + Fluxo.Valor;
                        }
                    }
                    //
                    Fluxo.Cod_Fato_Gerador = Convert.ToInt32(cod_fato_gerador);
                    //
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    Fluxo.Cod_Usuario = Convert.ToInt16(items[0]);
                    Fluxo.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    if (items[1].Contains("Nº PDV:"))
                    {
                        Fluxo.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", ""));
                    }
                    else
                    {
                        Fluxo.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº Comp.: ", ""));
                    }
                    //
                    con.Salvar_Fluxo_Caixa(Fluxo);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Fluxo_Caixa_Dados(string data, string data1, string hora_inicio, string hora_fim, string usuario, string cod_pdv_computador, string tipo)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;
                //
                string SqlData;
                string SqlUsuario;
                string SqlCodPdvComputador;
                string SqlTipo;
                //
                if (data.Contains("_") || data1.Contains("_"))
                {
                    SqlData = "WHERE data BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = "";
                    }
                    else
                    {
                        hora_inicio = " " + hora_inicio;
                    }
                    //
                    if (hora_fim.Contains("_"))
                    {
                        hora_fim = " 23:59:59";
                    }
                    else
                    {
                        hora_fim = " " + hora_fim;
                    }
                    //
                    SqlData = "WHERE data BETWEEN '" + data.Replace("/", ".") + hora_inicio + "' AND '" + data1.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND id_usuario=" + items[0];
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND id_pdv_computador=" + cod_pdv_computador;
                }
                //
                if (tipo == "")
                {
                    SqlTipo = "";
                }
                else
                {
                    SqlTipo = " AND tipo='" + tipo + "'";
                }
                //
                return con.Sel_Fluxo_Caixa_Dados(SqlData, SqlUsuario, SqlCodPdvComputador, SqlTipo);
            }
        }

        public static DataTable Sel_Fluxo_Caixa_Cod(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FluxoCaixa Fluxo = new FluxoCaixa())
                {
                    Fluxo.Pesquisar = pesquisar;
                    return con.Sel_Fluxo_Caixa_Cod(Fluxo);
                }
            }
        }




        public static DataTable Sel_Fluxo_Caixa_Usuario_PDV(string data_abertura, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (FluxoCaixa Fluxo = new FluxoCaixa())
                {
                    Fluxo.Data = data_abertura.Replace('/', '.');
                    //
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    Fluxo.Cod_Usuario = Convert.ToInt16(items[0]);
                    //
                    items = cod_pdv_computador.Split('/');
                    Fluxo.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", ""));
                    //
                    return con.Sel_Fluxo_Caixa_Usuario_PDV(Fluxo);
                }
            }
        }
    }
}
