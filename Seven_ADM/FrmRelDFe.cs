using ACBrLib.NFe;
using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelDFe : Form
    {
        public FrmRelDFe(string cod_pdv_computador, string usuario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = 0;
        }

        public FrmRelDFe(string cod_pdv_computador, string usuario, string data, string horario, string data1, string horario1, string pdv_computador_reg)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Data = data;
            _Data1 = data1;
            _Horario = horario;
            _Horario1 = horario1;
            _PDV_Computador_Reg = pdv_computador_reg;
            _Formulario = 1;
        }

        private byte _Trabalho;
        private string _Cod_PDV_Computador;
        private string _Usuario;
        //
        private string _Data;
        private string _Data1;
        private string _Horario;
        private string _Horario1;
        private string _PDV_Computador_Reg;
        private byte _Formulario;
        private bool _Exp_Contador;

        private void FrmRelDFe_Load(object sender, EventArgs e)
        {
            try
            {
                bllDFe._FrmRelDocFiscais_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelDFe iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelDFe iniciado.");
                }
                //
                rbtnCodigo.Checked = true;
                //
                if (_Formulario == 1)
                {
                    rbtnTodos.Checked = true;
                    rbtnCodigo.Enabled = false;
                    rbtnChave.Enabled = false;
                    rbtnCodVenda.Checked = false;
                    rbtnNumeroNF.Enabled = false;
                    rbtnCodDevolucao.Enabled = false;
                    lblDataSaida.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelDFe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelDFe.");
                }
            }
        }

        private void Limpar_OutrosFiltros()
        {
            mtxtpDataEmissao.Text = null;
            mtxtHorarioEmissao.Text = null;
            mtxtpDataEmissao1.Text = null;
            mtxtHorarioEmissao1.Text = null;
            mtxtpDataSaida.Text = null;
            mtxtHorarioSaida.Text = null;
            mtxtpDataSaida1.Text = null;
            mtxtHorarioSaida1.Text = null;
            cbbSituacao.Text = null;
            cbbTipo.Text = null;
            cbbEmitenteDestinatario.Text = null;
            cbbProduto.Text = null;
            cbbModelo.Text = null;
            cbbCFOPNaturezaOp.Text = null;
            cbbFinalidade.Text = null;
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodos_MouseLeave(object sender, EventArgs e)
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

        private void btnSelecionarData1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData1_MouseLeave(object sender, EventArgs e)
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

        private void cbbEmitenteDestinatario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEmitenteDestinatario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarEmitDest_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarEmitDest_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarProduto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarProduto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbModelo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbModelo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCFOPNaturezaOp_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCFOPNaturezaOp_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarCFOPNaturezaOp_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarCFOPNaturezaOp_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtDFe_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtDFE.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtDFe_MouseLeave(object sender, EventArgs e)
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

        private void lblValorTotalReal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalReal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRelatorioTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelatorioTodos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExportarCsv_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExportarCsv_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnExportarTxt_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnExportarTxt_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRelResumido_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelResumido_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarItens_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarItens_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbEmitenteDestinatario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbEmitenteDestinatario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbProduto_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbProduto_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbModelo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbModelo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCFOPNaturezaOp_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCFOPNaturezaOp_DropDownClosed(object sender, EventArgs e)
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

        private void FrmRelDFe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelDFe foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelDFe foi finalizado.");
                }
                bllDFe._FrmRelDocFiscais_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelDFe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelDFe.");
                }
            }
        }

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            mtxtChave.Visible = false;
            lblFin.Enabled = false;
            cbbFinalidade.Enabled = false;
            lblLocalizarEmitente.Enabled = false;
            cbbTipoEmitente.Enabled = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(764, 19);
            txtpCodigo.Text = null;
            Limpar_OutrosFiltros();
            lblDataEntrada.Enabled = false;
            mtxtpDataEmissao.Enabled = false;
            lblAte.Enabled = false;
            mtxtpDataEmissao1.Enabled = false;
            btnSelecionarData.Enabled = false;
            mtxtHorarioEmissao.Enabled = false;
            mtxtHorarioEmissao1.Enabled = false;
            lblDataSaida.Enabled = false;
            mtxtpDataSaida.Enabled = false;
            lblAte1.Enabled = false;
            mtxtpDataSaida1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            mtxtHorarioSaida.Enabled = false;
            mtxtHorarioSaida1.Enabled = false;
            cbbTipo.Enabled = false;
            lblEmissao.Enabled = false;
            cbbEmitenteDestinatario.Enabled = false;
            lblEmitenteDestinatario.Enabled = false;
            btnProcurarEmitDest.Enabled = false;
            cbbProduto.Enabled = false;
            lbProdutoServico.Enabled = false;
            btnProcurarProduto.Enabled = false;
            lblModelo.Enabled = false;
            cbbModelo.Enabled = false;
            lblSituacao.Enabled = false;
            cbbSituacao.Enabled = false;
            cbbCFOPNaturezaOp.Enabled = false;
            lblCFOPNatOp.Enabled = false;
            btnProcurarCFOPNaturezaOp.Enabled = false;
            btnLimpar.Enabled = false;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            mtxtChave.Visible = false;
            lblFin.Enabled = true;
            cbbFinalidade.Enabled = true;
            lblLocalizarEmitente.Enabled = true;
            cbbTipoEmitente.Enabled = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(812, 19);
            Limpar_OutrosFiltros();
            lblDataEntrada.Enabled = true;
            mtxtpDataEmissao.Enabled = true;
            lblAte.Enabled = true;
            mtxtpDataEmissao1.Enabled = true;
            btnSelecionarData.Enabled = true;
            mtxtHorarioEmissao.Enabled = true;
            mtxtHorarioEmissao1.Enabled = true;
            lblDataSaida.Enabled = true;
            mtxtpDataSaida.Enabled = true;
            lblAte1.Enabled = true;
            mtxtpDataSaida1.Enabled = true;
            btnSelecionarData1.Enabled = true;
            mtxtHorarioSaida.Enabled = true;
            mtxtHorarioSaida1.Enabled = true;
            cbbTipo.Enabled = true;
            lblEmissao.Enabled = true;
            cbbEmitenteDestinatario.Enabled = true;
            lblEmitenteDestinatario.Enabled = true;
            btnProcurarEmitDest.Enabled = false;
            cbbProduto.Enabled = true;
            lbProdutoServico.Enabled = true;
            btnProcurarProduto.Enabled = true;
            lblModelo.Enabled = true;
            cbbModelo.Enabled = true;
            lblSituacao.Enabled = true;
            cbbSituacao.Enabled = true;
            cbbCFOPNaturezaOp.Enabled = true;
            lblCFOPNatOp.Enabled = true;
            btnProcurarCFOPNaturezaOp.Enabled = true;
            btnLimpar.Enabled = true;
            btnPesquisar.Select();
            //
            try
            {
                cbbProduto.Items.Clear();
                if (bllDFe.Sel_Produto_DFe("ATIVO") == null)
                {
                    cbbProduto.Enabled = false;
                    cbbProduto.Text = null;
                }
                else
                {
                    cbbProduto.Enabled = true;
                    cbbProduto.Items.Add("");
                    foreach (DataRow dr in bllDFe.Sel_Produto_DFe("ATIVO").Rows)
                    {
                        cbbProduto.Items.Add(dr["id_produto"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
                //
                cbbCFOPNaturezaOp.Items.Clear();
                if (bllDFe.Sel_Cfop_Dfe(null) == null)
                {
                    cbbCFOPNaturezaOp.Enabled = false;
                    cbbCFOPNaturezaOp.Text = null;
                }
                else
                {
                    cbbCFOPNaturezaOp.Enabled = true;
                    cbbCFOPNaturezaOp.Items.Add("");
                    foreach (DataRow dr in bllDFe.Sel_Cfop_Dfe(null).Rows)
                    {
                        cbbCFOPNaturezaOp.Items.Add(dr["cod_cfop"].ToString() + "—" + dr["descricao"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnTodos.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnTodos.");
                }
                cbbEmitenteDestinatario.Items.Clear();
                cbbEmitenteDestinatario.Text = null;
                cbbCFOPNaturezaOp.Items.Clear();
                cbbCFOPNaturezaOp.Text = null;
                cbbProduto.Items.Clear();
                cbbProduto.Text = null;
            }
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            if (txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpCodigo.Text = null;
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void mtxtpDataEmissao_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao.Text == "")
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmissao.Text == "")
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioEmissao.Select();
            }
        }

        private void mtxtpDataEmissao_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtpDataEmissao_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao.Text != "")
            {
                try
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmissao.Text);

                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmissao1.Text != "")
                    {
                        mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmissao.Text) > Convert.ToDateTime(mtxtpDataEmissao1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao.");
                    }
                    mtxtpDataEmissao.Text = null;
                }
            }
            mtxtpDataEmissao.BackColor = Color.White;
        }

        private void lblValorTotal_DoubleClick(object sender, EventArgs e)
        {

        }

        private void mtxtHorarioEmissao_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao.Text == "")
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioEmissao.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioEmissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioEmissao.Text == "")
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataEmissao1.Select();
            }
        }

        private void mtxtHorarioEmissao_Leave(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao.Text != "")
            {
                if (mtxtHorarioEmissao.Text.Length == 4)
                {
                    mtxtHorarioEmissao.Text = mtxtHorarioEmissao.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioEmissao.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao.");
                    }
                    mtxtHorarioEmissao.Text = null;
                }
            }
            mtxtHorarioEmissao.BackColor = Color.White;
        }

        private void mtxtHorarioEmissao_Enter(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtpDataEmissao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao1.Text == "")
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmissao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmissao1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmissao1.Text == "")
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmissao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmissao1_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao1.Text != "")
            {
                try
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmissao1.Text);

                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmissao.Text != "")
                    {
                        mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmissao1.Text) < Convert.ToDateTime(mtxtpDataEmissao.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao1.");
                    }
                    mtxtpDataEmissao1.Text = null;
                }
            }
            mtxtpDataEmissao1.BackColor = Color.White;
        }

        private void mtxtpDataEmissao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioEmissao1.Select();
            }
        }

        private void mtxtpDataEmissao1_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioEmissao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao1.Text == "")
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioEmissao1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioEmissao1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioEmissao1.Text == "")
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioEmissao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataSaida.Select();
            }
        }

        private void mtxtHorarioEmissao1_Leave(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao1.Text != "")
            {
                if (mtxtHorarioEmissao1.Text.Length == 4)
                {
                    mtxtHorarioEmissao1.Text = mtxtHorarioEmissao1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioEmissao1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao1.");
                    }
                    mtxtHorarioEmissao1.Text = null;
                }
            }
            mtxtHorarioEmissao1.BackColor = Color.White;
        }

        private void FrmRelDFe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void mtxtHorarioEmissao1_Enter(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.BackColor = Color.LightBlue;
        }

        private void mtxtpDataSaida_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mtxtpDataSaida_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataSaida.Text == "")
                {
                    mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataSaida.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioSaida.Select();
            }
        }

        private void mtxtpDataSaida_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataSaida.Text == "")
            {
                mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataSaida.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataSaida_Leave(object sender, EventArgs e)
        {
            mtxtpDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataSaida.Text != "")
            {
                try
                {
                    mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataSaida.Text);

                    mtxtpDataSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataSaida1.Text != "")
                    {
                        mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataSaida.Text) > Convert.ToDateTime(mtxtpDataSaida1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataSaida.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataSaida.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataSaida.");
                    }
                    mtxtpDataSaida.Text = null;
                }
            }
            mtxtpDataSaida.BackColor = Color.White;
        }

        private void mtxtpDataSaida_Enter(object sender, EventArgs e)
        {
            mtxtpDataSaida.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioSaida_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioSaida.Text == "")
            {
                mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioSaida.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioSaida_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioSaida.Text == "")
                {
                    mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioSaida.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataSaida1.Select();
            }
        }

        private void mtxtHorarioSaida_Leave(object sender, EventArgs e)
        {
            mtxtHorarioSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioSaida.Text != "")
            {
                if (mtxtHorarioSaida.Text.Length == 4)
                {
                    mtxtHorarioSaida.Text = mtxtHorarioSaida.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioSaida.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioSaida.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioSaida.");
                    }
                    mtxtHorarioSaida.Text = null;
                }
            }
            mtxtHorarioSaida.BackColor = Color.White;
        }

        private void mtxtHorarioSaida_Enter(object sender, EventArgs e)
        {
            mtxtHorarioSaida.BackColor = Color.LightBlue;
        }

        private void mtxtpDataSaida1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataSaida1.Text == "")
            {
                mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataSaida1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataSaida1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioSaida1.Select();
            }
        }

        private void mtxtpDataSaida1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataSaida1.Text == "")
                {
                    mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataSaida1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataSaida1_Leave(object sender, EventArgs e)
        {
            mtxtpDataSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataSaida1.Text != "")
            {
                try
                {
                    mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataSaida1.Text);

                    mtxtpDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataSaida.Text != "")
                    {
                        mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataSaida1.Text) < Convert.ToDateTime(mtxtpDataSaida.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataSaida1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataSaida1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataSaida1.");
                    }
                    mtxtpDataSaida1.Text = null;
                }
            }
            mtxtpDataSaida1.BackColor = Color.White;
        }

        private void mtxtpDataSaida1_Enter(object sender, EventArgs e)
        {
            mtxtpDataSaida1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioSaida1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioSaida1.Text == "")
            {
                mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioSaida1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioSaida1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbModelo.Select();
            }
        }

        private void mtxtHorarioSaida1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioSaida1.Text == "")
                {
                    mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioSaida1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioSaida1_Leave(object sender, EventArgs e)
        {
            mtxtHorarioSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioSaida1.Text != "")
            {
                if (mtxtHorarioSaida1.Text.Length == 4)
                {
                    mtxtHorarioSaida1.Text = mtxtHorarioSaida1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioSaida1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioSaida1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioSaida1.");
                    }
                    mtxtHorarioSaida1.Text = null;
                }
            }
            mtxtHorarioSaida1.BackColor = Color.White;
        }

        private void mtxtHorarioSaida1_Enter(object sender, EventArgs e)
        {
            mtxtHorarioSaida1.BackColor = Color.LightBlue;
        }

        private void txtNumeroNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbTipo.Select();
            }
        }

        private void cbbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipoEmitente.Select();
            }
        }

        private void cbbEmitenteDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbProduto.Select();
            }
        }

        private void cbbProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCFOPNaturezaOp.Select();
            }
        }

        private void cbbModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void cbbCFOPNaturezaOp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFinalidade.Select();
            }
        }

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            try
            {
                if (cbbTipo.SelectedIndex == 0)
                {
                    cbbFinalidade.Text = null;
                    cbbFinalidade.Enabled = true;
                }
                else if (cbbTipo.SelectedIndex == 1)
                {
                    cbbFinalidade.Text = null;
                    cbbFinalidade.Enabled = false;
                }
                else if (cbbTipo.SelectedIndex == 2)
                {
                    cbbFinalidade.Text = null;
                    cbbFinalidade.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto cbbTipo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto cbbTipo.");
                }
                cbbEmitenteDestinatario.Text = null;
            }
            */
        }

        private void btnProcurarEmitDest_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                if (cbbTipoEmitente.SelectedIndex == 1)
                {
                    using (FrmPesqCliente Clie = new FrmPesqCliente(9, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Clie.ShowDialog() == DialogResult.OK)
                        {
                            cbbEmitenteDestinatario.Items.Clear();
                            if (bllDFe.Sel_Cliente_DFe() == null)
                            {
                                cbbEmitenteDestinatario.Text = null;
                            }
                            else
                            {
                                cbbEmitenteDestinatario.Items.Add("");
                                foreach (DataRow dr in bllDFe.Sel_Cliente_DFe().Rows)
                                {
                                    cbbEmitenteDestinatario.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                            cbbEmitenteDestinatario.Text = bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela;
                            bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = null;
                            cbbEmitenteDestinatario.Select();
                        }
                    }
                }
                else if (cbbTipoEmitente.SelectedIndex == 2)
                {
                    using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(6, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Forn.ShowDialog() == DialogResult.OK)
                        {
                            cbbEmitenteDestinatario.Items.Clear();
                            if (bllDFe.Sel_Fornecedor_DFe() == null)
                            {
                                cbbEmitenteDestinatario.Text = null;
                            }
                            else
                            {
                                cbbEmitenteDestinatario.Items.Add("");
                                foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                                {
                                    cbbEmitenteDestinatario.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                                }
                            }
                            cbbEmitenteDestinatario.Text = bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela;
                            bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = null;
                            cbbEmitenteDestinatario.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
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
                cbbEmitenteDestinatario.Text = null;
                bllDFe._FornDFe_Prod_PesqFornClieFunc_Tabela = null;
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarProduto_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqProduto Prod = new FrmPesqProduto(3, null, _Usuario, _Cod_PDV_Computador, 0, null))
            {
                if (Prod.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbProduto.Items.Clear();
                        if (bllDFe.Sel_Produto_DFe("ATIVO") == null)
                        {
                            cbbProduto.Text = null;
                            cbbProduto.Enabled = false;
                        }
                        else
                        {
                            cbbProduto.Enabled = true;
                            cbbProduto.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Produto_DFe("ATIVO").Rows)
                            {
                                cbbProduto.Items.Add((dr["id_produto"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbProduto.Text = bllDFe._FornDFe_Produto_PesqProduto_Tabela;
                        bllDFe._FornDFe_Produto_PesqProduto_Tabela = null;
                        cbbProduto.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProduto.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarProduto.");
                        }
                        cbbProduto.Text = null;
                        bllDFe._FornDFe_Produto_PesqProduto_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarCFOPNaturezaOp_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            //
            using (FrmPesqCFOP CFOP = new FrmPesqCFOP(1, null, _Usuario, _Cod_PDV_Computador))
            {
                if (CFOP.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbCFOPNaturezaOp.Items.Clear();
                        if (bllDFe.Sel_Cfop_Dfe(null) == null)
                        {
                            cbbCFOPNaturezaOp.Text = null;
                            cbbCFOPNaturezaOp.Enabled = false;
                        }
                        else
                        {
                            cbbCFOPNaturezaOp.Enabled = true;
                            cbbCFOPNaturezaOp.Items.Add("");
                            foreach (DataRow dr in bllDFe.Sel_Cfop_Dfe(null).Rows)
                            {
                                cbbCFOPNaturezaOp.Items.Add((dr["cod_cfop"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbCFOPNaturezaOp.Text = bllDFe._FornDFe_Cfop_PesqCfop_Tabela;
                        bllDFe._FornDFe_Cfop_PesqCfop_Tabela = null;
                        cbbCFOPNaturezaOp.Select();
                    }
                    catch (Exception ex)
                    {
                        pEnabled.Enabled = true;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCFOPNaturezaOp.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCFOPNaturezaOp.");
                        }
                        cbbCFOPNaturezaOp.Text = null;
                        bllDFe._FornDFe_Cfop_PesqCfop_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por código, chave, número da nf, código da venda, código da devolução, todos os dados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir um relatório simples do(s) registro(s).\n\n2 - Exp. dados para (.txt): Clique para exportar os dados da tabela para um arquivo (.txt).\n\n3 - Exp. dados para (.csv): Clique para exportar os dados da tabela para um arquivo (.csv).\n\n4 - Consultar Itens: Clique para visualizar o(s) item(ns) da Venda.\n\n5 - Editar/Alterar DFe: Clique para modificar um DFe criado anteriormente.\n\n6 - Clique para exportar os arquivos XML listados na tabela.\n\n7 - Enviar DFe: Clique para enviar por e-mail um DFe selecionado.\n\n8 - Consultar Transportador: Clique para visualizar o transportadpr dp DFe selecionado.\n\n9 - Consultar Referências: Clique para visualizar as referências do DFe selecionado.\n\n10 - Consultar Pagamentos: Clique para visualizar o(s) pagamento(s) do DFe.\n\n11 - Gerar DANFE: Clique para gerar o Danfe do DFe selecionado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllDFe.Sel_Nfe_Codigo(txtpCodigo.Text) == null)
                        {
                            dtDFE.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtDFE.DataSource = bllDFe.Sel_Nfe_Codigo(txtpCodigo.Text);
                            dtDFE.Select();
                        }
                    }
                }
                else if (rbtnChave.Checked == true)
                {
                    mtxtChave.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtChave.Text != "")
                    {
                        mtxtChave.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllDFe.Sel_Nfe_Chave(mtxtChave.Text) == null)
                        {
                            dtDFE.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtDFE.DataSource = bllDFe.Sel_Nfe_Chave(mtxtChave.Text);
                            dtDFE.Select();
                        }
                    }
                }
                else if (rbtnNumeroNF.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtHorarioSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtHorarioSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpDataEmissao.Text == "" & mtxtpDataEmissao1.Text != "") || (mtxtpDataEmissao.Text != "" & mtxtpDataEmissao1.Text == ""))
                        {
                            mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao.Select();
                            return;
                        }
                        else if ((mtxtpDataSaida.Text == "" & mtxtpDataSaida1.Text != "") || (mtxtpDataSaida.Text != "" & mtxtpDataSaida1.Text == ""))
                        {
                            mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao.Select();
                            return;
                        }
                        else
                        {
                            mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Numero_NF(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, mtxtpDataSaida.Text, mtxtpDataSaida1.Text, mtxtHorarioSaida.Text, mtxtHorarioSaida1.Text, cbbModelo.Text, cbbTipo.Text, cbbEmitenteDestinatario.Text, cbbProduto.Text, cbbCFOPNaturezaOp.Text, cbbTipoEmitente.Text, cbbFinalidade.Text, cbbSituacao.Text, txtpCodigo.Text) == null)
                            {
                                dtDFE.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtDFE.DataSource = bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Numero_NF(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, mtxtpDataSaida.Text, mtxtpDataSaida1.Text, mtxtHorarioSaida.Text, mtxtHorarioSaida1.Text, cbbModelo.Text, cbbTipo.Text, cbbEmitenteDestinatario.Text, cbbProduto.Text, cbbCFOPNaturezaOp.Text, cbbTipoEmitente.Text, cbbFinalidade.Text, cbbSituacao.Text, txtpCodigo.Text);
                                dtDFE.Select();
                            }
                        }
                    }
                }
                else if (rbtnCodVenda.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtHorarioSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtHorarioSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpDataEmissao.Text == "" & mtxtpDataEmissao1.Text != "") || (mtxtpDataEmissao.Text != "" & mtxtpDataEmissao1.Text == ""))
                        {
                            mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao.Select();
                            return;
                        }
                        else if ((mtxtpDataSaida.Text == "" & mtxtpDataSaida1.Text != "") || (mtxtpDataSaida.Text != "" & mtxtpDataSaida1.Text == ""))
                        {
                            mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao.Select();
                            return;
                        }
                        else
                        {
                            mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, mtxtpDataSaida.Text, mtxtpDataSaida1.Text, mtxtHorarioSaida.Text, mtxtHorarioSaida1.Text, cbbModelo.Text, cbbTipo.Text, cbbEmitenteDestinatario.Text, cbbProduto.Text, cbbCFOPNaturezaOp.Text, cbbTipoEmitente.Text, cbbFinalidade.Text, cbbSituacao.Text, txtpCodigo.Text) == null)
                            {
                                dtDFE.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtDFE.DataSource = bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, mtxtpDataSaida.Text, mtxtpDataSaida1.Text, mtxtHorarioSaida.Text, mtxtHorarioSaida1.Text, cbbModelo.Text, cbbTipo.Text, cbbEmitenteDestinatario.Text, cbbProduto.Text, cbbCFOPNaturezaOp.Text, cbbTipoEmitente.Text, cbbFinalidade.Text, cbbSituacao.Text, txtpCodigo.Text);
                                dtDFE.Select();
                            }
                        }
                    }
                }
                else if (rbtnCodDevolucao.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtHorarioSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtHorarioSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpDataEmissao.Text == "" & mtxtpDataEmissao1.Text != "") || (mtxtpDataEmissao.Text != "" & mtxtpDataEmissao1.Text == ""))
                        {
                            mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao.Select();
                            return;
                        }
                        else if ((mtxtpDataSaida.Text == "" & mtxtpDataSaida1.Text != "") || (mtxtpDataSaida.Text != "" & mtxtpDataSaida1.Text == ""))
                        {
                            mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao.Select();
                            return;
                        }
                        else
                        {
                            mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Devolucao(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, mtxtpDataSaida.Text, mtxtpDataSaida1.Text, mtxtHorarioSaida.Text, mtxtHorarioSaida1.Text, cbbModelo.Text, cbbTipo.Text, cbbEmitenteDestinatario.Text, cbbProduto.Text, cbbCFOPNaturezaOp.Text, cbbTipoEmitente.Text, cbbFinalidade.Text, cbbSituacao.Text, txtpCodigo.Text) == null)
                            {
                                dtDFE.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtDFE.DataSource = bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Devolucao(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, mtxtpDataSaida.Text, mtxtpDataSaida1.Text, mtxtHorarioSaida.Text, mtxtHorarioSaida1.Text, cbbModelo.Text, cbbTipo.Text, cbbEmitenteDestinatario.Text, cbbProduto.Text, cbbCFOPNaturezaOp.Text, cbbTipoEmitente.Text, cbbFinalidade.Text, cbbSituacao.Text, txtpCodigo.Text);
                                dtDFE.Select();
                            }
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtpDataSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpDataSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtHorarioSaida.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtHorarioSaida1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if ((mtxtpDataEmissao.Text == "" & mtxtpDataEmissao1.Text != "") || (mtxtpDataEmissao.Text != "" & mtxtpDataEmissao1.Text == ""))
                    {
                        mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ ]ata > para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpDataEmissao.Select();
                        return;
                    }
                    else if ((mtxtpDataSaida.Text == "" & mtxtpDataSaida1.Text != "") || (mtxtpDataSaida.Text != "" & mtxtpDataSaida1.Text == ""))
                    {
                        mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpDataEmissao.Select();
                        return;
                    }
                    else
                    {
                        mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioSaida.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioSaida1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Emissao_Todos(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, mtxtpDataSaida.Text, mtxtpDataSaida1.Text, mtxtHorarioSaida.Text, mtxtHorarioSaida1.Text, cbbModelo.Text, cbbTipo.Text, cbbEmitenteDestinatario.Text, cbbProduto.Text, cbbCFOPNaturezaOp.Text, cbbTipoEmitente.Text, cbbFinalidade.Text, cbbSituacao.Text) == null)
                        {
                            dtDFE.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtDFE.DataSource = bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Emissao_Todos(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, mtxtpDataSaida.Text, mtxtpDataSaida1.Text, mtxtHorarioSaida.Text, mtxtHorarioSaida1.Text, cbbModelo.Text, cbbTipo.Text, cbbEmitenteDestinatario.Text, cbbProduto.Text, cbbCFOPNaturezaOp.Text, cbbTipoEmitente.Text, cbbFinalidade.Text, cbbSituacao.Text);
                            dtDFE.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtDFE.DataSource = null;
                rbtnCodigo.Checked = true;
            }
        }

        private void dtDFe_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtDFE.Columns[0].HeaderText = "Código";
            dtDFE.Columns[1].HeaderText = "Número da NF";
            dtDFE.Columns[2].HeaderText = "Tipo de Emit./Dest.";
            dtDFE.Columns[3].HeaderText = "Código do Emit./Dest.";
            dtDFE.Columns[4].HeaderText = "Nome do Emitente/Destinatário";
            dtDFE.Columns[5].HeaderText = "CPF/CNPJ do Emitente/Destinatário";
            dtDFE.Columns[6].HeaderText = "Total dos Produtos";
            dtDFE.Columns[7].HeaderText = "Valor Total da NF";
            dtDFE.Columns[8].HeaderText = "Série";
            dtDFE.Columns[9].HeaderText = "Data de Emissão";
            dtDFE.Columns[10].HeaderText = "Hora da Emissão";
            dtDFE.Columns[11].HeaderText = "Data de Sáida";
            dtDFE.Columns[12].HeaderText = "Hora de Saída";
            dtDFE.Columns[13].HeaderText = "Modelo";
            dtDFE.Columns[14].HeaderText = "Emissão";
            dtDFE.Columns[15].HeaderText = "Descontos";
            dtDFE.Columns[16].HeaderText = "Frete";
            dtDFE.Columns[17].HeaderText = "Despesas";
            dtDFE.Columns[18].HeaderText = "Chave";
            dtDFE.Columns[19].HeaderText = "Observacao";
            dtDFE.Columns[20].HeaderText = "Natureza da Operação/CFOP Predominante";
            dtDFE.Columns[21].Visible = false;
            dtDFE.Columns[22].Visible = false;
            dtDFE.Columns[23].HeaderText = "Produto/Quantidade";
            dtDFE.Columns[24].HeaderText = "Seguro";
            dtDFE.Columns[25].HeaderText = "IPI";
            dtDFE.Columns[26].HeaderText = "Finalidade";
            dtDFE.Columns[27].HeaderText = "ICMS";
            dtDFE.Columns[28].HeaderText = "ICMS ST";
            dtDFE.Columns[29].HeaderText = "Base de Cálculo ICMS";
            dtDFE.Columns[30].HeaderText = "Base de Cálculo ICMS ST";
            dtDFE.Columns[31].HeaderText = "Total Aprox. dos Trib.";
            dtDFE.Columns[32].HeaderText = "Situação";
            dtDFE.Columns[33].Visible = false;
            dtDFE.Columns[34].Visible = false;
            dtDFE.Columns[35].HeaderText = "Consumidor Final";
            dtDFE.Columns[36].HeaderText = "Tipo de Operação";
            dtDFE.Columns[37].HeaderText = "Cód. da Venda";
            dtDFE.Columns[38].HeaderText = "Cód. da Devolução";
            dtDFE.Columns[39].Visible = false;
            dtDFE.Columns[40].HeaderText = "Data de Cad/Criação";
            //
            dtDFE.Columns[0].Width = 85;
            dtDFE.Columns[1].Width = 105;
            dtDFE.Columns[2].Width = 150;
            dtDFE.Columns[3].Width = 135;
            dtDFE.Columns[4].Width = 275;
            dtDFE.Columns[5].Width = 205;
            dtDFE.Columns[6].Width = 150;
            dtDFE.Columns[7].Width = 150;
            dtDFE.Columns[8].Width = 85;
            dtDFE.Columns[9].Width = 150;
            dtDFE.Columns[10].Width = 150;
            dtDFE.Columns[11].Width = 150;
            dtDFE.Columns[12].Width = 150;
            dtDFE.Columns[13].Width = 100;
            dtDFE.Columns[14].Width = 100;
            dtDFE.Columns[15].Width = 150;
            dtDFE.Columns[16].Width = 150;
            dtDFE.Columns[17].Width = 150;
            dtDFE.Columns[18].Width = 425;
            dtDFE.Columns[19].Width = 500;
            dtDFE.Columns[20].Width = 350;
            dtDFE.Columns[23].Width = 275;
            dtDFE.Columns[24].Width = 150;
            dtDFE.Columns[25].Width = 150;
            dtDFE.Columns[26].Width = 200;
            dtDFE.Columns[27].Width = 150;
            dtDFE.Columns[28].Width = 150;
            dtDFE.Columns[29].Width = 150;
            dtDFE.Columns[30].Width = 175;
            dtDFE.Columns[31].Width = 150;
            dtDFE.Columns[32].Width = 150;
            dtDFE.Columns[35].Width = 150;
            dtDFE.Columns[36].Width = 250;
            dtDFE.Columns[37].Width = 150;
            dtDFE.Columns[38].Width = 150;
            dtDFE.Columns[40].Width = 150;
            //
            dtDFE.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[37].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[40].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtDFE.Columns[40].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            dtDFE.DefaultCellStyle.Font = new Font(dtDFE.Font, FontStyle.Bold);
            lblRegistros.Text = "Registros: " + dtDFE.Rows.Count;
            //
            decimal valortotalreal = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valortotalreal += Convert.ToDecimal(dtDFE.Rows[i].Cells[7].Value);
            }
            lblValorTotalReal.Text = Convert.ToDecimal(valortotalreal).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valortotal = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valortotal += Convert.ToDecimal(dtDFE.Rows[i].Cells[6].Value);
            }
            lblValorTotal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valoricms = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valoricms += Convert.ToDecimal(dtDFE.Rows[i].Cells[27].Value);
            }
            lblValorICMS.Text = Convert.ToDecimal(valoricms).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valoricmsst = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valoricmsst += Convert.ToDecimal(dtDFE.Rows[i].Cells[28].Value);
            }
            lblValorICMSST.Text = Convert.ToDecimal(valoricmsst).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valorfrete = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valorfrete += Convert.ToDecimal(dtDFE.Rows[i].Cells[16].Value);
            }
            lblValorFrete.Text = Convert.ToDecimal(valorfrete).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valordespesa = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valordespesa += Convert.ToDecimal(dtDFE.Rows[i].Cells[17].Value);
            }
            lblValorDespesas.Text = Convert.ToDecimal(valordespesa).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valordesconto = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valordesconto += Convert.ToDecimal(dtDFE.Rows[i].Cells[15].Value);
            }
            lblValorDesconto.Text = Convert.ToDecimal(valordesconto).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valorseguro = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valorseguro += Convert.ToDecimal(dtDFE.Rows[i].Cells[24].Value);
            }
            lblValorSeguro.Text = Convert.ToDecimal(valorseguro).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valoripi = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valoripi += Convert.ToDecimal(dtDFE.Rows[i].Cells[25].Value);
            }
            lblValorIPI.Text = Convert.ToDecimal(valoripi).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valorbasecalculoicms = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valorbasecalculoicms += Convert.ToDecimal(dtDFE.Rows[i].Cells[29].Value);
            }
            lblValorBcICMS.Text = Convert.ToDecimal(valorbasecalculoicms).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valorbasecalculoicmsst = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valorbasecalculoicmsst += Convert.ToDecimal(dtDFE.Rows[i].Cells[30].Value);
            }
            lblValorBcSt.Text = Convert.ToDecimal(valorbasecalculoicmsst).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valortotalaproxtrib = 0;
            for (int i = 0; i < dtDFE.Rows.Count; i++)
            {
                valortotalaproxtrib += Convert.ToDecimal(dtDFE.Rows[i].Cells[31].Value);
            }
            lblValorAproxTrib.Text = Convert.ToDecimal(valortotalaproxtrib).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void dtDFe_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtDFE.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtDFE.DefaultCellStyle.SelectionForeColor = Color.Black;

            dtDFE.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[6].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[7].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[15].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[16].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[16].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[17].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[17].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[24].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[24].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[25].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[25].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[26].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[26].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[27].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[28].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[28].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[29].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[29].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[30].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[30].DefaultCellStyle.Format = "n2";
            dtDFE.Columns[31].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtDFE.Columns[31].DefaultCellStyle.Format = "n2";

            DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];

            if (SelectedRow.Cells[13].Value.ToString() == "55")
            {
                if (SelectedRow.Cells[32].Value.ToString() == "PENDENTE")
                {
                    if (SelectedRow.Cells[37].Value.ToString() != "0")
                    {
                        btnEditarDFe.Enabled = false;
                    }
                    else
                    {
                        btnEditarDFe.Enabled = true;
                    }
                }
                else
                {
                    btnEditarDFe.Enabled = false;
                }
            }
            else
            {
                btnEditarDFe.Enabled = false;
            }
            //
            if (SelectedRow.Cells[14].Value.ToString() == "PRÓPRIA")
            {
                btnConsultarPagamento.Enabled = true;
                btnConsultarReferencias.Enabled = true;
                btnEnviar.Enabled = true;
                btnGerarDanfe.Enabled = true;
                btnGerarContaPagar.Enabled = false;
            }
            else
            {
                btnConsultarPagamento.Enabled = false;
                btnConsultarReferencias.Enabled = false;
                btnEnviar.Enabled = false;
                btnGerarDanfe.Enabled = false;
                btnGerarContaPagar.Enabled = true;
            }
            //
            if (rbtnCodigo.Checked == true)
            {
                if (SelectedRow.Cells[32].Value.ToString() == "TRANSMITIDA")
                {
                    btnExportarXML.Enabled = true;
                }
                else
                {
                    btnExportarXML.Enabled = false;
                }
            }
        }

        private void dtDFe_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtDFE.DataSource == null)
            {
                dtDFE.Enabled = false;
                grbBox2.Enabled = false;
                lblValorTotal.Enabled = false;
                lblValorTotalReal.Enabled = false;
                lblTotal.Enabled = false;
                lblTotalReal.Enabled = false;
                lblICMS.Enabled = false;
                lblValorICMS.Enabled = false;
                lblICMSST.Enabled = false;
                lblValorICMSST.Enabled = false;
                lblValorDesconto.Enabled = false;
                lblDesconto.Enabled = false;
                lblValorFrete.Enabled = false;
                lblFrete.Enabled = false;
                lblDespesas.Enabled = false;
                lblValorDespesas.Enabled = false;
                lblValorSeguro.Enabled = false;
                lblSeguro.Enabled = false;
                lblIPI.Enabled = false;
                lblValorIPI.Enabled = false;
                lblValorBcICMS.Enabled = false;
                lblBCICMS.Enabled = false;
                lblValorBcSt.Enabled = false;
                lblBCICMSST.Enabled = false;
                lblTribAprox.Enabled = false;
                lblValorAproxTrib.Enabled = false;
                _Exp_Contador = false;
            }
            else
            {
                dtDFE.Enabled = true;
                grbBox2.Enabled = true;
                lblValorTotal.Enabled = true;
                lblValorTotalReal.Enabled = true;
                lblTotal.Enabled = true;
                lblTotalReal.Enabled = true;
                lblICMS.Enabled = true;
                lblValorICMS.Enabled = true;
                lblICMSST.Enabled = true;
                lblValorICMSST.Enabled = true;
                lblValorDesconto.Enabled = true;
                lblDesconto.Enabled = true;
                lblValorFrete.Enabled = true;
                lblFrete.Enabled = true;
                lblDespesas.Enabled = true;
                lblValorDespesas.Enabled = true;
                lblValorSeguro.Enabled = true;
                lblSeguro.Enabled = true;
                lblIPI.Enabled = true;
                lblValorIPI.Enabled = true;
                lblValorBcICMS.Enabled = true;
                lblBCICMS.Enabled = true;
                lblValorBcSt.Enabled = true;
                lblBCICMSST.Enabled = true;
                lblTribAprox.Enabled = true;
                lblValorAproxTrib.Enabled = true;
                //
                if (cbbTipo.Text == "PRÓPRIA" & cbbSituacao.Text == "TRANSMITIDA")
                {
                    _Exp_Contador = true;
                }
                else
                {
                    _Exp_Contador = false;
                }
            }
        }

        private void dtDFe_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorTotalReal.Text = null;
            lblValorTotal.Text = null;
            lblValorICMS.Text = null;
            lblValorICMSST.Text = null;
            lblValorFrete.Text = null;
            lblValorDespesas.Text = null;
            lblValorDesconto.Text = null;
            lblValorSeguro.Text = null;
            lblValorIPI.Text = null;
            lblValorBcSt.Text = null;
            lblValorBcICMS.Text = null;
            lblValorAproxTrib.Text = null;
        }

        private void dtDFe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 37 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 38 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 3 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 5 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 8 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 20 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 9 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 11 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 23 && !e.Value.ToString().Contains("—"))
            {
                e.Value = "QUANTIDADE DE ITENS: " + e.Value.ToString();
            }
            //
            if (e.ColumnIndex == 35 && e.Value.ToString() == "0")
            {
                e.Value = "NÃO";
            }
            else if (e.ColumnIndex == 35 && e.Value.ToString() == "1")
            {
                e.Value = "SIM";
            }
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblValorTotalReal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalReal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total dos Produtos (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbTipoEmitente_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                cbbEmitenteDestinatario.Items.Clear();
                if (cbbTipoEmitente.SelectedIndex == 0)
                {
                    cbbEmitenteDestinatario.Text = null;
                    btnProcurarEmitDest.Enabled = false;
                }
                else if (cbbTipoEmitente.SelectedIndex == 1)
                {
                    if (bllDFe.Sel_Cliente_DFe() == null)
                    {
                        cbbEmitenteDestinatario.Text = null;
                        btnProcurarEmitDest.Enabled = false;
                    }
                    else
                    {
                        btnProcurarEmitDest.Enabled = true;
                        cbbEmitenteDestinatario.Items.Add("");
                        foreach (DataRow dr in bllDFe.Sel_Cliente_DFe().Rows)
                        {
                            cbbEmitenteDestinatario.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbTipoEmitente.SelectedIndex == 2)
                {
                    if (bllDFe.Sel_Fornecedor_DFe() == null)
                    {
                        cbbEmitenteDestinatario.Text = null;
                        btnProcurarEmitDest.Enabled = false;
                    }
                    else
                    {
                        btnProcurarEmitDest.Enabled = true;
                        cbbEmitenteDestinatario.Items.Add("");
                        foreach (DataRow dr in bllDFe.Sel_Fornecedor_DFe().Rows)
                        {
                            cbbEmitenteDestinatario.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbTipoEmitente.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbTipoEmitente.");
                }
                cbbEmitenteDestinatario.Items.Clear();
                cbbEmitenteDestinatario.Text = null;
                cbbTipoEmitente.Text = null;
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

        private void cbbTipoEmitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbEmitenteDestinatario.Select();
            }
        }

        private void cbbFinalidade_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbFinalidade_DropDownClosed(object sender, EventArgs e)
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

        private void cbbFinalidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnConsultarItens_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 4))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtDFE.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(22))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataEmissao.Text = bllDFe._Data_DatePicker1;
                    mtxtpDataEmissao1.Text = bllDFe._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(22))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataSaida.Text = bllDFe._Data_DatePicker1;
                    mtxtpDataSaida1.Text = bllDFe._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_Trabalho == 0)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 9);
                    XPen pen1 = new XPen(XColors.LightBlue);
                    XPen pen = new XPen(XColors.Black);
                    DataRow dr;
                    //
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllClieCons._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 10 + Margem_Esq, 7 + Margem_Topo, 100, 116);
                    }
                    //DATA
                    graphics.DrawRectangle(pen, XBrushes.White, 494 + Margem_Esq, 5 + Margem_Topo, 95, 122);
                    textFormatter2.DrawString("Criado em:", fonte4, XBrushes.Black, new XRect(515 + Margem_Esq, 10 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString(DateTime.Now.ToShortDateString(), fonte1, XBrushes.Black, new XRect(510 + Margem_Esq, 22 + Margem_Topo, page.Width, page.Height));
                    //HORÁRIO                    
                    textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(527 + Margem_Esq, 72 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString(DateTime.Now.ToLongTimeString(), fonte1, XBrushes.Black, new XRect(516 + Margem_Esq, 84 + Margem_Topo, page.Width, page.Height));
                    //CABECALHO  DOCUMENTO
                    dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    if (!dr["nome"].ToString().Contains(" ") & dr["nome"].ToString().Length > 38)
                    {
                        textFormatter1.DrawString(dr["nome"].ToString().Insert(38, Environment.NewLine), fonte1, XBrushes.Black, new XRect(115 + Margem_Esq, 7 + Margem_Topo, 370, 28));
                    }
                    else
                    {
                        textFormatter1.DrawString(dr["nome"].ToString(), fonte1, XBrushes.Black, new XRect(115 + Margem_Esq, 7 + Margem_Topo, 370, 28));
                    }
                    //
                    textFormatter1.DrawString(dr["fantasia"].ToString() + Environment.NewLine + "CPF/CNPJ.: " + dr["cpf_cnpj"].ToString() + ", IE.: " + dr["ie_rg"].ToString() + Environment.NewLine + "End.: " + dr["endereco"].ToString() + Environment.NewLine + dr["complemento"].ToString() + ", " + dr["numero"].ToString() + Environment.NewLine + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + Environment.NewLine + "Tel.: " + dr["telefone"].ToString() + ", Cel.: " + dr["celular"].ToString() + Environment.NewLine + "E-mail.: " + dr["email"].ToString(), fonte2, XBrushes.Black, new XRect(115 + Margem_Esq, 35 + Margem_Topo, 370, 95));
                    //
                    textFormatter1.DrawString("Relatório de DFe", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓD.    EMISSÃO    SÉRIE/Nº NF    DATA DE EMISSÃO    EMIT./DEST.    MODELO    TOTAIS", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //           
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtDFE.Rows.Count; i++)
                    {
                        if (i == 16)
                        {
                            TotalPaginas = TotalPaginas + 1;
                        }
                        else if (i == registros)
                        {
                            registros = registros + 21;
                            TotalPaginas = TotalPaginas + 1;
                        }
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //
                    for (int linha = 0; linha < dtDFE.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtDFE.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtDFE.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 202) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Emissão:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Série/Nº NF:", fonte2, XBrushes.Black, new XRect(200 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[8].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + " / " + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(254 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data e Horário Emissão:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString().Remove(10) + " " + SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(453 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                //
                                string cpf_cnpj;
                                if (SelectedRow.Cells[5].Value.ToString() == "0" || SelectedRow.Cells[5].Value.ToString() == null || SelectedRow.Cells[5].Value.ToString() == "")
                                {
                                    cpf_cnpj = null;
                                }
                                else
                                {
                                    cpf_cnpj = "-" + SelectedRow.Cells[5].Value.ToString();
                                }
                                string cod_cons;
                                if (SelectedRow.Cells[3].Value.ToString() == "0")
                                {
                                    cod_cons = null;
                                }
                                else
                                {
                                    cod_cons = SelectedRow.Cells[3].Value.ToString() + "-";
                                }
                                textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(cod_cons + SelectedRow.Cells[4].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(95 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Modelo:", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(483 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Produtos: " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desc.: " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Seg.: " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + "  IPI: " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Frete: " + Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desp.: " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS: " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS-ST: " + Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Total NF: " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, 18));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Total Produtos: " + lblValorTotalReal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Total NF: " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 202) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Emissão:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Série/Nº NF:", fonte2, XBrushes.Black, new XRect(200 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[8].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + " / " + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(254 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data e Horário Emissão:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString().Remove(10) + " " + SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(453 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                //
                                string cpf_cnpj;
                                if (SelectedRow.Cells[5].Value.ToString() == "0" || SelectedRow.Cells[5].Value.ToString() == null || SelectedRow.Cells[5].Value.ToString() == "")
                                {
                                    cpf_cnpj = null;
                                }
                                else
                                {
                                    cpf_cnpj = "-" + SelectedRow.Cells[5].Value.ToString();
                                }
                                string cod_cons;
                                if (SelectedRow.Cells[3].Value.ToString() == "0")
                                {
                                    cod_cons = null;
                                }
                                else
                                {
                                    cod_cons = SelectedRow.Cells[3].Value.ToString() + "-";
                                }
                                textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(cod_cons + SelectedRow.Cells[4].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(95 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Modelo:", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(483 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Produtos: " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desc.: " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Seg.: " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + "  IPI: " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Frete: " + Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desp.: " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS: " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS-ST: " + Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Total NF: " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, 18));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            //
                            if (linha == (pagina - 1) & dtDFE.Rows.Count > 16)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                ContadorPagina = ContadorPagina + 1;
                                pagina = pagina + 22;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                fonte4 = new XFont("Microsoft Sans Serif", 9);
                                pen1 = new XPen(XColors.LightBlue);
                                pen = new XPen(XColors.Black);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                textFormatter1.DrawString("Relatório de DFe", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                        }
                        else
                        {
                            if (linha == (pagina - 1))
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                ContadorPagina = ContadorPagina + 1;
                                pagina = pagina + 21;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                fonte4 = new XFont("Microsoft Sans Serif", 9);
                                pen1 = new XPen(XColors.LightBlue);
                                pen = new XPen(XColors.Black);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                textFormatter1.DrawString("Relatório de DFe", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtDFE.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 24) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Emissão:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Série/Nº NF:", fonte2, XBrushes.Black, new XRect(200 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[8].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + " / " + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(254 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data e Horário Emissão:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString().Remove(10) + " " + SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(453 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                //
                                string cpf_cnpj;
                                if (SelectedRow.Cells[5].Value.ToString() == "0" || SelectedRow.Cells[5].Value.ToString() == null || SelectedRow.Cells[5].Value.ToString() == "")
                                {
                                    cpf_cnpj = null;
                                }
                                else
                                {
                                    cpf_cnpj = "-" + SelectedRow.Cells[5].Value.ToString();
                                }
                                string cod_cons;
                                if (SelectedRow.Cells[3].Value.ToString() == "0")
                                {
                                    cod_cons = null;
                                }
                                else
                                {
                                    cod_cons = SelectedRow.Cells[3].Value.ToString() + "-";
                                }
                                textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(cod_cons + SelectedRow.Cells[4].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(95 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Modelo:", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(483 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Produtos: " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desc.: " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Seg.: " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + "  IPI: " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Frete: " + Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desp.: " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS: " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS-ST: " + Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Total NF: " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, 18));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Total Produtos: " + lblValorTotalReal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Total NF: " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 24) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Emissão:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Série/Nº NF:", fonte2, XBrushes.Black, new XRect(200 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[8].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + " / " + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(254 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data e Horário Emissão:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString().Remove(10) + " " + SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(453 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                //
                                string cpf_cnpj;
                                if (SelectedRow.Cells[5].Value.ToString() == "0" || SelectedRow.Cells[5].Value.ToString() == null || SelectedRow.Cells[5].Value.ToString() == "")
                                {
                                    cpf_cnpj = null;
                                }
                                else
                                {
                                    cpf_cnpj = "-" + SelectedRow.Cells[5].Value.ToString();
                                }
                                string cod_cons;
                                if (SelectedRow.Cells[3].Value.ToString() == "0")
                                {
                                    cod_cons = null;
                                }
                                else
                                {
                                    cod_cons = SelectedRow.Cells[3].Value.ToString() + "-";
                                }
                                textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(cod_cons + SelectedRow.Cells[4].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(95 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Modelo:", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(483 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Produtos: " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desc.: " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Seg.: " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + "  IPI: " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Frete: " + Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desp.: " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS: " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS-ST: " + Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Total NF: " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, 18));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe");
                }

                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.txt");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.txt"))
                {
                    writer.WriteLine("Relatório de DFe" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToLongTimeString());
                    for (int linha = 0; linha < dtDFE.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtDFE.Rows[linha];
                        //
                        string data_emissao;
                        if (SelectedRow.Cells[9].Value.ToString() == "" || SelectedRow.Cells[9].Value.ToString() == null)
                        {
                            data_emissao = "";
                        }
                        else
                        {
                            data_emissao = SelectedRow.Cells[9].Value.ToString().Remove(10);
                        }
                        //
                        string data_saida;
                        if (SelectedRow.Cells[11].Value.ToString() == "" || SelectedRow.Cells[11].Value.ToString() == null)
                        {
                            data_saida = "";
                        }
                        else
                        {
                            data_saida = SelectedRow.Cells[11].Value.ToString().Remove(10);
                        }
                        //
                        string cpf_cnpj;
                        if (SelectedRow.Cells[5].Value.ToString() == "0")
                        {
                            cpf_cnpj = "";
                        }
                        else
                        {
                            cpf_cnpj = SelectedRow.Cells[5].Value.ToString();
                        }
                        //
                        string numero;
                        if (SelectedRow.Cells[1].Value.ToString() == "" || SelectedRow.Cells[1].Value.ToString() == null)
                        {
                            numero = "";
                        }
                        else
                        {
                            numero = SelectedRow.Cells[1].Value.ToString();
                        }
                        //
                        string serie;
                        if (SelectedRow.Cells[8].Value.ToString() == "" || SelectedRow.Cells[8].Value.ToString() == null)
                        {
                            serie = "";
                        }
                        else
                        {
                            serie = SelectedRow.Cells[8].Value.ToString();
                        }
                        //
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Número da NF: " + SelectedRow.Cells[1].Value.ToString() + " |Tipo de Emitente: " + SelectedRow.Cells[2].Value.ToString() + " |Código do Emit./Dest.: " + SelectedRow.Cells[3].Value.ToString() + " |Nome do Emitente/Destinatário: " + SelectedRow.Cells[4].Value.ToString() + " |CPF/CNPJ do Emitente/Destinatário: " + cpf_cnpj + " |Total dos Produtos: " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor Total da NF: " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Série: " + serie + " |Data de Emissão: " + data_emissao + " |Hora da Emissão: " + SelectedRow.Cells[10].Value.ToString() + "|Data de Sáida: " + data_saida + " |Hora de Saída: " + SelectedRow.Cells[12].Value.ToString() + " |Modelo: " + SelectedRow.Cells[13].Value.ToString() + " |Emissão: " + SelectedRow.Cells[14].Value.ToString() + " |Descontos: " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Frete: " + Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Despesas: " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Chave: " + SelectedRow.Cells[18].Value.ToString() + " |Observacao: " + SelectedRow.Cells[19].Value.ToString() + " |Natureza da Operação/CFOP Predominante: " + SelectedRow.Cells[20].Value.ToString() + " |Produto/Quantidade: " + SelectedRow.Cells[23].Value.ToString() + " |Seguro: " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + " |IPI: " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Finalidade: " + SelectedRow.Cells[26].Value.ToString() + " |ICMS: " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")) + " |ICMS ST: " + Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Báse de Cálculo ICMS: " + Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Base de Cálculo ICMS ST: " + Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Total Aprox. dos Trib.: " + Convert.ToDecimal(SelectedRow.Cells[31].Value).ToString("n2", new CultureInfo("pt-BR")));
                    }
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.txt");
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Número da NF;Tipo de Emitente;Código do Emit./Dest.;Nome do Emitente/Destinatário;CPF/CNPJ do Emitente/Destinatário;Total dos Produtos;Valor Total da NF;Série;Data de Emissão;Hora da Emissão;Data de Sáida;Hora de Saída;Modelo;Emissão;Descontos;Frete;Despesas;Chave;Observacao;Natureza da Operação/CFOP Predominante;Produto/Quantidade;Seguro;IPI;Finalidade;ICMS;ICMS ST");
                    for (int linha = 0; linha < dtDFE.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtDFE.Rows[linha];
                        //
                        string data_emissao;
                        if (SelectedRow.Cells[9].Value.ToString() == "" || SelectedRow.Cells[9].Value.ToString() == null)
                        {
                            data_emissao = "";
                        }
                        else
                        {
                            data_emissao = SelectedRow.Cells[9].Value.ToString().Remove(10);
                        }
                        //
                        string cpf_cnpj;
                        if (SelectedRow.Cells[5].Value.ToString() == "0")
                        {
                            cpf_cnpj = "";
                        }
                        else
                        {
                            cpf_cnpj = SelectedRow.Cells[5].Value.ToString();
                        }
                        //
                        string data_saida;
                        if (SelectedRow.Cells[11].Value.ToString() == "" || SelectedRow.Cells[11].Value.ToString() == null)
                        {
                            data_saida = "";
                        }
                        else
                        {
                            data_saida = SelectedRow.Cells[11].Value.ToString().Remove(10);
                        }
                        //
                        string numero;
                        if (SelectedRow.Cells[1].Value.ToString() == "" || SelectedRow.Cells[1].Value.ToString() == null)
                        {
                            numero = "";
                        }
                        else
                        {
                            numero = SelectedRow.Cells[1].Value.ToString();
                        }
                        //
                        string serie;
                        if (SelectedRow.Cells[8].Value.ToString() == "" || SelectedRow.Cells[8].Value.ToString() == null)
                        {
                            serie = "";
                        }
                        else
                        {
                            serie = SelectedRow.Cells[8].Value.ToString();
                        }
                        //
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24};{25};{26};{27};{28};{29}", SelectedRow.Cells[0].Value.ToString(), numero, SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), cpf_cnpj, Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), serie, data_emissao, SelectedRow.Cells[10].Value.ToString(), data_saida, SelectedRow.Cells[12].Value.ToString(), SelectedRow.Cells[13].Value.ToString(), SelectedRow.Cells[14].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[18].Value.ToString(), SelectedRow.Cells[19].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), SelectedRow.Cells[23].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[26].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[29].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[30].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[31].Value).ToString("n2", new CultureInfo("pt-BR"))));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de DFe");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.csv");
            }
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

        private void lblValorDespesas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Despesas: " + lblValorDespesas.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorBaseCalculo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorBaseCalculo_MouseLeave(object sender, EventArgs e)
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

        private void lblValorICMSST_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorICMSST_MouseLeave(object sender, EventArgs e)
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

        private void lblValorFrete_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorFrete_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDespesas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDespesas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorSeguro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorSeguro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorIPI_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorIPI_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorSeguro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seguro: " + lblValorSeguro.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorIPI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IPI: " + lblValorSeguro.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnConsultarTransportador_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 5))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtDFE.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnConsultarTransportador_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarTransportador_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                //
                pgbProgresso.Value = 0;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtDFE.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao2.Enabled = true;
                picbInterrogacao3.Enabled = true;
                btnSair.Enabled = true;
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtDFE.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao2.Enabled = true;
                picbInterrogacao3.Enabled = true;
                dtDFE.Select();
                //
                try
                {
                    if (_Trabalho == 0)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\DFe\DFe.pdf");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    //
                    pgbProgresso.Value = 0;
                    this.Cursor = Cursors.Default;
                    pgbProgresso.Visible = false;
                    lblProgresso.Visible = false;
                    dtDFE.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao2.Enabled = true;
                    picbInterrogacao3.Enabled = true;
                    btnSair.Enabled = true;
                }
            }
        }

        private void btnRelatorioTodos_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (Seven_Sistema.FrmInfImpressao Imp = new Seven_Sistema.FrmInfImpressao(42))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 0;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtDFE.Enabled = false;
                    dtDFE.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao2.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnExportar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExportar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnExportarTxt_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 1;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            grbBox1.Enabled = false;
            dtDFE.Enabled = false;
            dtDFE.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao2.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 2;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            grbBox1.Enabled = false;
            dtDFE.Enabled = false;
            dtDFE.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao2.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                if (SelectedRow.Cells[22].Value.ToString() == "")
                {
                    MessageBox.Show("O DFe selecionado não possui arquivo xml informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    Process.Start(SelectedRow.Cells[22].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
            }
        }

        private void btnXML_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnXML_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEnviar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                if (SelectedRow.Cells[32].Value.ToString() != "TRANSMITIDA")
                {
                    MessageBox.Show("Para enviar o DFe por e-mail é necessário que a situação seja\n[ TRANSMITIDA ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtDFE.Enabled = false;
                    dtDFE.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao2.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                    //
                    if (!File.Exists(SelectedRow.Cells[22].Value.ToString()))
                    {
                        MessageBox.Show("Não foi possível localizar o arquivo do dfe [ " + SelectedRow.Cells[0].Value.ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        this.Cursor = Cursors.Default;
                        pgbProgresso.Visible = false;
                        lblProgresso.Visible = false;
                        dtDFE.Enabled = true;
                        grbBox1.Enabled = true;
                        grbBox2.Enabled = true;
                        btnPesquisar.Enabled = true;
                        picbInterrogacao2.Enabled = true;
                        picbInterrogacao3.Enabled = true;
                        dtDFE.Select();
                        return;
                    }
                    //
                    string modelo = null;
                    if (SelectedRow.Cells[13].Value.ToString() == "55")
                    {
                        modelo = "NFe";
                    }
                    else if (SelectedRow.Cells[13].Value.ToString() == "65")
                    {
                        modelo = "NFCe";
                    }
                    //
                    TemporizadorDanfe.Start();
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
                    string destino_pdf = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\" + modelo + "_" + SelectedRow.Cells[1].Value.ToString() + ".pdf";
                    ACBrNFe.LimparLista();
                    ACBrNFe.CarregarXML(SelectedRow.Cells[22].Value.ToString());
                    var nomeArquivo = destino_pdf;
                    //
                    using (FileStream aStream = File.Create(nomeArquivo))
                    {
                        ACBrNFe.ImprimirPDF(aStream);
                        byte[] buffer = new Byte[aStream.Length];
                        await aStream.ReadAsync(buffer, 0, buffer.Length);
                        await aStream.FlushAsync();
                        aStream.Seek(0, SeekOrigin.End);
                        await aStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    //
                    string email_cliente_fornecedor = null;
                    if (SelectedRow.Cells[2].Value.ToString() == "CLIENTES")
                    {
                        if (SelectedRow.Cells[3].Value.ToString() != "0")
                        {
                            if (bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[3].Value.ToString()) == null)
                            {
                                MessageBox.Show("O Cliente/Consumidor não foi encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                email_cliente_fornecedor = null;
                            }
                            else
                            {
                                DataRow dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[3].Value.ToString()).Rows[0];
                                if (dr["email"].ToString() == "")
                                {
                                    MessageBox.Show("O Cliente/Consumidor não possui um e-mail cadastrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.None;
                                    email_cliente_fornecedor = null;
                                }
                                else
                                {
                                    email_cliente_fornecedor = dr["email"].ToString();
                                }
                            }
                        }
                        else
                        {
                            email_cliente_fornecedor = null;
                        }
                    }
                    else if (SelectedRow.Cells[2].Value.ToString() == "FORNECEDORES")
                    {
                        if (SelectedRow.Cells[3].Value.ToString() != "0")
                        {
                            if (bllFornecedor.Sel_F_Cod(SelectedRow.Cells[3].Value.ToString()) == null)
                            {
                                MessageBox.Show("O Fornecedor não foi encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.None;
                                email_cliente_fornecedor = null;
                            }
                            else
                            {
                                DataRow dr = bllFornecedor.Sel_F_Cod(SelectedRow.Cells[3].Value.ToString()).Rows[0];
                                if (dr["email"].ToString() == "")
                                {
                                    MessageBox.Show("O Fornecedor não possui um e-mail cadastrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.None;
                                    email_cliente_fornecedor = null;
                                }
                                else
                                {
                                    email_cliente_fornecedor = dr["email"].ToString();
                                }
                            }
                        }
                        else
                        {
                            email_cliente_fornecedor = null;
                        }
                    }
                    //
                    this.Cursor = Cursors.Default;
                    pgbProgresso.Visible = false;
                    lblProgresso.Visible = false;
                    dtDFE.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao2.Enabled = true;
                    picbInterrogacao3.Enabled = true;
                    dtDFE.Select();
                    //
                    pEnabled.Enabled = false;
                    using (FrmUtilEnviarEmail Email = new FrmUtilEnviarEmail(3, _Cod_PDV_Computador, _Usuario, SelectedRow.Cells[22].Value.ToString() + ";" + destino_pdf + ";", "Atenciosamente, " + bllMinhaEmpresa.Sel_Nome_Empresa() + " - " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), "Referente a " + modelo + " de número " + SelectedRow.Cells[1].Value.ToString(), email_cliente_fornecedor))
                    {
                        if (Email.ShowDialog() == DialogResult.Abort)
                        {
                            dtDFE.Select();
                        }
                    }
                    pEnabled.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviar.");
                }
            }
        }

        private void btnDanfeDFe_Click(object sender, EventArgs e)
        {
            try
            {
                string pergunta = "Deseja exportar os XML para enviar ao seu contador e/ou contabilidade?";

                if (_Exp_Contador == true)
                {
                    DialogResult = MessageBox.Show(pergunta, "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (DialogResult == DialogResult.Yes)
                    {
                        string diretorio = @"C:\Windows\Temp\Sistema SEVEN\\Exportacao_" + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("HH_mm_ss");
                        //
                        Directory.CreateDirectory(diretorio);
                        //
                        bool sucesso = true;
                        for (int i = 0; i < dtDFE.Rows.Count; i++)
                        {
                            DataGridViewRow SelectedRow = dtDFE.Rows[i];
                            //
                            if (bllDFe.Sel_Situacao_Emissao_DFe(SelectedRow.Cells[0].Value.ToString()) == true)
                            {
                                if (SelectedRow.Cells[22].Value.ToString() != "")
                                {
                                    string[] items = SelectedRow.Cells[22].Value.ToString().Split('\\');
                                    //
                                    if (File.Exists(SelectedRow.Cells[22].Value.ToString()) == true)
                                    {
                                        File.Copy(SelectedRow.Cells[22].Value.ToString(), diretorio + @"\" + items[7], true);
                                    }
                                    else
                                    {
                                        if (bllXML.Sel_Dados_XML(SelectedRow.Cells[0].Value.ToString()) != null)
                                        {
                                            DataRow drXML = bllXML.Sel_Dados_XML(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                            //
                                            if (File.Exists(diretorio + @"\" + items[7]) == true)
                                            {
                                                File.Delete(diretorio + @"\" + items[7]);
                                            }
                                            //
                                            File.WriteAllText(diretorio + @"\" + items[7], drXML["texto_xml"].ToString(), Encoding.UTF8);
                                        }
                                        else
                                        {
                                            sucesso = false;
                                            MessageBox.Show("DFe de código [ " + SelectedRow.Cells[0].Value.ToString() + " ] não foi localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            //
                                            MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    sucesso = false;
                                    MessageBox.Show("DFe de código [ " + SelectedRow.Cells[0].Value.ToString() + " ] não foi localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    //
                                    MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }
                            else
                            {
                                sucesso = false;
                                MessageBox.Show("DFe de código [ " + SelectedRow.Cells[0].Value.ToString() + " ] não incluído na exportação pois ou não possui o status [ Transmitida ] ou não é [ Próprio ] da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                DialogResult = MessageBox.Show("Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                //
                                MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        //
                        if (sucesso == true)
                        {
                            using (var doc = new PdfDocument())
                            {
                                var page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                var graphics = XGraphics.FromPdfPage(page);
                                var textFormatter1 = new XTextFormatter(graphics);
                                var textFormatter2 = new XTextFormatter(graphics);
                                var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                var fonte4 = new XFont("Microsoft Sans Serif", 9);
                                XPen pen1 = new XPen(XColors.LightBlue);
                                XPen pen = new XPen(XColors.Black);
                                DataRow dr;
                                //
                                short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                                //
                                if (bllClieCons._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                                {
                                    XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                                    graphics.DrawImage(imagem1, 10 + Margem_Esq, 7 + Margem_Topo, 100, 116);
                                }
                                //DATA
                                graphics.DrawRectangle(pen, XBrushes.White, 494 + Margem_Esq, 5 + Margem_Topo, 95, 122);
                                textFormatter2.DrawString("Criado em:", fonte4, XBrushes.Black, new XRect(515 + Margem_Esq, 10 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(DateTime.Now.ToShortDateString(), fonte1, XBrushes.Black, new XRect(510 + Margem_Esq, 22 + Margem_Topo, page.Width, page.Height));
                                //HORÁRIO                    
                                textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(527 + Margem_Esq, 72 + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(DateTime.Now.ToLongTimeString(), fonte1, XBrushes.Black, new XRect(516 + Margem_Esq, 84 + Margem_Topo, page.Width, page.Height));
                                //CABECALHO  DOCUMENTO
                                dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                if (!dr["nome"].ToString().Contains(" ") & dr["nome"].ToString().Length > 38)
                                {
                                    textFormatter1.DrawString(dr["nome"].ToString().Insert(38, Environment.NewLine), fonte1, XBrushes.Black, new XRect(115 + Margem_Esq, 7 + Margem_Topo, 370, 28));
                                }
                                else
                                {
                                    textFormatter1.DrawString(dr["nome"].ToString(), fonte1, XBrushes.Black, new XRect(115 + Margem_Esq, 7 + Margem_Topo, 370, 28));
                                }
                                //
                                textFormatter1.DrawString(dr["fantasia"].ToString() + Environment.NewLine + "CPF/CNPJ.: " + dr["cpf_cnpj"].ToString() + ", IE.: " + dr["ie_rg"].ToString() + Environment.NewLine + "End.: " + dr["endereco"].ToString() + Environment.NewLine + dr["complemento"].ToString() + ", " + dr["numero"].ToString() + Environment.NewLine + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + Environment.NewLine + "Tel.: " + dr["telefone"].ToString() + ", Cel.: " + dr["celular"].ToString() + Environment.NewLine + "E-mail.: " + dr["email"].ToString(), fonte2, XBrushes.Black, new XRect(115 + Margem_Esq, 35 + Margem_Topo, 370, 95));
                                //
                                textFormatter1.DrawString("Relatório de DFe", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                                textFormatter2.DrawString("CÓD.    EMISSÃO    SÉRIE/Nº NF    DATA DE EMISSÃO    EMIT./DEST.    MODELO    TOTAIS", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                                //           
                                //Linhas do datagrid
                                int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                                int ContadorPagina = 1;
                                int pagina = 16;
                                bool PrimeiraPagina = true;

                                int TotalPaginas = 1;//Numero de páginas do documento.
                                int registros = 37;
                                for (int i = 0; i < dtDFE.Rows.Count; i++)
                                {
                                    if (i == 16)
                                    {
                                        TotalPaginas = TotalPaginas + 1;
                                    }
                                    else if (i == registros)
                                    {
                                        registros = registros + 21;
                                        TotalPaginas = TotalPaginas + 1;
                                    }
                                }
                                //
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                //
                                for (int linha = 0; linha < dtDFE.Rows.Count; linha++)
                                {
                                    DataGridViewRow SelectedRow = dtDFE.Rows[linha];
                                    if (linha < 16 & PrimeiraPagina == true)
                                    {
                                        if (linha == dtDFE.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                                        {
                                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 202) + Margem_Topo, 75, 18));
                                            //
                                            textFormatter2.DrawString("Emissão:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Série/Nº NF:", fonte2, XBrushes.Black, new XRect(200 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            if (SelectedRow.Cells[8].Value.ToString() != "0")
                                            {
                                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + " / " + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(268 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            }
                                            //
                                            textFormatter2.DrawString("Data e Horário Emissão:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString().Remove(10) + " " + SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(453 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            //
                                            string cpf_cnpj;
                                            if (SelectedRow.Cells[5].Value.ToString() == "0" || SelectedRow.Cells[5].Value.ToString() == null || SelectedRow.Cells[5].Value.ToString() == "")
                                            {
                                                cpf_cnpj = null;
                                            }
                                            else
                                            {
                                                cpf_cnpj = "-" + SelectedRow.Cells[5].Value.ToString();
                                            }
                                            string cod_cons;
                                            if (SelectedRow.Cells[3].Value.ToString() == "0")
                                            {
                                                cod_cons = null;
                                            }
                                            else
                                            {
                                                cod_cons = SelectedRow.Cells[3].Value.ToString() + "-";
                                            }
                                            textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(cod_cons + SelectedRow.Cells[4].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(95 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Modelo:", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(483 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Produtos: " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desc.: " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Seg.: " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + "  IPI: " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Frete: " + Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desp.: " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS: " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS-ST: " + Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Total NF: " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, 18));
                                            //
                                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                            textFormatter2.DrawString("Total Produtos: " + lblValorTotalReal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString("Total NF: " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                            //
                                            Incrementar = 36 + Incrementar;//incrementando                               
                                        }
                                        else
                                        {
                                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 202) + Margem_Topo, 75, 18));
                                            //
                                            textFormatter2.DrawString("Emissão:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Série/Nº NF:", fonte2, XBrushes.Black, new XRect(200 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            if (SelectedRow.Cells[8].Value.ToString() != "0")
                                            {
                                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + " / " + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(268 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            }
                                            //
                                            textFormatter2.DrawString("Data e Horário Emissão:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString().Remove(10) + " " + SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(453 + Margem_Esq, (Incrementar + 202) + Margem_Topo, page.Width, page.Height));
                                            //
                                            string cpf_cnpj;
                                            if (SelectedRow.Cells[5].Value.ToString() == "0" || SelectedRow.Cells[5].Value.ToString() == null || SelectedRow.Cells[5].Value.ToString() == "")
                                            {
                                                cpf_cnpj = null;
                                            }
                                            else
                                            {
                                                cpf_cnpj = "-" + SelectedRow.Cells[5].Value.ToString();
                                            }
                                            string cod_cons;
                                            if (SelectedRow.Cells[3].Value.ToString() == "0")
                                            {
                                                cod_cons = null;
                                            }
                                            else
                                            {
                                                cod_cons = SelectedRow.Cells[3].Value.ToString() + "-";
                                            }
                                            textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(cod_cons + SelectedRow.Cells[4].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(95 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Modelo:", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(483 + Margem_Esq, (Incrementar + 214) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Produtos: " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desc.: " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Seg.: " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + "  IPI: " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Frete: " + Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desp.: " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS: " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS-ST: " + Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Total NF: " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 225) + Margem_Topo, page.Width, 18));
                                            //
                                            Incrementar = 36 + Incrementar;//incrementando                               
                                        }
                                        //
                                        if (linha == (pagina - 1) & dtDFE.Rows.Count > 16)
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            ContadorPagina = ContadorPagina + 1;
                                            pagina = pagina + 22;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                            fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                            fonte4 = new XFont("Microsoft Sans Serif", 9);
                                            pen1 = new XPen(XColors.LightBlue);
                                            pen = new XPen(XColors.Black);
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            //
                                            textFormatter1.DrawString("Relatório de DFe", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                            textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                            textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                        }
                                    }
                                    else
                                    {
                                        if (linha == (pagina - 1))
                                        {
                                            PrimeiraPagina = false;
                                            Incrementar = 0;
                                            ContadorPagina = ContadorPagina + 1;
                                            pagina = pagina + 21;
                                            page = doc.AddPage();
                                            page.Width = 595;
                                            page.Height = 842;
                                            graphics = XGraphics.FromPdfPage(page);
                                            textFormatter1 = new XTextFormatter(graphics);
                                            textFormatter2 = new XTextFormatter(graphics);
                                            fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                            fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                            fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                            fonte4 = new XFont("Microsoft Sans Serif", 9);
                                            pen1 = new XPen(XColors.LightBlue);
                                            pen = new XPen(XColors.Black);
                                            textFormatter1.Alignment = XParagraphAlignment.Center;
                                            //
                                            textFormatter1.DrawString("Relatório de DFe", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                            textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                            textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                                        }
                                        //
                                        if (linha == dtDFE.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                                        {
                                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 24) + Margem_Topo, 75, 18));
                                            //
                                            textFormatter2.DrawString("Emissão:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Série/Nº NF:", fonte2, XBrushes.Black, new XRect(200 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            if (SelectedRow.Cells[8].Value.ToString() != "0")
                                            {
                                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + " / " + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(268 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            }
                                            //
                                            textFormatter2.DrawString("Data e Horário Emissão:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString().Remove(10) + " " + SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(453 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            //
                                            string cpf_cnpj;
                                            if (SelectedRow.Cells[5].Value.ToString() == "0" || SelectedRow.Cells[5].Value.ToString() == null || SelectedRow.Cells[5].Value.ToString() == "")
                                            {
                                                cpf_cnpj = null;
                                            }
                                            else
                                            {
                                                cpf_cnpj = "-" + SelectedRow.Cells[5].Value.ToString();
                                            }
                                            string cod_cons;
                                            if (SelectedRow.Cells[3].Value.ToString() == "0")
                                            {
                                                cod_cons = null;
                                            }
                                            else
                                            {
                                                cod_cons = SelectedRow.Cells[3].Value.ToString() + "-";
                                            }
                                            textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(cod_cons + SelectedRow.Cells[4].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(95 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Modelo:", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(483 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Produtos: " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desc.: " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Seg.: " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + "  IPI: " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Frete: " + Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desp.: " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS: " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS-ST: " + Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Total NF: " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, 18));
                                            //
                                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                            textFormatter2.DrawString("Total Produtos: " + lblValorTotalReal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString("Total NF: " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                            //
                                            Incrementar = 36 + Incrementar;//incrementando                               
                                        }
                                        else
                                        {
                                            graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                            textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 24) + Margem_Topo, 75, 18));
                                            //
                                            textFormatter2.DrawString("Emissão:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Série/Nº NF:", fonte2, XBrushes.Black, new XRect(200 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            if (SelectedRow.Cells[8].Value.ToString() != "0")
                                            {
                                                textFormatter2.DrawString(SelectedRow.Cells[8].Value.ToString() + " / " + SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(268 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            }
                                            //
                                            textFormatter2.DrawString("Data e Horário Emissão:", fonte2, XBrushes.Black, new XRect(350 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[9].Value.ToString().Remove(10) + " " + SelectedRow.Cells[10].Value.ToString(), fonte4, XBrushes.Black, new XRect(453 + Margem_Esq, (Incrementar + 24) + Margem_Topo, page.Width, page.Height));
                                            //
                                            string cpf_cnpj;
                                            if (SelectedRow.Cells[5].Value.ToString() == "0" || SelectedRow.Cells[5].Value.ToString() == null || SelectedRow.Cells[5].Value.ToString() == "")
                                            {
                                                cpf_cnpj = null;
                                            }
                                            else
                                            {
                                                cpf_cnpj = "-" + SelectedRow.Cells[5].Value.ToString();
                                            }
                                            string cod_cons;
                                            if (SelectedRow.Cells[3].Value.ToString() == "0")
                                            {
                                                cod_cons = null;
                                            }
                                            else
                                            {
                                                cod_cons = SelectedRow.Cells[3].Value.ToString() + "-";
                                            }
                                            textFormatter2.DrawString("Nome/Razão Social:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(cod_cons + SelectedRow.Cells[4].Value.ToString() + cpf_cnpj, fonte4, XBrushes.Black, new XRect(95 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Modelo:", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                            textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(483 + Margem_Esq, (Incrementar + 35) + Margem_Topo, page.Width, page.Height));
                                            //
                                            textFormatter2.DrawString("Produtos: " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desc.: " + Convert.ToDecimal(SelectedRow.Cells[15].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Seg.: " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + "  IPI: " + Convert.ToDecimal(SelectedRow.Cells[25].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Frete: " + Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Desp.: " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS: " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")) + "  ICMS-ST: " + Convert.ToDecimal(SelectedRow.Cells[28].Value).ToString("n2", new CultureInfo("pt-BR")) + "  Total NF: " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 47) + Margem_Topo, page.Width, 18));
                                            //
                                            Incrementar = 36 + Incrementar;//incrementando                               
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
                                doc.Save(diretorio + @"\Relatorio.pdf");
                            }
                            //
                            string destino = @"C:\Windows\Temp\Sistema SEVEN\Exportacao_" + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("HH_mm_ss") + ".zip";
                            //
                            if (File.Exists(destino))
                            {
                                File.Delete(destino);
                            }
                            //
                            ZipFile.CreateFromDirectory(diretorio, destino);
                            //
                            pEnabled.Enabled = false;
                            using (FrmUtilEnviarEmail Mail = new FrmUtilEnviarEmail(1, _Cod_PDV_Computador, _Usuario, destino + ";", "Segue em anexo os arquivos XML.", "Arquivos XML", bllMinhaEmpresa.Sel_Email_Contador_Contabilidade()))
                            {
                                if (Mail.ShowDialog() == DialogResult.OK)
                                {
                                    dtDFE.Select();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (DialogResult == DialogResult.No)
                    {
                        using (FolderBrowserDialog folder = new FolderBrowserDialog())
                        {
                            folder.Description = "Selecione uma Pasta";
                            //
                            if (folder.ShowDialog() == DialogResult.OK & !string.IsNullOrEmpty(folder.SelectedPath))
                            {
                                string comp_diretorio = @"\Exportacao_" + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("HH_mm_ss");
                                //
                                Directory.CreateDirectory(folder.SelectedPath + comp_diretorio);
                                //
                                bool sucesso = true;
                                for (int i = 0; i < dtDFE.Rows.Count; i++)
                                {
                                    DataGridViewRow SelectedRow = dtDFE.Rows[i];
                                    //
                                    string[] items = SelectedRow.Cells[22].Value.ToString().Split('\\');
                                    //
                                    if (File.Exists(SelectedRow.Cells[22].Value.ToString()) == true)
                                    {
                                        File.Copy(SelectedRow.Cells[22].Value.ToString(), folder.SelectedPath + comp_diretorio + @"\" + items[7], true);
                                    }
                                    else
                                    {
                                        if (bllXML.Sel_Dados_XML(SelectedRow.Cells[0].Value.ToString()) != null)
                                        {
                                            DataRow drXML = bllXML.Sel_Dados_XML(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                            //
                                            if (File.Exists(folder.SelectedPath + comp_diretorio + @"\" + items[7]) == true)
                                            {
                                                File.Delete(folder.SelectedPath + comp_diretorio + @"\" + items[7]);
                                            }
                                            //
                                            File.WriteAllText(folder.SelectedPath + comp_diretorio + @"\" + items[7], drXML["texto_xml"].ToString(), Encoding.UTF8);
                                        }
                                        else
                                        {
                                            sucesso = false;
                                            MessageBox.Show("DFe de código [ " + SelectedRow.Cells[0].Value.ToString() + " ] não foi localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            DialogResult = MessageBox.Show("Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (DialogResult == DialogResult.No)
                                            {
                                                MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                return;
                                            }
                                        }
                                    }
                                }
                                //
                                if (sucesso == true)
                                {
                                    MessageBox.Show("Arquivos exportados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (FolderBrowserDialog folder = new FolderBrowserDialog())
                    {
                        folder.Description = "Selecione uma Pasta";
                        //
                        if (folder.ShowDialog() == DialogResult.OK & !string.IsNullOrEmpty(folder.SelectedPath))
                        {
                            string comp_diretorio = @"\Exportacao_" + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("HH_mm_ss");
                            //
                            Directory.CreateDirectory(folder.SelectedPath + comp_diretorio);
                            //
                            bool sucesso = true;
                            for (int i = 0; i < dtDFE.Rows.Count; i++)
                            {
                                DataGridViewRow SelectedRow = dtDFE.Rows[i];
                                //
                                string[] items = SelectedRow.Cells[22].Value.ToString().Split('\\');
                                //
                                if (File.Exists(SelectedRow.Cells[22].Value.ToString()) == true)
                                {
                                    File.Copy(SelectedRow.Cells[22].Value.ToString(), folder.SelectedPath + comp_diretorio + @"\" + items[7], true);
                                }
                                else
                                {
                                    if (bllXML.Sel_Dados_XML(SelectedRow.Cells[0].Value.ToString()) != null)
                                    {
                                        DataRow drXML = bllXML.Sel_Dados_XML(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                                        //
                                        if (File.Exists(folder.SelectedPath + comp_diretorio + @"\" + items[7]) == true)
                                        {
                                            File.Delete(folder.SelectedPath + comp_diretorio + @"\" + items[7]);
                                        }
                                        //
                                        File.WriteAllText(folder.SelectedPath + comp_diretorio + @"\" + items[7], drXML["texto_xml"].ToString(), Encoding.UTF8);
                                    }
                                    else
                                    {
                                        sucesso = false;
                                        MessageBox.Show("O DFe de código [ " + SelectedRow.Cells[0].Value.ToString() + " ] não foi localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        DialogResult = MessageBox.Show("Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (DialogResult == DialogResult.No)
                                        {
                                            MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            return;
                                        }
                                    }
                                }
                            }
                            //
                            if (sucesso == true)
                            {
                                MessageBox.Show("Arquivos exportados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Alguns arquivos não foram exportados corretamente, é necessário verificar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExportarXML.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExportarXML.");
                }
            }
            pEnabled.Enabled = true;
        }


        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbTipo.Select();
            }
        }

        private void cbbSituacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSituacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNumeroNF_CheckedChanged(object sender, EventArgs e)
        {
            mtxtChave.Visible = false;
            lblFin.Enabled = true;
            cbbFinalidade.Enabled = true;
            lblLocalizarEmitente.Enabled = true;
            cbbTipoEmitente.Enabled = true;
            txtpCodigo.Visible = true;
            lblPesquisar.Text = "Digite o número da nf:";
            lblPesquisar.Location = new Point(728, 19);
            txtpCodigo.Text = null;
            Limpar_OutrosFiltros();
            lblDataEntrada.Enabled = true;
            mtxtpDataEmissao.Enabled = true;
            lblAte.Enabled = true;
            mtxtpDataEmissao1.Enabled = true;
            btnSelecionarData.Enabled = true;
            mtxtHorarioEmissao.Enabled = true;
            mtxtHorarioEmissao1.Enabled = true;
            lblDataSaida.Enabled = true;
            mtxtpDataSaida.Enabled = true;
            lblAte1.Enabled = true;
            mtxtpDataSaida1.Enabled = true;
            btnSelecionarData1.Enabled = true;
            mtxtHorarioSaida.Enabled = true;
            mtxtHorarioSaida1.Enabled = true;
            cbbTipo.Enabled = true;
            lblEmissao.Enabled = true;
            cbbEmitenteDestinatario.Enabled = true;
            lblEmitenteDestinatario.Enabled = true;
            btnProcurarEmitDest.Enabled = true;
            cbbProduto.Enabled = true;
            lbProdutoServico.Enabled = true;
            btnProcurarProduto.Enabled = true;
            lblModelo.Enabled = true;
            cbbModelo.Enabled = true;
            lblSituacao.Enabled = true;
            cbbSituacao.Enabled = true;
            cbbCFOPNaturezaOp.Enabled = true;
            lblCFOPNatOp.Enabled = true;
            btnProcurarCFOPNaturezaOp.Enabled = true;
            btnLimpar.Enabled = true;
            txtpCodigo.Select();
        }

        private void rbtnNumeroNF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNumeroNF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarPagamento_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];

                using (FrmConsultarPagamento Pag = new FrmConsultarPagamento(SelectedRow.Cells[0].Value.ToString(), 5))
                {
                    if (Pag.ShowDialog() == DialogResult.Abort)
                    {
                        dtDFE.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultaPagamento.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnConsultarReferencias_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarReferencias_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarReferencias_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];

                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 6))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtDFE.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0 & bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == true)
                {
                    MessageBox.Show("Não é possível Editar DFe porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtDFE.Select();
                }
                else if (SelectedRow.Cells[32].Value.ToString() == "TRANSMITIDA" || SelectedRow.Cells[32].Value.ToString() == "CANCELADA" || SelectedRow.Cells[32].Value.ToString() == "INUTILIZADA")
                {
                    MessageBox.Show("Não é possível editar DFe que já tenha sido enviado para a sefaz.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                    //
                    byte formulario = 3;
                    if (SelectedRow.Cells[38].Value.ToString() != "0")
                    {
                        formulario = 4;
                    }
                    //
                    using (FrmCadNFeNFCe NFe = new FrmCadNFeNFCe(_Usuario, _Cod_PDV_Computador, formulario, null, null, SelectedRow.Cells[0].Value.ToString(), 0, false))
                    {
                        if (NFe.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                    //
                    btnPesquisar_Click(sender, e);
                    //
                    if (dtDFE.DataSource != null)
                    {
                        foreach (DataGridViewRow row in dtDFE.Rows)
                        {
                            if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                            {
                                row.Selected = true;
                                dtDFE.CurrentCell = row.Cells[0];
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnEditarDFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEditarDFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodVenda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodVenda_CheckedChanged(object sender, EventArgs e)
        {
            mtxtChave.Visible = false;
            lblFin.Enabled = true;
            cbbFinalidade.Enabled = true;
            lblLocalizarEmitente.Enabled = true;
            cbbTipoEmitente.Enabled = true;
            txtpCodigo.Visible = true;
            lblPesquisar.Text = "Digite o código da venda:";
            lblPesquisar.Location = new Point(707, 19);
            txtpCodigo.Text = null;
            Limpar_OutrosFiltros();
            lblDataEntrada.Enabled = true;
            mtxtpDataEmissao.Enabled = true;
            lblAte.Enabled = true;
            mtxtpDataEmissao1.Enabled = true;
            btnSelecionarData.Enabled = true;
            mtxtHorarioEmissao.Enabled = true;
            mtxtHorarioEmissao1.Enabled = true;
            lblDataSaida.Enabled = true;
            mtxtpDataSaida.Enabled = true;
            lblAte1.Enabled = true;
            mtxtpDataSaida1.Enabled = true;
            btnSelecionarData1.Enabled = true;
            mtxtHorarioSaida.Enabled = true;
            mtxtHorarioSaida1.Enabled = true;
            cbbTipo.Enabled = true;
            lblEmissao.Enabled = true;
            cbbEmitenteDestinatario.Enabled = true;
            lblEmitenteDestinatario.Enabled = true;
            btnProcurarEmitDest.Enabled = true;
            cbbProduto.Enabled = true;
            lbProdutoServico.Enabled = true;
            btnProcurarProduto.Enabled = true;
            lblModelo.Enabled = true;
            cbbModelo.Enabled = true;
            lblSituacao.Enabled = true;
            cbbSituacao.Enabled = true;
            cbbCFOPNaturezaOp.Enabled = true;
            lblCFOPNatOp.Enabled = true;
            btnProcurarCFOPNaturezaOp.Enabled = true;
            btnLimpar.Enabled = true;
            txtpCodigo.Select();
        }

        private void rbtnCodDevolucao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodDevolucao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodDevolucao_CheckedChanged(object sender, EventArgs e)
        {
            mtxtChave.Visible = false;
            lblFin.Enabled = true;
            cbbFinalidade.Enabled = true;
            lblLocalizarEmitente.Enabled = true;
            cbbTipoEmitente.Enabled = true;
            txtpCodigo.Visible = true;
            lblPesquisar.Text = "Digite o código da devolução:";
            lblPesquisar.Location = new Point(683, 19);
            txtpCodigo.Text = null;
            Limpar_OutrosFiltros();
            lblDataEntrada.Enabled = true;
            mtxtpDataEmissao.Enabled = true;
            lblAte.Enabled = true;
            mtxtpDataEmissao1.Enabled = true;
            btnSelecionarData.Enabled = true;
            mtxtHorarioEmissao.Enabled = true;
            mtxtHorarioEmissao1.Enabled = true;
            lblDataSaida.Enabled = true;
            mtxtpDataSaida.Enabled = true;
            lblAte1.Enabled = true;
            mtxtpDataSaida1.Enabled = true;
            btnSelecionarData1.Enabled = true;
            mtxtHorarioSaida.Enabled = true;
            mtxtHorarioSaida1.Enabled = true;
            cbbTipo.Enabled = true;
            lblEmissao.Enabled = true;
            cbbEmitenteDestinatario.Enabled = true;
            lblEmitenteDestinatario.Enabled = true;
            btnProcurarEmitDest.Enabled = true;
            cbbProduto.Enabled = true;
            lbProdutoServico.Enabled = true;
            btnProcurarProduto.Enabled = true;
            lblModelo.Enabled = true;
            cbbModelo.Enabled = true;
            lblSituacao.Enabled = true;
            cbbSituacao.Enabled = true;
            cbbCFOPNaturezaOp.Enabled = true;
            lblCFOPNatOp.Enabled = true;
            btnProcurarCFOPNaturezaOp.Enabled = true;
            btnLimpar.Enabled = true;
            txtpCodigo.Select();
        }


        private void lblBcICMS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BC ICMS: " + lblValorBcICMS.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorAproxTrib_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trib. Aprox: " + lblValorAproxTrib.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorBcSt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BC ICMS ST: " + lblValorBcSt.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorBcSt_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorBcSt_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorAproxTrib_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorAproxTrib_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblBcICMS_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblBcICMS_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void TemporizadorDanfe_Tick(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pEnabled.Enabled = true;
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Tick do botão TemporizadorDanfe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Tick do botão TemporizadorDanfe.");
                }
            }
        }

        private void mtxtChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtChave_Enter(object sender, EventArgs e)
        {
            mtxtChave.BackColor = Color.LightBlue;
        }

        private void mtxtChave_Leave(object sender, EventArgs e)
        {
            mtxtChave.BackColor = Color.White;
        }

        private void rbtnChave_CheckedChanged(object sender, EventArgs e)
        {
            mtxtChave.Visible = true;
            lblFin.Enabled = false;
            cbbFinalidade.Enabled = false;
            lblLocalizarEmitente.Enabled = false;
            cbbTipoEmitente.Enabled = false;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Digite a chave:";
            lblPesquisar.Location = new Point(463, 19);
            txtpCodigo.Text = null;
            Limpar_OutrosFiltros();
            lblDataEntrada.Enabled = false;
            mtxtpDataEmissao.Enabled = false;
            lblAte.Enabled = false;
            mtxtpDataEmissao1.Enabled = false;
            btnSelecionarData.Enabled = false;
            mtxtHorarioEmissao.Enabled = false;
            mtxtHorarioEmissao1.Enabled = false;
            lblDataSaida.Enabled = false;
            mtxtpDataSaida.Enabled = false;
            lblAte1.Enabled = false;
            mtxtpDataSaida1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            mtxtHorarioSaida.Enabled = false;
            mtxtHorarioSaida1.Enabled = false;
            cbbTipo.Enabled = false;
            lblEmissao.Enabled = false;
            cbbEmitenteDestinatario.Enabled = false;
            lblEmitenteDestinatario.Enabled = false;
            btnProcurarEmitDest.Enabled = false;
            cbbProduto.Enabled = false;
            lbProdutoServico.Enabled = false;
            btnProcurarProduto.Enabled = false;
            lblModelo.Enabled = false;
            cbbModelo.Enabled = false;
            lblSituacao.Enabled = false;
            cbbSituacao.Enabled = false;
            cbbCFOPNaturezaOp.Enabled = false;
            lblCFOPNatOp.Enabled = false;
            btnProcurarCFOPNaturezaOp.Enabled = false;
            btnLimpar.Enabled = false;
            mtxtChave.Select();
        }

        private void rbtnChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                if (!File.Exists(SelectedRow.Cells[22].Value.ToString()))
                {
                    MessageBox.Show("Não foi possível localizar o arquivo do dfe [ " + SelectedRow.Cells[0].Value.ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtDFE.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    pEnabled.Enabled = false;
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
                    string modelo = null;
                    if (SelectedRow.Cells[13].Value.ToString() == "55")
                    {
                        modelo = "NFe";
                    }
                    else if (SelectedRow.Cells[13].Value.ToString() == "65")
                    {
                        modelo = "NFCe";
                    }
                    //
                    string destino_pdf = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\" + modelo + "_" + SelectedRow.Cells[1].Value.ToString() + ".pdf";
                    ACBrNFe.LimparLista();
                    ACBrNFe.CarregarXML(SelectedRow.Cells[22].Value.ToString());
                    var nomeArquivo = destino_pdf;
                    //
                    for (int i = 0; i < 2; i++)
                    {
                        using (FileStream aStream = File.Create(nomeArquivo))
                        {
                            ACBrNFe.ImprimirPDF(aStream);
                            byte[] buffer = new Byte[aStream.Length];
                            await aStream.ReadAsync(buffer, 0, buffer.Length);
                            await aStream.FlushAsync();
                            aStream.Seek(0, SeekOrigin.End);
                            await aStream.WriteAsync(buffer, 0, buffer.Length);
                        }
                    }
                    //
                    Process.Start(destino_pdf);
                    //
                    this.Cursor = Cursors.Default;
                    pgbProgresso.Visible = false;
                    lblProgresso.Visible = false;
                    dtDFE.Select();
                    //
                    pEnabled.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                pEnabled.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerarDanfe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerarDanfe.");
                }
            }
        }

        private void btnGerarDanfe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnGerarDanfe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void TemporizadorGerarDanfe_Tick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pEnabled.Enabled = true;
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Tick do botão TemporizadorGerarDanfe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Tick do botão TemporizadorGerarDanfe.");
                }
            }
        }

        private void btnGerarContaPagar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                DialogResult = MessageBox.Show("Deseja criar um registro de Conta a Pagar apartir deste documento DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (bllDFe.Sel_Dfe_Existe_Conta_Pagar(SelectedRow.Cells[0].Value.ToString()) == true)
                    {
                        DialogResult = MessageBox.Show("Já existe uma ou mais Conta a Pagar com os mesmos dados do DFe selecionado.\n\nDeseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.No)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            return;
                        }
                    }
                    //
                    DialogResult = MessageBox.Show("Existe parcelamento no valor do DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        bllItem_Parcelamento_DFe.Excluir_Todos_Item_Parcelamento_DFe_Temp(bllConexao._Codigo_Conexao);
                        //
                        using (FrmQuantidade Quant = new FrmQuantidade(2, "1"))
                        {
                            if (Quant.ShowDialog() == DialogResult.OK)
                            {
                                bllItem_Parcelamento_DFe._Data_Vencimento_Multiplicada = SelectedRow.Cells[9].Value.ToString().Remove(10);
                                //
                                for (int i = 0; i < Convert.ToInt32(bllItem_Parcelamento_DFe._Quantidade); i++)
                                {
                                    bllItem_Parcelamento_DFe.Salvar((i + 1).ToString(), SelectedRow.Cells[7].Value.ToString(), bllConexao._Codigo_Conexao);
                                }
                                //
                                bllItem_Parcelamento_DFe._Quantidade = null;
                                bllItem_Parcelamento_DFe._Data_Vencimento_Multiplicada = null;
                                //
                                using (FrmCadDFeParcelamento Parc = new FrmCadDFeParcelamento(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), _Usuario, _Cod_PDV_Computador))
                                {
                                    if (Parc.ShowDialog() == DialogResult.OK)
                                    {
                                        dtDFE.Select();
                                    }
                                    else
                                    {
                                        dtDFE.Select();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        DataRow dr = bllDFe.Sel_Nfe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                        //
                        string modelo = null;
                        string modelo1 = null;
                        if (dr["modelo"].ToString() == "55")
                        {
                            modelo = "MODELO 55(NFe)";
                            modelo1 = "NFe";

                        }
                        else if (dr["modelo"].ToString() == "65")
                        {
                            modelo = "MODELO 65(NFCe)";
                            modelo1 = "NFCe";
                        }
                        //
                        bllContasPagar.Salvar(null, null, "1", "DFE " + modelo + " DE NÚMERO " + dr["numero_nf"].ToString() + " SÉRIE " + dr["serie"].ToString(), null, dr["data_emissao"].ToString().Remove(10), dr["data_emissao"].ToString().Remove(10), modelo1, dr["tipo_emitente_destinatario"].ToString(), dr["id_emitente_Destinatario"].ToString() + "—" + dr["nome_emitente_destinatario"].ToString(), dr["valor_total_nf"].ToString(), null, null, null, null, null, null, null, null, "2—CONTAS A PAGAR NO GERAL", "2—GERAL", null, "DFE", SelectedRow.Cells[0].Value.ToString(), null);
                        //
                        string codigo = bllContasPagar.Sel_Ultimo_Cod_Conta_Pagar();
                        //
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        //
                        if (bllUsuario.Sel_Criar_Lemb_Conta_Pagar_Usuario(_Usuario) == true)
                        {
                            dr = bllContasPagar.Sel_Conta_Codigo(codigo).Rows[0];
                            //
                            string data = null;
                            if (Convert.ToDateTime(dr["data_vencimento"].ToString()) < DateTime.Now)
                            {
                                data = DateTime.Now.ToShortDateString();
                            }
                            else
                            {
                                data = dr["data_vencimento"].ToString().Remove(10);
                            }
                            DialogResult = MessageBox.Show("Deseja também criar um lembrete de Conta a Pagar apartir deste documento DFe?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                using (FrmUtilCadLembrete Lembrete = new FrmUtilCadLembrete(null, data, null, "LEMBRETE DE CONTA A PAGAR", "LEMBRETE DE CONTA A PAGAR DE CÓDIGO " + codigo + "  NO VALOR DE " + Convert.ToDecimal(dr["valor_real"]).ToString("n2", new CultureInfo("pt-BR")) + " R$ DO " + dr["tipo_emitente"].ToString() + " " + dr["id_emitente"].ToString() + "-" + dr["nome_emitente"].ToString() + ".", null, false, _Usuario, _Cod_PDV_Computador, 2, "CONTAS A PAGAR", codigo))
                                {
                                    if (Lembrete.ShowDialog() == DialogResult.OK)
                                    {
                                        this.DialogResult = DialogResult.None;
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
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerarContaPagar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnGerarContaPagar.");
                }
            }
        }

        private void btnImprimirDanfe_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtDFE.Rows[dtDFE.CurrentRow.Index];
                //
                if (SelectedRow.Cells[13].Value.ToString() == "65")
                {
                    bllDFe.GerarDANFE(SelectedRow.Cells[0].Value.ToString(), _Cod_PDV_Computador, false);
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja imprimir o DANFE no modelo A4?", "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.None;
                        bllDFe.GerarDANFE(SelectedRow.Cells[0].Value.ToString(), _Cod_PDV_Computador, false);
                    }
                    else if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        bllDFe.GerarDANFE(SelectedRow.Cells[0].Value.ToString(), _Cod_PDV_Computador, true);
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnImprimir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnImprimir.");
                }
            }
        }

        private void pEnabled_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mtxtpDataSaida.Text = null;
            mtxtpDataSaida1.Text = null;
            mtxtHorarioSaida.Text = null;
            mtxtHorarioSaida1.Text = null;
            mtxtpDataEmissao.Text = null;
            mtxtpDataEmissao1.Text = null;
            mtxtHorarioEmissao.Text = null;
            mtxtHorarioEmissao1.Text = null;
            cbbModelo.Text = null;
            cbbSituacao.Text = null;
            cbbTipo.Text = null;
            cbbTipoEmitente.Text = null;
            cbbEmitenteDestinatario.Text = null;
            cbbProduto.Text = null;
            cbbCFOPNaturezaOp.Text = null;
            cbbFinalidade.Text = null;


        }
    }
}
