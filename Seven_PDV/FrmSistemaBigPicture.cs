using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BLL;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Diagnostics;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using System.Drawing.Printing;
using PdfSharp.Pdf.Security;
using System.Linq;
using ACBrLib.NFe;

namespace Seven_Sistema
{
    public partial class FrmSistemaBigPicture : Form
    {
        public FrmSistemaBigPicture()
        {
            InitializeComponent();
            
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;
        }

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
    int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOOWNERZORDER = 0x0200;
        private const uint SWP_SHOWWINDOW = 0x0040;

        private Point ultimaPosicaoMouse;
        private int segundosSemTecla = 0;
        private bool _VerificarNomeComputador;
        private string _Ult_Codigo_DFe;
        private string _Caminho_Imagem;
        private string _Versao = "1.0.22";
        private bool _Sleep = true;
        private bool _Mostrar_Mensagem = false;
        private int _Tempo_Mostrar_Atualizacao = 0;
        private bool _Reiniciar = false;
        private bool _Atualizacao_Disponivel = false;
        private byte _Trabalho;
        private string _Quantidade = "1";
        private string _Tipo_Venda;
        private bool _Acesso_Negado = false;
        private bool _Devolucao, _Orcamento, _Venda;
        private string _Cod_Venda, _Data, _Hora, _Valor_Desconto_Venda, _Valor_Desconto_Item, _Valor_Acrescimo_Venda, _Valor_Acrescimo_Item, _Valor, _Valor_Real, _Troco, _Cod_Consumidor, _Nome_Consumidor, _CPF_CNPJ_Consumidor, _Cod_Usuario, _Nome_Usuario, _Cod_Conta_Receber, _Desconto_Porc, _Acrescimo_Porc;
        private bool _NFCe_Ativo;
        private int _Tempo_Mostrar_Logado = 86400;
        private int _ContMostrar_Logado = 0;

