using DAL;
using System;
using System.Data;

namespace BLL
{
    public class bllConfiguracaoSistema
    {
        public static string _Url_Imagem_Comp;

        public static DataTable Sel_Tabela_Configuracao_Local_Configuracoes(string cod_conexao)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao);
                    //
                    return con.Sel_Tabela_Configuracao_Local_Configuracoes(Config);
                }
            }
        }

        public static DataTable Sel_Tabela_Configuracao_Global_Configuracoes()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Tabela_Configuracao_Global_Configuracoes();
            }
        }

        public static void Excluir_Configuracao_Local(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Local(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Dado_PDV_Atual(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Dado_PDV_Atual(Config);
                }
            }
        }

        public static void Excluir_Configuracao_DFE_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_DFE_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Conta_Pagar_Pgto_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Conta_Pagar_Pgto_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Conta_Receber_Pgto_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Conta_Receber_Pgto_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Devolucao_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Devolucao_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Dev_Prod_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Dev_Prod_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Dfe_Pgto_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Dfe_Pgto_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Dfe_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Dfe_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Orcamento_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Orcamento_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Os_Funcionario_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Os_Funcionario_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Os_Pgto_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Os_Pgto_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Os_Produto_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Os_Produto_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Parcelamento_Dfe(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Parcelamento_Dfe(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_PDV_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_PDV_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Item_Servico_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Item_Servico_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_SMS_Configuracoes(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_SMS_Configuracoes(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Transportador_Temp(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Transportador_Temp(Config);
                }
            }
        }

        public static void Excluir_Configuracao_Layout_PDV(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(codigo);
                    //
                    con.Excluir_Configuracao_Layout_PDV(Config);
                }
            }
        }

        public static string Sel_Imagem_Fundo_7_Adm(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Imagem_Fundo_7_Adm(Config);
                }
            }
        }

        public static string Sel_Ajuste_Imagem_7_Adm(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Ajuste_Imagem_7_Adm(Config);
                }
            }
        }

        public static bool Sel_Ver_Data_Hora_Internet(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    if (con.Sel_Ver_Data_Hora_Internet(Config) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool Sel_Ativar_Letreiro(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    if (con.Sel_Ativar_Letreiro(Config) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static short Sel_Margem_Esq_NFCe(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Margem_Esq_NFCe(Config);
                }
            }
        }

        public static short Sel_Margem_Dir_NFCe(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Margem_Dir_NFCe(Config);
                }
            }
        }

        public static short Sel_Margem_Esq_Pdv_PDF(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Margem_Esq_Pdv_PDF(Config);
                }
            }
        }

        public static short Sel_Margem_Topo_Pdv_PDF(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Margem_Topo_Pdv_PDF(Config);
                }
            }
        }

        public static short Sel_Margem_Esq_80_Pdv(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Margem_Esq_80_Pdv(Config);
                }
            }
        }

        public static short Sel_Margem_Topo_80_Pdv(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Margem_Topo_80_Pdv(Config);
                }
            }
        }

        public static short Sel_Margem_Esq_A4_Pdv(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Margem_Esq_A4_Pdv(Config);
                }
            }
        }

        public static string Sel_Resolucao_Pdv(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Resolucao_Pdv(Config);
                }
            }
        }

        public static string Sel_Mensagem_Pdv(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Mensagem_Pdv(Config);
                }
            }
        }

        public static bool Sel_Mostrar_Inf_Usuario(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    if (con.Sel_Mostrar_Inf_Usuario(Config) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static short Sel_Margem_Topo_A4_Pdv(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Margem_Topo_A4_Pdv(Config);
                }
            }
        }

        public static void Alterar_Data_Ult_Backup()
        {
            using (Con7BD con = new Con7BD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Data_Ult_Backup = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    con.Alterar_Data_Ult_Backup(Config);
                }
            }
        }

        public static void Alterar_Local(string margem_esq, string margem_topo, string margem_esq_pdv, string margem_topo_pdv, string margem_esq_80_pdv, string margem_topo_80_pdv, string margem_esq_a4_pdv, string margem_topo_a4_pdv, bool usar_axacropdf, string resolucao, string imagem_fundo_7_adm, string ajuste_imagem_7_adm, bool ver_data_hora_internet, bool ativar_letreiro, bool usar_axacropdf_pdv, string mensagem, bool mostrar_desc_acresc_venda, string tipo_imp_nnf, string tipo_imp_nota_prom, string tipo_imp_orc, string tipo_imp_dev, string tipo_imp_conta_receber, string nome_imp_nnf, string nome_imp_nota_prom, string nome_imp_orc, string nome_imp_dev, string nome_imp_conta_receber, string cod_conexao, bool mostrar_inf_usuario, string margem_esq_nfce, string margem_dir_nfce, bool buscar_atualizacao)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Margem_Esq = Convert.ToInt16(margem_esq);
                    //                    
                    Config.Margem_Topo = Convert.ToInt16(margem_topo);
                    //
                    Config.Margem_Esq_pdv = Convert.ToInt16(margem_esq_pdv);
                    //                    
                    Config.Margem_Topo_pdv = Convert.ToInt16(margem_topo_pdv);
                    //
                    Config.Margem_Esq_80_pdv = Convert.ToInt16(margem_esq_80_pdv);
                    //                    
                    Config.Margem_Topo_80_pdv = Convert.ToInt16(margem_topo_80_pdv);
                    //
                    Config.Margem_Esq_A4_pdv = Convert.ToInt16(margem_esq_a4_pdv);
                    //                    
                    Config.Margem_Topo_A4_pdv = Convert.ToInt16(margem_topo_a4_pdv);
                    //
                    if (usar_axacropdf == true)
                    {
                        Config.Usar_Axacropdf = 1;
                    }
                    else
                    {
                        Config.Usar_Axacropdf = 0;
                    }
                    //
                    if (usar_axacropdf_pdv == true)
                    {
                        Config.Usar_Axacropdf_PDV = 1;
                    }
                    else
                    {
                        Config.Usar_Axacropdf_PDV = 0;
                    }
                    //
                    Config.Resolucao = resolucao.Insert(resolucao.Length, "'").Insert(0, "'");
                    //
                    if (ajuste_imagem_7_adm == "")
                    {
                        Config.Ajuste_Imagem_7_ADM = "null";
                    }
                    else
                    {
                        Config.Ajuste_Imagem_7_ADM = ajuste_imagem_7_adm.Insert(ajuste_imagem_7_adm.Length, "'").Insert(0, "'");
                    }
                    //
                    if (mensagem == "")
                    {
                        Config.Mensagem = "null";
                    }
                    else
                    {
                        Config.Mensagem = mensagem.Insert(mensagem.Length, "'").Insert(0, "'");
                    }
                    //
                    if (imagem_fundo_7_adm == "" || imagem_fundo_7_adm == null)
                    {
                        Config.Imagem_Fundo_7_ADM = "null";
                    }
                    else
                    {
                        Config.Imagem_Fundo_7_ADM = imagem_fundo_7_adm.Insert(imagem_fundo_7_adm.Length, "'").Insert(0, "'");
                    }
                    //
                    if (ver_data_hora_internet == true)
                    {
                        Config.Ver_Data_Hora_Internet = 1;
                    }
                    else
                    {
                        Config.Ver_Data_Hora_Internet = 0;
                    }
                    //
                    if (ativar_letreiro == true)
                    {
                        Config.Ativar_Letreiro = 1;
                    }
                    else
                    {
                        Config.Ativar_Letreiro = 0;
                    }
                    //
                    if (mostrar_desc_acresc_venda == true)
                    {
                        Config.Mostrar_Desc_Acresc = 1;
                    }
                    else
                    {
                        Config.Mostrar_Desc_Acresc = 0;
                    }
                    //
                    if (tipo_imp_nnf == "" || tipo_imp_nnf == null)
                    {
                        Config.Tipo_Impressao_NNF = "null";
                    }
                    else
                    {
                        Config.Tipo_Impressao_NNF = tipo_imp_nnf.Insert(tipo_imp_nnf.Length, "'").Insert(0, "'");
                    }
                    //
                    if (tipo_imp_nota_prom == "" || tipo_imp_nota_prom == null)
                    {
                        Config.Tipo_Impressao_Nota_Prom = "null";
                    }
                    else
                    {
                        Config.Tipo_Impressao_Nota_Prom = tipo_imp_nota_prom.Insert(tipo_imp_nota_prom.Length, "'").Insert(0, "'");
                    }
                    //
                    if (tipo_imp_orc == "" || tipo_imp_orc == null)
                    {
                        Config.Tipo_Impressao_Orcamento = "null";
                    }
                    else
                    {
                        Config.Tipo_Impressao_Orcamento = tipo_imp_orc.Insert(tipo_imp_orc.Length, "'").Insert(0, "'");
                    }
                    //
                    if (tipo_imp_dev == "" || tipo_imp_dev == null)
                    {
                        Config.Tipo_Impressao_Devolucao = "null";
                    }
                    else
                    {
                        Config.Tipo_Impressao_Devolucao = tipo_imp_dev.Insert(tipo_imp_dev.Length, "'").Insert(0, "'");
                    }
                    //
                    if (tipo_imp_conta_receber == "" || tipo_imp_conta_receber == null)
                    {
                        Config.Tipo_Impressao_Conta_Receber = "null";
                    }
                    else
                    {
                        Config.Tipo_Impressao_Conta_Receber = tipo_imp_conta_receber.Insert(tipo_imp_conta_receber.Length, "'").Insert(0, "'");
                    }
                    //
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao);
                    //
                    if (nome_imp_nnf == "" || nome_imp_nnf == null)
                    {
                        Config.Nome_Imp_NNF = "null";
                    }
                    else
                    {
                        Config.Nome_Imp_NNF = nome_imp_nnf.Insert(nome_imp_nnf.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_imp_nota_prom == "" || nome_imp_nota_prom == null)
                    {
                        Config.Nome_Imp_Nota_Prom = "null";
                    }
                    else
                    {
                        Config.Nome_Imp_Nota_Prom = nome_imp_nota_prom.Insert(nome_imp_nota_prom.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_imp_orc == "" || nome_imp_orc == null)
                    {
                        Config.Nome_Imp_Orcamento = "null";
                    }
                    else
                    {
                        Config.Nome_Imp_Orcamento = nome_imp_orc.Insert(nome_imp_orc.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_imp_dev == "" || nome_imp_dev == null)
                    {
                        Config.Nome_Imp_Devolucao = "null";
                    }
                    else
                    {
                        Config.Nome_Imp_Devolucao = nome_imp_dev.Insert(nome_imp_dev.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_imp_conta_receber == "" || nome_imp_conta_receber == null)
                    {
                        Config.Nome_Imp_Conta_Receber = "null";
                    }
                    else
                    {
                        Config.Nome_Imp_Conta_Receber = nome_imp_conta_receber.Insert(nome_imp_conta_receber.Length, "'").Insert(0, "'");
                    }
                    //
                    if (mostrar_inf_usuario == true)
                    {
                        Config.Mostrar_Inf_Usuario = 1;
                    }
                    else
                    {
                        Config.Mostrar_Inf_Usuario = 0;
                    }
                    //
                    Config.Margem_Esq_NFCe = Convert.ToInt16(margem_esq_nfce);
                    //                    
                    Config.Margem_Dir_NFCe = Convert.ToInt16(margem_dir_nfce);
                    //
                    if (buscar_atualizacao == true)
                    {
                        Config.Buscar_Atualizacao = 1;
                    }
                    else
                    {
                        Config.Buscar_Atualizacao = 0;
                    }
                    //
                    con.Alterar_Configuracao_Local(Config);
                }
            }
        }

        public static void Salvar_Local(string margem_esq, string margem_topo, string margem_esq_pdv, string margem_topo_pdv, string margem_esq_80_pdv, string margem_topo_80_pdv, string margem_esq_a4_pdv, string margem_topo_a4_pdv, bool usar_axacropdf, string resolucao, string imagem_fundo_7_adm, string ajuste_imagem_7_adm, bool ver_data_hora_internet, bool ativar_letreiro, bool usar_axacropdf_pdv, string mensagem, bool mostrar_desc_acresc_venda, string tipo_imp_nnf, string tipo_imp_nota_prom, string tipo_imp_orc, string tipo_imp_dev, string tipo_imp_conta_receber, string nome_imp_nnf, string nome_imp_nota_prom, string nome_imp_orc, string nome_imp_dev, string nome_imp_conta_receber, string cod_conexao, bool mostrar_inf_usuario, string margem_esq_nfce, string margem_dir_nfce, string tipo, bool buscar_atualizacao)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    Config.Margem_Esq = Convert.ToInt16(margem_esq);
                    //                    
                    Config.Margem_Topo = Convert.ToInt16(margem_topo);
                    //
                    Config.Margem_Esq_pdv = Convert.ToInt16(margem_esq_pdv);
                    //                    
                    Config.Margem_Topo_pdv = Convert.ToInt16(margem_topo_pdv);
                    //
                    Config.Margem_Esq_80_pdv = Convert.ToInt16(margem_esq_80_pdv);
                    //                    
                    Config.Margem_Topo_80_pdv = Convert.ToInt16(margem_topo_80_pdv);
                    //
                    Config.Margem_Esq_A4_pdv = Convert.ToInt16(margem_esq_a4_pdv);
                    //                    
                    Config.Margem_Topo_A4_pdv = Convert.ToInt16(margem_topo_a4_pdv);
                    //
                    if (usar_axacropdf == true)
                    {
                        Config.Usar_Axacropdf = 1;
                    }
                    else
                    {
                        Config.Usar_Axacropdf = 0;
                    }
                    //
                    if (usar_axacropdf_pdv == true)
                    {
                        Config.Usar_Axacropdf_PDV = 1;
                    }
                    else
                    {
                        Config.Usar_Axacropdf_PDV = 0;
                    }
                    //
                    Config.Resolucao = resolucao.Insert(resolucao.Length, "'").Insert(0, "'");
                    //
                    if (ajuste_imagem_7_adm == "")
                    {
                        Config.Ajuste_Imagem_7_ADM = "null";
                    }
                    else
                    {
                        Config.Ajuste_Imagem_7_ADM = ajuste_imagem_7_adm.Insert(ajuste_imagem_7_adm.Length, "'").Insert(0, "'");
                    }
                    //
                    if (mensagem == "")
                    {
                        Config.Mensagem = "null";
                    }
                    else
                    {
                        Config.Mensagem = mensagem.Insert(mensagem.Length, "'").Insert(0, "'");
                    }
                    //
                    if (imagem_fundo_7_adm == "" || imagem_fundo_7_adm == null)
                    {
                        Config.Imagem_Fundo_7_ADM = "null";
                    }
                    else
                    {
                        Config.Imagem_Fundo_7_ADM = imagem_fundo_7_adm.Insert(imagem_fundo_7_adm.Length, "'").Insert(0, "'");
                    }
                    //
                    if (ver_data_hora_internet == true)
                    {
                        Config.Ver_Data_Hora_Internet = 1;
                    }
                    else
                    {
                        Config.Ver_Data_Hora_Internet = 0;
                    }
                    //
                    if (ativar_letreiro == true)
                    {
                        Config.Ativar_Letreiro = 1;
                    }
                    else
                    {
                        Config.Ativar_Letreiro = 0;
                    }
                    //
                    if (mostrar_desc_acresc_venda == true)
                    {
                        Config.Mostrar_Desc_Acresc = 1;
                    }
                    else
                    {
                        Config.Mostrar_Desc_Acresc = 0;
                    }
                    //
                    if (tipo_imp_nnf == "" || tipo_imp_nnf == null)
                    {
                        Config.Tipo_Impressao_NNF = "null";
                    }
                    else
                    {
                        Config.Tipo_Impressao_NNF = tipo_imp_nnf.Insert(tipo_imp_nnf.Length, "'").Insert(0, "'");
                    }
                    //
                    if (tipo_imp_nota_prom == "" || tipo_imp_nota_prom == null)
                    {
                        Config.Tipo_Impressao_Nota_Prom = "null";
                    }
                    else
                    {
                        Config.Tipo_Impressao_Nota_Prom = tipo_imp_nota_prom.Insert(tipo_imp_nota_prom.Length, "'").Insert(0, "'");
                    }
                    //
                    if (tipo_imp_orc == "" || tipo_imp_orc == null)
                    {
                        Config.Tipo_Impressao_Orcamento = "null";
                    }
                    else
                    {
                        Config.Tipo_Impressao_Orcamento = tipo_imp_orc.Insert(tipo_imp_orc.Length, "'").Insert(0, "'");
                    }
                    //
                    if (tipo_imp_dev == "" || tipo_imp_dev == null)
                    {
                        Config.Tipo_Impressao_Devolucao = "null";
                    }
                    else
                    {
                        Config.Tipo_Impressao_Devolucao = tipo_imp_dev.Insert(tipo_imp_dev.Length, "'").Insert(0, "'");
                    }
                    //
                    if (tipo_imp_conta_receber == "" || tipo_imp_conta_receber == null)
                    {
                        Config.Tipo_Impressao_Conta_Receber = "null";
                    }
                    else
                    {
                        Config.Tipo_Impressao_Conta_Receber = tipo_imp_conta_receber.Insert(tipo_imp_conta_receber.Length, "'").Insert(0, "'");
                    }
                    //
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao);
                    //
                    if (nome_imp_nnf == "" || nome_imp_nnf == null)
                    {
                        Config.Nome_Imp_NNF = "null";
                    }
                    else
                    {
                        Config.Nome_Imp_NNF = nome_imp_nnf.Insert(nome_imp_nnf.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_imp_nota_prom == "" || nome_imp_nota_prom == null)
                    {
                        Config.Nome_Imp_Nota_Prom = "null";
                    }
                    else
                    {
                        Config.Nome_Imp_Nota_Prom = nome_imp_nota_prom.Insert(nome_imp_nota_prom.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_imp_orc == "" || nome_imp_orc == null)
                    {
                        Config.Nome_Imp_Orcamento = "null";
                    }
                    else
                    {
                        Config.Nome_Imp_Orcamento = nome_imp_orc.Insert(nome_imp_orc.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_imp_dev == "" || nome_imp_dev == null)
                    {
                        Config.Nome_Imp_Devolucao = "null";
                    }
                    else
                    {
                        Config.Nome_Imp_Devolucao = nome_imp_dev.Insert(nome_imp_dev.Length, "'").Insert(0, "'");
                    }
                    //
                    if (nome_imp_conta_receber == "" || nome_imp_conta_receber == null)
                    {
                        Config.Nome_Imp_Conta_Receber = "null";
                    }
                    else
                    {
                        Config.Nome_Imp_Conta_Receber = nome_imp_conta_receber.Insert(nome_imp_conta_receber.Length, "'").Insert(0, "'");
                    }
                    //
                    if (mostrar_inf_usuario == true)
                    {
                        Config.Mostrar_Inf_Usuario = 1;
                    }
                    else
                    {
                        Config.Mostrar_Inf_Usuario = 0;
                    }
                    //
                    Config.Margem_Esq_NFCe = Convert.ToInt16(margem_esq_nfce);
                    //                    
                    Config.Margem_Dir_NFCe = Convert.ToInt16(margem_dir_nfce);
                    //
                    if (buscar_atualizacao == true)
                    {
                        Config.Buscar_Atualizacao = 1;
                    }
                    else
                    {
                        Config.Buscar_Atualizacao = 0;
                    }
                    //
                    con.Salvar_Configuracao_Local(Config);
                }
            }
        }

        public static void Alterar_Tipo_Documento_PDV(string tipo, string cod_conexao)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    Config.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao);
                    //
                    con.Alterar_Tipo_Documento_PDV(Config);
                }
            }
        }

        public static void Alterar_Global(bool abert_fech_caixa, bool alertar_estoque, bool destacar_est_vaixo, bool alertar_observacao, bool mostrar_ass_cons, bool cont_usuario_vendas, bool alterar_codigos_id, string porta_email, bool contingencia_nfce)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    if (abert_fech_caixa == true)
                    {
                        Config.Abert_Fech_Caixa = 1;
                    }
                    else
                    {
                        Config.Abert_Fech_Caixa = 0;
                    }
                    //
                    if (alertar_estoque == true)
                    {
                        Config.Alertar_Estoque = 1;
                    }
                    else
                    {
                        Config.Alertar_Estoque = 0;
                    }
                    //
                    if (destacar_est_vaixo == true)
                    {
                        Config.Dest_Est_Baixo = 1;
                    }
                    else
                    {
                        Config.Dest_Est_Baixo = 0;
                    }
                    //
                    if (alertar_estoque == true)
                    {
                        Config.Alertar_Estoque = 1;
                        con.Alterar_Alertar_Estoque_Baixo_Todos(Config);
                    }
                    else
                    {
                        Config.Alertar_Estoque = 0;
                        con.Alterar_Alertar_Estoque_Baixo_Todos(Config);
                    }
                    //
                    if (destacar_est_vaixo == true)
                    {
                        Config.Dest_Est_Baixo = 1;
                        con.Alterar_Destacar_Est_Baixo_Todos(Config);
                    }
                    else
                    {
                        Config.Dest_Est_Baixo = 0;
                        con.Alterar_Destacar_Est_Baixo_Todos(Config);
                    }
                    //
                    if (alertar_observacao == true)
                    {
                        Config.Alertar_Observacao = 1;
                    }
                    else
                    {
                        Config.Alertar_Observacao = 0;
                    }
                    //
                    if (mostrar_ass_cons == true)
                    {
                        Config.Mostrar_Ass_Cons = 1;
                    }
                    else
                    {
                        Config.Mostrar_Ass_Cons = 0;
                    }
                    //
                    if (cont_usuario_vendas == true)
                    {
                        Config.Cont_Usuario_Vendas = 1;
                    }
                    else
                    {
                        Config.Cont_Usuario_Vendas = 0;
                    }
                    //
                    if (contingencia_nfce == true)
                    {
                        Config.Contingencia_NFCe = 1;
                    }
                    else
                    {
                        Config.Contingencia_NFCe = 0;
                    }
                    //
                    Config.Porta_Email = porta_email.Insert(porta_email.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Configuracoes_Globais(Config);
                }
            }
        }

        public static void Salvar_Global(bool abert_fech_caixa, bool alertar_estoque, bool destacar_est_vaixo, bool alertar_observacao, bool mostrar_ass_cons, bool cont_usuario_vendas, bool alterar_codigos_id, string porta_email, bool contingencia_nfce)
        {
            using (Con7BD con = new Con7BD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    if (abert_fech_caixa == true)
                    {
                        Config.Abert_Fech_Caixa = 1;
                    }
                    else
                    {
                        Config.Abert_Fech_Caixa = 0;
                    }
                    //
                    if (alertar_estoque == true)
                    {
                        Config.Alertar_Estoque = 1;
                    }
                    else
                    {
                        Config.Alertar_Estoque = 0;
                    }
                    //
                    if (destacar_est_vaixo == true)
                    {
                        Config.Dest_Est_Baixo = 1;
                    }
                    else
                    {
                        Config.Dest_Est_Baixo = 0;
                    }
                    //
                    if (alertar_estoque == true)
                    {
                        Config.Alertar_Estoque = 1;
                        con.Alterar_Alertar_Estoque_Baixo_Todos(Config);
                    }
                    else
                    {
                        Config.Alertar_Estoque = 0;
                        con.Alterar_Alertar_Estoque_Baixo_Todos(Config);
                    }
                    //
                    if (destacar_est_vaixo == true)
                    {
                        Config.Dest_Est_Baixo = 1;
                        con.Alterar_Destacar_Est_Baixo_Todos(Config);
                    }
                    else
                    {
                        Config.Dest_Est_Baixo = 0;
                        con.Alterar_Destacar_Est_Baixo_Todos(Config);
                    }
                    //
                    if (alertar_observacao == true)
                    {
                        Config.Alertar_Observacao = 1;
                    }
                    else
                    {
                        Config.Alertar_Observacao = 0;
                    }
                    //
                    if (mostrar_ass_cons == true)
                    {
                        Config.Mostrar_Ass_Cons = 1;
                    }
                    else
                    {
                        Config.Mostrar_Ass_Cons = 0;
                    }
                    //
                    if (cont_usuario_vendas == true)
                    {
                        Config.Cont_Usuario_Vendas = 1;
                    }
                    else
                    {
                        Config.Cont_Usuario_Vendas = 0;
                    }
                    //
                    if (contingencia_nfce == true)
                    {
                        Config.Contingencia_NFCe = 1;
                    }
                    else
                    {
                        Config.Contingencia_NFCe = 0;
                    }
                    //
                    if (porta_email == null)
                    {
                        Config.Porta_Email = "null";
                    }
                    else
                    {
                        Config.Porta_Email = porta_email.Insert(porta_email.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Salvar_Configuracoes_Globais(Config);
                }
            }
        }

        public static bool Sel_Abert_Fech_Caixa_Config()
        {
            using (Con7BD con = new Con7BD())
            {
                if (con.Sel_Abert_Fech_Caixa_Config() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static short Sel_Margem_Esq_PDF_A4_Adm(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Margem_Esq_PDF_A4_Adm(Config);
                }
            }
        }

        public static short Sel_Margem_Topo_PDF_A4_Adm(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Margem_Topo_PDF_A4_Adm(Config);
                }
            }
        }

        public static string Sel_Tipo_Imp_NNF(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Tipo_Imp_NNF(Config);
                }
            }
        }

        public static string Sel_Tipo_Imp_Nota_Promissoria(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Tipo_Imp_Nota_Promissoria(Config);
                }
            }
        }

        public static string Sel_Nome_Imp_NNF(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Nome_Imp_NNF(Config);
                }
            }
        }

        public static string Sel_Tipo_Imp_Orcamento(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Tipo_Imp_Orcamento(Config);
                }
            }
        }

        public static string Sel_Nome_Imp_Orcamento(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Nome_Imp_Orcamento(Config);
                }
            }
        }
              
        public static string Sel_Tipo_Imp_Devolucao(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Tipo_Imp_Devolucao(Config);
                }
            }
        }

        public static bool Sel_Contingencia_NFCe()
        {
            using (Con7BD con = new Con7BD())
            {
                if (con.Sel_Contingencia_NFCe() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool Sel_Alertar_Observacao()
        {
            using (Con7BD con = new Con7BD())
            {
                if (con.Sel_Alertar_Observacao() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string Sel_Porta_Email()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Porta_Email();
            }
        }

        public static bool Sel_Alertar_Estoque()
        {
            using (Con7BD con = new Con7BD())
            {
                if (con.Sel_Alertar_Estoque() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool Sel_Dest_Estoque_Baixo()
        {
            using (Con7BD con = new Con7BD())
            {
                if (con.Sel_Dest_Estoque_Baixo() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool Sel_Mostrar_Ass_Cons()
        {
            using (Con7BD con = new Con7BD())
            {
                if (con.Sel_Mostrar_Ass_Cons() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool Sel_Cont_Usuario_Vendas()
        {
            using (Con7BD con = new Con7BD())
            {
                if (con.Sel_Cont_Usuario_Vendas() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string Sel_Tipo_Documento_Venda(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    return con.Sel_Tipo_Documento_Venda(Config);
                }
            }
        }

        public static bool Sel_Mostrar_Desc_Acresc_Venda(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    if (con.Sel_Mostrar_Desc_Acresc_Venda(Config) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool Sel_Buscar_Atualizacoes(string codigo)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (ConfiguracaoSistema Config = new ConfiguracaoSistema())
                {
                    Config.Codigo = Convert.ToInt16(codigo);
                    //
                    if (con.Sel_Buscar_Atualizacoes(Config) == 1)
                    {
                        return true;
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
