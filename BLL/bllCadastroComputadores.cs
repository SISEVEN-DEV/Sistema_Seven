using DAL;
using System;
using System.Data;
using System.Net;

namespace BLL
{
    public class bllCadastroComputadores
    {
        public static bool _FrmEsquemaComputadores_Ativo;

        public static void Salvar(string nome_computador, string senha_autorizacao, string tipo_computador, bool seven_adm, bool seven_pdv)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    Comp.Nome_Computador = nome_computador.Insert(nome_computador.Length, "'").Insert(0, "'");
                    //
                    Comp.Senha_Autorizacao = senha_autorizacao.Insert(senha_autorizacao.Length, "'").Insert(0, "'");
                    //
                    Comp.Cod_Usuario_Adm = 0;
                    //
                    Comp.Nome_Usuario_Adm = "null";
                    //
                    Comp.Cod_Usuario_Pdv = 0;
                    //
                    Comp.Nome_Usuario_Pdv = "null";
                    //
                    Comp.Seven_Sistema_Adm = 0;
                    //
                    Comp.Seven_Sistema_Pdv = 0;
                    //
                    Comp.Tipo_Computador = tipo_computador.Insert(tipo_computador.Length, "'").Insert(0, "'");
                    //
                    if (seven_adm == true)
                    {
                        Comp.Seven_Sistema_Adm = 1;
                    }
                    else
                    {
                        Comp.Seven_Sistema_Adm = 0;
                    }
                    //
                    if (seven_pdv == true)
                    {
                        Comp.Seven_Sistema_Pdv = 1;
                    }
                    else
                    {
                        Comp.Seven_Sistema_Pdv = 0;
                    }
                    //
                    con.Salvar_Cadastro_Computadores(Comp);
                }
            }
        }

        public static void Alterar(string codigo, string nome_computador, string senha_autorizacao, string tipo_computador, bool seven_adm, bool seven_pdv)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    Comp.Codigo = Convert.ToInt16(codigo);
                    //
                    Comp.Nome_Computador = nome_computador.Insert(nome_computador.Length, "'").Insert(0, "'");
                    //
                    Comp.Senha_Autorizacao = senha_autorizacao.Insert(senha_autorizacao.Length, "'").Insert(0, "'");
                    //
                    Comp.Tipo_Computador = tipo_computador.Insert(tipo_computador.Length, "'").Insert(0, "'");
                    //
                    if (seven_adm == true)
                    {
                        Comp.Seven_Sistema_Adm = 1;
                    }
                    else
                    {
                        Comp.Seven_Sistema_Adm = 0;
                    }
                    //
                    if (seven_pdv == true)
                    {
                        Comp.Seven_Sistema_Pdv = 1;
                    }
                    else
                    {
                        Comp.Seven_Sistema_Pdv = 0;
                    }
                    //
                    con.Alterar_Cadastro_Computadores(Comp);
                }
            }
        }

        public static bool Sel_Computador_Fluxo_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Cad = new CadastroComputadores())
                {
                    Cad.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Computador_Fluxo_Ver(Cad);
                }
            }
        }

        public static bool Sel_Computador_Abert_Fech_Caixa_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Cad = new CadastroComputadores())
                {
                    Cad.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Computador_Abert_Fech_Caixa_Ver(Cad);
                }
            }
        }

        public static bool Sel_Computador_Devolucao_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Cad = new CadastroComputadores())
                {
                    Cad.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Computador_Devolucao_Ver(Cad);
                }
            }
        }

        public static bool Sel_Computador_Orcamento_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Cad = new CadastroComputadores())
                {
                    Cad.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Computador_Orcamento_Ver(Cad);
                }
            }
        }

        public static bool Sel_Computador_Registro_Atividade_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Cad = new CadastroComputadores())
                {
                    Cad.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Computador_Registro_Atividade_Ver(Cad);
                }
            }
        }

        public static void Apagar_Registro_Atividades()
        {
            using (Con7BD con = new Con7BD())
            {
                con.Apagar_Registro_Atividades();
                con.Apagar_Gen_Registro_Atividades();
            }
        }

        public static bool Sel_Adm_Aberto_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Cad = new CadastroComputadores())
                {
                    Cad.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Adm_Aberto_Ver(Cad);
                }
            }
        }

        public static bool Sel_Pdv_Aberto_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Cad = new CadastroComputadores())
                {
                    Cad.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Pdv_Aberto_Ver(Cad);
                }
            }
        }

        public static bool Sel_Computador_Registro_Atividades_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Cad = new CadastroComputadores())
                {
                    Cad.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Computador_Registro_Atividades_Ver(Cad);
                }
            }
        }

        public static bool Sel_Computador_Sangria_Suprimento_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Cad = new CadastroComputadores())
                {
                    Cad.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Computador_Sangria_Suprimento_Ver(Cad);
                }
            }
        }

        public static bool Sel_Computador_Venda_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Cad = new CadastroComputadores())
                {
                    Cad.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Computador_Venda_Ver(Cad);
                }
            }
        }

        public static bool Sel_Cadastro_Computadores_Modulo_Aberto_Adm()
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    string strHostName = Dns.GetHostName();
                    //
                    Comp.Nome_Computador = strHostName;
                    //
                    if (con.Sel_Cadastro_Computadores_Modulo_Aberto_Adm(Comp) == 0)
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

        public static DataTable Sel_Nome_Computador_Todos_Cadastro_Computadores()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Nome_Computador_Todos_Cadastro_Computadores();
            }
        }

        public static bool Verificar_Computador_Cadastrado(string selectedindex, string modulo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ConOperationBD conOp = new ConOperationBD())
                {
                    using (CadastroComputadores Comp = new CadastroComputadores())
                    {
                        using (Conexao Conect = new Conexao())
                        {
                            Conect.Codigo = Convert.ToInt16(selectedindex);
                            //                            
                            DataRow dr = conOp.Sel_Nome_Computador_Senha_Aut_Computadores(Conect).Rows[0];
                            //
                            Comp.Nome_Computador = dr["nome_computador"].ToString();
                            //
                            Comp.Senha_Autorizacao = dr["senha_autorizacao"].ToString();
                            //
                            if (con.Verificar_Computador_Cadastrado(Comp) != null)
                            {
                                dr = con.Verificar_Computador_Cadastrado(Comp).Rows[0];
                                //
                                if (modulo == "sistemaseven")
                                {
                                    if (dr["tipo_computador"].ToString() == "SERVIDOR" & Convert.ToByte(dr["seven_sistema_adm"]) == 0)
                                    {
                                        if (dr["nome_computador"].ToString() == Environment.MachineName)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else if (dr["tipo_computador"].ToString() == "TERMINAL" & Convert.ToByte(dr["seven_sistema_adm"]) == 0)
                                    {
                                        if (dr["nome_computador"].ToString() == Environment.MachineName)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else if (modulo == "sistemasevenpdv")
                                {
                                    if (dr["tipo_computador"].ToString() == "SERVIDOR" & Convert.ToByte(dr["seven_sistema_pdv"]) == 0)
                                    {
                                        if (dr["nome_computador"].ToString() == Environment.MachineName)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else if (dr["tipo_computador"].ToString() == "TERMINAL" & Convert.ToByte(dr["seven_sistema_pdv"]) == 0)
                                    {
                                        if (dr["nome_computador"].ToString() == Environment.MachineName)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }

        public static bool Verificar_Primeira_Conexao()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Verificar_Primeira_Conexao();
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    Comp.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Cadastro_Computadores(Comp);
                }
            }
        }

        public static DataTable Sel_Todos_Cadastro_Computadores_Info(string nome_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    Comp.Nome_Computador = nome_computador;
                    return con.Sel_Todos_Cadastro_Computadores_Info(Comp);
                }
            }
        }

        public static DataTable Sel_Computadores_Ver_Codigo(string nome_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    Comp.Nome_Computador = nome_computador;
                    return con.Sel_Computadores_Ver_Codigo(Comp);
                }
            }
        }

      

        public static DataTable Sel_Computadores_Op_Ver_Codigo()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    return con.Sel_Computadores_Op_Ver_Codigo();
                }
            }
        }

        public static bool Val_Computador_Servidor(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    Comp.Codigo = Convert.ToInt16(codigo);
                    return con.Val_Computador_Servidor(Comp);
                }
            }
        }

        public static string Sel_Nome_Computador_Servidor()
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    return con.Sel_Nome_Computador_Servidor();
                }
            }
        }

        public static DataTable Sel_Nome_Computador_CadComputador(string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    Comp.Pesquisar = nome;
                    return con.Sel_Nome_Computador_CadComputador(Comp);
                }
            }
        }

        public static DataTable Sel_Codigo_Computador_CadComputador(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    Comp.Pesquisar = codigo;
                    return con.Sel_Codigo_Computador_CadComputador(Comp);
                }
            }
        }

        public static DataTable Sel_Tipo_Computador_CadComputador(string tipo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    Comp.Pesquisar = tipo;
                    return con.Sel_Tipo_Computador_CadComputador(Comp);
                }
            }
        }

        public static DataTable Sel_Todos_Computador_CadComputador()
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    return con.Sel_Todos_Computador_CadComputador();
                }
            }
        }

        public static void Atualizar_Item_Dt_Computadores(int item_atual, int total_item)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CadastroComputadores Comp = new CadastroComputadores())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Comp.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dt_Computadores(Comp, item.ToString());
                    }
                }
            }
        }
    }
}
