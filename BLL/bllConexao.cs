using DAL;
using System;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace BLL
{
    public class bllConexao
    {
        public static string _Descricao_Conexao_Atual;
        public static string _Descricao_Entidade;
        public static string _Codigo_Conexao;
        public static string _Usuario;
        public static string _Caminho;
        public static string _Tipo;
        public static string _Nome_Computador_Local;

        public static void Salvar(string caminho_conexao, string tipo_conexao, string nome_computador, string desc_razao_fantasia_empresa, string senha_autorizacao, string ordem, string nome_servidor, string porta)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    if (tipo_conexao == "LOCAL")
                    {
                        Conect.Caminho_Conexao = caminho_conexao.Insert(caminho_conexao.Length, "'").Insert(0, "'");
                        Conect.Conexao_Completa = @"'USER=SYSDBA;PASSWORD=7sysgod;DATABASE=" + caminho_conexao + ";PORT=3050;DIALECT=3;CHARSET=NONE;ROLE=;CONNECTION TIMEOUT=7;CONNECTION LIFETIME=0;POOLING=True;PACKET SIZE=8192;SERVER TYPE=0;'";
                        Conect.Nome_Computador = nome_computador.Insert(nome_computador.Length, "'").Insert(0, "'");
                    }
                    else if (tipo_conexao == "REDE (LAN)")
                    {
                        Conect.Caminho_Conexao = caminho_conexao.Insert(caminho_conexao.Length, "'").Insert(0, "'");
                        Conect.Conexao_Completa = @"'Server=" + nome_servidor + ";User=SYSDBA;password=7sysgod;Database=" + caminho_conexao + ";'";
                        Conect.Nome_Computador = nome_computador.Insert(nome_computador.Length, "'").Insert(0, "'");
                    }
                    else if (tipo_conexao == "REDE (VPS)")
                    {
                        Conect.Caminho_Conexao = caminho_conexao.Insert(caminho_conexao.Length, "'").Insert(0, "'");
                        Conect.Conexao_Completa = @"'Server=" + nome_servidor + ";Port=" + porta + ";Database=" + caminho_conexao + ";User=SYSDBA;password=7sysgod;'";
                        Conect.Nome_Computador = nome_computador.Insert(nome_computador.Length, "'").Insert(0, "'");
                    }
                    //
                    Conect.Tipo_Conexao = tipo_conexao.Insert(tipo_conexao.Length, "'").Insert(0, "'");
                    //
                    Conect.Entidade = desc_razao_fantasia_empresa.Insert(desc_razao_fantasia_empresa.Length, "'").Insert(0, "'");
                    //
                    Conect.Senha_Autorizacao = senha_autorizacao.Insert(senha_autorizacao.Length, "'").Insert(0, "'");
                    //
                    Conect.Ordem = Convert.ToInt16(ordem);
                    //
                    Conect.Nome_Servidor = nome_servidor.Insert(nome_servidor.Length, "'").Insert(0, "'");
                    //
                    if (porta == null || porta == "")
                    {
                        Conect.Porta = 0;
                    }
                    else
                    {
                        Conect.Porta = Convert.ToInt32(porta);
                    }
                    //
                    con.Salvar_Conexao(Conect);
                }
            }
        }

        public static bool Sel_Conexao_Ordem_Alt(string codigo, string ordem)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    Conect.Ordem = Convert.ToInt16(ordem);
                    if (con.Sel_Conexao_Ordem_Alt(Conect) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Conexao_Ordem_Alt(Conect) == 0)
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

        public static bool Sel_Entidade_Ver_Nome(string entidade)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    Conect.Entidade = entidade;
                    return con.Sel_Entidade_Ver_Nome(Conect);
                }
            }
        }

        public static bool Sel_Entidade_Ver_Nome_Alt(string codigo, string entidade)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    Conect.Entidade = entidade;
                    if (con.Sel_Emitente_Ver_Nome_Alt(Conect) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Emitente_Ver_Nome_Alt(Conect) == 0)
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

        public static bool Sel_Conexao_Ordem_Ver(string ordem)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    Conect.Ordem = Convert.ToInt16(ordem);
                    return con.Sel_Conexao_Ordem_Ver(Conect);
                }
            }
        }

        public static string Sel_Ult_Ordem_Existe()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Ult_Ordem_Existe();
            }
        }

        public static void Alterar(string codigo, string caminho_conexao, string tipo_conexao, string nome_computador, string desc_razao_fantasia_empresa, string senha_autorizacao, string ordem, string ordem_anterior, string nome_servidor, string porta)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    Conect.Codigo = Convert.ToInt16(codigo);
                    //
                    if (tipo_conexao == "LOCAL")
                    {
                        Conect.Caminho_Conexao = caminho_conexao.Insert(caminho_conexao.Length, "'").Insert(0, "'");
                        Conect.Conexao_Completa = @"'USER=SYSDBA;PASSWORD=7sysgod;DATABASE=" + caminho_conexao + ";PORT=3050;DIALECT=3;CHARSET=NONE;ROLE=;CONNECTION TIMEOUT=7;CONNECTION LIFETIME=0;POOLING=True;PACKET SIZE=8192;SERVER TYPE=0;'";
                        Conect.Nome_Computador = nome_computador.Insert(nome_computador.Length, "'").Insert(0, "'");
                    }
                    else if (tipo_conexao == "REDE (LAN)")
                    {
                        Conect.Caminho_Conexao = caminho_conexao.Insert(caminho_conexao.Length, "'").Insert(0, "'");
                        Conect.Conexao_Completa = @"'Server=" + nome_servidor + ";User=SYSDBA;password=7sysgod;Database=" + caminho_conexao + ";'";
                        Conect.Nome_Computador = nome_computador.Insert(nome_computador.Length, "'").Insert(0, "'");
                    }
                    else if (tipo_conexao == "REDE (VPS)")
                    {
                        Conect.Caminho_Conexao = caminho_conexao.Insert(caminho_conexao.Length, "'").Insert(0, "'");
                        Conect.Conexao_Completa = @"'Server=" + nome_servidor + ";Port=" + porta + ";Database=" + caminho_conexao + ";User=SYSDBA;password=7sysgod;'";
                        Conect.Nome_Computador = nome_computador.Insert(nome_computador.Length, "'").Insert(0, "'");
                    }
                    //
                    Conect.Tipo_Conexao = tipo_conexao.Insert(tipo_conexao.Length, "'").Insert(0, "'");
                    //
                    Conect.Entidade = desc_razao_fantasia_empresa.Insert(desc_razao_fantasia_empresa.Length, "'").Insert(0, "'");
                    //
                    Conect.Senha_Autorizacao = senha_autorizacao.Insert(senha_autorizacao.Length, "'").Insert(0, "'");
                    //
                    Conect.Ordem = Convert.ToInt16(ordem);
                    //
                    if (ordem_anterior != ordem)
                    {
                        string cod = con.Sel_Codigo_Conexao_Ordem(ordem);
                        //
                        if (cod != null)
                        {
                            con.Alterar_Ordem_Conexao(cod, ordem_anterior);
                        }
                    }
                    //
                    Conect.Nome_Servidor = nome_servidor.Insert(nome_servidor.Length, "'").Insert(0, "'");
                    //
                    if (porta == null || porta == "")
                    {
                        Conect.Porta = 0;
                    }
                    else
                    {
                        Conect.Porta = Convert.ToInt32(porta);
                    }
                    //
                    con.Alterar_Conexao(Conect);
                }
            }
        }

        public static void Atualizar_Item_Dt_Conexao(int item_atual, int total_item)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Conect.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        con.Atualizar_Item_Dt_Conexao(Conect, item.ToString());
                    }
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    Conect.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Conexao(Conect);
                }
            }
        }

        public static DataTable Sel_Todos_Conexao()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Todos_Conexao();
            }
        }

        public static DataTable Sel_Todos_Computadores()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Todos_Computadores();
            }
        }

        public static DataTable Sel_Conexao_Empresa_Todas()
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                return con.Sel_Conexao_Empresa_Todas();
            }
        }

        public static void Sel_Descricao_Conexao_Atual(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    Conect.Codigo = Convert.ToInt16(codigo);

                    if (con.Sel_Descricao_Conexao_Atual(Conect)[2].ToString() == "LOCAL")
                    {
                        _Descricao_Conexao_Atual = con.Sel_Descricao_Conexao_Atual(Conect)[0] + ":" + con.Sel_Descricao_Conexao_Atual(Conect)[1];
                    }
                    else
                    {
                        string[] items = con.Sel_Descricao_Conexao_Atual(Conect)[1].Split(':');
                        //
                        _Descricao_Conexao_Atual = con.Sel_Descricao_Conexao_Atual(Conect)[1];
                    }
                }
            }
        }

        public static string Sel_Cod_Ult_Con_Sucess_Con(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    Conect.Codigo = Convert.ToInt16(codigo);
                    DataRow dr = con.Sel_Cod_Ult_Con_Sucess_Con(Conect).Rows[0];
                    //
                    return dr["entidade"].ToString();
                }
            }
        }

        public static void Sel_Conexao_Completa_Con(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    Conect.Codigo = Convert.ToInt16(codigo);
                    //
                    Con7BD.strConexao = con.Sel_Conexao_Completa_Con(Conect);
                }
            }
        }

        public static string Sel_Computadores_Op_Ver_Codigo(string entidade)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    Conect.Entidade = entidade;
                    return con.Sel_Computadores_Op_Ver_Codigo(Conect);
                }
            }
        }

        public static void Sel_Conexao_Completa_Cadastro_Computador(string caminho_conexao, string tipo_conexao)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Conexao Conect = new Conexao())
                {
                    if (tipo_conexao == "LOCAL")
                    {
                        Con7BD.strConexao = @"USER=SYSDBA;PASSWORD=7sysgod;DATABASE=" + caminho_conexao + ";PORT=3050;DIALECT=3;CHARSET=NONE;ROLE=;CONNECTION TIMEOUT=7;CONNECTION LIFETIME=0;POOLING=True;PACKET SIZE=8192;SERVER TYPE=0;";
                        //MessageBox.Show(@"USER=SYSDBA;PASSWORD=7sysgod;DATABASE=" + caminho_conexao + ";PORT=3050;DIALECT=3;CHARSET=NONE;ROLE=;CONNECTION TIMEOUT=7;CONNECTION LIFETIME=0;POOLING=True;PACKET SIZE=8192;SERVER TYPE=0;");
                    }
                    else if (tipo_conexao == "REDE")
                    {
                        string[] items = caminho_conexao.Split(':');
                        //
                        MessageBox.Show(items[0]);
                        Con7BD.strConexao = @"Server=" + items[0] + ";User=SYSDBA;password=7sysgod;Database=" + caminho_conexao + ";";
                        //MessageBox.Show(@"Server=" + nome_computador_local + ";User=SYSDBA;password=7sysgod;Database=" + caminho_conexao + ";");
                    }
                }

            }
        }
    }
}
