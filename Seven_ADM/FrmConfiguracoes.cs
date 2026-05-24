using BLL;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmConfiguracoes : Form
    {
        public FrmConfiguracoes()
        {
            InitializeComponent();
        }

        private bool _Contem_Imagem;

        private void FrmContTipoIndicacao_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConfiguracoes iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConfiguracoes iniciado.");
                }
                //
                foreach (string printname in PrinterSettings.InstalledPrinters)
                {
                    cbbImprimirNNF.Items.Add(printname);
                    cbbImprimirNotaPromEm.Items.Add(printname);
                    cbbImprimirOrcEm.Items.Add(printname);
                    cbbImprimirReceberEm.Items.Add(printname);
                    cbbImprimirDevEm.Items.Add(printname);
                }
                //
                if (bllConfiguracaoSistema.Sel_Tabela_Configuracao_Global_Configuracoes() == null)
                {
                    MessageBox.Show("Ainda não foram definidas configurações para esta opção.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    txtMargemEsq.Select();
                }
                else
                {
                    DataRow dr = bllConfiguracaoSistema.Sel_Tabela_Configuracao_Global_Configuracoes().Rows[0];

                    if (Convert.ToByte(dr["contingencia_nfce"]) == 1)
                    {
                        chkbContNFCe.Checked = true;
                    }
                    else
                    {
                        chkbContNFCe.Checked = false;
                    }
                    //
                    if (Convert.ToByte(dr["abert_fech_caixa"]) == 1)
                    {
                        chkbControlarCaixa.Checked = true;
                    }
                    else
                    {
                        chkbControlarCaixa.Checked = false;
                    }
                    //
                    if (Convert.ToByte(dr["alertar_observacao"]) == 1)
                    {
                        chkbAlertarObservacao.Checked = true;
                    }
                    else
                    {
                        chkbAlertarObservacao.Checked = false;
                    }
                    //
                    if (Convert.ToByte(dr["alertar_estoque"]) == 1)
                    {
                        chkbAlertarEstoque.Checked = true;
                    }
                    else
                    {
                        chkbAlertarEstoque.Checked = false;
                    }
                    //
                    if (Convert.ToByte(dr["dest_est_baixo"]) == 1)
                    {
                        chkbDestEstoqueBaixo.Checked = true;
                    }
                    else
                    {
                        chkbDestEstoqueBaixo.Checked = false;
                    }
                    //
                    if (Convert.ToByte(dr["mostrar_ass_cons"]) == 1)
                    {
                        chkbMostrarAssinatura.Checked = true;
                    }
                    else
                    {
                        chkbMostrarAssinatura.Checked = false;
                    }
                    //
                    if (Convert.ToByte(dr["cont_usuario_vendas"]) == 1)
                    {
                        chkbContUsuarioVend.Checked = true;
                    }
                    else
                    {
                        chkbContUsuarioVend.Checked = false;
                    }
                    //
                    cbbPorta.Text = dr["porta_email"].ToString();
                    txtMargemEsq.Select();
                }
                //
                if (bllConfiguracaoSistema.Sel_Tabela_Configuracao_Local_Configuracoes(bllConexao._Codigo_Conexao) == null)
                {
                    MessageBox.Show("Ainda não foram definidas configurações para esta opção.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    txtMargemEsq.Select();
                }
                else
                {
                    DataRow dr = bllConfiguracaoSistema.Sel_Tabela_Configuracao_Local_Configuracoes(bllConexao._Codigo_Conexao).Rows[0];
                    //
                    if (Convert.ToByte(dr["ativar_letreiro"]) == 1)
                    {
                        chkbAtivarLetreiro.Checked = true;
                    }
                    else
                    {
                        chkbAtivarLetreiro.Checked = false;
                    }
                    //
                    if (Convert.ToByte(dr["ver_data_hora_internet"]) == 1)
                    {
                        chkbVerDataHora.Checked = true;
                    }
                    else
                    {
                        chkbVerDataHora.Checked = false;
                    }
                    //                       
                    txtMargemTopo.Text = dr["margem_topo_pdf"].ToString();
                    if (dr["margem_topo_pdf"].ToString().Contains("-"))
                    {
                        lblMaisMenos2.Text = "-";
                        txtMargemTopo.Text = txtMargemTopo.Text.Replace("-", "");
                    }
                    else
                    {
                        lblMaisMenos2.Text = "+";
                    }
                    //
                    txtMargemEsq.Text = dr["margem_esq_pdf"].ToString();
                    if (dr["margem_esq_pdf"].ToString().Contains("-"))
                    {
                        lblMaisMenos1.Text = "-";
                        txtMargemEsq.Text = txtMargemEsq.Text.Replace("-", "");
                    }
                    else
                    {
                        lblMaisMenos1.Text = "+";
                    }
                    //
                    cbbResolucao.Text = dr["resolucao"].ToString();
                    //                        //
                    if (dr["ajuste_imagem_7_adm"].ToString() != "")
                    {
                        cbbAjusteImagemFundo.Text = dr["ajuste_imagem_7_adm"].ToString();
                    }
                    //
                    if (dr["imagem_fundo_7_adm"].ToString() != "")
                    {
                        lblLegendaImagem.Visible = false;
                        pcibImagem.ImageLocation = dr["imagem_fundo_7_adm"].ToString();
                        _Contem_Imagem = true;
                    }
                    else
                    {
                        lblLegendaImagem.Visible = true;
                        _Contem_Imagem = false;
                    }
                    //
                    cbbTipoImpNotaProm.Text = dr["tipo_impressao_nota_prom"].ToString();
                    //
                    cbbTipoImpOrc.Text = dr["tipo_impressao_orcamento"].ToString();
                    //
                    cbbTipoImpReceber.Text = dr["tipo_impressao_conta_receber"].ToString();
                    //
                    cbbTipoImpDev.Text = dr["tipo_impressao_devolucao"].ToString();
                    //
                    cbbImprimirReceberEm.Text = dr["nome_imp_conta_receber"].ToString();
                    //
                    cbbImprimirDevEm.Text = dr["nome_imp_devolucao"].ToString();
                    //
                    cbbImprimirOrcEm.Text = dr["nome_imp_orcamento"].ToString();
                    //
                    txtMensagem.Text = dr["mensagem"].ToString();
                    //
                    cbbImprimirNNF.Text = dr["nome_imp_nnf"].ToString();
                    //
                    cbbImprimirNotaPromEm.Text = dr["nome_imp_nota_prom"].ToString();
                    //
                    cbbTipoImpressao.Text = dr["tipo_impressao_nnf"].ToString();
                    //
                    txtMargemTopoPDV.Text = dr["margem_topo_pdf_pdv"].ToString();
                    if (dr["margem_topo_pdf_pdv"].ToString().Contains("-"))
                    {
                        lblMaisMenos4.Text = "-";
                        txtMargemTopoPDV.Text = txtMargemTopoPDV.Text.Replace("-", "");
                    }
                    else
                    {
                        lblMaisMenos4.Text = "+";
                    }
                    //
                    txtMargemEsqPDV.Text = dr["margem_esq_pdf_pdv"].ToString();
                    if (dr["margem_esq_pdf_pdv"].ToString().Contains("-"))
                    {
                        lblMaisMenos3.Text = "-";
                        txtMargemEsqPDV.Text = txtMargemEsqPDV.Text.Replace("-", "");
                    }
                    else
                    {
                        lblMaisMenos3.Text = "+";
                    }
                    //
                    txtMargemTopoA4PDV.Text = dr["margem_topo_a4_pdv"].ToString();
                    if (dr["margem_topo_a4_pdv"].ToString().Contains("-"))
                    {
                        lblMaisMenos6.Text = "-";
                        txtMargemTopoA4PDV.Text = txtMargemTopoA4PDV.Text.Replace("-", "");
                    }
                    else
                    {
                        lblMaisMenos6.Text = "+";
                    }
                    //
                    txtMargemEsqA4PDV.Text = dr["margem_esq_a4_pdv"].ToString();
                    if (dr["margem_esq_a4_pdv"].ToString().Contains("-"))
                    {
                        lblMaisMenos5.Text = "-";
                        txtMargemEsqA4PDV.Text = txtMargemEsqA4PDV.Text.Replace("-", "");
                    }
                    else
                    {
                        lblMaisMenos5.Text = "+";
                    }
                    //
                    txtMargemTopo80PDV.Text = dr["margem_topo_80_pdv"].ToString();
                    if (dr["margem_topo_80_pdv"].ToString().Contains("-"))
                    {
                        lblMaisMenos8.Text = "-";
                        txtMargemTopo80PDV.Text = txtMargemTopo80PDV.Text.Replace("-", "");
                    }
                    else
                    {
                        lblMaisMenos8.Text = "+";
                    }
                    //
                    txtMargemEsq80PDV.Text = dr["margem_esq_80_pdv"].ToString();
                    if (dr["margem_esq_80_pdv"].ToString().Contains("-"))
                    {
                        lblMaisMenos7.Text = "-";
                        txtMargemEsq80PDV.Text = txtMargemEsq80PDV.Text.Replace("-", "");
                    }
                    else
                    {
                        lblMaisMenos7.Text = "+";
                    }
                    //
                    if (Convert.ToByte(dr["mostrar_desc_acresc_venda"]) == 1)
                    {
                        chkbMostrarDescAcresc.Checked = true;
                    }
                    else
                    {
                        chkbMostrarDescAcresc.Checked = false;
                    }
                    //
                    if (Convert.ToByte(dr["mostrar_inf_usuario"]) == 1)
                    {
                        chkbMostrarUsuarioCupom.Checked = true;
                    }
                    else
                    {
                        chkbMostrarUsuarioCupom.Checked = false;
                    }
                    //
                    txtMargemEsqNFCe.Text = dr["margem_esq_nfce"].ToString();
                    //
                    txtMargemDirNFCe.Text = dr["margem_dir_nfce"].ToString();
                    //
                    if (Convert.ToByte(dr["buscar_atualizacao"]) == 1)
                    {
                        chkbBuscarAtu.Checked = true;
                    }
                    else
                    {
                        chkbBuscarAtu.Checked = false;
                    }
                    //
                    txtMargemEsq.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConfiguracoes.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmConfiguracoes.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMargemEsq.Text.Trim() == "" || txtMargemTopo.Text.Trim() == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: \n[ Margem Esquerda ], [ Margem Topo ], [ Margem Esquerda PDF 58mm ], [ Margem Topo PDF 58mm ], [ Margem Esquerda PDF 80 mm ], [ Margem Topo PDF 80mm ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtMargemEsq.Select();
                }
                else if (pcibImagem.ImageLocation != "" & cbbAjusteImagemFundo.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: \n[ Tela de fundo 7 ADM ] e [ Ajuste de imagem ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtMargemEsq.Select();
                }
                else
                {
                    bllConfiguracaoSistema.Alterar_Local(lblMaisMenos1.Text + txtMargemEsq.Text.Trim(), lblMaisMenos2.Text + txtMargemTopo.Text.Trim(), lblMaisMenos3.Text + txtMargemEsqPDV.Text.Trim(), lblMaisMenos4.Text + txtMargemTopoPDV.Text.Trim(), lblMaisMenos7.Text + txtMargemEsq80PDV.Text.Trim(), lblMaisMenos8.Text + txtMargemTopo80PDV.Text.Trim(), lblMaisMenos5.Text + txtMargemEsqA4PDV.Text.Trim(), lblMaisMenos6.Text + txtMargemTopoA4PDV.Text.Trim(), false, cbbResolucao.Text, pcibImagem.ImageLocation, cbbAjusteImagemFundo.Text, chkbVerDataHora.Checked, chkbAtivarLetreiro.Checked, false, txtMensagem.Text.Trim(), chkbMostrarDescAcresc.Checked, cbbTipoImpressao.Text, cbbTipoImpNotaProm.Text, cbbTipoImpOrc.Text, cbbTipoImpDev.Text, cbbTipoImpReceber.Text, cbbImprimirNNF.Text, cbbImprimirNotaPromEm.Text, cbbImprimirOrcEm.Text, cbbImprimirDevEm.Text, cbbImprimirReceberEm.Text, bllConexao._Codigo_Conexao, chkbMostrarUsuarioCupom.Checked, txtMargemEsqNFCe.Text, txtMargemDirNFCe.Text, chkbBuscarAtu.Checked);
                    bllConfiguracaoSistema.Alterar_Global(chkbControlarCaixa.Checked, chkbAlertarEstoque.Checked, chkbDestEstoqueBaixo.Checked, chkbAlertarObservacao.Checked, chkbMostrarAssinatura.Checked, chkbContUsuarioVend.Checked, chkbAlterarCodigosID.Checked, cbbPorta.Text, chkbContNFCe.Checked);
                    MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    chkbControlarCaixa.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtImagemLocal7Dir_Enter(object sender, EventArgs e)
        {

        }

        private void txtImagemLocal7Dir_Leave(object sender, EventArgs e)
        {
        }

        private void txtImagemLocal7Dir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

            }
        }

        private void txtImagemLocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

            }
        }


        private void pcibInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("É o caminho onde fica um arquivo txt que contém o ultimo código de uma determinada tabela. Ele é necessário para saber o código da pasta onde serão salvas as imagens.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnCadFuncao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadFuncao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmConfiguracoes_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void FrmConfiguracoes_MouseLeave(object sender, EventArgs e)
        {

        }


        private void chkbUsarVisAdobe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbUsarVisAdobe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos1_MouseMove(object sender, MouseEventArgs e)
        {
            lblMaisMenos1.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void lblMaisMenos1_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos1.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos2_MouseMove(object sender, MouseEventArgs e)
        {
            lblMaisMenos2.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void lblMaisMenos2_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos2.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void txtMargemEsq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMargemTopo.Select();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtMargemTopo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void lblMaisMenos1_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos1.Text == "+")
            {
                lblMaisMenos1.Text = "-";
            }
            else
            {
                lblMaisMenos1.Text = "+";
            }
        }

        private void lblMaisMenos2_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos2.Text == "+")
            {
                lblMaisMenos2.Text = "-";
            }
            else
            {
                lblMaisMenos2.Text = "+";
            }
        }

        private void btnAlterarLocal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterarLocal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterarLocal_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMargemEsq.Text.Trim() == "" || txtMargemTopo.Text.Trim() == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: \n[ Margem Esquerda ], [ Margem Topo ], [ Margem Esquerda PDF 58mm ], [ Margem Topo PDF 58mm ], [ Margem Esquerda PDF 80mm ], [ Margem Topo PDF 80mm ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtMargemEsq.Select();
                }
                else if (pcibImagem.ImageLocation != "" & cbbAjusteImagemFundo.Text == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: \n[ Tela de fundo 7 ADM ] e [ Ajuste de imagem ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtMargemEsq.Select();
                }
                else
                {
                    bllConfiguracaoSistema.Alterar_Local(lblMaisMenos1.Text + txtMargemEsq.Text.Trim(), lblMaisMenos2.Text + txtMargemTopo.Text.Trim(), lblMaisMenos3.Text + txtMargemEsqPDV.Text.Trim(), lblMaisMenos4.Text + txtMargemTopoPDV.Text.Trim(), lblMaisMenos7.Text + txtMargemEsq80PDV.Text.Trim(), lblMaisMenos8.Text + txtMargemTopo80PDV.Text.Trim(), lblMaisMenos5.Text + txtMargemEsqA4PDV.Text.Trim(), lblMaisMenos6.Text + txtMargemTopoA4PDV.Text.Trim(), false, cbbResolucao.Text, pcibImagem.ImageLocation, cbbAjusteImagemFundo.Text, chkbVerDataHora.Checked, chkbAtivarLetreiro.Checked, false, txtMensagem.Text.Trim(), chkbMostrarDescAcresc.Checked, cbbTipoImpressao.Text, cbbTipoImpNotaProm.Text, cbbTipoImpOrc.Text, cbbTipoImpDev.Text, cbbTipoImpReceber.Text, cbbImprimirNNF.Text, cbbImprimirNotaPromEm.Text, cbbImprimirOrcEm.Text, cbbImprimirDevEm.Text, cbbImprimirReceberEm.Text, bllConexao._Codigo_Conexao, chkbMostrarUsuarioCupom.Checked, txtMargemEsqNFCe.Text, txtMargemDirNFCe.Text, chkbBuscarAtu.Checked);
                    MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                    txtMargemEsq.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnAlterarLocal.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do btnAlterarLocal.");
                }
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnSalvarLocal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvarLocal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmConfiguracoes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmConfiguracoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConfiguracoes foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmConfiguracoes foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmConfiguracoes.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmConfiguracoes.");
                }
            }
        }

        private void rbtn800600_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtn800600_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtn1024768_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtn1024768_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void radioButton1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void radioButton1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtn1280720_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtn1280720_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void checkBox2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void checkBox2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void checkBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void checkBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void comboBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbAjusteImagemFundo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbAjusteImagemFundo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbAjusteImagemFundo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImagemLogo_Click(object sender, EventArgs e)
        {
            using (FrmImagemOpcoes Imagem = new FrmImagemOpcoes(_Contem_Imagem, 2))
            {
                if (Imagem.ShowDialog() == DialogResult.OK)
                {
                    if (bllConfiguracaoSistema._Url_Imagem_Comp == null)
                    {
                        pcibImagem.ImageLocation = null;
                        _Contem_Imagem = false;
                        lblLegendaImagem.Visible = true;
                        cbbAjusteImagemFundo.Text = "NORMAL";
                    }
                    else
                    {
                        lblLegendaImagem.Visible = false;
                        pcibImagem.ImageLocation = bllConfiguracaoSistema._Url_Imagem_Comp;
                        _Contem_Imagem = true;
                    }
                }
            }
        }

        private void pcibImagem_Click(object sender, EventArgs e)
        {
            if (_Contem_Imagem == true)
            {
                try
                {
                    Process.Start(pcibImagem.ImageLocation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Sem imagem. Para adicionar uma imagem clique no botão\n[ Adicionar ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblLegendaImagem_Click(object sender, EventArgs e)
        {
            if (_Contem_Imagem == true)
            {
                try
                {
                    Process.Start(pcibImagem.ImageLocation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pcibImagem.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Sem imagem. Para adicionar uma imagem clique no botão\n[ Adicionar ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImagemLogo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImagemLogo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);

            this.Cursor = Cursors.Hand;
        }

        private void lblLegendaImagem_MouseMove(object sender, MouseEventArgs e)
        {
            lblLegendaImagem.ForeColor = Color.Red;
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Underline);

            this.Cursor = Cursors.Hand;
        }

        private void lblLegendaImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            lblLegendaImagem.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void pcibImagem_MouseLeave(object sender, EventArgs e)
        {
            lblLegendaImagem.Font = new Font(lblLegendaImagem.Font.Name, lblLegendaImagem.Font.SizeInPoints, FontStyle.Regular);
            lblLegendaImagem.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpressao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpressao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpressao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpressao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpNotaProm_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpNotaProm_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpNotaProm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpNotaProm_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpOrc_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpOrc_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpDev_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpDev_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpDev_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpDev_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpReceber_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpReceber_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpReceber_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirNNF_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImprimirNNF_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirNotaPromEm_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImprimirNNF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImprimirNNF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirNotaPromEm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImprimirNotaPromEm_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirNotaPromEm_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void cbbImprimirNotaPromEm_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirDevEm_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void cbbImprimirDevEm_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImprimirDevEm_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirDevEm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImprimirDevEm_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirReceberEm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImprimirReceberEm_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpOrc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoImpOrc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirOrcEm_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImprimirOrcEm_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirOrcEm_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbImprimirOrcEm_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirReceberEm_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbImprimirReceberEm_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos3_MouseMove(object sender, MouseEventArgs e)
        {
            lblMaisMenos3.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void lblMaisMenos3_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos3.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos3_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos3.Text == "+")
            {
                lblMaisMenos3.Text = "-";
            }
            else
            {
                lblMaisMenos3.Text = "+";
            }
        }

        private void lblMaisMenos4_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos4.Text == "+")
            {
                lblMaisMenos4.Text = "-";
            }
            else
            {
                lblMaisMenos4.Text = "+";
            }
        }

        private void lblMaisMenos4_MouseMove(object sender, MouseEventArgs e)
        {
            lblMaisMenos4.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void lblMaisMenos4_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos4.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos5_MouseMove(object sender, MouseEventArgs e)
        {
            lblMaisMenos5.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void lblMaisMenos5_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos5.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos6_MouseMove(object sender, MouseEventArgs e)
        {
            lblMaisMenos6.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void lblMaisMenos6_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos6.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos7_MouseMove(object sender, MouseEventArgs e)
        {
            lblMaisMenos7.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void lblMaisMenos7_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos7.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos8_MouseMove(object sender, MouseEventArgs e)
        {
            lblMaisMenos8.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void lblMaisMenos8_MouseLeave(object sender, EventArgs e)
        {
            lblMaisMenos8.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void lblMaisMenos5_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos5.Text == "+")
            {
                lblMaisMenos5.Text = "-";
            }
            else
            {
                lblMaisMenos5.Text = "+";
            }
        }

        private void lblMaisMenos6_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos6.Text == "+")
            {
                lblMaisMenos6.Text = "-";
            }
            else
            {
                lblMaisMenos6.Text = "+";
            }
        }

        private void lblMaisMenos7_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos7.Text == "+")
            {
                lblMaisMenos7.Text = "-";
            }
            else
            {
                lblMaisMenos7.Text = "+";
            }
        }

        private void lblMaisMenos8_Click(object sender, EventArgs e)
        {
            if (lblMaisMenos8.Text == "+")
            {
                lblMaisMenos8.Text = "-";
            }
            else
            {
                lblMaisMenos8.Text = "+";
            }
        }

        private void chkbUsarVisAdobePDV_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbUsarVisAdobePDV_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbAlertarEstoque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbAlertarEstoque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbDestEstoqueBaixo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbDestEstoqueBaixo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbControlarCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbControlarCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpressao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTipoImpressao.SelectedIndex == 1 || cbbTipoImpressao.SelectedIndex == 4)
            {
                cbbImprimirNNF.Enabled = true;
            }
            else
            {
                cbbImprimirNNF.Enabled = false;
                cbbImprimirNNF.Text = null;
            }
        }

        private void cbbTipoImpReceber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTipoImpReceber.SelectedIndex != 1 & cbbTipoImpReceber.SelectedIndex != 2)
            {
                cbbImprimirReceberEm.Enabled = false;
                cbbImprimirReceberEm.Text = null;
            }
            else
            {
                cbbImprimirReceberEm.Enabled = true;
            }
        }

        private void cbbTipoImpDev_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbImprimirDevEm.Enabled = false;
        }

        private void cbbTipoImpOrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTipoImpOrc.SelectedIndex == 1 || cbbTipoImpOrc.SelectedIndex == 4)
            {
                cbbImprimirOrcEm.Enabled = true;
            }
            else
            {
                cbbImprimirOrcEm.Enabled = false;
                cbbImprimirOrcEm.Text = null;
            }
        }

        private void chkAlertarObservacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkAlertarObservacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterarGlobal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterarGlobal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvarGlobal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvarGlobal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMostrarObservacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarObservacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMostrarDescAcresc_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarDescAcresc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoImpNotaProm_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbImprimirNotaPromEm.Enabled = false;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbResolucao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbResolucao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbResolucao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbResolucao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbAjusteImagemFundo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkbMostrarAssinatura_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarAssinatura_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbContUsuarioVend_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbContUsuarioVend_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMostrarUsuarioCupom_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarUsuarioCupom_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRemoverVersoes_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRemoverVersoes_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRemoverVersoes_Click(object sender, EventArgs e)
        {
            DirectoryInfo Dir = new DirectoryInfo(@"C:\Sistema SEVEN\Config\Versoes");

            foreach (FileInfo file in Dir.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo direcetory in Dir.GetDirectories())
            {
                direcetory.Delete(true);
            }
        }

        private void checkBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void checkBox1_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbPorta_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbPorta_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbPorta_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbPorta_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ACBrLib.NFe.Demo.FrmMain Main = new ACBrLib.NFe.Demo.FrmMain(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                {
                    if (Main.ShowDialog() == DialogResult.Abort)
                    {
                        btnConfNFeNFCe.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConfNFeNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConfNFeNFCe.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void chkbContNFCe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbContNFCe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (ACBrLibNCM.Demo.FrmMain Main = new ACBrLibNCM.Demo.FrmMain())
                {
                    if (Main.ShowDialog() == DialogResult.Abort)
                    {
                        btnConfNFeNFCe.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConfNFeNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConfNFeNFCe.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (ACBrLibPIXCD.Demo.FrmMain Main = new ACBrLibPIXCD.Demo.FrmMain(@"C:\Sistema SEVEN\" + bllConexao._Codigo_Conexao + "pix.ini"))
                {
                    if (Main.ShowDialog() == DialogResult.Abort)
                    {
                        btnConfNFeNFCe.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConfNFeNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConfNFeNFCe.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (ACBrLibNFSe.Demo.FrmMain Main = new ACBrLibNFSe.Demo.FrmMain(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfse.ini"))
                {
                    if (Main.ShowDialog() == DialogResult.Abort)
                    {
                        btnConfNFeNFCe.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConfNFeNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConfNFeNFCe.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnConfCNPJ_Click(object sender, EventArgs e)
        {
            try
            {
                using (ACBrLibConsultaCNPJ.Demo.FrmMain Main = new ACBrLibConsultaCNPJ.Demo.FrmMain(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "cnpj.ini"))
                {
                    if (Main.ShowDialog() == DialogResult.Abort)
                    {
                        btnConfCNPJ.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConfCNPJ.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConfCNPJ.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
