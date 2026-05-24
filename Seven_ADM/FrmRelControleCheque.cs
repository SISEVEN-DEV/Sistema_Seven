using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelControleCheque : Form
    {
        public FrmRelControleCheque(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private byte _Trabalho;
        private string _Cod_PDV_Computador;

        private void FrmConfCadProduto_Load(object sender, EventArgs e)
        {
            try
            {
                bllControleCheque._FrmRelControleCheque_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelControleCheque iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelControleCheque iniciado.");
                }
                //
                rbtnCodigo.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelControleCheque.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelControleCheque.");
                }
                //
                this.Close();
            }
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void radioButton1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void radioButton1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnTodos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnTodos_MouseLeave(object sender, EventArgs e)
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

        private void btnSelecionarDataVencimento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarDataVencimento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCodPDV_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCodPDV_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbCodPDV_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbCodPDV_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarPDV_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarPDV_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarDataCompensacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarDataCompensacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbConsumidor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbConsumidor_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbConsumidor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbConsumidor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarCliente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarCliente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUsuario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUsuario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSituacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_MouseLeave(object sender, EventArgs e)
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

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnTodasCheques_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTodasCheques_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnBaixaRegistro_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnBaixaRegistro_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExportarCsv_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExportarCsv_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rbtnExportarTxt_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnExportarTxt_MouseLeave(object sender, EventArgs e)
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

        private void lblValorTotal_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorTotal_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorVencidos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorVencidos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValoraVencer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValoraVencer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorCompensados_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorCompensados_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
        }

        private void mtxtHorario_Enter(object sender, EventArgs e)
        {
            mtxtHorario.BackColor = Color.LightBlue;
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
        }

        private void mtxtHorario1_Enter(object sender, EventArgs e)
        {
            mtxtHorario1.BackColor = Color.LightBlue;
        }

        private void mtxtpDataVencimento_Enter(object sender, EventArgs e)
        {
            mtxtpDataVencimento.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioVencimento_Enter(object sender, EventArgs e)
        {
            mtxtHorarioVencimento.BackColor = Color.LightBlue;
        }

        private void mtxtpDataVencimento1_Enter(object sender, EventArgs e)
        {
            mtxtpDataVencimento1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioVencimento1_Enter(object sender, EventArgs e)
        {
            mtxtHorarioVencimento1.BackColor = Color.LightBlue;
        }

        private void mtxtpDataCompensacao_Enter(object sender, EventArgs e)
        {
            mtxtpDataCompensacao.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioCompensacao_Enter(object sender, EventArgs e)
        {
            mtxtHorarioCompensacao.BackColor = Color.LightBlue;
        }

        private void mtxtpDataCompensacao1_Enter(object sender, EventArgs e)
        {
            mtxtpDataCompensacao1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioCompensacao1_Enter(object sender, EventArgs e)
        {
            mtxtHorarioCompensacao1.BackColor = Color.LightBlue;
        }

        private void mtxtpData_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData.Text == "")
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpData1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mtxtpData1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData1.Text == "")
            {
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataVencimento_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVencimento.Text == "")
            {
                mtxtpDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataVencimento1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataVencimento1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVencimento1.Text == "")
            {
                mtxtpDataVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataVencimento1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataCompensacao_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtxtpDataCompensacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataCompensacao.Text == "")
            {
                mtxtpDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataCompensacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataCompensacao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataCompensacao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataCompensacao1.Text == "")
            {
                mtxtpDataCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataCompensacao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorario_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario.Text == "")
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorario1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario1.Text == "")
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioVencimento_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioVencimento.Text == "")
            {
                mtxtHorarioVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioVencimento.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioVencimento1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtxtHorarioVencimento1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioVencimento1.Text == "")
            {
                mtxtHorarioVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioVencimento1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioCompensacao_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioCompensacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioCompensacao.Text == "")
            {
                mtxtHorarioCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioCompensacao.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioCompensacao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioCompensacao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioCompensacao1.Text == "")
            {
                mtxtHorarioCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioCompensacao1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpData_Leave(object sender, EventArgs e)
        {
            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData.Text != "")
            {
                try
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpData.Text);

                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData1.Text != "")
                    {
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpData.Text) > Convert.ToDateTime(mtxtpData1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpData.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    mtxtpData.Text = null;
                }
            }
            mtxtpData.BackColor = Color.White;
        }

        private void mtxtpData1_Leave(object sender, EventArgs e)
        {
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData1.Text != "")
            {
                try
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpData1.Text);

                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpData1.Text) < Convert.ToDateTime(mtxtpData.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpData1.Text = null;
                        }
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
                    mtxtpData1.Text = null;
                }
            }
            mtxtpData1.BackColor = Color.White;
        }

        private void mtxtpDataVencimento_Leave(object sender, EventArgs e)
        {
            mtxtpDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVencimento.Text != "")
            {
                try
                {
                    mtxtpDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataVencimento.Text);

                    mtxtpDataVencimento1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataVencimento1.Text != "")
                    {
                        mtxtpDataVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataVencimento.Text) > Convert.ToDateTime(mtxtpDataVencimento1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpData.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    mtxtpDataVencimento.Text = null;
                }
            }
            mtxtpDataVencimento.BackColor = Color.White;
        }

        private void mtxtpDataVencimento1_Leave(object sender, EventArgs e)
        {
            mtxtpDataVencimento1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVencimento1.Text != "")
            {
                try
                {
                    mtxtpDataVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataVencimento1.Text);

                    mtxtpDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataVencimento.Text != "")
                    {
                        mtxtpDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataVencimento1.Text) < Convert.ToDateTime(mtxtpDataVencimento.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataVencimento1.Text = null;
                        }
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
                    mtxtpDataVencimento1.Text = null;
                }
            }
            mtxtpDataVencimento1.BackColor = Color.White;
        }

        private void mtxtpDataCompensacao_Leave(object sender, EventArgs e)
        {
            mtxtpDataCompensacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataCompensacao.Text != "")
            {
                try
                {
                    mtxtpDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataCompensacao.Text);

                    mtxtpDataCompensacao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataCompensacao1.Text != "")
                    {
                        mtxtpDataCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataCompensacao.Text) > Convert.ToDateTime(mtxtpDataCompensacao1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataCompensacao.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    mtxtpDataCompensacao.Text = null;
                }
            }
            mtxtpDataCompensacao.BackColor = Color.White;
        }

        private void mtxtpDataCompensacao1_Leave(object sender, EventArgs e)
        {
            mtxtpDataCompensacao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataCompensacao1.Text != "")
            {
                try
                {
                    mtxtpDataCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataCompensacao1.Text);

                    mtxtpDataCompensacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataCompensacao.Text != "")
                    {
                        mtxtpDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataCompensacao1.Text) < Convert.ToDateTime(mtxtpDataCompensacao.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataCompensacao1.Text = null;
                        }
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
                    mtxtpDataCompensacao1.Text = null;
                }
            }
            mtxtpDataCompensacao1.BackColor = Color.White;
        }

        private void mtxtpDataCompensacao_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataCompensacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataCompensacao.Text == "")
            {
                mtxtpDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataCompensacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorario_Leave(object sender, EventArgs e)
        {
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario.Text != "")
            {
                if (mtxtHorario.Text.Length == 4)
                {
                    mtxtHorario.Text = mtxtHorario.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorario.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    mtxtHorario.Text = null;
                }
            }
            mtxtHorario.BackColor = Color.White;
        }

        private void mtxtHorario1_Leave(object sender, EventArgs e)
        {
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario1.Text != "")
            {
                if (mtxtHorario1.Text.Length == 4)
                {
                    mtxtHorario1.Text = mtxtHorario1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorario1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    mtxtHorario1.Text = null;
                }
            }
            mtxtHorario1.BackColor = Color.White;
        }

        private void mtxtHorarioVencimento_Leave(object sender, EventArgs e)
        {
            mtxtHorarioVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioVencimento.Text != "")
            {
                if (mtxtHorarioVencimento.Text.Length == 4)
                {
                    mtxtHorarioVencimento.Text = mtxtHorario.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioVencimento.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    mtxtHorarioVencimento.Text = null;
                }
            }
            mtxtHorarioVencimento.BackColor = Color.White;
        }

        private void mtxtHorarioVencimento1_Leave(object sender, EventArgs e)
        {
            mtxtHorarioVencimento1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioVencimento1.Text != "")
            {
                if (mtxtHorarioVencimento1.Text.Length == 4)
                {
                    mtxtHorarioVencimento1.Text = mtxtHorario.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioVencimento1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    mtxtHorarioVencimento1.Text = null;
                }
            }
            mtxtHorarioVencimento1.BackColor = Color.White;
        }

        private void mtxtHorarioCompensacao_Leave(object sender, EventArgs e)
        {
            mtxtHorarioCompensacao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioCompensacao.Text != "")
            {
                if (mtxtHorarioCompensacao.Text.Length == 4)
                {
                    mtxtHorarioCompensacao.Text = mtxtHorario.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioCompensacao.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    mtxtHorarioCompensacao.Text = null;
                }
            }
            mtxtHorarioCompensacao.BackColor = Color.White;
        }

        private void mtxtHorarioCompensacao1_Leave(object sender, EventArgs e)
        {
            mtxtHorarioCompensacao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioCompensacao1.Text != "")
            {
                if (mtxtHorarioCompensacao1.Text.Length == 4)
                {
                    mtxtHorarioCompensacao1.Text = mtxtHorario.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioCompensacao1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    mtxtHorarioCompensacao1.Text = null;
                }
            }
            mtxtHorarioCompensacao1.BackColor = Color.White;
        }

        private void mtxtHorarioVencimento1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioVencimento1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioVencimento1.Text == "")
            {
                mtxtHorarioVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioVencimento1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new Point(763, 19);
            txtpCodigo.Visible = true;
            lblDataEntrada.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            mtxtHorario.Enabled = false;
            mtxtHorario1.Enabled = false;
            btnSelecionarData.Enabled = false;
            lblDataHorarioVencimento.Enabled = false;
            mtxtpDataVencimento.Enabled = false;
            lblEntidade.Enabled = false;
            mtxtpDataVencimento1.Enabled = false;
            mtxtHorarioVencimento.Enabled = false;
            mtxtHorarioVencimento1.Enabled = false;
            btnSelecionarDataVencimento.Enabled = false;
            btnSelecionarData.Enabled = false;
            cbbEntidadeBancaria.Enabled = false;
            btnProcurarEntidade.Enabled = false;
            lblDataHorarioCompensacao.Enabled = false;
            mtxtpDataCompensacao.Enabled = false;
            mtxtpDataCompensacao1.Enabled = false;
            mtxtHorarioCompensacao.Enabled = false;
            mtxtHorarioCompensacao1.Enabled = false;
            btnSelecionarDataCompensacao.Enabled = false;
            cbbConsumidor.Enabled = false;
            lblConsumidor.Enabled = false;
            btnProcurarCliente.Enabled = false;
            lblUsuario.Enabled = false;
            cbbUsuario.Enabled = false;
            btnProcurarUsuario.Enabled = false;
            cbbSituacao.Enabled = false;
            lblSituacao.Enabled = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnNCheque_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Digite o nº do cheque:";
            lblPesquisar.Location = new Point(729, 21);
            txtpCodigo.Visible = true;
            lblDataEntrada.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            mtxtHorario.Enabled = false;
            lblEntidade.Enabled = false;
            mtxtHorario1.Enabled = false;
            btnSelecionarData.Enabled = false;
            lblDataHorarioVencimento.Enabled = false;
            mtxtpDataVencimento.Enabled = false;
            mtxtpDataVencimento1.Enabled = false;
            mtxtHorarioVencimento.Enabled = false;
            mtxtHorarioVencimento1.Enabled = false;
            btnSelecionarDataVencimento.Enabled = false;
            btnSelecionarData.Enabled = false;
            cbbEntidadeBancaria.Enabled = false;
            btnProcurarEntidade.Enabled = false;
            lblDataHorarioCompensacao.Enabled = false;
            mtxtpDataCompensacao.Enabled = false;
            mtxtpDataCompensacao1.Enabled = false;
            mtxtHorarioCompensacao.Enabled = false;
            mtxtHorarioCompensacao1.Enabled = false;
            btnSelecionarDataCompensacao.Enabled = false;
            cbbConsumidor.Enabled = false;
            lblConsumidor.Enabled = false;
            btnProcurarCliente.Enabled = false;
            lblUsuario.Enabled = false;
            cbbUsuario.Enabled = false;
            btnProcurarUsuario.Enabled = false;
            cbbSituacao.Enabled = false;
            lblSituacao.Enabled = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new Point(815, 21);
            txtpCodigo.Visible = false;
            lblDataEntrada.Enabled = true;
            mtxtpData.Enabled = true;
            mtxtpData1.Enabled = true;
            mtxtHorario.Enabled = true;
            lblEntidade.Enabled = true;
            mtxtHorario1.Enabled = true;
            btnSelecionarData.Enabled = true;
            lblDataHorarioVencimento.Enabled = true;
            mtxtpDataVencimento.Enabled = true;
            mtxtpDataVencimento1.Enabled = true;
            mtxtHorarioVencimento.Enabled = true;
            mtxtHorarioVencimento1.Enabled = true;
            btnSelecionarDataVencimento.Enabled = true;
            btnSelecionarData.Enabled = true;
            cbbEntidadeBancaria.Enabled = true;
            btnProcurarEntidade.Enabled = true;
            lblDataHorarioCompensacao.Enabled = true;
            mtxtpDataCompensacao.Enabled = true;
            mtxtpDataCompensacao1.Enabled = true;
            mtxtHorarioCompensacao.Enabled = true;
            mtxtHorarioCompensacao1.Enabled = true;
            btnSelecionarDataCompensacao.Enabled = true;
            cbbConsumidor.Enabled = true;
            lblConsumidor.Enabled = true;
            btnProcurarCliente.Enabled = true;
            lblUsuario.Enabled = true;
            cbbUsuario.Enabled = true;
            btnProcurarUsuario.Enabled = true;
            cbbSituacao.Enabled = true;
            lblSituacao.Enabled = true;
            btnPesquisar.Select();
            //
            try
            {

                cbbUsuario.Items.Clear();
                if (bllControleCheque.Sel_Usuario_Controle_Cheque() == null)
                {
                    cbbUsuario.Enabled = false;
                    cbbUsuario.Text = null;
                }
                else
                {
                    cbbUsuario.Enabled = true;
                    cbbUsuario.Items.Add("");
                    foreach (DataRow dr in bllControleCheque.Sel_Usuario_Controle_Cheque().Rows)
                    {
                        cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                    }
                }
                //
                cbbConsumidor.Items.Clear();
                if (bllControleCheque.Sel_Cliente_Controle_Cheque() == null)
                {
                    cbbConsumidor.Enabled = false;
                    cbbConsumidor.Text = null;
                }
                else
                {
                    cbbConsumidor.Enabled = true;
                    cbbConsumidor.Items.Add("");
                    foreach (DataRow dr in bllControleCheque.Sel_Cliente_Controle_Cheque().Rows)
                    {
                        cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
                //
                cbbEntidadeBancaria.Items.Clear();
                if (bllControleCheque.Sel_Entidade_Bancaria_Controle_Cheque() == null)
                {
                    cbbEntidadeBancaria.Enabled = false;
                    cbbEntidadeBancaria.Text = null;
                }
                else
                {
                    cbbEntidadeBancaria.Enabled = true;
                    cbbEntidadeBancaria.Items.Add("");
                    foreach (DataRow dr in bllControleCheque.Sel_Entidade_Bancaria_Controle_Cheque().Rows)
                    {
                        cbbEntidadeBancaria.Items.Add((dr["id_ent_bancaria"].ToString()) + "—" + (dr["descricao"].ToString()));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnTodos.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento checkedchanged do radio botão rbtnTodos.");
                }
                cbbEntidadeBancaria.Items.Clear();
                cbbEntidadeBancaria.Text = null;
                cbbUsuario.Items.Clear();
                cbbUsuario.Text = null;
            }
        }

        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqCliente Clie = new FrmPesqCliente(7, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbConsumidor.Items.Clear();
                        if (bllControleCheque.Sel_Cliente_Controle_Cheque() == null)
                        {
                            cbbConsumidor.Text = null;
                            cbbConsumidor.Enabled = false;
                            lblConsumidor.Enabled = false;
                        }
                        else
                        {
                            cbbConsumidor.Enabled = true;
                            lblConsumidor.Enabled = true;
                            cbbConsumidor.Items.Add("");
                            foreach (DataRow dr in bllControleCheque.Sel_Cliente_Controle_Cheque().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        cbbConsumidor.Text = bllControleCheque._Consumidor_PesqControleCheque;
                        bllControleCheque._Consumidor_PesqControleCheque = null;
                        cbbConsumidor.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        cbbConsumidor.Text = null;
                        bllControleCheque._Consumidor_PesqControleCheque = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarUsuario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqUsuario User = new FrmPesqUsuario(9, _Usuario, _Cod_PDV_Computador))
            {
                if (User.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbUsuario.Items.Clear();
                        if (bllControleCheque.Sel_Usuario_Controle_Cheque() == null)
                        {
                            cbbUsuario.Text = null;
                            cbbUsuario.Enabled = false;
                            lblUsuario.Enabled = false;
                        }
                        else
                        {
                            cbbUsuario.Enabled = true;
                            lblUsuario.Enabled = true;
                            cbbUsuario.Items.Add("");
                            foreach (DataRow dr in bllControleCheque.Sel_Usuario_Controle_Cheque().Rows)
                            {
                                cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                            }
                        }
                        cbbUsuario.Text = bllControleCheque._Usuario_PesqControleCheque;
                        bllControleCheque._Usuario_PesqControleCheque = null;
                        cbbUsuario.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarUsuario.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarUsuario.");
                        }
                        cbbUsuario.Text = null;
                        bllControleCheque._Usuario_PesqControleCheque = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRelControleCheque_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmRelControleCheque_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelControleCheque foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelControleCheque foi finalizado.");
                }
                bllControleCheque._FrmRelControleCheque_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelControleCheque.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmRelControleCheque.");
                }
            }
        }

        private void btnProcurarPDV_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqEntidadeBancaria Ent = new FrmPesqEntidadeBancaria(2))
            {
                if (Ent.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbEntidadeBancaria.Items.Clear();
                        if (bllControleCheque.Sel_Entidade_Bancaria_Controle_Cheque() == null)
                        {
                            cbbEntidadeBancaria.Text = null;
                            cbbEntidadeBancaria.Enabled = false;
                            lblEntidade.Enabled = false;
                        }
                        else
                        {
                            cbbEntidadeBancaria.Enabled = true;
                            lblEntidade.Enabled = true;
                            cbbEntidadeBancaria.Items.Add("");
                            foreach (DataRow dr in bllControleCheque.Sel_Entidade_Bancaria_Controle_Cheque().Rows)
                            {
                                cbbEntidadeBancaria.Items.Add((dr["id_ent_bancaria"].ToString()) + "—" + (dr["descricao"].ToString()));
                            }
                        }
                        cbbEntidadeBancaria.Text = bllControleCheque._Entidade_Bancaria_PesqControleCheque;
                        bllControleCheque._Entidade_Bancaria_PesqControleCheque = null;
                        cbbEntidadeBancaria.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarEntidade.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarEntidade.");
                        }
                        cbbEntidadeBancaria.Text = null;
                        bllControleCheque._Entidade_Bancaria_PesqControleCheque = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por código, nº do cheque e todos os dados cadastrados e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(21))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllControleCheque._Data_DatePicker1;
                    mtxtpData1.Text = bllControleCheque._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSelecionarDataCompensacao_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(21))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataCompensacao.Text = bllControleCheque._Data_DatePicker1;
                    mtxtpDataCompensacao1.Text = bllControleCheque._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSelecionarDataVencimento_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(21))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataVencimento.Text = bllControleCheque._Data_DatePicker1;
                    mtxtpDataVencimento1.Text = bllControleCheque._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
            }
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
            }
        }

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
            }
        }

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataVencimento.Select();
            }
        }

        private void mtxtpDataVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioVencimento.Select();
            }
        }

        private void mtxtHorarioVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataVencimento1.Select();
            }
        }

        private void mtxtpDataVencimento1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioVencimento1.Select();
            }
        }

        private void mtxtHorarioVencimento1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbEntidadeBancaria.Select();
            }
        }

        private void cbbCodPDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataCompensacao.Select();
            }
        }

        private void mtxtpDataCompensacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioCompensacao.Select();
            }
        }

        private void mtxtHorarioCompensacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataCompensacao1.Select();
            }
        }

        private void mtxtHorarioCompensacao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbConsumidor.Select();
            }
        }

        private void cbbConsumidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUsuario.Select();
            }
        }

        private void cbbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void mtxtpDataCompensacao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioCompensacao1.Select();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text.Trim() != "")
                    {
                        if (bllControleCheque.Sel_Controle_Cheque_Codigo(txtpCodigo.Text.Trim()) == null)
                        {
                            dtCheque.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtCheque.DataSource = bllControleCheque.Sel_Controle_Cheque_Codigo(txtpCodigo.Text.Trim());
                            dtCheque.Select();
                        }
                    }
                }
                else if (rbtnNCheque.Checked == true)
                {
                    if (txtpCodigo.Text.Trim() != "")
                    {
                        if (bllControleCheque.Sel_Controle_Cheque_N_Cheque(txtpCodigo.Text.Trim()) == null)
                        {
                            dtCheque.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtCheque.DataSource = bllControleCheque.Sel_Controle_Cheque_N_Cheque(txtpCodigo.Text.Trim());
                            dtCheque.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Entrada ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpData.Select();
                        return;
                    }
                    else if ((mtxtpDataVencimento.Text == "" & mtxtpDataVencimento1.Text != "") || (mtxtpDataVencimento.Text != "" & mtxtpDataVencimento1.Text == ""))
                    {
                        mtxtpDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Vencimento ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpDataVencimento.Select();
                        return;
                    }
                    else if ((mtxtpDataCompensacao.Text == "" & mtxtpDataCompensacao1.Text != "") || (mtxtpDataCompensacao.Text != "" & mtxtpDataCompensacao1.Text == ""))
                    {
                        mtxtpDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Vencimento ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpDataCompensacao.Select();
                        return;
                    }
                    else
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioVencimento1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioCompensacao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioCompensacao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllControleCheque.Sel_Controle_Data_Hora_Usuario_Tipo_Situacao_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, mtxtpDataVencimento.Text, mtxtpDataVencimento1.Text, mtxtHorarioVencimento.Text, mtxtHorarioVencimento1.Text, mtxtpDataCompensacao.Text, mtxtpDataCompensacao1.Text, mtxtHorarioCompensacao.Text, mtxtHorarioCompensacao1.Text, cbbUsuario.Text, cbbSituacao.Text, cbbEntidadeBancaria.Text, cbbConsumidor.Text) == null)
                        {
                            dtCheque.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtCheque.DataSource = bllControleCheque.Sel_Controle_Data_Hora_Usuario_Tipo_Situacao_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, mtxtpDataVencimento.Text, mtxtpDataVencimento1.Text, mtxtHorarioVencimento.Text, mtxtHorarioVencimento1.Text, mtxtpDataCompensacao.Text, mtxtpDataCompensacao1.Text, mtxtHorarioCompensacao.Text, mtxtHorarioCompensacao1.Text, cbbUsuario.Text, cbbSituacao.Text, cbbEntidadeBancaria.Text, cbbConsumidor.Text);
                            dtCheque.Select();
                        }
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
                dtCheque.DataSource = null;
                rbtnCodigo.Checked = true;
            }
        }

        private void dtCheque_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtCheque.Columns[0].HeaderText = "Código";
                dtCheque.Columns[1].HeaderText = "Data de Entrada";
                dtCheque.Columns[2].HeaderText = "Horário de Entrada";
                dtCheque.Columns[3].HeaderText = "Tipo do Emitente";
                dtCheque.Columns[4].HeaderText = "Cód. do Emitente";
                dtCheque.Columns[5].HeaderText = "Nome do Emitente";
                dtCheque.Columns[6].HeaderText = "CPF/CNPJ Emitente";
                dtCheque.Columns[7].HeaderText = "Cód. da Entidade Bancária";
                dtCheque.Columns[8].HeaderText = "Nome da Entidade Bancária";
                dtCheque.Columns[9].HeaderText = "Agência";
                dtCheque.Columns[10].HeaderText = "Conta Corrente";
                dtCheque.Columns[11].HeaderText = "Nº do Cheque";
                dtCheque.Columns[12].HeaderText = "Valor (R$)";
                dtCheque.Columns[13].HeaderText = "Data de Vencimento";
                dtCheque.Columns[14].HeaderText = "Horário de Vencimento";
                dtCheque.Columns[15].HeaderText = "Data de Compensação";
                dtCheque.Columns[16].HeaderText = "Horário de Compensação";
                dtCheque.Columns[17].HeaderText = "Situação";
                dtCheque.Columns[18].HeaderText = "Cód. do Fato Gerador";
                dtCheque.Columns[19].HeaderText = "Cód. do Usuário";
                dtCheque.Columns[20].HeaderText = "Nome do Usuário";
                dtCheque.Columns[21].HeaderText = "Cód. do PDV/Computador";
                dtCheque.Columns[22].HeaderText = "Observações";

                dtCheque.DefaultCellStyle.Font = new Font(dtCheque.Font, FontStyle.Bold);

                dtCheque.Columns[0].Width = 95;
                dtCheque.Columns[1].Width = 115;
                dtCheque.Columns[2].Width = 125;
                dtCheque.Columns[3].Width = 145;
                dtCheque.Columns[4].Width = 115;
                dtCheque.Columns[5].Width = 325;
                dtCheque.Columns[6].Width = 185;
                dtCheque.Columns[7].Width = 165;
                dtCheque.Columns[8].Width = 325;
                dtCheque.Columns[9].Width = 115;
                dtCheque.Columns[10].Width = 150;
                dtCheque.Columns[11].Width = 115;
                dtCheque.Columns[12].Width = 115;
                dtCheque.Columns[13].Width = 145;
                dtCheque.Columns[14].Width = 145;
                dtCheque.Columns[15].Width = 150;
                dtCheque.Columns[16].Width = 155;
                dtCheque.Columns[17].Width = 105;
                dtCheque.Columns[18].Width = 135;
                dtCheque.Columns[19].Width = 150;
                dtCheque.Columns[20].Width = 170;
                dtCheque.Columns[21].Width = 170;
                dtCheque.Columns[22].Width = 500;
                //
                dtCheque.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtCheque.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //
                lblRegistros.Text = "Registros: " + dtCheque.Rows.Count;
                //
                decimal valortotal = 0;
                for (int i = 0; i < dtCheque.Rows.Count; i++)
                {
                    valortotal += Convert.ToDecimal(dtCheque.Rows[i].Cells[12].Value);
                }
                lblValorTotal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valorcompensado = 0;
                for (int i = 0; i < dtCheque.Rows.Count; i++)
                {
                    if (dtCheque.Rows[i].Cells[17].Value.ToString() == "COMPENSADO")
                    {
                        valorcompensado += Convert.ToDecimal(dtCheque.Rows[i].Cells[12].Value);
                    }
                    lblValorCompensados.Text = Convert.ToDecimal(valorcompensado).ToString("n2", new CultureInfo("pt-BR"));
                }
                //
                decimal valorpendente = 0;
                for (int i = 0; i < dtCheque.Rows.Count; i++)
                {
                    if (dtCheque.Rows[i].Cells[17].Value.ToString() == "PENDENTE")
                    {
                        valorpendente += Convert.ToDecimal(dtCheque.Rows[i].Cells[12].Value);
                    }
                    lblValorPendente.Text = Convert.ToDecimal(valorpendente).ToString("n2", new CultureInfo("pt-BR"));
                }
                //
                decimal valorcancelado = 0;
                for (int i = 0; i < dtCheque.Rows.Count; i++)
                {
                    if (dtCheque.Rows[i].Cells[17].Value.ToString() == "CANCELADO")
                    {
                        valorcancelado += Convert.ToDecimal(dtCheque.Rows[i].Cells[12].Value);
                    }
                    lblValorCancelado.Text = Convert.ToDecimal(valorcancelado).ToString("n2", new CultureInfo("pt-BR"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtCheque.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtCheque.");
                }
                dtCheque.DataSource = null;
            }
        }

        private void dtCheque_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 13 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 15 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 18 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void dtCheque_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorTotal.Text = null;
            lblValorPendente.Text = null;
            lblValorCompensados.Text = null;
            lblValorCancelado.Text = null;
        }

        private void dtCheque_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtCheque.Columns[12].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtCheque.Columns[12].DefaultCellStyle.Format = "n2";

            dtCheque.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtCheque.DefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewRow SelectedRow = dtCheque.Rows[dtCheque.CurrentRow.Index];

            if (SelectedRow.Cells[17].Value.ToString() == "PENDENTE")
            {
                lblValorSituacao.Text = "PENDENTE";
                btnBaixarCheque.Enabled = true;
                btnDesfazer.Enabled = false;
                lblValorSituacao.ForeColor = Color.Coral;
                lblCxSituacao.BackColor = Color.Coral;
            }
            else if (SelectedRow.Cells[17].Value.ToString() == "COMPENSADO")
            {
                lblValorSituacao.Text = "COMPENSADO";
                btnBaixarCheque.Enabled = false;
                btnDesfazer.Enabled = true;
                lblValorSituacao.ForeColor = Color.Green;
                lblCxSituacao.BackColor = Color.Green;
            }
            else if (SelectedRow.Cells[17].Value.ToString() == "CANCELADO")
            {
                lblValorSituacao.Text = "CANCELADO";
                btnBaixarCheque.Enabled = false;
                btnDesfazer.Enabled = false;
                lblValorSituacao.ForeColor = Color.Red;
                lblCxSituacao.BackColor = Color.Red;
            }
        }

        private void lblValorPendente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pendentes (R$): " + lblValorPendente.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblValorCompensados_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Compensados (R$): " + lblValorCompensados.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtCheque_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtCheque.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtCheque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtCheque_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtCheque.DataSource == null)
            {
                dtCheque.Enabled = false;
                grbBox2.Enabled = false;
                lblTotal.Enabled = false;
                lblValorTotal.Enabled = false;
                lblPendente.Enabled = false;
                lblValorPendente.Enabled = false;
                lblCompensados.Enabled = false;
                lblValorCompensados.Enabled = false;
                lblCxSituacao.BackColor = Color.White;
                lblValorSituacao.ForeColor = Color.White;
                lblValorSituacao.Text = "Situação";
                lblCancelado.Enabled = false;
                lblValorCancelado.Enabled = false;
            }
            else
            {
                dtCheque.Enabled = true;
                grbBox2.Enabled = true;
                lblTotal.Enabled = true;
                lblValorTotal.Enabled = true;
                lblPendente.Enabled = true;
                lblValorPendente.Enabled = true;
                lblCompensados.Enabled = true;
                lblValorCompensados.Enabled = true;
                lblCancelado.Enabled = true;
                lblValorCancelado.Enabled = true;
            }
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            if (txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpCodigo.Text = null;
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnTodasCheques_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(7))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    if (bllVenda._Tipo_Impressao == "PDF A4")
                    {
                        _Trabalho = 0;
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtCheque.Enabled = false;
                    dtCheque.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao1.Enabled = false;
                    picbInterrogacao.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void bckwIndeterminado_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (_Trabalho == 0)
            {
                using (var doc = new PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Width = 595;
                    page.Height = 842;
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                    var fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                    var fonte4 = new XFont("Microsoft Sans Serif", 9);
                    XPen pen1 = new XPen(XColors.LightBlue);
                    XPen pen = new XPen(XColors.Black);
                    DataRow dr;
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllVenda._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 10 + Margem_Esq, 7 + Margem_Topo, 100, 116);
                    }
                    //DATA
                    graphics.DrawRectangle(pen, XBrushes.White, 494 + Margem_Esq, 5 + Margem_Topo, 95, 122);
                    textFormatter2.DrawString("Criado em:", fonte4, XBrushes.Black, new XRect(515 + Margem_Esq, 10 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString(DateTime.Now.ToShortDateString(), fonte1, XBrushes.Black, new XRect(510 + Margem_Esq, 22 + Margem_Topo, page.Width, page.Height));
                    //HORÁRIO                    
                    textFormatter2.DrawString("Horário:", fonte4, XBrushes.Black, new XRect(527 + Margem_Esq, 72 + Margem_Topo, page.Width, page.Height));
                    textFormatter2.DrawString(DateTime.Now.ToLongTimeString(), fonte1, XBrushes.Black, new XRect(516 + Margem_Esq, 84 + Margem_Topo, page.Width, page.Height));
                    //CABECALHO  DOCUMENTO
                    dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    if (!dr["nome"].ToString().Contains(" ") & dr["nome"].ToString().Length > 38)
                    {
                        textFormatter1.DrawString(dr["nome"].ToString().Insert(38, Environment.NewLine), fonte1, XBrushes.Black, new XRect(115 + Margem_Esq, 7 + Margem_Topo, 370, 28));
                    }
                    else
                    {
                        textFormatter1.DrawString(dr["nome"].ToString(), fonte1, XBrushes.Black, new XRect(115 + Margem_Esq, 7 + Margem_Topo, 370, 28));
                    }
                    //
                    textFormatter1.DrawString(dr["fantasia"].ToString() + Environment.NewLine + "CPF/CNPJ.: " + dr["cpf_cnpj"].ToString() + ", IE.: " + dr["ie_rg"].ToString() + Environment.NewLine + "End.: " + dr["endereco"].ToString() + Environment.NewLine + dr["complemento"].ToString() + ", " + dr["numero"].ToString() + Environment.NewLine + dr["bairro"].ToString() + ", " + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + Environment.NewLine + "Tel.: " + dr["telefone"].ToString() + ", Cel.: " + dr["celular"].ToString() + Environment.NewLine + "E-mail.: " + dr["email"].ToString(), fonte2, XBrushes.Black, new XRect(115 + Margem_Esq, 35 + Margem_Topo, 370, 95));
                    //
                    textFormatter1.DrawString("Relatório de Controle de Cheque", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO    CONSUMIDOR     ENT.BANCARIA     DATA VENC.     DATA COMP.      VALOR (R$)", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //                  
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtCheque.Rows.Count; i++)
                    {
                        if (i == 16)
                        {
                            TotalPaginas = TotalPaginas + 1;
                        }
                        else if (i == registros)
                        {
                            registros = registros + 21;
                            TotalPaginas = TotalPaginas + 1;
                        }
                    }
                    //
                    textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                    textFormatter1.DrawString("Páginas: 1 de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                    //   
                    for (int linha = 0; linha < dtCheque.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtCheque.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtCheque.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(85 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString() + "-" + SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Ent/Banco.:", fonte2, XBrushes.Black, new XRect(380 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString() + "-" + SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(430 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Ent.:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(63 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Venc.:", fonte2, XBrushes.Black, new XRect(150 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(215 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Compensação:", fonte2, XBrushes.Black, new XRect(300 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte4, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));

                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(485 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(533 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Pendentes (R$): " + lblValorPendente.Text, fonte2, XBrushes.Coral, new XRect(135 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Cancelados (R$): " + lblValorCancelado.Text, fonte2, XBrushes.Red, new XRect(275 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Compensados (R$): " + lblValorCompensados.Text, fonte2, XBrushes.Green, new XRect(420 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(85 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString() + "-" + SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Ent/Banco.:", fonte2, XBrushes.Black, new XRect(380 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[7].Value.ToString() + "-" + SelectedRow.Cells[8].Value.ToString(), fonte4, XBrushes.Black, new XRect(430 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Ent.:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(63 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Venc.:", fonte2, XBrushes.Black, new XRect(150 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[13].Value.ToString(), fonte4, XBrushes.Black, new XRect(215 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Compensação:", fonte2, XBrushes.Black, new XRect(300 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[15].Value.ToString(), fonte4, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));

                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(485 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(533 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            //
                            if (linha == (pagina - 1) & dtCheque.Rows.Count > 16)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                ContadorPagina = ContadorPagina + 1;
                                pagina = pagina + 22;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                fonte4 = new XFont("Microsoft Sans Serif", 9);
                                pen1 = new XPen(XColors.LightBlue);
                                pen = new XPen(XColors.Black);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                textFormatter1.DrawString("Relatório de Controle de Cheque", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                        }
                        else
                        {
                            if (linha == (pagina - 1))
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                ContadorPagina = ContadorPagina + 1;
                                pagina = pagina + 21;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 9, XFontStyle.Bold);
                                fonte3 = new XFont("Calibri", 34, XFontStyle.Bold);
                                fonte4 = new XFont("Microsoft Sans Serif", 9);
                                pen1 = new XPen(XColors.LightBlue);
                                pen = new XPen(XColors.Black);
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                //
                                textFormatter1.DrawString("Relatório de Controle de Cheque", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtCheque.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(85 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString() + "-" + SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Ent/Banco.:", fonte2, XBrushes.Black, new XRect(380 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString() + "-" + SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(430 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Ent.:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(63 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Venc.:", fonte2, XBrushes.Black, new XRect(150 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte4, XBrushes.Black, new XRect(215 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Compensação:", fonte2, XBrushes.Black, new XRect(300 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(485 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(533 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 61) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Total (R$): " + lblValorTotal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Pendentes (R$): " + lblValorPendente.Text, fonte2, XBrushes.Coral, new XRect(135 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Cancelados (R$): " + lblValorCancelado.Text, fonte2, XBrushes.Red, new XRect(275 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString("Compensados (R$): " + lblValorCompensados.Text, fonte2, XBrushes.Green, new XRect(420 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(41 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(85 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[4].Value.ToString() + "-" + SelectedRow.Cells[5].Value.ToString(), fonte4, XBrushes.Black, new XRect(141 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Ent/Banco.:", fonte2, XBrushes.Black, new XRect(380 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[6].Value.ToString() + "-" + SelectedRow.Cells[7].Value.ToString(), fonte4, XBrushes.Black, new XRect(430 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Ent.:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString(), fonte4, XBrushes.Black, new XRect(63 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Venc.:", fonte2, XBrushes.Black, new XRect(150 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte4, XBrushes.Black, new XRect(215 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Data de Compensação:", fonte2, XBrushes.Black, new XRect(300 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(400 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(485 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(533 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;
                            }
                        }
                    }
                    //
                    PdfSecuritySettings security = doc.SecuritySettings;
                    //
                    security.PermitAccessibilityExtractContent = false;
                    security.PermitAnnotations = false;
                    security.PermitAssembleDocument = false;
                    security.PermitExtractContent = false;
                    security.PermitFormsFill = true;
                    security.PermitFullQualityPrint = false;
                    security.PermitModifyDocument = false;
                    security.PermitPrint = true;
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.pdf");
                    }
                }
            }
            else if (_Trabalho == 1)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Data de Entrada;Horário de Entrada;Tipo do Emitente;Cód. do Emitente;Nome do Emitente;CPF/CNPJ Emitente;Cód. da Entidade Bancária;Nome da Entidade Bancária;Agência;Conta Corrente;Nº do Cheque;Valor (R$);Data de Vencimento;Horário de Vencimento;Data de Compensação;Horário de Compensação;Situação;Cód. do Fato Gerador;Cód. do Usuário;Nome do Usuário;Cód. do PDV/Computador;Observações");
                    for (int linha = 0; linha < dtCheque.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtCheque.Rows[linha];
                        //
                        string data_vencimento = SelectedRow.Cells[13].Value.ToString();
                        string hora_vencimento = SelectedRow.Cells[14].Value.ToString();
                        //
                        string data_compensacao = SelectedRow.Cells[15].Value.ToString();
                        string hora_comepensacao = SelectedRow.Cells[16].Value.ToString();
                        //
                        string fato_gerador = SelectedRow.Cells[18].Value.ToString();
                        //
                        if (fato_gerador == "0")
                        {
                            fato_gerador = "";
                        }
                        //
                        if (data_vencimento == "" || data_vencimento == null)
                        {
                            data_vencimento = "";
                        }
                        else
                        {
                            data_vencimento = data_vencimento.Remove(10);
                        }
                        //
                        if (hora_vencimento == "" || hora_vencimento == null)
                        {
                            hora_vencimento = "";
                        }
                        else
                        {
                            hora_vencimento = hora_vencimento.Remove(5);
                        }
                        //
                        if (data_compensacao == "" || data_compensacao == null)
                        {
                            data_compensacao = "";
                        }
                        else
                        {
                            data_compensacao = data_compensacao.Remove(10);
                        }
                        //
                        if (hora_comepensacao == "" || hora_comepensacao == null)
                        {
                            hora_comepensacao = "";
                        }
                        else
                        {
                            hora_comepensacao = hora_comepensacao.Remove(5);
                        }
                        //
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21};{22}", SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString().Remove(10), SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[6].Value.ToString(), SelectedRow.Cells[7].Value.ToString(), SelectedRow.Cells[8].Value.ToString(), SelectedRow.Cells[9].Value.ToString(), SelectedRow.Cells[10].Value.ToString(), SelectedRow.Cells[11].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-BR")), data_vencimento, hora_vencimento, data_compensacao, hora_comepensacao, SelectedRow.Cells[17].Value.ToString(), fato_gerador, SelectedRow.Cells[19].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), SelectedRow.Cells[21].Value.ToString(), SelectedRow.Cells[22].Value.ToString()));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Controle de Cheque");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                    Sw.WriteLine("Total (R$): " + lblValorTotal.Text);
                    Sw.WriteLine("Pendentes (R$): " + lblValorPendente.Text);
                    Sw.WriteLine("Cancelados (R$): " + lblValorCancelado.Text);
                    Sw.WriteLine("Compensados (R$): " + lblValorCompensados.Text);
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.csv");
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque");
                }
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.txt");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.txt"))
                {
                    writer.WriteLine("Relatório de Controle de Cheque" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToShortTimeString());
                    for (int linha = 0; linha < dtCheque.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtCheque.Rows[linha];
                        string data_vencimento = SelectedRow.Cells[13].Value.ToString();
                        string hora_vencimento = SelectedRow.Cells[14].Value.ToString();
                        //
                        string data_compensacao = SelectedRow.Cells[15].Value.ToString();
                        string hora_comepensacao = SelectedRow.Cells[16].Value.ToString();
                        //
                        string fato_gerador = SelectedRow.Cells[18].Value.ToString();
                        //
                        if (fato_gerador == "0")
                        {
                            fato_gerador = "";
                        }
                        //
                        if (data_vencimento == "" || data_vencimento == null)
                        {
                            data_vencimento = "";
                        }
                        else
                        {
                            data_vencimento = data_vencimento.Remove(10);
                        }
                        //
                        if (hora_vencimento == "" || hora_vencimento == null)
                        {
                            hora_vencimento = "";
                        }
                        else
                        {
                            hora_vencimento = hora_vencimento.Remove(5);
                        }
                        //
                        if (data_compensacao == "" || data_compensacao == null)
                        {
                            data_compensacao = "";
                        }
                        else
                        {
                            data_compensacao = data_compensacao.Remove(10);
                        }
                        //
                        if (hora_comepensacao == "" || hora_comepensacao == null)
                        {
                            hora_comepensacao = "";
                        }
                        else
                        {
                            hora_comepensacao = hora_comepensacao.Remove(5);
                        }
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Data de Entrada: " + SelectedRow.Cells[1].Value.ToString().Remove(10) + " |Horário de Entrada: " + SelectedRow.Cells[2].Value.ToString() + " |Tipo do Emitente: " + SelectedRow.Cells[3].Value.ToString() + " |Cód. do Emitente: " + SelectedRow.Cells[4].Value.ToString() + " |Nome do Emitente: " + SelectedRow.Cells[5].Value.ToString() + " |CPF/CNPJ Emitente: " + SelectedRow.Cells[6].Value.ToString() + " |Cód. da Entidade Bancária: " + SelectedRow.Cells[7].Value.ToString() + " |Nome da Entidade Bancária: " + SelectedRow.Cells[8].Value.ToString() + " |Agência: " + SelectedRow.Cells[9].Value.ToString() + " |Conta Corrente: " + SelectedRow.Cells[10].Value.ToString() + " |Nº do Cheque: " + SelectedRow.Cells[11].Value.ToString() + " |Valor (R$): " + Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-br")) + " |Data de Vencimento: " + data_vencimento + " |Horário de Vencimento: " + hora_vencimento + " |Data de Compensação: " + data_compensacao + " |Horário de Compensação: " + hora_comepensacao + " |Situação: " + SelectedRow.Cells[17].Value.ToString() + " |Cód. do Fato Gerador: " + fato_gerador + " |Cód. do Usuário: " + SelectedRow.Cells[19].Value.ToString() + " |Nome do Usuário: " + SelectedRow.Cells[20].Value.ToString() + " |Cód. do PDV/Computador: " + SelectedRow.Cells[21].Value.ToString() + " |Observações: " + SelectedRow.Cells[22].Value.ToString());
                    }
                    writer.WriteLine("Total (R$): " + lblValorTotal.Text);
                    writer.WriteLine("Pendentes (R$): " + lblValorPendente.Text);
                    writer.WriteLine("Cancelados (R$): " + lblValorCancelado.Text);
                    writer.WriteLine("Compensados (R$): " + lblValorCompensados.Text);
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.txt");
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                MessageBox.Show(e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                //
                pgbProgresso.Value = 0;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtCheque.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao.Enabled = true;
                btnSair.Enabled = true;
            }
            else
            {
                //Carrega todo progressbar.
                pgbProgresso.MarqueeAnimationSpeed = 0;
                pgbProgresso.Value = 100;
                this.Cursor = Cursors.Default;
                pgbProgresso.Visible = false;
                lblProgresso.Visible = false;
                dtCheque.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao1.Enabled = true;
                picbInterrogacao.Enabled = true;
                dtCheque.Select();
                //
                try
                {
                    DataGridViewRow SelectedRow = dtCheque.Rows[dtCheque.CurrentRow.Index];

                    if (_Trabalho == 0)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\ControleCheque\ControleCheque.pdf");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    //
                    pgbProgresso.Value = 0;
                    this.Cursor = Cursors.Default;
                    pgbProgresso.Visible = false;
                    lblProgresso.Visible = false;
                    dtCheque.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao1.Enabled = true;
                    picbInterrogacao.Enabled = true;
                    btnSair.Enabled = true;
                    rbtnCodigo.Checked = true;
                }
            }
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 1;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtCheque.Enabled = false;
            dtCheque.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao.Enabled = false;
        }

        private void rbtnExportarTxt_Click(object sender, EventArgs e)
        {
            pgbProgresso.Visible = true;
            lblProgresso.Visible = true;
            _Trabalho = 2;
            bckwIndeterminado.RunWorkerAsync();
            pgbProgresso.MarqueeAnimationSpeed = 2;
            this.Cursor = Cursors.WaitCursor;
            dtCheque.Enabled = false;
            dtCheque.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao1.Enabled = false;
            picbInterrogacao.Enabled = false;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnContaReceberCheque_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnContaReceberCheque_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnContaReceberCheque_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtCheque.Rows[dtCheque.CurrentRow.Index];
                //
                if (bllControleCheque.Sel_Controle_Cheque_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtCheque.Select();
                }
                else
                {
                    using (FrmRelBaixarCheque Cheque = new FrmRelBaixarCheque(_Usuario, _Cod_PDV_Computador, SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[1].Value.ToString(), SelectedRow.Cells[13].Value.ToString(), SelectedRow.Cells[11].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[12].Value).ToString("n2", new CultureInfo("pt-br")), SelectedRow.Cells[4].Value.ToString() + "—" + SelectedRow.Cells[5].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), SelectedRow.Cells[18].Value.ToString()))
                    {
                        if (Cheque.ShowDialog() == DialogResult.OK)
                        {
                            if (bllControleCheque.Sel_Controle_Cheque_Codigo(SelectedRow.Cells[0].Value.ToString()) == null)
                            {
                                dtCheque.DataSource = null;
                            }
                            else
                            {
                                dtCheque.DataSource = bllControleCheque.Sel_Controle_Cheque_Codigo(SelectedRow.Cells[0].Value.ToString());
                                //
                                this.DialogResult = DialogResult.None;
                                //
                                dtCheque.Select();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnBaixaRegistro.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnBaixaRegistro.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtCheque.Rows[dtCheque.CurrentRow.Index];
                //
                if (bllControleCheque.Sel_Controle_Cheque_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Este registro já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtCheque.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja desfazer a baixa do registro selecionado? Todos os dados de pagamento serão excluídos, deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        //
                        bllControleCheque.Desfazer_refazer_Baixa_Controle_Cheque(SelectedRow.Cells[0].Value.ToString());
                        //
                        if (bllContasReceber.Sel_Conta_Codigo_Controle_Cheque_Receber(SelectedRow.Cells[0].Value.ToString()) != null)
                        {
                            DataRow dr = bllContasReceber.Sel_Conta_Codigo_Controle_Cheque_Receber(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                            //
                            bllContasReceber.Excluir_Pagamento_Conta_Receber(dr["id_conta_receber"].ToString());
                            //
                            bllContasReceber.Excluir(dr["id_conta_receber"].ToString());
                        }
                        //
                        bllFluxoCaixa.Salvar(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), "SAIDA", "CANCELAMENTO DE RECEBIMENTO DE CONTA A RECEBER", SelectedRow.Cells[12].Value.ToString(), SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //
                        if (bllControleCheque.Sel_Controle_Cheque_Codigo(SelectedRow.Cells[0].Value.ToString()) == null)
                        {
                            dtCheque.DataSource = null;
                        }
                        else
                        {
                            dtCheque.DataSource = bllControleCheque.Sel_Controle_Cheque_Codigo(SelectedRow.Cells[0].Value.ToString());
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDesfazer.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnDesfazer.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnDesfazer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDesfazer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir um relatório simples em PDF.\n\n2 - Exp. dados para (.txt): Clique para exportar os dados da tabela para um arquivo (.txt).\n\n3 - Exp. dados para (.csv): Clique para exportar os dados da tabela para um arquivo (.csv).\n\n4 - Desfazer Baixa: Desfaz a baixa do registro selecionado.\n\n5 - Baixar Registro: Clique para baixar um registro de um cheque.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorCancelado_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblValorCancelado_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorCancelado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancelados (R$): " + lblValorCancelado.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
