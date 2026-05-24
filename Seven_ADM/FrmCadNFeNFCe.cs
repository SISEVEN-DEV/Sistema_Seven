using ACBrLib.NFe;
using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadNFeNFCe : Form
    {
        public FrmCadNFeNFCe(string usuario, string cod_pdv_computador, byte formulario, string total_produtos, string valor_total, string cod_dfe, byte importado, bool proprio)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Total_Produtos = total_produtos;
            _Valor_Total = valor_total;
            _Cod_Dfe = cod_dfe;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Total_Produtos_Items = Convert.ToDecimal(valor_total);
            //
            if (_Formulario == 0)
            {
                if (importado == 1)
                {
                    _Importado = true;
                }
                else
                {
                    _Importado = false;
                }
                //
                lblItem.Location = new Point(23, 48);
                dtItens.Location = new Point(30, 65);
                dtItens.Size = new Size(764, 238);
                btnIncluir.Location = new Point(30, 309);
                btnAlterar.Location = new Point(110, 309);
                lblDiferenca.Location = new Point(346, 306);
                btnExcluirItem.Location = new Point(186, 309);
                lblRegistros.Location = new Point(677, 306);
                btnCapturar.Visible = false;
                lblAsterisco7.Visible = false;
                label10.Visible = false;
                cbbTipo.Visible = false;
                cbbFinalidade.Visible = false;
                grbBox1.Visible = false;
                if (proprio == true)
                {
                    lblDiferenca.Visible = false;
                    _Importado = true;
                }
                else
                {
                    lblDiferenca.Visible = true;
                }
                grbBox2.Location = new Point(30, 346);
                btnSalvar.Visible = false;
                btnSair.Location = new Point(739, 464);
                btnContinuar.Visible = false;
                this.Size = new Size(802, 503);
                this.Text = "Cadastro de itens da DFe";
                label15.Visible = true;
                lblValorDesconto.Visible = true;
                label17.Visible = true;
                lblValorFrete.Visible = true;
                label21.Visible = true;
                lblValorTotal.Visible = true;
                label19.Visible = true;
                lblValorDespesa.Visible = true;
                btnCadastrarTransportadora.Visible = false;
                btnReferenciar.Visible = false;
                btnPagamento.Visible = false;
                btnExcluirDFe.Visible = false;
                btnCancelar.Visible = false;
                //
                ttpNFe.SetToolTip(btnSair, "Sair do Cadastro de itens da DFe");
            }
            else if (_Formulario == 3)
            {
                btnSalvar.Visible = false;
            }
        }

        private byte _Formulario;
        private string _Total_Produtos;
        private string _Valor_Total;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Cod_Dfe;
        private decimal _Total_Produtos_Items;
        private bool _Importado;

        private void FrmCadNFeNFCe_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadNFeNFCe iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadNFeNFCe iniciado.");
                }
                //
                bllDFe._FrmCadNFeNFCe_Ativo = true;
                //
                if (_Formulario == 0)
                {
                    if (bllDFe.Sel_Items_DFe(_Cod_Dfe) == null)
                    {
                        lblDiferenca.Text = "Difrerença: " + _Total_Produtos_Items;
                        btnIncluir.Select();
                    }
                    else
                    {
                        dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);

                    }
                    //
                    cbbFinalidade.Text = "SAIDA";
                    dtItens.Select();
                }
                else if (_Formulario == 1)
                {
                    if (bllDFe.Sel_Dados_DFe_Temp(bllConexao._Codigo_Conexao) != null)
                    {
                        DataRow dr = bllDFe.Sel_Dados_DFe_Temp(bllConexao._Codigo_Conexao).Rows[0];
                        //
                        cbbTipo.Text = "MODELO 55 (NFe)";
                        //
                        cbbFinalidade.Text = dr["finalidade"].ToString();
                        //
                        mtxtDataSaida.Text = dr["data_saida"].ToString();
                        //
                        mtxtHorario1.Text = dr["hora_saida"].ToString();
                        //
                        cbbNaturezaOperacaoCFOP.Text = dr["cod_cfop"].ToString() + "—" + dr["descricao_cfop"].ToString();
                        //
                        cbbTipoDestinatario.Text = dr["tipo_emitente_destinatario"].ToString();
                        //
                        cbbDestinatario.Text = dr["id_emitente_destinatario"].ToString() + "—" + dr["nome_emitente_destinatario"].ToString() + "—" + dr["cpf_cnpj_emitente_destinatario"].ToString();
                        //
                        rtxtObs.Text = dr["observacao"].ToString();
                        //
                        if (Convert.ToByte(dr["consumidor_final"]) == 1)
                        {
                            bllDFe._Consumidor_Final = true;
                        }
                        else
                        {
                            bllDFe._Consumidor_Final = false;
                        }
                        //
                        if (dr["tipo_operacao"].ToString() == "OPERACAO PRESENCIAL")
                        {
                            bllDFe._Tipo_Operacao = "OPERACAO PRESENCIAL";
                        }
                        else if (dr["tipo_operacao"].ToString() == "OPERACAO PELA INTERNET")
                        {
                            bllDFe._Tipo_Operacao = "OPERACAO PELA INTERNET";
                        }
                        else if (dr["tipo_operacao"].ToString() == "OPERACAO NAO PRESENCIAL")
                        {
                            bllDFe._Tipo_Operacao = "OPERACAO NAO PRESENCIAL";
                        }
                        //
                        if (Convert.ToInt32(dr["id_dfe"]) == 0)
                        {
                            _Cod_Dfe = null;
                        }
                        else
                        {
                            _Cod_Dfe = dr["id_dfe"].ToString();
                        }
                    }
                    else
                    {
                        cbbTipo.Text = "MODELO 55 (NFe)";
                        //
                        cbbFinalidade.Text = "SAIDA";
                        //
                        cbbTipoDestinatario.Text = "CLIENTES";
                        //
                        cbbTipoDestinatario.SelectedIndex = 0;
                    }
                    //
                    if (bllDFe.Sel_Items_DFe_Temp(bllConexao._Codigo_Conexao) != null)
                    {
                        dtItens.DataSource = bllDFe.Sel_Items_DFe_Temp(bllConexao._Codigo_Conexao);
                        //
                        dtItens.Select();
                    }
                    else
                    {
                        cbbTipo.Select();
                    }
                }
                else if (_Formulario == 2)
                {
                    DataRow drDFe = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                    //
                    lblTipo.ForeColor = Color.Blue;
                    cbbTipo.Text = "MODELO 55 (NFe)";
                    //
                    lblFinalidade.ForeColor = Color.Blue;
                    cbbFinalidade.Items.Clear();
                    cbbFinalidade.Items.Add(drDFe["finalidade"].ToString());
                    cbbFinalidade.Text = drDFe["finalidade"].ToString();
                    //
                    lblNatOp.ForeColor = Color.Blue;
                    cbbNaturezaOperacaoCFOP.Items.Clear();
                    cbbNaturezaOperacaoCFOP.Items.Add(drDFe["descricao_cfop_natop"].ToString().Replace("5—", ""));
                    cbbNaturezaOperacaoCFOP.Text = drDFe["descricao_cfop_natop"].ToString().Replace("5—", "");
                    btnProcurarNatOPCFOP.Enabled = false;
                    cbbNaturezaOperacaoCFOP.DropDownWidth = 223;
                    //
                    btnSelecionarData2.Enabled = false;
                    //
                    lblLocDestinatario.ForeColor = Color.Blue;
                    cbbTipoDestinatario.Items.Clear();
                    cbbTipoDestinatario.Items.Add(drDFe["tipo_emitente_destinatario"].ToString());
                    cbbTipoDestinatario.Text = drDFe["tipo_emitente_destinatario"].ToString();
                    //
                    rtxtObs.Text = drDFe["observacao"].ToString();
                    //
                    lblDestinatario.ForeColor = Color.Blue;
                    if (drDFe["id_emitente_destinatario"].ToString() != "0")
                    {
                        cbbDestinatario.Items.Clear();
                        cbbDestinatario.Items.Add(drDFe["id_emitente_destinatario"].ToString() + "—" + drDFe["nome_emitente_destinatario"].ToString() + "—" + drDFe["cpf_cnpj_emit_dest"].ToString());
                        cbbDestinatario.Text = drDFe["id_emitente_destinatario"].ToString() + "—" + drDFe["nome_emitente_destinatario"].ToString() + "—" + drDFe["cpf_cnpj_emit_dest"].ToString();
                    }
                    else
                    {
                        cbbDestinatario.Items.Clear();
                        cbbDestinatario.Items.Add(drDFe["nome_emitente_destinatario"].ToString());
                        cbbDestinatario.Text = drDFe["nome_emitente_destinatario"].ToString();
                    }
                    btnpProcurarDestinatario.Enabled = false;
                    //
                    if (Convert.ToByte(drDFe["consumidor_final"]) == 1)
                    {
                        bllDFe._Consumidor_Final = true;
                    }
                    else
                    {
                        bllDFe._Consumidor_Final = false;
                    }
                    //
                    if (drDFe["tipo_operacao"].ToString() == "OPERACAO PRESENCIAL")
                    {
                        bllDFe._Tipo_Operacao = "OPERACAO PRESENCIAL";
                    }
                    else if (drDFe["tipo_operacao"].ToString() == "OPERACAO PELA INTERNET")
                    {
                        bllDFe._Tipo_Operacao = "OPERACAO PELA INTERNET";
                    }
                    else if (drDFe["tipo_operacao"].ToString() == "OPERACAO NAO PRESENCIAL")
                    {
                        bllDFe._Tipo_Operacao = "OPERACAO NAO PRESENCIAL";
                    }
                    //
                    lblItem.ForeColor = Color.Blue;
                    if (bllDFe.Sel_Items_DFe(_Cod_Dfe) != null)
                    {
                        dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                    }
                    //
                    bllDFe.CriarDFeNFe(_Cod_Dfe, _Cod_PDV_Computador);
                    //
                    btnCapturar.Visible = false;
                    btnExcluirItem.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnIncluir.Enabled = false;
                    btnCancelar.Visible = false;
                    btnReferenciar.Visible = false;
                    btnCadastrarTransportadora.Visible = false;
                    btnPagamento.Visible = false;
                    btnSalvar.Visible = false;
                    btnContinuar.Select();
                    //
                    btnContinuar_Click(sender, e);
                }
                else if (_Formulario == 3)
                {
                    DataRow drDFe = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                    //
                    cbbTipo.Text = "MODELO 55 (NFe)";
                    //
                    cbbFinalidade.Text = drDFe["finalidade"].ToString();
                    //
                    cbbNaturezaOperacaoCFOP.Text = drDFe["descricao_cfop_natop"].ToString();
                    //
                    mtxtDataSaida.Text = drDFe["data_saida"].ToString();
                    //
                    mtxtHorario1.Text = drDFe["hora_saida"].ToString();
                    //
                    cbbTipoDestinatario.Text = drDFe["tipo_emitente_destinatario"].ToString();
                    //
                    rtxtObs.Text = drDFe["observacao"].ToString();
                    //
                    if (drDFe["id_emitente_destinatario"].ToString() != "0")
                    {
                        cbbDestinatario.Text = drDFe["id_emitente_destinatario"].ToString() + "—" + drDFe["nome_emitente_destinatario"].ToString() + "—" + drDFe["cpf_cnpj_emit_dest"].ToString();
                    }
                    else
                    {
                        cbbDestinatario.Text = drDFe["nome_emitente_destinatario"].ToString();
                    }
                    //
                    if (Convert.ToByte(drDFe["consumidor_final"]) == 1)
                    {
                        bllDFe._Consumidor_Final = true;
                    }
                    else
                    {
                        bllDFe._Consumidor_Final = false;
                    }
                    //
                    if (drDFe["tipo_operacao"].ToString() == "OPERACAO PRESENCIAL")
                    {
                        bllDFe._Tipo_Operacao = "OPERACAO PRESENCIAL";
                    }
                    else if (drDFe["tipo_operacao"].ToString() == "OPERACAO PELA INTERNET")
                    {
                        bllDFe._Tipo_Operacao = "OPERACAO PELA INTERNET";
                    }
                    else if (drDFe["tipo_operacao"].ToString() == "OPERACAO NAO PRESENCIAL")
                    {
                        bllDFe._Tipo_Operacao = "OPERACAO NAO PRESENCIAL";
                    }
                    //
                    if (bllDFe.Sel_Items_DFe(_Cod_Dfe) != null)
                    {
                        dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                    }
                    //
                    btnExcluirDFe.Visible = true;
                    btnCancelar.Visible = false;
                }
                else if (_Formulario == 4)
                {
                    DataRow drDFe = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                    //
                    lblTipo.ForeColor = Color.Blue;
                    cbbTipo.Text = "MODELO 55 (NFe)";
                    //
                    lblFinalidade.ForeColor = Color.Blue;
                    cbbFinalidade.Items.Clear();
                    cbbFinalidade.Items.Add(drDFe["finalidade"].ToString());
                    cbbFinalidade.Text = drDFe["finalidade"].ToString();
                    //
                    lblNatOp.ForeColor = Color.Blue;
                    cbbNaturezaOperacaoCFOP.Items.Clear();
                    cbbNaturezaOperacaoCFOP.Items.Add(drDFe["descricao_cfop_natop"].ToString().Replace("5—", ""));
                    cbbNaturezaOperacaoCFOP.Text = drDFe["descricao_cfop_natop"].ToString().Replace("5—", "");
                    btnProcurarNatOPCFOP.Enabled = false;
                    cbbNaturezaOperacaoCFOP.DropDownWidth = 223;
                    //
                    btnSelecionarData2.Enabled = false;
                    //
                    lblLocDestinatario.ForeColor = Color.Blue;
                    cbbTipoDestinatario.Items.Clear();
                    cbbTipoDestinatario.Items.Add(drDFe["tipo_emitente_destinatario"].ToString());
                    cbbTipoDestinatario.Text = drDFe["tipo_emitente_destinatario"].ToString();
                    //
                    rtxtObs.Text = drDFe["observacao"].ToString();
                    //
                    lblDestinatario.ForeColor = Color.Blue;
                    if (drDFe["id_emitente_destinatario"].ToString() != "0")
                    {
                        cbbDestinatario.Items.Clear();
                        cbbDestinatario.Items.Add(drDFe["id_emitente_destinatario"].ToString() + "—" + drDFe["nome_emitente_destinatario"].ToString() + "—" + drDFe["cpf_cnpj_emit_dest"].ToString());
                        cbbDestinatario.Text = drDFe["id_emitente_destinatario"].ToString() + "—" + drDFe["nome_emitente_destinatario"].ToString() + "—" + drDFe["cpf_cnpj_emit_dest"].ToString();
                    }
                    else
                    {
                        cbbDestinatario.Items.Clear();
                        cbbDestinatario.Items.Add(drDFe["nome_emitente_destinatario"].ToString());
                        cbbDestinatario.Text = drDFe["nome_emitente_destinatario"].ToString();
                    }
                    btnpProcurarDestinatario.Enabled = false;
                    //
                    if (Convert.ToByte(drDFe["consumidor_final"]) == 1)
                    {
                        bllDFe._Consumidor_Final = true;
                    }
                    else
                    {
                        bllDFe._Consumidor_Final = false;
                    }
                    //
                    if (drDFe["tipo_operacao"].ToString() == "OPERACAO PRESENCIAL")
                    {
                        bllDFe._Tipo_Operacao = "OPERACAO PRESENCIAL";
                    }
                    else if (drDFe["tipo_operacao"].ToString() == "OPERACAO PELA INTERNET")
                    {
                        bllDFe._Tipo_Operacao = "OPERACAO PELA INTERNET";
                    }
                    else if (drDFe["tipo_operacao"].ToString() == "OPERACAO NAO PRESENCIAL")
                    {
                        bllDFe._Tipo_Operacao = "OPERACAO NAO PRESENCIAL";
                    }
                    //
                    lblItem.ForeColor = Color.Blue;
                    if (bllDFe.Sel_Items_DFe(_Cod_Dfe) != null)
                    {
                        dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                    }
                    //
                    bllDFe.CriarDFeNFe(_Cod_Dfe, _Cod_PDV_Computador);
                    //
                    btnCapturar.Visible = false;
                    btnExcluirItem.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnIncluir.Enabled = false;
                    btnCancelar.Visible = false;
                    btnReferenciar.Visible = false;
                    btnCadastrarTransportadora.Visible = false;
                    btnPagamento.Visible = false;
                    btnSalvar.Visible = false;
                    btnContinuar.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadNFeNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadNFeNFCe.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Limpar()
        {
            cbbTipo.Text = "MODELO 55 (NFe)";
            cbbFinalidade.Text = "SAIDA";
            cbbTipoDestinatario.Text = "CLIENTES";
            mtxtDataSaida.Text = null;
            mtxtHorario1.Text = null;
            cbbDestinatario.Text = null;
            rtxtObs.Text = null;
            dtItens.DataSource = null;
            cbbNaturezaOperacaoCFOP.Text = null;
            bllDFe._Consumidor_Final = false;
            bllDFe._Tipo_Operacao = null;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnContinuar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnContinuar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnIncuir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncuir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluirItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCapturar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCapturar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurarDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurarDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbDestinatario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbDestinatario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarNatOPCFOP_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarNatOPCFOP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbNaturezaOperacaoCFOP_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbNaturezaOperacaoCFOP_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbNaturezaOperacaoCFOP_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbNaturezaOperacaoCFOP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImportarXML_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImportarXML_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFinalidade_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFinalidade_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbFinalidade_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFinalidade_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalProdutos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalProdutos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDesconto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDesconto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorBaseCalculo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorBaseCalculo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorFrete_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorFrete_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorICMS_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorICMS_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDespesa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDespesa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorICMSST_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorICMSST_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmCadNFeNFCe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Formulario == 0 || _Formulario == 3 || _Formulario == 4)
                {
                    this.DialogResult = DialogResult.Abort;
                }
                else if (_Formulario == 2)
                {
                    DialogResult = MessageBox.Show("Deseja sair do Cadastro de Itens do DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0 || _Formulario == 3 || _Formulario == 4)
            {
                this.DialogResult = DialogResult.Abort;
            }
            else if (_Formulario == 2)
            {
                DialogResult = MessageBox.Show("Deseja sair do Cadastro de Itens do DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Abort;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void lblValorTotalProdutos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total dos Produtos: " + lblValorTotalProdutos.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorBaseCalculo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Base de Cálculo ICMS: " + lblValorBaseCalculo.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorICMS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ICMS: " + lblValorICMS.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorICMSST_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ICMS ST: " + lblValorICMSST.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDesconto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Descontos: " + lblValorDesconto.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorFrete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Frete: " + lblValorFrete.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDespesa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Despesas: " + lblValorDespesa.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Total: " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFinalidade.Select();
            }
        }

        private void cbbNaturezaOperacaoCFOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipoDestinatario.Select();
            }
        }

        private void FrmCadNFeNFCe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_Formulario == 1)
                {
                    mtxtDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    //
                    if (_Cod_Dfe == null)
                    {
                        if (dtItens.DataSource != null || cbbTipo.Text != "MODELO 55 (NFe)" || cbbFinalidade.Text != "SAIDA" || mtxtDataSaida.Text != "" || mtxtHorario1.Text != "" || cbbNaturezaOperacaoCFOP.Text != "" || cbbDestinatario.Text != "" || rtxtObs.Text.Trim() != "" || bllTransportador.Sel_Dados_Transportador_Temp(bllConexao._Codigo_Conexao) != null || bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao) != null || bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao) != null)
                        {
                            DialogResult = MessageBox.Show("Deseja manter os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                //
                                if (bllDFe.Sel_Dados_DFe_Temp(bllConexao._Codigo_Conexao) == null)
                                {
                                    bllDFe.Salvar_DFe_Temp(cbbFinalidade.Text, cbbTipo.Text, mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text, cbbNaturezaOperacaoCFOP.Text, bllConexao._Codigo_Conexao, cbbTipoDestinatario.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, _Cod_Dfe);
                                }
                                else
                                {
                                    bllDFe.Alterar_DFe_Temp(cbbFinalidade.Text, cbbTipo.Text, mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text, cbbNaturezaOperacaoCFOP.Text, bllConexao._Codigo_Conexao, cbbTipoDestinatario.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, _Cod_Dfe);
                                }
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                //
                                if (dtItens.DataSource != null)
                                {
                                    for (int i = 0; i < dtItens.Rows.Count; i++)
                                    {
                                        DataGridViewRow SelectedRow = dtItens.Rows[i];
                                        //
                                        if (cbbFinalidade.Text == "SAIDA")
                                        {
                                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                                        }
                                        else if (cbbFinalidade.Text == "RETORNO")
                                        {
                                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                                        }
                                        else if (cbbFinalidade.Text == "ENTRADA")
                                        {
                                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                                        }
                                        else if (cbbFinalidade.Text == "DEVOLUCAO")
                                        {
                                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                                        }
                                        else if (cbbFinalidade.Text == "COMPLEMENTAR")
                                        {
                                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                                        }
                                    }
                                }
                                //
                                bllDFe.Excluir_DFe_Temp(bllConexao._Codigo_Conexao);
                                //
                                bllDFe.Excluir_Todos_Item_DFe_Temp(bllConexao._Codigo_Conexao);
                                //
                                bllDFe.Excluir_Todos_Referencia_Temp(bllConexao._Codigo_Conexao);
                                //
                                bllDFe.Excluir_Todos_Transportador_Temp(bllConexao._Codigo_Conexao);
                                //
                                bllDFe.Excluir_Item_DFe_Pgto_Atual(bllConexao._Codigo_Conexao);
                                //
                                this.DialogResult = DialogResult.Abort;
                            }
                        }
                    }
                }
                else
                {
                    if (_Formulario != 0)
                    {
                        DataRow dr;
                        if (bllDFe.Sel_Nfe_Codigo(_Cod_Dfe) != null)
                        {
                            dr = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                            //
                            if (dr["situacao"].ToString() == "PENDENTE")
                            {
                                bool consumidor_final;
                                if (Convert.ToByte(dr["consumidor_final"]) == 1)
                                {
                                    consumidor_final = true;
                                }
                                else
                                {
                                    consumidor_final = false;
                                }
                                //
                                bool venda;
                                if (Convert.ToByte(dr["origem_venda"]) == 1)
                                {
                                    venda = true;
                                }
                                else
                                {
                                    venda = false;
                                }
                                //
                                bllDFe.Alterar(_Cod_Dfe, dr["chave_dfe"].ToString(), dr["emissao"].ToString(), cbbTipo.Text, dr["numero_nf"].ToString(), dr["serie"].ToString(), dr["data_emissao"].ToString().Remove(10), dr["hora_emissao"].ToString(), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text, lblValorDesconto.Text, lblValorFrete.Text, lblValorDespesa.Text, lblValorTotal.Text, cbbNaturezaOperacaoCFOP.Text, cbbTipoDestinatario.Text, dr["seguro"].ToString(), dr["ipi"].ToString(), cbbFinalidade.Text, consumidor_final, dr["tipo_operacao"].ToString(), venda);
                            }
                        }
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadNFeNFCe foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadNFeNFCe foi finalizado.");
                }
                //
                bllDFe._FrmCadNFeNFCe_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadNFeNFCe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmCadNFeNFCe.");
                }
            }
        }



        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                btnIncluir.Select();
                //
                pEnabled.Enabled = false;
                //
                string cfop = null;
                if (cbbNaturezaOperacaoCFOP.Text != null)
                {
                    string[] items = cbbNaturezaOperacaoCFOP.Text.Split('—');
                    cfop = items[0];
                }
                //
                using (FrmCadItemNFeNFCe Item = new FrmCadItemNFeNFCe(_Formulario, dtItens.Rows.Count.ToString(), _Cod_Dfe, false, null, null, null, null, null, null, cfop, null, null, null, null, null, null, null, null, null, null, null, null, null, null, cbbFinalidade.Text, cbbTipo.Text, _Usuario, _Cod_PDV_Computador, null, null, null, null))
                {
                    if (Item.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.None;
                        if (_Formulario == 0 || _Formulario == 4)
                        {
                            dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                            //
                            DataRow dr;
                            decimal icms = 0;
                            decimal icmsst = 0;
                            decimal base_calculo_icms = 0;
                            decimal base_calculo_icms_st = 0;
                            decimal total_aprox_trib = 0;
                            //
                            for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                            {
                                dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                //
                                icms += Convert.ToDecimal(dr["valor_icms"]);
                                icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                            }
                            //
                            bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                            //
                            dtItens.CurrentCell = dtItens.Rows[dtItens.Rows.Count - 1].Cells[0];
                            //
                            dtItens.Rows[dtItens.Rows.Count - 1].Selected = true;
                            //
                            dtItens.FirstDisplayedScrollingRowIndex = dtItens.Rows.Count - 1;
                            //
                            dtItens.Select();
                        }                        
                        else if (_Formulario == 1)
                        {
                            if (_Cod_Dfe == null)
                            {
                                dtItens.DataSource = bllDFe.Sel_Items_DFe_Temp(bllConexao._Codigo_Conexao);
                            }
                            else
                            {
                                dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                                //
                                string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                //
                                DataRow dr = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                                //
                                bool venda;
                                if (dr["origem_venda"].ToString() == "1")
                                {
                                    venda = true;
                                }
                                else
                                {
                                    venda = false;
                                }
                                //
                                bllDFe.Alterar(_Cod_Dfe, dr["chave_dfe"].ToString(), "PRÓPRIA", cbbTipo.Text, dr["numero_nf"].ToString(), serie, dr["data_emissao"].ToString().Remove(10), dr["hora_emissao"].ToString(), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text.Trim(), lblValorDesconto.Text.Trim(), lblValorFrete.Text.Trim(), lblValorDespesa.Text.Trim(), lblValorTotal.Text.Trim(), cbbNaturezaOperacaoCFOP.Text, cbbTipoDestinatario.Text, "0", "0", cbbFinalidade.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, venda);
                                //
                                decimal icms = 0;
                                decimal icmsst = 0;
                                decimal base_calculo_icms = 0;
                                decimal base_calculo_icms_st = 0;
                                decimal total_aprox_trib = 0;
                                //
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                                {
                                    dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                    //
                                    icms += Convert.ToDecimal(dr["valor_icms"]);
                                    icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                    base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                    base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                    total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                                }
                                //
                                bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                            }
                            //
                            dtItens.CurrentCell = dtItens.Rows[dtItens.Rows.Count - 1].Cells[0];
                            //
                            dtItens.Rows[dtItens.Rows.Count - 1].Selected = true;
                            //
                            dtItens.FirstDisplayedScrollingRowIndex = dtItens.Rows.Count - 1;
                            //
                            dtItens.Select();
                            //
                            DataGridViewRow SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                            //
                            if (cbbFinalidade.Text == "SAIDA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "RETORNO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "ENTRADA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "DEVOLUCAO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "COMPLEMENTAR")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                        }
                        else if (_Formulario == 3)
                        {
                            dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                            //
                            string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                            //
                            DataRow dr = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                            //
                            bool venda;
                            if (dr["origem_venda"].ToString() == "1")
                            {
                                venda = true;
                            }
                            else
                            {
                                venda = false;
                            }
                            //
                            bllDFe.Alterar(_Cod_Dfe, dr["chave_dfe"].ToString(), "PRÓPRIA", cbbTipo.Text, dr["numero_nf"].ToString(), serie, dr["data_emissao"].ToString().Remove(10), dr["hora_emissao"].ToString(), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text.Trim(), lblValorDesconto.Text.Trim(), lblValorFrete.Text.Trim(), lblValorDespesa.Text.Trim(), lblValorTotal.Text.Trim(), cbbNaturezaOperacaoCFOP.Text, cbbTipoDestinatario.Text, "0", "0", cbbFinalidade.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, venda);
                            //
                            decimal icms = 0;
                            decimal icmsst = 0;
                            decimal base_calculo_icms = 0;
                            decimal base_calculo_icms_st = 0;
                            decimal total_aprox_trib = 0;
                            //
                            for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                            {
                                dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                //
                                icms += Convert.ToDecimal(dr["valor_icms"]);
                                icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                            }
                            //
                            bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                            //
                            dtItens.CurrentCell = dtItens.Rows[dtItens.Rows.Count - 1].Cells[0];
                            //
                            dtItens.Rows[dtItens.Rows.Count - 1].Selected = true;
                            //
                            dtItens.FirstDisplayedScrollingRowIndex = dtItens.Rows.Count - 1;
                            //
                            dtItens.Select();
                            //
                            DataGridViewRow SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                            //
                            if (cbbFinalidade.Text == "SAIDA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "RETORNO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "ENTRADA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "DEVOLUCAO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "COMPLEMENTAR")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
                dtItens.DataSource = null;
                btnIncluir.Select();
            }
            pEnabled.Enabled = true;
        }

        private void dtItens_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtItens.Columns[0].HeaderText = "Item";
                dtItens.Columns[1].HeaderText = "Código";
                dtItens.Columns[2].HeaderText = "Descrição";
                dtItens.Columns[3].HeaderText = "UM.";
                dtItens.Columns[4].HeaderText = "Quantidade";
                dtItens.Columns[5].HeaderText = "QTD. da Emb.";
                dtItens.Columns[6].HeaderText = "VL. Unit./Preço (R$)";
                dtItens.Columns[7].HeaderText = "Total (R$)";
                dtItens.Columns[8].HeaderText = "Valor do Desconto (R$)";
                dtItens.Columns[9].HeaderText = "Valor do Acréscimo (R$)";
                dtItens.Columns[10].HeaderText = "CST";
                dtItens.Columns[11].HeaderText = "Alíquota ICMS (%)";
                dtItens.Columns[12].HeaderText = "ICMS";
                dtItens.Columns[13].HeaderText = "Base de Cálculo";
                dtItens.Columns[14].HeaderText = "Total Real (R$)";
                dtItens.Columns[15].HeaderText = "CSOSN";
                dtItens.Columns[16].HeaderText = "CFOP";
                dtItens.Columns[17].HeaderText = "NCM";
                dtItens.Columns[18].HeaderText = "CEST";
                dtItens.Columns[19].Visible = false;
                dtItens.Columns[20].HeaderText = "Alíquota ST (%)";
                dtItens.Columns[21].HeaderText = "Base de Cálculo ST";
                dtItens.Columns[22].HeaderText = "MVA (%)";
                dtItens.Columns[23].HeaderText = "Redução BC (%)";
                dtItens.Columns[24].HeaderText = "ICMS ST";
                if (_Formulario == 0)
                {
                    dtItens.Columns[25].Visible = false;
                }
                else
                {
                    dtItens.Columns[25].HeaderText = "Total Aprox. dos Trib.";
                }
                dtItens.Columns[26].HeaderText = "Alíquota IPI (%)";
                dtItens.Columns[27].HeaderText = "IPI";
                dtItens.Columns[28].HeaderText = "Redução BC ST (%)";
                dtItens.Columns[29].HeaderText = "CST IBS CBS";
                dtItens.Columns[30].HeaderText = "Cód. Sit. Trib. (cClass Trib)";
                dtItens.Columns[31].HeaderText = "Aliq. IBS Mun. (%)";
                dtItens.Columns[32].HeaderText = "Aliq. IBS Est. (%)";
                dtItens.Columns[33].HeaderText = "Aliq. CBS (%)";
                dtItens.Columns[34].HeaderText = "Valor Frete (R$)";
                //
                dtItens.Columns[0].Width = 55;
                dtItens.Columns[1].Width = 85;
                dtItens.Columns[2].Width = 255;
                dtItens.Columns[3].Width = 46;
                dtItens.Columns[4].Width = 95;
                dtItens.Columns[5].Width = 100;
                dtItens.Columns[6].Width = 135;
                dtItens.Columns[7].Width = 150;
                dtItens.Columns[8].Width = 150;
                dtItens.Columns[9].Width = 150;
                dtItens.Columns[10].Width = 85;
                dtItens.Columns[11].Width = 150;
                dtItens.Columns[12].Width = 150;
                dtItens.Columns[13].Width = 150;
                dtItens.Columns[14].Width = 150;
                dtItens.Columns[15].Width = 85;
                dtItens.Columns[16].Width = 85;
                dtItens.Columns[17].Width = 120;
                dtItens.Columns[18].Width = 120;
                dtItens.Columns[20].Width = 150;
                dtItens.Columns[21].Width = 150;
                dtItens.Columns[22].Width = 150;
                dtItens.Columns[23].Width = 150;
                dtItens.Columns[24].Width = 150;
                dtItens.Columns[25].Width = 175;
                dtItens.Columns[26].Width = 150;
                dtItens.Columns[27].Width = 150;
                dtItens.Columns[28].Width = 150;
                dtItens.Columns[29].Width = 125;
                dtItens.Columns[30].Width = 175;
                dtItens.Columns[31].Width = 175;
                dtItens.Columns[32].Width = 125;
                dtItens.Columns[33].Width = 125;
                dtItens.Columns[34].Width = 150;

                dtItens.DefaultCellStyle.Font = new Font(dtItens.Font, FontStyle.Bold);

                dtItens.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtItens.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtItens.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                decimal total_produtos_items = _Total_Produtos_Items;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    //total_produtos_items -= Convert.ToDecimal(dtItens.Rows[i].Cells[14].Value) + Convert.ToDecimal(dtItens.Rows[i].Cells[27].Value);
                    total_produtos_items -= Convert.ToDecimal(dtItens.Rows[i].Cells[14].Value);
                }
                lblDiferenca.Text = "Diferença (R$): " + total_produtos_items.ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal total_produtos = 0;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    total_produtos += Convert.ToDecimal(dtItens.Rows[i].Cells[7].Value);
                }
                lblValorTotalProdutos.Text = total_produtos.ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal base_calculo = 0;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    base_calculo += Convert.ToDecimal(dtItens.Rows[i].Cells[13].Value);
                }
                lblValorBaseCalculo.Text = base_calculo.ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal icms = 0;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    icms += Convert.ToDecimal(dtItens.Rows[i].Cells[12].Value);
                }
                lblValorICMS.Text = icms.ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valor_total = 0;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    valor_total += Convert.ToDecimal(dtItens.Rows[i].Cells[14].Value);
                }
                lblValorTotal.Text = valor_total.ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal despesas = 0;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    despesas += Convert.ToDecimal(dtItens.Rows[i].Cells[9].Value);
                }
                lblValorDespesa.Text = despesas.ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal descontos = 0;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    descontos += Convert.ToDecimal(dtItens.Rows[i].Cells[8].Value);
                }
                lblValorDesconto.Text = descontos.ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal base_calculo_st = 0;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    base_calculo_st += Convert.ToDecimal(dtItens.Rows[i].Cells[21].Value);
                }
                lblValorBaseCalculoST.Text = base_calculo_st.ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal icms_st = 0;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    icms_st += Convert.ToDecimal(dtItens.Rows[i].Cells[24].Value);
                }
                lblValorICMSST.Text = icms_st.ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal ipi = 0;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    ipi += Convert.ToDecimal(dtItens.Rows[i].Cells[27].Value);
                }
                lblValorIPI.Text = ipi.ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal frete = 0;
                for (int i = 0; i < dtItens.Rows.Count; i++)
                {
                    frete += Convert.ToDecimal(dtItens.Rows[i].Cells[34].Value);
                }
                lblValorFrete.Text = frete.ToString("n2", new CultureInfo("pt-BR"));
                //
                lblRegistros.Text = "Registros: " + dtItens.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtItens.");
                }
                dtItens.DataSource = null;
            }
        }

        private void dtItens_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtItens.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtItens.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtItens.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[0].DefaultCellStyle.Format = "D3";
                dtItens.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[4].DefaultCellStyle.Format = "n2";
                dtItens.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[5].DefaultCellStyle.Format = "n2";
                dtItens.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[6].DefaultCellStyle.Format = "n2";
                dtItens.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[7].DefaultCellStyle.Format = "n2";
                dtItens.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[8].DefaultCellStyle.Format = "n2";
                dtItens.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[9].DefaultCellStyle.Format = "n2";
                dtItens.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[11].DefaultCellStyle.Format = "n2";
                dtItens.Columns[12].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[12].DefaultCellStyle.Format = "n2";
                dtItens.Columns[13].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[13].DefaultCellStyle.Format = "n2";
                dtItens.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[14].DefaultCellStyle.Format = "n2";
                dtItens.Columns[20].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[20].DefaultCellStyle.Format = "n2";
                dtItens.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[21].DefaultCellStyle.Format = "n2";
                dtItens.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[22].DefaultCellStyle.Format = "n2";
                dtItens.Columns[23].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[23].DefaultCellStyle.Format = "n2";
                dtItens.Columns[24].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[24].DefaultCellStyle.Format = "n2";
                dtItens.Columns[26].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[26].DefaultCellStyle.Format = "n2";
                dtItens.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[27].DefaultCellStyle.Format = "n2";
                dtItens.Columns[28].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[28].DefaultCellStyle.Format = "n2";
                dtItens.Columns[31].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[31].DefaultCellStyle.Format = "n2";
                dtItens.Columns[32].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[32].DefaultCellStyle.Format = "n2";
                dtItens.Columns[33].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[33].DefaultCellStyle.Format = "n2";
                dtItens.Columns[34].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtItens.Columns[34].DefaultCellStyle.Format = "n2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtItens.");
                }
                dtItens.DataSource = null;
            }
        }

        private void dtItens_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            decimal total_produtos_items = _Total_Produtos_Items;
            for (int i = 0; i < dtItens.Rows.Count; i++)
            {
                total_produtos_items += Convert.ToDecimal(dtItens.Rows[i].Cells[14].Value);

            }
            lblDiferenca.Text = "Diferença (R$): " + total_produtos_items.ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal total_produtos = 0;
            for (int i = 0; i < dtItens.Rows.Count; i++)
            {
                total_produtos += Convert.ToDecimal(dtItens.Rows[i].Cells[7].Value);
            }
            lblValorTotalProdutos.Text = total_produtos.ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal base_calculo = 0;
            for (int i = 0; i < dtItens.Rows.Count; i++)
            {
                base_calculo += Convert.ToDecimal(dtItens.Rows[i].Cells[13].Value);
            }
            lblValorBaseCalculo.Text = base_calculo.ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal icms = 0;
            for (int i = 0; i < dtItens.Rows.Count; i++)
            {
                icms += Convert.ToDecimal(dtItens.Rows[i].Cells[12].Value);
            }
            lblValorICMS.Text = icms.ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valor_total = 0;
            for (int i = 0; i < dtItens.Rows.Count; i++)
            {
                valor_total += Convert.ToDecimal(dtItens.Rows[i].Cells[14].Value);
            }
            lblValorTotal.Text = icms.ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal despesas = 0;
            for (int i = 0; i < dtItens.Rows.Count; i++)
            {
                despesas += Convert.ToDecimal(dtItens.Rows[i].Cells[9].Value);
            }
            lblValorDespesa.Text = despesas.ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal descontos = 0;
            for (int i = 0; i < dtItens.Rows.Count; i++)
            {
                descontos += Convert.ToDecimal(dtItens.Rows[i].Cells[8].Value);
            }
            lblValorDesconto.Text = descontos.ToString("n2", new CultureInfo("pt-BR"));
            //
            lblRegistros.Text = "Registros: " + dtItens.Rows.Count;
        }

        private void btnAlterar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAlterar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtItens_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtItens.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtItens_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtItens_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtItens.DataSource == null)
            {
                btnExcluirItem.Enabled = false;
                btnAlterar.Enabled = false;
                dtItens.Enabled = false;
            }
            else
            {
                if (_Importado == true)
                {
                    btnExcluirItem.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnIncluir.Enabled = false;
                }
                else
                {
                    if (_Formulario == 4)
                    {
                        btnExcluirItem.Enabled = false;
                    }
                    else
                    {
                        btnExcluirItem.Enabled = true;
                    }

                    btnAlterar.Enabled = true;
                }
                dtItens.Enabled = true;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                pEnabled.Enabled = false;

                btnAlterar.Select();
                //
                DataGridViewRow SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                //
                int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                //
                using (FrmCadItemNFeNFCe Item = new FrmCadItemNFeNFCe(_Formulario, SelectedRow.Cells[0].Value.ToString(), _Cod_Dfe, true, SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString() + "—" + SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[17].Value.ToString(), SelectedRow.Cells[18].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString(), SelectedRow.Cells[15].Value.ToString(), SelectedRow.Cells[16].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[12].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[13].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[14].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), SelectedRow.Cells[23].Value.ToString(), SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), SelectedRow.Cells[24].Value.ToString(), cbbFinalidade.Text, cbbTipo.Text, _Usuario, _Cod_PDV_Computador, SelectedRow.Cells[26].Value.ToString(), SelectedRow.Cells[27].Value.ToString(), SelectedRow.Cells[28].Value.ToString(), SelectedRow.Cells[29].Value.ToString()))
                {
                    if (Item.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.None;
                        if (_Formulario == 0 || _Formulario == 4)
                        {
                            dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                            //
                            DataRow dr;
                            decimal icms = 0;
                            decimal icmsst = 0;
                            decimal base_calculo_icms = 0;
                            decimal base_calculo_icms_st = 0;
                            decimal total_aprox_trib = 0;
                            //
                            for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                            {
                                dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                //
                                icms += Convert.ToDecimal(dr["valor_icms"]);
                                icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                            }
                            //
                            bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                            //
                            foreach (DataGridViewRow row in dtItens.Rows)
                            {
                                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                                {
                                    row.Selected = true;
                                    dtItens.CurrentCell = row.Cells[0];
                                    break;
                                }
                            }
                        }
                        else if (_Formulario == 1)
                        {
                            if (cbbFinalidade.Text == "SAIDA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "RETORNO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "ENTRADA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "DEVOLUCAO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "COMPLEMENTAR")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            //
                            if (_Cod_Dfe == null)
                            {
                                dtItens.DataSource = bllDFe.Sel_Items_DFe_Temp(bllConexao._Codigo_Conexao);
                            }
                            else
                            {
                                dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                                //
                                string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                //
                                DataRow dr = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                                //
                                bool venda;
                                if (dr["origem_venda"].ToString() == "1")
                                {
                                    venda = true;
                                }
                                else
                                {
                                    venda = false;
                                }
                                //
                                bllDFe.Alterar(_Cod_Dfe, dr["chave_dfe"].ToString(), "PRÓPRIA", cbbTipo.Text, dr["numero_nf"].ToString(), serie, dr["data_emissao"].ToString().Remove(10), dr["hora_emissao"].ToString(), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text.Trim(), lblValorDesconto.Text.Trim(), lblValorFrete.Text.Trim(), lblValorDespesa.Text.Trim(), lblValorTotal.Text.Trim(), cbbNaturezaOperacaoCFOP.Text, cbbTipoDestinatario.Text, "0", "0", cbbFinalidade.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, venda);
                                //
                                decimal icms = 0;
                                decimal icmsst = 0;
                                decimal base_calculo_icms = 0;
                                decimal base_calculo_icms_st = 0;
                                decimal total_aprox_trib = 0;
                                //
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                                {
                                    dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                    //
                                    icms += Convert.ToDecimal(dr["valor_icms"]);
                                    icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                    base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                    base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                    total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                                }
                                //
                                bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                            }
                            //
                            foreach (DataGridViewRow row in dtItens.Rows)
                            {
                                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                                {
                                    row.Selected = true;
                                    dtItens.CurrentCell = row.Cells[0];
                                    break;
                                }
                            }
                            //
                            SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                            //
                            if (cbbFinalidade.Text == "SAIDA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "RETORNO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "ENTRADA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "DEVOLUCAO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "COMPLEMENTAR")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                        }
                        else if (_Formulario == 3)
                        {
                            if (cbbFinalidade.Text == "SAIDA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "RETORNO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "ENTRADA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "DEVOLUCAO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "COMPLEMENTAR")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            //
                            dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                            //
                            string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                            //
                            DataRow dr = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                            //
                            bool venda;
                            if (dr["origem_venda"].ToString() == "1")
                            {
                                venda = true;
                            }
                            else
                            {
                                venda = false;
                            }
                            //
                            bllDFe.Alterar(_Cod_Dfe, dr["chave_dfe"].ToString(), "PRÓPRIA", cbbTipo.Text, dr["numero_nf"].ToString(), serie, dr["data_emissao"].ToString().Remove(10), dr["hora_emissao"].ToString(), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text.Trim(), lblValorDesconto.Text.Trim(), lblValorFrete.Text.Trim(), lblValorDespesa.Text.Trim(), lblValorTotal.Text.Trim(), cbbNaturezaOperacaoCFOP.Text, cbbTipoDestinatario.Text, "0", "0", cbbFinalidade.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, venda);
                            //
                            decimal icms = 0;
                            decimal icmsst = 0;
                            decimal base_calculo_icms = 0;
                            decimal base_calculo_icms_st = 0;
                            decimal total_aprox_trib = 0;
                            //
                            for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                            {
                                dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                //
                                icms += Convert.ToDecimal(dr["valor_icms"]);
                                icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                            }
                            //
                            bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                            //
                            foreach (DataGridViewRow row in dtItens.Rows)
                            {
                                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                                {
                                    row.Selected = true;
                                    dtItens.CurrentCell = row.Cells[0];
                                    break;
                                }
                            }
                            //
                            SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                            //
                            if (cbbFinalidade.Text == "SAIDA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "RETORNO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "ENTRADA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "DEVOLUCAO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "COMPLEMENTAR")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                        }
                    }
                }
                //
                dtItens.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAlterar.");
                }
                dtItens.DataSource = null;
                btnIncluir.Select();
            }
            pEnabled.Enabled = true;
        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtItens.Rows[dtItens.CurrentRow.Index];
                //
                if (bllDFe.Sel_Item_Dfe_Ainda_Existe(SelectedRow.Cells[19].Value.ToString()) == false & _Formulario == 0)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Item?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        if (_Formulario == 0 || _Formulario == 4)
                        {
                            bllDFe.Excluir_Item(SelectedRow.Cells[19].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUIU UM ITEM DFE", "DFE", SelectedRow.Cells[17].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item excluído. Cod: " + SelectedRow.Cells[17].Value.ToString());
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item excluído. Cod: " + SelectedRow.Cells[17].Value.ToString());
                            }
                            //
                            bllDFe.Atualizar_Item_Dt_Item(dtItens.CurrentRow.Index + 1, dtItens.Rows.Count);
                            //
                            bllDFe.Atualizar_Saldo_Produto_Exclusao_Dfe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString());
                            //
                            DataRow dr;
                            decimal icms = 0;
                            decimal icmsst = 0;
                            decimal base_calculo_icms = 0;
                            decimal base_calculo_icms_st = 0;
                            decimal total_aprox_trib = 0;
                            //
                            if (bllDFe.Sel_Items_DFe(_Cod_Dfe) != null)
                            {
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                                {
                                    dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                    //
                                    icms += Convert.ToDecimal(dr["valor_icms"]);
                                    icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                    base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                    base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                    total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                                }
                            }
                            else
                            {
                                icms += 0;
                                icmsst = 0;
                                base_calculo_icms = 0;
                                base_calculo_icms_st = 0;
                                total_aprox_trib = 0;
                            }
                            //
                            bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                            //
                            dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                            //
                            if (dtItens.Rows.Count >= 1)
                            {
                                dtItens.Rows[dtItens.Rows.Count - 1].Selected = true;

                                dtItens.FirstDisplayedScrollingRowIndex = dtItens.Rows.Count - 1;

                                dtItens.Select();
                            }
                            else
                            {
                                dtItens.DataSource = null;
                                btnIncluir.Select();
                            }
                        }
                        else if (_Formulario == 1)
                        {
                            if (cbbFinalidade.Text == "SAIDA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "RETORNO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "ENTRADA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "DEVOLUCAO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "COMPLEMENTAR")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            //
                            if (_Cod_Dfe == null)
                            {
                                bllDFe.Excluir_Item_DFe_Temp(SelectedRow.Cells[0].Value.ToString(), bllConexao._Codigo_Conexao);
                                //
                                bllDFe.Atualizar_Item_Dt_Item_Temp(dtItens.CurrentRow.Index + 1, dtItens.Rows.Count, bllConexao._Codigo_Conexao);
                                //
                                dtItens.DataSource = bllDFe.Sel_Items_DFe_Temp(bllConexao._Codigo_Conexao);
                            }
                            else
                            {
                                bllDFe.Excluir_Item(SelectedRow.Cells[19].Value.ToString());
                                //
                                bllRegistroAtividades.Salvar("EXCLUIU UM ITEM DFE", "DFE", SelectedRow.Cells[17].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                //
                                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item excluído. Cod: " + SelectedRow.Cells[17].Value.ToString());
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item excluído. Cod: " + SelectedRow.Cells[17].Value.ToString());
                                }
                                //
                                bllDFe.Atualizar_Item_Dt_Item(dtItens.CurrentRow.Index + 1, dtItens.Rows.Count);
                                //
                                string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                //
                                DataRow dr = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                                //
                                bool venda;
                                if (dr["origem_venda"].ToString() == "1")
                                {
                                    venda = true;
                                }
                                else
                                {
                                    venda = false;
                                }
                                //
                                bllDFe.Alterar(_Cod_Dfe, dr["chave_dfe"].ToString(), "PRÓPRIA", cbbTipo.Text, dr["numero_nf"].ToString(), serie, dr["data_emissao"].ToString().Remove(10), dr["hora_emissao"].ToString(), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text.Trim(), lblValorDesconto.Text.Trim(), lblValorFrete.Text.Trim(), lblValorDespesa.Text.Trim(), lblValorTotal.Text.Trim(), cbbNaturezaOperacaoCFOP.Text, cbbTipoDestinatario.Text, "0", "0", cbbFinalidade.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, venda);
                                //
                                decimal icms = 0;
                                decimal icmsst = 0;
                                decimal base_calculo_icms = 0;
                                decimal base_calculo_icms_st = 0;
                                decimal total_aprox_trib = 0;
                                //
                                if (bllDFe.Sel_Items_DFe(_Cod_Dfe) != null)
                                {
                                    for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                                    {
                                        dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                        //
                                        icms += Convert.ToDecimal(dr["valor_icms"]);
                                        icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                        base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                        base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                        total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                                    }
                                }
                                else
                                {
                                    icms += 0;
                                    icmsst = 0;
                                    base_calculo_icms = 0;
                                    base_calculo_icms_st = 0;
                                    total_aprox_trib = 0;
                                }
                                //
                                bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                                //
                                dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                            }
                            //
                            if (dtItens.Rows.Count >= 1)
                            {
                                dtItens.Rows[dtItens.Rows.Count - 1].Selected = true;

                                dtItens.FirstDisplayedScrollingRowIndex = dtItens.Rows.Count - 1;

                                dtItens.Select();
                            }
                            else
                            {
                                dtItens.DataSource = null;
                                btnIncluir.Select();
                            }
                        }
                        else if (_Formulario == 3)
                        {
                            if (cbbFinalidade.Text == "SAIDA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "RETORNO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "ENTRADA")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                            }
                            else if (cbbFinalidade.Text == "DEVOLUCAO")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            else if (cbbFinalidade.Text == "COMPLEMENTAR")
                            {
                                bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                            }
                            //
                            bllDFe.Excluir_Item(SelectedRow.Cells[19].Value.ToString());
                            //
                            bllRegistroAtividades.Salvar("EXCLUIU UM ITEM DFE", "DFE", SelectedRow.Cells[17].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item excluído. Cod: " + SelectedRow.Cells[17].Value.ToString());
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item excluído. Cod: " + SelectedRow.Cells[17].Value.ToString());
                            }
                            //
                            bllDFe.Atualizar_Item_Dt_Item(dtItens.CurrentRow.Index + 1, dtItens.Rows.Count);
                            //
                            string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                            //
                            DataRow dr = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                            //
                            bool venda;
                            if (dr["origem_venda"].ToString() == "1")
                            {
                                venda = true;
                            }
                            else
                            {
                                venda = false;
                            }
                            //
                            bllDFe.Alterar(_Cod_Dfe, dr["chave_dfe"].ToString(), "PRÓPRIA", cbbTipo.Text, dr["numero_nf"].ToString(), serie, dr["data_emissao"].ToString().Remove(10), dr["hora_emissao"].ToString(), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text.Trim(), lblValorDesconto.Text.Trim(), lblValorFrete.Text.Trim(), lblValorDespesa.Text.Trim(), lblValorTotal.Text.Trim(), cbbNaturezaOperacaoCFOP.Text, cbbTipoDestinatario.Text, "0", "0", cbbFinalidade.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, venda);
                            //
                            decimal icms = 0;
                            decimal icmsst = 0;
                            decimal base_calculo_icms = 0;
                            decimal base_calculo_icms_st = 0;
                            decimal total_aprox_trib = 0;
                            //
                            if (bllDFe.Sel_Items_DFe(_Cod_Dfe) != null)
                            {
                                for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                                {
                                    dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                    //
                                    icms += Convert.ToDecimal(dr["valor_icms"]);
                                    icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                    base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                    base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                    total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                                }
                            }
                            else
                            {
                                icms += 0;
                                icmsst = 0;
                                base_calculo_icms = 0;
                                base_calculo_icms_st = 0;
                                total_aprox_trib = 0;
                            }
                            //
                            bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                            //
                            dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                            //
                            if (dtItens.Rows.Count >= 1)
                            {
                                dtItens.Rows[dtItens.Rows.Count - 1].Selected = true;

                                dtItens.FirstDisplayedScrollingRowIndex = dtItens.Rows.Count - 1;

                                dtItens.Select();
                            }
                            else
                            {
                                dtItens.DataSource = null;
                                btnIncluir.Select();
                            }
                        }
                        //
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        dtItens.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
                dtItens.DataSource = null;
                btnIncluir.Select();
            }
        }

        private void lblDiferenca_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblDiferenca_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblDiferenca_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Total (R$): " + _Total_Produtos + Environment.NewLine + Environment.NewLine + "Valor Total restante (R$): " + lblDiferenca.Text.Replace("Diferença (R$): ", ""), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblDiferenca_TextChanged(object sender, EventArgs e)
        {
            if (lblDiferenca.Text == "Diferença (R$): 0,00")
            {
                lblDiferenca.ForeColor = Color.Blue;
            }
            else
            {
                lblDiferenca.ForeColor = Color.Red;
            }
        }

        private void dtItens_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Importado == false)
            {
                if (_Formulario != 2 & _Formulario != 4)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        btnExcluirItem_Click(sender, e);
                    }
                }
            }
        }

        private void dtItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void cbbTipoEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoEmitente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTipoEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTipoEmitente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Formulario != 2 & _Formulario != 4)
                {
                    cbbDestinatario.Items.Clear();
                    if (cbbTipoDestinatario.SelectedIndex == 0)
                    {
                        if (bllDFe.Sel_Cliente_DFe() == null)
                        {
                            cbbDestinatario.Text = null;
                        }
                        else
                        {
                            btnpProcurarDestinatario.Enabled = true;
                            cbbDestinatario.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Cliente_DFe().Rows)
                            {
                                string cpfcnpj;
                                if (dr["cpf_cnpj"].ToString() == "")
                                {
                                    cpfcnpj = "";
                                }
                                else
                                {
                                    cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                }
                                cbbDestinatario.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                            }
                        }
                    }
                    else if (cbbTipoDestinatario.SelectedIndex == 1)
                    {
                        if (bllDFe.Sel_Fornecedor_DFe() == null)
                        {
                            cbbDestinatario.Text = null;
                            btnpProcurarDestinatario.Enabled = false;
                        }
                        else
                        {
                            btnpProcurarDestinatario.Enabled = true;
                            cbbDestinatario.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                            {
                                string cpfcnpj;
                                if (dr["cpf_cnpj"].ToString() == "")
                                {
                                    cpfcnpj = "";
                                }
                                else
                                {
                                    cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                }
                                cbbDestinatario.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbDestinatario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbDestinatario.");
                }
                cbbDestinatario.Items.Clear();
                cbbDestinatario.Text = null;
                cbbTipoDestinatario.Text = null;
            }
        }

        private void btnpProcurarDestinatario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbTipoDestinatario.SelectedIndex == 0)
                {
                    using (FrmPesqCliente Clie = new FrmPesqCliente(9, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Clie.ShowDialog() == DialogResult.OK)
                        {
                            cbbDestinatario.Items.Clear();
                            if (bllDFe.Sel_Cliente_DFe() == null)
                            {
                                cbbDestinatario.Text = null;
                            }
                            else
                            {
                                cbbDestinatario.Items.Add("");
                                foreach (DataRow dr in bllDFe.Sel_Cliente_DFe().Rows)
                                {
                                    string cpfcnpj;
                                    if (dr["cpf_cnpj"].ToString() == "")
                                    {
                                        cpfcnpj = "";
                                    }
                                    else
                                    {
                                        cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                    }
                                    cbbDestinatario.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                                }
                            }
                            cbbDestinatario.Text = bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela;
                            bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = null;
                            cbbDestinatario.Select();
                        }
                    }
                }
                else if (cbbTipoDestinatario.SelectedIndex == 1)
                {
                    using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(6, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Forn.ShowDialog() == DialogResult.OK)
                        {
                            cbbDestinatario.Items.Clear();
                            if (bllDFe.Sel_Fornecedor_DFe() == null)
                            {
                                cbbDestinatario.Text = null;
                            }
                            else
                            {
                                cbbDestinatario.Items.Add("");
                                foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                                {
                                    string cpfcnpj;
                                    if (dr["cpf_cnpj"].ToString() == "")
                                    {
                                        cpfcnpj = "";
                                    }
                                    else
                                    {
                                        cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                    }
                                    cbbDestinatario.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                                }
                            }
                            cbbDestinatario.Text = bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela;
                            bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = null;
                            cbbDestinatario.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbDestinatario.Text = null;
                bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
            }
            pEnabled.Enabled = true;
        }

        private void mtxtDataSaida_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataSaida.Text == "")
            {
                mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataSaida.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataSaida_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataSaida.Text == "")
                {
                    mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataSaida.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataSaida_Leave(object sender, EventArgs e)
        {
            mtxtDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataSaida.Text != "")
            {
                try
                {
                    mtxtDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataSaida.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataSaida.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataSaida.");
                    }
                    mtxtDataSaida.Text = null;
                }
            }
            mtxtDataSaida.BackColor = Color.White;
        }

        private void mtxtDataSaida_Enter(object sender, EventArgs e)
        {
            mtxtDataSaida.BackColor = Color.LightBlue;
        }

        private void mtxtHorario1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario1.Text == "")
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorario1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorario1.Text == "")
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario1_Leave(object sender, EventArgs e)
        {
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario1.Text != "")
            {
                if (mtxtHorario1.Text.Length == 4)
                {
                    mtxtHorario1.Text = mtxtHorario1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorario1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario1.");
                    }
                    mtxtHorario1.Text = null;
                }
            }
            mtxtHorario1.BackColor = Color.White;
        }

        private void mtxtHorario1_Enter(object sender, EventArgs e)
        {
            mtxtHorario1.BackColor = Color.LightBlue;
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataSaida.Select();
            }
        }

        private void mtxtDataSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
            }
        }

        private void cbbTipoEmitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbDestinatario.Select();
            }
        }

        private void rtxtObs_Leave(object sender, EventArgs e)
        {
            if (rtxtObs.Text.Contains(";") || rtxtObs.Text.Contains("'") || rtxtObs.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                rtxtObs.Text = null;
                rtxtObs.Select();
            }
            rtxtObs.BackColor = Color.White;
        }

        private void rtxtObs_Enter(object sender, EventArgs e)
        {
            rtxtObs.BackColor = Color.LightBlue;
        }

        private void rtxtObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnIncluir.Select();
            }
        }

        private void btnSelecionarData2_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(3))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataSaida.Text = bllDFe._Data_DatePicker1;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSelecionarData2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCadastrarTransportadora_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadastrarTransportadora_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarNatOPCFOP_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqCFOP Cfop = new FrmPesqCFOP(1, cbbFinalidade.Text, _Usuario, _Cod_PDV_Computador))
            {
                if (Cfop.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbNaturezaOperacaoCFOP.Items.Clear();
                        if (bllDFe.Sel_Cfop_Dfe(cbbFinalidade.Text) == null)
                        {
                            cbbNaturezaOperacaoCFOP.Text = null;
                        }
                        else
                        {
                            if (_Formulario != 4)
                            {
                                cbbNaturezaOperacaoCFOP.Items.Add("");
                            }
                            //
                            foreach (DataRow dr in bllDFe.Sel_Cfop_Dfe(cbbFinalidade.Text).Rows)
                            {
                                cbbNaturezaOperacaoCFOP.Items.Add((dr["cod_cfop"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbNaturezaOperacaoCFOP.Text = bllDFe._FornDFe_Cfop_PesqCfop_Tabela;
                        bllDFe._FornDFe_Cfop_PesqCfop_Tabela = null;
                        cbbNaturezaOperacaoCFOP.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarNatOPCFOP.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarNatOPCFOP.");
                        }
                        cbbNaturezaOperacaoCFOP.Text = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                btnSalvar.Select();
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    if (cbbNaturezaOperacaoCFOP.Text == "" || cbbDestinatario.Text == "" || dtItens.DataSource == null)
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Natureza da Operação/CFOP Predominante ],\n[ Destinatário ] e [ Itens ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        cbbTipo.Select();
                    }
                    else
                    {
                        if (_Cod_Dfe == null)
                        {
                            string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                            //
                            bool venda;
                            if (cbbFinalidade.Text == "SAIDA")
                            {
                                DialogResult = MessageBox.Show("O DFe atual é uma Saída de uma Venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    this.DialogResult = DialogResult.None;
                                    //
                                    venda = true;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                    //
                                    venda = false;
                                }
                            }
                            else
                            {
                                venda = false;
                            }
                            //
                            bllDFe.Salvar(null, "PRÓPRIA", cbbTipo.Text, null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text.Trim(), lblValorDesconto.Text.Trim(), lblValorFrete.Text.Trim(), lblValorDespesa.Text.Trim(), lblValorTotal.Text.Trim(), cbbNaturezaOperacaoCFOP.Text, false, _Cod_PDV_Computador, cbbTipoDestinatario.Text, "0", "0", true, cbbFinalidade.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, "PENDENTE", null, null, null, venda);
                            //
                            string _Ult_Codigo = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                            //
                            DataRow dr;
                            //
                            for (int i = 0; i < dtItens.Rows.Count; i++)
                            {
                                DataGridViewRow SelectedRow = dtItens.Rows[i];
                                //
                                int item = Convert.ToInt32(SelectedRow.Cells[0].Value) - 1;
                                bllDFe.Salvar_Items(item.ToString(), SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[17].Value.ToString(), SelectedRow.Cells[18].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString(), SelectedRow.Cells[15].Value.ToString(), SelectedRow.Cells[16].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[14].Value.ToString(), SelectedRow.Cells[12].Value.ToString(), SelectedRow.Cells[13].Value.ToString(), _Ult_Codigo, SelectedRow.Cells[24].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), SelectedRow.Cells[23].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), "0", SelectedRow.Cells[26].Value.ToString(), SelectedRow.Cells[27].Value.ToString(), SelectedRow.Cells[28].Value.ToString(), SelectedRow.Cells[29].Value.ToString(), SelectedRow.Cells[30].Value.ToString(), SelectedRow.Cells[31].Value.ToString(), SelectedRow.Cells[32].Value.ToString(), SelectedRow.Cells[33].Value.ToString(), SelectedRow.Cells[34].Value.ToString());
                            }
                            //
                            if (bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao) != null)
                            {
                                for (int i = 0; i < bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao).Rows.Count; i++)
                                {
                                    dr = bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao).Rows[i];
                                    //
                                    bllDFe.Salvar_Pagamento_DFe(dr["id_item_pagamento"].ToString(), dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString(), dr["valor_pago"].ToString(), _Ult_Codigo);
                                }
                            }
                            //
                            if (bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao) != null)
                            {
                                for (int i = 0; i < bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao).Rows.Count; i++)
                                {
                                    dr = bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao).Rows[i];
                                    //
                                    bllDFe.Salvar_Referencia_DFe(dr["id_referencia"].ToString(), dr["chave_dfe"].ToString(), _Ult_Codigo);
                                }
                            }
                            //
                            decimal icms = 0;
                            decimal icmsst = 0;
                            decimal base_calculo_icms = 0;
                            decimal base_calculo_icms_st = 0;
                            decimal total_aprox_trib = 0;
                            //
                            for (int i = 0; i < bllDFe.Sel_Items_DFe(_Ult_Codigo).Rows.Count; i++)
                            {
                                dr = bllDFe.Sel_Items_DFe(_Ult_Codigo).Rows[i];
                                //
                                icms += Convert.ToDecimal(dr["valor_icms"]);
                                icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                            }
                            //
                            bllDFe.Salvar_icms_icms_st_base_total_trib(_Ult_Codigo, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                            //
                            _Importado = false;
                            //
                            bllDFe.CriarDFeNFe(_Ult_Codigo, _Cod_PDV_Computador);
                            //
                            bllRegistroAtividades.Salvar("SALVOU UM DFE", "DFE", _Ult_Codigo, _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe cadastrado. Cod: " + _Ult_Codigo);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe cadastrado. Cod: " + _Ult_Codigo);
                            }
                            //
                            Limpar();
                            //
                            cbbTipo.Select();
                            //
                            bllDFe._Consumidor_Final = false;
                            //
                            bllDFe._Tipo_Operacao = null;
                            //
                            bllDFe.Excluir_DFe_Temp(bllConexao._Codigo_Conexao);
                            //
                            bllDFe.Excluir_Todos_Item_DFe_Temp(bllConexao._Codigo_Conexao);
                            //
                            bllDFe.Excluir_Todos_Referencia_Temp(bllConexao._Codigo_Conexao);
                            //
                            bllDFe.Excluir_Todos_Transportador_Temp(bllConexao._Codigo_Conexao);
                            //
                            bllDFe.Excluir_Item_DFe_Pgto_Atual(bllConexao._Codigo_Conexao);
                            //
                            _Cod_Dfe = null;
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso." + Environment.NewLine + Environment.NewLine + "Código do DFe salvo: [ " + _Ult_Codigo + " ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                            //
                            DataRow dr;
                            //
                            dr = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                            //
                            bool venda;
                            if (cbbFinalidade.Text == "SAIDA")
                            {
                                DialogResult = MessageBox.Show("O DFe atual é uma Saída de uma Venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    this.DialogResult = DialogResult.None;
                                    //
                                    venda = true;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                    //
                                    venda = false;
                                }
                            }
                            else
                            {
                                venda = false;
                            }
                            //
                            bllDFe.Alterar(_Cod_Dfe, dr["chave_dfe"].ToString(), "PRÓPRIA", cbbTipo.Text, dr["numero_nf"].ToString(), serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text.Trim(), lblValorDesconto.Text.Trim(), lblValorFrete.Text.Trim(), lblValorDespesa.Text.Trim(), lblValorTotal.Text.Trim(), cbbNaturezaOperacaoCFOP.Text, cbbTipoDestinatario.Text, "0", "0", cbbFinalidade.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, venda);
                            //
                            decimal icms = 0;
                            decimal icmsst = 0;
                            decimal base_calculo_icms = 0;
                            decimal base_calculo_icms_st = 0;
                            decimal total_aprox_trib = 0;
                            //
                            for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                            {
                                dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                //
                                icms += Convert.ToDecimal(dr["valor_icms"]);
                                icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                total_aprox_trib += Convert.ToDecimal(dr["total_aprox_trib"]);
                            }
                            //
                            bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                            //
                            _Importado = false;
                            //
                            bllDFe.CriarDFeNFe(_Cod_Dfe, _Cod_PDV_Computador);
                            //
                            bllRegistroAtividades.Salvar("SALVOU UM DFE", "DFE", _Cod_Dfe, _Usuario, _Cod_PDV_Computador);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe cadastrado. Cod: " + _Cod_Dfe);
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe cadastrado. Cod: " + _Cod_Dfe);
                            }
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso." + Environment.NewLine + Environment.NewLine + "Código do DFe salvo: [ " + _Cod_Dfe + " ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.None;
                            //
                            Limpar();
                            //
                            bllDFe._Consumidor_Final = false;
                            bllDFe._Tipo_Operacao = null;
                            //
                            _Cod_Dfe = null;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    cbbTipo.Select();
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
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                _Importado = false;
                dtItens.DataSource = null;
                Limpar();
                bllDFe._Consumidor_Final = false;
                bllDFe._Tipo_Operacao = null;
            }
        }

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbNaturezaOperacaoCFOP.Select();
            }
        }

        private void cbbDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                rtxtObs.Select();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja apagar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.None;
                //
                if (dtItens.DataSource != null)
                {
                    for (int i = 0; i < dtItens.Rows.Count; i++)
                    {
                        DataGridViewRow SelectedRow = dtItens.Rows[i];
                        //
                        if (cbbFinalidade.Text == "SAIDA")
                        {
                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                        }
                        else if (cbbFinalidade.Text == "RETORNO")
                        {
                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                        }
                        else if (cbbFinalidade.Text == "ENTRADA")
                        {
                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                        }
                        else if (cbbFinalidade.Text == "DEVOLUCAO")
                        {
                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                        }
                        else if (cbbFinalidade.Text == "COMPLEMENTAR")
                        {
                            bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                        }
                    }
                }
                //
                bllDFe.Excluir_DFe_Temp(bllConexao._Codigo_Conexao);
                //
                bllDFe.Excluir_Todos_Item_DFe_Temp(bllConexao._Codigo_Conexao);
                //
                bllDFe.Excluir_Todos_Transportador_Temp(bllConexao._Codigo_Conexao);
                //
                bllDFe.Excluir_Todos_Referencia_Temp(bllConexao._Codigo_Conexao);
                //
                bllDFe.Excluir_Item_DFe_Pgto_Atual(bllConexao._Codigo_Conexao);
                //
                _Cod_Dfe = null;
                //
                Limpar();
                //
                cbbTipo.Select();
                //
                MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                using (FrmCapturar Capturar = new FrmCapturar(_Usuario, _Cod_PDV_Computador, 0))
                {
                    if (Capturar.ShowDialog() == DialogResult.OK)
                    {
                        if (bllDFe._Tipo_Captura == 0)
                        {
                            if (bllOrcamento.Sel_Itens_Orcamento_Orc(bllDFe._Cod_Orcamento) == null)
                            {
                                MessageBox.Show("O Orçamento informado não possui itens.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pEnabled.Enabled = true;
                                return;
                            }
                            //
                            string cfop = null;
                            if (cbbNaturezaOperacaoCFOP.Text == "")
                            {
                                DialogResult = MessageBox.Show("Ainda não foi incluída a Natureza da Operação/CFOP Predominante, e sua inclusão é obrigatória para importar o Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                //
                                using (FrmPesqCFOP Cfop = new FrmPesqCFOP(1, cbbFinalidade.Text, _Usuario, _Cod_PDV_Computador))
                                {
                                    if (Cfop.ShowDialog() == DialogResult.OK)
                                    {
                                        cbbNaturezaOperacaoCFOP.Items.Clear();
                                        if (bllDFe.Sel_Cfop_Dfe(cbbFinalidade.Text) == null)
                                        {
                                            cbbNaturezaOperacaoCFOP.Text = null;
                                        }
                                        else
                                        {
                                            cbbNaturezaOperacaoCFOP.Items.Add("");
                                            foreach (DataRow dr in bllDFe.Sel_Cfop_Dfe(cbbFinalidade.Text).Rows)
                                            {
                                                cbbNaturezaOperacaoCFOP.Items.Add((dr["cod_cfop"].ToString()) + "—" + (dr["descricao"].ToString()));
                                            }
                                        }
                                        cbbNaturezaOperacaoCFOP.Text = bllDFe._FornDFe_Cfop_PesqCfop_Tabela;
                                        string[] items = bllDFe._FornDFe_Cfop_PesqCfop_Tabela.Split('—');
                                        cfop = items[0];
                                        bllDFe._FornDFe_Cfop_PesqCfop_Tabela = null;
                                        cbbNaturezaOperacaoCFOP.Select();
                                    }
                                    else
                                    {
                                        MessageBox.Show("É necessário informar a Natureza da Operação/CFOP para continuar com a importação do Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                        pEnabled.Enabled = true;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                string[] items = cbbNaturezaOperacaoCFOP.Text.Split('—');
                                cfop = items[0];
                            }
                            //
                            DataRow drClie = bllOrcamento.Sel_Orcamento_Codigo(bllDFe._Cod_Orcamento).Rows[0];
                            //
                            if (cbbDestinatario.Text != "")
                            {
                                DialogResult = MessageBox.Show("Deseja alterar o Destinatário já informado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    if (Convert.ToInt32(drClie["id_consumidor"].ToString()) == 0)
                                    {
                                        MessageBox.Show("Cliente/Consumidor não informado no Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        if (bllClieCons.Sel_Cliente_Ainda_Existe(drClie["id_consumidor"].ToString()) == false)
                                        {
                                            MessageBox.Show("Cliente/Consumidor não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            cbbTipoDestinatario.SelectedIndex = 0;
                                            //
                                            drClie = bllClieCons.Sel_Cliente_Codigo(drClie["id_consumidor"].ToString()).Rows[0];
                                            //
                                            cbbDestinatario.Text = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(drClie["id_consumidor"].ToString()) == 0)
                                {
                                    MessageBox.Show("Cliente/Consumidor não informado no Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    if (bllClieCons.Sel_Cliente_Ainda_Existe(drClie["id_consumidor"].ToString()) == false)
                                    {
                                        MessageBox.Show("Cliente/Consumidor não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        cbbTipoDestinatario.SelectedIndex = 0;
                                        //
                                        drClie = bllClieCons.Sel_Cliente_Codigo(drClie["id_consumidor"].ToString()).Rows[0];
                                        //
                                        cbbDestinatario.Text = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString();
                                    }
                                }
                            }
                            //
                            for (int a = 0; a < bllOrcamento.Sel_Itens_Orcamento_Orc(bllDFe._Cod_Orcamento).Rows.Count; a++)
                            {
                                DataRow drOrc = bllOrcamento.Sel_Itens_Orcamento_Orc(bllDFe._Cod_Orcamento).Rows[a];
                                //
                                if (bllProduto.Sel_Prod_Codigo(drOrc["id_produto"].ToString(), "") == null)
                                {
                                    MessageBox.Show("Código de produto não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    DataRow drProd = bllProduto.Sel_Prod_Codigo(drOrc["id_produto"].ToString(), "").Rows[0];
                                    //
                                    if (drProd["ncm"].ToString() == "")
                                    {
                                        MessageBox.Show("O Produto [ " + drProd["id_produto"].ToString() + " ] não foi adicionado pois não possui NCM.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else if (bllIBPT.Sel_IBPT_NCM(drProd["ncm"].ToString(), drProd["excecao_ncm"].ToString()) == null)
                                    {
                                        MessageBox.Show("O NCM do Produto [ " + drProd["id_produto"].ToString() + " ] não foi encontrado na tabela IBPT.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        bllDFe.Salvar_Items_Temp(dtItens.Rows.Count.ToString(), drProd["id_produto"].ToString() + "—" + drProd["descricao"].ToString(), drProd["ncm"].ToString(), drProd["cest"].ToString(), drProd["cst"].ToString(), drProd["aliq_icms"].ToString(), drProd["csosn"].ToString(), cfop, drOrc["quantidade"].ToString(), "1", drOrc["valor_total"].ToString(), drOrc["valor_unitario"].ToString(), drOrc["valor_desconto"].ToString(), drOrc["valor_acrescimo"].ToString(), drOrc["valor_total_a_desc_acresc"].ToString(), bllDFe.Calculo_Valor_ICMS(bllDFe.Calculo_Valor_Base_Calculo_ICMS(drOrc["valor_unitario"].ToString(), drOrc["quantidade"].ToString(), drOrc["valor_desconto"].ToString(), drOrc["valor_acrescimo"].ToString()), drProd["aliq_icms"].ToString()), drOrc["valor_total"].ToString(), bllConexao._Codigo_Conexao, "0,00", "0,00", "0,00", "0,00", "0,00", drOrc["um"].ToString(), bllDFe.Calculo_Valor_Aprox_Trib(drOrc["valor_total_a_desc_acresc"].ToString(), drProd["id_produto"].ToString() + "—" + drProd["descricao"].ToString()), "0,00", "0,00", "0,00", drProd["cst_ibs_cbs"].ToString(), drProd["cclass_trib"].ToString(), drProd["aliq_ibs_mun"].ToString(), drProd["aliq_ibs_est"].ToString(), drProd["aliq_ibs_est"].ToString(), "0");
                                        //
                                        dtItens.DataSource = bllDFe.Sel_Items_DFe_Temp(bllConexao._Codigo_Conexao);
                                    }
                                }
                            }
                        }
                        else if (bllDFe._Tipo_Captura == 1)
                        {
                            if (bllVenda.Sel_Itens_Venda_Venda(bllDFe._Cod_Venda) == null)
                            {
                                MessageBox.Show("A Venda informada não possui itens.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pEnabled.Enabled = true;
                                return;
                            }
                            //
                            string cfop = null;
                            if (cbbNaturezaOperacaoCFOP.Text == "")
                            {
                                DialogResult = MessageBox.Show("Ainda não foi incluída a Natureza da Operação/CFOP Predominante, e sua inclusão é obrigatória para importar a Venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                this.DialogResult = DialogResult.None;
                                //
                                using (FrmPesqCFOP Cfop = new FrmPesqCFOP(1, cbbFinalidade.Text, _Usuario, _Cod_PDV_Computador))
                                {
                                    if (Cfop.ShowDialog() == DialogResult.OK)
                                    {

                                        cbbNaturezaOperacaoCFOP.Items.Clear();
                                        if (bllDFe.Sel_Cfop_Dfe(cbbFinalidade.Text) == null)
                                        {
                                            cbbNaturezaOperacaoCFOP.Text = null;
                                        }
                                        else
                                        {
                                            cbbNaturezaOperacaoCFOP.Items.Add("");
                                            foreach (DataRow dr in bllDFe.Sel_Cfop_Dfe(cbbFinalidade.Text).Rows)
                                            {
                                                cbbNaturezaOperacaoCFOP.Items.Add((dr["cod_cfop"].ToString()) + "—" + (dr["descricao"].ToString()));
                                            }
                                        }
                                        cbbNaturezaOperacaoCFOP.Text = bllDFe._FornDFe_Cfop_PesqCfop_Tabela;
                                        string[] items = bllDFe._FornDFe_Cfop_PesqCfop_Tabela.Split('—');
                                        cfop = items[0];
                                        bllDFe._FornDFe_Cfop_PesqCfop_Tabela = null;
                                        cbbNaturezaOperacaoCFOP.Select();
                                    }
                                    else
                                    {
                                        MessageBox.Show("É necessário informar a Natureza da Operação/CFOP para continuar com a importação da Venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                        pEnabled.Enabled = true;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                string[] items = cbbNaturezaOperacaoCFOP.Text.Split('—');
                                cfop = items[0];
                            }
                            //
                            DataRow drClie = bllVenda.Sel_Venda_Codigo(bllDFe._Cod_Venda).Rows[0];
                            //
                            if (cbbDestinatario.Text != "")
                            {
                                DialogResult = MessageBox.Show("Deseja alterar o Destinatário já informado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    if (Convert.ToInt32(drClie["id_consumidor"].ToString()) == 0)
                                    {
                                        MessageBox.Show("Cliente/Consumidor não informado no Orçamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        if (bllClieCons.Sel_Cliente_Ainda_Existe(drClie["id_consumidor"].ToString()) == false)
                                        {
                                            MessageBox.Show("Cliente/Consumidor não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            cbbTipoDestinatario.SelectedIndex = 0;
                                            //
                                            drClie = bllClieCons.Sel_Cliente_Codigo(drClie["id_consumidor"].ToString()).Rows[0];
                                            //
                                            cbbDestinatario.Text = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(drClie["id_consumidor"].ToString()) == 0)
                                {
                                    MessageBox.Show("Cliente/Consumidor não informado na Venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    if (bllClieCons.Sel_Cliente_Ainda_Existe(drClie["id_consumidor"].ToString()) == false)
                                    {
                                        MessageBox.Show("Cliente/Consumidor não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        cbbTipoDestinatario.SelectedIndex = 0;
                                        //
                                        drClie = bllClieCons.Sel_Cliente_Codigo(drClie["id_consumidor"].ToString()).Rows[0];
                                        //
                                        cbbDestinatario.Text = drClie["id_cliente"].ToString() + "—" + drClie["nome"].ToString();
                                    }
                                }
                            }
                            //
                            for (int a = 0; a < bllVenda.Sel_Itens_Venda_Venda(bllDFe._Cod_Venda).Rows.Count; a++)
                            {
                                DataRow drVenda = bllVenda.Sel_Itens_Venda_Venda(bllDFe._Cod_Venda).Rows[a];
                                //
                                DataRow drProd = bllProduto.Sel_Prod_Codigo(drVenda["id_produto"].ToString(), "").Rows[0];
                                //
                                if (bllProduto.Sel_Prod_Codigo(drVenda["id_produto"].ToString(), "") == null)
                                {
                                    MessageBox.Show("Código de produto não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else if (drProd["ncm"].ToString() == "")
                                {
                                    MessageBox.Show("O Produto [ " + drProd["id_produto"].ToString() + " ] não foi adicionado pois não possui NCM.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else if (bllIBPT.Sel_IBPT_NCM(drProd["ncm"].ToString(), drProd["excecao_ncm"].ToString()) == null)
                                {
                                    MessageBox.Show("O NCM do Produto [ " + drProd["id_produto"].ToString() + " ] não foi encontrado na tabela IBPT.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    string total = bllDFe.Calculo_Valor_Item(drProd["preco"].ToString(), drVenda["quantidade"].ToString());
                                    //
                                    string valor_desconto = bllDFe.Calculo_Desconto(total, drProd["desconto_porc"].ToString());
                                    //
                                    string valor_acrescimo = bllDFe.Calculo_Acrescimo(total, drProd["acrescimo_porc"].ToString());
                                    //
                                    string total_real = bllDFe.Calculo_Valor_Item_Desc_Acresc(total, valor_desconto, valor_acrescimo, "0", "0");
                                    //
                                    string base_calculo = bllDFe.Calculo_Valor_Base_Calculo_ICMS(drProd["preco"].ToString(), drVenda["quantidade"].ToString(), valor_desconto, valor_acrescimo);

                                    string valor_icms = bllDFe.Calculo_Valor_ICMS(base_calculo, drProd["aliq_icms"].ToString());
                                    //
                                    bllDFe.Salvar_Items_Temp(dtItens.Rows.Count.ToString(), drProd["id_produto"].ToString() + "—" + drProd["descricao"].ToString(), drProd["ncm"].ToString(), drProd["cest"].ToString(), drProd["cst"].ToString(), drProd["aliq_icms"].ToString(), drProd["csosn"].ToString(), cfop, drVenda["quantidade"].ToString(), "1", total, drProd["preco"].ToString(), valor_desconto, valor_acrescimo, total_real, valor_icms, base_calculo, bllConexao._Codigo_Conexao, "0,00", "0,00", "0,00", "0,00", "0,00", drProd["um"].ToString(), bllDFe.Calculo_Valor_Aprox_Trib(total_real, drProd["id_produto"].ToString() + "—" + drProd["descricao"].ToString()), "0,00", "0,00", "0,00", drProd["cst_ibs_cbs"].ToString(), drProd["cclass_trib"].ToString(), drProd["aliq_ibs_mun"].ToString(), drProd["aliq_ibs_est"].ToString(), drProd["aliq_ibs_est"].ToString(), "0");
                                    //
                                    dtItens.DataSource = bllDFe.Sel_Items_DFe_Temp(bllConexao._Codigo_Conexao);
                                }
                            }
                        }
                        else if (bllDFe._Tipo_Captura == 2)
                        {
                            if (bllDFe.Sel_Items_DFe(bllDFe._Cod_DFe) == null)
                            {
                                MessageBox.Show("O DFe informado não possui itens.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pEnabled.Enabled = true;
                                return;
                            }
                            //
                            DataRow drDfe = bllDFe.Sel_Nfe_Cod(bllDFe._Cod_DFe, "").Rows[0];
                            //
                            bool destinatario = false;
                            //
                            string cfop = null;
                            if (cbbNaturezaOperacaoCFOP.Text == "")
                            {
                                DialogResult = MessageBox.Show("Ainda não foi incluída a Natureza da Operação/CFOP, e sua inclusão é obrigatória para importar o DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                //
                                using (FrmPesqCFOP Cfop = new FrmPesqCFOP(1, cbbFinalidade.Text, _Usuario, _Cod_PDV_Computador))
                                {
                                    if (Cfop.ShowDialog() == DialogResult.OK)
                                    {
                                        cbbNaturezaOperacaoCFOP.Items.Clear();
                                        if (bllDFe.Sel_Cfop_Dfe(cbbFinalidade.Text) == null)
                                        {
                                            cbbNaturezaOperacaoCFOP.Text = null;
                                        }
                                        else
                                        {
                                            cbbNaturezaOperacaoCFOP.Items.Add("");
                                            foreach (DataRow dr in bllDFe.Sel_Cfop_Dfe(cbbFinalidade.Text).Rows)
                                            {
                                                cbbNaturezaOperacaoCFOP.Items.Add((dr["cod_cfop"].ToString()) + "—" + (dr["descricao"].ToString()));
                                            }
                                        }
                                        cbbNaturezaOperacaoCFOP.Text = bllDFe._FornDFe_Cfop_PesqCfop_Tabela;
                                        string[] items = bllDFe._FornDFe_Cfop_PesqCfop_Tabela.Split('—');
                                        cfop = items[0];
                                        bllDFe._FornDFe_Cfop_PesqCfop_Tabela = null;
                                        cbbNaturezaOperacaoCFOP.Select();
                                    }
                                    else
                                    {
                                        MessageBox.Show("É necessário informar a Natureza da Operação/CFOP para continuar com a importação do DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                        if (destinatario == true)
                                        {
                                            cbbDestinatario.Text = null;
                                        }
                                        pEnabled.Enabled = true;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                string[] items = cbbNaturezaOperacaoCFOP.Text.Split('—');
                                cfop = items[0];
                            }
                            //
                            if (cbbDestinatario.Text != "")
                            {
                                DialogResult = MessageBox.Show("Deseja alterar o Destinatário já informado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    destinatario = true;
                                    //
                                    if (Convert.ToInt32(drDfe["id_emitente_destinatario"].ToString()) == 0)
                                    {
                                        MessageBox.Show("Cliente/Consumidor não informado no DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        if (drDfe["tipo_emitente_destinatario"].ToString() == "FORNECEDORES")
                                        {
                                            if (bllFornecedor.Sel_Fornecedor_Ainda_Existe(drDfe["id_emitente_destinatario"].ToString()) == false)
                                            {
                                                MessageBox.Show("Fornecedor não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                this.DialogResult = DialogResult.None;
                                            }
                                            else
                                            {
                                                cbbTipoDestinatario.SelectedIndex = 1;
                                                //
                                                drDfe = bllFornecedor.Sel_F_Cod(drDfe["id_emitente_destinatario"].ToString()).Rows[0];
                                                //
                                                cbbDestinatario.Text = drDfe["id_fornecedor"].ToString() + "—" + drDfe["nome"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            if (bllClieCons.Sel_Cliente_Ainda_Existe(drDfe["id_emitente_destinatario"].ToString()) == false)
                                            {
                                                MessageBox.Show("Cliente/Consumidor não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                this.DialogResult = DialogResult.None;
                                            }
                                            else
                                            {
                                                cbbTipoDestinatario.SelectedIndex = 0;
                                                //
                                                drDfe = bllClieCons.Sel_Cliente_Codigo(drDfe["id_emitente_destinatario"].ToString()).Rows[0];
                                                //
                                                cbbDestinatario.Text = drDfe["id_cliente"].ToString() + "—" + drDfe["nome"].ToString();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.None;
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(drDfe["id_emitente_destinatario"].ToString()) == 0)
                                {
                                    MessageBox.Show("Cliente/Consumidor não informado na Venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    if (drDfe["tipo_emitente_destinatario"].ToString() == "FORNECEDORES")
                                    {
                                        if (bllFornecedor.Sel_Fornecedor_Ainda_Existe(drDfe["id_emitente_destinatario"].ToString()) == false)
                                        {
                                            MessageBox.Show("Fornecedor não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            cbbTipoDestinatario.SelectedIndex = 1;
                                            //
                                            drDfe = bllFornecedor.Sel_F_Cod(drDfe["id_emitente_destinatario"].ToString()).Rows[0];
                                            //
                                            cbbDestinatario.Text = drDfe["id_fornecedor"].ToString() + "—" + drDfe["nome"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        if (bllClieCons.Sel_Cliente_Ainda_Existe(drDfe["id_emitente_destinatario"].ToString()) == false)
                                        {
                                            MessageBox.Show("Cliente/Consumidor não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                        }
                                        else
                                        {
                                            cbbTipoDestinatario.SelectedIndex = 0;
                                            //
                                            drDfe = bllClieCons.Sel_Cliente_Codigo(drDfe["id_emitente_destinatario"].ToString()).Rows[0];
                                            //
                                            cbbDestinatario.Text = drDfe["id_cliente"].ToString() + "—" + drDfe["nome"].ToString();
                                        }
                                    }
                                }
                            }
                            //
                            for (int a = 0; a < bllDFe.Sel_Items_DFe(bllDFe._Cod_DFe).Rows.Count; a++)
                            {
                                DataRow drItemDfe = bllDFe.Sel_Items_DFe(bllDFe._Cod_DFe).Rows[a];
                                //
                                DataRow drProd = bllProduto.Sel_Prod_Codigo(drItemDfe["id_produto"].ToString(), "").Rows[0];
                                //
                                if (bllProduto.Sel_Prod_Codigo(drItemDfe["id_produto"].ToString(), "") == null)
                                {
                                    MessageBox.Show("Código de produto não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else if (drProd["ncm"].ToString() == "")
                                {
                                    MessageBox.Show("O Produto [ " + drProd["id_produto"].ToString() + " ] não foi adicionado pois não possui NCM.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else if (bllIBPT.Sel_IBPT_NCM(drProd["ncm"].ToString(), drProd["excecao_ncm"].ToString()) == null)
                                {
                                    MessageBox.Show("O NCM do Produto [ " + drProd["id_produto"].ToString() + " ] não foi encontrado na tabela IBPT.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.DialogResult = DialogResult.None;
                                }
                                else
                                {
                                    string total = bllDFe.Calculo_Valor_Item(drProd["preco"].ToString(), drItemDfe["quantidade"].ToString());
                                    //
                                    string valor_desconto = bllDFe.Calculo_Desconto(total, drProd["desconto_porc"].ToString());
                                    //
                                    string valor_acrescimo = bllDFe.Calculo_Acrescimo(total, drProd["acrescimo_porc"].ToString());
                                    //
                                    string total_real = bllDFe.Calculo_Valor_Item_Desc_Acresc(total, valor_desconto, valor_acrescimo, "0", "0");
                                    //
                                    string base_calculo = bllDFe.Calculo_Valor_Base_Calculo_ICMS(drProd["preco"].ToString(), drItemDfe["quantidade"].ToString(), valor_desconto, valor_acrescimo);
                                    //
                                    string valor_icms = bllDFe.Calculo_Valor_ICMS(base_calculo, drProd["aliq_icms"].ToString());
                                    //
                                    bllDFe.Salvar_Items_Temp(dtItens.Rows.Count.ToString(), drProd["id_produto"].ToString() + "—" + drProd["descricao"].ToString(), drProd["ncm"].ToString(), drProd["cest"].ToString(), drProd["cst"].ToString(), drProd["aliq_icms"].ToString(), drProd["csosn"].ToString(), cfop, drItemDfe["quantidade"].ToString(), "1", total, drProd["preco"].ToString(), valor_desconto, valor_acrescimo, total_real, valor_icms, base_calculo, bllConexao._Codigo_Conexao, "0,00", "0,00", "0,00", "0,00", "0,00", drProd["um"].ToString(), bllDFe.Calculo_Valor_Aprox_Trib(total_real, drProd["id_produto"].ToString() + "—" + drProd["descricao"].ToString()), "0,00", "0,00", "0,00", drProd["cst_ibs_cbs"].ToString(), drProd["cclass_trib"].ToString(), drProd["aliq_ibs_mun"].ToString(), drProd["aliq_ibs_est"].ToString(), drProd["aliq_ibs_est"].ToString(), "0");
                                    //
                                    dtItens.DataSource = bllDFe.Sel_Items_DFe_Temp(bllConexao._Codigo_Conexao);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCapturar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCapturar.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbNaturezaOperacaoCFOP_Leave(object sender, EventArgs e)
        {
            try
            {
                if (_Formulario != 2 & _Formulario != 4)
                {
                    if (cbbNaturezaOperacaoCFOP.Text != "")
                    {
                        string[] items = cbbNaturezaOperacaoCFOP.Text.Split('—');
                        //
                        DataRow dr = bllCFOP.Sel_CFOP_Codigo(items[0]).Rows[0];
                        //
                        if (dr["finalidade"].ToString() != cbbFinalidade.Text)
                        {
                            DialogResult = MessageBox.Show("A finalidade do CFOP/Natureza da Operação cadastrado está como [ " + dr["finalidade"].ToString() + " ], diferente da finalidade selecionada para a criação deste Dfe.\n\nDeseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.None;
                                cbbNaturezaOperacaoCFOP.Text = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Leave do cbbNaturezaOperacaoCFOP.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Leave do cbbNaturezaOperacaoCFOP.");
                }
            }
        }

        private void btnCadastrarTransportadora_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmCadTransportadora Transp = new FrmCadTransportadora(1, null, 0, false, _Usuario, _Cod_PDV_Computador))
            {
                if (Transp.ShowDialog() == DialogResult.OK)
                {
                    dtItens.Select();
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0)
                {
                    MessageBox.Show("Não é possível emitir este registro porque o caixa está fechado.\n\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    btnContinuar.Select();
                }
                else
                {
                    btnSalvar.Select();
                    //
                    if (_Formulario == 2)
                    {
                        using (FrmMenuNFeNFCe Menu = new FrmMenuNFeNFCe(_Usuario, _Cod_PDV_Computador, _Formulario, _Cod_Dfe))
                        {
                            if (Menu.ShowDialog() == DialogResult.OK)
                            {
                                if (_Formulario == 2)
                                {
                                    this.DialogResult = DialogResult.OK;
                                }
                                else if (_Formulario == 3)
                                {
                                    this.DialogResult = DialogResult.OK;
                                }
                                else if (_Formulario == 4)
                                {
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    cbbTipo.Text = "MODELO 55 (NFe)";
                                    //
                                    cbbFinalidade.Text = "SAIDA";
                                    //
                                    cbbTipoDestinatario.Text = "CLIENTES";
                                    //
                                    cbbTipoDestinatario.SelectedIndex = 0;
                                    //
                                    _Cod_Dfe = null;
                                    //
                                    Limpar();
                                    //
                                    btnExcluirDFe.Visible = false;
                                    btnCancelar.Visible = true;
                                }
                            }
                            else
                            {
                                if (_Formulario != 2 & _Formulario != 4)
                                {
                                    btnCancelar.Visible = false;
                                    btnExcluirDFe.Visible = true;
                                    btnSalvar.Visible = false;
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.Abort;
                                }
                            }
                        }
                    }
                    else
                    {
                        DialogResult = MessageBox.Show("Deseja continuar para emissão do DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            if (cbbNaturezaOperacaoCFOP.Text == "" || cbbDestinatario.Text == "")
                            {
                                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:\n[ Natureza da Operação/CFOP Predominante ] e \n[ Destinatário ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbTipo.Select();
                            }
                            else if (dtItens.DataSource == null)
                            {
                                MessageBox.Show("É necessário informar pelo menos 1 (um) item para salvar o DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                cbbTipo.Select();
                            }
                            else
                            {
                                if (_Formulario != 4)
                                {
                                    decimal valor_pago = 0;
                                    DataRow dr;
                                    if (bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao) != null)
                                    {
                                        for (int i = 0; i < bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao).Rows.Count; i++)
                                        {
                                            dr = bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao).Rows[i];
                                            //
                                            valor_pago += Convert.ToDecimal(dr["valor_pago"]);
                                        }
                                        //
                                        if (valor_pago < Convert.ToDecimal(lblValorTotal.Text))
                                        {
                                            MessageBox.Show("O valor total do pagamento informado é menor que o valor total do DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.DialogResult = DialogResult.None;
                                            pEnabled.Enabled = true;
                                            return;
                                        }
                                    }
                                    //
                                    if (_Cod_Dfe == null)
                                    {
                                        string serie;
                                        serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                        //
                                        bool venda;
                                        if (cbbFinalidade.Text == "SAIDA")
                                        {
                                            DialogResult = MessageBox.Show("O DFe atual é uma Saída de uma Venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (DialogResult == DialogResult.Yes)
                                            {
                                                this.DialogResult = DialogResult.None;
                                                //
                                                if (bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao) == null)
                                                {
                                                    this.DialogResult = DialogResult.None;
                                                    DialogResult = MessageBox.Show("Ainda não foi informado o Pagamento para o DFe com finalidade [ Saída ] do tipo [ Venda ].\n\nDeseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                    if (DialogResult == DialogResult.Yes)
                                                    {
                                                        this.DialogResult = DialogResult.None;
                                                        venda = false;
                                                        pEnabled.Enabled = true;
                                                        btnPagamento_Click(sender, e);
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        this.DialogResult = DialogResult.None;
                                                        venda = false;
                                                        pEnabled.Enabled = true;
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    venda = true;
                                                }
                                            }
                                            else
                                            {
                                                this.DialogResult = DialogResult.None;
                                                //
                                                venda = false;
                                            }
                                        }
                                        else
                                        {
                                            venda = false;
                                        }
                                        //
                                        bllDFe.Salvar(null, "PRÓPRIA", cbbTipo.Text, null, serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text.Trim(), lblValorDesconto.Text.Trim(), lblValorFrete.Text.Trim(), lblValorDespesa.Text.Trim(), lblValorTotal.Text.Trim(), cbbNaturezaOperacaoCFOP.Text, false, _Cod_PDV_Computador, cbbTipoDestinatario.Text, "0", "0", true, cbbFinalidade.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, "PENDENTE", null, null, null, venda);
                                        //
                                        string _Ult_Codigo = bllDFe.Sel_Dfe_Ultimo_Cod_Adicionado().ToString();
                                        //
                                        for (int i = 0; i < dtItens.Rows.Count; i++)
                                        {
                                            DataGridViewRow SelectedRow = dtItens.Rows[i];
                                            //
                                            int item = Convert.ToInt32(SelectedRow.Cells[0].Value) - 1;
                                            bllDFe.Salvar_Items(item.ToString(), SelectedRow.Cells[1].Value.ToString() + "—" + SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[17].Value.ToString(), SelectedRow.Cells[18].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString(), SelectedRow.Cells[15].Value.ToString(), SelectedRow.Cells[16].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[14].Value.ToString(), SelectedRow.Cells[12].Value.ToString(), SelectedRow.Cells[13].Value.ToString(), _Ult_Codigo, SelectedRow.Cells[24].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), SelectedRow.Cells[22].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), SelectedRow.Cells[23].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), "0", SelectedRow.Cells[26].Value.ToString(), SelectedRow.Cells[27].Value.ToString(), SelectedRow.Cells[28].Value.ToString(), SelectedRow.Cells[29].Value.ToString(), SelectedRow.Cells[30].Value.ToString(), SelectedRow.Cells[31].Value.ToString(), SelectedRow.Cells[32].Value.ToString(), SelectedRow.Cells[33].Value.ToString(), SelectedRow.Cells[34].Value.ToString());
                                        }
                                        //
                                        if (bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao) != null)
                                        {
                                            for (int i = 0; i < bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao).Rows.Count; i++)
                                            {
                                                dr = bllDFe.Sel_Item_DFe_Pgto_Todas_Temp(bllConexao._Codigo_Conexao).Rows[i];
                                                //
                                                bllDFe.Salvar_Pagamento_DFe(dr["id_item_pagamento"].ToString(), dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString(), dr["valor_pago"].ToString(), _Ult_Codigo);
                                            }
                                        }
                                        //
                                        if (bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao) != null)
                                        {
                                            for (int i = 0; i < bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao).Rows.Count; i++)
                                            {
                                                dr = bllDFe.Sel_Referencia_DFe_Temp(bllConexao._Codigo_Conexao).Rows[i];
                                                //
                                                bllDFe.Salvar_Referencia_DFe(dr["id_referencia"].ToString(), dr["chave_dfe"].ToString(), _Ult_Codigo);
                                            }
                                        }
                                        //
                                        decimal icms = 0;
                                        decimal icmsst = 0;
                                        decimal base_calculo_icms = 0;
                                        decimal base_calculo_icms_st = 0;
                                        decimal total_aprox_trib = 0;
                                        //
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(_Ult_Codigo).Rows.Count; i++)
                                        {
                                            dr = bllDFe.Sel_Items_DFe(_Ult_Codigo).Rows[i];
                                            //
                                            icms += Convert.ToDecimal(dr["valor_icms"]);
                                            icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                            base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                            base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                            total_aprox_trib += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                        }
                                        //
                                        bllDFe.Salvar_icms_icms_st_base_total_trib(_Ult_Codigo, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                                        //
                                        _Importado = false;
                                        //
                                        bllDFe.CriarDFeNFe(_Ult_Codigo, _Cod_PDV_Computador);
                                        //
                                        bllRegistroAtividades.Salvar("SALVOU UM DFE", "DFE", _Ult_Codigo, _Usuario, _Cod_PDV_Computador);
                                        //
                                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                        {
                                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe cadastrado. Cod: " + _Ult_Codigo);
                                        }
                                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                        {
                                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe cadastrado. Cod: " + _Ult_Codigo);
                                        }
                                        //
                                        bllDFe._Consumidor_Final = false;
                                        bllDFe._Tipo_Operacao = null;
                                        //
                                        bllDFe.Excluir_DFe_Temp(bllConexao._Codigo_Conexao);
                                        //
                                        bllDFe.Excluir_Todos_Item_DFe_Temp(bllConexao._Codigo_Conexao);
                                        //
                                        bllDFe.Excluir_Todos_Transportador_Temp(bllConexao._Codigo_Conexao);
                                        //
                                        bllDFe.Excluir_Todos_Referencia_Temp(bllConexao._Codigo_Conexao);
                                        //
                                        bllDFe.Excluir_Item_DFe_Pgto_Atual(bllConexao._Codigo_Conexao);
                                        //
                                        _Cod_Dfe = _Ult_Codigo;
                                    }
                                    else
                                    {
                                        string serie = bllMinhaEmpresa.Sel_Empresa_Serie_NFe();
                                        //
                                        dr = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                                        //
                                        bool venda;
                                        if (cbbFinalidade.Text == "SAIDA")
                                        {
                                            DialogResult = MessageBox.Show("O DFe atual é uma Saída de uma Venda?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (DialogResult == DialogResult.Yes)
                                            {
                                                this.DialogResult = DialogResult.None;
                                                if (bllDFe.Sel_Formas_Pagamento_DFe(_Cod_Dfe) == null)
                                                {
                                                    DialogResult = MessageBox.Show("Ainda não foi informado o Pagamento para o DFe com finalidade [ Saída ] do tipo [ Venda ].\n\nDeseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                    if (DialogResult == DialogResult.Yes)
                                                    {
                                                        this.DialogResult = DialogResult.None;
                                                        venda = false;
                                                        pEnabled.Enabled = true;
                                                        btnPagamento_Click(sender, e);
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        this.DialogResult = DialogResult.None;
                                                        venda = false;
                                                        pEnabled.Enabled = true;
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    venda = true;
                                                }
                                            }
                                            else
                                            {
                                                this.DialogResult = DialogResult.None;
                                                //
                                                venda = false;
                                            }
                                        }
                                        else
                                        {
                                            venda = false;
                                        }
                                        //
                                        bllDFe.Alterar(_Cod_Dfe, dr["chave_dfe"].ToString(), "PRÓPRIA", cbbTipo.Text, dr["numero_nf"].ToString(), serie, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"), mtxtDataSaida.Text, mtxtHorario1.Text, cbbDestinatario.Text, rtxtObs.Text.Trim(), lblValorTotalProdutos.Text.Trim(), lblValorDesconto.Text.Trim(), lblValorFrete.Text.Trim(), lblValorDespesa.Text.Trim(), lblValorTotal.Text.Trim(), cbbNaturezaOperacaoCFOP.Text, cbbTipoDestinatario.Text, "0", "0", cbbFinalidade.Text, bllDFe._Consumidor_Final, bllDFe._Tipo_Operacao, venda);
                                        //
                                        decimal icms = 0;
                                        decimal icmsst = 0;
                                        decimal base_calculo_icms = 0;
                                        decimal base_calculo_icms_st = 0;
                                        decimal total_aprox_trib = 0;
                                        //
                                        for (int i = 0; i < bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows.Count; i++)
                                        {
                                            dr = bllDFe.Sel_Items_DFe(_Cod_Dfe).Rows[i];
                                            //
                                            icms += Convert.ToDecimal(dr["valor_icms"]);
                                            icmsst += Convert.ToDecimal(dr["valor_icms_st"]);
                                            base_calculo_icms += Convert.ToDecimal(dr["valor_base_calculo"]);
                                            base_calculo_icms_st += Convert.ToDecimal(dr["valor_base_calculo_st"]);
                                        }
                                        //
                                        bllDFe.Salvar_icms_icms_st_base_total_trib(_Cod_Dfe, icms.ToString(), icmsst.ToString(), base_calculo_icms.ToString(), base_calculo_icms_st.ToString(), total_aprox_trib.ToString());
                                        //
                                        _Importado = false;
                                        //
                                        bllDFe.CriarDFeNFe(_Cod_Dfe, _Cod_PDV_Computador);
                                        //
                                        bllRegistroAtividades.Salvar("ALTEROU UM DFE", "DFE", _Cod_Dfe, _Usuario, _Cod_PDV_Computador);
                                        //
                                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                        {
                                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe cadastrado. Cod: " + _Cod_Dfe);
                                        }
                                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                        {
                                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe cadastrado. Cod: " + _Cod_Dfe);
                                        }
                                    }
                                }
                                else if (_Formulario == 4)
                                {
                                    DataRow dr = bllDFe.Sel_Nfe_Codigo(_Cod_Dfe).Rows[0];
                                    //
                                    bllDFe.Alterar(_Cod_Dfe, dr["chave_dfe"].ToString(), dr["emissao"].ToString(), "MODELO 55 (NFe)", dr["numero_nf"].ToString(), dr["serie"].ToString(), dr["data_emissao"].ToString().Remove(10), dr["hora_emissao"].ToString(), mtxtDataSaida.Text, mtxtHorario1.Text, dr["id_emitente_destinatario"].ToString() + "—" + dr["nome_emitente_destinatario"].ToString() + "—" + dr["cpf_cnpj_emit_dest"].ToString(), rtxtObs.Text.Trim(), dr["total_produtos"].ToString(), dr["descontos"].ToString(), dr["frete"].ToString(), dr["despesas"].ToString(), dr["valor_total_nf"].ToString(), dr["descricao_cfop_natop"].ToString(), dr["tipo_emitente_destinatario"].ToString(), dr["seguro"].ToString(), dr["ipi"].ToString(), dr["finalidade"].ToString(), false, dr["tipo_operacao"].ToString(), false);
                                }
                                //
                                using (FrmMenuNFeNFCe Menu = new FrmMenuNFeNFCe(_Usuario, _Cod_PDV_Computador, _Formulario, _Cod_Dfe))
                                {
                                    if (Menu.ShowDialog() == DialogResult.OK)
                                    {
                                        if (_Formulario == 3)
                                        {
                                            this.DialogResult = DialogResult.OK;
                                        }
                                        else if (_Formulario == 4)
                                        {
                                            this.DialogResult = DialogResult.OK;
                                        }
                                        else
                                        {
                                            cbbTipo.Text = "MODELO 55 (NFe)";
                                            //
                                            cbbFinalidade.Text = "SAIDA";
                                            //
                                            cbbTipoDestinatario.Text = "CLIENTES";
                                            //
                                            cbbTipoDestinatario.SelectedIndex = 0;
                                            //
                                            _Cod_Dfe = null;
                                            //
                                            Limpar();
                                            //
                                            btnExcluirDFe.Visible = false;
                                            btnCancelar.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        if (_Formulario != 4)
                                        {
                                            btnCancelar.Visible = false;
                                            btnExcluirDFe.Visible = true;
                                            btnSalvar.Visible = false;
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.Abort;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            cbbTipo.Select();
                        }
                    }
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
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                _Importado = false;
                dtItens.DataSource = null;
                Limpar();
                bllDFe._Consumidor_Final = false;
                bllDFe._Tipo_Operacao = null;
            }
        }

        private void btnDinheiro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDinheiro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPagamentoDFe Dfe = new FrmPagamentoDFe(lblValorTotal.Text, _Cod_PDV_Computador, _Usuario, _Cod_Dfe))
            {
                if (Dfe.ShowDialog() == DialogResult.OK)
                {
                    dtItens.Select();
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbDestinatario_Leave(object sender, EventArgs e)
        {
            try
            {
                if (_Formulario != 2 & _Formulario != 4)
                {
                    if (cbbDestinatario.Text != "")
                    {
                        string[] items = cbbDestinatario.Text.Split('—');

                        if ((cbbDestinatario.Text.Split('—').Length - 1) == 1)
                        {
                            MessageBox.Show("Não é possível selecionar um consumidor sem [ CPF/CNPJ ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            cbbDestinatario.Text = null;
                        }
                        else if (bllClieCons.Sel_Situacao_Cliente_Bloqueado(items[0], "BLOQUEADO") == true)
                        {
                            MessageBox.Show("O Consumidor está com a situação cadastral [ Bloqueado ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            cbbDestinatario.Text = null;
                        }
                        else
                        {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão cbbCliente.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão cbbCliente.");
                }
                cbbDestinatario.Text = null;
            }
        }

        private void cbbFinalidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataSaida.Select();
            }
        }

        private void btnReferenciar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnReferenciar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnReferenciar_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmReferenciarDfe Ref = new FrmReferenciarDfe(_Cod_Dfe))
            {
                if (Ref.ShowDialog() == DialogResult.Abort)
                {
                    dtItens.Select();
                }
            }
            pEnabled.Enabled = true;
        }

        private void cbbFinalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Formulario != 4 & _Formulario != 2)
                {
                    if (cbbFinalidade.Text == "SAIDA" || cbbFinalidade.Text == "DEVOLUCAO" || cbbFinalidade.Text == "OUTROS")
                    {
                        btnReferenciar.Enabled = true;
                    }
                    else
                    {
                        btnReferenciar.Enabled = false;
                    }
                    //
                    if (cbbFinalidade.Text != "SAIDA")
                    {
                        btnPagamento.Enabled = false;
                    }
                    else
                    {
                        btnPagamento.Enabled = true;
                    }
                    //
                    cbbNaturezaOperacaoCFOP.Items.Clear();
                    if (bllDFe.Sel_Cfop_Dfe(cbbFinalidade.Text) == null)
                    {
                        cbbNaturezaOperacaoCFOP.Text = null;
                    }
                    else
                    {
                        cbbNaturezaOperacaoCFOP.Items.Add("");
                        foreach (DataRow dr in bllDFe.Sel_Cfop_Dfe(cbbFinalidade.Text).Rows)
                        {
                            cbbNaturezaOperacaoCFOP.Items.Add((dr["cod_cfop"].ToString()) + "—" + (dr["descricao"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarNatOPCFOP.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarNatOPCFOP.");
                }
                cbbNaturezaOperacaoCFOP.Text = null;
            }
        }

        private void btnExcluirDFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirDFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluirDFe_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllDFe.Sel_Dfe_Ainda_Existe(_Cod_Dfe) == false)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.Abort;
                    //
                    _Cod_Dfe = null;
                    //
                    Limpar();
                    //
                    cbbTipo.Select();
                    //
                    btnExcluirDFe.Visible = false;
                    btnCancelar.Visible = true;
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        if (dtItens.DataSource != null)
                        {
                            for (int i = 0; i < dtItens.Rows.Count; i++)
                            {
                                DataGridViewRow SelectedRow = dtItens.Rows[i];
                                //
                                if (cbbFinalidade.Text == "SAIDA")
                                {
                                    bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                                }
                                else if (cbbFinalidade.Text == "RETORNO")
                                {
                                    bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                                }
                                else if (cbbFinalidade.Text == "ENTRADA")
                                {
                                    bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), false);
                                }
                                else if (cbbFinalidade.Text == "DEVOLUCAO")
                                {
                                    bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                                }
                                else if (cbbFinalidade.Text == "COMPLEMENTAR")
                                {
                                    bllDFe.Alterar_Estoque_Produto_NFe(SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), true);
                                }
                            }
                        }
                        //
                        bllDFe.Excluir_Transportador(_Cod_Dfe);
                        //
                        bllDFe.Excluir_Items_DFe(_Cod_Dfe);
                        //
                        bllDFe.Excluir_Referencia_DFe(_Cod_Dfe);
                        //
                        bllDFe.Excluir_Validade_DFe(_Cod_Dfe);
                        //
                        bllDFe.Excluir_Pagamento_DFe(_Cod_Dfe);
                        //
                        bllDFe.Excluir(_Cod_Dfe, _Cod_PDV_Computador);
                        //
                        bllRegistroAtividades.Salvar("EXCLUIU UM DFE", "DFE", _Cod_Dfe, _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe excluído. Cod: " + _Cod_Dfe);
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Dfe excluído. Cod: " + _Cod_Dfe);
                        }
                        //
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //
                        if (_Formulario != 1)
                        {
                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            _Cod_Dfe = null;
                            //
                            Limpar();
                            //
                            cbbTipo.Select();
                            //
                            btnExcluirDFe.Visible = false;
                            btnCancelar.Visible = true;
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirDFe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluirDFe.");
                }
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                _Importado = false;
                dtItens.DataSource = null;
                Limpar();
                bllDFe._Consumidor_Final = false;
                bllDFe._Tipo_Operacao = null;
            }
        }

        private void cbbNaturezaOperacaoCFOP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtItens.DataSource != null & cbbNaturezaOperacaoCFOP.Text != "")
                {
                    bool executar = false;
                    string[] items = cbbNaturezaOperacaoCFOP.Text.Split('—');
                    //
                    for (int i = 0; i < dtItens.Rows.Count; i++)
                    {
                        DataGridViewRow SelectedRow = dtItens.Rows[i];
                        //
                        if (SelectedRow.Cells[16].Value.ToString() != items[0])
                        {
                            executar = true;
                        }
                    }
                    //
                    if (executar == true)
                    {
                        DialogResult = MessageBox.Show("Foi encontrado um ou mais CFOP's que diferem da Natureza da Operação/CFOP Predominante.\n\nDeseja alterar também os CFOP's dos itens cadastrados neste DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            if (_Formulario == 1)
                            {
                                bllDFe.Alterar_CFOP_Item_DFe_Temp(items[0], bllConexao._Codigo_Conexao);
                                //
                                dtItens.DataSource = bllDFe.Sel_Items_DFe_Temp(bllConexao._Codigo_Conexao);
                                //
                                dtItens.Select();
                            }
                            else if (_Formulario == 3)
                            {
                                bllDFe.Alterar_CFOP_Item_DFe(items[0], _Cod_Dfe);
                                //
                                dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                                //
                                dtItens.Select();
                            }
                            else if (_Formulario == 4)
                            {
                                bllDFe.Alterar_CFOP_Item_DFe(items[0], _Cod_Dfe);
                                //
                                dtItens.DataSource = bllDFe.Sel_Items_DFe(_Cod_Dfe);
                                //
                                dtItens.Select();
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão cbbNaturezaOperacaoCFOP.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão cbbNaturezaOperacaoCFOP.");
                }
            }
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Emitir DFe: Clique para iniciar o processo de transmitir o DFe.\n\n2 - Pagamento: Clique para informar as formas de pagamento do DFe.\n\n3 - Transportador: Clique para informar os dados do transportador.\n\n4 - Referenciar: Clique para referenciar um DFe pespecífico.\n\n5 - Cancelar: Clique neste botão se por algum um motivo você deseja descartar o preenchimento do DFe atual.\n\n6 - Excluir DFe: Clicando neste botão você estará excluindo o DFe atual.\n\n7 - Salvar: Clique para salvar o preenchimento do Dfe atual.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblValorIPI_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorIPI_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorBaseCalculoST_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorBaseCalculoST_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorBaseCalculoST_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Base de Cálculo ICMS ST: " + lblValorBaseCalculoST.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorIPI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IPI: " + lblValorIPI.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void rtxtObs_TextChanged(object sender, EventArgs e)
        {
            lblQtdeCar.Text = "Max. de Caracteres: " + rtxtObs.Text.Length + "/4000";
        }

        private void dtItens_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mtxtDataSaida_MouseCaptureChanged(object sender, EventArgs e)
        {

        }
    }
}
