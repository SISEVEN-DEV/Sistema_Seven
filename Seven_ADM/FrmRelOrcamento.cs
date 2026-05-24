using BLL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using Seven_ADM;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmRelOrcamento : Form
    {
        public FrmRelOrcamento(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        byte _Trabalho;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmRelOrcamento_Load(object sender, EventArgs e)
        {
            try
            {
                bllOrcamento._FrmRelOrcamento_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelOrcamento iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelOrcamento iniciado.");
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelOrcamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmRelOrcamento.");
                }
                this.Close();
            }
        }

        private void Limpar_OutrosFiltros()
        {
            mtxtHorario.Text = null;
            mtxtHorario1.Text = null;
            mtxtpData.Text = null;
            mtxtpData1.Text = null;
            mtxtpDataVal.Text = null;
            mtxtpDataVal1.Text = null;
            cbbUsuario.Text = null;
            cbbCodPDV.Text = null;
            cbbConsumidor.Text = null;
            cbbSituacao.Text = null;
            mtxtHorarioVal.Text = null;
            mtxtHorarioVal1.Text = null;
        }

        private void rbtnCodigo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnCodigo_MouseLeave(object sender, EventArgs e)
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

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarCliente_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnProcurarCliente_MouseLeave(object sender, EventArgs e)
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

        private void btnPesquisar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnPesquisar_MouseLeave(object sender, EventArgs e)
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

        private void cbbUsuario_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbUsuario_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
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

        private void cbbSituacao_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSituacao_DropDownClosed(object sender, EventArgs e)
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

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
            }
        }

        private void mtxtpData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
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
        }

        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
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

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
            }
        }

        private void mtxtpData1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
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
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
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

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(12))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllOrcamento._Data_DatePicker1;
                    mtxtpData1.Text = bllOrcamento._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
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

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
            }
        }

        private void mtxtHorario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
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
        }

        private void mtxtHorario_Enter(object sender, EventArgs e)
        {
            mtxtHorario.BackColor = Color.LightBlue;
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

                    mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtHorario1.Text != "")
                    {
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtHorario.Text) > Convert.ToDateTime(mtxtHorario1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtHorario.Text = null;
                        }
                    }
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

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataVal.Select();
            }
        }

        private void mtxtHorario1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
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
        }

        private void mtxtHorario1_Enter(object sender, EventArgs e)
        {
            mtxtHorario1.BackColor = Color.LightBlue;
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

                    mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtHorario.Text != "")
                    {
                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtHorario1.Text) < Convert.ToDateTime(mtxtHorario.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtHorario1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario1.");
                    }
                    mtxtHorario1.Text = null;
                }
            }
            mtxtHorario1.BackColor = Color.White;
        }

        private void FrmRelOrcamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bllOrcamento._FrmRelOrcamento_Ativo = false;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelOrcamento foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmRelOrcamento foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelOrcamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmRelOrcamento.");
                }
            }
        }

        private void FrmRelOrcamento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void mtxtpDataVal_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataVal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVal.Text == "")
            {
                mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataVal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataVal1.Select();
            }
        }

        private void mtxtpDataVal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataVal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataVal.Text == "")
                {
                    mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataVal.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataVal_Enter(object sender, EventArgs e)
        {
            mtxtpDataVal.BackColor = Color.LightBlue;
        }

        private void mtxtpDataVal_Leave(object sender, EventArgs e)
        {
            mtxtpDataVal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVal.Text != "")
            {
                try
                {
                    mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataVal.Text);

                    mtxtpDataVal1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataVal1.Text != "")
                    {
                        mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataVal.Text) > Convert.ToDateTime(mtxtpDataVal1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataVal.Text = null;
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
                    mtxtpDataVal.Text = null;
                }
            }
            mtxtpDataVal.BackColor = Color.White;
        }

        private void mtxtpDataVal1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataVal1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVal1.Text == "")
            {
                mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataVal1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataVal1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioVal.Select();
            }
        }

        private void mtxtpDataVal1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataVal1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataVal1.Text == "")
                {
                    mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataVal1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataVal1_Enter(object sender, EventArgs e)
        {
            mtxtpDataVal1.BackColor = Color.LightBlue;
        }

        private void mtxtpDataVal1_Leave(object sender, EventArgs e)
        {
            mtxtpDataVal1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataVal1.Text != "")
            {
                try
                {
                    mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataVal1.Text);

                    mtxtpDataVal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataVal.Text != "")
                    {
                        mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataVal1.Text) < Convert.ToDateTime(mtxtpDataVal.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataVal1.Text = null;
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
                    mtxtpDataVal1.Text = null;
                }
            }
            mtxtpDataVal1.BackColor = Color.White;
        }

        private void cbbUsuario_KeyPress(object sender, KeyPressEventArgs e)
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
                cbbSituacao.Select();
            }
        }

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbCodPDV.Select();
            }
        }

        private void cbbCodPDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void rbtnCodigo_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            mtxtHorarioVal.Enabled = false;
            mtxtHorarioVal1.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            lblDatas.Enabled = false;
            lblAte.Enabled = false;
            cbbSituacao.Enabled = false;
            mtxtHorario.Enabled = false;
            mtxtHorario1.Enabled = false;
            btnSelecionarData.Enabled = false;
            lblUsuario.Enabled = false;
            cbbUsuario.Enabled = false;
            btnProcurarUsuario.Enabled = false;
            lblCodPDV.Enabled = false;
            cbbCodPDV.Enabled = false;
            btnProcurarUsuario.Enabled = false;
            btnProcurarCliente.Enabled = false;
            cbbConsumidor.Enabled = false;
            lblConsumidor.Enabled = false;
            txtpCodigo.Visible = true;
            lblPesquisar.Text = "Digite o código:";
            lblPesquisar.Location = new System.Drawing.Point(571, 19);
            label1.Enabled = false;
            mtxtpData.Enabled = false;
            mtxtpData1.Enabled = false;
            btnSelecionarData1.Enabled = false;
            lblAte2.Enabled = false;
            btnSelecionarData.Enabled = false;
            lblSituacao.Enabled = false;
            btnProcurarPDV.Enabled = false;
            mtxtpDataVal.Enabled = false;
            mtxtpDataVal1.Enabled = false;
            txtpCodigo.Text = null;
            txtpCodigo.Select();
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

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            Limpar_OutrosFiltros();
            mtxtHorarioVal.Enabled = true;
            mtxtHorarioVal1.Enabled = true;
            mtxtpData.Enabled = true;
            mtxtpData1.Enabled = true;
            lblDatas.Enabled = true;
            lblAte.Enabled = true;
            cbbSituacao.Enabled = true;
            mtxtHorario.Enabled = true;
            mtxtHorario1.Enabled = true;
            btnSelecionarData.Enabled = true;
            lblUsuario.Enabled = true;
            cbbUsuario.Enabled = true;
            btnProcurarUsuario.Enabled = true;
            lblCodPDV.Enabled = true;
            cbbCodPDV.Enabled = true;
            btnProcurarUsuario.Enabled = true;
            btnProcurarCliente.Enabled = true;
            cbbConsumidor.Enabled = true;
            lblConsumidor.Enabled = true;
            txtpCodigo.Visible = false;
            lblPesquisar.Text = "Exibir todo o cadastro:";
            lblPesquisar.Location = new System.Drawing.Point(619, 19);
            label1.Enabled = true;
            mtxtpData.Enabled = true;
            mtxtpData1.Enabled = true;
            lblAte2.Enabled = true;
            btnSelecionarData.Enabled = true;
            lblSituacao.Enabled = true;
            btnSelecionarData1.Enabled = true;
            btnProcurarPDV.Enabled = true;
            mtxtpDataVal.Enabled = true;
            mtxtpDataVal1.Enabled = true;
            btnPesquisar.Select();
            //
            try
            {
                cbbConsumidor.Items.Clear();
                if (bllOrcamento.Sel_Cliente_Orc() == null)
                {
                    cbbConsumidor.Enabled = false;
                    cbbConsumidor.Text = null;
                }
                else
                {
                    cbbConsumidor.Enabled = true;
                    cbbConsumidor.Items.Add("");
                    foreach (DataRow dr in bllOrcamento.Sel_Cliente_Orc().Rows)
                    {
                        cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                    }
                }
                //  
                cbbUsuario.Items.Clear();
                if (bllOrcamento.Sel_Usuario_Orc() == null)
                {
                    cbbUsuario.Enabled = false;
                    cbbUsuario.Text = null;
                }
                else
                {
                    cbbUsuario.Enabled = true;
                    cbbUsuario.Items.Add("");
                    foreach (DataRow dr in bllOrcamento.Sel_Usuario_Orc().Rows)
                    {
                        cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                    }
                }
                //
                cbbCodPDV.Items.Clear();
                if (bllOrcamento.Sel_Cod_PDV_Orc() == null)
                {
                    cbbCodPDV.Enabled = false;
                    cbbCodPDV.Text = null;
                }
                else
                {
                    cbbCodPDV.Items.Add("");
                    foreach (DataRow dr in bllOrcamento.Sel_Cod_PDV_Orc().Rows)
                    {
                        cbbCodPDV.Items.Add((dr["id_cadastro_computadores"].ToString()));
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
                cbbCodPDV.Items.Clear();
                cbbCodPDV.Text = null;
                cbbUsuario.Items.Clear();
                cbbUsuario.Text = null;
                cbbConsumidor.Items.Clear();
                cbbConsumidor.Text = null;
            }
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(12))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpDataVal.Text = bllOrcamento._Data_DatePicker1;
                    mtxtpDataVal1.Text = bllOrcamento._Data_DatePicker2;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarPDV_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqComputadorPDV Comp = new FrmPesqComputadorPDV(7))
            {
                if (Comp.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbCodPDV.Items.Clear();
                        if (bllOrcamento.Sel_Cod_PDV_Orc() != null)
                        {
                            cbbCodPDV.Items.Add("");
                            foreach (DataRow dr in bllOrcamento.Sel_Cod_PDV_Orc().Rows)
                            {
                                cbbCodPDV.Items.Add((dr["id_cadastro_computadores"].ToString()));
                            }
                        }
                        cbbCodPDV.Text = bllOrcamento._Orc_PesqCompPDV_Tabela;
                        bllOrcamento._Orc_PesqCompPDV_Tabela = null;
                        cbbCodPDV.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarPDV.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarPDV.");
                        }
                        cbbCodPDV.Text = null;
                        bllOrcamento._Orc_PesqCompPDV_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarUsuario_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqUsuario User = new FrmPesqUsuario(8, _Usuario, _Cod_PDV_Computador))
            {
                if (User.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbUsuario.Items.Clear();
                        if (bllOrcamento.Sel_Usuario_Orc() == null)
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
                            foreach (DataRow dr in bllOrcamento.Sel_Usuario_Orc().Rows)
                            {
                                cbbUsuario.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                            }
                        }
                        cbbUsuario.Text = bllOrcamento._Orc_PesqUsuario_Tabela;
                        bllOrcamento._Orc_PesqUsuario_Tabela = null;
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
                        bllOrcamento._Orc_PesqUsuario_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmPesqCliente Clie = new FrmPesqCliente(4, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbConsumidor.Items.Clear();
                        if (bllOrcamento.Sel_Cliente_Orc() == null)
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
                            foreach (DataRow dr in bllOrcamento.Sel_Cliente_Orc().Rows)
                            {
                                cbbConsumidor.Items.Add((dr["id_cliente"].ToString()) + "—" + (dr["nome"].ToString()));
                            }
                        }
                        cbbConsumidor.Text = bllOrcamento._Orc_PesqConsumidor_Tabela;
                        bllOrcamento._Orc_PesqConsumidor_Tabela = null;
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
                        bllOrcamento._Orc_PesqConsumidor_Tabela = null;
                    }
                }
            }
            pEnabled.Enabled = true;
        }

        private void mtxtHorarioVal_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioVal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioVal.Text == "")
            {
                mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioVal.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioVal1.Select();
            }
        }

        private void mtxtHorarioVal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioVal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioVal.Text == "")
                {
                    mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioVal.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioVal_Enter(object sender, EventArgs e)
        {
            mtxtHorarioVal.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioVal_Leave(object sender, EventArgs e)
        {
            mtxtHorarioVal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioVal.Text != "")
            {
                if (mtxtHorarioVal.Text.Length == 4)
                {
                    mtxtHorarioVal.Text = mtxtHorarioVal.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioVal.Text);

                    mtxtHorarioVal1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtHorarioVal1.Text != "")
                    {
                        mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtHorarioVal.Text) > Convert.ToDateTime(mtxtHorarioVal1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtHorarioVal.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioVal.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioVal.");
                    }
                    mtxtHorarioVal.Text = null;
                }
            }
            mtxtHorarioVal.BackColor = Color.White;
        }

        private void mtxtHorarioVal1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioVal1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioVal1.Text == "")
            {
                mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioVal1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioVal1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbUsuario.Select();
            }
        }

        private void mtxtHorarioVal1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioVal1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioVal1.Text == "")
                {
                    mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioVal1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioVal1_Enter(object sender, EventArgs e)
        {
            mtxtHorarioVal1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioVal1_Leave(object sender, EventArgs e)
        {
            mtxtHorarioVal1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioVal1.Text != "")
            {
                if (mtxtHorarioVal1.Text.Length == 4)
                {
                    mtxtHorarioVal1.Text = mtxtHorarioVal1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioVal1.Text);

                    mtxtHorarioVal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtHorarioVal.Text != "")
                    {
                        mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtHorarioVal1.Text) < Convert.ToDateTime(mtxtHorarioVal.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtHorarioVal1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario1.");
                    }
                    mtxtHorarioVal1.Text = null;
                }
            }
            mtxtHorarioVal1.BackColor = Color.White;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnCodigo.Checked == true)
                {
                    if (txtpCodigo.Text.Trim() != "")
                    {
                        if (bllOrcamento.Sel_Orcamento_Codigo(txtpCodigo.Text.Trim()) == null)
                        {
                            dtOrc.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtOrc.DataSource = bllOrcamento.Sel_Orcamento_Codigo(txtpCodigo.Text.Trim());
                            dtOrc.Select();
                        }
                    }
                }
                else if (rbtnTodos.Checked == true)
                {
                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtpDataVal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtpDataVal1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    mtxtHorarioVal.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtHorarioVal1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpData.Select();
                    }
                    else if ((mtxtpDataVal.Text == "" & mtxtpDataVal1.Text != "") || (mtxtpDataVal.Text != "" & mtxtpDataVal1.Text == ""))
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Data de Validade ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpData.Select();
                    }
                    else if ((mtxtHorario.Text == "" & mtxtHorario1.Text != "") || (mtxtHorario.Text != "" & mtxtHorario1.Text == ""))
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Horário ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpData.Select();
                    }
                    else if ((mtxtHorarioVal.Text == "" & mtxtHorarioVal1.Text != "") || (mtxtHorarioVal.Text != "" & mtxtHorarioVal1.Text == ""))
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        MessageBox.Show("É necessário preencher ambos os campos de [ Horário de Validade ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtpData.Select();
                    }
                    else
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (bllOrcamento.Sel_DataCad_DataVal_Usuario_Consumidor_Orc_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtpDataVal.Text, mtxtpDataVal1.Text, cbbUsuario.Text, cbbConsumidor.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbSituacao.Text, mtxtHorarioVal.Text, mtxtHorarioVal1.Text, cbbCodPDV.Text) == null)
                        {
                            dtOrc.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                        }
                        else
                        {
                            dtOrc.DataSource = bllOrcamento.Sel_DataCad_DataVal_Usuario_Consumidor_Orc_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtpDataVal.Text, mtxtpDataVal1.Text, cbbUsuario.Text, cbbConsumidor.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbSituacao.Text, mtxtHorarioVal.Text, mtxtHorarioVal1.Text, cbbCodPDV.Text);
                            dtOrc.Select();
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
                dtOrc.DataSource = null;
                rbtnCodigo.Checked = true;
            }
        }

        private void dtOrc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtOrc.Columns[0].HeaderText = "Código";
            dtOrc.Columns[1].HeaderText = "Cód. do Consumidor";
            dtOrc.Columns[2].HeaderText = "Nome do Consumidor";
            dtOrc.Columns[3].HeaderText = "CPF/CNPJ do Consumidor";
            dtOrc.Columns[4].HeaderText = "Valor (R$)";
            dtOrc.Columns[5].HeaderText = "Desconto -(%)";
            dtOrc.Columns[6].HeaderText = "Valor do Desconto (R$)";
            dtOrc.Columns[7].HeaderText = "Acréscimo -(%)";
            dtOrc.Columns[8].HeaderText = "Valor do Acréscimo (R$)";
            dtOrc.Columns[9].HeaderText = "Valor do Desconto (R$)";
            dtOrc.Columns[10].HeaderText = "Valor do Acréscimo (R$)";
            dtOrc.Columns[11].HeaderText = "Valor Real (R$)";
            dtOrc.Columns[12].HeaderText = "Data";
            dtOrc.Columns[13].HeaderText = "Horário";
            dtOrc.Columns[14].HeaderText = "Data de Validade";
            dtOrc.Columns[15].HeaderText = "Horário de Validade";
            dtOrc.Columns[16].HeaderText = "Cód. do Usuário";
            dtOrc.Columns[17].HeaderText = "Nome do Usuário";
            dtOrc.Columns[18].HeaderText = "Cód. do PDV/Computador";
            dtOrc.Columns[19].HeaderText = "Observações";
            dtOrc.Columns[20].HeaderText = "Situação";
            dtOrc.Columns[21].HeaderText = "Cód. da Venda";

            dtOrc.DefaultCellStyle.Font = new System.Drawing.Font(dtOrc.Font, FontStyle.Bold);

            dtOrc.Columns[0].Width = 95;
            dtOrc.Columns[1].Width = 130;
            dtOrc.Columns[2].Width = 325;
            dtOrc.Columns[3].Width = 185;
            dtOrc.Columns[4].Width = 115;
            dtOrc.Columns[5].Width = 115;
            dtOrc.Columns[6].Width = 150;
            dtOrc.Columns[7].Width = 115;
            dtOrc.Columns[8].Width = 150;
            dtOrc.Columns[9].Width = 170;
            dtOrc.Columns[10].Width = 170;
            dtOrc.Columns[11].Width = 115;
            dtOrc.Columns[12].Width = 85;
            dtOrc.Columns[13].Width = 85;
            dtOrc.Columns[14].Width = 125;
            dtOrc.Columns[15].Width = 150;
            dtOrc.Columns[16].Width = 115;
            dtOrc.Columns[17].Width = 150;
            dtOrc.Columns[18].Width = 170;
            dtOrc.Columns[19].Width = 500;
            dtOrc.Columns[20].Width = 125;
            dtOrc.Columns[21].Width = 115;

            dtOrc.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtOrc.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            lblRegistros.Text = "Registros: " + dtOrc.Rows.Count;
            //
            decimal valortotal = 0;
            for (int i = 0; i < dtOrc.Rows.Count; i++)
            {
                valortotal += Convert.ToDecimal(dtOrc.Rows[i].Cells[4].Value);
            }
            lblValorTotal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valortotalreal = 0;
            for (int i = 0; i < dtOrc.Rows.Count; i++)
            {
                valortotalreal += Convert.ToDecimal(dtOrc.Rows[i].Cells[11].Value);
            }
            lblValorTotalReal.Text = Convert.ToDecimal(valortotalreal).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valoracrescimos = 0;
            for (int i = 0; i < dtOrc.Rows.Count; i++)
            {
                valoracrescimos += Convert.ToDecimal(dtOrc.Rows[i].Cells[8].Value);
            }
            lblValorAcrescimos.Text = Convert.ToDecimal(valoracrescimos).ToString("n2", new CultureInfo("pt-BR"));
            //
            decimal valordescontos= 0;
            for (int i = 0; i < dtOrc.Rows.Count; i++)
            {
                valordescontos += Convert.ToDecimal(dtOrc.Rows[i].Cells[8].Value);
            }
            lblValorDescontos.Text = Convert.ToDecimal(valordescontos).ToString("n2", new CultureInfo("pt-BR"));
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dtOrc_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
            lblValorTotal.Text = null;
            lblValorTotalReal.Text = null;
            lblValorAcrescimos.Text = null;
            lblValorDescontos.Text = null;
        }

        private void dtOrc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 12 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 14 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 21 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void dtOrc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtOrc.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOrc.Columns[4].DefaultCellStyle.Format = "n2";
            dtOrc.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOrc.Columns[5].DefaultCellStyle.Format = "n2";
            dtOrc.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOrc.Columns[6].DefaultCellStyle.Format = "n2";
            dtOrc.Columns[7].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOrc.Columns[7].DefaultCellStyle.Format = "n2";
            dtOrc.Columns[8].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOrc.Columns[8].DefaultCellStyle.Format = "n2";
            dtOrc.Columns[9].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOrc.Columns[9].DefaultCellStyle.Format = "n2";
            dtOrc.Columns[10].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOrc.Columns[10].DefaultCellStyle.Format = "n2";
            dtOrc.Columns[11].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtOrc.Columns[11].DefaultCellStyle.Format = "n2";

            dtOrc.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtOrc.DefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewRow SelectedRow = dtOrc.Rows[dtOrc.CurrentRow.Index];
            //
            if (SelectedRow.Cells[20].Value.ToString() == "PENDENTE")
            {
                lblValorSituacao.Text = "PENDENTE";
                lblValorSituacao.ForeColor = Color.Red;
                pcibCross.Visible = true;
                pcibTick.Visible = false;
            }
            else if (SelectedRow.Cells[20].Value.ToString() == "REALIZADO")
            {
                lblValorSituacao.Text = "REALIZADO";
                lblValorSituacao.ForeColor = Color.Green;
                pcibCross.Visible = false;
                pcibTick.Visible = true;
            }
        }

        private void dtOrc_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtOrc.DataSource == null)
            {
                dtOrc.Enabled = false;
                grbBox2.Enabled = false;
                lblTotal.Enabled = false;
                lblValorTotal.Enabled = false;
                lblTotalReal.Enabled = false;
                lblValorTotalReal.Enabled = false;
                pcibCross.Visible = false;
                pcibTick.Visible = false;
                lblValorSituacao.ForeColor = Color.White;
                lblValorSituacao.Text = "Situação";
                lblValorSituacao.Visible = false;               
                lblValorAcrescimos.Enabled = false;
                lblValorDescontos.Enabled = false;
                lblDescontos.Enabled = false;
                lblAcrescimos.Enabled = false;
            }
            else
            {
                dtOrc.Enabled = true;
                grbBox2.Enabled = true;
                lblTotal.Enabled = true;
                lblValorTotal.Enabled = true;
                lblTotalReal.Enabled = true;
                lblValorTotalReal.Enabled = true;
                lblValorSituacao.Visible = true;
                lblValorAcrescimos.Enabled = true;
                lblValorDescontos.Enabled = true;
                lblDescontos.Enabled = true;
                lblAcrescimos.Enabled = true;
            }
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + Convert.ToDecimal(lblValorTotal.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblValorTotalReal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Real (R$): " + Convert.ToDecimal(lblValorTotalReal.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por código, todos e/ou outros filtros.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRelatorioPDF_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRelatorioPDF_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnGerarCupom_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnGerarCupom_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarItens_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConsultarItens_MouseLeave(object sender, EventArgs e)
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

        private void btnCancelarDevolucao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCancelarDevolucao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnExcluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnExcluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConsultarItens_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtOrc.Rows[dtOrc.CurrentRow.Index];

                pEnabled.Enabled = false;
                using (FrmConsultarItem Item = new FrmConsultarItem(SelectedRow.Cells[0].Value.ToString(), 3))
                {
                    if (Item.ShowDialog() == DialogResult.Abort)
                    {
                        dtOrc.Select();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnConsultarItens.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtOrc.Rows[dtOrc.CurrentRow.Index];
                //
                if (bllOrcamento.Sel_Orcamento_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível excluir este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtOrc.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja excluir este Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;

                        bllOrcamento.Excluir_Item_Orcamento(SelectedRow.Cells[0].Value.ToString());
                        //
                        bllOrcamento.Excluir(SelectedRow.Cells[0].Value.ToString());
                        //
                        bllRegistroAtividades.Salvar("EXCLUIU UM ORCAMENTO", "ORCAMENTO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Orçamento excluída. Cod: " + SelectedRow.Cells[0].Value.ToString());
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Orçamento excluída. Cod: " + SelectedRow.Cells[0].Value.ToString());
                        }
                        //
                        if (rbtnTodos.Checked == true)
                        {
                            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                            if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                            {
                                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.DialogResult = DialogResult.None;
                                mtxtpData.Select();
                                return;
                            }
                            else
                            {
                                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                mtxtpDataVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtpDataVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                mtxtHorarioVal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                                mtxtHorarioVal1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                                if (bllOrcamento.Sel_DataCad_DataVal_Usuario_Consumidor_Orc_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtpDataVal.Text, mtxtpDataVal1.Text, cbbUsuario.Text, cbbConsumidor.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbSituacao.Text, mtxtHorarioVal.Text, mtxtHorarioVal1.Text, cbbCodPDV.Text) == null)
                                {
                                    dtOrc.DataSource = null;
                                }
                                else
                                {
                                    dtOrc.DataSource = bllOrcamento.Sel_DataCad_DataVal_Usuario_Consumidor_Orc_Todos(mtxtpData.Text, mtxtpData1.Text, mtxtpDataVal.Text, mtxtpDataVal1.Text, cbbUsuario.Text, cbbConsumidor.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbSituacao.Text, mtxtHorarioVal.Text, mtxtHorarioVal1.Text, cbbCodPDV.Text);
                                    dtOrc.Select();
                                }
                            }
                        }
                        else
                        {
                            dtOrc.DataSource = null;
                        }
                        //
                        MessageBox.Show("Dados excluídos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //
                        this.DialogResult = DialogResult.None;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnExcluir.");
                }
            }
        }

        private void bckwIndeterminado_DoWork(object sender, DoWorkEventArgs e)
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
                    short Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    short Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_PDF_A4_Adm(bllConexao._Codigo_Conexao);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    //
                    graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, 5 + Margem_Topo, 485, 122);
                    //
                    if (bllOrcamento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
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
                    textFormatter1.DrawString("Relatório de Orçamento", fonte3, XBrushes.Black, new XRect(0 + Margem_Esq, 122 + Margem_Topo, page.Width, page.Height));
                    //
                    graphics.DrawRectangle(pen, XBrushes.LightBlue, 5 + Margem_Esq, 174 + Margem_Topo, 584, 26);
                    textFormatter2.DrawString("CÓDIGO   DATA   HORÁRIO   CONSUMIDOR   DATA DE VALIDADE    VALOR(R$)   VALOR REAL(R$)", fonte1, XBrushes.Black, new XRect(7 + Margem_Esq, 180 + Margem_Topo, page.Width, page.Height));
                    //           
                    //Linhas do datagrid
                    int Incrementar = 0;//Para egistro do datagrid ele conta uma quantidade de numeros (57) para escrever o proximo registro no pdf
                    int ContadorPagina = 1;
                    int pagina = 16;
                    bool PrimeiraPagina = true;

                    int TotalPaginas = 1;//Numero de páginas do documento.
                    int registros = 37;
                    for (int i = 0; i < dtOrc.Rows.Count; i++)
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
                    for (int linha = 0; linha < dtOrc.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtOrc.Rows[linha];
                        if (linha < 16 & PrimeiraPagina == true)
                        {
                            if (linha == dtOrc.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte4, XBrushes.Black, new XRect(126 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(225 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(281 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data de Validade:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(84 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(260 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(309 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor Real (R$):", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 236) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Valor Total (R$): " + lblValorTotal.Text + "                                                                                                              Valor Real Total (R$): " + lblValorTotalReal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 239) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando                               
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 200) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 207) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte4, XBrushes.Black, new XRect(126 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(225 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(281 + Margem_Esq, (Incrementar + 207) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data de Validade:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(84 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(260 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(309 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor Real (R$):", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 219) + Margem_Topo, page.Width, page.Height));      //
                                //
                                Incrementar = 36 + Incrementar;//incrementando                 
                            }
                            //
                            if (linha == (pagina - 1) & dtOrc.Rows.Count > 15)
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
                                textFormatter1.DrawString("Relatório de Orçamento", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
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
                                textFormatter1.DrawString("Relatório de Orçamento", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 7 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Sistema SEVEN", fonte2, XBrushes.Black, new XRect(13 + Margem_Esq, 820 + Margem_Topo, page.Width, page.Height));
                                textFormatter1.DrawString("Páginas: " + ContadorPagina + " de " + TotalPaginas, fonte4, XBrushes.Black, new XRect(7 + Margem_Esq, 800 + Margem_Topo, page.Width, page.Height));
                            }
                            //
                            if (linha == dtOrc.Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte4, XBrushes.Black, new XRect(126 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(225 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(281 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data de Validade:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(84 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(260 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(309 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor Real (R$):", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 58) + Margem_Topo, 584, 18);
                                textFormatter2.DrawString("Valor Total (R$): " + lblValorTotal.Text + "                                                                                                              Valor Real Total (R$): " + lblValorTotalReal.Text, fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 61) + Margem_Topo, page.Width, page.Height));
                                //
                                Incrementar = 36 + Incrementar;//incrementando       
                            }
                            else
                            {
                                graphics.DrawRectangle(pen, XBrushes.White, 5 + Margem_Esq, (Incrementar + 22) + Margem_Topo, 584, 36);
                                textFormatter2.DrawString("Código:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[0].Value.ToString(), fonte4, XBrushes.Black, new XRect(42 + Margem_Esq, (Incrementar + 29) + Margem_Topo, 75, 18));
                                //
                                textFormatter2.DrawString("Data:", fonte2, XBrushes.Black, new XRect(100 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[12].Value.ToString(), fonte4, XBrushes.Black, new XRect(126 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Consumidor:", fonte2, XBrushes.Black, new XRect(225 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                if (SelectedRow.Cells[1].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString(SelectedRow.Cells[1].Value.ToString() + "-" + SelectedRow.Cells[2].Value.ToString(), fonte4, XBrushes.Black, new XRect(281 + Margem_Esq, (Incrementar + 29) + Margem_Topo, page.Width, page.Height));
                                }
                                //
                                textFormatter2.DrawString("Data de Validade:", fonte2, XBrushes.Black, new XRect(7 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(SelectedRow.Cells[14].Value.ToString(), fonte4, XBrushes.Black, new XRect(84 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor (R$):", fonte2, XBrushes.Black, new XRect(260 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(309 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                //
                                textFormatter2.DrawString("Valor Real (R$):", fonte2, XBrushes.Black, new XRect(448 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
                                textFormatter2.DrawString(Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte4, XBrushes.Black, new XRect(519 + Margem_Esq, (Incrementar + 41) + Margem_Topo, page.Width, page.Height));
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
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos");
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamentos.pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamentos.pdf");
                    }
                }
            }
            if (_Trabalho == 1)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamento.csv"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamento.csv");
                }
                //
                using (StreamWriter Sw = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamento.csv", false, Encoding.Default))
                {
                    StringBuilder Sb = new StringBuilder();
                    Sb.AppendLine("Código;Cód. do Consumidor;Nome do Consumidor;CPF/CNPJ do Consumidor;Valor (R$);Desconto -(%);Valor do Desconto (R$);Acréscimo +(%);Valor do Acréscimo (R$);Valor do Desconto (R$);Valor do Acréscimo (R$);Valor Real (R$);Data;Horário;Data de Validade;Horário de Validade;Cód. do Usuário;Nome do Usuario;Cód. do PDV/Computador;Observações;Situação;Cód. da Venda");
                    for (int linha = 0; linha < dtOrc.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtOrc.Rows[linha];
                        //
                        string cod_consumidor = "";
                        if (SelectedRow.Cells[1].Value.ToString() == "0")
                        {
                            cod_consumidor = "";
                        }
                        else
                        {
                            cod_consumidor = SelectedRow.Cells[1].Value.ToString();
                        }
                        //
                        string cod_venda;
                        if (SelectedRow.Cells[21].Value.ToString() == "0")
                        {
                            cod_venda = "";
                        }
                        else
                        {
                            cod_venda = SelectedRow.Cells[21].Value.ToString();
                        }
                        //
                        string data_validade;
                        if (SelectedRow.Cells[14].Value.ToString() == "")
                        {
                            data_validade = "";
                        }
                        else
                        {
                            data_validade = SelectedRow.Cells[14].Value.ToString();
                        }
                        Sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21}", SelectedRow.Cells[0].Value.ToString(), cod_consumidor, SelectedRow.Cells[2].Value.ToString(), SelectedRow.Cells[3].Value.ToString(), Convert.ToDecimal(SelectedRow.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")), Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), SelectedRow.Cells[12].Value.ToString().Remove(10), SelectedRow.Cells[13].Value.ToString(), data_validade, SelectedRow.Cells[15].Value.ToString(), SelectedRow.Cells[16].Value.ToString(), SelectedRow.Cells[17].Value.ToString(), SelectedRow.Cells[18].Value.ToString(), SelectedRow.Cells[19].Value.ToString(), SelectedRow.Cells[20].Value.ToString(), cod_venda));
                    }
                    Sw.Write(Sb.ToString());
                    Sw.WriteLine("Relatório de Orçamento");
                    Sw.WriteLine("Data: " + DateTime.Now.ToShortDateString());
                    Sw.WriteLine("Horário: " + DateTime.Now.ToLongTimeString());
                    Sw.WriteLine("Valor Total (R$): " + lblValorTotal.Text);
                    Sw.WriteLine("Valor Real (R$): " + lblValorTotalReal.Text);
                }
                //
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamento.csv");
            }
            else if (_Trabalho == 2)
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos");
                }
                //
                if (!File.Exists(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamento.txt"))
                {
                    File.Delete(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamento.txt");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamento.txt"))
                {
                    writer.WriteLine("Relatório de Orçamento" + Environment.NewLine + "Data: " + DateTime.Now.ToShortDateString() + ", Horário: " + DateTime.Now.ToLongTimeString());
                    for (int linha = 0; linha < dtOrc.Rows.Count; linha++)
                    {
                        DataGridViewRow SelectedRow = dtOrc.Rows[linha];
                        //
                        string cod_consumidor;
                        if (SelectedRow.Cells[1].Value.ToString() == "0")
                        {
                            cod_consumidor = "";
                        }
                        else
                        {
                            cod_consumidor = SelectedRow.Cells[1].Value.ToString();
                        }
                        //
                        string cod_venda;
                        if (SelectedRow.Cells[21].Value.ToString() == "0")
                        {
                            cod_venda = "";
                        }
                        else
                        {
                            cod_venda = SelectedRow.Cells[21].Value.ToString();
                        }
                        //
                        string data_validade;
                        if (SelectedRow.Cells[14].Value.ToString() == "")
                        {
                            data_validade = "";
                        }
                        else
                        {
                            data_validade = SelectedRow.Cells[14].Value.ToString();
                        }
                        //
                        writer.WriteLine(@"|Código: " + SelectedRow.Cells[0].Value.ToString() + " |Cód. do Consumidor: " + cod_consumidor + " |Nome do Consumidor: " + SelectedRow.Cells[2].Value.ToString() + " |CPF/CNPJ do Consumidor: " + SelectedRow.Cells[3].Value.ToString() + " |Valor (R$): " + Convert.ToDecimal(SelectedRow.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Desconto -(%): " + Convert.ToDecimal(SelectedRow.Cells[5].Value).ToString("n2", new CultureInfo("pt-BR")) + " | Valor do Desconto (R$): " + Convert.ToDecimal(SelectedRow.Cells[6].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Acréscimo (%): " + Convert.ToDecimal(SelectedRow.Cells[7].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor do Acréscimo (R$): " + Convert.ToDecimal(SelectedRow.Cells[8].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor do Desconto Item (R$): " + Convert.ToDecimal(SelectedRow.Cells[9].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor do Acréscimo Item (R$): " + Convert.ToDecimal(SelectedRow.Cells[10].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Valor Real (R$): " + Convert.ToDecimal(SelectedRow.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")) + " |Data: " + SelectedRow.Cells[12].Value.ToString().Remove(10) + " | Horário: " + SelectedRow.Cells[13].Value.ToString() + " |Data de Validade: " + data_validade + " |Horário de Validade: " + SelectedRow.Cells[15].Value.ToString() + " |Cód. do Usuário: " + SelectedRow.Cells[16].Value.ToString() + " |Nome do Usuário: " + SelectedRow.Cells[17].Value.ToString() + " |Cód. do PDV/Computador: " + SelectedRow.Cells[18].Value.ToString() + " |Observações: " + SelectedRow.Cells[19].Value.ToString() + "| Situação: " + SelectedRow.Cells[20].Value.ToString() + "| Cód. da Venda: " + cod_venda);
                    }
                    writer.WriteLine("Valor Total (R$): " + lblValorTotal.Text);
                    writer.WriteLine("Valor Real (R$): " + lblValorTotalReal.Text);
                }
                Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamento.txt");
            }
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                dtOrc.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao2.Enabled = true;
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
                dtOrc.Enabled = true;
                grbBox1.Enabled = true;
                grbBox2.Enabled = true;
                btnPesquisar.Enabled = true;
                picbInterrogacao2.Enabled = true;
                picbInterrogacao.Enabled = true;
                dtOrc.Select();
                //
                try
                {
                    DataGridViewRow SelectedRow = dtOrc.Rows[dtOrc.CurrentRow.Index];

                    if (_Trabalho == 0)
                    {
                        Process.Start(@"C:\Sistema SEVEN\Relatorios\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Orcamentos\Orcamentos.pdf");
                    }
                    else if (_Trabalho == 3)
                    {
                        string mes;
                        if (Convert.ToDateTime(SelectedRow.Cells[12].Value).Month < 10)
                        {
                            mes = "0" + Convert.ToDateTime(SelectedRow.Cells[12].Value).Month;
                        }
                        else
                        {
                            mes = Convert.ToDateTime(SelectedRow.Cells[12].Value).Month.ToString();
                        }
                        //
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRow.Cells[12].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
                    }
                    else if (_Trabalho == 4 || _Trabalho == 5)
                    {
                        string mes;
                        if (Convert.ToDateTime(SelectedRow.Cells[12].Value).Month < 10)
                        {
                            mes = "0" + Convert.ToDateTime(SelectedRow.Cells[12].Value).Month;
                        }
                        else
                        {
                            mes = Convert.ToDateTime(SelectedRow.Cells[12].Value).Month.ToString();
                        }
                        //
                        Process.Start(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRow.Cells[12].Value).Year + mes + @"\" + SelectedRow.Cells[0].Value.ToString() + ".pdf");
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
                    dtOrc.Enabled = true;
                    grbBox1.Enabled = true;
                    grbBox2.Enabled = true;
                    btnPesquisar.Enabled = true;
                    picbInterrogacao2.Enabled = true;
                    picbInterrogacao.Enabled = true;
                    btnSair.Enabled = true;
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
            dtOrc.Enabled = false;
            dtOrc.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao2.Enabled = false;
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
            dtOrc.Enabled = false;
            dtOrc.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
            grbBox1.Enabled = false;
            grbBox2.Enabled = false;
            btnPesquisar.Enabled = false;
            picbInterrogacao.Enabled = false;
            picbInterrogacao.Enabled = false;
        }

        private void btnCancelarDevolucao_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtOrc.Rows[dtOrc.CurrentRow.Index];
                //
                if (bllOrcamento.Sel_Orcamento_Ainda_Existe(SelectedRow.Cells[0].Value.ToString()) == false)
                {
                    MessageBox.Show("Não é possível cancelar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtOrc.Select();
                }
                else if (bllOrcamento.Sel_Situacao_Orcamento(SelectedRow.Cells[0].Value.ToString(), "CANCELADO") == true)
                {
                    MessageBox.Show("Não é possível cancelar um Orçamento que já foi cancelada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtOrc.Select();
                }
                else if (bllOrcamento.Sel_Situacao_Orcamento(SelectedRow.Cells[0].Value.ToString(), "PENDENTE") == true)
                {
                    MessageBox.Show("Não é possível cancelar um Orçamento pendente, é necessário excluir este registro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    dtOrc.Select();
                }
                else
                {
                    DialogResult = MessageBox.Show("Deseja cancelar este Orçamento?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.None;
                        bllOrcamento.Alterar_Situacao_Orcamento(SelectedRow.Cells[0].Value.ToString(), "CANCELADO");
                        //               
                        bllRegistroAtividades.Salvar("CANCELAMENTO DE ORCAMENTO", "ORCAMENTO", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //
                        MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //
                        this.DialogResult = DialogResult.None;
                        //
                        dtOrc.DataSource = bllOrcamento.Sel_Orcamento_Codigo(SelectedRow.Cells[0].Value.ToString());
                        dtOrc.Select();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                        dtOrc.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCancelarOrcamento");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnCancelarOrcamento.");
                }
            }
        }

        private void btnRelatorioPDF_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(19))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    _Trabalho = 0;
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    grbBox1.Enabled = false;
                    dtOrc.Enabled = false;
                    dtOrc.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox2.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Relatório em PDF: Clique para imprimir o relatório em PDF.\n\n2 - Exp. dados para (.csv): Clique para gerar em arquivo excel o relatório.\n\n3 - Exp. dados para (.txt): Clique para gerar em arquivo texto o relatório.\n\n4 - Consultar Itens: Clique para visualizar o(s) item(ns) do orçamento.\n\n5 - Cupom do Orçamento: Clique para imprimir o cupom do registro selecionado.\n\n6 - Cancelar Orçamento: Clique para cancelar o orçamento já realizado.\n\n7 - Excluir Orçamento: Clique para excluir o orçamento pendente já realizado.\n\n8 - Cupom do Orçamento: Clique para imprimir o cupom do orçamento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dtOrc_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtOrc.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtOrc_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void Gerar_PDF()
        {
            if (_Trabalho == 3)
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                    byte pessoa;
                    //
                    nome = drPDF["nome"].ToString();
                    fantasia = drPDF["fantasia"].ToString();
                    cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                    ie_rg = drPDF["ie_rg"].ToString();
                    endereco = drPDF["endereco"].ToString();
                    numero = drPDF["numero"].ToString();
                    bairro = drPDF["bairro"].ToString();
                    cidade = drPDF["cidade"].ToString();
                    uf = drPDF["uf"].ToString();
                    cep = drPDF["cep"].ToString();
                    pessoa = Convert.ToByte(drPDF["pessoa"]);
                    //
                    var page = doc.AddPage();
                    //
                    page.Width = 595;
                    page.Height = 842;
                    //
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var textFormatter4 = new XTextFormatter(graphics);
                    //
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 12);
                    var fonte3 = new XFont("Microsoft Sans Serif", 11);
                    var fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                    //
                    bool PrimeiraPagina = true;
                    int registros;
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    //                   
                    if (bllOrcamento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        Margem_Topo = Margem_Topo + 5;
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 280 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                        registros = 16;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                        registros = 18;
                    }
                    //
                    textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 595, 13));
                    //
                    textFormatter1.DrawString(fantasia, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 98 + Margem_Topo, 595, 13));
                    //
                    if (pessoa == 1)
                    {
                        textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 111 + Margem_Topo, 595, 13));
                    }
                    else
                    {
                        textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 111 + Margem_Topo, 595, 13));
                    }
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 124 + Margem_Topo, 595, 45);
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 124 + Margem_Topo, 595, 45));
                    //
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 160 + Margem_Topo, 595, 24));
                    textFormatter1.DrawString("ORÇAMENTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 169 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 175 + Margem_Topo, 595, 24));
                    //
                    textFormatter2.DrawString(" #       Código               Descrição                                                               Qtde.        UN.        Vl.Unit        Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 185 + Margem_Topo, 595, 13));
                    //
                    int Incrementar = 0;
                    //
                    DataGridViewRow SelectedRows = dtOrc.Rows[dtOrc.CurrentRow.Index];
                    //
                    for (int i = 0; i < bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count; i++)
                    {
                        DataRow dr = bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows[i];
                        //
                        if (PrimeiraPagina == true)
                        {
                            if (i == bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "                      " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 203 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 203 + Margem_Topo, 100, 13));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 216 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[4].Value.ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 216 + Margem_Topo, 100, 13));
                                //
                                if (SelectedRows.Cells[6].Value.ToString() != "0" || SelectedRows.Cells[9].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 198, 13));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(SelectedRows.Cells[6].Value.ToString()) + Convert.ToDecimal(SelectedRows.Cells[9].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 229 + Margem_Topo, 100, 13));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                if (SelectedRows.Cells[8].Value.ToString() != "0" || SelectedRows.Cells[10].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(SelectedRows.Cells[8].Value.ToString()) + Convert.ToDecimal(SelectedRows.Cells[10].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 229 + Margem_Topo, 100, 8));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                textFormatter2.DrawString("Valor Total Real R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 229 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 229 + Margem_Topo, 100, 13));
                                //
                                if (SelectedRows.Cells[3].Value.ToString() != "")
                                {
                                    textFormatter1.DrawString(SelectedRows.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                //
                                textFormatter1.DrawString("Orçamento nº: " + SelectedRows.Cells[0].Value.ToString() + "  " + SelectedRows.Cells[12].Value.ToString().Remove(10) + "  " + SelectedRows.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 595, 13));
                                //
                                if (SelectedRows.Cells[14].Value.ToString() != null & SelectedRows.Cells[14].Value.ToString() != "")
                                {
                                    Incrementar = Incrementar + 13;
                                    textFormatter1.DrawString("Data e Hora de Validade: " + SelectedRows.Cells[14].Value.ToString().Remove(10) + "  " + SelectedRows.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 242 + Margem_Topo, 595, 13));
                                }
                                //
                                textFormatter1.DrawString("NÃO É VÁLIDO COMO COMPROVANTE\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 255 + Margem_Topo, 595, 28));
                                //
                                textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 281 + Margem_Topo, 585, 11));
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 198 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "                      " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                            }
                            //
                            if (i == registros - 5 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 4 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 3 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 2 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 1 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                        else
                        {
                            if (i == bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 38 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "                      " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 38 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 43 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 43 + Margem_Topo, 100, 13));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 56 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 56 + Margem_Topo, 100, 13));
                                //
                                if (SelectedRows.Cells[6].Value.ToString() != "0" || SelectedRows.Cells[9].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 198, 13));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(SelectedRows.Cells[6].Value) + Convert.ToDecimal(SelectedRows.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 69 + Margem_Topo, 100, 13));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                if (SelectedRows.Cells[8].Value.ToString() != "0" || SelectedRows.Cells[10].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(SelectedRows.Cells[8].Value) + Convert.ToDecimal(SelectedRows.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 69 + Margem_Topo, 100, 8));
                                    Incrementar = Incrementar + 13;
                                }
                                //
                                textFormatter2.DrawString("Valor Total Real R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 69 + Margem_Topo, 198, 13));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 69 + Margem_Topo, 100, 13));
                                //
                                //
                                if (SelectedRows.Cells[3].Value.ToString() != "")
                                {
                                    textFormatter1.DrawString(SelectedRows.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 595, 12));
                                    Incrementar = Incrementar + 12;
                                }
                                //
                                textFormatter1.DrawString("Orçamento nº: " + SelectedRows.Cells[0].Value.ToString() + "   " + SelectedRows.Cells[12].Value.ToString().Remove(10) + "   " + SelectedRows.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 595, 13));
                                //
                                if (SelectedRows.Cells[14].Value.ToString() != null & SelectedRows.Cells[14].Value.ToString() != "")
                                {
                                    Incrementar = Incrementar + 13;
                                    textFormatter1.DrawString("Data e Hora de Validade: " + SelectedRows.Cells[14].Value.ToString().Remove(10) + "  " + SelectedRows.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 82 + Margem_Topo, 595, 13));
                                }
                                textFormatter1.DrawString("NÃO É VÁLIDO COMO COMPROVANTE\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 95 + Margem_Topo, 595, 28));
                                //
                                textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 121 + Margem_Topo, 585, 11));
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 38 + Margem_Topo, 198, 7));
                                //  
                                //graphics.DrawRectangle(pen, 35 + Margem_Esq, Incrementar + 198 + Margem_Topo, 595, 13);
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "                      " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(35 + Margem_Esq, Incrementar + 38 + Margem_Topo, 595, 13));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //textFormatter1.DrawString("000.000,00", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 100, 13));
                                //
                                //graphics.DrawRectangle(pen, 195 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(195 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //
                                //graphics.DrawRectangle(pen, 490 + Margem_Esq, 211 + Margem_Topo, 100, 13);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 13;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                //graphics.DrawRectangle(pen, 217 + Margem_Esq, Incrementar + 211 + Margem_Topo, 200, 13);
                                textFormatter1.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(217 + Margem_Esq, Incrementar + 51 + Margem_Topo, 200, 13));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(490 + Margem_Esq, Incrementar + 51 + Margem_Topo, 100, 13));
                                //
                                Incrementar = Incrementar + 26;
                            }
                            //
                            if (i == registros - 5 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 4 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 3 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 2 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (i == registros - 1 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 595;
                                page.Height = 842;
                                registros = registros + 21;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                                fonte2 = new XFont("Microsoft Sans Serif", 12);
                                fonte3 = new XFont("Microsoft Sans Serif", 11);
                                fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
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
                    string mes;
                    if (Convert.ToDateTime(SelectedRows.Cells[12].Value).Month < 10)
                    {
                        mes = "0" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Month;
                    }
                    else
                    {
                        mes = Convert.ToDateTime(SelectedRows.Cells[12].Value).Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes + @"\" + SelectedRows.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes + @"\" + SelectedRows.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
            else if (_Trabalho == 4)
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                    byte pessoa;
                    //
                    nome = drPDF["nome"].ToString();
                    fantasia = drPDF["fantasia"].ToString();
                    cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                    ie_rg = drPDF["ie_rg"].ToString();
                    endereco = drPDF["endereco"].ToString();
                    numero = drPDF["numero"].ToString();
                    bairro = drPDF["bairro"].ToString();
                    cidade = drPDF["cidade"].ToString();
                    uf = drPDF["uf"].ToString();
                    cep = drPDF["cep"].ToString();
                    pessoa = Convert.ToByte(drPDF["pessoa"]);
                    //
                    var page = doc.AddPage();
                    //
                    page.Width = 203;
                    page.Height = 842;
                    //                       
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var textFormatter4 = new XTextFormatter(graphics);
                    //
                    var fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                    var fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                    var fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                    var fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    int Incrementar = 0;
                    bool PrimeiraPagina = true;
                    int registros;

                    //
                    if (bllOrcamento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                        registros = 32;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                        registros = 34;
                    }
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 85 + Margem_Topo, 198, 16);
                    if (nome.Length > 30)
                    {
                        if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                        {
                            textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 9;
                    }
                    else
                    {
                        textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 10));
                    }
                    //
                    if (fantasia.Length > 30)
                    {
                        if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                        {
                            textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 94 + Margem_Topo, 198, 21));
                        }
                        else
                        {
                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 94 + Margem_Topo, 198, 21));
                        }
                        Incrementar = Incrementar + 9;
                    }
                    else
                    {
                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 94 + Margem_Topo, 198, 10));
                    }
                    //
                    if (pessoa == 1)
                    {
                        textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 102 + Margem_Topo, 198, 10));
                    }
                    else
                    {
                        textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 102 + Margem_Topo, 198, 10));
                    }
                    //
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 110 + Margem_Topo, 198, 32));
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    Incrementar = Incrementar - 6;
                    //
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter1.DrawString("ORÇAMENTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 150 + Incrementar + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + Incrementar + Margem_Topo, 198, 24));
                    //
                    Incrementar = Incrementar + 3;
                    //
                    textFormatter2.DrawString(" # Código  Descrição  Qtde.  UN.  Vl.Unit  Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 160 + Margem_Topo, 198, 8));
                    //
                    Incrementar = Incrementar + 3;
                    //
                    DataGridViewRow SelectedRows = dtOrc.Rows[dtOrc.CurrentRow.Index];

                    for (int linha = 0; linha < bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count; linha++)
                    {
                        DataRow dr = bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows[linha];
                        //
                        if (PrimeiraPagina == true)
                        {
                            if (linha == bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                if (dr["descricao"].ToString().Length > 30)
                                {
                                    //graphics.DrawRectangle(pen, 20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20);
                                    if (!dr["descricao"].ToString().Substring(0, 30).Contains(" ") || !dr["descricao"].ToString().Substring(30).Contains(" "))
                                    {
                                        textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString().Insert(30, Environment.NewLine), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20));
                                    }
                                    else
                                    {
                                        textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20));
                                    }
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                }
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 14;
                                //
                                Incrementar = Incrementar + 3;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 168 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 168 + Margem_Topo, 198, 8));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[4].Value.ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                Incrementar = Incrementar + 9;
                                //
                                if (SelectedRows.Cells[6].Value.ToString() != "0" || SelectedRows.Cells[9].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(SelectedRows.Cells[6].Value) + Convert.ToDecimal(SelectedRows.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                if (SelectedRows.Cells[8].Value.ToString() != "0" || SelectedRows.Cells[10].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(SelectedRows.Cells[8].Value) + Convert.ToDecimal(SelectedRows.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                textFormatter2.DrawString("Valor Total Real R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 176 + Margem_Topo, 198, 8));
                                //
                                if (SelectedRows.Cells[3].Value.ToString() != "")
                                {
                                    textFormatter1.DrawString(SelectedRows.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 185 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 185 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                textFormatter1.DrawString("Orçamento nº: " + SelectedRows.Cells[0].Value.ToString() + "   " + SelectedRows.Cells[12].Value.ToString().Remove(10) + "   " + SelectedRows.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 184 + Margem_Topo, 198, 8));
                                //
                                if (SelectedRows.Cells[14].Value.ToString() != "")
                                {
                                    Incrementar = Incrementar + 9;
                                    textFormatter1.DrawString("Data e Hora de Validade: " + SelectedRows.Cells[14].Value.ToString().Remove(10) + "  " + SelectedRows.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 184 + Margem_Topo, 198, 8));
                                }
                                textFormatter1.DrawString("NÃO É VÁLIDO COMO COMPROVANTE\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 194 + Margem_Topo, 198, 16));
                                //
                                Incrementar = Incrementar + 9;
                                //
                                textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 200 + Margem_Topo, 198, 16));
                                //
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                if (dr["descricao"].ToString().Length > 30)
                                {
                                    //graphics.DrawRectangle(pen, 20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20);
                                    if (!dr["descricao"].ToString().Substring(0, 30).Contains(" ") || !dr["descricao"].ToString().Substring(30).Contains(" "))
                                    {
                                        textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString().Insert(30, Environment.NewLine), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20));
                                    }
                                    else
                                    {
                                        textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20));
                                    }
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                }
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 16;
                            }
                            //
                            if (linha == registros - 5 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 4 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 3 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 2 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 1 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                        else
                        {
                            if (linha == bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {

                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                if (dr["descricao"].ToString().Length > 30)
                                {
                                    //graphics.DrawRectangle(pen, 20 + Margem_Esq, Incrementar + 167 + Margem_Topo, 180, 20);
                                    if (!dr["descricao"].ToString().Substring(0, 30).Contains(" ") || !dr["descricao"].ToString().Substring(30).Contains(" "))
                                    {
                                        textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString().Insert(30, Environment.NewLine), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 10 + Margem_Topo, 180, 20));
                                    }
                                    else
                                    {
                                        textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 10 + Margem_Topo, 180, 20));
                                    }
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(20 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                }
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 9;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 14;
                                //
                                Incrementar = Incrementar + 3;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                Incrementar = Incrementar + 9;
                                //
                                if (SelectedRows.Cells[6].Value.ToString() != "0" || SelectedRows.Cells[9].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(SelectedRows.Cells[6].Value) + Convert.ToDecimal(SelectedRows.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                if (SelectedRows.Cells[8].Value.ToString() != "0" || SelectedRows.Cells[10].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(SelectedRows.Cells[8].Value.ToString()) + Convert.ToDecimal(SelectedRows.Cells[10].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                textFormatter2.DrawString("Valor Total Real R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 19 + Margem_Topo, 198, 8));
                                //
                                if (SelectedRows.Cells[3].Value.ToString() != "")
                                {
                                    textFormatter1.DrawString(SelectedRows.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 27 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                else
                                {
                                    textFormatter1.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 27 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 9;
                                }
                                //
                                textFormatter1.DrawString("Orçamento nº: " + SelectedRows.Cells[0].Value.ToString() + "   " + SelectedRows.Cells[12].Value.ToString().Remove(10) + "   " + SelectedRows.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 27 + Margem_Topo, 198, 8));
                                //
                                if (SelectedRows.Cells[14].Value.ToString() != null & SelectedRows.Cells[14].Value.ToString() != "")
                                {
                                    Incrementar = Incrementar + 9;
                                    //
                                    textFormatter1.DrawString("Data e Hora de Validade: " + SelectedRows.Cells[14].Value.ToString().Remove(10) + "  " + SelectedRows.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 27 + Margem_Topo, 198, 8));
                                }
                                textFormatter1.DrawString("NÃO É VÁLIDO COMO COMPROVANTE\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 36 + Margem_Topo, 198, 16));
                                //
                                Incrementar = Incrementar + 9;
                                //
                                textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 42 + Margem_Topo, 198, 16));
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(85 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 198, 7));
                                //
                                Incrementar = Incrementar + 14;
                            }
                            //
                            if (linha == registros - 5 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 4 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 3 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 2 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 1 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 203;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 9, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 9, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 8, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 7, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
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
                    string mes;
                    if (Convert.ToDateTime(SelectedRows.Cells[12].Value).Month < 10)
                    {
                        mes = "0" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Month;
                    }
                    else
                    {
                        mes = Convert.ToDateTime(SelectedRows.Cells[12].Value).Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes + @"\" + SelectedRows.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes + @"\" + SelectedRows.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
            else if (_Trabalho == 5)
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                    byte pessoa;
                    //
                    nome = drPDF["nome"].ToString();
                    fantasia = drPDF["fantasia"].ToString();
                    cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                    ie_rg = drPDF["ie_rg"].ToString();
                    endereco = drPDF["endereco"].ToString();
                    numero = drPDF["numero"].ToString();
                    bairro = drPDF["bairro"].ToString();
                    cidade = drPDF["cidade"].ToString();
                    uf = drPDF["uf"].ToString();
                    cep = drPDF["cep"].ToString();
                    pessoa = Convert.ToByte(drPDF["pessoa"]);
                    //
                    var page = doc.AddPage();
                    //
                    page.Width = 140;
                    page.Height = 842;
                    //                       
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var textFormatter4 = new XTextFormatter(graphics);
                    //
                    var fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                    var fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                    var fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                    var fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    int Incrementar = 0;
                    bool PrimeiraPagina = true;
                    int registros;

                    //
                    if (bllOrcamento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                        registros = 32;
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                        registros = 34;
                    }
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 85 + Margem_Topo, 198, 16);
                    if (nome.Length > 30)
                    {
                        if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                        {
                            textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 128, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 128, 16));
                        }
                        Incrementar = Incrementar + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 128, 8));
                    }
                    //
                    if (fantasia.Length > 30)
                    {
                        if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                        {
                            textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 128, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 128, 16));
                        }
                        Incrementar = Incrementar + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 93 + Margem_Topo, 128, 8));
                    }
                    //
                    textFormatter2.DrawString(cpf_cnpj + "   " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 101 + Margem_Topo, 198, 8));
                    //
                    textFormatter2.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 109 + Margem_Topo, 198, 24));
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    Incrementar = Incrementar - 15;
                    //
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter1.DrawString("ORÇAMENTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 150 + Incrementar + Margem_Topo, 128, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + Incrementar + Margem_Topo, 128, 24));
                    //
                    textFormatter2.DrawString("#Cód. Descrição Qtde. UN. Vl.Unit Vl.Total", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 160 + Margem_Topo, 198, 8));
                    //
                    Incrementar = Incrementar + 1;
                    //
                    DataGridViewRow SelectedRows = dtOrc.Rows[dtOrc.CurrentRow.Index];

                    for (int linha = 0; linha < bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count; linha++)
                    {
                        DataRow dr = bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows[linha];
                        //
                        if (PrimeiraPagina == true)
                        {
                            if (linha == bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(45 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(55 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 14;
                                //
                                Incrementar = Incrementar + 5;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 128, 8));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[4].Value.ToString()).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 128, 8));
                                Incrementar = Incrementar + 8;
                                //
                                if (SelectedRows.Cells[6].Value.ToString() != "0" || SelectedRows.Cells[9].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(SelectedRows.Cells[6].Value) + Convert.ToDecimal(SelectedRows.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 128, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (SelectedRows.Cells[8].Value.ToString() != "0" || SelectedRows.Cells[10].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(SelectedRows.Cells[8].Value) + Convert.ToDecimal(SelectedRows.Cells[10].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 128, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                textFormatter2.DrawString("Valor Total Real R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 175 + Margem_Topo, 128, 8));
                                //
                                if (SelectedRows.Cells[3].Value.ToString() != "")
                                {
                                    textFormatter2.DrawString(SelectedRows.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                else
                                {
                                    textFormatter2.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                //
                                textFormatter2.DrawString("Orç nº: " + SelectedRows.Cells[0].Value.ToString() + " " + SelectedRows.Cells[12].Value.ToString().Remove(10) + " " + SelectedRows.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                //
                                if (SelectedRows.Cells[14].Value.ToString() != "")
                                {
                                    Incrementar = Incrementar + 8;
                                    textFormatter2.DrawString("Data e Hora de Validade: " + SelectedRows.Cells[14].Value.ToString().Remove(10) + "  " + SelectedRows.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 8));
                                }
                                Incrementar = Incrementar + 8;
                                textFormatter2.DrawString("NÃO É VÁLIDO COMO COMPROVANTE\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 183 + Margem_Topo, 198, 16));
                                //
                                Incrementar = Incrementar + 8;
                                //
                                textFormatter2.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 191 + Margem_Topo, 198, 16));
                                //
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 167 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(45 + Margem_Esq, Incrementar + 174 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(55 + Margem_Esq, Incrementar + 174 + Margem_Topo, 85, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 174 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 14;
                            }
                            //
                            if (linha == registros - 5 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 4 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 3 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 2 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 1 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                        }
                        else
                        {
                            if (linha == bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count - 1)//Se chegar no ultimo registro execute isso
                            {

                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(45 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(55 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 14;
                                //
                                Incrementar = Incrementar + 5;
                                //
                                textFormatter2.DrawString("Qtde. total de itens", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToInt16(bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 128, 8));
                                //
                                textFormatter2.DrawString("Valor Total R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[4].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 128, 8));
                                Incrementar = Incrementar + 8;
                                //
                                if (SelectedRows.Cells[6].Value.ToString() != "0" || SelectedRows.Cells[9].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Descontos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString("-" + (Convert.ToDecimal(SelectedRows.Cells[6].Value) + Convert.ToDecimal(SelectedRows.Cells[9].Value)).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 128, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                if (SelectedRows.Cells[8].Value.ToString() != "0" || SelectedRows.Cells[10].Value.ToString() != "0")
                                {
                                    textFormatter2.DrawString("Acréscimos R$", fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                    //
                                    textFormatter3.DrawString((Convert.ToDecimal(SelectedRows.Cells[8].Value.ToString()) + Convert.ToDecimal(SelectedRows.Cells[10].Value.ToString())).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 128, 8));
                                    Incrementar = Incrementar + 8;
                                }
                                //
                                textFormatter2.DrawString("Valor Total Real R$", fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 198, 8));
                                //
                                textFormatter3.DrawString(Convert.ToDecimal(SelectedRows.Cells[11].Value).ToString("n2", new CultureInfo("pt-BR")), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 18 + Margem_Topo, 128, 8));
                                //
                                if (SelectedRows.Cells[3].Value.ToString() != "")
                                {
                                    textFormatter2.DrawString(SelectedRows.Cells[3].Value.ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                else
                                {
                                    textFormatter2.DrawString("CONSUMIDOR NÃO IDENTIFICADO", fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                    Incrementar = Incrementar + 7;
                                }
                                //
                                textFormatter2.DrawString("Orç nº: " + SelectedRows.Cells[0].Value.ToString() + " " + SelectedRows.Cells[12].Value.ToString().Remove(10) + " " + SelectedRows.Cells[13].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                //
                                if (SelectedRows.Cells[14].Value.ToString() != null & SelectedRows.Cells[14].Value.ToString() != "")
                                {
                                    Incrementar = Incrementar + 8;
                                    textFormatter2.DrawString("Data e Hora de Validade: " + SelectedRows.Cells[14].Value.ToString().Remove(10) + "  " + SelectedRows.Cells[15].Value.ToString(), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 8));
                                }
                                Incrementar = Incrementar + 8;
                                textFormatter2.DrawString("NÃO É VÁLIDO COMO COMPROVANTE\n" + bllConfiguracaoSistema.Sel_Mensagem_Pdv(bllConexao._Codigo_Conexao), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 25 + Margem_Topo, 198, 16));
                                //
                                Incrementar = Incrementar + 8;
                                //
                                textFormatter3.DrawString("Sistema SEVEN - Tel/Zap: (75) 98271-6595", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 33 + Margem_Topo, 198, 16));
                            }
                            else
                            {
                                textFormatter2.DrawString(Convert.ToUInt16(dr["id_item"]).ToString("D3", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //  
                                textFormatter2.DrawString(dr["id_produto"].ToString() + "   " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(15 + Margem_Esq, Incrementar + 10 + Margem_Topo, 198, 7));
                                //         
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter1.DrawString(Convert.ToDecimal(dr["quantidade"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 45, 7));
                                //
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 50, 8);
                                textFormatter1.DrawString(dr["um"] + "  X  " + Convert.ToDecimal(dr["valor_unitario"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(45 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                //
                                //graphics.DrawRectangle(pen, 169 + Margem_Esq, AumentoDeLinhaFixo + 174 + Margem_Topo, 35, 8);
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 7;
                                //graphics.DrawRectangle(pen, 2 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Desconto: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 85, 7));
                                //graphics.DrawRectangle(pen, 85 + Margem_Esq, Incrementar + AumentoDeLinhaFixo + 174 + Margem_Topo, 85, 7);
                                textFormatter2.DrawString("Acréscimo: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(55 + Margem_Esq, Incrementar + 17 + Margem_Topo, 65, 7));
                                textFormatter3.DrawString(Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 17 + Margem_Topo, 128, 7));
                                //
                                Incrementar = Incrementar + 14;
                            }
                            //
                            if (linha == registros - 5 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 3)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 4 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 2)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 3 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros - 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 2 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count == registros)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
                            }
                            else if (linha == registros - 1 & bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRows.Cells[0].Value.ToString()).Rows.Count >= registros + 1)
                            {
                                PrimeiraPagina = false;
                                Incrementar = 0;
                                page = doc.AddPage();
                                page.Width = 140;
                                page.Height = 842;
                                registros = registros + 39;
                                Margem_Topo = 0;
                                //
                                graphics = XGraphics.FromPdfPage(page);
                                textFormatter1 = new XTextFormatter(graphics);
                                textFormatter2 = new XTextFormatter(graphics);
                                textFormatter3 = new XTextFormatter(graphics);
                                textFormatter4 = new XTextFormatter(graphics);
                                //
                                fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                                fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                                fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                                fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                                //
                                textFormatter1.Alignment = XParagraphAlignment.Center;
                                textFormatter2.Alignment = XParagraphAlignment.Left;
                                textFormatter3.Alignment = XParagraphAlignment.Right;
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
                    string mes;
                    if (Convert.ToDateTime(SelectedRows.Cells[12].Value).Month < 10)
                    {
                        mes = "0" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Month;
                    }
                    else
                    {
                        mes = Convert.ToDateTime(SelectedRows.Cells[12].Value).Month.ToString();
                    }
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes);
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes + @"\" + SelectedRows.Cells[0].Value.ToString() + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(SelectedRows.Cells[12].Value).Year + mes + @"\" + SelectedRows.Cells[0].Value.ToString() + ".pdf");
                    }
                }
            }
        }

        private void btnGerarCupom_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            using (FrmInfImpressao Imp = new FrmInfImpressao(29))
            {
                if (Imp.ShowDialog() == DialogResult.OK)
                {
                    pgbProgresso.Visible = true;
                    lblProgresso.Visible = true;
                    if (bllOrcamento._Tipo_Impressao == "PDF A4")
                    {
                        _Trabalho = 3;
                        Gerar_PDF();
                    }
                    else if (bllOrcamento._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                    {
                        _Trabalho = 4;
                        Gerar_PDF();
                    }
                    else
                    {
                        _Trabalho = 5;
                        Gerar_PDF();
                    }
                    bckwIndeterminado.RunWorkerAsync();
                    pgbProgresso.MarqueeAnimationSpeed = 2;
                    this.Cursor = Cursors.WaitCursor;
                    dtOrc.Enabled = false;
                    dtOrc.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveBorder;
                    grbBox1.Enabled = false;
                    grbBox2.Enabled = false;
                    btnPesquisar.Enabled = false;
                    picbInterrogacao2.Enabled = false;
                    picbInterrogacao.Enabled = false;
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnVendaOrcamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVendaOrcamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVendaOrcamento_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEnviar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                pEnabled.Enabled = false;
                DataGridViewRow SelectedRow = dtOrc.Rows[dtOrc.CurrentRow.Index];
                //
                DataRow dr = bllOrcamento.Sel_Orcamento_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                string email;
                //
                if (dr["id_consumidor"].ToString() != "0")
                {
                    if (bllClieCons.Sel_Cliente_Codigo(dr["id_consumidor"].ToString()) == null)
                    {
                        MessageBox.Show("O Cliente/Consumidor não foi encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        email = null;
                    }
                    else
                    {
                        dr = bllClieCons.Sel_Cliente_Codigo(dr["id_consumidor"].ToString()).Rows[0];
                        //
                        if (dr["email"].ToString() == "" || dr["email"].ToString() == null)
                        {
                            MessageBox.Show("O Cliente/Consumidor não possui um e-mail cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            email = null;
                        }
                        else
                        {
                            email = dr["email"].ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("O Orçamento selecionado não possui nenhum Cliente/Consumidor informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    email = null;
                }
                //
                dr = bllOrcamento.Sel_Orcamento_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                using (FrmInfImpressao Imp = new FrmInfImpressao(29))
                {
                    if (Imp.ShowDialog() == DialogResult.OK)
                    {
                        if (bllOrcamento._Tipo_Impressao == "PDF A4")
                        {
                            _Trabalho = 3;
                            Gerar_PDF();
                        }
                        else if (bllOrcamento._Tipo_Impressao == "PDF Impressora Térmica(80mm)")
                        {
                            _Trabalho = 4;
                            Gerar_PDF();
                        }
                        else
                        {
                            _Trabalho = 5;
                            Gerar_PDF();
                        }
                    }
                    else
                    {
                        pEnabled.Enabled = true;
                        return;
                    }
                }
                //
                string mes;
                if (DateTime.Now.Month < 10)
                {
                    mes = "0" + DateTime.Now.Month;
                }
                else
                {
                    mes = DateTime.Now.Month.ToString();
                }
                //
                pEnabled.Enabled = false;
                using (FrmUtilEnviarEmail Email = new FrmUtilEnviarEmail(2, _Cod_PDV_Computador, _Usuario, @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Orcamento\" + Convert.ToDateTime(dr["data"]).Year + mes + @"\" + dr["id_orcamento"].ToString() + ".pdf;", "Atenciosamente, " + bllMinhaEmpresa.Sel_Nome_Empresa() + " - " + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ(), "Referente ao orçamento de número " + dr["id_orcamento"].ToString(), email))
                {
                    if (Email.ShowDialog() == DialogResult.Abort)
                    {
                        dtOrc.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviar.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void btnInformarCPFCNPJ_Click(object sender, EventArgs e)
        {
            pEnabled.Enabled = false;
            try
            {
                DataGridViewRow SelectedRow = dtOrc.Rows[dtOrc.CurrentRow.Index];
                //
                DataRow dr = bllClieCons.Sel_Cliente_Codigo(SelectedRow.Cells[1].Value.ToString()).Rows[0];
                //
                string nome_consumidor = dr["nome"].ToString();
                //
                string cpfcnpj = dr["cpf_cnpj"].ToString();
                //
                if (cpfcnpj == null || cpfcnpj == "")
                {
                    cpfcnpj = "";
                }
                else
                {
                    cpfcnpj = dr["cpf_cnpj"].ToString();
                }
                //
                string celular;
                if (dr["celular"].ToString() == null || dr["celular"].ToString() == "")
                {
                    MessageBox.Show("Este consumidor não possui celular cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //
                    using (FrmCadCelular Cel = new FrmCadCelular(_Usuario, _Cod_PDV_Computador, 1))
                    {
                        if (Cel.ShowDialog() == DialogResult.OK)
                        {
                            celular = bllOrcamento._Celular_CadCelular_Tabela;
                        }
                        else
                        {
                            celular = null;
                            pEnabled.Enabled = true;
                            return;
                        }
                    }
                }
                else
                {
                    celular = dr["celular"].ToString();
                }
                //
                dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                //
                celular = celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                //
                string complemento = dr["complemento"].ToString();
                //
                if (complemento == null || complemento == "")
                {
                    complemento = "";
                }
                else
                {
                    complemento = dr["complemento"].ToString() + ", ";
                }
                //
                string mensagem = "*ORÇAMENTO*\n\n*" + dr["nome"].ToString() + "*\n" + dr["cpf_cnpj"].ToString() + "\n" + dr["ie_rg"].ToString() + "\n" + dr["endereco"].ToString() + ", " + dr["numero"].ToString() + "\n" + complemento + dr["bairro"].ToString() + "\n" + dr["cidade"].ToString() + ", " + dr["uf"].ToString() + ", " + dr["cep"].ToString() + "\n\n*CLIENTE/CONSUMIDOR*\nNOME:\n" + nome_consumidor + "\nCPF / CNPJ:\n" + cpfcnpj + "\n\n*Itens:*\n";
                //
                for (int linha = 0; linha < bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRow.Cells[0].Value.ToString()).Rows.Count; linha++)
                {
                    dr = bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRow.Cells[0].Value.ToString()).Rows[linha];
                    //
                    mensagem = mensagem + "\n" + dr["id_item"].ToString() + " - " + dr["descricao"].ToString() + "\n             Qtde.: " + Convert.ToDecimal(dr["quantidade"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + "   -   " + dr["um"].ToString() + " X " + Convert.ToDecimal(dr["valor_unitario"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + "   -   " + Convert.ToDecimal(dr["valor_total"].ToString()).ToString("n2", new CultureInfo("pt-BR")) + "\n                          Desc.: " + (Convert.ToDecimal(dr["valor_desconto"]) + Convert.ToDecimal(dr["valor_desconto_item"])).ToString("n2", new CultureInfo("pt-BR")) + "  -  Acresc.: " + (Convert.ToDecimal(dr["valor_acrescimo"]) + Convert.ToDecimal(dr["valor_acrescimo_item"])).ToString("n2", new CultureInfo("pt-BR")) + "  -  Vl. Total: " + Convert.ToDecimal(dr["valor_total_a_desc_acresc"]).ToString("n2", new CultureInfo("pt-BR"));
                }
                //
                dr = bllOrcamento.Sel_Orcamento_Codigo(SelectedRow.Cells[0].Value.ToString()).Rows[0];
                //
                mensagem = mensagem + "\n\nQtde. total de itens: " + Convert.ToInt16(bllOrcamento.Sel_Itens_Orcamento_Orc(SelectedRow.Cells[0].Value.ToString()).Rows.Count).ToString("D3", new CultureInfo("pt-BR")) + "\nValor Total R$: " + Convert.ToDecimal(dr["valor"]).ToString("n2", new CultureInfo("pt-BR"));
                //
                if (dr["valor_desconto_item"].ToString() != "0" || dr["valor_desconto"].ToString() != "0")
                {
                    mensagem = mensagem + "\nDescontos R$: -" + (Convert.ToDecimal(dr["valor_desconto_item"]) + Convert.ToDecimal(dr["valor_desconto"])).ToString("n2", new CultureInfo("pt-BR"));
                }
                //
                if (dr["valor_acrescimo_item"].ToString() != "0" || dr["valor_acrescimo"].ToString() != "0")
                {
                    mensagem = mensagem + "\nAcréscimos R$: " + (Convert.ToDecimal(dr["valor_acrescimo_item"]) + Convert.ToDecimal(dr["valor_acrescimo"])).ToString("n2", new CultureInfo("pt-BR"));
                }
                //
                mensagem = mensagem + "\nValor Total Real R$: *" + Convert.ToDecimal(dr["valor_real"]).ToString("n2", new CultureInfo("pt-BR")) + "*";
                //
                mensagem = mensagem + "\nOrçamento nº: *" + SelectedRow.Cells[0].Value.ToString() + "*   " + dr["data"].ToString().Remove(10) + "   " + dr["hora"].ToString();
                //
                if (dr["data_validade"].ToString() != "")
                {
                    mensagem = mensagem + "\nData e Hora de Validade: " + dr["data_validade"].ToString().Remove(10) + "  " + dr["hora_validade"].ToString();
                }
                //
                mensagem = mensagem + "\n\n*Sistema SEVEN*";
                //
                Clipboard.SetText(mensagem);
                //
                string encodedMessage = HttpUtility.UrlEncode(mensagem);
                //
                string url = $"https://wa.me/55{celular}?text={encodedMessage}";
                //
                bllRegistroAtividades.Salvar("ENVIO DE MENSAGEM WHATSAPP DE ORCAMENTO.", "ORCAMENTO", dr["id_orcamento"].ToString(), _Usuario, _Cod_PDV_Computador);
                //
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviar.");
                }
            }
            pEnabled.Enabled = true;
        }

        private void lblValorDescontos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor dos Descontos (R$): " + Convert.ToDecimal(lblValorDescontos.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblValorAcrescimos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor dos Acréscimos (R$): " + Convert.ToDecimal(lblValorAcrescimos.Text).ToString("n2", new CultureInfo("pt-BR")), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
