using BLL;
using System;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmImagemOpcoes : Form
    {
        public FrmImagemOpcoes(bool contem_imagem, byte form)
        {
            InitializeComponent();
            if (contem_imagem == false)
            {
                btnVisualizar.Enabled = false;
                btnExcluirImg.Enabled = false;
            }
            else
            {
                btnVisualizar.Enabled = true;
                btnExcluirImg.Enabled = true;
            }
            _Formulario = form;
        }

        byte _Formulario;

        private void btnEscolherImagem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    file.Title = "Selecione uma imagem";
                    file.Filter = "Imagens no formato:(*.bmp;*.jpg;*.gif;*.png|*.bmp;*.jpg;*.gif;*.png";
                    file.InitialDirectory = @"C:\";

                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        if (_Formulario == 0)
                        {
                            bllClieCons._Url_Imagem = file.FileName;
                            DialogResult = DialogResult.OK;
                        }
                        else if (_Formulario == 1)
                        {
                            bllFornecedor._Url_Imagem = file.FileName;
                            DialogResult = DialogResult.OK;
                        }
                        else if (_Formulario == 2)
                        {
                            bllConfiguracaoSistema._Url_Imagem_Comp = file.FileName;
                            DialogResult = DialogResult.OK;
                        }
                        else if (_Formulario == 3)
                        {
                            bllFuncionario._Url_Imagem = file.FileName;
                            DialogResult = DialogResult.OK;
                        }
                        else if (_Formulario == 4)
                        {
                            bllProduto._Url_Imagem = file.FileName;
                            DialogResult = DialogResult.OK;
                        }
                        else if (_Formulario == 5)
                        {
                            bllMinhaEmpresa._Url_Imagem = file.FileName;
                            DialogResult = DialogResult.OK;
                        }
                        else if (_Formulario == 6)
                        {
                            bllOS._Url_Imagem = file.FileName;
                            DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        btnEscolherImagem.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do botão btnEscolherImagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do botão btnEscolherImagem.");
                }
            }
        }

        private void FrmImagemOpcoes_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmImagemOpcoes iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmImagemOpcoes iniciado.");
                }
                //
                if (_Formulario == 2)
                {
                    ttpInserirImagem.Active = false;
                }
                else if (_Formulario == 5)
                {
                    btnTirarFoto.Enabled = false;
                }
                btnEscolherImagem.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmImagemOpcoes.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmImagemOpcoes.");
                }
            }
        }

        private void btnEscolherImagem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEscolherImagem_MouseLeave(object sender, EventArgs e)
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

        private void btnVisualizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVisualizar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void FrmImagemOpcoes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                bllClieCons._Mostrar_Imagem = true;
            }
            else if (_Formulario == 1)
            {
                bllFornecedor._Mostrar_Imagem = true;
            }
            else if (_Formulario == 3)
            {
                bllFuncionario._Mostrar_Imagem = true;
            }
            else if (_Formulario == 4)
            {
                bllProduto._Mostrar_Imagem = true;
            }
            else if (_Formulario == 5)
            {
                bllMinhaEmpresa._Mostrar_Imagem = true;
            }
            else if (_Formulario == 6)
            {
                bllOS._Mostrar_Imagem = true;
            }
            DialogResult = DialogResult.OK;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Escolher uma imagem do computador: Permite você navegar por seu computador para localizar uma imagem.\n\n2 - Tirar uma foto: Permite você tirar uma foto com o dispositivo de câmera conectado ao seu computador.\n\n3 - Visualizar imagem: Permite você visualizar uma imagem que antes foi escolhida através do visualizador de fotos padrão do windows\n\n4 - Excluir imagem: Exclui a imagem atual.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnExcluirImg_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                bllClieCons._Excluir_Imagem = true;
                MessageBox.Show("Imagem removida.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Formulario == 1)
            {
                bllFornecedor._Excluir_Imagem = true;
                MessageBox.Show("Imagem removida.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Formulario == 2)
            {
                bllConfiguracaoSistema._Url_Imagem_Comp = null;
                MessageBox.Show("Imagem removida.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Formulario == 3)
            {
                bllFuncionario._Excluir_Imagem = true;
                MessageBox.Show("Imagem removida.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Formulario == 4)
            {
                bllProduto._Excluir_Imagem = true;
                MessageBox.Show("Imagem removida.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Formulario == 5)
            {
                bllMinhaEmpresa._Excluir_Imagem = true;
                MessageBox.Show("Imagem removida com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Formulario == 6)
            {
                bllOS._Excluir_Imagem = true;
                MessageBox.Show("Imagem removida com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DialogResult = DialogResult.OK;
        }

        private void btnExcluirImg_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluirImg_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnTirarFoto_Click(object sender, EventArgs e)
        {
            using (FrmCapturarImagemWebCam WebCam = new FrmCapturarImagemWebCam(_Formulario))
            {
                if (WebCam.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    btnEscolherImagem.Select();
                }
            }
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmImagemOpcoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmImagemOpcoes foi finalizado.");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmImagemOpcoes foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmImagemOpcoes.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmImagemOpcoes.");
                }
            }
        }
    }
}
