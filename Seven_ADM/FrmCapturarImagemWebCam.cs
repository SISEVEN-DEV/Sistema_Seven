//using AForge.Video;
//using AForge.Video.DirectShow;
using BLL;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCapturarImagemWebCam : Form
    {
        //private FilterInfoCollection _VideoCaptureDevices;
        //private VideoCaptureDevice _Capturar_Dispositivos;

        public FrmCapturarImagemWebCam(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        public FrmCapturarImagemWebCam(byte formulario, string codigo)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Codigo = codigo;
        }

        private byte _Formulario;
        private bool _Camera;
        private string _Codigo;

        private void FrmCapturarImagemWebCam_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCapturarImagemWebCam iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCapturarImagemWebCam iniciado.");
                }

                //_VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                /*
                foreach (FilterInfo VideoCaptureDevice in _VideoCaptureDevices)
                {
                    if (cbbCamera.Items.Count == 0)
                    {
                        cbbCamera.Items.Add(VideoCaptureDevice.Name);
                        cbbCamera.Text = VideoCaptureDevice.Name;
                    }
                    else
                    {
                        cbbCamera.Items.Add(VideoCaptureDevice.Name);
                    }
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCapturarWebCam.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCapturarWebCam.");
                }
            }
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
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

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            try
            {
                lblImagem.Text = "Imagem capturada pelo dispositivo de câmera:";
                Bitmap pic = new Bitmap(pcibImagemWebCam.Image);
                pcibImagemCapturada.Image = pic;
                pic = null;
                btnSalvar.Enabled = true;
                btnSalvar.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do botão btnCapturar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do botão btnCapturar.");
                }
            }
        }

        private void FrmCapturarImagemWebCam_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Formulario == 6)
                {
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Formulario == 0)
                {
                    using (FrmNomeArquivo Arquivo = new FrmNomeArquivo(_Formulario, null, null))
                    {
                        if (Arquivo.ShowDialog() == DialogResult.OK)
                        {
                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem"))
                            {
                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem");
                                pcibImagemCapturada.Image.Save(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\" + bllClieCons._Nome_Arquivo, ImageFormat.Jpeg);
                                bllClieCons._Url_Imagem = @"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\" + bllClieCons._Nome_Arquivo;
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                pcibImagemCapturada.Image.Save(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\" + bllClieCons._Nome_Arquivo, ImageFormat.Jpeg);
                                bllClieCons._Url_Imagem = @"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\" + bllClieCons._Nome_Arquivo;
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                }
                else if (_Formulario == 1)
                {
                    using (FrmNomeArquivo Arquivo = new FrmNomeArquivo(_Formulario, null, null))
                    {
                        if (Arquivo.ShowDialog() == DialogResult.OK)
                        {
                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem"))
                            {
                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem");
                                pcibImagemCapturada.Image.Save(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + bllFornecedor._Nome_Arquivo, ImageFormat.Jpeg);
                                bllFornecedor._Url_Imagem = @"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + bllFornecedor._Nome_Arquivo;
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                pcibImagemCapturada.Image.Save(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + bllFornecedor._Nome_Arquivo, ImageFormat.Jpeg);
                                bllFornecedor._Url_Imagem = @"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + bllFornecedor._Nome_Arquivo;
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                }
                else if (_Formulario == 2)
                {
                    using (FrmNomeArquivo Arquivo = new FrmNomeArquivo(_Formulario, null, null))
                    {
                        if (Arquivo.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                }
                else if (_Formulario == 3)
                {
                    using (FrmNomeArquivo Arquivo = new FrmNomeArquivo(_Formulario, null, null))
                    {
                        if (Arquivo.ShowDialog() == DialogResult.OK)
                        {
                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem"))
                            {
                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem");
                                pcibImagemCapturada.Image.Save(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + bllFuncionario._Nome_Arquivo, ImageFormat.Jpeg);
                                bllFuncionario._Url_Imagem = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + bllFuncionario._Nome_Arquivo;
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                pcibImagemCapturada.Image.Save(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + bllFuncionario._Nome_Arquivo, ImageFormat.Jpeg);
                                bllFuncionario._Url_Imagem = @"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + bllFuncionario._Nome_Arquivo;
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                }
                else if (_Formulario == 4)
                {
                    using (FrmNomeArquivo Arquivo = new FrmNomeArquivo(_Formulario, null, null))
                    {
                        if (Arquivo.ShowDialog() == DialogResult.OK)
                        {
                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem"))
                            {
                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem");
                                pcibImagemCapturada.Image.Save(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + bllProduto._Nome_Arquivo, ImageFormat.Jpeg);
                                bllProduto._Url_Imagem = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + bllProduto._Nome_Arquivo;
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                pcibImagemCapturada.Image.Save(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + bllProduto._Nome_Arquivo, ImageFormat.Jpeg);
                                bllProduto._Url_Imagem = @"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + bllProduto._Nome_Arquivo;
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                }
                else if (_Formulario == 6)
                {
                    using (FrmNomeArquivo Arquivo = new FrmNomeArquivo(_Formulario, null, null))
                    {
                        if (Arquivo.ShowDialog() == DialogResult.OK)
                        {
                            if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\OS\Imagem"))
                            {
                                Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\OS\Imagem");
                                pcibImagemCapturada.Image.Save(@"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\" + bllOS._Nome_Arquivo, ImageFormat.Jpeg);
                                bllOS._Url_Imagem = @"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\" + bllOS._Nome_Arquivo;
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                pcibImagemCapturada.Image.Save(@"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\" + bllOS._Nome_Arquivo, ImageFormat.Jpeg);
                                bllOS._Url_Imagem = @"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\" + bllOS._Nome_Arquivo;
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Imagem capturada.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Imagem capturada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do botão btnSalvar.");
                }
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

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Ligar câmera: Aciona o disposistivo de câmera conectado ao seu computador.\n\n2 - Capturar imagem: Clique para tirar uma foto com sua câmera conectada ao seu computador.\n\n3 - Salvar imagem: Após clicar em capturar imagem, clique para salvar e escolher a imagem capturada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnLigarCamera_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbCamera.Text == "")
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido:\n[ Selecionar Câmera ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbbCamera.Select();
                }
                else
                {
                    /*
                    if (_Capturar_Dispositivos.IsRunning == true)
                    {
                        _Capturar_Dispositivos.Stop();
                    }

                    //_Capturar_Dispositivos = new VideoCaptureDevice(_VideoCaptureDevices[cbbCamera.SelectedIndex].MonikerString);
                    //_Capturar_Dispositivos.NewFrame += new NewFrameEventHandler(_Capturar_Dispositivos_NewFrame);
                    _Capturar_Dispositivos.Start();
                    btnSelecionar.Enabled = false;
                    cbbCamera.Enabled = false;
                    btnCapturar.Enabled = true;
                    */
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do botão btnLigarCamera.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do botão btnLigarCamera.");
                }
            }
        }

        /*
        void _Capturar_Dispositivos_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap video = (Bitmap)eventArgs.Frame.Clone();
                pcibImagemWebCam.Image = video;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Método _Capturar_Dispositivos_NewFrame.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Método _Capturar_Dispositivos_NewFrame.");
                }
            }
        }
        */

        private void cbbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _Camera = true;

                //_Capturar_Dispositivos = new VideoCaptureDevice();

                btnCapturar.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do combobox cbbCamera.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento selectedindex do combobox cbbCamera.");
                }
                _Camera = false;
            }
            btnSelecionar.Enabled = true;
        }

        private void FrmCapturarImagemWebCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCapturarImagemWebCam foi finalizado.");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCapturarImagemWebCam foi finalizado.");
                }
                //
                if (_Camera == true)
                {
                    /*
                    if (_Capturar_Dispositivos.IsRunning == true)
                    {
                        _Capturar_Dispositivos.Stop();
                        _VideoCaptureDevices = null;
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCapturarWebCam.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCapturarWebCam.");
                }
            }


        }

        private void btnSelecionar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCamera_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCamera_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void pcibImagemWebCam_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }

        private void pcibImagemWebCam_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibImagemCapturada_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }

        private void pcibImagemCapturada_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCamera_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCamera_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCamera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSelecionar.Select();
            }
        }
    }
}
