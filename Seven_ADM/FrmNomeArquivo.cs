using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmNomeArquivo : Form
    {
        public FrmNomeArquivo(byte formulario, string cod_pdv_computador, string codigo)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Codigo = codigo;
        }

        byte _Formulario;
        string _Cod_PDV_Computador;
        string _Codigo;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomeArquivo.Text.Trim() == "")
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido: [ Nome do arquivo ]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeArquivo.Select();
                }
                else
                {
                    if (_Formulario == 0)
                    {
                        if (File.Exists(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\" + txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg")))
                        {
                            File.Delete(@"C:\Windows\Temp\Sistema SEVEN\Clientes\Imagem\" + txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg"));
                            bllClieCons._Nome_Arquivo = txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            bllClieCons._Nome_Arquivo = txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 1)
                    {
                        if (File.Exists(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg")))
                        {
                            File.Delete(@"C:\Windows\Temp\Sistema SEVEN\Fornecedores\Imagem\" + txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg"));
                            bllFornecedor._Nome_Arquivo = txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            bllFornecedor._Nome_Arquivo = txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 7)
                    {
                        bllContasPagar._Nome_Arquivo = txtNomeArquivo.Text.Trim();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 3)
                    {
                        if (File.Exists(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg")))
                        {
                            File.Delete(@"C:\Windows\Temp\Sistema SEVEN\Funcionarios\Imagem\" + txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg"));
                            bllFuncionario._Nome_Arquivo = txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            bllFuncionario._Nome_Arquivo = txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 4)
                    {
                        if (File.Exists(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg")))
                        {
                            File.Delete(@"C:\Windows\Temp\Sistema SEVEN\Produtos\Imagem\" + txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg"));
                            bllProduto._Nome_Arquivo = txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            bllProduto._Nome_Arquivo = txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 6)
                    {
                        if (File.Exists(@"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\" + txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg")))
                        {
                            File.Delete(@"C:\Windows\Temp\Sistema SEVEN\OS\Imagem\" + txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg"));
                            bllOS._Nome_Arquivo = txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            bllOS._Nome_Arquivo = txtNomeArquivo.Text.Insert(txtNomeArquivo.TextLength, ".jpg");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
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
            }
        }

        private void txtNomeArquivo_Leave(object sender, EventArgs e)
        {
            if (txtNomeArquivo.Text.Contains(":") || txtNomeArquivo.Text.Contains(@"\") || txtNomeArquivo.Text.Contains("/") || txtNomeArquivo.Text.Contains('"') || txtNomeArquivo.Text.Contains("*") || txtNomeArquivo.Text.Contains("<") || txtNomeArquivo.Text.Contains(">") || txtNomeArquivo.Text.Contains("|") || txtNomeArquivo.Text.Contains("'"))
            {
                MessageBox.Show("Caractéres inválidos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeArquivo.Text = null;
            }
            txtNomeArquivo.BackColor = Color.White;
        }

        private void txtNomeArquivo_Enter(object sender, EventArgs e)
        {
            txtNomeArquivo.BackColor = Color.LightBlue;
        }

        private void txtNomeArquivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void FrmNomeArquivo_Load(object sender, EventArgs e)
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
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmNomeArquivo iniciado.");
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmNomeArquivo iniciado.");
            }
            //
            if (_Formulario == 0)
            {
                txtNomeArquivo.Text = "cliente_consumidor";
            }
            else if (_Formulario == 1)
            {
                txtNomeArquivo.Text = "fornecedor";
            }
            else if (_Formulario == 3)
            {
                txtNomeArquivo.Text = "funcionario";
            }
            else if (_Formulario == 4)
            {
                txtNomeArquivo.Text = "produto";
            }
            else if (_Formulario == 6)
            {
                txtNomeArquivo.Text = "os";
            }
            else if (_Formulario == 7)
            {
                txtNomeArquivo.Text = "comprovante";
            }
            txtNomeArquivo.Select();
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O nome do arquivo não pode conter nenhum dos seguintes caratceres:" + Environment.NewLine + @"(Aspas dupla) \ / : * < > | . ' ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmNomeArquivo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
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

        private void FrmNomeArquivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmNomeArquivo foi finalizado.");
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmNomeArquivo foi finalizado.");
            }
        }
    }
}
