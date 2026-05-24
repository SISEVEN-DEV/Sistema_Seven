using ACBrLib;
using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadFuncaoUsuario : Form
    {
        public FrmCadFuncaoUsuario(string codigo)
        {
            InitializeComponent();
            _Codigo = codigo;
        }

        private string _Codigo;

        private void FrmCadFuncaoUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFuncaoUsuario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFuncaoUsuario iniciado.");
                }
                //
                if (bllUsuario._Funcoes_Salvas == true)
                {
                    chkbPermOrc.Checked = bllUsuario._Realizar_Orcamento;
                    chkbPermDev.Checked = bllUsuario._Realizar_Devolucao;
                    chkbPermCancExclItem.Checked = bllUsuario._Permitir_Canc_Exc_Item_Venda;
                    chkbCapOrcamento.Checked = bllUsuario._Capturar_Orcamento;
                    chkbCapDevolucao.Checked = bllUsuario._Capturar_Devolucao;
                    chkbPermConPerm.Checked = bllUsuario._Permissao_Usuarios;
                    //
                    chkbPermDescPag.Checked = bllUsuario._Permitir_Desc_Pag;
                    if (chkbPermDescPag.Checked == false)
                    {
                        lblDesconto.Enabled = false;
                        label3.Enabled = false;
                        txtDesconto.Enabled = false;
                        txtDesconto.Text = "0,00";
                    }
                    else
                    {
                        lblDesconto.Enabled = true;
                        label3.Enabled = true;
                        txtDesconto.Enabled = true;
                    }
                    //
                    chkbPermAcrescPag.Checked = bllUsuario._Permitir_Acresc_Pag;
                    if (chkbPermAcrescPag.Checked == false)
                    {
                        lblAcrescimo.Enabled = false;
                        label1.Enabled = false;
                        txtAcrescimo.Enabled = false;
                        txtAcrescimo.Text = "0,00";
                    }
                    else
                    {
                        lblAcrescimo.Enabled = true;
                        label1.Enabled = true;
                        txtAcrescimo.Enabled = true;
                    }
                    //
                    chkbPermFinPDV.Checked = bllUsuario._Permitir_Fin_PDV;
                    chkbPermAltProdItem.Checked = bllUsuario._Permitir_Alt_Prod_Item;
                    chkbMostrarDadoProdItem.Checked = bllUsuario._Mostrar_Dados_Prod_Item;
                    txtAcrescimo.Text = bllUsuario._Acrescimo_Porc_Max_Venda;
                    txtDesconto.Text = bllUsuario._Desconto_Porc_Max_Venda;
                    chkbPermAbrirCaixa.Checked = bllUsuario._Permitir_Abrir_Caixa;
                    chkbpermFechCaixa.Checked = bllUsuario._Permitir_Fechar_Caixa;
                    chkbPermSangSup.Checked = bllUsuario._Permitir_Real_SangSup;
                    chkbPermRecContaPagar.Checked = bllUsuario._Permitir_Real_Conta_Pagar;
                    chkbPermRecContaReceber.Checked = bllUsuario._Permitir_Real_Conta_Receber;
                    chkbPermRecContaPagar.Checked = bllUsuario._Permitir_Real_Conta_Pagar;
                    chkbClienteCons.Checked = bllUsuario._Cadastrar_Cliente_Consumidor;
                    chkbContaPagar.Checked = bllUsuario._Cadastrar_Conta_Pagar;
                    chkbContaReceber.Checked = bllUsuario._Cadastrar_Conta_Receber;
                    chkbCFOPNat.Checked = bllUsuario._Cadastrar_CFOP_NatOp;
                    chkbEntidadeBancaria.Checked = bllUsuario._Cadastrar_Entidade_Bancaria;
                    chkbFormasPagamento.Checked = bllUsuario._Cadastrar_Forma_Pagamento;
                    chkbFornecedores.Checked = bllUsuario._Cadastrar_Fornecedor;
                    chkbFuncionarios.Checked = bllUsuario._Cadastrar_Funcionario;
                    chkbGrupos.Checked = bllUsuario._Cadastrar_Grupo;
                    chkbLocalizacao.Checked = bllUsuario._Cadastrar_Localizacao;
                    chkbMarcas.Checked = bllUsuario._Cadastrar_Marca;
                    chkbProdutos.Checked = bllUsuario._Cadastrar_Produto;
                    chkbSubgrupos.Checked = bllUsuario._Cadastrar_Subgrupo;
                    chkbUsuarios.Checked = bllUsuario._Cadastrar_Usuario;
                    chkbpermPausarCaixa.Checked = bllUsuario._Permitir_Pausar_Caixa;
                    chkbpermVisHistCaixa.Checked = bllUsuario._Permitir_Vis_Hist_Caixa;
                    chkbPermCadNoPDV.Checked = bllUsuario._Permitir_Cad_No_Pdv;
                    chkbPermVendaClieSCredito.Checked = bllUsuario._Permitir_Venda_N_Prom_S_Credito;
                    chkbRelAbertFechCaixa.Checked = bllUsuario._Rel_Abert_Fech_Caixa;
                    chkbRelClienteCons.Checked = bllUsuario._Rel_Cliente_Consumidor;
                    chkbRelContaPagar.Checked = bllUsuario._Rel_Conta_Pagar;
                    chkbRelContasReceber.Checked = bllUsuario._Rel_Conta_Receber;
                    chkbRelProdutosServicos.Checked = bllUsuario._Rel_Produtos_Servico;
                    chkbRelOrcamento.Checked = bllUsuario._Rel_Orcamento;
                    chkbRelVendas.Checked = bllUsuario._Rel_Venda;
                    chkbRelGrupos.Checked = bllUsuario._Rel_Grupo;
                    chkbRelFuncionarios.Checked = bllUsuario._Rel_Funcionario;
                    chkbRelFormasPagamento.Checked = bllUsuario._Rel_Formas_Pagamento;
                    chkbRelFornecedores.Checked = bllUsuario._Rel_Fornecedor;
                    chkbRelSubgrupos.Checked = bllUsuario._Rel_Subgrupo;
                    chkbRelHistCaixa.Checked = bllUsuario._Rel_Historico_Caixa;
                    chkbRelFluxoCaixa.Checked = bllUsuario._Rel_Fluxo_Caixa;
                    chkbRelSaidasProdutos.Checked = bllUsuario._Rel_Saida_Produto;
                    chkbRelEntradaProduto.Checked = bllUsuario._Rel_Entrada_Produto;
                    chkbRelSangriaSuprimento.Checked = bllUsuario._Rel_Sangria_Suprimento;
                    chkbRelDevolucaoProdServ.Checked = bllUsuario._Rel_Devolucao_Servico;
                    chkbVisSenhaUsuario.Checked = bllUsuario._Permitir_Vis_Senha_Usuario;
                    chkbPermIgnorarMultaJuros.Checked = bllUsuario._Permitir_Ignorar_Multa_Juros_Receber;
                    chkbPermExcSangSup.Checked = bllUsuario._Permitir_Exc_Sang_Sup;
                    chkbRelUsuarios.Checked = bllUsuario._Rel_Usuario;
                    chkbRelMarca.Checked = bllUsuario._Rel_Marca;
                    chkbLocalizacao.Checked = bllUsuario._Rel_Localizacao;
                    chkbPermVenSCreLoja.Checked = bllUsuario._Permitir_Venda_S_Credito_Loja;
                    chkbPermitirAltEmp.Checked = bllUsuario._Permitir_Alt_Dados_Emp;
                    chkbPermAltConfig.Checked = bllUsuario._Permitir_Alt_Dados_Config;
                    chkbLembContaPagar.Checked = bllUsuario._Criar_Lembrete_Conta_Pagar;
                    chkbLembContaReceber.Checked = bllUsuario._Criar_Lembrete_Conta_Receber;
                    chkbCriarContaAoDFe.Checked = bllUsuario._Criar_Conta_a_Pagar_DFe;
                    chkbLembValidade.Checked = bllUsuario._Criar_Lembrete_Validade;
                    chkbRelAniversariante.Checked = bllUsuario._Rel_Aniversariante;
                    chkbRelDFe.Checked = bllUsuario._Rel_DFe;
                    chkbCadDFe.Checked = bllUsuario._Cadastrar_DFe;
                    chkbRelRegAtividade.Checked = bllUsuario._Rel_Reg_Atividade;
                    chkbRelValProdServ.Checked = bllUsuario._Rel_Reg_Validade_Prod_Serv;
                    chkbPermAtuZerEst.Checked = bllUsuario._Permitir_Atualizar_Zerar_Estoque;
                    chkbEstoque.Checked = bllUsuario._Rel_Estoque;
                    chkbPermExcInv.Checked = bllUsuario._Permitir_Excluir_Inventario;
                    chkbCapVenda.Checked = bllUsuario._Capturar_Venda;
                    chkbServicos.Checked = bllUsuario._Cadastrar_Servico;
                    chkbPermExcOS.Checked = bllUsuario._Permitir_Excluir_OS;
                    chkbOS.Checked = bllUsuario._Cadastrar_OS;
                    chkbPSPPIX.Checked = bllUsuario._Cadastrar_PSPPIX;
                    chkbMenuNFeNFCe.Checked = bllUsuario._Acessar_Menu_NFe_NFCe;
                    chkbMenuNFSe.Checked = bllUsuario._Acessar_Menu_NFSe;
                    chkbCriarNFe55.Checked = bllUsuario._Cadastrar_NFe;
                    chkbRelComissao.Checked = bllUsuario._Rel_Comissao;
                    chkbRelContCheque.Checked = bllUsuario._Rel_Controle_Cheque;
                    chkbRelOS.Checked = bllUsuario._Rel_OS;
                    chkbCadDoc.Checked = bllUsuario._Cadastrar_Documentos;
                    chkbpermDesfBaixa.Checked = bllUsuario._Permitir_Desfazer_Baixa;
                }
                else
                {
                    if (_Codigo != "")
                    {
                        if (bllUsuario.Sel_Funcoes_Usuario(_Codigo) != null)
                        {
                            DataRow dr = bllUsuario.Sel_Funcoes_Usuario(_Codigo).Rows[0];
                            //
                            if (Convert.ToByte(dr["perm_exc_inv"]) == 0)
                            {
                                chkbPermExcInv.Checked = false;
                            }
                            else
                            {
                                chkbPermExcInv.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["realizar_orcamento"]) == 0)
                            {
                                chkbPermOrc.Checked = false;
                            }
                            else
                            {
                                chkbPermOrc.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["realizar_devolucao"]) == 0)
                            {
                                chkbPermDev.Checked = false;
                            }
                            else
                            {
                                chkbPermDev.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_canc_exc_item_venda"]) == 0)
                            {
                                chkbPermCancExclItem.Checked = false;
                            }
                            else
                            {
                                chkbPermCancExclItem.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["capturar_orcamento"]) == 0)
                            {
                                chkbCapOrcamento.Checked = false;
                            }
                            else
                            {
                                chkbCapOrcamento.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["capturar_devolucao"]) == 0)
                            {
                                chkbCapDevolucao.Checked = false;
                            }
                            else
                            {
                                chkbCapDevolucao.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permissao_usuarios"]) == 0)
                            {
                                chkbPermConPerm.Checked = false;
                            }
                            else
                            {
                                chkbPermConPerm.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_dfe"]) == 0)
                            {
                                chkbRelDFe.Checked = false;
                            }
                            else
                            {
                                chkbRelDFe.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_dfe"]) == 0)
                            {
                                chkbCadDFe.Checked = false;
                            }
                            else
                            {
                                chkbCadDFe.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_validade_prod_serv"]) == 0)
                            {
                                chkbRelValProdServ.Checked = false;
                            }
                            else
                            {
                                chkbRelValProdServ.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_desc_pag"]) == 0)
                            {
                                chkbPermDescPag.Checked = false;
                                lblDesconto.Enabled = false;
                                label3.Enabled = false;
                                txtDesconto.Enabled = false;
                                txtDesconto.Text = "0,00";
                            }
                            else
                            {
                                chkbPermDescPag.Checked = true;
                                lblDesconto.Enabled = true;
                                label3.Enabled = true;
                                txtDesconto.Enabled = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_acresc_pag"]) == 0)
                            {
                                chkbPermAcrescPag.Checked = false;
                                lblAcrescimo.Enabled = false;
                                label1.Enabled = false;
                                txtAcrescimo.Enabled = false;
                                txtAcrescimo.Text = "0,00";
                            }
                            else
                            {
                                chkbPermAcrescPag.Checked = true;
                                lblAcrescimo.Enabled = true;
                                label1.Enabled = true;
                                txtAcrescimo.Enabled = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_fin_pdv"]) == 0)
                            {
                                chkbPermFinPDV.Checked = false;
                            }
                            else
                            {
                                chkbPermFinPDV.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_alt_prod_item"]) == 0)
                            {
                                chkbPermAltProdItem.Checked = false;
                            }
                            else
                            {
                                chkbPermAltProdItem.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["mostrar_dados_prod_item"]) == 0)
                            {
                                chkbMostrarDadoProdItem.Checked = false;
                            }
                            else
                            {
                                chkbMostrarDadoProdItem.Checked = true;
                            }
                            //
                            txtAcrescimo.Text = Convert.ToDecimal(dr["acrescimo_porc_max_venda"]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            txtDesconto.Text = Convert.ToDecimal(dr["desconto_porc_max_venda"]).ToString("n2", new CultureInfo("pt-BR"));
                            //
                            if (Convert.ToByte(dr["permitir_abrir_caixa"]) == 0)
                            {
                                chkbPermAbrirCaixa.Checked = false;
                            }
                            else
                            {
                                chkbPermAbrirCaixa.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_fechar_caixa"]) == 0)
                            {
                                chkbpermFechCaixa.Checked = false;
                            }
                            else
                            {
                                chkbpermFechCaixa.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_aniversariante"]) == 0)
                            {
                                chkbRelAniversariante.Checked = false;
                            }
                            else
                            {
                                chkbRelAniversariante.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_real_sangsup"]) == 0)
                            {
                                chkbPermSangSup.Checked = false;
                            }
                            else
                            {
                                chkbPermSangSup.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_real_conta_receber"]) == 0)
                            {
                                chkbPermRecContaReceber.Checked = false;
                            }
                            else
                            {
                                chkbPermRecContaReceber.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_real_conta_pagar"]) == 0)
                            {
                                chkbPermRecContaPagar.Checked = false;
                            }
                            else
                            {
                                chkbPermRecContaPagar.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_vis_hist_caixa"]) == 0)
                            {
                                chkbpermVisHistCaixa.Checked = false;
                            }
                            else
                            {
                                chkbpermVisHistCaixa.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_cliente"]) == 0)
                            {
                                chkbClienteCons.Checked = false;
                            }
                            else
                            {
                                chkbClienteCons.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_conta_pagar"]) == 0)
                            {
                                chkbContaPagar.Checked = false;
                            }
                            else
                            {
                                chkbContaPagar.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_conta_receber"]) == 0)
                            {
                                chkbContaReceber.Checked = false;
                            }
                            else
                            {
                                chkbContaReceber.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_cfop_natop"]) == 0)
                            {
                                chkbCFOPNat.Checked = false;
                            }
                            else
                            {
                                chkbCFOPNat.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_entidade_bancaria"]) == 0)
                            {
                                chkbEntidadeBancaria.Checked = false;
                            }
                            else
                            {
                                chkbEntidadeBancaria.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_forma_pagamento"]) == 0)
                            {
                                chkbFormasPagamento.Checked = false;
                            }
                            else
                            {
                                chkbFormasPagamento.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_fornecedor"]) == 0)
                            {
                                chkbFornecedores.Checked = false;
                            }
                            else
                            {
                                chkbFornecedores.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_funcionario"]) == 0)
                            {
                                chkbFuncionarios.Checked = false;
                            }
                            else
                            {
                                chkbFuncionarios.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_grupo"]) == 0)
                            {
                                chkbGrupos.Checked = false;
                            }
                            else
                            {
                                chkbGrupos.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_localizacao"]) == 0)
                            {
                                chkbLocalizacao.Checked = false;
                            }
                            else
                            {
                                chkbLocalizacao.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_marca"]) == 0)
                            {
                                chkbMarcas.Checked = false;
                            }
                            else
                            {
                                chkbMarcas.Checked = true;
                            }
                            //
                            //
                            if (Convert.ToByte(dr["cadastrar_produto"]) == 0)
                            {
                                chkbProdutos.Checked = false;
                            }
                            else
                            {
                                chkbProdutos.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_subgrupo"]) == 0)
                            {
                                chkbSubgrupos.Checked = false;
                            }
                            else
                            {
                                chkbSubgrupos.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_usuario"]) == 0)
                            {
                                chkbUsuarios.Checked = false;
                            }
                            else
                            {
                                chkbUsuarios.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_pausar_caixa"]) == 0)
                            {
                                chkbpermPausarCaixa.Checked = false;
                            }
                            else
                            {
                                chkbpermPausarCaixa.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_reg_atividade"]) == 0)
                            {
                                chkbRelRegAtividade.Checked = false;
                            }
                            else
                            {
                                chkbRelRegAtividade.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_vis_hist_caixa"]) == 0)
                            {
                                chkbpermVisHistCaixa.Checked = false;
                            }
                            else
                            {
                                chkbpermVisHistCaixa.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_cad_no_pdv"]) == 0)
                            {
                                chkbPermCadNoPDV.Checked = false;
                            }
                            else
                            {
                                chkbPermCadNoPDV.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_venda_n_prom_s_credito"]) == 0)
                            {
                                chkbPermVendaClieSCredito.Checked = false;
                            }
                            else
                            {
                                chkbPermVendaClieSCredito.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_abert_fech_caixa"]) == 0)
                            {
                                chkbRelAbertFechCaixa.Checked = false;
                            }
                            else
                            {
                                chkbRelAbertFechCaixa.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_cliente_consumidor"]) == 0)
                            {
                                chkbRelClienteCons.Checked = false;
                            }
                            else
                            {
                                chkbRelClienteCons.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_conta_pagar"]) == 0)
                            {
                                chkbRelContaPagar.Checked = false;
                            }
                            else
                            {
                                chkbRelContaPagar.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_conta_receber"]) == 0)
                            {
                                chkbRelContasReceber.Checked = false;
                            }
                            else
                            {
                                chkbRelContasReceber.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_produto"]) == 0)
                            {
                                chkbRelProdutosServicos.Checked = false;
                            }
                            else
                            {
                                chkbRelProdutosServicos.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_orcamento"]) == 0)
                            {
                                chkbRelOrcamento.Checked = false;
                            }
                            else
                            {
                                chkbRelOrcamento.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_venda"]) == 0)
                            {
                                chkbRelVendas.Checked = false;
                            }
                            else
                            {
                                chkbRelVendas.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_grupo"]) == 0)
                            {
                                chkbRelGrupos.Checked = false;
                            }
                            else
                            {
                                chkbRelGrupos.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_funcionario"]) == 0)
                            {
                                chkbRelFuncionarios.Checked = false;
                            }
                            else
                            {
                                chkbRelFuncionarios.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_forma_pagamento"]) == 0)
                            {
                                chkbRelFormasPagamento.Checked = false;
                            }
                            else
                            {
                                chkbRelFormasPagamento.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_fornecedor"]) == 0)
                            {
                                chkbRelFornecedores.Checked = false;
                            }
                            else
                            {
                                chkbRelFornecedores.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_subgrupo"]) == 0)
                            {
                                chkbRelSubgrupos.Checked = false;
                            }
                            else
                            {
                                chkbRelSubgrupos.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_hist_caixa"]) == 0)
                            {
                                chkbRelHistCaixa.Checked = false;
                            }
                            else
                            {
                                chkbRelHistCaixa.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_fluxo_caixa"]) == 0)
                            {
                                chkbRelFluxoCaixa.Checked = false;
                            }
                            else
                            {
                                chkbRelFluxoCaixa.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_saida_produto"]) == 0)
                            {
                                chkbRelSaidasProdutos.Checked = false;
                            }
                            else
                            {
                                chkbRelSaidasProdutos.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_entrada_produto"]) == 0)
                            {
                                chkbRelEntradaProduto.Checked = false;
                            }
                            else
                            {
                                chkbRelEntradaProduto.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_sangria_suprimento"]) == 0)
                            {
                                chkbRelSangriaSuprimento.Checked = false;
                            }
                            else
                            {
                                chkbRelSangriaSuprimento.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_devolucao_servico"]) == 0)
                            {
                                chkbRelDevolucaoProdServ.Checked = false;
                            }
                            else
                            {
                                chkbRelDevolucaoProdServ.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["perm_vis_senha_usuario"]) == 0)
                            {
                                chkbVisSenhaUsuario.Checked = false;
                            }
                            else
                            {
                                chkbVisSenhaUsuario.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["perm_ign_multa_juros_rec"]) == 0)
                            {
                                chkbPermIgnorarMultaJuros.Checked = false;
                            }
                            else
                            {
                                chkbPermIgnorarMultaJuros.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["perm_exc_sang_sup"]) == 0)
                            {
                                chkbPermExcSangSup.Checked = false;
                            }
                            else
                            {
                                chkbPermExcSangSup.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_usuario"]) == 0)
                            {
                                chkbRelUsuarios.Checked = false;
                            }
                            else
                            {
                                chkbRelUsuarios.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_marca"]) == 0)
                            {
                                chkbRelMarca.Checked = false;
                            }
                            else
                            {
                                chkbRelMarca.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_localizacao"]) == 0)
                            {
                                chkbRelLocalizacao.Checked = false;
                            }
                            else
                            {
                                chkbRelLocalizacao.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_venda_s_credito_loja"]) == 0)
                            {
                                chkbPermVenSCreLoja.Checked = false;
                            }
                            else
                            {
                                chkbPermVenSCreLoja.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_alt_dados_emp"]) == 0)
                            {
                                chkbPermitirAltEmp.Checked = false;
                            }
                            else
                            {
                                chkbPermitirAltEmp.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_alt_dados_config"]) == 0)
                            {
                                chkbPermAltConfig.Checked = false;
                            }
                            else
                            {
                                chkbPermAltConfig.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["criar_lemb_conta_pagar"]) == 0)
                            {
                                chkbLembContaPagar.Checked = false;
                            }
                            else
                            {
                                chkbLembContaPagar.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["criar_lemb_conta_receber"]) == 0)
                            {
                                chkbLembContaReceber.Checked = false;
                            }
                            else
                            {
                                chkbLembContaReceber.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["criar_conta_pagar_dfe"]) == 0)
                            {
                                chkbCriarContaAoDFe.Checked = false;
                            }
                            else
                            {
                                chkbCriarContaAoDFe.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["criar_lemb_validade"]) == 0)
                            {
                                chkbLembValidade.Checked = false;
                            }
                            else
                            {
                                chkbLembValidade.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["perm_atu_zer_est"]) == 0)
                            {
                                chkbPermAtuZerEst.Checked = false;
                            }
                            else
                            {
                                chkbPermAtuZerEst.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_estoque"]) == 0)
                            {
                                chkbEstoque.Checked = false;
                            }
                            else
                            {
                                chkbEstoque.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["capturar_venda"]) == 0)
                            {
                                chkbCapVenda.Checked = false;
                            }
                            else
                            {
                                chkbCapVenda.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_servico"]) == 0)
                            {
                                chkbServicos.Checked = false;
                            }
                            else
                            {
                                chkbServicos.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["perm_exc_os"]) == 0)
                            {
                                chkbPermExcOS.Checked = false;
                            }
                            else
                            {
                                chkbPermExcOS.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_os"]) == 0)
                            {
                                chkbOS.Checked = false;
                            }
                            else
                            {
                                chkbOS.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_psppix"]) == 0)
                            {
                                chkbPSPPIX.Checked = false;
                            }
                            else
                            {
                                chkbPSPPIX.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["acessar_menu_nfe_nfce"]) == 0)
                            {
                                chkbMenuNFeNFCe.Checked = false;
                            }
                            else
                            {
                                chkbMenuNFeNFCe.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["acessar_menu_nfse"]) == 0)
                            {
                                chkbMenuNFSe.Checked = false;
                            }
                            else
                            {
                                chkbMenuNFSe.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_nfe"]) == 0)
                            {
                                chkbCriarNFe55.Checked = false;
                            }
                            else
                            {
                                chkbCriarNFe55.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_comissao"]) == 0)
                            {
                                chkbRelComissao.Checked = false;
                            }
                            else
                            {
                                chkbRelComissao.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_controle_cheque"]) == 0)
                            {
                                chkbRelContCheque.Checked = false;
                            }
                            else
                            {
                                chkbRelContCheque.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["rel_os"]) == 0)
                            {
                                chkbRelOS.Checked = false;
                            }
                            else
                            {
                                chkbRelOS.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["cadastrar_documentos"]) == 0)
                            {
                                chkbCadDoc.Checked = false;
                            }
                            else
                            {
                                chkbCadDoc.Checked = true;
                            }
                            //
                            if (Convert.ToByte(dr["permitir_desfazer_baixa"]) == 0)
                            {
                                chkbpermDesfBaixa.Checked = false;
                            }
                            else
                            {
                                chkbpermDesfBaixa.Checked = true;
                            }
                        }
                    }
                    else
                    {
                        chkbPermOrc.Checked = true;
                        chkbPermDev.Checked = true;
                        chkbPermCancExclItem.Checked = true;
                        chkbCapOrcamento.Checked = true;
                        chkbCapDevolucao.Checked = true;
                        chkbPermConPerm.Checked = false;
                        chkbPermDescPag.Checked = false;
                        txtDesconto.Text = "0,00";
                        chkbPermAcrescPag.Checked = false;
                        txtAcrescimo.Text = "0,00";
                        txtDesconto.Enabled = false;
                        txtAcrescimo.Enabled = false;


                        /*
                      
                        Users.Permitir_Fin_PDV = 1;
                        Users.Permitir_Alt_Prod_Item = 1;
                        Users.Mostrar_Dados_Prod_Item = 0;
                        Users.Desconto_Porc_Max_Venda = 0;
                        Users.Acrescimo_Porc_Max_Venda = 0;
                        Users.Permitir_Abrir_Caixa = 1;
                        Users.Permitir_Fechar_Caixa = 1;
                        Users.Permitir_Real_SangSup = 0;
                        Users.Permitir_Real_Conta_Receber = 1;
                        Users.Permitir_Real_Conta_Pagar = 0;
                        Users.Cadastrar_Cliente_Consumidor = 1;
                        Users.Cadastrar_Conta_Pagar = 1;
                        Users.Cadastrar_Conta_Receber = 1;
                        Users.Cadastrar_Entidade_Bancaria = 1;
                        Users.Cadastrar_Forma_Pagamento = 0;
                        Users.Cadastrar_Fornecedor = 1;
                        Users.Cadastrar_Funcionario = 1;
                        Users.Cadastrar_Grupo = 1;
                        Users.Cadastrar_Localizacao = 1;
                        Users.Cadastrar_Marca = 1;
                        Users.Cadastrar_Produto = 1;
                        Users.Cadastrar_Subgrupo = 1;
                        Users.Cadastrar_Usuario = 1;
                        Users.Permitir_Pausar_Caixa = 1;
                        Users.Permitir_Vis_Hist_Caixa = 0;
                        Users.Permitir_Cad_No_Pdv = 1;
                        Users.Permitir_Venda_N_Promissoria_S_Credito = 0;
                        Users.Rel_Abert_Fech_Caixa = 0;
                        Users.Rel_Cliente_Consumidor = 1;
                        Users.Rel_Conta_Pagar = 0;
                        Users.Rel_Conta_Receber = 0;
                        Users.Rel_Produtos_Servico = 1;
                        Users.Rel_Orcamento = 1;
                        Users.Rel_Venda = 1;
                        Users.Rel_Grupo = 1;
                        Users.Rel_Funcionario = 0;
                        Users.Rel_Formas_Pagamento = 1;
                        Users.Rel_Fornecedor = 1;
                        Users.Rel_Subgrupo = 1;
                        Users.Rel_Historico_Caixa = 1;
                        Users.Rel_Fluxo_Caixa = 1;
                        Users.Rel_Saida_Produto = 1;
                        Users.Rel_Entrada_Produto = 1;
                        Users.Rel_Sangria_Suprimento = 0;
                        Users.Rel_Devolucao_Servico = 1;
                        Users.Permitir_Vis_Senha_Usuario = 0;
                        Users.Permitir_Ignorar_Multa_Juros_Receber = 0;
                        Users.Permitir_Exc_Sang_Sup = 0;
                        Users.Rel_Usuario = 0;
                        Users.Rel_Marca = 1;
                        Users.Rel_Localizacao = 1;
                        Users.Permitir_Venda_S_Credito_Loja = 0;
                        Users.Permitir_Alt_Dados_Emp = 0;
                        Users.Permitir_Alt_Dados_Config = 0;
                        Users.Criar_Lembrete_Conta_Pagar = 1;
                        Users.Criar_Lembrete_Conta_Receber = 0;
                        Users.Criar_Conta_a_Pagar_DFe = 1;
                        Users.Criar_Lembrete_Validade = 1;
                        Users.Cadastrar_CFOP_NatOp = 1;
                        Users.Rel_Aniversariante = 1;
                        Users.Rel_DFe = 1;
                        Users.Cadastrar_DFe = 1;
                        Users.Rel_Reg_Atividade = 1;
                        Users.Rel_Reg_Validade_Prod_Serv = 1;
                        Users.Permitir_Atualizar_Zerar_Estoque = 0;
                        Users.Rel_Estoque = 1;
                        Users.Permitir_Excluir_Inventario = 0;
                        Users.Capturar_Venda = 1;
                        Users.Cadastrar_Servico = 1;
                        Users.Permitir_Excluir_OS = 1;
                        Users.Cadastrar_OS = 1;
                        Users.Cadastrar_PSPPIX = 1;
                        Users.Acessar_Menu_NFe_NFCe = 1;
                        Users.Acessar_Menu_NFSe = 1;
                        Users.Cadastrar_NFe = 1;
                        */
                    }
                }
                btnSalvar.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFuncaoUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFuncaoUsuario.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void chkbPermOrc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermOrc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadFuncaoUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    bllUsuario._Realizar_Orcamento = chkbPermOrc.Checked;
                    bllUsuario._Realizar_Devolucao = chkbPermDev.Checked;
                    bllUsuario._Permitir_Canc_Exc_Item_Venda = chkbPermCancExclItem.Checked;
                    bllUsuario._Capturar_Orcamento = chkbCapOrcamento.Checked;
                    bllUsuario._Capturar_Devolucao = chkbCapDevolucao.Checked;
                    bllUsuario._Permissao_Usuarios = chkbPermConPerm.Checked;
                    bllUsuario._Permitir_Desc_Pag = chkbPermDescPag.Checked;
                    bllUsuario._Permitir_Acresc_Pag = chkbPermAcrescPag.Checked;
                    bllUsuario._Permitir_Fin_PDV = chkbPermFinPDV.Checked;
                    bllUsuario._Permitir_Alt_Prod_Item = chkbPermAltProdItem.Checked;
                    bllUsuario._Mostrar_Dados_Prod_Item = chkbMostrarDadoProdItem.Checked;
                    bllUsuario._Desconto_Porc_Max_Venda = txtDesconto.Text;
                    bllUsuario._Acrescimo_Porc_Max_Venda = txtAcrescimo.Text;
                    bllUsuario._Permitir_Abrir_Caixa = chkbPermAbrirCaixa.Checked;
                    bllUsuario._Permitir_Fechar_Caixa = chkbpermFechCaixa.Checked;
                    bllUsuario._Permitir_Real_SangSup = chkbPermSangSup.Checked;
                    bllUsuario._Permitir_Real_Conta_Receber = chkbPermRecContaReceber.Checked;
                    bllUsuario._Permitir_Real_Conta_Pagar = chkbPermRecContaPagar.Checked;
                    bllUsuario._Cadastrar_Cliente_Consumidor = chkbClienteCons.Checked;
                    bllUsuario._Cadastrar_Conta_Pagar = chkbContaPagar.Checked;
                    bllUsuario._Cadastrar_Conta_Receber = chkbContaReceber.Checked;
                    bllUsuario._Cadastrar_Entidade_Bancaria = chkbEntidadeBancaria.Checked;
                    bllUsuario._Cadastrar_Forma_Pagamento = chkbFormasPagamento.Checked;
                    bllUsuario._Cadastrar_Fornecedor = chkbFornecedores.Checked;
                    bllUsuario._Cadastrar_Funcionario = chkbFuncionarios.Checked;
                    bllUsuario._Cadastrar_Grupo = chkbGrupos.Checked;
                    bllUsuario._Cadastrar_Localizacao = chkbLocalizacao.Checked;
                    bllUsuario._Cadastrar_Marca = chkbMarcas.Checked;
                    bllUsuario._Cadastrar_Produto = chkbProdutos.Checked;
                    bllUsuario._Cadastrar_Subgrupo = chkbSubgrupos.Checked;
                    bllUsuario._Cadastrar_Usuario = chkbUsuarios.Checked;
                    bllUsuario._Permitir_Pausar_Caixa = chkbpermPausarCaixa.Checked;
                    bllUsuario._Permitir_Vis_Hist_Caixa = chkbpermVisHistCaixa.Checked;
                    bllUsuario._Permitir_Cad_No_Pdv = chkbPermCadNoPDV.Checked;
                    bllUsuario._Permitir_Venda_N_Prom_S_Credito = chkbPermVendaClieSCredito.Checked;
                    bllUsuario._Rel_Abert_Fech_Caixa = chkbRelAbertFechCaixa.Checked;
                    bllUsuario._Rel_Cliente_Consumidor = chkbRelClienteCons.Checked;
                    bllUsuario._Rel_Conta_Pagar = chkbRelContaPagar.Checked;
                    bllUsuario._Rel_Conta_Receber = chkbRelContasReceber.Checked;
                    bllUsuario._Rel_Produtos_Servico = chkbRelProdutosServicos.Checked;
                    bllUsuario._Rel_Orcamento = chkbRelOrcamento.Checked;
                    bllUsuario._Rel_Venda = chkbRelVendas.Checked;
                    bllUsuario._Rel_Grupo = chkbRelGrupos.Checked;
                    bllUsuario._Rel_Funcionario = chkbRelFuncionarios.Checked;
                    bllUsuario._Rel_Formas_Pagamento = chkbRelFormasPagamento.Checked;
                    bllUsuario._Rel_Fornecedor = chkbRelFornecedores.Checked;
                    bllUsuario._Rel_Subgrupo = chkbRelSubgrupos.Checked;
                    bllUsuario._Rel_Historico_Caixa = chkbRelHistCaixa.Checked;
                    bllUsuario._Rel_Fluxo_Caixa = chkbRelFluxoCaixa.Checked;
                    bllUsuario._Rel_Saida_Produto = chkbRelSaidasProdutos.Checked;
                    bllUsuario._Rel_Entrada_Produto = chkbRelEntradaProduto.Checked;
                    bllUsuario._Rel_Sangria_Suprimento = chkbRelSangriaSuprimento.Checked;
                    bllUsuario._Rel_Devolucao_Servico = chkbRelDevolucaoProdServ.Checked;
                    bllUsuario._Permitir_Vis_Senha_Usuario = chkbVisSenhaUsuario.Checked;
                    bllUsuario._Permitir_Ignorar_Multa_Juros_Receber = chkbPermIgnorarMultaJuros.Checked;
                    bllUsuario._Permitir_Exc_Sang_Sup = chkbPermExcSangSup.Checked;
                    bllUsuario._Rel_Usuario = chkbRelUsuarios.Checked;
                    bllUsuario._Rel_Marca = chkbRelMarca.Checked;
                    bllUsuario._Rel_Localizacao = chkbRelLocalizacao.Checked;
                    bllUsuario._Permitir_Venda_S_Credito_Loja = chkbPermVenSCreLoja.Checked;
                    bllUsuario._Permitir_Alt_Dados_Emp = chkbPermitirAltEmp.Checked;
                    bllUsuario._Permitir_Alt_Dados_Config = chkbPermAltConfig.Checked;
                    bllUsuario._Criar_Lembrete_Conta_Pagar = chkbLembContaPagar.Checked;
                    bllUsuario._Criar_Lembrete_Conta_Receber = chkbLembContaReceber.Checked;
                    bllUsuario._Criar_Conta_a_Pagar_DFe = chkbCriarContaAoDFe.Checked;
                    bllUsuario._Criar_Lembrete_Validade = chkbLembValidade.Checked;
                    bllUsuario._Cadastrar_CFOP_NatOp = chkbCFOPNat.Checked;
                    bllUsuario._Rel_Aniversariante = chkbRelAniversariante.Checked;
                    bllUsuario._Rel_DFe = chkbRelDFe.Checked;
                    bllUsuario._Cadastrar_DFe = chkbCadDFe.Checked;
                    bllUsuario._Rel_Reg_Atividade = chkbRelRegAtividade.Checked;
                    bllUsuario._Rel_Reg_Validade_Prod_Serv = chkbRelValProdServ.Checked;
                    bllUsuario._Permitir_Atualizar_Zerar_Estoque = chkbPermAtuZerEst.Checked;
                    bllUsuario._Rel_Estoque = chkbEstoque.Checked;
                    bllUsuario._Permitir_Excluir_Inventario = chkbPermExcInv.Checked;
                    bllUsuario._Capturar_Venda = chkbCapVenda.Checked;
                    bllUsuario._Cadastrar_Servico = chkbServicos.Checked;
                    bllUsuario._Permitir_Excluir_OS = chkbPermExcOS.Checked;
                    bllUsuario._Cadastrar_OS = chkbOS.Checked;
                    bllUsuario._Cadastrar_PSPPIX = chkbPSPPIX.Checked;
                    bllUsuario._Acessar_Menu_NFe_NFCe = chkbMenuNFeNFCe.Checked;
                    bllUsuario._Acessar_Menu_NFSe = chkbMenuNFSe.Checked;
                    bllUsuario._Cadastrar_NFe = chkbCriarNFe55.Checked;
                    bllUsuario._Rel_Comissao = chkbRelComissao.Checked;
                    bllUsuario._Rel_Controle_Cheque = chkbRelContCheque.Checked;
                    bllUsuario._Rel_OS = chkbRelOS.Checked;
                    //
                    bllUsuario._Funcoes_Salvas = true;
                    //
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                btnVoltar.Select();
            }
        }

        private void checkBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void checkBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void chkbPermCancExclItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermCancExclItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbCapOrcamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbCapOrcamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbCapDevolucao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbCapDevolucao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermConPerm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermConPerm_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermDescPag_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermDescPag_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void checkBox6_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void checkBox6_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermFinPDV_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermFinPDV_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermAltProdItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermAltProdItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMostrarDadoProdItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarDadoProdItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtDesconto_Enter(object sender, EventArgs e)
        {
            txtDesconto.BackColor = Color.LightBlue;
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            if (txtDesconto.Text.Contains("'") || txtDesconto.Text.Contains(";") || txtDesconto.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDesconto.Text = null;
                txtDesconto.Select();
            }
            else
            {
                try
                {
                    if (txtDesconto.Text != "")
                    {
                        txtDesconto.Text = Convert.ToDecimal(txtDesconto.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDesconto.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtDesconto.");
                    }
                    txtDesconto.Text = null;
                }
            }
            //
            txtDesconto.BackColor = Color.White;
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDesconto.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                chkbPermAcrescPag.Select();
            }
        }

        private void txtAcrescimo_Leave(object sender, EventArgs e)
        {
            if (txtAcrescimo.Text.Contains("'") || txtAcrescimo.Text.Contains(";") || txtAcrescimo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtAcrescimo.Text = null;
                txtAcrescimo.Select();
            }
            else
            {
                try
                {
                    if (txtAcrescimo.Text != "")
                    {
                        txtAcrescimo.Text = Convert.ToDecimal(txtAcrescimo.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAcrescimo.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtAcrescimo.");
                    }
                    txtAcrescimo.Text = null;
                }
            }
            //
            txtAcrescimo.BackColor = Color.White;
        }

        private void txtAcrescimo_Enter(object sender, EventArgs e)
        {
            txtAcrescimo.BackColor = Color.LightBlue;
        }

        private void txtAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDesconto.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                chkbPermFinPDV.Select();
            }
        }

        private void chkbPermDescPag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbPermDescPag.Checked == false)
            {
                lblDesconto.Enabled = false;
                label3.Enabled = false;
                txtDesconto.Enabled = false;
                txtDesconto.Text = "0,00";
            }
            else
            {
                lblDesconto.Enabled = true;
                label3.Enabled = true;
                txtDesconto.Enabled = true;
            }
        }

        private void chkbPermAcrescPag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbPermAcrescPag.Checked == false)
            {
                lblAcrescimo.Enabled = false;
                label1.Enabled = false;
                txtAcrescimo.Enabled = false;
                txtAcrescimo.Text = "0,00";
            }
            else
            {
                lblAcrescimo.Enabled = true;
                label1.Enabled = true;
                txtAcrescimo.Enabled = true;
            }
        }

        private void chkbpermFechCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbpermFechCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermAbrirCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermAbrirCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermRecContaPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermRecContaPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermRecContaReceber_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermRecContaReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermSangSup_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermSangSup_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkbpermPausarCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbpermPausarCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbpermVisHistCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbpermVisHistCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkbClienteCons_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbClienteCons_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbContaPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbContaPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbContaReceber_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbContaReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbEntidadeBancaria_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbEntidadeBancaria_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbFormasPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbFormasPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbFornecedores_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbFornecedores_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbFuncionarios_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbFuncionarios_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbGrupos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbGrupos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbLocalizacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbLocalizacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbProdutos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbProdutos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbSubgrupos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbSubgrupos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbUsuarios_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbUsuarios_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMarcas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMarcas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbPerfil_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbPerfil_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbPerfil_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbPerfil_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermCadNoPDV_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermCadNoPDV_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPermVendaClieSCredito_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPermVendaClieSCredito_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelAbertFechCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelAbertFechCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelClienteCons_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelClienteCons_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelContaPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelContaPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelContasReceber_MouseEnter(object sender, EventArgs e)
        {

        }

        private void chkbRelContasReceber_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelContasReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelProdutosServicos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelProdutosServicos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelOrcamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelOrcamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelVendas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelVendas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelGrupos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelGrupos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelFuncionarios_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelFuncionarios_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelFormasPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelFormasPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelFornecedores_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelFornecedores_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelSubgrupos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelSubgrupos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelHistCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelHistCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelFluxoCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelFluxoCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelSaidasProdutos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelSaidasProdutos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelEntradaProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelEntradaProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelSangriaSuprimento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelDevolucaoProdServ_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelDevolucaoProdServ_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelSangriaSuprimento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void checkBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void checkBox1_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermIgnorarMultaJuros_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermIgnorarMultaJuros_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadFuncaoUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFuncaoUsuario foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadFuncaoUsuario foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFuncaoUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadFuncaoUsuario.");
                }
            }
        }

        private void chkbPermExcSangSup_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermExcSangSup_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelUsuarios_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelUsuarios_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelLocalizacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelLocalizacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelMarca_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelMarca_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermVenSCreLoja_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermVenSCreLoja_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermitirAltEmp_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermitirAltEmp_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void chkbPermAltConfig_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermAltConfig_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbLembContaReceber_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbLembContaReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbLembContaPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbLembContaPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbCriarContaAoDFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbCriarContaAoDFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbLembValidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbLembValidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbCFOPNat_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbCFOPNat_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelAniversariante_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelAniversariante_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelDFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelDFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbCadDFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbCadDFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelRegAtividade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelRegAtividade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbRelValProdServ_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbRelValProdServ_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermAtuZerEst_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermAtuZerEst_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbEstoque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbEstoque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermExcInv_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermExcInv_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbCapVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbCapVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbServicos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbServicos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPermExcOS_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPermExcOS_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbOS_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbOS_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbPSPPIX_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbPSPPIX_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMenuNFeNFCe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMenuNFeNFCe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMenuNFSe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMenuNFSe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbCriarNFe55_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbCriarNFe55_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
