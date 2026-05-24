using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmCancInutCorrec : Form
    {
        public FrmCancInutCorrec(byte formulario)
        {
            InitializeComponent();
            _Formulario = formulario;
        }

        private byte _Formulario;

        private void FrmCancelamentoVenda_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCancelamentoVenda iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCancelamentoVenda iniciado.");
                }
                //
                if (_Formulario == 3)
                {
                    this.Text = "Descrição da Carta de Correção";
                    lblDescricao.Text = "Descrição:";
                    lblAsterisco.Location = new Point(89, 13);
                    this.ttpJust.SetToolTip(btnVoltar, "Sair de Descrição da Carta de Correção");

                }
                txtJustificativa.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCancelamentoVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCancelamentoVenda.");
                }
                this.DialogResult = DialogResult.Abort;
            }
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

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            txtJustificativa.BackColor = Color.LightBlue;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            if (txtJustificativa.Text.Contains("'") || txtJustificativa.Text.Contains(";") || txtJustificativa.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtJustificativa.Text = null;
                txtJustificativa.Select();
            }
            txtJustificativa.BackColor = Color.White;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtJustificativa.Text.Trim() == "")
            {
                MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido.\n[ Justificativa ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                txtJustificativa.Select();
            }
            else
            {
                if (_Formulario == 0)
                {
                    bllVenda._Justificativa_Cancelamento = txtJustificativa.Text.Trim();
                }
                else if (_Formulario == 1)
                {
                    bllDevolucao._Justificativa_Cancelamento = txtJustificativa.Text.Trim();
                }
                else if (_Formulario == 2 || _Formulario == 3)
                {
                    string justdesc;
                    if (_Formulario == 2)
                    {
                        justdesc = "justificativa";
                    }
                    else
                    {
                        justdesc = "descrição";
                    }
                    //
                    if (txtJustificativa.TextLength < 15)
                    {
                        MessageBox.Show("É necessário informar uma " + justdesc + " que tenha, no mínimo, 15 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        txtJustificativa.Select();
                        return;
                    }
                    else
                    {
                        bllDFe._JustificativaInutCancelCorr = txtJustificativa.Text.Trim();
                    }
                }
                //
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FrmCancelamentoVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelVenda foi FrmCancelamentoVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelVenda foi FrmCancelamentoVenda.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCancelamentoVenda.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCancelamentoVenda.");
                }
            }
        }

        private void FrmCancelamentoVenda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Formulario == 0)
                {
                    bllVenda._Justificativa_Cancelamento = null;
                }
                else if (_Formulario == 1)
                {
                    bllDevolucao._Justificativa_Cancelamento = null;
                }
                else if (_Formulario == 2)
                {
                    bllDFe._JustificativaInutCancelCorr = null;
                }
                //
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Informe a justificativa do cancelamento no campo [ Justificativa ].", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                bllVenda._Justificativa_Cancelamento = null;
            }
            else if (_Formulario == 1)
            {
                bllDevolucao._Justificativa_Cancelamento = null;
            }
            else if (_Formulario == 2)
            {
                bllDFe._JustificativaInutCancelCorr = null;
            }
        }
    }
}
