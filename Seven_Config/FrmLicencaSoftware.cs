using BLL;
using System;
using System.IO;
using System.Windows.Forms;

namespace Sistema_SEVEN_Config
{
    public partial class FrmLicencaSoftware : Form
    {
        public FrmLicencaSoftware()
        {
            InitializeComponent();
        }

        private void FrmLicencaSoftware_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLicencaSoftware iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLicencaSoftware iniciado.");
                }
                //
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    //btnNovo.Select();
                }
                else
                {
                    txtCPFCNPJ.Text = bllMinhaEmpresa.Sel_Empresa_CPFCNPJ();
                    txtCPFCNPJ.Select();
                }
                //
                txtCPFCNPJ.Select();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLicencaSoftware.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLicencaSoftware.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCPFCNPJ.Text.Trim() == "" || txtCPFCNPJ.Text.Trim() == null)
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido: \n< CPF/CNPJ >.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    txtCPFCNPJ.Select();
                }
                else
                {
                    string chave;
                    //
                    if (txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Length == 14)
                    {
                        if (!ValidarCNPJECPF.ValidaCNPJ(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "")))
                        {
                            MessageBox.Show("CNPJ inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.DialogResult = DialogResult.None;
                            txtCPFCNPJ.Text = null;
                            txtCPFCNPJ.Select();
                        }
                        else
                        {
                            if (txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "0" || txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "2" || txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "4" || txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "6" || txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "8")
                            {
                                decimal valor = Convert.ToDecimal(DateTime.Now.Day) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(2, 1));
                                //
                                decimal valor2 = Convert.ToDecimal(DateTime.Now.Month) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(4, 1));
                                //
                                decimal valor3 = Convert.ToDecimal(DateTime.Now.Year) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(6, 1)); ;
                                //
                                decimal valor4 = Convert.ToDecimal(DateTime.Now.Day) + Convert.ToDecimal(DateTime.Now.Month) + Convert.ToDecimal(DateTime.Now.Year);
                                //
                                chave = txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) + valor.ToString() + txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(7, 1) + valor2.ToString() + valor3.ToString() + valor4.ToString();
                                //
                                txtChaveLicenca.Text = chave;
                            }
                            else
                            {
                                decimal valor = Convert.ToDecimal(DateTime.Now.Day) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(2, 1));
                                //
                                decimal valor2 = Convert.ToDecimal(DateTime.Now.Month) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(4, 1));
                                //
                                decimal valor3 = Convert.ToDecimal(DateTime.Now.Year) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(6, 1)); ;
                                //
                                decimal valor4 = Convert.ToDecimal(DateTime.Now.Day) + Convert.ToDecimal(DateTime.Now.Month) + Convert.ToDecimal(DateTime.Now.Year);
                                //
                                chave = txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(7, 1) + valor.ToString() + txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) + valor2.ToString() + valor3.ToString() + valor4.ToString();
                                //
                                txtChaveLicenca.Text = chave;
                            }
                        }
                    }
                    else if (txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Length == 11)
                    {
                        if (!ValidarCNPJECPF.ValidarCPF(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "")))
                        {
                            MessageBox.Show("CPF inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.DialogResult = DialogResult.None;
                            txtCPFCNPJ.Text = null;
                            txtCPFCNPJ.Select();
                        }
                        else
                        {
                            if (txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "0" || txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "2" || txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "4" || txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "6" || txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) == "8")
                            {
                                decimal valor = Convert.ToDecimal(DateTime.Now.Day) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(2, 1));
                                //
                                decimal valor2 = Convert.ToDecimal(DateTime.Now.Month) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(4, 1));
                                //
                                decimal valor3 = Convert.ToDecimal(DateTime.Now.Year) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(6, 1)); ;
                                //
                                decimal valor4 = Convert.ToDecimal(DateTime.Now.Day) + Convert.ToDecimal(DateTime.Now.Month) + Convert.ToDecimal(DateTime.Now.Year);
                                //
                                chave = txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) + valor.ToString() + txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(7, 1) + valor2.ToString() + valor3.ToString() + valor4.ToString();
                                //
                                txtChaveLicenca.Text = chave;
                            }
                            else
                            {
                                decimal valor = Convert.ToDecimal(DateTime.Now.Day) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(2, 1));
                                //
                                decimal valor2 = Convert.ToDecimal(DateTime.Now.Month) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(4, 1));
                                //
                                decimal valor3 = Convert.ToDecimal(DateTime.Now.Year) * Convert.ToDecimal(txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(6, 1)); ;
                                //
                                decimal valor4 = Convert.ToDecimal(DateTime.Now.Day) + Convert.ToDecimal(DateTime.Now.Month) + Convert.ToDecimal(DateTime.Now.Year);
                                //
                                chave = txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(7, 1) + valor.ToString() + txtCPFCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 1) + valor2.ToString() + valor3.ToString() + valor4.ToString();
                                //
                                txtChaveLicenca.Text = chave;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("CPF/CNPJ informado está incorreto verifique e tente novamente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.None;
                        txtCPFCNPJ.Text = null;
                        txtCPFCNPJ.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento clivk do botão btnGerarCPFCNPJ.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento clivk do botão btnGerarCPFCNPJ.");
                }
                txtCPFCNPJ.Text = null;
            }
        }

        private void btnGerarCPFCNPJ_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnGerarCPFCNPJ_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAplicar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAplicar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmLicencaSoftware_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtCPFCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtChaveLicenca.Select();
            }
        }

        private void txtChaveLicenca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnAplicar.Select();
            }
        }

        private void FrmLicencaSoftware_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLicencaSoftware foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLicencaSoftware foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmLicencaSoftware.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmLicencaSoftware.");
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
