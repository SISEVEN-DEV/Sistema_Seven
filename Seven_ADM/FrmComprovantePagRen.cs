using System;
using System.Windows.Forms;
using BLL;
using System.Diagnostics;
using System.IO;

namespace SIE_7_Sistema
{
    public partial class FrmComprovantePagRen : Form
    {
        public FrmComprovantePagRen(string codigo)
        {
            InitializeComponent();
            _Codigo = codigo;
        }

        string _Codigo;

        private void FrmComprovantePagamento_Load(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmComprovantePagRen iniciado.");
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmComprovantePagRen iniciado.");
            }
            btnEscolherArquivo.Select();
        }

        private void FrmComprovantePagamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnDigitalizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDigitalizar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVisualizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVisualizar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEscolherImagem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEscolherImagem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnDigitalizar_Click(object sender, EventArgs e)
        {
            using(FrmSelecionarScanner Scan = new FrmSelecionarScanner(7, _Codigo))
            {
                if (Scan.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(@"C:\7 Sistema\Documentos\Conta a Pagar\" + _Codigo + @"\Comprovante"))
                {
                    DirectoryInfo dir = new DirectoryInfo(@"C:\7 Sistema\Documentos\Conta a Pagar\" + _Codigo + @"\Comprovante");

                    if (dir.GetFiles().Length <= 0)
                    {
                        MessageBox.Show("Ainda não existem comprovantes para esta conta a pagar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        Process.Start(@"C:\7 Sistema\Documentos\Conta a Pagar\" + _Codigo + @"\Comprovante");
                        using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Arquivo visualizado.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Arquivo visualizado.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ainda não existem comprovantes para esta conta a pagar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnVisualizar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnVisualizar.");
                }
            }
        }

        private void btnEscolherImagem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    file.Title = "Selecione um arquivo";
                    file.Filter = "Arquivo no formato:(*.PDF;*.BMP;*.JPG;*.GIF;*.PNG;*.XPS;*.DOC;*.XLS;*.TXT;*.XML)|*.PDF;*.BMP;*.JPG;*.GIF;*.PNG*.XPS;*.DOC;*.XLS;*.TXT;*.XML";
                    file.InitialDirectory = @"C:\";

                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        if (!Directory.Exists(@"C:\7 Sistema\Documentos\Conta a Pagar\" + _Codigo + @"\Comprovante"))
                        {
                            Directory.CreateDirectory(@"C:\7 Sistema\Documentos\Conta a Pagar\" + _Codigo + @"\Comprovante");

                            File.Copy(file.FileName, @"C:\7 Sistema\Documentos\Conta a Pagar\" + _Codigo + @"\Comprovante\" + file.SafeFileName);

                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Arquivo salvo.");
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Arquivo salvo.");
                            }

                            this.DialogResult = DialogResult.Abort;
                        }
                        else
                        {
                            if (File.Exists(@"C:\7 Sistema\Documentos\Conta a Pagar\" + _Codigo + @"\Comprovante\" + file.SafeFileName))
                            {
                               MessageBox.Show("Já existe um arquivo com este nome, por favor verifique e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                            }
                            else
                            {
                                File.Copy(file.FileName, @"C:\7 Sistema\Documentos\Conta a Pagar\" + _Codigo + @"\Comprovante\" + file.SafeFileName);

                                MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Arquivo salvo.");
                                }
                                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                                {
                                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Arquivo salvo.");
                                }

                                this.DialogResult = DialogResult.Abort;
                            }
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        btnEscolherArquivo.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEscolherImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEscolherImagem.");
                }
            }
        }

        private void FrmComprovantePagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário comprovante de pagamento foi finalizado.");
            }

            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário comprovante de pagamento foi finalizado.");
            }

            if (this.DialogResult != DialogResult.Abort)
            {
                e.Cancel = true;
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Escolher um arquivo do computador: Você vai selecionar um arquivo no seu computador.\n\n2 - Digitalizar documentos: Significa que você vai digitalizar com seu scanner um documento para deixar salvo no sistema.\n\n3 - Tirar uma Foto: Significa que você vai tirar uma foto com sua câmera ou webcam do documento para deixar salvo no sistema.\n\n4 - Visualizar comprovantes: Clicando nesta opção você poderá visualizar os comprovantes que foram salvos no sistema.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnTirarFoto_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTirarFoto_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnTirarFoto_Click(object sender, EventArgs e)
        {
            using (FrmCapturarImagemWebCam WebCam = new FrmCapturarImagemWebCam(7, _Codigo))
            {
                if (WebCam.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
        }
    }
}
