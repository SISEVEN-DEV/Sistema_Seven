using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelBaixarCheque : Form
    {
        public FrmRelBaixarCheque(string usuario, string cod_pdv_computador, string codigo, string data_emissao, string data_vencimento, string n_cheque, string valor, string emitente, string tipo_emitente, string cod_fato_gerador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            lblValorCodigo.Text = codigo;
            lblValorDataEmissao.Text = data_emissao;
            lblValorDataVencimento.Text = data_vencimento;
            lblNCheque.Text = n_cheque;
            lblValorDocumento.Text = valor;
            _Emitente = emitente;
            _Tipo_Emitente = tipo_emitente;
            _Cod_Fato_Gerador = cod_fato_gerador;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Emitente;
        private string _Tipo_Emitente;
        private string _Cod_Fato_Gerador;

        private void FrmRelBaixarCheque_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelBaixarCheque iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelBaixarCheque iniciado.");
                }
                //
                mtxtDataCompensacao.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelBaixarCheque.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelBaixarCheque.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSelecionarData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
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

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pcibInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtDataCompensacao_Enter(object sender, EventArgs e)
        {
            mtxtDataCompensacao.BackColor = Color.LightBlue;
        }

        private void mtxtDataCompensacao_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataCompensacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataCompensacao.Text == "")
            {
                mtxtDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataCompensacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataCompensacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void mtxtDataCompensacao_Leave(object sender, EventArgs e)
        {
            mtxtDataCompensacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            //
            if (mtxtDataCompensacao.Text != "")
            {
                try
                {
                    mtxtDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    ValidarData.Ver_Data(mtxtDataCompensacao.Text);
                    //
                    if (Convert.ToDateTime(mtxtDataCompensacao.Text) < Convert.ToDateTime(lblValorDataEmissao.Text.Remove(10)))
                    {
                        MessageBox.Show("A Data de Compensação informada é menor que a Data de Emissão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataCompensacao.Text = null;
                        mtxtDataCompensacao.Select();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData1.");
                    }
                    mtxtDataCompensacao.Text = null;
                }
            }
            mtxtDataCompensacao.BackColor = Color.White;
        }

        private void FrmRelBaixarCheque_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmRelBaixarCheque_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelBaixarCheque foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelBaixarCheque foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelBaixarCheque.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelBaixarCheque.");
                }
            }
        }

        private void lblNCheque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblNCheque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDataVencimento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDataVencimento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDocumento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDocumento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDataEmissao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorDataEmissao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDataVencimento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data de Vencimento: " + lblValorDataVencimento.Text.Remove(10), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDocumento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor (R$): " + lblValorDocumento.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDataEmissao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data de Emissão: " + lblValorDataEmissao.Text.Remove(10), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblNCheque_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nº do Cheque: " + lblNCheque.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorCodigo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Código: " + lblValorCodigo.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Select();
            try
            {
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (bllControleCheque.Sel_Controle_Cheque_Ainda_Existe(lblValorCodigo.Text) == false)
                    {
                        MessageBox.Show("Este Cheque não existe ou foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        btnSair.Select();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        mtxtDataCompensacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        if (mtxtDataCompensacao.Text == "")
                        {
                            MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido: [ Data de Compensação ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            mtxtDataCompensacao.Select();
                        }
                        else if (bllControleCheque.Sel_Baixa_Controle_Cheque_Aconteceu(lblValorCodigo.Text) == true)
                        {
                            MessageBox.Show("Este Cheque já foi baixado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            mtxtDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            this.DialogResult = DialogResult.None;
                            //
                            bllControleCheque.Salvar_Baixa_Controle_Cheque(lblValorCodigo.Text, mtxtDataCompensacao.Text);
                            //
                            bllRegistroAtividades.Salvar("COMPENSOU UM CHEQUE.", "CONTROLE CHEQUE", lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //
                            bllContasReceber.Salvar("1", "RECEBIMENTO DE CHEQUE", lblValorDataEmissao.Text.Remove(10), lblValorDataVencimento.Text.Remove(10), "3—CONTAS A RECEBER NO GERAL", "3—GERAL", lblValorDocumento.Text, _Emitente, "Referente ao cheque de nº " + lblNCheque.Text, _Tipo_Emitente, "", "CHEQUE", lblValorDocumento.Text, _Usuario, mtxtDataCompensacao.Text, DateTime.Now.ToLongTimeString(), _Cod_Fato_Gerador, "FINALIZADA", _Cod_PDV_Computador, lblValorCodigo.Text);
                            //
                            string cod_conta = bllContasReceber.Sel_Ultimo_Cod_Conta_Receber();
                            //
                            bllContasReceber.Salvar_Pagamento_Conta_Receber("1", "1—DINHEIRO", lblValorDocumento.Text, cod_conta, mtxtDataCompensacao.Text, 0, _Usuario, _Cod_PDV_Computador);
                            //
                            bllRegistroAtividades.Salvar("FECHOU UMA CONTA A RECEBER.", "CONTAS A RECEBER", cod_conta, _Usuario, _Cod_PDV_Computador);
                            //
                            bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), "ENTRADA", "RECEBIMENTO DE CONTA A RECEBER", lblValorDocumento.Text, lblValorCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
                mtxtDataCompensacao.Text = null;
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            using (FrmDatePicker Data = new FrmDatePicker(2))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataCompensacao.Text = bllControleCheque._Data_DatePicker1;
                }
            }
        }

        private void mtxtDataCompensacao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataCompensacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataCompensacao.Text == "")
                {
                    mtxtDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataCompensacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }
    }
}
