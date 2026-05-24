using ACBrLib.NFSe;
using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;


namespace Seven_Sistema
{
    public partial class FrmMenuNFSe : Form
    {
        public FrmMenuNFSe(string usuario, string cod_pdv_computador, byte formulario, string cod_nfse)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Cod_NFSe = cod_nfse;
        }

        private byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Cod_NFSe;
        bool _Concluiu = false;

        private bool isMethodRunning = false;

        private void FrmMenuNFSe_Load(object sender, EventArgs e)
        {
            try
            {
                bllNFSe._FrmMenuNFSe_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuNFSe iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuNFSe iniciado.");
                }
                //
                if (_Formulario == 1)
                {
                    this.ControlBox = false;
                    //
                    grbBox1.Enabled = false;
                    //
                    btnPesquisar_Click(sender, e);
                }
                else
                {
                    cbbSituacao.Text = "PENDENTE";
                    btnPesquisar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMenuNFSe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMenuNFSe.");
                }
            }
        }

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
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

        private void cbbSituacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorTotalReal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotalReal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCopiarChave_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCopiarChave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnAbrirArquivo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAbrirArquivo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnTransmitir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTransmitir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarDFe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarDFe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
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

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if ((mtxtpDataEmissao.Text == "" & mtxtpDataEmissao1.Text != "") || (mtxtpDataEmissao.Text != "" & mtxtpDataEmissao1.Text == ""))
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtpDataEmissao.Select();
                    return;
                }
                else
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    if (bllNFSe.Sel_NFSe_Menu_NFSe(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, cbbSituacao.Text, txtNumeroNF.Text, _Cod_NFSe, txtCodigo.Text) == null)
                    {
                        dtNFSe.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtNFSe.DataSource = bllNFSe.Sel_NFSe_Menu_NFSe(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, cbbSituacao.Text, txtNumeroNF.Text, _Cod_NFSe, txtCodigo.Text);
                        dtNFSe.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtNFSe.DataSource = null;
                txtCodigo.Select();
            }
        }

        private void FrmMenuNFSe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                /*
                if (bllLetreiro.Sel_Tipo_Letreiro_Existe("DFE") == true)
                {
                    if (bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "") != null)
                    {
                        if (_Formulario == 0)
                        {
                            DialogResult = MessageBox.Show("Existe(m) " + bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "").Rows.Count + " DFe (NFe/NFCe) com status [ PENDENTE ] que ainda não foi(ram) verifcado(os).\n\nDeseja verificar agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                                e.Cancel = true;
                                //
                                cbbSituacao.Text = "PENDENTE";
                                dtDFE.DataSource = bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "");
                                dtDFE.Select();
                                //
                                return;
                            }
                        }
                        bllLetreiro.Alterar_Letreiro("Existe(m) " + bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "").Rows.Count + " DFe (NFe/NFCe) com status [ PENDENTE ] que ainda não foi(ram) verifcado(os).", "DFE");
                    }
                    else
                    {
                        bllLetreiro.Excluir_Letreiro("DFE");
                    }
                }
                else
                {
                    if (bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "") != null)
                    {
                        if (_Formulario == 0)
                        {
                            DialogResult = MessageBox.Show("Existe(m) " + bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "").Rows.Count + " DFe (NFe/NFCe) com status [ PENDENTE ] que ainda não foi(ram) verifcado(os).\n\nDeseja verificar agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                this.DialogResult = DialogResult.None;
                                e.Cancel = true;
                                //
                                cbbSituacao.Text = "PENDENTE";
                                dtDFE.DataSource = bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "");
                                dtDFE.Select();
                                //
                                return;
                            }
                        }
                        bllLetreiro.Salvar_Letreiro("Existe(m) " + bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "").Rows.Count + " DFe (NFe/NFCe) com status [ PENDENTE ] que ainda não foi(ram) verifcado(os).", "1", "DFE");
                    }
                    else
                    {
                        bllLetreiro.Excluir_Letreiro("DFE");
                    }
                }
                */
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuNFSe foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuNFSe foi finalizado.");
                }
                //
                bllNFSe._FrmMenuNFSe_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMenuNFSe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMenuNFSe.");
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txtNumeroNF.Select();
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Contains("'") || txtCodigo.Text.Contains(";") || txtCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtCodigo.Text = null;
                txtCodigo.Select();
            }
            txtCodigo.BackColor = Color.White;
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            txtCodigo.BackColor = Color.LightBlue;
        }

        private void txtNumeroNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                mtxtpDataEmissao.Select();
            }
        }

        private void txtNumeroNF_Leave(object sender, EventArgs e)
        {
            if (txtNumeroNF.Text.Contains("'") || txtNumeroNF.Text.Contains(";") || txtNumeroNF.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtNumeroNF.Text = null;
                txtNumeroNF.Select();
            }
            txtNumeroNF.BackColor = Color.White;
        }

        private void txtNumeroNF_Enter(object sender, EventArgs e)
        {
            txtNumeroNF.BackColor = Color.LightBlue;
        }

        private void mtxtpDataEmissao_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao.Text == "")
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioEmissao.Select();
            }
        }

        private void mtxtpDataEmissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmissao.Text == "")
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmissao_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao.Text != "")
            {
                try
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmissao.Text);

                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmissao1.Text != "")
                    {
                        mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmissao.Text) > Convert.ToDateTime(mtxtpDataEmissao1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao.");
                    }
                    mtxtpDataEmissao.Text = null;
                }
            }
            mtxtpDataEmissao.BackColor = Color.White;
        }

        private void mtxtpDataEmissao_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioEmissao_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao.Text == "")
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioEmissao.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataEmissao1.Select();
            }
        }

        private void mtxtHorarioEmissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioEmissao.Text == "")
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioEmissao_Enter(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioEmissao_Leave(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao.Text != "")
            {
                if (mtxtHorarioEmissao.Text.Length == 4)
                {
                    mtxtHorarioEmissao.Text = mtxtHorarioEmissao.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioEmissao.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao.");
                    }
                    mtxtHorarioEmissao.Text = null;
                }
            }
            mtxtHorarioEmissao.BackColor = Color.White;
        }

        private void mtxtpDataEmissao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao1.Text == "")
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmissao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmissao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioEmissao1.Select();
            }
        }

        private void mtxtpDataEmissao1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmissao1.Text == "")
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmissao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmissao1_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.BackColor = Color.LightBlue;
        }

        private void mtxtpDataEmissao1_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao1.Text != "")
            {
                try
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmissao1.Text);

                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmissao.Text != "")
                    {
                        mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmissao1.Text) < Convert.ToDateTime(mtxtpDataEmissao.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao1.");
                    }
                    mtxtpDataEmissao1.Text = null;
                }
            }
            mtxtpDataEmissao1.BackColor = Color.White;
        }

        private void mtxtHorarioEmissao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao1.Text == "")
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioEmissao1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioEmissao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void mtxtHorarioEmissao1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioEmissao1.Text == "")
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioEmissao1_Enter(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioEmissao1_Leave(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao1.Text != "")
            {
                if (mtxtHorarioEmissao1.Text.Length == 4)
                {
                    mtxtHorarioEmissao1.Text = mtxtHorarioEmissao1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioEmissao1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao1.");
                    }
                    mtxtHorarioEmissao1.Text = null;
                }
            }
            mtxtHorarioEmissao1.BackColor = Color.White;
        }

        private void FrmMenuNFSe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_Formulario == 1)
                {
                    if (_Concluiu == true)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Abort;
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (_Formulario == 1)
            {
                if (_Concluiu == true)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(27))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataEmissao.Text = bllNFSe._Data_DatePicker1;
                    mtxtpDataEmissao1.Text = bllNFSe._Data_DatePicker2;
                }
            }
            this.Enabled = true;
        }

        private void lblValorTotalReal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total dos Serviços (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }


        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void dtNFSe_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtNFSe.DataSource == null)
            {
                dtNFSe.Enabled = false;
                lblValorTotal.Enabled = false;
                lblTotal.Enabled = false;
                btnTransmitir.Enabled = false;
                btnImprimir.Enabled = false;
                btnCancelar.Enabled = false;
                btnConsultarNFSe.Enabled = false;
                lblValorSituacao.Visible = false;
                lblCxSituacao.Visible = false;
                mtxtChave.Enabled = false;
                btnCopiarChave.Enabled = false;
                lblChave.Enabled = false;
                btnAbrirArquivo.Enabled = false;
                mtxtChave.Text = null;
            }
            else
            {
                dtNFSe.Enabled = true;
                lblValorTotal.Enabled = true;
                lblTotal.Enabled = true;
                btnImprimir.Enabled = true;
                lblValorSituacao.Visible = true;
                lblCxSituacao.Visible = true;
                btnCopiarChave.Enabled = true;
                btnAbrirArquivo.Enabled = true;
            }
        }

        private void dtNFSe_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtNFSe.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtNFSe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtNFSe_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtNFSe.Columns[0].HeaderText = "Código";
            dtNFSe.Columns[1].HeaderText = "Número da NFSe";
            dtNFSe.Columns[2].HeaderText = "Cód. do Consumidor";
            dtNFSe.Columns[3].HeaderText = "Nome do Consumidor";
            dtNFSe.Columns[4].HeaderText = "CPF/CNPJ do Consumidor";
            dtNFSe.Columns[5].HeaderText = "Total dos Serviços";
            dtNFSe.Columns[6].HeaderText = "Série";
            dtNFSe.Columns[7].HeaderText = "Data de Emissão";
            dtNFSe.Columns[8].HeaderText = "Hora de Emissão";
            dtNFSe.Columns[9].HeaderText = "Situação";
            dtNFSe.Columns[10].HeaderText = "Data de Criação";
            dtNFSe.Columns[11].HeaderText = "Cód. da O.S.";
            //
            dtNFSe.Columns[0].Width = 95;
            dtNFSe.Columns[1].Width = 115;
            dtNFSe.Columns[2].Width = 125;
            dtNFSe.Columns[3].Width = 285;
            dtNFSe.Columns[4].Width = 175;
            dtNFSe.Columns[5].Width = 125;
            dtNFSe.Columns[6].Width = 85;
            dtNFSe.Columns[7].Width = 125;
            dtNFSe.Columns[8].Width = 125;
            dtNFSe.Columns[9].Width = 125;
            dtNFSe.Columns[10].Width = 125;
            dtNFSe.Columns[11].Width = 125;
            //
            dtNFSe.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtNFSe.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            dtNFSe.DefaultCellStyle.Font = new Font(dtNFSe.Font, FontStyle.Bold);
            lblRegistros.Text = "Registros: " + dtNFSe.Rows.Count;
            //
            decimal valortotal = 0;
            for (int i = 0; i < dtNFSe.Rows.Count; i++)
            {
                valortotal += Convert.ToDecimal(dtNFSe.Rows[i].Cells[5].Value);
            }
            lblValorTotal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void dtNFSe_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtNFSe.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dtNFSe.DefaultCellStyle.SelectionForeColor = Color.Black;

                dtNFSe.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
                dtNFSe.Columns[5].DefaultCellStyle.Format = "n2";
                //
                DataGridViewRow SelectedRow = dtNFSe.Rows[dtNFSe.CurrentRow.Index];
                //
                if (SelectedRow.Cells[9].Value.ToString() == "CANCELADA")
                {
                    lblValorSituacao.Visible = true;
                    lblCxSituacao.Visible = true;
                    lblValorSituacao.Text = "CANCELADA";
                    lblValorSituacao.ForeColor = Color.Red;
                    lblCxSituacao.BackColor = Color.Red;
                    btnConsultarNFSe.Enabled = true;
                    btnTransmitir.Enabled = false;
                    btnCancelar.Enabled = false;
                    lblChave.Enabled = true;
                    mtxtChave.Enabled = true;
                    btnCopiarChave.Enabled = true;
                }
                else if (SelectedRow.Cells[9].Value.ToString() == "TRANSMITIDA")
                {
                    lblValorSituacao.Visible = true;
                    lblCxSituacao.Visible = true;
                    lblValorSituacao.Text = "TRANSMITIDA";
                    lblValorSituacao.ForeColor = Color.Green;
                    lblCxSituacao.BackColor = Color.Green;
                    btnConsultarNFSe.Enabled = true;
                    btnTransmitir.Enabled = false;
                    btnCancelar.Enabled = false;
                    lblChave.Enabled = true;
                    mtxtChave.Enabled = true;
                    btnCopiarChave.Enabled = true;
                }
                else if (SelectedRow.Cells[9].Value.ToString() == "PENDENTE")
                {
                    lblValorSituacao.Visible = true;
                    lblCxSituacao.Visible = true;
                    lblValorSituacao.Text = "PENDENTE";
                    lblValorSituacao.ForeColor = Color.Red;
                    lblCxSituacao.BackColor = Color.Red;
                    btnConsultarNFSe.Enabled = true;
                    btnTransmitir.Enabled = false;
                    lblChave.Enabled = true;
                    mtxtChave.Enabled = true;
                    btnCopiarChave.Enabled = true;
                    btnCancelar.Enabled = false;
                }
                else
                {
                    lblValorSituacao.Visible = true;
                    lblCxSituacao.Visible = true;
                    lblValorSituacao.Text = "PENDENTE";
                    lblValorSituacao.ForeColor = Color.Red;
                    lblCxSituacao.BackColor = Color.Red;
                    btnConsultarNFSe.Enabled = true;
                    btnTransmitir.Enabled = false;
                    lblChave.Enabled = true;
                    mtxtChave.Enabled = true;
                    btnAbrirArquivo.Enabled = true;
                    btnCopiarChave.Enabled = true;
                    btnCancelar.Enabled = false;
                }
                //
                if (isMethodRunning == false)
                {
                    rtbRespostas.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtNFSe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtNFSe.");
                }
                dtNFSe.DataSource = null;
            }
        }

        private void dtNFSe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por código da o.s., número da nfse, data e horário de emissão e situação.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total das NF (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;

        }

        private void cbbSituacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnTransmitir_Click(object sender, EventArgs e)
        {
            //try
            //{
            isMethodRunning = true;
            //
            DataGridViewRow SelectedRow = dtNFSe.Rows[dtNFSe.CurrentRow.Index];
            //
            if (bllNFSe.Sel_NFSe_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
            {
                MessageBox.Show("Não é possível transmitir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                DataRow drNFSe = bllNFSe.Sel_NFSe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];

                bllRegistroAtividades.Salvar("INICIOU A TRANSMISSAO DA DFSE " + SelectedRow.Cells[0].Value.ToString() + ".", "NFSE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                //
                ACBrNFSe ACBrNFSe;
                if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfse.ini"))
                {
                    ACBrNFSe = new ACBrNFSe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfse.ini");
                }
                else
                {
                    ACBrNFSe = new ACBrNFSe();
                }
                //
                bllNFSe.CriarNFSe(SelectedRow.Cells[0].Value.ToString(), _Cod_PDV_Computador);
                //
                ACBrNFSe.CarregarINI(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\nfse" + drNFSe["numero_nf"].ToString() + ".ini");
                //
                var ret = ACBrNFSe.Emitir("1", 0, true);

            }
        }

        private void btnConsultarDFe_Click(object sender, EventArgs e)
        {
            try
            {
                isMethodRunning = true;
                DataGridViewRow SelectedRow = dtNFSe.Rows[dtNFSe.CurrentRow.Index];
                //
                DataRow drNFSe = bllNFSe.Sel_NFSe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                bllRegistroAtividades.Salvar("CONSULTOU A NFSE " + SelectedRow.Cells[0].Value.ToString() + ".", "NFSE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                //
                ACBrNFSe ACBrNFSe;
                if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfse.ini"))
                {
                    ACBrNFSe = new ACBrNFSe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfse.ini");
                }
                else
                {
                    ACBrNFSe = new ACBrNFSe();
                }
                //
                int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                //
                ACBrNFSe.LimparLista();
                //
                var ret = ACBrNFSe.ConsultarNFSePorFaixa(drNFSe["numero_nf"].ToString(), drNFSe["numero_nf"].ToString(), 1);
                //
                string[] items = ret.Split('\n');
                //
                if (ret.Contains("[Erro1]"))
                {
                    MessageBox.Show(items[0] + '\n' + "NFSe nº: " + drNFSe["numero_nf"].ToString() + '\n' + items[1] + '\n' + items[2] + '\n' + items[3], "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    MessageBox.Show("", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                }
                //
                rtbRespostas.Text = ret;
                //
                isMethodRunning = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                isMethodRunning = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnConsultarNFSe.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnConsultarNFSe.");
                }
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Antes de executar qualquer ação na NFSe é importante antes de tudo, clicar em [ Consultar NFSe ] para verificar o retorno do provedor/sefaz.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void rtbRespostas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnTransmitir.Select();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                isMethodRunning = true;
                DataGridViewRow SelectedRow = dtNFSe.Rows[dtNFSe.CurrentRow.Index];
                //
                if (bllNFSe.Sel_NFSe_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível transmitir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    DataRow drNFSe = bllNFSe.Sel_NFSe_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                    //
                    bllRegistroAtividades.Salvar("INICIOU O CANCELAMENTO DO NFSE " + SelectedRow.Cells[0].Value.ToString() + ".", "NFSE", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                    //
                    int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                    //
                    ACBrNFSe ACBrNFSe;
                    if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfse.ini"))
                    {
                        ACBrNFSe = new ACBrNFSe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfse.ini");
                    }
                    else
                    {
                        ACBrNFSe = new ACBrNFSe();
                    }
                    //
                    ACBrNFSe.LimparLista();
                    //
                    var justificativa = "";
                    using (FrmCancInutCorrec Inut = new FrmCancInutCorrec(2))
                    {
                        if (Inut.ShowDialog() == DialogResult.OK)
                        {
                            justificativa = bllDFe._JustificativaInutCancelCorr;
                        }
                        else
                        {
                            MessageBox.Show("É necessário informar uma justificativa para cancelar a NFSe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            return;
                        }
                    }
                    //
                    string arquivoini = bllNFSe.CancelarNFSe(SelectedRow.Cells[0].Value.ToString(), _Cod_PDV_Computador, justificativa);
                    //
                    ACBrNFSe.CarregarINI(arquivoini);
                    //
                    var ret = ACBrNFSe.EnviarEvento(arquivoini);
                    //
                    rtbRespostas.Text = ret;
                    //
                    /*
                    if (ret.CStat == 101)
                    {
                        MessageBox.Show(ret.XMotivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                    */
                    //
                    foreach (DataGridViewRow row in dtNFSe.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                        {
                            row.Selected = true;
                            dtNFSe.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                    //
                    btnConsultarDFe_Click(sender, e);
                    //
                    ACBrNFSe.Dispose();
                    ACBrNFSe = null;
                    //
                    isMethodRunning = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                isMethodRunning = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnCancelar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário btnCancelar.");
                }
            }
        }
    }
}
