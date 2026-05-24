using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelContaPagar : Form
    {
        public FrmRelContaPagar(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private byte _Trabalho;
        private string _Cod_PDV_Computador;

        private void Limpar_OutrosFiltros()
        {
            mtxtpDataEmi.Text = null;
            mtxtpDataEmi1.Text = null;
            mtxtpDataVenc.Text = null;
            mtxtpDataVenc1.Text = null;
            mtxtDataPag.Text = null;
            mtxtDataPag1.Text = null;
            cbbpGrupo.Text = null;
            cbbpSubGrupo.Text = null;
            cbbpTipo.Text = null;
        }

        private void FrmOpeBaixaContaPagar_Load(object sender, EventArgs e)
        {
            try
            {
                bllContasPagar._FrmRelContaPagar_Ativo = true;
                //
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelContaPagar iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelContaPagar iniciado.");
                }
                //
                rbtnDescricao.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelContaPagar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelContaPagar.");
                }
                this.Close();
            }
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodBarra_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodBarra_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNContratoMatriculaServico_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNContratoMatriculaServico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnNDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnNDocumento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTodas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipoEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipoEmitente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpEmitente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpEmitente_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpEmitente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpEmitente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnpProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnpProcurar_MouseLeave(object sender, EventArgs e)
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

        private void btnSelecionarData2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpTipo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpTipo_DropDownClosed(object sender, EventArgs e)
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

        private void lblValorRecebido_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorRecebido_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorAReceber_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorAReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnBaixaRegistro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnBaixaRegistro_MouseLeave(object sender, EventArgs e)
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

        private void btnReciboRegistro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnReciboRegistro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void mtxtpDataEmi_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmi.Text != "")
            {
                try
                {
                    mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmi.Text);

                    mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmi1.Text != "")
                    {
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmi.Text) > Convert.ToDateTime(mtxtpDataEmi1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmi.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmi.");
                    }
                    mtxtpDataEmi.Text = null;
                }
            }
            mtxtpDataEmi.BackColor = Color.White;
        }

        private void mtxtpDataEmi1_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmi1.Text != "")
            {
                try
                {
                    mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmi1.Text);

                    mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmi.Text != "")
                    {
                        mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmi.Text) > Convert.ToDateTime(mtxtpDataEmi1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmi1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmi1.");
                    }
                    mtxtpDataEmi1.Text = null;
                }
            }
            mtxtpDataEmi1.BackColor = Color.White;
        }

        private void mtxtpDataVenc_Leave(object sender, EventArgs e)
        {
            mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVenc.Text != "")
            {
                try
                {
                    mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataVenc.Text);

                    mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataVenc1.Text != "")
                    {
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataVenc.Text) > Convert.ToDateTime(mtxtpDataVenc1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataVenc.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc.");
                    }
                    mtxtpDataVenc.Text = null;
                }
            }
            mtxtpDataVenc.BackColor = Color.White;
        }

        private void mtxtpDataVenc1_Leave(object sender, EventArgs e)
        {
            mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVenc1.Text != "")
            {
                try
                {
                    mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataVenc1.Text);

                    mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataVenc.Text != "")
                    {
                        mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataVenc1.Text) < Convert.ToDateTime(mtxtpDataVenc.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataVenc1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc1.");
                    }
                    mtxtpDataVenc1.Text = null;
                }
            }
            mtxtpDataVenc1.BackColor = Color.White;
        }

        private void mtxtpDataEmi_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmi.BackColor = Color.LightBlue;
        }

        private void mtxtpDataEmi1_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmi1.BackColor = Color.LightBlue;
        }

        private void mtxtpDataVenc_Enter(object sender, EventArgs e)
        {
            mtxtpDataVenc.BackColor = Color.LightBlue;
        }

        private void mtxtpDataVenc1_Enter(object sender, EventArgs e)
        {
            mtxtpDataVenc1.BackColor = Color.LightBlue;
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(1))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataEmi1.Select();
                    mtxtpDataEmi.Text = bllContasPagar._Data_DatePicker1;
                    mtxtpDataEmi1.Text = bllContasPagar._Data_DatePicker2;
                }
            }
            pPanel.Enabled = true;
        }

        private void btnSelecionarData2_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(1))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataVenc1.Select();
                    mtxtpDataVenc.Text = bllContasPagar._Data_DatePicker1;
                    mtxtpDataVenc1.Text = bllContasPagar._Data_DatePicker2;
                }
            }
            pPanel.Enabled = true;
        }

        private void mtxtpDataEmi_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmi.Text == "")
            {
                mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmi.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmi1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmi1.Text == "")
            {
                mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmi1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataVenc_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVenc.Text == "")
            {
                mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataVenc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataVenc1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVenc1.Text == "")
            {
                mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataVenc1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblDataPagamentos.Enabled = false;
            cbbTabela.Visible = false;
            lblEscolha.Visible = false;
            lblAte2.Enabled = false;
            mtxtDataPag.Enabled = false;
            mtxtDataPag1.Enabled = false;
            btnSelecionarData3.Enabled = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblGrupos.Enabled = false;
            cbbpGrupo.Enabled = false;
            lblSubgrupos.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            txtpContratoMatServ.Visible = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData2.Enabled = false;
            lblSituacao.Enabled = false;
            cbbpTipo.Enabled = false;
            Limpar_OutrosFiltros();
            cbbpTipo.Text = "AMBAS";
            cbbpEmitente.Visible = false;
            cbbpTipoEmitente.Visible = false;
            btnpProcurar.Visible = false;
            txtpBarra.Visible = false;
            txtpCodigo.Visible = true;
            txtpCodigo.MaxLength = 10;
            lblPesquisar.Location = new Point(773, 20);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnCodBarra_CheckedChanged(object sender, EventArgs e)
        {
            cbbTabela.Visible = false;
            lblEscolha.Visible = false;
            lblDataPagamentos.Enabled = false;
            lblAte2.Enabled = false;
            mtxtDataPag.Enabled = false;
            mtxtDataPag1.Enabled = false;
            btnSelecionarData3.Enabled = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblGrupos.Enabled = false;
            cbbpGrupo.Enabled = false;
            lblSubgrupos.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            txtpContratoMatServ.Visible = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData2.Enabled = false;
            lblSituacao.Enabled = false;
            cbbpTipo.Enabled = false;
            Limpar_OutrosFiltros();
            cbbpTipo.Text = "AMBAS";
            cbbpEmitente.Visible = false;
            cbbpTipoEmitente.Visible = false;
            btnpProcurar.Visible = false;
            txtpBarra.Visible = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Location = new Point(522, 20);
            lblPesquisar.Text = "Digite o código de barras:";
            txtpBarra.Text = null;
            txtpBarra.Select();
        }

        private void rbtnEmitente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbTabela.Visible = false;
                lblEscolha.Visible = false;
                lblDataPagamentos.Enabled = true;
                lblAte2.Enabled = true;
                mtxtDataPag.Enabled = true;
                mtxtDataPag1.Enabled = true;
                btnSelecionarData3.Enabled = true;
                txtpDescricao.Visible = false;
                txtpPalavraChave.Visible = false;
                btnProcurarGrupo.Enabled = true;
                btnProcurarSubgrupo.Enabled = false;
                lblGrupos.Enabled = true;
                cbbpGrupo.Enabled = true;
                cbbpSubGrupo.Enabled = false;
                txtpContratoMatServ.Visible = false;
                lblDataEmissao.Enabled = true;
                lblDataVencimento.Enabled = true;
                mtxtpDataEmi.Enabled = true;
                mtxtpDataEmi1.Enabled = true;
                mtxtpDataVenc.Enabled = true;
                mtxtpDataVenc1.Enabled = true;
                btnSelecionarData1.Enabled = true;
                btnSelecionarData2.Enabled = true;
                lblSituacao.Enabled = true;
                cbbpTipo.Enabled = true;
                Limpar_OutrosFiltros();
                cbbpTipo.Text = "AMBAS";
                cbbpTipoEmitente.Visible = true;
                btnpProcurar.Visible = true;
                txtpBarra.Visible = false;
                txtpCodigo.Visible = false;
                lblPesquisar.Location = new Point(461, 20);
                cbbpEmitente.Visible = true;
                lblPesquisar.Text = "Localizar emitente em:";
                cbbpTipoEmitente.Text = "CLIENTES";
                cbbpEmitente.Text = null;
                cbbpTipoEmitente.Select();
                //
                cbbpEmitente.Items.Clear();
                if (cbbpTipoEmitente.SelectedIndex == 1)
                {
                    if (bllContasPagar.Sel_Cliente_Cont() == null)
                    {
                        cbbpEmitente.Enabled = false;
                        cbbpEmitente.Text = null;
                    }
                    else
                    {
                        cbbpEmitente.Enabled = true;
                        cbbpEmitente.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                        {
                            cbbpEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                //
                cbbpGrupo.Items.Clear();
                if (bllContasPagar.Sel_Grupo_Conta_Pagar() == null)
                {
                    cbbpGrupo.Text = null;
                    cbbpGrupo.Enabled = false;
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnProcurarSubgrupo.Enabled = false;
                }
                else
                {
                    cbbpGrupo.Enabled = true;
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllContasPagar.Sel_Grupo_Conta_Pagar().Rows)
                    {
                        cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnEmitente.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnEmitente.");
                }
                cbbpEmitente.Items.Clear();
                cbbpEmitente.Text = null;
            }
        }

        private void rbtnTodas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbTabela.Visible = false;
                lblEscolha.Visible = false;
                lblDataPagamentos.Enabled = true;
                lblAte2.Enabled = true;
                mtxtDataPag.Enabled = true;
                mtxtDataPag1.Enabled = true;
                btnSelecionarData3.Enabled = true;
                txtpDescricao.Visible = false;
                txtpPalavraChave.Visible = false;
                btnProcurarGrupo.Enabled = true;
                btnProcurarSubgrupo.Enabled = false;
                lblGrupos.Enabled = true;
                cbbpGrupo.Enabled = true;
                lblSubgrupos.Enabled = true;
                cbbpSubGrupo.Enabled = false;
                txtpContratoMatServ.Visible = false;
                lblDataEmissao.Enabled = true;
                lblDataVencimento.Enabled = true;
                mtxtpDataEmi.Enabled = true;
                mtxtpDataEmi1.Enabled = true;
                mtxtpDataVenc.Enabled = true;
                mtxtpDataVenc1.Enabled = true;
                btnSelecionarData1.Enabled = true;
                btnSelecionarData2.Enabled = true;
                lblSituacao.Enabled = true;
                cbbpTipo.Enabled = true;
                Limpar_OutrosFiltros();
                cbbpTipo.Text = null;
                cbbpEmitente.Visible = false;
                cbbpTipoEmitente.Visible = false;
                btnpProcurar.Visible = false;
                txtpBarra.Visible = false;
                txtpCodigo.Visible = false;
                lblPesquisar.Location = new Point(821, 20);
                lblPesquisar.Text = "Exibir todo o cadastro:";
                btnPesquisar.Select();
                //
                cbbpGrupo.Items.Clear();
                if (bllContasPagar.Sel_Grupo_Conta_Pagar() == null)
                {
                    cbbpGrupo.Text = null;
                    cbbpGrupo.Enabled = false;
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnProcurarSubgrupo.Enabled = false;
                }
                else
                {
                    cbbpGrupo.Enabled = true;
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllContasPagar.Sel_Grupo_Conta_Pagar().Rows)
                    {
                        cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
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
                cbbpGrupo.Items.Clear();
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Items.Clear();
                cbbpSubGrupo.Text = null;
                cbbpEmitente.Items.Clear();
                cbbpEmitente.Text = null;
            }
        }

        private void rbtnNContratoMatriculaServico_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbTabela.Visible = false;
                lblEscolha.Visible = false;
                lblDataPagamentos.Enabled = true;
                lblAte2.Enabled = true;
                mtxtDataPag.Enabled = true;
                mtxtDataPag1.Enabled = true;
                btnSelecionarData3.Enabled = true;
                txtpDescricao.Visible = false;
                txtpPalavraChave.Visible = false;
                btnProcurarGrupo.Enabled = true;
                btnProcurarSubgrupo.Enabled = false;
                lblGrupos.Enabled = true;
                cbbpGrupo.Enabled = true;
                lblSubgrupos.Enabled = true;
                cbbpSubGrupo.Enabled = false;
                lblDataEmissao.Enabled = true;
                lblDataVencimento.Enabled = true;
                mtxtpDataEmi.Enabled = true;
                mtxtpDataEmi1.Enabled = true;
                mtxtpDataVenc.Enabled = true;
                mtxtpDataVenc1.Enabled = true;
                btnSelecionarData1.Enabled = true;
                btnSelecionarData2.Enabled = true;
                lblSituacao.Enabled = true;
                cbbpTipo.Enabled = true;
                Limpar_OutrosFiltros();
                cbbpTipo.Text = "AMBAS";
                cbbpEmitente.Visible = false;
                cbbpTipoEmitente.Visible = false;
                btnpProcurar.Visible = false;
                txtpBarra.Visible = false;
                txtpCodigo.Visible = false;
                txtpContratoMatServ.Visible = true;
                lblPesquisar.Location = new Point(571, 20);
                lblPesquisar.Text = "Digite o contrato/matrícula/serviço:";
                txtpContratoMatServ.Text = null;
                txtpContratoMatServ.Select();
                cbbpGrupo.Items.Clear();
                //
                if (bllContasPagar.Sel_Grupo_Conta_Pagar() == null)
                {
                    cbbpGrupo.Text = null;
                    cbbpGrupo.Enabled = false;
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnProcurarSubgrupo.Enabled = false;
                }
                else
                {
                    cbbpGrupo.Enabled = true;
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllContasPagar.Sel_Grupo_Conta_Pagar().Rows)
                    {
                        cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
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
                cbbpGrupo.Items.Clear();
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Items.Clear();
                cbbpSubGrupo.Text = null;
                cbbpEmitente.Items.Clear();
                cbbpEmitente.Text = null;
            }
        }

        private void rbtnNDocumento_CheckedChanged(object sender, EventArgs e)
        {
            cbbTabela.Visible = false;
            lblEscolha.Visible = false;
            lblDataPagamentos.Enabled = false;
            lblAte2.Enabled = false;
            mtxtDataPag.Enabled = false;
            mtxtDataPag1.Enabled = false;
            btnSelecionarData3.Enabled = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblGrupos.Enabled = false;
            cbbpGrupo.Enabled = false;
            lblSubgrupos.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            txtpContratoMatServ.Visible = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData2.Enabled = false;
            lblSituacao.Enabled = false;
            cbbpTipo.Enabled = false;
            Limpar_OutrosFiltros();
            cbbpTipo.Text = null;
            cbbpEmitente.Visible = false;
            cbbpTipoEmitente.Visible = false;
            btnpProcurar.Visible = false;
            txtpBarra.Visible = false;
            txtpCodigo.Visible = true;
            txtpCodigo.MaxLength = 15;
            lblPesquisar.Location = new Point(713, 20);
            lblPesquisar.Text = "Digite o nº do documento:";
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void mtxtpDataEmi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataEmi1.Select();
            }
        }

        private void mtxtpDataEmi1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataVenc.Select();
            }
        }

        private void mtxtpDataVenc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataVenc1.Select();
            }
        }

        private void mtxtpDataVenc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataPag.Select();
            }
        }

        private void mtxtpDataEmi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmi.Text == "")
                {
                    mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmi.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmi1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmi1.Text == "")
                {
                    mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmi1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataVenc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataVenc.Text == "")
                {
                    mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataVenc.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataVenc1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataVenc1.Text == "")
                {
                    mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataVenc1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void cbbpTipoEmitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpEmitente.Select();
            }
        }

        private void cbbpTipoEmitente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbpEmitente.Items.Clear();
                if (cbbpTipoEmitente.SelectedIndex == 0)
                {
                    cbbpEmitente.Text = null;
                    cbbpEmitente.Enabled = false;
                    btnpProcurar.Enabled = false;
                }
                else if (cbbpTipoEmitente.SelectedIndex == 1)
                {
                    if (bllContasPagar.Sel_Cliente_Cont() == null)
                    {
                        cbbpEmitente.Text = null;
                        cbbpEmitente.Enabled = false;
                    }
                    else
                    {
                        cbbpEmitente.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpEmitente.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                        {
                            cbbpEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbpTipoEmitente.SelectedIndex == 2)
                {
                    if (bllContasPagar.Sel_Forn_Cont() == null)
                    {
                        cbbpEmitente.Text = null;
                        cbbpEmitente.Enabled = false;
                    }
                    else
                    {
                        cbbpEmitente.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpEmitente.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Forn_Cont().Rows)
                        {
                            cbbpEmitente.Items.Add((dr["id_fornecedor"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                else if (cbbpTipoEmitente.SelectedIndex == 3)
                {
                    if (bllContasPagar.Sel_Func_Cont() == null)
                    {
                        cbbpEmitente.Text = null;
                        cbbpEmitente.Enabled = false;
                    }
                    else
                    {
                        cbbpEmitente.Enabled = true;
                        btnpProcurar.Enabled = true;
                        cbbpEmitente.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Func_Cont().Rows)
                        {
                            cbbpEmitente.Items.Add((dr["id_funcionario"].ToString()) + "—" + (dr["nome"].ToString()));
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbpTipoEmitente.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedIndexChanged do combo cbbpTipoEmitente.");
                }
                cbbpEmitente.Items.Clear();
                cbbpEmitente.Text = null;
                cbbpTipoEmitente.Text = null;
            }
        }

        private void txtpBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
                {
                    MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    txtpBarra.Text = null;
                    txtpBarra.Select();
                }
                else
                {
                    if (txtpBarra.Text != "")
                    {
                        try
                        {
                            if (bllContasPagar.Sel_Conta_Codigo_Barra(txtpBarra.Text) == null)
                            {
                                dtContaPagar.DataSource = null;
                            }
                            else
                            {
                                dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Codigo_Barra(txtpBarra.Text);
                                dtContaPagar.Select();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.DialogResult = DialogResult.None;
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keypress da caixa de texto txtpBarra.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento keypress da caixa de texto txtpBarra.");
                            }
                            txtpBarra.Text = null;
                        }
                    }
                    else
                    {
                        btnPesquisar.Select();
                    }
                }
            }
        }

        private void txtpBarra_Leave(object sender, EventArgs e)
        {
            if (txtpBarra.Text.Contains("'") || txtpBarra.Text.Contains(";") || txtpBarra.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpBarra.Text = null;
                txtpBarra.Select();
            }
            txtpBarra.BackColor = Color.White;
        }

        private void txtpBarra_Enter(object sender, EventArgs e)
        {
            txtpBarra.BackColor = Color.LightBlue;
        }

        private void cbbpEmitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
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

        private void txtpContratoMatServ_Enter(object sender, EventArgs e)
        {
            txtpContratoMatServ.BackColor = Color.LightBlue;
        }

        private void txtpContratoMatServ_Leave(object sender, EventArgs e)
        {
            txtpContratoMatServ.BackColor = Color.White;
        }

        private void txtpContratoMatServ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnpProcurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbpTipoEmitente.Text == "CLIENTES")
                {
                    pPanel.Enabled = false;
                    using (FrmPesqCliente Clie = new FrmPesqCliente(5, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Clie.ShowDialog() == DialogResult.OK)
                        {
                            cbbpEmitente.Items.Clear();
                            if (bllContasPagar.Sel_Cliente_Cont() == null)
                            {
                                cbbpEmitente.Text = null;
                            }
                            else
                            {
                                cbbpEmitente.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                                {
                                    cbbpEmitente.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString());
                                }
                            }
                            cbbpEmitente.Text = bllContasPagar._Emitente_PesqContaPagar_Tabela;
                            bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
                            cbbpEmitente.Select();
                        }
                    }
                    pPanel.Enabled = true;
                }
                else if (cbbpTipoEmitente.Text == "FORNECEDORES")
                {
                    using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(3, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Forn.ShowDialog() == DialogResult.OK)
                        {
                            cbbpEmitente.Items.Clear();
                            if (bllContasPagar.Sel_Forn_Cont() == null)
                            {
                                cbbpEmitente.Text = null;
                            }
                            else
                            {
                                cbbpEmitente.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Forn_Cont().Rows)
                                {
                                    cbbpEmitente.Items.Add(dr["id_fornecedor"].ToString() + "—" + dr["nome"].ToString());
                                }
                            }
                            cbbpEmitente.Text = bllContasPagar._Emitente_PesqContaPagar_Tabela;
                            bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
                            cbbpEmitente.Select();
                        }
                    }
                }
                else if (cbbpTipoEmitente.Text == "FUNCIONARIOS")
                {
                    using (FrmPesqFuncionario Func = new FrmPesqFuncionario(3, _Usuario, _Cod_PDV_Computador))
                    {
                        if (Func.ShowDialog() == DialogResult.OK)
                        {
                            cbbpEmitente.Items.Clear();
                            if (bllContasPagar.Sel_Func_Cont() == null)
                            {
                                cbbpEmitente.Text = null;
                            }
                            else
                            {
                                cbbpEmitente.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_Func_Cont().Rows)
                                {
                                    cbbpEmitente.Items.Add(dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString());
                                }
                            }
                            cbbpEmitente.Text = bllContasPagar._Emitente_PesqContaPagar_Tabela;
                            bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
                            cbbpEmitente.Select();
                        }
                    }
                }
                grbBox1.Enabled = true;
                if (dtContaPagar.DataSource == null)
                {
                    grbBox2.Enabled = false;
                }
                else
                {
                    grbBox2.Enabled = true;
                }
                btnPesquisar.Enabled = true;
                btnSair.Enabled = true;
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
                cbbpEmitente.Text = null;
                bllContasPagar._Emitente_PesqContaPagar_Tabela = null;
            }
        }

        private void FrmOpeBaixaContaPagar_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelContaPagar foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelContaPagar foi finalizado.");
                }
                bllContasPagar._FrmRelContaPagar_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmOpeBaixaContaPagar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmOpeBaixaContaPagar.");
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnTodas.Checked == true)
                {
                    mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtDataPag.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtDataPag1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if ((mtxtpDataEmi.Text == "" & mtxtpDataEmi1.Text != "") || (mtxtpDataEmi.Text != "" & mtxtpDataEmi1.Text == ""))
                    {
                        mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Emissão ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpDataEmi.Select();
                        return;
                    }
                    else if ((mtxtpDataVenc.Text == "" & mtxtpDataVenc1.Text != "") || (mtxtpDataVenc.Text != "" & mtxtpDataVenc1.Text == ""))
                    {
                        mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Vencimento ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpDataEmi.Select();
                        return;
                    }
                    else if ((mtxtDataPag.Text == "" & mtxtDataPag1.Text != "") || (mtxtDataPag.Text != "" & mtxtDataPag1.Text == ""))
                    {
                        mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data da Baixa ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpDataEmi.Select();
                        return;
                    }
                    else
                    {
                        mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllContasPagar.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Todos(mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpTipo.Text, mtxtDataPag.Text, mtxtDataPag1.Text) == null)
                        {
                            dtContaPagar.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Todos(mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpTipo.Text, mtxtDataPag.Text, mtxtDataPag1.Text);
                            dtContaPagar.Select();
                        }
                    }
                }
                else if (rbtnPalavraChave.Checked == true)
                {
                    if (txtpPalavraChave.Text != "")
                    {
                        if (bllContasPagar.Sel_Conta_Codigo_Palavra_Chave(txtpPalavraChave.Text) == null)
                        {
                            dtContaPagar.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Codigo_Palavra_Chave(txtpPalavraChave.Text);
                            dtContaPagar.Select();
                        }
                    }
                }
                else if (rbtnCodBarra.Checked == true)
                {
                    if (txtpBarra.Text != "")
                    {
                        if (bllContasPagar.Sel_Conta_Codigo_Barra(txtpBarra.Text) == null)
                        {
                            dtContaPagar.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Codigo_Barra(txtpBarra.Text);
                            dtContaPagar.Select();
                        }
                    }
                }
                else if (rbtnNContratoMatriculaServico.Checked == true)
                {
                    if (txtpContratoMatServ.Text != "")
                    {
                        mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtDataPag.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtDataPag1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpDataEmi.Text == "" & mtxtpDataEmi1.Text != "") || (mtxtpDataEmi.Text != "" & mtxtpDataEmi1.Text == ""))
                        {
                            mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Emissão ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else if ((mtxtpDataVenc.Text == "" & mtxtpDataVenc1.Text != "") || (mtxtpDataVenc.Text != "" & mtxtpDataVenc1.Text == ""))
                        {
                            mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Vencimento ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else if ((mtxtDataPag.Text == "" & mtxtDataPag1.Text != "") || (mtxtDataPag.Text != "" & mtxtDataPag1.Text == ""))
                        {
                            mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data da Baixa ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else
                        {
                            mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllContasPagar.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Contrato(txtpContratoMatServ.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpTipo.Text, mtxtDataPag.Text, mtxtDataPag1.Text) == null)
                            {
                                dtContaPagar.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Contrato(txtpContratoMatServ.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpTipo.Text, mtxtDataPag.Text, mtxtDataPag1.Text);
                                dtContaPagar.Select();
                            }
                        }
                    }
                }
                else if (rbtnEmitente.Checked == true)
                {
                    if (cbbpTipoEmitente.Text != "")
                    {
                        mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtDataPag.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtDataPag1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpDataEmi.Text == "" & mtxtpDataEmi1.Text != "") || (mtxtpDataEmi.Text != "" & mtxtpDataEmi1.Text == ""))
                        {
                            mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Emissão ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else if ((mtxtpDataVenc.Text == "" & mtxtpDataVenc1.Text != "") || (mtxtpDataVenc.Text != "" & mtxtpDataVenc1.Text == ""))
                        {
                            mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Vencimento ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else if ((mtxtDataPag.Text == "" & mtxtDataPag1.Text != "") || (mtxtDataPag.Text != "" & mtxtDataPag1.Text == ""))
                        {
                            mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data da Baixa ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else
                        {
                            mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllContasPagar.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Emit(cbbpTipoEmitente.Text, cbbpEmitente.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpTipo.Text, mtxtDataPag.Text, mtxtDataPag1.Text) == null)
                            {
                                dtContaPagar.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Emit(cbbpTipoEmitente.Text, cbbpEmitente.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpTipo.Text, mtxtDataPag.Text, mtxtDataPag1.Text);
                                dtContaPagar.Select();
                            }
                        }
                    }
                }
                else if (rbtnNDocumento.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllContasPagar.Sel_Conta_N_Documento(txtpCodigo.Text) == null)
                        {
                            dtContaPagar.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtContaPagar.DataSource = bllContasPagar.Sel_Conta_N_Documento(txtpCodigo.Text);
                            dtContaPagar.Select();
                        }
                    }
                }
                else if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text != "")
                    {
                        if (bllContasPagar.Sel_Conta_Codigo(txtpCodigo.Text) == null)
                        {
                            dtContaPagar.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Codigo(txtpCodigo.Text);
                            dtContaPagar.Select();
                        }
                    }
                }
                else if (rbtnTabela.Checked == true)
                {
                    if (bllContasPagar.Sel_Conta_Tabela_Geradora(cbbTabela.Text, txtpCodigo.Text) == null)
                    {
                        dtContaPagar.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Tabela_Geradora(cbbTabela.Text, txtpCodigo.Text);
                        dtContaPagar.Select();
                    }
                }
                else if (rbtnDescricao.Checked == true)
                {
                    if (txtpDescricao.Text != "")
                    {
                        mtxtpDataEmi.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataEmi1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtpDataVenc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtpDataVenc1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        mtxtDataPag.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        mtxtDataPag1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                        if ((mtxtpDataEmi.Text == "" & mtxtpDataEmi1.Text != "") || (mtxtpDataEmi.Text != "" & mtxtpDataEmi1.Text == ""))
                        {
                            mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Emissão ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else if ((mtxtpDataVenc.Text == "" & mtxtpDataVenc1.Text != "") || (mtxtpDataVenc.Text != "" & mtxtpDataVenc1.Text == ""))
                        {
                            mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data de Vencimento ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else if ((mtxtDataPag.Text == "" & mtxtDataPag1.Text != "") || (mtxtDataPag.Text != "" & mtxtDataPag1.Text == ""))
                        {
                            mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            MessageBox.Show("É necessário preencher ambos os campos de [ Data da Baixa ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmi.Select();
                            return;
                        }
                        else
                        {
                            mtxtpDataEmi.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataEmi1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtpDataVenc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtpDataVenc1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                            if (bllContasPagar.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Desc(txtpDescricao.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpTipo.Text, mtxtDataPag.Text, mtxtDataPag1.Text) == null)
                            {
                                dtContaPagar.DataSource = null;
                                MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Pagar_DataCad_DataEmi_DataVenc_Grupo_Subgrupo_Situacao_Desc(txtpDescricao.Text, mtxtpDataEmi.Text, mtxtpDataEmi1.Text, mtxtpDataVenc.Text, mtxtpDataVenc1.Text, cbbpGrupo.Text, cbbpSubGrupo.Text, cbbpTipo.Text, mtxtDataPag.Text, mtxtDataPag1.Text);
                                dtContaPagar.Select();
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtContaPagar.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void dtContaPagar_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtContaPagar.DataSource == null)
            {
                dtContaPagar.Enabled = false;
                grbBox2.Enabled = false;
                lblTotal.Enabled = false;
                lblValorTotal.Enabled = false;
                lblPago.Enabled = false;
                lblValorPago.Enabled = false;
                lblaPagar.Enabled = false;
                lblValorAPagar.Enabled = false;
                lblCxSituacao.BackColor = Color.White;
                lblValorSituacao.ForeColor = Color.White;
                lblValorSituacao.Text = "Situação";
            }
            else
            {
                dtContaPagar.Enabled = true;
                grbBox2.Enabled = true;
                lblTotal.Enabled = true;
                lblValorTotal.Enabled = true;
                lblPago.Enabled = true;
                lblValorPago.Enabled = true;
                lblaPagar.Enabled = true;
                lblValorAPagar.Enabled = true;
                //
                List<string> cor = new List<string>();
                List<string> grupo = new List<string>();

                if (bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A PAGAR") != null)
                {
                    for (int i = 0; i < bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A PAGAR").Rows.Count; i++)
                    {
                        DataRow dr = bllGrupo.Sel_Grupo_Cor_Destaque("CONTAS A PAGAR").Rows[i];
                        //
                        if (dr["cor_destaque"].ToString() != null & dr["cor_destaque"].ToString() != "")
                        {
                            cor.Add(dr["cor_destaque"].ToString());
                            grupo.Add(dr["id_grupo"].ToString());
                        }
                    }
                }

                for (int i = 0; i < dtContaPagar.Rows.Count; i++)
                {
                    for (int u = 0; u < cor.Count; u++)
                    {
                        if (cor[u] == "")
                        {
                            dtContaPagar.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        else if (cor[u] == "1" & grupo[u] == dtContaPagar.Rows[i].Cells[12].Value.ToString())
                        {
                            dtContaPagar.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                        else if (cor[u] == "2" & grupo[u] == dtContaPagar.Rows[i].Cells[12].Value.ToString())
                        {
                            dtContaPagar.Rows[i].DefaultCellStyle.BackColor = Color.Tan;
                        }
                        else if (cor[u] == "3" & grupo[u] == dtContaPagar.Rows[i].Cells[12].Value.ToString())
                        {
                            dtContaPagar.Rows[i].DefaultCellStyle.BackColor = Color.Peru;
                        }
                        else if (cor[u] == "4" & grupo[u] == dtContaPagar.Rows[i].Cells[12].Value.ToString())
                        {
                            dtContaPagar.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        else if (cor[u] == "5" & grupo[u] == dtContaPagar.Rows[i].Cells[12].Value.ToString())
                        {
                            dtContaPagar.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                        }
                        else if (cor[u] == "6" & grupo[u] == dtContaPagar.Rows[i].Cells[12].Value.ToString())
                        {
                            dtContaPagar.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }
            }
        }

        private void dtContaPagar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtContaPagar.Columns[16].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaPagar.Columns[16].DefaultCellStyle.Format = "n2";
                dtContaPagar.Columns[17].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaPagar.Columns[17].DefaultCellStyle.Format = "n2";
                dtContaPagar.Columns[19].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaPagar.Columns[19].DefaultCellStyle.Format = "n2";
                dtContaPagar.Columns[20].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaPagar.Columns[20].DefaultCellStyle.Format = "n2";
                dtContaPagar.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaPagar.Columns[21].DefaultCellStyle.Format = "n2";
                dtContaPagar.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaPagar.Columns[22].DefaultCellStyle.Format = "n2";
                dtContaPagar.Columns[23].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaPagar.Columns[23].DefaultCellStyle.Format = "n2";
                dtContaPagar.Columns[24].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaPagar.Columns[24].DefaultCellStyle.Format = "n2";
                dtContaPagar.Columns[26].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaPagar.Columns[26].DefaultCellStyle.Format = "n2";
                dtContaPagar.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtContaPagar.Columns[27].DefaultCellStyle.Format = "n2";

                dtContaPagar.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtContaPagar.DefaultCellStyle.SelectionForeColor = Color.Black;

                DataGridViewRow SelectedRow = dtContaPagar.Rows[e.RowIndex];

                if (SelectedRow.Cells[25].Value.ToString() == "PENDENTE")
                {
                    btnBaixaRegistro.Enabled = true;
                    btnReciboRegistro.Enabled = false;
                    if (Convert.ToDecimal(SelectedRow.Cells[26].Value) > 0)
                    {
                        btnReciboRegistro.Enabled = true;
                        btnDesfazer.Enabled = true;
                    }
                    else
                    {
                        btnReciboRegistro.Enabled = false;
                        btnDesfazer.Enabled = false;
                    }
                    lblValorSituacao.Text = "PENDENTE";
                    lblValorSituacao.ForeColor = Color.Red;
                    lblCxSituacao.BackColor = Color.Red;
                }
                else if (SelectedRow.Cells[25].Value.ToString() == "EFETUADO")
                {
                    lblValorSituacao.Text = "EFETUADO";
                    lblValorSituacao.ForeColor = Color.Green;
                    lblCxSituacao.BackColor = Color.Green;
                    btnBaixaRegistro.Enabled = false;
                    btnReciboRegistro.Enabled = true;
                    btnDesfazer.Enabled = true;
                }
                //
                if (SelectedRow.Cells[41].Value.ToString() == "0")
                {
                    btnReciboRegistro.Enabled = false;
                }
                else if (SelectedRow.Cells[41].Value.ToString() == "1")
                {
                    btnReciboRegistro.Enabled = true;
                }
                else
                {
                    btnReciboRegistro.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellEnter da grade de dados dtContaPagar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellEnter da grade de dados dtContaPagar.");
                }
                dtContaPagar.DataSource = null;
                rbtnDescricao.Checked = true;
            }
        }

        private void dtContaPagar_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtContaPagar.Columns[0].HeaderText = "Código";
                dtContaPagar.Columns[1].HeaderText = "Descrição";
                dtContaPagar.Columns[2].HeaderText = "Contrato/Mátricula/Serviço";
                dtContaPagar.Columns[3].HeaderText = "Parcela(s)";
                dtContaPagar.Columns[4].HeaderText = "Nº do Documento";
                dtContaPagar.Columns[5].HeaderText = "Código de Barras";
                dtContaPagar.Columns[6].HeaderText = "Data de Emissão";
                dtContaPagar.Columns[7].HeaderText = "Data de Vencimento";
                dtContaPagar.Columns[8].HeaderText = "Tipo do Documento";
                dtContaPagar.Columns[9].HeaderText = "Tipo de Emitente";
                dtContaPagar.Columns[10].HeaderText = "Cód. do Emitente";
                dtContaPagar.Columns[11].HeaderText = "Nome do Emitente";
                dtContaPagar.Columns[12].HeaderText = "Cód. do Grupo";
                dtContaPagar.Columns[13].HeaderText = "Descrição do Grupo";
                dtContaPagar.Columns[14].HeaderText = "Cód. do Subgrupo";
                dtContaPagar.Columns[15].HeaderText = "Descrição do Subgrupo";
                dtContaPagar.Columns[16].HeaderText = "Valor (R$)";
                dtContaPagar.Columns[17].HeaderText = "Valor Real (R$)";
                dtContaPagar.Columns[18].HeaderText = "Desconto Até";
                dtContaPagar.Columns[19].HeaderText = "Desconto (%)";
                dtContaPagar.Columns[20].HeaderText = "Valor do Desconto (R$)";
                dtContaPagar.Columns[21].HeaderText = "Multa (%)";
                dtContaPagar.Columns[22].HeaderText = "Valor da Multa (R$)";
                dtContaPagar.Columns[23].HeaderText = "Juros (a.m) (%)";
                dtContaPagar.Columns[24].HeaderText = "Valor Juros (a.m) (R$)";
                dtContaPagar.Columns[25].HeaderText = "Situação";
                dtContaPagar.Columns[26].HeaderText = "Valor Total Pago (R$)";
                dtContaPagar.Columns[27].HeaderText = "Troco (R$)";
                dtContaPagar.Columns[28].HeaderText = "Data da Baixa";
                dtContaPagar.Columns[29].HeaderText = "Horário da Baixa";
                dtContaPagar.Columns[30].HeaderText = "Observações";
                dtContaPagar.Columns[31].HeaderText = "Palavra-Chave";
                dtContaPagar.Columns[32].HeaderText = "Data de Cadastro";
                dtContaPagar.Columns[33].Visible = false;
                dtContaPagar.Columns[34].HeaderText = "Cód. do Usuário da Baixa";
                dtContaPagar.Columns[35].HeaderText = "Nome do Usuário da Baixa";
                dtContaPagar.Columns[36].HeaderText = "Tabela Geradora";
                dtContaPagar.Columns[37].HeaderText = "Cód. do Fato Gerador";
                dtContaPagar.Columns[38].HeaderText = "Cód. da Ent. Bancária";
                dtContaPagar.Columns[39].HeaderText = "Descrição da Entidade Bancária";
                dtContaPagar.Columns[40].Visible = false;
                dtContaPagar.Columns[41].HeaderText = "Descontar Caixa";

                dtContaPagar.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[37].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[39].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[39].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[41].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtContaPagar.Columns[41].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtContaPagar.Columns[0].Width = 95;
                dtContaPagar.Columns[1].Width = 325;
                dtContaPagar.Columns[2].Width = 168;
                dtContaPagar.Columns[3].Width = 146;
                dtContaPagar.Columns[4].Width = 142;
                dtContaPagar.Columns[5].Width = 500;
                dtContaPagar.Columns[6].Width = 150;
                dtContaPagar.Columns[7].Width = 150;
                dtContaPagar.Columns[8].Width = 200;
                dtContaPagar.Columns[9].Width = 150;
                dtContaPagar.Columns[10].Width = 125;
                dtContaPagar.Columns[11].Width = 325;
                dtContaPagar.Columns[12].Width = 105;
                dtContaPagar.Columns[13].Width = 325;
                dtContaPagar.Columns[14].Width = 125;
                dtContaPagar.Columns[15].Width = 325;
                dtContaPagar.Columns[16].Width = 162;
                dtContaPagar.Columns[17].Width = 162;
                dtContaPagar.Columns[18].Width = 150;
                dtContaPagar.Columns[19].Width = 150;
                dtContaPagar.Columns[20].Width = 150;
                dtContaPagar.Columns[21].Width = 150;
                dtContaPagar.Columns[22].Width = 150;
                dtContaPagar.Columns[23].Width = 150;
                dtContaPagar.Columns[24].Width = 150;
                dtContaPagar.Columns[25].Width = 168;
                dtContaPagar.Columns[26].Width = 162;
                dtContaPagar.Columns[27].Width = 162;
                dtContaPagar.Columns[28].Width = 150;
                dtContaPagar.Columns[29].Width = 145;
                dtContaPagar.Columns[30].Width = 500;
                dtContaPagar.Columns[31].Width = 150;
                dtContaPagar.Columns[32].Width = 150;
                dtContaPagar.Columns[34].Width = 168;
                dtContaPagar.Columns[35].Width = 168;
                dtContaPagar.Columns[36].Width = 235;
                dtContaPagar.Columns[37].Width = 175;
                dtContaPagar.Columns[38].Width = 150;
                dtContaPagar.Columns[39].Width = 325;
                dtContaPagar.Columns[41].Width = 125;

                dtContaPagar.DefaultCellStyle.Font = new Font(dtContaPagar.Font, FontStyle.Bold);

                lblRegistros.Text = "Registros: " + dtContaPagar.Rows.Count;

                decimal valortotal = 0;
                for (int i = 0; i < dtContaPagar.Rows.Count; i++)
                {
                    valortotal += Convert.ToDecimal(dtContaPagar.Rows[i].Cells[16].Value);
                }
                lblValorTotal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valorpago = 0;
                for (int i = 0; i < dtContaPagar.Rows.Count; i++)
                {
                    if (dtContaPagar.Rows[i].Cells[25].Value.ToString() == "EFETUADO")
                    {
                        valorpago += Convert.ToDecimal(dtContaPagar.Rows[i].Cells[16].Value);
                    }
                    else if (dtContaPagar.Rows[i].Cells[25].Value.ToString() == "PENDENTE" & Convert.ToDecimal(dtContaPagar.Rows[i].Cells[26].Value) > 0)
                    {
                        valorpago += Convert.ToDecimal(dtContaPagar.Rows[i].Cells[26].Value);
                    }
                }
                //
                lblValorPago.Text = Convert.ToDecimal(valorpago).ToString("n2", new CultureInfo("pt-BR"));
                //
                valorpago = valortotal - valorpago;
                lblValorAPagar.Text = Convert.ToDecimal(valorpago).ToString("n2", new CultureInfo("pt-BR"));
                //
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtProd.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtProd.");
                }
                dtContaPagar.DataSource = null;
            }
        }

        private void FrmOpeBaixaContaPagar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dtContaPagar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtContaPagar.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtContaPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtContaPagar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 34 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 28 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 6 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 7 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 18 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
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
            if (e.ColumnIndex == 41 && e.Value.ToString() == "0")
            {
                e.Value = "NÃO";
            }
            else if (e.ColumnIndex == 41 && e.Value.ToString() == "1")
            {
                e.Value = "SIM";
            }
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorPago_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pago (R$): " + lblValorPago.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorAPagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("a Pagar (R$): " + lblValorAPagar.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtContaPagar_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorTotal.Text = null;
            lblValorPago.Text = null;
            lblValorAPagar.Text = null;
        }

        private void btnConsultarPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtContaPagar.Rows[dtContaPagar.CurrentRow.Index];

                if (Convert.ToDecimal(SelectedRow.Cells[26].Value) <= 0)
                {
                    MessageBox.Show("Ainda não existe(m) pagamento(s) para esta Conta a Pagar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtContaPagar.Select();
                }
                else
                {
                    pPanel.Enabled = false;
                    using (FrmConsultarPagamento Pag = new FrmConsultarPagamento(SelectedRow.Cells[0].Value.ToString(), 1))
                    {
                        if (Pag.ShowDialog() == DialogResult.Abort)
                        {
                            dtContaPagar.Select();
                        }
                    }
                    pPanel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
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
        }

        private void btnBaixaRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtContaPagar.Rows[dtContaPagar.CurrentRow.Index];
                //
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0 & bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == true)
                {
                    MessageBox.Show("Não é possível baixar este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtContaPagar.Select();
                }
                else if (bllContasPagar.Sel_Conta_Pagar_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtContaPagar.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja Baixar esta Conta a Pagar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;

                        DialogResult = MessageBox.Show("Deseja descontar esta Conta a Pagar do caixa?", "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.No)
                        {
                            this.DialogResult = DialogResult.OK;
                            if (bllContasPagar.Sel_Baixa_Conta_Pagar_Aconteceu(SelectedRow.Cells[0].Value.ToString()) == true)
                            {
                                MessageBox.Show("Esta conta a receber já foi baixada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                bllContasPagar.Salvar_Baixa_Pagamento_Conta_Pagar(SelectedRow.Cells[0].Value.ToString(), "0", SelectedRow.Cells[17].Value.ToString(), DateTime.Now.ToShortDateString(), SelectedRow.Cells[17].Value.ToString(), "0", _Usuario, _Cod_PDV_Computador, false);
                                //
                                bllRegistroAtividades.Salvar("FECHOU UMA CONTA A PAGAR SEM DESCONTAR DO CAIXA.", "CONTAS A PAGAR", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                                //
                                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //
                                dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Codigo(SelectedRow.Cells[0].Value.ToString());
                            }
                        }
                        else if (DialogResult == DialogResult.Yes)
                        {
                            pPanel.Enabled = false;
                            using (FrmRelBaixaConta Conta = new FrmRelBaixaConta(_Usuario, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[18].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[23].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[22].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[26].Value).ToString("n2", new CultureInfo("pt-BR")), _Cod_PDV_Computador, SelectedRow.Cells[4].Value.ToString(), 1, 0, ""))
                            {
                                if (Conta.ShowDialog() == DialogResult.OK)
                                {
                                    if (bllContasPagar.Sel_Conta_Codigo(SelectedRow.Cells[0].Value.ToString()) == null)
                                    {
                                        dtContaPagar.DataSource = null;
                                    }
                                    else
                                    {
                                        dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Codigo(SelectedRow.Cells[0].Value.ToString());
                                        //
                                        DialogResult = MessageBox.Show("Deseja imprimir o Recibo de Pagamento da Conta a Pagar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (DialogResult == DialogResult.Yes)
                                        {
                                            this.DialogResult = DialogResult.None;
                                            using (FrmInfImpressao Imp = new FrmInfImpressao(4))
                                            {
                                                if (Imp.ShowDialog() == DialogResult.OK)
                                                {
                                                    pgbProgresso.Visible = true;
                                                    lblProgresso.Visible = true;
                                                    if (bllContasPagar._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                                                    {
                                                        _Trabalho = 0;
                                                    }
                                                    else if (bllContasPagar._Tipo_Impressao == "PDF A4")
                                                    {
                                                        _Trabalho = 1;
                                                    }
                                                    bckwIndeterminado.RunWorkerAsync();
                                                    pgbProgresso.MarqueeAnimationSpeed = 2;
                                                    this.Cursor = Cursors.WaitCursor;
                                                    grbBox1.Enabled = false;
                                                    dtContaPagar.Enabled = false;
                                                    dtContaPagar.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                                                    grbBox1.Enabled = false;
                                                    grbBox2.Enabled = false;
                                                    lblDataEmissao.Enabled = false;
                                                    lblDataVencimento.Enabled = false;
                                                    mtxtpDataEmi.Enabled = false;
                                                    mtxtpDataEmi1.Enabled = false;
                                                    mtxtpDataVenc.Enabled = false;
                                                    mtxtpDataVenc1.Enabled = false;
                                                    btnSelecionarData1.Enabled = false;
                                                    btnSelecionarData2.Enabled = false;
                                                    lblSituacao.Enabled = false;
                                                    cbbpTipo.Enabled = false;
                                                    btnPesquisar.Enabled = false;
                                                    picbInterrogacao1.Enabled = false;
                                                    picbInterrogacao3.Enabled = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.DialogResult = DialogResult.None;
                                        }
                                        //
                                        dtContaPagar.Select();
                                    }
                                }
                            }
                            pPanel.Enabled = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnBaixaRegistro.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnBaixaRegistro.");
                }
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por descrição, código, código de barras, emitente, contrato/matrícula/serviço, nº do documento, palavra-chave e todos os dados cadastrados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Baixar Registro: Clique para baixar/confirmar pagamento de uma Conta a Pagar.\n\n2 - 2ª Via do Recibo: Clique para gerar a segunda via (Sistema) do recibo de pagamento de uma Conta a Pagar.\n\n3 - Comprovante(s) Físico(s): Clique ver opções de manipulação de comprovante(s) físico(s).\n\n4 - Refazer/Desfazer Baixa: Clique para refazer/desfazer uma baixa de pagamento de uma Conta a Pagar.\n\n5 - Consultar Pagamentos: Clique para visualizar os pagamentos da Conta a Pagar.\n\n6 - Relatório Resumido: Clique para imprimir um relatório simples do(s) registro(s).\n\n7 - Exp. dados para (.txt): Clique para exportar os dados da tabela para um arquivo (.txt).\n\n8 - Exp. dados para (.csv): Clique para exportar os dados da tabela para um arquivo (.csv).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnReciboRegistro_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(4))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    if (bllContasPagar._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                    {
                        _Trabalho = 0;
                    }
                    else if (bllContasPagar._Tipo_Impressao == "PDF A4")
                    {
                        _Trabalho = 1;
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtContaPagar.Enabled = false;
                    dtContaPagar.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pPanel.Enabled = true;
        }

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_Trabalho == 0)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    //
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep, tel, cel;
                    byte pessoa;
                    //
                    nome = dr["nome"].ToString();
                    fantasia = dr["fantasia"].ToString();
                    cpf_cnpj = dr["cpf_cnpj"].ToString();
                    ie_rg = dr["ie_rg"].ToString();
                    endereco = dr["endereco"].ToString();
                    numero = dr["numero"].ToString();
                    bairro = dr["bairro"].ToString();
                    cidade = dr["cidade"].ToString();
                    uf = dr["uf"].ToString();
                    cep = dr["cep"].ToString();
                    pessoa = Convert.ToByte(dr["pessoa"]);
                    tel = dr["telefone"].ToString();
                    cel = dr["celular"].ToString();
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
                    var fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                    var fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
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
                    if (bllContasPagar._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 20 + Margem_Esq, 1 + Margem_Topo, 158, 69);
                        imagem1.Dispose();
                        Margem_Topo = Margem_Topo - 15;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                    }
                    //        
                    Margem_Topo = Margem_Topo + 5;
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 2 + Margem_Topo, 203, 16);     
                    if (nome.Length > 30)
                    {
                        if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                        {
                            textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 9;
                    }
                    else
                    {
                        textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 10));
                    }
                    //
                    if (fantasia.Length > 30)
                    {
                        if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                        {
                            textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 94 + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 94 + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 9;
                    }
                    else
                    {
                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 94 + Margem_Topo, 198, 10));
                    }
                    //
                    if (pessoa == 1)
                    {
                        textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 102 + Margem_Topo, 198, 10));
                    }
                    else
                    {
                        textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 102 + Margem_Topo, 198, 10));
                    }
                    //
                    if (tel != "" & cel != "")
                    {
                        tel = tel + " - ";
                    }
                    //
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep + Environment.NewLine + tel + cel, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 110 + Margem_Topo, 198, 43));
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    Incrementar = Incrementar + 8;
                    //
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Incrementar + Margem_Topo, 198, 24));
                    //Margem_Topo = Margem_Topo - 4;
                    textFormatter1.DrawString("RECIBO", fonte3, XBrushes.Black, new XRect(5 + Margem_Esq, 149 + Margem_Topo + Incrementar, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + Margem_Topo + Incrementar, 198, 24));
                    //
                    string tipo_documento;
                    //
                    DataGridViewRow SelectedRow = dtContaPagar.Rows[dtContaPagar.CurrentRow.Index];
                    //
                    tipo_documento = "referente ao pagamento da Conta a Pagar nº " + SelectedRow.Cells[0].Value.ToString();
                    //
                    textFormatter2.DrawString("Código: " + SelectedRow.Cells[0].Value.ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 183 + Margem_Topo, 198, 8));
                    //
                    textFormatter3.DrawString("Valor Total Real (R$): " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 171 + Margem_Topo, 198, 12));
                    //}
                    //
                    textFormatter2.DrawString("Data e Hora da Impressão: " + DateTime.Now.ToShortDateString() + "   -   " + DateTime.Now.ToLongTimeString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 191 + Margem_Topo, 198, 8));
                    //
                    Margem_Topo = Margem_Topo - 17;
                    //
                    DataRow drEmitente = bllContasPagar.Sel_Dados_Emitente_Conta_Pagar(SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[9].Value.ToString()).Rows[0];
                    //
                    if (SelectedRow.Cells[11].Value.ToString().Length > 20)
                    {
                        if (!SelectedRow.Cells[11].Value.ToString().Substring(0, 20).Contains(" ") || (!SelectedRow.Cells[11].Value.ToString().Substring(20).Contains(" ") & SelectedRow.Cells[11].Value.ToString().Substring(20).Length > 10))
                        {
                            textFormatter2.DrawString("Emitente: " + SelectedRow.Cells[11].Value.ToString().Insert(20, Environment.NewLine) + Environment.NewLine + "   -   " + drEmitente["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo, 198, 24));
                        }
                        else
                        {
                            textFormatter2.DrawString("Emitente: " + SelectedRow.Cells[11].Value.ToString() + Environment.NewLine + "   -   " + drEmitente["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo, 198, 24));
                        }
                        Margem_Topo = Margem_Topo + 8;
                    }
                    else
                    {
                        textFormatter2.DrawString("Emitente: " + SelectedRow.Cells[11].Value.ToString() + Environment.NewLine + "   -   " + drEmitente["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 217 + Margem_Topo, 198, 24));
                    }
                    //                    
                    string quantia = SelectedRow.Cells[26].Value.ToString();
                    //
                    Margem_Topo = Margem_Topo + 14;
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 225 + Margem_Topo, 198, 64);
                    textFormatter2.DrawString("Quitei(amos) para " + SelectedRow.Cells[11].Value.ToString() + ", a quantia de R$ " + Convert.ToDecimal(quantia).ToString("n2", new CultureInfo("pt-BR")) + " (" + EscreverExtenso.Extenso(Convert.ToDecimal(quantia)) + "), " + tipo_documento + ".", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 225 + Margem_Topo, 198, 64));
                    //
                    textFormatter2.DrawString(" Pagamento       -        Valor Pago (R$)   -   Data   -   Hora", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 289 + Incrementar + Margem_Topo, 198, 8));
                    //
                    textFormatter2.DrawString("____________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 298 + Margem_Topo, 198, 16));
                    //
                    Margem_Topo = Margem_Topo + 2;
                    //
                    for (int i = 0; i < bllContasPagar.Sel_Pagamento_Conta_Pagar(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                    {
                        dr = bllContasPagar.Sel_Pagamento_Conta_Pagar(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                        textFormatter2.DrawString(dr["tipo"].ToString() + "   -   " + Convert.ToDecimal(dr["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")) + "  -   " + dr["data_pagamento"].ToString().Remove(10) + "  -  " + dr["hora_pagamento"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 305 + Margem_Topo, 198, 8));
                        //
                        Incrementar = Incrementar + 8;
                    }
                    textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[17].Value) - (Convert.ToDecimal(SelectedRow.Cells[26].Value) - Convert.ToDecimal(SelectedRow.Cells[27].Value))).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 308 + Margem_Topo, 198, 8));
                    //}
                    //
                    textFormatter2.DrawString("Troco (R$): " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 308 + Margem_Topo, 198, 8));
                    //
                    textFormatter2.DrawString("____________________________________________________", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 300 + Margem_Topo, 198, 16));
                    //
                    //
                    string arqmes;
                    if (Convert.ToDateTime(SelectedRow.Cells[32].Value).Month < 10)
                    {
                        arqmes = "0" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Month;
                    }
                    else
                    {
                        arqmes = Convert.ToDateTime(SelectedRow.Cells[32].Value).Month.ToString();
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString()))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString());
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
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
                    if (bllContasPagar._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
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
                    DataGridViewRow SelectedRow = dtContaPagar.Rows[dtContaPagar.CurrentRow.Index];
                    //
                    tipo_documento = "referente ao pagamento da Conta a Pagar nº " + SelectedRow.Cells[0].Value.ToString();
                    //
                    textFormatter2.DrawString("Código: " + SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 74 + Margem_Topo, 575, 10));
                    //
                    textFormatter3.DrawString("Valor Total Real (R$): " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 74 + Margem_Topo, 575, 10));
                    //}
                    //
                    textFormatter2.DrawString("Data e Hora da Impressão: " + DateTime.Now.ToShortDateString() + "  -  " + DateTime.Now.ToLongTimeString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 83 + Margem_Topo, 575, 10));
                    //
                    DataRow drEmitente = bllContasPagar.Sel_Dados_Emitente_Conta_Pagar(SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[9].Value.ToString()).Rows[0];
                    textFormatter2.DrawString("Emitente: " + SelectedRow.Cells[11].Value.ToString() + "  -  " + drEmitente["cpf_cnpj"].ToString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 94 + Margem_Topo, 570, 10));
                    //
                    string quantia = SelectedRow.Cells[26].Value.ToString();
                    //
                    Margem_Topo = Margem_Topo + 10;
                    //graphics.DrawRectangle(pen, XBrushes.White, 7 + Margem_Esq, AumentoDeLinhaFixo + 120 + Margem_Topo, 570, 22);
                    textFormatter2.DrawString("Quitei(amos) para " + SelectedRow.Cells[11].Value.ToString() + ", a quantia de " + Convert.ToDecimal(quantia).ToString("n2", new CultureInfo("pt-BR")) + " R$ (" + EscreverExtenso.Extenso(Convert.ToDecimal(quantia)) + "), " + tipo_documento + ".", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 105 + Margem_Topo, 570, 22));
                    //
                    textFormatter2.DrawString("Pagamento                                         -                                                 Valor Pago (R$)               -               Data               -               Hora", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 127 + Margem_Topo, 575, 10));
                    //
                    textFormatter2.DrawString("_____________________________________________________________________________________________________________________", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, 128 + Margem_Topo, 570, 10));
                    //
                    for (int i = 0; i < bllContasPagar.Sel_Pagamento_Conta_Pagar(SelectedRow.Cells[0].Value.ToString()).Rows.Count; i++)
                    {
                        dr = bllContasPagar.Sel_Pagamento_Conta_Pagar(SelectedRow.Cells[0].Value.ToString()).Rows[i];
                        //graphics.DrawRectangle(pen, XBrushes.White, 7 + Margem_Esq, AumentoDeLinhaFixo + 154 + Margem_Topo, 260, 10);
                        textFormatter2.DrawString(dr["tipo"].ToString(), fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 138 + Margem_Topo, 260, 10));
                        //graphics.DrawRectangle(pen, XBrushes.White, 265 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                        textFormatter1.DrawString(Convert.ToDecimal(dr["valor_pago"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(265 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                        //graphics.DrawRectangle(pen, XBrushes.White, 380 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                        textFormatter1.DrawString(dr["data_pagamento"].ToString().Remove(10), fonte2, XBrushes.Black, new XRect(380 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                        //graphics.DrawRectangle(pen, XBrushes.White, 475 + Margem_Esq, AumentoDeLinhaFixo + Incrementar + 154 + Margem_Topo, 80, 10);
                        textFormatter1.DrawString(dr["hora_pagamento"].ToString(), fonte2, XBrushes.Black, new XRect(475 + Margem_Esq, Incrementar + 138 + Margem_Topo, 80, 10));
                        Incrementar = Incrementar + 8;
                    }
                    //
                    textFormatter2.DrawString("_____________________________________________________________________________________________________________________", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 132 + Margem_Topo, 570, 10));
                    //
                    textFormatter3.DrawString("Restante a pagar (R$): " + Convert.ToDecimal(Convert.ToDecimal(SelectedRow.Cells[17].Value) - (Convert.ToDecimal(SelectedRow.Cells[26].Value) - Convert.ToDecimal(SelectedRow.Cells[27].Value))).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 142 + Margem_Topo, 575, 10));
                    //}
                    //
                    textFormatter2.DrawString("Troco (R$): " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, Incrementar + 142 + Margem_Topo, 575, 10));
                    //
                    textFormatter2.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte4, XBrushes.Black, new XRect(4 + Margem_Esq, Incrementar + 160 + Margem_Topo, 5, 595));
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
                    if (Convert.ToDateTime(SelectedRow.Cells[32].Value).Month < 10)
                    {
                        arqmes = "0" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Month;
                    }
                    else
                    {
                        arqmes = Convert.ToDateTime(SelectedRow.Cells[32].Value).Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString()))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString());
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
            else if (_Trabalho == 2)
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
                    if (bllContasPagar._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter2.DrawString(DateTime.Now.ToShortTimeString(), fonte1, XBrushes.Black, new XRect(526 + Margem_Esq, 84 + Margem_Topo, page.Width, page.Height));
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
                    textFormatter1.DrawString("Relatório de Contas a Pagar", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("EMITENTE", fonte1, XBrushes.Black, new XRect(85 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("Nº DO DOC.", fonte1, XBrushes.Black, new XRect(165 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("DATA DE VENCIMENTO", fonte1, XBrushes.Black, new XRect(250 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("VALOR REAL (R$)", fonte1, XBrushes.Black, new XRect(400 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString("SITUAÇÃO", fonte1, XBrushes.Black, new XRect(520 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //                  
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtContaPagar.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtContaPagar.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtContaPagar.Rows[linha];
                        //
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtContaPagar.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[9].Value.ToString() == "CLIENTES")
                                {
                                    textFormatter2.DrawString("Cliente:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(134 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[9].Value.ToString() == "FORNECEDORES")
                                {
                                    textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[9].Value.ToString() == "FUNCIONARIOS")
                                {
                                    textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Nº do Documento:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(86 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Vencimento:", fonte2, XBrushes.Black, new XRect(180 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(269 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(335 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(384 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[25].Value.ToString(), fonte4, XBrushes.Black, new XRect(502 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Pago (R$): " + lblValorPago.Text, fonte2, XBrushes.Blue, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("a Pagar (R$): " + lblValorAPagar.Text, fonte2, XBrushes.Red, new XRect(240 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[9].Value.ToString() == "CLIENTES")
                                {
                                    textFormatter2.DrawString("Cliente:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(134 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[9].Value.ToString() == "FORNECEDORES")
                                {
                                    textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[9].Value.ToString() == "FUNCIONARIOS")
                                {
                                    textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Nº do Documento:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(86 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Vencimento:", fonte2, XBrushes.Black, new XRect(180 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(269 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(335 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(384 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[25].Value.ToString(), fonte4, XBrushes.Black, new XRect(502 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;
                            }
                            //
                            if (linha == (pagina - 1) & dtContaPagar.Rows.Count > 16)
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
                                textFormatter1.DrawString("Relatório de Contas a Pagar", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Contas a Pagar", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtContaPagar.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[9].Value.ToString() == "CLIENTES")
                                {
                                    textFormatter2.DrawString("Cliente:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(134 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[9].Value.ToString() == "FORNECEDORES")
                                {
                                    textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[9].Value.ToString() == "FUNCIONARIOS")
                                {
                                    textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Nº do Documento:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(86 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Vencimento:", fonte2, XBrushes.Black, new XRect(180 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(269 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(335 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(384 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[25].Value.ToString(), fonte4, XBrushes.Black, new XRect(502 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Pago (R$): " + lblValorPago.Text, fonte2, XBrushes.Blue, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("a Pagar (R$): " + lblValorAPagar.Text, fonte2, XBrushes.Red, new XRect(240 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(420 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));

                                Incrementar = 36 + Incrementar;
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                if (SelectedRow.Cells[9].Value.ToString() == "CLIENTES")
                                {
                                    textFormatter2.DrawString("Cliente:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(134 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[9].Value.ToString() == "FORNECEDORES")
                                {
                                    textFormatter2.DrawString("Fornecedor:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                else if (SelectedRow.Cells[9].Value.ToString() == "FUNCIONARIOS")
                                {
                                    textFormatter2.DrawString("Funcionário:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                    textFormatter2.DrawString(SelectedRow.Cells[10].Value.ToString() + "—" + SelectedRow.Cells[11].Value.ToString(), fonte4, XBrushes.Black, new XRect(154 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Nº do Documento:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString(), fonte4, XBrushes.Black, new XRect(86 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Vencimento:", fonte2, XBrushes.Black, new XRect(180 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString().Remove(10), fonte4, XBrushes.Black, new XRect(269 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(335 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(384 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Situação:", fonte2, XBrushes.Black, new XRect(460 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[25].Value.ToString(), fonte4, XBrushes.Black, new XRect(502 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.pdf");
                    }
                }
            }
            else if (_Trabalho == 3)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar");
                }
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.txt");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.txt"))
                {
                    writer.WriteLine("Relatório de Contas a Pagar" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToShortTimeString());
                    for (int linha = 0; linha < dtContaPagar.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtContaPagar.Rows[linha];
                        string data_baixa = SelectedRow.Cells[28].Value.ToString();
                        string data_desconto = SelectedRow.Cells[18].Value.ToString();
                        string hora_baixa = SelectedRow.Cells[29].Value.ToString();
                        string cod_usuario = SelectedRow.Cells[34].Value.ToString();
                        string cod_fato_gerador = SelectedRow.Cells[37].Value.ToString();
                        string cod_entidade_bancaria = SelectedRow.Cells[38].Value.ToString();
                        //
                        if (data_desconto == "" || data_desconto == null)
                        {
                            data_desconto = "";
                        }
                        else
                        {
                            data_desconto = data_desconto.Remove(10);
                        }
                        //
                        if (data_baixa == "" || data_baixa == null)
                        {
                            data_baixa = "";
                        }
                        else
                        {
                            data_baixa = data_baixa.Remove(10);
                        }
                        //
                        if (cod_usuario == "0")
                        {
                            cod_usuario = "";
                        }
                        //
                        if (cod_fato_gerador == "0")
                        {
                            cod_fato_gerador = "";
                        }
                        //
                        if (cod_entidade_bancaria == "0")
                        {
                            cod_entidade_bancaria = "";
                        }
                        //
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Descrição: " + SelectedRow.Cells[1].Value.ToString() + " |Contrato/Mátricula/Serviço: " + SelectedRow.Cells[2].Value.ToString() + " |Parcela(s): " + SelectedRow.Cells[3].Value.ToString() + " |Nº do Documento: " + SelectedRow.Cells[4].Value.ToString() + " |Código de Barras: " + SelectedRow.Cells[5].Value.ToString() + " |Data de Emissão: " + SelectedRow.Cells[6].Value.ToString().Remove(10) + " |Data de Vencimento: " + SelectedRow.Cells[7].Value.ToString().Remove(10) + " |Tipo do Documento: " + SelectedRow.Cells[8].Value.ToString() + " |Tipo de Emitente: " + SelectedRow.Cells[9].Value.ToString() + " |Cód. do Emitente: " + SelectedRow.Cells[10].Value.ToString() + " |Nome/Razão Social do Emitente: " + SelectedRow.Cells[11].Value.ToString() + " |Cód. do Grupo: " + SelectedRow.Cells[12].Value.ToString() + " |Descrição do Grupo: " + SelectedRow.Cells[13].Value.ToString() + " |Cód. do Subgrupo: " + SelectedRow.Cells[14].Value.ToString() + " |Descrição do Subgrupo: " + SelectedRow.Cells[15].Value.ToString() + " |Valor (R$): " + Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor Real (R$): " + Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Desconto Até: " + data_desconto + " |Desconto (%): " + Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor do Desconto (R$): " + Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Multa (%): " + Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor da Multa (R$): " + Convert.ToDecimal(SelectedRow.Cells[22].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Juros (a.m) (%): " + Convert.ToDecimal(SelectedRow.Cells[23].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor Juros (a.m) (R$): " + Convert.ToDecimal(SelectedRow.Cells[24].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Situação: " + SelectedRow.Cells[25].Value.ToString() + " |Valor Total Pago (R$): " + Convert.ToDecimal(SelectedRow.Cells[26].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Troco: " + Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Data da Baixa: " + data_baixa + " |Hora da Baixa: " + hora_baixa + " |Observações: " + SelectedRow.Cells[30].Value.ToString() + " |Palavra-chave: " + SelectedRow.Cells[31].Value.ToString() + " |Data de Cadastro: " + SelectedRow.Cells[32].Value.ToString().Remove(10) + " |Cód. do Usuário da Baixa: " + cod_usuario + " |Nome do Usuário da Baixa: " + SelectedRow.Cells[35].Value.ToString() + " |Tabela Geradora: " + SelectedRow.Cells[36].Value.ToString() + " |Cód. do Fato Gerador: " + cod_fato_gerador + " |Cód. da Entidade Bancária: " + cod_entidade_bancaria + " |Descrição da Entidade Bancária: " + SelectedRow.Cells[39].Value.ToString());
                    }
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.txt");
            }
            else if (_Trabalho == 4)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Descrição;Contrato/Mátricula/Serviço;Parcela(s);Nº do Documento;Código de Barras;Data de Emissão;Data de Vencimento;Tipo do Documento;Tipo de Emitente;Cód. do Emitente;Nome/Razão Social do Emitente;Cód. do Grupo;Descrição do Grupo;Cód. do Subgrupo;Descrição do Subgrupo;Valor (R$);Valor Real (R$);Desconto Até;Desconto (%);Valor do Desconto (R$);Multa (%);Valor da Multa (R$);Juros (a.m) (%);Valor Juros (a.m) (R$);Situação;Valor Total Pago (R$);Troco (R$);Data da Baixa;Hora da Baixa;Observações;Palavra-Chave;Data de Cadastro;Cód. do Usuário da Baixa;Nome do Usuário da Baixa;Tabela Geradora;Cód. do Fato Gerador;Cód. da Ent. Bancária;Descrição da Entidade Bancária");
                    for (int linha = 0; linha < dtContaPagar.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtContaPagar.Rows[linha];
                        string data_baixa = SelectedRow.Cells[28].Value.ToString();
                        string data_desconto = SelectedRow.Cells[18].Value.ToString();
                        string hora_baixa = SelectedRow.Cells[29].Value.ToString();
                        string cod_usuario = SelectedRow.Cells[34].Value.ToString();
                        string cod_fato_gerador = SelectedRow.Cells[37].Value.ToString();
                        string cod_entidade_bancaria = SelectedRow.Cells[38].Value.ToString();
                        //
                        if (data_desconto == "" || data_desconto == null)
                        {
                            data_desconto = "";
                        }
                        else
                        {
                            data_desconto = data_desconto.Remove(10);
                        }
                        //
                        if (data_baixa == "" || data_baixa == null)
                        {
                            data_baixa = "";
                        }
                        else
                        {
                            data_baixa = data_baixa.Remove(10);
                        }
                        //
                        if (cod_usuario == "0")
                        {
                            cod_usuario = "";
                        }
                        //
                        if (cod_fato_gerador == "0")
                        {
                            cod_fato_gerador = "";
                        }
                        //
                        if (cod_entidade_bancaria == "0")
                        {
                            cod_entidade_bancaria = "";
                        }
                        //
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22};{23};{24};{25};{26};{27};{28};{29};{30};{31};{32};{33};{34};{35};{36};{37};{38}", SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString().Remove(10), SelectedRow.Cells[7].Value.ToString().Remove(10), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString(), SelectedRow.Cells[12].Value.ToString(), SelectedRow.Cells[13].Value.ToString(), SelectedRow.Cells[14].Value.ToString(), SelectedRow.Cells[15].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[16].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[17].Value).ToString("n2", new CultureInfo("pt-BR")), data_desconto, Convert.ToDecimal(SelectedRow.Cells[19].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[20].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[21].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[22].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[23].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[24].Value.ToString()).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[25].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[26].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[27].Value).ToString("n2", new CultureInfo("pt-BR")), data_baixa, hora_baixa, SelectedRow.Cells[30].Value.ToString(), SelectedRow.Cells[31].Value.ToString(), SelectedRow.Cells[32].Value.ToString().Remove(10), cod_usuario, SelectedRow.Cells[35].Value.ToString(), SelectedRow.Cells[36].Value.ToString(), cod_fato_gerador, cod_entidade_bancaria, SelectedRow.Cells[39].Value.ToString()));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Contas a Pagar");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToShortTimeString());
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.csv");
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
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
                dtContaPagar.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
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
                dtContaPagar.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao3.Enabled = true;
                dtContaPagar.Select();
                //
                try
                {
                    if (_Trabalho == 0)
                    {
                        DataGridViewRow SelectedRow = dtContaPagar.Rows[dtContaPagar.CurrentRow.Index];
                        //
                        string arqmes;
                        if (Convert.ToDateTime(SelectedRow.Cells[32].Value).Month < 10)
                        {
                            arqmes = "0" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Month;
                        }
                        else
                        {
                            arqmes = Convert.ToDateTime(SelectedRow.Cells[32].Value).Month.ToString();
                        }
                        //
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else if (_Trabalho == 1)
                    {
                        DataGridViewRow SelectedRow = dtContaPagar.Rows[dtContaPagar.CurrentRow.Index];
                        //
                        string arqmes;
                        if (Convert.ToDateTime(SelectedRow.Cells[32].Value).Month < 10)
                        {
                            arqmes = "0" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Month;
                        }
                        else
                        {
                            arqmes = Convert.ToDateTime(SelectedRow.Cells[32].Value).Month.ToString();
                        }
                        //
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Comprovantes\" + Convert.ToDateTime(SelectedRow.Cells[32].Value).Year + arqmes + @"\" + SelectedRow.Cells[0].Value.ToString() + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else if (_Trabalho == 2)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Contas a Pagar\Contas a Pagar.pdf");
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
                    dtContaPagar.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao1.Enabled = true;
                    picbInterrogacao3.Enabled = true;
                    btnSair.Enabled = true;
                    rbtnDescricao.Checked = true;
                }
            }
        }

        private void cbbpTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpGrupo.Select();
            }
        }

        private void cbbpGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarSubgrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarSubgrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarGrupo_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmPesqGrupo Grupo = new FrmPesqGrupo(2))
            {
                if (Grupo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpGrupo.Items.Clear();
                        if (bllContasPagar.Sel_Grupo_Conta_Pagar() == null)
                        {
                            cbbpGrupo.Text = null;
                            cbbpGrupo.Enabled = false;
                            cbbpSubGrupo.Text = null;
                            cbbpSubGrupo.Enabled = false;
                            btnProcurarSubgrupo.Enabled = false;
                        }
                        else
                        {
                            cbbpGrupo.Enabled = true;
                            cbbpGrupo.Items.Add("");
                            foreach (DataRow dr in bllContasPagar.Sel_Grupo_Conta_Pagar().Rows)
                            {
                                cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                            cbbpSubGrupo.Enabled = true;
                            btnProcurarSubgrupo.Enabled = true;
                        }
                        cbbpGrupo.Text = bllContasPagar._Grupo_PesqGrupo_Tabela;
                        bllContasPagar._Grupo_PesqGrupo_Tabela = null;
                        cbbpGrupo.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarGrupo.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarGrupo.");
                        }
                        cbbpGrupo.Text = null;
                        bllContasPagar._Grupo_PesqGrupo_Tabela = null;
                    }
                }
            }
            pPanel.Enabled = true;
        }

        private void btnProcurarSubgrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.Text.Split('—');

                    pPanel.Enabled = false;
                    using (FrmPesqSubGrupo Sub = new FrmPesqSubGrupo(items[0], 1))
                    {
                        if (Sub.ShowDialog() == DialogResult.OK)
                        {
                            cbbpSubGrupo.Items.Clear();
                            if (bllContasPagar.Sel_SubGrupo_Conta_Pagar(items[0]) == null)
                            {
                                cbbpSubGrupo.Text = null;
                                cbbpSubGrupo.Enabled = false;
                            }
                            else
                            {
                                cbbpSubGrupo.Enabled = true;
                                cbbpSubGrupo.Items.Add("");
                                foreach (DataRow dr in bllContasPagar.Sel_SubGrupo_Conta_Pagar(items[0]).Rows)
                                {
                                    cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                                }
                            }
                            cbbpSubGrupo.Text = bllContasPagar._SubGrupo_PesqSubGrupo_Tabela;
                            bllContasPagar._SubGrupo_PesqSubGrupo_Tabela = null;
                            cbbpSubGrupo.Select();
                        }
                    }
                    pPanel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar2.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar2.");
                }
                cbbpSubGrupo.Text = null;
                bllContasPagar._SubGrupo_PesqSubGrupo_Tabela = null;
            }
        }

        private void cbbpGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbpGrupo.Text != "")
                {
                    string[] items = cbbpGrupo.SelectedItem.ToString().Split('—');
                    cbbpSubGrupo.Items.Clear();
                    if (bllContasPagar.Sel_SubGrupo_Conta_Pagar(items[0]) == null)
                    {
                        cbbpSubGrupo.Text = null;
                        cbbpSubGrupo.Enabled = false;
                        btnProcurarSubgrupo.Enabled = false;
                    }
                    else
                    {
                        cbbpSubGrupo.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_SubGrupo_Conta_Pagar(items[0]).Rows)
                        {
                            cbbpSubGrupo.Items.Add((dr["id_subgrupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                            cbbpSubGrupo.Enabled = true;
                            btnProcurarSubgrupo.Enabled = true;
                        }
                    }
                }
                else
                {
                    cbbpSubGrupo.Items.Clear();
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnProcurarSubgrupo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do botão cbbGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do botão cbbGrupo.");
                }
                cbbpGrupo.Text = null;
                cbbpSubGrupo.Text = null;
            }
        }

        private void cbbpSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpSubGrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbpSubGrupo_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cbbpSubGrupo.Enabled == true)
                {
                    cbbpSubGrupo.Select();
                }
                else
                {
                    btnPesquisar.Select();
                }
            }
        }

        private void cbbpSubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnTodasContas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTodasContas_MouseLeave(object sender, EventArgs e)
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

        private void btnExportarCsv_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExportarCsv_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnTodasContas_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(5))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    if (bllContasPagar._Tipo_Impressao == "PDF A4")
                    {
                        _Trabalho = 2;
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtContaPagar.Enabled = false;
                    dtContaPagar.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao3.Enabled = false;
                }
            }
            pPanel.Enabled = true;
        }

        private void rbtnExportarTxt_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 3;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtContaPagar.Enabled = false;
            dtContaPagar.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 4;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtContaPagar.Enabled = false;
            dtContaPagar.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao3.Enabled = false;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnDescricao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnPalavraChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPalavraChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnDescricao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbTabela.Visible = false;
                lblEscolha.Visible = false;
                lblDataPagamentos.Enabled = true;
                lblAte2.Enabled = true;
                mtxtDataPag.Enabled = true;
                mtxtDataPag1.Enabled = true;
                btnSelecionarData3.Enabled = true;
                txtpDescricao.Visible = true;
                txtpPalavraChave.Visible = false;
                btnProcurarGrupo.Enabled = true;
                btnProcurarSubgrupo.Enabled = false;
                lblGrupos.Enabled = true;
                cbbpGrupo.Enabled = true;
                lblSubgrupos.Enabled = true;
                cbbpSubGrupo.Enabled = false;
                txtpContratoMatServ.Visible = false;
                lblDataEmissao.Enabled = true;
                lblDataVencimento.Enabled = true;
                mtxtpDataEmi.Enabled = true;
                mtxtpDataEmi1.Enabled = true;
                mtxtpDataVenc.Enabled = true;
                mtxtpDataVenc1.Enabled = true;
                btnSelecionarData1.Enabled = true;
                btnSelecionarData2.Enabled = true;
                lblSituacao.Enabled = true;
                cbbpTipo.Enabled = true;
                Limpar_OutrosFiltros();
                cbbpTipo.Text = null;
                cbbpTipoEmitente.Visible = false;
                btnpProcurar.Visible = false;
                txtpBarra.Visible = false;
                txtpCodigo.Visible = false;
                lblPesquisar.Location = new Point(562, 20);
                cbbpEmitente.Visible = false;
                lblPesquisar.Text = "Digite a descrição:";
                txtpDescricao.Text = null;
                txtpDescricao.Select();
                //
                cbbpEmitente.Items.Clear();
                if (cbbpTipoEmitente.SelectedIndex == 1)
                {
                    if (bllContasPagar.Sel_Cliente_Cont() == null)
                    {
                        cbbpEmitente.Enabled = false;
                        cbbpEmitente.Text = null;
                    }
                    else
                    {
                        cbbpEmitente.Enabled = true;
                        cbbpEmitente.Items.Add("");
                        foreach (DataRow dr in bllContasPagar.Sel_Cliente_Cont().Rows)
                        {
                            cbbpEmitente.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                        }
                    }
                }
                //
                cbbpGrupo.Items.Clear();
                if (bllContasPagar.Sel_Grupo_Conta_Pagar() == null)
                {
                    cbbpGrupo.Text = null;
                    cbbpGrupo.Enabled = false;
                    cbbpSubGrupo.Text = null;
                    cbbpSubGrupo.Enabled = false;
                    btnProcurarSubgrupo.Enabled = false;
                }
                else
                {
                    cbbpGrupo.Enabled = true;
                    cbbpGrupo.Items.Add("");
                    foreach (DataRow dr in bllContasPagar.Sel_Grupo_Conta_Pagar().Rows)
                    {
                        cbbpGrupo.Items.Add((dr["id_grupo"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnDescricao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnDescricao.");
                }
                cbbpGrupo.Items.Clear();
                cbbpGrupo.Text = null;
                cbbpEmitente.Items.Clear();
                cbbpEmitente.Text = null;
            }
        }

        private void rbtnPalavraChave_CheckedChanged(object sender, EventArgs e)
        {
            cbbTabela.Visible = false;
            lblEscolha.Visible = false;
            lblDataPagamentos.Enabled = false;
            lblAte2.Enabled = false;
            mtxtDataPag.Enabled = false;
            mtxtDataPag1.Enabled = false;
            btnSelecionarData3.Enabled = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = true;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblGrupos.Enabled = false;
            cbbpGrupo.Enabled = false;
            lblSubgrupos.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            txtpContratoMatServ.Visible = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData2.Enabled = false;
            lblSituacao.Enabled = false;
            cbbpTipo.Enabled = false;
            Limpar_OutrosFiltros();
            cbbpTipo.Text = null;
            cbbpEmitente.Visible = false;
            cbbpTipoEmitente.Visible = false;
            btnpProcurar.Visible = false;
            txtpBarra.Visible = false;
            txtpCodigo.Visible = false;
            txtpCodigo.MaxLength = 10;
            lblPesquisar.Location = new Point(730, 20);
            lblPesquisar.Text = "Digite a palavra-chave:";
            txtpPalavraChave.Text = null;
            txtpPalavraChave.Select();
        }

        private void mtxtDataPag_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataPag.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataPag.Text == "")
            {
                mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataPag.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataPag_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataPag.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataPag.Text == "")
                {
                    mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataPag.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataPag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataPag1.Select();
            }
        }

        private void mtxtDataPag_Enter(object sender, EventArgs e)
        {
            mtxtDataPag.BackColor = Color.LightBlue;
        }

        private void mtxtDataPag_Leave(object sender, EventArgs e)
        {
            mtxtDataPag.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataPag.Text != "")
            {
                try
                {
                    mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataPag.Text);

                    mtxtDataPag1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataPag1.Text != "")
                    {
                        mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataPag.Text) > Convert.ToDateTime(mtxtDataPag1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataPag.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc.");
                    }
                    mtxtDataPag.Text = null;
                }
            }
            mtxtDataPag.BackColor = Color.White;
        }

        private void mtxtDataPag1_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataPag1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataPag1.Text == "")
            {
                mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataPag1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataPag1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpTipo.Select();
            }
        }

        private void mtxtDataPag1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataPag1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataPag1.Text == "")
                {
                    mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataPag1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataPag1_Enter(object sender, EventArgs e)
        {
            mtxtDataPag1.BackColor = Color.LightBlue;
        }

        private void mtxtDataPag1_Leave(object sender, EventArgs e)
        {
            mtxtDataPag1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataPag1.Text != "")
            {
                try
                {
                    mtxtDataPag1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataPag1.Text);

                    mtxtDataPag.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataPag.Text != "")
                    {
                        mtxtDataPag.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataPag1.Text) < Convert.ToDateTime(mtxtDataPag.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataPag1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataVenc1.");
                    }
                    mtxtDataPag1.Text = null;
                }
            }
            mtxtDataPag1.BackColor = Color.White;
        }

        private void txtpDescricao_Enter(object sender, EventArgs e)
        {
            txtpDescricao.BackColor = Color.LightBlue;
        }

        private void txtpDescricao_Leave(object sender, EventArgs e)
        {
            if (txtpDescricao.Text.Contains("'") || txtpDescricao.Text.Contains(";") || txtpDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpDescricao.Text = null;
                txtpDescricao.Select();
            }
            txtpDescricao.BackColor = Color.White;
        }

        private void txtpDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void txtpPalavraChave_Leave(object sender, EventArgs e)
        {
            if (txtpPalavraChave.Text.Contains("'") || txtpPalavraChave.Text.Contains(";") || txtpPalavraChave.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpPalavraChave.Text = null;
                txtpPalavraChave.Select();
            }
            txtpPalavraChave.BackColor = Color.White;
        }

        private void txtpPalavraChave_Enter(object sender, EventArgs e)
        {
            txtpPalavraChave.BackColor = Color.LightBlue;
        }

        private void txtpPalavraChave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnSelecionarData3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData3_Click(object sender, EventArgs e)
        {
            pPanel.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(1))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataPag1.Select();
                    mtxtDataPag.Text = bllContasPagar._Data_DatePicker1;
                    mtxtDataPag1.Text = bllContasPagar._Data_DatePicker2;
                }
            }
            pPanel.Enabled = true;
        }

        private void grbBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtContaPagar.Rows[dtContaPagar.CurrentRow.Index];
                //
                if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) != 0 & bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == true)
                {
                    MessageBox.Show("Não é possível desfazer este registro porque o caixa está fechado.\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtContaPagar.Select();
                }
                else if (bllContasPagar.Sel_Conta_Pagar_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtContaPagar.Select();
                }
                else if (Convert.ToDateTime(SelectedRow.Cells[28].Value).ToShortDateString() != DateTime.Now.ToShortDateString())
                {
                    MessageBox.Show("A operação não pode ser desfeita: a data de pagamento informada neste registro não corresponde à data atual.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtContaPagar.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja desfazer a baixa do registro selecionado? Todos os dados de pagamento serão excluídos, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        bllContasPagar.Desfazer_Refazer_Baixa_Conta_Pagar(SelectedRow.Cells[0].Value.ToString());
                        //
                        if (SelectedRow.Cells[41].Value.ToString() == "1")
                        {
                            bllContasPagar.Excluir_Pagamento_Conta_Pagar(SelectedRow.Cells[0].Value.ToString());
                            //
                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), "ENTRADA", "CANCELAMENTO DE PAGAMENTO DE CONTA A PAGAR", (Convert.ToDecimal(SelectedRow.Cells[26].Value) - Convert.ToDecimal(SelectedRow.Cells[27].Value)).ToString(), SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                            //
                        }
                        bllRegistroAtividades.Salvar("ABRIU UMA CONTA A PAGAR.", "CONTAS A PAGAR", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //
                        if (bllContasPagar.Sel_Conta_Codigo(SelectedRow.Cells[0].Value.ToString()) == null)
                        {
                            dtContaPagar.DataSource = null;
                        }
                        else
                        {
                            dtContaPagar.DataSource = bllContasPagar.Sel_Conta_Codigo(SelectedRow.Cells[0].Value.ToString());
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDesfazer.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDesfazer.");
                }
            }
        }

        private void btnDesfazer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDesfazer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnDigitalizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDigitalizar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbpGrupo_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void rbtnTabela_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTabela_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTabela_CheckedChanged(object sender, EventArgs e)
        {
            lblDataPagamentos.Enabled = false;
            cbbTabela.Visible = true;
            lblEscolha.Visible = true;
            lblAte2.Enabled = false;
            mtxtDataPag.Enabled = false;
            mtxtDataPag1.Enabled = false;
            btnSelecionarData3.Enabled = false;
            txtpDescricao.Visible = false;
            txtpPalavraChave.Visible = false;
            btnProcurarGrupo.Enabled = false;
            btnProcurarSubgrupo.Enabled = false;
            lblGrupos.Enabled = false;
            cbbpGrupo.Enabled = false;
            lblSubgrupos.Enabled = false;
            cbbpSubGrupo.Enabled = false;
            txtpContratoMatServ.Visible = false;
            lblDataEmissao.Enabled = false;
            lblDataVencimento.Enabled = false;
            mtxtpDataEmi.Enabled = false;
            mtxtpDataEmi1.Enabled = false;
            mtxtpDataVenc.Enabled = false;
            mtxtpDataVenc1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            btnSelecionarData2.Enabled = false;
            lblSituacao.Enabled = false;
            cbbpTipo.Enabled = false;
            Limpar_OutrosFiltros();
            cbbpTipo.Text = "AMBAS";
            cbbpEmitente.Visible = false;
            cbbpTipoEmitente.Visible = false;
            btnpProcurar.Visible = false;
            txtpBarra.Visible = false;
            txtpCodigo.Visible = true;
            txtpCodigo.MaxLength = 10;
            lblPesquisar.Location = new Point(773, 20);
            lblPesquisar.Text = "Digite o código:";
            txtpCodigo.Text = null;
            cbbTabela.Text = "DFE";
            cbbTabela.Select();
        }

        private void cbbTabela_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTabela_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTabela_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbTabela_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbTabela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtpCodigo.Select();
            }
        }
    }
}