        private void FrmPesqPDVCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                if (bllCadastroComputadores.Sel_Computadores_Ver_Codigo(Environment.MachineName) == null)
                {
                    MessageBox.Show("Este computador não se encontra na lista de dispositivos cadastrados neste banco de dados, contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _Acesso_Negado = true;
                    Application.Exit();
                }
                else if (bllConexao.Sel_Computadores_Op_Ver_Codigo(bllConexao._Descricao_Entidade) != Environment.MachineName)
                {
                    MessageBox.Show("Este computador não se encontra na lista de dispositivos cadastrados, contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _Acesso_Negado = true;
                    Application.Exit();
                }
                else
                {
                    tData.Start();
                    lblDataCaixaLivre.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    lblDataCaixaFechado.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    //
                    lblEmpresa.Text = bllMinhaEmpresa.Sel_Nome_Empresa();
                    //
                    _Tipo_Venda = bllConfiguracaoSistema.Sel_Tipo_Documento_Venda(bllConexao._Codigo_Conexao);
                    if (_Tipo_Venda == "DAV")
                    {
                        _Tipo_Venda = "DAV";
                        lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** DAV **\r\n-------------------------------------------";
                        //
                        lblContAtiva.Visible = false;
                    }
                    else if (_Tipo_Venda == "NFCe")
                    {
                        _Tipo_Venda = "NFCe";
                        lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFCe **\r\n-------------------------------------------";
                        //
                        if (bllConfiguracaoSistema.Sel_Contingencia_NFCe() == true)
                        {
                            lblContAtiva.Visible = true;
                        }
                        else
                        {
                            lblContAtiva.Visible = false;
                        }
                    }
                    else if (_Tipo_Venda == "NFe")
                    {
                        _Tipo_Venda = "NFe";
                        lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFe **\r\n-------------------------------------------";
                        //
                        lblContAtiva.Visible = false;
                    }
                    //
                    lblUsuario.Text = "Usuário(a): " + bllConexao._Usuario;
                    //
                    txtProduto.Select();
                    //
                    DataRow drComp = bllCadastroComputadores.Sel_Computadores_Ver_Codigo(Environment.MachineName).Rows[0];
                    //
                    lblVersao.Text = "Versão: " + _Versao + "/Nº PDV: " + drComp["id_cadastro_computadores"].ToString();
                    //
                    lblEmpresa.Text = bllMinhaEmpresa.Sel_Nome_Empresa().Replace("&", "&&");
                    //
                    string[] items = lblUsuario.Text.Remove(0, 12).Split('—');
                    //
                    bllRegistroAtividades.Salvar("O USUARIO " + lblUsuario.Text.Remove(0, 12) + " LOGOU NO SISTEMA SEVEN PDV.", "USUARIO", "0", lblUsuario.Text, lblVersao.Text);
                    //
                    bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(null, null);
                    //
                    bllVenda.Excluir_Venda_Atual_PDV("Tabela[1]", bllConexao._Codigo_Conexao);
                    //
                    bllVenda.Excluir_Consumidor_PDV("Tabela[1]", bllConexao._Codigo_Conexao);
                    //
                    if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(lblVersao.Text) == 0)
                    {
                        if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                        {
                            DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                            //
                            if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                            {
                                if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                {
                                    bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                    //
                                    lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                }
                                else
                                {
                                    lblDescCliente.Text = "Consumidor: Não identificado.";
                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                }
                                //
                                if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                {
                                    dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                    //
                                    dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                    //
                                    dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                    //
                                    dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                    //
                                    DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                    //
                                    lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                    //
                                    txtProduto.Text = null;
                                    //
                                    txtProduto.Select();
                                    //
                                    pPanelCaixaLivre.Visible = false;
                                    pPanelCaixaFechado.Visible = false;
                                }
                                else
                                {
                                    txtProduto.Text = null;
                                    //
                                    txtProduto.Select();
                                    //
                                    pPanelCaixaLivre.BringToFront();
                                    pPanelCaixaLivre.Visible = true;
                                    pPanelCaixaFechado.Visible = false;
                                }
                            }
                            else if (dr["id_devolucao"].ToString() != "0")
                            {
                                bllVenda._Cod_Devolucao = dr["id_devolucao"].ToString();
                                //
                                _Devolucao = true;
                                //
                                if (dr["valor_desconto_devolucao"].ToString() != "0")
                                {
                                    bllVenda._Valor_Desconto_Devolucao = dr["valor_desconto_devolucao"].ToString();
                                }
                                else
                                {
                                    bllVenda._Valor_Desconto_Devolucao = null;
                                }
                                //
                                if (bllDevolucao.Sel_Dados_Devolucao(bllVenda._Cod_Devolucao) != null)
                                {
                                    dr = bllDevolucao.Sel_Dados_Devolucao(bllVenda._Cod_Devolucao).Rows[0];
                                    //
                                    if (Convert.ToDecimal(dr["valor_devolvido"]) < 0)
                                    {
                                        bllVenda._Valor_Desconto_Devolucao = Convert.ToDecimal(dr["valor_devolvido"]).ToString("n2", new CultureInfo("pt-BR")).Replace("-", "");
                                    }
                                    //
                                    if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                    {
                                        bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                        //
                                        lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor"].ToString();
                                    }
                                    else
                                    {
                                        lblDescCliente.Text = "Consumidor: Não identificado.";
                                    }
                                    //
                                    if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                    {
                                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                        //
                                        dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                        //
                                        dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                        //
                                        dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                        //
                                        DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                        //
                                        lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                    }
                                    //
                                    pPanelCaixaLivre.Visible = false;
                                    pPanelCaixaFechado.Visible = false;
                                }
                                else
                                {
                                    MessageBox.Show("Não foram encontrados os dados da devolução.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    //
                                    txtProduto.Text = null;
                                    //
                                    txtProduto.Select();
                                    //
                                    pPanelCaixaLivre.BringToFront();
                                    pPanelCaixaLivre.Visible = true;
                                    pPanelCaixaFechado.Visible = false;
                                }
                            }
                            else if (dr["id_orcamento"].ToString() != "0")
                            {
                                bllVenda._Cod_Orcamento = dr["id_orcamento"].ToString();
                                //
                                _Orcamento = true;
                                //
                                MessageBox.Show(bllVenda._Cod_Orcamento);

                                if (bllOrcamento.Sel_Dados_Orcamento(bllVenda._Cod_Orcamento) != null)
                                {
                                    dr = bllOrcamento.Sel_Dados_Orcamento(bllVenda._Cod_Orcamento).Rows[0];
                                    //
                                    if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                    {
                                        bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                        //
                                        lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor"].ToString();
                                    }
                                    else
                                    {
                                        lblDescCliente.Text = "Consumidor: Não identificado.";
                                    }
                                    //
                                    if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                    {
                                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                        //
                                        dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                        //
                                        dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                        //
                                        dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                        //
                                        DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                        //
                                        lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                    }
                                    //
                                    pPanelCaixaLivre.Visible = false;
                                    pPanelCaixaFechado.Visible = false;
                                }
                                else
                                {
                                    MessageBox.Show("Não foram encontrados os dados do orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    //
                                    txtProduto.Text = null;
                                    //
                                    txtProduto.Select();
                                    //
                                    pPanelCaixaLivre.BringToFront();
                                    pPanelCaixaLivre.Visible = true;
                                    pPanelCaixaFechado.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                            //
                            bllVenda._PDV_PesqCliente_Tabela = null;
                            //
                            txtProduto.Select();
                            //
                            pPanelCaixaLivre.BringToFront();
                            pPanelCaixaLivre.Visible = true;
                            pPanelCaixaFechado.Visible = false;
                        }
                    }
                    else if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(lblVersao.Text) == 1)
                    {
                        if (bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) == null)
                        {
                            bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                        }
                        //
                        txtProduto.Text = null;
                        txtQuantidade.Text = null;
                        txtUnitario.Text = null;
                        lblValorTotalunit.Text = "0,00";
                        lblDescCliente.Text = "Consumidor: Não identificado.";
                        lblQuantidadeItem.Text = "0";
                        lblValorTotal.Text = "0,00";
                        lblValorTotalunit.Text = "0,00";
                        dtItems.DataSource = null;
                        //
                        pPanelCaixaLivre.BringToFront();
                        pPanelCaixaLivre.Visible = true;
                    }
                    else
                    {
                        txtProduto.Text = null;
                        txtQuantidade.Text = null;
                        txtUnitario.Text = null;
                        lblValorTotalunit.Text = "0,00";
                        lblDescCliente.Text = "Consumidor: Não identificado.";
                        lblQuantidadeItem.Text = "0";
                        lblValorTotal.Text = "0,00";
                        lblValorTotalunit.Text = "0,00";
                        dtItems.DataSource = null;
                        //
                        pPanelCaixaFechado.BringToFront();
                        pPanelCaixaFechado.Visible = true;
                    }
                    //
                    if (bllLicenca.Verificar_Data_Licenca() != null)
                    {
                        DataRow drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                        //
                        if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 0)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("hoje em", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 1)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 1 dia.", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 2)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 2 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 3)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 3 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 4)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 4 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 5)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 5 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //
                    //
                    if (bllConfiguracaoSistema.Sel_Buscar_Atualizacoes(bllConexao._Codigo_Conexao) == true)
                    {
                        bckwInicio.RunWorkerAsync();
                        bckwIndeterminado.RunWorkerAsync();
                    }
                    //
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Normal;
                    this.Bounds = Screen.PrimaryScreen.Bounds;
                    //
                    SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0,
                        Screen.PrimaryScreen.Bounds.Width,
                        Screen.PrimaryScreen.Bounds.Height,
                        SWP_NOZORDER | SWP_NOOWNERZORDER | SWP_SHOWWINDOW);
                    //
                    ACBrNFe ACBrNFe;
                    if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                    {
                        ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                    }
                    else
                    {
                        ACBrNFe = new ACBrNFe();
                    }
                    //
                    if (ACBrNFe.Config.DFe.ArquivoPFX != "")
                    {
                        var ret = ACBrNFe.ObterCertificados();
                        //
                        string datavalidade = string.Join(Environment.NewLine, ret.Select(x => x.Vencimento.ToString()).ToArray());
                        //
                        if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays < 0)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual está expirado desde " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual está expirado desde " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual está expirado desde " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 0)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar hoje " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar hoje " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar hoje " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 1)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar amanhã " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar amanhã " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar amanhã " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 2)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 1 dia " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 1 dia " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 1 dia " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 3)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 2 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 2 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 2 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 4)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 3 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 3 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 3 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 5)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 4 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 4 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 4 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 6)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 5 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 5 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 5 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 7)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 6 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 6 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 6 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 8)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 7 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 7 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 7 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 9)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 8 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 8 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 8 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 10)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 9 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 9 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 9 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo um novoovar para continuar a emissão de NFe/NFCe/NFSe.\n\nContate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 11)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 10 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 10 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 10 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 12)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 11 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 11 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 11 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 13)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 12 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 12 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 12 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 14)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 13 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 13 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 13 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 15)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 14 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 14 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 14 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            bllLetreiro.Excluir_Letreiro("CERTIFICADO");
                        }
                    }
                    //
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do FrmSistema.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do FrmSistema.");
                }
            }
        }

        private void Menu_BigPicture() 
        {
            using (FrmMenuBigPicture Menu = new FrmMenuBigPicture(lblVersao.Text))
            {
                if (Menu.ShowDialog() == DialogResult.OK)
                {
                    if (bllVenda._Opcao_Menu_BigPicture == 1)
                    {
                        if (bllUsuario.Sel_Reallizar_Abert_Caixa_Usuario(lblUsuario.Text) == true)
                        {
                            this.Enabled = false;
                            using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                            {
                                if (Abrir.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                                    {
                                        DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                        //
                                        if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                        {
                                            if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                            {
                                                bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                                //
                                                lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                                //
                                            }
                                            else
                                            {
                                                lblDescCliente.Text = "Consumidor: Não identificado.";
                                                bllVenda._PDV_PesqCliente_Tabela = null;
                                            }
                                            //
                                            if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                            {
                                                dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                                //
                                                dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                                //
                                                dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                                //
                                                dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                                //
                                                DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                                //
                                                lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                            }
                                            //
                                            txtProduto.Text = null;
                                            //
                                            txtProduto.Select();
                                            //
                                            pPanelCaixaLivre.BringToFront();
                                            pPanelCaixaLivre.Visible = true;
                                            pPanelCaixaFechado.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                        //
                                        bllVenda._PDV_PesqCliente_Tabela = null;
                                        //
                                        txtProduto.Select();
                                        //
                                        pPanelCaixaLivre.BringToFront();
                                        pPanelCaixaLivre.Visible = true;
                                        pPanelCaixaFechado.Visible = false;

                                    }
                                }
                            }
                            this.Enabled = true;
                        }
                        else
                        {
                            this.Enabled = false;
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Abrir_Caixa"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Abrir_Caixa == 1)
                                    {
                                        using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                                        {
                                            if (Abrir.ShowDialog() == DialogResult.OK)
                                            {
                                                if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                                                {
                                                    DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                                    //
                                                    if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                                    {
                                                        if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                                        {
                                                            bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                                            //
                                                            lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                                        }
                                                        else
                                                        {
                                                            lblDescCliente.Text = "Consumidor: Não identificado.";
                                                            bllVenda._PDV_PesqCliente_Tabela = null;
                                                        }
                                                        //
                                                        if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                                        {
                                                            dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                                            //
                                                            dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                                            //
                                                            dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                                            //
                                                            dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                                            //
                                                            DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                                            //
                                                            lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                                            //
                                                        }
                                                        //
                                                        txtProduto.Text = null;
                                                        //
                                                        txtProduto.Select();
                                                        //
                                                        pPanelCaixaLivre.BringToFront();
                                                        pPanelCaixaLivre.Visible = true;
                                                        pPanelCaixaFechado.Visible = false;
                                                    }
                                                }
                                                else
                                                {
                                                    bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                                    //
                                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                                    //
                                                    txtProduto.Select();
                                                    //
                                                    pPanelCaixaLivre.BringToFront();
                                                    pPanelCaixaLivre.Visible = true;
                                                    pPanelCaixaFechado.Visible = false;
                                                }
                                            }
                                        }
                                    }
                                    else if (bllVenda._Permitir_Abrir_Caixa == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para realizar Abertura de Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                            this.Enabled = true;
                        }
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 2)
                    {
                        if (bllUsuario.Sel_Reallizar_Pausa_Caixa_Usuario(lblUsuario.Text) == true)
                        {
                            string mensagem;
                            //
                            if (lblMensagemTopo.Text == "CAIXA PAUSADO")
                            {
                                mensagem = "Deseja retomar o Caixa?";
                            }
                            else
                            {
                                mensagem = "Deseja realmente pausar o Caixa?";
                            }
                            //
                            DialogResult = MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {

                                Form[] mdichild = this.MdiChildren;

                                if (this.MdiChildren.Length > 0)
                                {
                                    MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else if (dtItems.DataSource != null)
                                {
                                    MessageBox.Show("Por favor, finalize ou cancele os itens de uma possível venda antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    if (lblMensagemTopo.Text == "CAIXA PAUSADO")
                                    {
                                        bllAbert_Fech_Caixa.Alterar_Abertura_Abrir(lblVersao.Text, "ABERTO");
                                        //
                                        bllRegistroAtividades.Salvar("RETOMOU O CAIXA.", "ABERT/FECH/CAIXA", "0", lblUsuario.Text, lblVersao.Text);
                                        //
                                        txtProduto.Select();
                                    }
                                    else
                                    {
                                        bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                        bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                        bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                                        bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                                        //
                                        bllVenda._Quantidade = null;
                                        bllVenda._Total = null;
                                        bllVenda._Total_Real = null;
                                        bllVenda._PDV_PesqForma_Tabela = null;
                                        bllVenda._Desconto_Porc = null;
                                        bllVenda._Valor_Desconto = null;
                                        bllVenda._Acrescimo_Porc = null;
                                        bllVenda._Valor_Acrescimo = null;
                                        bllVenda._Troco = null;
                                        bllVenda._Observacao = null;
                                        bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                                        bllVenda._N_Parcela = null;
                                        bllVenda._Descricao_Produto = null;
                                        bllVenda._PDV_Forma_Pagamento.Clear();
                                        bllVenda._Dados_Cheque.Clear();
                                        bllVenda._PDV_PesqCliente_Tabela = null;
                                        bllVenda._Valor_Credito_Loja = null;
                                        bllVenda._Valor_Cheque = null;
                                        bllVenda._Valor_Desconto_Devolucao = null;
                                        //
                                        _Quantidade = "1";
                                        //
                                        lblMensagemTopo.Font = new Font("Calibri", 44, FontStyle.Bold);
                                        lblMensagemTopo.ForeColor = Color.Goldenrod;
                                        lblMensagemTopo.Text = "CAIXA PAUSADO";
                                        //
                                        txtProduto.Text = null;
                                        txtQuantidade.Text = null;
                                        txtUnitario.Text = null;
                                        lblDescCliente.Text = "Consumidor: Não identificado.";
                                        lblQuantidadeItem.Text = "0";
                                        lblValorTotal.Text = "R$ 0,00";
                                        dtItems.DataSource = null;
                                        //
                                        bllAbert_Fech_Caixa.Alterar_Abertura_Pausa(lblVersao.Text, "PAUSADO");
                                        //
                                        bllRegistroAtividades.Salvar("PAUSOU O CAIXA.", "ABERT/FECH/CAIXA", "0", lblUsuario.Text, lblVersao.Text);
                                        //
                                        MessageBox.Show("O caixa foi pausado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                if (txtProduto.Enabled != false)
                                {
                                    txtProduto.Select();
                                }
                            }
                        }
                        else
                        {
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Pausar_Caixa"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Pausar_Caixa == 1)
                                    {
                                        string mensagem;
                                        //
                                        if (lblMensagemTopo.Text == "CAIXA PAUSADO")
                                        {
                                            mensagem = "Deseja retomar o Caixa?";
                                        }
                                        else
                                        {
                                            mensagem = "Deseja realmente pausar o Caixa?";
                                        }
                                        //
                                        DialogResult = MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (DialogResult == DialogResult.Yes)
                                        {
                                            Form[] mdichild = this.MdiChildren;

                                            if (this.MdiChildren.Length > 0)
                                            {
                                                MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                            else if (dtItems.DataSource != null)
                                            {
                                                MessageBox.Show("Por favor, finalize ou cancele os itens de uma possível venda antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                            else
                                            {
                                                if (lblMensagemTopo.Text == "CAIXA PAUSADO")
                                                {
                                                    bllAbert_Fech_Caixa.Alterar_Abertura_Abrir(lblVersao.Text, "ABERTO");
                                                    //
                                                    bllRegistroAtividades.Salvar("RETOMOU O CAIXA.", "ABERT/FECH/CAIXA", "0", lblUsuario.Text, lblVersao.Text);
                                                    //
                                                    txtProduto.Select();
                                                }
                                                else
                                                {
                                                    bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                                    bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                                    bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                                                    bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                                                    //
                                                    bllVenda._Quantidade = null;
                                                    bllVenda._Total = null;
                                                    bllVenda._Total_Real = null;
                                                    bllVenda._PDV_PesqForma_Tabela = null;
                                                    bllVenda._Desconto_Porc = null;
                                                    bllVenda._Valor_Desconto = null;
                                                    bllVenda._Acrescimo_Porc = null;
                                                    bllVenda._Valor_Acrescimo = null;
                                                    bllVenda._Troco = null;
                                                    bllVenda._Observacao = null;
                                                    bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                                                    bllVenda._N_Parcela = null;
                                                    bllVenda._Descricao_Produto = null;
                                                    bllVenda._PDV_Forma_Pagamento.Clear();
                                                    bllVenda._Dados_Cheque.Clear();
                                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                                    bllVenda._Valor_Credito_Loja = null;
                                                    bllVenda._Valor_Cheque = null;
                                                    bllVenda._Valor_Desconto_Devolucao = null;
                                                    //
                                                    _Quantidade = "1";
                                                    //
                                                    lblMensagemTopo.Font = new Font("Calibri", 44, FontStyle.Bold);
                                                    lblMensagemTopo.ForeColor = Color.Goldenrod;
                                                    lblMensagemTopo.Text = "CAIXA PAUSADO";
                                                    //
                                                    txtProduto.Text = null;
                                                    txtQuantidade.Text = null;
                                                    txtUnitario.Text = null;
                                                    lblDescCliente.Text = "Consumidor: Não identificado.";
                                                    lblQuantidadeItem.Text = "0";
                                                    lblValorTotal.Text = "R$ 0,00";
                                                    dtItems.DataSource = null;
                                                    //
                                                    bllAbert_Fech_Caixa.Alterar_Abertura_Pausa(lblVersao.Text, "PAUSADO");
                                                    //
                                                    bllRegistroAtividades.Salvar("PAUSOU O CAIXA.", "ABERT/FECH/CAIXA", "0", lblUsuario.Text, lblVersao.Text);
                                                    //
                                                    MessageBox.Show("O caixa foi pausado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (txtProduto.Enabled != false)
                                            {
                                                txtProduto.Select();
                                            }
                                        }
                                    }
                                    else if (bllVenda._Permitir_Pausar_Caixa == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para realizar Pausa do Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                        }
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 3)
                    {
                        this.Enabled = false;
                        if (bllUsuario.Sel_Reallizar_Fechamento_Caixa_Usuario(lblUsuario.Text) == true)
                        {
                            Form[] mdichild = this.MdiChildren;

                            if (this.MdiChildren.Length > 0)
                            {
                                MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dtItems.DataSource != null)
                            {
                                MessageBox.Show("Por favor, finalize ou cancele os itens de uma possível venda antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                using (FrmFecharCaixa Fechar = new FrmFecharCaixa(lblUsuario.Text, lblVersao.Text))
                                {
                                    if (Fechar.ShowDialog() == DialogResult.OK)
                                    {
                                        bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                        bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                        bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                                        bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                                        bllVenda.Excluir_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                        //
                                        bllVenda._Quantidade = null;
                                        bllVenda._Total = null;
                                        bllVenda._Total_Real = null;
                                        bllVenda._PDV_PesqForma_Tabela = null;
                                        bllVenda._Desconto_Porc = null;
                                        bllVenda._Valor_Desconto = null;
                                        bllVenda._Acrescimo_Porc = null;
                                        bllVenda._Valor_Acrescimo = null;
                                        bllVenda._Troco = null;
                                        bllVenda._Observacao = null;
                                        bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                                        bllVenda._N_Parcela = null;
                                        bllVenda._Descricao_Produto = null;
                                        bllVenda._PDV_Forma_Pagamento.Clear();
                                        bllVenda._Dados_Cheque.Clear();
                                        bllVenda._PDV_PesqCliente_Tabela = null;
                                        bllVenda._Valor_Credito_Loja = null;
                                        bllVenda._Valor_Cheque = null;
                                        bllVenda._Valor_Desconto_Devolucao = null;
                                        _Quantidade = "1";
                                        //
                                        txtProduto.Text = null;
                                        txtQuantidade.Text = null;
                                        txtUnitario.Text = null;
                                        lblDescCliente.Text = "Consumidor: Não identificado.";
                                        lblQuantidadeItem.Text = "0";
                                        lblValorTotal.Text = "0,00";
                                        lblValorTotalunit.Text = "0,00";
                                        dtItems.DataSource = null;
                                        //
                                        pPanelCaixaFechado.BringToFront();
                                        pPanelCaixaFechado.Visible = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Fechar_Caixa"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Fechar_Caixa == 1)
                                    {
                                        using (FrmFecharCaixa Fechar = new FrmFecharCaixa(lblUsuario.Text, lblVersao.Text))
                                        {
                                            if (Fechar.ShowDialog() == DialogResult.OK)
                                            {
                                                bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                                bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                                bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                                                bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                                                bllVenda._Quantidade = null;
                                                bllVenda._Total = null;
                                                bllVenda._Total_Real = null;
                                                bllVenda._PDV_PesqForma_Tabela = null;
                                                bllVenda._Desconto_Porc = null;
                                                bllVenda._Valor_Desconto = null;
                                                bllVenda._Acrescimo_Porc = null;
                                                bllVenda._Valor_Acrescimo = null;
                                                bllVenda._Troco = null;
                                                bllVenda._Observacao = null;
                                                bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                                                bllVenda._N_Parcela = null;
                                                bllVenda._Descricao_Produto = null;
                                                bllVenda._PDV_Forma_Pagamento.Clear();
                                                bllVenda._Dados_Cheque.Clear();
                                                bllVenda._PDV_PesqCliente_Tabela = null;
                                                bllVenda._Valor_Credito_Loja = null;
                                                bllVenda._Valor_Cheque = null;
                                                bllVenda._Valor_Desconto_Devolucao = null;
                                                _Quantidade = "1";
                                                //
                                                txtProduto.Text = null;
                                                txtQuantidade.Text = null;
                                                txtUnitario.Text = null;
                                                lblDescCliente.Text = "Consumidor: Não identificado.";
                                                lblQuantidadeItem.Text = "0";
                                                lblValorTotal.Text = "0,00";
                                                lblValorTotalunit.Text = "0,00";
                                                dtItems.DataSource = null;
                                                //
                                                pPanelCaixaFechado.BringToFront();
                                                pPanelCaixaFechado.Visible = true;
                                            }
                                        }
                                    }
                                    else if (bllVenda._Permitir_Fechar_Caixa == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para realizar Fechamento do Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                        }
                        this.Enabled = true;
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 4)
                    {
                        if (bllLicenca.Verificar_Data_Licenca() != null)
                        {
                            DataRow drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                            //
                            if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 0)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("hoje em", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 1)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 1 dia.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 2)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 2 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 3)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 3 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 4)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 4 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 5)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 5 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                        if (bllUsuario.Sel_Reallizar_Recebimento_Usuario(lblUsuario.Text) == true)
                        {
                            this.Enabled = false;
                            using (FrmRelContaReceber Conta = new FrmRelContaReceber(lblUsuario.Text, lblVersao.Text))
                            {
                                if (Conta.ShowDialog() == DialogResult.Abort)
                                {
                                    txtProduto.Select();
                                }
                            }
                            this.Enabled = true;
                        }
                        else
                        {
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Real_Conta_Receber"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Real_Conta_Receber == 1)
                                    {
                                        this.Enabled = false;
                                        using (FrmRelContaReceber Conta = new FrmRelContaReceber(lblUsuario.Text, lblVersao.Text))
                                        {
                                            if (Conta.ShowDialog() == DialogResult.Abort)
                                            {
                                                txtProduto.Select();
                                            }
                                        }
                                        this.Enabled = true;
                                    }
                                    else if (bllVenda._Permitir_Real_Conta_Receber == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para realizar Recebimentos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                        }
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 5)
                    {
                        if (bllLicenca.Verificar_Data_Licenca() != null)
                        {
                            DataRow drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                            //
                            if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 0)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("hoje em", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 1)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 1 dia.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 2)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 2 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 3)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 3 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 4)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 4 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 5)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 5 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                        if (bllUsuario.Sel_Reallizar_Pagamento_Usuario(lblUsuario.Text) == true)
                        {
                            using (FrmRelContaPagar Conta = new FrmRelContaPagar(lblUsuario.Text, lblVersao.Text))
                            {
                                this.Enabled = false;
                                if (Conta.ShowDialog() == DialogResult.Abort)
                                {
                                    txtProduto.Select();
                                }
                                this.Enabled = true;
                            }
                        }
                        else
                        {
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Real_Conta_Pagar"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Real_Conta_Pagar == 1)
                                    {
                                        this.Enabled = false;
                                        using (FrmRelContaPagar Conta = new FrmRelContaPagar(lblUsuario.Text, lblVersao.Text))
                                        {
                                            if (Conta.ShowDialog() == DialogResult.Abort)
                                            {
                                                txtProduto.Select();
                                            }
                                        }
                                        this.Enabled = true;
                                    }
                                    else if (bllVenda._Permitir_Real_Conta_Pagar == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para realizar Pagamentos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                        }
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 6)
                    {
                        if (bllLicenca.Verificar_Data_Licenca() != null)
                        {
                            DataRow drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                            //
                            if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 0)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("hoje em", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 1)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 1 dia.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 2)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 2 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 3)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 3 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 4)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 4 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 5)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 5 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                        this.Enabled = false;
                        using (FrmRelOrcamento Orc = new FrmRelOrcamento(lblUsuario.Text, lblVersao.Text))
                        {
                            if (Orc.ShowDialog() == DialogResult.Abort)
                            {
                                txtProduto.Select();
                            }
                        }
                        this.Enabled = true;
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 8)
                    {
                        if (bllLicenca.Verificar_Data_Licenca() != null)
                        {
                            DataRow drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                            //
                            if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 0)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("hoje em", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 1)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 1 dia.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 2)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 2 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 3)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 3 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 4)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 4 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                            else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 5)
                            {
                                using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 5 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                                {
                                    if (LicEx.ShowDialog() == DialogResult.Yes)
                                    {
                                        using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                        {
                                            if (Lic.ShowDialog() == DialogResult.OK)
                                            {
                                                drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                                //
                                                MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                        this.Enabled = false;
                        using (FrmRelDevolucao Dev = new FrmRelDevolucao(lblUsuario.Text, lblVersao.Text))
                        {
                            if (Dev.ShowDialog() == DialogResult.Abort)
                            {
                                txtProduto.Select();
                            }
                        }
                        this.Enabled = true;
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 9)
                    {
                        if (bllUsuario.Sel_Reallizar_SangSup_Usuario(lblUsuario.Text) == true)
                        {
                            using (FrmSangriaSuprimento Sang = new FrmSangriaSuprimento(lblUsuario.Text, lblVersao.Text, 0, null))
                            {
                                if (Sang.ShowDialog() == DialogResult.Abort)
                                {
                                    txtProduto.Select();
                                }
                            }
                        }
                        else
                        {
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Real_SangSup"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Real_SangSup == 1)
                                    {
                                        using (FrmSangriaSuprimento Sang = new FrmSangriaSuprimento(lblUsuario.Text, lblVersao.Text, 0, null))
                                        {
                                            if (Sang.ShowDialog() == DialogResult.Abort)
                                            {
                                                txtProduto.Select();
                                            }
                                        }
                                    }
                                    else if (bllVenda._Permitir_Real_SangSup == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para realizar Sangria/Suprimento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                        }
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 10)
                    {
                        if (bllUsuario.Sel_Visualizar_Hist_Caixa_Usuario(lblUsuario.Text) == true)
                        {
                            string datainicio = null;
                            string horainicio = null;
                            string datafim = null;
                            string horafim = null;
                            //
                            if (bllUsuario.Sel_Reallizar_Abert_Caixa_Usuario(lblUsuario.Text) == true)
                            {
                                DataRow dr = bllAbert_Fech_Caixa.Sel_Data_Ultimo_Fech_Caixa_PDV(lblVersao.Text).Rows[0];
                                //
                                datainicio = dr["data_abertura"].ToString().Remove(10);
                                //
                                horainicio = dr["hora_abertura"].ToString();
                                //
                                datafim = DateTime.Now.ToShortDateString();
                                //
                                horafim = DateTime.Now.ToLongTimeString();
                                //
                                MessageBox.Show("A data de abertura do caixa será informada automaticamente\n[ Data de Abertura ] até [ Data Atual ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //
                            using (FrmRelHistCaixa Caix = new FrmRelHistCaixa(datainicio, datafim, horainicio, horafim, lblVersao.Text, lblUsuario.Text, lblVersao.Text, 2))
                            {
                                if (Caix.ShowDialog() == DialogResult.Abort)
                                {
                                    if (txtProduto.Enabled == true)
                                    {
                                        txtProduto.Select();
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.Enabled = false;
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Vis_Hist_Caixa"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Vis_Hist_Caixa == 1)
                                    {
                                        string datainicio = null;
                                        string horainicio = null;
                                        string datafim = null;
                                        string horafim = null;
                                        //
                                        if (bllUsuario.Sel_Reallizar_Abert_Caixa_Usuario(lblUsuario.Text) == true)
                                        {
                                            DataRow dr = bllAbert_Fech_Caixa.Sel_Data_Ultimo_Fech_Caixa_PDV(lblVersao.Text).Rows[0];
                                            //
                                            datainicio = dr["data_abertura"].ToString().Remove(10);
                                            //
                                            horainicio = dr["hora_abertura"].ToString();
                                            //
                                            datafim = DateTime.Now.ToShortDateString();
                                            //
                                            horafim = DateTime.Now.ToLongTimeString();
                                            //
                                            MessageBox.Show("A data de abertura do caixa será informada automaticamente\n[ Data de Abertura ] até [ Data Atual ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        //
                                        using (FrmRelHistCaixa Caix = new FrmRelHistCaixa(datainicio, datafim, horainicio, horafim, lblVersao.Text, lblUsuario.Text, lblVersao.Text, 2))
                                        {
                                            if (Caix.ShowDialog() == DialogResult.Abort)
                                            {
                                                if (txtProduto.Enabled == true)
                                                {
                                                    txtProduto.Select();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para visualizar o Histórico do Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                            this.Enabled = true;
                        }
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 11)
                    {
                        this.Enabled = false;
                        using (FrmObservacao Obs = new FrmObservacao(lblUsuario.Text, lblVersao.Text))
                        {
                            if (Obs.ShowDialog() == DialogResult.OK)
                            {
                                txtProduto.Select();
                            }
                            else
                            {
                                txtProduto.Select();
                            }
                        }
                        this.Enabled = true;
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 12)
                    {
                        if (bllClieCons._FrmCadClieCons_Ativo == false)
                        {
                            if (bllUsuario.Sel_Cadastrar_Cliente_Consumidor(lblUsuario.Text) == true)
                            {
                                this.Enabled = false;
                                using (FrmMenuNFeNFCe MenuNFeNFCe = new FrmMenuNFeNFCe(lblUsuario.Text, lblVersao.Text, 0, null))
                                {
                                    if (MenuNFeNFCe.ShowDialog() == DialogResult.Abort)
                                    {
                                        txtProduto.Select();
                                    }
                                }
                                this.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("O Usuário atual não possui permissão para visualizar Menu NFe/NFCe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 13)
                    {
                        try
                        {
                            if (bckwIndeterminado.IsBusy == true)
                            {
                                MessageBox.Show("Sua solicitação está sendo processada. Por favor, aguarde um momento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                _Mostrar_Mensagem = true;
                                //
                                bckwIndeterminado.RunWorkerAsync();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do atualizaçõesToolStripMenuItem.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do atualizaçõesToolStripMenuItem.");
                            }
                        }
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 14)
                    {
                        this.Enabled = false;
                        try
                        {
                            Form[] mdichild = this.MdiChildren;
                            //
                            if (this.MdiChildren.Length > 0)
                            {
                                MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                using (FrmBackup Back = new FrmBackup())
                                {
                                    if (Back.ShowDialog() == DialogResult.Abort)
                                    {

                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do toolStripMenuItem1.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do toolStripMenuItem1.");
                            }
                            this.Enabled = true;
                        }
                        this.Enabled = true;
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 15)
                    {
                        try
                        {
                            DataRow dr = bllLicenca.Verificar_Data_Licenca().Rows[0];
                            //
                            MessageBox.Show("Duração da licença: Até " + dr["data_expiracao"].ToString().Remove(10) + " (" + (Convert.ToDateTime(dr["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays + " dia(s)).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            DialogResult = MessageBox.Show("Deseja aplicar a chave da licença agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                {
                                    if (Lic.ShowDialog() == DialogResult.OK)
                                    {
                                        dr = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                        //
                                        MessageBox.Show("Duração da licença: Até " + dr["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do consultarLicençaToolStripMenuItem.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do consultarLicençaToolStripMenuItem.");
                            }
                        }
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 16)
                    {
                        this.Enabled = false;
                        try
                        {
                            using (FrmLayoutPDV lay = new FrmLayoutPDV(1))
                            {
                                if (lay.ShowDialog() == DialogResult.OK)
                                {
                                    DialogResult = MessageBox.Show("Reinicie o aplicativo para aplicar as mudanças.\n\nDeseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        _Reiniciar = true;
                                        //
                                        Process.Start(@"C:\Sistema SEVEN\Seven_PDV.exe");
                                        //
                                        Application.Exit();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do layoutPDVToolStripMenuItem.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do layoutPDVToolStripMenuItem.");
                            }
                        }
                        this.Enabled = true;
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 17)
                    {
                        this.Enabled = false;
                        try
                        {
                            Form[] mdichild = this.MdiChildren;

                            if (this.MdiChildren.Length > 0)
                            {
                                MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                using (FrmLoginUsuario Login = new FrmLoginUsuario(lblUsuario.Text, lblVersao.Text, 0))
                                {
                                    if (Login.ShowDialog() == DialogResult.OK)
                                    {
                                        this.DialogResult = DialogResult.Abort;
                                        lblUsuario.Text = "Usuário(a): " + bllConexao._Usuario;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.Enabled = true;
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do mudarUsuárioToolStripMenuItem.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do mudarUsuárioToolStripMenuItem.");
                            }
                        }
                        this.Enabled = true;
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 18)
                    {
                        MessageBox.Show("Versão: " + _Versao + "\nSistema SEVEN - SISEVEN (C)", "Informações do Aplicativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (bllVenda._Opcao_Menu_BigPicture == 19)
                    {
                        try
                        {
                            if (bllUsuario.Sel_Permitir_Finalizar_PDV_Usuario(lblUsuario.Text) == true)
                            {

                                DialogResult = MessageBox.Show("Deseja finalizar o aplicativo Sistema SEVEN - PDV?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    Application.Exit();
                                }
                            }
                            else
                            {
                                using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Fin_PDV"))
                                {
                                    if (Login.ShowDialog() == DialogResult.OK)
                                    {
                                        if (bllVenda._Permitir_Fin_PDV == 1)
                                        {
                                            DialogResult = MessageBox.Show("Deseja finalizar o aplicativo Sistema SEVEN - PDV?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (DialogResult == DialogResult.Yes)
                                            {
                                                Application.Exit();
                                            }
                                        }
                                        else if (bllVenda._Permitir_Fin_PDV == 0)
                                        {
                                            MessageBox.Show("O Usuário informado não possui permissão para finalizar o aplicativo Sistema SEVEN - PDV.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyUp do formulário FrmSistema PDV.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyUp do formulário FrmSistema PDV.");
                            }
                        }
                    }
                }
            }
        }

        public void Devolucao()
        {
            try
            {
                this.Enabled = false;
                if (bllUsuario.Sel_Reallizar_Devolucao_Usuario(lblUsuario.Text) == true)
                {

                    using (FrmDevolucao Dev = new FrmDevolucao(lblUsuario.Text, lblVersao.Text))
                    {
                        if (Dev.ShowDialog() == DialogResult.OK)
                        {
                            bllVenda.Alterar_Devolucao_PDV(bllVenda._Cod_Devolucao, bllVenda._Valor_Desconto_Devolucao);
                            //
                            _Devolucao = true;
                            //
                            if (bllVenda._PDV_PesqCliente_Tabela != null)
                            {
                                string[] consumidor = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                                //
                                bllVenda.Alterar_Consumidor_PDV(consumidor[0], consumidor[1], consumidor[2], "Tabela [1]", bllConexao._Codigo_Conexao);
                                //
                                if (consumidor[1].Length > 30)
                                {
                                    lblDescCliente.Text = "Consumidor: " + consumidor[2];
                                }
                                else
                                {
                                    lblDescCliente.Text = "Consumidor: " + consumidor[2];
                                }
                            }
                            else
                            {
                                lblDescCliente.Text = "Consumidor: Não identificado.";
                            }
                            //
                            //
                            dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                            //
                            lblMensagemTopo.Text = bllVenda._Descricao_Produto;
                            //
                            txtProduto.Text = null;
                            //
                            dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                            //
                            dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                            //
                            dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                            //
                            Pagamento();
                        }
                    }
                }
                else
                {
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Realizar_Devolucao"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Realizar_Devolucao == 1)
                            {
                                using (FrmDevolucao Dev = new FrmDevolucao(lblUsuario.Text, lblVersao.Text))
                                {
                                    if (Dev.ShowDialog() == DialogResult.OK)
                                    {
                                        bllVenda.Alterar_Devolucao_PDV(bllVenda._Cod_Devolucao, bllVenda._Valor_Desconto_Devolucao);
                                        //
                                        _Devolucao = true;
                                        //
                                        if (bllVenda._PDV_PesqCliente_Tabela != null)
                                        {
                                            string[] consumidor = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                                            //
                                            bllVenda.Alterar_Consumidor_PDV(consumidor[0], consumidor[1], consumidor[2], "Tabela [1]", bllConexao._Codigo_Conexao);
                                            //
                                            if (consumidor[1].Length > 30)
                                            {
                                                lblDescCliente.Text = "Consumidor: " + consumidor[2];
                                            }
                                            else
                                            {
                                                lblDescCliente.Text = "Consumidor: " + consumidor[2];
                                            }
                                        }
                                        else
                                        {
                                            lblDescCliente.Text = "Consumidor: Não identificado.";
                                        }
                                        //
                                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                        //
                                        lblMensagemTopo.Text = bllVenda._Descricao_Produto;
                                        //
                                        txtProduto.Text = null;
                                        //
                                        dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                        //
                                        dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                        //
                                        dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                        //
                                        Pagamento();
                                    }
                                }
                            }
                            else if (bllVenda._Realizar_Devolucao == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para realizar Devolução.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Devolucao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Devolucao.");
                }
                bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                bllVenda._Valor_Desconto_Devolucao = null;
                _Quantidade = "1";
                bllVenda._Descricao_Produto = null;
                //
                bllVenda._Cod_Devolucao = null;
                bllDevolucao._Consumidor_PesqDev = null;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
            this.Enabled = true;
        }

        private void Quantidade()
        {
            this.Enabled = false;
            using (FrmQuantidade Quant = new FrmQuantidade(0, ""))
            {
                if (Quant.ShowDialog() == DialogResult.OK)
                {
                    _Quantidade = bllVenda._Quantidade;
                    bllVenda._Quantidade = null;
                }
                txtProduto.Select();
            }
            this.Enabled = true;
        }

        public void Capturar()
        {
            try
            {
                this.Enabled = false;
                using (FrmCapturar Cap = new FrmCapturar(lblUsuario.Text, lblVersao.Text))
                {
                    if (Cap.ShowDialog() == DialogResult.OK)
                    {
                        if (bllVenda._Tipo_Captura == 0)
                        {
                            using (FrmCapturarDevolucao Dev = new FrmCapturarDevolucao())
                            {
                                if (Dev.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllDevolucao.Sel_Itens_Prod_Devolucao(bllVenda._Cod_Devolucao) != null)
                                    {
                                        if (bllVenda.Sel_Devolucao_Venda_Ver(bllVenda._Cod_Devolucao) == false)
                                        {
                                            bllVenda.Alterar_Devolucao_PDV(bllVenda._Cod_Devolucao, bllVenda._Valor_Desconto_Devolucao);
                                            //
                                            _Devolucao = true;
                                            //
                                            DataRow dr = bllDevolucao.Sel_Dados_Devolucao(bllVenda._Cod_Devolucao).Rows[0];
                                            //
                                            if (Convert.ToDecimal(dr["valor_devolvido"]) < 0)
                                            {
                                                bllVenda._Valor_Desconto_Devolucao = Convert.ToDecimal(dr["valor_devolvido"]).ToString("n2", new CultureInfo("pt-BR")).Replace("-", "");
                                            }
                                            //
                                            if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                            {
                                                bllVenda.Alterar_Consumidor_PDV(dr["id_consumidor"].ToString(), dr["nome_consumidor"].ToString(), dr["cpf_cnpj_consumidor"].ToString(), "Tabela [1]", bllConexao._Codigo_Conexao);
                                                //
                                                bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                                //
                                                if (dr["nome_consumidor"].ToString().Length > 30)
                                                {
                                                    lblDescCliente.Text = "Consumidor: " + dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString().Substring(0, 30) + "...—" + dr["cpf_cnpj_consumidor"].ToString();
                                                }
                                                else
                                                {
                                                    lblDescCliente.Text = "Consumidor: " + dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                lblDescCliente.Text = "Consumidor: Não identificado.";
                                                bllVenda._PDV_PesqCliente_Tabela = null;
                                            }
                                            //
                                            for (int a = 0; a < bllDevolucao.Sel_Itens_Prod_Devolucao(bllVenda._Cod_Devolucao).Rows.Count; a++)
                                            {
                                                dr = bllDevolucao.Sel_Itens_Prod_Devolucao(bllVenda._Cod_Devolucao).Rows[a];
                                                //
                                                string cod_prod = dr["id_produto"].ToString();
                                                //
                                                if (bllProduto.Sel_Prod_Codigo(cod_prod, "") == null)
                                                {
                                                    MessageBox.Show("Código de produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    this.DialogResult = DialogResult.None;
                                                }
                                                else
                                                {
                                                    dr = bllProduto.Sel_Prod_Codigo(cod_prod, "").Rows[0];
                                                    //
                                                    dr = bllDevolucao.Sel_Itens_Prod_Devolucao(bllVenda._Cod_Devolucao).Rows[a];
                                                    //
                                                    bllVenda.Salvar_Items_PDV_Devolucao(dr["id_item"].ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["valor_unitario"].ToString(), dr["um"].ToString(), dr["quantidade"].ToString(), dr["valor_acrescimo_item"].ToString(), dr["valor_desconto_item"].ToString(), dr["valor_total_a_desc_acresc"].ToString(), bllConexao._Codigo_Conexao, "PRODUTO");
                                                    //
                                                    dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                                }
                                            }
                                            //
                                            txtProduto.Text = null;
                                            //
                                            dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                            //
                                            dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                            //
                                            dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Já existe uma Venda realizada para o código de Devolução informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não foram encontrados items para esta Devolução.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                        }
                        else if (bllVenda._Tipo_Captura == 1)
                        {
                            using (FrmCapturarOrcamento Orc = new FrmCapturarOrcamento(0, lblUsuario.Text, lblVersao.Text))
                            {
                                if (Orc.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllOrcamento.Sel_Itens_Orcamento_Orc(bllVenda._Cod_Orcamento) == null)
                                    {
                                        MessageBox.Show("O Orçamento informado não possui itens.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.Enabled = true;
                                        return;
                                    }
                                    //
                                    bllVenda.Alterar_Orcamento_PDV(bllVenda._Cod_Orcamento);
                                    //
                                    _Orcamento = true;
                                    //
                                    DataRow dr = bllOrcamento.Sel_Dados_Orcamento(bllVenda._Cod_Orcamento).Rows[0];
                                    //
                                    if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                    {
                                        bllVenda.Alterar_Consumidor_PDV(dr["id_consumidor"].ToString(), dr["nome_consumidor"].ToString(), dr["cpf_cnpj_consumidor"].ToString(), "Tabela [1]", bllConexao._Codigo_Conexao);
                                        //
                                        bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                        //
                                        if (dr["nome_consumidor"].ToString().Length > 30)
                                        {
                                            lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor"].ToString();
                                        }
                                        else
                                        {
                                            lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        lblDescCliente.Text = "Consumidor: Não identificado.";
                                        bllVenda._PDV_PesqCliente_Tabela = null;
                                    }
                                    //
                                    for (int a = 0; a < bllOrcamento.Sel_Itens_Orcamento_Orc(bllVenda._Cod_Orcamento).Rows.Count; a++)
                                    {
                                        dr = bllOrcamento.Sel_Itens_Orcamento_Orc(bllVenda._Cod_Orcamento).Rows[a];
                                        //
                                        string cod_prod = dr["id_produto"].ToString();
                                        //
                                        if (bllProduto.Sel_Prod_Codigo(cod_prod, "") == null)
                                        {
                                            MessageBox.Show("Código de produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            DataRow drProd = bllProduto.Sel_Prod_Codigo(cod_prod, "").Rows[0];
                                            //
                                            dr = bllOrcamento.Sel_Itens_Orcamento_Orc(bllVenda._Cod_Orcamento).Rows[a];
                                            //
                                            string total_acrescimo = (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString();
                                            //
                                            string total_desconto = (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString();
                                            //
                                            bllVenda.Salvar_Items_PDV_Orcamento((dtItems.Rows.Count + 1).ToString(), drProd["id_produto"].ToString(), drProd["descricao"].ToString(), dr["valor_unitario"].ToString(), dr["um"].ToString(), dr["quantidade"].ToString(), total_acrescimo, total_desconto, "Tabela [1]", bllConexao._Codigo_Conexao, "PRODUTO");
                                            //
                                            dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                        }
                                    }
                                    //
                                    txtProduto.Text = null;
                                    //
                                    dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                    //
                                    dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                    //
                                    dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                }
                            }
                        }
                        else if (bllVenda._Tipo_Captura == 2)
                        {
                            using (FrmCapturarVenda Venda = new FrmCapturarVenda(1, lblUsuario.Text, lblVersao.Text))
                            {
                                if (Venda.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda.Sel_Itens_Venda_Venda(bllVenda._Cod_Venda) == null)
                                    {
                                        MessageBox.Show("A Venda informada não possui itens.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.Enabled = true;
                                        return;
                                    }
                                    //
                                    bllVenda.Alterar_Venda_PDV(bllVenda._Cod_Venda);
                                    //
                                    _Venda = true;
                                    //
                                    DataRow dr = bllVenda.Sel_Venda_Codigo(bllVenda._Cod_Venda).Rows[0];
                                    //
                                    if (Convert.ToInt32(dr["id_consumidor"]) != 0)
                                    {
                                        bllVenda.Alterar_Consumidor_PDV(dr["id_consumidor"].ToString(), dr["nome_consumidor"].ToString(), dr["cpf_cnpj_consumidor"].ToString(), "Tabela [1]", bllConexao._Codigo_Conexao);
                                        //
                                        bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor"].ToString() + "—" + dr["nome_consumidor"].ToString() + "—" + dr["cpf_cnpj_consumidor"].ToString();
                                        //
                                        if (dr["nome_consumidor"].ToString().Length > 30)
                                        {
                                            lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor"].ToString();
                                        }
                                        else
                                        {
                                            lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        lblDescCliente.Text = "Consumidor: Não identificado.";
                                        bllVenda._PDV_PesqCliente_Tabela = null;
                                    }
                                    //
                                    for (int a = 0; a < bllVenda.Sel_Itens_Venda_Venda(bllVenda._Cod_Venda).Rows.Count; a++)
                                    {
                                        dr = bllVenda.Sel_Itens_Venda_Venda(bllVenda._Cod_Venda).Rows[a];
                                        //
                                        string cod_prod = dr["id_produto"].ToString();
                                        //
                                        if (bllProduto.Sel_Prod_Codigo(cod_prod, "") == null)
                                        {
                                            MessageBox.Show("Código de produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            DataRow drProd = bllProduto.Sel_Prod_Codigo(cod_prod, "").Rows[0];
                                            //
                                            string total_acrescimo = (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString();
                                            //
                                            string total_desconto = (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString();
                                            //
                                            bllVenda.Salvar_Items_PDV((dtItems.Rows.Count + 1).ToString(), drProd["id_produto"].ToString(), drProd["descricao"].ToString(), drProd["preco"].ToString(), drProd["um"].ToString(), dr["quantidade"].ToString(), drProd["acrescimo_porc"].ToString(), drProd["desconto_porc"].ToString(), "Tabela [1]", bllConexao._Codigo_Conexao, "PRODUTO");
                                            //
                                            dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                        }
                                    }
                                    //
                                    txtProduto.Text = null;
                                    //
                                    dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                    //
                                    dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                    //
                                    dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                }
                            }
                        }
                    }
                }
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Capturar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Capturar.");
                }
                bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                _Quantidade = "1";
                bllVenda._Cod_Devolucao = null;
                bllVenda._Cod_Orcamento = null;
                bllVenda._Descricao_Produto = null;
                bllVenda._PDV_PesqCliente_Tabela = null;
                bllVenda._Valor_Desconto_Devolucao = null;
            }
        }

        private void Identificar_Consumidor()
        {
            try
            {
                if (bllVenda._PDV_PesqCliente_Tabela != null)
                {
                    DialogResult = MessageBox.Show("Você deseja remover somente o consumidor informado?", "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                        lblDescCliente.Text = "Consumidor: Não identificado.";
                        bllVenda._PDV_PesqCliente_Tabela = null;
                        return;
                    }
                    else if (DialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                //
                this.Enabled = false;
                using (FrmInformar Inf = new FrmInformar())
                {
                    if (Inf.ShowDialog() == DialogResult.OK)
                    {
                        if (bllVenda._Tipo_Informar_Cliente == 0)
                        {
                            using (FrmPesqConsumidor Clie = new FrmPesqConsumidor(0, "Tabela [1]", lblUsuario.Text, lblVersao.Text))
                            {
                                if (Clie.ShowDialog() == DialogResult.OK)
                                {
                                    string consumidor = bllVenda._PDV_PesqCliente_Tabela;
                                    string[] items = consumidor.Split('—');
                                    //
                                    lblDescCliente.Text = "Consumidor: " + items[2];
                                    //
                                    if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                    {
                                        if (bllClieCons.Sel_Cliente_Alerta_Observacao(items[0]) != "")
                                        {
                                            MessageBox.Show(bllClieCons.Sel_Cliente_Alerta_Observacao(items[0]), "Informação de Observação do Consumidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if (bllVenda._Tipo_Informar_Cliente == 1)
                        {
                            using (FrmInfConsManual Man = new FrmInfConsManual("Tabela [1]", lblUsuario.Text, lblVersao.Text))
                            {
                                if (Man.ShowDialog() == DialogResult.OK)
                                {
                                    string consumidor = bllVenda._PDV_PesqCliente_Tabela;
                                    string[] items = consumidor.Split('—');
                                    //
                                    lblDescCliente.Text = "Consumidor: " + items[2];
                                    //
                                    if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                    {
                                        if (bllClieCons.Sel_Cliente_Alerta_Observacao(items[0]) != "")
                                        {
                                            MessageBox.Show(bllClieCons.Sel_Cliente_Alerta_Observacao(items[0]), "Informação de Observação do Consumidor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    txtProduto.Select();
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Identificar_Consumidor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Identificar_Consumidor.");
                }
            }
            this.Enabled = true;
        }

        private void Ajuda()
        {
            try
            {
                DialogResult = MessageBox.Show("Menu/Teclas de Atalho:\n\nF1 -> Informações de ajuda.\n\nF2 -> Formulário de formas de pagamento para finalizar uma venda.\n\nF3 -> Formulário de orçamento.\n\nF4 -> Formulário de quantidade do próximo item que irá ser informado.\n\nF5 -> Formulário de cancelamento de todos os itens e/ou consumidores informados na tabela atual.\n\nF6 -> Formulário de identificação do consumidor.\n\nF7 -> Formulário de captura de orçamentos e devoluções.\n\nF8 -> Formulário de devolução/troca.\n\nF9 -> Outras opções disponíveis no sistema.\n\nDelete -> Exclui o item selecionado.\n\nInsert -> Mostra as informações detalhadas do item selecionado.\n\nDeseja contactar o suporte?", "Ajuda", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.Yes)
                {
                    Process.Start("https://wa.me/5575982868624?text=Ol%C3%A1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão toolStripMenuItem1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão toolStripMenuItem1.");
                }
            }
        }

        public void Excluir_Item()
        {
            try
            {
                DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];

                bllVenda.Excluir_Item(SelectedRow.Cells[0].Value.ToString(), "Tabela [1]");

                bllVenda.Atualizar_Item_Dt_Item(dtItems.CurrentRow.Index + 1, dtItems.Rows.Count, "Tabela [1]", bllConexao._Codigo_Conexao);

                bllRegistroAtividades.Salvar("EXCLUIU O ITEM DE CÓDIGO " + SelectedRow.Cells[1].Value.ToString() + " DO PDV", "VENDAS", "0", lblUsuario.Text, lblVersao.Text);

                dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);

                if (dtItems.Rows.Count >= 1)
                {
                    dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                    //
                    dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                    //
                    dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                }
                else
                {
                    bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                    bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                    //
                    bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                    bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                    //
                    dtItems.DataSource = null;
                    //
                    bllVenda._Quantidade = null;
                    bllVenda._Total = null;
                    bllVenda._Total_Real = null;
                    bllVenda._PDV_PesqForma_Tabela = null;
                    bllVenda._Desconto_Porc = null;
                    bllVenda._Valor_Desconto = null;
                    bllVenda._Acrescimo_Porc = null;
                    bllVenda._Valor_Acrescimo = null;
                    bllVenda._Troco = null;
                    bllVenda._Observacao = null;
                    bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                    bllVenda._N_Parcela = null;
                    bllVenda._Descricao_Produto = null;
                    bllVenda._PDV_Forma_Pagamento.Clear();
                    bllVenda._Dados_Cheque.Clear();
                    bllVenda._PDV_PesqCliente_Tabela = null;
                    bllVenda._Cod_Devolucao = null;
                    bllVenda._Cod_Orcamento = null;
                    bllVenda._Valor_Credito_Loja = null;
                    bllVenda._Valor_Cheque = null;
                    bllVenda._Valor_Desconto_Devolucao = null;
                    //
                    _Quantidade = "1";
                    _Devolucao = false;
                    _Orcamento = false;
                    //
                    lblDescCliente.Text = "Consumidor: Não identificado.";
                    //
                    if (_NFCe_Ativo == true)
                    {
                        _Tipo_Venda = "NFCe";
                        lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFCe **\r\n-------------------------------------------";
                        //
                        bllConfiguracaoSistema.Alterar_Tipo_Documento_PDV(_Tipo_Venda, bllConexao._Codigo_Conexao);
                        //
                        _NFCe_Ativo = false;
                    }
                    //
                    MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    pPanelCaixaLivre.BringToFront();
                    pPanelCaixaLivre.Visible = true;
                }
                //
                txtProduto.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Excluir_Item.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Excluir_Item.");
                }
            }
        }

        private void Cancelar_Venda_Atual()
        {
            try
            {
                string mensagem;
                //
                if (_Devolucao == true)
                {
                    mensagem = "Deseja cancelar uma possível venda atual?\n\nA venda atual foi gerada de uma Devolução.\n\nDeseja continuar?";
                }
                else
                {
                    mensagem = "Deseja cancelar uma possível venda atual?";
                }
                //
                DialogResult = MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (bllUsuario.Sel_Permitir_Canc_Exc_Item_Venda_Usuario(lblUsuario.Text))
                    {
                        bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                        bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                        //
                        dtItems.DataSource = null;
                        //
                        bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                        bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                        //
                        bllVenda._Quantidade = null;
                        bllVenda._Total = null;
                        bllVenda._Total_Real = null;
                        bllVenda._PDV_PesqForma_Tabela = null;
                        bllVenda._Desconto_Porc = null;
                        bllVenda._Valor_Desconto = null;
                        bllVenda._Acrescimo_Porc = null;
                        bllVenda._Valor_Acrescimo = null;
                        bllVenda._Troco = null;
                        bllVenda._Observacao = null;
                        bllVenda._N_Parcela = null;
                        bllVenda._Descricao_Produto = null;
                        bllVenda._PDV_Forma_Pagamento.Clear();
                        bllVenda._Dados_Cheque.Clear();
                        bllVenda._PDV_PesqCliente_Tabela = null;
                        bllVenda._Cod_Devolucao = null;
                        bllVenda._Cod_Orcamento = null;
                        bllVenda._Valor_Credito_Loja = null;
                        bllVenda._Valor_Cheque = null;
                        bllVenda._Valor_Desconto_Devolucao = null;
                        //
                        _Quantidade = "1";
                        _Devolucao = false;
                        _Orcamento = false;
                        //
                        lblDescCliente.Text = "Consumidor: Não identificado.";
                        //
                        if (_NFCe_Ativo == true)
                        {
                            _Tipo_Venda = "NFCe";
                            lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFCe **\r\n-------------------------------------------";
                            //
                            bllConfiguracaoSistema.Alterar_Tipo_Documento_PDV(_Tipo_Venda, bllConexao._Codigo_Conexao);
                            //
                            _NFCe_Ativo = false;
                        }
                        //
                        bllRegistroAtividades.Salvar("CANCELOU UMA VENDA POR COMPLETO NO PDV", "VENDAS", "0", lblUsuario.Text, lblVersao.Text);
                        //
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //
                        pPanelCaixaLivre.BringToFront();
                        pPanelCaixaLivre.Visible = true;
                    }
                    else
                    {
                        using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Excluir_Item"))
                        {
                            if (Login.ShowDialog() == DialogResult.OK)
                            {
                                if (bllVenda._Excluir_Item == 1)
                                {
                                    bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                    bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                    //
                                    dtItems.DataSource = null;
                                    //
                                    bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                                    bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                                    //
                                    bllVenda._Quantidade = null;
                                    bllVenda._Total = null;
                                    bllVenda._Total_Real = null;
                                    bllVenda._PDV_PesqForma_Tabela = null;
                                    bllVenda._Desconto_Porc = null;
                                    bllVenda._Valor_Desconto = null;
                                    bllVenda._Acrescimo_Porc = null;
                                    bllVenda._Valor_Acrescimo = null;
                                    bllVenda._Troco = null;
                                    bllVenda._Observacao = null;
                                    bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                                    bllVenda._N_Parcela = null;
                                    bllVenda._Descricao_Produto = null;
                                    bllVenda._PDV_Forma_Pagamento.Clear();
                                    bllVenda._Dados_Cheque.Clear();
                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                    bllVenda._Cod_Devolucao = null;
                                    bllVenda._Cod_Orcamento = null;
                                    bllVenda._Valor_Credito_Loja = null;
                                    bllVenda._Valor_Cheque = null;
                                    bllVenda._Valor_Desconto_Devolucao = null;
                                    //
                                    _Quantidade = "1";
                                    _Devolucao = false;
                                    _Orcamento = false;
                                    //
                                    lblDescCliente.Text = "Consumidor: Não identificado.";
                                    //
                                    if (_NFCe_Ativo == true)
                                    {
                                        _Tipo_Venda = "NFCe";
                                        lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFCe **\r\n-------------------------------------------";
                                        //
                                        bllConfiguracaoSistema.Alterar_Tipo_Documento_PDV(_Tipo_Venda, bllConexao._Codigo_Conexao);
                                        //
                                        _NFCe_Ativo = false;
                                    }
                                    //
                                    bllRegistroAtividades.Salvar("CANCELOU UMA VENDA POR COMPLETO NO PDV", "VENDAS", "0", lblUsuario.Text, lblVersao.Text);
                                    //
                                    MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //
                                    pPanelCaixaLivre.BringToFront();
                                    pPanelCaixaLivre.Visible = true;
                                }
                                else if (bllVenda._Excluir_Item == 0)
                                {
                                    MessageBox.Show("O Usuário informado não possui permissão para Excluir Itens/Cancelar possíveis Vendas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                    }
                }
                //
                txtProduto.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Cancelamento_Venda_Atual.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Cancelamento_Venda_Atual.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
        }

        private void Pagamento()
        {
            try
            {
                if (bllConfiguracaoSistema.Sel_Contingencia_NFCe() == true & _Tipo_Venda == "NFCe")
                {
                    lblContAtiva.Visible = true;
                }
                else
                {
                    lblContAtiva.Visible = false;
                }
                //
                if (bllVenda._PDV_PesqCliente_Tabela != null)
                {
                    string[] items = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                    //
                    /*
                    if (_Tipo_Venda == "NFCe" & items[2].Length == 18)
                    {
                        DialogResult = MessageBox.Show("A NFC-e por lei só pode ser emitida para pessoa física. Para empresas, use a NF-e!\n\nDeseja fazer isso agora?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (DialogResult == DialogResult.Yes)
                        {
                            _Tipo_Venda = "NFe";
                            lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFe **\r\n-------------------------------------------";
                            //
                            bllConfiguracaoSistema.Alterar_Tipo_Documento_PDV(_Tipo_Venda, bllConexao._Codigo_Conexao);
                            //
                            _NFCe_Ativo = true;
                        }
                        else
                        {
                            return;
                        }
                    }
                    */
                    //
                    if (items[0] == "0" & _Tipo_Venda == "NFe")
                    {
                        MessageBox.Show("É necessário identificar o Consumidor [ Cadastrar ] para emitir um documento NFe modelo 55.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else if (bllVenda._PDV_PesqCliente_Tabela == null & _Tipo_Venda == "NFe")
                {
                    MessageBox.Show("É necessário identificar o Consumidor [ Cadastrar ] para emitir um documento NFe modelo 55.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //
                if (_Tipo_Venda != "DAV")
                {
                    for (int i = 0; i < dtItems.Rows.Count; i++)
                    {
                        DataGridViewRow SelectedRow = dtItems.Rows[i];
                        //
                        DataRow dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];
                        //
                        if (dr["ncm"].ToString() == "" || dr["ncm"].ToString() == null)
                        {
                            MessageBox.Show("É necessário ter um NCM válido cadastrado para o produto:\n[ " + SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
                //
                if (bllConfiguracaoSistema.Sel_Cont_Usuario_Vendas() == true)
                {
                    DialogResult = MessageBox.Show("ATENÇÃO! O usuário que vai finalizar a venda é o usuário\n\n                                        [ " + lblUsuario.Text.Replace("Usuário(a): ", "").Replace("—", "-") + " ]\n\ndeseja trocar de usuário?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        using (FrmLoginUsuario Login = new FrmLoginUsuario(lblUsuario.Text, lblVersao.Text, 1))
                        {
                            if (Login.ShowDialog() == DialogResult.OK)
                            {
                                this.DialogResult = DialogResult.Abort;
                                lblUsuario.Text = "Usuário(a): " + bllConexao._Usuario;
                            }
                        }
                    }
                }
                //
                byte Formulario;
                if (_Devolucao == true)
                {
                    Formulario = 1;
                }
                else if (_Orcamento == true)
                {
                    Formulario = 2;
                }
                else
                {
                    Formulario = 0;
                }
                //
                decimal totalsub = 0;
                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    totalsub += Convert.ToDecimal(dtItems.Rows[i].Cells[9].Value) - Convert.ToDecimal(dtItems.Rows[i].Cells[8].Value) + Convert.ToDecimal(dtItems.Rows[i].Cells[7].Value);
                }
                //
                decimal valordescontoitem = 0;
                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    valordescontoitem += Convert.ToDecimal(dtItems.Rows[i].Cells[7].Value);
                }
                string desc_item = Convert.ToDecimal(valordescontoitem).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valoracrescimoitem = 0;
                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    valoracrescimoitem += Convert.ToDecimal(dtItems.Rows[i].Cells[8].Value);
                }
                string acresc_item = Convert.ToDecimal(valoracrescimoitem).ToString("n2", new CultureInfo("pt-BR"));
                //
                this.Enabled = false;
                using (FrmFormaPagamento Pag = new FrmFormaPagamento(lblValorTotal.Text.Replace("R$ ", ""), Convert.ToDecimal(totalsub).ToString("n2", new CultureInfo("pt-BR")), Formulario, Convert.ToDecimal(valoracrescimoitem).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(valordescontoitem).ToString("n2", new CultureInfo("pt-BR")), lblUsuario.Text, lblVersao.Text))
                {
                    if (Pag.ShowDialog() == DialogResult.OK)
                    {
                        if (bllVenda._Nota_Promissoria == true)
                        {
                            bllVenda.Salvar_Venda(bllVenda._PDV_PesqCliente_Tabela, bllVenda._Desconto_Porc, bllVenda._Valor_Desconto, bllVenda._Acrescimo_Porc, bllVenda._Valor_Acrescimo, _Tipo_Venda, bllVenda._Total, bllVenda._Total_Real, bllVenda._Observacao, lblUsuario.Text, lblVersao.Text, bllVenda._Troco, bllVenda._Valor_Total_Pago, acresc_item, desc_item, null, null, null, false);
                            //
                            DataRow dr = bllVenda.Sel_Dados_Venda_A_Finalizar().Rows[0];
                            //
                            _Cod_Venda = dr["id_venda"].ToString();
                            _Data = dr["data"].ToString().Remove(10);
                            _Hora = dr["hora"].ToString();
                            _Valor_Desconto_Venda = dr["valor_desconto"].ToString();
                            _Valor_Desconto_Item = dr["valor_desconto_item"].ToString();
                            _Valor_Acrescimo_Venda = dr["valor_acrescimo"].ToString();
                            _Valor_Acrescimo_Item = dr["valor_acrescimo_item"].ToString();
                            _Valor = dr["valor"].ToString();
                            _Valor_Real = dr["valor_real"].ToString();
                            _Troco = dr["troco"].ToString();
                            _Cod_Consumidor = dr["id_consumidor"].ToString();
                            _Nome_Consumidor = dr["nome_consumidor"].ToString();
                            _CPF_CNPJ_Consumidor = dr["cpf_cnpj_consumidor"].ToString();
                            _Cod_Usuario = dr["id_usuario"].ToString();
                            _Nome_Usuario = dr["nome_usuario"].ToString();
                            _Desconto_Porc = dr["desconto_porc"].ToString();
                            _Acrescimo_Porc = dr["acrescimo_porc"].ToString();
                            _Cod_Conta_Receber = null;
                            //
                            for (int i = 0; i < dtItems.Rows.Count; i++)
                            {
                                DataGridViewRow SelectedRow = dtItems.Rows[i];
                                if (i == dtItems.Rows.Count - 1)
                                {
                                    bllVenda.Salvar_Itens_Venda(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), _Cod_Venda, _Valor_Desconto_Venda, _Valor_Acrescimo_Venda, _Valor, true, dtItems.Rows.Count.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), false, _Desconto_Porc, _Acrescimo_Porc, "PRODUTO");
                                }
                                else if (i == 0)
                                {
                                    bllVenda.Salvar_Itens_Venda(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), _Cod_Venda, _Valor_Desconto_Venda, _Valor_Acrescimo_Venda, _Valor, true, dtItems.Rows.Count.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), true, _Desconto_Porc, _Acrescimo_Porc, "PRODUTO");
                                }
                                else
                                {
                                    bllVenda.Salvar_Itens_Venda(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), _Cod_Venda, _Valor_Desconto_Venda, _Valor_Acrescimo_Venda, _Valor, false, dtItems.Rows.Count.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), false, _Desconto_Porc, _Acrescimo_Porc, "PRODUTO");
                                }
                            }
                            //
                            for (int i = 0; i < dtItems.Rows.Count; i++)
                            {
                                DataGridViewRow SelectedRow = dtItems.Rows[i];
                                bllVenda.Alterar_Estoque_Produto_PDV(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString());
                            }
                            //
                            string[] items = bllVenda._PDV_Forma_Pagamento[0].ToString().Split('—');
                            bllVenda.Salvar_Forma_Pagamento("1", items[0].ToString(), items[1].ToString(), _Valor_Real, _Cod_Venda, _Data, _Hora, _Tipo_Venda, lblUsuario.Text);
                            //
                            dr = bllVenda.Sel_Dados_Nota_Promissoria_PDV(items[0].ToString()).Rows[0];
                            //
                            string multa_porc = dr["multa_porc"].ToString();
                            string juros_am_porc = dr["juros_mora_porc"].ToString();
                            string desconto_porc = dr["desconto_porc"].ToString();
                            string dia_duracao_desconto = dr["dia_duracao_desconto"].ToString();
                            string dia_primeiro_pagamento = dr["dia_primeiro_pagamento"].ToString();
                            //
                            if (Convert.ToDecimal(bllVenda._Valor_Entrada_Promissoria) > 0)
                            {
                                bllContasReceber.Salvar("0", "ENTRADA DE VENDA EM NOTA PROMISSORIA", DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.'), DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.'), "3—CONTAS A RECEBER NO GERAL", "3—GERAL", bllVenda._Valor_Entrada_Promissoria, _Cod_Consumidor + "—" + _Nome_Consumidor, "", "CLIENTES", "", "NOTA PROMISSORIA", bllVenda._Valor_Entrada_Promissoria, lblUsuario.Text, _Data, _Hora, _Cod_Venda, "FINALIZADA", "", "");
                                //
                                _Cod_Conta_Receber = bllVenda.Sel_Ultima_Conta_Receber_PDV();
                                //
                                bllVenda.Salvar_Pagamento_Conta_Receber_PDV("1", bllVenda._Forma_Ent_Pagamento_Promissoria, bllVenda._Valor_Entrada_Promissoria, _Cod_Conta_Receber, lblUsuario.Text, lblVersao.Text, _Data, _Hora);
                                //
                                bllFluxoCaixa.Salvar(_Data, _Hora, "ENTRADA", "VENDA DE PRODUTOS NO PDV", bllVenda._Valor_Entrada_Promissoria, _Cod_Venda, lblUsuario.Text, lblVersao.Text);
                            }
                            //
                            for (int i = 0; i < Convert.ToInt32(bllVenda._N_Parcela); i++)
                            {
                                bllVenda.Salvar_Conta_Receber((i + 1).ToString(), "VENDA EM NOTA PROMISSORIA", _Cod_Consumidor + "—" + _Nome_Consumidor, _Valor_Real, bllVenda._N_Parcela, bllVenda._Valor_Entrada_Promissoria, multa_porc, juros_am_porc, _Cod_Venda, desconto_porc, dia_duracao_desconto, dia_primeiro_pagamento);
                            }
                            //
                            bllClieCons.Baixa_Saldo_Clie(_Cod_Consumidor, _Valor_Real, bllVenda._Valor_Entrada_Promissoria);
                            //
                            if (_Tipo_Venda == "NFCe")
                            {
                                string serie;
                                serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFCe();
                                //
                                if (bllVenda._PDV_PesqCliente_Tabela != null)
                                {
                                    items = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                                    //
                                    if (items[0] == "0")
                                    {
                                        bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(items[1], items[2]);
                                    }
                                }
                                //
                                bllDFe.Salvar(null, "PRÓPRIA", "65", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, bllVenda._PDV_PesqCliente_Tabela, null, bllVenda._Total, (Convert.ToDecimal(bllVenda._Valor_Desconto) + Convert.ToDecimal(desc_item)).ToString(), null, (Convert.ToDecimal(bllVenda._Valor_Acrescimo) + Convert.ToDecimal(acresc_item)).ToString(), bllVenda._Total_Real, "VENDA DE MERCADORIA", false, lblVersao.Text, "CLIENTES", "0", "0", true, "SAIDA", true, null, "PENDENTE", null, _Cod_Venda, null, false);
                                //
                                _Ult_Codigo_DFe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                //
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(_Cod_Venda).Rows.Count; i++)
                                {
                                    DataRow drItemVenda = bllVenda.Sel_Itens_Venda_Venda(_Cod_Venda).Rows[i];
                                    //
                                    DataRow drProduto = bllProduto.Sel_Prod_Codigo(drItemVenda["id_produto"].ToString(), "").Rows[0];
                                    //
                                    int item = Convert.ToInt32(drItemVenda["id_item"]) - 1;
                                    //
                                    string valor_base_calculo = bllDFe.Calculo_Valor_Base_Calculo_ICMS(drItemVenda["valor_unitario"].ToString(), drItemVenda["quantidade"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString());
                                    //
                                    string valor_base_calculo_st = "0";
                                    //
                                    string valor_icms = bllDFe.Calculo_Valor_ICMS(valor_base_calculo, drProduto["aliq_icms"].ToString());
                                    //
                                    string valor_icms_st = "0";
                                    //
                                    string total_aprox_trib = bllDFe.Calculo_Valor_Aprox_Trib(drItemVenda["valor_total"].ToString(), drItemVenda["id_produto"].ToString());
                                    //
                                    string cfop = null;
                                    if (bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL" || bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL - MEI")
                                    {
                                        if (drProduto["csosn"].ToString() == "101")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "102")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "103")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "201")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "202")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "203")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "300")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "400")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "500")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "900")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                    }
                                    //
                                    bllDFe.Salvar_Items(item.ToString(), drItemVenda["id_produto"].ToString() + "—" + drItemVenda["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), cfop, drItemVenda["quantidade"].ToString(), "1", drItemVenda["valor_total"].ToString(), drItemVenda["valor_unitario"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString(), drItemVenda["valor_total_a_desc_acresc"].ToString(), valor_icms, valor_base_calculo, _Ult_Codigo_DFe, valor_icms_st, "0", "0", valor_base_calculo_st, "0", drItemVenda["um"].ToString(), total_aprox_trib, "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                                }
                                //
                                DataRow drItemDfe;
                                decimal icms = 0;
                                decimal icmsst = 0;
                                decimal base_calculo_icms = 0;
                                decimal base_calculo_icms_st = 0;
                                decimal total_apx_trib = 0;
                                //
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(_Ult_Codigo_DFe).Rows.Count; i++)
                                {
                                    drItemDfe = bllDFe.Sel_Items_DFe(_Ult_Codigo_DFe).Rows[i];
                                    //
                                    icms += Convert.ToDecimal(drItemDfe["valor_icms"]);
                                    icmsst += Convert.ToDecimal(drItemDfe["valor_icms_st"]);
                                    base_calculo_icms += Convert.ToDecimal(drItemDfe["valor_base_calculo"]);
                                    base_calculo_icms_st += Convert.ToDecimal(drItemDfe["valor_base_calculo_st"]);
                                    total_apx_trib += Convert.ToDecimal(drItemDfe["total_aprox_trib"]);
                                }
                                //
                                bllDFe.Salvar_icms_icms_st_base_total_trib(_Ult_Codigo_DFe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_apx_trib.ToString());
                                //
                                for (int i = 0; i < bllVenda._PDV_Forma_Pagamento.Count; i++)
                                {
                                    items = bllVenda._PDV_Forma_Pagamento[i].ToString().Split('—');
                                    //
                                    bllDFe.Salvar_Pagamento_DFe((i + 1).ToString(), items[0] + "—" + items[1], bllVenda._Total_Real, _Ult_Codigo_DFe);
                                }
                                //
                                lblProgresso.Visible = true;
                                lblProgresso.Text = "Transmitindo, por favor, aguarde...";
                                //
                                bool contingencia = false;
                                //
                                if (bllConfiguracaoSistema.Sel_Contingencia_NFCe() == true)
                                {
                                    contingencia = true;
                                }
                                else
                                {
                                    contingencia = false;
                                }
                                //
                                if (bllDFe.Transmitir_NFCe(_Ult_Codigo_DFe, lblVersao.Text, false) == contingencia)
                                {
                                    DataRow drDFe = bllDFe.Sel_Nfe_Codigo(_Ult_Codigo_DFe).Rows[0];
                                    //
                                    items = drDFe["caminho_dfe"].ToString().Split('\\');
                                    //
                                    if (File.Exists(drDFe["caminho_dfe"].ToString()))
                                    {
                                        string diretorio = @"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\Cont-NFCe\" + items[5] + @"\" + items[6];
                                        if (!Directory.Exists(diretorio))
                                        {
                                            Directory.CreateDirectory(diretorio);
                                        }
                                        //
                                        File.Move(drDFe["caminho_dfe"].ToString(), diretorio + @"\" + items[7]);
                                    }
                                    //
                                    bllDFe.Transmitir_NFCe(_Ult_Codigo_DFe, lblVersao.Text, true);
                                }
                                //
                                bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(null, null);
                                lblProgresso.Visible = false;
                            }
                            else if (_Tipo_Venda == "NFe")
                            {
                                string serie;
                                serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFCe();
                                //
                                if (bllVenda._PDV_PesqCliente_Tabela != null)
                                {
                                    items = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                                    //
                                    if (items[0] == "0")
                                    {
                                        bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(items[1], items[2]);
                                    }
                                }
                                //
                                bllDFe.Salvar(null, "PRÓPRIA", "55", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, bllVenda._PDV_PesqCliente_Tabela, null, bllVenda._Total, (Convert.ToDecimal(bllVenda._Valor_Desconto) + Convert.ToDecimal(desc_item)).ToString(), null, (Convert.ToDecimal(bllVenda._Valor_Acrescimo) + Convert.ToDecimal(acresc_item)).ToString(), bllVenda._Total_Real, "VENDA DE MERCADORIA", false, lblVersao.Text, "CLIENTES", "0", "0", true, "SAIDA", true, null, "PENDENTE", null, _Cod_Venda, null, true);
                                //
                                _Ult_Codigo_DFe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                //
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(_Cod_Venda).Rows.Count; i++)
                                {
                                    DataRow drItemVenda = bllVenda.Sel_Itens_Venda_Venda(_Cod_Venda).Rows[i];
                                    //
                                    DataRow drProduto = bllProduto.Sel_Prod_Codigo(drItemVenda["id_produto"].ToString(), "").Rows[0];
                                    //
                                    int item = Convert.ToInt32(drItemVenda["id_item"]) - 1;
                                    //
                                    string valor_base_calculo = bllDFe.Calculo_Valor_Base_Calculo_ICMS(drItemVenda["valor_unitario"].ToString(), drItemVenda["quantidade"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString());
                                    //
                                    string valor_base_calculo_st = "0";
                                    //
                                    string valor_icms = bllDFe.Calculo_Valor_ICMS(valor_base_calculo, drProduto["aliq_icms"].ToString());
                                    //
                                    string valor_icms_st = "0";
                                    //
                                    string total_aprox_trib = bllDFe.Calculo_Valor_Aprox_Trib(drItemVenda["valor_total"].ToString(), drItemVenda["id_produto"].ToString());
                                    //
                                    string cfop = null;
                                    if (bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL" || bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL - MEI")
                                    {
                                        if (drProduto["csosn"].ToString() == "101")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "102")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "103")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "201")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "202")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "203")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "300")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "400")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "500")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "900")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                    }
                                    //
                                    bllDFe.Salvar_Items(item.ToString(), drItemVenda["id_produto"].ToString() + "—" + drItemVenda["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), cfop, drItemVenda["quantidade"].ToString(), "1", drItemVenda["valor_total"].ToString(), drItemVenda["valor_unitario"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString(), drItemVenda["valor_total_a_desc_acresc"].ToString(), valor_icms, valor_base_calculo, _Ult_Codigo_DFe, valor_icms_st, "0", "0", valor_base_calculo_st, "0", drItemVenda["um"].ToString(), total_aprox_trib, "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                                }
                                //
                                DataRow drItemDfe;
                                decimal icms = 0;
                                decimal icmsst = 0;
                                decimal base_calculo_icms = 0;
                                decimal base_calculo_icms_st = 0;
                                decimal total_apx_trib = 0;
                                //
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(_Ult_Codigo_DFe).Rows.Count; i++)
                                {
                                    drItemDfe = bllDFe.Sel_Items_DFe(_Ult_Codigo_DFe).Rows[i];
                                    //
                                    icms += Convert.ToDecimal(drItemDfe["valor_icms"]);
                                    icmsst += Convert.ToDecimal(drItemDfe["valor_icms_st"]);
                                    base_calculo_icms += Convert.ToDecimal(drItemDfe["valor_base_calculo"]);
                                    base_calculo_icms_st += Convert.ToDecimal(drItemDfe["valor_base_calculo_st"]);
                                    total_apx_trib += Convert.ToDecimal(drItemDfe["total_aprox_trib"]);
                                }
                                //
                                bllDFe.Salvar_icms_icms_st_base_total_trib(_Ult_Codigo_DFe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_apx_trib.ToString());
                                //
                                for (int i = 0; i < bllVenda._PDV_Forma_Pagamento.Count; i++)
                                {
                                    items = bllVenda._PDV_Forma_Pagamento[i].ToString().Split('—');
                                    //
                                    bllDFe.Salvar_Pagamento_DFe((i + 1).ToString(), items[0] + "—" + items[1], bllVenda._Total_Real, _Ult_Codigo_DFe);
                                }
                                //
                                using (FrmCadNFeNFCe NFe = new FrmCadNFeNFCe(lblUsuario.Text, lblVersao.Text, 2, null, null, _Ult_Codigo_DFe, 0, false))
                                {
                                    if (NFe.ShowDialog() == DialogResult.Abort)
                                    {
                                        MessageBox.Show("O DFe de código [ " + _Ult_Codigo_DFe + " ] referente a venda atual se encontra pendente, é necessário verificar o motivo e transmitir ou inutilizar a numeração.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                            //
                            bllRegistroAtividades.Salvar("VENDA DE PRODUTOS NO PDV", "VENDAS", _Cod_Venda, lblUsuario.Text, lblVersao.Text);
                            //
                            if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "" & _Tipo_Venda == "DAV")
                            {
                                MessageBox.Show("Impressão do cupom [ NNF ] desabilitado por configuração.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(58mm)" & _Tipo_Venda == "DAV")
                            {
                                _Trabalho = 1;
                                if (bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao) == null || bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao) == "")
                                {
                                    prtDocumento.PrintController = new StandardPrintController();
                                    prtDocumento.Print();
                                }
                                else
                                {
                                    prtDocumento.PrinterSettings.PrinterName = bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao);
                                    prtDocumento.PrintController = new StandardPrintController();
                                    prtDocumento.Print();
                                }
                            }
                            else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)" & _Tipo_Venda == "DAV")
                            {
                                _Trabalho = 0;
                                if (bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao) == null || bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao) == "")
                                {
                                    prtDocumento.PrintController = new StandardPrintController();
                                    prtDocumento.Print();
                                }
                                else
                                {
                                    prtDocumento.PrinterSettings.PrinterName = bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao);
                                    prtDocumento.PrintController = new StandardPrintController();
                                    prtDocumento.Print();
                                }
                            }
                            else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "A4(Mostrar na Tela)" & _Tipo_Venda == "DAV")
                            {
                                Process.Start(bllVenda.GerarDAV(1, _Cod_Venda));
                            }
                            else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)(Mostrar na Tela)" & _Tipo_Venda == "DAV")
                            {
                                Process.Start(bllVenda.GerarDAV(1, _Cod_Venda));
                            }
                            // 
                            if (Convert.ToDecimal(bllVenda._Valor_Entrada_Promissoria) > 0)
                            {
                                if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "")
                                {
                                    MessageBox.Show("Impressão do comprovante [ NNF ] desabilitado por configuração.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "A4(Mostrar na Tela)")
                                {
                                    using (var doc = new PdfDocument())
                                    {
                                        var page = doc.AddPage();
                                        page.Width = 595;
                                        page.Height = 842;
                                        var graphics = XGraphics.FromPdfPage(page);
                                        var textFormatter1 = new XTextFormatter(graphics);
                                        var textFormatter2 = new XTextFormatter(graphics);
                                        var textFormatter3 = new XTextFormatter(graphics);
                                        var fonte1 = new XFont("Microsoft Sans Serif", 14, XFontStyle.Bold);
                                        var fonte2 = new XFont("Microsoft Sans Serif", 9);
                                        var fonte3 = new XFont("Microsoft Sans Serif", 11, XFontStyle.Bold);
                                        var fonte4 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                        XPen pen = new XPen(XColors.Black);
                                        //
                                        int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                                        int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                                        //
                                        textFormatter1.Alignment = XParagraphAlignment.Center;
                                        textFormatter3.Alignment = XParagraphAlignment.Right;
                                        //                   
                                        //Linhas do datagrid
                                        int Incrementar = 0;
                                        //                    
                                        int AumentoImagem = 0;
                                        if (bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                                        {
                                            XImage imagem;
                                            imagem = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                                            graphics.DrawImage(imagem, 15 + Margem_Esq, 7 + Margem_Topo, 58, 69);
                                            AumentoImagem = 30;
                                        }
                                        else
                                        {
                                            AumentoImagem = 0;
                                        }
                                        //
                                        dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        textFormatter1.DrawString(dr["nome"].ToString(), fonte3, XBrushes.Black, new XRect(AumentoImagem + 7 + Margem_Esq, 7 + Margem_Topo, 575, 28));
                                        //
                                        textFormatter1.DrawString(dr["fantasia"].ToString(), fonte2, XBrushes.Black, new XRect(AumentoImagem + 7 + Margem_Esq, 20 + Margem_Topo, 575, 10));
                                        //
                                        string cpf_cnpj;
                                        string ie_rg;
                                        if (Convert.ToByte(dr["pessoa"]) == 0)
                                        {
                                            cpf_cnpj = "CPF:";
                                            ie_rg = "RG:";
                                        }
                                        else
                                        {
                                            cpf_cnpj = "CNPJ:";
                                            ie_rg = "IE:";
                                        }
                                        //
                                        //graphics.DrawRectangle(pen, XBrushes.White, AumentoImagem + 45 + Margem_Esq, 40 + Margem_Topo, 500, 33);
                                        textFormatter1.DrawString(cpf_cnpj + " " + dr["cpf_cnpj"].ToString() + ", " + ie_rg + " " + dr["ie_rg"].ToString(), fonte2, XBrushes.Black, new XRect(AumentoImagem + 45 + Margem_Esq, 30 + Margem_Topo, 500, 11));
                                        //
                                        textFormatter1.DrawString("End.: " + dr["endereco"].ToString() + ", " + dr["numero"].ToString() + ", " + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + ", " + dr["cep"].ToString(), fonte2, XBrushes.Black, new XRect(AumentoImagem + 45 + Margem_Esq, 40 + Margem_Topo, 500, 33));
                                        //
                                        textFormatter1.DrawString("RECIBO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 77 + Margem_Topo, 575, 15));
                                        //
                                        Margem_Topo = Margem_Topo + 15;
                                        //
                                        string tipo_documento;
                                        //
                                        tipo_documento = "referente ao pagamento de entrada da Venda nº " + _Cod_Venda + " em Nota Promissória.";
                                        //
                                        textFormatter2.DrawString("Código: " + _Cod_Conta_Receber, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 74 + Margem_Topo, 575, 10));
                                        //
                                        textFormatter3.DrawString("Valor Total Real (R$): " + Convert.ToDecimal(_Valor_Real).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 74 + Margem_Topo, 575, 10));
                                        // 
                                        textFormatter2.DrawString("Data e Hora da Impressão: " + DateTime.Now.ToShortDateString() + "  -  " + DateTime.Now.ToLongTimeString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 83 + Margem_Topo, 575, 10));
                                        //
                                        textFormatter2.DrawString("Consumidor: " + _Cod_Consumidor + " - " + _Nome_Consumidor + "  CPF/CNPJ: " + _CPF_CNPJ_Consumidor, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 94 + Margem_Topo, 570, 10));
                                        //
                                        string quantia = bllVenda._Valor_Entrada_Promissoria;
                                        //
                                        Margem_Topo = Margem_Topo + 10;
                                        //graphics.DrawRectangle(pen, XBrushes.White, 7 + Margem_Esq, AumentoDeLinhaFixo + 120 + Margem_Topo, 570, 22);
                                        textFormatter2.DrawString("Recebi(emos) de " + _Nome_Consumidor + ", a quantia de " + Convert.ToDecimal(quantia).ToString("n2", new CultureInfo("pt-BR")) + " R$ (" + EscreverExtenso.Extenso(Convert.ToDecimal(quantia)) + "), " + tipo_documento + ".", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 105 + Margem_Topo, 570, 22));
                                        //
                                        textFormatter2.DrawString("Pagamento                                         -                                                 Valor Pago (R$)               -               Data               -               Hora", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 127 + Margem_Topo, 575, 10));
                                        //
                                        textFormatter2.DrawString("_____________________________________________________________________________________________________________________", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 128 + Margem_Topo, 570, 10));
                                        //
                                        //for (int i = 0; i < bllContasReceber.Sel_Pagamento_Conta_Receber(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                                        dr = bllContasReceber.Sel_Pagamento_Conta_Receber(_Cod_Conta_Receber).Rows[0];
                                        //graphics.DrawRectangle(pen, XBrushes.White, 7 + Margem_Esq, AumentoDeLinhaFixo + 154 + Margem_Topo, 260, 10);
                                        textFormatter2.DrawString(dr["tipo"].ToString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 138 + Margem_Topo, 260, 10));
                                        //graphics.DrawRectangle(pen, XBrushes.White, 265 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                                        textFormatter1.DrawString(Convert.ToDecimal(dr["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(265 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                                        //graphics.DrawRectangle(pen, XBrushes.White, 380 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                                        textFormatter1.DrawString(dr["data_pagamento"].ToString().Remove(10), fonte2, XBrushes.Black, new XRect(380 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                                        //graphics.DrawRectangle(pen, XBrushes.White, 475 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                                        textFormatter1.DrawString(dr["hora_pagamento"].ToString(), fonte2, XBrushes.Black, new XRect(475 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                                        Incrementar = Incrementar + 8;
                                        //
                                        textFormatter2.DrawString("_____________________________________________________________________________________________________________________", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 132 + Margem_Topo, 570, 10));
                                        //
                                        textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(_Valor_Real) - Convert.ToDecimal(bllVenda._Valor_Entrada_Promissoria)).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 142 + Margem_Topo, 575, 10));
                                        //
                                        PdfSecuritySettings security = doc.SecuritySettings;
                                        //
                                        security.PermitAccessibilityExtractContent = false;
                                        security.PermitAnnotations = false;
                                        security.PermitAssembleDocument = false;
                                        security.PermitExtractContent = false;
                                        security.PermitFormsFill = true;
                                        security.PermitFullQualityPrint = false;
                                        security.PermitModifyDocument = false;
                                        security.PermitPrint = true;
                                        //
                                        string mes;
                                        if (DateTime.Now.Month < 10)
                                        {
                                            mes = "0" + DateTime.Now.Month;
                                        }
                                        else
                                        {
                                            mes = DateTime.Now.Month.ToString();
                                        }
                                        //
                                        if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + DateTime.Now.Year + mes))
                                        {
                                            Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + DateTime.Now.Year + mes);
                                            doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + DateTime.Now.Year + mes + @"\" + _Cod_Conta_Receber + ".pdf");
                                        }
                                        else
                                        {
                                            doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + DateTime.Now.Year + mes + @"\" + _Cod_Conta_Receber + ".pdf");
                                        }
                                        //
                                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + DateTime.Now.Year + mes + @"\" + _Cod_Conta_Receber + ".pdf");
                                    }
                                }
                                else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)")
                                {
                                    using (var doc = new PdfDocument())
                                    {
                                        var page = doc.AddPage();
                                        //
                                        DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                                        byte pessoa;
                                        //
                                        nome = drPDF["nome"].ToString();
                                        fantasia = drPDF["fantasia"].ToString();
                                        cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                                        ie_rg = drPDF["ie_rg"].ToString();
                                        endereco = drPDF["endereco"].ToString();
                                        numero = drPDF["numero"].ToString();
                                        bairro = drPDF["bairro"].ToString();
                                        cidade = drPDF["cidade"].ToString();
                                        uf = drPDF["uf"].ToString();
                                        cep = drPDF["cep"].ToString();
                                        pessoa = Convert.ToByte(drPDF["pessoa"]);
                                        //
                                        page.Width = 203;
                                        page.Height = 842;
                                        //
                                        var graphics = XGraphics.FromPdfPage(page);
                                        var textFormatter1 = new XTextFormatter(graphics);
                                        var textFormatter2 = new XTextFormatter(graphics);
                                        var textFormatter3 = new XTextFormatter(graphics);
                                        var textFormatter4 = new XTextFormatter(graphics);
                                        //
                                        var fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                        var fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                        var fonte3 = new XFont("Courrier New", 12, XFontStyle.Regular);
                                        //
                                        textFormatter1.Alignment = XParagraphAlignment.Center;
                                        textFormatter2.Alignment = XParagraphAlignment.Left;
                                        textFormatter3.Alignment = XParagraphAlignment.Right;
                                        //
                                        XPen pen1 = new XPen(XColors.AntiqueWhite);
                                        XPen pen = new XPen(XColors.Black);
                                        //
                                        int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_80_Pdv(bllConexao._Codigo_Conexao);
                                        int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_80_Pdv(bllConexao._Codigo_Conexao);
                                        //
                                        StringFormat Sf1 = new StringFormat();
                                        Sf1.Alignment = StringAlignment.Near;
                                        //
                                        StringFormat Sf2 = new StringFormat();
                                        Sf2.Alignment = StringAlignment.Far;
                                        //
                                        int Incrementar = 0;
                                        //
                                        if (bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                                        {
                                            XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                                            graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                                        }
                                        else
                                        {
                                            Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                                        }
                                        //        
                                        //graphics.DrawRectangle(pen, 2 + Margem_Esq, 2 + Margem_Topo, 203, 16);     
                                        if (nome.Length > 30)
                                        {
                                            if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                                            {
                                                textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                                            }
                                            else
                                            {
                                                textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                                            }
                                            Incrementar = Incrementar + 8;
                                        }
                                        else
                                        {
                                            textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 8));
                                        }
                                        //
                                        if (fantasia.Length > 30)
                                        {
                                            if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                                            {
                                                textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 16));
                                            }
                                            else
                                            {
                                                textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 16));
                                            }
                                            Incrementar = Incrementar + 8;
                                        }
                                        else
                                        {
                                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 198, 8));
                                        }
                                        //
                                        if (pessoa == 1)
                                        {
                                            textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                                        }
                                        else
                                        {
                                            textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                                        }
                                        //
                                        textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 109 + Margem_Topo, 198, 24));
                                        //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                                        Incrementar = Incrementar - 15;
                                        //
                                        textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Incrementar + Margem_Topo, 198, 24));
                                        Margem_Topo = Margem_Topo - 4;
                                        textFormatter1.DrawString("RECIBO", fonte3, XBrushes.Black, new XRect(5 + Margem_Esq, 146 + Margem_Topo, 198, 24));
                                        textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + Margem_Topo, 198, 24));
                                        //
                                        string tipo_documento;
                                        //
                                        tipo_documento = "referente ao pagamento de entrada da Venda nº " + _Cod_Venda + " em Nota Promissória.";
                                        //
                                        textFormatter3.DrawString("Valor Total Real (R$): " + Convert.ToDecimal(_Valor_Real).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 171 + Margem_Topo, 198, 12));
                                        textFormatter2.DrawString("Código: " + _Cod_Conta_Receber, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 183 + Margem_Topo, 198, 8));
                                        //
                                        textFormatter2.DrawString("Data e Hora da Impressão: " + DateTime.Now.ToShortDateString() + "   -   " + DateTime.Now.ToLongTimeString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 191 + Margem_Topo, 198, 8));
                                        //
                                        Margem_Topo = Margem_Topo - 17;
                                        //
                                        if (_Nome_Consumidor.Length > 20)
                                        {
                                            if (!_Nome_Consumidor.Substring(0, 20).Contains(" ") || (!_Nome_Consumidor.Substring(20).Contains(" ") & _Nome_Consumidor.Substring(20).Length > 10))
                                            {
                                                textFormatter2.DrawString("Consumidor: " + _Cod_Consumidor + "-" + _Nome_Consumidor.Insert(20, Environment.NewLine) + Environment.NewLine + "CPF/CNPJ: " + _CPF_CNPJ_Consumidor, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo, 198, 24));
                                            }
                                            else
                                            {
                                                textFormatter2.DrawString("Consumidor: " + _Cod_Consumidor + "-" + _Nome_Consumidor + Environment.NewLine + "CPF/CNPJ: " + _CPF_CNPJ_Consumidor, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo, 198, 24));
                                            }
                                            Margem_Topo = Margem_Topo + 8;
                                        }
                                        else
                                        {
                                            textFormatter2.DrawString("Consumidor: " + _Cod_Consumidor + "-" + _Nome_Consumidor + Environment.NewLine + "CPF/CNPJ: " + _CPF_CNPJ_Consumidor, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo, 198, 24));
                                        }
                                        //                    
                                        string quantia = bllVenda._Valor_Entrada_Promissoria; ;
                                        //
                                        Margem_Topo = Margem_Topo + 14;
                                        //graphics.DrawRectangle(pen, 2 + Margem_Esq, 225 + Margem_Topo, 198, 64);
                                        textFormatter2.DrawString("Recebi(emos) de " + _Nome_Consumidor + ", a quantia de R$ " + Convert.ToDecimal(quantia).ToString("n2", new CultureInfo("pt-BR")) + " (" + EscreverExtenso.Extenso(Convert.ToDecimal(quantia)) + "), " + tipo_documento + ".", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo, 198, 64));
                                        //
                                        textFormatter2.DrawString(" Pagamento       -        Valor Pago (R$)   -   Data   -   Hora", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 289 + Margem_Topo, 198, 8));
                                        //
                                        textFormatter2.DrawString("____________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 298 + Margem_Topo, 198, 16));
                                        //

                                        Margem_Topo = Margem_Topo + 2;
                                        for (int i = 0; i < bllContasReceber.Sel_Pagamento_Conta_Receber(_Cod_Conta_Receber).Rows.Count; i++)
                                        {
                                            dr = bllContasReceber.Sel_Pagamento_Conta_Receber(_Cod_Conta_Receber).Rows[i];
                                            textFormatter2.DrawString(dr["tipo"].ToString() + "   -   " + Convert.ToDecimal(dr["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")) + "  -   " + dr["data_pagamento"].ToString().Remove(10) + "  -  " + dr["hora_pagamento"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 305 + Margem_Topo, 198, 8));
                                            //
                                            Incrementar = Incrementar + 8;
                                        }
                                        //
                                        textFormatter2.DrawString("____________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 300 + Margem_Topo, 198, 16));
                                        //
                                        textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(_Valor_Real) - Convert.ToDecimal(bllVenda._Valor_Entrada_Promissoria)).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 308 + Margem_Topo, 198, 8));
                                        //
                                        string mes;
                                        if (DateTime.Now.Month < 10)
                                        {
                                            mes = "0" + DateTime.Now.Month;
                                        }
                                        else
                                        {
                                            mes = DateTime.Now.Month.ToString();
                                        }
                                        //
                                        if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + DateTime.Now.Year + mes))
                                        {
                                            Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + DateTime.Now.Year + mes);
                                            doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + DateTime.Now.Year + mes + @"\" + _Cod_Conta_Receber + ".pdf");
                                        }
                                        else
                                        {
                                            doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + DateTime.Now.Year + mes + @"\" + _Cod_Conta_Receber + ".pdf");
                                        }
                                        //
                                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Comprovantes\" + DateTime.Now.Year + mes + @"\" + _Cod_Conta_Receber + ".pdf");
                                    }
                                }
                            }
                            //
                            if (bllVenda.Sel_Nota_Promissoria_Dados_Venda(_Cod_Venda) != null)
                            {
                                if (bllConfiguracaoSistema.Sel_Tipo_Imp_Nota_Promissoria(bllConexao._Codigo_Conexao) == "")
                                {
                                    MessageBox.Show("Impressão do documento [ Nota Promissória ] desabilitado por configuração.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if (bllConfiguracaoSistema.Sel_Tipo_Imp_Nota_Promissoria(bllConexao._Codigo_Conexao) == "A4(Mostrar na Tela)")
                                {
                                    using (var doc = new PdfDocument())
                                    {
                                        var page = doc.AddPage();
                                        page.Width = 595;
                                        page.Height = 842;
                                        var graphics = XGraphics.FromPdfPage(page);
                                        var textFormatter1 = new XTextFormatter(graphics);
                                        var textFormatter2 = new XTextFormatter(graphics);
                                        var textFormatter3 = new XTextFormatter(graphics);
                                        var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                        var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                        var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                        var fonte4 = new XFont("Microsoft Sans Serif", 9);
                                        XPen pen = new XPen(XColors.Black);
                                        XPen pen2 = new XPen(XColors.LightGray);
                                        bool PrimeiraPagina = true;
                                        int Incrementar = 0;
                                        DataRow drCabecalho;
                                        DataRow drContaReceber;
                                        //
                                        int pagina = 4;
                                        int TotalPaginas = 1;//Numero de páginas do documento.
                                        int ContadorPagina = 1;
                                        int registros = 8;
                                        //
                                        for (int i = 0; i < bllVenda.Sel_Nota_Promissoria_Dados_Venda(_Cod_Venda).Rows.Count; i++)
                                        {
                                            if (i == 4)
                                            {
                                                TotalPaginas = TotalPaginas + 1;
                                            }
                                            else if (i == registros)
                                            {
                                                registros = registros + 4;
                                                TotalPaginas = TotalPaginas + 1;
                                            }
                                        }
                                        //
                                        short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_A4_Pdv(bllConexao._Codigo_Conexao);
                                        short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_A4_Pdv(bllConexao._Codigo_Conexao);
                                        //
                                        textFormatter1.Alignment = XParagraphAlignment.Center;
                                        textFormatter3.Alignment = XParagraphAlignment.Right;
                                        //
                                        textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                        textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                        //
                                        for (int linha = 0; linha < bllVenda.Sel_Nota_Promissoria_Dados_Venda(_Cod_Venda).Rows.Count; linha++)
                                        {
                                            if (linha < 4 & PrimeiraPagina == true)
                                            {
                                                //Logo da Promissoria
                                                XImage imagem1 = XImage.FromFile(@"C:\Sistema SEVEN\Config\Miscellaneous\rfb_np.png");
                                                //
                                                CultureInfo cultura = new CultureInfo("pt-BR");
                                                DateTimeFormatInfo dtfi = cultura.DateTimeFormat;
                                                int dia;
                                                int ano;
                                                string mes;
                                                //Linhas do datagrid                                            
                                                drContaReceber = bllVenda.Sel_Nota_Promissoria_Dados_Venda(_Cod_Venda).Rows[linha];
                                                //
                                                //Código
                                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 5 + Margem_Topo, 575, 175);
                                                //
                                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 5 + Margem_Topo, 60, 175);
                                                //
                                                graphics.DrawImage(imagem1, 17 + Margem_Esq, Incrementar + 7 + Margem_Topo, 45, 171);
                                                //
                                                XImage imagem2;
                                                string espaco;
                                                int margem_esq_prom_num;
                                                if (bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                                                {
                                                    imagem2 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                                                    graphics.DrawImage(imagem2, 70 + Margem_Esq, Incrementar + 7 + Margem_Topo, 58, 69);
                                                    espaco = "                           ";
                                                    margem_esq_prom_num = 135;
                                                }
                                                else
                                                {
                                                    espaco = "";
                                                    margem_esq_prom_num = 70;
                                                }
                                                //
                                                textFormatter2.DrawString("NOTA PROMISSÓRIA", fonte1, XBrushes.Black, new XRect(margem_esq_prom_num + Margem_Esq, Incrementar + 7 + Margem_Topo, page.Width, 14));
                                                //
                                                DateTime vencimento = Convert.ToDateTime(drContaReceber["data_vencimento"].ToString());
                                                //
                                                dia = vencimento.Day;
                                                ano = vencimento.Year;
                                                mes = cultura.TextInfo.ToTitleCase(dtfi.GetMonthName(vencimento.Month).ToUpper());
                                                //
                                                graphics.DrawRectangle(pen2, XBrushes.LightGray, 400 + Margem_Esq, Incrementar + 7 + Margem_Topo, 175, 14);
                                                textFormatter3.DrawString("Vencimento: " + dia + " de " + mes + " de " + ano, fonte4, XBrushes.Black, new XRect(5 + Margem_Esq, Incrementar + 8 + Margem_Topo, 570, 14));
                                                //
                                                graphics.DrawRectangle(pen2, XBrushes.LightGray, margem_esq_prom_num + Margem_Esq, Incrementar + 24 + Margem_Topo, 125, 14);
                                                textFormatter2.DrawString("Nº/Parcela: " + drContaReceber["n_promissoria"].ToString() + "/" + drContaReceber["ocorrencia_parc"].ToString(), fonte4, XBrushes.Black, new XRect(margem_esq_prom_num + Margem_Esq, Incrementar + 25 + Margem_Topo, 85, 14));
                                                //
                                                graphics.DrawRectangle(pen2, XBrushes.LightGray, 400 + Margem_Esq, Incrementar + 24 + Margem_Topo, 175, 14);
                                                textFormatter3.DrawString("Valor (R$): " + Convert.ToDecimal(drContaReceber["valor_real"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(5 + Margem_Esq, Incrementar + 25 + Margem_Topo, 570, 14));
                                                //
                                                drCabecalho = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                                string cpf_cnpj;
                                                if (Convert.ToByte(drCabecalho["pessoa"]) == 0)
                                                {
                                                    cpf_cnpj = "CPF";
                                                }
                                                else
                                                {
                                                    cpf_cnpj = "CNPJ";
                                                }
                                                textFormatter2.DrawString(espaco + "No dia " + dia + " do mês de " + mes + " do ano de " + ano + " pagarei(emos) por esta única via de NOTA PROMISSÓRIA a " + drCabecalho["nome"].ToString() + ", " + cpf_cnpj + " de nº " + drCabecalho["cpf_cnpj"].ToString() + " ou a sua ordem, a quantia de " + Convert.ToDecimal(drContaReceber["valor_real"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + " R$ (" + EscreverExtenso.Extenso(Convert.ToDecimal(drContaReceber["valor_real"].ToString())) + "), em moeda corrente deste país.", fonte4, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 65 + Margem_Topo, 505, 45));
                                                //
                                                textFormatter2.DrawString("Pagável em: " + drCabecalho["cidade"].ToString() + "-" + drCabecalho["uf"].ToString(), fonte4, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 119 + Margem_Topo, 505, 10));
                                                //
                                                DateTime emissao = Convert.ToDateTime(drContaReceber["data_emissao"].ToString());
                                                //
                                                dia = emissao.Day;
                                                ano = emissao.Year;
                                                mes = cultura.TextInfo.ToTitleCase(dtfi.GetMonthName(emissao.Month).ToUpper());
                                                textFormatter3.DrawString("Emissão: " + dia + " de " + mes + " de " + ano, fonte4, XBrushes.Black, new XRect(5 + Margem_Esq, Incrementar + 119 + Margem_Topo, 570, 10));
                                                //
                                                textFormatter2.DrawString("Emitente:_______________________________________________________________________________________ ", fonte4, XBrushes.Black, new XRect(90 + Margem_Esq, Incrementar + 129 + Margem_Topo, 505, 10));
                                                //
                                                textFormatter1.DrawString(drContaReceber["nome_consumidor"].ToString(), fonte4, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 139 + Margem_Topo, 505, 10));
                                                //
                                                drContaReceber = bllContasReceber.Sel_Dados_Consumidor_Conta_Receber(drContaReceber["id_consumidor"].ToString(), drContaReceber["tipo_consumidor"].ToString()).Rows[0];
                                                //
                                                if (Convert.ToByte(drContaReceber["pessoa"]) == 0)
                                                {
                                                    cpf_cnpj = "CPF: ";
                                                }
                                                else
                                                {
                                                    cpf_cnpj = "CNPJ: ";
                                                }
                                                textFormatter1.DrawString(cpf_cnpj + drContaReceber["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 149 + Margem_Topo, 505, 10));
                                                //
                                                textFormatter1.DrawString("End.: " + drContaReceber["endereco"].ToString() + ", " + drContaReceber["numero"].ToString() + " - " + drContaReceber["bairro"].ToString() + " - " + drContaReceber["cidade"].ToString() + "/" + drContaReceber["uf"].ToString() + " - " + drContaReceber["cep"].ToString(), fonte2, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 159 + Margem_Topo, 505, 22));
                                                //
                                                textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, Incrementar + 184 + Margem_Topo, 5, 595));
                                                Incrementar = 194 + Incrementar;
                                                //
                                                if (linha == (pagina - 1) & bllVenda.Sel_Nota_Promissoria_Dados_Venda(_Cod_Venda).Rows.Count > 4)
                                                {
                                                    PrimeiraPagina = false;
                                                    Incrementar = 0;
                                                    ContadorPagina = ContadorPagina + 1;
                                                    pagina = pagina + 4;
                                                    page = doc.AddPage();
                                                    page.Width = 595;
                                                    page.Height = 842;
                                                    graphics = XGraphics.FromPdfPage(page);
                                                    textFormatter1 = new XTextFormatter(graphics);
                                                    textFormatter2 = new XTextFormatter(graphics);
                                                    textFormatter3 = new XTextFormatter(graphics);
                                                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                                    fonte4 = new XFont("Microsoft Sans Serif", 9);
                                                    pen = new XPen(XColors.Black);
                                                    pen2 = new XPen(XColors.LightGray);
                                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                                    //
                                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                                    textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                                }
                                            }
                                            else
                                            {
                                                //Logo da Promissoria
                                                XImage imagem1 = XImage.FromFile(@"C:\Sistema SEVEN\Config\Miscellaneous\rfb_np.png");
                                                //
                                                CultureInfo cultura = new CultureInfo("pt-BR");
                                                DateTimeFormatInfo dtfi = cultura.DateTimeFormat;
                                                int dia;
                                                int ano;
                                                string mes;
                                                //Linhas do datagrid                                            
                                                drContaReceber = bllVenda.Sel_Nota_Promissoria_Dados_Venda(_Cod_Venda).Rows[linha];
                                                //
                                                //Código
                                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 5 + Margem_Topo, 575, 175);
                                                //
                                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, Incrementar + 5 + Margem_Topo, 60, 175);
                                                //
                                                graphics.DrawImage(imagem1, 17 + Margem_Esq, Incrementar + 7 + Margem_Topo, 45, 171);
                                                //
                                                XImage imagem2;
                                                string espaco;
                                                int margem_esq_prom_num;
                                                if (bllContasReceber._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                                                {
                                                    imagem2 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                                                    graphics.DrawImage(imagem2, 70 + Margem_Esq, Incrementar + 7 + Margem_Topo, 58, 69);
                                                    espaco = "                           ";
                                                    margem_esq_prom_num = 135;
                                                }
                                                else
                                                {
                                                    espaco = "";
                                                    margem_esq_prom_num = 70;
                                                }
                                                //
                                                textFormatter2.DrawString("NOTA PROMISSÓRIA", fonte1, XBrushes.Black, new XRect(margem_esq_prom_num + Margem_Esq, Incrementar + 7 + Margem_Topo, page.Width, 14));
                                                //
                                                DateTime vencimento = Convert.ToDateTime(drContaReceber["data_vencimento"].ToString());
                                                //
                                                dia = vencimento.Day;
                                                ano = vencimento.Year;
                                                mes = cultura.TextInfo.ToTitleCase(dtfi.GetMonthName(vencimento.Month).ToUpper());
                                                //
                                                graphics.DrawRectangle(pen2, XBrushes.LightGray, 400 + Margem_Esq, Incrementar + 7 + Margem_Topo, 175, 14);
                                                textFormatter3.DrawString("Vencimento: " + dia + " de " + mes + " de " + ano, fonte4, XBrushes.Black, new XRect(5 + Margem_Esq, Incrementar + 8 + Margem_Topo, 570, 14));
                                                //
                                                graphics.DrawRectangle(pen2, XBrushes.LightGray, margem_esq_prom_num + Margem_Esq, Incrementar + 24 + Margem_Topo, 125, 14);
                                                textFormatter2.DrawString("Nº/Parcela: " + drContaReceber["n_promissoria"].ToString() + "/" + drContaReceber["ocorrencia_parc"].ToString(), fonte4, XBrushes.Black, new XRect(margem_esq_prom_num + Margem_Esq, Incrementar + 25 + Margem_Topo, 85, 14));
                                                //
                                                graphics.DrawRectangle(pen2, XBrushes.LightGray, 400 + Margem_Esq, Incrementar + 24 + Margem_Topo, 175, 14);
                                                textFormatter3.DrawString("Valor (R$): " + Convert.ToDecimal(drContaReceber["valor_real"].ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(5 + Margem_Esq, Incrementar + 25 + Margem_Topo, 570, 14));
                                                //
                                                drCabecalho = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                                string cpf_cnpj;
                                                if (Convert.ToByte(drCabecalho["pessoa"]) == 0)
                                                {
                                                    cpf_cnpj = "CPF";
                                                }
                                                else
                                                {
                                                    cpf_cnpj = "CNPJ";
                                                }
                                                textFormatter2.DrawString(espaco + "No dia " + dia + " do mês de " + mes + " do ano de " + ano + " pagarei(emos) por esta única via de NOTA PROMISSÓRIA a " + drCabecalho["nome"].ToString() + ", " + cpf_cnpj + " de nº " + drCabecalho["cpf_cnpj"].ToString() + " ou a sua ordem, a quantia de " + Convert.ToDecimal(drContaReceber["valor_real"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + " R$ (" + EscreverExtenso.Extenso(Convert.ToDecimal(drContaReceber["valor_real"].ToString())) + "), em moeda corrente deste país.", fonte4, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 65 + Margem_Topo, 505, 45));
                                                //
                                                textFormatter2.DrawString("Pagável em: " + drCabecalho["cidade"].ToString() + "-" + drCabecalho["uf"].ToString(), fonte4, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 119 + Margem_Topo, 505, 10));
                                                //
                                                DateTime emissao = Convert.ToDateTime(drContaReceber["data_emissao"].ToString());
                                                //
                                                dia = emissao.Day;
                                                ano = emissao.Year;
                                                mes = cultura.TextInfo.ToTitleCase(dtfi.GetMonthName(emissao.Month).ToUpper());
                                                textFormatter3.DrawString("Emissão: " + dia + " de " + mes + " de " + ano, fonte4, XBrushes.Black, new XRect(5 + Margem_Esq, Incrementar + 119 + Margem_Topo, 570, 10));
                                                //
                                                textFormatter2.DrawString("Emitente:_______________________________________________________________________________________ ", fonte4, XBrushes.Black, new XRect(90 + Margem_Esq, Incrementar + 129 + Margem_Topo, 505, 10));
                                                //
                                                textFormatter1.DrawString(drContaReceber["nome_consumidor"].ToString(), fonte4, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 139 + Margem_Topo, 505, 10));
                                                //
                                                drContaReceber = bllContasReceber.Sel_Dados_Consumidor_Conta_Receber(drContaReceber["id_consumidor"].ToString(), drContaReceber["tipo_consumidor"].ToString()).Rows[0];
                                                //
                                                if (Convert.ToByte(drContaReceber["pessoa"]) == 0)
                                                {
                                                    cpf_cnpj = "CPF: ";
                                                }
                                                else
                                                {
                                                    cpf_cnpj = "CNPJ: ";
                                                }
                                                textFormatter1.DrawString(cpf_cnpj + drContaReceber["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 149 + Margem_Topo, 505, 10));
                                                //
                                                textFormatter1.DrawString("End.: " + drContaReceber["endereco"].ToString() + ", " + drContaReceber["numero"].ToString() + " - " + drContaReceber["bairro"].ToString() + " - " + drContaReceber["cidade"].ToString() + "/" + drContaReceber["uf"].ToString() + " - " + drContaReceber["cep"].ToString(), fonte2, XBrushes.Black, new XRect(70 + Margem_Esq, Incrementar + 159 + Margem_Topo, 505, 22));
                                                //
                                                textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, Incrementar + 184 + Margem_Topo, 5, 595));
                                                Incrementar = 194 + Incrementar;
                                                //
                                                if (linha == (pagina - 1) & (bllVenda.Sel_Nota_Promissoria_Dados_Venda(_Cod_Venda).Rows.Count - 1) > linha)
                                                {
                                                    PrimeiraPagina = false;
                                                    Incrementar = 0;
                                                    ContadorPagina = ContadorPagina + 1;
                                                    pagina = pagina + 4;
                                                    page = doc.AddPage();
                                                    page.Width = 595;
                                                    page.Height = 842;
                                                    graphics = XGraphics.FromPdfPage(page);
                                                    textFormatter1 = new XTextFormatter(graphics);
                                                    textFormatter2 = new XTextFormatter(graphics);
                                                    textFormatter3 = new XTextFormatter(graphics);
                                                    fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                                    fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                                    fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                                    fonte4 = new XFont("Microsoft Sans Serif", 9);
                                                    pen = new XPen(XColors.Black);
                                                    pen2 = new XPen(XColors.LightGray);
                                                    textFormatter1.Alignment = XParagraphAlignment.Center;
                                                    textFormatter3.Alignment = XParagraphAlignment.Right;
                                                    //
                                                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                                    textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                                }
                                            }
                                        }
                                        //
                                        PdfSecuritySettings security = doc.SecuritySettings;
                                        //
                                        security.PermitAccessibilityExtractContent = false;
                                        security.PermitAnnotations = false;
                                        security.PermitAssembleDocument = false;
                                        security.PermitExtractContent = false;
                                        security.PermitFormsFill = true;
                                        security.PermitFullQualityPrint = false;
                                        security.PermitModifyDocument = false;
                                        security.PermitPrint = true;
                                        //
                                        string arqmes;
                                        if (DateTime.Now.Month < 10)
                                        {
                                            arqmes = "0" + DateTime.Now.Month;
                                        }
                                        else
                                        {
                                            arqmes = DateTime.Now.Month.ToString();
                                        }
                                        //
                                        if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Nota Promissoria\" + DateTime.Now.Year + arqmes))
                                        {
                                            Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Nota Promissoria\" + DateTime.Now.Year + arqmes);
                                            doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Nota Promissoria\" + DateTime.Now.Year + arqmes + @"\Promissoria.pdf");
                                        }
                                        else
                                        {
                                            doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Nota Promissoria\" + DateTime.Now.Year + arqmes + @"\Promissoria.pdf");
                                        }
                                        //
                                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Receber\Nota Promissoria\" + DateTime.Now.Year + arqmes + @"\Promissoria.pdf");
                                    }
                                }
                            }
                            //
                            bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                            bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                            bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                            bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                            dtItems.DataSource = null;
                            //
                            bllVenda._Quantidade = null;
                            bllVenda._Total = null;
                            bllVenda._Total_Real = null;
                            bllVenda._PDV_PesqForma_Tabela = null;
                            bllVenda._Desconto_Porc = null;
                            bllVenda._Valor_Desconto = null;
                            bllVenda._Acrescimo_Porc = null;
                            bllVenda._Valor_Acrescimo = null;
                            bllVenda._Troco = null;
                            bllVenda._Observacao = null;
                            bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                            bllVenda._N_Parcela = null;
                            bllVenda._Descricao_Produto = null;
                            bllVenda._PDV_Forma_Pagamento.Clear();
                            bllVenda._Dados_Cheque.Clear();
                            bllVenda._PDV_PesqCliente_Tabela = null;
                            bllVenda._Valor_Credito_Loja = null;
                            bllVenda._Valor_Cheque = null;
                            bllVenda._Valor_Desconto_Devolucao = null;
                            _Quantidade = "1";
                            //                               
                            lblDescCliente.Text = "Consumidor: Não identificado.";
                            bllVenda._PDV_PesqCliente_Tabela = null;
                            //
                            _Devolucao = false;
                            _Orcamento = false;
                            bllVenda._Cod_Orcamento = null;
                            bllVenda._Cod_Devolucao = null;
                            //
                            this.TopMost = true;
                            using (FrmTroco Troco = new FrmTroco(Convert.ToDecimal(_Troco).ToString("n2", new CultureInfo("pt-BR")), _Cod_Venda, lblUsuario.Text, lblVersao.Text))
                            {
                                if (Troco.ShowDialog() == DialogResult.OK)
                                {
                                    _Troco = null;
                                }
                            }
                            //
                            this.TopMost = false;
                            //
                            if (_NFCe_Ativo == true)
                            {
                                _Tipo_Venda = "NFCe";
                                lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFCe **\r\n-------------------------------------------";
                                //
                                bllConfiguracaoSistema.Alterar_Tipo_Documento_PDV(_Tipo_Venda, bllConexao._Codigo_Conexao);
                                //
                                _NFCe_Ativo = false;
                            }
                            //
                            pPanelCaixaLivre.BringToFront();
                            pPanelCaixaLivre.Visible = true;
                            //
                            _Cod_Venda = null;
                            _Data = null;
                            _Hora = null;
                            _Valor_Desconto_Venda = null;
                            _Valor_Acrescimo_Venda = null;
                            _Valor = null;
                            _Valor_Real = null;
                            _Troco = null;
                            _Cod_Consumidor = null;
                            _Nome_Consumidor = null;
                            _Cod_Usuario = null;
                            _Nome_Usuario = null;
                        }
                        else if (bllVenda._Nota_Promissoria == false)
                        {
                            if (_Devolucao == true)
                            {
                                if (bllDevolucao.Sel_Devolucao_Ainda_Existe(bllVenda._Cod_Devolucao) == false)
                                {
                                    MessageBox.Show("Esta Devolução já foi excluída.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    //
                                    bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                    bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                    bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                                    bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                                    dtItems.DataSource = null;
                                    //
                                    bllVenda._Quantidade = null;
                                    bllVenda._Total = null;
                                    bllVenda._Total_Real = null;
                                    bllVenda._PDV_PesqForma_Tabela = null;
                                    bllVenda._Desconto_Porc = null;
                                    bllVenda._Valor_Desconto = null;
                                    bllVenda._Acrescimo_Porc = null;
                                    bllVenda._Valor_Acrescimo = null;
                                    bllVenda._Troco = null;
                                    bllVenda._Observacao = null;
                                    bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                                    bllVenda._N_Parcela = null;
                                    bllVenda._Descricao_Produto = null;
                                    bllVenda._PDV_Forma_Pagamento.Clear();
                                    bllVenda._Dados_Cheque.Clear();
                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                    bllVenda._Cod_Devolucao = null;
                                    bllVenda._Cod_Orcamento = null;
                                    bllVenda._Valor_Credito_Loja = null;
                                    bllVenda._Valor_Cheque = null;
                                    //
                                    _Quantidade = "1";
                                    //
                                    lblDescCliente.Text = "Consumidor: Não identificado.";
                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                    //
                                    _Devolucao = false;
                                    //
                                    txtProduto.Select();
                                    //
                                    return;
                                }
                            }
                            else if (_Orcamento == true)
                            {
                                if (bllOrcamento.Sel_Orcamento_Ainda_Existe(bllVenda._Cod_Orcamento) == false)
                                {
                                    MessageBox.Show("Este Orçamento já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    //
                                    bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                    bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                                    bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                                    bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                                    dtItems.DataSource = null;
                                    //
                                    bllVenda._Quantidade = null;
                                    bllVenda._Total = null;
                                    bllVenda._Total_Real = null;
                                    bllVenda._PDV_PesqForma_Tabela = null;
                                    bllVenda._Desconto_Porc = null;
                                    bllVenda._Valor_Desconto = null;
                                    bllVenda._Acrescimo_Porc = null;
                                    bllVenda._Valor_Acrescimo = null;
                                    bllVenda._Troco = null;
                                    bllVenda._Observacao = null;
                                    bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                                    bllVenda._N_Parcela = null;
                                    bllVenda._Descricao_Produto = null;
                                    bllVenda._PDV_Forma_Pagamento.Clear();
                                    bllVenda._Dados_Cheque.Clear();
                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                    bllVenda._Cod_Devolucao = null;
                                    bllVenda._Cod_Orcamento = null;
                                    bllVenda._Valor_Credito_Loja = null;
                                    bllVenda._Valor_Cheque = null;
                                    //
                                    _Quantidade = "1";
                                    //
                                    lblDescCliente.Text = "Consumidor: Não identificado.";
                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                    //
                                    _Orcamento = false;
                                    //
                                    return;
                                }
                                else
                                {
                                    bllOrcamento.Alterar_Situacao_Orcamento(bllVenda._Cod_Orcamento, "REALIZADO");
                                }
                            }
                            //
                            bllVenda.Salvar_Venda(bllVenda._PDV_PesqCliente_Tabela, bllVenda._Desconto_Porc, bllVenda._Valor_Desconto, bllVenda._Acrescimo_Porc, bllVenda._Valor_Acrescimo, _Tipo_Venda, bllVenda._Total, bllVenda._Total_Real, bllVenda._Observacao, lblUsuario.Text, lblVersao.Text, bllVenda._Troco, bllVenda._Valor_Total_Pago, acresc_item, desc_item, bllVenda._Cod_Orcamento, bllVenda._Cod_Devolucao, null, false);
                            //
                            DataRow dr = bllVenda.Sel_Dados_Venda_A_Finalizar().Rows[0];
                            //
                            _Cod_Venda = dr["id_venda"].ToString();
                            _Data = dr["data"].ToString().Remove(10);
                            _Hora = dr["hora"].ToString();
                            _Valor_Desconto_Venda = dr["valor_desconto"].ToString();
                            _Valor_Desconto_Item = dr["valor_desconto_item"].ToString();
                            _Valor_Acrescimo_Venda = dr["valor_acrescimo"].ToString();
                            _Valor_Acrescimo_Item = dr["valor_acrescimo_item"].ToString();
                            _Valor = dr["valor"].ToString();
                            _Valor_Real = dr["valor_real"].ToString();
                            _Troco = dr["troco"].ToString();
                            _Cod_Consumidor = dr["id_consumidor"].ToString();
                            _Nome_Consumidor = dr["nome_consumidor"].ToString();
                            _Cod_Usuario = dr["id_usuario"].ToString();
                            _Nome_Usuario = dr["nome_usuario"].ToString();
                            _Desconto_Porc = dr["desconto_porc"].ToString();
                            _Acrescimo_Porc = dr["acrescimo_porc"].ToString();
                            _CPF_CNPJ_Consumidor = dr["cpf_cnpj_consumidor"].ToString();
                            //
                            for (int i = 0; i < dtItems.Rows.Count; i++)
                            {
                                DataGridViewRow SelectedRow = dtItems.Rows[i];

                                if (i == 0 & dtItems.Rows.Count == 1)
                                {
                                    bllVenda.Salvar_Itens_Venda(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), _Cod_Venda, _Valor_Desconto_Venda, _Valor_Acrescimo_Venda, _Valor, false, dtItems.Rows.Count.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), true, _Desconto_Porc, _Acrescimo_Porc, "PRODUTO");
                                }
                                else if (i == dtItems.Rows.Count - 1)
                                {
                                    bllVenda.Salvar_Itens_Venda(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), _Cod_Venda, _Valor_Desconto_Venda, _Valor_Acrescimo_Venda, _Valor, true, dtItems.Rows.Count.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), false, _Desconto_Porc, _Acrescimo_Porc, "PRODUTO");
                                }
                                else
                                {
                                    bllVenda.Salvar_Itens_Venda(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), _Cod_Venda, _Valor_Desconto_Venda, _Valor_Acrescimo_Venda, _Valor, false, dtItems.Rows.Count.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), false, _Desconto_Porc, _Acrescimo_Porc, "PRODUTO");
                                }
                            }
                            //
                            for (int i = 0; i < dtItems.Rows.Count; i++)
                            {
                                DataGridViewRow SelectedRow = dtItems.Rows[i];
                                bllVenda.Alterar_Estoque_Produto_PDV(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[3].Value.ToString());
                            }
                            //
                            if (bllVenda._PDV_Forma_Pagamento.Count > 1)
                            {
                                decimal valor_total_pago = 0;
                                for (int i = 0; i < bllVenda._PDV_Forma_Pagamento.Count; i++)
                                {
                                    string[] items = bllVenda._PDV_Forma_Pagamento[i].ToString().Split('—');
                                    bllVenda.Salvar_Forma_Pagamento((i + 1).ToString(), items[0], items[1], items[2], _Cod_Venda, _Data, _Hora, lblVersao.Text, lblUsuario.Text);
                                    //
                                    if (items[1].ToString() == "CREDITO LOJA")
                                    {
                                        bllVenda.Baixa_Credito_Loja_Cliente(_Cod_Consumidor, items[2].ToString());
                                    }
                                    else
                                    {
                                        bllFluxoCaixa.Salvar(_Data, _Hora, "ENTRADA", "VENDA DE PRODUTOS NO PDV", valor_total_pago.ToString(), _Cod_Venda, lblUsuario.Text, lblVersao.Text);
                                    }
                                    //
                                    if (items[1].ToString() != "CHEQUE")
                                    {
                                        valor_total_pago = valor_total_pago + Convert.ToDecimal(items[2]);
                                    }
                                }
                            }
                            else
                            {
                                string[] items = bllVenda._PDV_Forma_Pagamento[0].ToString().Split('—');
                                bllVenda.Salvar_Forma_Pagamento("1", items[0].ToString(), items[1].ToString(), items[2].ToString(), _Cod_Venda, _Data, _Hora, lblVersao.Text, lblUsuario.Text);
                                //
                                if (items[1].ToString() == "CREDITO LOJA")
                                {
                                    bllVenda.Baixa_Credito_Loja_Cliente(_Cod_Consumidor, items[2].ToString());
                                }
                                //
                                if (items[1].ToString() != "CHEQUE" & items[1].ToString() != "CREDITO LOJA")
                                {
                                    bllFluxoCaixa.Salvar(_Data, _Hora, "ENTRADA", "VENDA DE PRODUTOS NO PDV", _Valor_Real, _Cod_Venda, lblUsuario.Text, lblVersao.Text);
                                }
                            }
                            //
                            for (int i = 0; i < bllVenda._Dados_Cheque.Count; i++)
                            {
                                string[] items = bllVenda._Dados_Cheque[0].ToString().Split('—');
                                //
                                bllControleCheque.Salvar(items[0] + "—" + items[1] + "—" + items[2], items[3] + "—" + items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], _Cod_Usuario + "—" + _Nome_Usuario, lblVersao.Text, "CLIENTES", _Cod_Venda, "VENDAS");
                            }
                            //
                            if (_Tipo_Venda == "NFCe")
                            {
                                string serie;
                                serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFCe();
                                //
                                if (bllVenda._PDV_PesqCliente_Tabela != null)
                                {
                                    string[] items = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                                    //
                                    if (items[0] == "0")
                                    {
                                        bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(items[1], items[2]);
                                    }
                                }
                                //
                                bllDFe.Salvar(null, "PRÓPRIA", "65", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, bllVenda._PDV_PesqCliente_Tabela, null, bllVenda._Total, (Convert.ToDecimal(bllVenda._Valor_Desconto) + Convert.ToDecimal(desc_item)).ToString(), null, (Convert.ToDecimal(bllVenda._Valor_Acrescimo) + Convert.ToDecimal(acresc_item)).ToString(), bllVenda._Total_Real, "VENDA DE MERCADORIA", false, lblVersao.Text, "CLIENTES", "0", "0", true, "SAIDA", true, null, "PENDENTE", null, _Cod_Venda, null, false);
                                //
                                _Ult_Codigo_DFe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                //
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(_Cod_Venda).Rows.Count; i++)
                                {
                                    DataRow drItemVenda = bllVenda.Sel_Itens_Venda_Venda(_Cod_Venda).Rows[i];
                                    //
                                    DataRow drProduto = bllProduto.Sel_Prod_Codigo(drItemVenda["id_produto"].ToString(), "").Rows[0];
                                    //
                                    int item = Convert.ToInt32(drItemVenda["id_item"]) - 1;
                                    //
                                    string valor_base_calculo = bllDFe.Calculo_Valor_Base_Calculo_ICMS(drItemVenda["valor_unitario"].ToString(), drItemVenda["quantidade"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString());
                                    //
                                    string valor_base_calculo_st = "0";
                                    //
                                    string valor_icms = bllDFe.Calculo_Valor_ICMS(valor_base_calculo, drProduto["aliq_icms"].ToString());
                                    //
                                    string valor_icms_st = "0";
                                    //
                                    string total_aprox_trib = bllDFe.Calculo_Valor_Aprox_Trib(drItemVenda["valor_total"].ToString(), drItemVenda["id_produto"].ToString());
                                    //
                                    string cfop = null;
                                    if (bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL" || bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL - MEI")
                                    {
                                        if (drProduto["csosn"].ToString() == "101")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "102")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "103")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "201")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "202")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "203")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "300")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "400")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "500")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "900")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                    }
                                    //
                                    bllDFe.Salvar_Items(item.ToString(), drItemVenda["id_produto"].ToString() + "—" + drItemVenda["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), cfop, drItemVenda["quantidade"].ToString(), "1", drItemVenda["valor_total"].ToString(), drItemVenda["valor_unitario"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString(), drItemVenda["valor_total_a_desc_acresc"].ToString(), valor_icms, valor_base_calculo, _Ult_Codigo_DFe, valor_icms_st, "0", "0", valor_base_calculo_st, "0", drItemVenda["um"].ToString(), total_aprox_trib, "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                                }
                                //
                                DataRow drItemDfe;
                                decimal icms = 0;
                                decimal icmsst = 0;
                                decimal base_calculo_icms = 0;
                                decimal base_calculo_icms_st = 0;
                                decimal total_apx_trib = 0;
                                //
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(_Ult_Codigo_DFe).Rows.Count; i++)
                                {
                                    drItemDfe = bllDFe.Sel_Items_DFe(_Ult_Codigo_DFe).Rows[i];
                                    //
                                    icms += Convert.ToDecimal(drItemDfe["valor_icms"]);
                                    icmsst += Convert.ToDecimal(drItemDfe["valor_icms_st"]);
                                    base_calculo_icms += Convert.ToDecimal(drItemDfe["valor_base_calculo"]);
                                    base_calculo_icms_st += Convert.ToDecimal(drItemDfe["valor_base_calculo_st"]);
                                    total_apx_trib += Convert.ToDecimal(drItemDfe["total_aprox_trib"]);
                                }
                                //
                                bllDFe.Salvar_icms_icms_st_base_total_trib(_Ult_Codigo_DFe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_apx_trib.ToString());
                                //
                                for (int i = 0; i < bllVenda._PDV_Forma_Pagamento.Count; i++)
                                {
                                    string[] items = bllVenda._PDV_Forma_Pagamento[i].ToString().Split('—');
                                    //
                                    bllDFe.Salvar_Pagamento_DFe((i + 1).ToString(), items[0] + "—" + items[1], items[2], _Ult_Codigo_DFe);
                                }
                                //
                                lblProgresso.Visible = true;
                                lblProgresso.Text = "Transmitindo, por favor, aguarde...";
                                //
                                bool contingencia = false;
                                //
                                if (bllConfiguracaoSistema.Sel_Contingencia_NFCe() == true)
                                {
                                    bllDFe.Transmitir_NFCe(_Ult_Codigo_DFe, lblVersao.Text, true);
                                }
                                else
                                {
                                    if (bllDFe.Transmitir_NFCe(_Ult_Codigo_DFe, lblVersao.Text, false) == contingencia)
                                    {
                                        DataRow drDFe = bllDFe.Sel_Nfe_Codigo(_Ult_Codigo_DFe).Rows[0];
                                        //
                                        string[] items = drDFe["caminho_dfe"].ToString().Split('\\');
                                        //
                                        if (File.Exists(drDFe["caminho_dfe"].ToString()))
                                        {
                                            string diretorio = @"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\Cont-NFCe\" + items[5] + @"\" + items[6];
                                            if (!Directory.Exists(diretorio))
                                            {
                                                Directory.CreateDirectory(diretorio);
                                            }
                                            //
                                            File.Move(drDFe["caminho_dfe"].ToString(), diretorio + @"\" + items[7]);
                                        }
                                        //
                                        bllDFe.Transmitir_NFCe(_Ult_Codigo_DFe, lblVersao.Text, true);
                                    }
                                }
                                //
                                bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(null, null);
                                lblProgresso.Visible = false;
                            }
                            else if (_Tipo_Venda == "NFe")
                            {
                                string serie;
                                serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                //
                                if (bllVenda._PDV_PesqCliente_Tabela != null)
                                {
                                    string[] items = bllVenda._PDV_PesqCliente_Tabela.Split('—');
                                    //
                                    if (items[0] == "0")
                                    {
                                        bllClieCons.Alterar_CPF_CNPJ_Clie_Zerado(items[1], items[2]);
                                    }
                                }
                                //
                                bllDFe.Salvar(null, "PRÓPRIA", "55", null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), null, null, bllVenda._PDV_PesqCliente_Tabela, null, bllVenda._Total, (Convert.ToDecimal(bllVenda._Valor_Desconto) + Convert.ToDecimal(desc_item)).ToString(), null, (Convert.ToDecimal(bllVenda._Valor_Acrescimo) + Convert.ToDecimal(acresc_item)).ToString(), bllVenda._Total_Real, "VENDA DE MERCADORIA", false, lblVersao.Text, "CLIENTES", "0", "0", true, "SAIDA", true, null, "PENDENTE", null, _Cod_Venda, null, true);
                                //
                                _Ult_Codigo_DFe = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                //
                                for (int i = 0; i < bllVenda.Sel_Itens_Venda_Venda(_Cod_Venda).Rows.Count; i++)
                                {
                                    DataRow drItemVenda = bllVenda.Sel_Itens_Venda_Venda(_Cod_Venda).Rows[i];
                                    //
                                    DataRow drProduto = bllProduto.Sel_Prod_Codigo(drItemVenda["id_produto"].ToString(), "").Rows[0];
                                    //
                                    int item = Convert.ToInt32(drItemVenda["id_item"]) - 1;
                                    //
                                    string valor_base_calculo = bllDFe.Calculo_Valor_Base_Calculo_ICMS(drItemVenda["valor_unitario"].ToString(), drItemVenda["quantidade"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString());
                                    //
                                    string valor_base_calculo_st = "0";
                                    //
                                    string valor_icms = bllDFe.Calculo_Valor_ICMS(valor_base_calculo, drProduto["aliq_icms"].ToString());
                                    //
                                    string valor_icms_st = "0";
                                    //
                                    string total_aprox_trib = bllDFe.Calculo_Valor_Aprox_Trib(drItemVenda["valor_total"].ToString(), drItemVenda["id_produto"].ToString());
                                    //
                                    string cfop = null;
                                    if (bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL" || bllMinhaEmpresa.Sel_Empresa_CRT() == "SIMPLES NACIONAL - MEI")
                                    {
                                        if (drProduto["csosn"].ToString() == "101")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "102")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "103")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "201")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "202")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "203")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "300")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "400")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "500")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Subs_Dentro();
                                        }
                                        else if (drProduto["csosn"].ToString() == "900")
                                        {
                                            cfop = bllMinhaEmpresa.Sel_Empresa_CFOP_Trib_Dentro();
                                        }
                                    }
                                    //
                                    bllDFe.Salvar_Items(item.ToString(), drItemVenda["id_produto"].ToString() + "—" + drItemVenda["descricao"].ToString(), drProduto["ncm"].ToString(), drProduto["cest"].ToString(), drProduto["cst"].ToString(), drProduto["aliq_icms"].ToString(), drProduto["csosn"].ToString(), cfop, drItemVenda["quantidade"].ToString(), "1", drItemVenda["valor_total"].ToString(), drItemVenda["valor_unitario"].ToString(), (Convert.ToDecimal(drItemVenda["valor_desconto"]) + Convert.ToDecimal(drItemVenda["valor_desconto_item"])).ToString(), (Convert.ToDecimal(drItemVenda["valor_acrescimo"]) + Convert.ToDecimal(drItemVenda["valor_acrescimo_item"])).ToString(), drItemVenda["valor_total_a_desc_acresc"].ToString(), valor_icms, valor_base_calculo, _Ult_Codigo_DFe, valor_icms_st, "0", "0", valor_base_calculo_st, "0", drItemVenda["um"].ToString(), total_aprox_trib, "0", "0", "0", drProduto["cst_ibs_cbs"].ToString(), drProduto["cclass_trib"].ToString(), drProduto["aliq_ibs_mun"].ToString(), drProduto["aliq_ibs_est"].ToString(), drProduto["aliq_cbs"].ToString(), "0");
                                }
                                //
                                DataRow drItemDfe;
                                decimal icms = 0;
                                decimal icmsst = 0;
                                decimal base_calculo_icms = 0;
                                decimal base_calculo_icms_st = 0;
                                decimal total_apx_trib = 0;
                                //
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(_Ult_Codigo_DFe).Rows.Count; i++)
                                {
                                    drItemDfe = bllDFe.Sel_Items_DFe(_Ult_Codigo_DFe).Rows[i];
                                    //
                                    icms += Convert.ToDecimal(drItemDfe["valor_icms"]);
                                    icmsst += Convert.ToDecimal(drItemDfe["valor_icms_st"]);
                                    base_calculo_icms += Convert.ToDecimal(drItemDfe["valor_base_calculo"]);
                                    base_calculo_icms_st += Convert.ToDecimal(drItemDfe["valor_base_calculo_st"]);
                                    total_apx_trib += Convert.ToDecimal(drItemDfe["total_aprox_trib"]);
                                }
                                //
                                bllDFe.Salvar_icms_icms_st_base_total_trib(_Ult_Codigo_DFe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_apx_trib.ToString());
                                //
                                for (int i = 0; i < bllVenda._PDV_Forma_Pagamento.Count; i++)
                                {
                                    string[] items = bllVenda._PDV_Forma_Pagamento[i].ToString().Split('—');
                                    //
                                    bllDFe.Salvar_Pagamento_DFe((i + 1).ToString(), items[0] + "—" + items[1], items[2], _Ult_Codigo_DFe);
                                }
                                //
                                using (FrmCadNFeNFCe NFe = new FrmCadNFeNFCe(lblUsuario.Text, lblVersao.Text, 2, null, null, _Ult_Codigo_DFe, 0, false))
                                {
                                    if (NFe.ShowDialog() == DialogResult.Abort)
                                    {
                                        MessageBox.Show("O DFe [ " + _Ult_Codigo_DFe + " ] referente a venda atual se encontra pendente, é necessário verificar o motivo em [ Menu NFe/NFCe ] e transmitir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                            //
                            bllRegistroAtividades.Salvar("VENDA DE PRODUTOS NO PDV", "VENDAS", _Cod_Venda, lblUsuario.Text, lblVersao.Text);
                            //
                            if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "" & _Tipo_Venda == "DAV")
                            {
                                MessageBox.Show("Impressão do cupom [ NNF ] desabilitado por configuração.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)" & _Tipo_Venda == "DAV")
                            {
                                _Trabalho = 0;
                                if (bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao) == null || bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao) == "")
                                {
                                    prtDocumento.PrintController = new StandardPrintController();
                                    prtDocumento.Print();
                                }
                                else
                                {
                                    prtDocumento.PrinterSettings.PrinterName = bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao);
                                    prtDocumento.PrintController = new StandardPrintController();
                                    prtDocumento.Print();
                                }
                            }
                            else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(58mm)" & _Tipo_Venda == "DAV")
                            {
                                _Trabalho = 1;
                                if (bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao) == null || bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao) == "")
                                {
                                    prtDocumento.PrintController = new StandardPrintController();
                                    prtDocumento.Print();
                                }
                                else
                                {
                                    prtDocumento.PrinterSettings.PrinterName = bllConfiguracaoSistema.Sel_Nome_Imp_NNF(bllConexao._Codigo_Conexao);
                                    prtDocumento.PrintController = new StandardPrintController();
                                    prtDocumento.Print();
                                }
                            }
                            else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "A4(Mostrar na Tela)" & _Tipo_Venda == "DAV")
                            {
                                Process.Start(bllVenda.GerarDAV(1, _Cod_Venda));
                            }
                            else if (bllConfiguracaoSistema.Sel_Tipo_Imp_NNF(bllConexao._Codigo_Conexao) == "Impressora Térmica(80mm)(Mostrar na Tela)" & _Tipo_Venda == "DAV")
                            {
                                Process.Start(bllVenda.GerarDAV(1, _Cod_Venda));
                            }
                            //
                            bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                            bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                            bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                            bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                            dtItems.DataSource = null;
                            //
                            bllVenda._Quantidade = null;
                            bllVenda._Total = null;
                            bllVenda._Total_Real = null;
                            bllVenda._PDV_PesqForma_Tabela = null;
                            bllVenda._Desconto_Porc = null;
                            bllVenda._Valor_Desconto = null;
                            bllVenda._Acrescimo_Porc = null;
                            bllVenda._Valor_Acrescimo = null;
                            bllVenda._Troco = null;
                            bllVenda._Observacao = null;
                            bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                            bllVenda._N_Parcela = null;
                            bllVenda._Descricao_Produto = null;
                            bllVenda._PDV_Forma_Pagamento.Clear();
                            bllVenda._Dados_Cheque.Clear();
                            bllVenda._PDV_PesqCliente_Tabela = null;
                            bllVenda._Valor_Credito_Loja = null;
                            bllVenda._Valor_Cheque = null;
                            bllVenda._Valor_Desconto_Devolucao = null;
                            _Ult_Codigo_DFe = null;
                            _Quantidade = "1";
                            //
                            lblDescCliente.Text = "Consumidor: Não identificado.";
                            bllVenda._PDV_PesqCliente_Tabela = null;
                            //
                            _Devolucao = false;
                            _Orcamento = false;
                            bllVenda._Cod_Orcamento = null;
                            bllVenda._Cod_Devolucao = null;
                            //
                            this.TopMost = true;
                            using (FrmTroco Troco = new FrmTroco(Convert.ToDecimal(_Troco).ToString("n2", new CultureInfo("pt-BR")), _Cod_Venda, lblUsuario.Text, lblVersao.Text))
                            {
                                if (Troco.ShowDialog() == DialogResult.OK)
                                {
                                    _Troco = null;
                                }
                            }
                            //
                            if (_NFCe_Ativo == true)
                            {
                                _Tipo_Venda = "NFCe";
                                lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFCe **\r\n-------------------------------------------";
                                //
                                bllConfiguracaoSistema.Alterar_Tipo_Documento_PDV(_Tipo_Venda, bllConexao._Codigo_Conexao);
                                //
                                _NFCe_Ativo = false;
                            }
                            //
                            this.TopMost = false;
                            //
                            pPanelCaixaLivre.BringToFront();
                            pPanelCaixaLivre.Visible = true;
                            //
                            _Cod_Venda = null;
                            _Data = null;
                            _Hora = null;
                            _Valor_Desconto_Venda = null;
                            _Valor_Acrescimo_Venda = null;
                            _Valor = null;
                            _Valor_Real = null;
                            _Cod_Consumidor = null;
                            _Nome_Consumidor = null;
                            _Cod_Usuario = null;
                            _Nome_Usuario = null;
                        }
                    }
                    else
                    {
                        if (_Devolucao == true)
                        {
                            dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                            //
                            dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                            //
                            dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                            //
                            dtItems.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                            //
                            dtItems.Select();
                        }
                        else
                        {
                            txtProduto.Select();
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Pagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Pagamento.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                //
                _Cod_Venda = null;
                _Data = null;
                _Hora = null;
                _Valor_Desconto_Venda = null;
                _Valor_Acrescimo_Venda = null;
                _Valor = null;
                _Valor_Real = null;
                _Troco = null;
                _Cod_Consumidor = null;
                _Nome_Consumidor = null;
                _Cod_Usuario = null;
                _Nome_Usuario = null;
                //              
                this.Enabled = true;
                //
                bllVenda.Excluir_Venda_Atual_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                bllVenda.Excluir_Consumidor_PDV("Tabela [1]", bllConexao._Codigo_Conexao);
                bllVenda.Excluir_Devolucao_PDV(bllConexao._Codigo_Conexao);
                bllVenda.Excluir_Orcamento_PDV(bllConexao._Codigo_Conexao);
                dtItems.DataSource = null;
                //
                bllVenda._Quantidade = null;
                bllVenda._Total = null;
                bllVenda._Total_Real = null;
                bllVenda._PDV_PesqForma_Tabela = null;
                bllVenda._Desconto_Porc = null;
                bllVenda._Valor_Desconto = null;
                bllVenda._Acrescimo_Porc = null;
                bllVenda._Valor_Acrescimo = null;
                bllVenda._Troco = null;
                bllVenda._Observacao = null;
                bllVenda._Forma_Ent_Pagamento_Promissoria = null;
                bllVenda._N_Parcela = null;
                bllVenda._Descricao_Produto = null;
                bllVenda._PDV_Forma_Pagamento.Clear();
                bllVenda._Dados_Cheque.Clear();
                bllVenda._PDV_PesqCliente_Tabela = null;
                bllVenda._Valor_Credito_Loja = null;
                bllVenda._Valor_Cheque = null;
                bllVenda._Valor_Desconto_Devolucao = null;
                _Ult_Codigo_DFe = null;
                _Quantidade = "1";
                //
                lblDescCliente.Text = "Consumidor: Não identificado.";
                bllVenda._PDV_PesqCliente_Tabela = null;
                //
                _Devolucao = false;
                _Orcamento = false;
                bllVenda._Cod_Orcamento = null;
                bllVenda._Cod_Devolucao = null;
                //
                pPanelCaixaLivre.BringToFront();
                pPanelCaixaLivre.Visible = true;
            }
            this.Enabled = true;
        }

        private void Orcamento()
        {
            if (bllUsuario.Sel_Reallizar_Orcamento_Usuario(lblUsuario.Text) == true)
            {
                if (bllOrcamento._FrmOrcamento_Ativo == false)
                {
                    this.Enabled = false;
                    using (FrmCadOrcamento Orc = new FrmCadOrcamento(lblUsuario.Text, lblVersao.Text))
                    {
                        if (Orc.ShowDialog(this) == DialogResult.Abort)
                        {
                            txtProduto.Select();
                        }
                    }
                    this.Enabled = true;
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Orçamento já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Realizar_Orcamento"))
                {
                    if (Login.ShowDialog() == DialogResult.OK)
                    {
                        if (bllVenda._Realizar_Orcamento == 1)
                        {
                            if (bllOrcamento._FrmOrcamento_Ativo == false)
                            {
                                this.Enabled = false;
                                using (FrmCadOrcamento Orc = new FrmCadOrcamento(lblUsuario.Text, lblVersao.Text))
                                {
                                    if (Orc.ShowDialog() == DialogResult.Abort)
                                    {
                                        txtProduto.Select();
                                    }
                                }
                                this.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("O fomulário Cadastro de Orçamento já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else if (bllVenda._Realizar_Orcamento == 0)
                        {
                            MessageBox.Show("O Usuário informado não possui permissão para realizar Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void lblVersao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblVersao.BackColor = Color.DimGray;
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblUsuario.Text.Replace('—', '-'), "Informações do Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblVersao_Click(object sender, EventArgs e)
        {
            if (_Atualizacao_Disponivel == false)
            {
                using (FrmVersao Ver = new FrmVersao(_Versao))
                {
                    if (Ver.ShowDialog() == DialogResult.Abort)
                    {
                        txtProduto.Select();
                    }
                }
            }
            else
            {
                if (_Atualizacao_Disponivel == true)
                {
                    if (bckwIndeterminado.IsBusy == true)
                    {
                        MessageBox.Show("Sua solicitação está sendo processada. Por favor, aguarde um momento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        _Mostrar_Mensagem = true;
                        //
                        bckwIndeterminado.RunWorkerAsync();
                    }
                }
            }
        }

        private void lblSair_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblSair.BackColor = Color.Gray;
        }

        private void lblSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblSair.BackColor = Color.DimGray;
        }

        private void btnProcurarProd_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarProd_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterarQuantidade_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterarQuantidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAlterarValorUnitario_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterarValorUnitario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblTipoVenda_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblTipoVenda.BackColor = Color.Gray;
        }

        private void lblTipoVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblTipoVenda.BackColor = Color.DimGray;
        }

        private void lblAjuda_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblAjuda.BackColor = Color.Gray;
        }

        private void lblAjuda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblAjuda.BackColor = Color.DimGray;
        }

        private void lblPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblPagamento.BackColor = Color.WhiteSmoke;
        }

        private void lblPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblPagamento.BackColor = Color.LightGray;
        }

        private void lblOrcamento_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblOrcamento.BackColor = Color.WhiteSmoke;
        }

        private void lblOrcamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblOrcamento.BackColor = Color.LightGray;
        }

        private void lblQuantidade_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblQuantidade.BackColor = Color.WhiteSmoke;
        }

        private void lblQuantidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblQuantidade.BackColor = Color.LightGray;
        }

        private void lblCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblCancelar.BackColor = Color.WhiteSmoke;
        }

        private void lblCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblCancelar.BackColor = Color.LightGray;
        }

        private void lblConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblConsumidor.BackColor = Color.WhiteSmoke;
        }

        private void lblConsumidor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblConsumidor.BackColor = Color.LightGray;
        }

        private void lblCapturar_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblCapturar.BackColor = Color.WhiteSmoke;
        }

        private void lblCapturar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblCapturar.BackColor = Color.LightGray;
        }

        private void lblDevolucao_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblDevolucao.BackColor = Color.WhiteSmoke;
        }

        private void lblDevolucao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblDevolucao.BackColor = Color.LightGray;
        }

        private void lblOutros_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblOutros.BackColor = Color.WhiteSmoke;
        }

        private void lblOutros_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblOutros.BackColor = Color.LightGray;
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Permitir_Finalizar_PDV_Usuario(lblUsuario.Text) == true)
                {

                    DialogResult = MessageBox.Show("Deseja finalizar o aplicativo Sistema SEVEN - PDV?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (bllMinhaEmpresa.Sel_Empresa_Backup_Automatico() == true & _Reiniciar == false)
                        {
                            if (bllBackup.Sel_Data_Ult_Backup() == null || bllBackup.Sel_Data_Ult_Backup() == "")
                            {
                                if (bckwIndeterminado.IsBusy != true)
                                {
                                    if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != null)
                                    {
                                        using (FrmProgresso Prog = new FrmProgresso(1))
                                        {
                                            if (Prog.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (Convert.ToDateTime(bllBackup.Sel_Data_Ult_Backup()).Day != DateTime.Now.Day)
                                {
                                    if (bckwIndeterminado.IsBusy != true)
                                    {
                                        if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != null)
                                        {
                                            using (FrmProgresso Prog = new FrmProgresso(1))
                                            {
                                                if (Prog.ShowDialog() == DialogResult.OK)
                                                {

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //
                        Application.Exit();
                    }
                }
                else
                {
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Fin_PDV"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Fin_PDV == 1)
                            {
                                DialogResult = MessageBox.Show("Deseja finalizar o aplicativo Sistema SEVEN - PDV?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {

                                    if (bllMinhaEmpresa.Sel_Empresa_Backup_Automatico() == true & _Reiniciar == false)
                                    {
                                        if (bckwIndeterminado.IsBusy != true)
                                        {
                                            if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != null)
                                            {
                                                using (FrmProgresso Prog = new FrmProgresso(1))
                                                {
                                                    if (Prog.ShowDialog() == DialogResult.OK)
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }
                                    Application.Exit();
                                }
                            }
                            else if (bllVenda._Permitir_Fin_PDV == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para finalizar o aplicativo Sistema SEVEN - PDV.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyUp do formulário FrmSistema PDV.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyUp do formulário FrmSistema PDV.");
                }
            }
        }

        private void FrmSistemaBigPicture_KeyDown(object sender, KeyEventArgs e)
        {
            if (pPanelCaixaLivre.Visible == true & (e.KeyCode != Keys.Escape & e.KeyCode != Keys.F5 & e.KeyCode != Keys.Delete & e.KeyCode != Keys.F2))
            {
                e.Handled = false;
                pPanelCaixaLivre.Visible = false;
            }
            //
            if (pPanelCaixaLivre.Visible == false)
            {
                segundosSemTecla = 0;
                tInativo.Stop();
                tInativo.Start();
            }
            //
            if (e.KeyCode == Keys.Escape)
            {
                lblSair.BackColor = Color.Gray;
            }
            else if (e.KeyCode == Keys.Home)
            {
                lblTipoVenda.BackColor = Color.Gray;
            }
            else if (e.KeyCode == Keys.F1)
            {
                lblAjuda.BackColor = Color.Gray;
            }
            else if (e.KeyCode == Keys.F2)
            {
                lblPagamento.BackColor = Color.White;
            }
            else if (e.KeyCode == Keys.F3)
            {
                lblOrcamento.BackColor = Color.White;                
            }
            else if (e.KeyCode == Keys.F4)
            {
                lblQuantidade.BackColor = Color.White;                
            }
            else if (e.KeyCode == Keys.F5)
            {
                lblCancelar.BackColor = Color.White;
            }
            else if (e.KeyCode == Keys.F6)
            {
                lblConsumidor.BackColor = Color.White;
            }
            else if (e.KeyCode == Keys.F7)
            {
                lblCapturar.BackColor = Color.White;
            }
            else if (e.KeyCode == Keys.F8)
            {
                lblDevolucao.BackColor = Color.White;
            }
            else if (e.KeyCode == Keys.F9)
            {
                lblOutros.BackColor = Color.White;
            }
            else if (e.KeyCode == Keys.F10)
            {
                lblCalculadora.BackColor = Color.Gray;
            }
        }
    
        private void lblTipoVenda_Click(object sender, EventArgs e)
        {
            lblTipoVenda.BackColor = Color.LightGray;
            try
            {
                if (_Tipo_Venda == "DAV")
                {
                    DialogResult = MessageBox.Show("Deseja alterar o tipo de documento da venda para NFCe\n[ Nota Fiscal de Consumidor Eletrônica Modelo 65 ]?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        _Tipo_Venda = "NFCe";
                        lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFCe **\r\n-------------------------------------------";
                    }
                }
                else if (_Tipo_Venda == "NFCe")
                {
                    DialogResult = MessageBox.Show("Deseja alterar o tipo de documento da venda para NFe [ Nota Fiscal Eletrônica Modelo 55 ]?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        _Tipo_Venda = "NFe";
                        lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFe **\r\n-------------------------------------------";
                    }
                }
                else if (_Tipo_Venda == "NFe")
                {
                    DialogResult = MessageBox.Show("Deseja alterar o tipo de documento da venda para DAV [ Documento Auxiliar de Venda ]?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        _Tipo_Venda = "DAV";
                        lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** DAV **\r\n-------------------------------------------";
                    }
                }
                //
                bllConfiguracaoSistema.Alterar_Tipo_Documento_PDV(_Tipo_Venda, bllConexao._Codigo_Conexao);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do KeyUp.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do KeyUp.");
                }
            }
        }

        private void lblPagamento_Click(object sender, EventArgs e)
        {
            lblPagamento.BackColor = Color.LightGray;
            if (dtItems.DataSource != null)
            {
                Pagamento();
            }
            else
            {
                MessageBox.Show("Nenhum item foi adicionado à venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblOrcamento_Click(object sender, EventArgs e)
        {
            if (dtItems.DataSource == null)
            {
                Orcamento();
            }
            else
            {
                MessageBox.Show("Existem itens de uma possível venda, finalize a venda ou cancele os itens para realizar um Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            if (dtItems.DataSource != null || bllVenda._PDV_PesqCliente_Tabela != null)
            {
                Cancelar_Venda_Atual();
            }
            else
            {
                MessageBox.Show("Não é possível cancelar: nenhum item foi adicionado e nenhum consumidor foi informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dtItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
                //
                dtItems.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItems.Columns[0].DefaultCellStyle.Format = "D3";
                dtItems.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItems.Columns[3].DefaultCellStyle.Format = "n2";
                dtItems.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItems.Columns[5].DefaultCellStyle.Format = "n2";
                dtItems.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItems.Columns[9].DefaultCellStyle.Format = "n2";
                //
                dtItems.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtItems.DefaultCellStyle.SelectionForeColor = Color.Black;
                //
                lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                txtQuantidade.Text = Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR"));
                txtUnitario.Text = Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR"));
                lblValorTotalunit.Text = Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtItems.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtItems.");
                }
            }
        }

        private void btnAlterarValorUnitario_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
            //
            try
            {
                DialogResult = MessageBox.Show("Deseja alterar o Valor Unitário?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (txtUnitario.Text.Trim() == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Valor Unitário ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtUnitario.Text = Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR"));
                        txtUnitario.Select();
                    }
                    else if (txtQuantidade.Text.Trim() == "0" || txtQuantidade.Text.Trim() == "0,00")
                    {
                        MessageBox.Show("Não é possível informar  valor [ 0 ] para o campo [ Quantidade ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtUnitario.Text = Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR"));
                        txtUnitario.Select();
                    }
                    else
                    {
                        if (bllUsuario.Sel_Permitir_Alt_Prod_Item_Usuario(lblUsuario.Text) == true)
                        {
                            int item_selecionado = SelectedRow.Index;

                            DataRow dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];

                            bllVenda.Alterar_Unitario_Item(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), txtUnitario.Text.Trim(), dr["acrescimo_porc"].ToString(), dr["desconto_porc"].ToString());

                            dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);

                            txtProduto.Text = null;

                            dtItems.CurrentCell = dtItems.Rows[item_selecionado].Cells[0];

                            dtItems.Rows[item_selecionado].Selected = true;

                            dtItems.FirstDisplayedScrollingRowIndex = item_selecionado;

                            dtItems.Select();
                        }
                        else
                        {
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Alt_Prod_Item"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Alt_Prod_Item == 1)
                                    {
                                        int item_selecionado = SelectedRow.Index;

                                        DataRow dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];

                                        bllVenda.Alterar_Unitario_Item(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), txtUnitario.Text.Trim(), dr["acrescimo_porc"].ToString(), dr["desconto_porc"].ToString());

                                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);

                                        txtProduto.Text = null;

                                        dtItems.CurrentCell = dtItems.Rows[item_selecionado].Cells[0];

                                        dtItems.Rows[item_selecionado].Selected = true;

                                        dtItems.FirstDisplayedScrollingRowIndex = item_selecionado;

                                        dtItems.Select();
                                    }
                                    else if (bllVenda._Permitir_Alt_Prod_Item == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para alterar Produto/Item.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        txtUnitario.Text = Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR"));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterarValorUnitario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterarValorUnitario.");
                }
                txtUnitario.Select();
                txtUnitario.Text = Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR"));
            }
        }

        private void lblQuantidade_Click(object sender, EventArgs e)
        {
            Quantidade();
        }

        private void lblConsumidor_Click(object sender, EventArgs e)
        {
            Identificar_Consumidor();
        }

        private void tInativo_Tick(object sender, EventArgs e)
        {
            segundosSemTecla++;
            //
            if (segundosSemTecla == 10)
            {
                int quantidadeAbertos = Application.OpenForms.Count;
                //
                if (quantidadeAbertos == 1 & dtItems.DataSource == null & bllVenda._PDV_PesqCliente_Tabela == null)
                {
                    pPanelCaixaLivre.BringToFront();
                    pPanelCaixaLivre.Visible = true;
                    segundosSemTecla = 0;
                    tInativo.Stop();
                }
                else
                {
                    segundosSemTecla = 0;
                    tInativo.Stop();
                }
            }
        }

        private void lblCapturar_Click(object sender, EventArgs e)
        {
            Capturar();
        }

        private void lblDevolucao_Click(object sender, EventArgs e)
        {
            if (dtItems.DataSource == null)
            {
                Devolucao();
            }
            else
            {
                MessageBox.Show("Existem itens de uma possível venda, finalize a venda ou cancele os itens para realizar uma Devolução.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmSistemaBigPicture_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == true)
            {
                if (pPanelCaixaFechado.Visible == false)
                {
                    tInativo.Start();
                }
            }
            else
            {
                tInativo.Stop();
            }
        }

        private void pPanelProtetorTela_Click(object sender, EventArgs e)
        {
            pPanelCaixaLivre.Visible = false;
        }

        private void pPanelProtetorTela_DoubleClick(object sender, EventArgs e)
        {
            pPanelCaixaLivre.Visible = false;
        }

        private void pPanelProtetorTela_VisibleChanged(object sender, EventArgs e)
        {
            if (pPanelCaixaLivre.Visible == true)
            {
                txtProduto.Select();
                tInativo.Stop();
            }
            else
            {
                tInativo.Start();
            }
        }

        private void lblCabecalhoNota_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void pPanel3_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void pPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void pPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void lblCabecalhoNota1_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void dtItems_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void lblValorTotal_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void lblValorTotalunit_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void lblQuantidadeItem_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void lblMensagemTopo_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void lblData_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void lblPDV_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            if (txtQuantidade.Text != "")
            {
                if (txtQuantidade.Text.Contains("'") || txtQuantidade.Text.Contains(";") || txtQuantidade.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantidade.Text = null;
                    txtQuantidade.Select();
                }
                else
                {
                    try
                    {
                        txtQuantidade.Text = Convert.ToDecimal(txtQuantidade.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtQuantidade.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtQuantidade.");
                        }
                        txtQuantidade.Text = null;
                    }
                }
            }
            txtQuantidade.BackColor = Color.White;
        }

        private void txtQuantidade_Enter(object sender, EventArgs e)
        {
            txtQuantidade.BackColor = Color.LightBlue;
        }

        private void txtUnitario_Leave(object sender, EventArgs e)
        {
            if (txtUnitario.Text != "")
            {
                if (txtUnitario.Text.Contains("'") || txtUnitario.Text.Contains(";") || txtUnitario.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUnitario.Text = null;
                    txtUnitario.Select();
                }
                else
                {
                    try
                    {
                        txtUnitario.Text = Convert.ToDecimal(txtUnitario.Text).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtUnitario.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto txtUnitario.");
                        }
                        txtUnitario.Text = null;
                    }
                }
            }
            txtUnitario.BackColor = Color.White;
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtQuantidade.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnAlterarQuantidade.Select();
            }
        }

        private void txtUnitario_Enter(object sender, EventArgs e)
        {
            txtUnitario.BackColor = Color.LightBlue;
        }

        private void FrmSistemaBigPicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_Acesso_Negado != true)
                {
                    if (bllUsuario.Sel_Permitir_Finalizar_PDV_Usuario(lblUsuario.Text) == false)
                    {

                        if (bllVenda._Permitir_Fin_PDV == 0)
                        {
                            e.Cancel = true;
                        }
                    }
                    //
                    if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) == null & bllOrcamento.Sel_Item_Orc_Todos(bllConexao._Codigo_Conexao) == null)
                    {
                        bllVenda.Excluir_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                    }
                    //
                    string[] items = lblUsuario.Text.Remove(0, 12).Split('—');
                    //
                    bllRegistroAtividades.Salvar("O USUARIO " + lblUsuario.Text.Remove(0, 12) + " DESLOGOU DO SISTEMA SEVEN PDV.", "USUARIO", items[0], lblUsuario.Text, lblVersao.Text);
                    //
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sistema SEVEN - PDV foi finalizado.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sistema SEVEN - PDV foi finalizado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmSistemaBigPicture.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmSistemaBigPicture.");
                }
            }
        }

        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (dtItems.DataSource != null)
            {
                if (e.KeyCode == Keys.Up)
                {
                    dtItems.Select();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    dtItems.Select();
                }
            }
        }

        private void txtUnitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (dtItems.DataSource != null)
            {
                if (e.KeyCode == Keys.Up)
                {
                    dtItems.Select();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    dtItems.Select();
                }
            }
        }

        private void lblOutros_Click(object sender, EventArgs e)
        {
            Menu_BigPicture();
        }

        private void pPanelCaixaFechado_VisibleChanged(object sender, EventArgs e)
        {
            if (pPanelCaixaFechado.Visible == true)
            {
                pPanel1.Enabled = false;
                pPanel2.Enabled = false;
                pPanel3.Enabled = false;
            }
            else
            {
                pPanel1.Enabled = true;
                pPanel2.Enabled = true;
                pPanel3.Enabled = true;
            }
        }

        private void pPanelCaixaFechado_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Reallizar_Abert_Caixa_Usuario(lblUsuario.Text) == true)
                {
                    this.Enabled = false;
                    using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                    {
                        if (Abrir.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                            {
                                DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                //
                                if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                {
                                    if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                    {
                                        bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                        //
                                        lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                        //
                                    }
                                    else
                                    {
                                        lblDescCliente.Text = "Consumidor: Não identificado.";
                                        bllVenda._PDV_PesqCliente_Tabela = null;
                                    }
                                    //
                                    if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                    {
                                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                        //
                                        dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                        //
                                        dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                        //
                                        dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                        //
                                        DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                        //
                                        lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                    }
                                    //
                                    txtProduto.Text = null;
                                    //
                                    txtProduto.Select();
                                    //
                                    pPanelCaixaLivre.Visible = false;
                                    pPanelCaixaFechado.Visible = false;
                                }
                            }
                            else
                            {
                                bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                //
                                bllVenda._PDV_PesqCliente_Tabela = null;
                                //
                                txtProduto.Select();
                                //
                                pPanelCaixaLivre.BringToFront();
                                pPanelCaixaLivre.Visible = true;
                                pPanelCaixaFechado.Visible = false;

                            }
                        }
                    }
                    this.Enabled = true;
                }
                else
                {
                    this.Enabled = false;
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Abrir_Caixa"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Abrir_Caixa == 1)
                            {
                                using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                                {
                                    if (Abrir.ShowDialog() == DialogResult.OK)
                                    {
                                        if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                                        {
                                            DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                            //
                                            if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                            {
                                                if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                                {
                                                    bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                                    //
                                                    lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                                }
                                                else
                                                {
                                                    lblDescCliente.Text = "Consumidor: Não identificado.";
                                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                                }
                                                //
                                                if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                                {
                                                    dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                                    //
                                                    dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                                    //
                                                    dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                                    //
                                                    dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                                    //
                                                    DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                                    //
                                                    lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                                    //
                                                }
                                                //
                                                txtProduto.Text = null;
                                                //
                                                txtProduto.Select();
                                                //
                                                pPanelCaixaLivre.Visible = false;
                                                pPanelCaixaFechado.Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                            //
                                            bllVenda._PDV_PesqCliente_Tabela = null;
                                            //
                                            txtProduto.Select();
                                            //
                                            pPanelCaixaLivre.BringToFront();
                                            pPanelCaixaLivre.Visible = true;
                                            pPanelCaixaFechado.Visible = false;
                                        }
                                    }
                                }
                            }
                            else if (bllVenda._Permitir_Abrir_Caixa == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para realizar Abertura de Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    this.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pPanelCaixaFechado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pPanelCaixaFechado.");
                }
            }
        }

        private void pPanelCaixaFechado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Reallizar_Abert_Caixa_Usuario(lblUsuario.Text) == true)
                {
                    this.Enabled = false;
                    using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                    {
                        if (Abrir.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                            {
                                DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                //
                                if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                {
                                    if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                    {
                                        bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                        //
                                        lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                        //
                                    }
                                    else
                                    {
                                        lblDescCliente.Text = "Consumidor: Não identificado.";
                                        bllVenda._PDV_PesqCliente_Tabela = null;
                                    }
                                    //
                                    if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                    {
                                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                        //
                                        dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                        //
                                        dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                        //
                                        dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                        //
                                        DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                        //
                                        lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                    }
                                    //
                                    txtProduto.Text = null;
                                    //
                                    txtProduto.Select();
                                    //
                                    pPanelCaixaLivre.Visible = false;
                                    pPanelCaixaFechado.Visible = false;
                                }
                            }
                            else
                            {
                                bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                //
                                bllVenda._PDV_PesqCliente_Tabela = null;
                                //
                                txtProduto.Select();
                                //
                                pPanelCaixaLivre.BringToFront();
                                pPanelCaixaLivre.Visible = true;
                                pPanelCaixaFechado.Visible = false;
                            }
                        }
                    }
                    this.Enabled = true;
                }
                else
                {
                    this.Enabled = false;
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Abrir_Caixa"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Abrir_Caixa == 1)
                            {
                                using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                                {
                                    if (Abrir.ShowDialog() == DialogResult.OK)
                                    {
                                        if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                                        {
                                            DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                            //
                                            if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                            {
                                                if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                                {
                                                    bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                                    //
                                                    lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                                }
                                                else
                                                {
                                                    lblDescCliente.Text = "Consumidor: Não identificado.";
                                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                                }
                                                //
                                                if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                                {
                                                    dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                                    //
                                                    dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                                    //
                                                    dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                                    //
                                                    dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                                    //
                                                    DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                                    //
                                                    lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                                    //
                                                }
                                                //
                                                txtProduto.Text = null;
                                                //
                                                txtProduto.Select();
                                                //
                                                pPanelCaixaLivre.Visible = false;
                                                pPanelCaixaFechado.Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                            //
                                            bllVenda._PDV_PesqCliente_Tabela = null;
                                            //
                                            txtProduto.Select();
                                            //
                                            pPanelCaixaLivre.BringToFront();
                                            pPanelCaixaLivre.Visible = true;
                                            pPanelCaixaFechado.Visible = false;
                                        }
                                    }
                                }
                            }
                            else if (bllVenda._Permitir_Abrir_Caixa == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para realizar Abertura de Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    this.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pPanelCaixaFechado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pPanelCaixaFechado.");
                }
            }
        }

        private void prtDocumento_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_Trabalho == 0)
            {
                DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                //
                string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                byte pessoa;
                //
                nome = drPDF["nome"].ToString();
                fantasia = drPDF["fantasia"].ToString();
                cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                endereco = drPDF["endereco"].ToString();
                ie_rg = drPDF["ie_rg"].ToString();
                numero = drPDF["numero"].ToString();
                bairro = drPDF["bairro"].ToString();
                cidade = drPDF["cidade"].ToString();
                uf = drPDF["uf"].ToString();
                cep = drPDF["cep"].ToString();
                pessoa = Convert.ToByte(drPDF["pessoa"]);
                //
                var fonte1 = new Font("Courrier Regular", 7, FontStyle.Bold);
                var fonte2 = new Font("Courrier New", 7, FontStyle.Regular);
                var fonte3 = new Font("Courrier New", 6, FontStyle.Regular);
                var fonte4 = new Font("Courrier Regular", 5, FontStyle.Italic);
                //
                StringFormat Sf = new StringFormat();
                StringFormat Sf1 = new StringFormat();
                StringFormat Sf2 = new StringFormat();
                //
                Sf.Alignment = StringAlignment.Center;
                Sf1.Alignment = StringAlignment.Near;
                Sf2.Alignment = StringAlignment.Far;
                //
                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_80_Pdv(bllConexao._Codigo_Conexao);
                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_80_Pdv(bllConexao._Codigo_Conexao);
                //
                Pen pen = new Pen(Color.Black);
                //
                int Incrementar = 0;
                //
                if (bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                {
                    Image imagem1 = Image.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                    e.Graphics.DrawImage(imagem1, 99 + Margem_Esq, 2 + Margem_Topo, 81, 95);
                }
                else
                {
                    Margem_Topo = Convert.ToInt16(Margem_Topo - 96);
                }
                //
                Margem_Topo = Margem_Topo + 33;
                //
                //e.Graphics.DrawRectangle(pen, 1 + Margem_Esq, AumentoDeLinhaFixo + 118 + Margem_Topo, 279, 70);
                //e.Graphics.DrawRectangle(pen, 0 + Margem_Esq, 167 + AumentoDeLinhaFixo + Margem_Topo, 275, 33);
                if (nome.Length > 30)
                {
                    if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                    {
                        e.Graphics.DrawString(nome.Insert(30, Environment.NewLine), fonte1, Brushes.Black, new Rectangle(1 + Margem_Esq, 85 + Margem_Topo, 280, 22), Sf);
                    }
                    else
                    {
                        e.Graphics.DrawString(nome, fonte1, Brushes.Black, new Rectangle(1 + Margem_Esq, 85 + Margem_Topo, 280, 22), Sf);
                    }
                    Incrementar = Incrementar + 11;
                }
                else
                {
                    e.Graphics.DrawString(nome, fonte1, Brushes.Black, new Rectangle(1 + Margem_Esq, 85 + Margem_Topo, 280, 11), Sf);
                }
                //
                if (fantasia.Length > 30)
                {
                    if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                    {
                        e.Graphics.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, Brushes.Black, new Rectangle(1 + Margem_Esq, Incrementar + 96 + Margem_Topo, 280, 22), Sf);
                    }
                    else
                    {
                        e.Graphics.DrawString(fantasia, fonte2, Brushes.Black, new Rectangle(1 + Margem_Esq, Incrementar + 96 + Margem_Topo, 280, 22), Sf);
                    }
                    Incrementar = Incrementar + 8;
                }
                else
                {
                    e.Graphics.DrawString(fantasia, fonte2, Brushes.Black, new Rectangle(1 + Margem_Esq, Incrementar + 96 + Margem_Topo, 280, 11), Sf);
                }
                //                
                e.Graphics.DrawString(cpf_cnpj + "   " + ie_rg, fonte2, Brushes.Black, new Rectangle(1 + Margem_Esq, Incrementar + 107 + Margem_Topo, 280, 11), Sf);
                //
                e.Graphics.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte2, Brushes.Black, new Rectangle(1 + Margem_Esq, Incrementar + 118 + Margem_Topo, 279, 70), Sf);
                //
                Incrementar = Incrementar - 22;
                //
                e.Graphics.DrawString("-------------------------------------------------------------------------------------", fonte2, Brushes.Black, new Rectangle(0 + Margem_Esq, 167 + Incrementar + Margem_Topo, 340, 33), Sf1);

                e.Graphics.DrawString("DAV - Documento Auxiliar de Venda", fonte1, Brushes.Black, new Rectangle(5 + Margem_Esq, 176 + Incrementar + Margem_Topo, 275, 33), Sf);

                e.Graphics.DrawString("-------------------------------------------------------------------------------------", fonte2, Brushes.Black, new Rectangle(0 + Margem_Esq, 182 + Incrementar + Margem_Topo, 340, 33), Sf1);
                //
                e.Graphics.DrawString(" #   Código  Descrição                   Qtde.   UN.   Vl.Unit    Vl.Total", fonte2, Brushes.Black, new Rectangle(0 + Margem_Esq, Incrementar + 189 + Margem_Topo, 285, 11));
                //

                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    DataGridViewRow SelectedRow = dtItems.Rows[i];
                    //
                    e.Graphics.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 200 + Margem_Topo, 275, 11));
                    //  
                    e.Graphics.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, Brushes.Black, new Rectangle(21 + Margem_Esq, Incrementar + 200 + Margem_Topo, 275, 11));
                    //         
                    e.Graphics.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 65, 11), Sf);
                    //
                    //e.Graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 211 + Margem_Topo, 85, 11);
                    e.Graphics.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(105 + Margem_Esq, Incrementar + 211 + Margem_Topo, 85, 11), Sf);
                    //
                    //e.Graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 215 + Margem_Topo, 65, 11);
                    e.Graphics.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11), Sf2);
                    //                
                    DataRow dtDescAcresc = bllVenda.Sel_Desconto_Acrescimo_Venda(_Cod_Venda, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    Incrementar = Incrementar + 8;
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                    e.Graphics.DrawString("Desconto: " + (Convert.ToDecimal(dtDescAcresc["valor_desconto"]) + Convert.ToDecimal(dtDescAcresc["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 85, 11));
                    //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                    e.Graphics.DrawString("Acréscimo: " + (Convert.ToDecimal(dtDescAcresc["valor_acrescimo"]) + Convert.ToDecimal(dtDescAcresc["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(105 + Margem_Esq, Incrementar + 211 + Margem_Topo, 85, 11));
                    e.Graphics.DrawString(Convert.ToDecimal(dtDescAcresc["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11), Sf2);
                    //
                    Incrementar = Incrementar + 21;
                }
                //
                Incrementar = Incrementar + 5;
                //
                e.Graphics.DrawString("Qtde. total de itens", fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 200 + Margem_Topo, 275, 11));
                //
                e.Graphics.DrawString(Convert.ToInt16(dtItems.Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 200 + Margem_Topo, 275, 11), Sf2);
                //
                e.Graphics.DrawString("Valor Total R$", fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11));
                //
                e.Graphics.DrawString(Convert.ToDecimal(_Valor).ToString("n2", new CultureInfo("pt-BR")), fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11), Sf2);
                //
                Incrementar = Incrementar + 11;
                //
                if (_Valor_Desconto_Venda != "0" || _Valor_Desconto_Item != "0")
                {
                    e.Graphics.DrawString("Descontos R$", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11));
                    //
                    e.Graphics.DrawString("-" + (Convert.ToDecimal(_Valor_Desconto_Venda) + Convert.ToDecimal(_Valor_Desconto_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11), Sf2);
                    Incrementar = Incrementar + 11;
                }
                //
                if (_Valor_Acrescimo_Venda != "0" || _Valor_Acrescimo_Item != "0")
                {
                    e.Graphics.DrawString("Acréscimos R$", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11));
                    //
                    e.Graphics.DrawString((Convert.ToDecimal(_Valor_Acrescimo_Venda) + Convert.ToDecimal(_Valor_Acrescimo_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11), Sf2);
                    Incrementar = Incrementar + 11;
                }
                //
                e.Graphics.DrawString("Valor a Pagar R$", fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11));
                //
                e.Graphics.DrawString(Convert.ToDecimal(_Valor_Real).ToString("n2", new CultureInfo("pt-BR")), fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11), Sf2);
                //
                e.Graphics.DrawString("FORMA PAGAMENTO", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 222 + Margem_Topo, 275, 11));
                //
                e.Graphics.DrawString("VALOR PAGO R$", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 222 + Margem_Topo, 275, 11), Sf2);
                //
                for (int i = 0; i < bllVenda.Sel_Dados_Pagamento_Venda(_Cod_Venda).Rows.Count; i++)
                {
                    drPDF = bllVenda.Sel_Dados_Pagamento_Venda(_Cod_Venda).Rows[i];
                    //
                    string tipo = drPDF["tipo"].ToString();
                    //
                    if (tipo == "DINHEIRO")
                    {
                        e.Graphics.DrawString("Dinheiro", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "CARTAO DE DEBITO")
                    {
                        e.Graphics.DrawString("Cartão Débito", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "CARTAO DE CREDITO")
                    {
                        e.Graphics.DrawString("Cartão Crédito", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "NOTA PROMISSORIA")
                    {
                        e.Graphics.DrawString("À Prazo", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "PIX")
                    {
                        e.Graphics.DrawString("Pagamento Instantâneo", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "CREDITO LOJA")
                    {
                        e.Graphics.DrawString("Crédito Loja", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "CHEQUE")
                    {
                        e.Graphics.DrawString("Cheque", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    //
                    e.Graphics.DrawString(Convert.ToDecimal(drPDF["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11), Sf2);
                    //
                    Incrementar = Incrementar + 11;
                }
                //
                if (_Troco != "0")
                {
                    e.Graphics.DrawString("Troco R$", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    e.Graphics.DrawString(Convert.ToDecimal(_Troco).ToString("n2", new CultureInfo("pt-BR")), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11), Sf2);
                    Incrementar = Incrementar + 11;
                }
                //
                if (_CPF_CNPJ_Consumidor != "")
                {
                    e.Graphics.DrawString(_CPF_CNPJ_Consumidor, fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 15), Sf);
                    Incrementar = Incrementar + 10;
                }
                else
                {
                    e.Graphics.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 15), Sf);
                    Incrementar = Incrementar + 10;
                }
                //
                e.Graphics.DrawString("DAV nº: " + _Cod_Venda + "   " + _Data + "   " + _Hora, fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11), Sf);
                //
                if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == false & _CPF_CNPJ_Consumidor == "")
                {
                    e.Graphics.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 244 + Margem_Topo, 275, 22), Sf);
                    //
                    Incrementar = Incrementar + 22;
                    //
                    e.Graphics.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 244 + Margem_Topo, 275, 11), Sf2);
                }
                else if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == true & _CPF_CNPJ_Consumidor != "")
                {
                    e.Graphics.DrawString("SEM VALOR FISCAL\n____________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 244 + Margem_Topo, 275, 46), Sf);
                    //
                    Incrementar = Incrementar + 22;
                    //
                    e.Graphics.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 268 + Margem_Topo, 275, 11), Sf2);
                }
                else
                {
                    e.Graphics.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 244 + Margem_Topo, 275, 22), Sf);
                    //
                    Incrementar = Incrementar + 22;
                    //
                    e.Graphics.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 244 + Margem_Topo, 275, 11), Sf2);
                }
            }
            else if (_Trabalho == 1)
            {
                DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                //
                string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                byte pessoa;
                //
                nome = drPDF["nome"].ToString();
                fantasia = drPDF["fantasia"].ToString();
                cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                endereco = drPDF["endereco"].ToString();
                ie_rg = drPDF["ie_rg"].ToString();
                numero = drPDF["numero"].ToString();
                bairro = drPDF["bairro"].ToString();
                cidade = drPDF["cidade"].ToString();
                uf = drPDF["uf"].ToString();
                cep = drPDF["cep"].ToString();
                pessoa = Convert.ToByte(drPDF["pessoa"]);
                //
                var fonte1 = new Font("Courrier Regular", 7, FontStyle.Bold);
                var fonte2 = new Font("Courrier New", 7, FontStyle.Regular);
                var fonte3 = new Font("Courrier New", 6, FontStyle.Regular);
                var fonte4 = new Font("Courrier Regular", 5, FontStyle.Italic);
                //
                StringFormat Sf = new StringFormat();
                StringFormat Sf1 = new StringFormat();
                StringFormat Sf2 = new StringFormat();
                //
                Sf.Alignment = StringAlignment.Near;
                Sf1.Alignment = StringAlignment.Center;
                Sf2.Alignment = StringAlignment.Far;
                //
                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_80_Pdv(bllConexao._Codigo_Conexao);
                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_80_Pdv(bllConexao._Codigo_Conexao);
                //
                Pen pen = new Pen(Color.Black);
                //
                int Incrementar = 0;
                //
                if (bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                {
                    Image imagem1 = Image.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                    e.Graphics.DrawImage(imagem1, 99 + Margem_Esq, 2 + Margem_Topo, 81, 95);
                }
                else
                {
                    Margem_Topo = Convert.ToInt16(Margem_Topo - 96);
                }
                //
                Margem_Topo = Margem_Topo + 33;
                //
                //e.Graphics.DrawRectangle(pen, 1 + Margem_Esq, AumentoDeLinhaFixo + 118 + Margem_Topo, 279, 70);
                //e.Graphics.DrawRectangle(pen, 0 + Margem_Esq, 167 + AumentoDeLinhaFixo + Margem_Topo, 275, 33);
                if (nome.Length > 30)
                {
                    if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                    {
                        e.Graphics.DrawString(nome.Insert(30, Environment.NewLine), fonte1, Brushes.Black, new Rectangle(1 + Margem_Esq, 85 + Margem_Topo, 185, 22), Sf1);
                    }
                    else
                    {
                        e.Graphics.DrawString(nome, fonte1, Brushes.Black, new Rectangle(1 + Margem_Esq, 85 + Margem_Topo, 185, 22), Sf1);
                    }
                    Incrementar = Incrementar + 11;
                }
                else
                {
                    e.Graphics.DrawString(nome, fonte1, Brushes.Black, new Rectangle(1 + Margem_Esq, 85 + Margem_Topo, 185, 11), Sf1);
                }
                //
                if (fantasia.Length > 30)
                {
                    if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                    {
                        e.Graphics.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, Brushes.Black, new Rectangle(1 + Margem_Esq, Incrementar + 96 + Margem_Topo, 185, 22), Sf1);
                    }
                    else
                    {
                        e.Graphics.DrawString(fantasia, fonte2, Brushes.Black, new Rectangle(1 + Margem_Esq, Incrementar + 96 + Margem_Topo, 185, 22), Sf1);
                    }
                    Incrementar = Incrementar + 8;
                }
                else
                {
                    e.Graphics.DrawString(fantasia, fonte2, Brushes.Black, new Rectangle(1 + Margem_Esq, Incrementar + 96 + Margem_Topo, 185, 11), Sf1);
                }
                //
                e.Graphics.DrawString(cpf_cnpj + "   " + ie_rg, fonte2, Brushes.Black, new Rectangle(1 + Margem_Esq, Incrementar + 107 + Margem_Topo, 280, 11), Sf);
                //
                e.Graphics.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte2, Brushes.Black, new Rectangle(1 + Margem_Esq, Incrementar + 118 + Margem_Topo, 279, 70), Sf);
                //
                Incrementar = Incrementar - 22;
                //
                e.Graphics.DrawString("-------------------------------------------------------------------------------------", fonte2, Brushes.Black, new Rectangle(0 + Margem_Esq, 167 + Incrementar + Margem_Topo, 340, 33), Sf);

                e.Graphics.DrawString("DAV", fonte1, Brushes.Black, new Rectangle(5 + Margem_Esq, 176 + Incrementar + Margem_Topo, 190, 33), Sf1);

                e.Graphics.DrawString("-------------------------------------------------------------------------------------", fonte2, Brushes.Black, new Rectangle(0 + Margem_Esq, 182 + Incrementar + Margem_Topo, 340, 33), Sf);
                //
                e.Graphics.DrawString(" # Cód. Descrição Qtde. UN. Vl.Unit Vl.Total", fonte2, Brushes.Black, new Rectangle(0 + Margem_Esq, Incrementar + 189 + Margem_Topo, 285, 11));
                //
                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    DataGridViewRow SelectedRow = dtItems.Rows[i];
                    //
                    e.Graphics.DrawString(Convert.ToUInt16(SelectedRow.Cells[0].Value).ToString("D3", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 200 + Margem_Topo, 275, 11));
                    //  
                    e.Graphics.DrawString(SelectedRow.Cells[1].Value.ToString() + "   " + SelectedRow.Cells[2].Value.ToString(), fonte3, Brushes.Black, new Rectangle(21 + Margem_Esq, Incrementar + 200 + Margem_Topo, 275, 11));
                    //         
                    e.Graphics.DrawString(Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 65, 11), Sf);
                    //
                    //e.Graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 211 + Margem_Topo, 85, 11);
                    e.Graphics.DrawString(SelectedRow.Cells[4].Value.ToString() + "  X  " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(75 + Margem_Esq, Incrementar + 211 + Margem_Topo, 85, 11), Sf);
                    //
                    //e.Graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 215 + Margem_Topo, 65, 11);
                    e.Graphics.DrawString(Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 185, 11), Sf2);
                    //                
                    DataRow dtDescAcresc = bllVenda.Sel_Desconto_Acrescimo_Venda(_Cod_Venda, SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    Incrementar = Incrementar + 8;
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                    e.Graphics.DrawString("Desconto: " + (Convert.ToDecimal(dtDescAcresc["valor_desconto"]) + Convert.ToDecimal(dtDescAcresc["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 85, 11));
                    //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                    e.Graphics.DrawString("Acréscimo: " + (Convert.ToDecimal(dtDescAcresc["valor_acrescimo"]) + Convert.ToDecimal(dtDescAcresc["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(85 + Margem_Esq, Incrementar + 211 + Margem_Topo, 85, 11));
                    e.Graphics.DrawString(Convert.ToDecimal(dtDescAcresc["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 185, 11), Sf2);
                    //
                    Incrementar = Incrementar + 21;
                }
                //
                Incrementar = Incrementar + 5;
                //
                e.Graphics.DrawString("Qtde. total de itens", fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 200 + Margem_Topo, 275, 11));
                //
                e.Graphics.DrawString(Convert.ToInt16(dtItems.Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 200 + Margem_Topo, 185, 11), Sf2);
                //
                e.Graphics.DrawString("Valor Total R$", fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11));
                //
                e.Graphics.DrawString(Convert.ToDecimal(_Valor).ToString("n2", new CultureInfo("pt-BR")), fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 185, 11), Sf2);
                //
                Incrementar = Incrementar + 11;
                //
                if (_Valor_Desconto_Venda != "0" || _Valor_Desconto_Item != "0")
                {
                    e.Graphics.DrawString("Descontos R$", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11));
                    //
                    e.Graphics.DrawString("-" + (Convert.ToDecimal(_Valor_Desconto_Venda) + Convert.ToDecimal(_Valor_Desconto_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 185, 11), Sf2);
                    Incrementar = Incrementar + 11;
                }
                //
                if (_Valor_Acrescimo_Venda != "0" || _Valor_Acrescimo_Item != "0")
                {
                    e.Graphics.DrawString("Acréscimos R$", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11));
                    //
                    e.Graphics.DrawString((Convert.ToDecimal(_Valor_Acrescimo_Venda) + Convert.ToDecimal(_Valor_Acrescimo_Item)).ToString("n2", new CultureInfo("pt-BR")), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 185, 11), Sf2);
                    Incrementar = Incrementar + 11;
                }
                //
                e.Graphics.DrawString("Valor a Pagar R$", fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 275, 11));
                //
                e.Graphics.DrawString(Convert.ToDecimal(_Valor_Real).ToString("n2", new CultureInfo("pt-BR")), fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 185, 11), Sf2);
                //
                e.Graphics.DrawString("FORMA PAGAMENTO VALOR PAGO R$", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 222 + Margem_Topo, 275, 11));
                //
                for (int i = 0; i < bllVenda.Sel_Dados_Pagamento_Venda(_Cod_Venda).Rows.Count; i++)
                {
                    drPDF = bllVenda.Sel_Dados_Pagamento_Venda(_Cod_Venda).Rows[i];
                    //
                    string tipo = drPDF["tipo"].ToString();
                    //
                    if (tipo == "DINHEIRO")
                    {
                        e.Graphics.DrawString("Dinheiro", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "CARTAO DE DEBITO")
                    {
                        e.Graphics.DrawString("Cartão Débito", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "CARTAO DE CREDITO")
                    {
                        e.Graphics.DrawString("Cartão Crédito", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "NOTA PROMISSORIA")
                    {
                        e.Graphics.DrawString("À Prazo", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "PIX")
                    {
                        e.Graphics.DrawString("Pagamento Instantâneo", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "CREDITO LOJA")
                    {
                        e.Graphics.DrawString("Crédito Loja", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    else if (tipo == "CHEQUE")
                    {
                        e.Graphics.DrawString("Cheque", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    }
                    //
                    e.Graphics.DrawString(Convert.ToDecimal(drPDF["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 185, 11), Sf2);
                    //
                    Incrementar = Incrementar + 11;
                }
                //
                if (_Troco != "0")
                {
                    e.Graphics.DrawString("Troco R$", fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11));
                    e.Graphics.DrawString(Convert.ToDecimal(_Troco).ToString("n2", new CultureInfo("pt-BR")), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 185, 11), Sf2);
                    Incrementar = Incrementar + 11;
                }
                //
                if (_CPF_CNPJ_Consumidor != "")
                {
                    e.Graphics.DrawString(_CPF_CNPJ_Consumidor, fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 15), Sf);
                    Incrementar = Incrementar + 10;
                }
                else
                {
                    e.Graphics.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 15), Sf);
                    Incrementar = Incrementar + 10;
                }
                //
                e.Graphics.DrawString("PED. nº: " + _Cod_Venda + " " + _Data + " " + _Hora, fonte1, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 233 + Margem_Topo, 275, 11), Sf);
                //
                if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == false & _CPF_CNPJ_Consumidor == "")
                {
                    e.Graphics.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 244 + Margem_Topo, 275, 22), Sf);
                    //
                    Incrementar = Incrementar + 22;
                    //
                    e.Graphics.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 244 + Margem_Topo, 275, 11), Sf);
                }
                else if (bllConfiguracaoSistema.Sel_Mostrar_Ass_Cons() == true & _CPF_CNPJ_Consumidor != "")
                {
                    e.Graphics.DrawString("SEM VALOR FISCAL\n____________________________________\n(Afirmo ter recebido mercadoria)\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 244 + Margem_Topo, 275, 46), Sf);
                    //
                    Incrementar = Incrementar + 22;
                    //
                    e.Graphics.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 268 + Margem_Topo, 275, 11), Sf);
                }
                else
                {
                    e.Graphics.DrawString("SEM VALOR FISCAL\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 244 + Margem_Topo, 275, 22), Sf);
                    //
                    Incrementar = Incrementar + 22;
                    //
                    e.Graphics.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, Brushes.Black, new Rectangle(2 + Margem_Esq, Incrementar + 244 + Margem_Topo, 275, 11), Sf);
                }
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _Atualizacao_Disponivel = false;
                TemporizadorVersao.Stop();
                //informa ao usuario do acontecimento de algum erro.
                MessageBox.Show(this, e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                _Mostrar_Mensagem = false;
                _Tempo_Mostrar_Atualizacao = 0;
                TemporizadorVersao.Start();
            }
            else
            {
                try
                {
                    TemporizadorVersao.Stop();
                    //
                    if (_Atualizacao_Disponivel == true)
                    {
                        using (FrmAtualizacaoDisponivel Disp = new FrmAtualizacaoDisponivel())
                        {
                            if (Disp.ShowDialog() == DialogResult.Yes)
                            {
                                using (FrmAtualizacao Atu = new FrmAtualizacao())
                                {
                                    if (Atu.ShowDialog() == DialogResult.OK)
                                    {
                                        foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                                        {
                                            if (form != Application.OpenForms[0])
                                            {
                                                form.Close();
                                            }
                                        }
                                        //
                                        using (FrmProgresso Prog = new FrmProgresso(0))
                                        {
                                            if (Prog.ShowDialog() == DialogResult.OK)
                                            {
                                                MessageBox.Show(this, "O Seu sistema SEVEN foi atualizado com sucesso.\n\nO Aplicativo precisará reiniciar todos os módulos para aplicar as alterações.\n\nCertifique-se de salvar seus trabalhos pendentes no aplicativo Administração, caso ele esteja aberto.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                //
                                                _Reiniciar = true;
                                                //
                                                Process[] processos = Process.GetProcessesByName("Seven_ADM");
                                                //
                                                foreach (Process processo in processos)
                                                {
                                                    processo.Kill();
                                                }
                                                //
                                                Process.Start(@"C:\Sistema SEVEN\Seven_PDV.exe");
                                                //
                                                this.Close();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_Mostrar_Mensagem == true)
                        {
                            _Mostrar_Mensagem = false;
                            MessageBox.Show("O Sistema SEVEN já possui todas as atualizações mais recentes.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //
                    _Tempo_Mostrar_Atualizacao = 0;
                    TemporizadorVersao.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                }
            }
        }

        private void TemporizadorVersao_Tick(object sender, EventArgs e)
        {
            if (bllConfiguracaoSistema.Sel_Buscar_Atualizacoes(bllConexao._Codigo_Conexao) == true)
            {
                if (_Atualizacao_Disponivel == true)
                {
                    if (lblVersao.ForeColor == Color.White)
                    {
                        lblVersao.ForeColor = Color.Blue;
                    }
                    else
                    {
                        lblVersao.ForeColor = Color.White;
                    }
                    //
                    if (_Tempo_Mostrar_Atualizacao == 900)
                    {
                        bckwIndeterminado.RunWorkerAsync();
                    }
                }
                else
                {
                    if (_Tempo_Mostrar_Atualizacao == 3600)
                    {
                        bckwIndeterminado.RunWorkerAsync();
                    }
                }
                //
                _Tempo_Mostrar_Atualizacao = _Tempo_Mostrar_Atualizacao + 1;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pPanelCaixaLivre.Visible = false;
        }

        private void lblDataCaixaLivre_Click(object sender, EventArgs e)
        {
            pPanelCaixaLivre.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Reallizar_Abert_Caixa_Usuario(lblUsuario.Text) == true)
                {
                    this.Enabled = false;
                    using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                    {
                        if (Abrir.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                            {
                                DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                //
                                if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                {
                                    if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                    {
                                        bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                        //
                                        lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                        //
                                    }
                                    else
                                    {
                                        lblDescCliente.Text = "Consumidor: Não identificado.";
                                        bllVenda._PDV_PesqCliente_Tabela = null;
                                    }
                                    //
                                    if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                    {
                                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                        //
                                        dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                        //
                                        dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                        //
                                        dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                        //
                                        DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                        //
                                        lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                    }
                                    //
                                    txtProduto.Text = null;
                                    //
                                    txtProduto.Select();
                                    //
                                    pPanelCaixaLivre.Visible = false;
                                    pPanelCaixaFechado.Visible = false;
                                }
                            }
                            else
                            {
                                bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                //
                                bllVenda._PDV_PesqCliente_Tabela = null;
                                //
                                txtProduto.Select();
                                //
                                pPanelCaixaLivre.BringToFront();
                                pPanelCaixaLivre.Visible = true;
                                pPanelCaixaFechado.Visible = false;

                            }
                        }
                    }
                    this.Enabled = true;
                }
                else
                {
                    this.Enabled = false;
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Abrir_Caixa"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Abrir_Caixa == 1)
                            {
                                using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                                {
                                    if (Abrir.ShowDialog() == DialogResult.OK)
                                    {
                                        if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                                        {
                                            DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                            //
                                            if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                            {
                                                if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                                {
                                                    bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                                    //
                                                    lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                                }
                                                else
                                                {
                                                    lblDescCliente.Text = "Consumidor: Não identificado.";
                                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                                }
                                                //
                                                if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                                {
                                                    dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                                    //
                                                    dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                                    //
                                                    dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                                    //
                                                    dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                                    //
                                                    DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                                    //
                                                    lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                                    //
                                                }
                                                //
                                                txtProduto.Text = null;
                                                //
                                                txtProduto.Select();
                                                //
                                                pPanelCaixaLivre.Visible = false;
                                                pPanelCaixaFechado.Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                            //
                                            bllVenda._PDV_PesqCliente_Tabela = null;
                                            //
                                            txtProduto.Select();
                                            //
                                            pPanelCaixaLivre.BringToFront();
                                            pPanelCaixaLivre.Visible = true;
                                            pPanelCaixaFechado.Visible = false;
                                        }
                                    }
                                }
                            }
                            else if (bllVenda._Permitir_Abrir_Caixa == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para realizar Abertura de Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    this.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pPanelCaixaFechado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pPanelCaixaFechado.");
                }
            }
        }

        private void lblDataCaixaFechado_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Reallizar_Abert_Caixa_Usuario(lblUsuario.Text) == true)
                {
                    this.Enabled = false;
                    using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                    {
                        if (Abrir.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                            {
                                DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                //
                                if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                {
                                    if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                    {
                                        bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                        //
                                        lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                        //
                                    }
                                    else
                                    {
                                        lblDescCliente.Text = "Consumidor: Não identificado.";
                                        bllVenda._PDV_PesqCliente_Tabela = null;
                                    }
                                    //
                                    if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                    {
                                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                        //
                                        dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                        //
                                        dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                        //
                                        dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                        //
                                        DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                        //
                                        lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                    }
                                    //
                                    txtProduto.Text = null;
                                    //
                                    txtProduto.Select();
                                    //
                                    pPanelCaixaLivre.Visible = false;
                                    pPanelCaixaFechado.Visible = false;
                                }
                            }
                            else
                            {
                                bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                //
                                bllVenda._PDV_PesqCliente_Tabela = null;
                                //
                                txtProduto.Select();
                                //
                                pPanelCaixaLivre.BringToFront();
                                pPanelCaixaLivre.Visible = true;
                                pPanelCaixaFechado.Visible = false;

                            }
                        }
                    }
                    this.Enabled = true;
                }
                else
                {
                    this.Enabled = false;
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Abrir_Caixa"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Abrir_Caixa == 1)
                            {
                                using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                                {
                                    if (Abrir.ShowDialog() == DialogResult.OK)
                                    {
                                        if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                                        {
                                            DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                            //
                                            if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                            {
                                                if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                                {
                                                    bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                                    //
                                                    lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                                }
                                                else
                                                {
                                                    lblDescCliente.Text = "Consumidor: Não identificado.";
                                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                                }
                                                //
                                                if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                                {
                                                    dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                                    //
                                                    dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                                    //
                                                    dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                                    //
                                                    dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                                    //
                                                    DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                                    //
                                                    lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                                    //
                                                }
                                                //
                                                txtProduto.Text = null;
                                                //
                                                txtProduto.Select();
                                                //
                                                pPanelCaixaLivre.Visible = false;
                                                pPanelCaixaFechado.Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                            //
                                            bllVenda._PDV_PesqCliente_Tabela = null;
                                            //
                                            txtProduto.Select();
                                            //
                                            pPanelCaixaLivre.BringToFront();
                                            pPanelCaixaLivre.Visible = true;
                                            pPanelCaixaFechado.Visible = false;
                                        }
                                    }
                                }
                            }
                            else if (bllVenda._Permitir_Abrir_Caixa == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para realizar Abertura de Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    this.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pPanelCaixaFechado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do pPanelCaixaFechado.");
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Windows\System32\Calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do bllCalculadora.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do bllCalculadora.");
                }
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblCalculadora.BackColor = Color.Gray;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblCalculadora.BackColor = Color.DimGray;
        }

        private void bckwInicio_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bllVersao.CriarArquivoLogLoginServ("seven_pdv_bp", _Versao, null);
        }

        private void bckwInicio_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this, e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwInicio.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwInicio.");
                }
            }
        }

        private void TemporizadorLogin_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_Tempo_Mostrar_Logado == _ContMostrar_Logado)
                {
                    DateTime TempoLogado = new DateTime();
                    //
                    TempoLogado = TempoLogado.AddSeconds(_ContMostrar_Logado);
                    //
                    _Tempo_Mostrar_Logado = _Tempo_Mostrar_Logado + 86400;
                    //
                    bllVersao.CriarArquivoLogLoginServ("seven_pdv", _Versao, TempoLogado.Hour.ToString() + "h " + TempoLogado.Minute.ToString() + "min");
                    //
                    if (bllMinhaEmpresa.Sel_Empresa_Backup_Automatico() == true)
                    {
                        if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != null)
                        {
                            DialogResult = MessageBox.Show("O Backup do Sistema não é realizado há mais de 24 horas. Deseja executá-lo agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                using (FrmProgresso Prog = new FrmProgresso(2))
                                {
                                    if (Prog.ShowDialog() == DialogResult.OK)
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
                //
                _ContMostrar_Logado++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento tick do botão TemporizadorLogin.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento tick do botão TemporizadorLogin.");
                }
            }
        }

        private void lblEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                {
                    foreach (DataRow dr in bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows)
                    {
                        MessageBox.Show("Nome/Razão Social: " + dr["nome"].ToString() + "\nCPF/CNPJ: " + dr["cpf_cnpj"].ToString() + "\nInscrição Estadual/RG: " + dr["ie_rg"].ToString() + "\nNome Fantasia: " + dr["fantasia"].ToString() + "\nEndereço/Logradouro: " + dr["endereco"].ToString() + "\nNumero: " + dr["numero"].ToString() + "\nBairro/Distrito: " + dr["bairro"].ToString() + "\nComplemento: " + dr["complemento"].ToString() + "\nReferência: " + dr["referencia"].ToString() + "\nUF: " + dr["UF"].ToString() + "\nCidade: " + dr["cidade"].ToString() + "\nLocalização: " + dr["localizacao"].ToString() + "\nCEP: " + dr["cep"].ToString() + "\nTelefone: " + dr["telefone"].ToString() + "\nCelular: " + dr["celular"].ToString() + "\nEmail: " + dr["email"].ToString(), "Informações da Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão tslblEmpresa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão tslblEmpresa.");
                }
            }
        }

        private void txtUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUnitario.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnAlterarValorUnitario.Select();
            }
        }

        private void btnAlterarQuantidade_Click(object sender, EventArgs e)
        {
            DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
            //
            try
            {
                DialogResult = MessageBox.Show("Deseja alterar a Quantidade?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (txtQuantidade.Text.Trim() == "")
                    {
                        MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Quantidade ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtQuantidade.Select();
                        txtQuantidade.Text = Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else if (txtQuantidade.Text.Trim() == "0" || txtQuantidade.Text.Trim() == "0,00" || txtQuantidade.Text.Trim() == "0,0")
                    {
                        MessageBox.Show("Não é possível informar  valor [ 0 ] para o campo [ Quantidade ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtQuantidade.Select();
                        txtQuantidade.Text = Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR"));
                    }
                    else
                    {
                        int item_selecionado = SelectedRow.Index;

                        DataRow dr = bllProduto.Sel_Prod_Codigo(SelectedRow.Cells[1].Value.ToString(), "").Rows[0];

                        bllVenda.Alterar_Quantidade_Item(SelectedRow.Cells[0].Value.ToString(), txtQuantidade.Text.Trim(), SelectedRow.Cells[5].Value.ToString(), dr["acrescimo_porc"].ToString(), dr["desconto_porc"].ToString());
                        //
                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                        //
                        txtProduto.Text = null;

                        dtItems.CurrentCell = dtItems.Rows[item_selecionado].Cells[0];

                        dtItems.Rows[item_selecionado].Selected = true;

                        dtItems.FirstDisplayedScrollingRowIndex = item_selecionado;

                        dtItems.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAdicionarQuantidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAdicionarQuantidade.");
                }
                txtQuantidade.Select();
                txtQuantidade.Text = Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR"));
            }
        }

        private void lblDescCliente_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
        }

        //private Size originalSize; // Armazena o tamanho original para referência

        private void lblAjuda_Click(object sender, EventArgs e)
        {
            Ajuda();
        }

        private void dtItems_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete & _Devolucao == false)
                {
                    if (dtItems.Rows.Count != 0)
                    {
                        DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            if (bllUsuario.Sel_Permitir_Canc_Exc_Item_Venda_Usuario(lblUsuario.Text) == true)
                            {
                                Excluir_Item();
                            }
                            else
                            {
                                using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Excluir_Item"))
                                {
                                    if (Login.ShowDialog() == DialogResult.OK)
                                    {
                                        if (bllVenda._Excluir_Item == 1)
                                        {
                                            Excluir_Item();
                                        }
                                        else if (bllVenda._Excluir_Item == 0)
                                        {
                                            MessageBox.Show("O Usuário informado não possui permissão para Excluir Itens/Cancelar Cupom.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    txtProduto.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyUp do dtItems.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Click do dtItems.");
                }
            }
        }

        private void txtProduto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtProduto.Text.Trim() == "")
                {
                    if (e.KeyCode == Keys.Delete & txtProduto.Text == "")
                    {
                        if (dtItems.Rows.Count != 0)
                        {
                            DialogResult = MessageBox.Show("Deseja excluir o item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                if (bllUsuario.Sel_Permitir_Canc_Exc_Item_Venda_Usuario(lblUsuario.Text) == true)
                                {
                                    Excluir_Item();
                                }
                                else
                                {
                                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Excluir_Item"))
                                    {
                                        if (Login.ShowDialog() == DialogResult.OK)
                                        {
                                            if (bllVenda._Excluir_Item == 1)
                                            {
                                                Excluir_Item();
                                            }
                                            else if (bllVenda._Excluir_Item == 0)
                                            {
                                                MessageBox.Show("O Usuário informado não possui permissão para Excluir Itens/Cancelar Cupom.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //
                if (dtItems.DataSource != null)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        dtItems.Select();
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        dtItems.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyUp do txtProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Click do txtProduto.");
                }
            }
        }

        private void dtItems_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtItems.DataSource != null)
            {
                btnAlterarQuantidade.Enabled = true;
                btnAlterarValorUnitario.Enabled = true;
                lblQuant.Enabled = true;
                txtQuantidade.Enabled = true;
                lblUnitario.Enabled = true;
                lblValorTotalItem.Enabled = true;
                txtUnitario.Enabled = true;
                lblItem.Enabled = true;
                lblQuantidadeItem.Enabled = true;
                lblValorTotalunit.Enabled = true;
                lblTotalProdutos.Enabled = true;
                lblValorTotal.Enabled = true;
                _Caminho_Imagem = null;
            }
            else
            {
                btnAlterarQuantidade.Enabled = false;
                btnAlterarValorUnitario.Enabled = false;
                lblQuant.Enabled = false;
                txtQuantidade.Enabled = false;
                lblUnitario.Enabled = false;
                lblValorTotalItem.Enabled = false;
                txtUnitario.Enabled = false;
                lblItem.Enabled = false;
                lblQuantidadeItem.Enabled = false;
                lblQuantidadeItem.Text = "0";
                lblValorTotal.Text = "0,00";
                txtQuantidade.Text = null;
                txtUnitario.Text = null;
                lblValorTotalunit.Enabled = false;
                lblValorTotalunit.Text = "0,00";
                lblTotalProdutos.Enabled = false;
                lblValorTotal.Enabled = false;
                lblMensagemTopo.Text = null;
            }
        }

        private void tData_Tick(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblDataCaixaLivre.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblDataCaixaFechado.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void txtProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (pPanelCaixaFechado.Visible != true)
            {
                if (e.KeyChar == 13)
                {
                    btnProcurarProd_Click(sender, e);
                }
                //
                if (txtProduto.Text.StartsWith(@"\") || txtProduto.Text.StartsWith(@"/"))
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtProduto_Enter(object sender, EventArgs e)
        {
            txtProduto.BackColor = Color.LightBlue;
        }

        private void txtProduto_Leave(object sender, EventArgs e)
        {
            if (txtProduto.Text.Contains("'") || txtProduto.Text.Contains(";") || txtProduto.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProduto.Text = null;
            }
            txtProduto.BackColor = Color.White;
        }

        private void dtItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtItems.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dtItems.Columns[0].Width = 42;
            dtItems.Columns[1].Width = 70;
            dtItems.Columns[2].Width = 300;
            dtItems.Columns[3].Width = 70;
            dtItems.Columns[4].Width = 38;
            dtItems.Columns[5].Width = 95;
            dtItems.Columns[6].Visible = false;
            dtItems.Columns[7].Visible = false;
            dtItems.Columns[8].Visible = false;
            dtItems.Columns[9].Width = 95;
            //
            dtItems.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtItems.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtItems.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtItems.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItems.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;           
            dtItems.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            dtItems.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            //
            lblQuantidadeItem.Text = dtItems.Rows.Count.ToString();
            //
            //
            decimal total = 0;
            for (int i = 0; i < dtItems.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dtItems.Rows[i].Cells[9].Value);
            }
            //
            lblValorTotal.Text = total.ToString("n2", new CultureInfo("pt-BR"));
        }

        private void lblVersao_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblVersao.BackColor = Color.Gray;
        }

        private void lblUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblUsuario.BackColor = Color.DimGray;
        }

        private void lblUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            segundosSemTecla = 0;
            tInativo.Stop();
            tInativo.Start();
            this.Cursor = Cursors.Hand;
            lblUsuario.BackColor = Color.Gray;
        }

        private void btnProcurarProd_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (txtProduto.Text == "")
                {
                    if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(lblUsuario.Text) == true)
                    {
                        using (FrmPesqProduto Prod = new FrmPesqProduto(3, dtItems.Rows.Count, lblUsuario.Text, lblVersao.Text, _Quantidade, "Tabela [1]", _Tipo_Venda))
                        {
                            if (Prod.ShowDialog() == DialogResult.OK)
                            {
                                using (FrmAdicionarItem Item = new FrmAdicionarItem(dtItems.Rows.Count, 2, "Tabela [1]", _Quantidade))
                                {
                                    if (Item.ShowDialog() == DialogResult.OK)
                                    {
                                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                        //
                                        lblMensagemTopo.Text = bllVenda._Descricao_Produto;
                                        //
                                        txtProduto.Text = null;
                                        //
                                        dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                        //
                                        dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                        //
                                        dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                        //
                                        DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
                                        //
                                        if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                        {
                                            if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                            {
                                                MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        txtProduto.Select();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        using (FrmPesqProduto Prod = new FrmPesqProduto(0, dtItems.Rows.Count + 1, lblUsuario.Text, lblVersao.Text, _Quantidade, "Tabela [1]", _Tipo_Venda))
                        {
                            if (Prod.ShowDialog() == DialogResult.OK)
                            {
                                dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                //
                                lblMensagemTopo.Text = bllVenda._Descricao_Produto;

                                txtProduto.Text = null;

                                dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];

                                dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;

                                dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                //
                                DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
                                //
                                if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                {
                                    if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                    {
                                        MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                txtProduto.Select();
                            }
                        }
                    }
                }
                else if (txtProduto.Text.Contains(@"\") || txtProduto.Text.Contains(@"/"))
                {
                    if ((txtProduto.Text.StartsWith(@"\") || txtProduto.Text.StartsWith(@"/")) == true)
                    {
                        if (txtProduto.Text.Replace(@"\", "").Replace(@"/", "") != "")
                        {
                            if (bllProduto.Sel_Prod_Codigo(txtProduto.Text.Replace(@"\", "").Replace(@"/", ""), "ATIVO") == null)
                            {
                                MessageBox.Show("Código de produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtProduto.Text = null;
                                txtProduto.Select();
                            }
                            else
                            {
                                DataRow dr = bllProduto.Sel_Prod_Codigo(txtProduto.Text.Replace(@"\", "").Replace(@"/", ""), "ATIVO").Rows[0];

                                if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(lblUsuario.Text) == true)
                                {
                                    bllVenda._PDV_PesqProduto_Tabela = dr["id_produto"].ToString() + "—" + dr["descricao"].ToString() + "—" + dr["um"].ToString() + "—" + dr["preco"].ToString() + "—" + dr["acrescimo_porc"].ToString() + "—" + dr["desconto_porc"].ToString();

                                    using (FrmAdicionarItem Item = new FrmAdicionarItem(dtItems.Rows.Count, 2, "Tabela [1]", _Quantidade))
                                    {
                                        if (Item.ShowDialog() == DialogResult.OK)
                                        {
                                            dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                            //
                                            lblMensagemTopo.Text = bllVenda._Descricao_Produto;

                                            txtProduto.Text = null;

                                            dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];

                                            dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;

                                            dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                            //
                                            DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
                                            //
                                            if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                            {
                                                if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                                {
                                                    MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                            txtProduto.Select();
                                        }
                                    }
                                }
                                else
                                {
                                    if (bllProduto.Sel_Alert_Est_Max_Min_Prod(dr["id_produto"].ToString()) == true)
                                    {
                                        if (bllProduto.Ver_Estoque_Min_Prod(dr["id_produto"].ToString(), _Quantidade) == true)
                                        {
                                            MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            bllVenda.Salvar_Items_PDV((dtItems.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["preco"].ToString(), dr["um"].ToString(), _Quantidade, dr["acrescimo_porc"].ToString(), dr["desconto_porc"].ToString(), "Tabela [1]", bllConexao._Codigo_Conexao, "PRODUTO");

                                            dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);

                                            lblMensagemTopo.Text = dr["descricao"].ToString();

                                            txtProduto.Text = null;

                                            dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];

                                            dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;

                                            dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                            //
                                            DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
                                            //
                                            if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                            {
                                                if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                                {
                                                    MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                            txtProduto.Select();
                                        }
                                    }
                                    else
                                    {
                                        bllVenda.Salvar_Items_PDV((dtItems.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["preco"].ToString(), dr["um"].ToString(), _Quantidade, dr["acrescimo_porc"].ToString(), dr["desconto_porc"].ToString(), "Tabela [1]", bllConexao._Codigo_Conexao, "PRODUTO");

                                        dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);

                                        lblMensagemTopo.Text = dr["descricao"].ToString();

                                        txtProduto.Text = null;

                                        dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];

                                        dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;

                                        dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                        //
                                        DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
                                        //
                                        if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                        {
                                            if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                            {
                                                MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        txtProduto.Select();
                                    }
                                }
                                //
                                _Quantidade = "1";
                            }
                        }
                    }
                }
                else
                {
                    if (bllProduto.Sel_Prod_Barra(txtProduto.Text, "ATIVO") == null)
                    {
                        MessageBox.Show("Código de barras do produto informado não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtProduto.Text = null;
                        txtProduto.Select();
                    }
                    else
                    {
                        DataRow dr = bllProduto.Sel_Prod_Barra(txtProduto.Text, "ATIVO").Rows[0];

                        if (bllUsuario.Sel_Mostrar_Dados_Prod_Item_Usuario(lblUsuario.Text) == true)
                        {
                            bllVenda._PDV_PesqProduto_Tabela = dr["id_produto"].ToString() + "—" + dr["descricao"].ToString() + "—" + dr["um"].ToString() + "—" + dr["preco"].ToString() + "—" + dr["acrescimo_porc"].ToString() + "—" + dr["desconto_porc"].ToString();

                            using (FrmAdicionarItem Item = new FrmAdicionarItem(dtItems.Rows.Count, 2, "Tabela [1]", _Quantidade))
                            {
                                if (Item.ShowDialog() == DialogResult.OK)
                                {
                                    dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                    //
                                    lblMensagemTopo.Text = bllVenda._Descricao_Produto;

                                    txtProduto.Text = null;

                                    dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];

                                    dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;

                                    dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                    //
                                    DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
                                    //
                                    if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                    {
                                        if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                        {
                                            MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    txtProduto.Select();
                                }
                            }
                        }
                        else
                        {
                            if (bllProduto.Sel_Alert_Est_Max_Min_Prod(dr["id_produto"].ToString()) == true)
                            {
                                if (bllProduto.Ver_Estoque_Min_Prod(dr["id_produto"].ToString(), _Quantidade) == true)
                                {
                                    MessageBox.Show("O seu estoque atual junto com a quantidade informada ultrapassou a quantidade de estoque mínimo definido para este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    bllVenda.Salvar_Items_PDV((dtItems.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["preco"].ToString(), dr["um"].ToString(), _Quantidade, dr["acrescimo_porc"].ToString(), dr["desconto_porc"].ToString(), "Tabela [1]", bllConexao._Codigo_Conexao, "PRODUTO");

                                    dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);

                                    lblMensagemTopo.Text = dr["descricao"].ToString();

                                    txtProduto.Text = null;

                                    dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];

                                    dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;

                                    dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                    //
                                    DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
                                    //
                                    if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                    {
                                        if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                        {
                                            MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    txtProduto.Select();
                                }
                            }
                            else
                            {
                                bllVenda.Salvar_Items_PDV((dtItems.Rows.Count + 1).ToString(), dr["id_produto"].ToString(), dr["descricao"].ToString(), dr["preco"].ToString(), dr["um"].ToString(), _Quantidade, dr["acrescimo_porc"].ToString(), dr["desconto_porc"].ToString(), "Tabela [1]", bllConexao._Codigo_Conexao, "PRODUTO");

                                dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);

                                lblMensagemTopo.Text = dr["descricao"].ToString();

                                txtProduto.Text = null;

                                dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];

                                dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;

                                dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                //
                                DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
                                //
                                if (bllConfiguracaoSistema.Sel_Alertar_Observacao() == true)
                                {
                                    if (bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()) != "")
                                    {
                                        MessageBox.Show(bllProduto.Sel_Produto_Alerta_Observacao(SelectedRow.Cells[1].Value.ToString()), "Informação de Observação do Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                txtProduto.Select();
                            }
                        }
                    }
                    //
                    _Quantidade = "1";
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProd.");
                }
                _Quantidade = "1";
                txtProduto.Text = null;
                bllVenda._Descricao_Produto = null;
                txtProduto.Select();
            }
            this.Enabled = true;
        }

        private void bckwIndeterminado_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (_Sleep == true)
            {
                Thread.Sleep(5000);
            }
            //
            if (bllVersao.VerificarAtualizacoesSQLOperation() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesSQLSeven() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
            {
                if (bllVersao.VerificarAtualizacoesSQL_CPF_CNPJ() == true)
                {
                    bllVersao.BaixarAtualizacoesSQL_CPF_CNPJ();
                }
            }
            //
            if (bllVersao.VerificarAtualizacoesIBPT() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesSeven_Adm() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesSeven_Pdv() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesBLL() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesDAL() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesSeven_Config() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesACBR_Lib() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesConfig() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesSistemaSeven() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (_Atualizacao_Disponivel == true)
            {
                bllVersao.BaixarDetalheAtualizacao();
            }
            //
            _Sleep = false;
        }

        private void FrmSistemaBigPicture_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (pPanelCaixaFechado.Visible != true)
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        lblSair.BackColor = Color.DimGray;

                        if (bllUsuario.Sel_Permitir_Finalizar_PDV_Usuario(lblUsuario.Text) == true)
                        {
                            DialogResult = MessageBox.Show("Deseja finalizar o aplicativo Sistema SEVEN - PDV?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                if (bllMinhaEmpresa.Sel_Empresa_Backup_Automatico() == true & _Reiniciar == false)
                                {
                                    if (bllBackup.Sel_Data_Ult_Backup() == null || bllBackup.Sel_Data_Ult_Backup() == "")
                                    {
                                        if (bckwIndeterminado.IsBusy != true)
                                        {
                                            if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != null)
                                            {
                                                using (FrmProgresso Prog = new FrmProgresso(1))
                                                {
                                                    if (Prog.ShowDialog() == DialogResult.OK)
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToDateTime(bllBackup.Sel_Data_Ult_Backup()).Day != DateTime.Now.Day)
                                        {
                                            if (bckwIndeterminado.IsBusy != true)
                                            {
                                                if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != null)
                                                {
                                                    using (FrmProgresso Prog = new FrmProgresso(1))
                                                    {
                                                        if (Prog.ShowDialog() == DialogResult.OK)
                                                        {

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                //
                                Application.Exit();
                            }
                        }
                        else
                        {
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Fin_PDV"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Fin_PDV == 1)
                                    {
                                        DialogResult = MessageBox.Show("Deseja finalizar o aplicativo Sistema SEVEN - PDV?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (DialogResult == DialogResult.Yes)
                                        {
                                            Application.Exit();
                                        }
                                    }
                                    else if (bllVenda._Permitir_Fin_PDV == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para finalizar o aplicativo Sistema SEVEN - PDV.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                        }
                    }
                    else if (e.KeyCode == Keys.F1)
                    {
                        lblAjuda.BackColor = Color.DimGray;
                        Ajuda();
                    }
                    else if (e.KeyCode == Keys.F2)
                    {
                        lblPagamento.BackColor = Color.LightGray;
                        if (dtItems.DataSource != null)
                        {
                            Pagamento();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum item foi adicionado à venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (e.KeyCode == Keys.F3)
                    {
                        lblOrcamento.BackColor = Color.LightGray;
                        if (dtItems.DataSource == null)
                        {
                            Orcamento();
                        }
                        else
                        {
                            MessageBox.Show("Existem itens de uma possível venda, finalize a venda ou cancele os itens para realizar um orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (e.KeyCode == Keys.F4)
                    {
                        lblQuantidade.BackColor = Color.LightGray;
                        Quantidade();
                    }
                    else if (e.KeyCode == Keys.F5)
                    {
                        lblCancelar.BackColor = Color.LightGray;
                        if (dtItems.DataSource != null || bllVenda._PDV_PesqCliente_Tabela != null)
                        {
                            Cancelar_Venda_Atual();
                        }
                        else
                        {
                            MessageBox.Show("Não é possível cancelar: nenhum item foi adicionado e nenhum consumidor foi informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (e.KeyCode == Keys.F6)
                    {
                        lblConsumidor.BackColor = Color.LightGray;
                        Identificar_Consumidor();
                    }
                    else if (e.KeyCode == Keys.F7)
                    {
                        lblCapturar.BackColor = Color.LightGray;
                        Capturar();
                    }
                    else if (e.KeyCode == Keys.F8)
                    {
                        lblDevolucao.BackColor = Color.LightGray;
                        if (dtItems.DataSource == null)
                        {
                            Devolucao();
                        }
                        else
                        {
                            MessageBox.Show("Existem itens de uma possível venda, finalize a venda ou cancele os itens para realizar uma Devolução.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (e.KeyCode == Keys.F9)
                    {
                        lblOutros.BackColor = Color.LightGray;
                        Menu_BigPicture();
                    }
                    else if (e.KeyCode == Keys.Home)
                    {

                        if (_Tipo_Venda == "DAV")
                        {
                            DialogResult = MessageBox.Show("Deseja alterar o tipo de documento da venda para NFCe\n[ Nota Fiscal de Consumidor Eletrônica Modelo 65 ]?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Tipo_Venda = "NFCe";
                                lblCabecalhoNota.Text = "--------------------------------------------\r\n  ** NFCe **\r\n--------------------------------------------";
                            }
                        }
                        else if (_Tipo_Venda == "NFCe")
                        {
                            DialogResult = MessageBox.Show("Deseja alterar o tipo de documento da venda para NFe [ Nota Fiscal Eletrônica Modelo 55 ]?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Tipo_Venda = "NFe";
                                lblCabecalhoNota.Text = "--------------------------------------------\r\n  ** NFe **\r\n--------------------------------------------";
                            }
                        }
                        else if (_Tipo_Venda == "NFe")
                        {
                            DialogResult = MessageBox.Show("Deseja alterar o tipo de documento da venda para DAV [ Documento Auxiliar de Venda ]?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                _Tipo_Venda = "DAV";
                                lblCabecalhoNota.Text = "--------------------------------------------\r\n  ** DAV **\r\n--------------------------------------------";
                            }
                        }
                        //
                        bllConfiguracaoSistema.Alterar_Tipo_Documento_PDV(_Tipo_Venda, bllConexao._Codigo_Conexao);
                        //
                        lblTipoVenda.BackColor = Color.DimGray;

                    }
                    else if (e.KeyCode == Keys.F10)
                    {
                        lblCalculadora.BackColor = Color.DimGray;
                        Process.Start(@"C:\Windows\System32\Calc.exe");
                    }
                    else if (e.KeyCode == Keys.Insert)
                    {
                        if (dtItems.Rows.Count != 0)
                        {
                            DataGridViewRow SelectedRow = dtItems.Rows[dtItems.CurrentRow.Index];
                            //
                            if (bllConfiguracaoSistema.Sel_Mostrar_Desc_Acresc_Venda(bllConexao._Codigo_Conexao) == true)
                            {
                                MessageBox.Show("Item: " + SelectedRow.Cells[0].Value.ToString() + "\n\nCódigo: " + SelectedRow.Cells[1].Value.ToString() + "\n\nDescrição: " + SelectedRow.Cells[2].Value.ToString() + "\n\nQtde.: " + Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")) + "\n\nUN.: " + SelectedRow.Cells[4].Value.ToString() + "\n\nVl. Unit. (R$): " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")) + "\n\nVl. Item. (R$): " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + "\n\nVl. do Desc. - (R$): " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + "\n\nVl. do Acrésc. + (R$): " + Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")) + "\n\nVl. A. Desc. Acresc. (R$): " + Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Item: " + SelectedRow.Cells[0].Value.ToString() + "\n\nCódigo: " + SelectedRow.Cells[1].Value.ToString() + "\n\nDescrição: " + SelectedRow.Cells[2].Value.ToString() + "\n\nQtde.: " + Convert.ToDecimal(SelectedRow.Cells[3].Value).ToString("n2", new CultureInfo("pt-BR")) + "\n\nUN.: " + SelectedRow.Cells[4].Value.ToString() + "\n\nVl. Unit. (R$): " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")) + "\n\nVl. Item. (R$): " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + "\n\nVl. do Desc. - (R$): " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + "\n\nVl. do Acrésc. + (R$): " + Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")) + "\n\nVl. A. Desc. Acresc. (R$): " + Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        lblSair.BackColor = Color.DimGray;

                        if (bllUsuario.Sel_Permitir_Finalizar_PDV_Usuario(lblUsuario.Text) == true)
                        {

                            DialogResult = MessageBox.Show("Deseja finalizar o aplicativo Sistema SEVEN - PDV?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                Application.Exit();
                            }
                        }
                        else
                        {
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Fin_PDV"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Fin_PDV == 1)
                                    {
                                        DialogResult = MessageBox.Show("Deseja finalizar o aplicativo Sistema SEVEN - PDV?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (DialogResult == DialogResult.Yes)
                                        {
                                            Application.Exit();
                                        }
                                    }
                                    else if (bllVenda._Permitir_Fin_PDV == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para finalizar o aplicativo Sistema SEVEN - PDV.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                        }
                    }
                    else if (e.KeyCode == Keys.F1)
                    {
                        lblAjuda.BackColor = Color.DimGray;
                        Ajuda();
                    }
                    else
                    {
                        if (bllUsuario.Sel_Reallizar_Abert_Caixa_Usuario(lblUsuario.Text) == true)
                        {
                            this.Enabled = false;
                            using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                            {
                                if (Abrir.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                                    {
                                        DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                        //
                                        if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                        {
                                            if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                            {
                                                bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                                //
                                                lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                            }
                                            else
                                            {
                                                lblDescCliente.Text = "Consumidor: Não identificado.";
                                                bllVenda._PDV_PesqCliente_Tabela = null;
                                            }
                                            //
                                            if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                            {
                                                dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                                //
                                                dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                                //
                                                dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                                //
                                                dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                                //
                                                DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                                //
                                                lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                            }
                                            //
                                            txtProduto.Text = null;
                                            //
                                            txtProduto.Select();
                                            //
                                            pPanelCaixaLivre.Visible = false;
                                            pPanelCaixaFechado.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                        //
                                        bllVenda._PDV_PesqCliente_Tabela = null;
                                        //
                                        txtProduto.Select();
                                        //
                                        pPanelCaixaLivre.BringToFront();
                                        pPanelCaixaLivre.Visible = true;
                                        pPanelCaixaFechado.Visible = false;

                                    }
                                }
                            }
                            this.Enabled = true;
                        }
                        else
                        {
                            this.Enabled = false;
                            using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(lblUsuario.Text, lblVersao.Text, "Permitir_Abrir_Caixa"))
                            {
                                if (Login.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllVenda._Permitir_Abrir_Caixa == 1)
                                    {
                                        using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(lblUsuario.Text, lblVersao.Text))
                                        {
                                            if (Abrir.ShowDialog() == DialogResult.OK)
                                            {
                                                if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null || bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao) != null)
                                                {
                                                    DataRow dr = bllVenda.Sel_Dados_Atuais_PDV(bllConexao._Codigo_Conexao).Rows[0];
                                                    //
                                                    if (dr["id_devolucao"].ToString() == "0" & dr["id_orcamento"].ToString() == "0")
                                                    {
                                                        if (Convert.ToInt32(dr["id_consumidor_pdv"]) != 0)
                                                        {
                                                            bllVenda._PDV_PesqCliente_Tabela = dr["id_consumidor_pdv"].ToString() + "—" + dr["nome_consumidor_pdv"].ToString() + "—" + dr["cpf_cnpj_consumidor_pdv"].ToString(); ;
                                                            //
                                                            lblDescCliente.Text = "Consumidor: " + dr["cpf_cnpj_consumidor_pdv"].ToString();
                                                        }
                                                        else
                                                        {
                                                            lblDescCliente.Text = "Consumidor: Não identificado.";
                                                            bllVenda._PDV_PesqCliente_Tabela = null;
                                                        }
                                                        //
                                                        if (bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao) != null)
                                                        {
                                                            dtItems.DataSource = bllVenda.Sel_Item_PDV_Todos("Tabela [1]", bllConexao._Codigo_Conexao);
                                                            //
                                                            dtItems.CurrentCell = dtItems.Rows[dtItems.Rows.Count - 1].Cells[0];
                                                            //
                                                            dtItems.Rows[dtItems.Rows.Count - 1].Selected = true;
                                                            //
                                                            dtItems.FirstDisplayedScrollingRowIndex = dtItems.Rows.Count - 1;
                                                            //
                                                            DataGridViewRow SelectedRow = dtItems.Rows[dtItems.Rows.Count - 1];
                                                            //
                                                            lblMensagemTopo.Text = SelectedRow.Cells[2].Value.ToString();
                                                            //
                                                        }
                                                        //
                                                        txtProduto.Text = null;
                                                        //
                                                        txtProduto.Select();
                                                        //
                                                        pPanelCaixaLivre.Visible = false;
                                                        pPanelCaixaFechado.Visible = false;
                                                    }
                                                }
                                                else
                                                {
                                                    bllVenda.Salvar_Dados_Atuais_PDV(bllConexao._Codigo_Conexao);
                                                    //
                                                    bllVenda._PDV_PesqCliente_Tabela = null;
                                                    //
                                                    txtProduto.Select();
                                                    //
                                                    pPanelCaixaLivre.BringToFront();
                                                    pPanelCaixaLivre.Visible = true;
                                                    pPanelCaixaFechado.Visible = false;
                                                }
                                            }
                                        }
                                    }
                                    else if (bllVenda._Permitir_Abrir_Caixa == 0)
                                    {
                                        MessageBox.Show("O Usuário informado não possui permissão para realizar Abertura de Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                            this.Enabled = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento eyUp do FrmSistemaBigPicture.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento eyUp do FrmSistemaBigPicture.");
                }
            }
        }
    }
}
