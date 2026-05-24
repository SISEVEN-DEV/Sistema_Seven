using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Threading;

namespace BLL
{
    public class bllControleCheque
    {
        public static bool _FrmRelControleCheque_Ativo;
        public static string _Consumidor_PesqControleCheque;
        public static string _Usuario_PesqControleCheque;
        public static string _Entidade_Bancaria_PesqControleCheque;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static DataTable Sel_Cliente_Controle_Cheque()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_Controle_Cheque();
            }
        }

        public static DataTable Sel_Usuario_Controle_Cheque()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Controle_Cheque();
            }
        }

        public static DataTable Sel_Entidade_Bancaria_Controle_Cheque()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Entidade_Bancaria_Controle_Cheque();
            }
        }

        public static void Salvar(string consumidor, string entidade_bancaria, string n_cheque, string beneficiario, string agencia, string conta_corrente, string valor_cheque, string data_vencimento, string observacao, string usuario, string cod_pdv_computador, string tipo_emitene, string cod_fato_gerador, string tipo_fato_gerador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ControleCheque Cheque = new ControleCheque())
                {
                    Cheque.Data_Entrada = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Cheque.Horario_Entrada = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    if (data_vencimento == "" || data_vencimento == "__/__/____" || data_vencimento == "  /  /")
                    {
                        Cheque.Data_Vencimento = "null";
                        Cheque.Horario_Vencimento = "null";
                    }
                    else
                    {
                        Cheque.Data_Vencimento = "'" + data_vencimento.Replace('/', '.') + " 23:59:59'";
                        Cheque.Horario_Vencimento = "'23:59:59'";
                    }
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items = consumidor.Split('—');
                    //
                    Cheque.Cod_Cliente = Convert.ToInt32(items[0]);
                    //
                    Cheque.Nome_Cliente = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Cheque.CPF_CNPJ = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                    //
                    items = entidade_bancaria.Split('—');
                    //
                    Cheque.Cod_Entidade_Bancaria = Convert.ToInt16(items[0]);
                    //
                    Cheque.Nome_Entidade_Bancaria = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    Cheque.Numero_Cheque = Convert.ToInt32(n_cheque);
                    //
                    if (beneficiario == "")
                    {
                        Cheque.Beneficiario = "null";
                    }
                    else
                    {
                        Cheque.Beneficiario = beneficiario.Insert(beneficiario.Length, "'").Insert(0, "'");
                    }
                    //
                    Cheque.Agencia = agencia.Insert(agencia.Length, "'").Insert(0, "'");
                    //
                    Cheque.Conta_Corrente = conta_corrente.Insert(conta_corrente.Length, "'").Insert(0, "'");
                    //
                    if (valor_cheque.Contains("."))
                    {
                        Cheque.Valor = Convert.ToDecimal(valor_cheque.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Cheque.Valor = Convert.ToDecimal(valor_cheque.Replace(",", "."));
                    }
                    //
                    Cheque.Situacao = "'PENDENTE'";
                    //
                    if (observacao == "")
                    {
                        Cheque.Observacao = "null";
                    }
                    else
                    {
                        Cheque.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Cheque.Cod_Usuario = Convert.ToInt16(items[0]);
                    //
                    Cheque.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Cheque.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", ""));
                    //
                    Cheque.Tipo_Emitente = tipo_emitene.Insert(tipo_emitene.Length, "'").Insert(0, "'");
                    //
                    Cheque.Cod_Fato_Gerador = Convert.ToInt32(cod_fato_gerador);
                    //
                    Cheque.Tipo_Fato_Gerador = tipo_fato_gerador.Insert(tipo_fato_gerador.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Controle_Cheque(Cheque);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Controle_Cheque_Venda(string cod_venda)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ControleCheque Cheque = new ControleCheque())
                {
                    Cheque.Cod_Fato_Gerador = Convert.ToInt32(cod_venda);
                    //
                    return con.Sel_Controle_Cheque_Venda(Cheque);
                }
            }
        }

        public static void Alterar_Situacao_Controle_Cheque(string cod_venda, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ControleCheque Cheque = new ControleCheque())
                {
                    Cheque.Cod_Fato_Gerador = Convert.ToInt32(cod_venda);
                    //
                    Cheque.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Situacao_Controle_Cheque_Venda(Cheque);
                }
            }
        }

        public static DataTable Sel_Controle_Cheque_Codigo(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ControleCheque Cheq = new ControleCheque())
                {
                    Cheq.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Controle_Cheque_Codigo(Cheq);
                }
            }
        }

        public static DataTable Sel_Controle_Cheque_N_Cheque(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ControleCheque Cheq = new ControleCheque())
                {
                    Cheq.Numero_Cheque = Convert.ToInt32(codigo);
                    return con.Sel_Controle_Cheque_N_Cheque(Cheq);
                }
            }
        }

        public static DataTable Sel_Controle_Data_Hora_Usuario_Tipo_Situacao_Todos(string data, string data1, string horario_cad, string horario_cad1, string datavencimento, string datavencimento1, string horariovencimento, string horariovencimento1, string datacompensacao, string datacompensacao1, string horariocompensacao, string horariocompensacao1, string usuario, string situacao, string entidade_bancaria, string consumidor)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ClieCons Clie = new ClieCons())
                {
                    string[] items;
                    string SqlDataEntrada;
                    string SqlDataVencimento;
                    string SqlDataCompensacao;
                    string SqlUsusario;
                    string SqlSituacao;
                    string SqlConsumidor;
                    string SqlEntidadeBancaria;
                    //
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlDataEntrada = "WHERE data_entrada BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
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
                        SqlDataEntrada = "WHERE data_entrada BETWEEN '" + data.Replace("/", ".") + horario_cad + "' AND '" + data1.Replace("/", ".") + horario_cad1 + "'";
                    }
                    //
                    if (datavencimento.Contains("_") || datavencimento1.Contains("_"))
                    {
                        SqlDataVencimento = "";
                    }
                    else
                    {
                        SqlDataVencimento = " AND data_vencimento BETWEEN '" + datavencimento.Replace("/", ".") + "' AND '" + datavencimento1.Replace("/", ".") + "'";
                    }
                    //
                    if (datacompensacao.Contains("_") || datacompensacao1.Contains("_"))
                    {
                        SqlDataCompensacao = "";
                    }
                    else
                    {
                        SqlDataCompensacao = " AND data_vencimento BETWEEN '" + datacompensacao.Replace("/", ".") + "' AND '" + datacompensacao1.Replace("/", ".") + "'";
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
                    if (usuario == "")
                    {
                        SqlUsusario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        SqlUsusario = " AND id_usuario=" + items[0];
                    }
                    //
                    if (consumidor == "")
                    {
                        SqlConsumidor = "";
                    }
                    else
                    {
                        items = consumidor.Split('—');
                        SqlConsumidor = " AND id_emitente=" + items[0];
                    }
                    //
                    if (entidade_bancaria == "")
                    {
                        SqlEntidadeBancaria = "";
                    }
                    else
                    {
                        items = entidade_bancaria.Split('—');
                        SqlEntidadeBancaria = " AND id_entidade_bancaria=" + items[0];
                    }
                    //
                    return con.Sel_Controle_Data_Hora_Usuario_Tipo_Situacao_Todos(SqlDataEntrada, SqlDataVencimento, SqlDataCompensacao, SqlUsusario, SqlSituacao, SqlConsumidor, SqlEntidadeBancaria);
                }
            }
        }

        public static bool Sel_Controle_Cheque_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ControleCheque Conta = new ControleCheque())
                {
                    Conta.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Controle_Cheque_Ainda_Existe(Conta);
                }
            }
        }

        public static bool Sel_Baixa_Controle_Cheque_Aconteceu(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ControleCheque Cheque = new ControleCheque())
                {
                    Cheque.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Baixa_Controle_Cheque_Aconteceu(Cheque);
                }
            }
        }

        public static void Salvar_Baixa_Controle_Cheque(string codigo, string data_compensacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ControleCheque Cheque = new ControleCheque())
                {
                    Cheque.Data_Compensacao = "'" + data_compensacao.Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Cheque.Horario_Compensacao = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Cheque.Codigo = Convert.ToInt32(codigo);
                    //                    
                    con.Salvar_Baixa_Controle_Cheque(Cheque);
                }
            }
        }

        public static void Desfazer_refazer_Baixa_Controle_Cheque(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ControleCheque Cheque = new ControleCheque())
                {
                    Cheque.Codigo = Convert.ToInt32(codigo);
                    //                    
                    con.Desfazer_refazer_Baixa_Controle_Cheque(Cheque);
                }
            }
        }


    }
}
