using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DAL
{
    public class ConOperationBD : IDisposable
    {
        FbConnection Conexao = new FbConnection(@"USER=SYSDBA;PASSWORD=7sysgod;DATABASE=C:\Sistema SEVEN\Config\Operation.FDB;PORT=3050;DIALECT=3;CHARSET=NONE;ROLE=;CONNECTION TIMEOUT=7;CONNECTION LIFETIME=0;POOLING=True;PACKET SIZE=8192;SERVER TYPE=0;");

        //CONEXAO
        public DataTable Sel_Todos_Conexao()
        {
            Conexao.Open();
            DataTable DtConect = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_conexao_configuracoes, nome_computador, caminho_conexao, senha_autorizacao, tipo_conexao, ordem, entidade, nome_servidor, porta FROM conexao_configuracoes ORDER BY id_conexao_configuracoes ASC;", Conexao);
            Adapter.Fill(DtConect);
            if (DtConect.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConect;
            }
        }

        public string Sel_Ult_Ordem_Existe()
        {
            Conexao.Open();
            DataTable DtConect = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT FIRST 1 ordem FROM conexao_configuracoes ORDER BY id_conexao_configuracoes DESC;", Conexao);
            Adapter.Fill(DtConect);
            if (DtConect.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public void Salvar_Conexao(Conexao Conect)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO conexao_configuracoes(caminho_conexao, entidade, nome_computador, tipo_conexao, conexao_completa, senha_autorizacao, ordem, nome_servidor, porta)VALUES(" + Conect.Caminho_Conexao + ", " + Conect.Entidade + ", " + Conect.Nome_Computador + ", " + Conect.Tipo_Conexao + ", " + Conect.Conexao_Completa + ", " + Conect.Senha_Autorizacao + ", " + Conect.Ordem + ", " + Conect.Nome_Servidor + ", " + Conect.Porta + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public short Sel_Conexao_Ordem_Alt(Conexao Conect)
        {
            Conexao.Open();
            FbDataReader dr;
            DataTable DtGrupo = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_conexao_configuracoes FROM conexao_configuracoes WHERE ordem='" + Conect.Ordem + "';", Conexao);
            Adapter.Fill(DtGrupo);
            if (DtGrupo.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public int Sel_Conexao_Ultimo_Cod_Adicionado()
        {
            Conexao.Open();
            DataTable DtTurma = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT FIRST 1 id_conexao_configuracoes FROM conexao_configuracoes ORDER BY id_conexao_configuracoes DESC;", Conexao);
            Adapter.Fill(DtTurma);
            if (DtTurma.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                int valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt32(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Codigo_Conexao_Ordem(string ordem)
        {
            Conexao.Open();
            DataTable DtTurma = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_conexao_configuracoes FROM conexao_configuracoes WHERE ordem=" + ordem + ";", Conexao);
            Adapter.Fill(DtTurma);
            if (DtTurma.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public void Alterar_Conexao(Conexao Conect)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE conexao_configuracoes SET caminho_conexao=" + Conect.Caminho_Conexao + ", entidade=" + Conect.Entidade + ", nome_computador=" + Conect.Nome_Computador + ", tipo_conexao=" + Conect.Tipo_Conexao + ", conexao_completa=" + Conect.Conexao_Completa + ", senha_autorizacao=" + Conect.Senha_Autorizacao + ", ordem=" + Conect.Ordem + ", nome_servidor=" + Conect.Nome_Servidor + ", porta=" + Conect.Porta + " WHERE id_conexao_configuracoes=" + Conect.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Ordem_Conexao(string codigo, string ordem_anterior)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE conexao_configuracoes SET ordem=" + ordem_anterior + " WHERE id_conexao_configuracoes=" + codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public bool Sel_Entidade_Ver_Nome(Conexao Conect)
        {
            Conexao.Open();
            DataTable DtUsers = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT entidade FROM conexao_configuracoes WHERE entidade ='" + Conect.Entidade + "';", Conexao);
            Adapter.Fill(DtUsers);
            if (DtUsers.Rows.Count == 0)
            {
                Conexao.Close();
                return false;
            }
            else
            {
                Conexao.Close();
                return true;
            }
        }

        public short Sel_Emitente_Ver_Nome_Alt(Conexao Conect)
        {
            Conexao.Open();
            FbDataReader dr;
            DataTable DtUsers = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_conexao_configuracoes FROM conexao_configuracoes WHERE entidade='" + Conect.Entidade + "';", Conexao);
            Adapter.Fill(DtUsers);
            if (DtUsers.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }


        public bool Sel_Conexao_Ordem_Ver(Conexao Conect)
        {
            Conexao.Open();
            DataTable DtConect = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT id_conexao_configuracoes FROM conexao_configuracoes WHERE ordem='" + Conect.Ordem + "';", Conexao);
            Adaper.Fill(DtConect);
            if (DtConect.Rows.Count == 0)
            {
                Conexao.Close();
                return false;
            }
            else
            {
                Conexao.Close();
                return true;
            }
        }

        public void Excluir_Conexao(Conexao Conect)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM conexao_configuracoes WHERE id_conexao_configuracoes=" + Conect.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Conexao(Conexao Conect, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE conexao_configuracoes SET id_conexao_configuracoes=" + Conect.Codigo + " WHERE id_conexao_configuracoes=" + cod_atual + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public string Sel_Computadores_Op_Ver_Codigo(Conexao Conect)
        {
            Conexao.Open();
            DataTable DtComp = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT nome_computador FROM conexao_configuracoes WHERE entidade='" + Conect.Entidade + "';", Conexao);
            Adapter.Fill(DtComp);
            if (DtComp.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string retorno;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                retorno = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }


        public DataTable Sel_Nome_Computador_Senha_Aut_Computadores(Conexao Conect)
        {
            Conexao.Open();
            DataTable DtConect = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT nome_computador, senha_autorizacao FROM conexao_configuracoes WHERE id_conexao_configuracoes='" + Conect.Codigo + "';", Conexao);
            Adapter.Fill(DtConect);
            if (DtConect.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConect;
            }
        }

        public DataTable Sel_Conexao_Empresa_Todas()
        {
            Conexao.Open();
            DataTable DtConect = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_conexao_configuracoes, entidade FROM conexao_configuracoes ORDER BY ordem ASC;", Conexao);
            Adapter.Fill(DtConect);
            if (DtConect.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConect;
            }
        }

        public string Sel_Conexao_Completa_Con(Conexao Conect)
        {
            Conexao.Open();
            DataTable DtConect = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT conexao_completa FROM conexao_configuracoes WHERE id_conexao_configuracoes=" + Conect.Codigo + ";", Conexao);
            Adapter.Fill(DtConect);
            if (DtConect.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string retorno;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                retorno = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public DataTable Sel_Cod_Ult_Con_Sucess_Con(Conexao Conect)
        {
            Conexao.Open();
            DataTable DtConect = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT desc_razao_fantasia_empresa FROM conexao_configuracoes WHERE id_conexao_configuracoes=" + Conect.Codigo + ";", Conexao);
            Adapter.Fill(DtConect);
            if (DtConect.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConect;
            }
        }

        public string[] Sel_Descricao_Conexao_Atual(Conexao Conect)
        {
            Conexao.Open();
            DataTable DtConect = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT nome_computador, caminho_conexao, tipo_conexao FROM conexao_configuracoes WHERE id_conexao_configuracoes=" + Conect.Codigo + ";", Conexao);
            Adapter.Fill(DtConect);
            if (DtConect.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string[] retorno = new string[3];
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                retorno[0] = dr.GetString(0);
                retorno[1] = dr.GetString(1);
                retorno[2] = dr.GetString(2);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }
        //ITEM PARCELAMENTO DFE

        public void Salvar_Item_Parcelamento_DFe(Item_Parcelamento_DFe Parc)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO item_parcelamento_dfe(ocorrencia_parc, data_vencimento, valor, id_conexao_configuracoes)VALUES(" + Parc.Ocorrencia_Parc + ", " + Parc.Data_Vencimento + ", " + Parc.Valor + ", " + Parc.Cod_Conexao_Configuracoes + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Item_Parcelamento_DFe(Item_Parcelamento_DFe Parc)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_parcelamento_dfe SET data_vencimento=" + Parc.Data_Vencimento + ", valor=" + Parc.Valor + ", id_conexao_configuracoes=" + Parc.Cod_Conexao_Configuracoes + " WHERE ocorrencia_parc=" + Parc.Ocorrencia_Parc + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }


        public DataTable Sel_Item_Parcelamento_DFe_Todos(Item_Parcelamento_DFe Parc)
        {
            Conexao.Open();
            DataTable DtItemOrc = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT ocorrencia_parc, data_vencimento, valor, id_conexao_configuracoes FROM item_parcelamento_dfe WHERE id_conexao_configuracoes=" + Parc._Cod_Conexao_Configuracoes + ";", Conexao);
            Adaper.Fill(DtItemOrc);
            if (DtItemOrc.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtItemOrc;
            }
        }

        public void Excluir_Todos_Item_Parcelamento_DFe_Temp(Item_Parcelamento_DFe Parc)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_parcelamento_dfe WHERE id_conexao_configuracoes=" + Parc.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        //LAYOUT PDV
        public void Salvar_Layout_PDV(LayoutPDV Lay)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO layout_pdv(layout_tipo, id_conexao_configuracoes)VALUES(" + Lay.Layout_Tipo + ", " + Lay.Cod_Conexao_Configuracoes + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Layout_PDV(LayoutPDV Lay)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE layout_pdv SET layout_tipo=" + Lay.Layout_Tipo + " WHERE id_conexao_configuracoes=" + Lay.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Layout_PDV_Todos(LayoutPDV Lay)
        {
            Conexao.Open();
            DataTable DtItemOrc = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT layout_tipo FROM layout_pdv WHERE id_conexao_configuracoes=" + Lay.Cod_Conexao_Configuracoes + ";", Conexao);
            Adaper.Fill(DtItemOrc);
            if (DtItemOrc.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtItemOrc;
            }
        }


        //VERSAO
        public void Executar_Arquivo_SQL(string sql)
        {
            if (Conexao.State == ConnectionState.Open)
            {
                Conexao.Close();
            }
            Conexao.Open();
            FbCommand Comandos = new FbCommand(sql, Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Versao_Todos()
        {
            Conexao.Open();
            DataTable DtCaixa = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT seven_adm, seven_pdv, seven_config, bll, dal, sql, acbr_lib, config, sistema_seven FROM versao WHERE id_versao='1';", Conexao);
            Adaper.Fill(DtCaixa);
            if (DtCaixa.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtCaixa;
            }
        }

        public void Alterar_Versao_SQL(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE versao SET sql='" + Ver.SQL_Operation + "' WHERE id_versao='1';", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Versao_SQL(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO versao(id_versao, sql)VALUES('1', '" + Ver.SQL_Operation + "');", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Versao_Seven_ADM(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE versao SET seven_adm='" + Ver.Seven_ADM + "' WHERE id_versao='1';", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Versao_Seven_ADM(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO versao(id_versao, seven_adm)VALUES('1', '" + Ver.Seven_ADM + "');", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Versao_Seven_Config(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE versao SET seven_config='" + Ver.Seven_Config + "' WHERE id_versao='1';", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Versao_ACBR_lib(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE versao SET acbr_lib='" + Ver.ACBR_LIB + "' WHERE id_versao='1';", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Versao_Config(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE versao SET config='" + Ver.Config + "' WHERE id_versao='1';", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Versao_Sistema_Seven(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE versao SET sistema_seven='" + Ver.Sistema_Seven + "' WHERE id_versao='1';", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Versao_ACBR_Lib(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO versao(id_versao, acbr_lib)VALUES('1', '" + Ver.ACBR_LIB + "');", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Versao_Config(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO versao(id_versao, config)VALUES('1', '" + Ver.Config + "');", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Versao_Sistema_Seven(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO versao(id_versao, sistema_seven)VALUES('1', '" + Ver.Sistema_Seven + "');", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }


        public void Salvar_Versao_Seven_Config(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO versao(id_versao, seven_config)VALUES('1', '" + Ver.Seven_Config + "');", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Versao_DAL(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE versao SET dal='" + Ver.DAL + "' WHERE id_versao='1';", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Versao_DAL(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO versao(id_versao, dal)VALUES('1', '" + Ver.DAL + "');", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

      

        public void Alterar_Versao_BLL(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE versao SET bll='" + Ver.BLL + "' WHERE id_versao='1';", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

       
     

        public void Salvar_Versao_BLL(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO versao(id_versao, bll)VALUES('1', '" + Ver.BLL + "');", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

     

       
      
        public void Alterar_Versao_Seven_PDV(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE versao SET seven_pdv='" + Ver.Seven_PDV + "' WHERE id_versao='1';", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Versao_Seven_PDV(Versao Ver)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO versao(id_versao, seven_pdv)VALUES('1', '" + Ver.Seven_PDV + "');", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        //MULTIPLO CODIGOS BARRA
        public void Salvar_Multiplo_Cod_Barra_Temp(MultiplosCodigoBarra_Temp Mult)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO multiplo_cod_barra_temp (id_mult_cod_barra, cod_barra)VALUES(" + Mult.Codigo + ", " + Mult.Cod_Barra + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Barra_Temp(MultiplosCodigoBarra_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE multiplo_cod_barra_temp SET id_mult_cod_barra=" + Items.Codigo + " WHERE id_mult_cod_barra=" + cod_atual + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Items_Codigo_Barra_Atual()
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM multiplo_cod_barra_temp;", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Multiplo_Cod_Barra_Todos_Temp()
        {
            Conexao.Open();
            DataTable DtMult = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_mult_cod_barra, cod_barra FROM multiplo_cod_barra_temp ORDER BY id_mult_cod_barra;", Conexao);
            Adapter.Fill(DtMult);
            if (DtMult.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtMult;
            }
        }

        public bool Val_Mult_Barra_Temp(MultiplosCodigoBarra_Temp Mult)
        {
            Conexao.Open();
            DataTable DtMult = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_mult_cod_barra FROM multiplo_cod_barra_temp WHERE cod_barra='" + Mult.Cod_Barra + "';", Conexao);
            Adapter.Fill(DtMult);
            if (DtMult.Rows.Count == 0)
            {
                Conexao.Close();
                return false;
            }
            else
            {
                Conexao.Close();
                return true;
            }
        }

        public void Excluir_Codigo_Barra_Temp(MultiplosCodigoBarra_Temp Mult)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM multiplo_cod_barra_temp WHERE id_mult_cod_barra=" + Mult.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }




        //CONFIGURAÇÃO SISTEMA
        public void Salvar_Configuracao_Local(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO configuracoes_locais(usar_axacropdf, resolucao, imagem_fundo_7_adm, ajuste_imagem_7_adm, ver_data_hora_internet, ativar_letreiro, mostrar_desc_acresc_venda, tipo_impressao_nnf, tipo_impressao_nota_prom, tipo_impressao_orcamento, tipo_impressao_devolucao, tipo_impressao_conta_receber, nome_imp_nnf, nome_imp_nota_prom, nome_imp_orcamento, nome_imp_devolucao, nome_imp_conta_receber, margem_esq_pdf, margem_topo_pdf, margem_esq_pdf_pdv, margem_topo_pdf_pdv, margem_esq_a4_pdv, margem_topo_a4_pdv, margem_esq_80_pdv, margem_topo_80_pdv, id_conexao_configuracoes, usar_axacropdf_pdv, mensagem, mostrar_inf_usuario, margem_esq_nfce, margem_dir_nfce, tipo, buscar_atualizacao)VALUES(" + Config.Usar_Axacropdf + ", " + Config.Resolucao + ", " + Config.Imagem_Fundo_7_ADM + ", " + Config.Ajuste_Imagem_7_ADM + ", " + Config.Ver_Data_Hora_Internet + ", " + Config.Ativar_Letreiro + ", " + Config.Mostrar_Desc_Acresc + ", " + Config.Tipo_Impressao_NNF + ", " + Config.Tipo_Impressao_Nota_Prom + ", " + Config.Tipo_Impressao_Orcamento + ", " + Config.Tipo_Impressao_Devolucao + ", " + Config.Tipo_Impressao_Conta_Receber + ", " + Config.Nome_Imp_NNF + ", " + Config.Nome_Imp_Nota_Prom + ", " + Config.Nome_Imp_Orcamento + ", " + Config.Nome_Imp_Devolucao + ", " + Config.Nome_Imp_Conta_Receber + ", " + Config.Margem_Esq + ", " + Config.Margem_Topo + ", " + Config.Margem_Esq_pdv + ", " + Config.Margem_Topo_pdv + ", " + Config.Margem_Esq_A4_pdv + ", " + Config.Margem_Topo_A4_pdv + ", " + Config.Margem_Esq_80_pdv + ", " + Config.Margem_Topo_80_pdv + ", " + Config.Cod_Conexao_Configuracoes + ", " + Config.Usar_Axacropdf_PDV + ", " + Config.Mensagem + ", " + Config.Mostrar_Inf_Usuario + ", " + Config.Margem_Esq_NFCe + ", " + Config.Margem_Dir_NFCe + ", " + Config.Tipo + ", " + Config.Buscar_Atualizacao + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Local(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Layout_PDV(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM layout_pdv WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Dado_PDV_Atual(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM dado_pdv_atual WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_DFE_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM dfe_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Conta_Pagar_Pgto_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_conta_pagar_pgto_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Conta_Receber_Pgto_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_conta_receber_pgto_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Devolucao_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_devolucao_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Dev_Prod_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_dev_prod_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Dfe_Pgto_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_dfe_pgto_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }
              
        public void Excluir_Configuracao_Item_Dfe_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_dfe_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Orcamento_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_orcamento_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Os_Funcionario_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_os_funcionario_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Os_Pgto_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_os_pgto_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Os_Produto_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_os_produto_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Parcelamento_Dfe(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_parcelamento_dfe WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_PDV_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_pdv_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Item_Servico_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_servico_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_SMS_Configuracoes(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM sms_configuracoes WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Configuracao_Transportador_Temp(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM transportador_temp WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public string Sel_Ajuste_Imagem_7_Adm(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtImagemSistema = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT ajuste_imagem_7_adm FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtImagemSistema);
            if (DtImagemSistema.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Imagem_Fundo_7_Adm(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtImagemSistema = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT imagem_fundo_7_adm FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtImagemSistema);
            if (DtImagemSistema.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Ver_Data_Hora_Internet(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtImagemSistema = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT ver_data_hora_internet FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtImagemSistema);
            if (DtImagemSistema.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Ativar_Letreiro(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtImagemSistema = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT ativar_letreiro FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtImagemSistema);
            if (DtImagemSistema.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public DataTable Sel_Tabela_Configuracao_Local_Configuracoes(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq_pdf, margem_topo_pdf, usar_axacropdf, resolucao, imagem_fundo_7_adm, ajuste_imagem_7_adm, ver_data_hora_internet, ativar_letreiro, mensagem, usar_axacropdf_pdv, nome_imp_nnf, nome_imp_nota_prom, tipo_impressao_nota_prom, tipo_impressao_orcamento, tipo_impressao_conta_receber, tipo_impressao_devolucao, nome_imp_conta_receber, nome_imp_devolucao, nome_imp_orcamento, tipo_impressao_nnf, margem_esq_pdf_pdv, margem_topo_pdf_pdv, margem_esq_80_pdv, margem_topo_80_pdv, margem_esq_a4_pdv, margem_topo_a4_pdv, mostrar_desc_acresc_venda, mostrar_inf_usuario, margem_esq_nfce, margem_dir_nfce, buscar_atualizacao FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConfig;
            }
        }

        public void Alterar_Configuracao_Local(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE configuracoes_locais SET usar_axacropdf=" + Config.Usar_Axacropdf + ", resolucao=" + Config.Resolucao + ", imagem_fundo_7_adm=" + Config.Imagem_Fundo_7_ADM + ", ajuste_imagem_7_adm=" + Config.Ajuste_Imagem_7_ADM + ", ver_data_hora_internet=" + Config.Ver_Data_Hora_Internet + ", ativar_letreiro=" + Config.Ativar_Letreiro + ", mostrar_desc_acresc_venda=" + Config.Mostrar_Desc_Acresc + ", tipo_impressao_nnf=" + Config.Tipo_Impressao_NNF + ", tipo_impressao_nota_prom=" + Config.Tipo_Impressao_Nota_Prom + ", tipo_impressao_orcamento=" + Config.Tipo_Impressao_Orcamento + ", tipo_impressao_devolucao=" + Config.Tipo_Impressao_Devolucao + ", tipo_impressao_conta_receber=" + Config.Tipo_Impressao_Conta_Receber + ", nome_imp_nnf=" + Config.Nome_Imp_NNF + ", nome_imp_nota_prom=" + Config.Nome_Imp_Nota_Prom + ", nome_imp_orcamento=" + Config.Nome_Imp_Orcamento + ", nome_imp_devolucao=" + Config.Nome_Imp_Devolucao + ", nome_imp_conta_receber=" + Config.Nome_Imp_Conta_Receber + ", margem_esq_pdf=" + Config.Margem_Esq + ", margem_topo_pdf=" + Config.Margem_Topo + ", margem_esq_pdf_pdv=" + Config.Margem_Esq_pdv + ", margem_topo_pdf_pdv=" + Config.Margem_Topo_pdv + ", margem_esq_a4_pdv=" + Config.Margem_Esq_A4_pdv + ", margem_topo_a4_pdv=" + Config.Margem_Topo_A4_pdv + ", margem_esq_80_pdv=" + Config.Margem_Esq_80_pdv + ", margem_topo_80_pdv=" + Config.Margem_Topo_80_pdv + ", id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ", usar_axacropdf_pdv=" + Config.Usar_Axacropdf_PDV + ", mensagem=" + Config.Mensagem + ", mostrar_inf_usuario=" + Config.Mostrar_Inf_Usuario + ", margem_esq_nfce=" + Config.Margem_Esq_NFCe + ", margem_dir_nfce=" + Config.Margem_Dir_NFCe + ", buscar_atualizacao=" + Config.Buscar_Atualizacao + " WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Tipo_Documento_PDV(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE configuracoes_locais SET tipo=" + Config.Tipo + " WHERE id_conexao_configuracoes=" + Config.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public short Sel_Margem_Esq_PDF_A4_Adm(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq_pdf FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Esq_NFCe(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq_nfce FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Dir_NFCe(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_dir_nfce FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Esq_Pdv_PDF(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq_pdf_pdv FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Esq_80_Pdv(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq_80_pdv FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Topo_80_Pdv(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq_80_pdv FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Esq_A4_Pdv(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq_a4_pdv FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Resolucao_Pdv(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT resolucao FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Mensagem_Pdv(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT mensagem FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Mostrar_Inf_Usuario(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT mostrar_inf_usuario FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Topo_A4_Pdv(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_topo_a4_pdv FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Topo_Pdv_PDF(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_topo_pdf_pdv FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Topo_PDF_A4_Adm(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_topo_pdf FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Tipo_Imp_NNF(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_impressao_nnf FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Tipo_Imp_Conta_Receber()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_impressao_conta_receber FROM configuracoes_locais WHERE id_conexao_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Tipo_Imp_Nota_Promissoria(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_impressao_nota_prom FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Nome_Imp_NNF(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT nome_imp_nnf FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Tipo_Imp_Orcamento(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_impressao_orcamento FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Nome_Imp_Orcamento(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT nome_imp_orcamento FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Tipo_Imp_Devolucao(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_impressao_devolucao FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public int Sel_Usar_Axacropdf_Adm(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT usar_axacropdf FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                int valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt32(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public int Sel_Usar_Axacropdf_Pdv(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT usar_axacropdf_pdv FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                int valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt32(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        //TRANSPORTADOR

        public void Salvar_Transportador_Temp(Transportador_Temp Transp)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO transportador_temp (tipo_transporte, tipo_frete, id_fornecedor, nome_fornecedor, veiculo, codigo_antt, placa, uf, especie, marca, quantidade, numeracao, peso_bruto, peso_liquido, id_conexao_configuracoes, valor_frete)VALUES(" + Transp.Tipo_Transporte + ", " + Transp.Tipo_Frete + ", " + Transp.Cod_Fornecedor + ", " + Transp.Nome_Fornecedor + ", " + Transp.Veiculo + ", " + Transp.Codigo_ANTT + ", " + Transp.Placa + ", " + Transp.UF + ", " + Transp.Especie + ", " + Transp.Marca + ", " + Transp.Quantidade + ", " + Transp.Numeracao + ", " + Transp.Peso_Bruto + ", " + Transp.Peso_Liquido + ", " + Transp.Cod_Conexao_Configuracoes + ", " + Transp.Valor_Frete + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Transportador_Temp(Transportador_Temp Transp)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE transportador_temp SET tipo_transporte=" + Transp.Tipo_Transporte + ", tipo_frete=" + Transp.Tipo_Frete + ", id_fornecedor=" + Transp.Cod_Fornecedor + ", nome_fornecedor=" + Transp.Nome_Fornecedor + ", veiculo=" + Transp.Veiculo + ", codigo_antt=" + Transp.Codigo_ANTT + ", placa=" + Transp.Placa + ", uf=" + Transp.UF + ", especie=" + Transp.Especie + ", marca=" + Transp.Marca + ", quantidade=" + Transp.Quantidade + ", numeracao=" + Transp.Numeracao + ", peso_bruto=" + Transp.Peso_Bruto + ", peso_liquido=" + Transp.Peso_Liquido + ", valor_frete=" + Transp.Valor_Frete + " WHERE id_conexao_configuracoes=" + Transp.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Dados_Transportador_Temp(Transportador_Temp Transp)
        {
            Conexao.Open();
            DataTable DtTransp = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_transporte, tipo_frete, id_fornecedor, nome_fornecedor, veiculo, codigo_antt, placa, uf, especie, marca, quantidade, numeracao, peso_bruto, peso_liquido, valor_frete FROM transportador_temp WHERE id_conexao_configuracoes=" + Transp.Cod_Conexao_Configuracoes + ";", Conexao);
            Adapter.Fill(DtTransp);
            if (DtTransp.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtTransp;
            }
        }

        //OS
        public DataTable Sel_Item_Servico_Temp_Todos(Item_Servico_Temp Items)
        {
            Conexao.Open();
            DataTable DtServ = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_item, id_servico, descricao, quantidade, valor_unitario, valor_total, comissao_porc, valor_desconto, valor_acrescimo, valor_total_a_desc_acresc, id_orcamento FROM item_servico_temp WHERE id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + " ORDER BY id_item ASC;", Conexao);
            Adapter.Fill(DtServ);
            if (DtServ.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtServ;
            }
        }

        public void Excluir_Item_OS_Pgto_Atual(Item_OS_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM Item_os_pgto_temp WHERE id_conexao_configuracoes=" + Pgto.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Pgto_OS(Item_OS_Pgto_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE Item_os_pgto_temp SET id_item_pagamento=" + Items.Codigo + " WHERE id_item_pagamento=" + cod_atual + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_Pgto_OS_Temp(Item_OS_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM Item_os_pgto_temp WHERE id_item_pagamento=" + Pgto.Codigo + " AND id_conexao_configuracoes=" + Pgto.Cod_Conexao_Configuracoes + " AND id_tabela=" + Pgto.Cod_Tabela + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Item_OS_Pgto_Todas(Item_OS_Pgto_Temp Items)
        {
            Conexao.Open();
            DataTable DtServ = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_item_pagamento, id_pagamento, tipo, valor_pago, pagamento_parcial FROM Item_os_pgto_temp WHERE id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + " ORDER BY id_item_pagamento ASC;", Conexao);
            Adapter.Fill(DtServ);
            if (DtServ.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtServ;
            }
        }

        public DataTable Sel_Item_OS_Funcionario_Temp_Todos(Item_OS_Funcionario_Temp Items)
        {
            Conexao.Open();
            DataTable DtServ = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_item, id_funcionario, nome_funcionario, imagem_func FROM item_os_funcionario_temp WHERE id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + " ORDER BY id_item ASC;", Conexao);
            Adapter.Fill(DtServ);
            if (DtServ.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtServ;
            }
        }

        public void Salvar_Forma_Pagamento_OS_Temp(Item_OS_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO Item_os_pgto_temp(id_item_pagamento, id_pagamento, tipo, valor_pago, id_conexao_configuracoes, id_tabela, pagamento_parcial)VALUES(" + Pgto.Codigo + ", " + Pgto.Cod_Pagamento + ", " + Pgto.Tipo + ", " + Pgto.Valor_Pago + ", " + Pgto.Cod_Conexao_Configuracoes + ", " + Pgto.Cod_Tabela + ", " + Pgto.Pagamento_Parcial + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Item_OS_Produto_Temp_Todos(Item_Servico_Temp Items)
        {
            Conexao.Open();
            DataTable DtServ = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_item, id_produto, descricao, quantidade, um, valor_unitario, valor_total, valor_desconto, valor_acrescimo, valor_total_a_desc_acresc, id_orcamento FROM item_os_produto_temp WHERE id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + " ORDER BY id_item;", Conexao);
            Adapter.Fill(DtServ);
            if (DtServ.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtServ;
            }
        }

        public void Salvar_Items_Servico_Temp(Item_Servico_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO item_servico_temp(id_item, id_servico, descricao, valor_unitario, id_conexao_configuracoes, quantidade, valor_total, comissao_porc, valor_desconto, valor_acrescimo, valor_total_a_desc_acresc, id_orcamento)VALUES(" + Items.Codigo + ", " + Items.Cod_Servico + ", " + Items.Desc_Servico + ", " + Items.Valor_Unitario + ", " + Items.Cod_Conexao_Configuracoes + ", " + Items.Quantidade + ", " + Items.Valor_Total + ", " + Items.Comissao_Porc + ", " + Items.Valor_Desconto + ", " + Items.Valor_Acrescimo + ", " + Items.Valor_Total_A_Desc_Acresc + ", " + Items.Cod_Orcamento + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Item_OS_Funcionario_Temp(Item_OS_Funcionario_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO item_os_funcionario_temp(id_item, id_funcionario, nome_funcionario, id_conexao_configuracoes, imagem_func)VALUES(" + Items.Codigo + ", " + Items.Cod_Funcionario + ", " + Items.Nome_Funcionario+ ", " + Items.Cod_Conexao_Configuracoes + ", " + Items.Imagem_Func + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_Servico_Todos_Temp(Item_Servico_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_servico_temp WHERE id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_OS_Produto_Todos_Temp(Item_Servico_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_os_produto_temp WHERE id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_OS_Funcionario_Todos_Temp(Item_OS_Funcionario_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_os_funcionario_temp WHERE id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_Servico_Temp(Item_Servico_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_servico_temp WHERE id_item=" + Items.Codigo + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_OS_Produto_Temp(Item_OS_Produto_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_os_produto_temp WHERE id_item=" + Items.Codigo + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_OS_Funcionario_Temp(Item_OS_Funcionario_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_os_funcionario_temp WHERE id_item=" + Items.Codigo + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }


        public void Atualizar_Item_Dt_Item_Servico_Temp(Item_Servico_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_servico_temp SET id_item=" + Items.Codigo + " WHERE id_item=" + cod_atual + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Item_OS_Produto_Temp(Item_OS_Produto_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_os_produto_temp SET id_item=" + Items.Codigo + " WHERE id_item=" + cod_atual + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Item_OS_Funcionario_Temp(Item_OS_Funcionario_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_os_funcionario_temp SET id_item=" + Items.Codigo + " WHERE id_item=" + cod_atual + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Item_OS_Produto_Temp(Item_OS_Produto_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO item_os_produto_temp(id_item, id_produto, descricao, valor_unitario, valor_total, quantidade, um, valor_desconto, valor_acrescimo, valor_total_a_desc_acresc, id_conexao_configuracoes, id_orcamento)VALUES(" + Items.Codigo + ", " + Items.Cod_Produto + ", " + Items.Descricao + ", " + Items.Valor_Unitario + ", " + Items.Valor_Total + ", " + Items.Quantidade + ", " + Items.UM + ", " + Items.Valor_Desconto + ", " + Items.Valor_Acrescimo + ", " + Items.Valor_Total_A_Desc_Acresc + ", " + Items.Cod_Conexao_Configuracoes + ", " + Items.Cod_Orcamento + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        /*
        //PREFENRENCIA_USUARIO_ORCAMENTO
        public void Salvar_InfImpressaoOrc(Item_Conta_Pagar_Pgto_Temp Pref)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO preferencia_usuario_orc(id_preferencia_usuario_orc, tipo_imp, nome_impressora, numero_copia, mostrar_logo_imp)VALUES(1, " + Pref.Tipo_Imp_Orc + ", " + Pref.Nome_Impressora + ", " + Pref.N_Copia + ", " + Pref.Mostrar_Logo_Imp + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_InfImpressaoOrc(Item_Conta_Pagar_Pgto_Temp Pref)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE preferencia_usuario_orc SET tipo_imp=" + Pref.Tipo_Imp_Orc + ", nome_impressora=" + Pref.Nome_Impressora + ", numero_copia=" + Pref.N_Copia + ", mostrar_logo_imp=" + Pref.Mostrar_Logo_Imp + " WHERE id_preferencia_usuario_orc=1;", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Tabela_InfImpressaoOrc_Configuracoes()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_imp, nome_impressora, numero_copia, mostrar_logo_imp FROM preferencia_usuario_orc WHERE id_preferencia_usuario_orc=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConfig;
            }
        }
        */
        //CONFIGURACOES DO SISTEMA

        public string Sel_Imagem_Local_7_dir()
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT imagem_local_7_dir FROM configuracao_sistema;", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public string Sel_Tipo_Documento_Venda(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT tipo FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public byte Sel_Mostrar_Desc_Acresc_Venda(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT mostrar_desc_acresc_venda FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public byte Sel_Buscar_Atualizacoes(ConfiguracaoSistema Config)
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT buscar_atualizacao FROM configuracoes_locais WHERE id_conexao_configuracoes=" + Config.Codigo + ";", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public string Sel_Digitalizacao_Local_7_dir()
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT digitalizacao_local_7_dir FROM configuracao_sistema;", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public byte Sel_Conta_Fechada_Excluir()
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT conta_fechada_excluir FROM configuracao_sistema;", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public byte Sel_Conta_Fechada_Alterar()
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT conta_fechada_alterar FROM configuracao_sistema;", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public string Sel_Rel_Impressora()
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT rel_impressora FROM configuracao_sistema;", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }


        public string Sel_Codigo_Tabela_Local()
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT codigo_tabela_local FROM configuracao_sistema;", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public byte Sel_Troco_Cartao_ContaPagar()
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT troco_cartao_contapagar FROM configuracao_sistema;", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public byte Sel_Troco_Cartao_ContaReceber()
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT troco_cartao_contareceber FROM configuracao_sistema;", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public string Sel_Arquivo_Local()
        {
            Conexao.Open();
            DataTable DtConfiguracao = new DataTable();
            FbDataReader dr;
            FbCommand Comandos = new FbCommand("SELECT arquivo_local FROM configuracao_sistema;", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfiguracao);
            if (DtConfiguracao.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string retorno;
                dr = Comandos.ExecuteReader();
                dr.Read();
                retorno = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return retorno;
            }
        }

        public bool Verificar_Dados()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbCommand Comandos = new FbCommand("SELECT id_configuracao_sistema FROM configuracao_sistema;", Conexao);
            FbDataAdapter Adapter = new FbDataAdapter(Comandos);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return false;
            }
            else
            {
                Conexao.Close();
                return true;
            }
        }

        public byte Gerar_Log_Acao()
        {
            Conexao.Open();
            FbDataReader dr;
            DataTable DtConfig = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT log_acao FROM configuracao_sistema;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public DataTable Sel_Tabela_Configuracoes()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT arquivo_local, imagem_local_7_dir, troco_cartao_contareceber, troco_cartao_contapagar, digitalizacao_local_7_dir, conta_fechada_excluir, conta_fechada_alterar FROM configuracao_sistema ORDER BY id_configuracao_sistema ASC;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else if (DtConfig.Rows.Count > 1)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConfig;
            }
        }

        public DataTable Sel_Computadores_Op_Ver_Codigo()
        {
            Conexao.Open();
            DataTable DtComp = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_conexao_configuracoes FROM conexao_configuracoes;", Conexao);
            Adapter.Fill(DtComp);
            if (DtComp.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtComp;
            }
        }

        //DFE
        public void Salvar_Forma_Pagamento_DFe_Temp(Item_DFe_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO item_dfe_pgto_temp(id_item_pagamento, id_pagamento, tipo, valor_pago, id_conexao_configuracoes)VALUES(" + Pgto.Codigo + ", " + Pgto.Cod_Pagamento + ", " + Pgto.Tipo + ", " + Pgto.Valor_Pago + ", " + Pgto.Cod_Conexao_Configuracoes + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_CFOP_Item_DFe_Temp(Item_DFe_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_dfe_temp SET cfop=" + Item.CFOP + " WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_Pgto_DFe_Temp(Item_DFe_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_dfe_pgto_temp WHERE id_item_pagamento=" + Pgto.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Referencia_Temp(ReferenciaDFe_Temp Ref)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM referencia_dfe_temp WHERE id_referencia=" + Ref.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Referencia_Temp(ReferenciaDFe_Temp Ref)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO referencia_dfe_temp (id_referencia, chave_dfe, id_conexao_configuracoes)VALUES(" + Ref.Codigo + ", " + Ref.Chave_DFe + ", " + Ref.Cod_Conexao_Configuracoes + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Referencia_Temp(ReferenciaDFe_Temp Ref)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE referencia_dfe_temp SET chave_dfe=" + Ref.Chave_DFe + " WHERE id_referencia=" + Ref.Codigo + " AND id_conexao_configuracoes=" + Ref.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Referencia_DFe_Temp(ReferenciaDFe_Temp Ref)
        {
            Conexao.Open();
            DataTable DtRef = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_referencia, chave_dfe FROM referencia_dfe_temp WHERE id_conexao_configuracoes=" + Ref.Cod_Conexao_Configuracoes + " ORDER BY id_referencia ASC;", Conexao);
            Adapter.Fill(DtRef);
            if (DtRef.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtRef;
            }
        }

        public short Val_Referencia_Chave_Alt_Temp(ReferenciaDFe_Temp Ref)
        {
            Conexao.Open();
            DataTable DtRef = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_referencia FROM referencia_dfe_temp WHERE chave_dfe='" + Ref.Chave_DFe + "';", Conexao);
            Adapter.Fill(DtRef);
            if (DtRef.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public bool Val_Referencia_Chave_Temp(ReferenciaDFe_Temp Ref)
        {
            Conexao.Open();
            DataTable DtRef = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_referencia FROM referencia_dfe_temp WHERE chave_dfe='" + Ref.Chave_DFe + "';", Conexao);
            Adapter.Fill(DtRef);
            if (DtRef.Rows.Count == 0)
            {
                Conexao.Close();
                return false;
            }
            else
            {
                Conexao.Close();
                return true;
            }
        }

        public void Excluir_Item_DFe_Pgto_Atual(Item_DFe_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM Item_dfe_pgto_temp WHERE id_conexao_configuracoes=" + Pgto.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Pgto_DFe_Temp(Item_DFe_Pgto_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE Item_dfe_pgto_temp SET id_item_pagamento=" + Items.Codigo + " WHERE id_item_pagamento=" + cod_atual + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Referencia_DFe_Temp(ReferenciaDFe_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE referencia_dfe_temp SET id_referencia=" + Items.Codigo + " WHERE id_referencia=" + cod_atual + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }



        public DataTable Sel_Item_DFe_Pgto_Todas_Temp(Item_DFe_Pgto_Temp Pgto)
        {
            Conexao.Open();
            DataTable DtConta = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_item_pagamento, id_pagamento, tipo, valor_pago FROM item_dfe_pgto_temp WHERE id_conexao_configuracoes=" + Pgto.Cod_Conexao_Configuracoes + " ORDER BY id_item_pagamento ASC;", Conexao);
            Adapter.Fill(DtConta);
            if (DtConta.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConta;
            }
        }


        //CONTA RECEBER
        public void Salvar_Forma_Pagamento_Conta_Receber(Item_Conta_Receber_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO Item_conta_receber_pgto_temp(id_item_pagamento, id_pagamento, tipo, valor_pago, pagamento_parcial, id_conexao_configuracoes)VALUES(" + Pgto.Codigo + ", " + Pgto.Cod_Pagamento + ", " + Pgto.Tipo + ", " + Pgto.Valor_Pago + ", " + Pgto.Pagamento_Parcial + ", " + Pgto.Cod_Conexao_Configuracoes + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        //CONFIGURACOES ENVIAR_EMAIL
        public void Salvar_Config_Email_Enviar(EnviarEmail Email)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO email_configuracoes (id_email_configuracoes, smtp_hotmail_outlook, porta_hotmail_outlook, smtp_gmail, porta_gmail, smtp_yahoo, porta_yahoo, prioridade, ssl, html)VALUES(1," + Email.Smtp_Hotmail_Outlook + ", " + Email.Porta_Hotmail_Outlook + ", " + Email.Smtp_Gmail + ", " + Email.Porta_Gmail + ", " + Email.Smtp_Yahoo + ", " + Email.Porta_Yahoo + ", " + Email.Prioridade + ", " + Email.SSL + ", " + Email.Html + ")", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Config_Email_Enviar(EnviarEmail Email)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE email_configuracoes SET smtp_hotmail_outlook=" + Email.Smtp_Hotmail_Outlook + ", porta_hotmail_outlook=" + Email.Porta_Hotmail_Outlook + ", smtp_gmail=" + Email.Smtp_Gmail + ", porta_gmail=" + Email.Porta_Gmail + ", smtp_yahoo=" + Email.Smtp_Yahoo + ", porta_yahoo=" + Email.Porta_Yahoo + ", prioridade=" + Email.Prioridade + ", ssl=" + Email.SSL + ", html=" + Email.Html + " WHERE id_email_configuracoes=1;", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Tabela_Email_Configuracoes()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT smtp_hotmail_outlook, porta_hotmail_outlook, smtp_gmail, porta_gmail, smtp_yahoo, porta_yahoo, prioridade, ssl, html FROM email_configuracoes WHERE id_email_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConfig;
            }
        }

        public string Sel_Smtp_Hotmail_Outlook()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT smtp_hotmail_outlook FROM email_configuracoes WHERE id_email_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public int Sel_Porta_Yahoo()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT porta_yahoo FROM email_configuracoes WHERE id_email_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                int valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt32(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public int Sel_Porta_Hotmail_Outlook()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT porta_hotmail_outlook FROM email_configuracoes WHERE id_email_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                int valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt32(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public int Sel_Porta_Gmail()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT porta_gmail FROM email_configuracoes WHERE id_email_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                int valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt32(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Smtp_Gmail()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT smtp_gmail FROM email_configuracoes WHERE id_email_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Smtp_Yahoo()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT smtp_yahoo FROM email_configuracoes WHERE id_email_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_SSL_Email()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT ssl FROM email_configuracoes WHERE id_email_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Prioridade_Email()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT prioridade FROM email_configuracoes WHERE id_email_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Html_Email()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT html FROM email_configuracoes WHERE id_email_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Alterar_Conta_Receber_Fechada()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT alterar_conta_receber_fechada FROM conta_receber_configuracoes WHERE id_conta_receber_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Excluir_Conta_Receber_Fechada()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT excluir_conta_receber_fechada FROM conta_receber_configuracoes WHERE id_conta_receber_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public void Salvar_Pagamento_Conta_Receber_Temp(Item_Conta_Receber_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO Item_conta_receber_pgto_temp(id_item_pagamento, id_pagamento, tipo, valor_pago, pagamento_parcial)VALUES(" + Pgto.Codigo + ", " + Pgto.Cod_Pagamento + ", " + Pgto.Tipo + ", " + Pgto.Valor_Pago + ", " + Pgto.Pagamento_Parcial + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Item_Conta_Receber_Pgto_Todas(Item_Conta_Receber_Pgto_Temp Items)
        {
            Conexao.Open();
            DataTable DtConta = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_item_pagamento, id_pagamento, tipo, valor_pago, pagamento_parcial FROM Item_conta_receber_pgto_temp WHERE id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + " ORDER BY id_item_pagamento ASC;", Conexao);
            Adapter.Fill(DtConta);
            if (DtConta.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConta;
            }
        }

        public void Excluir_Item_Pgto_Conta_Receber(Item_Conta_Receber_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM Item_conta_receber_pgto_temp WHERE id_item_pagamento=" + Pgto.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Pgto_Conta_Receber(Item_Conta_Receber_Pgto_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE Item_conta_receber_pgto_temp SET id_item_pagamento=" + Items.Codigo + " WHERE id_item_pagamento=" + cod_atual + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_Conta_Receber_Pgto_Atual(Item_Conta_Receber_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM Item_conta_receber_pgto_temp WHERE id_conexao_configuracoes=" + Pgto.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_Conta_Pagar_Pgto_Atual()
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM Item_conta_pagar_pgto_temp;", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Pagamento_Conta_Pagar(Item_Conta_Pagar_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO Item_conta_pagar_pgto_temp(id_item_pagamento, id_pagamento, tipo, valor_pago, pagamento_parcial, id_conexao_configuracoes)VALUES(" + Pgto.Codigo + ", " + Pgto.Cod_Pagamento + ", " + Pgto.Tipo + ", " + Pgto.Valor_Pago + ", " + Pgto.Pagamento_Parcial + ", " + Pgto.Cod_Conexao_Configuracoes + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Pgto_Conta_Pagar(Item_Conta_Pagar_Pgto_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE Item_conta_pagar_pgto_temp SET id_item_pagamento=" + Items.Codigo + " WHERE id_item_pagamento=" + cod_atual + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public byte Sel_Usar_Axacropdf_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT usar_axacropdf FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public void Excluir_Item_Pgto_Conta_Pagar(Item_Conta_Pagar_Pgto_Temp Pgto)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM Item_conta_pagar_pgto_temp WHERE id_item_pagamento=" + Pgto.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Item_Conta_Pagar_Pgto_Todas()
        {
            Conexao.Open();
            DataTable DtConta = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT id_item_pagamento, id_pagamento, tipo, valor_pago, pagamento_parcial FROM Item_conta_pagar_pgto_temp ORDER BY id_item_pagamento ASC;", Conexao);
            Adapter.Fill(DtConta);
            if (DtConta.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConta;
            }
        }

        public byte Sel_Mostrar_Logo_Relatorio_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT mostrar_logo_relatorio FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Tamanho_Term_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tamanho_term FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Fonte_Term_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT fonte_term FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Mostrar_Dados_Rel_Filtro_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT mostrar_dados_rel_filtro FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Tipo_Term_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_term FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Esq_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public int Sel_Margem_Esq_Term_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq_term FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                int valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt32(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Topo_Pdf_80_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_topo_pdf_80 FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Topo_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_topo FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Alterar_Conta_Pagar_Fechada()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT alterar_conta_pagar_fechada FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Excluir_Conta_Pagar_Fechada()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT excluir_conta_pagar_fechada FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Esq_Pdf_80_Conta_Pagar()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq_pdf_80 FROM conta_pagar_configuracoes WHERE id_conta_pagar_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }








        public string Sel_Tipo_Imp_PDV_Devolucao()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_impressao_devolucao FROM pdv_venda_configuracoes WHERE id_pdv_venda_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Tipo_Imp_Orc_PDV_Venda()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_impressao_orcamento FROM pdv_venda_configuracoes WHERE id_pdv_venda_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Nome_Imp_PDV_Venda_NNF()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT nome_imp_nnf FROM pdv_venda_configuracoes WHERE id_pdv_venda_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Nome_Imp_PDV_Venda_Nota_Prom()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT nome_imp_nota_prom FROM pdv_venda_configuracoes WHERE id_pdv_venda_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Tipo_Imp_PDV_Venda_Nota_Prom()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_impressao_nota_prom FROM pdv_venda_configuracoes WHERE id_pdv_venda_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Tipo_Imp_PDV_Venda_Conta_Receber()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT tipo_impressao_conta_receber FROM pdv_venda_configuracoes WHERE id_pdv_venda_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Resolucao_PDV_Venda()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT resolucao FROM pdv_venda_configuracoes WHERE id_pdv_venda_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public string Sel_Mensagem_PDV_Venda()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT mensagem FROM pdv_venda_configuracoes WHERE id_pdv_venda_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Mostrar_Logo_Marca_Imp_PDV_Venda()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT mostrar_logo_marca_imp FROM pdv_venda_configuracoes WHERE id_pdv_venda_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Usar_Axacropdf_Pdv_Venda()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT usar_axacropdf FROM pdv_venda_configuracoes WHERE id_pdv_venda_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        //SUBGRUPO
        public void Salvar_Config_SubGrupo(SubGrupo Sub)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO subgrupo_configuracoes (id_subgrupo_configuracoes, excluir_subgrupo_cascata, margem_esq, margem_topo, margem_esq_imp_mat, margem_topo_imp_mat, margem_esq_pdf_80, margem_topo_pdf_80, usar_axacropdf)VALUES(1, " + Sub.Excluir_SubGrupo_Cascata + ", " + Sub.Margem_Esq + ", " + Sub.Margem_Topo + ", " + Sub.Margem_Esq_Imp_Mat + ", " + Sub.Margem_Topo_Imp_Mat + ", " + Sub.Margem_Esq_Pdf_80 + ", " + Sub.Margem_Topo_Pdf_80 + ", " + Sub.Usar_Axacropdf + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Config_SubGrupo(SubGrupo Sub)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE subgrupo_configuracoes SET excluir_subgrupo_cascata=" + Sub.Excluir_SubGrupo_Cascata + ", margem_esq=" + Sub.Margem_Esq + ", margem_topo=" + Sub.Margem_Topo + ", margem_esq_imp_mat=" + Sub.Margem_Esq_Imp_Mat + ", margem_topo_imp_mat=" + Sub.Margem_Topo_Imp_Mat + ", margem_esq_pdf_80=" + Sub.Margem_Esq_Pdf_80 + ", margem_topo_pdf_80=" + Sub.Margem_Topo_Pdf_80 + ", usar_axacropdf=" + Sub.Usar_Axacropdf + " WHERE id_subgrupo_configuracoes=1;", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Tabela_SubGrupo_Configuracoes()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataAdapter Adapter = new FbDataAdapter("SELECT excluir_subgrupo_cascata, margem_esq, margem_topo, margem_esq_imp_mat, margem_topo_imp_mat, margem_esq_pdf_80, margem_topo_pdf_80, usar_axacropdf FROM subgrupo_configuracoes WHERE id_subgrupo_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtConfig;
            }
        }

        public short Sel_Margem_Esq_Subgrupo()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq FROM subgrupo_configuracoes WHERE id_subgrupo_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Topo_Subgrupo()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_topo FROM subgrupo_configuracoes WHERE id_subgrupo_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public int Sel_Usar_Axacropdf_Subgrupo()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT usar_axacropdf FROM subgrupo_configuracoes WHERE id_subgrupo_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                int valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt32(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Esq_Pdf_80_Subgrupo()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_esq_pdf_80 FROM subgrupo_configuracoes WHERE id_subgrupo_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public short Sel_Margem_Topo_Pdf_80_Subgrupo()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT margem_topo_pdf_80 FROM subgrupo_configuracoes WHERE id_subgrupo_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                short valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetInt16(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        public byte Sel_Excluir_SubGrupo_Cascata()
        {
            Conexao.Open();
            DataTable DtConfig = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT excluir_subgrupo_cascata FROM subgrupo_configuracoes WHERE id_subgrupo_configuracoes=1;", Conexao);
            Adapter.Fill(DtConfig);
            if (DtConfig.Rows.Count == 0)
            {
                Conexao.Close();
                return 0;
            }
            else
            {
                byte valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetByte(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        //ITEM_ORC
        public void Salvar_Itens_Orc_Operation(Item_Orc_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO item_orcamento_temp(id_item_orcamento, id_produto, descricao, valor_unitario, valor_total, quantidade, um, valor_desconto, valor_acrescimo, desconto_porc, acrescimo_porc, valor_total_a_desc_acresc, id_conexao_configuracoes, tabela)VALUES(" + Items.Codigo + ", " + Items.Cod_Item_Orc + ", " + Items.Descricao + ", " + Items.Valor_Unitario + ", " + Items.Valor_Total + ", " + Items.Quantidade + ", " + Items.UM + ", " + Items.Valor_Desconto_Item + ", " + Items.Valor_Acrescimo_Item + ", " + Items.Desconto_Porc + ", " + Items.Acrescimo_Porc + ", " + Items.Valor_Total_A_Desc_Acresc + ", " + Items.Cod_Conexao_Configuracoes + ", " + Items.Tabela + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Cab_Orcamento_Operation(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_consumidor_orc=0, nome_consumidor_orc=null, data_validade=null, hora_validade=null, cpf_cnpj_consumidor_orc=null, observacao_orc=null WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Item_Orc_Todos(Item_Orc_Temp Item)
        {
            Conexao.Open();
            DataTable DtItemOrc = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT id_item_orcamento, id_produto, descricao, quantidade, um, valor_unitario, valor_total, desconto_porc, valor_desconto, acrescimo_porc, valor_acrescimo, valor_total_a_desc_acresc, tabela FROM item_orcamento_temp WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + " ORDER BY id_item_orcamento ASC;", Conexao);
            Adaper.Fill(DtItemOrc);
            if (DtItemOrc.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtItemOrc;
            }
        }

        public DataTable Sel_Cab_Orcamento_Todos(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            DataTable DtItemOrc = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT id_consumidor_orc, nome_consumidor_orc, data_validade, hora_validade, observacao_orc, cpf_cnpj_consumidor_orc FROM dado_pdv_atual WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Adaper.Fill(DtItemOrc);
            if (DtItemOrc.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtItemOrc;
            }
        }

        public void Excluir_Orc_Atual(Item_Orc_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_orcamento_temp WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_Orc(Item_Orc Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_orcamento_temp WHERE id_item_orcamento=" + Items.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Prod(Item_Orc Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_orcamento_temp SET id_item_orcamento=" + Items.Codigo + " WHERE id_item_orcamento=" + cod_atual + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }









        //DEVOLUÇÃO
        public void Salvar_Item_Devolucao(Item_Devolucao_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO item_devolucao_temp(id_item, id_produto, descricao, quantidade, um, valor_unitario, valor_total, valor_desconto, valor_acrescimo, valor_desconto_item, valor_acrescimo_item, valor_total_a_desc_acresc, id_conexao_configuracoes)VALUES(" + Items.Codigo + ", " + Items.Cod_Produto + ", " + Items.Descricao + ", " + Items.Quantidade + ", " + Items.UM + ", " + Items.Valor_Unitario + ", " + Items.Valor_Total + ", " + Items.Valor_Desconto + ", " + Items.Valor_Acrescimo + ", " + Items.Valor_Desconto_Item + ", " + Items.Valor_Acrescimo_Item + ", " + Items.Valor_Total_A_Desc_Acresc + ", " + Items.Cod_Conexoes_Configuracoes + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Item_Dev_Prod(Item_Dev_Prod_Temp Items)
        {
            Conexao.Open();
            //MessageBox.Show("INSERT INTO item_dev_prod_temp(id_item, id_produto, descricao, valor_unitario, valor_total, quantidade, um, valor_desconto_item, valor_acrescimo_item, valor_total_a_desc_acresc)VALUES(" + Items.Codigo + ", " + Items.Cod_Produto + ", " + Items.Descricao + ", " + Items.Valor_Unitario + ", " + Items.Valor_Total + ", " + Items.Quantidade + ", " + Items.UM + ", " + Items.Valor_Desconto_Item + ", " + Items.Valor_Acrescimo_Item + ", " + Items.Valor_Total_A_Desc_Acresc + ");");
            FbCommand Comandos = new FbCommand("INSERT INTO item_dev_prod_temp(id_item, id_produto, descricao, valor_unitario, valor_total, quantidade, um, valor_desconto_item, valor_acrescimo_item, valor_total_a_desc_acresc, id_conexao_configuracoes)VALUES(" + Items.Codigo + ", " + Items.Cod_Produto + ", " + Items.Descricao + ", " + Items.Valor_Unitario + ", " + Items.Valor_Total + ", " + Items.Quantidade + ", " + Items.UM + ", " + Items.Valor_Desconto_Item + ", " + Items.Valor_Acrescimo_Item + ", " + Items.Valor_Total_A_Desc_Acresc + ", " + Items.Cod_Conexao_Configuracoes + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Itens_Devolucao(Item_Devolucao_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_devolucao_temp SET quantidade=" + Item.Quantidade + ", valor_unitario=" + Item.Valor_Unitario + ", valor_total=" + Item.Valor_Total + ", valor_total_a_desc_acresc=" + Item.Valor_Total_A_Desc_Acresc + " WHERE id_item=" + Item.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Todas_Itens_Venda_Dev()
        {
            Conexao.Open();
            DataTable DtDev = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT id_item, id_produto, descricao, quantidade, um, valor_unitario, valor_total, valor_desconto, valor_acrescimo, valor_desconto_item, valor_acrescimo_item, valor_total_a_desc_acresc FROM item_devolucao_temp ORDER BY id_item ASC;", Conexao);
            Adaper.Fill(DtDev);
            if (DtDev.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtDev;
            }
        }

        public void Excluir_Item_Dev_Prod(Item_Devolucao_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_dev_prod_temp WHERE id_item=" + Items.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Todos_Itens_Dev_Prod_Temp()
        {
            Conexao.Open();
            DataTable DtDev = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT id_item, id_produto, descricao, quantidade, um, valor_unitario, valor_total, valor_desconto_item, valor_acrescimo_item, valor_total_a_desc_acresc FROM item_dev_Prod_temp ORDER BY id_item;", Conexao);
            Adaper.Fill(DtDev);
            if (DtDev.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtDev;
            }
        }

        public void Excluir_Devolucao_Atual(Item_Devolucao_Temp Dev)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_devolucao_temp WHERE id_conexao_configuracoes=" + Dev.Cod_Conexoes_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Dev_Prod_Atual(Item_Devolucao_Temp Dev)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_dev_prod_temp WHERE id_conexao_configuracoes=" + Dev.Cod_Conexoes_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }


        public void Atualizar_Item_Dev_Prod(Item_Devolucao_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_dev_prod_temp SET id_item=" + Items.Codigo + " WHERE id_item=" + cod_atual + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        //ITEM_DFE
        public void Salvar_Item_DFe_Temp(Item_DFe_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO item_dfe_temp (id_item, id_produto, descricao, ncm, cst, aliq_icms, csosn, cest, cfop, quantidade, quantidade_embalagem, valor_unitario, total, valor_desconto, valor_acrescimo, valor_total, valor_base_calculo, valor_icms, id_conexao_configuracoes, valor_icms_st, reducao_bc, mva, aliq_icms_st, valor_base_calculo_st, um, total_aprox_trib, valor_ipi, aliq_ipi, reducao_bc_st, cst_ibs_cbs, cclass_trib, aliq_ibs_mun, aliq_ibs_est, aliq_cbs, valor_frete)VALUES(" + Item.Cod_Item + ", " + Item.Cod_Produto + ", " + Item.Descricao + ", " + Item.NCM + ", " + Item.CST + ", " + Item.Aliquota + ", " + Item.CSOSN + ", " + Item.CEST + ", " + Item.CFOP + ", " + Item.Quantidade + ", " + Item.Quantidade_Embalagem + ", " + Item.Valor_Unitario + ", " + Item.Total + ", " + Item.Valor_Desconto + ", " + Item.Valor_Acrescimo + ", " + Item.Valor_Total + ", " + Item.Valor_Base_Calculo + ", " + Item.Valor_Icms + ", " + Item.Cod_Conexao_Configuracoes + ", " + Item.Valor_Icms_St + ", " + Item.Reducao_BC + ", " + Item.MVA + ", " + Item.Aliquota_ST + ", " + Item.Valor_Base_Calculo_St + ", " + Item.UM + ", " + Item.Total_Aprox_Trib + ", " + Item.Valor_IPI + ", " + Item.Aliquota_IPI + ", " + Item.Reducao_BC_ST + ", " + Item.CST_IBS_CBS + ", " + Item.CClass_Trib + ", " + Item.Aliq_IBS_Mun + ", " + Item.Aliq_IBS_Est + ", " + Item.Aliq_CBS + ", " + Item.Valor_Frete + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Item_DFe_Temp(Item_DFe_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_dfe_temp SET id_produto=" + Item.Cod_Produto + ", descricao=" + Item.Descricao + ", ncm=" + Item.NCM + ", cst=" + Item.CST + ", aliq_icms=" + Item.Aliquota + ", csosn=" + Item.CSOSN + ", cest=" + Item.CEST + ", cfop=" + Item.CFOP + ", quantidade=" + Item.Quantidade + ", quantidade_embalagem=" + Item.Quantidade_Embalagem + ", valor_unitario=" + Item.Valor_Unitario + ", total=" + Item.Total + ", valor_desconto=" + Item.Valor_Desconto + ", valor_acrescimo=" + Item.Valor_Acrescimo + ", valor_total=" + Item.Valor_Total + ", valor_base_calculo=" + Item.Valor_Base_Calculo + ", valor_icms=" + Item.Valor_Icms + ", valor_icms_st=" + Item.Valor_Icms_St + ", reducao_bc=" + Item.Reducao_BC + ", mva=" + Item.MVA + ", aliq_icms_st=" + Item.Aliquota_ST + ", valor_base_calculo_st=" + Item.Valor_Base_Calculo_St + ", um=" + Item.UM + ", total_aprox_trib=" + Item.Total_Aprox_Trib + ", valor_ipi=" + Item.Valor_IPI + ", aliq_ipi=" + Item.Aliquota_IPI + ", reducao_bc_st=" + Item.Reducao_BC_ST + ", cst_ibs_cbs=" + Item.CST_IBS_CBS + ", cclass_trib=" + Item.CClass_Trib + ", aliq_ibs_mun=" + Item.Aliq_IBS_Mun + ", aliq_ibs_est=" + Item.Aliq_IBS_Est + ", aliq_cbs=" + Item.Aliq_CBS + ", valor_frete=" + Item.Valor_Frete + " WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + " AND id_item=" + Item.Cod_Item + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Item_Temp(Item_DFe_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_dfe_temp SET id_item=" + Items.Codigo + " WHERE id_item=" + cod_atual + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataTable Sel_Dados_DFe_Temp(Item_DFe_Temp Item)
        {
            Conexao.Open();
            DataTable DtDFe = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT modelo, observacao, data_saida, hora_saida, tipo_emitente_destinatario, id_emitente_destinatario, nome_emitente_destinatario, finalidade, cod_cfop, descricao_cfop, consumidor_final, tipo_operacao, cpf_cnpj_emitente_destinatario, id_dfe FROM dfe_temp WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + ";", Conexao);
            Adaper.Fill(DtDFe);
            if (DtDFe.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtDFe;
            }
        }

        public DataTable Sel_Items_DFe_Temp(Item_DFe_Temp Item)
        {
            Conexao.Open();
            DataTable DtDFe = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT id_item, id_produto, descricao, um, quantidade, quantidade_embalagem, valor_unitario, total, valor_desconto, valor_acrescimo, cst, aliq_icms, valor_icms, valor_base_calculo, valor_total, csosn, cfop, ncm, cest, id_conexao_configuracoes, aliq_icms_st, valor_base_calculo_st, mva, reducao_bc, valor_icms_st, total_aprox_trib, aliq_ipi, valor_ipi, reducao_bc_st, cst_ibs_cbs, cclass_trib, aliq_ibs_mun, aliq_ibs_est, aliq_cbs, valor_frete FROM item_dfe_temp WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + " ORDER BY id_item ASC;", Conexao);
            Adaper.Fill(DtDFe);
            if (DtDFe.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtDFe;
            }
        }

        public void Excluir_Item_DFe_Temp(Item_DFe_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_dfe_temp WHERE id_item=" + Item.Codigo + " AND id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Todos_Item_DFe_Temp(Item_DFe_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_dfe_temp WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Todos_Referencia_Temp(ReferenciaDFe_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM referencia_dfe_temp WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Todos_Transportador_Temp(ReferenciaDFe_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM transportador_temp WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_DFe_Temp(DFE_Temp NFe)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO dfe_temp (finalidade, modelo, data_saida, hora_saida, id_emitente_destinatario, nome_emitente_destinatario, observacao, cod_cfop, descricao_cfop, tipo_emitente_destinatario, id_conexao_configuracoes, consumidor_final, tipo_operacao, cpf_cnpj_emitente_destinatario, id_dfe)VALUES(" + NFe.Finalidade + ", " + NFe.Modelo + ", " + NFe.Data_Saida + ", " + NFe.Hora_Saida + ", " + NFe.Cod_Emitente_Destinatario + ", " + NFe.Nome_Emitente_Destinatario + ", " + NFe.Observacao + ", " + NFe.Cod_CFOP + ", " + NFe.Descricao_CFOP + ", " + NFe.Tipo_Emitente_Destinatario + ", " + NFe.Cod_Conexao_Configuracoes + ", " + NFe.Consumidor_Final + ", " + NFe.Tipo_Operacao + ", " + NFe.CPF_CNPJ_Emitente_Destinatario + ", " + NFe.Cod_DFe + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_DFe_Temp(DFE_Temp NFe)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dfe_temp SET finalidade=" + NFe.Finalidade + ", modelo=" + NFe.Modelo + ", data_saida=" + NFe.Data_Saida + ", hora_saida=" + NFe.Hora_Saida + ", id_emitente_destinatario=" + NFe.Cod_Emitente_Destinatario + ", nome_emitente_destinatario=" + NFe.Nome_Emitente_Destinatario + ", observacao=" + NFe.Observacao + ", cod_cfop=" + NFe.Cod_CFOP + ", descricao_cfop=" + NFe.Descricao_CFOP + ", tipo_emitente_destinatario=" + NFe.Tipo_Emitente_Destinatario + ", consumidor_final=" + NFe.Consumidor_Final + ", tipo_operacao=" + NFe.Tipo_Operacao + ", cpf_cnpj_emitente_destinatario=" + NFe.CPF_CNPJ_Emitente_Destinatario + ", id_dfe=" + NFe.Cod_DFe + " WHERE id_conexao_configuracoes=" + NFe.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_DFe_Temp(DFE_Temp NFe)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM dfe_temp WHERE id_conexao_configuracoes=" + NFe.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        //ITEM_PDV
        public void Salvar_Item_PDV(Item_PDV_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO item_pdv_temp(id_item, id_produto, descricao, valor_unitario, valor_total, quantidade, um, valor_desconto, valor_acrescimo, valor_total_a_desc_acresc, id_tabela, id_conexao_configuracoes, tipo)VALUES(" + Items.Codigo + ", " + Items.Cod_Produto + ", " + Items.Descricao + ", " + Items.Valor_Unitario + ", " + Items.Valor_Total + ", " + Items.Quantidade + ", " + Items.UM + ", " + Items.Valor_Desconto + ", " + Items.Valor_Acrescimo + ", " + Items.Valor_Total_A_Desc_Acresc + ", " + Items.Cod_Tabela + ", " + Items.Cod_Conexao_Configuracoes + ", " + Items.Tipo + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Item_PDV(Item_PDV_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_pdv_temp WHERE id_item=" + Items.Codigo + " AND id_tabela=" + Items.Cod_Tabela + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Venda_Atual_PDV(Item_PDV_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_pdv_temp WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Venda_Atual_PDV_Tabela(Item_PDV_Temp Item)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM item_pdv_temp WHERE id_tabela=" + Item.Cod_Tabela + " AND id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Consumidor_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_consumidor_pdv=0, nome_consumidor_pdv=null, cpf_cnpj_consumidor_pdv=null WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Consumidor_PDV_Tabela_2(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_consumidor_pdv_2=0, nome_consumidor_pdv_2=null, cpf_cnpj_consumidor_pdv_2=null WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Devolucao_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_devolucao=0 WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Orcamento_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_orcamento=0 WHERE id_dado_pdv=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Orcamento_Orc_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_orcamento_orc=0 WHERE id_dado_pdv=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Quantidade_Item(Item_PDV_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_pdv_temp SET quantidade=" + Items.Quantidade + ", valor_total=" + Items.Valor_Total + ", valor_acrescimo=" + Items.Valor_Acrescimo + ", valor_desconto=" + Items.Valor_Desconto + ", valor_total_a_desc_acresc=" + Items.Valor_Total_A_Desc_Acresc + " WHERE id_item=" + Items.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Unitario_Item(Item_PDV_Temp Items)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_pdv_temp SET valor_unitario=" + Items.Valor_Unitario + ", valor_total=" + Items.Valor_Total + ", valor_acrescimo=" + Items.Valor_Acrescimo + ", valor_desconto=" + Items.Valor_Desconto + ", valor_total_a_desc_acresc=" + Items.Valor_Total_A_Desc_Acresc + " WHERE id_item=" + Items.Codigo + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar_Item_Dt_Item(Item_PDV_Temp Items, string cod_atual)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE item_pdv_temp SET id_item=" + Items.Codigo + " WHERE id_item=" + cod_atual + " AND id_tabela=" + Items.Cod_Tabela + " AND id_conexao_configuracoes=" + Items.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }


        public DataTable Sel_Item_PDV_Todos(Item_PDV_Temp Item)
        {
            Conexao.Open();
            DataTable DtItem = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT id_item, id_produto, descricao, quantidade, um, valor_unitario, valor_total, valor_desconto, valor_acrescimo, valor_total_a_desc_acresc FROM item_pdv_temp WHERE id_tabela=" + Item.Cod_Tabela + " AND id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + " ORDER BY id_item;", Conexao);
            Adaper.Fill(DtItem);
            if (DtItem.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtItem;
            }
        }

        public DataTable Sel_Dados_Atuais_PDV(Item_PDV_Temp Item)
        {
            Conexao.Open();
            DataTable DtPDV = new DataTable();
            FbDataAdapter Adaper = new FbDataAdapter("SELECT id_consumidor_orc, nome_consumidor_orc, data_validade, hora_validade, observacao_orc, id_consumidor_pdv, nome_consumidor_pdv, cpf_cnpj_consumidor_pdv, id_devolucao, id_orcamento, valor_desconto_devolucao, id_orcamento_orc FROM dado_pdv_atual WHERE id_conexao_configuracoes=" + Item.Cod_Conexao_Configuracoes + ";", Conexao);
            Adaper.Fill(DtPDV);
            if (DtPDV.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                Conexao.Close();
                return DtPDV;
            }
        }

        public void Alterar_Consumidor_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_consumidor_pdv=" + Dado.Cod_Consumidor_PDV + ", nome_consumidor_pdv=" + Dado.Nome_Consumidor_PDV + ", cpf_cnpj_consumidor_pdv=" + Dado.CPF_CNPJ_Consumidor_PDV + " WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Dados_Orcamento_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_consumidor_Orc=" + Dado.Cod_Consumidor_Orc + ", nome_consumidor_orc=" + Dado.Nome_Consumidor_Orc + ", cpf_cnpj_consumidor_orc=" + Dado.CPF_CNPJ_Consumidor_Orc + ", data_validade=" + Dado.Data_Validade + ", hora_validade=" + Dado.Horario_Validade + ", observacao_orc=" + Dado.Observacao_Orc + " WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Consumidor_PDV_Tabela_2(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_consumidor_pdv_2=" + Dado.Cod_Consumidor_PDV_2 + ", nome_consumidor_pdv_2=" + Dado.Nome_Consumidor_PDV_2 + ", cpf_cnpj_consumidor_pdv_2=" + Dado.CPF_CNPJ_Consumidor_PDV_2 + " WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Devolucao_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_devolucao=" + Dado.Cod_Devolucao + ", valor_desconto_devolucao=" + Dado.Valor_Desconto_Devolucao + " WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        

        public void Alterar_Orcamento_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_orcamento=" + Dado.Cod_Orcamento + " WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Venda_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_venda=" + Dado.Cod_Venda + " WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Orcamento_Orc_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE dado_pdv_atual SET id_orcamento_orc=" + Dado.Cod_Orcamento_Orc + " WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Excluir_Dados_Atuais_PDV(Dado_PDV_Atual Dado)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("DELETE FROM dado_pdv_atual WHERE id_conexao_configuracoes=" + Dado.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Salvar_Dados_Atuais_PDV(Conexao Cone)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO dado_pdv_atual(id_dado_pdv, id_consumidor_orc, id_consumidor_pdv, id_devolucao, id_orcamento, id_consumidor_pdv_2, valor_desconto_devolucao, id_conexao_configuracoes, id_orcamento_orc, id_venda)VALUES(1, 0, 0, 0, 0, 0, 0, " + Cone.Codigo + ", 0, 0);", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        //SMS
        public void Salvar_Config_SMS(SMS Sms)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("INSERT INTO sms_configuracoes (porta, id_conexao_configuracoes)values(" + Sms.Porta + ", " + Sms.Cod_Conexao_Configuracoes + ");", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Alterar_Config_SMS(SMS Sms)
        {
            Conexao.Open();
            FbCommand Comandos = new FbCommand("UPDATE sms_configuracoes SET porta=" + Sms.Porta + " WHERE id_conexao_configuracoes=" + Sms.Cod_Conexao_Configuracoes + ";", Conexao);
            Comandos.ExecuteNonQuery();
            Conexao.Close();
        }

        public string Sel_Porta_SMS(SMS Sms)
        {
            Conexao.Open();
            DataTable DtPDV = new DataTable();
            FbDataReader dr;
            FbDataAdapter Adapter = new FbDataAdapter("SELECT porta FROM sms_configuracoes WHERE id_conexao_configuracoes=" + Sms.Cod_Conexao_Configuracoes + ";", Conexao);
            Adapter.Fill(DtPDV);
            if (DtPDV.Rows.Count == 0)
            {
                Conexao.Close();
                return null;
            }
            else
            {
                string valor;
                dr = Adapter.SelectCommand.ExecuteReader();
                dr.Read();
                valor = dr.GetString(0);
                dr.Close();
                Conexao.Close();
                return valor;
            }
        }

        bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Conexao = null;
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            Conexao = null;
            GC.SuppressFinalize(this);
        }

        ~ConOperationBD()
        {
            Dispose(false);
        }





    }
}
