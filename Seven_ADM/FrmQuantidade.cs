using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmQuantidade : Form
    {
        public FrmQuantidade(byte formulario, string quantidade)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Quantidade = quantidade;
        }

        private byte _Formulario;
        private string _Quantidade;

        private void FrmQuantidade_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmQuantidade iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmQuantidade iniciado.");
                }
                //
                if (_Formulario == 2)
                {
                    this.Text = "Adicionar Quantidade de Parcelas";
                    txtQuantidade.MaxLength = 3;
                }
                //
                txtQuantidade.Text = _Quantidade;
                txtQuantidade.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmQuantidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmQuantidade.");
                }
            }
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantidade.Text != "")
            {
                btnIncluir.Enabled = true;
            }
            else
            {
                btnIncluir.Enabled = false;
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Formulario == 2)
            {
                if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (txtQuantidade.Text.Contains(",") && e.KeyChar == (char)44)
                {
                    e.Handled = true;
                }
                if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8) && !(e.KeyChar == (char)44))
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar == 13)
            {
                btnIncluir.Select();
            }
        }

        private void txtQuantidade_Enter(object sender, EventArgs e)
        {
            txtQuantidade.BackColor = Color.LightBlue;
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
                        if (_Formulario != 2)
                        {
                            txtQuantidade.Text = Convert.ToDecimal(txtQuantidade.Text).ToString("n2", new CultureInfo("pt-BR"));
                        }
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

        private void FrmQuantidade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.Trim() == "")
            {
                MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido. [ Quantidade ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQuantidade.Select();
            }
            else
            {
                if (_Formulario == 0)
                {
                    bllOS._Quantidade = txtQuantidade.Text.Trim();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    bllOrcamento._Quantidade = txtQuantidade.Text.Trim();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    bllItem_Parcelamento_DFe._Quantidade = txtQuantidade.Text.Trim();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void FrmQuantidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmQuantidade foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmQuantidade foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmQuantidade.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmQuantidade.");
                }
            }
        }

        private void btnIncluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncluir_MouseLeave(object sender, EventArgs e)
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
    }
}
