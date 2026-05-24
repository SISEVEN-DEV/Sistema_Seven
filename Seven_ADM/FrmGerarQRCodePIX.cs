using ACBrLib.Core.PIXCD;
using ACBrLib.PIXCD;
using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using QRCoder;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;


namespace Seven_Sistema
{
    public partial class FrmGerarQRCodePIX : Form
    {
        public FrmGerarQRCodePIX(byte formulario, string valor, string cliecons, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            //
            _Formulario = formulario;
            _Valor = valor;
            _ClieCons = cliecons;
            _Usuario = usuario;
            _Cod_PDV_computador = cod_pdv_computador;
        }

        private byte _Formulario;
        private string _Valor;
        private string _Chave_Pix;
        private string _ClieCons;
        private string _Usuario;
        private string _Cod_PDV_computador;

        private void FrmGerarQRCodePIX_Load(object sender, EventArgs e)
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
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmGerarQRCodePIX iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmGerarQRCodePIX iniciado.");
                }
                //
                cbbPSP.Items.Clear();
                if (bllPSP.Sel_PSPPIX_PSP() == null)
                {
                    cbbPSP.Text = null;
                }
                else
                {
                    cbbPSP.Items.Add("");
                    foreach (DataRow dr in bllPSP.Sel_PSPPIX_PSP().Rows)
                    {
                        cbbPSP.Items.Add(dr["id_psp"].ToString() + "—" + dr["chave_pix"].ToString());
                    }
                }
                //
                if (_Formulario == 1)
                {
                    cbbPSP.SelectedIndex = 1;
                }
                //
                txtPIXCopiaCola.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmGerarQRCodePIX.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmGerarQRCodePIX.");
                }
            }
        }

        private Bitmap GerarQRCode(string pix)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(pix, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(7);
        }

        private void FrmGerarQRCodePIX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                this.DialogResult = DialogResult.Abort;
            }
            else if (_Formulario == 1)
            {

                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnCopiarChave_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPIXCopiaCola.Text);
        }

        private void btnEnviarZap_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEnviarZap_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImprimir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImprimir_MouseLeave(object sender, EventArgs e)
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

        private void btnGerarPIXCopiaCola_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnGerarPIXCopiaCola_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorPagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor a pagar: " + Convert.ToDecimal(_Valor).ToString("n2", new CultureInfo("pt-BR")) + " R$", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnCopiarChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCopiarChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                using (FrmInfImpressao Imp = new FrmInfImpressao(47))
                {
                    if (Imp.ShowDialog() == DialogResult.OK)
                    {
                        if (bllPSP._Tipo_Impressao == "PDF A4")
                        {
                            this.Cursor = Cursors.WaitCursor;
                            //
                            using (var doc = new PdfDocument())
                            {
                                var page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                var graphics = XGraphics.FromPdfPage(page);
                                var textFormatter1 = new XTextFormatter(graphics);
                                var fonte1 = new XFont("Microsoft Sans Serif", 25, XFontStyle.Bold);
                                var fonte2 = new XFont("Microsoft Sans Serif", 15, XFontStyle.Bold);
                                //
                                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                textFormatter1.DrawString(lblValorPagar.Text, fonte1, XBrushes.Black, new XRect(10 + Margem_Esq, 220 + Margem_Topo, page.Width, page.Height));
                                //
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    pcibQRCode.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    //
                                    XImage imagem1 = XImage.FromStream(ms);
                                    //
                                    graphics.DrawImage(imagem1, 75 + Margem_Esq, 250 + Margem_Topo, 450, 450);
                                }
                                //
                                textFormatter1.DrawString(_Chave_Pix, fonte2, XBrushes.Black, new XRect(10 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
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
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX");
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX\QRCODE.pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX\QRCODE.pdf");
                                }
                            }
                        }
                        else if (bllPSP._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                        {
                            using (var doc = new PdfDocument())
                            {
                                DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                //
                                var page = doc.AddPage();
                                //
                                page.Width = 203;
                                page.Height = 842;
                                //                       
                                var graphics = XGraphics.FromPdfPage(page);
                                var textFormatter1 = new XTextFormatter(graphics);
                                //
                                var fonte1 = new XFont("Courrier Regular", 12, XFontStyle.Bold);
                                var fonte2 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                XPen pen1 = new XPen(XColors.White);
                                XPen pen = new XPen(XColors.Black);
                                //
                                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                                //
                                textFormatter1.DrawString(lblValorPagar.Text, fonte1, XBrushes.Black, new XRect(0 + Margem_Esq, 55 + Margem_Topo, page.Width, page.Height));
                                //
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    pcibQRCode.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    //
                                    XImage imagem1 = XImage.FromStream(ms);
                                    //
                                    graphics.DrawImage(imagem1, 28 + Margem_Esq, 75 + Margem_Topo, 150, 150);
                                }
                                //
                                textFormatter1.DrawString(_Chave_Pix, fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 270 + Margem_Topo, page.Width, page.Height));
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
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX");
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX\QRCODE.pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX\QRCODE.pdf");
                                }
                            }
                        }
                        else if (bllPSP._Tipo_Impressao == "PDF Impressora Térmica(58mm)")
                        {
                            using (var doc = new PdfDocument())
                            {
                                DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                //
                                var page = doc.AddPage();
                                //
                                page.Width = 140;
                                page.Height = 842;
                                //                       
                                var graphics = XGraphics.FromPdfPage(page);
                                var textFormatter1 = new XTextFormatter(graphics);
                                //
                                var fonte1 = new XFont("Courrier Regular", 12, XFontStyle.Bold);
                                var fonte2 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                XPen pen1 = new XPen(XColors.White);
                                XPen pen = new XPen(XColors.Black);
                                //
                                int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                                int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                                //
                                textFormatter1.DrawString(lblValorPagar.Text, fonte1, XBrushes.Black, new XRect(0 + Margem_Esq, 55 + Margem_Topo, page.Width, page.Height));
                                //
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    pcibQRCode.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    //
                                    XImage imagem1 = XImage.FromStream(ms);
                                    //
                                    graphics.DrawImage(imagem1, 15 + Margem_Esq, 75 + Margem_Topo, 110, 110);
                                }
                                //
                                textFormatter1.DrawString(_Chave_Pix, fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 270 + Margem_Topo, page.Width, page.Height));
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
                                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX"))
                                {
                                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX");
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX\QRCODE.pdf");
                                }
                                else
                                {
                                    doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX\QRCODE.pdf");
                                }
                            }
                        }
                        //
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PSPPIX\QRCODE.pdf");
                    }
                }
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnImprimir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnImprimir.");
                }
            }
        }

        private void btnEnviarZap_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo;

                if (_ClieCons == null)
                {
                    codigo = null;
                }
                else
                {
                    string[] items = _ClieCons.Split('—');
                    //
                    codigo = items[0];
                }
                //
                using (FrmCelular Cel = new FrmCelular(codigo, _Cod_PDV_computador, _Usuario))
                {
                    if (Cel.ShowDialog() == DialogResult.OK)
                    {
                        DialogResult = MessageBox.Show("Você será direcionado para o whatsapp, deseja continuar?", "Ajuda", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.None;
                            //
                            string mensagem = "*PIX*\n\n*Valor:*\n" + lblValorPagar.Text + "\n\n*Chave PIX:*\n" + _Chave_Pix + "\n\n*PIX Copia e Cola:*\n" + txtPIXCopiaCola.Text;
                            //
                            string encodedMessage = HttpUtility.UrlEncode(mensagem);
                            //
                            string url = $"https://wa.me/55{Regex.Replace(bllPSP._Celular, "[^0-9]", "")}?text={encodedMessage}";
                            //
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = url,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            this.DialogResult = DialogResult.None;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarZAP.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarZAP.");
                }
            }
        }

        private void FrmGerarQRCodePIX_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmGerarQRCodePIX foi finalizado.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmGerarQRCodePIX foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmGerarQRCodePIX.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmGerarQRCodePIX.");
                }
            }
        }

        private void cbbPSP_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbPSP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbPSP_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbPSP_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqPSPPIX PSP = new FrmPesqPSPPIX(0))
            {
                if (PSP.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbPSP.Items.Clear();
                        if (bllPSP.Sel_PSPPIX_PSP() == null)
                        {
                            cbbPSP.Text = null;
                        }
                        else
                        {
                            cbbPSP.Items.Add("");
                            foreach (DataRow dr in bllPSP.Sel_PSPPIX_PSP().Rows)
                            {
                                cbbPSP.Items.Add(dr["id_psp"].ToString() + "—" + dr["chave_pix"].ToString());
                            }
                        }
                        //
                        cbbPSP.Text = bllPSP._PSPPIX_PesqPSPPIX_Tabela;
                        bllPSP._PSPPIX_PesqPSPPIX_Tabela = null;
                        cbbPSP.Select();
                    }
                    catch (Exception ex)
                    {
                        this.Enabled = true;
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
                        cbbPSP.Text = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void cbbPSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbPSP.Text != "")
                {
                    string[] items = cbbPSP.Text.Split('—');
                    //
                    DataRow dr = bllPSP.Sel_PSP_Codigo(items[0]).Rows[0];
                    //
                    ACBrPIXCD Pix = new ACBrPIXCD(@"C:\Sistema SEVEN\" + bllConexao._Codigo_Conexao + "pix.ini");
                    //
                    if (dr["nome_psp"].ToString() == "MERCADO PAGO")
                    {
                        if (dr["ambiente"].ToString() == "TESTE")
                        {
                            Pix.Config.Ambiente = Ambiente.ambTeste;
                        }
                        else if (dr["ambiente"].ToString() == "PRÉ-PRODUÇÃO")
                        {
                            Pix.Config.Ambiente = Ambiente.ambPreProducao;
                        }
                        else if (dr["ambiente"].ToString() == "PRODUÇÃO")
                        {
                            Pix.Config.Ambiente = Ambiente.ambProducao;
                        }
                        //
                        Pix.Config.NivelLog = NivelLogPSP.logPSPNenhum;
                        //
                        if (dr["tipo_chave"].ToString() == "ALEATORIA")
                        {
                            Pix.Config.TipoChave = TipoChave.tchAleatoria;
                            //
                            Pix.Config.MercadoPago.ChavePIX = dr["chave_pix"].ToString();
                        }
                        else if (dr["tipo_chave"].ToString() == "CELULAR")
                        {
                            Pix.Config.TipoChave = TipoChave.tchCelular;
                            //
                            Pix.Config.MercadoPago.ChavePIX = "+55" + dr["chave_pix"].ToString();
                        }
                        else if (dr["tipo_chave"].ToString() == "CNPJ")
                        {
                            Pix.Config.TipoChave = TipoChave.tchCNPJ;
                            //
                            Pix.Config.MercadoPago.ChavePIX = dr["chave_pix"].ToString();
                        }
                        else if (dr["tipo_chave"].ToString() == "CPF")
                        {
                            Pix.Config.TipoChave = TipoChave.tchCPF;
                            //
                            Pix.Config.MercadoPago.ChavePIX = dr["chave_pix"].ToString();
                        }
                        else if (dr["tipo_chave"].ToString() == "EMAIL")
                        {
                            Pix.Config.TipoChave = TipoChave.tchEmail;
                            //
                            Pix.Config.MercadoPago.ChavePIX = dr["chave_pix"].ToString();
                        }
                        //
                        Pix.Config.PSP = PSP.pspMercadoPago;
                        //
                        Pix.Config.Timeout = Convert.ToInt32(dr["timeout"]);
                        //
                        Pix.Config.ProxyHost = null;
                        //
                        Pix.Config.ProxyPass = null;
                        //
                        Pix.Config.ProxyPort = 0;
                        //
                        Pix.Config.ProxyUser = null;
                        //
                        Pix.Config.CEPRecebedor = dr["cep"].ToString();
                        //
                        Pix.Config.CidadeRecebedor = dr["Cidade"].ToString();
                        //
                        Pix.Config.NomeRecebedor = dr["nome_recebedor"].ToString();
                        //
                        Pix.Config.UFRecebedor = dr["uf"].ToString();
                        //
                        Pix.Config.MercadoPago.AccessToken = dr["acess_token"].ToString();
                        //
                        Pix.Config.MercadoPago.Scopes = dr["scopes"].ToString();
                    }
                    else if (dr["nome_psp"].ToString() == "INTER")
                    {
                        if (dr["ambiente"].ToString() == "TESTE")
                        {
                            Pix.Config.Ambiente = Ambiente.ambTeste;
                        }
                        else if (dr["ambiente"].ToString() == "PRÉ-PRODUÇÃO")
                        {
                            Pix.Config.Ambiente = Ambiente.ambPreProducao;
                        }
                        else if (dr["ambiente"].ToString() == "PRODUÇÃO")
                        {
                            Pix.Config.Ambiente = Ambiente.ambProducao;
                        }
                        //
                        Pix.Config.NivelLog = NivelLogPSP.logPSPNenhum;
                        //
                        if (dr["tipo_chave"].ToString() == "ALEATORIA")
                        {
                            Pix.Config.TipoChave = TipoChave.tchAleatoria;
                            //
                            Pix.Config.Inter.ChavePIX = dr["chave_pix"].ToString();
                        }
                        else if (dr["tipo_chave"].ToString() == "CELULAR")
                        {
                            Pix.Config.TipoChave = TipoChave.tchCelular;
                            //
                            Pix.Config.Inter.ChavePIX = "+55" + dr["chave_pix"].ToString();
                        }
                        else if (dr["tipo_chave"].ToString() == "CNPJ")
                        {
                            Pix.Config.TipoChave = TipoChave.tchCNPJ;
                            //
                            Pix.Config.Inter.ChavePIX = dr["chave_pix"].ToString();
                        }
                        else if (dr["tipo_chave"].ToString() == "CPF")
                        {
                            Pix.Config.TipoChave = TipoChave.tchCPF;
                            //
                            Pix.Config.Inter.ChavePIX = dr["chave_pix"].ToString();
                        }
                        else if (dr["tipo_chave"].ToString() == "EMAIL")
                        {
                            Pix.Config.TipoChave = TipoChave.tchEmail;
                            //
                            Pix.Config.Inter.ChavePIX = dr["chave_pix"].ToString();
                        }
                        //
                        Pix.Config.PSP = PSP.pspInter;
                        //
                        Pix.Config.Timeout = Convert.ToInt32(dr["timeout"]);
                        //
                        Pix.Config.ProxyHost = null;
                        //
                        Pix.Config.ProxyPass = null;
                        //
                        Pix.Config.ProxyPort = 0;
                        //
                        Pix.Config.ProxyUser = null;
                        //
                        Pix.Config.CEPRecebedor = dr["cep"].ToString();
                        //
                        Pix.Config.CidadeRecebedor = dr["Cidade"].ToString();
                        //
                        Pix.Config.NomeRecebedor = dr["nome_recebedor"].ToString();
                        //
                        Pix.Config.UFRecebedor = dr["uf"].ToString();
                        //
                        Pix.Config.Inter.Scopes = dr["scopes"].ToString();
                    }
                    //
                    _Chave_Pix = Pix.Config.Inter.ChavePIX;
                    //
                    txtPIXCopiaCola.Text = Pix.GerarQRCodeEstatico(Convert.ToDouble(_Valor), null, null);
                    //
                    Pix.Dispose();
                    Pix = null;
                    //
                    lblValorPagar.Text = "R$ " + Convert.ToDecimal(_Valor).ToString("n2", new CultureInfo("pt-BR"));
                    //
                    pcibQRCode.Image = GerarQRCode(txtPIXCopiaCola.Text);
                    //
                    btnCopiar.Select();
                    //
                    pcibQRCode.Enabled = true;
                    btnCopiar.Enabled = true;
                    txtPIXCopiaCola.Enabled = true;
                    btnImprimir.Enabled = true;
                    btnEnviarZap.Enabled = true;
                    lblValorPagar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário cbbPSP.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário cbbPSP.");
                }
                pcibQRCode.Enabled = false;
                btnCopiar.Enabled = false;
                txtPIXCopiaCola.Enabled = false;
                btnImprimir.Enabled = false;
                btnEnviarZap.Enabled = false;
                lblValorPagar.Enabled = false;
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Imprimir: Imprime o QR Code gerado na tela em uma impressora específica.\n\n2 - Enviar ZAP: Clique para enviar o Pix Copia e Cola pelo whatsapp web.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
