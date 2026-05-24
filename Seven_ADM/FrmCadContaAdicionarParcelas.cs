using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCadContaAdicionarParcelas : Form
    {
        public FrmCadContaAdicionarParcelas(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void FrmMultiplicar_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAdicionarParcelas iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAdicionarParcelas iniciado.");
                }
                //
                if (_Formulario != 2)
                {
                    cbbPDias.Text = "30";
                    txtNParcela.Select();
                }
                else
                {
                    ttpMultiplicar.SetToolTip(btnVoltar, "Voltar para o cadastro de lembretes.");
                    ttpMultiplicar.SetToolTip(btnOK, "Multiplicar o lembrete selecionado.");
                    lblMultiplicar.Location = new Point(6, 16);
                    lblMultiplicar.Text = "Adicionar Ocorrências:";
                    cbbPDias.Text = "1";
                    txtNParcela.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmAdicionarParcelas.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmAdicionarParcelas.");
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNParcela.Text == "" || cbbPDias.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos:" + Environment.NewLine + "[ Adicionar Parcelas ] e [ Período de Dias ]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                if (_Formulario == 0)
                {
                    bllContasPagar._Parcela = txtNParcela.Text;
                    bllContasPagar._Dias = cbbPDias.Text;
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    bllContasReceber._Parcela = txtNParcela.Text;
                    bllContasReceber._Dias = cbbPDias.Text;
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 2)
                {
                    bllLembrete._Ocorrencia = txtNParcela.Text;
                    bllLembrete._Dias = cbbPDias.Text;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void FrmMultiplicar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void cbbParcela_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbParcela_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbPDias_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbPDias_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnOK_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
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

        private void txtNParcela_Enter(object sender, EventArgs e)
        {
            txtNParcela.BackColor = Color.LightBlue;
        }

        private void txtNParcela_Leave(object sender, EventArgs e)
        {
            if (txtNParcela.Text.Contains("'") || txtNParcela.Text.Contains(";") || txtNParcela.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNParcela.Text = null;
                txtNParcela.Select();
            }
            txtNParcela.BackColor = Color.White;
        }

        private void txtNParcela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cbbPDias.Select();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_Formulario != 2)
            {
                MessageBox.Show("1 - Adicionar Parcelas: Insere a quantidade de parcelas e/ou ocorrências da conta selecionada.\n\n2 - Intervalo de dias: É o intervalo de dias entre as parcelas.\n\nO que vai constar nas parcelas?\nSerão importados os campos: Contrato/Matrícula/Serviço, Parcelas(serão incrementadas), Descrição, Nº do Documento, Tipo do Documento, Data de Emissão(será incrementada), Data de Vencimento(será Incrementada), Emitente, Valor (R$), Desconto Até(será incrementada), Desconto(%)(R$), Multa(%)(R$) e Mora(%)(R$).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("1 - Adicionar Ocorrencias: Insere a quantidade de ocorrência do lembrete selecionado.\n\n2 - Intervalo de dias: É o intervalo de dias entre as ocorrências.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.DialogResult = DialogResult.None;
        }

        private void pcibInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkSomarNDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkSomarNDocumento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbPDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOK.Select();
            }
        }

        private void FrmMultiplicar_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAdicionarParcelas foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAdicionarParcelas foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmAdicionarParcelas.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmAdicionarParcelas.");
                }
            }
        }

        private void grbBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
